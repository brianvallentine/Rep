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
    public class ESTIPULA_DCLESTIPULANTE : VarBasis
    {
        /*"    10 ESTIPULA-COD-CCT     PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis ESTIPULA_COD_CCT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 ESTIPULA-COD-FROTA   PIC X(15).*/
        public StringBasis ESTIPULA_COD_FROTA { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 ESTIPULA-NOME-ESTIPULANTE  PIC X(40).*/
        public StringBasis ESTIPULA_NOME_ESTIPULANTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 ESTIPULA-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis ESTIPULA_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 ESTIPULA-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis ESTIPULA_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 ESTIPULA-SITUACAO    PIC X(1).*/
        public StringBasis ESTIPULA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ESTIPULA-COD-USUARIO  PIC X(8).*/
        public StringBasis ESTIPULA_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 ESTIPULA-TIMESTAMP   PIC X(26).*/
        public StringBasis ESTIPULA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 ESTIPULA-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis ESTIPULA_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}