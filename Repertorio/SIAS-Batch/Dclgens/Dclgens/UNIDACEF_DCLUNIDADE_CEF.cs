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
    public class UNIDACEF_DCLUNIDADE_CEF : VarBasis
    {
        /*"    10 UNIDACEF-COD-UNIDADE  PIC S9(4) USAGE COMP.*/
        public IntBasis UNIDACEF_COD_UNIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 UNIDACEF-DV-UNIDADE  PIC S9(4) USAGE COMP.*/
        public IntBasis UNIDACEF_DV_UNIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 UNIDACEF-COD-SUREG   PIC S9(4) USAGE COMP.*/
        public IntBasis UNIDACEF_COD_SUREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 UNIDACEF-NOME-UNIDADE  PIC X(40).*/
        public StringBasis UNIDACEF_NOME_UNIDADE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 UNIDACEF-ENDERECO    PIC X(40).*/
        public StringBasis UNIDACEF_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 UNIDACEF-BAIRRO      PIC X(20).*/
        public StringBasis UNIDACEF_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 UNIDACEF-CIDADE      PIC X(20).*/
        public StringBasis UNIDACEF_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 UNIDACEF-UF          PIC X(2).*/
        public StringBasis UNIDACEF_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 UNIDACEF-CEP         PIC S9(9) USAGE COMP.*/
        public IntBasis UNIDACEF_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 UNIDACEF-SITUACAO    PIC X(1).*/
        public StringBasis UNIDACEF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 UNIDACEF-NUM-DDD     PIC S9(4) USAGE COMP.*/
        public IntBasis UNIDACEF_NUM_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 UNIDACEF-NUM-TELEFONE  PIC X(16).*/
        public StringBasis UNIDACEF_NUM_TELEFONE { get; set; } = new StringBasis(new PIC("X", "16", "X(16)."), @"");
        /*"*/
    }
}