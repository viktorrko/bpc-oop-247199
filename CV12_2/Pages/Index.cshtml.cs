using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Headers;

namespace CV12_2.Pages
{
    public class CalcModel
    {
        public decimal Operand1 { get; set; }
        public decimal Operand2 { get; set; }
        public string Operation { get; set; }
    }

    public class IndexModel : PageModel
    {
        private HttpClient _client;

        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public CalcModel CalcModel { get; set; }

        public List<SelectListItem> OperationList { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "plus", Text = "+" },
            new SelectListItem { Value = "minus", Text = "-" },
            new SelectListItem { Value = "krat", Text = "*" },
            new SelectListItem { Value = "deleno", Text = "/" }
        };

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7127/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public void OnGet()
        {
        }
        public async Task OnPostCalculate()
        {
            CalcDTO calcDTO = new CalcDTO();
            calcDTO.Operand1 = CalcModel.Operand1;
            calcDTO.Operand2 = CalcModel.Operand2;
            calcDTO.Operation = CalcModel.Operation;
            HttpResponseMessage response = await _client.PostAsJsonAsync($"api/Values", calcDTO);
            response.EnsureSuccessStatusCode();
            ViewData["ResultValue"] = await response.Content.ReadAsStringAsync();
        }

    }
}
