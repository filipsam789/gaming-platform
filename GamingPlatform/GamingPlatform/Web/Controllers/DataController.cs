using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using GemBox.Document;
using IntegratedSystems.Domain.DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace IntegratedSystems.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public FileContentResult ExportHighScores()
        {
            string fileName = "Top10HighScores.xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string openedFileName = "ExportTemplate.xlsx";

            using (var workBook = new XLWorkbook(openedFileName))
            {
                workBook.Worksheets.TryGetWorksheet("High Scores", out IXLWorksheet worksheet);

                HttpClient client = new HttpClient();
                string URL = "http://localhost:5176/api/HighScoreApi/";

                HttpResponseMessage response = client.GetAsync(URL).Result;

                var data = response.Content.ReadAsAsync<List<HighScore>>().Result;

                for (int i = 0; i < data.Count(); i++)
                {
                    var highScore = data[i];
                    worksheet.Cell(i + 8, 3).Value = highScore.Game.Name;
                    worksheet.Cell(i + 8, 4).Value = highScore.Score;
                    worksheet.Cell(i + 8, 5).Value = highScore.DateAchieved;
                    worksheet.Cell(i + 8, 6).Value = highScore.User.GamingPlatformUser.UserName;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, contentType, fileName);
                }
            }
        }
    }
}