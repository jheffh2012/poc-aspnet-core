using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using poc.AspNet.Core.Domain.Interfaces.Services;
using poc.AspNet.Core.Ioc.Entities;
using poc.AspNet.Core.MVC.Models;

namespace poc.AspNet.Core.MVC.Controllers
{
    [Authorize]
    public class EventoConfirmacaoController : BaseCrudController<EventoConfirmacao, EventoConfirmacaoViewModel>
    {
        public EventoConfirmacaoController(IEventoConfirmacaoService serviceCrud, IMapper mapper) : base(serviceCrud, mapper)
        {
        }
    }
}