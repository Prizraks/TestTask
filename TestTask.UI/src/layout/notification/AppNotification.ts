import { defineComponent } from 'vue';
import { useToastStore } from '../../stores/toast/toast.store';
import type { ToastModel } from '../../stores/toast/toast.types';
import type { ToastMessageOptions } from 'primevue';

const DefaultDelayInMS = 5000;

export default defineComponent({
  name: 'AppNotification',

  data(){
    return {
        toastStore: useToastStore(),
    }
  },
  created() {
      this.$watch("toastStore.$state.toasts", this.watchToasts, { deep: true })
  },
  methods: {
    watchToasts(tosts: Array<ToastModel>): void {
        tosts.forEach((toast, index) => {
            const toastOptions = {
                summary: toast.summary,
                detail: toast.detail,
                severity: toast.severity,
                life: toast.life ?? DefaultDelayInMS,
            } as ToastMessageOptions;

            // Подсвечивает ошибку, что не обнаружено глобальное св-во, но в рантайме подтягивает объект. Пока не разбирался в чем проблема.
            this.$toast.add(toastOptions);
            this.toastStore.removeToast(index);
        });
    }
  },
});