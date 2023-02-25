import type { PortalMessage } from '$configuration';
import { redirect } from '@sveltejs/kit';
import type { PageLoad } from './$types';

export const load: PageLoad = async ({ url }) => {
    const message = url.searchParams.get("msg") as PortalMessage;
    if (!message) throw redirect(302, "/");
    return { message };
};