import type {WorkEntry} from "./WorkEntry";

export interface IWorkQuery {
    results: Array<WorkEntry>,
    page: number,
    pageSize: number,
    totalRecords: number,
    totalPageCount: number,
}

export class WorkQuery implements IWorkQuery {
    results: WorkEntry[];
    page: number;
    pageSize: number;
    totalRecords: number;
    totalPageCount: number;
}
