import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import api from './plugins/api'
import Record from "./plugins/record.service";
import PrimeVue from "./plugins/primeVue/primeVue.config"
import router from './router';
import { createPinia } from 'pinia';

const app = createApp(App);

app.use(createPinia());
app.use(router);
app.use(api);
app.use(Record);
app.use(PrimeVue);

app.mount("#app");
