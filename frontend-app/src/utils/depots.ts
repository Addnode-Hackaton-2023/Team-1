import { useQuery } from '@tanstack/react-query';
import { DepotClient } from './AllwinClient';

const depotClient = new DepotClient("https://localhost:7130");

export const useGetAllDepots = () => {
  return useQuery({
    queryKey: ['depots'],
    queryFn: () => depotClient.getAll(),
    staleTime: Infinity
  });
};