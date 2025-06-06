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
    public class SIDOCACO_DCLSI_DOCUMENTO_ACOMP : VarBasis
    {
        /*"    10 SIDOCACO-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis SIDOCACO_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIDOCACO-NUM-PROTOCOLO-SINI  PIC S9(9) USAGE COMP.*/
        public IntBasis SIDOCACO_NUM_PROTOCOLO_SINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIDOCACO-DAC-PROTOCOLO-SINI  PIC X(1).*/
        public StringBasis SIDOCACO_DAC_PROTOCOLO_SINI { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIDOCACO-COD-DOCUMENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIDOCACO_COD_DOCUMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIDOCACO-NUM-OCORR-DOCACO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIDOCACO_NUM_OCORR_DOCACO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIDOCACO-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIDOCACO_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIDOCACO-COD-GRUPO-CAUSA  PIC S9(4) USAGE COMP.*/
        public IntBasis SIDOCACO_COD_GRUPO_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIDOCACO-COD-SUBGRUPO-CAUSA  PIC S9(4) USAGE COMP.*/
        public IntBasis SIDOCACO_COD_SUBGRUPO_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIDOCACO-DATA-INIVIG-DOCPAR  PIC X(10).*/
        public StringBasis SIDOCACO_DATA_INIVIG_DOCPAR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIDOCACO-COD-EVENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIDOCACO_COD_EVENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIDOCACO-DATA-MOVTO-DOCACO  PIC X(10).*/
        public StringBasis SIDOCACO_DATA_MOVTO_DOCACO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIDOCACO-DESCR-COMPLEMENTAR  PIC X(40).*/
        public StringBasis SIDOCACO_DESCR_COMPLEMENTAR { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SIDOCACO-NUM-CARTA   PIC S9(9) USAGE COMP.*/
        public IntBasis SIDOCACO_NUM_CARTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIDOCACO-COD-USUARIO  PIC X(8).*/
        public StringBasis SIDOCACO_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SIDOCACO-TIMESTAMP   PIC X(26).*/
        public StringBasis SIDOCACO_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}