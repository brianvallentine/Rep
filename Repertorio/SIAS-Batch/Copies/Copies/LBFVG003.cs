using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBFVG003 : VarBasis
    {
        /*"  01        MOVTO-T-REGISTRO*/
        public LBFVG003_MOVTO_T_REGISTRO MOVTO_T_REGISTRO { get; set; } = new LBFVG003_MOVTO_T_REGISTRO();

    }
}