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
    public class PROPFIDH : VarBasis
    {
        /*"01  DCLHIST-PROP-FIDELIZ.*/
        public PROPFIDH_DCLHIST_PROP_FIDELIZ DCLHIST_PROP_FIDELIZ { get; set; } = new PROPFIDH_DCLHIST_PROP_FIDELIZ();

    }
}