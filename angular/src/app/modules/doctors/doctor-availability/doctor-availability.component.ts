import { Component, OnInit, NgModule, OnDestroy } from '@angular/core';
import { DoctorAvailabilityDto, DoctorsService } from '@proxy/doctors';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe, CommonModule } from '@angular/common';
import { Subscription } from 'rxjs';
import { ThemeSharedModule, ToasterService  } from '@abp/ng.theme.shared';
import { AppointmentsService, AppointmentTypeDto, AppointmentTypesService, CreateAppointmentDto } from '@proxy/appointments';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-doctor-availability',
  standalone: true,
  imports: [DatePipe, CommonModule,ThemeSharedModule, FormsModule],
  templateUrl: './doctor-availability.component.html',
  styleUrl: './doctor-availability.component.scss'
})

export class DoctorAvailabilityComponent implements OnInit, OnDestroy{
  id: number ;
  doctorName: string | null = null;
  doctorAvailabilities: DoctorAvailabilityDto[];
  appointmentTypes: AppointmentTypeDto[];
  isModalOpen: boolean = false;
  modalDate:string | null = null;
  model: CreateAppointmentDto;

  paramSubscription?: Subscription;
  getAvailabilitySubscription?: Subscription;
  getAppointmentTypesSubscription?: Subscription;
  createAppointmentSubscription?: Subscription;


  constructor(private route: ActivatedRoute,
    private doctorService: DoctorsService,
    private appointmentTypesService: AppointmentTypesService,
    private appointmentService: AppointmentsService,
    private router: Router,
    private toasterService: ToasterService)
    {
      this.model = {
        patientId: undefined,
        doctorId: this.id,
        appointmentDate: '',
        appointmentTypeId: undefined,
      };
    }

  ngOnDestroy(): void {
    this.paramSubscription?.unsubscribe();
    this.getAvailabilitySubscription?.unsubscribe();
    this.getAppointmentTypesSubscription?.unsubscribe();
    this.createAppointmentSubscription?.unsubscribe();
  }

  /*buttonClicked(date: string): void{
    this.isModalOpen = true; 
    this.modalDate = date
  }*/

  ngOnInit(): void {
    this.paramSubscription = this.route.paramMap.subscribe({
      next: (param) => {
        this.id = Number(param.get('id'));
      }
    });

    if(this.id)
    {
      this.model.doctorId = this.id;
      this.getAvailabilitySubscription = this.doctorService.getDoctorAvailabilityById(this.id).subscribe({
        next: (response) =>{
          this.doctorAvailabilities = response;
          this.doctorName = response[0].doctorName;
        }
      });

      this.getAppointmentTypesSubscription = this.appointmentTypesService.getAllAppointmentTypes().subscribe({
        next: (response) => {
         // console.log(response);
          this.appointmentTypes = response;
        }
      })
    }
  }

  onFormSubmit():void{
    this.model.appointmentDate = this.modalDate;
    this.model.patientId = Number(this.model.patientId);
    this.model.appointmentTypeId = Number(this.model.patientId);
    this.router.navigateByUrl('/doctors');
    this.toasterService.success('Appointment Booked.');



    /*console.log(typeof this.model.appointmentTypeId);
    console.log(this.model);*/
  }
}
