import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Score } from '../models/score';

@Injectable({
  providedIn: 'root'
})
export class ScoresService {

  constructor(private httpClient: HttpClient) { }

  getTop(top: number) {
    return this.httpClient.get<Score[]>("https://localhost:44306/api/scores?top=" + top);
  }
}
