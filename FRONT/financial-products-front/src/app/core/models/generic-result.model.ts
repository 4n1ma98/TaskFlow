export interface GenericResult<T> {
  id: number;
  isSuccessful: boolean;
  message: string;
  data: T;
}
