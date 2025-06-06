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
    public class SUREGSAS : VarBasis
    {
        /*"01  DCLSUREG-SASSE.*/
        public SUREGSAS_DCLSUREG_SASSE DCLSUREG_SASSE { get; set; } = new SUREGSAS_DCLSUREG_SASSE();

    }
}