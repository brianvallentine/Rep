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
    public class SISINFAS_DCLSI_SINISTRO_FASE : VarBasis
    {
        /*"    10 SISINFAS-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis SISINFAS_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SISINFAS-NUM-PROTOCOLO-SINI  PIC S9(9) USAGE COMP.*/
        public IntBasis SISINFAS_NUM_PROTOCOLO_SINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SISINFAS-DAC-PROTOCOLO-SINI  PIC X(1).*/
        public StringBasis SISINFAS_DAC_PROTOCOLO_SINI { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SISINFAS-COD-FASE    PIC S9(4) USAGE COMP.*/
        public IntBasis SISINFAS_COD_FASE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SISINFAS-COD-EVENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SISINFAS_COD_EVENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SISINFAS-NUM-OCORR-SINIACO  PIC S9(4) USAGE COMP.*/
        public IntBasis SISINFAS_NUM_OCORR_SINIACO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SISINFAS-DATA-INIVIG-REFAEV  PIC X(10).*/
        public StringBasis SISINFAS_DATA_INIVIG_REFAEV { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SISINFAS-DATA-ABERTURA-SIFA  PIC X(10).*/
        public StringBasis SISINFAS_DATA_ABERTURA_SIFA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SISINFAS-DATA-FECHA-SIFA  PIC X(10).*/
        public StringBasis SISINFAS_DATA_FECHA_SIFA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SISINFAS-TIMESTAMP   PIC X(26).*/
        public StringBasis SISINFAS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}