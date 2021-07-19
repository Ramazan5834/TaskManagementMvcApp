﻿using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManagement.Business.Interfaces;
using TaskManagement.DTO.DTOs.GorevDtos;
using TaskManagement.Entities.Concrete;
using TaskManagement.Web.StringInfo;

namespace TaskManagement.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class GorevController : Controller
    {
        private readonly IGorevService _gorevService;
        private readonly IAciliyetService _aciliyetService;
        private readonly IMapper _mapper;

        public GorevController(IGorevService gorevService, IAciliyetService aciliyetService,IMapper mapper)
        {
            _gorevService = gorevService;
            _aciliyetService = aciliyetService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Gorev;
            //List<Gorev> gorevler = _gorevService.GetirAciliyetIleTamamlanmayan();
            //List<GorevListViewModel> models = new List<GorevListViewModel>();
            //foreach (var item in gorevler)
            //{
            //    GorevListViewModel model = new GorevListViewModel()
            //    {
            //        Aciklama = item.Aciklama,
            //        Aciliyet = item.Aciliyet,
            //        AciliyetId = item.AciliyetId,
            //        Ad = item.Ad,
            //        Durum = item.Durum,
            //        Id = item.Id,
            //        OlusturulmaTarih = item.OlusturulmaTarih
            //    };
            //    models.Add(model);
            //}
            return View(_mapper.Map<List<GorevListDto>>(_gorevService.GetirAciliyetIleTamamlanmayan()));
        }

        public IActionResult EkleGorev()
        {
            TempData["Active"] = TempdataInfo.Gorev;
            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetirHepsi(), "Id", "Tanim");
            return View(new GorevAddDto()); 
        }

        [HttpPost]
        public IActionResult EkleGorev(GorevAddDto model)
        {
            if (ModelState.IsValid)
            {
                 _gorevService.Kaydet(new Gorev()
                 {
                     Aciklama = model.Aciklama,
                     Ad = model.Ad,
                     AciliyetId = model.AciliyetId
                 });
                 return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult GuncelleGorev(int id)
        {
            TempData["Active"] = TempdataInfo.Gorev;
            var gorev = _gorevService.GetirIdile(id);
            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetirHepsi(), "Id", "Tanim",gorev.AciliyetId);
            return View(_mapper.Map<GorevUpdateDto>(gorev));
        }

        [HttpPost]
        public IActionResult GuncelleGorev(GorevUpdateDto model)
        {
            TempData["Active"] = TempdataInfo.Gorev;
            if (ModelState.IsValid)
            {
                _gorevService.Guncelle(new Gorev()
                {
                    Id = model.Id,
                    Aciklama = model.Aciklama,
                    AciliyetId = model.AciliyetId,
                    Ad = model.Ad
                });
                return RedirectToAction("Index");
            }
            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetirHepsi(), "Id", "Tanim", model.AciliyetId);
            return View();
        }

        public IActionResult SilGorev(int id)
        {
            _gorevService.Sil(new Gorev()
            {
                Id = id
            });
            return Json(null);
        }
    }
}
