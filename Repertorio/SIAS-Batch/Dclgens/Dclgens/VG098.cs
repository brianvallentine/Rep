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
    public class VG098 : VarBasis
    {
        /*"01  DCLVG-CERTIFICADO-TITULO.*/
        public VG098_DCLVG_CERTIFICADO_TITULO DCLVG_CERTIFICADO_TITULO { get; set; } = new VG098_DCLVG_CERTIFICADO_TITULO();

    }
}