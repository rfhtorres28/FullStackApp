import { CanActivateFn, Router, UrlTree } from '@angular/router';
import { inject } from '@angular/core';
import { AuthService } from '../service/auth-user.service';
import { HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { catchError, Observable, of, map} from 'rxjs';

export const authGuard: CanActivateFn = (route, state): Observable<boolean | UrlTree> => {
   
   const authService = inject(AuthService);
   const router = inject(Router); 



    return authService.isUserLogin().pipe(
        map((response:HttpResponse<any>) => {
           if (response.body.status) {
            
            return router.createUrlTree(['/login']);
           }
           else {
             console.log(response)
              return true;
           }
        }), 
        catchError((error: HttpErrorResponse)=>{
          console.error(error);
          return of(router.createUrlTree(['/login']));
           
        })
      ); 










};
