import { Component, input } from '@angular/core';
import { Band } from '../../../../core/models/band.model';

@Component({
  selector: 'app-card',
  imports: [],
  templateUrl: './card.html',
  styleUrl: './card.scss',
})
export class Card {
  variant = input<'primary' | 'secondary'>('primary');

  title = input<string>('');

  band = input<Band>({
    name: '',
    nationality: '',
    genre: '',
    studioAlbumsCount: 0,
    songsCount: 0,
    score: 0,
  });
}
