import { useQuery } from '@tanstack/react-query';
import { PickupClient } from './AllwinClient';

const pickupClient = new PickupClient("https://localhost:7130");

export const useGetAllPickups = () => {
    return useQuery({
        queryKey: ['pickups'],
        queryFn: () => pickupClient.getAll(),
        staleTime: Infinity
    });
};