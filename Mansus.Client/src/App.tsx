import AppRouter from './app-router.tsx'
import AppProviders from './app-providers.tsx'
import './App.css'


function App() {
    return (
        <AppProviders>
            <AppRouter />
        </AppProviders >
    );
}

export default App
