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
    public class GEACODIR_DCLGE_ACOMP_DIRECIONA : VarBasis
    {
        /*"    10 GEACODIR-DTH-REFERENCIA  PIC X(10).*/
        public StringBasis GEACODIR_DTH_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GEACODIR-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis GEACODIR_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GEACODIR-COD-TIPO-MOVIMENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis GEACODIR_COD_TIPO_MOVIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEACODIR-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis GEACODIR_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEACODIR-RAMO-EMISSOR  PIC S9(4) USAGE COMP.*/
        public IntBasis GEACODIR_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEACODIR-COD-MODALIDADE  PIC S9(4) USAGE COMP.*/
        public IntBasis GEACODIR_COD_MODALIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEACODIR-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis GEACODIR_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEACODIR-NUM-CENTRO-CUSTO  PIC S9(9) USAGE COMP.*/
        public IntBasis GEACODIR_NUM_CENTRO_CUSTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GEACODIR-IND-EVENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis GEACODIR_IND_EVENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEACODIR-QTD-APURADA  PIC S9(10)V9(2) USAGE COMP-3.*/
        public DoubleBasis GEACODIR_QTD_APURADA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(2)"), 2);
        /*"    10 GEACODIR-NOM-PROGRAMA  PIC X(8).*/
        public StringBasis GEACODIR_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GEACODIR-COD-USUARIO  PIC X(8).*/
        public StringBasis GEACODIR_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GEACODIR-DTH-TIMESTAMP  PIC X(26).*/
        public StringBasis GEACODIR_DTH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
    }
}