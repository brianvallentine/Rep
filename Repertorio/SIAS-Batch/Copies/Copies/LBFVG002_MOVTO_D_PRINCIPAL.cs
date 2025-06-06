using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBFVG002_MOVTO_D_PRINCIPAL : VarBasis
    {
        /*"      15    MOVTO-D-NOME         PIC  X(040)*/
        public StringBasis MOVTO_D_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"      15    MOVTO-D-DTH-NASC*/
        public LBFVG002_MOVTO_D_DTH_NASC MOVTO_D_DTH_NASC { get; set; } = new LBFVG002_MOVTO_D_DTH_NASC();

        public StringBasis MOVTO_D_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"      15    MOVTO-D-EST-CIVIL    PIC  X(001)*/
        public StringBasis MOVTO_D_EST_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"      15    MOVTO-D-CGC-CPF      PIC  9(014)*/
        public IntBasis MOVTO_D_CGC_CPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"      15    MOVTO-D-ENDERECO     PIC  X(040)*/
        public StringBasis MOVTO_D_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"      15    MOVTO-D-COMPLEMENTO  PIC  X(020)*/
        public StringBasis MOVTO_D_COMPLEMENTO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
        /*"      15    MOVTO-D-BAIRRO       PIC  X(020)*/
        public StringBasis MOVTO_D_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
        /*"      15    MOVTO-D-CIDADE       PIC  X(020)*/
        public StringBasis MOVTO_D_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
        /*"      15    MOVTO-D-UF           PIC  X(002)*/
        public StringBasis MOVTO_D_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"      15    MOVTO-D-CEP          PIC  9(008)*/
        public IntBasis MOVTO_D_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"      15    MOVTO-D-DDD          PIC  9(004)*/
        public IntBasis MOVTO_D_DDD { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"      15    MOVTO-D-TELEFONE     PIC  9(009)*/
        public IntBasis MOVTO_D_TELEFONE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"      15    MOVTO-D-DTH-ADESAO*/
        public LBFVG002_MOVTO_D_DTH_ADESAO MOVTO_D_DTH_ADESAO { get; set; } = new LBFVG002_MOVTO_D_DTH_ADESAO();

        public LBFVG002_MOVTO_D_DTH_1ASSEMBLEIA MOVTO_D_DTH_1ASSEMBLEIA { get; set; } = new LBFVG002_MOVTO_D_DTH_1ASSEMBLEIA();

        public LBFVG002_MOVTO_D_DTH_PASSEMBLEIA MOVTO_D_DTH_PASSEMBLEIA { get; set; } = new LBFVG002_MOVTO_D_DTH_PASSEMBLEIA();

        public LBFVG002_MOVTO_D_DTH_VENCTO MOVTO_D_DTH_VENCTO { get; set; } = new LBFVG002_MOVTO_D_DTH_VENCTO();

        public DoubleBasis MOVTO_D_VAL_CARTA { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99"), 2);
        /*"      15    MOVTO-D-VAL-SALDO-D  PIC  9(010)V99*/
        public DoubleBasis MOVTO_D_VAL_SALDO_D { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99"), 2);
        /*"      15    MOVTO-D-VAL-PREMIO   PIC  9(010)V99*/
        public DoubleBasis MOVTO_D_VAL_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99"), 2);
        /*"      15    MOVTO-D-NUM-PARCELA  PIC  9(003)*/
        public IntBasis MOVTO_D_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"      15    MOVTO-D-PLANO-COTA   PIC  9(003)*/
        public IntBasis MOVTO_D_PLANO_COTA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"      15    MOVTO-D-NUM-GRUPO    PIC  9(006)*/
        public IntBasis MOVTO_D_NUM_GRUPO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"      15    MOVTO-D-NUM-COTA     PIC  9(003)*/
        public IntBasis MOVTO_D_NUM_COTA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"      15    MOVTO-D-NUM-VERSAO   PIC  9(002)*/
        public IntBasis MOVTO_D_NUM_VERSAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"      15    MOVTO-D-COD-AGENCIA  PIC  9(004)*/
        public IntBasis MOVTO_D_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"      15    MOVTO-D-NUM-CONTRATO PIC  9(008)*/
        public IntBasis MOVTO_D_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"      15    MOVTO-D-DPS          PIC  X(006)*/
        public StringBasis MOVTO_D_DPS { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
        /*"      15    MOVTO-D-IND-SEGUIM   PIC  9(001)*/
        public IntBasis MOVTO_D_IND_SEGUIM { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"      15    MOVTO-D-INDICADOR    PIC  X(007)*/
        public StringBasis MOVTO_D_INDICADOR { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
        /*"      15    MOVTO-D-INF-COMPL    PIC  X(080)*/
        public StringBasis MOVTO_D_INF_COMPL { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
        /*"      15    MOVTO-D-COD-ERROS    PIC  9(004) OCCURS 20*/
        public ListBasis<IntBasis, Int64> MOVTO_D_COD_ERROS { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "4", "9(004)"), 20);
        /*"      15    MOVTO-D-SITUACAO     PIC  X(005)*/
        public StringBasis MOVTO_D_SITUACAO { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
        /*"      15    MOVTO-D-COD-ERRO     PIC  9(004)*/
        public IntBasis MOVTO_D_COD_ERRO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"*/
    }
}