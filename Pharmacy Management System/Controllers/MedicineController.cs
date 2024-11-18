using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy_Management_System.Data;
using Pharmacy_Management_System.Models;
using Pharmacy_Management_System.Reposatory;
using Pharmacy_Management_System.ViewModel;

namespace Pharmacy_Management_System.Controllers
{
    [Authorize]
    public class MedicineController : Controller
    {
        IReposatory<Medicine> MedicineReposatory;
        IReposatory<Stock> StockReposatory;
        public MedicineController(IReposatory<Medicine> medicineReposatory, IReposatory<Stock> _StockReposatory)
        {
            MedicineReposatory = medicineReposatory;
            StockReposatory = _StockReposatory;
        }
        [HttpGet]
        public IActionResult Add()
        {
            MedicineViewModel medicine = new MedicineViewModel();
            medicine.Stocks = StockReposatory.GetAll();
            return View("Add",medicine);
        }
        [HttpPost]
        public IActionResult SaveAdd(MedicineViewModel medicine) { 
            Medicine _medicine = new Medicine();
            medicine.Stocks = StockReposatory?.GetAll();
            if (ModelState.IsValid && medicine.Quantity>0 && medicine.PricePerUnit >0.00M&&medicine.StockId>0) {
                _medicine.Name = medicine.Name;
                _medicine.Description = medicine.Description;
                _medicine.ExpiryDate = medicine.ExpiryDate;
                _medicine.ManufacturingDate = medicine.ManufacturingDate;
                _medicine.Quantity = medicine.Quantity;
                _medicine.PricePerUnit = medicine.PricePerUnit;
                _medicine.StockId = medicine.StockId;
                MedicineReposatory.Add(_medicine);
                MedicineReposatory.Save();
                return RedirectToAction("AllMedicines");
            }

            return View("Add", medicine);
        }
        public IActionResult AllMedicines()
        {
            List<Medicine> medicines = MedicineReposatory.GetAll();
            return View("AllMedicines",medicines);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            MedicineViewModel medicineViewModel = new MedicineViewModel();
            Medicine medicine = MedicineReposatory.GetById(id); 
            medicineViewModel.Id = id;  
            medicineViewModel.Name = medicine.Name;
            medicineViewModel.Quantity = medicine.Quantity;
            medicineViewModel.PricePerUnit = medicine.PricePerUnit;
            medicineViewModel.ExpiryDate = medicine.ExpiryDate;
            medicineViewModel.ManufacturingDate = medicine.ManufacturingDate;
            medicineViewModel.Description = medicine.Description;
            medicineViewModel.StockId = medicine.StockId;
            medicineViewModel.Stocks = StockReposatory.GetAll();    
            return View("Edit",medicineViewModel);
        }
        [Authorize,HttpPost]
        public IActionResult SaveEdit(MedicineViewModel medicine) {
            if (ModelState.IsValid) {
                Medicine MedicineTosave = new Medicine();
                MedicineTosave.Id = medicine.Id;
                MedicineTosave.Name = medicine.Name;
                MedicineTosave.Quantity = medicine.Quantity;
                MedicineTosave.PricePerUnit = medicine.PricePerUnit;
                MedicineTosave.ExpiryDate = medicine.ExpiryDate;
                MedicineTosave.ManufacturingDate = medicine.ManufacturingDate;
                MedicineTosave.Description = medicine.Description;
                MedicineTosave.StockId = medicine.StockId;
                MedicineReposatory.Update(MedicineTosave);
                MedicineReposatory.Save();
                return RedirectToAction("AllMedicines");
            }
            else
            {
                return RedirectToAction("Edit");
            }
        }
        public IActionResult Delete(int id) { 
            MedicineReposatory.Delete(id);
            MedicineReposatory.Save();
            return RedirectToAction("AllMedicines");
        }
        public IActionResult SellMedicine()
        {
            SellMedicineViewModel sellMedicineViewModel = new SellMedicineViewModel();
            Medicine medicine = new Medicine();
            sellMedicineViewModel.Medicines = MedicineReposatory.GetAll();
            return View("SellMedicine", sellMedicineViewModel);
        }
  //      public IActionResult SaveSellMedicine(SellMedicineViewModel sellMedicineViewModel)
  //      {
  //          if (ModelState.IsValid) { 
                
  //          }
  //          else
		//		return View("SellMedicine", sellMedicineViewModel);
		//}

    }
}
