using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConstrucaoCivil.Models;
using Newtonsoft.Json;

namespace ConstrucaoCivil.Controllers
{
    public class FornecedoresController : Controller
    {
        ConstrucaoCivEntities db = new ConstrucaoCivEntities();
        // GET: Fornecedores
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListaFornecedor()
        {
            //Pass The All Student Record From Controller To View For Show The All Data For User
            List<FornecedorViewModel> FornList = db.tblFornecedor.Select(x => new FornecedorViewModel
            {
                id_fornecedor = x.id_fornecedor,
                nif = x.nif,
                nome = x.nome,
                area = x.area,
                servico = x.servico,
                cidade = x.cidade,
                local = x.local,
                email = x.email,
                telefone = x.telefone,
                conta_bancaria = x.conta_bancaria,
                createdAt = x.createdAt,
                updatedAt = x.updatedAt
            }).ToList();

            return Json(FornList, JsonRequestBehavior.AllowGet);
        }


        public JsonResult FornecedorPorId(int id_fornecedor)
        {
            tblFornecedor model = db.tblFornecedor.Where(x => x.id_fornecedor == id_fornecedor).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult NovoOuEditarFornecedor(FornecedorViewModel model)
        {
            bool result = false;
            try
            {
                if (model.id_fornecedor > 0)
                {
                    tblFornecedor fornecedor = db.tblFornecedor.SingleOrDefault(x => x.id_fornecedor == model.id_fornecedor);
                    fornecedor.nif = model.nif;
                    fornecedor.nome = model.nome;
                    fornecedor.area = model.area;
                    fornecedor.servico = model.servico;
                    fornecedor.cidade = model.cidade;
                    fornecedor.local = model.local;
                    fornecedor.email = model.email;
                    fornecedor.telefone = model.telefone;
                    fornecedor.conta_bancaria = model.conta_bancaria;
                    fornecedor.updatedAt = DateTime.Now;

                    db.SaveChanges();

                    result = true;
                }
                else
                {
                    tblFornecedor fornecedor = new tblFornecedor();
                    fornecedor.nif = model.nif;
                    fornecedor.nome = model.nome;
                    fornecedor.area = model.area;
                    fornecedor.servico = model.servico;
                    fornecedor.cidade = model.cidade;
                    fornecedor.local = model.local;
                    fornecedor.email = model.email;
                    fornecedor.telefone = model.telefone;
                    fornecedor.conta_bancaria = model.conta_bancaria;
                    fornecedor.createdAt = DateTime.Now;
                    fornecedor.updatedAt = DateTime.Now;
                    db.tblFornecedor.Add(fornecedor);
                    db.SaveChanges();

                    result = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ApagarFornecedor(int id_fornecedor)
        {
            bool result = false;

            tblFornecedor fornecedor = db.tblFornecedor.SingleOrDefault(x => x.id_fornecedor == id_fornecedor);
            if (fornecedor != null)
            {
                db.tblFornecedor.Remove(fornecedor);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}