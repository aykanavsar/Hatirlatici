using Microsoft.AspNetCore.Mvc;
using Hatirlatici.Models;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Hatirlatici.Controllers
{
   

    public class OrganizationController : Controller
    {
        // Geçici veri saklama için static listeler
        public static List<GroupCompany> GroupCompanies = new List<GroupCompany>();
        public static List<Company> Companies = new List<Company>();
        public static List<City> Cities = new List<City>();
        public static List<Branch> Branches = new List<Branch>();
        public static List<Brand> Brands = new List<Brand>();

        // Grup Şirketler Sayfası
        public IActionResult GroupCompany()
        {
            return View(GroupCompanies);
        }

        // Grup Şirket Ekleme (GET)
        public IActionResult AddGroupCompany()
        {
            return View();
        }

        // Grup Şirket Ekleme (POST)
        [HttpPost]
        public IActionResult AddGroupCompany(GroupCompany groupCompany)
        {
            groupCompany.Id = GroupCompanies.Count + 1;
            GroupCompanies.Add(groupCompany);
            return RedirectToAction("GroupCompany");
        }

        // Şirketler Sayfası
        public IActionResult Company()
        {
            return View(Companies);
        }

        // Şirket Ekleme (GET)
        public IActionResult AddCompany()
        {
            ViewBag.GroupCompanies = GroupCompanies; // Grup şirket dropdown için
            return View();
        }

        // Şirket Ekleme (POST)
        [HttpPost]
        public IActionResult AddCompany(Company company)
        {
            company.Id = Companies.Count + 1;
            Companies.Add(company);
            return RedirectToAction("Company");
        }

        // Şehirler Sayfası
        public IActionResult City()
        {
            return View(Cities);
        }

        // Şehir Ekleme (GET)
        public IActionResult AddCity()
        {
            return View();
        }

        // Şehir Ekleme (POST)
        [HttpPost]
        public IActionResult AddCity(City city)
        {
            city.Id = Cities.Count + 1;
            Cities.Add(city);
            return RedirectToAction("City");
        }

        // Şubeler Sayfası
        public IActionResult Branch()
        {
            return View(Branches);
        }

        // Şube Ekleme (GET)
        public IActionResult AddBranch()
        {
            ViewBag.Companies = Companies; // Şirket dropdown için
            return View();
        }

        // Şube Ekleme (POST)
        [HttpPost]
        [HttpPost]
        public IActionResult AddBranch(Branch branch)
        {
            if (ModelState.IsValid)
            {
                branch.Id = Branches.Count + 1;
                var company = Companies.FirstOrDefault(c => c.Id == branch.CompanyId);
                if (company != null)
                {
                    branch.Company = company; // Şubeyi seçilen şirketle ilişkilendiriyoruz
                }
                Branches.Add(branch);
                return RedirectToAction("Branch");
            }
            ViewBag.Companies = Companies;
            return View(branch); // Eğer model geçerli değilse, aynı sayfayı render et
        }



        // Markalar/Alt Şirketler Sayfası
        public IActionResult Brand()
        {
            return View(Brands); // Brands listesi, View'a gönderiliyor.
        }

        // Marka/Alt Şirket Ekleme (GET)
        public IActionResult AddBrand()
        {
            ViewBag.Branches = Branches; // Şube dropdown için
            return View();
        }

        // Marka/Alt Şirket Ekleme (POST)
        [HttpPost]
        public IActionResult AddBrand(Brand brand)
        {
            if (ModelState.IsValid)
            {
                brand.Id = Brands.Count + 1;
                var branch = Branches.FirstOrDefault(b => b.Id == brand.BranchId);
                if (branch != null)
                {
                    brand.Branch = branch; // Markayı seçilen şube ile ilişkilendiriyoruz
                }
                Brands.Add(brand);
                return RedirectToAction("Brand");
            }
            ViewBag.Branches = Branches;
            return View(brand); // Eğer model geçerli değilse, aynı sayfayı render et
        }



    }

}
