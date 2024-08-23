import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient, HttpResponse, HttpErrorResponse, HttpClientModule } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { FormGroup, FormBuilder } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { z } from 'zod';
import { Router } from '@angular/router';
import { AuthService } from '../service/auth-user.service';

const loginResponseSchema = z.object({
  message: z.string(), 
  status: z.boolean()
}).strict();

type LoginResponse = z.infer<typeof loginResponseSchema>;

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, HttpClientModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;


  constructor(private fb: FormBuilder, private router: Router, private authservice: AuthService) {}

  ngOnInit(): void { 
    this.loginForm = this.fb.group({
     email: ['', [Validators.required, Validators.email]],
     password: ['', [Validators.required, Validators.minLength(10)]], 
     rememberMe: [false]   
    })

  }



  userAuthentication(): Observable<HttpResponse<LoginResponse>> {
        
        
        const userData = {email: this.loginForm.get("email")?.value, password: this.loginForm.get("password")?.value, rememberMe:this.loginForm.get("rememberMe")?.value};

        const response$ = this.authservice.login(userData).pipe(
          map(response => {
     
            const result = loginResponseSchema.safeParse(response.body);

            if (!result.success){
                    throw new Error('Invalid Format');
            }
            return response as HttpResponse<LoginResponse>;
          })
        );


        return response$;
  }
  
  onSubmit() {
      if (this.loginForm.invalid) {
        alert("Error");
        console.error("Login Form Error");
      }

      this.userAuthentication().subscribe(
        (response: HttpResponse<any>)=>{

         if (response.body.status === true) {
             this.router.navigate(['profile']);
         }
        }, 
        (error: HttpErrorResponse)=>{
          console.error(error); }) 

      }




}
