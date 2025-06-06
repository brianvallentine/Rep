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
    public class AGENCCEF_DCLAGENCIAS_CEF : VarBasis
    {
        /*"    10 AGENCCEF-COD-AGENCIA  PIC S9(4) USAGE COMP.*/
        public IntBasis AGENCCEF_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AGENCCEF-NOME-AGENCIA  PIC X(40).*/
        public StringBasis AGENCCEF_NOME_AGENCIA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 AGENCCEF-COD-SUREG   PIC S9(4) USAGE COMP.*/
        public IntBasis AGENCCEF_COD_SUREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AGENCCEF-SITUACAO    PIC X(1).*/
        public StringBasis AGENCCEF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AGENCCEF-COD-GRUPO-AGENCIA  PIC S9(4) USAGE COMP.*/
        public IntBasis AGENCCEF_COD_GRUPO_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AGENCCEF-COD-ESCNEG  PIC S9(4) USAGE COMP.*/
        public IntBasis AGENCCEF_COD_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AGENCCEF-TIPO-PV     PIC X(10).*/
        public StringBasis AGENCCEF_TIPO_PV { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 AGENCCEF-CLASSE      PIC X(3).*/
        public StringBasis AGENCCEF_CLASSE { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 AGENCCEF-DATA-SIGAT  PIC X(10).*/
        public StringBasis AGENCCEF_DATA_SIGAT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 AGENCCEF-AGE-CENTRAL-PROD01  PIC S9(4) USAGE COMP.*/
        public IntBasis AGENCCEF_AGE_CENTRAL_PROD01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AGENCCEF-CGC         PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis AGENCCEF_CGC { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 AGENCCEF-MATR-ASSIST-COMERC  PIC S9(9) USAGE COMP.*/
        public IntBasis AGENCCEF_MATR_ASSIST_COMERC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}