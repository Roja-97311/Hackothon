using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using SampleFrameworkApp;
using System.IO;

namespace SampleFrameworkApp
{

    class Patient
    {
        public string DiseaseName { get; set; }
        public string Severity { get; set; }
        public Object Symtoms { get; set; }
        public string Causes { get; set; }
        public string Description { get; set; }
        public string PatientName { get; set; }
    }
    class Doctor
    {
        public static ArrayList doc = null;
        private Patient[] _patient = null;

      
        public void AddNewDiseaseName(Patient pt)
        {
            for (int i = 0; i < _patient.Length; i++)
            {
                _patient[i] = new Patient { DiseaseName = pt.DiseaseName, Severity = pt.Severity, Causes = pt.Causes, Description = pt.Description };
                return;
            }

        }
        public Patient AddNewSymtoms(string diseaseName)
        {
            {
                foreach (Patient pt in _patient)
                {
                    if (pt.DiseaseName == diseaseName)
                        return pt;
                }
                throw new Exception("No Record found");
            }

        }
        
            

        
        public void CheckPatient(Patient pt)
        {

            for (int i = 0; i < _patient.Length; i++)
            {

                _patient[i] = new Patient { DiseaseName = pt.DiseaseName, Symtoms = pt.Symtoms, Description = pt.Description };
 }
        }

    }


    enum SeverityOptions { high, medium, low };
    enum CausesOption { externalFactors, internalDisorder }

    class UIDisplay
    {
      
        public static Doctor doctor = null;

        internal static void DisplayMenu(string file)
        {

            bool processing = true;
            string menu = File.ReadAllText(file);
            do
            {
                int choice = Utilities.GetNumber(menu);
                processing = processMenu(choice);
            } while (processing);
            Console.WriteLine("Thanks for using our application");
        }

        private static bool processMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddingNewDisease();
                    break;
                case 2:
                    AddingNewSymtoms();
                    break;
                case 3:
                    CheckingPatient();
                    break;


                default:
                    return false;
            }
            return true;
        }
        private static void AddingNewDisease()
        {
            string diesesName = Utilities.prompt("Enter the Dieses Name:");

            Console.WriteLine("select the severity in the bellow options");
            Array PosibleSeverityOptions = Enum.GetValues(typeof(SeverityOptions));
            for (int i = 0; i < PosibleSeverityOptions.Length; i++)
            {
                Console.WriteLine(PosibleSeverityOptions.GetValue(i));
            }
            string severity = Console.ReadLine();
            Console.WriteLine("select the Causes in the bellow options");
            Array PosibleCausesOptions = Enum.GetValues(typeof(CausesOption));
            for (int i = 0; i < PosibleCausesOptions.Length; i++)
            {
                Console.WriteLine(PosibleCausesOptions.GetValue(i));
            }
            string causes = Console.ReadLine();

            string description = Utilities.prompt("enter the description");
            Patient pt = new Patient { DiseaseName = diesesName, Causes = causes, Severity = severity, Description = description };
            doctor.AddNewDiseaseName(pt);
            Utilities.prompt("Press Enter to clear the Screen");
            Console.Clear();
        }
        private static void AddingNewSymtoms()
        {
            string diseaseName = Utilities.prompt("Enter the Dieses Name:");
            Patient patient= doctor.AddNewSymtoms(diseaseName);
            


            string symtoms = Utilities.prompt("Enter the Symptoms :");
            Doctor.doc = new ArrayList();
            Doctor.doc.Add(symtoms);

            string description = Utilities.prompt("enter the description");
            Patient pt = new Patient { DiseaseName = diseaseName, Symtoms = symtoms, Description = description };
         

        }
        private static void CheckingPatient()
        {
            string patientName = Utilities.prompt("Enter the Patient Name :");
            string symptoms = Utilities.prompt("Enter the symtoms :");
            Patient pt = new Patient { PatientName = patientName, Symtoms = symptoms };
            doctor.CheckPatient(pt);

        }

    }
        class Assignments
        {
            static void Main(string[] args)
            {
                UIDisplay.DisplayMenu(args[0]);
            }
        }
    
}




    




