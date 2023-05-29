import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HeaderComponent } from './Shared/header/header.component';
import { UserlayoutComponent } from './Shared/userlayout/userlayout.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CoursesComponent } from './courses/courses.component';
import { UserRoutingModule } from './user-routing/user-routing.module';



@NgModule({
  declarations: [
    HeaderComponent,
    UserlayoutComponent,
    DashboardComponent,
    CoursesComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule
  ],  exports:[RouterModule],
  providers: []
})
export class UserModule { }
