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
    public class LXFCT004_REG_PROPOSTA_SASSE : VarBasis
    {
        /*"     10    R3-TIPO-REG                 PIC  X(001)*/
        public StringBasis R3_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10    R3-NUM-PROPOSTA             PIC  9(014)*/
        public IntBasis R3_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"     10    R3-COD-PRODUTO              PIC  9(004)*/
        public IntBasis R3_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"     10    R3-AGECOBR                  PIC  9(004)*/
        public IntBasis R3_AGECOBR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"     10    R3-DATA-PROPOSTA            PIC  9(008)*/
        public IntBasis R3_DATA_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10    R3-OPCAOPAG                 PIC  9(001)*/
        public IntBasis R3_OPCAOPAG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"     10    R3-CONTA-DEBITO*/
        public LXFCT004_R3_CONTA_DEBITO R3_CONTA_DEBITO { get; set; } = new LXFCT004_R3_CONTA_DEBITO();

        private _REDEF_LXFCT004_R3_CARTAO _r3_cartao { get; set; }
        public _REDEF_LXFCT004_R3_CARTAO R3_CARTAO
        {
            get { _r3_cartao = new _REDEF_LXFCT004_R3_CARTAO(); _.Move(R3_CONTA_DEBITO, _r3_cartao); VarBasis.RedefinePassValue(R3_CONTA_DEBITO, _r3_cartao, R3_CONTA_DEBITO); _r3_cartao.ValueChanged += () => { _.Move(_r3_cartao, R3_CONTA_DEBITO); }; return _r3_cartao; }
            set { VarBasis.RedefinePassValue(value, _r3_cartao, R3_CONTA_DEBITO); }
        }  //Redefines

        public StringBasis R3_DPS_TITULAR { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
        /*"     10    R3-DPS-CONJUGE              PIC  X(007)*/
        public StringBasis R3_DPS_CONJUGE { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
        /*"     10    R3-NRMATRVEN                PIC  9(008)*/
        public IntBasis R3_NRMATRVEN { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10    R3-VALOR-PREMIO-TOTAL       PIC  9(014)V99*/
        public DoubleBasis R3_VALOR_PREMIO_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "14", "9(014)V99"), 2);
        /*"     10    R3-APOS-INVALIDEZ           PIC  X(001)*/
        public StringBasis R3_APOS_INVALIDEZ { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10    R3-RENOVACAO-AUTOM          PIC  X(001)*/
        public StringBasis R3_RENOVACAO_AUTOM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10    R3-DIA-DEBITO               PIC  9(002)*/
        public IntBasis R3_DIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"     10    R3-PCT-DESCONTO             PIC  9(003)V99*/
        public DoubleBasis R3_PCT_DESCONTO { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99"), 2);
        /*"     10    R3-NOME-CONVENENTE          PIC  X(040)*/
        public StringBasis R3_NOME_CONVENENTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"     10    R3-CGC-CONVENENTE           PIC  9(014)*/
        public IntBasis R3_CGC_CONVENENTE { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"     10    R3-INDIC-TIPO-PROPOSTA      PIC  X(001)*/
        public StringBasis R3_INDIC_TIPO_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10    R3-INDIC-TIPO-CONTA         PIC  X(001)*/
        public StringBasis R3_INDIC_TIPO_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10    FILLER                      PIC  X(001)*/
        public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10    R3-SIT-PROPOSTA             PIC  X(003)*/
        public StringBasis R3_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"     10    R3-SIT-COBRANCA             PIC  X(003)*/
        public StringBasis R3_SIT_COBRANCA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"     10    R3-SIT-MOTIVO               PIC  9(003)*/
        public IntBasis R3_SIT_MOTIVO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"     10    R3-OPCAO-COBER              PIC  X(001)*/
        public StringBasis R3_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10    R3-OPCAO-COBER-R  REDEFINES R3-OPCAO-COBER*/
        private _REDEF_LXFCT004_R3_OPCAO_COBER_R _r3_opcao_cober_r { get; set; }
        public _REDEF_LXFCT004_R3_OPCAO_COBER_R R3_OPCAO_COBER_R
        {
            get { _r3_opcao_cober_r = new _REDEF_LXFCT004_R3_OPCAO_COBER_R(); _.Move(R3_OPCAO_COBER, _r3_opcao_cober_r); VarBasis.RedefinePassValue(R3_OPCAO_COBER, _r3_opcao_cober_r, R3_OPCAO_COBER); _r3_opcao_cober_r.ValueChanged += () => { _.Move(_r3_opcao_cober_r, R3_OPCAO_COBER); }; return _r3_opcao_cober_r; }
            set { VarBasis.RedefinePassValue(value, _r3_opcao_cober_r, R3_OPCAO_COBER); }
        }  //Redefines

        public IntBasis R3_COD_PLANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"     10    R3-DTQITBCO                 PIC  9(008)*/
        public IntBasis R3_DTQITBCO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10    R3-VAL-PAGO                 PIC  9(013)V99*/
        public DoubleBasis R3_VAL_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"     10    R3-AGEPGTO                  PIC  9(004)*/
        public IntBasis R3_AGEPGTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"     10    R3-VAL-TARIFA               PIC  9(013)V99*/
        public DoubleBasis R3_VAL_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"     10    R3-DATA-CREDITO             PIC  9(008)*/
        public IntBasis R3_DATA_CREDITO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10    R3-VAL-COMISSAO             PIC  9(013)V99*/
        public DoubleBasis R3_VAL_COMISSAO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"     10    R3-PERIPGTO                 PIC  9(002)*/
        public IntBasis R3_PERIPGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"     10    R3-OPCAO-CONJUGE            PIC  X(001)*/
        public StringBasis R3_OPCAO_CONJUGE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10    R3-TIPO-RESIDENCIA          PIC  9(001)*/
        public IntBasis R3_TIPO_RESIDENCIA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"     10    R3-VALOR-IOF                PIC  9(006)V99*/
        public DoubleBasis R3_VALOR_IOF { get; set; } = new DoubleBasis(new PIC("9", "6", "9(006)V99"), 2);
        /*"     10    R3-CUSTO-APOLICE            PIC  9(006)V99*/
        public DoubleBasis R3_CUSTO_APOLICE { get; set; } = new DoubleBasis(new PIC("9", "6", "9(006)V99"), 2);
        /*"     10    R3-SPACES                   PIC  X(005)*/
        public StringBasis R3_SPACES { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
        /*"     10    R3-NUM-SICOB                PIC  9(013)*/
        public IntBasis R3_NUM_SICOB { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"     10    R3-ORIGEM-PROPOSTA-AIC      PIC  9(004)*/
        public IntBasis R3_ORIGEM_PROPOSTA_AIC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"     10    R3-ORIGEM-PROPOSTA-SIV      REDEFINES           R3-ORIGEM-PROPOSTA-AIC*/
        private _REDEF_LXFCT004_R3_ORIGEM_PROPOSTA_SIV _r3_origem_proposta_siv { get; set; }
        public _REDEF_LXFCT004_R3_ORIGEM_PROPOSTA_SIV R3_ORIGEM_PROPOSTA_SIV
        {
            get { _r3_origem_proposta_siv = new _REDEF_LXFCT004_R3_ORIGEM_PROPOSTA_SIV(); _.Move(R3_ORIGEM_PROPOSTA_AIC, _r3_origem_proposta_siv); VarBasis.RedefinePassValue(R3_ORIGEM_PROPOSTA_AIC, _r3_origem_proposta_siv, R3_ORIGEM_PROPOSTA_AIC); _r3_origem_proposta_siv.ValueChanged += () => { _.Move(_r3_origem_proposta_siv, R3_ORIGEM_PROPOSTA_AIC); }; return _r3_origem_proposta_siv; }
            set { VarBasis.RedefinePassValue(value, _r3_origem_proposta_siv, R3_ORIGEM_PROPOSTA_AIC); }
        }  //Redefines

        public IntBasis R3_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"     10    R3-NSL                      PIC  9(006)*/
        public IntBasis R3_NSL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"     10    R3-PRAZO-VIGENCIA           PIC  9(002)*/
        public IntBasis R3_PRAZO_VIGENCIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"     10    FILLER                      PIC  X(008)*/
        public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"*/
    }
}