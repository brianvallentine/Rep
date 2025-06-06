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
    public class VG131_DCLVG_PESSOA_PEPS : VarBasis
    {
        /*"    10 VG131-NUM-PESSOA     PIC S9(18) USAGE COMP.*/
        public IntBasis VG131_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 VG131-DTA-INI-VIGENCIA       PIC X(10).*/
        public StringBasis VG131_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG131-DTA-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis VG131_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG131-IND-TP-PESSOA  PIC X(1).*/
        public StringBasis VG131_IND_TP_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG131-NUM-CPF-CNPJ   PIC S9(18) USAGE COMP.*/
        public IntBasis VG131_NUM_CPF_CNPJ { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 VG131-NOM-PESSOA.*/
        public VG131_VG131_NOM_PESSOA VG131_NOM_PESSOA { get; set; } = new VG131_VG131_NOM_PESSOA();

        public StringBasis VG131_IND_TP_RELACIONA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG131-COD-CARGO      PIC S9(9) USAGE COMP.*/
        public IntBasis VG131_COD_CARGO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG131-NOM-CARGO.*/
        public VG131_VG131_NOM_CARGO VG131_NOM_CARGO { get; set; } = new VG131_VG131_NOM_CARGO();

        public IntBasis VG131_COD_ORGAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG131-NOM-ORGAO.*/
        public VG131_VG131_NOM_ORGAO VG131_NOM_ORGAO { get; set; } = new VG131_VG131_NOM_ORGAO();

        public VG131_VG131_NOM_MUNICIPIO_ORGAO VG131_NOM_MUNICIPIO_ORGAO { get; set; } = new VG131_VG131_NOM_MUNICIPIO_ORGAO();

        public StringBasis VG131_COD_UF_ORGAO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 VG131-COD-COAF       PIC S9(9) USAGE COMP.*/
        public IntBasis VG131_COD_COAF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG131-DTA-NOMEACAO   PIC X(10).*/
        public StringBasis VG131_DTA_NOMEACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG131-DTA-EXONERACAO       PIC X(10).*/
        public StringBasis VG131_DTA_EXONERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG131-IND-SEXO       PIC X(1).*/
        public StringBasis VG131_IND_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG131-NOM-LOGRADOURO.*/
        public VG131_VG131_NOM_LOGRADOURO VG131_NOM_LOGRADOURO { get; set; } = new VG131_VG131_NOM_LOGRADOURO();

        public StringBasis VG131_NUM_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG131-DES-COMPL-LOGR.*/
        public VG131_VG131_DES_COMPL_LOGR VG131_DES_COMPL_LOGR { get; set; } = new VG131_VG131_DES_COMPL_LOGR();

        public VG131_VG131_NOM_BAIRRO VG131_NOM_BAIRRO { get; set; } = new VG131_VG131_NOM_BAIRRO();

        public VG131_VG131_NOM_MUNICIPIO VG131_NOM_MUNICIPIO { get; set; } = new VG131_VG131_NOM_MUNICIPIO();

        public StringBasis VG131_COD_CEP { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG131-COD-UF         PIC X(2).*/
        public StringBasis VG131_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 VG131-NUM-PESSOA-RELAC       PIC S9(18) USAGE COMP.*/
        public IntBasis VG131_NUM_PESSOA_RELAC { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 VG131-NOM-PESSOA-RELAC.*/
        public VG131_VG131_NOM_PESSOA_RELAC VG131_NOM_PESSOA_RELAC { get; set; } = new VG131_VG131_NOM_PESSOA_RELAC();

        public StringBasis VG131_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG131-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis VG131_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG131-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis VG131_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}