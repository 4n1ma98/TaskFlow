import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { GenericResult } from '../models/generic-result.model';
import { ClientProduct } from '../models/client-product.model';
import { CreateProductRequest } from '../models/requests/create-product-request.model';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private readonly http = inject(HttpClient);

  private readonly apiUrl = 'http://localhost:11724/api/Products';

  getByClientIdentification(
    identification: string,
  ): Observable<GenericResult<ClientProduct[]>> {
    return this.http.get<GenericResult<ClientProduct[]>>(
      `${this.apiUrl}/ByClientIdentification/${identification}`,
    );
  }

  create(request: CreateProductRequest): Observable<GenericResult<null>> {
    return this.http.post<GenericResult<null>>(this.apiUrl, request);
  }
}
