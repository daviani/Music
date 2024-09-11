import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { environment } from '../../environement';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private uri = environment.apiUrl;
  constructor(private http: HttpClient) {};

  httpOptions ={
    headers : new HttpHeaders({
      'Access-Control-Allow-Origin':'*',
      'Cross-origin': 'cross-site'
    })
  }


  getAllBands() {
    const response =  this.http.get(`${this.uri}/bands`, this.httpOptions);
    console.log('-------',response)
    return response
  }

}
