namespace Ktusaro.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Representative Representative { get; set; }
    }

    public enum Representative
    {
        Infosa = 1,
        VivatChemija = 2,
        Vfsa = 3,
        Esa = 4,
        Fumsa = 5,
        Indi = 6,
        Shm = 7,
        Statius = 8
    }
}
