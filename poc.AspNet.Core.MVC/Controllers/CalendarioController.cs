using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using poc.AspNet.Core.Domain.Interfaces.Services;
using poc.AspNet.Core.Ioc.Entities;
using poc.AspNet.Core.MVC.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace poc.AspNet.Core.MVC.Controllers
{
    [Authorize]
    public class CalendarioController : BaseCrudController<Calendario, CalendarioViewModel>
    {
        protected readonly IUsuarioService _usuarioService;
        public CalendarioController(
            ICalendarioService serviceCrud,
            IMapper mapper,
            IUsuarioService usuarioService) : base(serviceCrud, mapper)
        {
            _usuarioService = usuarioService;
        }

        // GET: Equipe
        public override ActionResult Index()
        {

            return View("Index", _mapper.Map<IEnumerable<Calendario>, IEnumerable<CalendarioViewModel>>(_serviceCrud.GetAll()));
        }

        // GET: Equipe/Create
        public override ActionResult Create()
        {
            var usuario = _usuarioService.BuscarDadosDoUsuario(User.Identity.Name);

            ViewBag.Equipes = new Collection<EquipeViewModel> { _mapper.Map<Equipe, EquipeViewModel>(usuario.Equipe) };
            return View();
        }

        // GET: Equipe/Edit/5
        public override ActionResult Edit(int id)
        {
            var usuario = _usuarioService.BuscarDadosDoUsuario(User.Identity.Name);

            ViewBag.Equipes = new Collection<EquipeViewModel> { _mapper.Map<Equipe, EquipeViewModel>(usuario.Equipe) };

            return View(_mapper.Map<Calendario, CalendarioViewModel>(_serviceCrud.GetById(id)));
        }
    }
}