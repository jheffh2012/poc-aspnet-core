using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using poc.AspNet.Core.Domain.Interfaces.Services;
using poc.AspNet.Core.Ioc.Entities;
using poc.AspNet.Core.MVC.Models;
using System.Collections.ObjectModel;

namespace poc.AspNet.Core.MVC.Controllers
{
    [Authorize]
    public class EventoController : BaseCrudController<Evento, EventoViewModel>
    {
        protected readonly ICalendarioService _calendarioService;
        protected readonly IUsuarioService _usuarioService;
        protected readonly IEventoConfirmacaoService _eventoConfirmacaoService;
        public EventoController(
            IEventoService serviceCrud,
            ICalendarioService calendarioService,
            IUsuarioService usuarioService,
            IEventoConfirmacaoService eventoConfirmacaoService,
            IMapper mapper
        ) : base(serviceCrud, mapper)
        {
            _calendarioService = calendarioService;
            _usuarioService = usuarioService;
            _eventoConfirmacaoService = eventoConfirmacaoService;
        }

        // GET: Equipe/Create
        public override ActionResult Create()
        {
            ViewBag.Calendarios = _calendarioService.BuscarCalendariosDoUsuario(User.Identity.Name);
            ViewBag.Usuarios = new Collection<UsuarioViewModel> { _mapper.Map<Usuario, UsuarioViewModel>(_usuarioService.BuscarDadosDoUsuario(User.Identity.Name)) };
            return View();
        }

        // GET: Equipe/Edit/5
        public override ActionResult Edit(int id)
        {
            ViewBag.Calendarios = _calendarioService.BuscarCalendariosDoUsuario(User.Identity.Name);

            ViewBag.Usuarios = new Collection<UsuarioViewModel> { _mapper.Map<Usuario, UsuarioViewModel>(_usuarioService.BuscarDadosDoUsuario(User.Identity.Name)) };

            return View(_mapper.Map<Evento, EventoViewModel>(_serviceCrud.GetById(id)));
        }

        // GET: Equipe/Details/5
        public override ActionResult Details(int id)
        {
            var evento = _serviceCrud.GetById(id);

            var retorno = _mapper.Map<Evento, EventoViewModel>(evento);

            IEventoService _serv = _serviceCrud as IEventoService;

            retorno.PercentualConfirmacao = _serv.BuscarPercentualConfirmacao(evento);
            return View(retorno);
        }

        // GET: Equipe/Confirmar/5
        public virtual ActionResult Confirmar(int Id)
        {
            _eventoConfirmacaoService.UsuarioConfirmaPresenca(User.Identity.Name, Id);

            return RedirectToAction("Details");
        }
    }
}