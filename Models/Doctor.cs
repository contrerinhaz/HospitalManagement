

namespace HospitalManagement.Models;

public class Doctor (string name, byte age, string identificationNumber, string phone , string email) : Person (name, identificationNumber, age, phone, email)
{
    public Doctor(string name, byte age, string identificationNumber, string phone, string email, byte yearsExperience) : this(name, age, identificationNumber, phone, email)
    {
    }

    private byte YearsExperience { get; set; }
    
    public override void ShowInfo()
    {
        Console.WriteLine(
            $"Id: {this.Id} | Name: {this.Name} | Age: {this.Age} | identification Number: {this.IdentificationNumber} | Phone: {this.Phone} | YearsExperience: {this.YearsExperience}");
    }
}
