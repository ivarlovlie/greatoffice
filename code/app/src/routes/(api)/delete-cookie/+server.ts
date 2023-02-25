import type { RequestHandler } from './$types';

export const GET: RequestHandler = async ({ cookies, url }) => {
    const cookieToDelete = url.searchParams.get("key");
    if (!cookieToDelete || cookies.get(cookieToDelete) === undefined) return;
    cookies.delete(cookieToDelete)
    return new Response();
};