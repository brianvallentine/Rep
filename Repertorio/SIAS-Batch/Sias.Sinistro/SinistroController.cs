
using Microsoft.AspNetCore.Mvc;
using Copies;
using Sias.Sinistro.Model;
using IA_ConverterCommons;
using static Code.SI0000B;
using Code;

namespace Sias.Sinistro
{
    [ApiController]
    [Route("Sinistro")]
    public class SinistroController : ControllerBase
    {

        [HttpPost("SI0000B")]
        public IActionResult SI0000B(SI0000BModel SI0000BModel_P)
        {
            var program = new SI0000B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("SI0005B")]
        public IActionResult SI0005B(SI0005BModel SI0005BModel_P)
        {
            var program = new SI0005B();
            var result = program.Execute(SI0005BModel_P.ARQENT, SI0005BModel_P.ARQRET, SI0005BModel_P.CRITICA);
            return Ok(result);
        }

        [HttpPost("SI0006S")]
        public IActionResult SI0006S(SI0006SModel SI0006SModel_P)
        {
            var program = new SI0006S();
            var result = program.Execute(SI0006SModel_P.LK2_LINK);
            return Ok(result);
        }

        [HttpPost("SI0007B")]
        public IActionResult SI0007B(SI0007BModel SI0007BModel_P)
        {
            var program = new SI0007B();
            var result = program.Execute(SI0007BModel_P.AVISO);
            return Ok(result);
        }

        [HttpPost("SI0021B")]
        public IActionResult SI0021B(SI0021BModel SI0021BModel_P)
        {
            var program = new SI0021B();
            var result = program.Execute(SI0021BModel_P.PRINTER1, SI0021BModel_P.PRINTER2);
            return Ok(result);
        }

        [HttpPost("SI0029B")]
        public IActionResult SI0029B(SI0029BModel SI0029BModel_P)
        {
            var program = new SI0029B();
            var result = program.Execute(SI0029BModel_P.ARQCDG1, SI0029BModel_P.ARQCDG2);
            return Ok(result);
        }

        [HttpPost("SI0031B")]
        public IActionResult SI0031B(SI0031BModel SI0031BModel_P)
        {
            var program = new SI0031B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("SI0032B")]
        public IActionResult SI0032B(SI0032BModel SI0032BModel_P)
        {
            var program = new SI0032B();
            var result = program.Execute(SI0032BModel_P.SI0032B1);
            return Ok(result);
        }

        [HttpPost("SI0033B")]
        public IActionResult SI0033B(SI0033BModel SI0033BModel_P)
        {
            var program = new SI0033B();
            var result = program.Execute(SI0033BModel_P.SI0033B1);
            return Ok(result);
        }

        [HttpPost("SI0034B")]
        public IActionResult SI0034B(SI0034BModel SI0034BModel_P)
        {
            var program = new SI0034B();
            var result = program.Execute(SI0034BModel_P.SI0034B1);
            return Ok(result);
        }

        [HttpPost("SI0035B")]
        public IActionResult SI0035B(SI0035BModel SI0035BModel_P)
        {
            var program = new SI0035B();
            var result = program.Execute(SI0035BModel_P.SI0035B1);
            return Ok(result);
        }

        [HttpPost("SI0036B")]
        public IActionResult SI0036B(SI0036BModel SI0036BModel_P)
        {
            var program = new SI0036B();
            var result = program.Execute(SI0036BModel_P.SI0036B1);
            return Ok(result);
        }

        [HttpPost("SI0037B")]
        public IActionResult SI0037B(SI0037BModel SI0037BModel_P)
        {
            var program = new SI0037B();
            var result = program.Execute(SI0037BModel_P.SI0037B1);
            return Ok(result);
        }

        [HttpPost("SI0038B")]
        public IActionResult SI0038B(SI0038BModel SI0038BModel_P)
        {
            var program = new SI0038B();
            var result = program.Execute(SI0038BModel_P.SI0038B1);
            return Ok(result);
        }

        [HttpPost("SI0042B")]
        public IActionResult SI0042B(SI0042BModel SI0042BModel_P)
        {
            var program = new SI0042B();
            var result = program.Execute(SI0042BModel_P.SI0042B1);
            return Ok(result);
        }

        [HttpPost("SI0045B")]
        public IActionResult SI0045B(SI0045BModel SI0045BModel_P)
        {
            var program = new SI0045B();
            var result = program.Execute(SI0045BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0048B")]
        public IActionResult SI0048B(SI0048BModel SI0048BModel_P)
        {
            var program = new SI0048B();
            var result = program.Execute(SI0048BModel_P.SI0048B1);
            return Ok(result);
        }

        [HttpPost("SI0077B")]
        public IActionResult SI0077B(SI0077BModel SI0077BModel_P)
        {
            var program = new SI0077B();
            var result = program.Execute(SI0077BModel_P.SIHAPLAN);
            return Ok(result);
        }

        [HttpPost("SI0078B")]
        public IActionResult SI0078B(SI0078BModel SI0078BModel_P)
        {
            var program = new SI0078B();
            var result = program.Execute(SI0078BModel_P.SI0078BR);
            return Ok(result);
        }

        [HttpPost("SI0095B")]
        public IActionResult SI0095B(SI0095BModel SI0095BModel_P)
        {
            var program = new SI0095B();
            var result = program.Execute(SI0095BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0101B")]
        public IActionResult SI0101B(SI0101BModel SI0101BModel_P)
        {
            var program = new SI0101B();
            var result = program.Execute(SI0101BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0102B")]
        public IActionResult SI0102B(SI0102BModel SI0102BModel_P)
        {
            var program = new SI0102B();
            var result = program.Execute(SI0102BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0103B")]
        public IActionResult SI0103B(SI0103BModel SI0103BModel_P)
        {
            var program = new SI0103B();
            var result = program.Execute(SI0103BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0104B")]
        public IActionResult SI0104B(SI0104BModel SI0104BModel_P)
        {
            var program = new SI0104B();
            var result = program.Execute(SI0104BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0105B")]
        public IActionResult SI0105B(SI0105BModel SI0105BModel_P)
        {
            var program = new SI0105B();
            var result = program.Execute(SI0105BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0106B")]
        public IActionResult SI0106B(SI0106BModel SI0106BModel_P)
        {
            var program = new SI0106B();
            var result = program.Execute(SI0106BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0107B")]
        public IActionResult SI0107B(SI0107BModel SI0107BModel_P)
        {
            var program = new SI0107B();
            var result = program.Execute(SI0107BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0108B")]
        public IActionResult SI0108B(SI0108BModel SI0108BModel_P)
        {
            var program = new SI0108B();
            var result = program.Execute(SI0108BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0109B")]
        public IActionResult SI0109B(SI0109BModel SI0109BModel_P)
        {
            var program = new SI0109B();
            var result = program.Execute(SI0109BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0110B")]
        public IActionResult SI0110B(SI0110BModel SI0110BModel_P)
        {
            var program = new SI0110B();
            var result = program.Execute(SI0110BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0111B")]
        public IActionResult SI0111B(SI0111BModel SI0111BModel_P)
        {
            var program = new SI0111B();
            var result = program.Execute(SI0111BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0112B")]
        public IActionResult SI0112B(SI0112BModel SI0112BModel_P)
        {
            var program = new SI0112B();
            var result = program.Execute(SI0112BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0120B")]
        public IActionResult SI0120B(SI0120BModel SI0120BModel_P)
        {
            var program = new SI0120B();
            var result = program.Execute(SI0120BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0133B")]
        public IActionResult SI0133B(SI0133BModel SI0133BModel_P)
        {
            var program = new SI0133B();
            var result = program.Execute(SI0133BModel_P.RSI0133B);
            return Ok(result);
        }

        [HttpPost("SI0134B")]
        public IActionResult SI0134B(SI0134BModel SI0134BModel_P)
        {
            var program = new SI0134B();
            var result = program.Execute(SI0134BModel_P.SAI0134B);
            return Ok(result);
        }

        [HttpPost("SI0140B")]
        public IActionResult SI0140B(SI0140BModel SI0140BModel_P)
        {
            var program = new SI0140B();
            var result = program.Execute(SI0140BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0181B")]
        public IActionResult SI0181B(SI0181BModel SI0181BModel_P)
        {
            var program = new SI0181B();
            var result = program.Execute(SI0181BModel_P.ARQSAIDA);
            return Ok(result);
        }

        [HttpPost("SI0200B")]
        public IActionResult SI0200B(SI0200BModel SI0200BModel_P)
        {
            var program = new SI0200B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("SI0201B")]
        public IActionResult SI0201B(SI0201BModel SI0201BModel_P)
        {
            var program = new SI0201B();
            var result = program.Execute(SI0201BModel_P.LINK_PARM_DE_EXECUCAO, SI0201BModel_P.SAIDA);
            return Ok(result);
        }

        [HttpPost("SI0202B")]
        public IActionResult SI0202B(SI0202BModel SI0202BModel_P)
        {
            var program = new SI0202B();
            var result = program.Execute(SI0202BModel_P.LINK_PARM_DE_EXECUCAO, SI0202BModel_P.SAIDA);
            return Ok(result);
        }

        [HttpPost("SI0202S")]
        public IActionResult SI0202S(SI0202SModel SI0202SModel_P)
        {
            var program = new SI0202S();
            var result = program.Execute(SI0202SModel_P.SI0202S_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("SI0211B")]
        public IActionResult SI0211B(SI0211BModel SI0211BModel_P)
        {
            var program = new SI0211B();
            var result = program.Execute(SI0211BModel_P.ARQRET);
            return Ok(result);
        }

        [HttpPost("SI0213B")]
        public IActionResult SI0213B(SI0213BModel SI0213BModel_P)
        {
            var program = new SI0213B();
            var result = program.Execute(SI0213BModel_P.SI0213B1_FILE_NAME);
            return Ok(result);
        }

        [HttpPost("SI0214B")]
        public IActionResult SI0214B(SI0214BModel SI0214BModel_P)
        {
            var program = new SI0214B();
            var result = program.Execute(SI0214BModel_P.ARQRET);
            return Ok(result);
        }

        [HttpPost("SI0216B")]
        public IActionResult SI0216B(SI0216BModel SI0216BModel_P)
        {
            var program = new SI0216B();
            var result = program.Execute(SI0216BModel_P.ARQRET);
            return Ok(result);
        }

        [HttpPost("SI0218B")]
        public IActionResult SI0218B(SI0218BModel SI0218BModel_P)
        {
            var program = new SI0218B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("SI0220B")]
        public IActionResult SI0220B(SI0220BModel SI0220BModel_P)
        {
            var program = new SI0220B();
            var result = program.Execute(SI0220BModel_P.ARQRET);
            return Ok(result);
        }

        [HttpPost("SI0234B")]
        public IActionResult SI0234B(SI0234BModel SI0234BModel_P)
        {
            var program = new SI0234B();
            var result = program.Execute(SI0234BModel_P.ARQENT, SI0234BModel_P.ARQRET);
            return Ok(result);
        }

        [HttpPost("SI0502S")]
        public IActionResult SI0502S(SI0502SModel SI0502SModel_P)
        {
            var program = new SI0502S();
            var result = program.Execute(SI0502SModel_P.LINK_PARAMETRO);
            return Ok(result);
        }

        [HttpPost("SI0505B")]
        public IActionResult SI0505B(SI0505BModel SI0505BModel_P)
        {
            var program = new SI0505B();
            var result = program.Execute(SI0505BModel_P.SI0505B_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("SI0803B")]
        public IActionResult SI0803B(SI0803BModel SI0803BModel_P)
        {
            var program = new SI0803B();
            var result = program.Execute(SI0803BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0805B")]
        public IActionResult SI0805B(SI0805BModel SI0805BModel_P)
        {
            var program = new SI0805B();
            var result = program.Execute(SI0805BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0806B")]
        public IActionResult SI0806B(SI0806BModel SI0806BModel_P)
        {
            var program = new SI0806B();
            var result = program.Execute(SI0806BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0807B")]
        public IActionResult SI0807B(SI0807BModel SI0807BModel_P)
        {
            var program = new SI0807B();
            var result = program.Execute(SI0807BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0808B")]
        public IActionResult SI0808B(SI0808BModel SI0808BModel_P)
        {
            var program = new SI0808B();
            var result = program.Execute(SI0808BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0809B")]
        public IActionResult SI0809B(SI0809BModel SI0809BModel_P)
        {
            var program = new SI0809B();
            var result = program.Execute(SI0809BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0845B")]
        public IActionResult SI0845B(SI0845BModel SI0845BModel_P)
        {
            var program = new SI0845B();
            var result = program.Execute(SI0845BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0810B")]
        public IActionResult SI0810B(SI0810BModel SI0810BModel_P)
        {
            var program = new SI0810B();
            var result = program.Execute(SI0810BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0846B")]
        public IActionResult SI0846B(SI0846BModel SI0846BModel_P)
        {
            var program = new SI0846B();
            var result = program.Execute(SI0846BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0811B")]
        public IActionResult SI0811B(SI0811BModel SI0811BModel_P)
        {
            var program = new SI0811B();
            var result = program.Execute(SI0811BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0847B")]
        public IActionResult SI0847B(SI0847BModel SI0847BModel_P)
        {
            var program = new SI0847B();
            var result = program.Execute(SI0847BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0848B")]
        public IActionResult SI0848B(SI0848BModel SI0848BModel_P)
        {
            var program = new SI0848B();
            var result = program.Execute(SI0848BModel_P.ARQSAIDA);
            return Ok(result);
        }

        [HttpPost("SI0812B")]
        public IActionResult SI0812B(SI0812BModel SI0812BModel_P)
        {
            var program = new SI0812B();
            var result = program.Execute(SI0812BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0814B")]
        public IActionResult SI0814B(SI0814BModel SI0814BModel_P)
        {
            var program = new SI0814B();
            var result = program.Execute(SI0814BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0850B")]
        public IActionResult SI0850B(SI0850BModel SI0850BModel_P)
        {
            var program = new SI0850B();
            var result = program.Execute(SI0850BModel_P.PRINTER, SI0850BModel_P.ARQSORT);
            return Ok(result);
        }

        [HttpPost("SI0851B")]
        public IActionResult SI0851B(SI0851BModel SI0851BModel_P)
        {
            var program = new SI0851B();
            var result = program.Execute(SI0851BModel_P.ARQMOV);
            return Ok(result);
        }

        [HttpPost("SI0853B")]
        public IActionResult SI0853B(SI0853BModel SI0853BModel_P)
        {
            var program = new SI0853B();
            var result = program.Execute(SI0853BModel_P.NOVAPT, SI0853BModel_P.PPPT, SI0853BModel_P.PTPP, SI0853BModel_P.PTPT);
            return Ok(result);
        }

        [HttpPost("SI0820B")]
        public IActionResult SI0820B(SI0820BModel SI0820BModel_P)
        {
            var program = new SI0820B();
            var result = program.Execute(SI0820BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI0857B")]
        public IActionResult SI0857B(SI0857BModel SI0857BModel_P)
        {
            var program = new SI0857B();
            var result = program.Execute(SI0857BModel_P.ARQGEMAN, SI0857BModel_P.ARQGEHAB, SI0857BModel_P.ARQGILIE, SI0857BModel_P.ARQFUNCE, SI0857BModel_P.ARQCONSO, SI0857BModel_P.ARQGEPOI);
            return Ok(result);
        }

        [HttpPost("SI0822B")]
        public IActionResult SI0822B(SI0822BModel SI0822BModel_P)
        {
            var program = new SI0822B();
            var result = program.Execute(SI0822BModel_P.SICEDIDO, SI0822BModel_P.SIACEITO);
            return Ok(result);
        }

        [HttpPost("SI0836B")]
        public IActionResult SI0836B(SI0836BModel SI0836BModel_P)
        {
            var program = new SI0836B();
            var result = program.Execute(SI0836BModel_P.SIPGTAZU);
            return Ok(result);
        }

        [HttpPost("SI0860B")]
        public IActionResult SI0860B(SI0860BModel SI0860BModel_P)
        {
            var program = new SI0860B();
            var result = program.Execute(SI0860BModel_P.SI0860BA);
            return Ok(result);
        }

        [HttpPost("SI0861B")]
        public IActionResult SI0861B(SI0861BModel SI0861BModel_P)
        {
            var program = new SI0861B();
            var result = program.Execute(SI0861BModel_P.SAIDA);
            return Ok(result);
        }

        [HttpPost("SI0843B")]
        public IActionResult SI0843B(SI0843BModel SI0843BModel_P)
        {
            var program = new SI0843B();
            var result = program.Execute(SI0843BModel_P.SI0843);
            return Ok(result);
        }

        [HttpPost("SI0862B")]
        public IActionResult SI0862B(SI0862BModel SI0862BModel_P)
        {
            var program = new SI0862B();
            var result = program.Execute(SI0862BModel_P.SAIDA);
            return Ok(result);
        }

        [HttpPost("SI0844B")]
        public IActionResult SI0844B(SI0844BModel SI0844BModel_P)
        {
            var program = new SI0844B();
            var result = program.Execute(SI0844BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI1007S")]
        public IActionResult SI1007S(SI1007SModel SI1007SModel_P)
        {
            var program = new SI1007S();
            var result = program.Execute(SI1007SModel_P.SI1001S_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("SI1011S")]
        public IActionResult SI1011S(SI1011SModel SI1011SModel_P)
        {
            var program = new SI1011S();
            var result = program.Execute(SI1011SModel_P.SI1001S_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("SI0863B")]
        public IActionResult SI0863B(SI0863BModel SI0863BModel_P)
        {
            var program = new SI0863B();
            var result = program.Execute(SI0863BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI1017S")]
        public IActionResult SI1017S(SI1017SModel SI1017SModel_P)
        {
            var program = new SI1017S();
            var result = program.Execute(SI1017SModel_P.SI1001S_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("SI1018S")]
        public IActionResult SI1018S(SI1018SModel SI1018SModel_P)
        {
            var program = new SI1018S();
            var result = program.Execute(SI1018SModel_P.SI1001S_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("SI1019S")]
        public IActionResult SI1019S(SI1019SModel SI1019SModel_P)
        {
            var program = new SI1019S();
            var result = program.Execute(SI1019SModel_P.SI1001S_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("SI1023S")]
        public IActionResult SI1023S(SI1023SModel SI1023SModel_P)
        {
            var program = new SI1023S();
            var result = program.Execute(SI1023SModel_P.SI1001S_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("SI1024S")]
        public IActionResult SI1024S(SI1024SModel SI1024SModel_P)
        {
            var program = new SI1024S();
            var result = program.Execute(SI1024SModel_P.SI1001S_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("SI1025S")]
        public IActionResult SI1025S(SI1025SModel SI1025SModel_P)
        {
            var program = new SI1025S();
            var result = program.Execute(SI1025SModel_P.SI1001S_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("SI1032S")]
        public IActionResult SI1032S(SI1032SModel SI1032SModel_P)
        {
            var program = new SI1032S();
            var result = program.Execute(SI1032SModel_P.SI1001S_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("SI1040S")]
        public IActionResult SI1040S(SI1040SModel SI1040SModel_P)
        {
            var program = new SI1040S();
            var result = program.Execute(SI1040SModel_P.SI1040S_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("SI0864B")]
        public IActionResult SI0864B(SI0864BModel SI0864BModel_P)
        {
            var program = new SI0864B();
            var result = program.Execute(SI0864BModel_P.SAIDA);
            return Ok(result);
        }

        [HttpPost("SI1051S")]
        public IActionResult SI1051S(SI1051SModel SI1051SModel_P)
        {
            var program = new SI1051S();
            var result = program.Execute(SI1051SModel_P.LINK_ESTORNA_REPASSE);
            return Ok(result);
        }

        [HttpPost("SI2010B")]
        public IActionResult SI2010B(SI2010BModel SI2010BModel_P)
        {
            var program = new SI2010B();
            var result = program.Execute(SI2010BModel_P.SI2010B1);
            return Ok(result);
        }

        [HttpPost("SI3041B")]
        public IActionResult SI3041B(SI3041BModel SI3041BModel_P)
        {
            var program = new SI3041B();
            var result = program.Execute(SI3041BModel_P.SEGAB02);
            return Ok(result);
        }

        [HttpPost("SI4922B")]
        public IActionResult SI4922B(SI4922BModel SI4922BModel_P)
        {
            var program = new SI4922B();
            var result = program.Execute(SI4922BModel_P.LK_PARAMETRO);
            return Ok(result);
        }

        [HttpPost("SI5000B")]
        public IActionResult SI5000B(SI5000BModel SI5000BModel_P)
        {
            var program = new SI5000B();
            var result = program.Execute(SI5000BModel_P.LINK_PARM_CONV_PROCESSADO);
            return Ok(result);
        }

        [HttpPost("SI5001B")]
        public IActionResult SI5001B(SI5001BModel SI5001BModel_P)
        {
            var program = new SI5001B();
            var result = program.Execute(SI5001BModel_P.LINK_PARM_CONV_PROCESSADO, SI5001BModel_P.MVDBCCOR, SI5001BModel_P.PRINTER);
            return Ok(result);
        }

        [HttpPost("SI5039B")]
        public IActionResult SI5039B(SI5039BModel SI5039BModel_P)
        {
            var program = new SI5039B();
            var result = program.Execute(SI5039BModel_P.ARQNEGAV);
            return Ok(result);
        }

        [HttpPost("SI5040B")]
        public IActionResult SI5040B(SI5040BModel SI5040BModel_P)
        {
            var program = new SI5040B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("SI0867B")]
        public IActionResult SI0867B(SI0867BModel SI0867BModel_P)
        {
            var program = new SI0867B();
            var result = program.Execute(SI0867BModel_P.SAIDA);
            return Ok(result);
        }

        [HttpPost("SI5066B")]
        public IActionResult SI5066B(SI5066BModel SI5066BModel_P)
        {
            var program = new SI5066B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("SI0868B")]
        public IActionResult SI0868B(SI0868BModel SI0868BModel_P)
        {
            var program = new SI0868B();
            var result = program.Execute(SI0868BModel_P.SAIDA);
            return Ok(result);
        }

        [HttpPost("SI9101B")]
        public IActionResult SI9101B(SI9101BModel SI9101BModel_P)
        {
            var program = new SI9101B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("SI9102B")]
        public IActionResult SI9102B(SI9102BModel SI9102BModel_P)
        {
            var program = new SI9102B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("SI9104B")]
        public IActionResult SI9104B(SI9104BModel SI9104BModel_P)
        {
            var program = new SI9104B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("SI9105B")]
        public IActionResult SI9105B(SI9105BModel SI9105BModel_P)
        {
            var program = new SI9105B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("SI9106B")]
        public IActionResult SI9106B(SI9106BModel SI9106BModel_P)
        {
            var program = new SI9106B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("SI0869B")]
        public IActionResult SI0869B(SI0869BModel SI0869BModel_P)
        {
            var program = new SI0869B();
            var result = program.Execute(SI0869BModel_P.SAIDA);
            return Ok(result);
        }

        [HttpPost("SI9107B")]
        public IActionResult SI9107B(SI9107BModel SI9107BModel_P)
        {
            var program = new SI9107B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("SI9109B")]
        public IActionResult SI9109B(SI9109BModel SI9109BModel_P)
        {
            var program = new SI9109B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("SI9111B")]
        public IActionResult SI9111B(SI9111BModel SI9111BModel_P)
        {
            var program = new SI9111B();
            var result = program.Execute(SI9111BModel_P.CVPAGSIN);
            return Ok(result);
        }

        [HttpPost("SI9115B")]
        public IActionResult SI9115B(SI9115BModel SI9115BModel_P)
        {
            var program = new SI9115B();
            var result = program.Execute(SI9115BModel_P.CVPAGSIN);
            return Ok(result);
        }

        [HttpPost("SI0874B")]
        public IActionResult SI0874B(SI0874BModel SI0874BModel_P)
        {
            var program = new SI0874B();
            var result = program.Execute(SI0874BModel_P.LK_LINK_PERIODICIDADE, SI0874BModel_P.ARQANAL);
            return Ok(result);
        }

        [HttpPost("SI9147B")]
        public IActionResult SI9147B(SI9147BModel SI9147BModel_P)
        {
            var program = new SI9147B();
            var result = program.Execute(SI9147BModel_P.CVPAGSIN);
            return Ok(result);
        }

        [HttpPost("SI0882B")]
        public IActionResult SI0882B(SI0882BModel SI0882BModel_P)
        {
            var program = new SI0882B();
            var result = program.Execute(SI0882BModel_P.ARQCALC);
            return Ok(result);
        }

        [HttpPost("SI0884B")]
        public IActionResult SI0884B(SI0884BModel SI0884BModel_P)
        {
            var program = new SI0884B();
            var result = program.Execute(SI0884BModel_P.RSICV23B);
            return Ok(result);
        }

        [HttpPost("SI9148B")]
        public IActionResult SI9148B(SI9148BModel SI9148BModel_P)
        {
            var program = new SI9148B();
            var result = program.Execute(SI9148BModel_P.CVPAGSIN);
            return Ok(result);
        }

        [HttpPost("SI9168B")]
        public IActionResult SI9168B(SI9168BModel SI9168BModel_P)
        {
            var program = new SI9168B();
            var result = program.Execute(SI9168BModel_P.CVPAGSIN);
            return Ok(result);
        }

        [HttpPost("SI0888B")]
        public IActionResult SI0888B(SI0888BModel SI0888BModel_P)
        {
            var program = new SI0888B();
            var result = program.Execute(SI0888BModel_P.ARQESTOR);
            return Ok(result);
        }

        [HttpPost("SI9169B")]
        public IActionResult SI9169B(SI9169BModel SI9169BModel_P)
        {
            var program = new SI9169B();
            var result = program.Execute(SI9169BModel_P.CVPAGSIN);
            return Ok(result);
        }

        [HttpPost("SI0890B")]
        public IActionResult SI0890B(SI0890BModel SI0890BModel_P)
        {
            var program = new SI0890B();
            var result = program.Execute(SI0890BModel_P.LOTER01);
            return Ok(result);
        }

        [HttpPost("SI0891B")]
        public IActionResult SI0891B(SI0891BModel SI0891BModel_P)
        {
            var program = new SI0891B();
            var result = program.Execute(SI0891BModel_P.FENAE01);
            return Ok(result);
        }

        [HttpPost("SI0896B")]
        public IActionResult SI0896B(SI0896BModel SI0896BModel_P)
        {
            var program = new SI0896B();
            var result = program.Execute(SI0896BModel_P.ARQMATC);
            return Ok(result);
        }

        [HttpPost("SI0900B")]
        public IActionResult SI0900B(SI0900BModel SI0900BModel_P)
        {
            var program = new SI0900B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("SI9211B")]
        public IActionResult SI9211B(SI9211BModel SI9211BModel_P)
        {
            var program = new SI9211B();
            var result = program.Execute(SI9211BModel_P.CSPAGSIN);
            return Ok(result);
        }

        [HttpPost("SI0910B")]
        public IActionResult SI0910B(SI0910BModel SI0910BModel_P)
        {
            var program = new SI0910B();
            var result = program.Execute(SI0910BModel_P.LK_PARAMETROS, SI0910BModel_P.SIJC0910);
            return Ok(result);
        }

        [HttpPost("SI1000B")]
        public IActionResult SI1000B(SI1000BModel SI1000BModel_P)
        {
            var program = new SI1000B();
            var result = program.Execute();
            return Ok(result);
        }

        [HttpPost("SI1000S")]
        public IActionResult SI1000S(SI1000SModel SI1000SModel_P)
        {
            var program = new SI1000S();
            var result = program.Execute(SI1000SModel_P.SI1000S_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("SI1001S")]
        public IActionResult SI1001S(SI1001SModel SI1001SModel_P)
        {
            var program = new SI1001S();
            var result = program.Execute(SI1001SModel_P.SI1001S_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("SI1002S")]
        public IActionResult SI1002S(SI1002SModel SI1002SModel_P)
        {
            var program = new SI1002S();
            var result = program.Execute(SI1002SModel_P.SI1001S_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("SI1003S")]
        public IActionResult SI1003S(SI1003SModel SI1003SModel_P)
        {
            var program = new SI1003S();
            var result = program.Execute(SI1003SModel_P.SI1001S_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("SI1005S")]
        public IActionResult SI1005S(SI1005SModel SI1005SModel_P)
        {
            var program = new SI1005S();
            var result = program.Execute(SI1005SModel_P.SI1001S_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("SI1006S")]
        public IActionResult SI1006S(SI1006SModel SI1006SModel_P)
        {
            var program = new SI1006S();
            var result = program.Execute(SI1006SModel_P.SI1001S_PARAMETROS);
            return Ok(result);
        }

        [HttpPost("SI9215B")]
        public IActionResult SI9215B(SI9215BModel SI9215BModel_P)
        {
            var program = new SI9215B();
            var result = program.Execute(SI9215BModel_P.CSPAGSIN);
            return Ok(result);
        }

        [HttpPost("SI9229B")]
        public IActionResult SI9229B(SI9229BModel SI9229BModel_P)
        {
            var program = new SI9229B();
            var result = program.Execute(SI9229BModel_P.SIAVISAD);
            return Ok(result);
        }

        [HttpPost("SI9247B")]
        public IActionResult SI9247B(SI9247BModel SI9247BModel_P)
        {
            var program = new SI9247B();
            var result = program.Execute(SI9247BModel_P.CSPAGSIN);
            return Ok(result);
        }

        [HttpPost("SI9248B")]
        public IActionResult SI9248B(SI9248BModel SI9248BModel_P)
        {
            var program = new SI9248B();
            var result = program.Execute(SI9248BModel_P.CSPAGSIN);
            return Ok(result);
        }

        [HttpPost("SI9268B")]
        public IActionResult SI9268B(SI9268BModel SI9268BModel_P)
        {
            var program = new SI9268B();
            var result = program.Execute(SI9268BModel_P.CSPAGSIN);
            return Ok(result);
        }

        [HttpPost("SI9269B")]
        public IActionResult SI9269B(SI9269BModel SI9269BModel_P)
        {
            var program = new SI9269B();
            var result = program.Execute(SI9269BModel_P.CSPAGSIN);
            return Ok(result);
        }

        [HttpPost("SICP001S")]
        public IActionResult SICP001S(SICP001SModel SICP001SModel_P)
        {
            var program = new SICP001S();
            var result = program.Execute(SICP001SModel_P.SICPW001);
            return Ok(result);
        }

        [HttpPost("SICP002S")]
        public IActionResult SICP002S(SICP002SModel SICP002SModel_P)
        {
            var program = new SICP002S();
            var result = program.Execute(SICP002SModel_P.SICPW002, SICP002SModel_P.RSGEWCNT);
            return Ok(result);
        }

        [HttpPost("SISAP01B")]
        public IActionResult SISAP01B(SISAP01BModel SISAP01BModel_P)
        {
            var program = new SISAP01B();
            var result = program.Execute(SISAP01BModel_P.REGISTRO_LINKAGE_SAP);
            return Ok(result);
        }

        [HttpPost("SISAP03B")]
        public IActionResult SISAP03B(SISAP03BModel SISAP03BModel_P)
        {
            var program = new SISAP03B();
            var result = program.Execute(SISAP03BModel_P.LK_IDLG_REGISTRO_SINISTRO);
            return Ok(result);
        }

        [HttpPost("SISAP15B")]
        public IActionResult SISAP15B(SISAP15BModel SISAP15BModel_P)
        {
            var program = new SISAP15B();
            var result = program.Execute(SISAP15BModel_P.REGISTRO_LINKAGE_SAP);
            return Ok(result);
        }

        [HttpPost("SISMS1B")]
        public IActionResult SISMS1B(SISMS1BModel SISMS1BModel_P)
        {
            var program = new SISMS1B();
            var result = program.Execute(SISMS1BModel_P.ARQSMSCS, SISMS1BModel_P.ARQMOVSS);
            return Ok(result);
        }


        [HttpPost("SI9108B")]
        public IActionResult SI9108B(SI9108BModel SI9108BModel_P)
        {
            var program = new SI9108B();
            var result = program.Execute();
            return Ok(result);
        }
        
        [HttpPost("SI9110B")]
        public IActionResult SI9110B(SI9110BModel SI9110BModel_P)
        {
            var program = new SI9110B();
            var result = program.Execute(SI9110BModel_P.CVMOVSIN);
            return Ok(result);
        }
    }
}
