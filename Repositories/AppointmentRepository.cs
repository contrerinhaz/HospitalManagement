using HospitalManagement.Data;
using HospitalManagement.Models;
using HospitalManagement.Interfaces;

namespace HospitalManagement.Repositories;

public class AppointmentRepository : ICreate<Appointment>, IGet<Appointment>, IUpdate<Appointment>, IDelete
{
    public AppointmentRepository()
    {
    }

    public void Create(Appointment appointment)
    {
        DataBase.Appoitments.Add(appointment);
    }

    public List<Appointment> Get()
    {
        return DataBase.Appoitments;
    }

    public Appointment? GetByID(string id)
    {
        return DataBase.Appoitments.Find((appointment => appointment.Id.ToString() == id));
    }

    public Appointment? GetByName(string subject)
    {
        return DataBase.Appoitments.Find((appointment => appointment.Subject.Equals(subject, StringComparison.OrdinalIgnoreCase)));
    }

    public void Update(string id, Appointment appointment)
    {
        DataBase.Appoitments =
            DataBase.Appoitments.Select((appo => appo.Id.ToString() == id ? appointment : appo)).ToList();
    }

    public void Delete(string id)
    {
        DataBase.Appoitments = DataBase.Appoitments.Where((appointment => appointment.Id.ToString() != id)).ToList();
    }

    public Appointment? GetByDocument(string identificationNumber)
    {
        throw new NotImplementedException();
    }
}
