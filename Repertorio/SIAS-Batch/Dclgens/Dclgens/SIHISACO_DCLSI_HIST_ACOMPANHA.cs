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
    public class SIHISACO_DCLSI_HIST_ACOMPANHA : VarBasis
    {
        /*"    10 SIHISACO-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis SIHISACO_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIHISACO-NUM-PROTOCOLO-SINI  PIC S9(9) USAGE COMP.*/
        public IntBasis SIHISACO_NUM_PROTOCOLO_SINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIHISACO-DAC-PROTOCOLO-SINI  PIC X(1).*/
        public StringBasis SIHISACO_DAC_PROTOCOLO_SINI { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIHISACO-NUM-OCORR-SINIACO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIHISACO_NUM_OCORR_SINIACO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIHISACO-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SIHISACO_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SIHISACO-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIHISACO_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIHISACO-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIHISACO_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}