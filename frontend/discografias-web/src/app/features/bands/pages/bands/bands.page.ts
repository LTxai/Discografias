import { Component, inject } from '@angular/core';
import { BandsStore } from '../../store/bands.store';
import { Card } from '../../components/card/card';

@Component({
  selector: 'app-bands',
  imports: [Card],
  templateUrl: './bands.page.html',
  styleUrl: './bands.page.scss',
})
export class Bands {
  bandsStore = inject(BandsStore);

  ngOnInit() {
    this.bandsStore.loadBands();
  }
}
