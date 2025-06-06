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
    public class VGACOTER_DCLVG_ACOMP_TERMO : VarBasis
    {
        /*"    10 VGACOTER-NUM-TERMO   PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis VGACOTER_NUM_TERMO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 VGACOTER-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis VGACOTER_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGACOTER-COD-DEVOLUCAO  PIC S9(4) USAGE COMP.*/
        public IntBasis VGACOTER_COD_DEVOLUCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGACOTER-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis VGACOTER_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VGACOTER-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis VGACOTER_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGACOTER-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis VGACOTER_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VGACOTER-VLPREMIO    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGACOTER_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VGACOTER-COD-USUARIO  PIC X(8).*/
        public StringBasis VGACOTER_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VGACOTER-TIMESTAMP   PIC X(26).*/
        public StringBasis VGACOTER_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}