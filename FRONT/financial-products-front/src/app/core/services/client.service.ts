import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Client } from '../models/client.model';
import { GenericResult } from '../models/generic-result.model';
import { CreateClientRequest } from '../models/requests/create-client-request.model';
import { UpdateClientRequest } from '../models/requests/update-client-request.model';

@Injectable({
  providedIn: 'root',
})
export class ClientService {
  private readonly http = inject(HttpClient);

  private readonly apiUrl = 'http://localhost:11724/api/Clients';

  getAll(): Observable<GenericResult<Client[]>> {
    return this.http.get<GenericResult<Client[]>>(`${this.apiUrl}/GetAll`);
  }

  getById(id: number): Observable<GenericResult<Client>> {
    return this.http.get<GenericResult<Client>>(`${this.apiUrl}/GetById/${id}`);
  }

  getByIdentification(
    identification: string,
  ): Observable<GenericResult<Client>> {
    return this.http.get<GenericResult<Client>>(
      `${this.apiUrl}/GetByIdentification/${identification}`,
    );
  }

  create(request: CreateClientRequest): Observable<GenericResult<Client>> {
    return this.http.post<GenericResult<Client>>(
      `${this.apiUrl}/Create`,
      request,
    );
  }

  update(request: UpdateClientRequest): Observable<GenericResult<Client>> {
    return this.http.put<GenericResult<Client>>(
      `${this.apiUrl}/Update`,
      request,
    );
  }

  delete(id: number): Observable<GenericResult<null>> {
    return this.http.delete<GenericResult<null>>(`${this.apiUrl}/Delete/${id}`);
  }
}
