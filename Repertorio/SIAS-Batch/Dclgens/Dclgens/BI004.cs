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
    public class BI004 : VarBasis
    {
        /*"01  DCLBI-TIPO-PARCELM.*/
        public BI004_DCLBI_TIPO_PARCELM DCLBI_TIPO_PARCELM { get; set; } = new BI004_DCLBI_TIPO_PARCELM();

    }
}