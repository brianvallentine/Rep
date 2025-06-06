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
    public class LBFVG001 : VarBasis
    {
        /*"  01        MOVTO-H-REGISTRO*/
        public LBFVG001_MOVTO_H_REGISTRO MOVTO_H_REGISTRO { get; set; } = new LBFVG001_MOVTO_H_REGISTRO();

    }
}