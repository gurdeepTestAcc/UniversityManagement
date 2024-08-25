using System;
using UniversityManagement.Models;

namespace UniversityManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // We initialize University
            University university = new University();

            //  Faculties
            Faculty scienceFaculty = new Faculty("Science");
            Faculty artsFaculty = new Faculty("Arts");

            //  Departments
            Department csDepartment = new Department("Computer Science");
            Department mathDepartment = new Department("Mathematics");
            Department historyDepartment = new Department("Arts");

            // we add departments to faculties
            scienceFaculty.AddDepartment(csDepartment);
            scienceFaculty.AddDepartment(mathDepartment);
            artsFaculty.AddDepartment(historyDepartment);

            // we add faculties to university
            university.AddFaculty(scienceFaculty);
            university.AddFaculty(artsFaculty);

            // mock students data
            Student student1 = new Student(1, "Goldy", 3.8, "Software Engineering", 2);
            Student student2 = new Student(2, "Guri", 3.5, "Data Science", 3);
            Student student3 = new Student(3, "Ash", 3.9, "Applied Mathematics", 1);
            Student student4 = new Student(4, "Diana", 3.7, "Arts", 4);

            // we assign students to Departments
            csDepartment.AddStudent(student1);
            csDepartment.AddStudent(student2);
            mathDepartment.AddStudent(student3);
            historyDepartment.AddStudent(student4);

            //  student counts displayed on the console
            Console.WriteLine($"Total Students in {csDepartment.Name} Department: {csDepartment.GetStudentCount()}");
            Console.WriteLine($"Total Students in {mathDepartment.Name} Department: {mathDepartment.GetStudentCount()}");
            Console.WriteLine($"Total Students in {historyDepartment.Name} Department: {historyDepartment.GetStudentCount()}");
            Console.WriteLine($"Total Students in {scienceFaculty.Name} Faculty: {scienceFaculty.GetStudentCount()}");
            Console.WriteLine($"Total Students in {artsFaculty.Name} Faculty: {artsFaculty.GetStudentCount()}");

            // following is sorting and displaying students in Computer Science Department by GPA
            Console.WriteLine($"\nStudents in {csDepartment.Name} sorted by GPA:");
            Student[] sortedByGPA = csDepartment.SortStudentsByGPA();
            foreach (var student in sortedByGPA)
            {
                Console.WriteLine($"{student.Name} - GPA: {student.GPA}");
            }

            // sorting by Specialization
            Console.WriteLine($"\nStudents in {csDepartment.Name} sorted by Specialization:");
            Student[] sortedBySpecialization = csDepartment.SortStudentsBySpecialization();
            foreach (var student in sortedBySpecialization)
            {
                Console.WriteLine($"{student.Name} - Specialization: {student.Specialization}");
            }

            // Sorting by Year of Study
            Console.WriteLine($"\nStudents in {csDepartment.Name} sorted by Year of Study:");
            Student[] sortedByYear = csDepartment.SortStudentsByYearOfStudy();
            foreach (var student in sortedByYear)
            {
                Console.WriteLine($"{student.Name} - Year of Study: {student.YearOfStudy}");
            }

            // here we are searching for students in Science Faculty with GPA >= 3.6
            Console.WriteLine($"\nStudents in {scienceFaculty.Name} Faculty with GPA >= 3.6:");
            Faculty[] faculties = university.GetFaculties();
            foreach (var faculty in faculties)
            {
                if (faculty.Name == "Science")
                {
                    Department[] departments = faculty.GetDepartments();
                    foreach (var department in departments)
                    {
                        Student[] highGPAStudents = department.SearchStudentsByGPA(3.6);
                        foreach (var student in highGPAStudents)
                        {
                            Console.WriteLine($"{student.Name} - GPA: {student.GPA} - Department: {department.Name}");
                        }
                    }
                }
            }

            // searching for students in Computer Science Department specializing in "Data Science"
            Console.WriteLine($"\nStudents in {csDepartment.Name} specializing in 'Data Science':");
            Student[] dataScienceStudents = csDepartment.SearchStudentsBySpecialization("Data Science");
            foreach (var student in dataScienceStudents)
            {
                Console.WriteLine($"{student.Name} - Specialization: {student.Specialization}");
            }

            // searching for students in Mathematics Department in year 1
            Console.WriteLine($"\nStudents in {mathDepartment.Name} in Year 1:");
            Student[] year1Students = mathDepartment.SearchStudentsByYearOfStudy(1);
            foreach (var student in year1Students)
            {
                Console.WriteLine($"{student.Name} - Year of Study: {student.YearOfStudy}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
