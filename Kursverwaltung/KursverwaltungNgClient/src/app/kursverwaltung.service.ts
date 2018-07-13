import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Kurs} from './models';

@Injectable({
  providedIn: 'root'
})
export class KursverwaltungService {

  constructor(private httpClient : HttpClient) { }

  public getKurse(){
    return this.httpClient.get("https://localhost:44332/api/kurs").toPromise().then(r=><Kurs[]>r);
  }
}
