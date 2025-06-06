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
    public class SINCREIN_DCLSINISTRO_CRED_INT : VarBasis
    {
        /*"    10 SINCREIN-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis SINCREIN_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINCREIN-COD-SUREG   PIC S9(4) USAGE COMP.*/
        public IntBasis SINCREIN_COD_SUREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINCREIN-COD-AGENCIA  PIC S9(4) USAGE COMP.*/
        public IntBasis SINCREIN_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINCREIN-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis SINCREIN_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINCREIN-NUM-CONTRATO  PIC S9(9) USAGE COMP.*/
        public IntBasis SINCREIN_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINCREIN-CONTRATO-DIGITO  PIC S9(4) USAGE COMP.*/
        public IntBasis SINCREIN_CONTRATO_DIGITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINCREIN-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINCREIN_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINCREIN-SIT-REGISTRO  PIC X(1).*/
        public StringBasis SINCREIN_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINCREIN-TIMESTAMP   PIC X(26).*/
        public StringBasis SINCREIN_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}