import type {CustomerContact} from "./CustomerContact";
import type {User} from "./User";

export type Customer = {
    /**
     * Guid id for customer
     */
    id: string,
    /**
     * The name of the company
     */
    name: string,
    /**
     * Responsible contact in the current tenant
     */
    tenantContact: User,
    /**
     * The customers main contact
     */
    mainContact: CustomerContact,
}