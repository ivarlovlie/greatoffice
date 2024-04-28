import type { ProjectRole } from "./ProjectRole"

export type ProjectMember = {
    id: string,
    name: string,
    role: ProjectRole,
    email: string,
    userId?: string,
    customerId?: string
}