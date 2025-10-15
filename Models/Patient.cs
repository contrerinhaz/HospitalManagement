namespace HospitalManagement.Models;

public class Patient  (string name, string identificationNumber, byte age, string phone, string email) : Person (name, identificationNumber, age, phone, email )
{
    public override void ShowInfo()
    {
        Console.WriteLine($"Id: {this.Id} | Name: {this.Name} | Identification Number: {this.IdentificationNumber} | Age: {this.Age} | Phone: {this.Phone} | Email: {this.Email}");
    }
}
