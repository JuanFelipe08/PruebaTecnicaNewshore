import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {Journey} from '../models/journey';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class JourneyService {
  baseUrl: string;
  constructor(private http: HttpClient) {
    this.baseUrl = environment.url_api;
  }

  searchJourney(origin: string, destination: string): Observable<Journey>{
    return this.http.get<Journey>(`${this.baseUrl}/api/Journey/${origin}/${destination}`);
  }
}
