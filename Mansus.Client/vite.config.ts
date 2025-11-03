import { defineConfig } from 'vite'
import mkcert from 'vite-plugin-mkcert'
import react from '@vitejs/plugin-react'

// https://vite.dev/config/
export default defineConfig({
    plugins: [react(), mkcert()],
    server: {
        port: 51755,
        proxy: {
            '/api': {
                target: 'https://localhost:7029',
                changeOrigin: true,
                secure: false,
                rewrite: (path) => path.replace(/^\/api/, '')
            }
        }
    }
})
