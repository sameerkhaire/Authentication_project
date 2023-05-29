import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


const routes: Routes = [

  {path:'user',loadChildren:()=>import('./User/admin/user.module').then(m=>m.UserModule)},
  {  path:'admin',loadChildren :()=> import('./admin/admin.module').then(m=>m.AdminModule)},
  {
    path: 'public', loadChildren:()=> import('./features/public/public.module').then(m=>m.PublicModule)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
