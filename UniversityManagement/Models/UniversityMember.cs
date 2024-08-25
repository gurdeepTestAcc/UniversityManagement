namespace UniversityManagement.Models
{

    // it represents a member of the university (base class).
    public abstract class UniversityMember
    {
        public int Id { get; }
        public string Name { get; }

        protected UniversityMember(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
