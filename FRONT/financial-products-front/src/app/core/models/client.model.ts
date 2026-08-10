export interface Client {
  id: number;
  documentType: string;
  identificationNumber: string;
  firstName: string;
  lastName: string;
  address: string | null;
  phoneNumber: string | null;
  email: string | null;
}
