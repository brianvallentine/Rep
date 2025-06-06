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
    public class FUNCIONA_DCLFUNCIONARIOS : VarBasis
    {
        /*"    10 FUNCIONA-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis FUNCIONA_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FUNCIONA-NUM-MATRICULA       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis FUNCIONA_NUM_MATRICULA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 FUNCIONA-NUM-CENTRO-CUSTO       PIC S9(9) USAGE COMP.*/
        public IntBasis FUNCIONA_NUM_CENTRO_CUSTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FUNCIONA-NOME-FUNCIONARIO       PIC X(40).*/
        public StringBasis FUNCIONA_NOME_FUNCIONARIO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 FUNCIONA-SIT-REGISTRO       PIC X(1).*/
        public StringBasis FUNCIONA_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FUNCIONA-TIMESTAMP   PIC X(26).*/
        public StringBasis FUNCIONA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 FUNCIONA-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis FUNCIONA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FUNCIONA-COD-BANCO   PIC S9(4) USAGE COMP.*/
        public IntBasis FUNCIONA_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FUNCIONA-COD-AGENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis FUNCIONA_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FUNCIONA-NUM-CTA-CORRENTE       PIC S9(17)V USAGE COMP-3.*/
        public DoubleBasis FUNCIONA_NUM_CTA_CORRENTE { get; set; } = new DoubleBasis(new PIC("S9", "17", "S9(17)V"), 0);
        /*"    10 FUNCIONA-NUM-CPF     PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis FUNCIONA_NUM_CPF { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"*/
    }
}