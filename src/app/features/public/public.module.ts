import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { CartComponent } from './cart/cart.component';
import { PaymentComponent } from './payment/payment.component';
import { LayoutComponent } from './shared/layout/layout.component';
import { FullLayoutComponent } from './shared/layout/full-layout/full-layout.component';
import { PublicRoutingModule } from './public-routing/public-routing.module';
import { CourseComponent } from './course/course.component';
import { MycoursesComponent } from './mycourses/mycourses.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { HeaderComponent } from './shared/header/header.component';
import { FooterComponent } from './shared/footer/footer.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {  HttpClientModule } from '@angular/common/http';
import { NgToastModule } from 'ng-angular-popup';

@NgModule({
  declarations: [
    HomeComponent,
    LoginComponent,
    NotFoundComponent,
    SignUpComponent,
    CartComponent,
    PaymentComponent,
    LayoutComponent,
    FullLayoutComponent,
    CourseComponent,
    MycoursesComponent,
    UnauthorizedComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    PublicRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgToastModule
 
  ],
  exports:[RouterModule],
  providers: []
})
export class PublicModule { }
