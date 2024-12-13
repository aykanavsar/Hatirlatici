namespace Hatirlatici.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GroupCompanyId { get; set; }
        public GroupCompany GroupCompany { get; set; }  // İlişkili Grup Şirket
    }





}