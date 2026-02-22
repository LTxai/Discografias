import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { Band } from '../models/band.model';

@Injectable({
  providedIn: 'root',
})
export class BandsService {
  private httpClient = inject(HttpClient);

  public getBands(): Observable<Band[]> {
    return this.httpClient.get<Band[]>('http://localhost:5119/api/Bands').pipe(
      catchError((error) => {
        console.error('[BandsService] Failed to fetch bands:', error);
        return throwError(() => new Error('Failed to fetch bands. Please try again later.'));
      }),
    );
  }

  public postBand(band: Band): Observable<Band> {
    return this.httpClient.post<Band>('http://localhost:5119/api/Bands', band).pipe(
      catchError((error) => {
        console.error('[BandsService] Failed to post band:', error);
        return throwError(() => new Error('Failed to post band. Please try again later.'));
      }),
    );
  }
}
