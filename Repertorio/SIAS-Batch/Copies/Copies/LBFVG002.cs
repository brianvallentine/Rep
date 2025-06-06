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
    public class LBFVG002 : VarBasis
    {
        /*"  01        MOVTO-D-REGISTRO*/
        public LBFVG002_MOVTO_D_REGISTRO MOVTO_D_REGISTRO { get; set; } = new LBFVG002_MOVTO_D_REGISTRO();

    }
}