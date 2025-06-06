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
    public class SIANAROD_DCLSI_ANALISTA_RODIZI : VarBasis
    {
        /*"    10 SIANAROD-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis SIANAROD_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIANAROD-NUM-PROTOCOLO-SINI  PIC S9(9) USAGE COMP.*/
        public IntBasis SIANAROD_NUM_PROTOCOLO_SINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIANAROD-DAC-PROTOCOLO-SINI  PIC X(1).*/
        public StringBasis SIANAROD_DAC_PROTOCOLO_SINI { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIANAROD-COD-USUARIO  PIC X(8).*/
        public StringBasis SIANAROD_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SIANAROD-NUM-TIPO-RODIZIO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIANAROD_NUM_TIPO_RODIZIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}