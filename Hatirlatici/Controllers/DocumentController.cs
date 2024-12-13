using Hatirlatici.Models;
using Microsoft.AspNetCore.Mvc;

public class DocumentController : Controller
{
    // Geçici veri saklama için static listeler
    public static List<Document> Documents = new List<Document>();
    public static List<Company> Companies = new List<Company>();
    public static List<Branch> Branches = new List<Branch>();

    // Belge Ekleme Sayfası (GET)
    public IActionResult AddDocument()
    {
        // Şirketler ve şubeler listesi ViewBag ile view'a gönderiliyor
        ViewBag.Companies = Companies;
        ViewBag.Branches = Branches;
        return View();
    }

    // Belge Ekleme (POST)
    [HttpPost]
    public IActionResult AddDocument(Document document)
    {
        if (ModelState.IsValid)
        {
            // Yeni belge ekleniyor
            document.Id = Documents.Count + 1;

            // Şirket ve şube ilişkisi kontrol ediliyor
            var company = Companies.FirstOrDefault(c => c.Id == document.CompanyId);
            var branch = Branches.FirstOrDefault(b => b.Id == document.BranchId);

            if (company != null)
            {
                document.Company = company; // Belgeyi şirket ile ilişkilendiriyoruz
            }

            if (branch != null)
            {
                document.Branch = branch; // Belgeyi şube ile ilişkilendiriyoruz
            }

            Documents.Add(document); // Belge listeye ekleniyor
            return RedirectToAction("DocumentList"); // Belge listesine yönlendiriliyor
        }

        // Eğer model geçerli değilse, aynı sayfayı ve verileri tekrar render ediyoruz
        ViewBag.Companies = Companies;
        ViewBag.Branches = Branches;
        return View(document);
    }

    // Belge Listesi Sayfası
    public IActionResult DocumentList()
    {
        return View(Documents);
    }
}
