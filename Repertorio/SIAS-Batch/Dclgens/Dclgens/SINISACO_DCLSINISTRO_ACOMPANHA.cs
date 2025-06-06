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
    public class SINISACO_DCLSINISTRO_ACOMPANHA : VarBasis
    {
        /*"    10 SINISACO-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis SINISACO_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISACO-NUM-PROTOCOLO-SINI       PIC S9(9) USAGE COMP.*/
        public IntBasis SINISACO_NUM_PROTOCOLO_SINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISACO-DAC-PROTOCOLO-SINI       PIC X(1).*/
        public StringBasis SINISACO_DAC_PROTOCOLO_SINI { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINISACO-COD-OPERACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISACO_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISACO-DATA-OPERACAO       PIC X(10).*/
        public StringBasis SINISACO_DATA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINISACO-HORA-OPERACAO       PIC X(8).*/
        public StringBasis SINISACO_HORA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SINISACO-OCORR-HISTORICO       PIC S9(4) USAGE COMP.*/
        public IntBasis SINISACO_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINISACO-COD-USUARIO       PIC X(8).*/
        public StringBasis SINISACO_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SINISACO-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis SINISACO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINISACO-TIMESTAMP   PIC X(26).*/
        public StringBasis SINISACO_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SINISACO-DES-OCORR-TEC.*/
        public SINISACO_SINISACO_DES_OCORR_TEC SINISACO_DES_OCORR_TEC { get; set; } = new SINISACO_SINISACO_DES_OCORR_TEC();

    }
}