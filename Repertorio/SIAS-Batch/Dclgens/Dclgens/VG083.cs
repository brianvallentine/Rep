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
    public class VG083 : VarBasis
    {
        /*"01  DCLVG-VIGENCIA-FATURA.*/
        public VG083_DCLVG_VIGENCIA_FATURA DCLVG_VIGENCIA_FATURA { get; set; } = new VG083_DCLVG_VIGENCIA_FATURA();

    }
}