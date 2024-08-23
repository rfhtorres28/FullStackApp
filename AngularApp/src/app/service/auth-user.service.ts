import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpResponse, HttpClientModule, HttpErrorResponse } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class AuthService  {
  
  apiRegister!: string; 
  apiLogin!: string;
  apiCheckAuthentication!: string;

  constructor(private http: HttpClient) {
     this.apiRegister = "http://localhost:5223/api/users/register"; 
     this.apiLogin = "http://localhost:5223/api/users/login"; 
     this.apiCheckAuthentication = "http://localhost:5223/api/users/check-authentication";
   }
 
  

  register(userData: object): Observable<HttpResponse<any>> {

      return this.http.post(this.apiRegister, userData, {observe: 'response'}); 
      
  }
  
  login(userData: object): Observable<HttpResponse<any>> {

      return this.http.post(this.apiLogin, userData, {observe: 'response', withCredentials: true }); 
      
  }

  isUserLogin(): Observable<HttpResponse<any>> {
     
       return this.http.get<any>(this.apiCheckAuthentication);
      
  }

  





}
