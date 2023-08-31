import { useQuery } from '@tanstack/react-query';
import { DeliveryClient } from './AllwinClient';

const deliveryClient = new DeliveryClient("https://localhost:7130");

export const useGetAllDeliveries = () => {
    return useQuery({
        queryKey: ['deliveries'],
        queryFn: () => deliveryClient.getAll(),
        staleTime: Infinity
    });
};