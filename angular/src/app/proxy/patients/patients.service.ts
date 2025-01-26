import type { PatientDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PatientsService {
  apiName = 'Default';
  

  getAllPatient = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, PatientDto[]>({
      method: 'GET',
      url: '/api/patients',
    },
    { apiName: this.apiName,...config });
  

  getPatientByIdById = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PatientDto>({
      method: 'GET',
      url: `/api/patients/${id}`,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
