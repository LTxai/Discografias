import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'bands',
    loadComponent: () => import('./features/bands/pages/bands/bands.page').then((m) => m.Bands),
  },
  {
    path: 'bands/add',
    loadComponent: () =>
      import('./features/bands/pages/add-band/add-band.page').then((m) => m.AddBand),
  },
];
