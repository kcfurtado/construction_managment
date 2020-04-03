using ConstrucaoCivil.Models;
using System.Linq;
using System.Web.Mvc;

namespace ConstrucaoCivil.Controllers
{
    public class HomeController : Controller
    {
        private ConstrucaoCivEntities db = new ConstrucaoCivEntities();
        public ActionResult Index()
        {
            ViewBag.ContarFuncionario = db.tblFuncionario.Count();
            ViewBag.ContarCliente = db.tblCliente.Count();
            ViewBag.ContarObras= db.tblObra.Count();
            ViewBag.ContarFornecedor = db.tblFornecedor.Count();

            var model = db.tblFuncionario.OrderByDescending(f => f.createdAt).Take(8);
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}