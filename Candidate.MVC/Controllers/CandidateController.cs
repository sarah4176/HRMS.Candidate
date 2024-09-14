using HRMS.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace HRMS.MVC.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        // GET: Candidate
        public IActionResult Index(string searchTerm)
        {
            var candidates = _candidateService.GetAllCandidates(searchTerm);
            ViewData["SearchTerm"] = searchTerm;  // Pass search term to view
            return View(candidates);
        }


        // GET: Candidate/Create
        public IActionResult Create()
        {
            var jobs = _candidateService.GetJobList();
            ViewBag.Jobs = new SelectList(jobs, "Id", "Title");
            return View();
        }


        // POST: Candidate/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CandidateDTO candidateDTO)
        {
            _candidateService.AddCandidate(candidateDTO);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [ActionName("EditCandidate")]
        public IActionResult EditGet(int id)
        {
            var candidate = _candidateService.GetCandidateById(id);
            var jobs = _candidateService.GetJobList();
            ViewBag.Jobs = new SelectList(jobs, "Id", "Title");

            return View("EditCandidate", candidate);  // Ensure the correct view name is passed
        }

        [HttpPost]
        [ActionName("EditCandidate")]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(CandidateDTO candidateDTO)
        {
            _candidateService.UpdateCandidate(candidateDTO);
            return RedirectToAction(nameof(Index));
        }




        // GET: Candidate/Delete/5
        // GET: Candidate/Delete/5
        public IActionResult Delete(int id)
        {
            var candidate = _candidateService.GetCandidateById(id);
            return View(candidate);  // No need for try/catch here as service handles it
        }

        // POST: Candidate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _candidateService.DeleteCandidate(id);
            return RedirectToAction(nameof(Index));
        }



        //// POST: Candidate/ExportToEmployee/5
        //[HttpPost]
        //public IActionResult ExportToEmployee(int id)
        //{
        //    _candidateService.ExportToEmployee(id);
        //    return RedirectToAction("Index", "Employee");
        //}
    }
}
