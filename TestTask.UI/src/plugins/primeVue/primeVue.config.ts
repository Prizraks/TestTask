import "primeflex/primeflex.css";
import "primeicons/primeicons.css";

import { PrimeVue } from "@primevue/core";
import type { App } from "vue";
import Aura from "@primeuix/themes/aura";
import Button from "primevue/button"
import DataTable from "primevue/datatable";
import Column from "primevue/column";

import Menubar from "primevue/menubar";
import InputText from "primevue/inputtext";
import Message from "primevue/message";
import Select  from "primevue/select";
import IftaLabel from "primevue/iftalabel";

export default {
    install(app: App) {
        app.use(PrimeVue, {
            theme: {
                preset: Aura
            }
        });

        app.component("PrimeButton", Button);
        app.component("PrimeDataTable", DataTable);
        app.component("PrimeColumn", Column);

        app.component("PrimeMenubar", Menubar);
        app.component("PrimeInputText", InputText);
        app.component("PrimeMessage", Message);
        app.component("PrimeIftaLabel", IftaLabel );
        app.component("PrimeSelect", Select );
    }
}