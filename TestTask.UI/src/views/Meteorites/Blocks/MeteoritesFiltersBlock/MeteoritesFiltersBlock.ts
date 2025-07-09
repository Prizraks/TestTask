import { defineComponent, type PropType } from 'vue';
import type { MeteoriteFiltersModel, MeteoritesLoadRequestModel } from '../../MeteoritesView.types';
import ValidInputText from '../../../../shared/components/Validation/ValidInputText/ValidInputText.vue';
import ValidSelect from '../../../../shared/components/Validation/ValidSelect/ValidSelect.vue';

const applyEmit = "apply";

export default defineComponent({
  name: 'MeteoritesFiltersBlock',
  components: { ValidInputText, ValidSelect },
  props: {
    classes: {
        type: Object as PropType<Array<string>>,
        required: true,
    },
    years: {
        type: Object as PropType<Array<number>>,
        required: true,
    },
    lazyParams: {
        type: Object as PropType<MeteoritesLoadRequestModel>,
        required: true,
    },
    invalidFields: {
        type: Object as PropType<Record<string, string>>,
        required: true,
    },
  },
  emits: [applyEmit],
  data(): {
    filters: MeteoriteFiltersModel,
  } {
    return {
      filters: {
        yearFrom: null,
        yearTo: null,
        name: null,
        recClass: null,
      },
    }
  },

  created() {
    this.filters.yearFrom = this.lazyParams.yearFrom;
    this.filters.yearTo = this.lazyParams.yearTo;
    this.filters.name = this.lazyParams.name;
    this.filters.recClass = this.lazyParams.recClass;
  },

  methods: {
    applyFilter(): void {
      this.$emit(applyEmit, this.filters);
    },
    clearFilter(): void {
      this.filters.yearFrom = null;
      this.filters.yearTo = null;
      this.filters.name = null;
      this.filters.recClass = null;

      this.$emit(applyEmit, this.filters);
    },
  }
});