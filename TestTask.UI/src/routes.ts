import type { RouteRecordRaw } from "vue-router";
import AppLayout from "./layout/AppLayout.vue";

export const HOME_PAGE: string = "meteorites";

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    redirect: HOME_PAGE, 
    name: 'home',
    component: AppLayout,
    children: [
        {
            path: `/${HOME_PAGE}`,
            name: HOME_PAGE,
            component: () => import("./views/Meteorites/MeteoritesView.vue")
        }
    ]
  },
  {
    path: `/:pathMatch(.*)*`,
    name: "notfound",
    component: () => import("./layout/pages/NotFound/NotFound.vue")
  }

]

export default routes;
