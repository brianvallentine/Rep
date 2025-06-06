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
    public class SISINACO_DCLSI_SINISTRO_ACOMP : VarBasis
    {
        /*"    10 SISINACO-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis SISINACO_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SISINACO-NUM-PROTOCOLO-SINI  PIC S9(9) USAGE COMP.*/
        public IntBasis SISINACO_NUM_PROTOCOLO_SINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SISINACO-DAC-PROTOCOLO-SINI  PIC X(1).*/
        public StringBasis SISINACO_DAC_PROTOCOLO_SINI { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SISINACO-NUM-OCORR-SINIACO  PIC S9(4) USAGE COMP.*/
        public IntBasis SISINACO_NUM_OCORR_SINIACO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SISINACO-COD-EVENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SISINACO_COD_EVENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SISINACO-DATA-MOVTO-SINIACO  PIC X(10).*/
        public StringBasis SISINACO_DATA_MOVTO_SINIACO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SISINACO-DESCR-COMPLEMENTAR  PIC X(40).*/
        public StringBasis SISINACO_DESCR_COMPLEMENTAR { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SISINACO-COD-USUARIO  PIC X(8).*/
        public StringBasis SISINACO_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SISINACO-TIMESTAMP   PIC X(26).*/
        public StringBasis SISINACO_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SISINACO-NUM-CARTA   PIC S9(9) USAGE COMP.*/
        public IntBasis SISINACO_NUM_CARTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}