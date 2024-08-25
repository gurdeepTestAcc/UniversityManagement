using System;

namespace UniversityManagement.Models
{
    public class Faculty
    {
        public string Name { get; }
        //Array to store departments within the faculty.
        private Department[] departments;
        private int departmentCount;

        public Faculty(string name, int maxDepartments = 10)
        {
            Name = name;
            departments = new Department[maxDepartments];
            departmentCount = 0;
        }
        // it adds a department to the faculty.
        public void AddDepartment(Department department)
        {
            if (departmentCount < departments.Length)
            {
                departments[departmentCount++] = department;
            }
            else
            {
                throw new InvalidOperationException("Maximum number of departments reached.");
            }
        }

        //it gets the total number of students in the faculty across all departments.
        public int GetStudentCount()
        {
            int count = 0;
            for (int i = 0; i < departmentCount; i++)
            {
                count += departments[i].GetStudentCount();
            }
            return count;
        }

        // gets the list of current departments in the faculty
        public Department[] GetDepartments()
        {
            Department[] currentDepartments = new Department[departmentCount];
            for (int i = 0; i < departmentCount; i++)
            {
                currentDepartments[i] = departments[i];
            }
            return currentDepartments;
        }
    }
}
