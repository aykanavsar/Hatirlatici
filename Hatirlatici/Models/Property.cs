namespace Hatirlatici.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Type { get; set; } // Ev, Arsa, İş Yeri gibi türler
        public string Address { get; set; }
        public int CompanyId { get; set; } // Şirket ID
        public Company Company { get; set; } // İlişkili Şirket
        public int BranchId { get; set; } // Şube ID
        public Branch Branch { get; set; } // İlişkili Şube
        public string InsuranceCompany { get; set; }
        public DateTime InsuranceDate { get; set; }
        public decimal InsurancePrice { get; set; }
        public DateTime InsuranceValidity { get; set; }
        public string KaskoCompany { get; set; }
        public DateTime KaskoDate { get; set; }
        public decimal KaskoPrice { get; set; }
        public DateTime KaskoValidity { get; set; }
        public string DocumentName { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }
        public int ValidityPeriod { get; set; } // Geçerlilik süresi (gün, ay vb.)
    }
}
