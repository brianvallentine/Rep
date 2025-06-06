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
    public class RELCHSIV_DCLRELACAO_CHEQ_SIVAT : VarBasis
    {
        /*"    10 RELCHSIV-NUMERO-SIVAT  PIC S9(9)V USAGE COMP-3.*/
        public DoubleBasis RELCHSIV_NUMERO_SIVAT { get; set; } = new DoubleBasis(new PIC("S9", "9", "S9(9)V"), 0);
        /*"    10 RELCHSIV-DV-SIVAT    PIC X(1).*/
        public StringBasis RELCHSIV_DV_SIVAT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 RELCHSIV-SERIE-SIVAT  PIC X(6).*/
        public StringBasis RELCHSIV_SERIE_SIVAT { get; set; } = new StringBasis(new PIC("X", "6", "X(6)."), @"");
        /*"    10 RELCHSIV-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis RELCHSIV_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 RELCHSIV-DATA-SIVAT  PIC X(10).*/
        public StringBasis RELCHSIV_DATA_SIVAT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 RELCHSIV-AG-DESTINO  PIC S9(9) USAGE COMP.*/
        public IntBasis RELCHSIV_AG_DESTINO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 RELCHSIV-TIPO-FAVORECIDO  PIC X(1).*/
        public StringBasis RELCHSIV_TIPO_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 RELCHSIV-COD-FAVORECIDO  PIC S9(9) USAGE COMP.*/
        public IntBasis RELCHSIV_COD_FAVORECIDO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 RELCHSIV-VAL-BRUTO-RESGATE  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis RELCHSIV_VAL_BRUTO_RESGATE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 RELCHSIV-TIPO-MOVIMENTO  PIC X(1).*/
        public StringBasis RELCHSIV_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 RELCHSIV-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis RELCHSIV_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 RELCHSIV-NUM-DOCUMENTO  PIC X(18).*/
        public StringBasis RELCHSIV_NUM_DOCUMENTO { get; set; } = new StringBasis(new PIC("X", "18", "X(18)."), @"");
        /*"    10 RELCHSIV-NUM-CHEQUE-INTERNO  PIC S9(9) USAGE COMP.*/
        public IntBasis RELCHSIV_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 RELCHSIV-VAL-CHEQUE  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis RELCHSIV_VAL_CHEQUE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 RELCHSIV-VAL-IRF     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis RELCHSIV_VAL_IRF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 RELCHSIV-VAL-ISS     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis RELCHSIV_VAL_ISS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 RELCHSIV-SITUACAO    PIC X(1).*/
        public StringBasis RELCHSIV_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 RELCHSIV-TIMESTAMP   PIC X(26).*/
        public StringBasis RELCHSIV_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 RELCHSIV-NUMREC      PIC S9(9) USAGE COMP.*/
        public IntBasis RELCHSIV_NUMREC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 RELCHSIV-COD-DESPESA  PIC S9(4) USAGE COMP.*/
        public IntBasis RELCHSIV_COD_DESPESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RELCHSIV-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis RELCHSIV_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}