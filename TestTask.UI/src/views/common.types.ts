export interface ValidationResult {
    invalidFields: Record<string, string>;
}

export interface PagedModel
{
    pageNumber: number;
    pageSize: number;
}

export interface SortModel
{
    sortField: string | null;
    sortOrder: number | null | undefined; // 1 - asc, -1 - desc
}

export interface LazyLoadResponseModel<T> {
    data: Array<T>;
    totalRecords : number
}