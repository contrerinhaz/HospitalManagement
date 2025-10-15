using HospitalManagement.Data;
using HospitalManagement.Interfaces;
using HospitalManagement.Models;

namespace HospitalManagement.Repositories;

public class PatientRepository : ICreate<Patient>, IGet<Patient>, IUpdate<Patient>, IDelete
{
    public PatientRepository()
    {
    }

    public void Create(Patient Patient)
    {
        DataBase.Patients.Add(Patient);
    }

    public List<Patient> Get()
    {
        return DataBase.Patients;
    }

    public Patient? GetByID(string id)
    {
        throw new NotImplementedException();
    }

    public Patient? GetByDocument(string identificationNumber)
    {
        throw new NotImplementedException();
    }

     public Patient? GetByName(string name)
    {
        return DataBase.Patients.Find((patient => patient.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));
    }
    public void Update(string id, Patient Patient)
    {
        DataBase.Patients =
            DataBase.Patients.Select((own => own.Id.ToString() == id ? Patient : own)).ToList();
    }
    public void Remove(string id)
    {
        DataBase.Patients = DataBase.Patients.Where((Patient => Patient.Id.ToString() != id)).ToList();
    }
    public void Delete(string identificationNumber)
    {
        throw new NotImplementedException();
    }
}
