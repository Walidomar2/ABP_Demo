
export interface DoctorAvailabilityDto {
  doctorName?: string;
  day?: string;
  start?: string;
  end?: string;
}

export interface PopularAppointmentDto {
  appointmentType?: string;
  count: number;
}
