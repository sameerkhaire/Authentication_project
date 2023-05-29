import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { AuthService } from '../public/Services/auth.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';


@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(private auth:AuthService,private route:Router,private toas:ToastrService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> 
  {
    const mytoken=this.auth.gettoken();
    if(!mytoken)
    {
     request= request.clone({
      setHeaders:{Authorization:`Bearer ${mytoken}`}
     })
    }
    return next.handle(request).pipe(
      catchError((err:any) =>{
      if(err instanceof HttpErrorResponse){
        if(err.status==401){

          this.route.navigate(['/login']);
        }
      }
       return throwError(()=> new Error("something went wrong!!! it's thrown an exceptions..."));
      })
      
    );
  }
}


