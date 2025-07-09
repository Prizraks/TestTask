import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// https://vite.dev/config/
export default defineConfig(({ command }) => ({
  plugins: [vue()],
  build: {
    target: "es2022",
  }
  // server:{
  //   host: 'localhost',
  //   port: 5173,
  //   strictPort: true,
  //   https: generateCerts()
  // }
}))
