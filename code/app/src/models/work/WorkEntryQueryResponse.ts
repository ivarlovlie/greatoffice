import type { WorkCategory } from "./WorkCategory";
import type { WorkLabel } from "./WorkLabel";
import type { Temporal } from "temporal-polyfill";

export interface WorkEntryQueryResponse {
    duration: WorkEntryQueryDuration,
    categories?: Array<WorkCategory>,
    labels?: Array<WorkLabel>,
    dateRange?: WorkEntryQueryDateRange,
    specificDate?: Temporal.PlainDateTime
    page: number,
    pageSize: number
}

export interface WorkEntryQueryDateRange {
    from: Temporal.PlainDateTime,
    to: Temporal.PlainDateTime
}

export enum WorkEntryQueryDuration {
    TODAY = 0,
    THIS_WEEK = 1,
    THIS_MONTH = 2,
    THIS_YEAR = 3,
    SPECIFIC_DATE = 4,
    DATE_RANGE = 5,
}
