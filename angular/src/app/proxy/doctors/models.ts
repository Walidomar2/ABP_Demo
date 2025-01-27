
export interface DoctorAvailabilityDto {
  doctorName?: string;
  day?: string;
  start?: string;
  end?: string;
}

export interface DoctorDto {
  id: number;
  name?: string;
  specialization?: string;
  email?: string;
  phoneNumber?: string;
}

export interface PopularAppointmentDto {
  appointmentType?: string;
  count: number;
}
