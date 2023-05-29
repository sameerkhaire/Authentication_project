import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baserurl="https://localhost:44346/api/User/";
  filurl="https://localhost:44346/api/File/myfile";
  constructor(private http:HttpClient) 
  { 

  }
  file(data:any):Observable<any>{
    return this.http.post<any>(`${this.filurl}`,data) 
  }
  SignIn(data:any):Observable<any>{
   return this.http.post<any>(`${this.baserurl}authenticate`,data)
  }
  SignUp(data:any):Observable<any>{
    return this.http.post<any>(`${this.baserurl}register`,data)
  }
  Signout(){
    localStorage.clear();
  }
  Storetoken(tokenvalue:string){
    localStorage.setItem('token',tokenvalue);
  }
  gettoken(){
   return localStorage.getItem('token');
  }
  IsloggedIn():boolean{
    return !! localStorage.getItem('token');
  }
  decodedToken(){
    // const jwttoken=new JwtHelperService();

  }
}
