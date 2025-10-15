namespace HospitalManagement.Interfaces;

public interface IGet<T>
{
    public List<T> Get();

    public T? GetByID(string id);

    public T? GetByDocument(string identificationNumber);

    public T? GetByName(string name);
}
