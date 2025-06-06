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
    public class SIPROACO_DCLSI_PROTOCOLO_ACOMP : VarBasis
    {
        /*"    10 SIPROACO-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis SIPROACO_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIPROACO-NUM-PROTOCOLO-SINI  PIC S9(9) USAGE COMP.*/
        public IntBasis SIPROACO_NUM_PROTOCOLO_SINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIPROACO-DAC-PROTOCOLO-SINI  PIC X(1).*/
        public StringBasis SIPROACO_DAC_PROTOCOLO_SINI { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIPROACO-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIPROACO_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIPROACO-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis SIPROACO_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIPROACO-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis SIPROACO_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIPROACO-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIPROACO_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIPROACO-COD-GRUPO-CAUSA  PIC S9(4) USAGE COMP.*/
        public IntBasis SIPROACO_COD_GRUPO_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIPROACO-COD-SUBGRUPO-CAUSA  PIC S9(4) USAGE COMP.*/
        public IntBasis SIPROACO_COD_SUBGRUPO_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIPROACO-NUM-PARTICIPANTE  PIC S9(4) USAGE COMP.*/
        public IntBasis SIPROACO_NUM_PARTICIPANTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIPROACO-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis SIPROACO_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIPROACO-COD-DOCUMENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIPROACO_COD_DOCUMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIPROACO-COD-FASE    PIC S9(4) USAGE COMP.*/
        public IntBasis SIPROACO_COD_FASE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIPROACO-COD-EVENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIPROACO_COD_EVENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIPROACO-NUM-CARTA   PIC S9(9) USAGE COMP.*/
        public IntBasis SIPROACO_NUM_CARTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIPROACO-OCORR-HIST-PAI  PIC S9(4) USAGE COMP.*/
        public IntBasis SIPROACO_OCORR_HIST_PAI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIPROACO-COD-USUARIO  PIC X(8).*/
        public StringBasis SIPROACO_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SIPROACO-TIMESTAMP   PIC X(26).*/
        public StringBasis SIPROACO_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SIPROACO-NOM-SISTEMA-ORIGEM  PIC X(8).*/
        public StringBasis SIPROACO_NOM_SISTEMA_ORIGEM { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SIPROACO-NOM-PROGRAMA  PIC X(8).*/
        public StringBasis SIPROACO_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SIPROACO-STA-INTEGRA-AMSS  PIC X(1).*/
        public StringBasis SIPROACO_STA_INTEGRA_AMSS { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}