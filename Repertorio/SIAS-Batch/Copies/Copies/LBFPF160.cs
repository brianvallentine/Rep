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
    public class LBFPF160 : VarBasis
    {
        /*"01     REGISTRO-VIDA-EMPRESARIAL*/
        public LBFPF160_REGISTRO_VIDA_EMPRESARIAL REGISTRO_VIDA_EMPRESARIAL { get; set; } = new LBFPF160_REGISTRO_VIDA_EMPRESARIAL();

    }
}