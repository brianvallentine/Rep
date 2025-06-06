using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class VGSOLFAT : VarBasis
    {
        /*"01  DCLVG-SOLICITA-FATURA.*/
        public VGSOLFAT_DCLVG_SOLICITA_FATURA DCLVG_SOLICITA_FATURA { get; set; } = new VGSOLFAT_DCLVG_SOLICITA_FATURA();

    }
}