using HospitalManagement.Services;

namespace HospitalManagement.Utils;

public class Menu
{
    public static void ShowMenu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("===== HOSPITAL MANAGEMENT SYSTEM =====");
            Console.WriteLine("1. Manage Doctors");
            Console.WriteLine("2. Manage Patients");
            Console.WriteLine("3. Manage Appointments");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    DoctorMenu();
                    break;
                case "2":
                    PatientMenu();
                    break;
                case "3":
                    AppointmentMenu();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Press ENTER to continue.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private static void DoctorMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("===== DOCTOR MANAGEMENT =====");
            Console.WriteLine("1. Create Doctor");
            Console.WriteLine("2. List Doctors");
            Console.WriteLine("3. Get Doctor by ID");
            Console.WriteLine("4. Get Doctor by Name");
            Console.WriteLine("5. Get Doctor by Identification");
            Console.WriteLine("6. Update Doctor");
            Console.WriteLine("7. Remove Doctor");
            Console.WriteLine("8. Back to Main Menu");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Age: ");
                    byte age = byte.Parse(Console.ReadLine());
                    Console.Write("Identification Number: ");
                    string idNum = Console.ReadLine();
                    Console.Write("Phone: ");
                    string phone = Console.ReadLine();
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    Console.Write("Years of Experience: ");
                    byte yearsExperience = byte.Parse(Console.ReadLine());
                    DoctorServices.CreateDoctor(name, age, idNum, phone, email, yearsExperience);
                    break;

                case "2":
                    var doctors = DoctorServices.GetDoctors();
                    foreach (var doc in doctors)
                        doc.ShowInfo();
                    break;

                case "3":
                    Console.Write("Doctor ID: ");
                    string id = Console.ReadLine();
                    var doctorById = DoctorServices.GetDoctorById(id);
                    if (doctorById != null)
                        doctorById.ShowInfo();
                    else
                        Console.WriteLine("Doctor not found");
                    break;

                case "4":
                    Console.Write("Name: ");
                    string docName = Console.ReadLine();
                    var doctorByName = DoctorServices.GetDoctorByName(docName);
                    if (doctorByName != null)
                        doctorByName.ShowInfo();
                    else
                        Console.WriteLine("Doctor not found");
                    break;

                case "5":
                    Console.Write("Identification Number: ");
                    string docId = Console.ReadLine();
                    var doctorByDoc = DoctorServices.GetDoctorByIdentification(docId);
                    if (doctorByDoc != null)
                        doctorByDoc.ShowInfo();
                    else
                        Console.WriteLine("Doctor not found");
                    break;

                case "6":
                    Console.Write("Doctor ID: ");
                    string upId = Console.ReadLine();
                    var currentDoctor = DoctorServices.GetDoctorById(upId);
                    if (currentDoctor == null)
                    {
                        Console.WriteLine("Doctor not found");
                        break;
                    }

                    Console.WriteLine("Press ENTER to keep current value:");
                    Console.Write($"New Name ({currentDoctor.Name}): ");
                    string newName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newName)) newName = currentDoctor.Name;

                    Console.Write($"New Age ({currentDoctor.Age}): ");
                    string ageInput = Console.ReadLine();
                    byte newAge = string.IsNullOrWhiteSpace(ageInput) ? currentDoctor.Age : byte.Parse(ageInput);

                    Console.Write($"New Identification Number ({currentDoctor.IdentificationNumber}): ");
                    string newIdNum = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newIdNum)) newIdNum = currentDoctor.IdentificationNumber;

                    Console.Write($"New Phone ({currentDoctor.Phone}): ");
                    string newPhone = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newPhone)) newPhone = currentDoctor.Phone;

                    Console.Write($"New Email ({currentDoctor.Email}): ");
                    string newEmail = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newEmail)) newEmail = currentDoctor.Email;

                    Console.Write("New Years of Experience (press ENTER to keep current): ");
                    string yearsInput = Console.ReadLine();
                    byte newYears = string.IsNullOrWhiteSpace(yearsInput) ? (byte)0 : byte.Parse(yearsInput);

                    DoctorServices.UpdateDoctor(upId, newName, newAge, newIdNum, newPhone, newEmail, newYears);
                    break;

                case "7":
                    Console.Write("Doctor ID: ");
                    string delId = Console.ReadLine();
                    DoctorServices.RemoveDoctor(delId);
                    break;

                case "8":
                    back = true;
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }
    }

    private static void PatientMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("===== PATIENT MANAGEMENT =====");
            Console.WriteLine("1. Create Patient");
            Console.WriteLine("2. List Patients");
            Console.WriteLine("3. Get Patient by ID");
            Console.WriteLine("4. Get Patient by Identification");
            Console.WriteLine("5. Update Patient");
            Console.WriteLine("6. Remove Patient");
            Console.WriteLine("7. Back to Main Menu");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Identification Number: ");
                    string idNum = Console.ReadLine();
                    Console.Write("Age: ");
                    byte age = byte.Parse(Console.ReadLine());
                    Console.Write("Phone: ");
                    string phone = Console.ReadLine();
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    PatientServices.CreatePatiente(name, idNum, age, phone, email);
                    break;

                case "2":
                    var patients = PatientServices.GetPatients();
                    foreach (var p in patients)
                        p.ShowInfo();
                    break;

                case "3":
                    Console.Write("Patient ID: ");
                    string id = Console.ReadLine();
                    var patientById = PatientServices.GetPatientById(id);
                    if (patientById != null)
                        patientById.ShowInfo();
                    else
                        Console.WriteLine("Patient not found");
                    break;

                case "4":
                    Console.Write("Identification Number: ");
                    string ident = Console.ReadLine();
                    var patientByIdent = PatientServices.GetPatientByIdentification(ident);
                    if (patientByIdent != null)
                        patientByIdent.ShowInfo();
                    else
                        Console.WriteLine("Patient not found");
                    break;

                case "5":
                    Console.Write("Patient ID: ");
                    string upId = Console.ReadLine();
                    var currentPatient = PatientServices.GetPatientById(upId);
                    if (currentPatient == null)
                    {
                        Console.WriteLine("Patient not found");
                        break;
                    }

                    Console.WriteLine("Press ENTER to keep current value:");
                    Console.Write($"New Name ({currentPatient.Name}): ");
                    string newName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newName)) newName = currentPatient.Name;

                    Console.Write($"New Identification Number ({currentPatient.IdentificationNumber}): ");
                    string newIdNum = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newIdNum)) newIdNum = currentPatient.IdentificationNumber;

                    Console.Write($"New Age ({currentPatient.Age}): ");
                    string ageInput = Console.ReadLine();
                    byte newAge = string.IsNullOrWhiteSpace(ageInput) ? currentPatient.Age : byte.Parse(ageInput);

                    Console.Write($"New Phone ({currentPatient.Phone}): ");
                    string newPhone = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newPhone)) newPhone = currentPatient.Phone;

                    Console.Write($"New Email ({currentPatient.Email}): ");
                    string newEmail = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newEmail)) newEmail = currentPatient.Email;

                    PatientServices.UpdatePatient(upId, newName, newIdNum, newAge, newPhone, newEmail);
                    break;

                case "6":
                    Console.Write("Patient ID: ");
                    string delId = Console.ReadLine();
                    PatientServices.RemovePatient(delId);
                    break;

                case "7":
                    back = true;
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }
    }

    private static void AppointmentMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("===== APPOINTMENT MANAGEMENT =====");
            Console.WriteLine("1. Create Appointment");
            Console.WriteLine("2. List Appointments");
            Console.WriteLine("3. Get Appointment by ID");
            Console.WriteLine("4. Get Appointment by Name");
            Console.WriteLine("5. Update Appointment");
            Console.WriteLine("6. Remove Appointment");
            Console.WriteLine("7. Back to Main Menu");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Subject: ");
                    string subject = Console.ReadLine();
                    Console.Write("Doctor Name: ");
                    string doctorName = Console.ReadLine();
                    Console.Write("Patient Identification Number: ");
                    string patientId = Console.ReadLine();
                    Console.Write("Symptoms: ");
                    string symptoms = Console.ReadLine();
                    Console.Write("Date (YYYY-MM-DD HH:mm): ");
                    string date = Console.ReadLine();
                    AppointmentServices.CreateAppointment(subject, doctorName, patientId, symptoms, date);
                    break;

                case "2":
                    var appointments = AppointmentServices.GetAppointments();
                    foreach (var a in appointments)
                        a.ShowInfo();
                    break;

                case "3":
                    Console.Write("Appointment ID: ");
                    string id = Console.ReadLine();
                    var appById = AppointmentServices.GetAppointmentById(id);
                    if (appById != null)
                        appById.ShowInfo();
                    else
                        Console.WriteLine("Appointment not found");
                    break;

                case "4":
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    var appByName = AppointmentServices.GetAppointmentByName(name);
                    if (appByName != null)
                        appByName.ShowInfo();
                    else
                        Console.WriteLine("Appointment not found");
                    break;

                case "5":
                    Console.Write("Appointment ID: ");
                    string upId = Console.ReadLine();
                    var currentApp = AppointmentServices.GetAppointmentById(upId);
                    if (currentApp == null)
                    {
                        Console.WriteLine("Appointment not found");
                        break;
                    }

                    Console.WriteLine("Press ENTER to keep current value:");
                    Console.Write($"New Subject ({currentApp.Subject}): ");
                    string newSubject = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newSubject)) newSubject = currentApp.Subject;

                    Console.Write($"Doctor Name ({currentApp.Doctor.Name}): ");
                    string newDoctor = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newDoctor)) newDoctor = currentApp.Doctor.Name;

                    Console.Write($"Patient Name ({currentApp.Patient.Name}): ");
                    string newPatient = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newPatient)) newPatient = currentApp.Patient.Name;

                    Console.Write($"Symptoms ({currentApp.Symptoms}): ");
                    string newSymptoms = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newSymptoms)) newSymptoms = currentApp.Symptoms;

                    Console.Write($"Date ({currentApp.Date}): ");
                    string newDate = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newDate)) newDate = currentApp.Date.ToString();

                    AppointmentServices.UpdateAppointment(upId, newSubject, newDoctor, newPatient, newSymptoms, newDate);
                    break;

                case "6":
                    Console.Write("Appointment ID: ");
                    string delId = Console.ReadLine();
                    AppointmentServices.RemoveAppointment(delId);
                    break;

                case "7":
                    back = true;
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }
    }
}