import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { WorkplaceComponent } from '../components/data-elements/workplace/workplace.component';

const routes: Routes = [
  { path: "home", component: WorkplaceComponent },
  { path: '', redirectTo: "home", pathMatch: "full" }
];

@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forRoot(routes)]
})
export class AppRoutingModule { }