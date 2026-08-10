import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

import { ProductFormComponent } from './product-form/product-form.component';
import { ProductService } from '../../core/services/product.service';
import { ClientProduct } from '../../core/models/client-product.model';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [FormsModule, ProductFormComponent],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss',
})
export class ProductsComponent {
  private readonly productService = inject(ProductService);
  private readonly route = inject(ActivatedRoute);

  products: ClientProduct[] = [];

  identification = '';
  search = false;

  loadingData = false;
  errorMessage = '';
  successMessage = '';

  showForm = false;

  hasSearched = false;

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      const identification = params['identification'];

      if (identification) {
        this.identification = identification;
        this.searchProducts();
      }
    });
  }

  searchProducts(): void {
    if (!this.identification.trim()) {
      this.errorMessage = 'Ingrese un número de identificación.';
      this.products = [];
      this.hasSearched = false;
      return;
    }

    this.loadingData = true;
    this.errorMessage = '';
    this.successMessage = '';
    this.hasSearched = true;

    this.productService
      .getByClientIdentification(this.identification.trim())
      .subscribe({
        next: (response) => {
          this.loadingData = false;

          if (response.isSuccessful) {
            this.products = response.data;
            return;
          }

          this.products = [];
          this.errorMessage = response.message;
        },

        error: (error: HttpErrorResponse) => {
          this.loadingData = false;
          this.products = [];

          if (error.error?.message) {
            this.errorMessage = error.error.message;
          } else {
            this.errorMessage = 'No fue posible conectar con el servidor.';
          }
        },
      });
  }

  openCreateForm(): void {
    this.showForm = true;
    this.errorMessage = '';
    this.successMessage = '';
  }

  closeForm(): void {
    this.showForm = false;
  }

  onProductCreated(): void {
    this.showForm = false;
    this.successMessage = 'Producto creado exitosamente.';

    if (this.identification.trim()) {
      this.searchProducts();
    }
  }
}
