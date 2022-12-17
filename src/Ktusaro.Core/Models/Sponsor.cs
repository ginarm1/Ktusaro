namespace Ktusaro.Core.Models
{
    public class Sponsor
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public CompanyType CompanyType { get; set; }
    }

    public enum CompanyType
    {
        UAB = 1,
        AB = 2
    }
}
