using Microsoft.AspNetCore.Mvc;
using IMCCalculator.Models;

namespace IMCCalculator.Controllers
{
    public class IMCController : Controller
    {
        public IActionResult Index()
        {
            return View(new IMCModel());
        }

        [HttpPost]
        public IActionResult Calcular(IMCModel model)
        {
            if (model.Peso > 0 && model.Altura > 0)
            {
                model.IMC = model.Peso / (model.Altura * model.Altura);
                model.Classificacao = ClassificarIMC(model.IMC);
            }
            return View("Index", model);
        }

        private string ClassificarIMC(double imc)
        {
            if (imc < 18.5)
                return "Abaixo do peso";
            else if (imc >= 18.5 && imc < 24.9)
                return "Peso normal";
            else if (imc >= 25 && imc < 29.9)
                return "Sobrepeso";
            else if (imc >= 30 && imc < 34.9)
                return "Obesidade Grau I";
            else if (imc >= 35 && imc < 39.9)
                return "Obesidade Grau II";
            else
                return "Obesidade Grau III";
        }
    }
}
