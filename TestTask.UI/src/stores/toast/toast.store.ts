import { defineStore } from "pinia"
import type { ToastModel } from "./toast.types"

export const useToastStore = defineStore('toast', {
  state: () => ({toasts: [] as Array<ToastModel>}),
  getters: {
    toasts: (state) => state.toasts,
  },
  actions: {
    addToast(toast: ToastModel) {
      this.$state.toasts.push(toast);
    },

    removeToast(index: number) {
      this.$state.toasts.slice(index);
    },
  },
})