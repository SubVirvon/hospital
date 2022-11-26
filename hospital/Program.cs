using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital(new Patient[]
            {
                new Patient("Игорь", "грипп", 20),
                new Patient("Владислав", "деменция", 13),
                new Patient("Глеб", "ожирение", 24),
                new Patient("Дмитрий", "астма", 17),
                new Patient("Аркадий", "диабет", 16),
                new Patient("Борис", "ожирение", 21),
                new Patient("Дмитрий", "грипп", 34),
                new Patient("Александра", "грипп", 12),
                new Patient("Мария", "диабет", 18),
                new Patient("Елена", "астма", 24),
            });

            hospital.Work();
        }
    }

    class Hospital
    {
        private Patient[] _patients;

        public Hospital(Patient[] patients)
        {
            _patients = patients;
        }

        public void Work()
        {
            const string CommandSortByName = "1";
            const string CommandSortByAge = "2";
            const string CommandSortDiseaseName = "3";
            bool isWork = true;

            while (isWork)
            {
                Console.Write($"{CommandSortByName}. Сортировать по имени\n{CommandSortByAge}. Сортировать по возрасту\n{CommandSortDiseaseName}. Найти по заболеванию\nВведите команду: ");

                switch(Console.ReadLine())
                {
                    case CommandSortByName:
                        ShowSortByName();
                        break;
                    case CommandSortByAge:
                        ShowSortByAge();
                        break;
                    case CommandSortDiseaseName:
                        ShowSortDiseaseName();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Некоректная команда");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ShowSortByName()
        {
            ShowSortPatients(_patients.OrderBy(patient => patient.Name).ToArray());
        }

        private void ShowSortByAge()
        {
            ShowSortPatients(_patients.OrderBy(patients => patients.Age).ToArray());
        }

        private void ShowSortDiseaseName()
        {
            Console.Clear();
            Console.Write("Введите болезнь: ");

            string diseases = Console.ReadLine();

            Patient[] patients = _patients.Where(patient => patient.DiseaseName == diseases).ToArray();

            if (patients.Length > 0)
                ShowSortPatients(patients);
            else
                Console.WriteLine("Пациенты с такой болезнью не найдены");
        }

        private void ShowSortPatients(Patient[] patients)
        {
            Console.Clear();

            for(int i = 0; i < patients.Length; i++)
            {
                Console.WriteLine($"{i + 1}.{patients[i].Name}, возраст: {patients[i].Age}, заболевание: {patients[i].DiseaseName}");
            }
        }
    }

    class Patient
    {
        public string Name { get; private set; }
        public string DiseaseName { get; private set; }
        public int Age { get; private set; }

        public Patient(string name, string diseaseName, int age)
        {
            Name = name;
            DiseaseName = diseaseName;
            Age = age;
        }
    }
}
