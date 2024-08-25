using System;

namespace UniversityManagement.Models
{
    public class Department
    {
        public string Name { get; }
        private Student[] students;
        private int studentCount;

        public Department(string name, int maxStudents = 100)
        {
            Name = name;
            students = new Student[maxStudents];
            studentCount = 0;
        }

        // the following is method to add a student to the department
        public void AddStudent(Student student)
        {
            if (studentCount < students.Length)
            {
                students[studentCount++] = student;
            }
            else
            {
                throw new InvalidOperationException("Maximum number of students reached.");
            }
        }

        // to get the total number of students in the department
        public int GetStudentCount()
        {
            return studentCount;
        }

        // to get the current list of students
        public Student[] GetStudents()
        {
            Student[] currentStudents = new Student[studentCount];
            for (int i = 0; i < studentCount; i++)
            {
                currentStudents[i] = students[i];
            }
            return currentStudents;
        }

        // using array sort to sort students by GPA in descending order
        public Student[] SortStudentsByGPA()
        {
            Student[] sortedStudents = GetStudents();
            Array.Sort(sortedStudents, (s1, s2) => s2.GPA.CompareTo(s1.GPA));
            return sortedStudents;
        }

        // sorting students by specialization alphabetically
        public Student[] SortStudentsBySpecialization()
        {
            Student[] sortedStudents = GetStudents();
            Array.Sort(sortedStudents, (s1, s2) => string.Compare(s1.Specialization, s2.Specialization, StringComparison.Ordinal));
            return sortedStudents;
        }

        // sorting students by year of study in ascending order
        public Student[] SortStudentsByYearOfStudy()
        {
            Student[] sortedStudents = GetStudents();
            Array.Sort(sortedStudents, (s1, s2) => s1.YearOfStudy.CompareTo(s2.YearOfStudy));
            return sortedStudents;
        }

        // method to search for students with a GPA equal to or higher than the specified value
        public Student[] SearchStudentsByGPA(double minGPA)
        {
            int matchCount = 0;
            for (int i = 0; i < studentCount; i++)
            {
                if (students[i].GPA >= minGPA)
                {
                    matchCount++;
                }
            }

            Student[] matchedStudents = new Student[matchCount];
            int index = 0;
            for (int i = 0; i < studentCount; i++)
            {
                if (students[i].GPA >= minGPA)
                {
                    matchedStudents[index++] = students[i];
                }
            }

            return matchedStudents;
        }

        // searching for students by their specialization
        public Student[] SearchStudentsBySpecialization(string specialization)
        {
            int matchCount = 0;
            for (int i = 0; i < studentCount; i++)
            {
                if (students[i].Specialization.Equals(specialization, StringComparison.OrdinalIgnoreCase))
                {
                    matchCount++;
                }
            }

            Student[] matchedStudents = new Student[matchCount];
            int index = 0;
            for (int i = 0; i < studentCount; i++)
            {
                if (students[i].Specialization.Equals(specialization, StringComparison.OrdinalIgnoreCase))
                {
                    matchedStudents[index++] = students[i];
                }
            }

            return matchedStudents;
        }

        // searching for students by their year of study
        public Student[] SearchStudentsByYearOfStudy(int year)
        {
            int matchCount = 0;
            for (int i = 0; i < studentCount; i++)
            {
                if (students[i].YearOfStudy == year)
                {
                    matchCount++;
                }
            }

            Student[] matchedStudents = new Student[matchCount];
            int index = 0;
            for (int i = 0; i < studentCount; i++)
            {
                if (students[i].YearOfStudy == year)
                {
                    matchedStudents[index++] = students[i];
                }
            }

            return matchedStudents;
        }
    }
}
