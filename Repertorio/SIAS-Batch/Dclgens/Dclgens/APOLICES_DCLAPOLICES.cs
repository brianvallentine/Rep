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
    public class APOLICES_DCLAPOLICES : VarBasis
    {
        /*"    10 APOLICES-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis APOLICES_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLICES-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis APOLICES_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 APOLICES-NUM-ITEM    PIC S9(9) USAGE COMP.*/
        public IntBasis APOLICES_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLICES-COD-MODALIDADE  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICES_COD_MODALIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICES-ORGAO-EMISSOR  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICES_ORGAO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICES-RAMO-EMISSOR  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICES_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICES-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICES_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICES-NUM-APOL-ANTERIOR  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis APOLICES_NUM_APOL_ANTERIOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 APOLICES-NUM-BILHETE  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis APOLICES_NUM_BILHETE { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 APOLICES-TIPO-SEGURO  PIC X(1).*/
        public StringBasis APOLICES_TIPO_SEGURO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLICES-TIPO-APOLICE  PIC X(1).*/
        public StringBasis APOLICES_TIPO_APOLICE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLICES-TIPO-CALCULO  PIC X(1).*/
        public StringBasis APOLICES_TIPO_CALCULO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLICES-IND-SORTEIO  PIC X(1).*/
        public StringBasis APOLICES_IND_SORTEIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLICES-NUM-ATA     PIC S9(9) USAGE COMP.*/
        public IntBasis APOLICES_NUM_ATA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLICES-ANO-ATA     PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICES_ANO_ATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICES-IND-ENDOS-MANUAL  PIC X(1).*/
        public StringBasis APOLICES_IND_ENDOS_MANUAL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLICES-PCT-DESC-PREMIO  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis APOLICES_PCT_DESC_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 APOLICES-PCT-IOCC    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis APOLICES_PCT_IOCC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 APOLICES-TIPO-COSSEGURO-CED  PIC X(1).*/
        public StringBasis APOLICES_TIPO_COSSEGURO_CED { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLICES-QTD-COSSEGURADORA  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICES_QTD_COSSEGURADORA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICES-PCT-COSSEGURO-CED  PIC S9(4)V9(5) USAGE COMP-3.*/
        public DoubleBasis APOLICES_PCT_COSSEGURO_CED { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(5)"), 5);
        /*"    10 APOLICES-DATA-SORTEIO  PIC X(10).*/
        public StringBasis APOLICES_DATA_SORTEIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 APOLICES-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis APOLICES_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLICES-TIMESTAMP   PIC X(26).*/
        public StringBasis APOLICES_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 APOLICES-TIPO-CORRETAGEM  PIC X(1).*/
        public StringBasis APOLICES_TIPO_CORRETAGEM { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}