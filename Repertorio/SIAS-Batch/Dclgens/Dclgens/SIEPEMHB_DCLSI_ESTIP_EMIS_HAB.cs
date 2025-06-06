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
    public class SIEPEMHB_DCLSI_ESTIP_EMIS_HAB : VarBasis
    {
        /*"    10 SIEPEMHB-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SIEPEMHB_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SIEPEMHB-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIEPEMHB_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIEPEMHB-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIEPEMHB_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIEPEMHB-SEQ-ESTIP-HAB  PIC S9(4) USAGE COMP.*/
        public IntBasis SIEPEMHB_SEQ_ESTIP_HAB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIEPEMHB-COD-ESTIP-EMIS  PIC S9(9) USAGE COMP.*/
        public IntBasis SIEPEMHB_COD_ESTIP_EMIS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIEPEMHB-COD-SUBESTIP-EMIS  PIC S9(9) USAGE COMP.*/
        public IntBasis SIEPEMHB_COD_SUBESTIP_EMIS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIEPEMHB-COD-FILIAL-EMIS  PIC S9(4) USAGE COMP.*/
        public IntBasis SIEPEMHB_COD_FILIAL_EMIS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIEPEMHB-COD-AGENTE-EMIS  PIC S9(9) USAGE COMP.*/
        public IntBasis SIEPEMHB_COD_AGENTE_EMIS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIEPEMHB-COD-AGENCIA  PIC S9(4) USAGE COMP.*/
        public IntBasis SIEPEMHB_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIEPEMHB-COD-TP-RECIBO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIEPEMHB_COD_TP_RECIBO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}