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
    public class RAMOS_DCLRAMOS : VarBasis
    {
        /*"    10 RAMOS-RAMO-EMISSOR   PIC S9(4) USAGE COMP.*/
        public IntBasis RAMOS_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RAMOS-COD-MODALIDADE  PIC S9(4) USAGE COMP.*/
        public IntBasis RAMOS_COD_MODALIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RAMOS-NOME-RAMO      PIC X(40).*/
        public StringBasis RAMOS_NOME_RAMO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 RAMOS-HORA-INIVIGENCIA  PIC X(8).*/
        public StringBasis RAMOS_HORA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 RAMOS-PCT-COM-SEGURO  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis RAMOS_PCT_COM_SEGURO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 RAMOS-PCT-COM-COSSEGURO  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis RAMOS_PCT_COM_COSSEGURO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 RAMOS-PCT-COM-RESSEGURO  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis RAMOS_PCT_COM_RESSEGURO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 RAMOS-SIT-REGISTRO   PIC X(1).*/
        public StringBasis RAMOS_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 RAMOS-DIA-REMESSA-DOC  PIC S9(4) USAGE COMP.*/
        public IntBasis RAMOS_DIA_REMESSA_DOC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RAMOS-COD-EMPRESA    PIC S9(9) USAGE COMP.*/
        public IntBasis RAMOS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 RAMOS-TIMESTAMP      PIC X(26).*/
        public StringBasis RAMOS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 RAMOS-SIGLA-RAMO     PIC X(3).*/
        public StringBasis RAMOS_SIGLA_RAMO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
    }
}