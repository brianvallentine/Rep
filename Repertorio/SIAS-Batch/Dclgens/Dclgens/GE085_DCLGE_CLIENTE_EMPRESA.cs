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
    public class GE085_DCLGE_CLIENTE_EMPRESA : VarBasis
    {
        /*"    10 GE085-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis GE085_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 GE085-IND-TP-PROPOSTA       PIC X(2).*/
        public StringBasis GE085_IND_TP_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE085-COD-CLIENTE-PJ       PIC S9(9) USAGE COMP.*/
        public IntBasis GE085_COD_CLIENTE_PJ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE085-COD-ENDERECO-PJ       PIC S9(4) USAGE COMP.*/
        public IntBasis GE085_COD_ENDERECO_PJ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE085-COD-CLIENTE-PF       PIC S9(9) USAGE COMP.*/
        public IntBasis GE085_COD_CLIENTE_PF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE085-COD-USUARIO    PIC X(8).*/
        public StringBasis GE085_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE085-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis GE085_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE085-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE085_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}