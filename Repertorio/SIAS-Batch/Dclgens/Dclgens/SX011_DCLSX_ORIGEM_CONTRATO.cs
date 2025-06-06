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
    public class SX011_DCLSX_ORIGEM_CONTRATO : VarBasis
    {
        /*"    10 SX011-NUM-ORI-CONTRATO       PIC S9(18) USAGE COMP.*/
        public IntBasis SX011_NUM_ORI_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 SX011-COD-PRODUTO    PIC S9(9) USAGE COMP.*/
        public IntBasis SX011_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SX011-SEQ-APOLICE    PIC S9(9) USAGE COMP.*/
        public IntBasis SX011_SEQ_APOLICE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SX011-NUM-PES-ESTIP  PIC S9(9) USAGE COMP.*/
        public IntBasis SX011_NUM_PES_ESTIP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SX011-NUM-PES-SUBESTIP       PIC S9(9) USAGE COMP.*/
        public IntBasis SX011_NUM_PES_SUBESTIP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SX011-COD-BANCO      PIC S9(4) USAGE COMP.*/
        public IntBasis SX011_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SX011-NUM-PES-PARCEIRO       PIC S9(9) USAGE COMP.*/
        public IntBasis SX011_NUM_PES_PARCEIRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SX011-IND-ENDOSSO-INDIVIDUAL       PIC X(1).*/
        public StringBasis SX011_IND_ENDOSSO_INDIVIDUAL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SX011-STA-ORIGEM-CONTRATO       PIC X(1).*/
        public StringBasis SX011_STA_ORIGEM_CONTRATO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SX011-DTA-CADASTRAMENTO       PIC X(10).*/
        public StringBasis SX011_DTA_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}