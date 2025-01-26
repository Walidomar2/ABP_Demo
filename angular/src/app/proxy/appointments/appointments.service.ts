import type { AppointmentsCountDto, DoctorAppointmentDto, PatientAppointmentDto, PatientUpcomingAppointmentDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AppointmentsService {
  apiName = 'Default';
  

  getAllAppointmentsByPatiantIdById = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PatientAppointmentDto[]>({
      method: 'GET',
      url: `/api/appointments/patientappointments/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getAppointmentCount = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppointmentsCountDto[]>({
      method: 'GET',
      url: '/api/appointments',
    },
    { apiName: this.apiName,...config });
  

  getAppointmentsByDoctorIdById = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DoctorAppointmentDto[]>({
      method: 'GET',
      url: `/api/appointments/doctorappointments/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getAppointmentsByIdAndStartDateAndEndDate = (id: number, startDate: string, endDate: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DoctorAppointmentDto[]>({
      method: 'GET',
      url: `/api/appointments/doctorappointmentsrange/${id}`,
      params: { startDate, endDate },
    },
    { apiName: this.apiName,...config });
  

  getUpcomingAppointmentByPatientIdById = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PatientUpcomingAppointmentDto[]>({
      method: 'GET',
      url: `/api/appointments/patientupcomingappointments/${id}`,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
