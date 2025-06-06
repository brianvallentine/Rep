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
    public class LBFPF161 : VarBasis
    {
        /*"01     REGISTRO-VIDA-MULHER*/
        public LBFPF161_REGISTRO_VIDA_MULHER REGISTRO_VIDA_MULHER { get; set; } = new LBFPF161_REGISTRO_VIDA_MULHER();

    }
}