import { Component } from '@angular/core';
import { HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-logout',
  standalone: true,
  imports: [],
  templateUrl: './logout.component.html',
  styleUrl: './logout.component.css'
})
export class LogoutComponent {
  
  constructor(private http: HttpClient) {}

  
  api(): Observable<HttpResponse<any>> {    
    return this.http.post<any>("http://localhost:5223/api/users/logout", {}, { withCredentials: true });
  }

  onSubmit() {  

    this.api().subscribe((response:HttpResponse<any>)=> {
      console.log(response.body)}, 
    (error:HttpErrorResponse)=>{
      console.error(error);
    })

     
  }

}
