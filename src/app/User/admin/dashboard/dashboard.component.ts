import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/features/public/Services/auth.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styles: [
  ]
})
export class DashboardComponent implements OnInit{
 file:any;
  constructor(private auth:AuthService) {
  }
  ngOnInit(): void {

  }

  selectedFile(data:any){
    this.file=data.target.files[0];
  }
  upload(){
     let formdata=new FormData();
     formdata.append('file',this.file);
     this.auth.file(formdata).subscribe({
      next:(data)=>{
        console.log(data);
      }
     })
  }
}
