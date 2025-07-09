import { defineComponent, type PropType } from 'vue';
import ValidMixin from '../Valid.mixin';

const updateEmit = "update:modelValue";

export default defineComponent({
  name: 'ValidSelect',
  mixins: [ValidMixin],

  props: {
    modelValue: {
      type: [Number, String, null] as PropType<number | string | null>,
      required: true,
    },
    options: {
        type: Array<number | string>,
        required: true,
    }
  },
  emits: [updateEmit],

  computed: {
    model: {
      get(): number | string | null {
        return this.modelValue;
      },
      set(value: number | string): void {
        this.$emit(updateEmit, value);
      }
    }
  },
});