import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from '../models/order';
import { Status } from '../models/status';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http:HttpClient) { }

  api_title="BORUSAN";
  
  _apiUrl:string ="http://localhost:8356/api";

  getOrders():Observable<Order[]>{
    return this.http.get<Order[]>(this._apiUrl+"/orders");
  }
  
  getOrderStatus():Observable<Status[]>{
    return this.http.get<Status[]>(this._apiUrl+"/status");
  }
  updateOrder(val:Order[]):Observable<Order[]>{
    return this.http.put<Order[]>(this._apiUrl+"/orders",JSON.stringify(val),{
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
            'Accept': 'multipart/form-data',
          })
    });
  }
 

}
