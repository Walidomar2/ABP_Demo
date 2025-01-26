import { Component, OnInit } from '@angular/core';
import { DoctorAvailabilityDto, DoctorsService } from '@proxy/doctors';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-doctor-availability',
  standalone: true,
  imports: [DatePipe],
  templateUrl: './doctor-availability.component.html',
  styleUrl: './doctor-availability.component.scss'
})

export class DoctorAvailabilityComponent implements OnInit{
  id: number ;
  doctorName: string | null = null;
  doctorAvailabilities: DoctorAvailabilityDto[];

  constructor(private route: ActivatedRoute,
    private doctorService: DoctorsService)
    {}


  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (param) => {
        this.id = Number(param.get('id'));
      }
    });

    if(this.id)
    {
      this.doctorService.getDoctorAvailabilityById(this.id).subscribe({
        next: (response) =>{
          this.doctorAvailabilities = response;
          this.doctorName = response[0].doctorName;
        }
      });
    }
  }

}
