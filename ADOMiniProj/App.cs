using System;
using System.Collections.Generic;

using CoreLogic.Model;
using CoreLogic.Service;

namespace ADOMiniProj;

class App
{
    private readonly StudentService _studentService;
    public App()
    {
        _studentService= new StudentService();
    }
    public void ShowUI()
    {
        bool shouldWeKeepLooping = true;

        while (shouldWeKeepLooping is true)
        {
            DisplayMenu();
            int choiceOfUser = Convert.ToInt16(Console.ReadLine());

            switch (choiceOfUser)
            {
                case 1:
                    DisplayStudentsList();
                    break;

                case 2:
                    CreateStudent();
                    break;

                case 3:
                    UpdateStudent();
                    break;

                case 4:
                    DeleteStudent();
                    break;

                case 5:
                    DisplayTeachersList();
                    break;

                case 6:
                    shouldWeKeepLooping = false;
                    break;
            }
        }
    }
    private void DisplayMenu()
    {
        Console.WriteLine("\n****************MENU *********************\n" +
                        "1) List students\n" +
                        "2) Create new student\n" +
                        "3) Update student details\n" +
                        "4) Delete student\n" +
                        "5) List Teachers\n"+
                        "6) Exit\n" +
                        "*******************************************\n");
    }
    private void CreateStudent()
    {
        Student s = new Student();

        Console.WriteLine("Please provide the ID of the student:");
        s.Id = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Please provide the name of new student:");
        s.Name = Console.ReadLine();

        Console.WriteLine("Please provide the email of new student:");
        s.Email = Console.ReadLine();

        Console.WriteLine("Please provide the mobile of new student:");
        s.Mobile = Console.ReadLine();

        _studentService.Create(s);
        Console.WriteLine("New student is added!");
    }
    private void DisplayStudentsList()
    {
        var students = _studentService.RetrieveAll();

        Console.WriteLine();
        foreach ( var student in students )
            Console.WriteLine($"{student.Id,-5}{student.Name,-15}{student.Email}");
        Console.WriteLine();
    }
    private void UpdateStudent()
    {
        Student s = new Student();

        Console.WriteLine("Please provide the ID of the student to update:");
        s.Id = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Please provide the updated name of student:");
        s.Name = Console.ReadLine();

        _studentService.Update(s);
        Console.WriteLine("Student name is updated!");

        DisplayStudentsList();
    }
    private void DeleteStudent()
    {
        Console.WriteLine("Please provide the ID of the student to be deleted:");
        int id = Convert.ToInt16(Console.ReadLine());

        _studentService.Delete(id);
        
        Console.WriteLine($"Student {id} deleted!");

        DisplayStudentsList();
    }
    private void DisplayTeachersList()
    {
        Console.WriteLine("Feature comming soon...!");
    }
}
