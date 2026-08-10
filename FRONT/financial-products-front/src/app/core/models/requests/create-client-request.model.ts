export interface CreateClientRequest {
  documentType: string;
  identificationNumber: string;
  firstName: string;
  lastName: string;
  address?: string;
  phoneNumber?: string;
  email?: string;
}
