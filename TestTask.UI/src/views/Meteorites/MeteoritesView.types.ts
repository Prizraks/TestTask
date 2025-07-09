import type { LazyLoadResponseModel, PagedModel, SortModel, ValidationResult } from "../common.types";


export interface MeteoriteViewModel {
    year: number;
    count: number;
    massSum: number;
}

export interface MeteoriteFiltersModel {
    yearFrom: number | null;
    yearTo: number | null;
    recClass: string | null;
    name: string | null;
}
export interface MeteoritesLoadRequestModel extends MeteoriteFiltersModel, PagedModel, SortModel {
}
export interface MeteoritesLoadResponseModel extends LazyLoadResponseModel<MeteoriteViewModel>, ValidationResult {
}