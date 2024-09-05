using HRMS.DTO;
using HRMS.Handler;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            IEnumerable<CandidateDTO> candidates = _candidateService.GetAllCandidates(searchTerm);
            return View(candidates);
        }
        public IActionResult Search(string searchTerm)
        {
            IEnumerable<CandidateDTO> candidates = _candidateService.SearchCandidates(searchTerm);
            return View(candidates);
        }


        // GET: Candidate/Details/5
        public IActionResult Details(int id)
        {
            var candidate = _candidateService.GetCandidateById(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return View(candidate);
        }

        // GET: Candidate/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidate/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CandidateDTO candidateDTO)
        {
            if (ModelState.IsValid)
            {
                _candidateService.AddCandidate(candidateDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(candidateDTO);
        }

        // GET: Candidate/Edit/5
        public IActionResult Edit(int id)
        {
            var candidate = _candidateService.GetCandidateById(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return View(candidate);
        }

        // POST: Candidate/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CandidateDTO candidateDTO)
        {
            if (id != candidateDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _candidateService.UpdateCandidate(candidateDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(candidateDTO);
        }

        // GET: Candidate/Delete/5
        public IActionResult Delete(int id)
        {
            var candidate = _candidateService.GetCandidateById(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return View(candidate);
        }

        // POST: Candidate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _candidateService.DeleteCandidate(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: Candidate/ExportToEmployee/5
        [HttpPost]
        public IActionResult ExportToEmployee(int id)
        {
            _candidateService.ExportToEmployee(id);
            return RedirectToAction("Index", "Employee");
        }
    }
}
