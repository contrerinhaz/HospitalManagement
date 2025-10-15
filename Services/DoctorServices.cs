using HospitalManagement.Models;
using HospitalManagement.Repositories;

namespace HospitalManagement.Services;

public class DoctorServices
{

    private static DoctorRepository _doctorRepository = new DoctorRepository();

    public static void CreateDoctor(string name, byte age, string identificationNumber, string phone, string email, byte yearsExperience)
    {
        if (string.IsNullOrEmpty(name) || age <= 0 || age >= 100 || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email) || yearsExperience <= 0 || yearsExperience >= 80 || string.IsNullOrEmpty(identificationNumber))
        {
            Console.WriteLine("Invalid Information");
            return;
        }

        try
        {
            Doctor newDoctor = new Doctor(name, age, identificationNumber, phone, email, yearsExperience);
            _doctorRepository.Create(newDoctor);
            Console.WriteLine("Doctor created successfully");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error creating Doctor", err);
        }
    }

    public static List<Doctor> GetDoctors()
    {
        try
        {
            return _doctorRepository.Get();
        }
        catch (Exception err)
        {
            Console.WriteLine("Error getting Doctors", err);
            return [];
        }
    }

    public static Doctor? GetDoctorByIdentification(string identificationNumber)
    {
        if (string.IsNullOrEmpty(identificationNumber))
        {
            Console.WriteLine("Invalid Id");
            return null;
        }

        try
        {
            return _doctorRepository.GetByDocument(identificationNumber);
        }
        catch (Exception err)
        {
            Console.WriteLine("Error getting Doctor by id", err);
            return null;
        }
    }

    public static Doctor? GetDoctorByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Invalid name");
            return null;
        }

        try
        {
            return _doctorRepository.GetByName(name);
        }
        catch (Exception err)
        {
            Console.WriteLine("Error getting doctor by name", err);
            return null;
        }
    }

    public static Doctor? GetDoctorById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid Id");
            return null;
        }

        try
        {
            return _doctorRepository.GetByID(id);
        }
        catch (Exception err)
        {
            Console.WriteLine("Error getting Doctor by id", err);
            return null;
        }
    }

    public static void UpdateDoctor(string id, string newName, byte newAge, string newIdentificationNumber, string newPhone, string newEmail, byte newYearsExperience)
    {
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newName) || newAge <= 0 || newAge > 100 || string.IsNullOrEmpty(newIdentificationNumber) || string.IsNullOrEmpty(newPhone) || string.IsNullOrEmpty(newEmail) || newYearsExperience <= 0 || newYearsExperience > 80)
        {
            Console.WriteLine("Invalid information.");
        }

        try
        {
            Doctor updateDoctor = new Doctor(newName, newAge, newIdentificationNumber, newPhone, newEmail, newYearsExperience);
            _doctorRepository.Update(id, updateDoctor);
            Console.WriteLine("Doctor updated successfully");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error updating doctor.", err);
        }
    }

    public static void RemoveDoctor(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid id");
            return;
        }

        try
        {
            _doctorRepository.Delete(id);
            Console.WriteLine("Doctor removed successfully");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error deleting Doctor", err);
        }
    }
}
