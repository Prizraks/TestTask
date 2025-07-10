import type { MenuItem } from 'primevue/menuitem';
import { defineComponent } from 'vue';
import { HOME_PAGE } from '../routes';
import AppNotification from './notification/AppNotification.vue';

export default defineComponent({
  name: 'AppLayout',

  components: { AppNotification },
  data(): {
    isMobileMenuOpen : boolean,
    menuItems : MenuItem[],
  } {
    return {
        isMobileMenuOpen : false,
        menuItems:[
            {
                label: 'Метеориты',
                to: `/${HOME_PAGE}`
            }]
    }
  },

  created() {
    this.$options.currentYear = new Date().getFullYear();
  },
});