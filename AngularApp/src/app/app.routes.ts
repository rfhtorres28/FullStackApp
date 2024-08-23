import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';
import { ProfileComponent } from './profile/profile.component';
import { authGuard } from './authguard/authguard.guard';

export const routes: Routes = [
    { path: '', component: HomeComponent },        // Default route
    { path: 'home', component: HomeComponent },  
    { path: 'register', component: RegisterComponent }, 
    { path: 'login', component: LoginComponent},
    { path: 'logout', component: LogoutComponent},
    { path: 'profile', component: ProfileComponent, canActivate: [authGuard]},
  ];