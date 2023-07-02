export interface IContext {
  app: { id: string; version: string };
  defaultWebApiUrlKey: string;
  webApiUrlsByKeys: any;

  getWebApiUrl(key: string): string;

  getMoteurCalculWebApiUrl(key: string): string;

  getWebApiKeys(): string[];

  getAbsoluteUrl(url: string): string;
}
