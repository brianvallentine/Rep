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
    public class PESSOEND_DCLPESSOA_ENDERECO : VarBasis
    {
        /*"    10 PESSOEND-COD-PESSOA  PIC S9(9) USAGE COMP.*/
        public IntBasis PESSOEND_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PESSOEND-OCORR-ENDERECO  PIC S9(4) USAGE COMP.*/
        public IntBasis PESSOEND_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PESSOEND-ENDERECO    PIC X(40).*/
        public StringBasis PESSOEND_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 PESSOEND-TIPO-ENDER  PIC S9(4) USAGE COMP.*/
        public IntBasis PESSOEND_TIPO_ENDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PESSOEND-COMPL-ENDER  PIC X(15).*/
        public StringBasis PESSOEND_COMPL_ENDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 PESSOEND-BAIRRO      PIC X(20).*/
        public StringBasis PESSOEND_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 PESSOEND-CEP         PIC S9(9) USAGE COMP.*/
        public IntBasis PESSOEND_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PESSOEND-CIDADE      PIC X(20).*/
        public StringBasis PESSOEND_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 PESSOEND-SIGLA-UF    PIC X(2).*/
        public StringBasis PESSOEND_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 PESSOEND-SITUACAO-ENDERECO  PIC X(1).*/
        public StringBasis PESSOEND_SITUACAO_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PESSOEND-COD-USUARIO  PIC X(8).*/
        public StringBasis PESSOEND_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PESSOEND-TIMESTAMP   PIC X(26).*/
        public StringBasis PESSOEND_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}