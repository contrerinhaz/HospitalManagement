namespace HospitalManagement.Models;

public class Appointment(string subject, Doctor doctor, Patient patient, string symptoms, DateTime date)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Subject { get; set; } = subject;
    public Doctor Doctor { get; set; } = doctor;
    public Patient Patient { get; set; } = patient;
    public string Symptoms { get; set; } = symptoms;
    public DateTime Date { get; set; } = date;


    public void ShowInfo()
    {
        Console.WriteLine(
            $"Id: {Id} | Subject: {Subject} | Doctor: {Doctor.Name} | Patient: {Patient.Name} | Symptoms: {Symptoms} | Date: {Date.ToString()}");
    }
}