using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net.NetworkInformation;
using Todo_web_application.Data;
using Todo_web_application.Models;
using Todo_web_application.Models.Entities;

namespace Todo_web_application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext ;
        }

        public IActionResult Index()
        {
            var list = dbContext.TaskMasters.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskMaster model)
        {
            if (ModelState.IsValid)
            {
                TaskMaster data = new TaskMaster()
                {
                    Task = model.Task,
                    Description = model.Description,
                    TimeTacken = model.TimeTacken,
                    Status = model.Status,
                    AddDate = DateTime.Now
                };

                await dbContext.AddAsync(data);
                await dbContext.SaveChangesAsync();

                
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(Guid id)
        {
            var data = await dbContext.TaskMasters.FindAsync(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskMaster model)
        {
            var data = await dbContext.TaskMasters.FindAsync(model.Id);
            if(data != null)
            {
                data.Task = model.Task;
                data.Description = model.Description;
                data.TimeTacken = model.TimeTacken;
                data.Status = model.Status;
                data.AddDate = DateTime.Now;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpGet] 
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var data = await dbContext.TaskMasters.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
            {
                return NotFound(); 
            }

            dbContext.TaskMasters.Remove(data);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
