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
    public class AGENCEF_DCLAGENCIAS_CEF : VarBasis
    {
        /*"    10 COD-AGENCIA          PIC S9(4) USAGE COMP.*/
        public IntBasis COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NOME-AGENCIA         PIC X(40).*/
        public StringBasis NOME_AGENCIA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 COD-SUREG            PIC S9(4) USAGE COMP.*/
        public IntBasis COD_SUREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SITUACAO             PIC X(1).*/
        public StringBasis SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COD-GRUPO-AGENCIA    PIC S9(4) USAGE COMP.*/
        public IntBasis COD_GRUPO_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COD-ESCNEG           PIC S9(4) USAGE COMP.*/
        public IntBasis COD_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TIPO-PV              PIC X(10).*/
        public StringBasis TIPO_PV { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CLASSE               PIC X(3).*/
        public StringBasis CLASSE { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 DATA-SIGAT           PIC X(10).*/
        public StringBasis DATA_SIGAT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}