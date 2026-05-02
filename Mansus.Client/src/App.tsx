import AppRouter from './app-router.tsx'
import AppProviders from './app-providers.tsx'


const App = () => {
    return (
        <AppProviders>
            <AppRouter />
        </AppProviders>
    );
};

export default App;