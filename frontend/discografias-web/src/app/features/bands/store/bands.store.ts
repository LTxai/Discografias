import { Band } from './../../../core/models/band.model';
import { inject, Injectable, signal } from '@angular/core';
import { BandsService } from '../../../core/services/bands';

@Injectable({ providedIn: 'root' })
export class BandsStore {
  private bandsService = inject(BandsService);

  private readonly _bands = signal<Band[]>([]);
  private readonly _loading = signal(false);
  private readonly _error = signal<string | null>(null);

  readonly bands = this._bands.asReadonly();
  readonly loading = this._loading.asReadonly();
  readonly error = this._error.asReadonly();

  loadBands(): void {
    this._loading.set(true);
    this._error.set(null);

    this.bandsService.getBands().subscribe({
      next: (bands) => {
        this._bands.set(bands);
        this._loading.set(false);
      },
      error: () => {
        this._error.set('Failed to load bands. Please try again later.');
        this._loading.set(false);
      },
    });
  }
}
