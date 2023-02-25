import type { Temporal } from "temporal-polyfill"
import type { User } from "../base/User"

export type ProjectMeta = {
    created: Temporal.PlainDateTime,
    createdBy: User,
}