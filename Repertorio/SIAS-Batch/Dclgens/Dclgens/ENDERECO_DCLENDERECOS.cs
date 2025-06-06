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
    public class ENDERECO_DCLENDERECOS : VarBasis
    {
        /*"    10 ENDERECO-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis ENDERECO_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ENDERECO-COD-ENDERECO  PIC S9(4) USAGE COMP.*/
        public IntBasis ENDERECO_COD_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDERECO-OCORR-ENDERECO  PIC S9(4) USAGE COMP.*/
        public IntBasis ENDERECO_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDERECO-ENDERECO    PIC X(72).*/
        public StringBasis ENDERECO_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 ENDERECO-BAIRRO      PIC X(72).*/
        public StringBasis ENDERECO_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 ENDERECO-CIDADE      PIC X(72).*/
        public StringBasis ENDERECO_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 ENDERECO-SIGLA-UF    PIC X(2).*/
        public StringBasis ENDERECO_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 ENDERECO-CEP         PIC S9(9) USAGE COMP.*/
        public IntBasis ENDERECO_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ENDERECO-DDD         PIC S9(4) USAGE COMP.*/
        public IntBasis ENDERECO_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ENDERECO-TELEFONE    PIC S9(9) USAGE COMP.*/
        public IntBasis ENDERECO_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ENDERECO-FAX         PIC S9(9) USAGE COMP.*/
        public IntBasis ENDERECO_FAX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ENDERECO-TELEX       PIC S9(9) USAGE COMP.*/
        public IntBasis ENDERECO_TELEX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ENDERECO-SIT-REGISTRO  PIC X(1).*/
        public StringBasis ENDERECO_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ENDERECO-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis ENDERECO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ENDERECO-DES-COMPLEMENTO  PIC X(72).*/
        public StringBasis ENDERECO_DES_COMPLEMENTO { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"*/
    }
}