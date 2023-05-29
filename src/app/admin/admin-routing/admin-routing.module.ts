import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes } from '@angular/router';
import { AdminlayoutComponent } from '../Shared/adminlayout/adminlayout.component';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { CoursesComponent } from '../courses/courses.component';


const routes: Routes=[
   {
    path:'',component:AdminlayoutComponent,children:[
      {path:'',component:DashboardComponent},
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
export class AdminRoutingModule { }
