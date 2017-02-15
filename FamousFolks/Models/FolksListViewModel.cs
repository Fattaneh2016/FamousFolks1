namespace FamousFolks.Models
{
    public class FolksListViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthLocation { get; set; }
        public int? ExpertiseId { get; set; }

        public string Expertise { get; set; }
        public string Bio { get; set; }


    }
}