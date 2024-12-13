namespace Hatirlatici.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }  // İlişkili Şube
    }

}
