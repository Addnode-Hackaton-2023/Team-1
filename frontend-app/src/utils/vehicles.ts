import { AdminClient } from './AllwinClient';

const adminClient = new AdminClient();

export const GetAllVehicles = async () => {
  return await adminClient.getVehicles();
};
