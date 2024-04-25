using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV12_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost(Name = "Calculate")]
        public decimal Post([FromBody] CalcDTO calcDTO)
        {
            switch (calcDTO.Operation)
            {
                case "plus":
                    return calcDTO.Operand1 + calcDTO.Operand2;
                case "minus":
                    return calcDTO.Operand1 - calcDTO.Operand2;
                case "krat":
                    return calcDTO.Operand1 * calcDTO.Operand2;
                case "deleno":
                    return calcDTO.Operand1 / calcDTO.Operand2;
                default:
                    return 0;
            }
        }
    }
}
