using HospitalManagement.Repositories;
using HospitalManagement.Models;

namespace HospitalManagement.Services;

public class PatientServices
{
    private static PatientRepository _patientRepository = new PatientRepository();

    public static void CreatePatiente(string name, string identificationNumber, byte age, string phone, string email)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(identificationNumber) || age <= 0 || age > 100 || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email))
        {
            Console.WriteLine("Invalid information.");
        }

        try
        {
            Patient newPatient = new Patient(name, identificationNumber, age, phone, email);
            _patientRepository.Create(newPatient);
            Console.WriteLine("Patiente created successfully.");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error creating Patient.", err);
        }
    }

    public static List<Patient> GetPatients()
    {
        try
        {
            return _patientRepository.Get();
        }
        catch (Exception err)
        {
            Console.WriteLine("Error getting Patients", err);
            return [];
        }
    }

    public static Patient? GetPatientById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid Id");
            return null;
        }

        try
        {
            return _patientRepository.GetByID(id);
        }
        catch (Exception err)
        {
            Console.WriteLine("Error getting patients by id", err);
            return null;
        }
    }

    public static Patient? GetPatientByIdentification(string identificationNumber)
    {
        if (string.IsNullOrEmpty(identificationNumber))
        {
            Console.WriteLine("Invalid name");
            return null;
        }

        try
        {
            return _patientRepository.GetByDocument(identificationNumber);
        }
        catch (Exception err)
        {
            Console.WriteLine("Error getting patient by document", err);
            return null;
        }
    }

    public static void UpdatePatient(string id, string newName, string newIdentificationNumber, byte newAge, string newPhone, string newEmail)
    {
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newIdentificationNumber) || newAge <= 0 || newAge > 100 || string.IsNullOrEmpty(newPhone) || string.IsNullOrEmpty(newEmail))
        {
            Console.WriteLine("Invalid Information");
            return;
        }

        try
        {
            Patient updatePatient = new Patient(newName, newIdentificationNumber, newAge, newPhone, newEmail);
            _patientRepository.Update(id, updatePatient);
            Console.WriteLine("Patient updated successfully");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error updating patient", err);
        }
    }

    public static void RemovePatient(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid id");
            return;
        }

        try
        {
            _patientRepository.Delete(id);
            Console.WriteLine("Patient removed successfully");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error deleting patient", err);
        }
    }
}