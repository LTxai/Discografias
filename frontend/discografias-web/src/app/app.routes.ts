import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'bands',
    loadComponent: () => import('./features/bands/pages/bands/bands.page').then((m) => m.Bands),
  },
];
