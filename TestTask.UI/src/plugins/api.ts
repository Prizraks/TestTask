import axios, { type AxiosInstance, type AxiosResponse, AxiosError } from 'axios';
import { type App } from 'vue';

const BASE_URL = import.meta.env.VITE_API_URL;

declare module "@vue/runtime-core" {
  interface ComponentCustomProperties {
    $api: Readonly<Api>;
  }
}

// Api class
class Api {
  private static readonly UNAUTORIZED_STATUS_CODE = 401;
  private static readonly FORBIDDEN_STATUS_CODE = 403;

  private readonly axios: AxiosInstance;

  constructor() {
    this.axios = this.createAxios();
  }

  createAxios(): AxiosInstance {
    const instanse = axios.create({
      baseURL: BASE_URL,
      headers: {
        'Content-Type': 'application/json',
      },
    });

    instanse.interceptors.response.use(
      (response: AxiosResponse) => response,
      (error: AxiosError) => {
        if (this.isAccessDenied(error)) {
          //window.location.href = '/login';
        }
        return Promise.reject(error);
      }
    );

    return instanse;
  }

  public install(app: App) {
    app.config.globalProperties.$api = api
  }


  isAccessDenied(error: AxiosError | undefined): boolean {
    if(!error) {
      return false;
    }

    return [Api.UNAUTORIZED_STATUS_CODE, Api.FORBIDDEN_STATUS_CODE].includes(error?.status ?? 0)
  }

  public async get<T>(url: string, params?: unknown): Promise<T> {
    const response = await this.axios.get<T>(url, { params });

    return response.data;
  }
}

const api: Readonly<Api> = Object.freeze(new Api())

export default api;