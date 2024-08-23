import { HttpClient, HttpResponse, HttpErrorResponse  } from '@angular/common/http';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { AuthService } from '../service/auth-user.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule, HttpClientModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnDestroy, OnInit {

  public registerForm!: FormGroup;
  private eventSubscription!: Subscription;

  constructor(private http: HttpClient,  private route: Router, private authService: AuthService) {}


  ngOnInit(): void {

    this.registerForm = new FormGroup ({
      username: new FormControl('', [Validators.required, Validators.minLength(8)]),
      email: new FormControl('', [Validators.required, Validators.email]), 
      password: new FormControl('', [Validators.required, Validators.minLength(8)]),
      confirmPassword: new FormControl('', [Validators.required, Validators.minLength(8)])    
    })
    
    

  }

  subscription(): void {
    this.eventSubscription = this.fetchData().subscribe((response:HttpResponse<any>)=> {
      if(response){
        console.log(response.body);
      }}, 
      (error: HttpErrorResponse)=> {
        console.error(error);
      })
  }
  
  fetchData(): Observable<HttpResponse<any>> {
     
    const userData = this.registerForm.value;
    console.log(userData);

     return this.authService.register(userData);
    
  }

  ngOnDestroy(): void {
      if(this.eventSubscription){
        this.eventSubscription.unsubscribe();
      }
  }

  onSubmit(): void {
    if (this.registerForm.valid) {
      return this.subscription();
    }
  
    // Print errors for each control
    Object.keys(this.registerForm.controls).forEach(key => {
      const controlErrors = this.registerForm.get(key)?.errors;
      if (controlErrors) {
        console.error(`Control: ${key}, Errors:`, controlErrors);
      }
    });
  
    alert("Form is invalid");
  }
  



}
