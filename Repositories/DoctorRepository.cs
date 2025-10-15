using HospitalManagement.Data;
using HospitalManagement.Interfaces;
using HospitalManagement.Models;

namespace HospitalManagement.Repositories;

public class DoctorRepository : ICreate<Doctor>, IGet<Doctor>, IUpdate<Doctor>, IDelete
{
    public void Create(Doctor Doctor)
    {
        DataBase.Doctors.Add(Doctor);
    }

    public List<Doctor> Get()
    {
        return DataBase.Doctors;
    }

    public Doctor? GetByID(string id)
    {
        return DataBase.Doctors.Find((Doctor => Doctor.Id.ToString() == id));
    }

    public Doctor? GetByDocument(string identificationNumber)
    {
        return DataBase.Doctors.Find((Doctor => Doctor.IdentificationNumber.Equals(identificationNumber, StringComparison.OrdinalIgnoreCase)));
    }

    public Doctor? GetByName(string name)
    {
        return DataBase.Doctors.Find((Doctor => Doctor.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));
    }

    public void Update(string id, Doctor Doctor)
    {
        DataBase.Doctors =
            DataBase.Doctors.Select((vet => vet.Id.ToString() == id ? Doctor : vet)).ToList();
    }

    public void Delete(string id)
    {
        DataBase.Doctors = DataBase.Doctors.Where((Doctor => Doctor.Id.ToString() != id)).ToList();
    }


}
