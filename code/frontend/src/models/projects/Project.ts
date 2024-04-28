import type { Temporal } from "temporal-polyfill"
import type { ProjectMember } from "./ProjectMember"
import type { ProjectStatus } from "./ProjectStatus"

export type Project = {
    id: string,
    name: string,
    description?: string,
    start: Temporal.PlainDate,
    stop?: Temporal.PlainDate,
    members: Array<ProjectMember>,
    status: ProjectStatus
}