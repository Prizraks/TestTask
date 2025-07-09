// Copyright (c) JSC BCSE. All rights reserved.

import type { App } from "vue";

declare module "@vue/runtime-core" {
  interface ComponentCustomProperties {
    $record: RecordService;
  }
}

interface RecordService {
  hasKey<V>(items: Record<string | number, V>, key: string | number): boolean;
  get<V>(items: Record<string | number, V>, key: string | number): V | undefined;
  delete<V>(items: Record<string | number, V>, key: string | number): void;
  isEmpty<V>(items: Record<string | number, V>): boolean;
}

export default {
  install: (app: App) => {
    app.config.globalProperties.$record = {
      hasKey<V>(items: Record<string | number, V>, key: string | number): boolean {
        return key in items;
      },

      get<V>(items: Record<string | number, V>, key: string | number): V | undefined {
        return items[key];
      },

      delete<V>(items: Record<string | number, V>, key: string | number): void {
        delete items[key];
      },
      isEmpty<V>(items: Record<string | number, V>): boolean {
        return Object.keys(items).length === 0;
      },
    };
  },
};
