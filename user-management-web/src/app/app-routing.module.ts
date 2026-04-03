import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './features/user/user.component';
import { UpdateUserComponent } from './features/user/update-user/update-user.component';

const routes: Routes = [
   { path: '', component: UserComponent },
   { path: 'update-user', component: UpdateUserComponent },
   { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
