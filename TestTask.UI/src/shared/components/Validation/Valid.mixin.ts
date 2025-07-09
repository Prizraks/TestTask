import { defineComponent, type PropType } from 'vue';

export default defineComponent({
  name: 'ValidMixin',
  props: {
    invalidFields: {
        type: Object as PropType<Record<string, string>>,
        required: true,
    },
    fieldName: {
        type: String,
        required: true,
    },
    labelName: {
        type: String,
        required: true,
    },
    id: {
        type: String,
        required: true,
    },
  },

  methods: {
    isExistsError(): boolean {
        return this.$record.hasKey(this.invalidFields, this.fieldName);
    },

    getErrorText(): any {
        return this.$record.get(this.invalidFields, this.fieldName);
    },

    clearError(): void {
        this.$record.delete(this.invalidFields, this.fieldName);
    }
  }
});