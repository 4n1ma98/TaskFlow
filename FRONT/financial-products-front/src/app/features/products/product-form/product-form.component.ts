import { Component, EventEmitter, OnInit, Output, inject } from '@angular/core';

import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';

import { ProductService } from '../../../core/services/product.service';
import { ProductTypeService } from '../../../core/services/product-type.service';
import { ClientService } from '../../../core/services/client.service';

import { Client } from '../../../core/models/client.model';
import { ProductType } from '../../../core/models/product-type.model';
import { CreateProductRequest } from '../../../core/models/requests/create-product-request.model';

@Component({
  selector: 'app-product-form',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './product-form.component.html',
  styleUrl: './product-form.component.scss',
})
export class ProductFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly productService = inject(ProductService);
  private readonly productTypeService = inject(ProductTypeService);
  private readonly clientService = inject(ClientService);

  @Output() saved = new EventEmitter<void>();
  @Output() cancelled = new EventEmitter<void>();

  clients: Client[] = [];
  productTypes: ProductType[] = [];

  loadingData = false;
  saving = false;

  errorMessage = '';
  successMessage = '';

  productForm = this.fb.nonNullable.group({
    name: ['', Validators.required],
    productTypeId: [0, [Validators.required, Validators.min(1)]],
    clientId: [0, [Validators.required, Validators.min(1)]],
  });

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.loadingData = true;
    this.errorMessage = '';

    let clientsLoaded = false;
    let productTypesLoaded = false;

    this.clientService.getAll().subscribe({
      next: (response) => {
        if (response.isSuccessful) {
          this.clients = response.data;
        } else {
          this.errorMessage = response.message;
        }

        clientsLoaded = true;

        if (clientsLoaded && productTypesLoaded) {
          this.loadingData = false;
        }
      },
      error: () => {
        this.errorMessage = 'No fue posible cargar los clientes.';
        clientsLoaded = true;

        if (clientsLoaded && productTypesLoaded) {
          this.loadingData = false;
        }
      },
    });

    this.productTypeService.getAll().subscribe({
      next: (response) => {
        if (response.isSuccessful) {
          this.productTypes = response.data;
        } else {
          this.errorMessage = response.message;
        }

        productTypesLoaded = true;

        if (clientsLoaded && productTypesLoaded) {
          this.loadingData = false;
        }
      },
      error: () => {
        this.errorMessage = 'No fue posible cargar los tipos de producto.';
        productTypesLoaded = true;

        if (clientsLoaded && productTypesLoaded) {
          this.loadingData = false;
        }
      },
    });
  }

  submit(): void {
    if (this.productForm.invalid) {
      this.productForm.markAllAsTouched();
      return;
    }

    this.saving = true;
    this.errorMessage = '';
    this.successMessage = '';

    const request: CreateProductRequest = this.productForm.getRawValue();

    this.productService.create(request).subscribe({
      next: (response) => {
        this.saving = false;

        if (!response.isSuccessful) {
          this.errorMessage = response.message;
          return;
        }

        this.saved.emit();
      },
      error: () => {
        this.saving = false;
        this.errorMessage = 'No fue posible conectar con el servidor.';
      },
    });
  }

  cancel(): void {
    this.cancelled.emit();
  }
}
