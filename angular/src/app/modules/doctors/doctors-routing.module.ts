import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListDoctorsComponent } from './list-doctors/list-doctors.component';
import { DoctorAvailabilityComponent } from './doctor-availability/doctor-availability.component';

const routes: Routes = [
  {
    path:'',
    pathMatch: 'full',
    component: ListDoctorsComponent
  },
  {
    path: ':id',
    pathMatch: 'full',
    component: DoctorAvailabilityComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DoctorsRoutingModule { }
