import { HttpErrorResponse } from '@angular/common/http';
import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';

import { ClientService } from '../../../core/services/client.service';
import { Client } from '../../../core/models/client.model';

@Component({
  selector: 'app-client-form',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './client-form.component.html',
  styleUrl: './client-form.component.scss',
})
export class ClientFormComponent {
  private readonly fb = inject(FormBuilder);
  private readonly clientService = inject(ClientService);

  @Input() client: Client | null = null;

  @Output() saved = new EventEmitter<void>();
  @Output() cancelled = new EventEmitter<void>();

  loading = false;
  errorMessage = '';

  clientForm = this.fb.nonNullable.group({
    documentType: ['', Validators.required],
    identificationNumber: ['', Validators.required],
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    address: ['', Validators.required],
    phoneNumber: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
  });

  get isEditMode(): boolean {
    return this.client !== null;
  }

  ngOnInit(): void {
    if (this.client) {
      this.clientForm.patchValue({
        documentType: this.client.documentType,
        identificationNumber: this.client.identificationNumber,
        firstName: this.client.firstName,
        lastName: this.client.lastName,
        address: this.client.address ?? '',
        phoneNumber: this.client.phoneNumber ?? '',
        email: this.client.email ?? '',
      });
    }
  }

  submit(): void {
    if (this.clientForm.invalid) {
      this.clientForm.markAllAsTouched();
      return;
    }

    this.loading = true;
    this.errorMessage = '';

    const formValue = this.clientForm.getRawValue();

    if (this.isEditMode && this.client) {
      const request = {
        id: this.client.id,
        ...formValue,
      };

      this.clientService.update(request).subscribe({
        next: (response) => {
          this.loading = false;

          if (!response.isSuccessful) {
            this.errorMessage = response.message;
            return;
          }

          this.saved.emit();
        },

        error: (error: HttpErrorResponse) => {
          this.loading = false;

          if (error.error?.message) {
            this.errorMessage = error.error.message;
          } else if (error.error?.errors) {
            this.errorMessage = this.getValidationErrorMessage(
              error.error.errors,
            );
          } else {
            this.errorMessage = 'No fue posible conectar con el servidor.';
          }
        },
      });

      return;
    }

    this.clientService.create(formValue).subscribe({
      next: (response) => {
        this.loading = false;

        if (!response.isSuccessful) {
          this.errorMessage = response.message;
          return;
        }

        this.saved.emit();
      },

      error: (error: HttpErrorResponse) => {
        this.loading = false;

        if (error.error?.message) {
          this.errorMessage = error.error.message;
        } else if (error.error?.errors) {
          this.errorMessage = this.getValidationErrorMessage(
            error.error.errors,
          );
        } else {
          this.errorMessage = 'No fue posible conectar con el servidor.';
        }
      },
    });
  }

  cancel(): void {
    this.cancelled.emit();
  }

  private getValidationErrorMessage(errors: {
    [key: string]: string[];
  }): string {
    const messages = Object.values(errors).flat();

    return messages.length > 0
      ? messages.join(' ')
      : 'Los datos enviados no son válidos.';
  }
}
