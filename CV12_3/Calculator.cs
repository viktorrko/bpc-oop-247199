using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Json;


namespace CV12_3
{
    
    public class CalcModel
    {
        public decimal Operand1 { get; set; }
        public decimal Operand2 { get; set; }
        public string Operation { get; set; }
    }

    class Calculator
    {
        public string Display;
        public decimal Operand1 = 0;
        public CalcModel calcModel;

        private readonly HttpClient _client;

        public Calculator()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7127/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [BindProperty]
        public CalcModel CalcModel { get; set; }

        public async Task OnPostCalculate(decimal Operand1, decimal Operand2, string Operation)
        {
            CalcDTO calcDTO = new CalcDTO();
            calcDTO.Operand1 = Operand1;
            calcDTO.Operand2 = Operand2;
            calcDTO.Operation = Operation;
            HttpResponseMessage response = await _client.PostAsJsonAsync($"api/Values", calcDTO);
            response.EnsureSuccessStatusCode();
            Display = await response.Content.ReadAsStringAsync();
            Display = await response.Content.ReadAsStringAsync();
        }

        public void Calculate(decimal Operand1, decimal Operand2, string Operation)
        {            
            OnPostCalculate(Operand1, Operand2, Operation);
        }
    }
}
