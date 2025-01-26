import { Component, OnInit } from '@angular/core';
import { DoctorDto } from '@proxy/booking-system/doctors';
import { DoctorsService } from '@proxy/doctors';
import { RouterLink } from '@angular/router';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-list-doctors',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './list-doctors.component.html',
  styleUrl: './list-doctors.component.scss'
})


export class ListDoctorsComponent implements OnInit{
  doctors: DoctorDto[];

  constructor(private doctorService: DoctorsService){
  }

  ngOnInit(): void {
    this.doctorService.getAllDoctors().subscribe((response) => {
      this.doctors = response;
    });
  } 

}
