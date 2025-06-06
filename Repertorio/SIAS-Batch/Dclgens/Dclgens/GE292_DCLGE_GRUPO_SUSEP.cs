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
    public class GE292_DCLGE_GRUPO_SUSEP : VarBasis
    {
        /*"    10 GE292-RAMO-EMISSOR   PIC S9(4) USAGE COMP.*/
        public IntBasis GE292_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE292-COD-MODALIDADE  PIC S9(4) USAGE COMP.*/
        public IntBasis GE292_COD_MODALIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE292-DTH-INI-VIGENCIA  PIC X(10).*/
        public StringBasis GE292_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE292-DTH-FIM-VIGENCIA  PIC X(10).*/
        public StringBasis GE292_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE292-COD-GRUPO-SUSEP  PIC S9(4) USAGE COMP.*/
        public IntBasis GE292_COD_GRUPO_SUSEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE292-COD-RAMO-SUSEP  PIC S9(4) USAGE COMP.*/
        public IntBasis GE292_COD_RAMO_SUSEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE292-DTH-GERACAO    PIC X(26).*/
        public StringBasis GE292_DTH_GERACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GE292-COD-USUARIO    PIC X(8).*/
        public StringBasis GE292_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"*/
    }
}