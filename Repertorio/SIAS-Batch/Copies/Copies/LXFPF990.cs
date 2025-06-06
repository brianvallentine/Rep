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
    public class LXFPF990 : VarBasis
    {
        /*"01       REG-HEADER*/
        public LXFPF990_REG_HEADER REG_HEADER { get; set; } = new LXFPF990_REG_HEADER();

    }
}