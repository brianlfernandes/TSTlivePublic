using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TSTmvc.Data;
using TSTmvc.Models;

namespace TSTmvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UsersPersistent _users;

    public HomeController(ILogger<HomeController> logger,UsersPersistent users)
    {
        _logger = logger;
        _users = users;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(User user)
    {
        FileInfo fileInfo = new FileInfo("Signups.xlsx");

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        // Create a new Excel package and open the existing file
        ExcelPackage excelPackage = new ExcelPackage(fileInfo);

        // Retrieve the existing worksheet
        ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets["Sheet 1"];

        if (excelWorksheet != null)
        {
            // Find the next empty row in the worksheet
            int row = excelWorksheet.Dimension.End.Row + 1;

            // Set the values of the cells in the next empty row
            excelWorksheet.Cells[row, 1].Value = user.Name;
            excelWorksheet.Cells[row, 2].Value = user.Email;
            excelWorksheet.Cells[row, 3].Value = user.City;
            excelWorksheet.Cells[row, 4].Value = DateTime.Now.ToShortDateString();

            // Save the changes to the Excel file
            excelPackage.Save();

            // Return a response indicating success
            return RedirectToAction("Privacy");
        }
        return NotFound();
    }


    public IActionResult Privacy()
    {
        // Create a FileInfo object for the Excel file
        FileInfo fileInfo = new FileInfo("Signups.xlsx");

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        // Create a new Excel package and open the file
        ExcelPackage excelPackage = new ExcelPackage(fileInfo);

        // Retrieve the worksheet
        ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets["Sheet 1"];

        // Create a model object to hold the email data
        List<User> users = new List<User>();

        // Iterate through the rows and cells of the worksheet, adding the values to the model
        for (int row = 3; row <= excelWorksheet.Dimension.End.Row; row++)
        {
            User user = new User();
            user.Name = excelWorksheet.Cells[row, 1].Value.ToString();
            user.Email = excelWorksheet.Cells[row, 2].Value.ToString();
            user.City = excelWorksheet.Cells[row, 3].Value.ToString();
            user.SignUpDate = excelWorksheet.Cells[row, 4].Value.ToString();
            users.Add(user);
        }

        // Return the view and pass the model object to the view as the model
        return View(users);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}



