namespace Hatirlatici.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string ShasiNo { get; set; }
        public string FuelType { get; set; }
        public int BranchId { get; set; } // Şube ID
        public Branch Branch { get; set; } // İlişkilendirilmiş Şube
        public int CompanyId { get; set; } // Şirket ID
        public Company Company { get; set; } // İlişkilendirilmiş Şirket
        public DateTime LastInspectionDate { get; set; }
        public string LastInspection { get; set; }
        public DateTime ValidityPeriod { get; set; }
        public string Description { get; set; }
    }
}
