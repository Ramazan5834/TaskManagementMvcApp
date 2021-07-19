using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Business.Interfaces;
using TaskManagement.DTO.DTOs.AciliyetDtos;
using TaskManagement.Entities.Concrete;
using TaskManagement.Web.StringInfo;

namespace TaskManagement.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class AciliyetController : Controller
    {
        private readonly IAciliyetService _aciliyetService;
        private readonly IMapper _mapper;

        public AciliyetController(IAciliyetService aciliyetService,IMapper mapper)
        {
            _aciliyetService = aciliyetService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Aciliyet;
            //List<Aciliyet> aciliyetler = _aciliyetService.GetirHepsi();
            //List<AciliyetListViewModel> model = new List<AciliyetListViewModel>();
            //foreach (var item in aciliyetler)
            //{
            //    AciliyetListViewModel aciliyetModel = new AciliyetListViewModel();
            //    aciliyetModel.Id = item.Id;
            //    aciliyetModel.Tanim = item.Tanim;
            //    model.Add(aciliyetModel);
            //}
            //return View(model);
            return View(_mapper.Map<List<AciliyetListDto>>(_aciliyetService.GetirHepsi()));
        }

        public IActionResult EkleAciliyet()
        {
            TempData["Active"] = TempdataInfo.Aciliyet;
            return View(new AciliyetAddDto());
        }

        [HttpPost]
        public IActionResult EkleAciliyet(AciliyetAddDto model)
        {
            if (ModelState.IsValid)
            {
                _aciliyetService.Kaydet(new Aciliyet()
                {
                    Tanim = model.Tanim
                });
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult GuncelleAciliyet(int id)
        {
            TempData["Active"] = TempdataInfo.Aciliyet;


            return View( _mapper.Map<AciliyetUpdateDto>(_aciliyetService.GetirIdile(id)));
        }

        [HttpPost]
        public IActionResult GuncelleAciliyet(AciliyetUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                //_aciliyetService.Guncelle(new Aciliyet()
                //{
                //    Id = model.Id,
                //    Tanim = model.Tanim
                //});
                _aciliyetService.Guncelle(_mapper.Map<Aciliyet>(model));
                return RedirectToAction("Index");
            }

            return View(model); 
        }
    }
}
