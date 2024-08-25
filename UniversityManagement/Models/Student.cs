using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagement.Models
{
    // following class represents a student, inheriting from UniversityMember.
    public class Student : UniversityMember
    {
        public double GPA { get; }
        public string Specialization { get; }
        public int YearOfStudy { get; }

        public Student(int id, string name, double gpa, string specialization, int yearOfStudy)
            : base(id, name)
        {
            GPA = gpa;
            Specialization = specialization;
            YearOfStudy = yearOfStudy;
        }
    }
}
