import { Component, OnInit } from '@angular/core';
import { DoctorDto } from '@proxy/doctors';
import { DoctorsService } from '@proxy/doctors';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-list-doctors',
  standalone: true,
  imports: [RouterLink, CommonModule],
  templateUrl: './list-doctors.component.html',
  styleUrl: './list-doctors.component.scss'
})


export class ListDoctorsComponent implements OnInit{
  doctors$?: Observable<DoctorDto[]>;

  constructor(private doctorService: DoctorsService){
  }

  ngOnInit(): void {
    this.doctors$ = this.doctorService.getAllDoctors();
  } 

}
