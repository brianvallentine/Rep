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
    public class PESFIS_DCLPESSOA_FISICA : VarBasis
    {
        /*"    10 COD-PESSOA           PIC S9(9) USAGE COMP.*/
        public IntBasis COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CPF                  PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis CPF { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 DATA-NASCIMENTO      PIC X(10).*/
        public StringBasis DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SEXO                 PIC X(1).*/
        public StringBasis SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COD-USUARIO          PIC X(8).*/
        public StringBasis COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 ESTADO-CIVIL         PIC X(1).*/
        public StringBasis ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 TIMESTAMP            PIC X(26).*/
        public StringBasis TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 NUM-IDENTIDADE       PIC X(15).*/
        public StringBasis NUM_IDENTIDADE { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 ORGAO-EXPEDIDOR      PIC X(5).*/
        public StringBasis ORGAO_EXPEDIDOR { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
        /*"    10 UF-EXPEDIDORA        PIC X(2).*/
        public StringBasis UF_EXPEDIDORA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 DATA-EXPEDICAO       PIC X(10).*/
        public StringBasis DATA_EXPEDICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 COD-CBO              PIC S9(9) USAGE COMP.*/
        public IntBasis COD_CBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 TIPO-IDENT-SIVPF     PIC X(5).*/
        public StringBasis TIPO_IDENT_SIVPF { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
        /*"*/
    }
}