
export interface AppointmentTypeDto {
  id: number;
  appointmentType?: string;
}

export interface AppointmentsCountDto {
  doctorName?: string;
  appointmentStatus?: string;
  appointmentCount: number;
}

export interface CreateAppointmentDto {
  appointmentDate: string;
  patientId: number;
  doctorId: number;
  appointmentTypeId: number;
}

export interface DoctorAppointmentDto {
  appoinmentId: number;
  appoinmentDate?: string;
  appointmentStatus?: string;
  patientTenantId?: string;
  patientId: number;
  appoinmentTypeId: number;
}

export interface PatientAppointmentDto {
  appointmentId: number;
  appoinmentDate?: string;
  appointmentStatus?: string;
  doctorId: number;
  appoinmentTypeId: number;
}

export interface PatientUpcomingAppointmentDto {
  appointmentId: number;
  appoinmentDate?: string;
  appointmentStatus?: string;
  doctorName?: string;
  appointmentType?: string;
  patientName?: string;
}
