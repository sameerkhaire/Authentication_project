import { Injectable } from '@angular/core';
import{HttpClient,HttpHeaders, HttpResponse} from '@angular/common/http'
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class FileService {
baseurll="https://localhost:44346/api/File/";
httpHeaders:HttpHeaders | undefined;
  constructor(private http:HttpClient) { }

UploadFile(file: any): Observable<HttpResponse<any>>{
 return this.http.post<any>(`${this.baseurll}myfile`, file,{headers:this.httpHeaders,observe:'response'})
}

}