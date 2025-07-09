import { defineComponent } from 'vue';
import ValidMixin from '../Valid.mixin';

const updateEmit = "update:modelValue";

export default defineComponent({
  name: 'ValidInputText',
  mixins: [ValidMixin],

  props: {
    modelValue: {
      type: [String, null],
      required: true,
    },
  },
  emits: [updateEmit],

  computed: {
    model: {
      get(): string | null {
        return this.modelValue;
      },
      set(value: string): void {
        this.$emit(updateEmit, value);
      }
    }
  },
});