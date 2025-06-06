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
    public class FUNCOMVA_DCLFUNDO_COMISSAO_VA : VarBasis
    {
        /*"    10 FUNCOMVA-CODIGO-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis FUNCOMVA_CODIGO_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FUNCOMVA-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis FUNCOMVA_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 FUNCOMVA-NUM-PROPOSTA-AZUL  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis FUNCOMVA_NUM_PROPOSTA_AZUL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 FUNCOMVA-NUM-TERMO   PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis FUNCOMVA_NUM_TERMO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 FUNCOMVA-SITUACAO    PIC X(1).*/
        public StringBasis FUNCOMVA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FUNCOMVA-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis FUNCOMVA_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FUNCOMVA-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis FUNCOMVA_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FUNCOMVA-COD-AGENCIA  PIC S9(4) USAGE COMP.*/
        public IntBasis FUNCOMVA_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FUNCOMVA-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis FUNCOMVA_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FUNCOMVA-NUM-MATRI-VENDEDOR  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis FUNCOMVA_NUM_MATRI_VENDEDOR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 FUNCOMVA-VAL-BASICO-VG  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis FUNCOMVA_VAL_BASICO_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 FUNCOMVA-VAL-BASICO-AP  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis FUNCOMVA_VAL_BASICO_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 FUNCOMVA-VAL-COMISSAO-VG  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis FUNCOMVA_VAL_COMISSAO_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 FUNCOMVA-VAL-COMISSAO-AP  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis FUNCOMVA_VAL_COMISSAO_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 FUNCOMVA-DATA-QUITACAO  PIC X(10).*/
        public StringBasis FUNCOMVA_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FUNCOMVA-PCCOMIND    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis FUNCOMVA_PCCOMIND { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 FUNCOMVA-PCCOMGER    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis FUNCOMVA_PCCOMGER { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 FUNCOMVA-PCCOMSUP    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis FUNCOMVA_PCCOMSUP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 FUNCOMVA-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis FUNCOMVA_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FUNCOMVA-COD-USUARIO  PIC X(8).*/
        public StringBasis FUNCOMVA_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 FUNCOMVA-TIMESTAMP   PIC X(26).*/
        public StringBasis FUNCOMVA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 FUNCOMVA-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis FUNCOMVA_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 FUNCOMVA-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis FUNCOMVA_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FUNCOMVA-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis FUNCOMVA_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FUNCOMVA-NUM-TITULO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis FUNCOMVA_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 FUNCOMVA-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis FUNCOMVA_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}