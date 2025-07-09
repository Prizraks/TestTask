import pluginVue from 'eslint-plugin-vue'
import globals from 'globals'

export default [
  // add more generic rulesets here, such as:
  ...pluginVue.configs['flat/recommended'],
  ...pluginVue.configs["flat/essential"],
  ...pluginVue.configs["flat/strongly-recommended"],
  ...pluginVue.configs["flat/recommended"],
  {
    rules: {
      // override/add rules settings here, such as:
    },
    languageOptions: {
      sourceType: 'module',
      globals: {
        ...globals.browser
      }
    }
  },
]