using ClinicConsoleApp;

List<Doctor> doctorsList = new List<Doctor>();
int[,] Journal = new int[4, 7];

int idCounter = 0;

void ClinicMenu()
{
    try
    {
        Console.WriteLine("To add a doctor enter - 1");
        Console.WriteLine("To show a doctor enter - 2");
        Console.WriteLine("To add a patient enter - 3");
        Console.WriteLine("To show all doctors enter - 4");
        Console.WriteLine("To create a journal enter - 5");

        int userPick = int.Parse(Console.ReadLine());

        switch (userPick)
        {
            case 1:
                AddDoctor();
                break;
            case 2:
                ShowDoctorByName();
                break;
            case 3:
                AddPatientToDoctor();
                break;
            case 4:
                ShowAllDoctors();
                break;
            case 5:
                createJournal();
                break;

            default:
                Console.WriteLine("Please enter valid number");
                ClinicMenu();
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        ClinicMenu();
    }
}
ClinicMenu();




void AddDoctor()
{
    Doctor newDoctor = new Doctor();

    Console.WriteLine("Enter doctor first name");
    newDoctor.fName = Console.ReadLine();

    Console.WriteLine("Enter doctor last name");
    newDoctor.lName = Console.ReadLine();

    Console.WriteLine("Enter doctor position");
    newDoctor.position = Console.ReadLine();

    Console.WriteLine("Enter birth year");
    newDoctor.birthYear = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter number of patients");
    newDoctor.numberOfPatients = int.Parse(Console.ReadLine());

    doctorsList.Add(newDoctor);

    SaveDoctorFile(newDoctor);
    AddToAllDoctorsFile(newDoctor);
    ClinicMenu();
}



void SaveDoctorFile(Doctor doctor)
{
    FileStream doctorFs = new FileStream($@"C:\STREAM\CLINIC\{doctor.fName} {doctor.lName}.txt", FileMode.Append);
    using (StreamWriter writer = new StreamWriter(doctorFs))
    {
        writer.WriteLine($"name: {doctor.fName} {doctor.lName}, position: {doctor.position}, birth year: {doctor.birthYear}, number of patients: {doctor.numberOfPatients}");
    }
}


void AddToAllDoctorsFile(Doctor doctor)
{
    try
    {
        FileStream getDoctorFs = new FileStream($@"C:\STREAM\CLINIC\all doctors.txt", FileMode.Open);
        using (StreamReader reader = new StreamReader(getDoctorFs))
        {
            int count = 0;
            while (reader.ReadLine() != null)
            {
                count++;
            }
            idCounter = count;
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    FileStream allDoctorFs = new FileStream(@"C:\STREAM\CLINIC\all doctors.txt", FileMode.Append);
    using (StreamWriter writer = new StreamWriter(allDoctorFs))
    {
        writer.WriteLine($"id: {idCounter}, name: {doctor.fName} {doctor.lName}, position: {doctor.position}, birth year: {doctor.birthYear}, number of patients: {doctor.numberOfPatients},");
    }

}


void ShowDoctorByName()
{
    Console.WriteLine("enter doctor full name");
    string doctorName = Console.ReadLine();

    FileStream getDoctorFs = new FileStream($@"C:\STREAM\CLINIC\{doctorName}.txt", FileMode.Open);
    using (StreamReader reader = new StreamReader(getDoctorFs))
    {
        Console.WriteLine(reader.ReadLine());
    }
    ClinicMenu();
}



void ShowAllDoctors()
{
    FileStream getAllDoctorFs = new FileStream($@"C:\STREAM\CLINIC\all doctors.txt", FileMode.Open);
    using (StreamReader reader = new StreamReader(getAllDoctorFs))
    {
        for (int i = 0; i < reader.Peek(); i++)
        {
            Console.WriteLine(reader.ReadLine());
        }
    }
    ClinicMenu();
}


void AddPatientToDoctor()
{
    string doctorNew;
    Console.WriteLine("enter doctor full name");
    string doctorName = Console.ReadLine();

    FileStream addPatientOpenFs = new FileStream($@"C:\STREAM\CLINIC\{doctorName}.txt", FileMode.Open);
    using (StreamReader reader = new StreamReader(addPatientOpenFs))
    {
        string doctorInfo = reader.ReadLine();

        string doctorNewInfo = doctorInfo.Substring(0, doctorInfo.IndexOf("patients:") + 10);
        int patients = int.Parse(doctorInfo.Substring(doctorInfo.IndexOf("patients:") + 10));
        patients++;
        doctorNew = $"{doctorNewInfo}{patients}";
        Console.WriteLine(doctorNew);
    }


    FileStream addPatientFs = new FileStream($@"C:\STREAM\CLINIC\{doctorName}.txt", FileMode.Create);
    using (StreamWriter writer = new StreamWriter(addPatientFs))
    {
        writer.WriteLine(doctorNew);
    }
    SortByPatients();
    ClinicMenu();
}


void SortByPatients()
{
    foreach (Doctor doc in doctorsList)
    {
        Console.WriteLine($"name: {doc.fName} {doc.lName}, position: {doc.position}, birth year: {doc.birthYear}, number of patients: {doc.numberOfPatients}");
    }

    doctorsList.Sort();

    foreach (Doctor doc in doctorsList)
    {
        Console.WriteLine($"name: {doc.fName} {doc.lName}, position: {doc.position}, birth year: {doc.birthYear}, number of patients: {doc.numberOfPatients}");
    }
}




void createJournal()
{
    Console.WriteLine("enter number of floors");
    int rows = int.Parse(Console.ReadLine());

    Console.WriteLine("enter number of patients");
    int columns = int.Parse(Console.ReadLine());

    Journal userJournal = new Journal(rows, columns);

    userJournal.PrintJournal();
}
