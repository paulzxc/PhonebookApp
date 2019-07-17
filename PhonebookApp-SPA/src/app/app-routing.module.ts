import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContactComponent } from './contact/contact.component';
import { ContactDetailComponent } from './contact/contact-detail/contact-detail.component';

const routes: Routes = [
  {
    path: 'contacts', children: [
      {
        path: '', component: ContactComponent
      },
      {
        path: 'new', component: ContactDetailComponent
      },
      {
        path: ':id', component: ContactDetailComponent
      }
    ],
  },
  {
    path: '', redirectTo: '/contacts', pathMatch: 'full'
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
