import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes } from '@angular/router';
import { UserlayoutComponent } from '../Shared/userlayout/userlayout.component';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { CoursesComponent } from '../courses/courses.component';


const routes: Routes=[
   {
    path:'',component:UserlayoutComponent,children:[
      {path:'dash',component:DashboardComponent},
      {path:'course',component:CoursesComponent}
    ]
   }
]
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports:[RouterModule]
})
export class UserRoutingModule { }
