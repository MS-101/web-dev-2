import { defineConfig } from 'vite'
import mkcert from 'vite-plugin-mkcert'
import react from '@vitejs/plugin-react'


// https://vite.dev/config/
export default defineConfig(({ mode }) => {
    const devTarget = 'https://localhost:7029'
    const prodTarget = 'https://localhost:7029'
    const apiTarget = mode === 'development' ? devTarget : prodTarget

    return {
        plugins: [react(), mkcert()],
        server: {
            port: 51755,
            proxy: {
                '/api': {
                    target: apiTarget,
                    changeOrigin: true,
                    secure: false,
                    rewrite: (path) => path.replace(/^\/api/, '')
                }
            }
        }
    }
})