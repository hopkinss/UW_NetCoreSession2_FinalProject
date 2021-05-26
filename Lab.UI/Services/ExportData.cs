using ClosedXML.Excel;
using Lab.UI.Data.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab.UI.Services
{
    public partial class ExportData
    {
        private ILabTestRepository _repository;
        private Destination destination;
        private string file;


        public ExportData(ILabTestRepository labTestRepository, string file)
        {
            _repository = labTestRepository;
            destination = Path.GetExtension(file).ToLower() == ".xlsx" ? Destination.xlsx : Destination.json;
            this.file = file;
        }

        public Response Export()
        {
            switch (destination)
            {
                case Destination.json:
                    try
                    {
                        ExportJson();
                        return new Response() { Ok = true, Msg = $"data exported as json to {file}" };
                    }
                    catch (Exception ex)
                    {
                        return new Response() { Ok = false, Msg = ex.Message };
                    }
                default:
                    try
                    {
                        ExportXlsx();
                        return new Response() { Ok = true, Msg = $"data exported as json to {file}" };
                    }
                    catch (Exception ex)
                    {
                        return new Response() { Ok = false, Msg = ex.Message };
                    }
            }
        }

        private async void ExportXlsx()
        {
            var data = await _repository.GetAllAsync();
            using (var wb =  new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Analytes");
                int row = 1;

                foreach (var a in data)
                {
                    if (row == 1)
                    {
                        ws.Row(row).Cell(1).Value = nameof(a.TestName);
                        ws.Row(row).Cell(2).Value = nameof(a.Category);
                        ws.Row(row).Cell(3).Value = nameof(a.CdiscTestCd);
                        ws.Row(row).Cell(4).Value = nameof(a.CdiscTestName);
                        ws.Row(row).Cell(5).Value = nameof(a.LabTestUnit);
                    }
                    row++;
                    ws.Row(row).Cell(1).Value = a.TestName;
                    ws.Row(row).Cell(2).Value = a.Category;
                    ws.Row(row).Cell(3).Value = a.CdiscTestCd;
                    ws.Row(row).Cell(4).Value = a.CdiscTestName;
                    ws.Row(row).Cell(5).Value = a.LabTestUnit;           
                }
                ws.Range("A1:E1").Style.Fill.BackgroundColor = XLColor.LightSteelBlue;
                ws.ColumnsUsed().AdjustToContents();
                wb.SaveAs(file);
            }                  
        }

        private async void ExportJson()
        {
            var data = await _repository.GetAllAsync();
            using (var sw = new StreamWriter(file))
            {      
                sw.Write(JsonConvert.SerializeObject(data,Formatting.Indented,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore}));
            }
        }
    }
    public class Response
    {
        public bool Ok { get; set; }
        public string Msg { get; set; }
    }
}
