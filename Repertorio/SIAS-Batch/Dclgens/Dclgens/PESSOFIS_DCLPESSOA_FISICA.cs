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
    public class PESSOFIS_DCLPESSOA_FISICA : VarBasis
    {
        /*"    10 PESSOFIS-COD-PESSOA  PIC S9(9) USAGE COMP.*/
        public IntBasis PESSOFIS_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PESSOFIS-CPF         PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis PESSOFIS_CPF { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 PESSOFIS-DATA-NASCIMENTO       PIC X(10).*/
        public StringBasis PESSOFIS_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PESSOFIS-SEXO        PIC X(1).*/
        public StringBasis PESSOFIS_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PESSOFIS-COD-USUARIO       PIC X(8).*/
        public StringBasis PESSOFIS_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PESSOFIS-ESTADO-CIVIL       PIC X(1).*/
        public StringBasis PESSOFIS_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PESSOFIS-TIMESTAMP   PIC X(26).*/
        public StringBasis PESSOFIS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 PESSOFIS-NUM-IDENTIDADE       PIC X(15).*/
        public StringBasis PESSOFIS_NUM_IDENTIDADE { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 PESSOFIS-ORGAO-EXPEDIDOR       PIC X(5).*/
        public StringBasis PESSOFIS_ORGAO_EXPEDIDOR { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
        /*"    10 PESSOFIS-UF-EXPEDIDORA       PIC X(2).*/
        public StringBasis PESSOFIS_UF_EXPEDIDORA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 PESSOFIS-DATA-EXPEDICAO       PIC X(10).*/
        public StringBasis PESSOFIS_DATA_EXPEDICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PESSOFIS-COD-CBO     PIC S9(9) USAGE COMP.*/
        public IntBasis PESSOFIS_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PESSOFIS-TIPO-IDENT-SIVPF       PIC X(5).*/
        public StringBasis PESSOFIS_TIPO_IDENT_SIVPF { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
        /*"*/
    }
}