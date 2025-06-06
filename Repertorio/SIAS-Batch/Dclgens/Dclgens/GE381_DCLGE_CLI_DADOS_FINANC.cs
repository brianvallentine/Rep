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
    public class GE381_DCLGE_CLI_DADOS_FINANC : VarBasis
    {
        /*"    10 GE381-COD-CLIENTE    PIC S9(9) USAGE COMP.*/
        public IntBasis GE381_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE381-COD-TIPO-CONTA       PIC X(1).*/
        public StringBasis GE381_COD_TIPO_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE381-COD-BCO        PIC S9(4) USAGE COMP.*/
        public IntBasis GE381_COD_BCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE381-COD-AGENCIA    PIC X(4).*/
        public StringBasis GE381_COD_AGENCIA { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 GE381-COD-AGENCIA-DV       PIC X(1).*/
        public StringBasis GE381_COD_AGENCIA_DV { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE381-COD-OPERACAO   PIC S9(4) USAGE COMP.*/
        public IntBasis GE381_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE381-NUM-CONTA      PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis GE381_NUM_CONTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 GE381-NUM-CONTA-DV1  PIC X(1).*/
        public StringBasis GE381_NUM_CONTA_DV1 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE381-COD-USUARIO    PIC X(8).*/
        public StringBasis GE381_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE381-DTH-TIMESTAMP  PIC X(26).*/
        public StringBasis GE381_DTH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
    }
}