import api from "../../plugins/api";
import type { MeteoritesLoadRequestModel, MeteoritesLoadResponseModel } from "../../views/Meteorites/MeteoritesView.types";
import Api from "./Api";

const baseUrl = "meteorite";

export default class MeteoriteApiService extends Api {
    public static getMeteorites(request: MeteoritesLoadRequestModel): Promise<MeteoritesLoadResponseModel> {
        return api.get(`${baseUrl}/get-meteorites?${this.getQueryString(request)}`);
    }

    public static getAllClasses(): Promise<Array<string>> {
        return api.get(`${baseUrl}/get-all-classes`);
    }

    public static getYears(): Promise<Array<number>> {
        return api.get(`${baseUrl}/get-years`);
    }
}