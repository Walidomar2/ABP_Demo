import { Component, OnInit, NgModule, OnDestroy } from '@angular/core';
import { DoctorAvailabilityDto, DoctorsService } from '@proxy/doctors';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe, CommonModule } from '@angular/common';
import { Subscription } from 'rxjs';


@Component({
  selector: 'app-doctor-availability',
  standalone: true,
  imports: [DatePipe, CommonModule],
  templateUrl: './doctor-availability.component.html',
  styleUrl: './doctor-availability.component.scss'
})

export class DoctorAvailabilityComponent implements OnInit, OnDestroy{
  id: number ;
  doctorName: string | null = null;
  doctorAvailabilities: DoctorAvailabilityDto[];

  paramSubscription?: Subscription;
  getAvailabilitySubscription?: Subscription;


  constructor(private route: ActivatedRoute,
    private doctorService: DoctorsService)
    {}

  ngOnDestroy(): void {
    this.paramSubscription?.unsubscribe();
    this.getAvailabilitySubscription?.unsubscribe();
  }


  ngOnInit(): void {
    this.paramSubscription = this.route.paramMap.subscribe({
      next: (param) => {
        this.id = Number(param.get('id'));
      }
    });

    if(this.id)
    {
      this.getAvailabilitySubscription = this.doctorService.getDoctorAvailabilityById(this.id).subscribe({
        next: (response) =>{
          this.doctorAvailabilities = response;
          this.doctorName = response[0].doctorName;
        }
      });
    }
  }

}
