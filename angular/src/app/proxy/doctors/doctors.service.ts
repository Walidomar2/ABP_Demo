import type { PopularAppointmentDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DoctorDto } from '../booking-system/doctors/models';

@Injectable({
  providedIn: 'root',
})
export class DoctorsService {
  apiName = 'Default';
  

  getAllDoctors = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DoctorDto[]>({
      method: 'GET',
      url: '/api/doctors',
    },
    { apiName: this.apiName,...config });
  

  getPopularAppointmentsById = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PopularAppointmentDto[]>({
      method: 'GET',
      url: `/api/doctors/popularappointments/${id}`,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
