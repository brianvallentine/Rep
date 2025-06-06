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
    public class GE530_DCLGE_PEPS_PESSOA_EXPOSTA : VarBasis
    {
        /*"    10 GE530-SEQ-PEPS       PIC S9(9) USAGE COMP.*/
        public IntBasis GE530_SEQ_PEPS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE530-DTA-INIVIG-PEPS       PIC X(10).*/
        public StringBasis GE530_DTA_INIVIG_PEPS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE530-DTA-FIMVIG-PEPS       PIC X(10).*/
        public StringBasis GE530_DTA_FIMVIG_PEPS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE530-COD-TP-PEPS    PIC S9(4) USAGE COMP.*/
        public IntBasis GE530_COD_TP_PEPS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE530-COD-PEPS-EXTERNO       PIC S9(9) USAGE COMP.*/
        public IntBasis GE530_COD_PEPS_EXTERNO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE530-COD-PEPS-RELACIONADO       PIC S9(9) USAGE COMP.*/
        public IntBasis GE530_COD_PEPS_RELACIONADO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE530-NUM-CPF-CNPJ   PIC S9(18) USAGE COMP.*/
        public IntBasis GE530_NUM_CPF_CNPJ { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE530-NOM-PEPS       PIC X(100).*/
        public StringBasis GE530_NOM_PEPS { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 GE530-COD-ORGAO-PESS-PEPS       PIC X(5).*/
        public StringBasis GE530_COD_ORGAO_PESS_PEPS { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
        /*"    10 GE530-NOM-ORGAO-PEPS       PIC X(150).*/
        public StringBasis GE530_NOM_ORGAO_PEPS { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"    10 GE530-COD-CARGO      PIC X(5).*/
        public StringBasis GE530_COD_CARGO { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
        /*"    10 GE530-NOM-CARGO      PIC X(100).*/
        public StringBasis GE530_NOM_CARGO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 GE530-COD-COAF       PIC X(5).*/
        public StringBasis GE530_COD_COAF { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
        /*"    10 GE530-IND-SEXO       PIC X(1).*/
        public StringBasis GE530_IND_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE530-NOM-LOGRADOURO       PIC X(50).*/
        public StringBasis GE530_NOM_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
        /*"    10 GE530-DES-LOGRADOURO       PIC X(5).*/
        public StringBasis GE530_DES_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
        /*"    10 GE530-DES-COMPLEMENTO       PIC X(40).*/
        public StringBasis GE530_DES_COMPLEMENTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE530-NOM-BAIRRO     PIC X(40).*/
        public StringBasis GE530_NOM_BAIRRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE530-COD-CEP        PIC X(8).*/
        public StringBasis GE530_COD_CEP { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE530-NOM-MUNICIPIO  PIC X(10).*/
        public StringBasis GE530_NOM_MUNICIPIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE530-COD-UF         PIC X(2).*/
        public StringBasis GE530_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE530-DTA-NOMEACAO   PIC X(10).*/
        public StringBasis GE530_DTA_NOMEACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE530-DTA-EXONERACAO       PIC X(10).*/
        public StringBasis GE530_DTA_EXONERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE530-NOM-MUNICIPIO-ORGAO       PIC X(40).*/
        public StringBasis GE530_NOM_MUNICIPIO_ORGAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE530-COD-UF-ORGAO   PIC X(2).*/
        public StringBasis GE530_COD_UF_ORGAO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE530-COD-USUARIO    PIC X(8).*/
        public StringBasis GE530_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE530-NOM-PROGRAMA   PIC X(30).*/
        public StringBasis GE530_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 GE530-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE530_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}