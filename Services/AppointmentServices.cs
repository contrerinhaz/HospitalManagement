using HospitalManagement.Models;
using HospitalManagement.Repositories;

namespace HospitalManagement.Services;

public class AppointmentServices
{
    private static AppointmentRepository _appointmentRepository = new AppointmentRepository();

    public static void CreateAppointment(string subject, string doctorName, string patientIdentificationNumber, string symptoms, string date)
    {
        if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(doctorName) || string.IsNullOrEmpty(patientIdentificationNumber) || string.IsNullOrEmpty(symptoms) || string.IsNullOrEmpty(date))
        {
            Console.WriteLine("Invalid Information");
            return;
        }

        var doctor = DoctorServices.GetDoctorByName(doctorName);
        var patient = PatientServices.GetPatientByIdentification(patientIdentificationNumber);
        if (doctor == null)
        {
            Console.WriteLine("No doctor found");
            return;
        }

        if (patient == null)
        {
            Console.WriteLine("No patient found");
            return;
        }

        if (!DateTime.TryParse(date, out var dateTime))
        {
            Console.WriteLine("Invalid Date");
        }

        try
        {
            Appointment newAppointment = new Appointment(subject, doctor, patient, symptoms, dateTime);

            var appointment = _appointmentRepository.Get();

            bool Conflict = appointment.Any(a =>
                a.Doctor.Name == newAppointment.Doctor.Name &&
                (
                    (newAppointment.Date >= a.Date &&
                    newAppointment.Date < a.Date + TimeSpan.FromHours(1)) ||
                    (a.Date >= newAppointment.Date &&
                     a.Date < newAppointment.Date + TimeSpan.FromHours(1))
                )
            );

            if (Conflict)
            {
                Console.WriteLine("There is already an appointment at that time for this doctor");
                return;
            }

            _appointmentRepository.Create(newAppointment);
            Console.WriteLine("Appointment created successfully");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error creating appointment", err);
        }
    }

    public static List<Appointment> GetAppointments()
    {
        try
        {
            return _appointmentRepository.Get();
        }
        catch (Exception err)
        {
            Console.WriteLine("Error getting Appointments", err);
            return [];
        }
    }

    public static Appointment? GetAppointmentById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid Id");
            return null;
        }

        try
        {
            return _appointmentRepository.GetByID(id);
        }
        catch (Exception err)
        {
            Console.WriteLine("Error getting appointment by id", err);
            return null;
        }
    }

    public static Appointment? GetAppointmentByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Invalid name");
            return null;
        }

        try
        {
            return _appointmentRepository.GetByName(name);
        }
        catch (Exception err)
        {
            Console.WriteLine("Error getting appointment by name", err);
            return null;
        }
    }

    public static void UpdateAppointment(string id, string subject, string doctorName, string patientName,
        string symptoms,
        string date)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(doctorName) || string.IsNullOrEmpty(patientName) ||
            string.IsNullOrEmpty(symptoms) || string.IsNullOrEmpty(date))
        {
            Console.WriteLine("Invalid Information");
            return;
        }

        // Validate doctor and patient
        var doctor = DoctorServices.GetDoctorByName(doctorName);
        var patient = PatientServices.GetPatientByIdentification(patientName);
        if (doctor == null)
        {
            Console.WriteLine("No doctor found");
            return;
        }

        if (patient == null)
        {
            Console.WriteLine("No patient found");
            return;
        }

        if (!DateTime.TryParse(date, out var dateTime))
        {
            Console.WriteLine("Invalid Date");
            return;
        }

        try
        {
            Appointment newAppointment = new Appointment(subject, doctor, patient, symptoms, dateTime);

            // Validate date
            var appointments = _appointmentRepository.Get();

            bool Conflict = appointments.Any(a =>
                a.Doctor.Id == newAppointment.Doctor.Id &&
                (
                    (newAppointment.Date >= a.Date &&
                     newAppointment.Date < a.Date + TimeSpan.FromHours(1)) || // empieza dentro de otra cita
                    (a.Date >= newAppointment.Date &&
                     a.Date < newAppointment.Date + TimeSpan.FromHours(1)) // otra cita empieza dentro de esta
                )
            );

            if (Conflict)
            {
                Console.WriteLine("There is already an appointment at that time for this veterinarian");
            }

            _appointmentRepository.Update(id, newAppointment);
            Console.WriteLine("Appointment updated successfully");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error updating appointment", err);
        }
    }

    public static void RemoveAppointment(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid id");
            return;
        }

        try
        {
            _appointmentRepository.Delete(id);
            Console.WriteLine("Appointment removed successfully");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error deleting appointment", err);
        }
    }

    internal static void UpdateAppointment(Guid id, string? newSubject, string? newDoctor, string? newPatientIdentification, string? newSymptoms, string? newDate)
    {
        throw new NotImplementedException();
    }
}
