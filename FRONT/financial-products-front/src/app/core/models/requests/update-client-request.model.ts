export interface UpdateClientRequest {
  id: number;
  documentType: string;
  identificationNumber: string;
  firstName: string;
  lastName: string;
  address?: string;
  phoneNumber?: string;
  email?: string;
}
