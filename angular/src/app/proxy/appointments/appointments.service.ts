import type { AppointmentsCountDto, CreateAppointmentDto, DoctorAppointmentDto, PatientAppointmentDto, PatientUpcomingAppointmentDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AppointmentsService {
  apiName = 'Default';
  

  createAppointmentByCreateAppointmentModel = (createAppointmentModel: CreateAppointmentDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CreateAppointmentDto>({
      method: 'POST',
      url: '/api/appointments',
      params: { appointmentDate: createAppointmentModel.appointmentDate, patientId: createAppointmentModel.patientId, doctorId: createAppointmentModel.doctorId, appointmentTypeId: createAppointmentModel.appointmentTypeId },
    },
    { apiName: this.apiName,...config });
  

  getDoctorAppointmentsById = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DoctorAppointmentDto[]>({
      method: 'GET',
      url: `/api/appointments/doctorappointments/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDoctorAppointmentsCountAndStatus = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppointmentsCountDto[]>({
      method: 'GET',
      url: '/api/appointments',
    },
    { apiName: this.apiName,...config });
  

  getDoctorAppointmentsRangeByIdAndStartDateAndEndDate = (id: number, startDate: string, endDate: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DoctorAppointmentDto[]>({
      method: 'GET',
      url: `/api/appointments/doctorappointmentsrange/${id}`,
      params: { startDate, endDate },
    },
    { apiName: this.apiName,...config });
  

  getPatientAppointmentsById = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PatientAppointmentDto[]>({
      method: 'GET',
      url: `/api/appointments/patientappointments/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getPatientUpcomingAppointmentsById = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PatientUpcomingAppointmentDto[]>({
      method: 'GET',
      url: `/api/appointments/patientupcomingappointments/${id}`,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
