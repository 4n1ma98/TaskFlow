import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'clients',
    loadComponent: () =>
      import('./features/clients/clients.component').then(
        (m) => m.ClientsComponent,
      ),
  },
  {
    path: 'products',
    loadComponent: () =>
      import('./features/products/products.component').then(
        (m) => m.ProductsComponent,
      ),
  },
  {
    path: 'product-types',
    loadComponent: () =>
      import('./features/product-types/product-types.component').then(
        (m) => m.ProductTypesComponent,
      ),
  },
  {
    path: '',
    redirectTo: 'clients',
    pathMatch: 'full',
  },
];
