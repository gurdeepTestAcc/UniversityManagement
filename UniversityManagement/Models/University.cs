using System;

namespace UniversityManagement.Models
{
    //it represents a university that contains multiple faculties.
    public class University
    {
        private Faculty[] faculties;
        private int facultyCount;

        public University(int maxFaculties = 10)
        {
            faculties = new Faculty[maxFaculties];
            facultyCount = 0;
        }

        // following method adds a faculty to the university.
        public void AddFaculty(Faculty faculty)
        {
            if (facultyCount < faculties.Length)
            {
                faculties[facultyCount++] = faculty;
            }
            else
            {
                throw new InvalidOperationException("Maximum number of faculties reached.");
            }
        }

        // it gets the list of current faculties in the university.
        public Faculty[] GetFaculties()
        {
            Faculty[] currentFaculties = new Faculty[facultyCount];
            for (int i = 0; i < facultyCount; i++)
            {
                currentFaculties[i] = faculties[i];
            }
            return currentFaculties;
        }
    }
}
