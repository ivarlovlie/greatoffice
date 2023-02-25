<script lang="ts">
    import { Button, ProjectStatusBadge, Input } from "$components";
    import type { Project } from "$models/projects/Project";
    import { createTable, Subscribe, Render } from "svelte-headless-table";
    import { addSortBy, addTableFilter } from "svelte-headless-table/plugins";
    import { writable, type Writable } from "svelte/store";
    import { ChevronDownIcon, ChevronUpIcon, ChevronUpDownIcon, MagnifyingGlassIcon, FunnelIcon } from "$components/icons";
    import LL from "$i18n/i18n-svelte";
    import { goto } from "$app/navigation";

    const projects: Writable<Array<Project>> = writable([]);

    function on_open_project(event) {
        if (event.code && (event.code !== "Enter" || event.code !== "Space")) return;
        const name = event.target.innerText;
        const projectId = $projects.find((p) => p.name === name).id;
        goto("/projects/" + projectId);
    }

    const table = createTable(projects, {
        sort: addSortBy(),
        filter: addTableFilter(),
    });

    const columns = table.createColumns([
        table.column({ header: $LL.name(), accessor: "name" }),
        table.column({ header: "Status", accessor: "status" }),
        table.column({ header: "Start", accessor: "start" }),
        table.column({ header: "Description", accessor: "description", plugins: { sort: { disable: true } } }),
    ]);

    const { headerRows, rows, tableAttrs, tableBodyAttrs, pluginStates } = table.createViewModel(columns);
    const { filterValue } = pluginStates.filter;
</script>

<div class="sm:flex sm:items-center">
    <div class="sm:flex-auto">
        <h1 class="text-xl font-semibold text-gray-900">Projects</h1>
        <p class="mt-2 text-sm text-gray-700">A list of all the projects in your organsation.</p>
    </div>
    <div class="mt-4 sm:mt-0 sm:ml-16 inline-flex gap-1 sm:flex-none">
        <Input icon={MagnifyingGlassIcon} placeholder="Search" bind:value={$filterValue} />
        <Button text="Create project" href="/projects/create" />
    </div>
</div>
<div class="-mx-2 mt-6 rounded-md shadow overflow-auto max-h-[80vh] sm:-mx-6 md:mx-0">
    <table {...$tableAttrs} class="min-w-full divide-y divide-gray-300">
        <thead class="bg-gray-50">
            {#each $headerRows as headerRow (headerRow.id)}
                <Subscribe rowAttrs={headerRow.attrs()} let:rowAttrs>
                    <tr {...rowAttrs} class="shadow-sm">
                        {#each headerRow.cells as cell (cell.id)}
                            <Subscribe attrs={cell.attrs()} let:attrs props={cell.props()} let:props>
                                <th
                                    {...attrs}
                                    scope="col"
                                    class="sticky top-0 bg-gray-50 bg-opacity-100 whitespace-nowrap px-2 py-3.5 text-left text-sm font-semibold text-gray-900"
                                >
                                    <div class="group inline-flex">
                                        <Render of={cell.render()} />
                                        <span
                                            on:click={props.sort.toggle}
                                            on:keypress={props.sort.toggle}
                                            class="{props.sort.disabled
                                                ? 'bg-gray-200 text-gray-900 group-hover:bg-gray-300'
                                                : 'invisible text-gray-400 group-hover:visible group-focus:visible'}
                          {props.sort.disabled ? '' : 'cursor-pointer'}
                          ml-2 flex-none rounded"
                                        >
                                            {#if props.sort.order === "asc"}
                                                <ChevronUpIcon />
                                            {:else if props.sort.order === "desc"}
                                                <ChevronDownIcon />
                                            {:else if !props.sort.disabled}
                                                <ChevronUpDownIcon />
                                            {/if}
                                        </span>
                                        {#if cell.id === "status"}
                                            <span
                                                class="invisible text-gray-400 cursor-pointer group-hover:visible group-focus:visible ml-2 flex-none rounded"
                                            >
                                                <FunnelIcon />
                                            </span>
                                        {/if}
                                    </div>
                                </th>
                            </Subscribe>
                        {/each}
                    </tr>
                </Subscribe>
            {/each}
        </thead>
        <tbody {...$tableBodyAttrs} class="divide-y divide-gray-200 bg-white">
            {#each $rows as row (row.id)}
                <Subscribe rowAttrs={row.attrs()} let:rowAttrs>
                    <tr {...rowAttrs}>
                        {#each row.cells as cell (cell.id)}
                            {@const materialisedCell = cell.render()}
                            <Subscribe attrs={cell.attrs()} let:attrs>
                                <td {...attrs} class="whitespace-nowrap px-2 py-2 text-sm">
                                    {#if cell.id === "name"}
                                        <span class="link" title="Open project" on:click={on_open_project} on:keypress={on_open_project}>
                                            <Render of={materialisedCell} />
                                        </span>
                                    {:else if cell.id === "status"}
                                        <ProjectStatusBadge status={materialisedCell.toString()} />
                                    {:else}
                                        <Render of={materialisedCell} />
                                    {/if}
                                </td>
                            </Subscribe>
                        {/each}
                    </tr>
                </Subscribe>
            {/each}
        </tbody>
    </table>
</div>
