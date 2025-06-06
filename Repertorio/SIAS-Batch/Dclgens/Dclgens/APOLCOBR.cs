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
    public class APOLCOBR : VarBasis
    {
        /*"01  DCLAPOLICE-COBRANCA.*/
        public APOLCOBR_DCLAPOLICE_COBRANCA DCLAPOLICE_COBRANCA { get; set; } = new APOLCOBR_DCLAPOLICE_COBRANCA();

    }
}