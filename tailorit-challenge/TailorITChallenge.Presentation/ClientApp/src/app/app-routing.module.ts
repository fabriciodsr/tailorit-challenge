import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsersComponent } from './users/users.component';
import { UserComponent } from './user/user.component';
import { UserAddEditComponent } from './user-add-edit/user-add-edit.component';


const routes: Routes = [
  { path: '', component: UsersComponent, pathMatch: 'full' },
  { path: 'user/:id', component: UserComponent },
  { path: 'add', component: UserAddEditComponent },
  { path: 'user/edit/:id', component: UserAddEditComponent },
  { path: '**', redirectTo: '/' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
