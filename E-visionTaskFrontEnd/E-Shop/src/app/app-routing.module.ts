import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { from } from 'rxjs';
import {ShowComponent} from "./components/show/show.component";
import {AddProductComponent} from "./components/add-product/add-product.component";
import {EditComponent} from "./components/edit/edit.component";
import {DetailsComponent} from "./components/details/details.component";
const routes: Routes = [
  {path: '', component: ShowComponent},
  {path: 'show', component: ShowComponent},
  {path: 'add', component: AddProductComponent},
  {path: 'edit/:id', component: EditComponent},
  {path: 'detailes/:id', component: DetailsComponent},
 
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
