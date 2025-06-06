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
    public class PESSOJUR_DCLPESSOA_JURIDICA : VarBasis
    {
        /*"    10 PESSOJUR-COD-PESSOA  PIC S9(9) USAGE COMP.*/
        public IntBasis PESSOJUR_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PESSOJUR-CGC         PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PESSOJUR_CGC { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PESSOJUR-NOME-FANTASIA       PIC X(40).*/
        public StringBasis PESSOJUR_NOME_FANTASIA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 PESSOJUR-COD-USUARIO       PIC X(8).*/
        public StringBasis PESSOJUR_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PESSOJUR-TIMESTAMP   PIC X(26).*/
        public StringBasis PESSOJUR_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}