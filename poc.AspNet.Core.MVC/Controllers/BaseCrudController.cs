using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using poc.AspNet.Core.Domain.Interfaces.Services;
using poc.AspNet.Core.Ioc.Entities;
using System;
using System.Collections.Generic;

namespace poc.AspNet.Core.MVC.Controllers
{
    public abstract class BaseCrudController<TEntity, TViewModel> : Controller where TEntity : BaseModel where TViewModel : class
    {
        protected readonly IServiceCrud<TEntity> _serviceCrud;
        protected readonly IMapper _mapper;

        public BaseCrudController(IServiceCrud<TEntity> serviceCrud, IMapper mapper)
        {
            _serviceCrud = serviceCrud;
            _mapper = mapper;
        }

        // GET: Equipe
        public virtual ActionResult Index()
        {
            return View(_mapper.Map<IEnumerable<TEntity>, IEnumerable<TViewModel>>(_serviceCrud.GetAll()));
        }

        // GET: Equipe/Details/5
        public virtual ActionResult Details(int id)
        {
            return View(_mapper.Map<TEntity, TViewModel>(_serviceCrud.GetById(id)));
        }

        // GET: Equipe/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: Equipe/Create
        [HttpPost]
        public virtual ActionResult Create(TViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<TViewModel, TEntity>(viewModel);
                _serviceCrud.Add(entity);

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Equipe/Edit/5
        public virtual ActionResult Edit(int id)
        {
            return View(_mapper.Map<TEntity, TViewModel>(_serviceCrud.GetById(id)));
        }

        // POST: Equipe/Edit/5
        [HttpPost]
        public virtual ActionResult Edit(int id, TViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<TViewModel, TEntity>(viewModel);
                _serviceCrud.Update(entity);

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Equipe/Delete/5
        public virtual ActionResult Delete(int id)
        {
            return View(_mapper.Map<TEntity, TViewModel>(_serviceCrud.GetById(id)));
        }

        // POST: Equipe/Delete/5
        [HttpPost]
        public virtual ActionResult Delete(int id, TViewModel viewModel)
        {
            try
            {
                _serviceCrud.Delete(_mapper.Map<TViewModel, TEntity>(viewModel));

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}