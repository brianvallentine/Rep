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
    public class COADSICO : VarBasis
    {
        /*"01  DCLCOMISS-ADIAN-SICOB.*/
        public COADSICO_DCLCOMISS_ADIAN_SICOB DCLCOMISS_ADIAN_SICOB { get; set; } = new COADSICO_DCLCOMISS_ADIAN_SICOB();

    }
}