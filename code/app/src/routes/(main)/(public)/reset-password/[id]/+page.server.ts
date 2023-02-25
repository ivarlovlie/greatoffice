import { is_guid } from "$utilities/validators";
import { redirect } from "@sveltejs/kit";
import type { PageServerLoad } from "./$types";

export const load: PageServerLoad = async ({ params }) => {
    const resetRequestId = params.id ?? "";
    if (!is_guid(resetRequestId)) throw redirect(302, "/reset-password");
    return {
        resetRequestId,
    };
};