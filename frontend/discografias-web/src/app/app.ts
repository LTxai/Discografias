import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Card } from './features/bands/components/card/card';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Card],
  templateUrl: './app.html',
  styleUrl: './app.scss',
})
export class App {
  protected readonly title = signal('discografias-web');
}
