
using Microsoft.AspNetCore.Mvc;
using Copies;
using Sias.Cosseguro.Model;
using IA_ConverterCommons;
using static Code.AC0003B;
using Code;

namespace Sias.Cosseguro
{
    [ApiController]
    [Route("Cosseguro")]
    public class CosseguroController : ControllerBase
    {

        [HttpPost("AC0003B")]
        public IActionResult AC0003B(AC0003BModel AC0003BModel_P)
        {
            var program = new AC0003B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("AC0004B")]
        public IActionResult AC0004B(AC0004BModel AC0004BModel_P)
        {
            var program = new AC0004B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("AC0005B")]
        public IActionResult AC0005B(AC0005BModel AC0005BModel_P)
        {
            var program = new AC0005B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("AC0006B")]
        public IActionResult AC0006B(AC0006BModel AC0006BModel_P)
        {
            var program = new AC0006B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("AC0007B")]
        public IActionResult AC0007B(AC0007BModel AC0007BModel_P)
        {
            var program = new AC0007B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("AC0008B")]
        public IActionResult AC0008B(AC0008BModel AC0008BModel_P)
        {
            var program = new AC0008B();
            var result = program.Execute(AC0008BModel_P.COSSHIST, AC0008BModel_P.COSSPREM);
            return Ok(result);
        }

        [HttpPost("AC0009B")]
        public IActionResult AC0009B(AC0009BModel AC0009BModel_P)
        {
            var program = new AC0009B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("AC0011B")]
        public IActionResult AC0011B(AC0011BModel AC0011BModel_P)
        {
            var program = new AC0011B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("AC0017B")]
        public IActionResult AC0017B(AC0017BModel AC0017BModel_P)
        {
            var program = new AC0017B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("AC0010B")]
        public IActionResult AC0010B(AC0010BModel AC0010BModel_P)
        {
            var program = new AC0010B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("AC0041B")]
        public IActionResult AC0041B(AC0041BModel AC0041BModel_P)
        {
            var program = new AC0041B();
            var result = program.Execute(AC0041BModel_P.RAC0041B);
            return Ok(result);
        }

        [HttpPost("AC0141B")]
        public IActionResult AC0141B(AC0141BModel AC0141BModel_P)
        {
            var program = new AC0141B();
            var result = program.Execute(AC0141BModel_P.RAC0141B);
            return Ok(result);
        }

        [HttpPost("AC0077B")]
        public IActionResult AC0077B(AC0077BModel AC0077BModel_P)
        {
            var program = new AC0077B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("AC0217B")]
        public IActionResult AC0217B(AC0217BModel AC0217BModel_P)
        {
            var program = new AC0217B();
            var result = program.Execute(AC0217BModel_P.ACOCORR_FILE_NAME);
            return Ok(result);
        }

        [HttpPost("AC0812B")]
        public IActionResult AC0812B(AC0812BModel AC0812BModel_P)
        {
            var program = new AC0812B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("AC0241B")]
        public IActionResult AC0241B(AC0241BModel AC0241BModel_P)
        {
            var program = new AC0241B();
            var result = program.Execute(AC0241BModel_P.RAC0241B);
            return Ok(result);
        }

        [HttpPost("AC0810B")]
        public IActionResult AC0810B(AC0810BModel AC0810BModel_P)
        {
            var program = new AC0810B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("AC0816B")]
        public IActionResult AC0816B(AC0816BModel AC0816BModel_P)
        {
            var program = new AC0816B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("AC0820B")]
        public IActionResult AC0820B(AC0820BModel AC0820BModel_P)
        {
            var program = new AC0820B();
            var result = program.Execute(AC0820BModel_P.AC0820B1, AC0820BModel_P.AC0820B2, AC0820BModel_P.AC0820B3);
            return Ok(result);
        }

        [HttpPost("AC0811B")]
        public IActionResult AC0811B(AC0811BModel AC0811BModel_P)
        {
            var program = new AC0811B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("AC0815B")]
        public IActionResult AC0815B(AC0815BModel AC0815BModel_P)
        {
            var program = new AC0815B();
            var result = program.Execute();
            return Ok(result);
        }

    }
}
