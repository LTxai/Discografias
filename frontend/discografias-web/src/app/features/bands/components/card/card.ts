import { Component, input } from '@angular/core';
import { Band } from '../../../../core/models/band.model';
import { COUNTRY_ICON_MAP } from '../../utils/country-icon.map';

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

  get countryIcon(): string | null {
    return `/icons/flags/${COUNTRY_ICON_MAP[this.band().nationality]}` || null;
  }
}
