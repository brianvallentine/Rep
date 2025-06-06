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
    public class PARCEVID_DCLPARCELAS_VIDAZUL : VarBasis
    {
        /*"    10 PARCEVID-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PARCEVID_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PARCEVID-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis PARCEVID_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARCEVID-DATA-VENCIMENTO  PIC X(10).*/
        public StringBasis PARCEVID_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PARCEVID-PREMIO-VG   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARCEVID_PREMIO_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PARCEVID-PREMIO-AP   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARCEVID_PREMIO_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PARCEVID-VLMULTA     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARCEVID_VLMULTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PARCEVID-OPCAO-PAGAMENTO  PIC X(1).*/
        public StringBasis PARCEVID_OPCAO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PARCEVID-SIT-REGISTRO  PIC X(1).*/
        public StringBasis PARCEVID_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PARCEVID-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis PARCEVID_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARCEVID-TIMESTAMP   PIC X(26).*/
        public StringBasis PARCEVID_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}