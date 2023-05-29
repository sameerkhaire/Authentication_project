import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule,Routes } from '@angular/router';
import { FullLayoutComponent } from '../shared/layout/full-layout/full-layout.component';
import { HomeComponent } from '../home/home.component';
import { CourseComponent } from '../course/course.component';
import { LayoutComponent } from '../shared/layout/layout.component';
import { LoginComponent } from '../login/login.component';
import { SignUpComponent } from '../sign-up/sign-up.component';
import { MycoursesComponent } from '../mycourses/mycourses.component';
import { NotFoundComponent } from '../not-found/not-found.component';
import { UnauthorizedComponent } from '../unauthorized/unauthorized.component';

const routes:Routes=[
  {
    path:'',component:FullLayoutComponent,children:[
      {path:'',component:HomeComponent},
      {path:'course/:name',component:CourseComponent}
    ]
  },{
    path:'',component:LayoutComponent,children:[
      {path:'login',component:LoginComponent},
      {path:'signup',component:SignUpComponent},
      {path:'courses',component:MycoursesComponent},
      {path:'notfound',component:NotFoundComponent},
      {path:"**",redirectTo:'/notfound'},
      {path:'unautho',component:UnauthorizedComponent}
    ]
  }
];
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports:[RouterModule],
})
export class PublicRoutingModule { }
