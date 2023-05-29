import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './Shared/header/header.component';
import { AdminlayoutComponent } from './Shared/adminlayout/adminlayout.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CoursesComponent } from './courses/courses.component';
import { AdminRoutingModule } from './admin-routing/admin-routing.module';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    HeaderComponent,
    AdminlayoutComponent,
    DashboardComponent,
    CoursesComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule
  ],  exports:[RouterModule],
  providers: []
})
export class AdminModule { }
