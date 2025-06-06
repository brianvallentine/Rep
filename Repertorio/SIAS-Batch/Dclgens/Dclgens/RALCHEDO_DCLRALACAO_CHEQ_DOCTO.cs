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
    public class RALCHEDO_DCLRALACAO_CHEQ_DOCTO : VarBasis
    {
        /*"    10 RALCHEDO-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis RALCHEDO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 RALCHEDO-NUM-CHEQUE-INTERNO  PIC S9(9) USAGE COMP.*/
        public IntBasis RALCHEDO_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 RALCHEDO-DIG-CHEQUE-INTERNO  PIC S9(4) USAGE COMP.*/
        public IntBasis RALCHEDO_DIG_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RALCHEDO-NUM-DOCUMENTO  PIC X(18).*/
        public StringBasis RALCHEDO_NUM_DOCUMENTO { get; set; } = new StringBasis(new PIC("X", "18", "X(18)."), @"");
        /*"    10 RALCHEDO-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis RALCHEDO_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RALCHEDO-TIPO-MOVIMENTO  PIC X(1).*/
        public StringBasis RALCHEDO_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 RALCHEDO-TIMESTAMP   PIC X(26).*/
        public StringBasis RALCHEDO_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 RALCHEDO-AGENCIA-CONTRATO  PIC S9(4) USAGE COMP.*/
        public IntBasis RALCHEDO_AGENCIA_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RALCHEDO-NUMERO-SIVAT  PIC S9(9)V USAGE COMP-3.*/
        public DoubleBasis RALCHEDO_NUMERO_SIVAT { get; set; } = new DoubleBasis(new PIC("S9", "9", "S9(9)V"), 0);
        /*"    10 RALCHEDO-DV-SIVAT    PIC X(1).*/
        public StringBasis RALCHEDO_DV_SIVAT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 RALCHEDO-DATA-SIVAT  PIC X(10).*/
        public StringBasis RALCHEDO_DATA_SIVAT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 RALCHEDO-AGE-CENTRAL-PROD01  PIC S9(4) USAGE COMP.*/
        public IntBasis RALCHEDO_AGE_CENTRAL_PROD01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RALCHEDO-NUMDOC-NUM01  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis RALCHEDO_NUMDOC_NUM01 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"*/
    }
}