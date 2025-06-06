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
    public class VG132_DCLVG_PESSOA_PEPS_CRUZADO : VarBasis
    {
        /*"    10 VG132-IND-TP-PESSOA  PIC X(1).*/
        public StringBasis VG132_IND_TP_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG132-NUM-CPF-CNPJ   PIC S9(18) USAGE COMP.*/
        public IntBasis VG132_NUM_CPF_CNPJ { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 VG132-DTA-ENQUADRAMENTO       PIC X(10).*/
        public StringBasis VG132_DTA_ENQUADRAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG132-DTA-EXONERACAO       PIC X(10).*/
        public StringBasis VG132_DTA_EXONERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG132-NOM-PESSOA.*/
        public VG132_VG132_NOM_PESSOA VG132_NOM_PESSOA { get; set; } = new VG132_VG132_NOM_PESSOA();

        public StringBasis VG132_IND_PEPS_ATIVO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG132-IND-TP-PEPS    PIC X(1).*/
        public StringBasis VG132_IND_TP_PEPS { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG132-IND-GRAU-RELAC       PIC X(2).*/
        public StringBasis VG132_IND_GRAU_RELAC { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 VG132-NOM-CARGO.*/
        public VG132_VG132_NOM_CARGO VG132_NOM_CARGO { get; set; } = new VG132_VG132_NOM_CARGO();

        public VG132_VG132_NOM_ORGAO VG132_NOM_ORGAO { get; set; } = new VG132_VG132_NOM_ORGAO();

        public StringBasis VG132_IND_TP_PESSOA_RELAC { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG132-NUM-CPF-CNPJ-RELAC       PIC S9(18) USAGE COMP.*/
        public IntBasis VG132_NUM_CPF_CNPJ_RELAC { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 VG132-NOM-PESSOA-RELAC.*/
        public VG132_VG132_NOM_PESSOA_RELAC VG132_NOM_PESSOA_RELAC { get; set; } = new VG132_VG132_NOM_PESSOA_RELAC();

        public VG132_VG132_NOM_CARGO_RELAC VG132_NOM_CARGO_RELAC { get; set; } = new VG132_VG132_NOM_CARGO_RELAC();

        public VG132_VG132_NOM_ORGAO_RELAC VG132_NOM_ORGAO_RELAC { get; set; } = new VG132_VG132_NOM_ORGAO_RELAC();

        public StringBasis VG132_DTA_ATUALIZACAO_BI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG132-COD-USUARIO    PIC X(8).*/
        public StringBasis VG132_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG132-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis VG132_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG132-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis VG132_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}