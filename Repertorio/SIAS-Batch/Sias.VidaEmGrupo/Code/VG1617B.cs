using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Dclgens;
using Copies;
using Sias.VidaEmGrupo.DB2.VG1617B;

namespace Code
{
    public class VG1617B
    {
        public bool IsCall { get; set; }

        public VG1617B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  VG - VIDA EM GRUPO - PJ            *      */
        /*"      *   PROGRAMA ...............  VG1617B                            *      */
        /*"      *   ANALISTA/PROGRAMADOR..... ELIERMES OLIVEIRA                  *      */
        /*"      *   DATA CODIFICACAO .......  OUTUBRO/2017                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .....  MANTER BENEFICIARIOS DE SEGURADOS DE APOLICES  *      */
        /*"      *                 ESPECIFICAS.                                   *      */
        /*"      *                                                                *      */
        /*"      *   OPERACOES ->  CRITICAR DADOS DE BENEFICIARIO DO SEGURADO     *      */
        /*"      *                 INCLUIR OS NOVOS BENEFICIARIOS DO SEGURADO     *      */
        /*"      *                 DA APOLICE ESPECIFICA, EXCLUINDO OS BENEFICIARIO      */
        /*"      *                 ANTERIORES, CASO EXISTAM.                             */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _MOV_BENEFC { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis MOV_BENEFC
        {
            get
            {
                _.Move(REG_BENEFICIARIO, _MOV_BENEFC); VarBasis.RedefinePassValue(REG_BENEFICIARIO, _MOV_BENEFC, REG_BENEFICIARIO); return _MOV_BENEFC;
            }
        }
        public FileBasis _RVG1617B { get; set; } = new FileBasis(new PIC("X", "199", "X(199)"));

        public FileBasis RVG1617B
        {
            get
            {
                _.Move(REG_RVG1617B, _RVG1617B); VarBasis.RedefinePassValue(REG_RVG1617B, _RVG1617B, REG_RVG1617B); return _RVG1617B;
            }
        }
        /*"01   REG-BENEFICIARIO                    PIC X(200).*/
        public StringBasis REG_BENEFICIARIO { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
        /*"01   REG-RVG1617B                       PIC X(199).*/
        public StringBasis REG_RVG1617B { get; set; } = new StringBasis(new PIC("X", "199", "X(199)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis I01 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I02 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I00 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WIDX1 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01  DCLPF-DET-ARQ-PROPOSTA.*/
        public VG1617B_DCLPF_DET_ARQ_PROPOSTA DCLPF_DET_ARQ_PROPOSTA { get; set; } = new VG1617B_DCLPF_DET_ARQ_PROPOSTA();
        public class VG1617B_DCLPF_DET_ARQ_PROPOSTA : VarBasis
        {
            /*"    10 PF088-NUM-CAMPO-PROPOSTA        PIC S9(9) USAGE COMP.*/
            public IntBasis PF088_NUM_CAMPO_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"    10 PF088-NOM-DET-ARQ-PROPOSTA      PIC X(50).*/
            public StringBasis PF088_NOM_DET_ARQ_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
            /*"    10 PF088-DES-DET-ARQ-PROPOSTA.*/
            public VG1617B_PF088_DES_DET_ARQ_PROPOSTA PF088_DES_DET_ARQ_PROPOSTA { get; set; } = new VG1617B_PF088_DES_DET_ARQ_PROPOSTA();
            public class VG1617B_PF088_DES_DET_ARQ_PROPOSTA : VarBasis
            {
                /*"       49 PF088-DET-ARQ-PROPOSTA-LEN   PIC S9(4) USAGE COMP.*/
                public IntBasis PF088_DET_ARQ_PROPOSTA_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
                /*"       49 PF088-DET-ARQ-PROPOSTA-TEXT  PIC X(200).*/
                public StringBasis PF088_DET_ARQ_PROPOSTA_TEXT { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
                /*"01  DCLPF-PROC-PROPOSTA-HIST.*/
            }
        }
        public VG1617B_DCLPF_PROC_PROPOSTA_HIST DCLPF_PROC_PROPOSTA_HIST { get; set; } = new VG1617B_DCLPF_PROC_PROPOSTA_HIST();
        public class VG1617B_DCLPF_PROC_PROPOSTA_HIST : VarBasis
        {
            /*"    10 PF090-SIGLA-ARQUIVO        PIC X(8).*/
            public StringBasis PF090_SIGLA_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
            /*"    10 PF090-SISTEMA-ORIGEM       PIC S9(4) USAGE COMP.*/
            public IntBasis PF090_SISTEMA_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    10 PF090-NSAS-SIVPF           PIC S9(9) USAGE COMP.*/
            public IntBasis PF090_NSAS_SIVPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"    10 PF090-NUM-PROPOSTA         PIC S9(15)V USAGE COMP-3.*/
            public DoubleBasis PF090_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
            /*"    10 PF090-SEQ-OCORRENCIA       PIC S9(4) USAGE COMP.*/
            public IntBasis PF090_SEQ_OCORRENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    10 PF090-SEQ-OCORR-HIST       PIC S9(4) USAGE COMP.*/
            public IntBasis PF090_SEQ_OCORR_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    10 PF090-STA-PROCESSAMENTO    PIC X(1).*/
            public StringBasis PF090_STA_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"    10 PF090-COD-USUARIO          PIC X(10).*/
            public StringBasis PF090_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 PF090-DTH-ATUALIZACAO      PIC X(26).*/
            public StringBasis PF090_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
            /*"01   REG-RE-BENEFIC.*/
        }
        public VG1617B_REG_RE_BENEFIC REG_RE_BENEFIC { get; set; } = new VG1617B_REG_RE_BENEFIC();
        public class VG1617B_REG_RE_BENEFIC : VarBasis
        {
            /*"     10  RE-NOM-SEGURADO             PIC  X(040).*/
            public StringBasis RE_NOM_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"     10  RE-NUM-CPF-SEG              PIC  9(011).*/
            public IntBasis RE_NUM_CPF_SEG { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"     10  RE-NOM-BENEFIC              PIC  X(040).*/
            public StringBasis RE_NOM_BENEFIC { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"     10  RE-GRAU-PARENTESCO          PIC  X(010).*/
            public StringBasis RE_GRAU_PARENTESCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"     10  RE-PERC-PARTICIPA           PIC  9(003).*/
            public IntBasis RE_PERC_PARTICIPA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"     10  RE-NUM-CPF-BENFC            PIC  9(011).*/
            public IntBasis RE_NUM_CPF_BENFC { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"     10  RE-NUM-APOLICE              PIC  9(013).*/
            public IntBasis RE_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"     10  RE-COD-SUBGRUPO             PIC  9(004).*/
            public IntBasis RE_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10  RE-RESTO                    PIC  X(001).*/
            public StringBasis RE_RESTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"01   REG-R1-BENEFIC.*/
        }
        public VG1617B_REG_R1_BENEFIC REG_R1_BENEFIC { get; set; } = new VG1617B_REG_R1_BENEFIC();
        public class VG1617B_REG_R1_BENEFIC : VarBasis
        {
            /*"     10  R1-NOM-SEGURADO             PIC  X(040).*/
            public StringBasis R1_NOM_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"     10  R1-NUM-CPF-SEG              PIC  9(011).*/
            public IntBasis R1_NUM_CPF_SEG { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"     10  R1-NOM-BENEFIC              PIC  X(040).*/
            public StringBasis R1_NOM_BENEFIC { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"     10  R1-GRAU-PARENTESCO          PIC  X(010).*/
            public StringBasis R1_GRAU_PARENTESCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"     10  R1-PERC-PARTICIPA           PIC  9(003).*/
            public IntBasis R1_PERC_PARTICIPA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"     10  R1-NUM-CPF-BENFC            PIC  9(011).*/
            public IntBasis R1_NUM_CPF_BENFC { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"     10  R1-NUM-APOLICE              PIC  9(013).*/
            public IntBasis R1_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"     10  R1-COD-SUBGRUPO             PIC  9(004).*/
            public IntBasis R1_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10  R1-COD-CLIENTE              PIC  9(011).*/
            public IntBasis R1_COD_CLIENTE { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"     10  R1-NUM-CERTIFICADO          PIC  9(015).*/
            public IntBasis R1_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"     10  R1-DAC-CERTIFICADO          PIC  X(001).*/
            public StringBasis R1_DAC_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R1-RESTO                    PIC  X(001).*/
            public StringBasis R1_RESTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"01  WS-PERC-PART-TOTAL               PIC  9(003).*/
        }
        public IntBasis WS_PERC_PART_TOTAL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
        /*"01  WHOST-APOLICE-PLANO              PIC S9(013) COMP-3.*/
        public IntBasis WHOST_APOLICE_PLANO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  WHOST-CODSUBES-PLANO             PIC S9(004) COMP.*/
        public IntBasis WHOST_CODSUBES_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-CODPRODU-PLANO             PIC S9(004) COMP.*/
        public IntBasis WHOST_CODPRODU_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-APOLICE                    PIC  9(013).*/
        public IntBasis WHOST_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
        /*"01  FILLER  REDEFINES WHOST-APOLICE.*/
        private _REDEF_VG1617B_FILLER_0 _filler_0 { get; set; }
        public _REDEF_VG1617B_FILLER_0 FILLER_0
        {
            get { _filler_0 = new _REDEF_VG1617B_FILLER_0(); _.Move(WHOST_APOLICE, _filler_0); VarBasis.RedefinePassValue(WHOST_APOLICE, _filler_0, WHOST_APOLICE); _filler_0.ValueChanged += () => { _.Move(_filler_0, WHOST_APOLICE); }; return _filler_0; }
            set { VarBasis.RedefinePassValue(value, _filler_0, WHOST_APOLICE); }
        }  //Redefines
        public class _REDEF_VG1617B_FILLER_0 : VarBasis
        {
            /*"    05  WHOST-NUM-VIDA               PIC  9(003).*/
            public IntBasis WHOST_NUM_VIDA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05  WHOST-NUM-RAMO               PIC  9(002).*/
            public IntBasis WHOST_NUM_RAMO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05  WHOST-NUM-SEQUENCIAL         PIC  9(008).*/
            public IntBasis WHOST_NUM_SEQUENCIAL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"01  WHOST-PRODUTO                    PIC S9(004) COMP.*/

            public _REDEF_VG1617B_FILLER_0()
            {
                WHOST_NUM_VIDA.ValueChanged += OnValueChanged;
                WHOST_NUM_RAMO.ValueChanged += OnValueChanged;
                WHOST_NUM_SEQUENCIAL.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WHOST_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-PERIPGTO                   PIC S9(004) COMP.*/
        public IntBasis WHOST_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-DATA-PROPOSTA              PIC  X(010).*/
        public StringBasis WHOST_DATA_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WS-DATA-MOV-ABERTO-1D            PIC  X(010).*/
        public StringBasis WS_DATA_MOV_ABERTO_1D { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WHOST-OPCAO-CONJUGE              PIC  X(001).*/
        public StringBasis WHOST_OPCAO_CONJUGE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WHOST-OPCAO-COBER                PIC  X(001).*/
        public StringBasis WHOST_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  W-TP-REGISTRO                    PIC  X(001).*/
        public StringBasis W_TP_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WHOST-IDADE                      PIC S9(004) COMP.*/
        public IntBasis WHOST_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-STA-ANTECIPACAO             PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_STA_ANTECIPACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NULL                        PIC S9(4) COMP VALUE -1.*/
        public IntBasis VIND_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"), -1);
        /*"01  VIND-OPER-CREDITO                PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_OPER_CREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NUM-PRAZO                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_NUM_PRAZO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-ZEROS                       PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_ZEROS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-CPF                         PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_CPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-SEXO                        PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_SEXO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-UF-EXP                      PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_UF_EXP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DT-NASCI                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DT_NASCI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTNASCI                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DTNASCI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-CBO-CONJ                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_CBO_CONJ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-CBO                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-TP-IDENT                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_TP_IDENT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTEXPEDI                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DTEXPEDI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-USUR                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_USUR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NUM-IDENT                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_NUM_IDENT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-ORGAO-EXP                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_ORGAO_EXP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-TIMESTAMP                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_TIMESTAMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-RCAPS-AGE                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_RCAPS_AGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-PESSOA                  PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTNASC-ESPOSA               PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DTNASC_ESPOSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WHOST-DTPROXVEN                  PIC  X(010).*/
        public StringBasis WHOST_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WHOST-FONTE                      PIC S9(004) COMP.*/
        public IntBasis WHOST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-PROPAUTOM                  PIC S9(009) COMP.*/
        public IntBasis WHOST_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-SIT-REGISTRO               PIC  X(001).*/
        public StringBasis WHOST_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  W-IND                            PIC S9(4) COMP VALUE +0.*/
        public IntBasis W_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-OPRCTADEB                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NUMCTADEB                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-CARTAO                      PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DIGCTADEB                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-TP-PROP                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_TP_PROP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WS-IDADE                         PIC S9(009) COMP.*/
        public IntBasis WS_IDADE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  COD-AGENCIA-CEF                  PIC S9(4) USAGE COMP.*/
        public IntBasis COD_AGENCIA_CEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WS-NOME-EMAIL                    PIC X(050) VALUE SPACES.*/
        public StringBasis WS_NOME_EMAIL { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
        /*"01  WS-FLAG-PROP-AUTOM               PIC X(001) VALUE 'N'.*/
        public StringBasis WS_FLAG_PROP_AUTOM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01  WS-FLAG-TEM-TP1                  PIC X(001) VALUE 'N'.*/
        public StringBasis WS_FLAG_TEM_TP1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01  WS-FLAG-TEM-TP2                  PIC X(001) VALUE 'N'.*/
        public StringBasis WS_FLAG_TEM_TP2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01  WS-FLAG-TEM-TP3                  PIC X(001) VALUE 'N'.*/
        public StringBasis WS_FLAG_TEM_TP3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01  WS-FLAG-TEM-TP4                  PIC X(001) VALUE 'N'.*/
        public StringBasis WS_FLAG_TEM_TP4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01  WS-FLAG-TEM-TP5                  PIC X(001) VALUE 'N'.*/
        public StringBasis WS_FLAG_TEM_TP5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01  WS-FLAG-TEM-TP6                  PIC X(001) VALUE 'N'.*/
        public StringBasis WS_FLAG_TEM_TP6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01  WS-FLAG-TEM-TP7                  PIC X(001) VALUE 'N'.*/
        public StringBasis WS_FLAG_TEM_TP7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01  WS-FLAG-TEM-SUBGRUPO             PIC X(001) VALUE 'N'.*/
        public StringBasis WS_FLAG_TEM_SUBGRUPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01  WS-DTA-INI-VIGENCIA              PIC X(010) VALUE SPACES.*/
        public StringBasis WS_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  WS-DTA-TER-VIGENCIA              PIC X(010) VALUE SPACES.*/
        public StringBasis WS_DTA_TER_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  WS-COD-PRODUTO                   PIC X(004) VALUE SPACES.*/
        public StringBasis WS_COD_PRODUTO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
        /*"01  WS-RAMO-APOLICE                  PIC S9(04) COMP VALUE +0.*/
        public IntBasis WS_RAMO_APOLICE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-CONTA-BRC                     PIC 9(005) VALUE ZEROS.*/
        public IntBasis WS_CONTA_BRC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01  WS-TRATA-NOME                    PIC X(040).*/
        public StringBasis WS_TRATA_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01  WS-TRATA-NOM REDEFINES WS-TRATA-NOME.*/
        private _REDEF_VG1617B_WS_TRATA_NOM _ws_trata_nom { get; set; }
        public _REDEF_VG1617B_WS_TRATA_NOM WS_TRATA_NOM
        {
            get { _ws_trata_nom = new _REDEF_VG1617B_WS_TRATA_NOM(); _.Move(WS_TRATA_NOME, _ws_trata_nom); VarBasis.RedefinePassValue(WS_TRATA_NOME, _ws_trata_nom, WS_TRATA_NOME); _ws_trata_nom.ValueChanged += () => { _.Move(_ws_trata_nom, WS_TRATA_NOME); }; return _ws_trata_nom; }
            set { VarBasis.RedefinePassValue(value, _ws_trata_nom, WS_TRATA_NOME); }
        }  //Redefines
        public class _REDEF_VG1617B_WS_TRATA_NOM : VarBasis
        {
            /*"    10 WS-NOM-1A-POSICAO             PIC X(001).*/
            public StringBasis WS_NOM_1A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10 WS-NOM-2A-POSICAO             PIC X(001).*/
            public StringBasis WS_NOM_2A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10 WS-NOM-3A-POSICAO             PIC X(001).*/
            public StringBasis WS_NOM_3A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10 WS-NOM-4A-POSICAO             PIC X(001).*/
            public StringBasis WS_NOM_4A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10 WS-NOM-5A-POSICAO             PIC X(001).*/
            public StringBasis WS_NOM_5A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10 WS-NOM-6A-POSICAO             PIC X(001).*/
            public StringBasis WS_NOM_6A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10 WS-NOM-7A-POSICAO             PIC X(001).*/
            public StringBasis WS_NOM_7A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10 WS-NOM-8A-POSICAO             PIC X(001).*/
            public StringBasis WS_NOM_8A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10 WS-NOM-9A-POSICAO             PIC X(001).*/
            public StringBasis WS_NOM_9A_POSICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10 FILLER                        PIC X(031).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)."), @"");
            /*"01  WS-CALL                          PIC  X(08) VALUE SPACES.*/

            public _REDEF_VG1617B_WS_TRATA_NOM()
            {
                WS_NOM_1A_POSICAO.ValueChanged += OnValueChanged;
                WS_NOM_2A_POSICAO.ValueChanged += OnValueChanged;
                WS_NOM_3A_POSICAO.ValueChanged += OnValueChanged;
                WS_NOM_4A_POSICAO.ValueChanged += OnValueChanged;
                WS_NOM_5A_POSICAO.ValueChanged += OnValueChanged;
                WS_NOM_6A_POSICAO.ValueChanged += OnValueChanged;
                WS_NOM_7A_POSICAO.ValueChanged += OnValueChanged;
                WS_NOM_8A_POSICAO.ValueChanged += OnValueChanged;
                WS_NOM_9A_POSICAO.ValueChanged += OnValueChanged;
                FILLER_1.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_CALL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
        /*"01 LPARM-CNPJ.*/
        public VG1617B_LPARM_CNPJ LPARM_CNPJ { get; set; } = new VG1617B_LPARM_CNPJ();
        public class VG1617B_LPARM_CNPJ : VarBasis
        {
            /*"   03 LPARM-FILLER                   PIC  X(002) VALUE SPACE.*/
            public StringBasis LPARM_FILLER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"   03 LPARM-ENT-CNPJ                 PIC  9(014) VALUE ZEROS.*/
            public IntBasis LPARM_ENT_CNPJ { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"   03 LPARM-SAI-CNPJ                 PIC  9(001) VALUE ZEROS.*/
            public IntBasis LPARM_SAI_CNPJ { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"01 LPARM-CPF.*/
        }
        public VG1617B_LPARM_CPF LPARM_CPF { get; set; } = new VG1617B_LPARM_CPF();
        public class VG1617B_LPARM_CPF : VarBasis
        {
            /*"   03 LPARM-FILLER-CPF               PIC  X(002) VALUE SPACE.*/
            public StringBasis LPARM_FILLER_CPF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"   03 LPARM-ENT-CPF                  PIC  9(011) VALUE ZEROS.*/
            public IntBasis LPARM_ENT_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"   03 LPARM-SAI-CPF                  PIC  9(001) VALUE ZEROS.*/
            public IntBasis LPARM_SAI_CPF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"01  WS-NUM-AGEN-OPER-CC              PIC  9(12) VALUE ZEROS.*/
        }
        public IntBasis WS_NUM_AGEN_OPER_CC { get; set; } = new IntBasis(new PIC("9", "12", "9(12)"));
        /*"01  FILLER      REDEFINES    WS-NUM-AGEN-OPER-CC.*/
        private _REDEF_VG1617B_FILLER_2 _filler_2 { get; set; }
        public _REDEF_VG1617B_FILLER_2 FILLER_2
        {
            get { _filler_2 = new _REDEF_VG1617B_FILLER_2(); _.Move(WS_NUM_AGEN_OPER_CC, _filler_2); VarBasis.RedefinePassValue(WS_NUM_AGEN_OPER_CC, _filler_2, WS_NUM_AGEN_OPER_CC); _filler_2.ValueChanged += () => { _.Move(_filler_2, WS_NUM_AGEN_OPER_CC); }; return _filler_2; }
            set { VarBasis.RedefinePassValue(value, _filler_2, WS_NUM_AGEN_OPER_CC); }
        }  //Redefines
        public class _REDEF_VG1617B_FILLER_2 : VarBasis
        {
            /*"    10 WS-AGENCIA                    PIC  9(004).*/
            public IntBasis WS_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10 WS-OPERACAO                   PIC  9(003).*/
            public IntBasis WS_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    10 WS-NUMCONTA                   PIC  9(008).*/
            public IntBasis WS_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"01  WS-PCT-PARTIC-12               PIC S9(004)V99 COMP.*/

            public _REDEF_VG1617B_FILLER_2()
            {
                WS_AGENCIA.ValueChanged += OnValueChanged;
                WS_OPERACAO.ValueChanged += OnValueChanged;
                WS_NUMCONTA.ValueChanged += OnValueChanged;
            }

        }
        public DoubleBasis WS_PCT_PARTIC_12 { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V99"), 2);
        /*"01  WS-PCT-PARTIC-3                PIC S9(004)V99 COMP.*/
        public DoubleBasis WS_PCT_PARTIC_3 { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V99"), 2);
        /*"01  WPARM15-AUX                    PIC S9(009) VALUE ZEROS COMP.*/
        public IntBasis WPARM15_AUX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WQUOCIENTE                     PIC S9(004) VALUE ZEROS COMP.*/
        public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WRESTO                         PIC S9(004) VALUE ZEROS COMP.*/
        public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-DIGCONTA                    PIC  9(001) VALUE ZEROS.*/
        public IntBasis WS_DIGCONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"01  WS-POSICAO                     PIC  9(005) VALUE ZEROS.*/
        public IntBasis WS_POSICAO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01  WS-POS                         PIC  9(005) VALUE ZEROS.*/
        public IntBasis WS_POS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01  WS-SIGLA-UF                    PIC  X(002) VALUE SPACES.*/
        public StringBasis WS_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"01  WS-ENCONTROU-LETRA             PIC  X(001) VALUE 'N'.*/

        public SelectorBasis WS_ENCONTROU_LETRA { get; set; } = new SelectorBasis("001", "N")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 WS-SIM-ACHOU                VALUE 'S'. */
							new SelectorItemBasis("WS_SIM_ACHOU", "S"),
							/*" 88 WS-NAO-ACHOU                VALUE 'N'. */
							new SelectorItemBasis("WS_NAO_ACHOU", "N")
                }
        };

        /*"01  WS-GRAU-PARENTESCO             PIC  X(010).*/

        public SelectorBasis WS_GRAU_PARENTESCO { get; set; } = new SelectorBasis("010")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 WS-GRAU-VALIDO              VALUE 'FILHO' 'FILHA' 'ESPOSA'       'ESPOSO' 'GENITOR' 'GENITORA' 'COMPANHEIR' 'PAI' 'M�E'       'C�NJUGE' 'CONJUGE' 'MAE' 'VOVO' 'VOV�' 'VOV�' 'IRMA'       'IRM�' 'IRM�O' 'IRMAO' 'TUTOR' 'TUTORA' 'TIO' 'TIA'       'PRIMO' 'PRIMA' 'SOBRINHO' 'SOBRINHA' 'SOGRO' 'SOGRA'       'OUTRO' 'OUTROS' 'NETO' 'NETA' 'MADRASTA' 'PADRASTO'       'HERDEIRO' 'HERDEIRA' 'GENRO' 'NORA' 'CUNHADO' 'CUNHADA'       'CURADOR' 'CURADORA' 'COMADRE' 'COMPRADRE' 'AV�' 'AV�'. */
							new SelectorItemBasis("WS_GRAU_VALIDO", "FILHO")
                }
        };

        /*"01  W-TAB-ERRO.*/
        public VG1617B_W_TAB_ERRO W_TAB_ERRO { get; set; } = new VG1617B_W_TAB_ERRO();
        public class VG1617B_W_TAB_ERRO : VarBasis
        {
            /*"   10 W-TAB-ERRO-REG   OCCURS 999  TIMES INDEXED BY I01.*/
            public ListBasis<VG1617B_W_TAB_ERRO_REG> W_TAB_ERRO_REG { get; set; } = new ListBasis<VG1617B_W_TAB_ERRO_REG>(999);
            public class VG1617B_W_TAB_ERRO_REG : VarBasis
            {
                /*"      15 W-TB-DESC-ERRO         PIC  X(050).*/
                public StringBasis W_TB_DESC_ERRO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"01  W-TAB-CAMPO.*/
            }
        }
        public VG1617B_W_TAB_CAMPO W_TAB_CAMPO { get; set; } = new VG1617B_W_TAB_CAMPO();
        public class VG1617B_W_TAB_CAMPO : VarBasis
        {
            /*"   10 W-TAB-CAMPO-REG   OCCURS 999  TIMES INDEXED BY I02.*/
            public ListBasis<VG1617B_W_TAB_CAMPO_REG> W_TAB_CAMPO_REG { get; set; } = new ListBasis<VG1617B_W_TAB_CAMPO_REG>(999);
            public class VG1617B_W_TAB_CAMPO_REG : VarBasis
            {
                /*"      15 W-TB-NOM-CAMPO         PIC  X(050).*/
                public StringBasis W_TB_NOM_CAMPO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"01  LPARM15X.*/
            }
        }
        public VG1617B_LPARM15X LPARM15X { get; set; } = new VG1617B_LPARM15X();
        public class VG1617B_LPARM15X : VarBasis
        {
            /*"    10      LPARM15             PIC  9(015).*/
            public IntBasis LPARM15 { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    10      FILLER              REDEFINES   LPARM15.*/
            private _REDEF_VG1617B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_VG1617B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_VG1617B_FILLER_3(); _.Move(LPARM15, _filler_3); VarBasis.RedefinePassValue(LPARM15, _filler_3, LPARM15); _filler_3.ValueChanged += () => { _.Move(_filler_3, LPARM15); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, LPARM15); }
            }  //Redefines
            public class _REDEF_VG1617B_FILLER_3 : VarBasis
            {
                /*"      15    LPARM15-1           PIC  9(001).*/
                public IntBasis LPARM15_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      15    LPARM15-2           PIC  9(001).*/
                public IntBasis LPARM15_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      15    LPARM15-3           PIC  9(001).*/
                public IntBasis LPARM15_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      15    LPARM15-4           PIC  9(001).*/
                public IntBasis LPARM15_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      15    LPARM15-5           PIC  9(001).*/
                public IntBasis LPARM15_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      15    LPARM15-6           PIC  9(001).*/
                public IntBasis LPARM15_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      15    LPARM15-7           PIC  9(001).*/
                public IntBasis LPARM15_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      15    LPARM15-8           PIC  9(001).*/
                public IntBasis LPARM15_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      15    LPARM15-9           PIC  9(001).*/
                public IntBasis LPARM15_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      15    LPARM15-10          PIC  9(001).*/
                public IntBasis LPARM15_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      15    LPARM15-11          PIC  9(001).*/
                public IntBasis LPARM15_11 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      15    LPARM15-12          PIC  9(001).*/
                public IntBasis LPARM15_12 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      15    LPARM15-13          PIC  9(001).*/
                public IntBasis LPARM15_13 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      15    LPARM15-14          PIC  9(001).*/
                public IntBasis LPARM15_14 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      15    LPARM15-15          PIC  9(001).*/
                public IntBasis LPARM15_15 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10      LPARM15-D1          PIC  9(001).*/

                public _REDEF_VG1617B_FILLER_3()
                {
                    LPARM15_1.ValueChanged += OnValueChanged;
                    LPARM15_2.ValueChanged += OnValueChanged;
                    LPARM15_3.ValueChanged += OnValueChanged;
                    LPARM15_4.ValueChanged += OnValueChanged;
                    LPARM15_5.ValueChanged += OnValueChanged;
                    LPARM15_6.ValueChanged += OnValueChanged;
                    LPARM15_7.ValueChanged += OnValueChanged;
                    LPARM15_8.ValueChanged += OnValueChanged;
                    LPARM15_9.ValueChanged += OnValueChanged;
                    LPARM15_10.ValueChanged += OnValueChanged;
                    LPARM15_11.ValueChanged += OnValueChanged;
                    LPARM15_12.ValueChanged += OnValueChanged;
                    LPARM15_13.ValueChanged += OnValueChanged;
                    LPARM15_14.ValueChanged += OnValueChanged;
                    LPARM15_15.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis LPARM15_D1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01  WS-TP-REG-BENEFC                 PIC 9(01) VALUE ZEROS.*/
        }
        public IntBasis WS_TP_REG_BENEFC { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
        /*"01  WS-NUM-PROPOSTA                  PIC 9(16) VALUE ZEROS.*/
        public IntBasis WS_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "16", "9(16)"));
        /*"01  WS-NUM-APOLICE                   PIC 9(15) VALUE ZEROS.*/
        public IntBasis WS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
        /*"01  WS-COD-SUBGRUPO                  PIC 9(04) VALUE ZEROS.*/
        public IntBasis WS_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"01  WS-NUM-CPF-SEG                   PIC 9(11) VALUE ZEROS.*/
        public IntBasis WS_NUM_CPF_SEG { get; set; } = new IntBasis(new PIC("9", "11", "9(11)"));
        /*"01  WS-NUM-CERTIF                    PIC 9(15) VALUE ZEROS.*/
        public IntBasis WS_NUM_CERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
        /*"01  WS-NUM-SEQ-ARQ                   PIC 9(04) VALUE ZEROS.*/
        public IntBasis WS_NUM_SEQ_ARQ { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"01  WS-COD-ERRO                      PIC 9(04) VALUE ZEROS.*/
        public IntBasis WS_COD_ERRO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"01  WS-COD-CAMPO                     PIC 9(04) VALUE ZEROS.*/
        public IntBasis WS_COD_CAMPO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"01  WS-DES-CONTEUDO                  PIC X(100) VALUE SPACES.*/
        public StringBasis WS_DES_CONTEUDO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
        /*"01  FILLER   REDEFINES    WS-DES-CONTEUDO.*/
        private _REDEF_VG1617B_FILLER_4 _filler_4 { get; set; }
        public _REDEF_VG1617B_FILLER_4 FILLER_4
        {
            get { _filler_4 = new _REDEF_VG1617B_FILLER_4(); _.Move(WS_DES_CONTEUDO, _filler_4); VarBasis.RedefinePassValue(WS_DES_CONTEUDO, _filler_4, WS_DES_CONTEUDO); _filler_4.ValueChanged += () => { _.Move(_filler_4, WS_DES_CONTEUDO); }; return _filler_4; }
            set { VarBasis.RedefinePassValue(value, _filler_4, WS_DES_CONTEUDO); }
        }  //Redefines
        public class _REDEF_VG1617B_FILLER_4 : VarBasis
        {
            /*"   05 WS-DES-CONTEU-N                PIC 9(18).*/
            public IntBasis WS_DES_CONTEU_N { get; set; } = new IntBasis(new PIC("9", "18", "9(18)."));
            /*"   05 FILLER                         PIC X(82).*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "82", "X(82)."), @"");
            /*"01  WAREA-AUXILIAR.*/

            public _REDEF_VG1617B_FILLER_4()
            {
                WS_DES_CONTEU_N.ValueChanged += OnValueChanged;
                FILLER_5.ValueChanged += OnValueChanged;
            }

        }
        public VG1617B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new VG1617B_WAREA_AUXILIAR();
        public class VG1617B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05 W-FIM-MVTO-BENEFC             PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_MVTO_BENEFC { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05 W-FIM-ERROS                   PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_ERROS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05 WS-COD-CBO                    PIC S9(9)   USAGE COMP.*/
            public IntBasis WS_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"    05 W-LIDO-MOVTO-BENEFC           PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_LIDO_MOVTO_BENEFC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05 W-AC-CONTROLE                 PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05 W-IND-MOV                     PIC  9(02)  VALUE ZEROS.*/
            public IntBasis W_IND_MOV { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05 W-IND-END                     PIC  9(02)  VALUE ZEROS.*/
            public IntBasis W_IND_END { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05 W-IND-1                       PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_IND_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05 W-IND-2                       PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_IND_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05 W-IND                         PIC S9(004)  COMP VALUE +0.*/
            public IntBasis W_IND_0 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 WS-QTD                        PIC S9(004)  COMP VALUE +0.*/
            public IntBasis WS_QTD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 WS-SUBGRUPO-1                 PIC S9(004)  VALUE +0 COMP.*/
            public IntBasis WS_SUBGRUPO_1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 WS-SUBGRUPO-2                 PIC S9(004)  VALUE +0 COMP.*/
            public IntBasis WS_SUBGRUPO_2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 W-IND-TAB                     PIC  9(004)  VALUE  0.*/
            public IntBasis W_IND_TAB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05 W-QTD-LD-BENEFC-0             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_BENEFC_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-QTD-LD-BENEFC-1             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_BENEFC_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-QTD-LD-BENEFC-2             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_BENEFC_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-QTD-LD-BENEFC-3             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_BENEFC_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-QTD-LD-BENEFC-4             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_BENEFC_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-QTD-LD-BENEFC-5             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_BENEFC_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-QTD-LD-BENEFC-6             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_BENEFC_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-QTD-LD-BENEFC-8             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_BENEFC_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-QTD-LD-BENEFC-9             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_BENEFC_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-CONT-LINHAS                 PIC  9(08)  VALUE 80.*/
            public IntBasis W_CONT_LINHAS { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"), 80);
            /*"    05 WS-TOTAL-INSERT               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis WS_TOTAL_INSERT { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 WS-CONT-CNTRLE-PROC           PIC  9(08)  VALUE ZEROS.*/
            public IntBasis WS_CONT_CNTRLE_PROC { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 WS-BENEF-GRAVADOS             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis WS_BENEF_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 WS-QTD-ERRO                   PIC  9(08)  VALUE ZEROS.*/
            public IntBasis WS_QTD_ERRO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-NUM-PROPOSTA-ANT            PIC 9(015)  VALUE ZEROS.*/
            public IntBasis W_NUM_PROPOSTA_ANT { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05 W-NUM-CPF-SEG                 PIC 9(011)  VALUE ZEROS.*/
            public IntBasis W_NUM_CPF_SEG { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"    05 W-NUM-CPF-SEG-ANT             PIC 9(011)  VALUE ZEROS.*/
            public IntBasis W_NUM_CPF_SEG_ANT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"    05 W-NSL-SASSE                   PIC 9(006).*/
            public IntBasis W_NSL_SASSE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05 W-NSAS-FILIAL                 PIC 9(006).*/
            public IntBasis W_NSAS_FILIAL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05 W-SIGLA-ARQUIVO               PIC X(008)  VALUE SPACES.*/
            public StringBasis W_SIGLA_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    05 FILLER REDEFINES W-SIGLA-ARQUIVO.*/
            private _REDEF_VG1617B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_VG1617B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_VG1617B_FILLER_6(); _.Move(W_SIGLA_ARQUIVO, _filler_6); VarBasis.RedefinePassValue(W_SIGLA_ARQUIVO, _filler_6, W_SIGLA_ARQUIVO); _filler_6.ValueChanged += () => { _.Move(_filler_6, W_SIGLA_ARQUIVO); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, W_SIGLA_ARQUIVO); }
            }  //Redefines
            public class _REDEF_VG1617B_FILLER_6 : VarBasis
            {
                /*"       07  W-IDE-SIGLA               PIC X(004).*/
                public StringBasis W_IDE_SIGLA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"       07  W-IDE-FILIAL              PIC 9(004).*/
                public IntBasis W_IDE_FILIAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DATA-PROPOSTA               PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_VG1617B_FILLER_6()
                {
                    W_IDE_SIGLA.ValueChanged += OnValueChanged;
                    W_IDE_FILIAL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-PROPOSTA.*/
            private _REDEF_VG1617B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_VG1617B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_VG1617B_FILLER_7(); _.Move(W_DATA_PROPOSTA, _filler_7); VarBasis.RedefinePassValue(W_DATA_PROPOSTA, _filler_7, W_DATA_PROPOSTA); _filler_7.ValueChanged += () => { _.Move(_filler_7, W_DATA_PROPOSTA); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, W_DATA_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VG1617B_FILLER_7 : VarBasis
            {
                /*"        07  W-ANO-PROPOSTA            PIC 9(004).*/
                public IntBasis W_ANO_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        07  W-MES-PROPOSTA            PIC 9(002).*/
                public IntBasis W_MES_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-DIA-PROPOSTA            PIC 9(002).*/
                public IntBasis W_DIA_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_VG1617B_FILLER_7()
                {
                    W_ANO_PROPOSTA.ValueChanged += OnValueChanged;
                    W_MES_PROPOSTA.ValueChanged += OnValueChanged;
                    W_DIA_PROPOSTA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_VG1617B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_VG1617B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_VG1617B_FILLER_8(); _.Move(W_DATA_TRABALHO, _filler_8); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_8, W_DATA_TRABALHO); _filler_8.ValueChanged += () => { _.Move(_filler_8, W_DATA_TRABALHO); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_VG1617B_FILLER_8 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DATA-NASCIMENTO             PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_VG1617B_FILLER_8()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-NASCIMENTO.*/
            private _REDEF_VG1617B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_VG1617B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_VG1617B_FILLER_9(); _.Move(W_DATA_NASCIMENTO, _filler_9); VarBasis.RedefinePassValue(W_DATA_NASCIMENTO, _filler_9, W_DATA_NASCIMENTO); _filler_9.ValueChanged += () => { _.Move(_filler_9, W_DATA_NASCIMENTO); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, W_DATA_NASCIMENTO); }
            }  //Redefines
            public class _REDEF_VG1617B_FILLER_9 : VarBasis
            {
                /*"        07  W-DIA-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_DIA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_MES_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-NASCIMENTO          PIC 9(004).*/
                public IntBasis W_ANO_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_VG1617B_FILLER_9()
                {
                    W_DIA_NASCIMENTO.ValueChanged += OnValueChanged;
                    W_MES_NASCIMENTO.ValueChanged += OnValueChanged;
                    W_ANO_NASCIMENTO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_VG1617B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_VG1617B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_VG1617B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_VG1617B_W_DTMOVABE1 : VarBasis
            {
                /*"        07  W-ANO-MOVABE1             PIC 9(004).*/
                public IntBasis W_ANO_MOVABE1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-MOVABE1             PIC 9(002).*/
                public IntBasis W_MES_MOVABE1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-DIA-MOVABE1             PIC 9(002).*/
                public IntBasis W_DIA_MOVABE1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  W-DTMOVABE-I                  PIC X(010).*/

                public _REDEF_VG1617B_W_DTMOVABE1()
                {
                    W_ANO_MOVABE1.ValueChanged += OnValueChanged;
                    W_BARRA1.ValueChanged += OnValueChanged;
                    W_MES_MOVABE1.ValueChanged += OnValueChanged;
                    W_BARRA2.ValueChanged += OnValueChanged;
                    W_DIA_MOVABE1.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE_I { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE-I1 REDEFINES W-DTMOVABE-I.*/
            private _REDEF_VG1617B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_VG1617B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_VG1617B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_VG1617B_W_DTMOVABE_I1 : VarBasis
            {
                /*"        07  W-DIA-MOVABEI1            PIC 9(002).*/
                public IntBasis W_DIA_MOVABEI1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRAI1                 PIC X(001).*/
                public StringBasis W_BARRAI1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-MOVABEI1            PIC 9(002).*/
                public IntBasis W_MES_MOVABEI1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRAI2                 PIC X(001).*/
                public StringBasis W_BARRAI2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-ANO-MOVABEI1            PIC 9(004).*/
                public IntBasis W_ANO_MOVABEI1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DATA-SQL                    PIC X(010).*/

                public _REDEF_VG1617B_W_DTMOVABE_I1()
                {
                    W_DIA_MOVABEI1.ValueChanged += OnValueChanged;
                    W_BARRAI1.ValueChanged += OnValueChanged;
                    W_MES_MOVABEI1.ValueChanged += OnValueChanged;
                    W_BARRAI2.ValueChanged += OnValueChanged;
                    W_ANO_MOVABEI1.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DATA-SQL1 REDEFINES W-DATA-SQL.*/
            private _REDEF_VG1617B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_VG1617B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_VG1617B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_VG1617B_W_DATA_SQL1 : VarBasis
            {
                /*"        07  W-ANO-SQL                 PIC 9(004).*/
                public IntBasis W_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        07  W-BARRA1-SQL              PIC X(001).*/
                public StringBasis W_BARRA1_SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-SQL                 PIC 9(002).*/
                public IntBasis W_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2-SQL              PIC X(001).*/
                public StringBasis W_BARRA2_SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-DIA-SQL                 PIC 9(002).*/
                public IntBasis W_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 W-TAB-MOV-BENEFC.*/

                public _REDEF_VG1617B_W_DATA_SQL1()
                {
                    W_ANO_SQL.ValueChanged += OnValueChanged;
                    W_BARRA1_SQL.ValueChanged += OnValueChanged;
                    W_MES_SQL.ValueChanged += OnValueChanged;
                    W_BARRA2_SQL.ValueChanged += OnValueChanged;
                    W_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public VG1617B_W_TAB_MOV_BENEFC W_TAB_MOV_BENEFC { get; set; } = new VG1617B_W_TAB_MOV_BENEFC();
            public class VG1617B_W_TAB_MOV_BENEFC : VarBasis
            {
                /*"       10 W-TAB-MOV-BENEFC  OCCURS 99  TIMES INDEXED BY I00.*/
                public ListBasis<VG1617B_W_TAB_MOV_BENEFC_0> W_TAB_MOV_BENEFC_0 { get; set; } = new ListBasis<VG1617B_W_TAB_MOV_BENEFC_0>(99);
                public class VG1617B_W_TAB_MOV_BENEFC_0 : VarBasis
                {
                    /*"          15 W-TB-MOV-BENEFC     PIC  X(180).*/
                    public StringBasis W_TB_MOV_BENEFC { get; set; } = new StringBasis(new PIC("X", "180", "X(180)."), @"");
                    /*"01  WS-TIME.*/
                }
            }
        }
        public VG1617B_WS_TIME WS_TIME { get; set; } = new VG1617B_WS_TIME();
        public class VG1617B_WS_TIME : VarBasis
        {
            /*"    05 WS-TIME-N                     PIC 9(06).*/
            public IntBasis WS_TIME_N { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 FILLER                        PIC X(02).*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"01  WS-TIME-EDIT                     PIC 99.99.99.*/
        }
        public IntBasis WS_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
        /*"01  WABEND.*/
        public VG1617B_WABEND WABEND { get; set; } = new VG1617B_WABEND();
        public class VG1617B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(010) VALUE            'VG1617B  '.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VG1617B  ");
            /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"       05      LOCALIZA-ABEND-1.*/
            public VG1617B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VG1617B_LOCALIZA_ABEND_1();
            public class VG1617B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"         10    FILLER                   PIC  X(012)   VALUE               'PARAGRAFO = '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"         10    PARAGRAFO              PIC  X(040)   VALUE SPACES*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"       05      LOCALIZA-ABEND-2.*/
            }
            public VG1617B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VG1617B_LOCALIZA_ABEND_2();
            public class VG1617B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"         10    FILLER                   PIC  X(012)   VALUE               'COMANDO   = '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"         10    COMANDO                PIC  X(060)   VALUE SPACES*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"       05         WSQLERRO.*/
            }
            public VG1617B_WSQLERRO WSQLERRO { get; set; } = new VG1617B_WSQLERRO();
            public class VG1617B_WSQLERRO : VarBasis
            {
                /*"         10       FILLER               PIC  X(014) VALUE                 ' *** SQLERRMC '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"         10       WSQLERRMC            PIC  X(070) VALUE  SPACES*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01  WREA88.*/
            }
        }
        public VG1617B_WREA88 WREA88 { get; set; } = new VG1617B_WREA88();
        public class VG1617B_WREA88 : VarBasis
        {
            /*"    05  W-NUM-PROPOSTA                PIC 9(015).*/
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05  CANAL  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_VG1617B_CANAL _canal { get; set; }
            public _REDEF_VG1617B_CANAL CANAL
            {
                get { _canal = new _REDEF_VG1617B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VG1617B_CANAL : VarBasis
            {
                /*"        07  W-CANAL-PROPOSTA          PIC 9(002).*/

                public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("002")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL                    VALUE 00. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "00"),
							/*" 88 CANAL-VENDA-CEF                      VALUE 01. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "01"),
							/*" 88 CANAL-VENDA-SASSE                    VALUE 02. */
							new SelectorItemBasis("CANAL_VENDA_SASSE", "02"),
							/*" 88 CANAL-VENDA-CORRETOR                 VALUE 03. */
							new SelectorItemBasis("CANAL_VENDA_CORRETOR", "03"),
							/*" 88 CANAL-VENDA-ATM                      VALUE 04. */
							new SelectorItemBasis("CANAL_VENDA_ATM", "04"),
							/*" 88 CANAL-VENDA-GITEL                    VALUE 05. */
							new SelectorItemBasis("CANAL_VENDA_GITEL", "05"),
							/*" 88 CANAL-VENDA-INTERNET                 VALUE 07. */
							new SelectorItemBasis("CANAL_VENDA_INTERNET", "07"),
							/*" 88 CANAL-VENDA-INTRANET                 VALUE 08. */
							new SelectorItemBasis("CANAL_VENDA_INTRANET", "08"),
							/*" 88 CANAL-VENDA-BENEFCPJ                 VALUE 13. */
							new SelectorItemBasis("CANAL_VENDA_BENEFCPJ", "13")
                }
                };

                /*"        07  FILLER                    PIC 9(013).*/
                public IntBasis FILLER_20 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    05  FAIXAS  REDEFINES W-NUM-PROPOSTA.*/

                public _REDEF_VG1617B_CANAL()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_20.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VG1617B_FAIXAS _faixas { get; set; }
            public _REDEF_VG1617B_FAIXAS FAIXAS
            {
                get { _faixas = new _REDEF_VG1617B_FAIXAS(); _.Move(W_NUM_PROPOSTA, _faixas); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _faixas, W_NUM_PROPOSTA); _faixas.ValueChanged += () => { _.Move(_faixas, W_NUM_PROPOSTA); }; return _faixas; }
                set { VarBasis.RedefinePassValue(value, _faixas, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VG1617B_FAIXAS : VarBasis
            {
                /*"        07  FILLER                    PIC 9(004).*/
                public IntBasis FILLER_21 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        07  FAIXA-NUMERACAO           PIC 9(003).*/

                public SelectorBasis FAIXA_NUMERACAO { get; set; } = new SelectorBasis("003")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 FAIXA-NUMERACAO-MULT-SUPER VALUE               845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_MULT_SUPER", "845,846"),
							/*" 88 FAIXA-NUMERACAO-MULT       VALUE               848, 850. */
							new SelectorItemBasis("FAIXA_NUMERACAO_MULT", "848,850"),
							/*" 88 FAIXA-NUMERACAO-BILHETE    VALUE               823, 824, 826, 827, 829, 837, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_BILHETE", "823,824,826,827,829,837,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-M-RISCO    VALUE               821, 823, 824, 826, 827, 829, 837, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_M_RISCO", "821,823,824,826,827,829,837,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-SENIOR     VALUE               821, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_SENIOR", "821,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-EXECUTIVO  VALUE               821, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_EXECUTIVO", "821,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-AUTO       VALUE               828, 837, 847, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_AUTO", "828,837,847,845,846")
                }
                };

                /*"        07  FILLER                    PIC 9(008).*/
                public IntBasis FILLER_22 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05  FILLER  REDEFINES W-NUM-PROPOSTA.*/

                public _REDEF_VG1617B_FAIXAS()
                {
                    FILLER_21.ValueChanged += OnValueChanged;
                    FAIXA_NUMERACAO.ValueChanged += OnValueChanged;
                    FILLER_22.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VG1617B_FILLER_23 _filler_23 { get; set; }
            public _REDEF_VG1617B_FILLER_23 FILLER_23
            {
                get { _filler_23 = new _REDEF_VG1617B_FILLER_23(); _.Move(W_NUM_PROPOSTA, _filler_23); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _filler_23, W_NUM_PROPOSTA); _filler_23.ValueChanged += () => { _.Move(_filler_23, W_NUM_PROPOSTA); }; return _filler_23; }
                set { VarBasis.RedefinePassValue(value, _filler_23, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VG1617B_FILLER_23 : VarBasis
            {
                /*"        07  FILLER                    PIC 9(006).*/
                public IntBasis FILLER_24 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"        07  PRP-AUTO                  PIC 9(002).*/

                public SelectorBasis PRP_AUTO { get; set; } = new SelectorBasis("002")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 PROPOSTA-AUTOMOVEL      VALUE               30, 31, 32, 34, 35, 37, 39, 40, 41. */
							new SelectorItemBasis("PROPOSTA_AUTOMOVEL", "30,31,32,34,35,37,39,40,41")
                }
                };

                /*"        07  FILLER                    PIC 9(007).*/
                public IntBasis FILLER_25 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"    05 W-LEITURA-CBO                  PIC  9(001) VALUE ZERO.*/

                public _REDEF_VG1617B_FILLER_23()
                {
                    FILLER_24.ValueChanged += OnValueChanged;
                    PRP_AUTO.ValueChanged += OnValueChanged;
                    FILLER_25.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_LEITURA_CBO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CBO-ENCONTRADO                          VALUE 1. */
							new SelectorItemBasis("CBO_ENCONTRADO", "1"),
							/*" 88 CBO-NAO-ENCONTRADO                      VALUE 2. */
							new SelectorItemBasis("CBO_NAO_ENCONTRADO", "2")
                }
            };

            /*"    05 W-LEITURA-SICOB                PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_LEITURA_SICOB { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 SICOB-JA-CADASTRADO                     VALUE 1. */
							new SelectorItemBasis("SICOB_JA_CADASTRADO", "1"),
							/*" 88 SICOB-NAO-CADASTRADO                    VALUE 2. */
							new SelectorItemBasis("SICOB_NAO_CADASTRADO", "2")
                }
            };

            /*"    05 W-CONVENIO                     PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_CONVENIO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 DEMAIS-CONVENIOS                        VALUE 1. */
							new SelectorItemBasis("DEMAIS_CONVENIOS", "1"),
							/*" 88 CONVENIO-VERA-CRUZ                      VALUE 2. */
							new SelectorItemBasis("CONVENIO_VERA_CRUZ", "2"),
							/*" 88 CONVENIO-CCA                            VALUE 3. */
							new SelectorItemBasis("CONVENIO_CCA", "3")
                }
            };

            /*"    05 W-GEROU-MOVTO-CEF              PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_GEROU_MOVTO_CEF { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 GEROU-MOVTO-CEF                         VALUE 1. */
							new SelectorItemBasis("GEROU_MOVTO_CEF", "1")
                }
            };

            /*"    05 W-LEITURA-RCAP                 PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_LEITURA_RCAP { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ENCONTROU-RCAP                          VALUE 1. */
							new SelectorItemBasis("ENCONTROU_RCAP", "1"),
							/*" 88 NAO-ENCONTROU-RCAP                      VALUE 2. */
							new SelectorItemBasis("NAO_ENCONTROU_RCAP", "2")
                }
            };

            /*"    05 W-LEITURA-RCAPCOMP             PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_LEITURA_RCAPCOMP { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ENCONTROU-RCAPCOMP                      VALUE 1. */
							new SelectorItemBasis("ENCONTROU_RCAPCOMP", "1"),
							/*" 88 NAO-ENCONTROU-RCAPCOMP                  VALUE 2. */
							new SelectorItemBasis("NAO_ENCONTROU_RCAPCOMP", "2")
                }
            };

            /*"    05 W-COD-EMPRESA                  PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_COD_EMPRESA { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 SASSE                                   VALUE 1. */
							new SelectorItemBasis("SASSE", "1"),
							/*" 88 CAIXA-PREVIDENCIA                       VALUE 2. */
							new SelectorItemBasis("CAIXA_PREVIDENCIA", "2"),
							/*" 88 CAIXA-CAPITALIZACAO                     VALUE 3. */
							new SelectorItemBasis("CAIXA_CAPITALIZACAO", "3")
                }
            };

            /*"    05 W-RELACIONAMENTO               PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_RELACIONAMENTO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 SEGURO-VIDA                             VALUE 1. */
							new SelectorItemBasis("SEGURO_VIDA", "1"),
							/*" 88 CAPITALIZACAO                           VALUE 2. */
							new SelectorItemBasis("CAPITALIZACAO", "2"),
							/*" 88 PREVIDENCIA                             VALUE 3. */
							new SelectorItemBasis("PREVIDENCIA", "3"),
							/*" 88 BILHETE-WR                              VALUE 4. */
							new SelectorItemBasis("BILHETE_WR", "4"),
							/*" 88 AUTOMOVEIS                              VALUE 5. */
							new SelectorItemBasis("AUTOMOVEIS", "5"),
							/*" 88 MULTIRISCO                              VALUE 6. */
							new SelectorItemBasis("MULTIRISCO", "6"),
							/*" 88 CONSORCIO                               VALUE 7. */
							new SelectorItemBasis("CONSORCIO", "7"),
							/*" 88 SEGURO-CREDITO                          VALUE 8. */
							new SelectorItemBasis("SEGURO_CREDITO", "8")
                }
            };

            /*"    05 W-TP-MOVIMENTO                 PIC  9(002) VALUE ZEROS.*/

            public SelectorBasis W_TP_MOVIMENTO { get; set; } = new SelectorBasis("002", "ZEROS")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 MOVTO-CEF-BENEFC                        VALUE 1. */
							new SelectorItemBasis("MOVTO_CEF_BENEFC", "1"),
							/*" 88 MOVTO-BENEFC-FILIAL                     VALUE 2. */
							new SelectorItemBasis("MOVTO_BENEFC_FILIAL", "2"),
							/*" 88 MOVTO-AIC                               VALUE 3. */
							new SelectorItemBasis("MOVTO_AIC", "3")
                }
            };

            /*"    05                   PIC  X(001) VALUE SPACES.*/

            public SelectorBasis PIC { get; set; } = new SelectorBasis("VALUE", "SPACES")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 TPREG-HEADER                            VALUE '0'. */
							new SelectorItemBasis("TPREG_HEADER", "0"),
							/*" 88 TPREG-SUBGRUPOS                         VALUE '1'. */
							new SelectorItemBasis("TPREG_SUBGRUPOS", "1"),
							/*" 88 TPREG-ENDERECO                          VALUE '2'. */
							new SelectorItemBasis("TPREG_ENDERECO", "2"),
							/*" 88 TPREG-REPRESENTANTE                     VALUE '3'. */
							new SelectorItemBasis("TPREG_REPRESENTANTE", "3"),
							/*" 88 TPREG-COBERTURA                         VALUE '4'. */
							new SelectorItemBasis("TPREG_COBERTURA", "4"),
							/*" 88 TPREG-CORRETAGEM                        VALUE '5'. */
							new SelectorItemBasis("TPREG_CORRETAGEM", "5"),
							/*" 88 TPREG-LIMITES-PLANO                     VALUE '6'. */
							new SelectorItemBasis("TPREG_LIMITES_PLANO", "6"),
							/*" 88 TPREG-COND-TECNIC                       VALUE '7'. */
							new SelectorItemBasis("TPREG_COND_TECNIC", "7"),
							/*" 88 TPREG-TRAILLER                          VALUE '9'. */
							new SelectorItemBasis("TPREG_TRAILLER", "9")
                }
            };

            /*"    05 W-COD-CLASSE-APOL               PIC  X(001) VALUE SPACES.*/

            public SelectorBasis W_COD_CLASSE_APOL { get; set; } = new SelectorBasis("001", "SPACES")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 COD-CLASSE-VALIDA      VALUE 'A', 'B', 'C',                                       'D', 'E', 'F'. */
							new SelectorItemBasis("COD_CLASSE_VALIDA", "A,B,C,D,E,F")
                }
            };

            /*"    05 W-COD-PERIO-FATURA              PIC  9(002) VALUE ZEROS.*/

            public SelectorBasis W_COD_PERIO_FATURA { get; set; } = new SelectorBasis("002", "ZEROS")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 COD-PERIO-FAT-VALIDO      VALUE 1, 2, 3, 4, 6, 8, 12. */
							new SelectorItemBasis("COD_PERIO_FAT_VALIDO", "1,2,3,4,6,8,12")
                }
            };

            /*"    05 W-PRP-REMOTO                   PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_PRP_REMOTO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 W-EXISTE-PRP-REMOTO                     VALUE 1. */
							new SelectorItemBasis("W_EXISTE_PRP_REMOTO", "1")
                }
            };

            /*"    05 W-MOVTO-AUTO                   PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_MOVTO_AUTO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 EXISTE-MOVTO-AUTO                       VALUE 1. */
							new SelectorItemBasis("EXISTE_MOVTO_AUTO", "1")
                }
            };

            /*"    05 W-MOVTO-RISCO                  PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_MOVTO_RISCO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 EXISTE-MOVTO-RISCO                      VALUE 1. */
							new SelectorItemBasis("EXISTE_MOVTO_RISCO", "1")
                }
            };

            /*"    05 W-MOVTO-VDEMP                  PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_MOVTO_VDEMP { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 EXISTE-MOVTO-VDEMP                      VALUE 1. */
							new SelectorItemBasis("EXISTE_MOVTO_VDEMP", "1")
                }
            };

            /*"    05 W-CRITICA-BENEFIC             PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_CRITICA_BENEFIC { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 BENEFIC-SEM-CRITICA                    VALUE 1. */
							new SelectorItemBasis("BENEFIC_SEM_CRITICA", "1"),
							/*" 88 BENEFIC-COM-CRITICA                    VALUE 2. */
							new SelectorItemBasis("BENEFIC_COM_CRITICA", "2")
                }
            };

            /*"    05 W-HEADER-AUTO                  PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_HEADER_AUTO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 HDAUTO-NAO-GERADO                       VALUE 1. */
							new SelectorItemBasis("HDAUTO_NAO_GERADO", "1"),
							/*" 88 HDAUTO-FOI-GERADO                       VALUE 2. */
							new SelectorItemBasis("HDAUTO_FOI_GERADO", "2")
                }
            };

            /*"    05 W-HEADER-RISCO                 PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_HEADER_RISCO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 HDRISCO-NAO-GERADO                      VALUE 1. */
							new SelectorItemBasis("HDRISCO_NAO_GERADO", "1"),
							/*" 88 HDRISCO-FOI-GERADO                      VALUE 2. */
							new SelectorItemBasis("HDRISCO_FOI_GERADO", "2")
                }
            };

            /*"    05 W-HEADER-VDEMP                 PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_HEADER_VDEMP { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 HDVDEMP-NAO-GERADO                      VALUE 1. */
							new SelectorItemBasis("HDVDEMP_NAO_GERADO", "1"),
							/*" 88 HDVDEMP-FOI-GERADO                      VALUE 2. */
							new SelectorItemBasis("HDVDEMP_FOI_GERADO", "2")
                }
            };

            /*"    05 W-VERSAO-BENEFC                 PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_VERSAO_BENEFC { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 VERSAO-BENEFC-NOVA                       VALUE 1. */
							new SelectorItemBasis("VERSAO_BENEFC_NOVA", "1"),
							/*" 88 VERSAO-BENEFC-ANTERIOR                   VALUE 2. */
							new SelectorItemBasis("VERSAO_BENEFC_ANTERIOR", "2")
                }
            };

            /*"    05 W-PERI-PGTO                    PIC  9(002) VALUE ZEROS.*/

            public SelectorBasis W_PERI_PGTO { get; set; } = new SelectorBasis("002", "ZEROS")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 PAGAMENTO-MENSAL                        VALUE 1. */
							new SelectorItemBasis("PAGAMENTO_MENSAL", "1"),
							/*" 88 PAGAMENTO-ANUAL                         VALUE 12. */
							new SelectorItemBasis("PAGAMENTO_ANUAL", "12"),
							/*" 88 PAGAMENTO-UNICO                         VALUE 36. */
							new SelectorItemBasis("PAGAMENTO_UNICO", "36")
                }
            };

            /*"    05 W-CONJUGE                      PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_CONJUGE { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CONJUGE-OPCIONAL                        VALUE 1. */
							new SelectorItemBasis("CONJUGE_OPCIONAL", "1"),
							/*" 88 SEM-CONJUGE                             VALUE 3. */
							new SelectorItemBasis("SEM_CONJUGE", "3")
                }
            };

            /*"01              LC00.*/
        }
        public VG1617B_LC00 LC00 { get; set; } = new VG1617B_LC00();
        public class VG1617B_LC00 : VarBasis
        {
            /*"  05            LC01.*/
            public VG1617B_LC01 LC01 { get; set; } = new VG1617B_LC01();
            public class VG1617B_LC01 : VarBasis
            {
                /*"    10          LC01-RELATORIO  PIC  X(008) VALUE 'VG1617B '.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG1617B ");
                /*"    10          FILLER          PIC  X(050) VALUE  SPACES.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    10          FILLER          PIC  X(028) VALUE     'C A I X A    S E G U R O S '.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"C A I X A    S E G U R O S ");
                /*"    10          FILLER          PIC  X(023) VALUE  SPACES.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
                /*"    10          FILLER          PIC  X(012) VALUE '    PAGINA: '*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"    PAGINA: ");
                /*"    10          LC01-PAGINA     PIC  9(04).*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"  05            LC02.*/
            }
            public VG1617B_LC02 LC02 { get; set; } = new VG1617B_LC02();
            public class VG1617B_LC02 : VarBasis
            {
                /*"    10          FILLER          PIC  X(113) VALUE  SPACES.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "113", "X(113)"), @"");
                /*"    10          FILLER          PIC  X(008) VALUE 'DATA..: '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"DATA..: ");
                /*"    10          LC02-DATA       PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC03.*/
            }
            public VG1617B_LC03 LC03 { get; set; } = new VG1617B_LC03();
            public class VG1617B_LC03 : VarBasis
            {
                /*"    10          FILLER          PIC  X(028) VALUE  SPACES.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"");
                /*"    10          FILLER          PIC  X(077) VALUE    'RELAT�RIO DE CR�TICAS DO MOVIMENTO DE BENEFICI�RIOS DE AP�LI    'CE ESPEC�FICA'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "77", "X(077)"), @"RELAT�RIO DE CR�TICAS DO MOVIMENTO DE BENEFICI�RIOS DE AP�LI    ");
                /*"    10          FILLER          PIC  X(008) VALUE  SPACES.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10          FILLER          PIC  X(008) VALUE 'HORA..: '.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"HORA..: ");
                /*"    10          LC03-HORA       PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05            LC04.*/
            }
            public VG1617B_LC04 LC04 { get; set; } = new VG1617B_LC04();
            public class VG1617B_LC04 : VarBasis
            {
                /*"    10          FILLER            PIC  X(021) VALUE               'NUM. ARQ. PROCESSADO:'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"NUM. ARQ. PROCESSADO:");
                /*"    10          LC04-NSAS-BENEFC  PIC  ZZ9999.*/
                public IntBasis LC04_NSAS_BENEFC { get; set; } = new IntBasis(new PIC("9", "6", "ZZ9999."));
                /*"    10          FILLER            PIC  X(013) VALUE               ' - GERADO EM '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" - GERADO EM ");
                /*"    10          LC04-DATA-GERACAO PIC  X(010).*/
                public StringBasis LC04_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10          FILLER            PIC  X(082) VALUE  SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "82", "X(082)"), @"");
                /*"  05            LC05.*/
            }
            public VG1617B_LC05 LC05 { get; set; } = new VG1617B_LC05();
            public class VG1617B_LC05 : VarBasis
            {
                /*"    10          FILLER            PIC  X(012) VALUE               'NUM APOLICE;'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"NUM APOLICE;");
                /*"    10          FILLER            PIC  X(013) VALUE               'NUM SUBGRUPO;'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"NUM SUBGRUPO;");
                /*"    10          FILLER            PIC  X(013) VALUE               'NUM CPF SEG ;'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"NUM CPF SEG ;");
                /*"    10          FILLER            PIC  X(013) VALUE               'CERTIFICADO ;'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"CERTIFICADO ;");
                /*"    10          FILLER            PIC  X(017) VALUE               'NUM SEQ REGISTRO;'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"NUM SEQ REGISTRO;");
                /*"    10          FILLER            PIC  X(010) VALUE               'NUM LINHA;'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"NUM LINHA;");
                /*"    10          FILLER            PIC  X(014) VALUE               'NOME DO CAMPO;'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"NOME DO CAMPO;");
                /*"    10          FILLER            PIC  X(028) VALUE               'DESCRICAO DA INCONSISTENCIA;'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"DESCRICAO DA INCONSISTENCIA;");
                /*"    10          FILLER            PIC  X(017) VALUE               'CONTEUDO ENVIADO;'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"CONTEUDO ENVIADO;");
                /*"  05            LC06.*/
            }
            public VG1617B_LC06 LC06 { get; set; } = new VG1617B_LC06();
            public class VG1617B_LC06 : VarBasis
            {
                /*"    10          FILLER               PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LC06-NUM-APOLICE     PIC  9(015).*/
                public IntBasis LC06_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10          FILLER               PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LC06-NUM-SUBGRUPO    PIC  9(003).*/
                public IntBasis LC06_NUM_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10          FILLER               PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LC06-NUM-CPF-SEG     PIC  9(011).*/
                public IntBasis LC06_NUM_CPF_SEG { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
                /*"    10          FILLER               PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LC06-NUM-CERTIF      PIC  9(015).*/
                public IntBasis LC06_NUM_CERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10          FILLER               PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LC06-NUM-SEQ-REG     PIC  9(002).*/
                public IntBasis LC06_NUM_SEQ_REG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          FILLER               PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LC06-NUM-LIN-ARQ     PIC  9(008).*/
                public IntBasis LC06_NUM_LIN_ARQ { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10          FILLER               PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LC06-CAMPO-ERRO      PIC  X(025).*/
                public StringBasis LC06_CAMPO_ERRO { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"    10          FILLER               PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LC06-DES-ERRO        PIC  X(050).*/
                public StringBasis LC06_DES_ERRO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"    10          FILLER               PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LC06-DES-CONTEUDO    PIC  X(050).*/
                public StringBasis LC06_DES_CONTEUDO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"    10          FILLER               PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER               PIC  X(023) VALUE  SPACES.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
                /*"  05            LC07.*/
            }
            public VG1617B_LC07 LC07 { get; set; } = new VG1617B_LC07();
            public class VG1617B_LC07 : VarBasis
            {
                /*"    10          FILLER          PIC  X(141) VALUE ALL '-'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "141", "X(141)"), @"ALL");
                /*"01  AREA-DAS-TABELAS.*/
            }
        }
        public VG1617B_AREA_DAS_TABELAS AREA_DAS_TABELAS { get; set; } = new VG1617B_AREA_DAS_TABELAS();
        public class VG1617B_AREA_DAS_TABELAS : VarBasis
        {
            /*"    05 W-TAB-CONSISTENCIA.*/
            public VG1617B_W_TAB_CONSISTENCIA W_TAB_CONSISTENCIA { get; set; } = new VG1617B_W_TAB_CONSISTENCIA();
            public class VG1617B_W_TAB_CONSISTENCIA : VarBasis
            {
                /*"       10 FILLER  OCCURS 9999 TIMES.*/
                public ListBasis<VG1617B_FILLER_60> FILLER_60 { get; set; } = new ListBasis<VG1617B_FILLER_60>(9999);
                public class VG1617B_FILLER_60 : VarBasis
                {
                    /*"          15 W-TB-NUM-APOLICE  PIC  9(015).*/
                    public IntBasis W_TB_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                    /*"          15 W-TB-NUM-SUBGRUPO PIC  9(005).*/
                    public IntBasis W_TB_NUM_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"          15 W-TB-NUM-CPF-SEG  PIC  9(011).*/
                    public IntBasis W_TB_NUM_CPF_SEG { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
                    /*"          15 W-TB-NUM-CERTIF   PIC  9(015).*/
                    public IntBasis W_TB_NUM_CERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                    /*"          15 W-TB-NUM-SEQ-REG  PIC  9(003).*/
                    public IntBasis W_TB_NUM_SEQ_REG { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"          15 W-TB-NUM-LIN-ARQ  PIC  9(008).*/
                    public IntBasis W_TB_NUM_LIN_ARQ { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"          15 W-TB-COD-ERRO     PIC  9(004).*/
                    public IntBasis W_TB_COD_ERRO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"          15 W-TB-COD-CAMPO    PIC  9(004).*/
                    public IntBasis W_TB_COD_CAMPO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"          15 W-TB-NSAS         PIC  9(006).*/
                    public IntBasis W_TB_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"          15 W-TB-DES-CONTEUDO PIC  X(040).*/
                    public StringBasis W_TB_DES_CONTEUDO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                    /*"    05 W-TAB-DESCRICAO.*/
                }
            }
            public VG1617B_W_TAB_DESCRICAO W_TAB_DESCRICAO { get; set; } = new VG1617B_W_TAB_DESCRICAO();
            public class VG1617B_W_TAB_DESCRICAO : VarBasis
            {
                /*"       10 FILLER               PIC  X(050)     VALUE          '000-PROPOSTA INCLUIDA COM SUCESSO NO SIAS         '.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"000-PROPOSTA INCLUIDA COM SUCESSO NO SIAS         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '001-MOVIMENTO NAO POSSUI HEADER                   '.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"001-MOVIMENTO NAO POSSUI HEADER                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '002-NOME DO ARQUIVO INVALIDO                      '.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"002-NOME DO ARQUIVO INVALIDO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '003-DATA DA GERACAO INVALIDA                      '.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"003-DATA DA GERACAO INVALIDA                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '004-SISTEMA ORIGEM INVALIDO                       '.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"004-SISTEMA ORIGEM INVALIDO                       ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '005-SISTEMA DESTINO INVALIDO                      '.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"005-SISTEMA DESTINO INVALIDO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '006-TIPO DE ARQUIVO INVALIDO                      '.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"006-TIPO DE ARQUIVO INVALIDO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '007-SEQUENCIAL DO ARQUIVO INVALIDO                '.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"007-SEQUENCIAL DO ARQUIVO INVALIDO                ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '008-MOVIMENTO JAH PROCESSADO                      '.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"008-MOVIMENTO JAH PROCESSADO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '101-NUM-PROPOSTA NAO NUMERICO OU ZERADA           '.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"101-NUM-PROPOSTA NAO NUMERICO OU ZERADA           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '102-NUM-PROPOSTA JA PROCESSADA PELO SIAS          '.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"102-NUM-PROPOSTA JA PROCESSADA PELO SIAS          ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '103-NUM-SUBGRUPO NAO NUMERICO                     '.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"103-NUM-SUBGRUPO NAO NUMERICO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '104-NUM-TIPO-APOL NAO INVALIDO                    '.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"104-NUM-TIPO-APOL NAO INVALIDO                    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '105-NOM-EMPRESA EM BRANCO                         '.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"105-NOM-EMPRESA EM BRANCO                         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '106-VAL-FAT-ANUAL NAO INVALIDO                    '.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"106-VAL-FAT-ANUAL NAO INVALIDO                    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '107-COD-PORTE-EMP NAO INVALIDO                    '.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"107-COD-PORTE-EMP NAO INVALIDO                    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '108-DTA-CONST-EMP EH NAO VALIDA                   '.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"108-DTA-CONST-EMP EH NAO VALIDA                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '109-DTA-INI-VIGENCIA EH NAO VALIDA                '.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"109-DTA-INI-VIGENCIA EH NAO VALIDA                ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '110-COD-SUCURSAL NAO INVALIDO                     '.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"110-COD-SUCURSAL NAO INVALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '111-COD-SUCURSAL NAO EXISTE NO SIAS               '.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"111-COD-SUCURSAL NAO EXISTE NO SIAS               ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '112-IND-OP-COBERTUR NAO INVALIDO                  '.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"112-IND-OP-COBERTUR NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '113-IND-OP-CORRETAG NAO INVALIDO                  '.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"113-IND-OP-CORRETAG NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '114-COD-AG-PRODUTORA NAO INVALIDO OU ZERADA       '.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"114-COD-AG-PRODUTORA NAO INVALIDO OU ZERADA       ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '115-COD-AG-PRODUTORA NAO EXISTE NO SIAS           '.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"115-COD-AG-PRODUTORA NAO EXISTE NO SIAS           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '116-COD-CLASSE-APOL NAO INVALIDA                  '.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"116-COD-CLASSE-APOL NAO INVALIDA                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '117-COD-TP-PLANO NAO INVALIDO                     '.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"117-COD-TP-PLANO NAO INVALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '118-COD-TP-CORRECAO NAO INVALIDO                  '.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"118-COD-TP-CORRECAO NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '119-PERIO-FATURA NAO INVALIDO                     '.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"119-PERIO-FATURA NAO INVALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '120-IND-FORMA-AVERB NAO INVALIDO                  '.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"120-IND-FORMA-AVERB NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '121-IND-FORMA-FATURA NAO INVALIDO                 '.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"121-IND-FORMA-FATURA NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '122-IND-COBRA-IOF NAO INVALIDO                    '.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"122-IND-COBRA-IOF NAO INVALIDO                    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '123-QTD-VIDA-CONTRAT NAO INVALIDO                 '.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"123-QTD-VIDA-CONTRAT NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '124-VAL-PRM-INICIAL NAO INVALIDO                  '.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"124-VAL-PRM-INICIAL NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '125-VAL-CAP-INICIAL NAO INVALIDO                  '.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"125-VAL-CAP-INICIAL NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '126-VAL-PRMVG-INICIAL NAO INVALIDO                '.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"126-VAL-PRMVG-INICIAL NAO INVALIDO                ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '127-VAL-PRMAP-INICIAL NAO INVALIDO                '.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"127-VAL-PRMAP-INICIAL NAO INVALIDO                ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '128-COD-TP-COSSEG-CED NAO INVALIDO                '.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"128-COD-TP-COSSEG-CED NAO INVALIDO                ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '129-COD-PRODUTO NAO INVALIDO                      '.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"129-COD-PRODUTO NAO INVALIDO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '130-R1-IND-OPCAO-CONJUGE NAO INVALIDO             '.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"130-R1-IND-OPCAO-CONJUGE NAO INVALIDO             ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '131-PER-COBERVG-CONJ NAO INVALIDO                 '.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"131-PER-COBERVG-CONJ NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '132-PER-COBERAP-CONJ NAO INVALIDO                 '.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"132-PER-COBERAP-CONJ NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '133-IND-PLANO-ASSOC NAO INVALIDO                  '.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"133-IND-PLANO-ASSOC NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '134-IND-COBER-ADIC NAO INVALIDO                   '.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"134-IND-COBER-ADIC NAO INVALIDO                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '135-IND-VALID-MATRC NAO INVALIDO                  '.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"135-IND-VALID-MATRC NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '136-NUM-DIA-DEBITO NAO INVALIDO                   '.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"136-NUM-DIA-DEBITO NAO INVALIDO                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '137-IND-OPCAO-PAGMTO NAO INVALIDO                 '.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"137-IND-OPCAO-PAGMTO NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '138-NUM-TITULO-RCAP NAO INVALIDO                  '.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"138-NUM-TITULO-RCAP NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '139-DTA-VENC-TITULO EH NAO VALIDA                 '.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"139-DTA-VENC-TITULO EH NAO VALIDA                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '140-VAL-TITULO-RCAP NAO INVALIDO                  '.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"140-VAL-TITULO-RCAP NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '141-NUM-BCO-COBR NAO INVALIDO                     '.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"141-NUM-BCO-COBR NAO INVALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '142-NUM-AGE-COBR NAO INVALIDO                     '.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"142-NUM-AGE-COBR NAO INVALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '143-NUM-AGE-COBR NAO CADASTRADA NO SIAS           '.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"143-NUM-AGE-COBR NAO CADASTRADA NO SIAS           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '144-NUM-CONTA-COBR NAO INVALIDO                   '.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"144-NUM-CONTA-COBR NAO INVALIDO                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '145-NUM-OPER-CONTA-COBR NAO INVALIDO              '.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"145-NUM-OPER-CONTA-COBR NAO INVALIDO              ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '146-NUM-DV-CONTA-COBR NAO INVALIDO P/ AGE/OPER/CON'.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"146-NUM-DV-CONTA-COBR NAO INVALIDO P/ AGE/OPER/CON");
                /*"       10 FILLER               PIC  X(050)     VALUE          '147-R1-NUM-CGC-CNPJ NAO INVALIDO                  '.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"147-R1-NUM-CGC-CNPJ NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '148-NUM-CGC-CNPJ DV INVALIDO                      '.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"148-NUM-CGC-CNPJ DV INVALIDO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '149-PER-COBERVG-CONJ NAO INVALIDO                 '.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"149-PER-COBERVG-CONJ NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '150-PER-COBERAP-CONJ NAO INVALIDO                 '.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"150-PER-COBERAP-CONJ NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '151-NOM-EMPRESA COM MENOS DE 5 CARACTERES         '.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"151-NOM-EMPRESA COM MENOS DE 5 CARACTERES         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '152-NUM-DV-AGE-COBR NAO INVALIDO P/ BCO/AGE/DAC   '.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"152-NUM-DV-AGE-COBR NAO INVALIDO P/ BCO/AGE/DAC   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '201-NUM-PROPOSTA NAO NUMERICO OU ZERADA           '.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"201-NUM-PROPOSTA NAO NUMERICO OU ZERADA           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '203-NUM-SUBGRUPO NAO NUMERICO                     '.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"203-NUM-SUBGRUPO NAO NUMERICO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '204-NUM-SEQ-REG-TP02 NAO INVALIDO                 '.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"204-NUM-SEQ-REG-TP02 NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '205-R2-NUM-TIPO-END NAO INVALIDO                  '.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"205-R2-NUM-TIPO-END NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '206-NOM-ENDERECO EM BRANCO                        '.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"206-NOM-ENDERECO EM BRANCO                        ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '207-NOM-ENDERECO COM MENOS DE 3 CARACTERES        '.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"207-NOM-ENDERECO COM MENOS DE 3 CARACTERES        ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '208-NOM-CIDADE EM BRANCO                          '.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"208-NOM-CIDADE EM BRANCO                          ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '209-NOM-CIDADE COM MENOS DE 3 CARACTERES          '.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"209-NOM-CIDADE COM MENOS DE 3 CARACTERES          ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '210-NOM-CIDADE COM CARACTERES INVALIDOS           '.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"210-NOM-CIDADE COM CARACTERES INVALIDOS           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '211-NOM-ENDERECO COM CARACTERES INVALIDOS         '.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"211-NOM-ENDERECO COM CARACTERES INVALIDOS         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '212-SIGLA-UF EM BRANCO                            '.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"212-SIGLA-UF EM BRANCO                            ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '213-SIGLA-UF NAO INVALIDA                         '.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"213-SIGLA-UF NAO INVALIDA                         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '214-NUM-CEP NAO INVALIDO                          '.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"214-NUM-CEP NAO INVALIDO                          ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '215-NUM-DDD-TEL NAO INVALIDO                      '.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"215-NUM-DDD-TEL NAO INVALIDO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '216-NUM-TEL-FIXO NAO INVALIDO                     '.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"216-NUM-TEL-FIXO NAO INVALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '217-NUM-TEL-FAX NAO INVALIDO                      '.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"217-NUM-TEL-FAX NAO INVALIDO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '218-NUM-TEL-CEL NAO INVALIDO                      '.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"218-NUM-TEL-CEL NAO INVALIDO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '219-NOM-EMAIL NAO INVALIDO                        '.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"219-NOM-EMAIL NAO INVALIDO                        ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '220-NOM-EMAIL COM MENOS DE 10 CARACTERES          '.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"220-NOM-EMAIL COM MENOS DE 10 CARACTERES          ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '221-NUM-SUBGRUPO NAO EXISTE PARA CADASTRAR ENDEREC'.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"221-NUM-SUBGRUPO NAO EXISTE PARA CADASTRAR ENDEREC");
                /*"       10 FILLER               PIC  X(050)     VALUE          '301-NUM-PROPOSTA NAO NUMERICO OU ZERADA           '.*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"301-NUM-PROPOSTA NAO NUMERICO OU ZERADA           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '303-NUM-SUBGRUPO NAO NUMERICO                     '.*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"303-NUM-SUBGRUPO NAO NUMERICO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '304-NUM-SEQ-REG-TP04 NAO INVALIDO                 '.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"304-NUM-SEQ-REG-TP04 NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '305-NUM-CPF-REPRES NAO INVALIDO                   '.*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"305-NUM-CPF-REPRES NAO INVALIDO                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '306-NUM-CPF-REPRES COM DV INVALIDO                '.*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"306-NUM-CPF-REPRES COM DV INVALIDO                ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '307-NOM-REPRES-LEGAL EM BRANCO                    '.*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"307-NOM-REPRES-LEGAL EM BRANCO                    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '308-NOM-REPRES-LEGAL COM MENOS DE 5 CARACTERES    '.*/
                public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"308-NOM-REPRES-LEGAL COM MENOS DE 5 CARACTERES    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '309-DTA-NASC-REPRES EM BRANCO                     '.*/
                public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"309-DTA-NASC-REPRES EM BRANCO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '310-DTA-NASC-REPRES NAO VALIDA                    '.*/
                public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"310-DTA-NASC-REPRES NAO VALIDA                    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '311-DTA-NASC-REPRES NAO VALIDA                    '.*/
                public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"311-DTA-NASC-REPRES NAO VALIDA                    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '312-IND-SEXO-REPRES NAO VALIDO                    '.*/
                public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"312-IND-SEXO-REPRES NAO VALIDO                    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '313-IND-SEXO-REPRES NAO VALIDO                    '.*/
                public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"313-IND-SEXO-REPRES NAO VALIDO                    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '314-IND-EST-CIVIL NAO VALIDO                      '.*/
                public StringBasis FILLER_154 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"314-IND-EST-CIVIL NAO VALIDO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '315-VAL-RENDA-REPRES NAO VALIDO OU ZERADO         '.*/
                public StringBasis FILLER_155 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"315-VAL-RENDA-REPRES NAO VALIDO OU ZERADO         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '316-NUM-TIPO-END NAO INVALIDO                     '.*/
                public StringBasis FILLER_156 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"316-NUM-TIPO-END NAO INVALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '317-NOM-ENDERECO EM BRANCO                        '.*/
                public StringBasis FILLER_157 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"317-NOM-ENDERECO EM BRANCO                        ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '318-NOM-ENDERECO COM MENOS DE 3 CARACTERES        '.*/
                public StringBasis FILLER_158 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"318-NOM-ENDERECO COM MENOS DE 3 CARACTERES        ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '319-NOM-ENDERECO COM CARACTERES INVALIDOS         '.*/
                public StringBasis FILLER_159 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"319-NOM-ENDERECO COM CARACTERES INVALIDOS         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '320-NOM-COMPL-END NAO VALIDO                      '.*/
                public StringBasis FILLER_160 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"320-NOM-COMPL-END NAO VALIDO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '321-NOM-CIDADE EM BRANCO                          '.*/
                public StringBasis FILLER_161 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"321-NOM-CIDADE EM BRANCO                          ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '322-NOM-CIDADE COM MENOS DE 3 CARACTERES          '.*/
                public StringBasis FILLER_162 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"322-NOM-CIDADE COM MENOS DE 3 CARACTERES          ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '323-NOM-CIDADE COM CARACTERES INVALIDOS           '.*/
                public StringBasis FILLER_163 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"323-NOM-CIDADE COM CARACTERES INVALIDOS           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '324-NOM-BAIRRO NAO VALIDO                         '.*/
                public StringBasis FILLER_164 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"324-NOM-BAIRRO NAO VALIDO                         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '325-SIGLA-UF EM BRANCO                            '.*/
                public StringBasis FILLER_165 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"325-SIGLA-UF EM BRANCO                            ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '326-SIGLA-UF NAO INVALIDA                         '.*/
                public StringBasis FILLER_166 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"326-SIGLA-UF NAO INVALIDA                         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '327-NUM-CEP NAO INVALIDO                          '.*/
                public StringBasis FILLER_167 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"327-NUM-CEP NAO INVALIDO                          ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '328-NOM-EMAIL NAO INVALIDO                        '.*/
                public StringBasis FILLER_168 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"328-NOM-EMAIL NAO INVALIDO                        ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '329-NOM-EMAIL NAO INVALIDO                        '.*/
                public StringBasis FILLER_169 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"329-NOM-EMAIL NAO INVALIDO                        ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '330-NOM-EMAIL COM MENOS DE 10 CARACTERES          '.*/
                public StringBasis FILLER_170 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"330-NOM-EMAIL COM MENOS DE 10 CARACTERES          ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '331-IND-TIPO-TEL NAO INVALIDO                     '.*/
                public StringBasis FILLER_171 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"331-IND-TIPO-TEL NAO INVALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '332-NUM-DDD-TEL NAO INVALIDO                      '.*/
                public StringBasis FILLER_172 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"332-NUM-DDD-TEL NAO INVALIDO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '333-NUM-TELEFONE NAO INVALIDO                     '.*/
                public StringBasis FILLER_173 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"333-NUM-TELEFONE NAO INVALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '334-COD-CBO NAO INVALIDO                          '.*/
                public StringBasis FILLER_174 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"334-COD-CBO NAO INVALIDO                          ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '335-COD-CBO NAO EXISTE                            '.*/
                public StringBasis FILLER_175 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"335-COD-CBO NAO EXISTE                            ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '336-NUM-SUBGRUPO NAO EXISTE PARA CADASTRAR REPRESE'.*/
                public StringBasis FILLER_176 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"336-NUM-SUBGRUPO NAO EXISTE PARA CADASTRAR REPRESE");
                /*"       10 FILLER               PIC  X(050)     VALUE          '337-REPRES-LEGAL JA USADO EM OUTRA EMPRESA        '.*/
                public StringBasis FILLER_177 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"337-REPRES-LEGAL JA USADO EM OUTRA EMPRESA        ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '401-NUM-PROPOSTA NAO NUMERICO OU ZERADA           '.*/
                public StringBasis FILLER_178 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"401-NUM-PROPOSTA NAO NUMERICO OU ZERADA           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '403-NUM-SUBGRUPO NAO NUMERICO                     '.*/
                public StringBasis FILLER_179 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"403-NUM-SUBGRUPO NAO NUMERICO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '404-NUM-SEQ-REG-TP04 NAO INVALIDO                 '.*/
                public StringBasis FILLER_180 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"404-NUM-SEQ-REG-TP04 NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '405-COD-COBERTURA NAO INVALIDO                    '.*/
                public StringBasis FILLER_181 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"405-COD-COBERTURA NAO INVALIDO                    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '406-VAL-IMP-SEGURADA NAO INVALIDO                 '.*/
                public StringBasis FILLER_182 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"406-VAL-IMP-SEGURADA NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '407-VAL-PRM-INDIVID NAO INVALIDO                  '.*/
                public StringBasis FILLER_183 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"407-VAL-PRM-INDIVID NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '408-IND-TRAT-FATURA NAO INVALIDO                  '.*/
                public StringBasis FILLER_184 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"408-IND-TRAT-FATURA NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '409-IND-TRAT-PREMIO NAO INVALIDO                  '.*/
                public StringBasis FILLER_185 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"409-IND-TRAT-PREMIO NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '410-PCT-COBER-BASICA NAO INVALIDO                 '.*/
                public StringBasis FILLER_186 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"410-PCT-COBER-BASICA NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '411-VAL-LIM-MINIMO NAO INVALIDO                   '.*/
                public StringBasis FILLER_187 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"411-VAL-LIM-MINIMO NAO INVALIDO                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '412-VAL-LIM-MAXIMO NAO INVALIDO                   '.*/
                public StringBasis FILLER_188 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"412-VAL-LIM-MAXIMO NAO INVALIDO                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '413-NUM-SUBGRUPO NAO EXISTE PARA CADASTRAR COBERTU'.*/
                public StringBasis FILLER_189 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"413-NUM-SUBGRUPO NAO EXISTE PARA CADASTRAR COBERTU");
                /*"       10 FILLER               PIC  X(050)     VALUE          '501-NUM-PROPOSTA NAO NUMERICO OU ZERADA           '.*/
                public StringBasis FILLER_190 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"501-NUM-PROPOSTA NAO NUMERICO OU ZERADA           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '503-NUM-SUBGRUPO NAO NUMERICO                     '.*/
                public StringBasis FILLER_191 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"503-NUM-SUBGRUPO NAO NUMERICO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '504-NUM-SEQ-REG-TP04 NAO INVALIDO                 '.*/
                public StringBasis FILLER_192 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"504-NUM-SEQ-REG-TP04 NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '505-COD-TIPO-CORR NAO INVALIDO                    '.*/
                public StringBasis FILLER_193 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"505-COD-TIPO-CORR NAO INVALIDO                    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '506-COD-CORRETOR NAO INVALIDO                     '.*/
                public StringBasis FILLER_194 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"506-COD-CORRETOR NAO INVALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '507-COD-TIPO-CORR NAO EXISTE                      '.*/
                public StringBasis FILLER_195 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"507-COD-TIPO-CORR NAO EXISTE                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '508-PCT-COMERCIALIZ NAO INVALIDO                  '.*/
                public StringBasis FILLER_196 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"508-PCT-COMERCIALIZ NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '509-PCT-PARTICIPAC NAO INVALIDO                   '.*/
                public StringBasis FILLER_197 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"509-PCT-PARTICIPAC NAO INVALIDO                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '510-PCT-PARTIC-CORR MAIOR QUE 100%                '.*/
                public StringBasis FILLER_198 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"510-PCT-PARTIC-CORR MAIOR QUE 100%                ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '511-PCT-PARTIC-INDICADOR MAIOR QUE 100%           '.*/
                public StringBasis FILLER_199 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"511-PCT-PARTIC-INDICADOR MAIOR QUE 100%           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '512-NUM-SUBGRUPO NAO EXISTE PARA CADASTRAR CORRETO'.*/
                public StringBasis FILLER_200 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"512-NUM-SUBGRUPO NAO EXISTE PARA CADASTRAR CORRETO");
                /*"       10 FILLER               PIC  X(050)     VALUE          '513-COD-CORRETOR NAO EXISTE                       '.*/
                public StringBasis FILLER_201 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"513-COD-CORRETOR NAO EXISTE                       ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '601-NUM-PROPOSTA NAO NUMERICO OU ZERADA           '.*/
                public StringBasis FILLER_202 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"601-NUM-PROPOSTA NAO NUMERICO OU ZERADA           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '602-NUM-SEQ-REG-TP06 NAO NUMERICO                 '.*/
                public StringBasis FILLER_203 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"602-NUM-SEQ-REG-TP06 NAO NUMERICO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '603-NUM-SUBGRUPO NAO NUMERICO                     '.*/
                public StringBasis FILLER_204 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"603-NUM-SUBGRUPO NAO NUMERICO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '604-NUM-TIPO-PLANO NAO VALIDO                     '.*/
                public StringBasis FILLER_205 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"604-NUM-TIPO-PLANO NAO VALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '605-DTA-INI-VIGENCIA NAO VALIDA                   '.*/
                public StringBasis FILLER_206 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"605-DTA-INI-VIGENCIA NAO VALIDA                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '606-VAL-IMP-MORNATU NAO NUMERICO                  '.*/
                public StringBasis FILLER_207 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"606-VAL-IMP-MORNATU NAO NUMERICO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '607-VAL-IMP-MORACID NAO NUMERICO                  '.*/
                public StringBasis FILLER_208 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"607-VAL-IMP-MORACID NAO NUMERICO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '608-VAL-IMP-INVPERM NAO NUMERICO                  '.*/
                public StringBasis FILLER_209 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"608-VAL-IMP-INVPERM NAO NUMERICO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '609-VAL-IMP-AMDS NAO NUMERICO                     '.*/
                public StringBasis FILLER_210 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"609-VAL-IMP-AMDS NAO NUMERICO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '610-VAL-IMP-DH NAO NUMERICO                       '.*/
                public StringBasis FILLER_211 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"610-VAL-IMP-DH NAO NUMERICO                       ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '611-VAL-IMP-DIT NAO NUMERICO                      '.*/
                public StringBasis FILLER_212 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"611-VAL-IMP-DIT NAO NUMERICO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '612-VAL-PRM-AP NAO NUMERICO                       '.*/
                public StringBasis FILLER_213 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"612-VAL-PRM-AP NAO NUMERICO                       ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '613-VAL-LIM-INFERIOR NAO INVALIDO                 '.*/
                public StringBasis FILLER_214 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"613-VAL-LIM-INFERIOR NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '614-VAL-LIM-SUPERIOR NAO INVALIDO                 '.*/
                public StringBasis FILLER_215 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"614-VAL-LIM-SUPERIOR NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '615-VAL-LIM-INFERIOR > VAL-LIM-SUPERIOR           '.*/
                public StringBasis FILLER_216 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"615-VAL-LIM-INFERIOR > VAL-LIM-SUPERIOR           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '616-VAL-TAXA NAO VALIDA OU ZERADA                 '.*/
                public StringBasis FILLER_217 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"616-VAL-TAXA NAO VALIDA OU ZERADA                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '617-VAL-PRM-VG NAO VALIDO                         '.*/
                public StringBasis FILLER_218 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"617-VAL-PRM-VG NAO VALIDO                         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '618-QTD-SAL-MORNATU NAO NUMERICO                  '.*/
                public StringBasis FILLER_219 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"618-QTD-SAL-MORNATU NAO NUMERICO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '619-VAL-LIM-CAP-MORNATU NAO NUMERICO              '.*/
                public StringBasis FILLER_220 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"619-VAL-LIM-CAP-MORNATU NAO NUMERICO              ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '620-QTD-SAL-MORACID NAO NUMERICO                  '.*/
                public StringBasis FILLER_221 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"620-QTD-SAL-MORACID NAO NUMERICO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '621-VAL-LIM-CAP-MORACID NAO NUMERICO              '.*/
                public StringBasis FILLER_222 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"621-VAL-LIM-CAP-MORACID NAO NUMERICO              ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '622-QTD-SAL-INVPERMU NAO NUMERICO                 '.*/
                public StringBasis FILLER_223 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"622-QTD-SAL-INVPERMU NAO NUMERICO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '623-VAL-LIM-CAP-INVPERM NAO NUMERICO              '.*/
                public StringBasis FILLER_224 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"623-VAL-LIM-CAP-INVPERM NAO NUMERICO              ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '624-NUM-SUBGRUPO NAO EXISTE P/ CADASTRAR PLANOS VG'.*/
                public StringBasis FILLER_225 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"624-NUM-SUBGRUPO NAO EXISTE P/ CADASTRAR PLANOS VG");
                /*"       10 FILLER               PIC  X(050)     VALUE          '625-VAL-PRM-AP NAO VALIDO                         '.*/
                public StringBasis FILLER_226 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"625-VAL-PRM-AP NAO VALIDO                         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '626-VAL-PRM-AP E VAL-PRM-VG ZERADOS               '.*/
                public StringBasis FILLER_227 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"626-VAL-PRM-AP E VAL-PRM-VG ZERADOS               ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '701-NUM-PROPOSTA NAO NUMERICO OU ZERADA           '.*/
                public StringBasis FILLER_228 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"701-NUM-PROPOSTA NAO NUMERICO OU ZERADA           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '703-NUM-SUBGRUPO NAO NUMERICO                     '.*/
                public StringBasis FILLER_229 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"703-NUM-SUBGRUPO NAO NUMERICO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '642-QTD-SAL-MORNATU NAO NUMERICO                  '.*/
                public StringBasis FILLER_230 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"642-QTD-SAL-MORNATU NAO NUMERICO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '643-QTD-SAL-MORACID NAO NUMERICO                  '.*/
                public StringBasis FILLER_231 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"643-QTD-SAL-MORACID NAO NUMERICO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '644-QTD-SAL-INVPERM NAO NUMERICO                  '.*/
                public StringBasis FILLER_232 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"644-QTD-SAL-INVPERM NAO NUMERICO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '627-VAL-TAXA-AP NAO NUMERICO                      '.*/
                public StringBasis FILLER_233 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"627-VAL-TAXA-AP NAO NUMERICO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '628-VAL-TAXA-AP-MORACID NAO NUMERICO              '.*/
                public StringBasis FILLER_234 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"628-VAL-TAXA-AP-MORACID NAO NUMERICO              ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '629-VAL-TAXA-AP-INVPERM NAO NUMERICO              '.*/
                public StringBasis FILLER_235 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"629-VAL-TAXA-AP-INVPERM NAO NUMERICO              ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '630-VAL-TAXA-AP-AMDS NAO NUMERICO                 '.*/
                public StringBasis FILLER_236 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"630-VAL-TAXA-AP-AMDS NAO NUMERICO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '631-VAL-TAXA-AP-DH NAO NUMERICO                   '.*/
                public StringBasis FILLER_237 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"631-VAL-TAXA-AP-DH NAO NUMERICO                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '632-VAL-TAXA-AP-DIT NAO NUMERICO                  '.*/
                public StringBasis FILLER_238 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"632-VAL-TAXA-AP-DIT NAO NUMERICO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '633-VAL-CARREGA-PRINC NAO NUMERICO                '.*/
                public StringBasis FILLER_239 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"633-VAL-CARREGA-PRINC NAO NUMERICO                ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '634-VAL-CARREGA-CONJ NAO NUMERICO                 '.*/
                public StringBasis FILLER_240 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"634-VAL-CARREGA-CONJ NAO NUMERICO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '635-R6-VAL-CARREGA-FILHO NAO NUMERICO             '.*/
                public StringBasis FILLER_241 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"635-R6-VAL-CARREGA-FILHO NAO NUMERICO             ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '636-VAL-GARAN-ADIC-IEA NAO NUMERICO               '.*/
                public StringBasis FILLER_242 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"636-VAL-GARAN-ADIC-IEA NAO NUMERICO               ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '637-VAL-GARAN-ADIC-IPA NAO NUMERICO               '.*/
                public StringBasis FILLER_243 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"637-VAL-GARAN-ADIC-IPA NAO NUMERICO               ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '638-VAL-GARAN-ADIC-IPD NAO NUMERICO               '.*/
                public StringBasis FILLER_244 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"638-VAL-GARAN-ADIC-IPD NAO NUMERICO               ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '639-VAL-GARAN-ADIC-HD NAO NUMERICO                '.*/
                public StringBasis FILLER_245 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"639-VAL-GARAN-ADIC-HD NAO NUMERICO                ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '640-VAL-TAXA-DESP-ADM NAO NUMERICO                '.*/
                public StringBasis FILLER_246 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"640-VAL-TAXA-DESP-ADM NAO NUMERICO                ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '641-VAL-TAXA-IRB NAO NUMERICO                     '.*/
                public StringBasis FILLER_247 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"641-VAL-TAXA-IRB NAO NUMERICO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '645-VAL-LIM-CAP-MORNATU NAO NUMERICO              '.*/
                public StringBasis FILLER_248 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"645-VAL-LIM-CAP-MORNATU NAO NUMERICO              ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '646-VAL-LIM-CAP-MORACID NAO NUMERICO              '.*/
                public StringBasis FILLER_249 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"646-VAL-LIM-CAP-MORACID NAO NUMERICO              ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '647-VAL-LIM-CAP-INVPERM NAO NUMERICO              '.*/
                public StringBasis FILLER_250 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"647-VAL-LIM-CAP-INVPERM NAO NUMERICO              ");
                /*"    05 TAB-AUX REDEFINES W-TAB-DESCRICAO.*/
            }
            private _REDEF_VG1617B_TAB_AUX _tab_aux { get; set; }
            public _REDEF_VG1617B_TAB_AUX TAB_AUX
            {
                get { _tab_aux = new _REDEF_VG1617B_TAB_AUX(); _.Move(W_TAB_DESCRICAO, _tab_aux); VarBasis.RedefinePassValue(W_TAB_DESCRICAO, _tab_aux, W_TAB_DESCRICAO); _tab_aux.ValueChanged += () => { _.Move(_tab_aux, W_TAB_DESCRICAO); }; return _tab_aux; }
                set { VarBasis.RedefinePassValue(value, _tab_aux, W_TAB_DESCRICAO); }
            }  //Redefines
            public class _REDEF_VG1617B_TAB_AUX : VarBasis
            {
                /*"      10 TAB-DESCR-ERRO   OCCURS 191 INDEXED BY WIDX1.*/
                public ListBasis<VG1617B_TAB_DESCR_ERRO> TAB_DESCR_ERRO { get; set; } = new ListBasis<VG1617B_TAB_DESCR_ERRO>(191);
                public class VG1617B_TAB_DESCR_ERRO : VarBasis
                {
                    /*"         20 W-TB-CODIGO       PIC  9(003).*/
                    public IntBasis W_TB_CODIGO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"         20 FILLER            PIC  X(001).*/
                    public StringBasis FILLER_251 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"         20 W-TB-DESCRI-ERRO  PIC  X(046).*/
                    public StringBasis W_TB_DESCRI_ERRO { get; set; } = new StringBasis(new PIC("X", "46", "X(046)."), @"");
                    /*"    05 W-TAB-CANAL.*/

                    public VG1617B_TAB_DESCR_ERRO()
                    {
                        W_TB_CODIGO.ValueChanged += OnValueChanged;
                        FILLER_251.ValueChanged += OnValueChanged;
                        W_TB_DESCRI_ERRO.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_VG1617B_TAB_AUX()
                {
                    TAB_DESCR_ERRO.ValueChanged += OnValueChanged;
                }

            }
            public VG1617B_W_TAB_CANAL W_TAB_CANAL { get; set; } = new VG1617B_W_TAB_CANAL();
            public class VG1617B_W_TAB_CANAL : VarBasis
            {
                /*"       10 FILLER               PIC  X(015)     VALUE          '01CAIXA    '.*/
                public StringBasis FILLER_252 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"01CAIXA    ");
                /*"       10 FILLER               PIC  X(015)     VALUE          '02CAIXA SEGUROS'.*/
                public StringBasis FILLER_253 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"02CAIXA SEGUROS");
                /*"       10 FILLER               PIC  X(015)     VALUE          '03CORRETOR '.*/
                public StringBasis FILLER_254 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"03CORRETOR ");
                /*"       10 FILLER               PIC  X(015)     VALUE          '04ATM      '.*/
                public StringBasis FILLER_255 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"04ATM      ");
                /*"       10 FILLER               PIC  X(015)     VALUE          '05GITEL    '.*/
                public StringBasis FILLER_256 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"05GITEL    ");
                /*"       10 FILLER               PIC  X(015)     VALUE          '07INTERNET '.*/
                public StringBasis FILLER_257 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"07INTERNET ");
                /*"       10 FILLER               PIC  X(015)     VALUE          '08INTRANET '.*/
                public StringBasis FILLER_258 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"08INTRANET ");
                /*"    05 W-TAB-CANAL-RD      REDEFINES W-TAB-CANAL                           OCCURS 7.*/
            }
            private ListBasis<_REDEF_VG1617B_W_TAB_CANAL_RD> _w_tab_canal_rd { get; set; }
            public ListBasis<_REDEF_VG1617B_W_TAB_CANAL_RD> W_TAB_CANAL_RD
            {
                get { _w_tab_canal_rd = new ListBasis<_REDEF_VG1617B_W_TAB_CANAL_RD>(7); _.Move(W_TAB_CANAL, _w_tab_canal_rd); VarBasis.RedefinePassValue(W_TAB_CANAL, _w_tab_canal_rd, W_TAB_CANAL); _w_tab_canal_rd.ValueChanged += () => { _.Move(_w_tab_canal_rd, W_TAB_CANAL); }; return _w_tab_canal_rd; }
                set { VarBasis.RedefinePassValue(value, _w_tab_canal_rd, W_TAB_CANAL); }
            }  //Redefines
            public class _REDEF_VG1617B_W_TAB_CANAL_RD : VarBasis
            {
                /*"       10 W-TB-COD-CANAL    PIC  9(002).*/
                public IntBasis W_TB_COD_CANAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 W-TB-DESCRI-CANAL PIC  X(013).*/
                public StringBasis W_TB_DESCRI_CANAL { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"    05 W-TAB-ORIGEM.*/

                public _REDEF_VG1617B_W_TAB_CANAL_RD()
                {
                    W_TB_COD_CANAL.ValueChanged += OnValueChanged;
                    W_TB_DESCRI_CANAL.ValueChanged += OnValueChanged;
                }

            }
            public VG1617B_W_TAB_ORIGEM W_TAB_ORIGEM { get; set; } = new VG1617B_W_TAB_ORIGEM();
            public class VG1617B_W_TAB_ORIGEM : VarBasis
            {
                /*"       10 FILLER               PIC  X(023)     VALUE          '01SIGPF                '.*/
                public StringBasis FILLER_259 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"01SIGPF                ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '02CAIXA&PREVIDENCIA    '.*/
                public StringBasis FILLER_260 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"02CAIXA&PREVIDENCIA    ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '03BENEFC               '.*/
                public StringBasis FILLER_261 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"03BENEFC               ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '04SASSE                '.*/
                public StringBasis FILLER_262 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"04SASSE                ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '05CAIXA&CAPITALIZACAO  '.*/
                public StringBasis FILLER_263 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"05CAIXA&CAPITALIZACAO  ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '06MANUAL               '.*/
                public StringBasis FILLER_264 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"06MANUAL               ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '07VENDAS REMOTAS       '.*/
                public StringBasis FILLER_265 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"07VENDAS REMOTAS       ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '08INTRANET             '.*/
                public StringBasis FILLER_266 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"08INTRANET             ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '09INTERNET             '.*/
                public StringBasis FILLER_267 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"09INTERNET             ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '97REMOTA FILIAL        '.*/
                public StringBasis FILLER_268 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"97REMOTA FILIAL        ");
                /*"    05 W-TAB-ORIGEM-RD      REDEFINES W-TAB-ORIGEM                           OCCURS 10.*/
            }
            private ListBasis<_REDEF_VG1617B_W_TAB_ORIGEM_RD> _w_tab_origem_rd { get; set; }
            public ListBasis<_REDEF_VG1617B_W_TAB_ORIGEM_RD> W_TAB_ORIGEM_RD
            {
                get { _w_tab_origem_rd = new ListBasis<_REDEF_VG1617B_W_TAB_ORIGEM_RD>(10); _.Move(W_TAB_ORIGEM, _w_tab_origem_rd); VarBasis.RedefinePassValue(W_TAB_ORIGEM, _w_tab_origem_rd, W_TAB_ORIGEM); _w_tab_origem_rd.ValueChanged += () => { _.Move(_w_tab_origem_rd, W_TAB_ORIGEM); }; return _w_tab_origem_rd; }
                set { VarBasis.RedefinePassValue(value, _w_tab_origem_rd, W_TAB_ORIGEM); }
            }  //Redefines
            public class _REDEF_VG1617B_W_TAB_ORIGEM_RD : VarBasis
            {
                /*"       10 W-TB-COD-ORIGEM     PIC  9(002).*/
                public IntBasis W_TB_COD_ORIGEM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 W-TB-DESCRI-ORIGEM  PIC  X(021).*/
                public StringBasis W_TB_DESCRI_ORIGEM { get; set; } = new StringBasis(new PIC("X", "21", "X(021)."), @"");

                public _REDEF_VG1617B_W_TAB_ORIGEM_RD()
                {
                    W_TB_COD_ORIGEM.ValueChanged += OnValueChanged;
                    W_TB_DESCRI_ORIGEM.ValueChanged += OnValueChanged;
                }

            }
        }


        public Copies.LBWPF002 LBWPF002 { get; set; } = new Copies.LBWPF002();
        public Dclgens.PF087 PF087 { get; set; } = new Dclgens.PF087();
        public Dclgens.PF089 PF089 { get; set; } = new Dclgens.PF089();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.APOLICOR APOLICOR { get; set; } = new Dclgens.APOLICOR();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.BENEFICI BENEFICI { get; set; } = new Dclgens.BENEFICI();
        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.CONDITEC CONDITEC { get; set; } = new Dclgens.CONDITEC();
        public Dclgens.PLANOAGE PLANOAGE { get; set; } = new Dclgens.PLANOAGE();
        public Dclgens.PLAVAVGA PLAVAVGA { get; set; } = new Dclgens.PLAVAVGA();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.VG093 VG093 { get; set; } = new Dclgens.VG093();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.FDCOMVA FDCOMVA { get; set; } = new Dclgens.FDCOMVA();
        public Dclgens.PLANFSAL PLANFSAL { get; set; } = new Dclgens.PLANFSAL();
        public Dclgens.FAIXASAL FAIXASAL { get; set; } = new Dclgens.FAIXASAL();
        public Dclgens.PLANOFAI PLANOFAI { get; set; } = new Dclgens.PLANOFAI();
        public Dclgens.FAIXAETA FAIXAETA { get; set; } = new Dclgens.FAIXAETA();
        public Dclgens.PLANOVGA PLANOVGA { get; set; } = new Dclgens.PLANOVGA();
        public Dclgens.PLANOMUL PLANOMUL { get; set; } = new Dclgens.PLANOMUL();
        public Dclgens.PFACOPRO PFACOPRO { get; set; } = new Dclgens.PFACOPRO();
        public Dclgens.TARIBCEF TARIBCEF { get; set; } = new Dclgens.TARIBCEF();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.MOEDAS MOEDAS { get; set; } = new Dclgens.MOEDAS();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.CEDENTE CEDENTE { get; set; } = new Dclgens.CEDENTE();
        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.CLIENEMA CLIENEMA { get; set; } = new Dclgens.CLIENEMA();
        public Dclgens.VGCOBSUB VGCOBSUB { get; set; } = new Dclgens.VGCOBSUB();
        public Dclgens.VGCOBSUH VGCOBSUH { get; set; } = new Dclgens.VGCOBSUH();
        public Dclgens.AGENCCEF AGENCCEF { get; set; } = new Dclgens.AGENCCEF();
        public Dclgens.AGENCIAS AGENCIAS { get; set; } = new Dclgens.AGENCIAS();
        public Dclgens.PRODUTOR PRODUTOR { get; set; } = new Dclgens.PRODUTOR();
        public Dclgens.FUNCICEF FUNCICEF { get; set; } = new Dclgens.FUNCICEF();
        public Dclgens.CONVESIV CONVESIV { get; set; } = new Dclgens.CONVESIV();
        public Dclgens.ESCNEG ESCNEG { get; set; } = new Dclgens.ESCNEG();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PROPSSBI PROPSSBI { get; set; } = new Dclgens.PROPSSBI();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.PROFIDCO PROFIDCO { get; set; } = new Dclgens.PROFIDCO();
        public Dclgens.PROPSSVD PROPSSVD { get; set; } = new Dclgens.PROPSSVD();
        public Dclgens.PESFONE PESFONE { get; set; } = new Dclgens.PESFONE();
        public Dclgens.PESEMAIL PESEMAIL { get; set; } = new Dclgens.PESEMAIL();
        public Dclgens.IDERELAC IDERELAC { get; set; } = new Dclgens.IDERELAC();
        public Dclgens.RTPRELAC RTPRELAC { get; set; } = new Dclgens.RTPRELAC();
        public Dclgens.TPRELAC TPRELAC { get; set; } = new Dclgens.TPRELAC();
        public Dclgens.PESENDER PESENDER { get; set; } = new Dclgens.PESENDER();
        public Dclgens.TPENDER TPENDER { get; set; } = new Dclgens.TPENDER();
        public Dclgens.PESSOA PESSOA { get; set; } = new Dclgens.PESSOA();
        public Dclgens.PESJUR PESJUR { get; set; } = new Dclgens.PESJUR();
        public Dclgens.PESFIS PESFIS { get; set; } = new Dclgens.PESFIS();
        public Dclgens.BENPROPZ BENPROPZ { get; set; } = new Dclgens.BENPROPZ();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.GETPMOIM GETPMOIM { get; set; } = new Dclgens.GETPMOIM();
        public Dclgens.GE372 GE372 { get; set; } = new Dclgens.GE372();
        public Dclgens.PF062 PF062 { get; set; } = new Dclgens.PF062();
        public Dclgens.CBO CBO { get; set; } = new Dclgens.CBO();
        public VG1617B_ERROPROC ERROPROC { get; set; } = new VG1617B_ERROPROC();
        public VG1617B_CAMPOARQ CAMPOARQ { get; set; } = new VG1617B_CAMPOARQ();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOV_BENEFC_FILE_NAME_P, string RVG1617B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOV_BENEFC.SetFile(MOV_BENEFC_FILE_NAME_P);
                RVG1617B.SetFile(RVG1617B_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL-SECTION */

                M_0000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-SECTION */
        private void M_0000_PRINCIPAL_SECTION()
        {
            /*" -1577- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1578- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1579- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1582- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -1583- DISPLAY 'VG1617B-PROCESSA ARQ. BENEFICIARIO APOL. ESPEC.' */
            _.Display($"VG1617B-PROCESSA ARQ. BENEFICIARIO APOL. ESPEC.");

            /*" -1584- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -1585- DISPLAY 'VERSAO V.00: ' FUNCTION WHEN-COMPILED ' - 148.997' */

            $"VERSAO V.00: FUNCTION{_.WhenCompiled()} - 148.997"
            .Display();

            /*" -1586- DISPLAY ' ' */
            _.Display($" ");

            /*" -1593- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1594- DISPLAY '   ' */
            _.Display($"   ");

            /*" -1596- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -1598- PERFORM R0000-00-INICIALIZAR. */

            R0000_00_INICIALIZAR_SECTION();

            /*" -1600- PERFORM R0050-00-LER-MOV-BENEFCPJ */

            R0050_00_LER_MOV_BENEFCPJ_SECTION();

            /*" -1601- IF (W-FIM-MVTO-BENEFC EQUAL 'FIM' ) */

            if ((WAREA_AUXILIAR.W_FIM_MVTO_BENEFC == "FIM"))
            {

                /*" -1602- DISPLAY 'MOVIMENTO DE BENEFICIARIOS VAZIO ' */
                _.Display($"MOVIMENTO DE BENEFICIARIOS VAZIO ");

                /*" -1603- DISPLAY 'MOVIMENTO DE BENEFICIARIOS VAZIO ' */
                _.Display($"MOVIMENTO DE BENEFICIARIOS VAZIO ");

                /*" -1604- DISPLAY 'MOVIMENTO DE BENEFICIARIOS VAZIO ' */
                _.Display($"MOVIMENTO DE BENEFICIARIOS VAZIO ");

                /*" -1605- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1607- END-IF. */
            }


            /*" -1609- PERFORM R0117-00-OBTER-NSAS-MOVTO */

            R0117_00_OBTER_NSAS_MOVTO_SECTION();

            /*" -1612- PERFORM R0200-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MVTO-BENEFC EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MVTO_BENEFC == "FIM"))
            {

                R0200_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -1613- IF (W-IND-1 > ZEROS) */

            if ((WAREA_AUXILIAR.W_IND_1 > 00))
            {

                /*" -1614- PERFORM R9980-00-GERAR-RELATORIO */

                R9980_00_GERAR_RELATORIO_SECTION();

                /*" -1616- END-IF. */
            }


            /*" -1616- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }

        [StopWatch]
        /*" R0000-00-INICIALIZAR-SECTION */
        private void R0000_00_INICIALIZAR_SECTION()
        {
            /*" -1622- MOVE 'R0000-00-INICIALIZAR' TO PARAGRAFO. */
            _.Move("R0000-00-INICIALIZAR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1624- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1625- OPEN INPUT MOV-BENEFC. */
            MOV_BENEFC.Open(REG_BENEFICIARIO);

            /*" -1627- OPEN OUTPUT RVG1617B. */
            RVG1617B.Open(REG_RVG1617B);

            /*" -1629- PERFORM R0005-00-OBTER-DT-SISTEMA. */

            R0005_00_OBTER_DT_SISTEMA_SECTION();

            /*" -1631- PERFORM R0118-00-CRITICA-ARQ-PROC. */

            R0118_00_CRITICA_ARQ_PROC_SECTION();

            /*" -1633- PERFORM R0010-00-GERAR-TAB-ERROS. */

            R0010_00_GERAR_TAB_ERROS_SECTION();

            /*" -1633- PERFORM R0020-00-GERAR-TAB-CAMPOS. */

            R0020_00_GERAR_TAB_CAMPOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_SAIDA*/

        [StopWatch]
        /*" R0005-00-OBTER-DT-SISTEMA-SECTION */
        private void R0005_00_OBTER_DT_SISTEMA_SECTION()
        {
            /*" -1643- MOVE 'R0005-00-OBTER-DT-SISTEMA' TO PARAGRAFO. */
            _.Move("R0005-00-OBTER-DT-SISTEMA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1645- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1647- MOVE 'VG' TO SISTEMAS-IDE-SISTEMA. */
            _.Move("VG", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -1655- PERFORM R0005_00_OBTER_DT_SISTEMA_DB_SELECT_1 */

            R0005_00_OBTER_DT_SISTEMA_DB_SELECT_1();

            /*" -1658- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1659- DISPLAY 'VG1617B - FIM ANORMAL' */
                _.Display($"VG1617B - FIM ANORMAL");

                /*" -1660- DISPLAY '          ERRO ACESSO TAB SISTEMAS  ' */
                _.Display($"          ERRO ACESSO TAB SISTEMAS  ");

                /*" -1661- DISPLAY '         ' SQLCODE */
                _.Display($"         {DB.SQLCODE}");

                /*" -1662- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1664- END-IF. */
            }


            /*" -1666- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -1667- MOVE W-DIA-MOVABE1 TO W-DIA-MOVABEI1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE1, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABEI1);

            /*" -1668- MOVE W-MES-MOVABE1 TO W-MES-MOVABEI1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE1, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABEI1);

            /*" -1670- MOVE W-ANO-MOVABE1 TO W-ANO-MOVABEI1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE1, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABEI1);

            /*" -1673- MOVE '/' TO W-BARRAI1 W-BARRAI2. */
            _.Move("/", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRAI1);
            _.Move("/", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRAI2);


            /*" -1673- DISPLAY 'DATA DO MOVIMENTO ->>> ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DATA DO MOVIMENTO ->>> {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

        }

        [StopWatch]
        /*" R0005-00-OBTER-DT-SISTEMA-DB-SELECT-1 */
        public void R0005_00_OBTER_DT_SISTEMA_DB_SELECT_1()
        {
            /*" -1655- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO - 1 DAY INTO :SISTEMAS-DATA-MOV-ABERTO, :WS-DATA-MOV-ABERTO-1D FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

            var r0005_00_OBTER_DT_SISTEMA_DB_SELECT_1_Query1 = new R0005_00_OBTER_DT_SISTEMA_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0005_00_OBTER_DT_SISTEMA_DB_SELECT_1_Query1.Execute(r0005_00_OBTER_DT_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WS_DATA_MOV_ABERTO_1D, WS_DATA_MOV_ABERTO_1D);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0005_SAIDA*/

        [StopWatch]
        /*" R0010-00-GERAR-TAB-ERROS-SECTION */
        private void R0010_00_GERAR_TAB_ERROS_SECTION()
        {
            /*" -1682- MOVE 'R0010-00-GERAR-TAB-ERROS' TO PARAGRAFO. */
            _.Move("R0010-00-GERAR-TAB-ERROS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1684- MOVE 'GERAR TABELA ERRO' TO COMANDO. */
            _.Move("GERAR TABELA ERRO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1686- SET I01 TO 1. */
            I01.Value = 1;

            /*" -1688- PERFORM R0011-00-DECLARE-ERRO-PROC. */

            R0011_00_DECLARE_ERRO_PROC_SECTION();

            /*" -1690- PERFORM R0012-00-FETCH-ERRO-PROC. */

            R0012_00_FETCH_ERRO_PROC_SECTION();

            /*" -1691- IF (W-FIM-ERROS NOT EQUAL SPACES) */

            if ((!WAREA_AUXILIAR.W_FIM_ERROS.IsEmpty()))
            {

                /*" -1692- DISPLAY 'R0010 - PROBLEMA NO FETCH ERRO-PROC ' SQLCODE */
                _.Display($"R0010 - PROBLEMA NO FETCH ERRO-PROC {DB.SQLCODE}");

                /*" -1693- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1695- END-IF. */
            }


            /*" -1696- PERFORM R0013-00-CARREGA-ERRO-PROC UNTIL W-FIM-ERROS EQUAL 'SIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_ERROS == "SIM"))
            {

                R0013_00_CARREGA_ERRO_PROC_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_SAIDA*/

        [StopWatch]
        /*" R0011-00-DECLARE-ERRO-PROC-SECTION */
        private void R0011_00_DECLARE_ERRO_PROC_SECTION()
        {
            /*" -1705- MOVE 'R0011-00-DECLARE-ERRO-PROC' TO PARAGRAFO. */
            _.Move("R0011-00-DECLARE-ERRO-PROC", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1707- MOVE 'DECLARE TABELA ERRO' TO COMANDO. */
            _.Move("DECLARE TABELA ERRO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1714- PERFORM R0011_00_DECLARE_ERRO_PROC_DB_DECLARE_1 */

            R0011_00_DECLARE_ERRO_PROC_DB_DECLARE_1();

            /*" -1716- PERFORM R0011_00_DECLARE_ERRO_PROC_DB_OPEN_1 */

            R0011_00_DECLARE_ERRO_PROC_DB_OPEN_1();

            /*" -1719- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1720- DISPLAY 'VG1617B - FIM ANORMAL' */
                _.Display($"VG1617B - FIM ANORMAL");

                /*" -1721- DISPLAY '          ERRO SELECT TAB PF_ERRO_PROC_PROPOST' */
                _.Display($"          ERRO SELECT TAB PF_ERRO_PROC_PROPOST");

                /*" -1723- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1724- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1724- END-IF. */
            }


        }

        [StopWatch]
        /*" R0011-00-DECLARE-ERRO-PROC-DB-DECLARE-1 */
        public void R0011_00_DECLARE_ERRO_PROC_DB_DECLARE_1()
        {
            /*" -1714- EXEC SQL DECLARE ERROPROC CURSOR FOR SELECT NUM_ERRO_PROPOSTA, DES_ERRO_PROPOSTA FROM SEGUROS.PF_ERRO_PROC_PROPOSTA ORDER BY NUM_ERRO_PROPOSTA FETCH FIRST 500 ROWS ONLY END-EXEC. */
            ERROPROC = new VG1617B_ERROPROC(false);
            string GetQuery_ERROPROC()
            {
                var query = @$"SELECT NUM_ERRO_PROPOSTA
							, 
							DES_ERRO_PROPOSTA 
							FROM SEGUROS.PF_ERRO_PROC_PROPOSTA 
							ORDER BY NUM_ERRO_PROPOSTA 
							FETCH FIRST 500 ROWS ONLY";

                return query;
            }
            ERROPROC.GetQueryEvent += GetQuery_ERROPROC;

        }

        [StopWatch]
        /*" R0011-00-DECLARE-ERRO-PROC-DB-OPEN-1 */
        public void R0011_00_DECLARE_ERRO_PROC_DB_OPEN_1()
        {
            /*" -1716- EXEC SQL OPEN ERROPROC END-EXEC. */

            ERROPROC.Open();

        }

        [StopWatch]
        /*" R0021-00-DECLARE-CAMPO-ARQ-DB-DECLARE-1 */
        public void R0021_00_DECLARE_CAMPO_ARQ_DB_DECLARE_1()
        {
            /*" -1813- EXEC SQL DECLARE CAMPOARQ CURSOR FOR SELECT NUM_DET_ARQ_PROPOSTA, NOM_DET_ARQ_PROPOSTA FROM SEGUROS.PF_DET_ARQ_PROPOSTA WHERE NUM_DET_ARQ_PROPOSTA BETWEEN 200 AND 299 ORDER BY NUM_DET_ARQ_PROPOSTA END-EXEC. */
            CAMPOARQ = new VG1617B_CAMPOARQ(false);
            string GetQuery_CAMPOARQ()
            {
                var query = @$"SELECT NUM_DET_ARQ_PROPOSTA
							, 
							NOM_DET_ARQ_PROPOSTA 
							FROM SEGUROS.PF_DET_ARQ_PROPOSTA 
							WHERE NUM_DET_ARQ_PROPOSTA BETWEEN 200 AND 299 
							ORDER BY NUM_DET_ARQ_PROPOSTA";

                return query;
            }
            CAMPOARQ.GetQueryEvent += GetQuery_CAMPOARQ;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0011_SAIDA*/

        [StopWatch]
        /*" R0012-00-FETCH-ERRO-PROC-SECTION */
        private void R0012_00_FETCH_ERRO_PROC_SECTION()
        {
            /*" -1734- MOVE 'R0012-00-FETCH-ERRO-PROC' TO PARAGRAFO. */
            _.Move("R0012-00-FETCH-ERRO-PROC", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1736- MOVE 'FETCH ERRO PROC' TO COMANDO. */
            _.Move("FETCH ERRO PROC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1738- INITIALIZE PF089-DES-ERRO-PROPOSTA. */
            _.Initialize(
                PF089.DCLPF_ERRO_PROC_PROPOSTA.PF089_DES_ERRO_PROPOSTA
            );

            /*" -1742- PERFORM R0012_00_FETCH_ERRO_PROC_DB_FETCH_1 */

            R0012_00_FETCH_ERRO_PROC_DB_FETCH_1();

            /*" -1745- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1746- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -1747- MOVE 'SIM' TO W-FIM-ERROS */
                    _.Move("SIM", WAREA_AUXILIAR.W_FIM_ERROS);

                    /*" -1747- PERFORM R0012_00_FETCH_ERRO_PROC_DB_CLOSE_1 */

                    R0012_00_FETCH_ERRO_PROC_DB_CLOSE_1();

                    /*" -1749- ELSE */
                }
                else
                {


                    /*" -1750- DISPLAY 'VG1617B - FIM ANORMAL' */
                    _.Display($"VG1617B - FIM ANORMAL");

                    /*" -1751- DISPLAY '     ERRO FETCH PF_ERRO_PROC_PROPOST' */
                    _.Display($"     ERRO FETCH PF_ERRO_PROC_PROPOST");

                    /*" -1753- DISPLAY '     SQLCODE......................  ' SQLCODE */
                    _.Display($"     SQLCODE......................  {DB.SQLCODE}");

                    /*" -1754- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1755- END-IF */
                }


                /*" -1755- END-IF. */
            }


        }

        [StopWatch]
        /*" R0012-00-FETCH-ERRO-PROC-DB-FETCH-1 */
        public void R0012_00_FETCH_ERRO_PROC_DB_FETCH_1()
        {
            /*" -1742- EXEC SQL FETCH ERROPROC INTO :PF089-NUM-ERRO-PROPOSTA, :PF089-DES-ERRO-PROPOSTA END-EXEC. */

            if (ERROPROC.Fetch())
            {
                _.Move(ERROPROC.PF089_NUM_ERRO_PROPOSTA, PF089.DCLPF_ERRO_PROC_PROPOSTA.PF089_NUM_ERRO_PROPOSTA);
                _.Move(ERROPROC.PF089_DES_ERRO_PROPOSTA, PF089.DCLPF_ERRO_PROC_PROPOSTA.PF089_DES_ERRO_PROPOSTA);
            }

        }

        [StopWatch]
        /*" R0012-00-FETCH-ERRO-PROC-DB-CLOSE-1 */
        public void R0012_00_FETCH_ERRO_PROC_DB_CLOSE_1()
        {
            /*" -1747- EXEC SQL CLOSE ERROPROC END-EXEC */

            ERROPROC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0012_SAIDA*/

        [StopWatch]
        /*" R0013-00-CARREGA-ERRO-PROC-SECTION */
        private void R0013_00_CARREGA_ERRO_PROC_SECTION()
        {
            /*" -1764- MOVE 'R0013-00-CARREGA-ERRO-PROC' TO PARAGRAFO. */
            _.Move("R0013-00-CARREGA-ERRO-PROC", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1766- MOVE 'CARREGA ERRO PROC' TO COMANDO. */
            _.Move("CARREGA ERRO PROC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1769- MOVE PF089-DES-ERRO-PROPOSTA-TEXT TO W-TB-DESC-ERRO (PF089-NUM-ERRO-PROPOSTA). */
            _.Move(PF089.DCLPF_ERRO_PROC_PROPOSTA.PF089_DES_ERRO_PROPOSTA.PF089_DES_ERRO_PROPOSTA_TEXT, W_TAB_ERRO.W_TAB_ERRO_REG[PF089.DCLPF_ERRO_PROC_PROPOSTA.PF089_NUM_ERRO_PROPOSTA].W_TB_DESC_ERRO);

            /*" -1771- SET I01 UP BY 1. */
            I01.Value += 1;

            /*" -1771- PERFORM R0012-00-FETCH-ERRO-PROC. */

            R0012_00_FETCH_ERRO_PROC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0013_SAIDA*/

        [StopWatch]
        /*" R0020-00-GERAR-TAB-CAMPOS-SECTION */
        private void R0020_00_GERAR_TAB_CAMPOS_SECTION()
        {
            /*" -1780- MOVE 'R0020-00-GERAR-TAB-CAMPOS' TO PARAGRAFO. */
            _.Move("R0020-00-GERAR-TAB-CAMPOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1782- MOVE 'GERAR TABELA CAMPOS' TO COMANDO. */
            _.Move("GERAR TABELA CAMPOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1783- MOVE SPACES TO W-FIM-ERROS */
            _.Move("", WAREA_AUXILIAR.W_FIM_ERROS);

            /*" -1785- SET I02 TO 1. */
            I02.Value = 1;

            /*" -1787- PERFORM R0021-00-DECLARE-CAMPO-ARQ. */

            R0021_00_DECLARE_CAMPO_ARQ_SECTION();

            /*" -1789- PERFORM R0022-00-FETCH-CAMPO-ARQ. */

            R0022_00_FETCH_CAMPO_ARQ_SECTION();

            /*" -1790- IF (W-FIM-ERROS NOT EQUAL SPACES) */

            if ((!WAREA_AUXILIAR.W_FIM_ERROS.IsEmpty()))
            {

                /*" -1791- DISPLAY 'R0020 - PROBLEMA NO FETCH CAMPO-ARQ ' SQLCODE */
                _.Display($"R0020 - PROBLEMA NO FETCH CAMPO-ARQ {DB.SQLCODE}");

                /*" -1792- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1794- END-IF. */
            }


            /*" -1795- PERFORM R0023-00-CARREGA-CAMPO-ARQ UNTIL W-FIM-ERROS EQUAL 'SIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_ERROS == "SIM"))
            {

                R0023_00_CARREGA_CAMPO_ARQ_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_SAIDA*/

        [StopWatch]
        /*" R0021-00-DECLARE-CAMPO-ARQ-SECTION */
        private void R0021_00_DECLARE_CAMPO_ARQ_SECTION()
        {
            /*" -1804- MOVE 'R0021-00-DECLARE-CAMPO-ARQ' TO PARAGRAFO. */
            _.Move("R0021-00-DECLARE-CAMPO-ARQ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1806- MOVE 'DECLARE TABELA CAMPO' TO COMANDO. */
            _.Move("DECLARE TABELA CAMPO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1813- PERFORM R0021_00_DECLARE_CAMPO_ARQ_DB_DECLARE_1 */

            R0021_00_DECLARE_CAMPO_ARQ_DB_DECLARE_1();

            /*" -1815- PERFORM R0021_00_DECLARE_CAMPO_ARQ_DB_OPEN_1 */

            R0021_00_DECLARE_CAMPO_ARQ_DB_OPEN_1();

            /*" -1818- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1819- DISPLAY 'VG1617B - FIM ANORMAL' */
                _.Display($"VG1617B - FIM ANORMAL");

                /*" -1820- DISPLAY '          ERRO SELECT TAB PF_DET_ARQ_PROPOSTA' */
                _.Display($"          ERRO SELECT TAB PF_DET_ARQ_PROPOSTA");

                /*" -1822- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1823- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1823- END-IF. */
            }


        }

        [StopWatch]
        /*" R0021-00-DECLARE-CAMPO-ARQ-DB-OPEN-1 */
        public void R0021_00_DECLARE_CAMPO_ARQ_DB_OPEN_1()
        {
            /*" -1815- EXEC SQL OPEN CAMPOARQ END-EXEC. */

            CAMPOARQ.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0021_SAIDA*/

        [StopWatch]
        /*" R0022-00-FETCH-CAMPO-ARQ-SECTION */
        private void R0022_00_FETCH_CAMPO_ARQ_SECTION()
        {
            /*" -1833- MOVE 'R0022-00-FETCH-CAMPO-ARQ' TO PARAGRAFO. */
            _.Move("R0022-00-FETCH-CAMPO-ARQ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1835- MOVE 'FETCH CAMPO ARQUIVO' TO COMANDO. */
            _.Move("FETCH CAMPO ARQUIVO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1839- PERFORM R0022_00_FETCH_CAMPO_ARQ_DB_FETCH_1 */

            R0022_00_FETCH_CAMPO_ARQ_DB_FETCH_1();

            /*" -1842- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1843- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -1844- MOVE 'SIM' TO W-FIM-ERROS */
                    _.Move("SIM", WAREA_AUXILIAR.W_FIM_ERROS);

                    /*" -1844- PERFORM R0022_00_FETCH_CAMPO_ARQ_DB_CLOSE_1 */

                    R0022_00_FETCH_CAMPO_ARQ_DB_CLOSE_1();

                    /*" -1846- ELSE */
                }
                else
                {


                    /*" -1847- DISPLAY 'VG1617B - FIM ANORMAL' */
                    _.Display($"VG1617B - FIM ANORMAL");

                    /*" -1848- DISPLAY '     ERRO FETCH PF_DET_ARQ_PROPOSTA' */
                    _.Display($"     ERRO FETCH PF_DET_ARQ_PROPOSTA");

                    /*" -1850- DISPLAY '     SQLCODE......................  ' SQLCODE */
                    _.Display($"     SQLCODE......................  {DB.SQLCODE}");

                    /*" -1851- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1852- END-IF */
                }


                /*" -1852- END-IF. */
            }


        }

        [StopWatch]
        /*" R0022-00-FETCH-CAMPO-ARQ-DB-FETCH-1 */
        public void R0022_00_FETCH_CAMPO_ARQ_DB_FETCH_1()
        {
            /*" -1839- EXEC SQL FETCH CAMPOARQ INTO :PF088-NUM-CAMPO-PROPOSTA, :PF088-NOM-DET-ARQ-PROPOSTA END-EXEC. */

            if (CAMPOARQ.Fetch())
            {
                _.Move(CAMPOARQ.PF088_NUM_CAMPO_PROPOSTA, DCLPF_DET_ARQ_PROPOSTA.PF088_NUM_CAMPO_PROPOSTA);
                _.Move(CAMPOARQ.PF088_NOM_DET_ARQ_PROPOSTA, DCLPF_DET_ARQ_PROPOSTA.PF088_NOM_DET_ARQ_PROPOSTA);
            }

        }

        [StopWatch]
        /*" R0022-00-FETCH-CAMPO-ARQ-DB-CLOSE-1 */
        public void R0022_00_FETCH_CAMPO_ARQ_DB_CLOSE_1()
        {
            /*" -1844- EXEC SQL CLOSE CAMPOARQ END-EXEC */

            CAMPOARQ.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0022_SAIDA*/

        [StopWatch]
        /*" R0023-00-CARREGA-CAMPO-ARQ-SECTION */
        private void R0023_00_CARREGA_CAMPO_ARQ_SECTION()
        {
            /*" -1861- MOVE 'R0023-00-CARREGA-CAMPO-ARQ' TO PARAGRAFO. */
            _.Move("R0023-00-CARREGA-CAMPO-ARQ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1863- MOVE 'CARREGA CAMPO ARQUIVO' TO COMANDO. */
            _.Move("CARREGA CAMPO ARQUIVO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1866- MOVE PF088-NOM-DET-ARQ-PROPOSTA TO W-TB-NOM-CAMPO (PF088-NUM-CAMPO-PROPOSTA). */
            _.Move(DCLPF_DET_ARQ_PROPOSTA.PF088_NOM_DET_ARQ_PROPOSTA, W_TAB_CAMPO.W_TAB_CAMPO_REG[DCLPF_DET_ARQ_PROPOSTA.PF088_NUM_CAMPO_PROPOSTA].W_TB_NOM_CAMPO);

            /*" -1868- SET I02 UP BY 1. */
            I02.Value += 1;

            /*" -1868- PERFORM R0022-00-FETCH-CAMPO-ARQ. */

            R0022_00_FETCH_CAMPO_ARQ_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0023_SAIDA*/

        [StopWatch]
        /*" R0050-00-LER-MOV-BENEFCPJ-SECTION */
        private void R0050_00_LER_MOV_BENEFCPJ_SECTION()
        {
            /*" -1877- MOVE 'R0050-00-LER-MOV-BENEFC' TO PARAGRAFO. */
            _.Move("R0050-00-LER-MOV-BENEFC", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1879- MOVE 'READ' TO COMANDO. */
            _.Move("READ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1880- READ MOV-BENEFC AT END */
            try
            {
                MOV_BENEFC.Read(() =>
                {

                    /*" -1882- MOVE 'FIM' TO W-FIM-MVTO-BENEFC */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MVTO_BENEFC);

                    /*" -1883- NOT AT END */
                }, () =>
                {

                    /*" -1885- ADD 1 TO W-LIDO-MOVTO-BENEFC W-AC-CONTROLE */
                    WAREA_AUXILIAR.W_LIDO_MOVTO_BENEFC.Value = WAREA_AUXILIAR.W_LIDO_MOVTO_BENEFC + 1;
                    WAREA_AUXILIAR.W_AC_CONTROLE.Value = WAREA_AUXILIAR.W_AC_CONTROLE + 1;

                    /*" -1887- END-READ. */
                });

                _.Move(MOV_BENEFC.Value, REG_BENEFICIARIO);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1898- UNSTRING REG-BENEFICIARIO DELIMITED BY ';' INTO RE-NOM-SEGURADO RE-NUM-CPF-SEG RE-NOM-BENEFIC RE-GRAU-PARENTESCO RE-PERC-PARTICIPA RE-NUM-CPF-BENFC RE-NUM-APOLICE RE-COD-SUBGRUPO RE-RESTO. */
            _.Unstring(REG_BENEFICIARIO,
                [new UnstringDelimitedParameter(";")],
                [new UnstringIntoParameter(REG_RE_BENEFIC.RE_NOM_SEGURADO)
                ,new UnstringIntoParameter(REG_RE_BENEFIC.RE_NUM_CPF_SEG)
                ,new UnstringIntoParameter(REG_RE_BENEFIC.RE_NOM_BENEFIC)
                ,new UnstringIntoParameter(REG_RE_BENEFIC.RE_GRAU_PARENTESCO)
                ,new UnstringIntoParameter(REG_RE_BENEFIC.RE_PERC_PARTICIPA)
                ,new UnstringIntoParameter(REG_RE_BENEFIC.RE_NUM_CPF_BENFC)
                ,new UnstringIntoParameter(REG_RE_BENEFIC.RE_NUM_APOLICE)
                ,new UnstringIntoParameter(REG_RE_BENEFIC.RE_COD_SUBGRUPO)
                ,new UnstringIntoParameter(REG_RE_BENEFIC.RE_RESTO)
            ]);

            /*" -1900- IF (W-LIDO-MOVTO-BENEFC EQUAL 1) AND (RE-NOM-SEGURADO EQUAL 'SEGURADO' ) */

            if ((WAREA_AUXILIAR.W_LIDO_MOVTO_BENEFC == 1) && (REG_RE_BENEFIC.RE_NOM_SEGURADO == "SEGURADO"))
            {

                /*" -1901- SUBTRACT 1 FROM W-LIDO-MOVTO-BENEFC */
                WAREA_AUXILIAR.W_LIDO_MOVTO_BENEFC.Value = WAREA_AUXILIAR.W_LIDO_MOVTO_BENEFC - 1;

                /*" -1902- GO TO R0050-00-LER-MOV-BENEFCPJ */
                new Task(() => R0050_00_LER_MOV_BENEFCPJ_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1902- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0117-00-OBTER-NSAS-MOVTO-SECTION */
        private void R0117_00_OBTER_NSAS_MOVTO_SECTION()
        {
            /*" -1912- MOVE 'R0117-00-OBTER-NSAS-MOVTO' TO PARAGRAFO. */
            _.Move("R0117-00-OBTER-NSAS-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1914- MOVE 'SELECT MAX ARQUIVOS-BENEFC' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-BENEFC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1915- MOVE 'BENEFAE' TO ARQSIVPF-SIGLA-ARQUIVO */
            _.Move("BENEFAE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -1917- MOVE 5 TO ARQSIVPF-SISTEMA-ORIGEM */
            _.Move(5, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -1924- PERFORM R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1 */

            R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1();

            /*" -1927- IF (SQLCODE EQUAL ZEROS) */

            if ((DB.SQLCODE == 00))
            {

                /*" -1928- MOVE ARQSIVPF-NSAS-SIVPF TO W-NSAS-FILIAL */
                _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS_FILIAL);

                /*" -1929- ELSE */
            }
            else
            {


                /*" -1930- DISPLAY 'VG1617B - FIM ANORMAL' */
                _.Display($"VG1617B - FIM ANORMAL");

                /*" -1932- DISPLAY '          ERRO ACESSO TABELA ARQUIVOS-SIVPF ' SQLCODE */
                _.Display($"          ERRO ACESSO TABELA ARQUIVOS-SIVPF {DB.SQLCODE}");

                /*" -1934- DISPLAY '          SIGLA DO ARQUIVO................. ' ARQSIVPF-SIGLA-ARQUIVO */
                _.Display($"          SIGLA DO ARQUIVO................. {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -1936- DISPLAY '          SISTEMA ORIGEM................... ' ARQSIVPF-SISTEMA-ORIGEM */
                _.Display($"          SISTEMA ORIGEM................... {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM}");

                /*" -1937- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1939- END-IF. */
            }


            /*" -1940- MOVE SISTEMAS-DATA-MOV-ABERTO TO ARQSIVPF-DATA-GERACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -1941- MOVE SISTEMAS-DATA-MOV-ABERTO TO ARQSIVPF-DATA-PROCESSAMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO);

            /*" -1943- MOVE ZEROS TO ARQSIVPF-QTDE-REG-GER */
            _.Move(0, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -1943- PERFORM R2060-00-ATUALIZA-ARQSIVPF. */

            R2060_00_ATUALIZA_ARQSIVPF_SECTION();

        }

        [StopWatch]
        /*" R0117-00-OBTER-NSAS-MOVTO-DB-SELECT-1 */
        public void R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1()
        {
            /*" -1924- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) + 1 INTO :ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

            var r0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1 = new R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1()
            {
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
            };

            var executed_1 = R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1.Execute(r0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_NSAS_SIVPF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0117_SAIDA*/

        [StopWatch]
        /*" R0118-00-CRITICA-ARQ-PROC-SECTION */
        private void R0118_00_CRITICA_ARQ_PROC_SECTION()
        {
            /*" -1952- MOVE 'R0118-00-CRITICA-ARQ-PROC' TO PARAGRAFO. */
            _.Move("R0118-00-CRITICA-ARQ-PROC", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1954- MOVE 'SELECT DATA ARQUIVOS-BENEFC' TO COMANDO. */
            _.Move("SELECT DATA ARQUIVOS-BENEFC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1955- MOVE 'BENEFAE' TO ARQSIVPF-SIGLA-ARQUIVO */
            _.Move("BENEFAE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -1957- MOVE 5 TO ARQSIVPF-SISTEMA-ORIGEM */
            _.Move(5, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -1964- PERFORM R0118_00_CRITICA_ARQ_PROC_DB_SELECT_1 */

            R0118_00_CRITICA_ARQ_PROC_DB_SELECT_1();

            /*" -1967- IF (SQLCODE EQUAL ZEROS AND +100) */

            if ((DB.SQLCODE.In("00", "+100")))
            {

                /*" -1968- DISPLAY 'VG1617B - FIM ANORMAL' */
                _.Display($"VG1617B - FIM ANORMAL");

                /*" -1970- DISPLAY '          ERRO ACESSO TABELA ARQUIVOS-SIVPF ' SQLCODE */
                _.Display($"          ERRO ACESSO TABELA ARQUIVOS-SIVPF {DB.SQLCODE}");

                /*" -1972- DISPLAY '          SIGLA DO ARQUIVO................. ' ARQSIVPF-SIGLA-ARQUIVO */
                _.Display($"          SIGLA DO ARQUIVO................. {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -1974- DISPLAY '          SISTEMA ORIGEM................... ' ARQSIVPF-SISTEMA-ORIGEM */
                _.Display($"          SISTEMA ORIGEM................... {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM}");

                /*" -1975- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1977- END-IF. */
            }


            /*" -1979- IF (ARQSIVPF-DATA-PROCESSAMENTO NOT < SISTEMAS-DATA-MOV-ABERTO) */

            if ((ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO! < SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO))
            {

                /*" -1980- DISPLAY 'VG1617B - FIM ANORMAL' */
                _.Display($"VG1617B - FIM ANORMAL");

                /*" -1982- DISPLAY 'ARQUIVO JAH PROCESSADO EM ' ARQSIVPF-DATA-PROCESSAMENTO */
                _.Display($"ARQUIVO JAH PROCESSADO EM {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO}");

                /*" -1983- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1983- END-IF. */
            }


        }

        [StopWatch]
        /*" R0118-00-CRITICA-ARQ-PROC-DB-SELECT-1 */
        public void R0118_00_CRITICA_ARQ_PROC_DB_SELECT_1()
        {
            /*" -1964- EXEC SQL SELECT VALUE(MAX(DATA_PROCESSAMENTO), '0001-01-01' ) INTO :ARQSIVPF-DATA-PROCESSAMENTO FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

            var r0118_00_CRITICA_ARQ_PROC_DB_SELECT_1_Query1 = new R0118_00_CRITICA_ARQ_PROC_DB_SELECT_1_Query1()
            {
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
            };

            var executed_1 = R0118_00_CRITICA_ARQ_PROC_DB_SELECT_1_Query1.Execute(r0118_00_CRITICA_ARQ_PROC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0118_SAIDA*/

        [StopWatch]
        /*" R0200-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0200_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -1992- MOVE 'R0200-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0200-00-PROCESSA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1994- MOVE 'PROCESSAR MOVIMENTO        ' TO COMANDO. */
            _.Move("PROCESSAR MOVIMENTO        ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1996- PERFORM R0270-00-INICIALIZAR-AREAS. */

            R0270_00_INICIALIZAR_AREAS_SECTION();

            /*" -2000- PERFORM R0310-00-MOVTO-SEG-BENEF UNTIL W-FIM-MVTO-BENEFC EQUAL 'FIM' OR RE-NUM-CPF-SEG NOT EQUAL W-NUM-CPF-SEG-ANT. */

            while (!(WAREA_AUXILIAR.W_FIM_MVTO_BENEFC == "FIM" || REG_RE_BENEFIC.RE_NUM_CPF_SEG != WAREA_AUXILIAR.W_NUM_CPF_SEG_ANT))
            {

                R0310_00_MOVTO_SEG_BENEF_SECTION();
            }

            /*" -2002- IF (WS-PERC-PART-TOTAL > 100) */

            if ((WS_PERC_PART_TOTAL > 100))
            {

                /*" -2003- MOVE 034 TO WS-COD-ERRO */
                _.Move(034, WS_COD_ERRO);

                /*" -2004- MOVE 204 TO WS-COD-CAMPO */
                _.Move(204, WS_COD_CAMPO);

                /*" -2005- MOVE WS-PERC-PART-TOTAL TO WS-DES-CONTEUDO */
                _.Move(WS_PERC_PART_TOTAL, WS_DES_CONTEUDO);

                /*" -2006- MOVE 5 TO WS-NUM-SEQ-ARQ */
                _.Move(5, WS_NUM_SEQ_ARQ);

                /*" -2007- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2008- MOVE 2 TO W-CRITICA-BENEFIC */
                _.Move(2, WREA88.W_CRITICA_BENEFIC);

                /*" -2010- END-IF */
            }


            /*" -2012- IF (WS-PERC-PART-TOTAL < 100) */

            if ((WS_PERC_PART_TOTAL < 100))
            {

                /*" -2013- MOVE 035 TO WS-COD-ERRO */
                _.Move(035, WS_COD_ERRO);

                /*" -2014- MOVE 204 TO WS-COD-CAMPO */
                _.Move(204, WS_COD_CAMPO);

                /*" -2015- MOVE WS-PERC-PART-TOTAL TO WS-DES-CONTEUDO */
                _.Move(WS_PERC_PART_TOTAL, WS_DES_CONTEUDO);

                /*" -2016- MOVE 5 TO WS-NUM-SEQ-ARQ */
                _.Move(5, WS_NUM_SEQ_ARQ);

                /*" -2017- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2018- MOVE 2 TO W-CRITICA-BENEFIC */
                _.Move(2, WREA88.W_CRITICA_BENEFIC);

                /*" -2020- END-IF */
            }


            /*" -2021- IF (BENEFIC-SEM-CRITICA) */

            if ((WREA88.W_CRITICA_BENEFIC["BENEFIC_SEM_CRITICA"]))
            {

                /*" -2022- MOVE ZEROS TO W-IND-TAB */
                _.Move(0, WAREA_AUXILIAR.W_IND_TAB);

                /*" -2023- PERFORM R0449-00-MAX-NUM-BENEFIC */

                R0449_00_MAX_NUM_BENEFIC_SECTION();

                /*" -2024- PERFORM R0450-00-CARREGA-BENEFIC W-IND-MOV TIMES */

                for (int i = 0; i < WAREA_AUXILIAR.W_IND_MOV; i++)
                {

                    R0450_00_CARREGA_BENEFIC_SECTION();

                }

                /*" -2026- END-IF. */
            }


            /*" -2027- IF (BENEFIC-SEM-CRITICA) */

            if ((WREA88.W_CRITICA_BENEFIC["BENEFIC_SEM_CRITICA"]))
            {

                /*" -2029- IF (W-NUM-CPF-SEG-ANT > ZEROS) */

                if ((WAREA_AUXILIAR.W_NUM_CPF_SEG_ANT > 00))
                {

                    /*" -2030- MOVE 036 TO WS-COD-ERRO */
                    _.Move(036, WS_COD_ERRO);

                    /*" -2031- MOVE 000 TO WS-COD-CAMPO */
                    _.Move(000, WS_COD_CAMPO);

                    /*" -2032- MOVE 0 TO WS-NUM-SEQ-ARQ */
                    _.Move(0, WS_NUM_SEQ_ARQ);

                    /*" -2033- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -2034- END-IF */
                }


                /*" -2034- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0270-00-INICIALIZAR-AREAS-SECTION */
        private void R0270_00_INICIALIZAR_AREAS_SECTION()
        {
            /*" -2043- MOVE 'R0270-00-INICIALIZAR-AREAS' TO PARAGRAFO */
            _.Move("R0270-00-INICIALIZAR-AREAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2045- MOVE 'INICIALIZAR AREAS ' TO COMANDO. */
            _.Move("INICIALIZAR AREAS ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2046- MOVE RE-NUM-APOLICE TO WS-NUM-APOLICE. */
            _.Move(REG_RE_BENEFIC.RE_NUM_APOLICE, WS_NUM_APOLICE);

            /*" -2047- MOVE RE-COD-SUBGRUPO TO WS-COD-SUBGRUPO. */
            _.Move(REG_RE_BENEFIC.RE_COD_SUBGRUPO, WS_COD_SUBGRUPO);

            /*" -2050- MOVE RE-NUM-CPF-SEG TO W-NUM-CPF-SEG-ANT WS-NUM-CPF-SEG */
            _.Move(REG_RE_BENEFIC.RE_NUM_CPF_SEG, WAREA_AUXILIAR.W_NUM_CPF_SEG_ANT, WS_NUM_CPF_SEG);

            /*" -2051- MOVE 1 TO W-CRITICA-BENEFIC. */
            _.Move(1, WREA88.W_CRITICA_BENEFIC);

            /*" -2052- MOVE ZEROS TO W-IND-MOV */
            _.Move(0, WAREA_AUXILIAR.W_IND_MOV);

            /*" -2052- MOVE ZEROS TO WS-PERC-PART-TOTAL. */
            _.Move(0, WS_PERC_PART_TOTAL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_SAIDA*/

        [StopWatch]
        /*" R0310-00-MOVTO-SEG-BENEF-SECTION */
        private void R0310_00_MOVTO_SEG_BENEF_SECTION()
        {
            /*" -2064- MOVE 'R0310-00-MOVTO-SEG-BENEF' TO PARAGRAFO. */
            _.Move("R0310-00-MOVTO-SEG-BENEF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2066- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2067- MOVE RE-NOM-SEGURADO TO R1-NOM-SEGURADO */
            _.Move(REG_RE_BENEFIC.RE_NOM_SEGURADO, REG_R1_BENEFIC.R1_NOM_SEGURADO);

            /*" -2068- MOVE RE-NUM-CPF-SEG TO R1-NUM-CPF-SEG */
            _.Move(REG_RE_BENEFIC.RE_NUM_CPF_SEG, REG_R1_BENEFIC.R1_NUM_CPF_SEG);

            /*" -2069- MOVE RE-NOM-BENEFIC TO R1-NOM-BENEFIC */
            _.Move(REG_RE_BENEFIC.RE_NOM_BENEFIC, REG_R1_BENEFIC.R1_NOM_BENEFIC);

            /*" -2070- MOVE RE-GRAU-PARENTESCO TO R1-GRAU-PARENTESCO */
            _.Move(REG_RE_BENEFIC.RE_GRAU_PARENTESCO, REG_R1_BENEFIC.R1_GRAU_PARENTESCO);

            /*" -2071- MOVE RE-PERC-PARTICIPA TO R1-PERC-PARTICIPA */
            _.Move(REG_RE_BENEFIC.RE_PERC_PARTICIPA, REG_R1_BENEFIC.R1_PERC_PARTICIPA);

            /*" -2072- MOVE RE-NUM-CPF-BENFC TO R1-NUM-CPF-BENFC */
            _.Move(REG_RE_BENEFIC.RE_NUM_CPF_BENFC, REG_R1_BENEFIC.R1_NUM_CPF_BENFC);

            /*" -2073- MOVE RE-NUM-APOLICE TO R1-NUM-APOLICE */
            _.Move(REG_RE_BENEFIC.RE_NUM_APOLICE, REG_R1_BENEFIC.R1_NUM_APOLICE);

            /*" -2074- MOVE RE-COD-SUBGRUPO TO R1-COD-SUBGRUPO */
            _.Move(REG_RE_BENEFIC.RE_COD_SUBGRUPO, REG_R1_BENEFIC.R1_COD_SUBGRUPO);

            /*" -2076- MOVE RE-RESTO TO R1-RESTO */
            _.Move(REG_RE_BENEFIC.RE_RESTO, REG_R1_BENEFIC.R1_RESTO);

            /*" -2077- MOVE ZEROS TO WS-COD-ERRO */
            _.Move(0, WS_COD_ERRO);

            /*" -2078- MOVE ZEROS TO R1-COD-CLIENTE */
            _.Move(0, REG_R1_BENEFIC.R1_COD_CLIENTE);

            /*" -2080- MOVE ZEROS TO R1-NUM-CERTIFICADO WS-NUM-CERTIF */
            _.Move(0, REG_R1_BENEFIC.R1_NUM_CERTIFICADO, WS_NUM_CERTIF);

            /*" -2082- MOVE SPACES TO R1-DAC-CERTIFICADO */
            _.Move("", REG_R1_BENEFIC.R1_DAC_CERTIFICADO);

            /*" -2084- INITIALIZE WS-DES-CONTEUDO */
            _.Initialize(
                WS_DES_CONTEUDO
            );

            /*" -2086- IF (R1-NOM-SEGURADO EQUAL SPACES OR LOW-VALUES) */

            if ((REG_R1_BENEFIC.R1_NOM_SEGURADO.IsLowValues()))
            {

                /*" -2087- MOVE 013 TO WS-COD-ERRO */
                _.Move(013, WS_COD_ERRO);

                /*" -2088- MOVE 200 TO WS-COD-CAMPO */
                _.Move(200, WS_COD_CAMPO);

                /*" -2089- MOVE R1-NOM-SEGURADO TO WS-DES-CONTEUDO */
                _.Move(REG_R1_BENEFIC.R1_NOM_SEGURADO, WS_DES_CONTEUDO);

                /*" -2090- MOVE 1 TO WS-NUM-SEQ-ARQ */
                _.Move(1, WS_NUM_SEQ_ARQ);

                /*" -2091- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2092- ELSE */
            }
            else
            {


                /*" -2093- MOVE 1 TO WS-POSICAO */
                _.Move(1, WS_POSICAO);

                /*" -2095- MOVE ZEROS TO WS-CONTA-BRC */
                _.Move(0, WS_CONTA_BRC);

                /*" -2096- PERFORM UNTIL WS-POSICAO > 40 */

                while (!(WS_POSICAO > 40))
                {

                    /*" -2097- IF (R1-NOM-SEGURADO(WS-POSICAO:1) NOT EQUAL SPACES) */

                    if ((REG_R1_BENEFIC.R1_NOM_SEGURADO.Substring(WS_POSICAO, 1) != string.Empty))
                    {

                        /*" -2098- ADD 1 TO WS-CONTA-BRC */
                        WS_CONTA_BRC.Value = WS_CONTA_BRC + 1;

                        /*" -2099- END-IF */
                    }


                    /*" -2100- ADD 1 TO WS-POSICAO */
                    WS_POSICAO.Value = WS_POSICAO + 1;

                    /*" -2102- END-PERFORM */
                }

                /*" -2104- IF WS-CONTA-BRC <= 10 */

                if (WS_CONTA_BRC <= 10)
                {

                    /*" -2105- MOVE 018 TO WS-COD-ERRO */
                    _.Move(018, WS_COD_ERRO);

                    /*" -2106- MOVE 200 TO WS-COD-CAMPO */
                    _.Move(200, WS_COD_CAMPO);

                    /*" -2107- MOVE R1-NOM-SEGURADO TO WS-DES-CONTEUDO */
                    _.Move(REG_R1_BENEFIC.R1_NOM_SEGURADO, WS_DES_CONTEUDO);

                    /*" -2108- MOVE 1 TO WS-NUM-SEQ-ARQ */
                    _.Move(1, WS_NUM_SEQ_ARQ);

                    /*" -2109- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -2110- END-IF */
                }


                /*" -2112- END-IF. */
            }


            /*" -2115- IF (R1-NUM-CPF-SEG IS NOT NUMERIC) OR (R1-NUM-CPF-SEG EQUAL ZEROS) */

            if ((!REG_R1_BENEFIC.R1_NUM_CPF_SEG.IsNumeric()) || (REG_R1_BENEFIC.R1_NUM_CPF_SEG == 00))
            {

                /*" -2116- MOVE 009 TO WS-COD-ERRO */
                _.Move(009, WS_COD_ERRO);

                /*" -2117- MOVE 201 TO WS-COD-CAMPO */
                _.Move(201, WS_COD_CAMPO);

                /*" -2118- MOVE R1-NUM-CPF-SEG TO WS-DES-CONTEUDO */
                _.Move(REG_R1_BENEFIC.R1_NUM_CPF_SEG, WS_DES_CONTEUDO);

                /*" -2119- MOVE 2 TO WS-NUM-SEQ-ARQ */
                _.Move(2, WS_NUM_SEQ_ARQ);

                /*" -2120- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2122- END-IF. */
            }


            /*" -2124- IF (R1-NOM-BENEFIC EQUAL SPACES OR LOW-VALUES) */

            if ((REG_R1_BENEFIC.R1_NOM_BENEFIC.IsLowValues()))
            {

                /*" -2125- MOVE 013 TO WS-COD-ERRO */
                _.Move(013, WS_COD_ERRO);

                /*" -2126- MOVE 202 TO WS-COD-CAMPO */
                _.Move(202, WS_COD_CAMPO);

                /*" -2127- MOVE R1-NOM-BENEFIC TO WS-DES-CONTEUDO */
                _.Move(REG_R1_BENEFIC.R1_NOM_BENEFIC, WS_DES_CONTEUDO);

                /*" -2128- MOVE 3 TO WS-NUM-SEQ-ARQ */
                _.Move(3, WS_NUM_SEQ_ARQ);

                /*" -2129- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2130- ELSE */
            }
            else
            {


                /*" -2131- MOVE 1 TO WS-POSICAO */
                _.Move(1, WS_POSICAO);

                /*" -2133- MOVE ZEROS TO WS-CONTA-BRC */
                _.Move(0, WS_CONTA_BRC);

                /*" -2134- PERFORM UNTIL WS-POSICAO > 40 */

                while (!(WS_POSICAO > 40))
                {

                    /*" -2135- IF (R1-NOM-BENEFIC(WS-POSICAO:1) NOT EQUAL SPACES) */

                    if ((REG_R1_BENEFIC.R1_NOM_BENEFIC.Substring(WS_POSICAO, 1) != string.Empty))
                    {

                        /*" -2136- ADD 1 TO WS-CONTA-BRC */
                        WS_CONTA_BRC.Value = WS_CONTA_BRC + 1;

                        /*" -2137- END-IF */
                    }


                    /*" -2138- ADD 1 TO WS-POSICAO */
                    WS_POSICAO.Value = WS_POSICAO + 1;

                    /*" -2140- END-PERFORM */
                }

                /*" -2142- IF WS-CONTA-BRC <= 10 */

                if (WS_CONTA_BRC <= 10)
                {

                    /*" -2143- MOVE 018 TO WS-COD-ERRO */
                    _.Move(018, WS_COD_ERRO);

                    /*" -2144- MOVE 202 TO WS-COD-CAMPO */
                    _.Move(202, WS_COD_CAMPO);

                    /*" -2145- MOVE R1-NOM-BENEFIC TO WS-DES-CONTEUDO */
                    _.Move(REG_R1_BENEFIC.R1_NOM_BENEFIC, WS_DES_CONTEUDO);

                    /*" -2146- MOVE 3 TO WS-NUM-SEQ-ARQ */
                    _.Move(3, WS_NUM_SEQ_ARQ);

                    /*" -2147- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -2148- END-IF */
                }


                /*" -2150- END-IF. */
            }


            /*" -2152- IF (R1-GRAU-PARENTESCO EQUAL SPACES OR LOW-VALUES) */

            if ((REG_R1_BENEFIC.R1_GRAU_PARENTESCO.IsLowValues()))
            {

                /*" -2153- MOVE 013 TO WS-COD-ERRO */
                _.Move(013, WS_COD_ERRO);

                /*" -2154- MOVE 203 TO WS-COD-CAMPO */
                _.Move(203, WS_COD_CAMPO);

                /*" -2155- MOVE R1-GRAU-PARENTESCO TO WS-DES-CONTEUDO */
                _.Move(REG_R1_BENEFIC.R1_GRAU_PARENTESCO, WS_DES_CONTEUDO);

                /*" -2156- MOVE 4 TO WS-NUM-SEQ-ARQ */
                _.Move(4, WS_NUM_SEQ_ARQ);

                /*" -2157- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2158- ELSE */
            }
            else
            {


                /*" -2160- MOVE R1-GRAU-PARENTESCO TO WS-GRAU-PARENTESCO */
                _.Move(REG_R1_BENEFIC.R1_GRAU_PARENTESCO, WS_GRAU_PARENTESCO);

                /*" -2162- IF NOT (WS-GRAU-VALIDO) */

                if (!(WS_GRAU_PARENTESCO["WS_GRAU_VALIDO"]))
                {

                    /*" -2163- MOVE 012 TO WS-COD-ERRO */
                    _.Move(012, WS_COD_ERRO);

                    /*" -2164- MOVE 203 TO WS-COD-CAMPO */
                    _.Move(203, WS_COD_CAMPO);

                    /*" -2165- MOVE R1-GRAU-PARENTESCO TO WS-DES-CONTEUDO */
                    _.Move(REG_R1_BENEFIC.R1_GRAU_PARENTESCO, WS_DES_CONTEUDO);

                    /*" -2166- MOVE 4 TO WS-NUM-SEQ-ARQ */
                    _.Move(4, WS_NUM_SEQ_ARQ);

                    /*" -2167- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -2168- END-IF */
                }


                /*" -2170- END-IF. */
            }


            /*" -2173- IF (R1-PERC-PARTICIPA IS NOT NUMERIC) OR (R1-PERC-PARTICIPA EQUAL ZEROS) */

            if ((!REG_R1_BENEFIC.R1_PERC_PARTICIPA.IsNumeric()) || (REG_R1_BENEFIC.R1_PERC_PARTICIPA == 00))
            {

                /*" -2174- MOVE 009 TO WS-COD-ERRO */
                _.Move(009, WS_COD_ERRO);

                /*" -2175- MOVE 204 TO WS-COD-CAMPO */
                _.Move(204, WS_COD_CAMPO);

                /*" -2176- MOVE R1-PERC-PARTICIPA TO WS-DES-CONTEUDO */
                _.Move(REG_R1_BENEFIC.R1_PERC_PARTICIPA, WS_DES_CONTEUDO);

                /*" -2177- MOVE 5 TO WS-NUM-SEQ-ARQ */
                _.Move(5, WS_NUM_SEQ_ARQ);

                /*" -2178- MOVE ZEROS TO R1-PERC-PARTICIPA */
                _.Move(0, REG_R1_BENEFIC.R1_PERC_PARTICIPA);

                /*" -2179- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2180- ELSE */
            }
            else
            {


                /*" -2182- IF (R1-PERC-PARTICIPA > 100) */

                if ((REG_R1_BENEFIC.R1_PERC_PARTICIPA > 100))
                {

                    /*" -2183- MOVE 028 TO WS-COD-ERRO */
                    _.Move(028, WS_COD_ERRO);

                    /*" -2184- MOVE 204 TO WS-COD-CAMPO */
                    _.Move(204, WS_COD_CAMPO);

                    /*" -2185- MOVE R1-PERC-PARTICIPA TO WS-DES-CONTEUDO */
                    _.Move(REG_R1_BENEFIC.R1_PERC_PARTICIPA, WS_DES_CONTEUDO);

                    /*" -2186- MOVE 5 TO WS-NUM-SEQ-ARQ */
                    _.Move(5, WS_NUM_SEQ_ARQ);

                    /*" -2187- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -2188- END-IF */
                }


                /*" -2190- END-IF. */
            }


            /*" -2192- ADD R1-PERC-PARTICIPA TO WS-PERC-PART-TOTAL */
            WS_PERC_PART_TOTAL.Value = WS_PERC_PART_TOTAL + REG_R1_BENEFIC.R1_PERC_PARTICIPA;

            /*" -2194- IF (R1-NUM-CPF-BENFC IS NOT NUMERIC) OR (R1-NUM-CPF-BENFC EQUAL ZEROS) */

            if ((!REG_R1_BENEFIC.R1_NUM_CPF_BENFC.IsNumeric()) || (REG_R1_BENEFIC.R1_NUM_CPF_BENFC == 00))
            {

                /*" -2195- MOVE ZEROS TO R1-NUM-CPF-BENFC */
                _.Move(0, REG_R1_BENEFIC.R1_NUM_CPF_BENFC);

                /*" -2196- ELSE */
            }
            else
            {


                /*" -2197- INITIALIZE LPARM-CPF */
                _.Initialize(
                    LPARM_CPF
                );

                /*" -2198- MOVE R1-NUM-CPF-BENFC TO LPARM-ENT-CPF */
                _.Move(REG_R1_BENEFIC.R1_NUM_CPF_BENFC, LPARM_CPF.LPARM_ENT_CPF);

                /*" -2200- PERFORM R8018-00-VALIDA-CPF */

                R8018_00_VALIDA_CPF_SECTION();

                /*" -2202- IF (LPARM-SAI-CPF NOT EQUAL ZEROS) */

                if ((LPARM_CPF.LPARM_SAI_CPF != 00))
                {

                    /*" -2203- MOVE 015 TO WS-COD-ERRO */
                    _.Move(015, WS_COD_ERRO);

                    /*" -2204- MOVE 205 TO WS-COD-CAMPO */
                    _.Move(205, WS_COD_CAMPO);

                    /*" -2205- MOVE R1-NUM-CPF-BENFC TO WS-DES-CONTEUDO */
                    _.Move(REG_R1_BENEFIC.R1_NUM_CPF_BENFC, WS_DES_CONTEUDO);

                    /*" -2206- MOVE 6 TO WS-NUM-SEQ-ARQ */
                    _.Move(6, WS_NUM_SEQ_ARQ);

                    /*" -2207- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -2208- END-IF */
                }


                /*" -2210- END-IF. */
            }


            /*" -2213- IF (R1-NUM-APOLICE IS NOT NUMERIC) OR (R1-NUM-APOLICE EQUAL ZEROS) */

            if ((!REG_R1_BENEFIC.R1_NUM_APOLICE.IsNumeric()) || (REG_R1_BENEFIC.R1_NUM_APOLICE == 00))
            {

                /*" -2214- MOVE 009 TO WS-COD-ERRO */
                _.Move(009, WS_COD_ERRO);

                /*" -2215- MOVE 206 TO WS-COD-CAMPO */
                _.Move(206, WS_COD_CAMPO);

                /*" -2216- MOVE R1-NUM-APOLICE TO WS-DES-CONTEUDO */
                _.Move(REG_R1_BENEFIC.R1_NUM_APOLICE, WS_DES_CONTEUDO);

                /*" -2217- MOVE 7 TO WS-NUM-SEQ-ARQ */
                _.Move(7, WS_NUM_SEQ_ARQ);

                /*" -2218- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2219- ELSE */
            }
            else
            {


                /*" -2220- MOVE R1-NUM-APOLICE TO PRODUVG-NUM-APOLICE */
                _.Move(REG_R1_BENEFIC.R1_NUM_APOLICE, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE);

                /*" -2222- PERFORM R8030-00-VERIFICA-APOL-PROD */

                R8030_00_VERIFICA_APOL_PROD_SECTION();

                /*" -2224- IF (PRODUVG-ESTR-EMISS EQUAL SPACES) */

                if ((PRODUVG.DCLPRODUTOS_VG.PRODUVG_ESTR_EMISS.IsEmpty()))
                {

                    /*" -2225- MOVE 031 TO WS-COD-ERRO */
                    _.Move(031, WS_COD_ERRO);

                    /*" -2226- MOVE 206 TO WS-COD-CAMPO */
                    _.Move(206, WS_COD_CAMPO);

                    /*" -2227- MOVE R1-NUM-APOLICE TO WS-DES-CONTEUDO */
                    _.Move(REG_R1_BENEFIC.R1_NUM_APOLICE, WS_DES_CONTEUDO);

                    /*" -2228- MOVE 7 TO WS-NUM-SEQ-ARQ */
                    _.Move(7, WS_NUM_SEQ_ARQ);

                    /*" -2229- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -2231- END-IF */
                }


                /*" -2234- IF (PRODUVG-ESTR-EMISS NOT EQUAL 'ESPEC' AND 'ESPE1' AND 'ESPE2' AND SPACES) */

                if ((!PRODUVG.DCLPRODUTOS_VG.PRODUVG_ESTR_EMISS.In("ESPEC", "ESPE1", "ESPE2", string.Empty)))
                {

                    /*" -2235- MOVE 032 TO WS-COD-ERRO */
                    _.Move(032, WS_COD_ERRO);

                    /*" -2236- MOVE 206 TO WS-COD-CAMPO */
                    _.Move(206, WS_COD_CAMPO);

                    /*" -2237- MOVE R1-NUM-APOLICE TO WS-DES-CONTEUDO */
                    _.Move(REG_R1_BENEFIC.R1_NUM_APOLICE, WS_DES_CONTEUDO);

                    /*" -2238- MOVE 7 TO WS-NUM-SEQ-ARQ */
                    _.Move(7, WS_NUM_SEQ_ARQ);

                    /*" -2239- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -2240- END-IF */
                }


                /*" -2242- END-IF. */
            }


            /*" -2245- IF (R1-COD-SUBGRUPO IS NOT NUMERIC) OR (R1-COD-SUBGRUPO EQUAL ZEROS) */

            if ((!REG_R1_BENEFIC.R1_COD_SUBGRUPO.IsNumeric()) || (REG_R1_BENEFIC.R1_COD_SUBGRUPO == 00))
            {

                /*" -2246- MOVE 009 TO WS-COD-ERRO */
                _.Move(009, WS_COD_ERRO);

                /*" -2247- MOVE 207 TO WS-COD-CAMPO */
                _.Move(207, WS_COD_CAMPO);

                /*" -2248- MOVE R1-COD-SUBGRUPO TO WS-DES-CONTEUDO */
                _.Move(REG_R1_BENEFIC.R1_COD_SUBGRUPO, WS_DES_CONTEUDO);

                /*" -2249- MOVE ZEROS TO R1-COD-SUBGRUPO */
                _.Move(0, REG_R1_BENEFIC.R1_COD_SUBGRUPO);

                /*" -2250- MOVE 8 TO WS-NUM-SEQ-ARQ */
                _.Move(8, WS_NUM_SEQ_ARQ);

                /*" -2251- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2253- END-IF. */
            }


            /*" -2254- IF (WS-COD-ERRO EQUAL ZEROS) */

            if ((WS_COD_ERRO == 00))
            {

                /*" -2255- MOVE R1-NUM-CPF-SEG TO CLIENTES-CGCCPF */
                _.Move(REG_R1_BENEFIC.R1_NUM_CPF_SEG, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);

                /*" -2256- MOVE R1-NUM-APOLICE TO SEGURVGA-NUM-APOLICE */
                _.Move(REG_R1_BENEFIC.R1_NUM_APOLICE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);

                /*" -2258- MOVE R1-COD-SUBGRUPO TO SEGURVGA-COD-SUBGRUPO */
                _.Move(REG_R1_BENEFIC.R1_COD_SUBGRUPO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);

                /*" -2260- PERFORM R8012-00-VERIFICA-SEGURVGA */

                R8012_00_VERIFICA_SEGURVGA_SECTION();

                /*" -2262- IF (SQLCODE NOT EQUAL ZEROS) */

                if ((DB.SQLCODE != 00))
                {

                    /*" -2263- MOVE 033 TO WS-COD-ERRO */
                    _.Move(033, WS_COD_ERRO);

                    /*" -2264- MOVE 201 TO WS-COD-CAMPO */
                    _.Move(201, WS_COD_CAMPO);

                    /*" -2265- MOVE R1-NUM-CPF-SEG TO WS-DES-CONTEUDO */
                    _.Move(REG_R1_BENEFIC.R1_NUM_CPF_SEG, WS_DES_CONTEUDO);

                    /*" -2266- MOVE 2 TO WS-NUM-SEQ-ARQ */
                    _.Move(2, WS_NUM_SEQ_ARQ);

                    /*" -2267- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -2268- ELSE */
                }
                else
                {


                    /*" -2269- MOVE SEGURVGA-COD-CLIENTE TO R1-COD-CLIENTE */
                    _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE, REG_R1_BENEFIC.R1_COD_CLIENTE);

                    /*" -2271- MOVE SEGURVGA-NUM-CERTIFICADO TO R1-NUM-CERTIFICADO WS-NUM-CERTIF */
                    _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO, REG_R1_BENEFIC.R1_NUM_CERTIFICADO, WS_NUM_CERTIF);

                    /*" -2272- MOVE SEGURVGA-DAC-CERTIFICADO TO R1-DAC-CERTIFICADO */
                    _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DAC_CERTIFICADO, REG_R1_BENEFIC.R1_DAC_CERTIFICADO);

                    /*" -2273- END-IF */
                }


                /*" -2275- END-IF. */
            }


            /*" -2276- IF (WS-COD-ERRO EQUAL ZEROS) */

            if ((WS_COD_ERRO == 00))
            {

                /*" -2277- ADD 1 TO W-IND-MOV */
                WAREA_AUXILIAR.W_IND_MOV.Value = WAREA_AUXILIAR.W_IND_MOV + 1;

                /*" -2278- MOVE REG-R1-BENEFIC TO W-TB-MOV-BENEFC(W-IND-MOV) */
                _.Move(REG_R1_BENEFIC, WAREA_AUXILIAR.W_TAB_MOV_BENEFC.W_TAB_MOV_BENEFC_0[WAREA_AUXILIAR.W_IND_MOV].W_TB_MOV_BENEFC);

                /*" -2279- ELSE */
            }
            else
            {


                /*" -2280- MOVE 2 TO W-CRITICA-BENEFIC */
                _.Move(2, WREA88.W_CRITICA_BENEFIC);

                /*" -2282- END-IF. */
            }


            /*" -2282- PERFORM R0050-00-LER-MOV-BENEFCPJ. */

            R0050_00_LER_MOV_BENEFCPJ_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_SAIDA*/

        [StopWatch]
        /*" R0449-00-MAX-NUM-BENEFIC-SECTION */
        private void R0449_00_MAX_NUM_BENEFIC_SECTION()
        {
            /*" -2293- MOVE 'R0449-00-MAX-NUM-BENEFIC  ' TO PARAGRAFO. */
            _.Move("R0449-00-MAX-NUM-BENEFIC  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2295- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2296- MOVE R1-NUM-APOLICE TO BENEFICI-NUM-APOLICE */
            _.Move(REG_R1_BENEFIC.R1_NUM_APOLICE, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_APOLICE);

            /*" -2297- MOVE R1-COD-SUBGRUPO TO BENEFICI-COD-SUBGRUPO */
            _.Move(REG_R1_BENEFIC.R1_COD_SUBGRUPO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_COD_SUBGRUPO);

            /*" -2299- MOVE R1-NUM-CERTIFICADO TO BENEFICI-NUM-CERTIFICADO */
            _.Move(REG_R1_BENEFIC.R1_NUM_CERTIFICADO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_CERTIFICADO);

            /*" -2307- PERFORM R0449_00_MAX_NUM_BENEFIC_DB_SELECT_1 */

            R0449_00_MAX_NUM_BENEFIC_DB_SELECT_1();

            /*" -2310- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -2311- DISPLAY 'VG1617B - FIM ANORMAL' */
                _.Display($"VG1617B - FIM ANORMAL");

                /*" -2313- DISPLAY '          ERRO ACESSO MAX BENEFICIARIO ' SQLCODE */
                _.Display($"          ERRO ACESSO MAX BENEFICIARIO {DB.SQLCODE}");

                /*" -2315- DISPLAY '          NUM-APOLICE...................... ' BENEFICI-NUM-APOLICE */
                _.Display($"          NUM-APOLICE...................... {BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_APOLICE}");

                /*" -2317- DISPLAY '          COD-SUBGRUPO..................... ' BENEFICI-COD-SUBGRUPO */
                _.Display($"          COD-SUBGRUPO..................... {BENEFICI.DCLBENEFICIARIOS.BENEFICI_COD_SUBGRUPO}");

                /*" -2319- DISPLAY '          NUM-CERTIFICADO.................. ' BENEFICI-NUM-CERTIFICADO */
                _.Display($"          NUM-CERTIFICADO.................. {BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_CERTIFICADO}");

                /*" -2320- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2320- END-IF. */
            }


        }

        [StopWatch]
        /*" R0449-00-MAX-NUM-BENEFIC-DB-SELECT-1 */
        public void R0449_00_MAX_NUM_BENEFIC_DB_SELECT_1()
        {
            /*" -2307- EXEC SQL SELECT VALUE(MAX(NUM_BENEFICIARIO), 0) INTO :BENEFICI-NUM-BENEFICIARIO FROM SEGUROS.BENEFICIARIOS WHERE NUM_APOLICE = :BENEFICI-NUM-APOLICE AND COD_SUBGRUPO = :BENEFICI-COD-SUBGRUPO AND NUM_CERTIFICADO = :BENEFICI-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r0449_00_MAX_NUM_BENEFIC_DB_SELECT_1_Query1 = new R0449_00_MAX_NUM_BENEFIC_DB_SELECT_1_Query1()
            {
                BENEFICI_NUM_CERTIFICADO = BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_CERTIFICADO.ToString(),
                BENEFICI_COD_SUBGRUPO = BENEFICI.DCLBENEFICIARIOS.BENEFICI_COD_SUBGRUPO.ToString(),
                BENEFICI_NUM_APOLICE = BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0449_00_MAX_NUM_BENEFIC_DB_SELECT_1_Query1.Execute(r0449_00_MAX_NUM_BENEFIC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BENEFICI_NUM_BENEFICIARIO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_BENEFICIARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0449_SAIDA*/

        [StopWatch]
        /*" R0450-00-CARREGA-BENEFIC-SECTION */
        private void R0450_00_CARREGA_BENEFIC_SECTION()
        {
            /*" -2332- MOVE 'R0450-00-CARREGA-BENEFIC  ' TO PARAGRAFO. */
            _.Move("R0450-00-CARREGA-BENEFIC  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2334- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2336- INITIALIZE REG-R1-BENEFIC */
            _.Initialize(
                REG_R1_BENEFIC
            );

            /*" -2337- ADD 1 TO W-IND-TAB */
            WAREA_AUXILIAR.W_IND_TAB.Value = WAREA_AUXILIAR.W_IND_TAB + 1;

            /*" -2339- MOVE W-TB-MOV-BENEFC(W-IND-TAB) TO REG-R1-BENEFIC */
            _.Move(WAREA_AUXILIAR.W_TAB_MOV_BENEFC.W_TAB_MOV_BENEFC_0[WAREA_AUXILIAR.W_IND_TAB].W_TB_MOV_BENEFC, REG_R1_BENEFIC);

            /*" -2340- MOVE R1-NUM-APOLICE TO BENEFICI-NUM-APOLICE */
            _.Move(REG_R1_BENEFIC.R1_NUM_APOLICE, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_APOLICE);

            /*" -2342- MOVE R1-COD-SUBGRUPO TO BENEFICI-COD-SUBGRUPO */
            _.Move(REG_R1_BENEFIC.R1_COD_SUBGRUPO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_COD_SUBGRUPO);

            /*" -2343- MOVE R1-NUM-CERTIFICADO TO BENEFICI-NUM-CERTIFICADO */
            _.Move(REG_R1_BENEFIC.R1_NUM_CERTIFICADO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_CERTIFICADO);

            /*" -2344- MOVE R1-DAC-CERTIFICADO TO BENEFICI-DAC-CERTIFICADO */
            _.Move(REG_R1_BENEFIC.R1_DAC_CERTIFICADO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_DAC_CERTIFICADO);

            /*" -2345- ADD 1 TO BENEFICI-NUM-BENEFICIARIO */
            BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_BENEFICIARIO.Value = BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_BENEFICIARIO + 1;

            /*" -2347- MOVE R1-NOM-BENEFIC TO BENEFICI-NOME-BENEFICIARIO */
            _.Move(REG_R1_BENEFIC.R1_NOM_BENEFIC, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NOME_BENEFICIARIO);

            /*" -2348- MOVE R1-GRAU-PARENTESCO TO BENEFICI-GRAU-PARENTESCO */
            _.Move(REG_R1_BENEFIC.R1_GRAU_PARENTESCO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_GRAU_PARENTESCO);

            /*" -2349- MOVE R1-PERC-PARTICIPA TO BENEFICI-PCT-PART-BENEFICIA */
            _.Move(REG_R1_BENEFIC.R1_PERC_PARTICIPA, BENEFICI.DCLBENEFICIARIOS.BENEFICI_PCT_PART_BENEFICIA);

            /*" -2351- MOVE R1-NUM-CPF-BENFC TO BENEFICI-NUM-CPF */
            _.Move(REG_R1_BENEFIC.R1_NUM_CPF_BENFC, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_CPF);

            /*" -2352- IF (R1-NUM-CPF-BENFC > ZEROS) */

            if ((REG_R1_BENEFIC.R1_NUM_CPF_BENFC > 00))
            {

                /*" -2353- MOVE ZEROS TO VIND-CPF */
                _.Move(0, VIND_CPF);

                /*" -2354- ELSE */
            }
            else
            {


                /*" -2355- MOVE -1 TO VIND-CPF */
                _.Move(-1, VIND_CPF);

                /*" -2357- END-IF */
            }


            /*" -2358- MOVE SISTEMAS-DATA-MOV-ABERTO TO BENEFICI-DATA-INIVIGENCIA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_DATA_INIVIGENCIA);

            /*" -2359- MOVE '9999-12-31' TO BENEFICI-DATA-TERVIGENCIA */
            _.Move("9999-12-31", BENEFICI.DCLBENEFICIARIOS.BENEFICI_DATA_TERVIGENCIA);

            /*" -2361- MOVE 'VG1617B' TO BENEFICI-COD-USUARIO */
            _.Move("VG1617B", BENEFICI.DCLBENEFICIARIOS.BENEFICI_COD_USUARIO);

            /*" -2362- IF (W-IND-TAB EQUAL 1) */

            if ((WAREA_AUXILIAR.W_IND_TAB == 1))
            {

                /*" -2363- PERFORM R8017-00-UPDATE-BENEFIC */

                R8017_00_UPDATE_BENEFIC_SECTION();

                /*" -2365- END-IF */
            }


            /*" -2365- PERFORM R0532-00-INSERT-BENEFIC. */

            R0532_00_INSERT_BENEFIC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0532-00-INSERT-BENEFIC-SECTION */
        private void R0532_00_INSERT_BENEFIC_SECTION()
        {
            /*" -2375- MOVE 'R0532-00-INSERT-BENEFIC ' TO PARAGRAFO. */
            _.Move("R0532-00-INSERT-BENEFIC ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2377- MOVE 'INSERT BENEFICIARIOS    ' TO COMANDO. */
            _.Move("INSERT BENEFICIARIOS    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2396- PERFORM R0532_00_INSERT_BENEFIC_DB_INSERT_1 */

            R0532_00_INSERT_BENEFIC_DB_INSERT_1();

            /*" -2399- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2400- DISPLAY 'VG1617B - FIM ANORMAL' */
                _.Display($"VG1617B - FIM ANORMAL");

                /*" -2401- DISPLAY '          ERRO INSERT DA TABELA SUBGRUPO ' */
                _.Display($"          ERRO INSERT DA TABELA SUBGRUPO ");

                /*" -2403- DISPLAY '          NUM APOLICE...................  ' BENEFICI-NUM-APOLICE */
                _.Display($"          NUM APOLICE...................  {BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_APOLICE}");

                /*" -2405- DISPLAY '          COD SUBGRUPO..................  ' BENEFICI-COD-SUBGRUPO */
                _.Display($"          COD SUBGRUPO..................  {BENEFICI.DCLBENEFICIARIOS.BENEFICI_COD_SUBGRUPO}");

                /*" -2407- DISPLAY '          NUMERO CERTIFICADO............  ' BENEFICI-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO............  {BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_CERTIFICADO}");

                /*" -2409- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2410- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2412- END-IF. */
            }


            /*" -2412- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0532-00-INSERT-BENEFIC-DB-INSERT-1 */
        public void R0532_00_INSERT_BENEFIC_DB_INSERT_1()
        {
            /*" -2396- EXEC SQL INSERT INTO SEGUROS.BENEFICIARIOS VALUES (:BENEFICI-NUM-APOLICE , :BENEFICI-COD-SUBGRUPO , :BENEFICI-NUM-CERTIFICADO , :BENEFICI-DAC-CERTIFICADO , :BENEFICI-NUM-BENEFICIARIO , :BENEFICI-NOME-BENEFICIARIO , :BENEFICI-GRAU-PARENTESCO , :BENEFICI-PCT-PART-BENEFICIA , :BENEFICI-DATA-INIVIGENCIA , :BENEFICI-DATA-TERVIGENCIA , :BENEFICI-COD-USUARIO , NULL , NULL , NULL , :BENEFICI-NUM-CPF :VIND-CPF , NULL ) END-EXEC. */

            var r0532_00_INSERT_BENEFIC_DB_INSERT_1_Insert1 = new R0532_00_INSERT_BENEFIC_DB_INSERT_1_Insert1()
            {
                BENEFICI_NUM_APOLICE = BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_APOLICE.ToString(),
                BENEFICI_COD_SUBGRUPO = BENEFICI.DCLBENEFICIARIOS.BENEFICI_COD_SUBGRUPO.ToString(),
                BENEFICI_NUM_CERTIFICADO = BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_CERTIFICADO.ToString(),
                BENEFICI_DAC_CERTIFICADO = BENEFICI.DCLBENEFICIARIOS.BENEFICI_DAC_CERTIFICADO.ToString(),
                BENEFICI_NUM_BENEFICIARIO = BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_BENEFICIARIO.ToString(),
                BENEFICI_NOME_BENEFICIARIO = BENEFICI.DCLBENEFICIARIOS.BENEFICI_NOME_BENEFICIARIO.ToString(),
                BENEFICI_GRAU_PARENTESCO = BENEFICI.DCLBENEFICIARIOS.BENEFICI_GRAU_PARENTESCO.ToString(),
                BENEFICI_PCT_PART_BENEFICIA = BENEFICI.DCLBENEFICIARIOS.BENEFICI_PCT_PART_BENEFICIA.ToString(),
                BENEFICI_DATA_INIVIGENCIA = BENEFICI.DCLBENEFICIARIOS.BENEFICI_DATA_INIVIGENCIA.ToString(),
                BENEFICI_DATA_TERVIGENCIA = BENEFICI.DCLBENEFICIARIOS.BENEFICI_DATA_TERVIGENCIA.ToString(),
                BENEFICI_COD_USUARIO = BENEFICI.DCLBENEFICIARIOS.BENEFICI_COD_USUARIO.ToString(),
                BENEFICI_NUM_CPF = BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_CPF.ToString(),
                VIND_CPF = VIND_CPF.ToString(),
            };

            R0532_00_INSERT_BENEFIC_DB_INSERT_1_Insert1.Execute(r0532_00_INSERT_BENEFIC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0532_SAIDA*/

        [StopWatch]
        /*" R0558-00-INSERT-CNTRLE-PROC-SECTION */
        private void R0558_00_INSERT_CNTRLE_PROC_SECTION()
        {
            /*" -2422- MOVE 'R0558-00-INSERT-CNTRLE-PRC' TO PARAGRAFO. */
            _.Move("R0558-00-INSERT-CNTRLE-PRC", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2424- MOVE 'INSERT PF_PROC_PROPOSTA   ' TO COMANDO. */
            _.Move("INSERT PF_PROC_PROPOSTA   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2440- PERFORM R0558_00_INSERT_CNTRLE_PROC_DB_INSERT_1 */

            R0558_00_INSERT_CNTRLE_PROC_DB_INSERT_1();

            /*" -2443- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2444- DISPLAY 'VG1617B - FIM ANORMAL' */
                _.Display($"VG1617B - FIM ANORMAL");

                /*" -2445- DISPLAY '          ERRO INSERT TAB. PF_PROC_PROPOSTA' */
                _.Display($"          ERRO INSERT TAB. PF_PROC_PROPOSTA");

                /*" -2447- DISPLAY '          SIGLA-ARQUIVO..........  ' PF087-SIGLA-ARQUIVO */
                _.Display($"          SIGLA-ARQUIVO..........  {PF087.DCLPF_PROC_PROPOSTA.PF087_SIGLA_ARQUIVO}");

                /*" -2449- DISPLAY '          SISTEMA-ORIGEM.........  ' PF087-SISTEMA-ORIGEM */
                _.Display($"          SISTEMA-ORIGEM.........  {PF087.DCLPF_PROC_PROPOSTA.PF087_SISTEMA_ORIGEM}");

                /*" -2451- DISPLAY '          NSAS-SIVPF.............  ' PF087-NSAS-SIVPF */
                _.Display($"          NSAS-SIVPF.............  {PF087.DCLPF_PROC_PROPOSTA.PF087_NSAS_SIVPF}");

                /*" -2453- DISPLAY '          NUM-PROPOSTA...........  ' PF087-NUM-PROPOSTA */
                _.Display($"          NUM-PROPOSTA...........  {PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_PROPOSTA}");

                /*" -2455- DISPLAY '          SEQ-OCORRENCIA.........  ' PF087-SEQ-OCORRENCIA */
                _.Display($"          SEQ-OCORRENCIA.........  {PF087.DCLPF_PROC_PROPOSTA.PF087_SEQ_OCORRENCIA}");

                /*" -2457- DISPLAY '          NUM-ERRO-PROPOSTA......  ' PF087-NUM-ERRO-PROPOSTA */
                _.Display($"          NUM-ERRO-PROPOSTA......  {PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_ERRO_PROPOSTA}");

                /*" -2459- DISPLAY '          NUM-DET-ARQ-PROPOSTA...  ' PF087-NUM-DET-ARQ-PROPOSTA */
                _.Display($"          NUM-DET-ARQ-PROPOSTA...  {PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_DET_ARQ_PROPOSTA}");

                /*" -2461- DISPLAY '          NUM-APOLICE-VINC.......  ' PF087-NUM-APOLICE-VINCULADA */
                _.Display($"          NUM-APOLICE-VINC.......  {PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_APOLICE_VINCULADA}");

                /*" -2463- DISPLAY '          SQLCODE................  ' SQLCODE */
                _.Display($"          SQLCODE................  {DB.SQLCODE}");

                /*" -2464- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2464- END-IF. */
            }


        }

        [StopWatch]
        /*" R0558-00-INSERT-CNTRLE-PROC-DB-INSERT-1 */
        public void R0558_00_INSERT_CNTRLE_PROC_DB_INSERT_1()
        {
            /*" -2440- EXEC SQL INSERT INTO SEGUROS.PF_PROC_PROPOSTA VALUES (:PF087-SIGLA-ARQUIVO , :PF087-SISTEMA-ORIGEM , :PF087-NSAS-SIVPF , :PF087-NUM-PROPOSTA , :PF087-SEQ-OCORRENCIA , :PF087-NUM-DET-ARQ-PROPOSTA , :PF087-NUM-ERRO-PROPOSTA , :PF087-NUM-APOLICE-VINCULADA , :PF087-NUM-LINHA-ARQUIVO , :PF087-DES-CONTEUDO , :PF087-STA-PROCESSAMENTO , :PF087-COD-USUARIO , CURRENT_TIMESTAMP ) END-EXEC. */

            var r0558_00_INSERT_CNTRLE_PROC_DB_INSERT_1_Insert1 = new R0558_00_INSERT_CNTRLE_PROC_DB_INSERT_1_Insert1()
            {
                PF087_SIGLA_ARQUIVO = PF087.DCLPF_PROC_PROPOSTA.PF087_SIGLA_ARQUIVO.ToString(),
                PF087_SISTEMA_ORIGEM = PF087.DCLPF_PROC_PROPOSTA.PF087_SISTEMA_ORIGEM.ToString(),
                PF087_NSAS_SIVPF = PF087.DCLPF_PROC_PROPOSTA.PF087_NSAS_SIVPF.ToString(),
                PF087_NUM_PROPOSTA = PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_PROPOSTA.ToString(),
                PF087_SEQ_OCORRENCIA = PF087.DCLPF_PROC_PROPOSTA.PF087_SEQ_OCORRENCIA.ToString(),
                PF087_NUM_DET_ARQ_PROPOSTA = PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_DET_ARQ_PROPOSTA.ToString(),
                PF087_NUM_ERRO_PROPOSTA = PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_ERRO_PROPOSTA.ToString(),
                PF087_NUM_APOLICE_VINCULADA = PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_APOLICE_VINCULADA.ToString(),
                PF087_NUM_LINHA_ARQUIVO = PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_LINHA_ARQUIVO.ToString(),
                PF087_DES_CONTEUDO = PF087.DCLPF_PROC_PROPOSTA.PF087_DES_CONTEUDO.ToString(),
                PF087_STA_PROCESSAMENTO = PF087.DCLPF_PROC_PROPOSTA.PF087_STA_PROCESSAMENTO.ToString(),
                PF087_COD_USUARIO = PF087.DCLPF_PROC_PROPOSTA.PF087_COD_USUARIO.ToString(),
            };

            R0558_00_INSERT_CNTRLE_PROC_DB_INSERT_1_Insert1.Execute(r0558_00_INSERT_CNTRLE_PROC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0558_SAIDA*/

        [StopWatch]
        /*" R0559-00-INSERT-CNTRLE-HIST-SECTION */
        private void R0559_00_INSERT_CNTRLE_HIST_SECTION()
        {
            /*" -2474- MOVE 'R0559-00-INSERT-CNTRLE-HIST' TO PARAGRAFO. */
            _.Move("R0559-00-INSERT-CNTRLE-HIST", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2476- MOVE 'INSERT PF_PROC_PROPOSTA_HIST' TO COMANDO. */
            _.Move("INSERT PF_PROC_PROPOSTA_HIST", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2488- PERFORM R0559_00_INSERT_CNTRLE_HIST_DB_INSERT_1 */

            R0559_00_INSERT_CNTRLE_HIST_DB_INSERT_1();

            /*" -2491- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2492- DISPLAY 'VG1617B - FIM ANORMAL' */
                _.Display($"VG1617B - FIM ANORMAL");

                /*" -2493- DISPLAY '          ERRO INSERT TAB. PF_PROC_PROPOST_HIST' */
                _.Display($"          ERRO INSERT TAB. PF_PROC_PROPOST_HIST");

                /*" -2495- DISPLAY '          SIGLA-ARQUIVO..........  ' PF087-SIGLA-ARQUIVO */
                _.Display($"          SIGLA-ARQUIVO..........  {PF087.DCLPF_PROC_PROPOSTA.PF087_SIGLA_ARQUIVO}");

                /*" -2497- DISPLAY '          SISTEMA-ORIGEM.........  ' PF087-SISTEMA-ORIGEM */
                _.Display($"          SISTEMA-ORIGEM.........  {PF087.DCLPF_PROC_PROPOSTA.PF087_SISTEMA_ORIGEM}");

                /*" -2499- DISPLAY '          NSAS-SIVPF.............  ' PF087-NSAS-SIVPF */
                _.Display($"          NSAS-SIVPF.............  {PF087.DCLPF_PROC_PROPOSTA.PF087_NSAS_SIVPF}");

                /*" -2501- DISPLAY '          NUM-PROPOSTA...........  ' PF087-NUM-PROPOSTA */
                _.Display($"          NUM-PROPOSTA...........  {PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_PROPOSTA}");

                /*" -2503- DISPLAY '          SEQ-OCORRENCIA.........  ' PF087-SEQ-OCORRENCIA */
                _.Display($"          SEQ-OCORRENCIA.........  {PF087.DCLPF_PROC_PROPOSTA.PF087_SEQ_OCORRENCIA}");

                /*" -2505- DISPLAY '          SEQ-OCORR-HIST.........  ' PF090-SEQ-OCORR-HIST */
                _.Display($"          SEQ-OCORR-HIST.........  {DCLPF_PROC_PROPOSTA_HIST.PF090_SEQ_OCORR_HIST}");

                /*" -2507- DISPLAY '          STA-PROCESSAMENTO......  ' PF087-STA-PROCESSAMENTO */
                _.Display($"          STA-PROCESSAMENTO......  {PF087.DCLPF_PROC_PROPOSTA.PF087_STA_PROCESSAMENTO}");

                /*" -2509- DISPLAY '          SQLCODE................  ' SQLCODE */
                _.Display($"          SQLCODE................  {DB.SQLCODE}");

                /*" -2510- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2510- END-IF. */
            }


        }

        [StopWatch]
        /*" R0559-00-INSERT-CNTRLE-HIST-DB-INSERT-1 */
        public void R0559_00_INSERT_CNTRLE_HIST_DB_INSERT_1()
        {
            /*" -2488- EXEC SQL INSERT INTO SEGUROS.PF_PROC_PROPOSTA_HIST VALUES (:PF087-SIGLA-ARQUIVO , :PF087-SISTEMA-ORIGEM , :PF087-NSAS-SIVPF , :PF087-NUM-PROPOSTA , :PF087-SEQ-OCORRENCIA , :PF090-SEQ-OCORR-HIST , :PF087-STA-PROCESSAMENTO , :PF087-COD-USUARIO , CURRENT_TIMESTAMP ) END-EXEC. */

            var r0559_00_INSERT_CNTRLE_HIST_DB_INSERT_1_Insert1 = new R0559_00_INSERT_CNTRLE_HIST_DB_INSERT_1_Insert1()
            {
                PF087_SIGLA_ARQUIVO = PF087.DCLPF_PROC_PROPOSTA.PF087_SIGLA_ARQUIVO.ToString(),
                PF087_SISTEMA_ORIGEM = PF087.DCLPF_PROC_PROPOSTA.PF087_SISTEMA_ORIGEM.ToString(),
                PF087_NSAS_SIVPF = PF087.DCLPF_PROC_PROPOSTA.PF087_NSAS_SIVPF.ToString(),
                PF087_NUM_PROPOSTA = PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_PROPOSTA.ToString(),
                PF087_SEQ_OCORRENCIA = PF087.DCLPF_PROC_PROPOSTA.PF087_SEQ_OCORRENCIA.ToString(),
                PF090_SEQ_OCORR_HIST = DCLPF_PROC_PROPOSTA_HIST.PF090_SEQ_OCORR_HIST.ToString(),
                PF087_STA_PROCESSAMENTO = PF087.DCLPF_PROC_PROPOSTA.PF087_STA_PROCESSAMENTO.ToString(),
                PF087_COD_USUARIO = PF087.DCLPF_PROC_PROPOSTA.PF087_COD_USUARIO.ToString(),
            };

            R0559_00_INSERT_CNTRLE_HIST_DB_INSERT_1_Insert1.Execute(r0559_00_INSERT_CNTRLE_HIST_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0559_SAIDA*/

        [StopWatch]
        /*" R2060-00-ATUALIZA-ARQSIVPF-SECTION */
        private void R2060_00_ATUALIZA_ARQSIVPF_SECTION()
        {
            /*" -2522- MOVE 'R2060-00-ATUALIZAR-ARQSIVPF' TO PARAGRAFO. */
            _.Move("R2060-00-ATUALIZAR-ARQSIVPF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2524- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2533- PERFORM R2060_00_ATUALIZA_ARQSIVPF_DB_INSERT_1 */

            R2060_00_ATUALIZA_ARQSIVPF_DB_INSERT_1();

            /*" -2536- IF (SQLCODE NOT EQUAL ZEROS AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -2537- DISPLAY 'VG1617B - FIM ANORMAL' */
                _.Display($"VG1617B - FIM ANORMAL");

                /*" -2538- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -2540- DISPLAY '          SIGLA DO ARQUIVO...............  ' ARQSIVPF-SIGLA-ARQUIVO */
                _.Display($"          SIGLA DO ARQUIVO...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -2542- DISPLAY '          NSAS BENEFC....................  ' ARQSIVPF-NSAS-SIVPF */
                _.Display($"          NSAS BENEFC....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -2544- DISPLAY '          DATA GERACAO..................  ' ARQSIVPF-DATA-GERACAO */
                _.Display($"          DATA GERACAO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -2546- DISPLAY '          QTDE. REGISTROS...............  ' ARQSIVPF-QTDE-REG-GER */
                _.Display($"          QTDE. REGISTROS...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -2548- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2549- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2549- END-IF. */
            }


        }

        [StopWatch]
        /*" R2060-00-ATUALIZA-ARQSIVPF-DB-INSERT-1 */
        public void R2060_00_ATUALIZA_ARQSIVPF_DB_INSERT_1()
        {
            /*" -2533- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:ARQSIVPF-SIGLA-ARQUIVO , :ARQSIVPF-SISTEMA-ORIGEM , :ARQSIVPF-NSAS-SIVPF , :ARQSIVPF-DATA-GERACAO , :ARQSIVPF-QTDE-REG-GER , :ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r2060_00_ATUALIZA_ARQSIVPF_DB_INSERT_1_Insert1 = new R2060_00_ATUALIZA_ARQSIVPF_DB_INSERT_1_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R2060_00_ATUALIZA_ARQSIVPF_DB_INSERT_1_Insert1.Execute(r2060_00_ATUALIZA_ARQSIVPF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_SAIDA*/

        [StopWatch]
        /*" R3000-00-GERAR-CNTRLE-PROC-SECTION */
        private void R3000_00_GERAR_CNTRLE_PROC_SECTION()
        {
            /*" -2557- MOVE 'R3000-00-GERAR-CNTRLE-PROC  ' TO PARAGRAFO. */
            _.Move("R3000-00-GERAR-CNTRLE-PROC  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2560- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2563- MOVE ZEROS TO PF087-SEQ-OCORRENCIA */
            _.Move(0, PF087.DCLPF_PROC_PROPOSTA.PF087_SEQ_OCORRENCIA);

            /*" -2564- MOVE ARQSIVPF-SIGLA-ARQUIVO TO PF087-SIGLA-ARQUIVO */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO, PF087.DCLPF_PROC_PROPOSTA.PF087_SIGLA_ARQUIVO);

            /*" -2565- MOVE ARQSIVPF-SISTEMA-ORIGEM TO PF087-SISTEMA-ORIGEM */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM, PF087.DCLPF_PROC_PROPOSTA.PF087_SISTEMA_ORIGEM);

            /*" -2567- MOVE ARQSIVPF-NSAS-SIVPF TO PF087-NSAS-SIVPF */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, PF087.DCLPF_PROC_PROPOSTA.PF087_NSAS_SIVPF);

            /*" -2568- ADD 1 TO PF087-SEQ-OCORRENCIA */
            PF087.DCLPF_PROC_PROPOSTA.PF087_SEQ_OCORRENCIA.Value = PF087.DCLPF_PROC_PROPOSTA.PF087_SEQ_OCORRENCIA + 1;

            /*" -2569- MOVE W-TB-NUM-APOLICE(W-IND-2) TO PF087-NUM-APOLICE-VINCULADA */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_2].W_TB_NUM_APOLICE, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_APOLICE_VINCULADA);

            /*" -2570- MOVE W-TB-NUM-SUBGRUPO(W-IND-2) TO LC06-NUM-SUBGRUPO */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_2].W_TB_NUM_SUBGRUPO, LC00.LC06.LC06_NUM_SUBGRUPO);

            /*" -2571- MOVE W-TB-NUM-SEQ-REG(W-IND-2) TO LC06-NUM-SEQ-REG */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_2].W_TB_NUM_SEQ_REG, LC00.LC06.LC06_NUM_SEQ_REG);

            /*" -2572- MOVE W-TB-NUM-LIN-ARQ(W-IND-2) TO PF087-NUM-LINHA-ARQUIVO */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_2].W_TB_NUM_LIN_ARQ, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_LINHA_ARQUIVO);

            /*" -2573- MOVE W-TB-COD-ERRO(W-IND-2) TO PF087-NUM-ERRO-PROPOSTA */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_2].W_TB_COD_ERRO, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_ERRO_PROPOSTA);

            /*" -2574- MOVE W-TB-COD-CAMPO(W-IND-2) TO PF087-NUM-DET-ARQ-PROPOSTA */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_2].W_TB_COD_CAMPO, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_DET_ARQ_PROPOSTA);

            /*" -2575- MOVE 100 TO PF087-DES-CONTEUDO-LEN */
            _.Move(100, PF087.DCLPF_PROC_PROPOSTA.PF087_DES_CONTEUDO.PF087_DES_CONTEUDO_LEN);

            /*" -2577- MOVE W-TB-DES-CONTEUDO(W-IND-2) TO PF087-DES-CONTEUDO-TEXT */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_2].W_TB_DES_CONTEUDO, PF087.DCLPF_PROC_PROPOSTA.PF087_DES_CONTEUDO.PF087_DES_CONTEUDO_TEXT);

            /*" -2578- IF (PF087-NUM-ERRO-PROPOSTA EQUAL 00 OR 01) */

            if ((PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_ERRO_PROPOSTA.In("00", "01")))
            {

                /*" -2579- MOVE ZEROS TO PF087-NUM-APOLICE-VINCULADA */
                _.Move(0, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_APOLICE_VINCULADA);

                /*" -2580- MOVE 'P' TO PF087-STA-PROCESSAMENTO */
                _.Move("P", PF087.DCLPF_PROC_PROPOSTA.PF087_STA_PROCESSAMENTO);

                /*" -2581- ELSE */
            }
            else
            {


                /*" -2582- MOVE 'E' TO PF087-STA-PROCESSAMENTO */
                _.Move("E", PF087.DCLPF_PROC_PROPOSTA.PF087_STA_PROCESSAMENTO);

                /*" -2584- END-IF */
            }


            /*" -2585- MOVE 'VG1617B' TO PF087-COD-USUARIO */
            _.Move("VG1617B", PF087.DCLPF_PROC_PROPOSTA.PF087_COD_USUARIO);

            /*" -2587- MOVE 1 TO PF090-SEQ-OCORR-HIST */
            _.Move(1, DCLPF_PROC_PROPOSTA_HIST.PF090_SEQ_OCORR_HIST);

            /*" -2588- PERFORM R0558-00-INSERT-CNTRLE-PROC */

            R0558_00_INSERT_CNTRLE_PROC_SECTION();

            /*" -2590- PERFORM R0559-00-INSERT-CNTRLE-HIST */

            R0559_00_INSERT_CNTRLE_HIST_SECTION();

            /*" -2590- ADD 1 TO WS-CONT-CNTRLE-PROC. */
            WAREA_AUXILIAR.WS_CONT_CNTRLE_PROC.Value = WAREA_AUXILIAR.WS_CONT_CNTRLE_PROC + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_SAIDA*/

        [StopWatch]
        /*" R8001-00-VERIFICA-DATA-VALIDA-SECTION */
        private void R8001_00_VERIFICA_DATA_VALIDA_SECTION()
        {
            /*" -2599- MOVE 'R8001-00-VERIFICA-DATA-VALIDA' TO PARAGRAFO. */
            _.Move("R8001-00-VERIFICA-DATA-VALIDA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2601- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2602- MOVE W-DIA-TRABALHO TO W-DIA-SQL */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -2603- MOVE W-MES-TRABALHO TO W-MES-SQL */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -2605- MOVE W-ANO-TRABALHO TO W-ANO-SQL */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -2608- MOVE '-' TO W-BARRA1-SQL W-BARRA2-SQL */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_SQL);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_SQL);


            /*" -2614- PERFORM R8001_00_VERIFICA_DATA_VALIDA_DB_SELECT_1 */

            R8001_00_VERIFICA_DATA_VALIDA_DB_SELECT_1();

        }

        [StopWatch]
        /*" R8001-00-VERIFICA-DATA-VALIDA-DB-SELECT-1 */
        public void R8001_00_VERIFICA_DATA_VALIDA_DB_SELECT_1()
        {
            /*" -2614- EXEC SQL SELECT DATE(:W-DATA-SQL) INTO :W-DATA-SQL FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' WITH UR END-EXEC. */

            var r8001_00_VERIFICA_DATA_VALIDA_DB_SELECT_1_Query1 = new R8001_00_VERIFICA_DATA_VALIDA_DB_SELECT_1_Query1()
            {
                W_DATA_SQL = WAREA_AUXILIAR.W_DATA_SQL.ToString(),
            };

            var executed_1 = R8001_00_VERIFICA_DATA_VALIDA_DB_SELECT_1_Query1.Execute(r8001_00_VERIFICA_DATA_VALIDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_DATA_SQL, WAREA_AUXILIAR.W_DATA_SQL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8001_99_SAIDA*/

        [StopWatch]
        /*" R8012-00-VERIFICA-SEGURVGA-SECTION */
        private void R8012_00_VERIFICA_SEGURVGA_SECTION()
        {
            /*" -2626- MOVE 'R8012-00-VERIFICA-CLIENTE-APOL' TO PARAGRAFO. */
            _.Move("R8012-00-VERIFICA-CLIENTE-APOL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2628- MOVE 'SELECT CLIENTE/APOLICE' TO COMANDO. */
            _.Move("SELECT CLIENTE/APOLICE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2643- PERFORM R8012_00_VERIFICA_SEGURVGA_DB_SELECT_1 */

            R8012_00_VERIFICA_SEGURVGA_DB_SELECT_1();

            /*" -2646- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -2650- DISPLAY 'R8003 - PROBLEMAS SELECT (SEGURADOS_VGAP) ' SEGURVGA-NUM-APOLICE ' - ' SEGURVGA-COD-SUBGRUPO ' - ' CLIENTES-CGCCPF */

                $"R8003 - PROBLEMAS SELECT (SEGURADOS_VGAP) {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE} - {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO} - {CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF}"
                .Display();

                /*" -2651- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -2652- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2652- END-IF. */
            }


        }

        [StopWatch]
        /*" R8012-00-VERIFICA-SEGURVGA-DB-SELECT-1 */
        public void R8012_00_VERIFICA_SEGURVGA_DB_SELECT_1()
        {
            /*" -2643- EXEC SQL SELECT A.COD_CLIENTE, A.NUM_CERTIFICADO, A.DAC_CERTIFICADO INTO :SEGURVGA-COD-CLIENTE, :SEGURVGA-NUM-CERTIFICADO, :SEGURVGA-DAC-CERTIFICADO FROM SEGUROS.SEGURADOS_VGAP A, SEGUROS.CLIENTES B WHERE A.NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND A.COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO AND A.COD_CLIENTE = B.COD_CLIENTE AND B.CGCCPF = :CLIENTES-CGCCPF FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r8012_00_VERIFICA_SEGURVGA_DB_SELECT_1_Query1 = new R8012_00_VERIFICA_SEGURVGA_DB_SELECT_1_Query1()
            {
                SEGURVGA_COD_SUBGRUPO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                CLIENTES_CGCCPF = CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF.ToString(),
            };

            var executed_1 = R8012_00_VERIFICA_SEGURVGA_DB_SELECT_1_Query1.Execute(r8012_00_VERIFICA_SEGURVGA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_COD_CLIENTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);
                _.Move(executed_1.SEGURVGA_NUM_CERTIFICADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);
                _.Move(executed_1.SEGURVGA_DAC_CERTIFICADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DAC_CERTIFICADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8012_99_SAIDA*/

        [StopWatch]
        /*" R8017-00-UPDATE-BENEFIC-SECTION */
        private void R8017_00_UPDATE_BENEFIC_SECTION()
        {
            /*" -2662- MOVE 'R8017-00-UPDATE-BENEFIC       ' TO PARAGRAFO. */
            _.Move("R8017-00-UPDATE-BENEFIC       ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2664- MOVE 'UPDATE BENEFICIARIO           ' TO COMANDO. */
            _.Move("UPDATE BENEFICIARIO           ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2671- PERFORM R8017_00_UPDATE_BENEFIC_DB_UPDATE_1 */

            R8017_00_UPDATE_BENEFIC_DB_UPDATE_1();

            /*" -2674- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -2678- DISPLAY 'R8017 - PROBLEMAS UPDATE (BENEFICIARIOS)..  ' BENEFICI-NUM-APOLICE ' ...' BENEFICI-COD-SUBGRUPO ' ...' BENEFICI-NUM-CERTIFICADO */

                $"R8017 - PROBLEMAS UPDATE (BENEFICIARIOS)..  {BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_APOLICE} ...{BENEFICI.DCLBENEFICIARIOS.BENEFICI_COD_SUBGRUPO} ...{BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_CERTIFICADO}"
                .Display();

                /*" -2679- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -2680- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2680- END-IF. */
            }


        }

        [StopWatch]
        /*" R8017-00-UPDATE-BENEFIC-DB-UPDATE-1 */
        public void R8017_00_UPDATE_BENEFIC_DB_UPDATE_1()
        {
            /*" -2671- EXEC SQL UPDATE SEGUROS.BENEFICIARIOS SET DATA_TERVIGENCIA = DATE(DATE(:BENEFICI-DATA-INIVIGENCIA) - 1 DAY) WHERE NUM_APOLICE = :BENEFICI-NUM-APOLICE AND COD_SUBGRUPO = :BENEFICI-COD-SUBGRUPO AND NUM_CERTIFICADO = :BENEFICI-NUM-CERTIFICADO END-EXEC. */

            var r8017_00_UPDATE_BENEFIC_DB_UPDATE_1_Update1 = new R8017_00_UPDATE_BENEFIC_DB_UPDATE_1_Update1()
            {
                BENEFICI_DATA_INIVIGENCIA = BENEFICI.DCLBENEFICIARIOS.BENEFICI_DATA_INIVIGENCIA.ToString(),
                BENEFICI_NUM_CERTIFICADO = BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_CERTIFICADO.ToString(),
                BENEFICI_COD_SUBGRUPO = BENEFICI.DCLBENEFICIARIOS.BENEFICI_COD_SUBGRUPO.ToString(),
                BENEFICI_NUM_APOLICE = BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_APOLICE.ToString(),
            };

            R8017_00_UPDATE_BENEFIC_DB_UPDATE_1_Update1.Execute(r8017_00_UPDATE_BENEFIC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8017_99_SAIDA*/

        [StopWatch]
        /*" R8018-00-VALIDA-CPF-SECTION */
        private void R8018_00_VALIDA_CPF_SECTION()
        {
            /*" -2689- MOVE 'R8018-00-VALIDA-CPF' TO PARAGRAFO. */
            _.Move("R8018-00-VALIDA-CPF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2691- MOVE 'VALIDA CPF ' TO COMANDO. */
            _.Move("VALIDA CPF ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2693- MOVE 'PROCPF02' TO WS-CALL */
            _.Move("PROCPF02", WS_CALL);

            /*" -2693- CALL WS-CALL USING LPARM-CPF. */
            _.Call(WS_CALL, LPARM_CPF);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8018_99_SAIDA*/

        [StopWatch]
        /*" R8030-00-VERIFICA-APOL-PROD-SECTION */
        private void R8030_00_VERIFICA_APOL_PROD_SECTION()
        {
            /*" -2702- MOVE 'R8030-00-VERIFICA-APOL-PROD  ' TO PARAGRAFO. */
            _.Move("R8030-00-VERIFICA-APOL-PROD  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2704- MOVE 'SELECT APOLICE ESPECIFICA  ' TO COMANDO. */
            _.Move("SELECT APOLICE ESPECIFICA  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2706- MOVE SPACES TO PRODUVG-ORIG-PRODU */
            _.Move("", PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU);

            /*" -2714- PERFORM R8030_00_VERIFICA_APOL_PROD_DB_SELECT_1 */

            R8030_00_VERIFICA_APOL_PROD_DB_SELECT_1();

            /*" -2717- IF (SQLCODE EQUAL ZEROS AND +100) */

            if ((DB.SQLCODE.In("00", "+100")))
            {

                /*" -2719- DISPLAY 'R8030 - PROBLEMAS SELECT (PRODUTOS_VG)..  ' PRODUVG-NUM-APOLICE */
                _.Display($"R8030 - PROBLEMAS SELECT (PRODUTOS_VG)..  {PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE}");

                /*" -2720- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -2721- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2721- END-IF. */
            }


        }

        [StopWatch]
        /*" R8030-00-VERIFICA-APOL-PROD-DB-SELECT-1 */
        public void R8030_00_VERIFICA_APOL_PROD_DB_SELECT_1()
        {
            /*" -2714- EXEC SQL SELECT VALUE(ESTR_EMISS, ' ' ) INTO :PRODUVG-ESTR-EMISS FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :PRODUVG-NUM-APOLICE ORDER BY COD_SUBGRUPO DESC FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r8030_00_VERIFICA_APOL_PROD_DB_SELECT_1_Query1 = new R8030_00_VERIFICA_APOL_PROD_DB_SELECT_1_Query1()
            {
                PRODUVG_NUM_APOLICE = PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE.ToString(),
            };

            var executed_1 = R8030_00_VERIFICA_APOL_PROD_DB_SELECT_1_Query1.Execute(r8030_00_VERIFICA_APOL_PROD_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_ESTR_EMISS, PRODUVG.DCLPRODUTOS_VG.PRODUVG_ESTR_EMISS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8030_SAIDA*/

        [StopWatch]
        /*" R9979-00-MONTA-TAB-CRITICA-SECTION */
        private void R9979_00_MONTA_TAB_CRITICA_SECTION()
        {
            /*" -2733- MOVE 'R9979-00-MONTA-TAB-CRITICA' TO PARAGRAFO. */
            _.Move("R9979-00-MONTA-TAB-CRITICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2735- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2737- ADD 1 TO W-IND-1 */
            WAREA_AUXILIAR.W_IND_1.Value = WAREA_AUXILIAR.W_IND_1 + 1;

            /*" -2738- IF (W-IND-1 > 9900) */

            if ((WAREA_AUXILIAR.W_IND_1 > 9900))
            {

                /*" -2739- DISPLAY ' ' */
                _.Display($" ");

                /*" -2740- DISPLAY '///////////////////////////////////////////////' */
                _.Display($"///////////////////////////////////////////////");

                /*" -2741- DISPLAY '//           PROGRAMA =>  VG1617B            //' */
                _.Display($"//           PROGRAMA =>  VG1617B            //");

                /*" -2742- DISPLAY '//                                           //' */
                _.Display($"//                                           //");

                /*" -2743- DISPLAY '//                 TERMINO                   //' */
                _.Display($"//                 TERMINO                   //");

                /*" -2744- DISPLAY '//                                           //' */
                _.Display($"//                                           //");

                /*" -2745- DISPLAY '//       ==>   A N O R M A L     <==         //' */
                _.Display($"//       ==>   A N O R M A L     <==         //");

                /*" -2746- DISPLAY '//                                           //' */
                _.Display($"//                                           //");

                /*" -2747- DISPLAY '//    ==> ESTOURO DA TABELA DE ERROS <==     //' */
                _.Display($"//    ==> ESTOURO DA TABELA DE ERROS <==     //");

                /*" -2748- DISPLAY '///////////////////////////////////////////////' */
                _.Display($"///////////////////////////////////////////////");

                /*" -2749- DISPLAY ' ' */
                _.Display($" ");

                /*" -2750- DISPLAY 'VALOR DO INDICE     ' W-IND-1 */
                _.Display($"VALOR DO INDICE     {WAREA_AUXILIAR.W_IND_1}");

                /*" -2751- DISPLAY ' ' */
                _.Display($" ");

                /*" -2752- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2754- END-IF */
            }


            /*" -2755- MOVE WS-NUM-APOLICE TO W-TB-NUM-APOLICE (W-IND-1) */
            _.Move(WS_NUM_APOLICE, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_1].W_TB_NUM_APOLICE);

            /*" -2756- MOVE WS-COD-SUBGRUPO TO W-TB-NUM-SUBGRUPO(W-IND-1) */
            _.Move(WS_COD_SUBGRUPO, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_1].W_TB_NUM_SUBGRUPO);

            /*" -2757- MOVE WS-NUM-CPF-SEG TO W-TB-NUM-CPF-SEG (W-IND-1) */
            _.Move(WS_NUM_CPF_SEG, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_1].W_TB_NUM_CPF_SEG);

            /*" -2758- MOVE WS-NUM-CERTIF TO W-TB-NUM-CERTIF (W-IND-1) */
            _.Move(WS_NUM_CERTIF, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_1].W_TB_NUM_CERTIF);

            /*" -2759- MOVE WS-NUM-SEQ-ARQ TO W-TB-NUM-SEQ-REG (W-IND-1) */
            _.Move(WS_NUM_SEQ_ARQ, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_1].W_TB_NUM_SEQ_REG);

            /*" -2760- MOVE W-LIDO-MOVTO-BENEFC TO W-TB-NUM-LIN-ARQ (W-IND-1) */
            _.Move(WAREA_AUXILIAR.W_LIDO_MOVTO_BENEFC, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_1].W_TB_NUM_LIN_ARQ);

            /*" -2761- MOVE WS-COD-ERRO TO W-TB-COD-ERRO (W-IND-1) */
            _.Move(WS_COD_ERRO, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_1].W_TB_COD_ERRO);

            /*" -2762- MOVE WS-COD-CAMPO TO W-TB-COD-CAMPO (W-IND-1) */
            _.Move(WS_COD_CAMPO, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_1].W_TB_COD_CAMPO);

            /*" -2763- MOVE WS-DES-CONTEUDO TO W-TB-DES-CONTEUDO(W-IND-1) */
            _.Move(WS_DES_CONTEUDO, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_1].W_TB_DES_CONTEUDO);

            /*" -2765- MOVE W-NSAS-FILIAL TO W-TB-NSAS (W-IND-1). */
            _.Move(WAREA_AUXILIAR.W_NSAS_FILIAL, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_1].W_TB_NSAS);

            /*" -2766- IF (WS-COD-ERRO EQUAL 36) */

            if ((WS_COD_ERRO == 36))
            {

                /*" -2767- ADD 1 TO WS-BENEF-GRAVADOS */
                WAREA_AUXILIAR.WS_BENEF_GRAVADOS.Value = WAREA_AUXILIAR.WS_BENEF_GRAVADOS + 1;

                /*" -2768- ELSE */
            }
            else
            {


                /*" -2769- ADD 1 TO WS-QTD-ERRO */
                WAREA_AUXILIAR.WS_QTD_ERRO.Value = WAREA_AUXILIAR.WS_QTD_ERRO + 1;

                /*" -2769- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9979_SAIDA*/

        [StopWatch]
        /*" R9980-00-GERAR-RELATORIO-SECTION */
        private void R9980_00_GERAR_RELATORIO_SECTION()
        {
            /*" -2780- MOVE 'R9980-00-GERAR-RELATORIO' TO PARAGRAFO. */
            _.Move("R9980-00-GERAR-RELATORIO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2782- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2784- MOVE '/' TO W-BARRA1 W-BARRA2 */
            _.Move("/", WAREA_AUXILIAR.W_DTMOVABE1.W_BARRA1);
            _.Move("/", WAREA_AUXILIAR.W_DTMOVABE1.W_BARRA2);


            /*" -2786- MOVE W-DTMOVABE-I TO LC02-DATA. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE_I, LC00.LC02.LC02_DATA);

            /*" -2790- PERFORM R9981-00-INCONSISTENCIA VARYING W-IND-2 FROM 1 BY 1 UNTIL W-IND-2 GREATER W-IND-1. */

            for (WAREA_AUXILIAR.W_IND_2.Value = 1; !(WAREA_AUXILIAR.W_IND_2 > WAREA_AUXILIAR.W_IND_1); WAREA_AUXILIAR.W_IND_2.Value += 1)
            {

                R9981_00_INCONSISTENCIA_SECTION();
            }

            /*" -2792- INITIALIZE W-TAB-CONSISTENCIA. */
            _.Initialize(
                AREA_DAS_TABELAS.W_TAB_CONSISTENCIA
            );

            /*" -2793- MOVE ZEROS TO W-IND-1. */
            _.Move(0, WAREA_AUXILIAR.W_IND_1);

            /*" -2793- MOVE 80 TO W-CONT-LINHAS. */
            _.Move(80, WAREA_AUXILIAR.W_CONT_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9980_SAIDA*/

        [StopWatch]
        /*" R9981-00-INCONSISTENCIA-SECTION */
        private void R9981_00_INCONSISTENCIA_SECTION()
        {
            /*" -2804- MOVE 'R9981-00-INCONSISTENCIA' TO PARAGRAFO. */
            _.Move("R9981-00-INCONSISTENCIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2806- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2807- MOVE W-TB-NUM-APOLICE (W-IND-2) TO LC06-NUM-APOLICE */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_2].W_TB_NUM_APOLICE, LC00.LC06.LC06_NUM_APOLICE);

            /*" -2808- MOVE W-TB-NUM-SUBGRUPO(W-IND-2) TO LC06-NUM-SUBGRUPO */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_2].W_TB_NUM_SUBGRUPO, LC00.LC06.LC06_NUM_SUBGRUPO);

            /*" -2809- MOVE W-TB-NUM-CPF-SEG (W-IND-2) TO LC06-NUM-CPF-SEG */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_2].W_TB_NUM_CPF_SEG, LC00.LC06.LC06_NUM_CPF_SEG);

            /*" -2810- MOVE W-TB-NUM-CERTIF (W-IND-2) TO LC06-NUM-CERTIF */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_2].W_TB_NUM_CERTIF, LC00.LC06.LC06_NUM_CERTIF);

            /*" -2811- MOVE W-TB-NUM-SEQ-REG (W-IND-2) TO LC06-NUM-SEQ-REG */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_2].W_TB_NUM_SEQ_REG, LC00.LC06.LC06_NUM_SEQ_REG);

            /*" -2812- MOVE W-TB-NUM-LIN-ARQ (W-IND-2) TO LC06-NUM-LIN-ARQ */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_2].W_TB_NUM_LIN_ARQ, LC00.LC06.LC06_NUM_LIN_ARQ);

            /*" -2813- MOVE W-TB-COD-ERRO (W-IND-2) TO WS-COD-ERRO */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_2].W_TB_COD_ERRO, WS_COD_ERRO);

            /*" -2815- MOVE W-TB-DESC-ERRO(WS-COD-ERRO) TO LC06-DES-ERRO */
            _.Move(W_TAB_ERRO.W_TAB_ERRO_REG[WS_COD_ERRO].W_TB_DESC_ERRO, LC00.LC06.LC06_DES_ERRO);

            /*" -2816- IF (WS-COD-ERRO EQUAL 36) */

            if ((WS_COD_ERRO == 36))
            {

                /*" -2817- MOVE ZEROS TO LC06-NUM-SEQ-REG */
                _.Move(0, LC00.LC06.LC06_NUM_SEQ_REG);

                /*" -2818- MOVE ZEROS TO LC06-NUM-LIN-ARQ */
                _.Move(0, LC00.LC06.LC06_NUM_LIN_ARQ);

                /*" -2819- MOVE SPACES TO LC06-CAMPO-ERRO */
                _.Move("", LC00.LC06.LC06_CAMPO_ERRO);

                /*" -2820- MOVE SPACES TO LC06-DES-CONTEUDO */
                _.Move("", LC00.LC06.LC06_DES_CONTEUDO);

                /*" -2821- ELSE */
            }
            else
            {


                /*" -2822- MOVE W-TB-COD-CAMPO(W-IND-2) TO WS-COD-CAMPO */
                _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_2].W_TB_COD_CAMPO, WS_COD_CAMPO);

                /*" -2823- MOVE W-TB-NOM-CAMPO(WS-COD-CAMPO) TO LC06-CAMPO-ERRO */
                _.Move(W_TAB_CAMPO.W_TAB_CAMPO_REG[WS_COD_CAMPO].W_TB_NOM_CAMPO, LC00.LC06.LC06_CAMPO_ERRO);

                /*" -2824- MOVE W-TB-DES-CONTEUDO(W-IND-2) TO LC06-DES-CONTEUDO */
                _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_2].W_TB_DES_CONTEUDO, LC00.LC06.LC06_DES_CONTEUDO);

                /*" -2826- END-IF. */
            }


            /*" -2827- IF (W-CONT-LINHAS > 60) */

            if ((WAREA_AUXILIAR.W_CONT_LINHAS > 60))
            {

                /*" -2828- PERFORM R9982-00-GRAVA-CABECALHO */

                R9982_00_GRAVA_CABECALHO_SECTION();

                /*" -2830- END-IF. */
            }


            /*" -2832- WRITE REG-RVG1617B FROM LC06 AFTER 1. */
            _.Move(LC00.LC06.GetMoveValues(), REG_RVG1617B);

            RVG1617B.Write(REG_RVG1617B.GetMoveValues().ToString());

            /*" -2832- ADD 1 TO W-CONT-LINHAS. */
            WAREA_AUXILIAR.W_CONT_LINHAS.Value = WAREA_AUXILIAR.W_CONT_LINHAS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9981_SAIDA*/

        [StopWatch]
        /*" R9982-00-GRAVA-CABECALHO-SECTION */
        private void R9982_00_GRAVA_CABECALHO_SECTION()
        {
            /*" -2843- MOVE 'R9982-00-GRAVA-CABECALHO' TO PARAGRAFO. */
            _.Move("R9982-00-GRAVA-CABECALHO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2845- MOVE 'WRITE' TO COMANDO. */
            _.Move("WRITE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2847- ADD 1 TO LC01-PAGINA. */
            LC00.LC01.LC01_PAGINA.Value = LC00.LC01.LC01_PAGINA + 1;

            /*" -2849- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -2850- MOVE WS-TIME-N TO WS-TIME-EDIT */
            _.Move(WS_TIME.WS_TIME_N, WS_TIME_EDIT);

            /*" -2852- MOVE WS-TIME-EDIT TO LC03-HORA. */
            _.Move(WS_TIME_EDIT, LC00.LC03.LC03_HORA);

            /*" -2854- MOVE W-TB-NSAS(W-IND-2) TO LC04-NSAS-BENEFC. */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_60[WAREA_AUXILIAR.W_IND_2].W_TB_NSAS, LC00.LC04.LC04_NSAS_BENEFC);

            /*" -2856- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -2857- MOVE W-DIA-MOVABE1 TO W-DIA-MOVABEI1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE1, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABEI1);

            /*" -2858- MOVE W-MES-MOVABE1 TO W-MES-MOVABEI1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE1, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABEI1);

            /*" -2860- MOVE W-ANO-MOVABE1 TO W-ANO-MOVABEI1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE1, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABEI1);

            /*" -2863- MOVE '/' TO W-BARRAI1 W-BARRAI2 */
            _.Move("/", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRAI1);
            _.Move("/", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRAI2);


            /*" -2865- MOVE W-DTMOVABE-I TO LC04-DATA-GERACAO. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE_I, LC00.LC04.LC04_DATA_GERACAO);

            /*" -2866- WRITE REG-RVG1617B FROM LC07 AFTER PAGE. */
            _.Move(LC00.LC07.GetMoveValues(), REG_RVG1617B);

            RVG1617B.Write(REG_RVG1617B.GetMoveValues().ToString());

            /*" -2867- WRITE REG-RVG1617B FROM LC01 AFTER 1. */
            _.Move(LC00.LC01.GetMoveValues(), REG_RVG1617B);

            RVG1617B.Write(REG_RVG1617B.GetMoveValues().ToString());

            /*" -2868- WRITE REG-RVG1617B FROM LC02 AFTER 1 */
            _.Move(LC00.LC02.GetMoveValues(), REG_RVG1617B);

            RVG1617B.Write(REG_RVG1617B.GetMoveValues().ToString());

            /*" -2869- WRITE REG-RVG1617B FROM LC03 AFTER 1 */
            _.Move(LC00.LC03.GetMoveValues(), REG_RVG1617B);

            RVG1617B.Write(REG_RVG1617B.GetMoveValues().ToString());

            /*" -2870- WRITE REG-RVG1617B FROM LC04 AFTER 2 */
            _.Move(LC00.LC04.GetMoveValues(), REG_RVG1617B);

            RVG1617B.Write(REG_RVG1617B.GetMoveValues().ToString());

            /*" -2872- WRITE REG-RVG1617B FROM LC07 AFTER 1 */
            _.Move(LC00.LC07.GetMoveValues(), REG_RVG1617B);

            RVG1617B.Write(REG_RVG1617B.GetMoveValues().ToString());

            /*" -2874- WRITE REG-RVG1617B FROM LC05 AFTER 2. */
            _.Move(LC00.LC05.GetMoveValues(), REG_RVG1617B);

            RVG1617B.Write(REG_RVG1617B.GetMoveValues().ToString());

            /*" -2874- MOVE 8 TO W-CONT-LINHAS. */
            _.Move(8, WAREA_AUXILIAR.W_CONT_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9982_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -2883- CLOSE MOV-BENEFC. */
            MOV_BENEFC.Close();

            /*" -2883- CLOSE RVG1617B. */
            RVG1617B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -2894- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -2896- DISPLAY ' ' */
            _.Display($" ");

            /*" -2897- IF (W-FIM-MVTO-BENEFC = 'FIM' ) */

            if ((WAREA_AUXILIAR.W_FIM_MVTO_BENEFC == "FIM"))
            {

                /*" -2898- DISPLAY '  ' */
                _.Display($"  ");

                /*" -2899- DISPLAY '=============================================' */
                _.Display($"=============================================");

                /*" -2900- DISPLAY '============== ESTATISTICA FINAL ============' */
                _.Display($"============== ESTATISTICA FINAL ============");

                /*" -2901- DISPLAY '=============================================' */
                _.Display($"=============================================");

                /*" -2902- DISPLAY 'QUANT. BENEFIC. LIDOS.. ' W-LIDO-MOVTO-BENEFC */
                _.Display($"QUANT. BENEFIC. LIDOS.. {WAREA_AUXILIAR.W_LIDO_MOVTO_BENEFC}");

                /*" -2903- DISPLAY '=============================================' */
                _.Display($"=============================================");

                /*" -2904- DISPLAY 'QUANT. ERRO ENCONTRADOS ' WS-QTD-ERRO */
                _.Display($"QUANT. ERRO ENCONTRADOS {WAREA_AUXILIAR.WS_QTD_ERRO}");

                /*" -2905- DISPLAY 'QUANT. INSERT BENEFIC.. ' WS-TOTAL-INSERT */
                _.Display($"QUANT. INSERT BENEFIC.. {WAREA_AUXILIAR.WS_TOTAL_INSERT}");

                /*" -2906- DISPLAY 'QUANT. CERTIF. CORRETOS ' WS-BENEF-GRAVADOS */
                _.Display($"QUANT. CERTIF. CORRETOS {WAREA_AUXILIAR.WS_BENEF_GRAVADOS}");

                /*" -2908- DISPLAY '=========== VG1617B - FIM NORMAL ============' */
                _.Display($"=========== VG1617B - FIM NORMAL ============");

                /*" -2910- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -2910- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -2913- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -2914- ELSE */
            }
            else
            {


                /*" -2915- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -2916- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

                /*" -2917- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

                /*" -2919- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -2920- MOVE SQLERRMC TO WSQLERRMC */
                _.Move(DB.SQLERRMC, WABEND.WSQLERRO.WSQLERRMC);

                /*" -2922- DISPLAY WSQLERRO */
                _.Display(WABEND.WSQLERRO);

                /*" -2923- DISPLAY '*** VG1617B *** ROLLBACK EM ANDAMENTO ...' */
                _.Display($"*** VG1617B *** ROLLBACK EM ANDAMENTO ...");

                /*" -2924- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -2924- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -2927- MOVE 09 TO RETURN-CODE */
                _.Move(09, RETURN_CODE);

                /*" -2929- END-IF. */
            }


            /*" -2929- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}