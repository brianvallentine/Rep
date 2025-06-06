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
    public class AU085_DCLAU_PROPOSTA_COMPL : VarBasis
    {
        /*"    10 AU085-COD-FONTE      PIC S9(4) USAGE COMP.*/
        public IntBasis AU085_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AU085-NUM-PROPOSTA   PIC S9(9) USAGE COMP.*/
        public IntBasis AU085_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AU085-NUM-ITEM       PIC S9(9) USAGE COMP.*/
        public IntBasis AU085_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AU085-DATA-INIVIGENCIA       PIC X(10).*/
        public StringBasis AU085_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 AU085-COD-PARCEIRO   PIC S9(4) USAGE COMP.*/
        public IntBasis AU085_COD_PARCEIRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AU085-COD-PONTO-VENDA       PIC S9(9) USAGE COMP.*/
        public IntBasis AU085_COD_PONTO_VENDA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AU085-NUM-CPF-OPERADOR       PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis AU085_NUM_CPF_OPERADOR { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 AU085-STA-RENOVACAO-AUT       PIC X(1).*/
        public StringBasis AU085_STA_RENOVACAO_AUT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AU085-STA-ENVIO-SMS  PIC X(1).*/
        public StringBasis AU085_STA_ENVIO_SMS { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AU085-STA-ENVIO-EMAIL       PIC X(1).*/
        public StringBasis AU085_STA_ENVIO_EMAIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AU085-NUM-TOKEN-PGTO       PIC S9(16)V USAGE COMP-3.*/
        public DoubleBasis AU085_NUM_TOKEN_PGTO { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V"), 0);
        /*"    10 AU085-IND-FORMA-PAGTO-AD       PIC X(1).*/
        public StringBasis AU085_IND_FORMA_PAGTO_AD { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AU085-COD-RETORNO-CEF       PIC S9(4) USAGE COMP.*/
        public IntBasis AU085_COD_RETORNO_CEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AU085-COD-RETORNO-BANCO       PIC X(2).*/
        public StringBasis AU085_COD_RETORNO_BANCO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"*/
    }
}