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
    public class CEDENTE_DCLCEDENTE : VarBasis
    {
        /*"    10 CEDENTE-COD-CEDENTE  PIC S9(4) USAGE COMP.*/
        public IntBasis CEDENTE_COD_CEDENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CEDENTE-NOME-CEDENTE       PIC X(40).*/
        public StringBasis CEDENTE_NOME_CEDENTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 CEDENTE-COD-AGENCIA  PIC S9(4) USAGE COMP.*/
        public IntBasis CEDENTE_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CEDENTE-OPERACAO-CONTA       PIC S9(4) USAGE COMP.*/
        public IntBasis CEDENTE_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CEDENTE-NUM-CONTA    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis CEDENTE_NUM_CONTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 CEDENTE-DIG-CONTA    PIC S9(4) USAGE COMP.*/
        public IntBasis CEDENTE_DIG_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CEDENTE-NUM-TITULO   PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis CEDENTE_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 CEDENTE-NUM-TITULO-MAX       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis CEDENTE_NUM_TITULO_MAX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 CEDENTE-TIMESTAMP    PIC X(26).*/
        public StringBasis CEDENTE_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 CEDENTE-TIPO-MOVIMENTO       PIC X(1).*/
        public StringBasis CEDENTE_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CEDENTE-COD-COBRANCA       PIC S9(4) USAGE COMP.*/
        public IntBasis CEDENTE_COD_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}