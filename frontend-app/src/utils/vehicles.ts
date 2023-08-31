import { useQuery } from '@tanstack/react-query';
import { AdminClient } from './AllwinClient';

const adminClient = new AdminClient();

export const useGetAllVehicles = () => {
  return useQuery({
    queryKey: ['vehicles'],
    queryFn: () => adminClient.getVehicles(),
    staleTime: Infinity
  });
};
