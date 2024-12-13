using Microsoft.AspNetCore.Mvc;
using Hatirlatici.Models;

namespace Hatirlatici.Controllers
{
    public class VehicleController : Controller
    {
        // Geçici veri saklama için static listeler
        public static List<Vehicle> Vehicles = new List<Vehicle>();

        // Araçlar Sayfası
        public IActionResult Vehicle()
        {
            return View(Vehicles); // Araçlar listesini view'a gönderiyoruz.
        }

        // Araç Ekleme (GET)
        public IActionResult AddVehicle()
        {
            // ViewBag ile Branches ve Companies verilerini gönderiyoruz
            ViewBag.Branches = OrganizationController.Branches; // Şube listesini ViewBag ile gönder
            ViewBag.Companies = OrganizationController.Companies; // Şirket listesini ViewBag ile gönder
            return View(); // Ekleme formunu döndürüyoruz
        }

        // Araç Ekleme (POST)
        [HttpPost]
        public IActionResult AddVehicle(Vehicle vehicle)
        {
            // Yeni araç ekleme işlemi
            vehicle.Id = Vehicles.Count + 1; // Yeni araç için ID ataması
            var branch = OrganizationController.Branches.FirstOrDefault(b => b.Id == vehicle.BranchId);
            if (branch != null)
            {
                vehicle.Branch = branch; // Araç şubeyle ilişkilendiriliyor
            }

            Vehicles.Add(vehicle); // Yeni aracı listeye ekliyoruz
            return RedirectToAction("Vehicle"); // Araçlar sayfasına yönlendiriyoruz
        }
    }
}
