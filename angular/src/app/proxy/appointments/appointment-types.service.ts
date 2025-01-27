import type { AppointmentTypeDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AppointmentTypesService {
  apiName = 'Default';
  

  getAllAppointmentTypes = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppointmentTypeDto[]>({
      method: 'GET',
      url: '/api/appointmenttypes',
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
