

namespace HospitalManagement.Models;

public abstract class Person (string name, string identificationNumber, byte age, string phone, string email)
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = name;

    public string IdentificationNumber { get; set; } = identificationNumber;

    public byte Age { get; set; } = age;

    public string Phone { get; set; } = phone;

    public string Email { get; set; } = email;
    
    public virtual void ShowInfo()
    {
        Console.WriteLine(
            $"Id: {this.Id} | Name: {this.Name} | Age: {this.Age} | Identification Number: {this.IdentificationNumber} | Phone: {this.Phone} | Email: {this.Email}");
    }
}
