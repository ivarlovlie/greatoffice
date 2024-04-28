<script lang="ts">
    import {Input, Button, Switch} from "$components";
</script>

<div class="relative mx-auto max-w-4xl md:px-8 xl:px-0">
    <div class="pt-10 pb-16">
        <div class="px-4 sm:px-6 md:px-0">
            <h1 class="text-3xl font-bold tracking-tight text-gray-900">Settings</h1>
        </div>
        <div class="px-4 sm:px-6 md:px-0">
            <div class="py-6">
                <!-- Tabs -->
                <div class="lg:hidden">
                    <label for="selected-tab" class="sr-only">Select a tab</label>
                    <select
                            id="selected-tab"
                            name="selected-tab"
                            class="mt-1 block w-full rounded-md border-gray-300 py-2 pl-3 pr-10 text-base focus:border-purple-500 focus:outline-none focus:ring-purple-500 sm:text-sm"
                    >
                        <option selected>General</option>

                        <option>Password</option>

                        <option>Notifications</option>

>

                        <option>Billing</option>

                        <option>Team Members</option>
                    </select>
                </div>
                <div class="hidden lg:block">
                    <div class="border-b border-gray-200">
                        <nav class="-mb-px flex space-x-8">
                            <!-- Current: "border-purple-500 text-purple-600", Default: "border-transparent text-gray-500 hover:border-gray-300 hover:text-gray-700" -->
                            <a href="#"
                               class="border-purple-500 text-purple-600 whitespace-nowrap py-4 px-1 border-b-2 font-medium text-sm"
                            >General</a
                            >

                            <a
                                    href="#"
                                    class="border-transparent text-gray-500 hover:border-gray-300 hover:text-gray-700 whitespace-nowrap py-4 px-1 border-b-2 font-medium text-sm"
                            >Password</a
                            >

                            <a
                                    href="#"
                                    class="border-transparent text-gray-500 hover:border-gray-300 hover:text-gray-700 whitespace-nowrap py-4 px-1 border-b-2 font-medium text-sm"
                            >Notifications</a
                            >

                            <a
                                    href="#"
                                    class="border-transparent text-gray-500 hover:border-gray-300 hover:text-gray-700 whitespace-nowrap py-4 px-1 border-b-2 font-medium text-sm"
                            >Plan</a
                            >

                            <a
                                    href="#"
                                    class="border-transparent text-gray-500 hover:border-gray-300 hover:text-gray-700 whitespace-nowrap py-4 px-1 border-b-2 font-medium text-sm"
                            >Billing</a
                            >

                            <a
                                    href="#"
                                    class="border-transparent text-gray-500 hover:border-gray-300 hover:text-gray-700 whitespace-nowrap py-4 px-1 border-b-2 font-medium text-sm"
                            >Team Members</a
                            >
                        </nav>
                    </div>
                </div>

                <!-- Description list with inline editing -->
                <div class="mt-10 divide-y divide-gray-200">
                    <div class="space-y-1">
                        <h3 class="text-lg font-medium leading-6 text-gray-900">Profile</h3>
                        <p class="max-w-2xl text-sm text-gray-500">
                            This information will be displayed publicly so be careful what you share.
                        </p>
                    </div>
                    <div class="mt-6">
                        <dl class="divide-y divide-gray-200">
                            <div class="py-4 sm:grid sm:grid-cols-3 sm:gap-4 sm:py-5">
                                <dt class="text-sm font-medium text-gray-500">Name</dt>
                                <dd class="mt-1 flex text-sm text-gray-900 sm:col-span-2 sm:mt-0">
                                    <span class="flex-grow">Chelsea Hagon</span>
                                    <span class="ml-4 flex-shrink-0">
                                        <button
                                                type="button"
                                                class="rounded-md bg-white font-medium text-purple-600 hover:text-purple-500 focus:outline-none focus:ring-2 focus:ring-purple-500 focus:ring-offset-2"
                                        >Update</button
                                        >
                                    </span>
                                </dd>
                            </div>
                            <div class="py-4 sm:grid sm:grid-cols-3 sm:gap-4 sm:py-5 sm:pt-5">
                                <dt class="text-sm font-medium text-gray-500">Photo</dt>
                                <dd class="mt-1 flex text-sm text-gray-900 sm:col-span-2 sm:mt-0">
                                    <span class="flex-grow">
                                        <img
                                                class="h-8 w-8 rounded-full"
                                                src="https://images.unsplash.com/photo-1550525811-e5869dd03032?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80"
                                                alt=""
                                        />
                                    </span>
                                    <span class="ml-4 flex flex-shrink-0 items-start space-x-4">
                                        <button
                                                type="button"
                                                class="rounded-md bg-white font-medium text-purple-600 hover:text-purple-500 focus:outline-none focus:ring-2 focus:ring-purple-500 focus:ring-offset-2"
                                        >Update</button
                                        >
                                        <span class="text-gray-300" aria-hidden="true">|</span>
                                        <button
                                                type="button"
                                                class="rounded-md bg-white font-medium text-purple-600 hover:text-purple-500 focus:outline-none focus:ring-2 focus:ring-purple-500 focus:ring-offset-2"
                                        >Remove</button
                                        >
                                    </span>
                                </dd>
                            </div>
                            <div class="py-4 sm:grid sm:grid-cols-3 sm:gap-4 sm:py-5 sm:pt-5">
                                <dt class="text-sm font-medium text-gray-500">Email</dt>
                                <dd class="mt-1 flex text-sm text-gray-900 sm:col-span-2 sm:mt-0">
                                    <span class="flex-grow">chelsea.hagon@example.com</span>
                                    <span class="ml-4 flex-shrink-0">
                                        <button
                                                type="button"
                                                class="rounded-md bg-white font-medium text-purple-600 hover:text-purple-500 focus:outline-none focus:ring-2 focus:ring-purple-500 focus:ring-offset-2"
                                        >Update</button
                                        >
                                    </span>
                                </dd>
                            </div>
                            <div class="py-4 sm:grid sm:grid-cols-3 sm:gap-4 sm:border-b sm:border-gray-200 sm:py-5">
                                <dt class="text-sm font-medium text-gray-500">Job title</dt>
                                <dd class="mt-1 flex text-sm text-gray-900 sm:col-span-2 sm:mt-0">
                                    <span class="flex-grow">Human Resources Manager</span>
                                    <span class="ml-4 flex-shrink-0">
                                        <button
                                                type="button"
                                                class="rounded-md bg-white font-medium text-purple-600 hover:text-purple-500 focus:outline-none focus:ring-2 focus:ring-purple-500 focus:ring-offset-2"
                                        >Update</button
                                        >
                                    </span>
                                </dd>
                            </div>
                        </dl>
                    </div>
                </div>

                <div class="mt-10 divide-y divide-gray-200">
                    <div class="space-y-1">
                        <h3 class="text-lg font-medium leading-6 text-gray-900">Account</h3>
                        <p class="max-w-2xl text-sm text-gray-500">Manage how information is displayed on your
                            account.</p>
                    </div>
                    <div class="mt-6">
                        <dl class="divide-y divide-gray-200">
                            <div class="py-4 sm:grid sm:grid-cols-3 sm:gap-4 sm:py-5">
                                <dt class="text-sm font-medium text-gray-500">Language</dt>
                                <dd class="mt-1 flex text-sm text-gray-900 sm:col-span-2 sm:mt-0">
                                    <span class="flex-grow">English</span>
                                    <span class="ml-4 flex-shrink-0">
                                        <button
                                                type="button"
                                                class="rounded-md bg-white font-medium text-purple-600 hover:text-purple-500 focus:outline-none focus:ring-2 focus:ring-purple-500 focus:ring-offset-2"
                                        >Update</button
                                        >
                                    </span>
                                </dd>
                            </div>
                            <div class="py-4 sm:grid sm:grid-cols-3 sm:gap-4 sm:py-5 sm:pt-5">
                                <dt class="text-sm font-medium text-gray-500">Date format</dt>
                                <dd class="mt-1 flex text-sm text-gray-900 sm:col-span-2 sm:mt-0">
                                    <span class="flex-grow">DD-MM-YYYY</span>
                                    <span class="ml-4 flex flex-shrink-0 items-start space-x-4">
                                        <button
                                                type="button"
                                                class="rounded-md bg-white font-medium text-purple-600 hover:text-purple-500 focus:outline-none focus:ring-2 focus:ring-purple-500 focus:ring-offset-2"
                                        >Update</button
                                        >
                                        <span class="text-gray-300" aria-hidden="true">|</span>
                                        <button
                                                type="button"
                                                class="rounded-md bg-white font-medium text-purple-600 hover:text-purple-500 focus:outline-none focus:ring-2 focus:ring-purple-500 focus:ring-offset-2"
                                        >Remove</button
                                        >
                                    </span>
                                </dd>
                            </div>
                            <div class="py-4 sm:grid sm:grid-cols-3 sm:gap-4 sm:py-5 sm:pt-5">
                                <dt class="text-sm font-medium text-gray-500" id="timezone-option-label">Automatic
                                    timezone
                                </dt>
                                <Switch/>
                            </div>
                        </dl>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
