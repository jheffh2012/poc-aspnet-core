using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using poc.AspNet.Core.Domain.Interfaces.Services;
using poc.AspNet.Core.Ioc.Entities;
using poc.AspNet.Core.MVC.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace poc.AspNet.Core.MVC.Controllers
{
    public class ContaController : Controller
    {
        protected readonly IUsuarioService _service;
        protected readonly IEquipeService _serviceEquipe;
        protected readonly IPrevisaoTempoService _servicePrevisaoTempo;
        protected readonly IMapper _mapper;

        public ContaController(
            IUsuarioService service,
            IEquipeService serviceEquipe,
            IPrevisaoTempoService servicePrevisaoTempo,
            IMapper mapper
        )
        {
            _service = service;
            _serviceEquipe = serviceEquipe;
            _mapper = mapper;
            _servicePrevisaoTempo = servicePrevisaoTempo;
        }
        // Return Home page.
        public ActionResult Index()
        {
            if (User.Identity?.Name != null)
            {
                ViewBag.DadosUsuario = _service.BuscarDadosDoUsuario(User.Identity.Name);
                ViewBag.PrevisaoTempo = _mapper.Map<PrevisaoTempoCidade, PrevisaoTempoCidadeViewModel>(_servicePrevisaoTempo.GetPrevisaoPorIp(HttpContext.Connection.RemoteIpAddress.ToString()));
                return View("Logado");
            }


            return View();
        }

        // Return Home page.
        public ActionResult Logado()
        {
            if (User.Identity != null && User.Identity.Name != null && User.Identity.Name != "")
            {
                ViewBag.DadosUsuario = _service.BuscarDadosDoUsuario(User.Identity.Name);
                ViewBag.PrevisaoTempo = _mapper.Map<PrevisaoTempoCidade, PrevisaoTempoCidadeViewModel>(_servicePrevisaoTempo.GetPrevisaoPorIp(HttpContext.Connection.RemoteIpAddress.ToString()));
                return View();
            }


            return View();
        }

        //Return Register view
        public ActionResult Register()
        {
            var equipes = _mapper.Map<IEnumerable<Equipe>, IEnumerable<EquipeViewModel>>(_serviceEquipe.GetAll());
            var model = new UsuarioViewModel {
                Equipes = new SelectList(equipes, "Id", "Nome")
            };
            
            return View(model);
        }

        //The form's data in Register view is posted to this method. 
        //We have binded the Register View with Register ViewModel, so we can accept object of Register class as parameter.
        //This object contains all the values entered in the form by the user.
        [HttpPost]
        public ActionResult Register(UsuarioViewModel usuario)
        {
            //We check if the model state is valid or not. We have used DataAnnotation attributes.
            //If any form value fails the DataAnnotation validation the model state becomes invalid.
            if (ModelState.IsValid)
            {
                //create database context using Entity framework 
                _service.Registrar(_mapper.Map<UsuarioViewModel, Usuario>(usuario));

                ViewBag.Message = "Usuário registrado com sucesso";
                return RedirectToAction("Index");
            }
            else
            {

                //If the validation fails, we are returning the model object with errors to the view, which will display the error messages.
                return View(usuario);
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        //The login form is posted to this method.
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            //Checking the state of model passed as parameter.
            if (ModelState.IsValid)
            {

                //Validating the user, whether the user is valid or not.
                var isValidUser = IsValidUser(model);

                //If user is valid & present in database, we are redirecting it to Welcome page.
                if (isValidUser != null)
                {
                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, model.Email)
                        };
                    var claimsIdentity = new ClaimsIdentity(
                        claims, 
                        CookieAuthenticationDefaults.AuthenticationScheme
                    );

                    var authProperties = new AuthenticationProperties {  };

                    HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                    ).Wait();

                    //FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("Index", "Conta");
                }
                else
                {
                    //If the username and password combination is not present in DB then error message is shown.
                    ModelState.AddModelError("Failure", "Wrong Username and password combination !");
                    return View();
                }
            }
            else
            {
                //If model state is not valid, the model with error message is returned to the View.
                return View(model);
            }
        }

        //function to check if User is valid or not
        public UsuarioViewModel IsValidUser(LoginViewModel model)
        {
            return _mapper.Map<Usuario, UsuarioViewModel>(_service.LoginValido(model.Email, model.Password));
        }

        public ActionResult Logout()
        {
            HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            return RedirectToAction("Index", "Conta");
        }
    }
}