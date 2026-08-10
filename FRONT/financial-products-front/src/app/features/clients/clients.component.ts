import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';

import { ClientFormComponent } from './client-form/client-form.component';
import { ClientService } from '../../core/services/client.service';
import { Client } from '../../core/models/client.model';

@Component({
  selector: 'app-clients',
  standalone: true,
  imports: [ClientFormComponent],
  templateUrl: './clients.component.html',
  styleUrl: './clients.component.scss',
})
export class ClientsComponent {
  private readonly clientService = inject(ClientService);
  private readonly router = inject(Router);

  clients: Client[] = [];
  loading = false;
  errorMessage = '';
  showForm = false;
  clientToEdit: Client | null = null;
  showDeleteModal = false;
  clientToDelete: Client | null = null;

  ngOnInit(): void {
    this.loadClients();
  }

  loadClients(): void {
    this.loading = true;
    this.errorMessage = '';

    this.clientService.getAll().subscribe({
      next: (response) => {
        if (response.isSuccessful) {
          this.clients = response.data;
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

  openCreateForm(): void {
    this.clientToEdit = null;
    this.showForm = true;
  }

  openEditForm(client: Client): void {
    this.clientToEdit = client;
    this.showForm = true;
  }

  closeForm(): void {
    this.showForm = false;
    this.clientToEdit = null;
  }

  onClientSaved(): void {
    this.showForm = false;
    this.clientToEdit = null;
    this.loadClients();
  }

  requestDeleteClient(client: Client): void {
    this.clientToDelete = client;
    this.showDeleteModal = true;
  }

  cancelDeleteClient(): void {
    this.showDeleteModal = false;
    this.clientToDelete = null;
  }

  confirmDeleteClient(): void {
    if (!this.clientToDelete) {
      return;
    }

    this.loading = true;
    this.errorMessage = '';
    this.showDeleteModal = false;

    this.clientService.delete(this.clientToDelete.id).subscribe({
      next: (response) => {
        this.clientToDelete = null;

        if (!response.isSuccessful) {
          this.errorMessage = response.message;
          this.loading = false;
          return;
        }

        this.loadClients();
      },

      error: (error) => {
        this.loading = false;
        this.clientToDelete = null;

        if (error.error?.message) {
          this.errorMessage = error.error.message;
        } else {
          this.errorMessage = 'No fue posible conectar con el servidor.';
        }
      },
    });
  }

  viewProducts(client: Client): void {
    this.router.navigate(['/products'], {
      queryParams: {
        identification: client.identificationNumber,
      },
    });
  }
}
