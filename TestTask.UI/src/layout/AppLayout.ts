import type { MenuItem } from 'primevue/menuitem';
import { defineComponent } from 'vue';
import { HOME_PAGE } from '../routes';

export default defineComponent({
  name: 'AppLayout',

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