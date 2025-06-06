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
    public class SIHISACM_DCLSI_HIST_ACOMP : VarBasis
    {
        /*"    10 SIHISACM-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis SIHISACM_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIHISACM-NUM-PROTOCOLO-SINI  PIC S9(9) USAGE COMP.*/
        public IntBasis SIHISACM_NUM_PROTOCOLO_SINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIHISACM-DAC-PROTOCOLO-SINI  PIC X(1).*/
        public StringBasis SIHISACM_DAC_PROTOCOLO_SINI { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIHISACM-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIHISACM_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIHISACM-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SIHISACM_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SIHISACM-OCORR-HIST  PIC S9(4) USAGE COMP.*/
        public IntBasis SIHISACM_OCORR_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIHISACM-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIHISACM_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}