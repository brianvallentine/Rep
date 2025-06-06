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
    public class CBHSTZUL_DCLCOBER_HIST_VIDAZUL : VarBasis
    {
        /*"    10 NUM-CERTIFICADO      PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 NUM-PARCELA          PIC S9(4) USAGE COMP.*/
        public IntBasis NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NUM-TITULO           PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 DATA-VENCIMENTO      PIC X(10).*/
        public StringBasis DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PRM-TOTAL            PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 OPCAO-PAGAMENTO      PIC X(1).*/
        public StringBasis OPCAO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIT-REGISTRO         PIC X(1).*/
        public StringBasis SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COD-OPERACAO         PIC S9(4) USAGE COMP.*/
        public IntBasis COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OCORR-HISTORICO      PIC S9(4) USAGE COMP.*/
        public IntBasis OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COD-DEVOLUCAO        PIC S9(4) USAGE COMP.*/
        public IntBasis COD_DEVOLUCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BCO-AVISO            PIC S9(4) USAGE COMP.*/
        public IntBasis BCO_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AGE-AVISO            PIC S9(4) USAGE COMP.*/
        public IntBasis AGE_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NUM-AVISO-CREDITO    PIC S9(9) USAGE COMP.*/
        public IntBasis NUM_AVISO_CREDITO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUM-TITULO-COMP      PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis NUM_TITULO_COMP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"*/
    }
}