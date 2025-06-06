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
    public class FDCOMVA_DCLFUNDO_COMISSAO_VA : VarBasis
    {
        /*"    10 CODIGO-PRODUTO       PIC S9(4) USAGE COMP.*/
        public IntBasis CODIGO_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NUM-CERTIFICADO      PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 NUM-PROPOSTA-AZUL    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis NUM_PROPOSTA_AZUL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 NUM-TERMO            PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis NUM_TERMO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 SITUACAO             PIC X(1).*/
        public StringBasis SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COD-OPERACAO         PIC S9(4) USAGE COMP.*/
        public IntBasis COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COD-FONTE            PIC S9(4) USAGE COMP.*/
        public IntBasis COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COD-AGENCIA          PIC S9(4) USAGE COMP.*/
        public IntBasis COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COD-CLIENTE          PIC S9(9) USAGE COMP.*/
        public IntBasis COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUM-MATRI-VENDEDOR   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NUM_MATRI_VENDEDOR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VAL-BASICO-VG        PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VAL_BASICO_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VAL-BASICO-AP        PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VAL_BASICO_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VAL-COMISSAO-VG      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VAL_COMISSAO_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VAL-COMISSAO-AP      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VAL_COMISSAO_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 DATA-QUITACAO        PIC X(10).*/
        public StringBasis DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PCCOMIND             PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis PCCOMIND { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 PCCOMGER             PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis PCCOMGER { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 PCCOMSUP             PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis PCCOMSUP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 DATA-MOVIMENTO       PIC X(10).*/
        public StringBasis DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 COD-USUARIO          PIC X(8).*/
        public StringBasis COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 TIMESTAMP            PIC X(26).*/
        public StringBasis TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}