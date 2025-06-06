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
    public class BANCOS_DCLBANCOS : VarBasis
    {
        /*"    10 BANCOS-COD-BANCO     PIC S9(4) USAGE COMP.*/
        public IntBasis BANCOS_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BANCOS-NOME-BANCO    PIC X(40).*/
        public StringBasis BANCOS_NOME_BANCO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 BANCOS-NOME-ABREVIADO  PIC X(25).*/
        public StringBasis BANCOS_NOME_ABREVIADO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"    10 BANCOS-CGCCPF        PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis BANCOS_CGCCPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 BANCOS-NUM-TITULO    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis BANCOS_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 BANCOS-CONVENIO-COBRANCA  PIC X(1).*/
        public StringBasis BANCOS_CONVENIO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 BANCOS-SIT-REGISTRO  PIC X(1).*/
        public StringBasis BANCOS_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 BANCOS-COD-EMPRESA   PIC S9(9) USAGE COMP.*/
        public IntBasis BANCOS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 BANCOS-TIMESTAMP     PIC X(26).*/
        public StringBasis BANCOS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}