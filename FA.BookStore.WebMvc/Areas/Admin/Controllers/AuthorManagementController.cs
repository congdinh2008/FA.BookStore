using FA.BookStore.Core.Models;
using FA.BookStore.Core.Repositories;
using System;
using System.Net;
using System.Web.Mvc;

namespace FA.BookStore.WebMvc.Areas.Admin.Controllers
{
    public class AuthorManagementController : Controller
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorManagementController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        // GET: Admin/AuthorManagement
        public ActionResult Index()
        {
            return View(_authorRepository.GetAll());
        }

        // GET: Admin/AuthorManagement/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = _authorRepository.Find((Guid)id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Admin/AuthorManagement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AuthorManagement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Author author)
        {
            if (ModelState.IsValid)
            {
                author.Id = Guid.NewGuid();
                _authorRepository.Add(author);
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Admin/AuthorManagement/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = _authorRepository.Find((Guid)id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Admin/AuthorManagement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Author author)
        {
            if (ModelState.IsValid)
            {
                _authorRepository.Update(author);
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Admin/AuthorManagement/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = _authorRepository.Find((Guid)id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Admin/AuthorManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Author author = _authorRepository.Find(id);
            _authorRepository.Delete(author);
            return RedirectToAction("Index");
        }
    }
}
