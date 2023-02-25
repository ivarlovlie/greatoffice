import type {UserRole} from "./UserRole";

export type User = {
    /**
     * Guid id for user
     */
    id: string,
    firstName: string,
    lastName: string,
    role: UserRole,
    username: string,
    email: string
}