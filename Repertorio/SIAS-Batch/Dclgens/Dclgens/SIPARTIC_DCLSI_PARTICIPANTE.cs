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
    public class SIPARTIC_DCLSI_PARTICIPANTE : VarBasis
    {
        /*"    10 SIPARTIC-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis SIPARTIC_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIPARTIC-NUM-PROTOCOLO-SINI  PIC S9(9) USAGE COMP.*/
        public IntBasis SIPARTIC_NUM_PROTOCOLO_SINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIPARTIC-DAC-PROTOCOLO-SINI  PIC X(1).*/
        public StringBasis SIPARTIC_DAC_PROTOCOLO_SINI { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIPARTIC-NUM-PARTICIPANTE  PIC S9(4) USAGE COMP.*/
        public IntBasis SIPARTIC_NUM_PARTICIPANTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIPARTIC-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis SIPARTIC_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIPARTIC-SIT-PARTICIPANTE  PIC X(1).*/
        public StringBasis SIPARTIC_SIT_PARTICIPANTE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIPARTIC-COD-USUARIO  PIC X(8).*/
        public StringBasis SIPARTIC_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SIPARTIC-TIMESTAMP   PIC X(26).*/
        public StringBasis SIPARTIC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}