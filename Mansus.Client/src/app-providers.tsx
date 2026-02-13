import type { ReactNode, ComponentType } from "react";

type ProviderComponent = ComponentType<{ children: ReactNode }>;

const providers_arr: ProviderComponent[] = [];

interface AppProvidersProps {
  children: ReactNode;
}

const AppProviders = ({ children }: AppProvidersProps) => {
  return providers_arr.reduceRight((acc, Provider) => {
    return <Provider>{acc}</Provider>;
  }, children);
};

export default AppProviders;
