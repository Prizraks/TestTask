export enum ToastSeveretyLevel {
    Success = "success",
    Info = "info",
    Warn = "warn",
    Error = "error",
    Secondary = "secondary",
    Contrast = "success",
}

export interface ToastModel {
    summary: string;
    detail: string;
    severity: ToastSeveretyLevel;
    life?: number;
}