// vite.config.js
import { defineConfig } from 'vite'
import reactRefresh from '@vitejs/plugin-react-refresh'

export default defineConfig({
  plugins: [reactRefresh()],
  css: {
    modules: {
      // Enable CSS Modules globally in the project
      // Change the `generateScopedName` option to customize the generated class names
      generateScopedName: '[name]__[local]--[hash:base64:5]'
    }
  }
})
