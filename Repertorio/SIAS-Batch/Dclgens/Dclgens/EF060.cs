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
    public class EF060 : VarBasis
    {
        /*"01  DCLEF-PREMIOS-FATURA.*/
        public EF060_DCLEF_PREMIOS_FATURA DCLEF_PREMIOS_FATURA { get; set; } = new EF060_DCLEF_PREMIOS_FATURA();

    }
}