import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { ProductType } from '../models/product-type.model';
import { GenericResult } from '../models/generic-result.model';

@Injectable({
  providedIn: 'root',
})
export class ProductTypeService {
  private readonly http = inject(HttpClient);

  private readonly apiUrl = 'http://localhost:11724/api/ProductTypes';

  getAll(): Observable<GenericResult<ProductType[]>> {
    return this.http.get<GenericResult<ProductType[]>>(`${this.apiUrl}/GetAll`);
  }
}
