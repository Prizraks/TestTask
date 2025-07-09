export default class Api {
    protected static getQueryString(request: object): string {
        return Object.entries(request)
            .map(([key, value]) => this.isEmptyValue(value) 
                ? `${encodeURIComponent(key)}=`
                : `${encodeURIComponent(key)}=${encodeURIComponent(value)}`)
            .join('&');
    }

    private static isEmptyValue(value: any): boolean {
        return value === null || value === undefined;
    }
}