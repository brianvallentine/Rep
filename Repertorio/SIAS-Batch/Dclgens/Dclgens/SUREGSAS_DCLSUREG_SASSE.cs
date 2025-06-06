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
    public class SUREGSAS_DCLSUREG_SASSE : VarBasis
    {
        /*"    10 SUREGSAS-COD-SUREG-SASSE  PIC S9(4) USAGE COMP.*/
        public IntBasis SUREGSAS_COD_SUREG_SASSE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SUREGSAS-NOME-SUREG-SASSE  PIC X(40).*/
        public StringBasis SUREGSAS_NOME_SUREG_SASSE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"*/
    }
}