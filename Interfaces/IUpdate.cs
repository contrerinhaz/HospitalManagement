namespace HospitalManagement.Interfaces;

public interface IUpdate<T>
{
    public void Update(string id, T entity);
}
