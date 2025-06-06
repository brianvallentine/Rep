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
    public class PF037_DCLPF_ERRO_DEVOLUCAO : VarBasis
    {
        /*"    10 PF037-COD-DEVOLUCAO  PIC S9(4) USAGE COMP.*/
        public IntBasis PF037_COD_DEVOLUCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PF037-SIT-MOTIVO-SIVPF  PIC S9(9) USAGE COMP.*/
        public IntBasis PF037_SIT_MOTIVO_SIVPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PF037-DTH-CADASTRAMENTO  PIC X(10).*/
        public StringBasis PF037_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}