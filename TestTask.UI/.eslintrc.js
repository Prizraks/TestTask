module.exports = {
  root: true,
  env: { node: true },
  extends: [
    'eslint:recommended',
    'plugin:@typescript-eslint/recommended',
    'plugin:vue/vue3-recommended',
    'prettier'
  ],
  parserOptions: {
    ecmaVersion: 2022,
    parser: '@typescript-eslint/parser'
  },
  rules: {
    // TypeScript
    '@typescript-eslint/explicit-module-boundary-types': 'off',
    '@typescript-eslint/no-non-null-assertion': 'off',
    
    // Vue
    'vue/component-tags-order': ['error', { order: ['script', 'template', 'style'] }],
    'vue/no-v-html': 'warn',
    'vue/require-default-prop': 'off',
    '@typescript-eslint/no-explicit-any': 'warn',
    'vue/multi-word-component-names': 'off',
    
    // Common
    'no-console': process.env.NODE_ENV === 'production' ? 'error' : 'warn'
    }
}