using System;
using System.Collections.Generic;
using System.Linq;

namespace hospitalLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            hospital.Work();
        }
    }

    class Hospital
    {
        private List<Patient> _patientList = new List<Patient>()
        {
            new Patient("Спиридонова Софья Артёмовна", 62, "Стенокардия"), new Patient("Егорова Мелания Георгиевна", 40, "Камни в почках"),
            new Patient("Лебедев Марк Борисович", 58, "Киста"), new Patient("Большакова Маргарита Фёдоровна", 20, "Вывих"),
            new Patient("Соколова Мия Эмировна", 30, "Бурсит"), new Patient("Любимов Игорь Максимович", 50, "Сахарный диабет"),
            new Patient("Соколов Ибрагим Александрович", 75, "Стенокардия"), new Patient("Данилов Александр Николаевич", 29, "Вывих"),
            new Patient("Федорова София Ивановна", 22, "Киста"), new Patient("Щербаков Тимофей Янович", 66, "Сахарный диабет"),
            new Patient("Ширяев Кирилл Семёнович", 59, "Вывих"), new Patient("Бессонов Святослав Тимофеевич", 19, "Перелом"),
        };

        public void Work()
        {
            const string ShowListWithoutSortingCommand = "1";
            const string SortByFullNameCommand = "2";
            const string SortByAgeCommand = "3";
            const string ShowWithNecessaryDiseaseCommand = "4";
            const string ExitCommand = "5";

            string errorInput = "Введена неверная команда, попробуй ещё раз";
            string exitText = "Выполнение программы завершено";
            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в программу просмотра списка пациентов.");
                Console.WriteLine($"Вводи команды:\n{ShowListWithoutSortingCommand} - показать список больных без сортировки\n{SortByFullNameCommand} - отсортировать список больных по ФИО\n{SortByAgeCommand} - отсортировать список больных по возрасту" +
                    $"\n{ShowWithNecessaryDiseaseCommand} - найти пациентов с определенной болезнью \n{ExitCommand} - выход из программы");
                string input = Console.ReadLine();

                switch (input)
                {
                    case ShowListWithoutSortingCommand:
                        ShowList(_patientList);
                        break;

                    case SortByFullNameCommand:
                        SortPatientsByFullName();
                        break;

                    case SortByAgeCommand:
                        SortPatientsByAge();
                        break;

                    case ShowWithNecessaryDiseaseCommand:
                        ShowPatientsWithNecessaryDisease();
                        break;

                    case ExitCommand:
                        Console.WriteLine(exitText);
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine(errorInput);
                        break;
                }

                Console.ReadKey();
            }
        }

        private void SortPatientsByFullName()
        {
            var sortByFullNameList = _patientList.OrderBy(patient => patient.FullName).ToList();
            ShowList(sortByFullNameList);
        }

        private void SortPatientsByAge()
        {
            var sortByAgeList = _patientList.OrderBy(patient => patient.Age).ToList();
            ShowList(sortByAgeList);
        }

        private void ShowPatientsWithNecessaryDisease()
        {
            Console.Write("Введите название болезни: ");
            string input = Console.ReadLine();

            var withNecessaryDiseaseList = _patientList.Where(patient => patient.Disease.ToUpper() == input.ToUpper()).ToList();

            if (withNecessaryDiseaseList.Count == 0)
            {
                Console.WriteLine("Пациентов с такой болезнью в больнице нет");
            }
            else
            {
                ShowList(withNecessaryDiseaseList);
            }
        }

        private void ShowList(List<Patient> list)
        {
            foreach (var patient in list)
            {
                patient.ShowInfo();
            }
        }

        class Patient
        {
            public Patient(string fullname, int age, string disease)
            {
                FullName = fullname;
                Age = age;
                Disease = disease;
            }

            public string FullName { get; }
            public int Age { get; }
            public string Disease { get; }

            public void ShowInfo()
            {
                Console.WriteLine($"ФИО: {FullName}, возраст: {Age}, заболевание {Disease}");
            }
        }
    }
}