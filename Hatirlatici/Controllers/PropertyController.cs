using Hatirlatici.Models;
using Microsoft.AspNetCore.Mvc;

public class PropertyController : Controller
{
    // Geçici veri saklama için static listeler
    public static List<Property> Properties = new List<Property>();
    public static List<Company> Companies = new List<Company>();
    public static List<Branch> Branches = new List<Branch>();

    // Ev Ekleme Sayfası (GET)
    public IActionResult AddProperty()
    {
        // Şirketler ve şubeler listesi ViewBag ile view'a gönderiliyor
        ViewBag.Companies = Companies;
        ViewBag.Branches = Branches;
        return View();
    }

    // Ev Ekleme (POST)
    [HttpPost]
    public IActionResult AddProperty(Property property)
    {
        if (ModelState.IsValid)
        {
            property.Id = Properties.Count + 1;

            // Şirket ve şube ilişkisini burada ekliyoruz
            var company = Companies.FirstOrDefault(c => c.Id == property.CompanyId);
            var branch = Branches.FirstOrDefault(b => b.Id == property.BranchId);

            if (company != null)
            {
                property.Company = company; // Emlakı şirket ile ilişkilendiriyoruz
            }

            if (branch != null)
            {
                property.Branch = branch; // Emlakı şube ile ilişkilendiriyoruz
            }

            Properties.Add(property); // Emlak listeye ekleniyor
            return RedirectToAction("PropertyList"); // Emlak listesine yönlendiriliyor
        }

        // Eğer model geçerli değilse, aynı sayfayı ve verileri tekrar render ediyoruz
        ViewBag.Companies = Companies;
        ViewBag.Branches = Branches;
        return View(property);
    }


    // Ev Listesi Sayfası
    public IActionResult PropertyList()
    {
        return View(Properties);
    }
}
