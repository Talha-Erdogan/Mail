using Mail.Business;
using Mail.Business.İnterfaces;
using Mail.Data.Entity;
using Mail.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mail.Controllers
{
    public class MailDetailController : Controller
    {

        private readonly IMailTypeService _mailTypeService;
        private readonly IMailDetailService _mailDetailService;
        public MailDetailController(IMailTypeService mailTypeService, IMailDetailService mailDetailService)
        {
            _mailTypeService = mailTypeService;
            _mailDetailService = mailDetailService;
        }

        public ActionResult List()
        {
            MailDetailViewModel model = new MailDetailViewModel();
            try
            {
                model.MailTypeSelectList= _mailTypeService.GetAll().Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).OrderBy(x => x.Text).ToList(); ;
            }
            catch (Exception ex)
            {
                model = new MailDetailViewModel();
                ViewBag.ErrorMessage = "Error";
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult List(MailDetailViewModel model)
        {
            if (!ModelState.IsValid ||model.TypeId ==null || model.TypeId <=0 || string.IsNullOrEmpty(model.Header)||string.IsNullOrEmpty(model.Body))
            {
                //select list
                model.MailTypeSelectList = _mailTypeService.GetAll().Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).OrderBy(x => x.Text).ToList();
                ViewBag.ErrorMessage = "Error";
                return View(model);
            }
            
            try
            {
                model.MailTypeSelectList = _mailTypeService.GetAll().Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).OrderBy(x => x.Text).ToList();

                MailDetail mailDetail = new MailDetail()
                {
                    TypeId = model.TypeId,
                    Body = model.Body,
                    Header = model.Header
                };
                var record= _mailDetailService.GetByMailTypeId(model.TypeId);
                if (record ==null)
                {
                    _mailDetailService.Add(mailDetail);
                }
                else
                {
                    record.Body = model.Body;
                    record.Header = model.Header;
                    _mailDetailService.Update(record);
                }
                
                return RedirectToAction(nameof(MailDetailController.List));
            }
            catch (Exception ex)
            {
                model = new MailDetailViewModel();
                ViewBag.ErrorMessage = "Error";
            }
            return View(model);
        }


        [HttpPost]
        public JsonResult SelectMailDetail(int[] data)
        {
            try
            {
                if (data == null || data[0]<=0)
                {
                    return Json("2");
                }

                var mailDetail = _mailDetailService.GetByMailTypeId(data[0]);
                return Json(mailDetail);
            }
            catch { return Json("0"); }
        }


    }
}
