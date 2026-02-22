import { Component, inject, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Card } from './features/bands/components/card/card';
import { BandsService } from './core/services/bands';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Card],
  templateUrl: './app.html',
  styleUrl: './app.scss',
})
export class App {
  protected readonly title = signal('discografias-web');
  readonly bandsService = inject(BandsService);

  constructor() {
    this.bandsService.getBands().subscribe({
      next: (bands) => {
        console.log('Bands fetched successfully:', bands);
      },
      error: (error) => {
        console.error('Error fetching bands:', error);
      },
    });
  }
}
