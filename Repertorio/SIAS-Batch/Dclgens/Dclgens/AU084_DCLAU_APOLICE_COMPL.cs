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
    public class AU084_DCLAU_APOLICE_COMPL : VarBasis
    {
        /*"    10 AU084-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis AU084_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 AU084-NUM-ENDOSSO    PIC S9(9) USAGE COMP.*/
        public IntBasis AU084_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AU084-NUM-ITEM       PIC S9(9) USAGE COMP.*/
        public IntBasis AU084_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AU084-COD-PARCEIRO   PIC S9(4) USAGE COMP.*/
        public IntBasis AU084_COD_PARCEIRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AU084-COD-PONTO-VENDA       PIC S9(9) USAGE COMP.*/
        public IntBasis AU084_COD_PONTO_VENDA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AU084-NUM-CPF-OPERADOR       PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis AU084_NUM_CPF_OPERADOR { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 AU084-STA-RENOVACAO-AUT       PIC X(1).*/
        public StringBasis AU084_STA_RENOVACAO_AUT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AU084-STA-ENVIO-SMS  PIC X(1).*/
        public StringBasis AU084_STA_ENVIO_SMS { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AU084-STA-ENVIO-EMAIL       PIC X(1).*/
        public StringBasis AU084_STA_ENVIO_EMAIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AU084-NUM-TOKEN-PGTO       PIC S9(16)V USAGE COMP-3.*/
        public DoubleBasis AU084_NUM_TOKEN_PGTO { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V"), 0);
        /*"    10 AU084-IND-FORMA-PAGTO-AD       PIC X(1).*/
        public StringBasis AU084_IND_FORMA_PAGTO_AD { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}