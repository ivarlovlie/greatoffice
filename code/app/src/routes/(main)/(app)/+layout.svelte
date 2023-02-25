<script lang="ts">
  import {
    ChevronUpDownIcon,
    MagnifyingGlassIcon,
    Bars3CenterLeftIcon,
    XMarkIcon,
    HomeIcon,
    MegaphoneIcon,
    FolderOpenIcon,
    QueueListIcon,
    CalendarIcon,
  } from "$components/icons";
  import { AccountService } from "$services/account-service";
  import {
    Dialog,
    Menu,
    MenuButton,
    MenuItem,
    MenuItems,
    Transition,
    TransitionChild,
    TransitionRoot,
  } from "@rgossiaux/svelte-headlessui";
  import { DialogPanel } from "@developermuch/dev-svelte-headlessui";
  import { Input, Notification } from "$components";
  import { goto } from "$app/navigation";
  import { page } from "$app/stores";
  import { onMount } from "svelte";
  import { fgs, sgs } from "$utilities/global-state";

  const accountService = AccountService.resolve();
  const session = {
    profile: {
      username: "Brukernavn",
      displayName: "epost@adresse.no",
    },
  };

  let sidebarOpen = false;
  let sidebarSearchValue: string | undefined;
  let showEmailValidatedNotif = false;

  onMount(() => {
    showEmailValidatedNotif =
      fgs("showEmailValidatedAlertWhenLoggedIn") === "true";
    if (showEmailValidatedNotif)
      sgs("showEmailValidatedAlertWhenLoggedIn", false);
  });

  function sign_out() {
    accountService.end_session(() => goto("/sign-in"));
  }
  const navigationItems = [
    {
      href: "/home",
      name: "Home",
      icon: HomeIcon,
    },
    {
      href: "/projects",
      name: "Projects",
      icon: CalendarIcon,
    },
    {
      href: "/tickets",
      name: "Tickets",
      icon: MegaphoneIcon,
    },
    {
      href: "/todo",
      name: "Todo",
      icon: QueueListIcon,
    },
    {
      href: "/wiki",
      name: "Wiki",
      icon: FolderOpenIcon,
    },
  ];
</script>

{#if showEmailValidatedNotif}
  <Notification
    title="Email successfully validated"
    subtitle="Because of this, you now have gained access to more functionality"
    show={true}
  />
{/if}

<div class="min-h-full">
  <!-- Mobile sidebar -->
  <TransitionRoot show={sidebarOpen}>
    <Dialog
      as="div"
      class="relative z-40 lg:hidden"
      on:close={() => (sidebarOpen = false)}
    >
      <TransitionChild
        as="div"
        enter="transition-opacity ease-linear duration-300"
        enterFrom="opacity-0"
        enterTo="opacity-100"
        leave="transition-opacity ease-linear duration-300"
        leaveFrom="opacity-100"
        leaveTo="opacity-0"
      >
        <div class="fixed inset-0 bg-gray-600 bg-opacity-75" />
      </TransitionChild>

      <div class="fixed inset-0 z-40 flex">
        <TransitionChild
          as="div"
          enter="transition ease-in-out duration-300 transform"
          enterFrom="-translate-x-full"
          enterTo="translate-x-0"
          leave="transition ease-in-out duration-300 transform"
          leaveFrom="translate-x-0"
          leaveTo="-translate-x-full"
        >
          <DialogPanel
            class="relative flex w-full max-w-xs flex-1 flex-col bg-white pt-5 pb-4"
          >
            <TransitionChild
              as="div"
              enter="ease-in-out duration-300"
              enterFrom="opacity-0"
              enterTo="opacity-100"
              leave="ease-in-out duration-300"
              leaveFrom="opacity-100"
              leaveTo="opacity-0"
            >
              <div class="absolute top-0 right-0 -mr-12 pt-2">
                <button
                  type="button"
                  class="ml-1 flex h-10 w-10 items-center justify-center rounded-full focus:outline-none focus:ring-2 focus:ring-inset focus:ring-white"
                  on:click={() => (sidebarOpen = false)}
                >
                  <span class="sr-only">Close sidebar</span>
                  <XMarkIcon class="text-white" aria-hidden="true" />
                </button>
              </div>
            </TransitionChild>
            <div class="mt-5 h-0 flex-1 overflow-y-auto">
              <nav class="px-2">
                <div class="space-y-1">
                  {#each navigationItems as item}
                    {@const current = $page.url.pathname.startsWith(item.href)}
                    <a
                      href={item.href}
                      aria-current={current ? "page" : undefined}
                      class="group flex items-center px-2 py-2 text-base leading-5 font-medium rounded-md
                      {current
                        ? 'bg-gray-100 text-gray-900'
                        : 'text-gray-600 hover:text-gray-900 hover:bg-gray-50'}"
                    >
                      <svelte:component
                        this={item.icon}
                        class="mr-3 flex-shrink-0 h-6 w-6 {current
                          ? 'text-gray-500'
                          : 'text-gray-400 group-hover:text-gray-500'}"
                        aria-hidden="true"
                      />
                      {item.name}
                    </a>
                  {/each}
                </div>
              </nav>
            </div>
          </DialogPanel>
        </TransitionChild>
        <div class="w-14 flex-shrink-0" aria-hidden="true">
          <!-- Dummy element to force sidebar to shrink to fit close icon -->
        </div>
      </div>
    </Dialog>
  </TransitionRoot>

  <!-- Static sidebar for desktop -->
  <div
    class="hidden lg:fixed lg:inset-y-0 lg:flex lg:w-64 lg:flex-col lg:border-r lg:border-gray-200 lg:bg-gray-100 lg:pb-4"
  >
    <div class="flex h-0 flex-1 p-3 flex-col overflow-y-auto">
      <!-- User account dropdown -->
      <Menu class="relative inline-block text-left">
        <MenuButton
          class="group w-full rounded-md bg-gray-100 px-3.5 py-2 text-left text-sm font-medium text-gray-700 hover:bg-gray-200 focus:outline-none focus:ring-2 focus:ring-teal-500 focus:ring-offset-2 focus:ring-offset-gray-100"
        >
          <span class="flex w-full items-center justify-between">
            <span class="flex min-w-0 items-center justify-between space-x-3">
              <span class="flex min-w-0 flex-1 flex-col">
                <span class="truncate text-sm font-medium text-gray-900">
                  {session.profile.username}
                </span>
                <span class="truncate text-sm text-gray-500"
                  >{session.profile.displayName}</span
                >
              </span>
            </span>
            <ChevronUpDownIcon
              class="flex-shrink-0 text-gray-400 group-hover:text-gray-500"
              aria-hidden="true"
            />
          </span>
        </MenuButton>
        <Transition
          leave="transition ease-in duration-75"
          enter="transition ease-out duration-100"
          enterFrom="transform opacity-0 scale-95"
          enterTo="transform opacity-100 scale-100"
          leaveFrom="transform opacity-100 scale-100"
          leaveTo="transform opacity-0 scale-95"
          as="div"
        >
          <MenuItems
            class="absolute right-0 left-0 z-10 mt-1 origin-top divide-y divide-gray-200 rounded-md bg-white shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none"
          >
            <div class="py-1">
              <MenuItem>
                <a
                  href="/profile"
                  class="text-gray-700 block px-4 py-2 text-sm hover:text-gray-900 hover:bg-gray-100"
                >
                  View profile
                </a>
              </MenuItem>
              <MenuItem>
                <a
                  href="/settings"
                  class="text-gray-700 block px-4 py-2 text-sm hover:text-gray-900 hover:bg-gray-100"
                >
                  Settings
                </a>
              </MenuItem>
            </div>
            <div class="py-1">
              <MenuItem>
                <span
                  on:click={() => sign_out()}
                  class="text-gray-700 block px-4 py-2 text-sm hover:bg-red-200 hover:text-red-900 cursor-pointer"
                >
                  Sign out
                </span>
              </MenuItem>
            </div>
          </MenuItems>
        </Transition>
      </Menu>
      <!-- Sidebar Search -->
      <div class="mt-3 hidden">
        <label for="search" class="sr-only">Search</label>
        <div class="relative mt-1 rounded-md shadow-sm">
          <Input
            type="search"
            name="search"
            icon={MagnifyingGlassIcon}
            placeholder="Search"
            bind:value={sidebarSearchValue}
          />
        </div>
      </div>
      <!-- Navigation -->
      <nav class="mt-5">
        <div class="space-y-1">
          {#each navigationItems as item}
            {@const current = $page.url.pathname.startsWith(item.href)}
            <a
              href={item.href}
              aria-current={current ? "page" : undefined}
              class="group flex items-center px-2 py-2 text-base leading-5 font-medium rounded-md
                      {current
                ? 'bg-gray-200 text-gray-900'
                : 'text-gray-700 hover:text-gray-900 hover:bg-gray-50'}"
            >
              <svelte:component
                this={item.icon}
                class="mr-3 flex-shrink-0 h-6 w-6 {current
                  ? 'text-gray-500'
                  : 'text-gray-400 group-hover:text-gray-500'}"
                aria-hidden="true"
              />
              {item.name}
            </a>
          {/each}
        </div>
      </nav>
    </div>
  </div>

  <!-- Main column -->
  <div class="flex flex-col lg:pl-64">
    <!-- Search header -->
    <div
      class="sticky top-0 z-10 flex h-16 flex-shrink-0 border-b border-gray-200 bg-white lg:hidden"
    >
      <button
        type="button"
        class="border-r border-gray-200 px-4 text-gray-500 focus:outline-none focus:ring-2 focus:ring-inset focus:ring-teal-500 lg:hidden"
        on:click={() => (sidebarOpen = true)}
      >
        <span class="sr-only">Open sidebar</span>
        <Bars3CenterLeftIcon aria-hidden="true" />
      </button>
      <div class="flex flex-1 justify-between px-4 sm:px-6 lg:px-8">
        <div class="flex flex-1">
          <form class="flex w-full md:ml-0" action="#" method="GET">
            <label for="search-field" class="sr-only">Search</label>
            <div
              class="relative w-full text-gray-400 focus-within:text-gray-600"
            >
              <Input
                bind:value={sidebarSearchValue}
                icon={MagnifyingGlassIcon}
                id="search-field"
                name="search-field"
                placeholder="Search"
                type="search"
              />
            </div>
          </form>
        </div>
        <div class="flex items-center">
          <!-- Profile dropdown -->
          <Menu as="div" class="relative ml-3">
            <div>
              <MenuButton
                class="flex max-w-xs items-center rounded-full bg-white text-sm focus:outline-none focus:ring-2 focus:ring-teal-500 focus:ring-offset-2"
              >
                <span class="sr-only">Open user menu</span>
              </MenuButton>
            </div>
            <Transition
              enterFrom="transform opacity-0 scale-95"
              enterTo="transform opacity-100 scale-100"
              leaveFrom="transform opacity-100 scale-100"
              leaveTo="transform opacity-0 scale-95"
              as="div"
            >
              <MenuItems
                class="absolute right-0 z-10 mt-2 w-48 origin-top-right divide-y divide-gray-200 rounded-md bg-white shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none"
              >
                <div class="py-1">
                  <MenuItem>
                    <a
                      href="/profile"
                      class="text-gray-700 block px-4 py-2 text-sm"
                    >
                      View profile
                    </a>
                  </MenuItem>
                  <MenuItem>
                    <a
                      href="/settings"
                      class="text-gray-700 block px-4 py-2 text-sm hover:text-gray-900 hover:bg-gray-100"
                    >
                      Settings
                    </a>
                  </MenuItem>
                  <div class="py-1">
                    <MenuItem>
                      <span
                        on:click={() => sign_out()}
                        class="text-gray-700 block px-4 py-2 text-sm"
                      >
                        Sign out
                      </span>
                    </MenuItem>
                  </div>
                </div>
              </MenuItems>
            </Transition>
          </Menu>
        </div>
      </div>
    </div>
    <main class="flex-1 p-3">
      <slot />
    </main>
  </div>
</div>
