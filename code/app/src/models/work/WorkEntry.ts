import type { WorkLabel } from "./WorkLabel";
import type { WorkCategory } from "./WorkCategory";
import type { Project } from "../projects/Project";

export type WorkEntry = {
    id: string,
    start: string,
    stop: string,
    description: string,
    labels?: Array<WorkLabel>,
    category?: WorkCategory,
    project?: Project
}
