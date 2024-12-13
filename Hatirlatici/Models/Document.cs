namespace Hatirlatici.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string DocumentName { get; set; } // Belge Adı
        public string DocumentNumber { get; set; } // Belge Numarası
        public DateTime DocumentDate { get; set; } // Belge Tarihi
        public int CompanyId { get; set; } // Şirket ID
        public Company Company { get; set; } // İlişkili Şirket
        public int BranchId { get; set; } // Şube ID
        public Branch Branch { get; set; } // İlişkili Şube
        public int ValidityPeriod { get; set; } // Geçerlilik Süresi
        public string Department { get; set; } // Belgeyi temsil eden departman
    }
}
