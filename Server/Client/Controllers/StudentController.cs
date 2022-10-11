using Microsoft.AspNetCore.Mvc;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class StudentController : Controller
    {
        HttpClient hc = new HttpClient();
        public StudentController()
        {
            hc.BaseAddress = new Uri("https://localhost:44379/api/");
        }
        public ActionResult Index()
        {
            IEnumerable<Student> list;
            var consumedata = hc.GetAsync("Student");
            consumedata.Wait();
            var data = consumedata.Result;
            if (data.IsSuccessStatusCode)
            {
                var result = data.Content.ReadAsAsync<List<Student>>();
                result.Wait();
                list = result.Result;
                return View(list);
            }
            return Content("Error while retriving data from server");
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student p)
        {
            if (ModelState.IsValid)
            {
                var consumedata = hc.PostAsJsonAsync<Student>("Student", p);
                consumedata.Wait();
                var data = consumedata.Result;
                return RedirectToAction("Index");             
            }
            return View();
        }


        public ActionResult Edit(int id)
        {
            var consumedata = hc.GetAsync($"Student/{id}");
            consumedata.Wait();
            var data = consumedata.Result;
            if (data.IsSuccessStatusCode)
            {
                var res = data.Content.ReadAsAsync<Student>();
                res.Wait();
                return View(res.Result);
            }
            return Content("This ID doesen't exist");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student p)
        {
            if (ModelState.IsValid)
            {
                var consumedata = hc.PutAsJsonAsync<Student>($"Student/{id}", p);
                consumedata.Wait();
                var data = consumedata.Result;
                if (data.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return Content("Error while updating server");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var consumedata = hc.DeleteAsync($"Student/{id}");
            consumedata.Wait();
            var data = consumedata.Result;
            if (data.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Content("Error while deleting data");
        }
    }
}
