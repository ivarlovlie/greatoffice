import LL from '$i18n/i18n-svelte';
import { get } from 'svelte/store';
import type { PageLoad } from './$types';

const l = get(LL);

export const load: PageLoad = async () => {
    return {
        title: l.resetPasswordPage.title(),
    };
};