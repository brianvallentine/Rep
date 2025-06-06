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
    public class APOLICRE_DCLAPOLICE_CREDITO : VarBasis
    {
        /*"    10 APOLICRE-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis APOLICRE_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLICRE-NUM-FATURA  PIC S9(9) USAGE COMP.*/
        public IntBasis APOLICRE_NUM_FATURA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLICRE-COD-SUREG   PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICRE_COD_SUREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICRE-COD-AGENCIA  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICRE_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICRE-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICRE_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICRE-NUM-CONTRATO  PIC S9(9) USAGE COMP.*/
        public IntBasis APOLICRE_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLICRE-CONTRATO-DIGITO  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICRE_CONTRATO_DIGITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICRE-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis APOLICRE_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 APOLICRE-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis APOLICRE_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 APOLICRE-PRAZO       PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICRE_PRAZO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICRE-PROPRIET    PIC X(40).*/
        public StringBasis APOLICRE_PROPRIET { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 APOLICRE-TIPO-PESSOA  PIC X(1).*/
        public StringBasis APOLICRE_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLICRE-CGCCPF      PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis APOLICRE_CGCCPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 APOLICRE-SITUACAO    PIC X(1).*/
        public StringBasis APOLICRE_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLICRE-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis APOLICRE_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 APOLICRE-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis APOLICRE_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLICRE-TIMESTAMP   PIC X(26).*/
        public StringBasis APOLICRE_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 APOLICRE-VAL-SEGURO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis APOLICRE_VAL_SEGURO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 APOLICRE-VAL-PREMIO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis APOLICRE_VAL_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 APOLICRE-CODIGO-RAMO  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICRE_CODIGO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICRE-TIPO-CREDITO  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICRE_TIPO_CREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICRE-NATUREZA    PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICRE_NATUREZA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICRE-COD-MODALIDADE  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICRE_COD_MODALIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICRE-COD-PROFISSAO  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICRE_COD_PROFISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICRE-STA-SEXO    PIC X(1).*/
        public StringBasis APOLICRE_STA_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLICRE-NUM-POS-SINISTRO  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICRE_NUM_POS_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}