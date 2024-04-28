import type {User} from "./User";

export type Tenant = {
    id: string,
    name: string,
    description: string,
    masterUser: User,
}