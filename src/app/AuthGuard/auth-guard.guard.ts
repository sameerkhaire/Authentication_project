import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../Services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardGuard implements CanActivate {
  constructor(private auth:AuthService,private route:Router) {
    
  }
  canActivate():boolean{
    if(this.auth.IsloggedIn()){
      return true;
    }
    else{
      this.route.navigate(['/login'])
      return false;
    }
  }
  
}
