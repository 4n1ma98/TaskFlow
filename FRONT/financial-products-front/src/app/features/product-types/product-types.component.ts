import { Component, inject, OnInit } from '@angular/core';

import { ProductTypeService } from '../../core/services/product-type.service';
import { ProductType } from '../../core/models/product-type.model';

@Component({
  selector: 'app-product-types',
  standalone: true,
  templateUrl: './product-types.component.html',
  styleUrl: './product-types.component.scss',
})
export class ProductTypesComponent implements OnInit {
  private readonly productTypeService = inject(ProductTypeService);

  productTypes: ProductType[] = [];
  loading = false;
  errorMessage = '';

  ngOnInit(): void {
    this.loadProductTypes();
  }

  loadProductTypes(): void {
    this.loading = true;
    this.errorMessage = '';

    this.productTypeService.getAll().subscribe({
      next: (response) => {
        if (response.isSuccessful) {
          this.productTypes = response.data;
        } else {
          this.errorMessage = response.message;
        }

        this.loading = false;
      },
      error: () => {
        this.errorMessage = 'No fue posible conectar con el servidor.';
        this.loading = false;
      },
    });
  }
}
