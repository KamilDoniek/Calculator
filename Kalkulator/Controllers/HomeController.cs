using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Kalkulator.Models;

namespace Kalkulator.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Calculator(Calculator calculator )
    {
       

        switch (calculator.symbols)
        {
            case '*' :
                calculator.result = calculator.firstNumber * calculator.SecondNumber;
                break;

            case '/' :
                if (calculator.SecondNumber!=0)
                {
                    calculator.result = calculator.firstNumber / calculator.SecondNumber;

                }
                break;

            case '+' :
                calculator.result = calculator.firstNumber + calculator.SecondNumber;
                break;

            case  '-' :
                calculator.result = calculator.firstNumber - calculator.SecondNumber;
                break;
            default:
                calculator.result = 0;
                break;
                
        }

        if (calculator.SecondNumber==0 && calculator.symbols=='/')
        {
            ViewBag.wynik = $" wynik działania {calculator.firstNumber} {calculator.symbols} {calculator.SecondNumber} = Nie dziel przez 0!";

        }
        else ViewBag.wynik = $" wynik działania {calculator.firstNumber} {calculator.symbols} {calculator.SecondNumber} = {calculator.result} ";
        
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}