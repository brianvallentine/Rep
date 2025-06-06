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
    public class SIHISMOT_DCLSI_HIST_MOTIVO : VarBasis
    {
        /*"    10 SIHISMOT-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis SIHISMOT_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIHISMOT-NUM-PROTOCOLO-SINI  PIC S9(9) USAGE COMP.*/
        public IntBasis SIHISMOT_NUM_PROTOCOLO_SINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIHISMOT-DAC-PROTOCOLO-SINI  PIC X(1).*/
        public StringBasis SIHISMOT_DAC_PROTOCOLO_SINI { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIHISMOT-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIHISMOT_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIHISMOT-NUM-MOTIVO  PIC S9(9) USAGE COMP.*/
        public IntBasis SIHISMOT_NUM_MOTIVO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}