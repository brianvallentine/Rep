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
    public class TOMADOR_DCLTOMADOR : VarBasis
    {
        /*"    10 TOMADOR-COD-FONTE    PIC S9(4) USAGE COMP.*/
        public IntBasis TOMADOR_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TOMADOR-NUM-PROPOSTA  PIC S9(9) USAGE COMP.*/
        public IntBasis TOMADOR_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 TOMADOR-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis TOMADOR_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 TOMADOR-OCORR-ENDERECO  PIC S9(4) USAGE COMP.*/
        public IntBasis TOMADOR_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TOMADOR-COD-USUARIO  PIC X(8).*/
        public StringBasis TOMADOR_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 TOMADOR-TIMESTAMP    PIC X(26).*/
        public StringBasis TOMADOR_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 TOMADOR-EMPREENDIMENTO  PIC X(40).*/
        public StringBasis TOMADOR_EMPREENDIMENTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 TOMADOR-CONTRA-GARANTIA  PIC X(40).*/
        public StringBasis TOMADOR_CONTRA_GARANTIA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 TOMADOR-ENDERECO-EMPREEND  PIC X(40).*/
        public StringBasis TOMADOR_ENDERECO_EMPREEND { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 TOMADOR-BAIRRO-EMPREEND  PIC X(20).*/
        public StringBasis TOMADOR_BAIRRO_EMPREEND { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 TOMADOR-CIDADE-EMPREEND  PIC X(20).*/
        public StringBasis TOMADOR_CIDADE_EMPREEND { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 TOMADOR-SIGLA-UF-EMPREEND  PIC X(2).*/
        public StringBasis TOMADOR_SIGLA_UF_EMPREEND { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 TOMADOR-CEP-EMPREEND  PIC S9(9) USAGE COMP.*/
        public IntBasis TOMADOR_CEP_EMPREEND { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}