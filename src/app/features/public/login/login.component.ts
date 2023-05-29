import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../Services/auth.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: [
  ]
})
export class LoginComponent {

  loginForm!:FormGroup;
  constructor(private fb:FormBuilder,private auth: AuthService,private toas:ToastrService, private route:Router) {
    
  }
  
    ngOnInit(): void {
    this.loginForm=this.fb.group({
      username:['',Validators.required],
      password:['', Validators.required]
    })
    }
    Onlogin(){
      if(this.loginForm.valid){
        this.auth.SignIn(this.loginForm.value).subscribe({
          next:(resp=>{
             this.toas.success(resp.message,"login success!!");
             this.route.navigate(['/admin']);
             this.auth.Storetoken(resp.token);
          })
          
        })
      }
    }
}
