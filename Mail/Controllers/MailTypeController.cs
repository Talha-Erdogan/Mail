using Mail.Business.İnterfaces;
using Mail.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mail.Controllers
{
    public class MailTypeController : Controller
    {
        private readonly IMailTypeService _mailTypeService;
        public MailTypeController(IMailTypeService mailTypeService)
        {
            _mailTypeService = mailTypeService;
        }

        public ActionResult List()
        {
            List<MailType> model = new List<MailType>();
            try
            {
                model = _mailTypeService.GetAll();
            }
            catch (Exception ex)
            {
                model = new List<MailType>();
                ViewBag.ErrorMessage = "Error";
            }
            return View(model);
        }


        public ActionResult Add()
        {
            Mail.Data.Entity.MailType model = new MailType();
            return View(model);
        }

        
        [HttpPost]
        public ActionResult Add(Mail.Data.Entity.MailType model)
        {
            if (!ModelState.IsValid)
            {
                //select list
                return View(model);
            }
            MailType mailType = new MailType()
            {
                Name = model.Name
            };

            try
            {
                _mailTypeService.Add(mailType);
                return RedirectToAction(nameof(MailTypeController.List));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Not Saved.";
                return View(model);
            }
        }


        public ActionResult Update(int id)
        {
            Data.Entity.MailType model = null;

            try
            {
                model = _mailTypeService.GetById(id);
                if (model == null)
                {
                    return View("_ErrorNotExist");
                }
            }
            catch
            {
                ViewBag.ErrorMessage = "Record Not Found";
                model = new Data.Entity.MailType();
                return View("_ErrorNotExist");
            }

            return View(model);
        }


        [HttpPost]
        public ActionResult Update(Data.Entity.MailType model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var mailType = _mailTypeService.GetById(model.Id);
                if (mailType == null)
                {
                    return View("_ErrorNotExist");
                }

                mailType.Name = model.Name;

                _mailTypeService.Update(mailType);
                return RedirectToAction(nameof(MailTypeController.List));
            }
            catch
            {
                ViewBag.ErrorMessage = "Not Operation.";
                return View(model);
            }
        }
    }
}
