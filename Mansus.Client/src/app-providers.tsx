import type { ReactNode, ComponentType } from "react";
import {
    QueryClient,
    QueryClientProvider,
} from '@tanstack/react-query'

type ProviderComponent = ComponentType<{ children: ReactNode }>;

const queryClient = new QueryClient()

function MyQueryClientProvider({ children }: { children: React.ReactNode }) {
    return (
        <QueryClientProvider client={queryClient}>
            {children}
        </QueryClientProvider>
    );
}

const providers_arr: ProviderComponent[] = [MyQueryClientProvider];

interface AppProvidersProps {
  children: ReactNode;
}

const AppProviders = ({ children }: AppProvidersProps) => {
  return providers_arr.reduceRight((acc, Provider) => {
    return <Provider>{acc}</Provider>;
  }, children);
};

export default AppProviders;
