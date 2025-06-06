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
    public class PESENDER_DCLPESSOA_ENDERECO : VarBasis
    {
        /*"    10 COD-PESSOA           PIC S9(9) USAGE COMP.*/
        public IntBasis COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 OCORR-ENDERECO       PIC S9(4) USAGE COMP.*/
        public IntBasis OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDERECO             PIC X(40).*/
        public StringBasis ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 TIPO-ENDER           PIC S9(4) USAGE COMP.*/
        public IntBasis TIPO_ENDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COMPL-ENDER          PIC X(15).*/
        public StringBasis COMPL_ENDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 BAIRRO               PIC X(20).*/
        public StringBasis BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 CEP                  PIC S9(9) USAGE COMP.*/
        public IntBasis CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CIDADE               PIC X(20).*/
        public StringBasis CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 SIGLA-UF             PIC X(2).*/
        public StringBasis SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SITUACAO-ENDERECO    PIC X(1).*/
        public StringBasis SITUACAO_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COD-USUARIO          PIC X(8).*/
        public StringBasis COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 TIMESTAMP            PIC X(26).*/
        public StringBasis TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}