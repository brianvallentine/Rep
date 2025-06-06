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
using Sias.VidaEmGrupo.DB2.VG2600B;

namespace Code
{
    public class VG2600B
    {
        public bool IsCall { get; set; }

        public VG2600B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ....... LER ARQUIVO DE PROPOSTAS APOLICES ESPECIFICAS *      */
        /*"      *                  ENVIADAS PELO NOVO PORTAL PJ E INSERE NAS    *       */
        /*"      *                  TABELAS CORPORATIVAS CRIANDO ESTRUTURA DE     *      */
        /*"      *                  DADOS NECESS�RIA PARA INTEGRAR CERTIFICADO    *      */
        /*"      *                  PELO VG0001B.                                 *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ..... EQUIPE ALTRAN - PROJETO FERRAMENTA PJ         *      */
        /*"      *   PROGRAMA ..... VG2600B                                       *      */
        /*"      *   DATA ......... 16/06/2017                                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *VERSAO 24: DEMANDA 517942 - TERCIO CARVALHO 28/07/2023          *      */
        /*"      *           - ABEND -803 NO INSERT DA CLIENTES                   *      */
        /*"      *             PROCURAR POR V.24                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *VERSAO 23: DEMANDA 477782 - BRICEHO 15/03/2023                  *      */
        /*"      *           - CONVERTER DADOS DO REGISTRO 3 PARA CAIXA ALTA      *      */
        /*"      *           - CORRECAO NA CONSULTA DE RISCO PELO SPBVG009        *      */
        /*"      *             PROCURAR POR V.23                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.22  *VERSAO 22: DEMANDA 463491 - TERCIO CARVALHO  03/02/2023         *      */
        /*"      *           - CRITICA INCONSISTENTE DA IDADE DO REPRESENTANTE    *      */
        /*"      *             LEGAL.                                             *      */
        /*"      *           - PROCURAR POR V.22                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.21  *VERSAO 21: DEMANDA 434029 - TERCIO CARVALHO  16/11/2022         *      */
        /*"      *           - INCLUSAO DE SUBGRUPOS VINDOS DO PORTAL PJ          *      */
        /*"      *           - PROCURAR POR V.21                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.20  *VERSAO 20: DEMANDA 440197 - ELIERMES 31/10/2022                 *      */
        /*"      *           - CORRECAO DA GRAVACAO DO CAMPO R1-COD-TP-FATURA NA  *      */
        /*"      *             SUBGVGAP-TIPO-FATURAMENTO E SUBGVGAP-TIPO-COBRANCA *      */
        /*"      *           - PROCURAR POR V.20                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.19  *VERSAO 19: DEMANDA 379166 - Circular 612 - ELIERMES 04/10/2022  *      */
        /*"      *           - REALIZAR A REJEICAO DA PROPOSTA COM ERRO DE PREEN- *      */
        /*"      *             CHIMENTO DE CAMPOS NOVOS APENAS APOS A DATA        *      */
        /*"      *             DE 10/11/2022, ANTES DISSO ACEITAR CAMPOS INCORRE- *      */
        /*"      *             TOS                                                *      */
        /*"      *           - PROCURAR POR V.19                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.18  *VERSAO 18: DEMANDA 379166 - Circular 612 - ELIERMES 21/09/2022  *      */
        /*"      *           - INCLUIDO ROTINA SPBVG009 PARA CONSULTA DO RISCO    *      */
        /*"      *             DA PROPOSTA GERADA PELO MOTOR ANTES DA EMISSAO     *      */
        /*"      *           - MARCA SITUACAO PENDENTE DE CLASSIFICACAO DE RISCO  *      */
        /*"      *             NA TABELA SEGUROS.VG_SOLICITA_FATURA PARA POSTERIOR*      */
        /*"      *             RECLASSIFICACAO PELO VA0603B APOS CHEGADA DE       *      */
        /*"      *             ARQUIVO COM CLASSIFICACAO DE RISCO, CASO NAO SEJA  *      */
        /*"      *             ENCONTRADO NA CONSULTA DO SPBVG009                 *      */
        /*"      *           - PROCURAR POR V.18                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *VERSAO 17: DEMANDA 379166 - Circular 612 - ELIERMES 01/07/2022  *      */
        /*"V.17  *           - ALTERACAO DE LAYOUT DO ARQUIVO DE PROPOSTAS PORTAL *      */
        /*"      *           - IMPLEMENTACAO DA CRITICA DO TIPO DE VINCULO        *      */
        /*"      *           - PROCURAR POR V.17                                  *      */
        /*"JV116 *----------------------------------------------------------------*      */
        /*"JV116 *VERSAO 16: JV1 DEMANDA 262179 - KINKAS 23/10/2020               *      */
        /*"JV116 *           EXCLUI APOLICES/PRODUTOS JV1 - FASE 2                *      */
        /*"JV116 *           - PROCURAR POR JV116                                 *      */
        /*"JV115 *----------------------------------------------------------------*      */
        /*"JV115 *VERSAO 15: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"JV115 *           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"JV115 *           - PROCURAR POR JV115                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.14  *   VERSAO 14  -DEMANDA 246794 - ALTERAR CRITICAS                *      */
        /*"      *   EM 18/06/2020 - KINKAS               PROCURE POR V.14        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.13  *   VERSAO 13  -DEMANDA ###### - ALTERAR CRITICAS                *      */
        /*"      *   EM 04/06/2020 - KINKAS               PROCURE POR V.13        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.12  *   VERSAO 12  -DEMANDA ###### - ELIMINAR -530 INSERT R0530      *      */
        /*"      *   EM 27/04/2020 - KINKAS               PROCURE POR V.12        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.11  *   VERSAO 11  -DEMANDA 241735 - ELIMINAR -803 INSERT DB030      *      */
        /*"      *   EM 17/04/2020 - KINKAS               PROCURE POR V.11        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.10  *   VERSAO 10  -DEMANDA 235266 - CONFORMIDADE - PORTAL PJ SIAS          */
        /*"      *   EM 06/03/2020 - KINKAS               PROCURE POR V.10        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.09  *   VERSAO 09  -DEFEITO 179076 - INCLUI REACESSO NA FONTE (R8002)*      */
        /*"      *   EM 22/11/2019 - KINKAS               PROCURE POR V.09        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.08.1*   VERSAO 08.1-DEFEITO 179076 - INCLUSAO DE DADOS NOS ERROS SQL *      */
        /*"      *   EM 21/11/2019 - KINKAS               PROCURE POR V.08.1      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 08 - DEFEITO 179076 - INCLUSAO DE DADOS NOS ERROS SQL *      */
        /*"V.08  *   EM 19/11/2019 - KINKAS               PROCURE POR V.08        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07 - AJUSTAR A FAIXA DE SALARIO INICIAL               *      */
        /*"      *   EM 24/09/2019 - KINKAS               PROCURE POR V.07        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06 - CORRIGIR CRITICA DE QTD. CARACTERES NOS CAMPOS.  *      */
        /*"      *                                                                *      */
        /*"      *    EM 03/09/2019 - HERVAL SOUZA/KINKAS                         *      */
        /*"      *                                        PROCURE POR  V.06       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV.02 *   VERSAO 05 - PROJETO JOINT VENTURE (JV)                       *      */
        /*"=     *             - AVALIAR IMPACTO PRODUTO, APOLICE, ORGAO, ETC.    *      */
        /*"=     *             - HISTORIA: 206622; TAREFA: 212919                 *      */
        /*"=     *             - ALTERAR CRIT�RIO PARA EMISS�O DA AP�LICE.        *      */
        /*"=     *              .SE PRODUTO JV1, COLOCAR EM AP�LICE ORG�O EMISSOR *      */
        /*"=     *                  300.                                          *      */
        /*"=     *              .CASO CONTR�RIO, CONTINUA IGUAL ATUAL.            *      */
        /*"=     *              .ESPERANDO OS PRODUTOS: 8203, 9311, 9354,         *      */
        /*"=     *                                      JVPRD9311 E JVPRD9354.    *      */
        /*"=     *                                                                *      */
        /*"=     *    EM 14/08/2019 - HERVAL SOUZA                                *      */
        /*"=     *                                        PROCURE POR JV.02       *      */
        /*"JV.02 *----------------------------------------------------------------*      */
        /*"JV.01 *   VERSAO 04 - PROJETO JOINT VENTURE (JV)                       *      */
        /*"=     *             - AVALIAR IMPACTO PRODUTO, APOLICE, ORGAO, ETC.    *      */
        /*"=     *             - HISTORIA: 181057.                                *      */
        /*"=     *             - TRATAMENTO DE FILIAIS PARA BUSCAR ORG�O EMISSOR. *      */
        /*"=     *               SE JV1 ATIVA, E PRODUTO MIGROU, USA 300 FIXO     *      */
        /*"=     *               PARA ORG�O EMISSOR!                              *      */
        /*"=     *             - CONSIDERAR DATA DO HEADER DO ARQUIVO, COMO DATA  *      */
        /*"=     *               DA PROPOSTA E CONSIDERAR NA MIGRA��O PARA JV1    *      */
        /*"=     *    EM 25/01/2019 - HERVAL SOUZA                                *      */
        /*"=     *                                        PROCURE POR JV.01       *      */
        /*"JV.01 *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03 -                                                  *      */
        /*"      *                                                                *      */
        /*"      *             - ALTERACAO DE VALIDACAO DE PROPOSTA JAH PROCESSADA*      */
        /*"      *               PELO SIAS.                                       *      */
        /*"      *                                                                *      */
        /*"      *             - VALIDACAO PASSA A SER FEITA ATRAVES DA TABELA    *      */
        /*"      *               PF_PROC_PROPOSTA COM FOCO EM APOLICES EMITIDAS   *      */
        /*"      *               PELO PORTAL PJ.                                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/05/2018 -  EQUIPE ATOS           PROCURE POR V.03      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02 -                                                  *      */
        /*"      *                                                                *      */
        /*"      *             - DEFINICAO DO PREMIO TOTAL COM BASE NO PRODUTO.   *      */
        /*"      *                                                                *      */
        /*"      *             - ALTERACAO DO TAMANHO DA VARIAVEL TAXA-VG PASSANDO*      */
        /*"      *               DE 9(006)V99 PARA 9(007)V9999.                   *      */
        /*"      *                                                                *      */
        /*"      *             - INSERCAO DE DADOS DE CORRETAGEM PARA SUBG = 0    *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/01/2018 -  EQUIPE ATOS.          PROCURE POR V.02      *      */
        /*"      *=================================================================      */
        #endregion


        #region VARIABLES

        public FileBasis _MOV_PORTAL { get; set; } = new FileBasis(new PIC("X", "600", "X(600)"));

        public FileBasis MOV_PORTAL
        {
            get
            {
                _.Move(REG_PORTAL, _MOV_PORTAL); VarBasis.RedefinePassValue(REG_PORTAL, _MOV_PORTAL, REG_PORTAL); return _MOV_PORTAL;
            }
        }
        public FileBasis _RVG2600B { get; set; } = new FileBasis(new PIC("X", "199", "X(199)"));

        public FileBasis RVG2600B
        {
            get
            {
                _.Move(REG_RVG2600B, _RVG2600B); VarBasis.RedefinePassValue(REG_RVG2600B, _RVG2600B, REG_RVG2600B); return _RVG2600B;
            }
        }
        /*"01   REG-PORTAL.*/
        public VG2600B_REG_PORTAL REG_PORTAL { get; set; } = new VG2600B_REG_PORTAL();
        public class VG2600B_REG_PORTAL : VarBasis
        {
            /*"     10  REG-TIPO-PORTAL                 PIC X(001).*/
            public StringBasis REG_TIPO_PORTAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  REG-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis REG_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"     10  FILLER REDEFINES REG-NUM-PROPOSTA.*/
            private _REDEF_VG2600B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VG2600B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VG2600B_FILLER_0(); _.Move(REG_NUM_PROPOSTA, _filler_0); VarBasis.RedefinePassValue(REG_NUM_PROPOSTA, _filler_0, REG_NUM_PROPOSTA); _filler_0.ValueChanged += () => { _.Move(_filler_0, REG_NUM_PROPOSTA); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, REG_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VG2600B_FILLER_0 : VarBasis
            {
                /*"         15  REG-NOME-ARQUIVO            PIC X(008).*/
                public StringBasis REG_NOME_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"         15  FILLER                      PIC X(006).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                /*"     10  FILLER                          PIC X(585).*/

                public _REDEF_VG2600B_FILLER_0()
                {
                    REG_NOME_ARQUIVO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "585", "X(585)."), @"");
            /*"01   REG-RVG2600B                       PIC X(199).*/
        }
        public StringBasis REG_RVG2600B { get; set; } = new StringBasis(new PIC("X", "199", "X(199)."), @"");

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
        /*"01  VN-COD-PORTE-EMP              PIC S9(04) COMP.*/
        public IntBasis VN_COD_PORTE_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VN-COD-PORTE-EMP-ED           PIC -9.*/
        public IntBasis VN_COD_PORTE_EMP_ED { get; set; } = new IntBasis(new PIC("9", "1", "-9."));
        /*"01  WHOST-NUM-APOLICE             PIC S9(13) COMP-3.*/
        public IntBasis WHOST_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  WHOST-COD-SUBGRUPO            PIC S9(04) COMP.*/
        public IntBasis WHOST_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-DT-CALC.*/
        public VG2600B_WS_DT_CALC WS_DT_CALC { get; set; } = new VG2600B_WS_DT_CALC();
        public class VG2600B_WS_DT_CALC : VarBasis
        {
            /*"    05 WS-DTNASC.*/
            public VG2600B_WS_DTNASC WS_DTNASC { get; set; } = new VG2600B_WS_DTNASC();
            public class VG2600B_WS_DTNASC : VarBasis
            {
                /*"      10 WS-AA-DTNASC               PIC  9(004).*/
                public IntBasis WS_AA_DTNASC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-MM-DTNASC               PIC  9(002).*/
                public IntBasis WS_MM_DTNASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10 FILLER                     PIC  X(001).*/
            }
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"       10 WS-DD-DTNASC               PIC  9(002).*/
            public IntBasis WS_DD_DTNASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 WS-DTPROP.*/
        }
        public VG2600B_WS_DTPROP WS_DTPROP { get; set; } = new VG2600B_WS_DTPROP();
        public class VG2600B_WS_DTPROP : VarBasis
        {
            /*"       10 WS-AA-DTPROP               PIC  9(004).*/
            public IntBasis WS_AA_DTPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"       10 FILLER                     PIC  X(001).*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      10 WS-MM-DTPROP               PIC  9(002).*/
            public IntBasis WS_MM_DTPROP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"       10 FILLER                     PIC  X(001).*/
        }
        public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"       10 WS-DD-DTPROP               PIC  9(002).*/
        public IntBasis WS_DD_DTPROP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"01  WS-JV1-PROGRAMA                  PIC  X(008)    VALUE SPACES*/
        public StringBasis WS_JV1_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  WS-JV1-DTA-PROPOSTA              PIC  X(010).*/
        public StringBasis WS_JV1_DTA_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WS-PROGRAMA                      PIC X(008)  VALUE SPACES.*/
        public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  WS-ENCONTROU-RISCO               PIC X(003)  VALUE SPACES.*/
        public StringBasis WS_ENCONTROU_RISCO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01  WS-QTD-PCR                       PIC 9(008)  VALUE ZEROS.*/
        public IntBasis WS_QTD_PCR { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"01       REG-HEADER.*/
        public VG2600B_REG_HEADER REG_HEADER { get; set; } = new VG2600B_REG_HEADER();
        public class VG2600B_REG_HEADER : VarBasis
        {
            /*"     10  RH-TIPO-REG                 PIC  X(001).*/
            public StringBasis RH_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  FILLER                      PIC  X(020).*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"     10  RH-NOME                     PIC  X(008).*/
            public StringBasis RH_NOME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"     10  RH-DATA-GERACAO             PIC  9(008).*/
            public IntBasis RH_DATA_GERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  RH-SIST-ORIGEM              PIC  9(001).*/
            public IntBasis RH_SIST_ORIGEM { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     10  RH-SIST-DESTINO             PIC  9(001).*/
            public IntBasis RH_SIST_DESTINO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     10  RH-NSAS                     PIC  9(006).*/
            public IntBasis RH_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10  RH-TIPO-ARQUIVO             PIC  9(001).*/
            public IntBasis RH_TIPO_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     10  FILLER                      PIC  X(554).*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "554", "X(554)."), @"");
            /*"01   REG-R1-SUBGRUPO.*/
        }
        public VG2600B_REG_R1_SUBGRUPO REG_R1_SUBGRUPO { get; set; } = new VG2600B_REG_R1_SUBGRUPO();
        public class VG2600B_REG_R1_SUBGRUPO : VarBasis
        {
            /*"     10  R1-TIPO-REG                 PIC  X(001).*/
            public StringBasis R1_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R1-NUM-PROPOSTA             PIC  9(014).*/
            public IntBasis R1_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"     10  R1-NUM-SUBGRUPO             PIC  9(005).*/
            public IntBasis R1_NUM_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"     10  R1-NUM-TIPO-APOL            PIC  X(001).*/
            public StringBasis R1_NUM_TIPO_APOL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R1-NUM-CGC-CNPJ             PIC  9(014).*/
            public IntBasis R1_NUM_CGC_CNPJ { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"     10  R1-NOM-EMPRESA              PIC  X(040).*/
            public StringBasis R1_NOM_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"     10  R1-VAL-FAT-ANUAL            PIC  9(012)V99.*/
            public DoubleBasis R1_VAL_FAT_ANUAL { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"     10  R1-COD-PORTE-EMP            PIC  9(002).*/
            public IntBasis R1_COD_PORTE_EMP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10  R1-DTA-CONST-EMP            PIC  X(008).*/
            public StringBasis R1_DTA_CONST_EMP { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"     10  R1-DTA-INI-VIGENCIA         PIC  X(008).*/
            public StringBasis R1_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"     10  R1-COD-SUCURSAL             PIC  9(004).*/
            public IntBasis R1_COD_SUCURSAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10  R1-IND-OP-COBERTUR          PIC  9(001).*/
            public IntBasis R1_IND_OP_COBERTUR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     10  R1-IND-OP-CORRETAG          PIC  9(001).*/
            public IntBasis R1_IND_OP_CORRETAG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     10  R1-COD-AG-PRODUTORA         PIC  9(004).*/
            public IntBasis R1_COD_AG_PRODUTORA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10  R1-COD-CLASSE-APOL          PIC  X(001).*/
            public StringBasis R1_COD_CLASSE_APOL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R1-COD-TP-PLANO             PIC  X(001).*/
            public StringBasis R1_COD_TP_PLANO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R1-COD-TP-CORRECAO          PIC  X(001).*/
            public StringBasis R1_COD_TP_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  FILLER                      PIC  X(001).*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R1-COD-TP-FATURA            PIC  X(001).*/
            public StringBasis R1_COD_TP_FATURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R1-COD-PERIO-FATURA         PIC  9(002).*/
            public IntBasis R1_COD_PERIO_FATURA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10  R1-IND-FORMA-AVERB          PIC  X(001).*/
            public StringBasis R1_IND_FORMA_AVERB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R1-IND-FORMA-FATURA         PIC  X(001).*/
            public StringBasis R1_IND_FORMA_FATURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R1-IND-COBRA-IOF            PIC  X(001).*/
            public StringBasis R1_IND_COBRA_IOF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R1-QTD-VIDA-CONTRAT         PIC  9(005).*/
            public IntBasis R1_QTD_VIDA_CONTRAT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"     10  R1-VAL-PRM-INICIAL          PIC  9(012)V99.*/
            public DoubleBasis R1_VAL_PRM_INICIAL { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"     10  R1-VAL-CAP-INICIAL          PIC  9(012)V99.*/
            public DoubleBasis R1_VAL_CAP_INICIAL { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"     10  R1-VAL-PRMVG-INICIAL        PIC  9(012)V99.*/
            public DoubleBasis R1_VAL_PRMVG_INICIAL { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"     10  R1-VAL-PRMAP-INICIAL        PIC  9(012)V99.*/
            public DoubleBasis R1_VAL_PRMAP_INICIAL { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"     10  R1-COD-TP-COSSEG-CED        PIC  9(001).*/
            public IntBasis R1_COD_TP_COSSEG_CED { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     10  R1-COD-PRODUTO              PIC  9(004).*/
            public IntBasis R1_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10  R1-IND-OPCAO-CONJUGE        PIC  X(001).*/
            public StringBasis R1_IND_OPCAO_CONJUGE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R1-PER-COBERVG-CONJ         PIC  9(002)V99.*/
            public DoubleBasis R1_PER_COBERVG_CONJ { get; set; } = new DoubleBasis(new PIC("9", "2", "9(002)V99."), 2);
            /*"     10  R1-PER-COBERAP-CONJ         PIC  9(002)V99.*/
            public DoubleBasis R1_PER_COBERAP_CONJ { get; set; } = new DoubleBasis(new PIC("9", "2", "9(002)V99."), 2);
            /*"     10  R1-IND-PLANO-ASSOC          PIC  X(001).*/
            public StringBasis R1_IND_PLANO_ASSOC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R1-IND-COBER-ADIC           PIC  9(001).*/
            public IntBasis R1_IND_COBER_ADIC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     10  R1-IND-VALID-MATRC          PIC  9(001).*/
            public IntBasis R1_IND_VALID_MATRC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     10  R1-NUM-DIA-DEBITO           PIC  9(002).*/
            public IntBasis R1_NUM_DIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10  R1-IND-OPCAO-PAGMTO         PIC  9(001).*/
            public IntBasis R1_IND_OPCAO_PAGMTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     10  R1-NUM-TITULO-RCAP          PIC  9(018).*/
            public IntBasis R1_NUM_TITULO_RCAP { get; set; } = new IntBasis(new PIC("9", "18", "9(018)."));
            /*"     10  R1-DTA-VENC-TITULO          PIC  X(008).*/
            public StringBasis R1_DTA_VENC_TITULO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"     10  R1-VAL-TITULO-RCAP          PIC  9(012)V99.*/
            public DoubleBasis R1_VAL_TITULO_RCAP { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"     10  R1-NUM-BCO-COBR             PIC  9(003).*/
            public IntBasis R1_NUM_BCO_COBR { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"     10  R1-NUM-AGE-COBR             PIC  9(004).*/
            public IntBasis R1_NUM_AGE_COBR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10  R1-NUM-DV-AGE-COBR          PIC  X(001).*/
            public StringBasis R1_NUM_DV_AGE_COBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R1-NUM-OPER-CONTA-COBR      PIC  9(003).*/
            public IntBasis R1_NUM_OPER_CONTA_COBR { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"     10  R1-NUM-CONTA-COBR           PIC  9(012).*/
            public IntBasis R1_NUM_CONTA_COBR { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"     10  R1-NUM-DV-CONTA-COBR        PIC  9(001).*/
            public IntBasis R1_NUM_DV_CONTA_COBR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     10  R1-COD-CNAE-ATIVIDADE       PIC  X(007).*/
            public StringBasis R1_COD_CNAE_ATIVIDADE { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
            /*"     10  R1-IND-PESSOA-PEP           PIC  X(001).*/
            public StringBasis R1_IND_PESSOA_PEP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R1-NOM-ORI-RECURSO-PEP      PIC  X(042).*/
            public StringBasis R1_NOM_ORI_RECURSO_PEP { get; set; } = new StringBasis(new PIC("X", "42", "X(042)."), @"");
            /*"     10  R1-NOM-ORI-PEP-OUTROS       PIC  X(030).*/
            public StringBasis R1_NOM_ORI_PEP_OUTROS { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"     10  R1-NUM-APOLICE              PIC  9(014).*/
            public IntBasis R1_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"     10  FILLER                      PIC  X(234).*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "234", "X(234)."), @"");
            /*"01   REG-R2-ENDERECO.*/
        }
        public VG2600B_REG_R2_ENDERECO REG_R2_ENDERECO { get; set; } = new VG2600B_REG_R2_ENDERECO();
        public class VG2600B_REG_R2_ENDERECO : VarBasis
        {
            /*"     10  R2-TIPO-REG                 PIC  X(001).*/
            public StringBasis R2_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R2-NUM-PROPOSTA             PIC  9(014).*/
            public IntBasis R2_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"     10  R2-NUM-SUBGRUPO             PIC  9(005).*/
            public IntBasis R2_NUM_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"     10  R2-NUM-SEQ-REG-TP02         PIC  9(002).*/
            public IntBasis R2_NUM_SEQ_REG_TP02 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10  R2-NUM-TIPO-END             PIC  9(001).*/
            public IntBasis R2_NUM_TIPO_END { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     10  R2-NOM-ENDERECO             PIC  X(050).*/
            public StringBasis R2_NOM_ENDERECO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
            /*"     10  R2-NOM-COMPLEM-END          PIC  X(072).*/
            public StringBasis R2_NOM_COMPLEM_END { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"     10  R2-NOM-BAIRRO               PIC  X(030).*/
            public StringBasis R2_NOM_BAIRRO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"     10  R2-NOM-CIDADE               PIC  X(035).*/
            public StringBasis R2_NOM_CIDADE { get; set; } = new StringBasis(new PIC("X", "35", "X(035)."), @"");
            /*"     10  R2-SIG-UF                   PIC  X(002).*/
            public StringBasis R2_SIG_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"     10  R2-NUM-CEP                  PIC  9(008).*/
            public IntBasis R2_NUM_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  R2-NUM-DDD-TEL              PIC  9(003).*/
            public IntBasis R2_NUM_DDD_TEL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"     10  R2-NUM-TEL-FIXO             PIC  9(010).*/
            public IntBasis R2_NUM_TEL_FIXO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"     10  R2-NUM-TEL-FAX              PIC  9(010).*/
            public IntBasis R2_NUM_TEL_FAX { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"     10  R2-NUM-TEL-CEL              PIC  9(010).*/
            public IntBasis R2_NUM_TEL_CEL { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"     10  R2-NOM-EMAIL                PIC  X(050).*/
            public StringBasis R2_NOM_EMAIL { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
            /*"     10  FILLER                      PIC  X(297).*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "297", "X(297)."), @"");
            /*"01   REG-R3-REPRESENTANTE.*/
        }
        public VG2600B_REG_R3_REPRESENTANTE REG_R3_REPRESENTANTE { get; set; } = new VG2600B_REG_R3_REPRESENTANTE();
        public class VG2600B_REG_R3_REPRESENTANTE : VarBasis
        {
            /*"     10  R3-TIPO-REG                 PIC  X(001).*/
            public StringBasis R3_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R3-NUM-PROPOSTA             PIC  9(014).*/
            public IntBasis R3_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"     10  R3-NUM-SUBGRUPO             PIC  9(005).*/
            public IntBasis R3_NUM_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"     10  R3-NUM-SEQ-REG-TP03         PIC  9(002).*/
            public IntBasis R3_NUM_SEQ_REG_TP03 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10  R3-NUM-CPF-REPRES           PIC  9(011).*/
            public IntBasis R3_NUM_CPF_REPRES { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"     10  R3-NOM-REPRES-LEGAL         PIC  X(040).*/
            public StringBasis R3_NOM_REPRES_LEGAL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"     10  R3-DTA-NASC-REPRES          PIC  X(008).*/
            public StringBasis R3_DTA_NASC_REPRES { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"     10  R3-IND-SEXO-REPRES          PIC  X(001).*/
            public StringBasis R3_IND_SEXO_REPRES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R3-IND-EST-CIVIL            PIC  X(001).*/
            public StringBasis R3_IND_EST_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R3-VAL-RENDA-REPRES         PIC  9(010)V99.*/
            public DoubleBasis R3_VAL_RENDA_REPRES { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
            /*"     10  R3-NUM-TIPO-END             PIC  9(001).*/
            public IntBasis R3_NUM_TIPO_END { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     10  R3-NOM-ENDERECO             PIC  X(040).*/
            public StringBasis R3_NOM_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"     10  R3-NOM-COMPL-END            PIC  X(015).*/
            public StringBasis R3_NOM_COMPL_END { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"     10  R3-NOM-BAIRRO               PIC  X(020).*/
            public StringBasis R3_NOM_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"     10  R3-NOM-CIDADE               PIC  X(020).*/
            public StringBasis R3_NOM_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"     10  R3-SIG-UF                   PIC  X(002).*/
            public StringBasis R3_SIG_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"     10  R3-NUM-CEP                  PIC  9(008).*/
            public IntBasis R3_NUM_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  R3-COD-CBO                  PIC  9(009).*/
            public IntBasis R3_COD_CBO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"     10  R3-TAB-EMAIL-TEL.*/
            public VG2600B_R3_TAB_EMAIL_TEL R3_TAB_EMAIL_TEL { get; set; } = new VG2600B_R3_TAB_EMAIL_TEL();
            public class VG2600B_R3_TAB_EMAIL_TEL : VarBasis
            {
                /*"       15 R3-TAB-EMAIL-TEL-REG  OCCURS 03  TIMES.*/
                public ListBasis<VG2600B_R3_TAB_EMAIL_TEL_REG> R3_TAB_EMAIL_TEL_REG { get; set; } = new ListBasis<VG2600B_R3_TAB_EMAIL_TEL_REG>(03);
                public class VG2600B_R3_TAB_EMAIL_TEL_REG : VarBasis
                {
                    /*"          20 R3-NOM-EMAIL            PIC  X(050).*/
                    public StringBasis R3_NOM_EMAIL { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                    /*"          20 R3-IND-TIPO-TEL         PIC  9(001).*/
                    public IntBasis R3_IND_TIPO_TEL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"          20 R3-NUM-DDD-TEL          PIC  9(003).*/
                    public IntBasis R3_NUM_DDD_TEL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"          20 R3-NUM-TELEFONE         PIC  9(010).*/
                    public IntBasis R3_NUM_TELEFONE { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                    /*"     10  R3-IND-PESSOA-PEP           PIC  X(001).*/
                }
            }
            public StringBasis R3_IND_PESSOA_PEP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R3-NOM-ORI-RECURSO-PEP      PIC  X(042).*/
            public StringBasis R3_NOM_ORI_RECURSO_PEP { get; set; } = new StringBasis(new PIC("X", "42", "X(042)."), @"");
            /*"     10  R3-NOM-ORI-PEP-OUTROS       PIC  X(030).*/
            public StringBasis R3_NOM_ORI_PEP_OUTROS { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"     10  R3-NOM-VINCULO.*/
            public VG2600B_R3_NOM_VINCULO R3_NOM_VINCULO { get; set; } = new VG2600B_R3_NOM_VINCULO();
            public class VG2600B_R3_NOM_VINCULO : VarBasis
            {
                /*"         15 R3-IND-TIPO-VINCULO      PIC  X(002).*/
                public StringBasis R3_IND_TIPO_VINCULO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"         15 FILLER                   PIC  X(018).*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)."), @"");
                /*"     10  R3-SIG-PARTICIPACAO         PIC  X(003).*/
            }
            public StringBasis R3_SIG_PARTICIPACAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"     10  FILLER                      PIC  X(102).*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "102", "X(102)."), @"");
            /*"01   REG-R4-COBERTURA.*/
        }
        public VG2600B_REG_R4_COBERTURA REG_R4_COBERTURA { get; set; } = new VG2600B_REG_R4_COBERTURA();
        public class VG2600B_REG_R4_COBERTURA : VarBasis
        {
            /*"     10  R4-TIPO-REG                 PIC  X(001).*/
            public StringBasis R4_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R4-NUM-PROPOSTA             PIC  9(014).*/
            public IntBasis R4_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"     10  R4-NUM-SUBGRUPO             PIC  9(005).*/
            public IntBasis R4_NUM_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"     10  R4-NUM-SEQ-REG-TP04         PIC  9(002).*/
            public IntBasis R4_NUM_SEQ_REG_TP04 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10  R4-TAB-COBER-ADIC.*/
            public VG2600B_R4_TAB_COBER_ADIC R4_TAB_COBER_ADIC { get; set; } = new VG2600B_R4_TAB_COBER_ADIC();
            public class VG2600B_R4_TAB_COBER_ADIC : VarBasis
            {
                /*"       15 R4-TAB-COBER-ADIC-REG  OCCURS 06  TIMES.*/
                public ListBasis<VG2600B_R4_TAB_COBER_ADIC_REG> R4_TAB_COBER_ADIC_REG { get; set; } = new ListBasis<VG2600B_R4_TAB_COBER_ADIC_REG>(06);
                public class VG2600B_R4_TAB_COBER_ADIC_REG : VarBasis
                {
                    /*"          20 R4-COD-COBERTURA        PIC  9(005).*/
                    public IntBasis R4_COD_COBERTURA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"          20 R4-VAL-IMP-SEGURADA     PIC  9(012)V99.*/
                    public DoubleBasis R4_VAL_IMP_SEGURADA { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
                    /*"          20 R4-VAL-PRM-INDIVID      PIC  9(009)V99999.*/
                    public DoubleBasis R4_VAL_PRM_INDIVID { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99999."), 5);
                    /*"          20 R4-IND-TRAT-FATURA      PIC  9(001).*/
                    public IntBasis R4_IND_TRAT_FATURA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"          20 R4-IND-TRAT-PREMIO      PIC  9(001).*/
                    public IntBasis R4_IND_TRAT_PREMIO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"          20 R4-PCT-COBER-BASICA     PIC  9(004)V99.*/
                    public DoubleBasis R4_PCT_COBER_BASICA { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V99."), 2);
                    /*"          20 R4-VAL-LIM-MINIMO       PIC  9(012)V99.*/
                    public DoubleBasis R4_VAL_LIM_MINIMO { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
                    /*"          20 R4-VAL-LIM-MAXIMO       PIC  9(012)V99.*/
                    public DoubleBasis R4_VAL_LIM_MAXIMO { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
                    /*"     10  FILLER                      PIC  X(164).*/
                }
            }
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "164", "X(164)."), @"");
            /*"01   REG-R5-CORRETAGEM.*/
        }
        public VG2600B_REG_R5_CORRETAGEM REG_R5_CORRETAGEM { get; set; } = new VG2600B_REG_R5_CORRETAGEM();
        public class VG2600B_REG_R5_CORRETAGEM : VarBasis
        {
            /*"     10  R5-TIPO-REG                 PIC  X(001).*/
            public StringBasis R5_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R5-NUM-PROPOSTA             PIC  9(014).*/
            public IntBasis R5_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"     10  R5-NUM-SUBGRUPO             PIC  9(005).*/
            public IntBasis R5_NUM_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"     10  R5-NUM-SEQ-REG-TP05         PIC  9(002).*/
            public IntBasis R5_NUM_SEQ_REG_TP05 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10  R5-TAB-CORRETAGEM.*/
            public VG2600B_R5_TAB_CORRETAGEM R5_TAB_CORRETAGEM { get; set; } = new VG2600B_R5_TAB_CORRETAGEM();
            public class VG2600B_R5_TAB_CORRETAGEM : VarBasis
            {
                /*"       15 R5-TAB-CORRETAGEM-REG  OCCURS 10  TIMES.*/
                public ListBasis<VG2600B_R5_TAB_CORRETAGEM_REG> R5_TAB_CORRETAGEM_REG { get; set; } = new ListBasis<VG2600B_R5_TAB_CORRETAGEM_REG>(10);
                public class VG2600B_R5_TAB_CORRETAGEM_REG : VarBasis
                {
                    /*"          20 R5-COD-TIPO-CORR        PIC  9(001).*/
                    public IntBasis R5_COD_TIPO_CORR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"          20 R5-COD-CORRETOR         PIC  9(015).*/
                    public IntBasis R5_COD_CORRETOR { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                    /*"          20 R5-PCT-COMERCIALIZ      PIC  9(004)V99.*/
                    public DoubleBasis R5_PCT_COMERCIALIZ { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V99."), 2);
                    /*"          20 R5-PCT-PARTICIPAC       PIC  9(004)V99.*/
                    public DoubleBasis R5_PCT_PARTICIPAC { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V99."), 2);
                    /*"     10  FILLER                      PIC  X(298).*/
                }
            }
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "298", "X(298)."), @"");
            /*"01   REG-R6-PLANO-CONDTEC.*/
        }
        public VG2600B_REG_R6_PLANO_CONDTEC REG_R6_PLANO_CONDTEC { get; set; } = new VG2600B_REG_R6_PLANO_CONDTEC();
        public class VG2600B_REG_R6_PLANO_CONDTEC : VarBasis
        {
            /*"     10  R6-TIPO-REG                 PIC  X(001).*/
            public StringBasis R6_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R6-NUM-PROPOSTA             PIC  9(014).*/
            public IntBasis R6_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"     10  R6-NUM-SUBGRUPO             PIC  9(005).*/
            public IntBasis R6_NUM_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"     10  R6-NUM-SEQ-REG-TP06         PIC  9(002).*/
            public IntBasis R6_NUM_SEQ_REG_TP06 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10  R6-NUM-TIPO-PLANO           PIC  9(001).*/
            public IntBasis R6_NUM_TIPO_PLANO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     10  R6-DTA-INI-VIGENCIA         PIC  X(008).*/
            public StringBasis R6_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"     10  R6-VAL-TAXA-AP              PIC  9(005)V9999.*/
            public DoubleBasis R6_VAL_TAXA_AP { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V9999."), 4);
            /*"     10  R6-VAL-TAXA-AP-MORACID      PIC  9(005)V9999.*/
            public DoubleBasis R6_VAL_TAXA_AP_MORACID { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V9999."), 4);
            /*"     10  R6-VAL-TAXA-AP-INVPERM      PIC  9(005)V9999.*/
            public DoubleBasis R6_VAL_TAXA_AP_INVPERM { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V9999."), 4);
            /*"     10  R6-VAL-TAXA-AP-AMDS         PIC  9(005)V9999.*/
            public DoubleBasis R6_VAL_TAXA_AP_AMDS { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V9999."), 4);
            /*"     10  R6-VAL-TAXA-AP-DH           PIC  9(005)V9999.*/
            public DoubleBasis R6_VAL_TAXA_AP_DH { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V9999."), 4);
            /*"     10  R6-VAL-TAXA-AP-DIT          PIC  9(005)V9999.*/
            public DoubleBasis R6_VAL_TAXA_AP_DIT { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V9999."), 4);
            /*"     10  R6-VAL-CARREGA-PRINC        PIC  9(012)V99.*/
            public DoubleBasis R6_VAL_CARREGA_PRINC { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"     10  R6-VAL-CARREGA-CONJ         PIC  9(012)V99.*/
            public DoubleBasis R6_VAL_CARREGA_CONJ { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"     10  R6-VAL-CARREGA-FILHO        PIC  9(012)V99.*/
            public DoubleBasis R6_VAL_CARREGA_FILHO { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"     10  R6-VAL-GARAN-ADIC-IEA       PIC  9(012)V99.*/
            public DoubleBasis R6_VAL_GARAN_ADIC_IEA { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"     10  R6-VAL-GARAN-ADIC-IPA       PIC  9(012)V99.*/
            public DoubleBasis R6_VAL_GARAN_ADIC_IPA { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"     10  R6-VAL-GARAN-ADIC-IPD       PIC  9(012)V99.*/
            public DoubleBasis R6_VAL_GARAN_ADIC_IPD { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"     10  R6-VAL-GARAN-ADIC-HD        PIC  9(012)V99.*/
            public DoubleBasis R6_VAL_GARAN_ADIC_HD { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"     10  R6-VAL-TAXA-DESP-ADM        PIC  9(012)V99.*/
            public DoubleBasis R6_VAL_TAXA_DESP_ADM { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"     10  R6-VAL-TAXA-IRB             PIC  9(012)V99.*/
            public DoubleBasis R6_VAL_TAXA_IRB { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"     10  R6-QTD-SAL-MORNATU          PIC  9(004).*/
            public IntBasis R6_QTD_SAL_MORNATU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10  R6-QTD-SAL-MORACID          PIC  9(004).*/
            public IntBasis R6_QTD_SAL_MORACID { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10  R6-QTD-SAL-INVPERM          PIC  9(004).*/
            public IntBasis R6_QTD_SAL_INVPERM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10  R6-VAL-LIM-CAP-MORNATU      PIC  9(012)V99.*/
            public DoubleBasis R6_VAL_LIM_CAP_MORNATU { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"     10  R6-VAL-LIM-CAP-MORACID      PIC  9(012)V99.*/
            public DoubleBasis R6_VAL_LIM_CAP_MORACID { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"     10  R6-VAL-LIM-CAP-INVPERM      PIC  9(012)V99.*/
            public DoubleBasis R6_VAL_LIM_CAP_INVPERM { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"     10  R6-VAL-IMP-MORNATU          PIC  9(010)V99.*/
            public DoubleBasis R6_VAL_IMP_MORNATU { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
            /*"     10  R6-VAL-IMP-MORACID          PIC  9(010)V99.*/
            public DoubleBasis R6_VAL_IMP_MORACID { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
            /*"     10  R6-VAL-IMP-INVPERM          PIC  9(010)V99.*/
            public DoubleBasis R6_VAL_IMP_INVPERM { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
            /*"     10  R6-VAL-IMP-AMDS             PIC  9(010)V99.*/
            public DoubleBasis R6_VAL_IMP_AMDS { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
            /*"     10  R6-VAL-IMP-DH               PIC  9(010)V99.*/
            public DoubleBasis R6_VAL_IMP_DH { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
            /*"     10  R6-VAL-IMP-DIT              PIC  9(010)V99.*/
            public DoubleBasis R6_VAL_IMP_DIT { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
            /*"     10  R6-VAL-PRM-AP               PIC  9(008)V99.*/
            public DoubleBasis R6_VAL_PRM_AP { get; set; } = new DoubleBasis(new PIC("9", "8", "9(008)V99."), 2);
            /*"     10  R6-TAB-LIM-TAXAS.*/
            public VG2600B_R6_TAB_LIM_TAXAS R6_TAB_LIM_TAXAS { get; set; } = new VG2600B_R6_TAB_LIM_TAXAS();
            public class VG2600B_R6_TAB_LIM_TAXAS : VarBasis
            {
                /*"       15 R6-TAB-LIM-TAXAS-REG  OCCURS 06  TIMES.*/
                public ListBasis<VG2600B_R6_TAB_LIM_TAXAS_REG> R6_TAB_LIM_TAXAS_REG { get; set; } = new ListBasis<VG2600B_R6_TAB_LIM_TAXAS_REG>(06);
                public class VG2600B_R6_TAB_LIM_TAXAS_REG : VarBasis
                {
                    /*"          20 R6-VAL-LIM-INFERIOR     PIC  9(010).*/
                    public IntBasis R6_VAL_LIM_INFERIOR { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                    /*"          20 R6-VAL-LIM-SUPERIOR     PIC  9(010).*/
                    public IntBasis R6_VAL_LIM_SUPERIOR { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                    /*"          20 R6-VAL-TAXA-VG          PIC  9(007)V9999.*/
                    public DoubleBasis R6_VAL_TAXA_VG { get; set; } = new DoubleBasis(new PIC("9", "7", "9(007)V9999."), 4);
                    /*"          20 R6-VAL-PRM-VG           PIC  9(008)V99.*/
                    public DoubleBasis R6_VAL_PRM_VG { get; set; } = new DoubleBasis(new PIC("9", "8", "9(008)V99."), 2);
                    /*"     10  FILLER                      PIC  X(007).*/
                }
            }
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
            /*"01       REG-TRAILER.*/
        }
        public VG2600B_REG_TRAILER REG_TRAILER { get; set; } = new VG2600B_REG_TRAILER();
        public class VG2600B_REG_TRAILER : VarBasis
        {
            /*"     10  RT-TIPO-REG                 PIC  X(001).*/
            public StringBasis RT_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  FILLER                      PIC  X(020).*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"     10  RT-NOME                     PIC  X(008).*/
            public StringBasis RT_NOME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"     10  RT-QTD-REG-TP01             PIC  9(008).*/
            public IntBasis RT_QTD_REG_TP01 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  RT-QTD-REG-TP02             PIC  9(008).*/
            public IntBasis RT_QTD_REG_TP02 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  RT-QTD-REG-TP03             PIC  9(008).*/
            public IntBasis RT_QTD_REG_TP03 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  RT-QTD-REG-TP04             PIC  9(008).*/
            public IntBasis RT_QTD_REG_TP04 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  RT-QTD-REG-TP05             PIC  9(008).*/
            public IntBasis RT_QTD_REG_TP05 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  RT-QTD-REG-TP06             PIC  9(008).*/
            public IntBasis RT_QTD_REG_TP06 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  RT-QTD-REG-TP07             PIC  9(008).*/
            public IntBasis RT_QTD_REG_TP07 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  RT-QTD-REG-TOTAL            PIC  9(008).*/
            public IntBasis RT_QTD_REG_TOTAL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  FILLER                      PIC  X(507).*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "507", "X(507)."), @"");
            /*"01  WH-QTD-ULT-PROP                  PIC  S9(009) COMP.*/
        }
        public IntBasis WH_QTD_ULT_PROP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WH-APOLICE                       PIC  9(013).*/
        public IntBasis WH_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
        /*"01  FILLER  REDEFINES WH-APOLICE.*/
        private _REDEF_VG2600B_FILLER_19 _filler_19 { get; set; }
        public _REDEF_VG2600B_FILLER_19 FILLER_19
        {
            get { _filler_19 = new _REDEF_VG2600B_FILLER_19(); _.Move(WH_APOLICE, _filler_19); VarBasis.RedefinePassValue(WH_APOLICE, _filler_19, WH_APOLICE); _filler_19.ValueChanged += () => { _.Move(_filler_19, WH_APOLICE); }; return _filler_19; }
            set { VarBasis.RedefinePassValue(value, _filler_19, WH_APOLICE); }
        }  //Redefines
        public class _REDEF_VG2600B_FILLER_19 : VarBasis
        {
            /*"    05  WH-NUM-VIDA                  PIC  9(003).*/
            public IntBasis WH_NUM_VIDA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05  WH-NUM-RAMO                  PIC  9(002).*/
            public IntBasis WH_NUM_RAMO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05  WH-NUM-SEQUENCIAL            PIC  9(008).*/
            public IntBasis WH_NUM_SEQUENCIAL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"01  W-TP-REGISTRO                    PIC  X(001).*/

            public _REDEF_VG2600B_FILLER_19()
            {
                WH_NUM_VIDA.ValueChanged += OnValueChanged;
                WH_NUM_RAMO.ValueChanged += OnValueChanged;
                WH_NUM_SEQUENCIAL.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis W_TP_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
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
        /*"01  WS-TEM-FAIXA-LIM                 PIC  X(001).*/
        public StringBasis WS_TEM_FAIXA_LIM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
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
        /*"01  WS-IDADE-D                       PIC  9(003).*/
        public IntBasis WS_IDADE_D { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
        /*"01  COD-AGENCIA-CEF                  PIC S9(4) USAGE COMP.*/
        public IntBasis COD_AGENCIA_CEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WS-NOME-EMAIL                    PIC X(050) VALUE SPACES.*/
        public StringBasis WS_NOME_EMAIL { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
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
        private _REDEF_VG2600B_WS_TRATA_NOM _ws_trata_nom { get; set; }
        public _REDEF_VG2600B_WS_TRATA_NOM WS_TRATA_NOM
        {
            get { _ws_trata_nom = new _REDEF_VG2600B_WS_TRATA_NOM(); _.Move(WS_TRATA_NOME, _ws_trata_nom); VarBasis.RedefinePassValue(WS_TRATA_NOME, _ws_trata_nom, WS_TRATA_NOME); _ws_trata_nom.ValueChanged += () => { _.Move(_ws_trata_nom, WS_TRATA_NOME); }; return _ws_trata_nom; }
            set { VarBasis.RedefinePassValue(value, _ws_trata_nom, WS_TRATA_NOME); }
        }  //Redefines
        public class _REDEF_VG2600B_WS_TRATA_NOM : VarBasis
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
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)."), @"");
            /*"01  WS-CALL                          PIC  X(08) VALUE SPACES.*/

            public _REDEF_VG2600B_WS_TRATA_NOM()
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
                FILLER_20.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_CALL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
        /*"01 LPARM-CNPJ.*/
        public VG2600B_LPARM_CNPJ LPARM_CNPJ { get; set; } = new VG2600B_LPARM_CNPJ();
        public class VG2600B_LPARM_CNPJ : VarBasis
        {
            /*"   03 LPARM-FILLER                   PIC  X(002) VALUE SPACE.*/
            public StringBasis LPARM_FILLER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"   03 LPARM-ENT-CNPJ                 PIC  9(014) VALUE ZEROS.*/
            public IntBasis LPARM_ENT_CNPJ { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"   03 LPARM-SAI-CNPJ                 PIC  9(001) VALUE ZEROS.*/
            public IntBasis LPARM_SAI_CNPJ { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"01 LPARM-CPF.*/
        }
        public VG2600B_LPARM_CPF LPARM_CPF { get; set; } = new VG2600B_LPARM_CPF();
        public class VG2600B_LPARM_CPF : VarBasis
        {
            /*"   03 LPARM-FILLER-CPF               PIC  X(002) VALUE SPACE.*/
            public StringBasis LPARM_FILLER_CPF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"   03 LPARM-ENT-CPF                  PIC  9(011) VALUE ZEROS.*/
            public IntBasis LPARM_ENT_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"   03 LPARM-SAI-CPF                  PIC  9(001) VALUE ZEROS.*/
            public IntBasis LPARM_SAI_CPF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"01  WS-NUM-AGEN-OPER-CC              PIC  9(15) VALUE ZEROS.*/
        }
        public IntBasis WS_NUM_AGEN_OPER_CC { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
        /*"01  FILLER      REDEFINES    WS-NUM-AGEN-OPER-CC.*/
        private _REDEF_VG2600B_FILLER_21 _filler_21 { get; set; }
        public _REDEF_VG2600B_FILLER_21 FILLER_21
        {
            get { _filler_21 = new _REDEF_VG2600B_FILLER_21(); _.Move(WS_NUM_AGEN_OPER_CC, _filler_21); VarBasis.RedefinePassValue(WS_NUM_AGEN_OPER_CC, _filler_21, WS_NUM_AGEN_OPER_CC); _filler_21.ValueChanged += () => { _.Move(_filler_21, WS_NUM_AGEN_OPER_CC); }; return _filler_21; }
            set { VarBasis.RedefinePassValue(value, _filler_21, WS_NUM_AGEN_OPER_CC); }
        }  //Redefines
        public class _REDEF_VG2600B_FILLER_21 : VarBasis
        {
            /*"    10 WS-AGENCIA                    PIC  9(004).*/
            public IntBasis WS_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10 WS-OPERACAO                   PIC  9(003).*/
            public IntBasis WS_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    10 WS-NUMCONTA                   PIC  9(008).*/
            public IntBasis WS_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"01  WS-PCT-PARTIC-1                PIC S9(004)V99 COMP.*/

            public _REDEF_VG2600B_FILLER_21()
            {
                WS_AGENCIA.ValueChanged += OnValueChanged;
                WS_OPERACAO.ValueChanged += OnValueChanged;
                WS_NUMCONTA.ValueChanged += OnValueChanged;
            }

        }
        public DoubleBasis WS_PCT_PARTIC_1 { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V99"), 2);
        /*"01  WS-PCT-PARTIC-2                PIC S9(004)V99 COMP.*/
        public DoubleBasis WS_PCT_PARTIC_2 { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V99"), 2);
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
                            /*" 88 WS-ENCONTROU-LETRA-SIM-88   VALUE 'S'. */
							new SelectorItemBasis("WS_ENCONTROU_LETRA_SIM_88", "S"),
							/*" 88 WS-ENCONTROU-LETRA-NAO-88   VALUE 'N'. */
							new SelectorItemBasis("WS_ENCONTROU_LETRA_NAO_88", "N")
                }
        };

        /*"01  W-TAB-ERRO.*/
        public VG2600B_W_TAB_ERRO W_TAB_ERRO { get; set; } = new VG2600B_W_TAB_ERRO();
        public class VG2600B_W_TAB_ERRO : VarBasis
        {
            /*"   10 W-TAB-ERRO-REG   OCCURS 999  TIMES INDEXED BY I01.*/
            public ListBasis<VG2600B_W_TAB_ERRO_REG> W_TAB_ERRO_REG { get; set; } = new ListBasis<VG2600B_W_TAB_ERRO_REG>(999);
            public class VG2600B_W_TAB_ERRO_REG : VarBasis
            {
                /*"      15 W-TB-DESC-ERRO         PIC  X(050).*/
                public StringBasis W_TB_DESC_ERRO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"01  W-TAB-CAMPO.*/
            }
        }
        public VG2600B_W_TAB_CAMPO W_TAB_CAMPO { get; set; } = new VG2600B_W_TAB_CAMPO();
        public class VG2600B_W_TAB_CAMPO : VarBasis
        {
            /*"   10 W-TAB-CAMPO-REG   OCCURS 999  TIMES INDEXED BY I02.*/
            public ListBasis<VG2600B_W_TAB_CAMPO_REG> W_TAB_CAMPO_REG { get; set; } = new ListBasis<VG2600B_W_TAB_CAMPO_REG>(999);
            public class VG2600B_W_TAB_CAMPO_REG : VarBasis
            {
                /*"      15 W-TB-NOM-CAMPO         PIC  X(050).*/
                public StringBasis W_TB_NOM_CAMPO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"01  LPARM15X.*/
            }
        }
        public VG2600B_LPARM15X LPARM15X { get; set; } = new VG2600B_LPARM15X();
        public class VG2600B_LPARM15X : VarBasis
        {
            /*"    10      LPARM15             PIC  9(015).*/
            public IntBasis LPARM15 { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    10      FILLER              REDEFINES   LPARM15.*/
            private _REDEF_VG2600B_FILLER_22 _filler_22 { get; set; }
            public _REDEF_VG2600B_FILLER_22 FILLER_22
            {
                get { _filler_22 = new _REDEF_VG2600B_FILLER_22(); _.Move(LPARM15, _filler_22); VarBasis.RedefinePassValue(LPARM15, _filler_22, LPARM15); _filler_22.ValueChanged += () => { _.Move(_filler_22, LPARM15); }; return _filler_22; }
                set { VarBasis.RedefinePassValue(value, _filler_22, LPARM15); }
            }  //Redefines
            public class _REDEF_VG2600B_FILLER_22 : VarBasis
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

                public _REDEF_VG2600B_FILLER_22()
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
            /*"01  WS-TP-REG-PORTAL                 PIC 9(01) VALUE ZEROS.*/
        }
        public IntBasis WS_TP_REG_PORTAL { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
        /*"01  WS-TP-MENSAGEM                   PIC X(08) VALUE SPACES.*/
        public StringBasis WS_TP_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
        /*"01  WS-NUM-PROPOSTA                  PIC 9(14) VALUE ZEROS.*/
        public IntBasis WS_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(14)"));
        /*"01  WS-NUM-APOLICE                   PIC 9(15) VALUE ZEROS.*/
        public IntBasis WS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
        /*"01  WS-COD-SUBGRUPO                  PIC 9(04) VALUE ZEROS.*/
        public IntBasis WS_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"01  WS-NUM-SEQ-ARQ                   PIC 9(04) VALUE ZEROS.*/
        public IntBasis WS_NUM_SEQ_ARQ { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"01  WS-COD-ERRO                      PIC 9(04) VALUE ZEROS.*/
        public IntBasis WS_COD_ERRO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"01  WS-COD-ERRO-ANT                  PIC 9(04) VALUE ZEROS.*/
        public IntBasis WS_COD_ERRO_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"01  WS-COD-CAMPO                     PIC 9(04) VALUE ZEROS.*/
        public IntBasis WS_COD_CAMPO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"01  WS-DES-CONTEUDO                  PIC X(100) VALUE SPACES.*/
        public StringBasis WS_DES_CONTEUDO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
        /*"01  FILLER   REDEFINES    WS-DES-CONTEUDO.*/
        private _REDEF_VG2600B_FILLER_23 _filler_23 { get; set; }
        public _REDEF_VG2600B_FILLER_23 FILLER_23
        {
            get { _filler_23 = new _REDEF_VG2600B_FILLER_23(); _.Move(WS_DES_CONTEUDO, _filler_23); VarBasis.RedefinePassValue(WS_DES_CONTEUDO, _filler_23, WS_DES_CONTEUDO); _filler_23.ValueChanged += () => { _.Move(_filler_23, WS_DES_CONTEUDO); }; return _filler_23; }
            set { VarBasis.RedefinePassValue(value, _filler_23, WS_DES_CONTEUDO); }
        }  //Redefines
        public class _REDEF_VG2600B_FILLER_23 : VarBasis
        {
            /*"   05 WS-DES-CONTEU-N                PIC 9(18).*/
            public IntBasis WS_DES_CONTEU_N { get; set; } = new IntBasis(new PIC("9", "18", "9(18)."));
            /*"   05 FILLER                         PIC X(82).*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "82", "X(82)."), @"");
            /*"01  WAREA-AUXILIAR.*/

            public _REDEF_VG2600B_FILLER_23()
            {
                WS_DES_CONTEU_N.ValueChanged += OnValueChanged;
                FILLER_24.ValueChanged += OnValueChanged;
            }

        }
        public VG2600B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new VG2600B_WAREA_AUXILIAR();
        public class VG2600B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05 W-FIM-FONTE                   PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_FONTE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05 W-FIM-MVTO-PORTAL             PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_MVTO_PORTAL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05 W-FIM-ERROS                   PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_ERROS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05 WS-COD-CBO                    PIC S9(9)   USAGE COMP.*/
            public IntBasis WS_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"    05 W-LIDO-MOVTO-PORTAL           PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_LIDO_MOVTO_PORTAL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
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
            /*"    05 W-QTD-LD-PORTAL-0             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_PORTAL_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-QTD-LD-PORTAL-1             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_PORTAL_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-QTD-LD-PORTAL-2             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_PORTAL_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-QTD-LD-PORTAL-3             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_PORTAL_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-QTD-LD-PORTAL-4             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_PORTAL_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-QTD-LD-PORTAL-5             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_PORTAL_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-QTD-LD-PORTAL-6             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_PORTAL_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-QTD-LD-PORTAL-8             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_PORTAL_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-QTD-LD-PORTAL-9             PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_PORTAL_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-CONT-LINHAS                 PIC  9(08)  VALUE 80.*/
            public IntBasis W_CONT_LINHAS { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"), 80);
            /*"    05 WS-TOTAL-INSERT               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis WS_TOTAL_INSERT { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 WS-CONT-CNTRLE-PROC           PIC  9(08)  VALUE ZEROS.*/
            public IntBasis WS_CONT_CNTRLE_PROC { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 WS-APOL-GRAVADAS              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis WS_APOL_GRAVADAS { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 WS-SUBG-GRAVADOS              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis WS_SUBG_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 WS-QTD-ERRO                   PIC  9(08)  VALUE ZEROS.*/
            public IntBasis WS_QTD_ERRO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 WS-QTD-ALERTA                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis WS_QTD_ALERTA { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-NUM-PROPOSTA-ANT            PIC 9(014)  VALUE ZEROS.*/
            public IntBasis W_NUM_PROPOSTA_ANT { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"    05 W-NSL-SASSE                   PIC 9(006).*/
            public IntBasis W_NSL_SASSE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05 W-NSAS-FILIAL                 PIC 9(006).*/
            public IntBasis W_NSAS_FILIAL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05 W-SIGLA-ARQUIVO               PIC X(008)  VALUE SPACES.*/
            public StringBasis W_SIGLA_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    05 FILLER REDEFINES W-SIGLA-ARQUIVO.*/
            private _REDEF_VG2600B_FILLER_25 _filler_25 { get; set; }
            public _REDEF_VG2600B_FILLER_25 FILLER_25
            {
                get { _filler_25 = new _REDEF_VG2600B_FILLER_25(); _.Move(W_SIGLA_ARQUIVO, _filler_25); VarBasis.RedefinePassValue(W_SIGLA_ARQUIVO, _filler_25, W_SIGLA_ARQUIVO); _filler_25.ValueChanged += () => { _.Move(_filler_25, W_SIGLA_ARQUIVO); }; return _filler_25; }
                set { VarBasis.RedefinePassValue(value, _filler_25, W_SIGLA_ARQUIVO); }
            }  //Redefines
            public class _REDEF_VG2600B_FILLER_25 : VarBasis
            {
                /*"       07  W-IDE-SIGLA               PIC X(004).*/
                public StringBasis W_IDE_SIGLA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"       07  W-IDE-FILIAL              PIC 9(004).*/
                public IntBasis W_IDE_FILIAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DATA-PROPOSTA               PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_VG2600B_FILLER_25()
                {
                    W_IDE_SIGLA.ValueChanged += OnValueChanged;
                    W_IDE_FILIAL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-PROPOSTA.*/
            private _REDEF_VG2600B_FILLER_26 _filler_26 { get; set; }
            public _REDEF_VG2600B_FILLER_26 FILLER_26
            {
                get { _filler_26 = new _REDEF_VG2600B_FILLER_26(); _.Move(W_DATA_PROPOSTA, _filler_26); VarBasis.RedefinePassValue(W_DATA_PROPOSTA, _filler_26, W_DATA_PROPOSTA); _filler_26.ValueChanged += () => { _.Move(_filler_26, W_DATA_PROPOSTA); }; return _filler_26; }
                set { VarBasis.RedefinePassValue(value, _filler_26, W_DATA_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VG2600B_FILLER_26 : VarBasis
            {
                /*"        07  W-ANO-PROPOSTA            PIC 9(004).*/
                public IntBasis W_ANO_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        07  W-MES-PROPOSTA            PIC 9(002).*/
                public IntBasis W_MES_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-DIA-PROPOSTA            PIC 9(002).*/
                public IntBasis W_DIA_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_VG2600B_FILLER_26()
                {
                    W_ANO_PROPOSTA.ValueChanged += OnValueChanged;
                    W_MES_PROPOSTA.ValueChanged += OnValueChanged;
                    W_DIA_PROPOSTA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_VG2600B_FILLER_27 _filler_27 { get; set; }
            public _REDEF_VG2600B_FILLER_27 FILLER_27
            {
                get { _filler_27 = new _REDEF_VG2600B_FILLER_27(); _.Move(W_DATA_TRABALHO, _filler_27); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_27, W_DATA_TRABALHO); _filler_27.ValueChanged += () => { _.Move(_filler_27, W_DATA_TRABALHO); }; return _filler_27; }
                set { VarBasis.RedefinePassValue(value, _filler_27, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_VG2600B_FILLER_27 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DATA-NASCIMENTO             PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_VG2600B_FILLER_27()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-NASCIMENTO.*/
            private _REDEF_VG2600B_FILLER_28 _filler_28 { get; set; }
            public _REDEF_VG2600B_FILLER_28 FILLER_28
            {
                get { _filler_28 = new _REDEF_VG2600B_FILLER_28(); _.Move(W_DATA_NASCIMENTO, _filler_28); VarBasis.RedefinePassValue(W_DATA_NASCIMENTO, _filler_28, W_DATA_NASCIMENTO); _filler_28.ValueChanged += () => { _.Move(_filler_28, W_DATA_NASCIMENTO); }; return _filler_28; }
                set { VarBasis.RedefinePassValue(value, _filler_28, W_DATA_NASCIMENTO); }
            }  //Redefines
            public class _REDEF_VG2600B_FILLER_28 : VarBasis
            {
                /*"        07  W-DIA-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_DIA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_MES_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-NASCIMENTO          PIC 9(004).*/
                public IntBasis W_ANO_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_VG2600B_FILLER_28()
                {
                    W_DIA_NASCIMENTO.ValueChanged += OnValueChanged;
                    W_MES_NASCIMENTO.ValueChanged += OnValueChanged;
                    W_ANO_NASCIMENTO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_VG2600B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_VG2600B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_VG2600B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_VG2600B_W_DTMOVABE1 : VarBasis
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

                public _REDEF_VG2600B_W_DTMOVABE1()
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
            private _REDEF_VG2600B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_VG2600B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_VG2600B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_VG2600B_W_DTMOVABE_I1 : VarBasis
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

                public _REDEF_VG2600B_W_DTMOVABE_I1()
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
            private _REDEF_VG2600B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_VG2600B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_VG2600B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_VG2600B_W_DATA_SQL1 : VarBasis
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
                /*"    05 W-TAB-MOV-PORTAL.*/

                public _REDEF_VG2600B_W_DATA_SQL1()
                {
                    W_ANO_SQL.ValueChanged += OnValueChanged;
                    W_BARRA1_SQL.ValueChanged += OnValueChanged;
                    W_MES_SQL.ValueChanged += OnValueChanged;
                    W_BARRA2_SQL.ValueChanged += OnValueChanged;
                    W_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public VG2600B_W_TAB_MOV_PORTAL W_TAB_MOV_PORTAL { get; set; } = new VG2600B_W_TAB_MOV_PORTAL();
            public class VG2600B_W_TAB_MOV_PORTAL : VarBasis
            {
                /*"       10 W-TAB-MOV-PORTAL  OCCURS 99  TIMES INDEXED BY I00.*/
                public ListBasis<VG2600B_W_TAB_MOV_PORTAL_0> W_TAB_MOV_PORTAL_0 { get; set; } = new ListBasis<VG2600B_W_TAB_MOV_PORTAL_0>(99);
                public class VG2600B_W_TAB_MOV_PORTAL_0 : VarBasis
                {
                    /*"          15 W-TB-MOV-PORTAL   PIC  X(600).*/
                    public StringBasis W_TB_MOV_PORTAL { get; set; } = new StringBasis(new PIC("X", "600", "X(600)."), @"");
                    /*"01  WS-TIME.*/
                }
            }
        }
        public VG2600B_WS_TIME WS_TIME { get; set; } = new VG2600B_WS_TIME();
        public class VG2600B_WS_TIME : VarBasis
        {
            /*"    05 WS-TIME-N                     PIC 9(06).*/
            public IntBasis WS_TIME_N { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 FILLER                        PIC X(02).*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"01  WS-TIME-EDIT                     PIC 99.99.99.*/
        }
        public IntBasis WS_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
        /*"01  WABEND.*/
        public VG2600B_WABEND WABEND { get; set; } = new VG2600B_WABEND();
        public class VG2600B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(010) VALUE            'VG2600B  '.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VG2600B  ");
            /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      05      LOCALIZA-ABEND-1.*/
            public VG2600B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VG2600B_LOCALIZA_ABEND_1();
            public class VG2600B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"        10    FILLER                   PIC  X(012)   VALUE              'PARAGRAFO = '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"        10    PARAGRAFO              PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      05      LOCALIZA-ABEND-2.*/
            }
            public VG2600B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VG2600B_LOCALIZA_ABEND_2();
            public class VG2600B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"        10    FILLER                   PIC  X(012)   VALUE              'COMANDO   = '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"        10    COMANDO                PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"      05         WSQLERRO.*/
            }
            public VG2600B_WSQLERRO WSQLERRO { get; set; } = new VG2600B_WSQLERRO();
            public class VG2600B_WSQLERRO : VarBasis
            {
                /*"        10       FILLER               PIC  X(014) VALUE                ' *** SQLERRMC '.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"        10       WSQLERRMC            PIC  X(070) VALUE  SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01  WREA88.*/
            }
        }
        public VG2600B_WREA88 WREA88 { get; set; } = new VG2600B_WREA88();
        public class VG2600B_WREA88 : VarBasis
        {
            /*"    05  W-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  CANAL  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_VG2600B_CANAL _canal { get; set; }
            public _REDEF_VG2600B_CANAL CANAL
            {
                get { _canal = new _REDEF_VG2600B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VG2600B_CANAL : VarBasis
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
							/*" 88 CANAL-VENDA-PORTALPJ                 VALUE 13. */
							new SelectorItemBasis("CANAL_VENDA_PORTALPJ", "13")
                }
                };

                /*"        07  FILLER                    PIC X(012).*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
                /*"    05  FAIXAS  REDEFINES W-NUM-PROPOSTA.*/

                public _REDEF_VG2600B_CANAL()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_39.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VG2600B_FAIXAS _faixas { get; set; }
            public _REDEF_VG2600B_FAIXAS FAIXAS
            {
                get { _faixas = new _REDEF_VG2600B_FAIXAS(); _.Move(W_NUM_PROPOSTA, _faixas); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _faixas, W_NUM_PROPOSTA); _faixas.ValueChanged += () => { _.Move(_faixas, W_NUM_PROPOSTA); }; return _faixas; }
                set { VarBasis.RedefinePassValue(value, _faixas, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VG2600B_FAIXAS : VarBasis
            {
                /*"        07  FILLER                    PIC X(004).*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
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

                /*"        07  FILLER                    PIC X(007).*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"    05  FILLER  REDEFINES W-NUM-PROPOSTA.*/

                public _REDEF_VG2600B_FAIXAS()
                {
                    FILLER_40.ValueChanged += OnValueChanged;
                    FAIXA_NUMERACAO.ValueChanged += OnValueChanged;
                    FILLER_41.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VG2600B_FILLER_42 _filler_42 { get; set; }
            public _REDEF_VG2600B_FILLER_42 FILLER_42
            {
                get { _filler_42 = new _REDEF_VG2600B_FILLER_42(); _.Move(W_NUM_PROPOSTA, _filler_42); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _filler_42, W_NUM_PROPOSTA); _filler_42.ValueChanged += () => { _.Move(_filler_42, W_NUM_PROPOSTA); }; return _filler_42; }
                set { VarBasis.RedefinePassValue(value, _filler_42, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VG2600B_FILLER_42 : VarBasis
            {
                /*"        07  FILLER                    PIC X(006).*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                /*"        07  PRP-AUTO                  PIC 9(002).*/

                public SelectorBasis PRP_AUTO { get; set; } = new SelectorBasis("002")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 PROPOSTA-AUTOMOVEL      VALUE               30, 31, 32, 34, 35, 37, 39, 40, 41. */
							new SelectorItemBasis("PROPOSTA_AUTOMOVEL", "30,31,32,34,35,37,39,40,41")
                }
                };

                /*"        07  FILLER                    PIC X(006).*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                /*"    05 W-LEITURA-CBO                  PIC  9(001) VALUE ZERO.*/

                public _REDEF_VG2600B_FILLER_42()
                {
                    FILLER_43.ValueChanged += OnValueChanged;
                    PRP_AUTO.ValueChanged += OnValueChanged;
                    FILLER_44.ValueChanged += OnValueChanged;
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
                            /*" 88 MOVTO-CEF-PORTAL                        VALUE 1. */
							new SelectorItemBasis("MOVTO_CEF_PORTAL", "1"),
							/*" 88 MOVTO-PORTAL-FILIAL                     VALUE 2. */
							new SelectorItemBasis("MOVTO_PORTAL_FILIAL", "2"),
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

            /*"    05 W-CRITICA-PROPOSTA             PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_CRITICA_PROPOSTA { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 W-CRITICA-PROPOSTA-NAO-88               VALUE 1. */
							new SelectorItemBasis("W_CRITICA_PROPOSTA_NAO_88", "1"),
							/*" 88 W-CRITICA-PROPOSTA-SIM-88               VALUE 2. */
							new SelectorItemBasis("W_CRITICA_PROPOSTA_SIM_88", "2")
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

            /*"    05 W-VERSAO-PORTAL                 PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_VERSAO_PORTAL { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 VERSAO-PORTAL-NOVA                       VALUE 1. */
							new SelectorItemBasis("VERSAO_PORTAL_NOVA", "1"),
							/*" 88 VERSAO-PORTAL-ANTERIOR                   VALUE 2. */
							new SelectorItemBasis("VERSAO_PORTAL_ANTERIOR", "2")
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
        public VG2600B_LC00 LC00 { get; set; } = new VG2600B_LC00();
        public class VG2600B_LC00 : VarBasis
        {
            /*"  05            LC01.*/
            public VG2600B_LC01 LC01 { get; set; } = new VG2600B_LC01();
            public class VG2600B_LC01 : VarBasis
            {
                /*"    10          LC01-RELATORIO  PIC  X(008) VALUE 'VG2600B '.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG2600B ");
                /*"    10          FILLER          PIC  X(050) VALUE  SPACES.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    10          FILLER          PIC  X(028) VALUE     'C A I X A    S E G U R O S '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"C A I X A    S E G U R O S ");
                /*"    10          FILLER          PIC  X(023) VALUE  SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
                /*"    10          FILLER          PIC  X(012) VALUE '    PAGINA: '*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"    PAGINA: ");
                /*"    10          LC01-PAGINA     PIC  9(04).*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"  05            LC02.*/
            }
            public VG2600B_LC02 LC02 { get; set; } = new VG2600B_LC02();
            public class VG2600B_LC02 : VarBasis
            {
                /*"    10          FILLER          PIC  X(113) VALUE  SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "113", "X(113)"), @"");
                /*"    10          FILLER          PIC  X(008) VALUE 'DATA..: '.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"DATA..: ");
                /*"    10          LC02-DATA       PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC03.*/
            }
            public VG2600B_LC03 LC03 { get; set; } = new VG2600B_LC03();
            public class VG2600B_LC03 : VarBasis
            {
                /*"    10          FILLER          PIC  X(038) VALUE  SPACES.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"");
                /*"    10          FILLER          PIC  X(057) VALUE    'RELATORIO DE CRITICAS DO MOVIMENTO DE PROPOSTAS PORTAL PJ'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"RELATORIO DE CRITICAS DO MOVIMENTO DE PROPOSTAS PORTAL PJ");
                /*"    10          FILLER          PIC  X(018) VALUE  SPACES.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
                /*"    10          FILLER          PIC  X(008) VALUE 'HORA..: '.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"HORA..: ");
                /*"    10          LC03-HORA       PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05            LC04.*/
            }
            public VG2600B_LC04 LC04 { get; set; } = new VG2600B_LC04();
            public class VG2600B_LC04 : VarBasis
            {
                /*"    10          FILLER            PIC  X(021) VALUE               'NUM. ARQ. PROCESSADO:'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"NUM. ARQ. PROCESSADO:");
                /*"    10          LC04-NSAS-PORTAL  PIC  ZZ9999.*/
                public IntBasis LC04_NSAS_PORTAL { get; set; } = new IntBasis(new PIC("9", "6", "ZZ9999."));
                /*"    10          FILLER            PIC  X(013) VALUE               ' - GERADO EM '.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" - GERADO EM ");
                /*"    10          LC04-DATA-GERACAO PIC  X(010).*/
                public StringBasis LC04_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10          FILLER            PIC  X(082) VALUE  SPACES.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "82", "X(082)"), @"");
                /*"  05            LC05.*/
            }
            public VG2600B_LC05 LC05 { get; set; } = new VG2600B_LC05();
            public class VG2600B_LC05 : VarBasis
            {
                /*"    10          FILLER            PIC  X(013) VALUE               'NUM PROPOSTA;'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"NUM PROPOSTA;");
                /*"    10          FILLER            PIC  X(012) VALUE               'NUM APOLICE;'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"NUM APOLICE;");
                /*"    10          FILLER            PIC  X(013) VALUE               'NUM SUBGRUPO;'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"NUM SUBGRUPO;");
                /*"    10          FILLER            PIC  X(017) VALUE               'NUM SEQ REGISTRO;'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"NUM SEQ REGISTRO;");
                /*"    10          FILLER            PIC  X(010) VALUE               'NUM LINHA;'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"NUM LINHA;");
                /*"    10          FILLER            PIC  X(014) VALUE               'TIPO MENSAGEM;'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"TIPO MENSAGEM;");
                /*"    10          FILLER            PIC  X(014) VALUE               'NOME DO CAMPO;'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"NOME DO CAMPO;");
                /*"    10          FILLER            PIC  X(028) VALUE               'DESCRICAO DA INCONSISTENCIA;'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"DESCRICAO DA INCONSISTENCIA;");
                /*"    10          FILLER            PIC  X(017) VALUE               'CONTEUDO ENVIADO;'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"CONTEUDO ENVIADO;");
                /*"  05            LC06.*/
            }
            public VG2600B_LC06 LC06 { get; set; } = new VG2600B_LC06();
            public class VG2600B_LC06 : VarBasis
            {
                /*"    10          FILLER              PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LC06-NUM-PROPOSTA   PIC  9(014).*/
                public IntBasis LC06_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"    10          FILLER              PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LC06-NUM-APOLICE    PIC  9(015).*/
                public IntBasis LC06_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10          FILLER              PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LC06-NUM-SUBGRUPO   PIC  9(003).*/
                public IntBasis LC06_NUM_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10          FILLER              PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LC06-NUM-SEQ-REG    PIC  9(002).*/
                public IntBasis LC06_NUM_SEQ_REG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          FILLER              PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LC06-NUM-LIN-ARQ    PIC  9(008).*/
                public IntBasis LC06_NUM_LIN_ARQ { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10          FILLER              PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LC06-TP-MENSAGEM    PIC  X(008).*/
                public StringBasis LC06_TP_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    10          FILLER              PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LC06-CAMPO-ERRO     PIC  X(025).*/
                public StringBasis LC06_CAMPO_ERRO { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"    10          FILLER              PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LC06-DES-ERRO       PIC  X(050).*/
                public StringBasis LC06_DES_ERRO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"    10          FILLER              PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          LC06-DES-CONTEUDO   PIC  X(050).*/
                public StringBasis LC06_DES_CONTEUDO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"    10          FILLER              PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10          FILLER              PIC  X(024) VALUE  SPACES.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
                /*"  05            LC07.*/
            }
            public VG2600B_LC07 LC07 { get; set; } = new VG2600B_LC07();
            public class VG2600B_LC07 : VarBasis
            {
                /*"    10          FILLER          PIC  X(141) VALUE ALL '-'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "141", "X(141)"), @"ALL");
                /*"01  AREA-DAS-TABELAS.*/
            }
        }
        public VG2600B_AREA_DAS_TABELAS AREA_DAS_TABELAS { get; set; } = new VG2600B_AREA_DAS_TABELAS();
        public class VG2600B_AREA_DAS_TABELAS : VarBasis
        {
            /*"    05 W-TAB-CONSISTENCIA.*/
            public VG2600B_W_TAB_CONSISTENCIA W_TAB_CONSISTENCIA { get; set; } = new VG2600B_W_TAB_CONSISTENCIA();
            public class VG2600B_W_TAB_CONSISTENCIA : VarBasis
            {
                /*"       10 FILLER  OCCURS 9999 TIMES.*/
                public ListBasis<VG2600B_FILLER_79> FILLER_79 { get; set; } = new ListBasis<VG2600B_FILLER_79>(9999);
                public class VG2600B_FILLER_79 : VarBasis
                {
                    /*"          15 W-TB-NUM-TIPO-REG PIC  9(001).*/
                    public IntBasis W_TB_NUM_TIPO_REG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"          15 W-TB-NUM-PROPOSTA PIC  9(014).*/
                    public IntBasis W_TB_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                    /*"          15 W-TB-NUM-APOLICE  PIC  9(015).*/
                    public IntBasis W_TB_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                    /*"          15 W-TB-NUM-SUBGRUPO PIC  9(005).*/
                    public IntBasis W_TB_NUM_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"          15 W-TB-NUM-SEQ-REG  PIC  9(003).*/
                    public IntBasis W_TB_NUM_SEQ_REG { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"          15 W-TB-NUM-LIN-ARQ  PIC  9(008).*/
                    public IntBasis W_TB_NUM_LIN_ARQ { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"          15 W-TB-COD-ERRO     PIC  9(004).*/
                    public IntBasis W_TB_COD_ERRO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"          15 W-TB-COD-CAMPO    PIC  9(004).*/
                    public IntBasis W_TB_COD_CAMPO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"          15 W-TB-TP-MENSAGEM  PIC  X(008).*/
                    public StringBasis W_TB_TP_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                    /*"          15 W-TB-NSAS         PIC  9(006).*/
                    public IntBasis W_TB_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"          15 W-TB-DES-CONTEUDO PIC  X(040).*/
                    public StringBasis W_TB_DES_CONTEUDO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                    /*"    05 W-TAB-DESCRICAO.*/
                }
            }
            public VG2600B_W_TAB_DESCRICAO W_TAB_DESCRICAO { get; set; } = new VG2600B_W_TAB_DESCRICAO();
            public class VG2600B_W_TAB_DESCRICAO : VarBasis
            {
                /*"       10 FILLER               PIC  X(050)     VALUE          '000-PROPOSTA INCLUIDA COM SUCESSO NO SIAS         '.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"000-PROPOSTA INCLUIDA COM SUCESSO NO SIAS         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '001-MOVIMENTO NAO POSSUI HEADER                   '.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"001-MOVIMENTO NAO POSSUI HEADER                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '002-NOME DO ARQUIVO INVALIDO                      '.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"002-NOME DO ARQUIVO INVALIDO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '003-DATA DA GERACAO INVALIDA                      '.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"003-DATA DA GERACAO INVALIDA                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '004-SISTEMA ORIGEM INVALIDO                       '.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"004-SISTEMA ORIGEM INVALIDO                       ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '005-SISTEMA DESTINO INVALIDO                      '.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"005-SISTEMA DESTINO INVALIDO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '006-TIPO DE ARQUIVO INVALIDO                      '.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"006-TIPO DE ARQUIVO INVALIDO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '007-SEQUENCIAL DO ARQUIVO INVALIDO                '.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"007-SEQUENCIAL DO ARQUIVO INVALIDO                ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '008-MOVIMENTO JAH PROCESSADO                      '.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"008-MOVIMENTO JAH PROCESSADO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '099-EXISTE RISCO PARA A CONTRATACAO DO SUBGRUPO   '.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"099-EXISTE RISCO PARA A CONTRATACAO DO SUBGRUPO   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '100-APOLICE NAO ESTA ATIVA - CAD SUBGRUPO         '.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"100-APOLICE NAO ESTA ATIVA - CAD SUBGRUPO         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '101-NUM-PROPOSTA NAO NUMERICO OU ZERADA           '.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"101-NUM-PROPOSTA NAO NUMERICO OU ZERADA           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '102-NUM-PROPOSTA JA PROCESSADA PELO SIAS          '.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"102-NUM-PROPOSTA JA PROCESSADA PELO SIAS          ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '103-NUM-SUBGRUPO NAO NUMERICO                     '.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"103-NUM-SUBGRUPO NAO NUMERICO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '104-NUM-TIPO-APOL NAO INVALIDO                    '.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"104-NUM-TIPO-APOL NAO INVALIDO                    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '105-NOM-EMPRESA EM BRANCO                         '.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"105-NOM-EMPRESA EM BRANCO                         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '106-VAL-FAT-ANUAL NAO INVALIDO                    '.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"106-VAL-FAT-ANUAL NAO INVALIDO                    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '107-COD-PORTE-EMP NAO INVALIDO                    '.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"107-COD-PORTE-EMP NAO INVALIDO                    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '108-DTA-CONST-EMP EH NAO VALIDA                   '.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"108-DTA-CONST-EMP EH NAO VALIDA                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '109-DTA-INI-VIGENCIA EH NAO VALIDA                '.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"109-DTA-INI-VIGENCIA EH NAO VALIDA                ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '110-COD-SUCURSAL NAO INVALIDO                     '.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"110-COD-SUCURSAL NAO INVALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '111-COD-SUCURSAL NAO EXISTE NO SIAS               '.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"111-COD-SUCURSAL NAO EXISTE NO SIAS               ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '112-IND-OP-COBERTUR NAO INVALIDO                  '.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"112-IND-OP-COBERTUR NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '113-IND-OP-CORRETAG NAO INVALIDO                  '.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"113-IND-OP-CORRETAG NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '114-COD-AG-PRODUTORA NAO INVALIDO OU ZERADA       '.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"114-COD-AG-PRODUTORA NAO INVALIDO OU ZERADA       ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '115-COD-AG-PRODUTORA NAO EXISTE NO SIAS           '.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"115-COD-AG-PRODUTORA NAO EXISTE NO SIAS           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '116-COD-CLASSE-APOL NAO INVALIDA                  '.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"116-COD-CLASSE-APOL NAO INVALIDA                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '117-COD-TP-PLANO NAO INVALIDO                     '.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"117-COD-TP-PLANO NAO INVALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '118-COD-TP-CORRECAO NAO INVALIDO                  '.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"118-COD-TP-CORRECAO NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '119-PERIO-FATURA NAO INVALIDO                     '.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"119-PERIO-FATURA NAO INVALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '120-IND-FORMA-AVERB NAO INVALIDO                  '.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"120-IND-FORMA-AVERB NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '121-IND-FORMA-FATURA NAO INVALIDO                 '.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"121-IND-FORMA-FATURA NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '122-IND-COBRA-IOF NAO INVALIDO                    '.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"122-IND-COBRA-IOF NAO INVALIDO                    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '123-QTD-VIDA-CONTRAT NAO INVALIDO                 '.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"123-QTD-VIDA-CONTRAT NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '124-VAL-PRM-INICIAL NAO INVALIDO                  '.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"124-VAL-PRM-INICIAL NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '125-VAL-CAP-INICIAL NAO INVALIDO                  '.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"125-VAL-CAP-INICIAL NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '126-VAL-PRMVG-INICIAL NAO INVALIDO                '.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"126-VAL-PRMVG-INICIAL NAO INVALIDO                ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '127-VAL-PRMAP-INICIAL NAO INVALIDO                '.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"127-VAL-PRMAP-INICIAL NAO INVALIDO                ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '128-COD-TP-COSSEG-CED NAO INVALIDO                '.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"128-COD-TP-COSSEG-CED NAO INVALIDO                ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '129-COD-PRODUTO NAO INVALIDO                      '.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"129-COD-PRODUTO NAO INVALIDO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '130-R1-IND-OPCAO-CONJUGE NAO INVALIDO             '.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"130-R1-IND-OPCAO-CONJUGE NAO INVALIDO             ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '131-PER-COBERVG-CONJ NAO INVALIDO                 '.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"131-PER-COBERVG-CONJ NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '132-PER-COBERAP-CONJ NAO INVALIDO                 '.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"132-PER-COBERAP-CONJ NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '133-IND-PLANO-ASSOC NAO INVALIDO                  '.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"133-IND-PLANO-ASSOC NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '134-IND-COBER-ADIC NAO INVALIDO                   '.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"134-IND-COBER-ADIC NAO INVALIDO                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '135-IND-VALID-MATRC NAO INVALIDO                  '.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"135-IND-VALID-MATRC NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '136-NUM-DIA-DEBITO NAO INVALIDO                   '.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"136-NUM-DIA-DEBITO NAO INVALIDO                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '137-IND-OPCAO-PAGMTO NAO INVALIDO                 '.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"137-IND-OPCAO-PAGMTO NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '138-NUM-TITULO-RCAP NAO INVALIDO                  '.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"138-NUM-TITULO-RCAP NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '139-DTA-VENC-TITULO EH NAO VALIDA                 '.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"139-DTA-VENC-TITULO EH NAO VALIDA                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '140-VAL-TITULO-RCAP NAO INVALIDO                  '.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"140-VAL-TITULO-RCAP NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '141-NUM-BCO-COBR NAO INVALIDO                     '.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"141-NUM-BCO-COBR NAO INVALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '142-NUM-AGE-COBR NAO INVALIDO                     '.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"142-NUM-AGE-COBR NAO INVALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '143-NUM-AGE-COBR NAO CADASTRADA NO SIAS           '.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"143-NUM-AGE-COBR NAO CADASTRADA NO SIAS           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '144-NUM-CONTA-COBR NAO INVALIDO                   '.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"144-NUM-CONTA-COBR NAO INVALIDO                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '145-NUM-OPER-CONTA-COBR NAO INVALIDO              '.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"145-NUM-OPER-CONTA-COBR NAO INVALIDO              ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '146-NUM-DV-CONTA-COBR NAO INVALIDO P/ AGE/OPER/CON'.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"146-NUM-DV-CONTA-COBR NAO INVALIDO P/ AGE/OPER/CON");
                /*"       10 FILLER               PIC  X(050)     VALUE          '147-R1-NUM-CGC-CNPJ NAO INVALIDO                  '.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"147-R1-NUM-CGC-CNPJ NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '148-NUM-CGC-CNPJ DV INVALIDO                      '.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"148-NUM-CGC-CNPJ DV INVALIDO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '149-PER-COBERVG-CONJ NAO INVALIDO                 '.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"149-PER-COBERVG-CONJ NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '150-PER-COBERAP-CONJ NAO INVALIDO                 '.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"150-PER-COBERAP-CONJ NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '151-NOM-EMPRESA COM MENOS DE 5 CARACTERES         '.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"151-NOM-EMPRESA COM MENOS DE 5 CARACTERES         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '152-NUM-DV-AGE-COBR NAO INVALIDO P/ BCO/AGE/DAC   '.*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"152-NUM-DV-AGE-COBR NAO INVALIDO P/ BCO/AGE/DAC   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '201-NUM-PROPOSTA NAO NUMERICO OU ZERADA           '.*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"201-NUM-PROPOSTA NAO NUMERICO OU ZERADA           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '203-NUM-SUBGRUPO NAO NUMERICO                     '.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"203-NUM-SUBGRUPO NAO NUMERICO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '204-NUM-SEQ-REG-TP02 NAO INVALIDO                 '.*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"204-NUM-SEQ-REG-TP02 NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '205-R2-NUM-TIPO-END NAO INVALIDO                  '.*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"205-R2-NUM-TIPO-END NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '206-NOM-ENDERECO EM BRANCO                        '.*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"206-NOM-ENDERECO EM BRANCO                        ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '207-NOM-ENDERECO COM MENOS DE 3 CARACTERES        '.*/
                public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"207-NOM-ENDERECO COM MENOS DE 3 CARACTERES        ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '208-NOM-CIDADE EM BRANCO                          '.*/
                public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"208-NOM-CIDADE EM BRANCO                          ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '209-NOM-CIDADE COM MENOS DE 3 CARACTERES          '.*/
                public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"209-NOM-CIDADE COM MENOS DE 3 CARACTERES          ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '210-NOM-CIDADE COM CARACTERES INVALIDOS           '.*/
                public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"210-NOM-CIDADE COM CARACTERES INVALIDOS           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '211-NOM-ENDERECO COM CARACTERES INVALIDOS         '.*/
                public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"211-NOM-ENDERECO COM CARACTERES INVALIDOS         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '212-SIGLA-UF EM BRANCO                            '.*/
                public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"212-SIGLA-UF EM BRANCO                            ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '213-SIGLA-UF NAO INVALIDA                         '.*/
                public StringBasis FILLER_154 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"213-SIGLA-UF NAO INVALIDA                         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '214-NUM-CEP NAO INVALIDO                          '.*/
                public StringBasis FILLER_155 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"214-NUM-CEP NAO INVALIDO                          ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '215-NUM-DDD-TEL NAO INVALIDO                      '.*/
                public StringBasis FILLER_156 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"215-NUM-DDD-TEL NAO INVALIDO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '216-NUM-TEL-FIXO NAO INVALIDO                     '.*/
                public StringBasis FILLER_157 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"216-NUM-TEL-FIXO NAO INVALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '217-NUM-TEL-FAX NAO INVALIDO                      '.*/
                public StringBasis FILLER_158 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"217-NUM-TEL-FAX NAO INVALIDO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '218-NUM-TEL-CEL NAO INVALIDO                      '.*/
                public StringBasis FILLER_159 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"218-NUM-TEL-CEL NAO INVALIDO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '219-NOM-EMAIL NAO INVALIDO                        '.*/
                public StringBasis FILLER_160 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"219-NOM-EMAIL NAO INVALIDO                        ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '220-NOM-EMAIL COM MENOS DE 10 CARACTERES          '.*/
                public StringBasis FILLER_161 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"220-NOM-EMAIL COM MENOS DE 10 CARACTERES          ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '221-NUM-SUBGRUPO NAO EXISTE PARA CADASTRAR ENDEREC'.*/
                public StringBasis FILLER_162 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"221-NUM-SUBGRUPO NAO EXISTE PARA CADASTRAR ENDEREC");
                /*"       10 FILLER               PIC  X(050)     VALUE          '301-NUM-PROPOSTA NAO NUMERICO OU ZERADA           '.*/
                public StringBasis FILLER_163 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"301-NUM-PROPOSTA NAO NUMERICO OU ZERADA           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '303-NUM-SUBGRUPO NAO NUMERICO                     '.*/
                public StringBasis FILLER_164 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"303-NUM-SUBGRUPO NAO NUMERICO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '304-NUM-SEQ-REG-TP04 NAO INVALIDO                 '.*/
                public StringBasis FILLER_165 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"304-NUM-SEQ-REG-TP04 NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '305-NUM-CPF-REPRES NAO INVALIDO                   '.*/
                public StringBasis FILLER_166 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"305-NUM-CPF-REPRES NAO INVALIDO                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '306-NUM-CPF-REPRES COM DV INVALIDO                '.*/
                public StringBasis FILLER_167 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"306-NUM-CPF-REPRES COM DV INVALIDO                ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '307-NOM-REPRES-LEGAL EM BRANCO                    '.*/
                public StringBasis FILLER_168 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"307-NOM-REPRES-LEGAL EM BRANCO                    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '308-NOM-REPRES-LEGAL COM MENOS DE 5 CARACTERES    '.*/
                public StringBasis FILLER_169 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"308-NOM-REPRES-LEGAL COM MENOS DE 5 CARACTERES    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '309-DTA-NASC-REPRES EM BRANCO                     '.*/
                public StringBasis FILLER_170 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"309-DTA-NASC-REPRES EM BRANCO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '310-DTA-NASC-REPRES NAO VALIDA                    '.*/
                public StringBasis FILLER_171 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"310-DTA-NASC-REPRES NAO VALIDA                    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '311-DTA-NASC-REPRES NAO VALIDA                    '.*/
                public StringBasis FILLER_172 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"311-DTA-NASC-REPRES NAO VALIDA                    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '312-IND-SEXO-REPRES NAO VALIDO                    '.*/
                public StringBasis FILLER_173 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"312-IND-SEXO-REPRES NAO VALIDO                    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '313-IND-SEXO-REPRES NAO VALIDO                    '.*/
                public StringBasis FILLER_174 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"313-IND-SEXO-REPRES NAO VALIDO                    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '314-IND-EST-CIVIL NAO VALIDO                      '.*/
                public StringBasis FILLER_175 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"314-IND-EST-CIVIL NAO VALIDO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '315-VAL-RENDA-REPRES NAO VALIDO OU ZERADO         '.*/
                public StringBasis FILLER_176 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"315-VAL-RENDA-REPRES NAO VALIDO OU ZERADO         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '316-NUM-TIPO-END NAO INVALIDO                     '.*/
                public StringBasis FILLER_177 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"316-NUM-TIPO-END NAO INVALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '317-NOM-ENDERECO EM BRANCO                        '.*/
                public StringBasis FILLER_178 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"317-NOM-ENDERECO EM BRANCO                        ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '318-NOM-ENDERECO COM MENOS DE 3 CARACTERES        '.*/
                public StringBasis FILLER_179 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"318-NOM-ENDERECO COM MENOS DE 3 CARACTERES        ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '319-NOM-ENDERECO COM CARACTERES INVALIDOS         '.*/
                public StringBasis FILLER_180 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"319-NOM-ENDERECO COM CARACTERES INVALIDOS         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '320-NOM-COMPL-END NAO VALIDO                      '.*/
                public StringBasis FILLER_181 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"320-NOM-COMPL-END NAO VALIDO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '321-NOM-CIDADE EM BRANCO                          '.*/
                public StringBasis FILLER_182 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"321-NOM-CIDADE EM BRANCO                          ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '322-NOM-CIDADE COM MENOS DE 3 CARACTERES          '.*/
                public StringBasis FILLER_183 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"322-NOM-CIDADE COM MENOS DE 3 CARACTERES          ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '323-NOM-CIDADE COM CARACTERES INVALIDOS           '.*/
                public StringBasis FILLER_184 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"323-NOM-CIDADE COM CARACTERES INVALIDOS           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '324-NOM-BAIRRO NAO VALIDO                         '.*/
                public StringBasis FILLER_185 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"324-NOM-BAIRRO NAO VALIDO                         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '325-SIGLA-UF EM BRANCO                            '.*/
                public StringBasis FILLER_186 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"325-SIGLA-UF EM BRANCO                            ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '326-SIGLA-UF NAO INVALIDA                         '.*/
                public StringBasis FILLER_187 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"326-SIGLA-UF NAO INVALIDA                         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '327-NUM-CEP NAO INVALIDO                          '.*/
                public StringBasis FILLER_188 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"327-NUM-CEP NAO INVALIDO                          ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '328-NOM-EMAIL NAO INVALIDO                        '.*/
                public StringBasis FILLER_189 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"328-NOM-EMAIL NAO INVALIDO                        ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '329-NOM-EMAIL NAO INVALIDO                        '.*/
                public StringBasis FILLER_190 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"329-NOM-EMAIL NAO INVALIDO                        ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '330-NOM-EMAIL COM MENOS DE 10 CARACTERES          '.*/
                public StringBasis FILLER_191 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"330-NOM-EMAIL COM MENOS DE 10 CARACTERES          ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '331-IND-TIPO-TEL NAO INVALIDO                     '.*/
                public StringBasis FILLER_192 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"331-IND-TIPO-TEL NAO INVALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '332-NUM-DDD-TEL NAO INVALIDO                      '.*/
                public StringBasis FILLER_193 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"332-NUM-DDD-TEL NAO INVALIDO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '333-NUM-TELEFONE NAO INVALIDO                     '.*/
                public StringBasis FILLER_194 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"333-NUM-TELEFONE NAO INVALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '334-COD-CBO NAO INVALIDO                          '.*/
                public StringBasis FILLER_195 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"334-COD-CBO NAO INVALIDO                          ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '335-COD-CBO NAO EXISTE                            '.*/
                public StringBasis FILLER_196 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"335-COD-CBO NAO EXISTE                            ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '336-NUM-SUBGRUPO NAO EXISTE PARA CADASTRAR REPRESE'.*/
                public StringBasis FILLER_197 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"336-NUM-SUBGRUPO NAO EXISTE PARA CADASTRAR REPRESE");
                /*"       10 FILLER               PIC  X(050)     VALUE          '337-REPRES-LEGAL JA USADO EM OUTRA EMPRESA        '.*/
                public StringBasis FILLER_198 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"337-REPRES-LEGAL JA USADO EM OUTRA EMPRESA        ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '401-NUM-PROPOSTA NAO NUMERICO OU ZERADA           '.*/
                public StringBasis FILLER_199 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"401-NUM-PROPOSTA NAO NUMERICO OU ZERADA           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '403-NUM-SUBGRUPO NAO NUMERICO                     '.*/
                public StringBasis FILLER_200 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"403-NUM-SUBGRUPO NAO NUMERICO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '404-NUM-SEQ-REG-TP04 NAO INVALIDO                 '.*/
                public StringBasis FILLER_201 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"404-NUM-SEQ-REG-TP04 NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '405-COD-COBERTURA NAO INVALIDO                    '.*/
                public StringBasis FILLER_202 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"405-COD-COBERTURA NAO INVALIDO                    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '406-VAL-IMP-SEGURADA NAO INVALIDO                 '.*/
                public StringBasis FILLER_203 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"406-VAL-IMP-SEGURADA NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '407-VAL-PRM-INDIVID NAO INVALIDO                  '.*/
                public StringBasis FILLER_204 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"407-VAL-PRM-INDIVID NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '408-IND-TRAT-FATURA NAO INVALIDO                  '.*/
                public StringBasis FILLER_205 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"408-IND-TRAT-FATURA NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '409-IND-TRAT-PREMIO NAO INVALIDO                  '.*/
                public StringBasis FILLER_206 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"409-IND-TRAT-PREMIO NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '410-PCT-COBER-BASICA NAO INVALIDO                 '.*/
                public StringBasis FILLER_207 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"410-PCT-COBER-BASICA NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '411-VAL-LIM-MINIMO NAO INVALIDO                   '.*/
                public StringBasis FILLER_208 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"411-VAL-LIM-MINIMO NAO INVALIDO                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '412-VAL-LIM-MAXIMO NAO INVALIDO                   '.*/
                public StringBasis FILLER_209 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"412-VAL-LIM-MAXIMO NAO INVALIDO                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '413-NUM-SUBGRUPO NAO EXISTE PARA CADASTRAR COBERTU'.*/
                public StringBasis FILLER_210 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"413-NUM-SUBGRUPO NAO EXISTE PARA CADASTRAR COBERTU");
                /*"       10 FILLER               PIC  X(050)     VALUE          '501-NUM-PROPOSTA NAO NUMERICO OU ZERADA           '.*/
                public StringBasis FILLER_211 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"501-NUM-PROPOSTA NAO NUMERICO OU ZERADA           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '503-NUM-SUBGRUPO NAO NUMERICO                     '.*/
                public StringBasis FILLER_212 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"503-NUM-SUBGRUPO NAO NUMERICO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '504-NUM-SEQ-REG-TP04 NAO INVALIDO                 '.*/
                public StringBasis FILLER_213 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"504-NUM-SEQ-REG-TP04 NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '505-COD-TIPO-CORR NAO INVALIDO                    '.*/
                public StringBasis FILLER_214 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"505-COD-TIPO-CORR NAO INVALIDO                    ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '506-COD-CORRETOR NAO INVALIDO                     '.*/
                public StringBasis FILLER_215 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"506-COD-CORRETOR NAO INVALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '507-COD-TIPO-CORR NAO EXISTE                      '.*/
                public StringBasis FILLER_216 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"507-COD-TIPO-CORR NAO EXISTE                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '508-PCT-COMERCIALIZ NAO INVALIDO                  '.*/
                public StringBasis FILLER_217 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"508-PCT-COMERCIALIZ NAO INVALIDO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '509-PCT-PARTICIPAC NAO INVALIDO                   '.*/
                public StringBasis FILLER_218 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"509-PCT-PARTICIPAC NAO INVALIDO                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '510-PCT-PARTIC-CORR MAIOR QUE 100%                '.*/
                public StringBasis FILLER_219 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"510-PCT-PARTIC-CORR MAIOR QUE 100%                ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '511-PCT-PARTIC-INDICADOR MAIOR QUE 100%           '.*/
                public StringBasis FILLER_220 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"511-PCT-PARTIC-INDICADOR MAIOR QUE 100%           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '512-NUM-SUBGRUPO NAO EXISTE PARA CADASTRAR CORRETO'.*/
                public StringBasis FILLER_221 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"512-NUM-SUBGRUPO NAO EXISTE PARA CADASTRAR CORRETO");
                /*"       10 FILLER               PIC  X(050)     VALUE          '513-COD-CORRETOR NAO EXISTE                       '.*/
                public StringBasis FILLER_222 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"513-COD-CORRETOR NAO EXISTE                       ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '601-NUM-PROPOSTA NAO NUMERICO OU ZERADA           '.*/
                public StringBasis FILLER_223 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"601-NUM-PROPOSTA NAO NUMERICO OU ZERADA           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '602-NUM-SEQ-REG-TP06 NAO NUMERICO                 '.*/
                public StringBasis FILLER_224 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"602-NUM-SEQ-REG-TP06 NAO NUMERICO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '603-NUM-SUBGRUPO NAO NUMERICO                     '.*/
                public StringBasis FILLER_225 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"603-NUM-SUBGRUPO NAO NUMERICO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '604-NUM-TIPO-PLANO NAO VALIDO                     '.*/
                public StringBasis FILLER_226 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"604-NUM-TIPO-PLANO NAO VALIDO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '605-DTA-INI-VIGENCIA NAO VALIDA                   '.*/
                public StringBasis FILLER_227 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"605-DTA-INI-VIGENCIA NAO VALIDA                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '606-VAL-IMP-MORNATU NAO NUMERICO                  '.*/
                public StringBasis FILLER_228 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"606-VAL-IMP-MORNATU NAO NUMERICO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '607-VAL-IMP-MORACID NAO NUMERICO                  '.*/
                public StringBasis FILLER_229 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"607-VAL-IMP-MORACID NAO NUMERICO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '608-VAL-IMP-INVPERM NAO NUMERICO                  '.*/
                public StringBasis FILLER_230 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"608-VAL-IMP-INVPERM NAO NUMERICO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '609-VAL-IMP-AMDS NAO NUMERICO                     '.*/
                public StringBasis FILLER_231 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"609-VAL-IMP-AMDS NAO NUMERICO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '610-VAL-IMP-DH NAO NUMERICO                       '.*/
                public StringBasis FILLER_232 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"610-VAL-IMP-DH NAO NUMERICO                       ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '611-VAL-IMP-DIT NAO NUMERICO                      '.*/
                public StringBasis FILLER_233 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"611-VAL-IMP-DIT NAO NUMERICO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '612-VAL-PRM-AP NAO NUMERICO                       '.*/
                public StringBasis FILLER_234 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"612-VAL-PRM-AP NAO NUMERICO                       ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '613-VAL-LIM-INFERIOR NAO INVALIDO                 '.*/
                public StringBasis FILLER_235 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"613-VAL-LIM-INFERIOR NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '614-VAL-LIM-SUPERIOR NAO INVALIDO                 '.*/
                public StringBasis FILLER_236 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"614-VAL-LIM-SUPERIOR NAO INVALIDO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '615-VAL-LIM-INFERIOR > VAL-LIM-SUPERIOR           '.*/
                public StringBasis FILLER_237 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"615-VAL-LIM-INFERIOR > VAL-LIM-SUPERIOR           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '616-VAL-TAXA NAO VALIDA OU ZERADA                 '.*/
                public StringBasis FILLER_238 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"616-VAL-TAXA NAO VALIDA OU ZERADA                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '617-VAL-PRM-VG NAO VALIDO                         '.*/
                public StringBasis FILLER_239 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"617-VAL-PRM-VG NAO VALIDO                         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '618-QTD-SAL-MORNATU NAO NUMERICO                  '.*/
                public StringBasis FILLER_240 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"618-QTD-SAL-MORNATU NAO NUMERICO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '619-VAL-LIM-CAP-MORNATU NAO NUMERICO              '.*/
                public StringBasis FILLER_241 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"619-VAL-LIM-CAP-MORNATU NAO NUMERICO              ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '620-QTD-SAL-MORACID NAO NUMERICO                  '.*/
                public StringBasis FILLER_242 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"620-QTD-SAL-MORACID NAO NUMERICO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '621-VAL-LIM-CAP-MORACID NAO NUMERICO              '.*/
                public StringBasis FILLER_243 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"621-VAL-LIM-CAP-MORACID NAO NUMERICO              ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '622-QTD-SAL-INVPERMU NAO NUMERICO                 '.*/
                public StringBasis FILLER_244 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"622-QTD-SAL-INVPERMU NAO NUMERICO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '623-VAL-LIM-CAP-INVPERM NAO NUMERICO              '.*/
                public StringBasis FILLER_245 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"623-VAL-LIM-CAP-INVPERM NAO NUMERICO              ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '624-NUM-SUBGRUPO NAO EXISTE P/ CADASTRAR PLANOS VG'.*/
                public StringBasis FILLER_246 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"624-NUM-SUBGRUPO NAO EXISTE P/ CADASTRAR PLANOS VG");
                /*"       10 FILLER               PIC  X(050)     VALUE          '625-VAL-PRM-AP NAO VALIDO                         '.*/
                public StringBasis FILLER_247 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"625-VAL-PRM-AP NAO VALIDO                         ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '626-VAL-PRM-AP E VAL-PRM-VG ZERADOS               '.*/
                public StringBasis FILLER_248 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"626-VAL-PRM-AP E VAL-PRM-VG ZERADOS               ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '701-NUM-PROPOSTA NAO NUMERICO OU ZERADA           '.*/
                public StringBasis FILLER_249 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"701-NUM-PROPOSTA NAO NUMERICO OU ZERADA           ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '703-NUM-SUBGRUPO NAO NUMERICO                     '.*/
                public StringBasis FILLER_250 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"703-NUM-SUBGRUPO NAO NUMERICO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '642-QTD-SAL-MORNATU NAO NUMERICO                  '.*/
                public StringBasis FILLER_251 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"642-QTD-SAL-MORNATU NAO NUMERICO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '643-QTD-SAL-MORACID NAO NUMERICO                  '.*/
                public StringBasis FILLER_252 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"643-QTD-SAL-MORACID NAO NUMERICO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '644-QTD-SAL-INVPERM NAO NUMERICO                  '.*/
                public StringBasis FILLER_253 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"644-QTD-SAL-INVPERM NAO NUMERICO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '627-VAL-TAXA-AP NAO NUMERICO                      '.*/
                public StringBasis FILLER_254 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"627-VAL-TAXA-AP NAO NUMERICO                      ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '628-VAL-TAXA-AP-MORACID NAO NUMERICO              '.*/
                public StringBasis FILLER_255 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"628-VAL-TAXA-AP-MORACID NAO NUMERICO              ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '629-VAL-TAXA-AP-INVPERM NAO NUMERICO              '.*/
                public StringBasis FILLER_256 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"629-VAL-TAXA-AP-INVPERM NAO NUMERICO              ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '630-VAL-TAXA-AP-AMDS NAO NUMERICO                 '.*/
                public StringBasis FILLER_257 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"630-VAL-TAXA-AP-AMDS NAO NUMERICO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '631-VAL-TAXA-AP-DH NAO NUMERICO                   '.*/
                public StringBasis FILLER_258 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"631-VAL-TAXA-AP-DH NAO NUMERICO                   ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '632-VAL-TAXA-AP-DIT NAO NUMERICO                  '.*/
                public StringBasis FILLER_259 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"632-VAL-TAXA-AP-DIT NAO NUMERICO                  ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '633-VAL-CARREGA-PRINC NAO NUMERICO                '.*/
                public StringBasis FILLER_260 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"633-VAL-CARREGA-PRINC NAO NUMERICO                ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '634-VAL-CARREGA-CONJ NAO NUMERICO                 '.*/
                public StringBasis FILLER_261 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"634-VAL-CARREGA-CONJ NAO NUMERICO                 ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '635-R6-VAL-CARREGA-FILHO NAO NUMERICO             '.*/
                public StringBasis FILLER_262 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"635-R6-VAL-CARREGA-FILHO NAO NUMERICO             ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '636-VAL-GARAN-ADIC-IEA NAO NUMERICO               '.*/
                public StringBasis FILLER_263 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"636-VAL-GARAN-ADIC-IEA NAO NUMERICO               ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '637-VAL-GARAN-ADIC-IPA NAO NUMERICO               '.*/
                public StringBasis FILLER_264 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"637-VAL-GARAN-ADIC-IPA NAO NUMERICO               ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '638-VAL-GARAN-ADIC-IPD NAO NUMERICO               '.*/
                public StringBasis FILLER_265 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"638-VAL-GARAN-ADIC-IPD NAO NUMERICO               ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '639-VAL-GARAN-ADIC-HD NAO NUMERICO                '.*/
                public StringBasis FILLER_266 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"639-VAL-GARAN-ADIC-HD NAO NUMERICO                ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '640-VAL-TAXA-DESP-ADM NAO NUMERICO                '.*/
                public StringBasis FILLER_267 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"640-VAL-TAXA-DESP-ADM NAO NUMERICO                ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '641-VAL-TAXA-IRB NAO NUMERICO                     '.*/
                public StringBasis FILLER_268 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"641-VAL-TAXA-IRB NAO NUMERICO                     ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '645-VAL-LIM-CAP-MORNATU NAO NUMERICO              '.*/
                public StringBasis FILLER_269 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"645-VAL-LIM-CAP-MORNATU NAO NUMERICO              ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '646-VAL-LIM-CAP-MORACID NAO NUMERICO              '.*/
                public StringBasis FILLER_270 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"646-VAL-LIM-CAP-MORACID NAO NUMERICO              ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '647-VAL-LIM-CAP-INVPERM NAO NUMERICO              '.*/
                public StringBasis FILLER_271 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"647-VAL-LIM-CAP-INVPERM NAO NUMERICO              ");
                /*"    05 TAB-AUX REDEFINES W-TAB-DESCRICAO.*/
            }
            private _REDEF_VG2600B_TAB_AUX _tab_aux { get; set; }
            public _REDEF_VG2600B_TAB_AUX TAB_AUX
            {
                get { _tab_aux = new _REDEF_VG2600B_TAB_AUX(); _.Move(W_TAB_DESCRICAO, _tab_aux); VarBasis.RedefinePassValue(W_TAB_DESCRICAO, _tab_aux, W_TAB_DESCRICAO); _tab_aux.ValueChanged += () => { _.Move(_tab_aux, W_TAB_DESCRICAO); }; return _tab_aux; }
                set { VarBasis.RedefinePassValue(value, _tab_aux, W_TAB_DESCRICAO); }
            }  //Redefines
            public class _REDEF_VG2600B_TAB_AUX : VarBasis
            {
                /*"       10 TAB-DESCR-ERRO   OCCURS 192 INDEXED BY WIDX1.*/
                public ListBasis<VG2600B_TAB_DESCR_ERRO> TAB_DESCR_ERRO { get; set; } = new ListBasis<VG2600B_TAB_DESCR_ERRO>(192);
                public class VG2600B_TAB_DESCR_ERRO : VarBasis
                {
                    /*"         20 W-TB-CODIGO       PIC  9(003).*/
                    public IntBasis W_TB_CODIGO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"         20 FILLER            PIC  X(001).*/
                    public StringBasis FILLER_272 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"         20 W-TB-DESCRI-ERRO  PIC  X(046).*/
                    public StringBasis W_TB_DESCRI_ERRO { get; set; } = new StringBasis(new PIC("X", "46", "X(046)."), @"");
                    /*"    05 W-TAB-CANAL.*/

                    public VG2600B_TAB_DESCR_ERRO()
                    {
                        W_TB_CODIGO.ValueChanged += OnValueChanged;
                        FILLER_272.ValueChanged += OnValueChanged;
                        W_TB_DESCRI_ERRO.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_VG2600B_TAB_AUX()
                {
                    TAB_DESCR_ERRO.ValueChanged += OnValueChanged;
                }

            }
            public VG2600B_W_TAB_CANAL W_TAB_CANAL { get; set; } = new VG2600B_W_TAB_CANAL();
            public class VG2600B_W_TAB_CANAL : VarBasis
            {
                /*"       10 FILLER               PIC  X(015)     VALUE          '01CAIXA    '.*/
                public StringBasis FILLER_273 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"01CAIXA    ");
                /*"       10 FILLER               PIC  X(015)     VALUE          '02CAIXA SEGUROS'.*/
                public StringBasis FILLER_274 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"02CAIXA SEGUROS");
                /*"       10 FILLER               PIC  X(015)     VALUE          '03CORRETOR '.*/
                public StringBasis FILLER_275 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"03CORRETOR ");
                /*"       10 FILLER               PIC  X(015)     VALUE          '04ATM      '.*/
                public StringBasis FILLER_276 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"04ATM      ");
                /*"       10 FILLER               PIC  X(015)     VALUE          '05GITEL    '.*/
                public StringBasis FILLER_277 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"05GITEL    ");
                /*"       10 FILLER               PIC  X(015)     VALUE          '07INTERNET '.*/
                public StringBasis FILLER_278 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"07INTERNET ");
                /*"       10 FILLER               PIC  X(015)     VALUE          '08INTRANET '.*/
                public StringBasis FILLER_279 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"08INTRANET ");
                /*"    05 W-TAB-CANAL-RD      REDEFINES W-TAB-CANAL                           OCCURS 7.*/
            }
            private ListBasis<_REDEF_VG2600B_W_TAB_CANAL_RD> _w_tab_canal_rd { get; set; }
            public ListBasis<_REDEF_VG2600B_W_TAB_CANAL_RD> W_TAB_CANAL_RD
            {
                get { _w_tab_canal_rd = new ListBasis<_REDEF_VG2600B_W_TAB_CANAL_RD>(7); _.Move(W_TAB_CANAL, _w_tab_canal_rd); VarBasis.RedefinePassValue(W_TAB_CANAL, _w_tab_canal_rd, W_TAB_CANAL); _w_tab_canal_rd.ValueChanged += () => { _.Move(_w_tab_canal_rd, W_TAB_CANAL); }; return _w_tab_canal_rd; }
                set { VarBasis.RedefinePassValue(value, _w_tab_canal_rd, W_TAB_CANAL); }
            }  //Redefines
            public class _REDEF_VG2600B_W_TAB_CANAL_RD : VarBasis
            {
                /*"       10 W-TB-COD-CANAL    PIC  9(002).*/
                public IntBasis W_TB_COD_CANAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 W-TB-DESCRI-CANAL PIC  X(013).*/
                public StringBasis W_TB_DESCRI_CANAL { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"    05 W-TAB-ORIGEM.*/

                public _REDEF_VG2600B_W_TAB_CANAL_RD()
                {
                    W_TB_COD_CANAL.ValueChanged += OnValueChanged;
                    W_TB_DESCRI_CANAL.ValueChanged += OnValueChanged;
                }

            }
            public VG2600B_W_TAB_ORIGEM W_TAB_ORIGEM { get; set; } = new VG2600B_W_TAB_ORIGEM();
            public class VG2600B_W_TAB_ORIGEM : VarBasis
            {
                /*"       10 FILLER               PIC  X(023)     VALUE          '01SIGPF                '.*/
                public StringBasis FILLER_280 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"01SIGPF                ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '02CAIXA&PREVIDENCIA    '.*/
                public StringBasis FILLER_281 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"02CAIXA&PREVIDENCIA    ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '03PORTAL               '.*/
                public StringBasis FILLER_282 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"03PORTAL               ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '04SASSE                '.*/
                public StringBasis FILLER_283 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"04SASSE                ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '05CAIXA&CAPITALIZACAO  '.*/
                public StringBasis FILLER_284 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"05CAIXA&CAPITALIZACAO  ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '06MANUAL               '.*/
                public StringBasis FILLER_285 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"06MANUAL               ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '07VENDAS REMOTAS       '.*/
                public StringBasis FILLER_286 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"07VENDAS REMOTAS       ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '08INTRANET             '.*/
                public StringBasis FILLER_287 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"08INTRANET             ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '09INTERNET             '.*/
                public StringBasis FILLER_288 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"09INTERNET             ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '97REMOTA FILIAL        '.*/
                public StringBasis FILLER_289 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"97REMOTA FILIAL        ");
                /*"    05 W-TAB-ORIGEM-RD      REDEFINES W-TAB-ORIGEM                           OCCURS 10.*/
            }
            private ListBasis<_REDEF_VG2600B_W_TAB_ORIGEM_RD> _w_tab_origem_rd { get; set; }
            public ListBasis<_REDEF_VG2600B_W_TAB_ORIGEM_RD> W_TAB_ORIGEM_RD
            {
                get { _w_tab_origem_rd = new ListBasis<_REDEF_VG2600B_W_TAB_ORIGEM_RD>(10); _.Move(W_TAB_ORIGEM, _w_tab_origem_rd); VarBasis.RedefinePassValue(W_TAB_ORIGEM, _w_tab_origem_rd, W_TAB_ORIGEM); _w_tab_origem_rd.ValueChanged += () => { _.Move(_w_tab_origem_rd, W_TAB_ORIGEM); }; return _w_tab_origem_rd; }
                set { VarBasis.RedefinePassValue(value, _w_tab_origem_rd, W_TAB_ORIGEM); }
            }  //Redefines
            public class _REDEF_VG2600B_W_TAB_ORIGEM_RD : VarBasis
            {
                /*"       10 W-TB-COD-ORIGEM     PIC  9(002).*/
                public IntBasis W_TB_COD_ORIGEM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 W-TB-DESCRI-ORIGEM  PIC  X(021).*/
                public StringBasis W_TB_DESCRI_ORIGEM { get; set; } = new StringBasis(new PIC("X", "21", "X(021)."), @"");

                public _REDEF_VG2600B_W_TAB_ORIGEM_RD()
                {
                    W_TB_COD_ORIGEM.ValueChanged += OnValueChanged;
                    W_TB_DESCRI_ORIGEM.ValueChanged += OnValueChanged;
                }

            }
        }


        public Copies.GEJVWCNT GEJVWCNT { get; set; } = new Copies.GEJVWCNT();
        public Copies.GEJVW002 GEJVW002 { get; set; } = new Copies.GEJVW002();
        public Copies.SPVG009W SPVG009W { get; set; } = new Copies.SPVG009W();
        public Copies.LBWPF002 LBWPF002 { get; set; } = new Copies.LBWPF002();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.APOLICOR APOLICOR { get; set; } = new Dclgens.APOLICOR();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.VGSOLFAT VGSOLFAT { get; set; } = new Dclgens.VGSOLFAT();
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
        public Dclgens.VG092 VG092 { get; set; } = new Dclgens.VG092();
        public Dclgens.GE374 GE374 { get; set; } = new Dclgens.GE374();
        public Dclgens.PF087 PF087 { get; set; } = new Dclgens.PF087();
        public Dclgens.PF088 PF088 { get; set; } = new Dclgens.PF088();
        public Dclgens.PF089 PF089 { get; set; } = new Dclgens.PF089();
        public Dclgens.PF090 PF090 { get; set; } = new Dclgens.PF090();
        public Dclgens.CBO CBO { get; set; } = new Dclgens.CBO();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public VG2600B_ERROPROC ERROPROC { get; set; } = new VG2600B_ERROPROC();
        public VG2600B_CAMPOARQ CAMPOARQ { get; set; } = new VG2600B_CAMPOARQ();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOV_PORTAL_FILE_NAME_P, string RVG2600B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOV_PORTAL.SetFile(MOV_PORTAL_FILE_NAME_P);
                RVG2600B.SetFile(RVG2600B_FILE_NAME_P);

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
            /*" -1733- DISPLAY ' ' */
            _.Display($" ");

            /*" -1735- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1742- DISPLAY 'PROGRAMA VG2600B - VERSAO V.23 - DEMANDA 477.782 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA VG2600B - VERSAO V.23 - DEMANDA 477.782 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -1743- DISPLAY 'PROCESSA ARQ. PROPOSTAS APOL. ESPEC. ' */
            _.Display($"PROCESSA ARQ. PROPOSTAS APOL. ESPEC. ");

            /*" -1745- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1746- DISPLAY ' ' */
            _.Display($" ");

            /*" -1747- DISPLAY ' ' */
            _.Display($" ");

            /*" -1754- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1756- DISPLAY '   ' */
            _.Display($"   ");

            /*" -1758- PERFORM R0000-00-INICIALIZAR. */

            R0000_00_INICIALIZAR_SECTION();

            /*" -1760- PERFORM R0050-00-LER-MOV-PORTALPJ */

            R0050_00_LER_MOV_PORTALPJ_SECTION();

            /*" -1761- IF (W-FIM-MVTO-PORTAL EQUAL 'FIM' ) */

            if ((WAREA_AUXILIAR.W_FIM_MVTO_PORTAL == "FIM"))
            {

                /*" -1762- DISPLAY 'MOVIMENTO PORTAL PJ SEM PROPOSTA ' */
                _.Display($"MOVIMENTO PORTAL PJ SEM PROPOSTA ");

                /*" -1763- DISPLAY 'MOVIMENTO PORTAL PJ SEM PROPOSTA ' */
                _.Display($"MOVIMENTO PORTAL PJ SEM PROPOSTA ");

                /*" -1764- DISPLAY 'MOVIMENTO PORTAL PJ SEM PROPOSTA ' */
                _.Display($"MOVIMENTO PORTAL PJ SEM PROPOSTA ");

                /*" -1765- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -1766- ELSE */
            }
            else
            {


                /*" -1767- IF (REG-TIPO-PORTAL NOT EQUAL '0' ) */

                if ((REG_PORTAL.REG_TIPO_PORTAL != "0"))
                {

                    /*" -1768- DISPLAY 'VG2600B - FIM ANORMAL' */
                    _.Display($"VG2600B - FIM ANORMAL");

                    /*" -1770- DISPLAY '          TIPO ARQUIVO INVALIDO ' RH-TIPO-ARQUIVO */
                    _.Display($"          TIPO ARQUIVO INVALIDO {REG_HEADER.RH_TIPO_ARQUIVO}");

                    /*" -1771- GO TO R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;

                    /*" -1772- END-IF */
                }


                /*" -1774- END-IF. */
            }


            /*" -1777- PERFORM R0200-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MVTO-PORTAL EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MVTO_PORTAL == "FIM"))
            {

                R0200_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -1778- IF (W-IND-1 > ZEROS) */

            if ((WAREA_AUXILIAR.W_IND_1 > 00))
            {

                /*" -1779- PERFORM R9980-00-GERAR-RELATORIO */

                R9980_00_GERAR_RELATORIO_SECTION();

                /*" -1781- END-IF. */
            }


            /*" -1781- GO TO R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION(); //GOTO
            return;

        }

        [StopWatch]
        /*" R0000-00-INICIALIZAR-SECTION */
        private void R0000_00_INICIALIZAR_SECTION()
        {
            /*" -1787- MOVE 'R0000-00-INICIALIZAR' TO PARAGRAFO. */
            _.Move("R0000-00-INICIALIZAR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1788- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1790- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1791- OPEN INPUT MOV-PORTAL. */
            MOV_PORTAL.Open(REG_PORTAL);

            /*" -1793- OPEN OUTPUT RVG2600B. */
            RVG2600B.Open(REG_RVG2600B);

            /*" -1795- PERFORM R0005-00-OBTER-DATA-DIA. */

            R0005_00_OBTER_DATA_DIA_SECTION();

            /*" -1797- PERFORM R0010-00-GERAR-TAB-ERROS. */

            R0010_00_GERAR_TAB_ERROS_SECTION();

            /*" -1799- PERFORM R0020-00-GERAR-TAB-CAMPOS. */

            R0020_00_GERAR_TAB_CAMPOS_SECTION();

            /*" -1799- PERFORM R0030-00-LER-PARAMETROS. */

            R0030_00_LER_PARAMETROS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_SAIDA*/

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-SECTION */
        private void R0005_00_OBTER_DATA_DIA_SECTION()
        {
            /*" -1809- MOVE 'R0005-00-OBTER-DATA-DIA' TO PARAGRAFO. */
            _.Move("R0005-00-OBTER-DATA-DIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1810- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1812- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1814- MOVE 'VG' TO SISTEMAS-IDE-SISTEMA. */
            _.Move("VG", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -1820- PERFORM R0005_00_OBTER_DATA_DIA_DB_SELECT_1 */

            R0005_00_OBTER_DATA_DIA_DB_SELECT_1();

            /*" -1823- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1824- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -1825- DISPLAY '          ERRO ACESSO TAB SISTEMAS  ' */
                _.Display($"          ERRO ACESSO TAB SISTEMAS  ");

                /*" -1827- DISPLAY '          SQLCODE....... ' SQLCODE */
                _.Display($"          SQLCODE....... {DB.SQLCODE}");

                /*" -1828- DISPLAY '          IDE_SISTEMA... ' SISTEMAS-IDE-SISTEMA */
                _.Display($"          IDE_SISTEMA... {SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA}");

                /*" -1829- DISPLAY 'SQLERRMC<' SQLERRMC '>' */

                $"SQLERRMC<{DB.SQLERRMC}>"
                .Display();

                /*" -1830- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -1832- END-IF. */
            }


            /*" -1834- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -1835- MOVE W-DIA-MOVABE1 TO W-DIA-MOVABEI1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE1, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABEI1);

            /*" -1836- MOVE W-MES-MOVABE1 TO W-MES-MOVABEI1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE1, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABEI1);

            /*" -1838- MOVE W-ANO-MOVABE1 TO W-ANO-MOVABEI1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE1, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABEI1);

            /*" -1839- MOVE W-DIA-MOVABE1 TO W-DIA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE1, WAREA_AUXILIAR.FILLER_26.W_DIA_PROPOSTA);

            /*" -1840- MOVE W-MES-MOVABE1 TO W-MES-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE1, WAREA_AUXILIAR.FILLER_26.W_MES_PROPOSTA);

            /*" -1842- MOVE W-ANO-MOVABE1 TO W-ANO-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE1, WAREA_AUXILIAR.FILLER_26.W_ANO_PROPOSTA);

            /*" -1843- MOVE '/' TO W-BARRAI1 W-BARRAI2. */
            _.Move("/", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRAI1);
            _.Move("/", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRAI2);


        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-DB-SELECT-1 */
        public void R0005_00_OBTER_DATA_DIA_DB_SELECT_1()
        {
            /*" -1820- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

            var r0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1 = new R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1.Execute(r0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0005_SAIDA*/

        [StopWatch]
        /*" R0010-00-GERAR-TAB-ERROS-SECTION */
        private void R0010_00_GERAR_TAB_ERROS_SECTION()
        {
            /*" -1852- MOVE 'R0010-00-GERAR-TAB-ERROS' TO PARAGRAFO. */
            _.Move("R0010-00-GERAR-TAB-ERROS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1853- MOVE 'GERAR TABELA ERRO' TO COMANDO. */
            _.Move("GERAR TABELA ERRO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1855- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1857- SET I01 TO 1. */
            I01.Value = 1;

            /*" -1859- PERFORM R0011-00-DECLARE-ERRO-PROC. */

            R0011_00_DECLARE_ERRO_PROC_SECTION();

            /*" -1861- PERFORM R0012-00-FETCH-ERRO-PROC. */

            R0012_00_FETCH_ERRO_PROC_SECTION();

            /*" -1862- IF (W-FIM-ERROS NOT EQUAL SPACES) */

            if ((!WAREA_AUXILIAR.W_FIM_ERROS.IsEmpty()))
            {

                /*" -1863- DISPLAY 'R0010 - PROBLEMA NO FETCH ERRO-PROC ' SQLCODE */
                _.Display($"R0010 - PROBLEMA NO FETCH ERRO-PROC {DB.SQLCODE}");

                /*" -1864- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -1866- END-IF. */
            }


            /*" -1867- PERFORM R0013-00-CARREGA-ERRO-PROC UNTIL W-FIM-ERROS EQUAL 'SIM' . */

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
            /*" -1876- MOVE 'R0011-00-DECLARE-ERRO-PROC' TO PARAGRAFO. */
            _.Move("R0011-00-DECLARE-ERRO-PROC", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1877- MOVE 'DECLARE TABELA ERRO' TO COMANDO. */
            _.Move("DECLARE TABELA ERRO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1879- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1885- PERFORM R0011_00_DECLARE_ERRO_PROC_DB_DECLARE_1 */

            R0011_00_DECLARE_ERRO_PROC_DB_DECLARE_1();

            /*" -1887- PERFORM R0011_00_DECLARE_ERRO_PROC_DB_OPEN_1 */

            R0011_00_DECLARE_ERRO_PROC_DB_OPEN_1();

            /*" -1890- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1891- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -1892- DISPLAY '          ERRO SELECT TAB PF_ERRO_PROC_PROPOST' */
                _.Display($"          ERRO SELECT TAB PF_ERRO_PROC_PROPOST");

                /*" -1894- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1895- DISPLAY 'SQLERRMC<' SQLERRMC '>' */

                $"SQLERRMC<{DB.SQLERRMC}>"
                .Display();

                /*" -1896- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -1896- END-IF. */
            }


        }

        [StopWatch]
        /*" R0011-00-DECLARE-ERRO-PROC-DB-DECLARE-1 */
        public void R0011_00_DECLARE_ERRO_PROC_DB_DECLARE_1()
        {
            /*" -1885- EXEC SQL DECLARE ERROPROC CURSOR FOR SELECT NUM_ERRO_PROPOSTA, DES_ERRO_PROPOSTA FROM SEGUROS.PF_ERRO_PROC_PROPOSTA ORDER BY NUM_ERRO_PROPOSTA END-EXEC. */
            ERROPROC = new VG2600B_ERROPROC(false);
            string GetQuery_ERROPROC()
            {
                var query = @$"SELECT NUM_ERRO_PROPOSTA
							, 
							DES_ERRO_PROPOSTA 
							FROM SEGUROS.PF_ERRO_PROC_PROPOSTA 
							ORDER BY NUM_ERRO_PROPOSTA";

                return query;
            }
            ERROPROC.GetQueryEvent += GetQuery_ERROPROC;

        }

        [StopWatch]
        /*" R0011-00-DECLARE-ERRO-PROC-DB-OPEN-1 */
        public void R0011_00_DECLARE_ERRO_PROC_DB_OPEN_1()
        {
            /*" -1887- EXEC SQL OPEN ERROPROC END-EXEC. */

            ERROPROC.Open();

        }

        [StopWatch]
        /*" R0021-00-DECLARE-CAMPO-ARQ-DB-DECLARE-1 */
        public void R0021_00_DECLARE_CAMPO_ARQ_DB_DECLARE_1()
        {
            /*" -1991- EXEC SQL DECLARE CAMPOARQ CURSOR FOR SELECT NUM_DET_ARQ_PROPOSTA, NOM_DET_ARQ_PROPOSTA FROM SEGUROS.PF_DET_ARQ_PROPOSTA ORDER BY NUM_DET_ARQ_PROPOSTA END-EXEC. */
            CAMPOARQ = new VG2600B_CAMPOARQ(false);
            string GetQuery_CAMPOARQ()
            {
                var query = @$"SELECT NUM_DET_ARQ_PROPOSTA
							, 
							NOM_DET_ARQ_PROPOSTA 
							FROM SEGUROS.PF_DET_ARQ_PROPOSTA 
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
            /*" -1906- MOVE 'R0012-00-FETCH-ERRO-PROC' TO PARAGRAFO. */
            _.Move("R0012-00-FETCH-ERRO-PROC", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1907- MOVE 'FETCH ERRO PROC' TO COMANDO. */
            _.Move("FETCH ERRO PROC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1909- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1911- INITIALIZE PF089-DES-ERRO-PROPOSTA-TEXT */
            _.Initialize(
                PF089.DCLPF_ERRO_PROC_PROPOSTA.PF089_DES_ERRO_PROPOSTA.PF089_DES_ERRO_PROPOSTA_TEXT
            );

            /*" -1915- PERFORM R0012_00_FETCH_ERRO_PROC_DB_FETCH_1 */

            R0012_00_FETCH_ERRO_PROC_DB_FETCH_1();

            /*" -1918- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1919- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -1920- MOVE 'SIM' TO W-FIM-ERROS */
                    _.Move("SIM", WAREA_AUXILIAR.W_FIM_ERROS);

                    /*" -1920- PERFORM R0012_00_FETCH_ERRO_PROC_DB_CLOSE_1 */

                    R0012_00_FETCH_ERRO_PROC_DB_CLOSE_1();

                    /*" -1922- ELSE */
                }
                else
                {


                    /*" -1923- DISPLAY 'VG2600B - FIM ANORMAL' */
                    _.Display($"VG2600B - FIM ANORMAL");

                    /*" -1924- DISPLAY '     ERRO FETCH PF_ERRO_PROC_PROPOST' */
                    _.Display($"     ERRO FETCH PF_ERRO_PROC_PROPOST");

                    /*" -1926- DISPLAY '     SQLCODE......................  ' SQLCODE */
                    _.Display($"     SQLCODE......................  {DB.SQLCODE}");

                    /*" -1927- GO TO R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;

                    /*" -1928- END-IF */
                }


                /*" -1928- END-IF. */
            }


        }

        [StopWatch]
        /*" R0012-00-FETCH-ERRO-PROC-DB-FETCH-1 */
        public void R0012_00_FETCH_ERRO_PROC_DB_FETCH_1()
        {
            /*" -1915- EXEC SQL FETCH ERROPROC INTO :PF089-NUM-ERRO-PROPOSTA, :PF089-DES-ERRO-PROPOSTA END-EXEC. */

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
            /*" -1920- EXEC SQL CLOSE ERROPROC END-EXEC */

            ERROPROC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0012_SAIDA*/

        [StopWatch]
        /*" R0013-00-CARREGA-ERRO-PROC-SECTION */
        private void R0013_00_CARREGA_ERRO_PROC_SECTION()
        {
            /*" -1937- MOVE 'R0013-00-CARREGA-ERRO-PROC' TO PARAGRAFO. */
            _.Move("R0013-00-CARREGA-ERRO-PROC", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1938- MOVE 'CARREGA ERRO PROC' TO COMANDO. */
            _.Move("CARREGA ERRO PROC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1940- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1943- MOVE SPACES TO W-TB-DESC-ERRO (PF089-NUM-ERRO-PROPOSTA). */
            _.Move("", W_TAB_ERRO.W_TAB_ERRO_REG[PF089.DCLPF_ERRO_PROC_PROPOSTA.PF089_NUM_ERRO_PROPOSTA].W_TB_DESC_ERRO);

            /*" -1946- MOVE PF089-DES-ERRO-PROPOSTA-TEXT TO W-TB-DESC-ERRO (PF089-NUM-ERRO-PROPOSTA). */
            _.Move(PF089.DCLPF_ERRO_PROC_PROPOSTA.PF089_DES_ERRO_PROPOSTA.PF089_DES_ERRO_PROPOSTA_TEXT, W_TAB_ERRO.W_TAB_ERRO_REG[PF089.DCLPF_ERRO_PROC_PROPOSTA.PF089_NUM_ERRO_PROPOSTA].W_TB_DESC_ERRO);

            /*" -1948- SET I01 UP BY 1. */
            I01.Value += 1;

            /*" -1948- PERFORM R0012-00-FETCH-ERRO-PROC. */

            R0012_00_FETCH_ERRO_PROC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0013_SAIDA*/

        [StopWatch]
        /*" R0020-00-GERAR-TAB-CAMPOS-SECTION */
        private void R0020_00_GERAR_TAB_CAMPOS_SECTION()
        {
            /*" -1957- MOVE 'R0020-00-GERAR-TAB-CAMPOS' TO PARAGRAFO. */
            _.Move("R0020-00-GERAR-TAB-CAMPOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1958- MOVE 'GERAR TABELA CAMPOS' TO COMANDO. */
            _.Move("GERAR TABELA CAMPOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1960- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1961- MOVE SPACES TO W-FIM-ERROS */
            _.Move("", WAREA_AUXILIAR.W_FIM_ERROS);

            /*" -1963- SET I02 TO 1. */
            I02.Value = 1;

            /*" -1965- PERFORM R0021-00-DECLARE-CAMPO-ARQ. */

            R0021_00_DECLARE_CAMPO_ARQ_SECTION();

            /*" -1967- PERFORM R0022-00-FETCH-CAMPO-ARQ. */

            R0022_00_FETCH_CAMPO_ARQ_SECTION();

            /*" -1968- IF (W-FIM-ERROS NOT EQUAL SPACES) */

            if ((!WAREA_AUXILIAR.W_FIM_ERROS.IsEmpty()))
            {

                /*" -1969- DISPLAY 'R0020 - PROBLEMA NO FETCH CAMPO-ARQ ' SQLCODE */
                _.Display($"R0020 - PROBLEMA NO FETCH CAMPO-ARQ {DB.SQLCODE}");

                /*" -1970- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -1972- END-IF. */
            }


            /*" -1973- PERFORM R0023-00-CARREGA-CAMPO-ARQ UNTIL W-FIM-ERROS EQUAL 'SIM' . */

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
            /*" -1982- MOVE 'R0021-00-DECLARE-CAMPO-ARQ' TO PARAGRAFO. */
            _.Move("R0021-00-DECLARE-CAMPO-ARQ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1983- MOVE 'DECLARE TABELA CAMPO' TO COMANDO. */
            _.Move("DECLARE TABELA CAMPO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1985- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1991- PERFORM R0021_00_DECLARE_CAMPO_ARQ_DB_DECLARE_1 */

            R0021_00_DECLARE_CAMPO_ARQ_DB_DECLARE_1();

            /*" -1993- PERFORM R0021_00_DECLARE_CAMPO_ARQ_DB_OPEN_1 */

            R0021_00_DECLARE_CAMPO_ARQ_DB_OPEN_1();

            /*" -1996- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1997- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -1998- DISPLAY '          ERRO SELECT TAB PF_DET_ARQ_PROPOSTA' */
                _.Display($"          ERRO SELECT TAB PF_DET_ARQ_PROPOSTA");

                /*" -2000- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2001- DISPLAY 'SQLERRMC<' SQLERRMC '>' */

                $"SQLERRMC<{DB.SQLERRMC}>"
                .Display();

                /*" -2002- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -2002- END-IF. */
            }


        }

        [StopWatch]
        /*" R0021-00-DECLARE-CAMPO-ARQ-DB-OPEN-1 */
        public void R0021_00_DECLARE_CAMPO_ARQ_DB_OPEN_1()
        {
            /*" -1993- EXEC SQL OPEN CAMPOARQ END-EXEC. */

            CAMPOARQ.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0021_SAIDA*/

        [StopWatch]
        /*" R0022-00-FETCH-CAMPO-ARQ-SECTION */
        private void R0022_00_FETCH_CAMPO_ARQ_SECTION()
        {
            /*" -2012- MOVE 'R0022-00-FETCH-CAMPO-ARQ' TO PARAGRAFO. */
            _.Move("R0022-00-FETCH-CAMPO-ARQ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2013- MOVE 'FETCH CAMPO ARQUIVO' TO COMANDO. */
            _.Move("FETCH CAMPO ARQUIVO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2015- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2019- PERFORM R0022_00_FETCH_CAMPO_ARQ_DB_FETCH_1 */

            R0022_00_FETCH_CAMPO_ARQ_DB_FETCH_1();

            /*" -2022- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2023- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -2024- MOVE 'SIM' TO W-FIM-ERROS */
                    _.Move("SIM", WAREA_AUXILIAR.W_FIM_ERROS);

                    /*" -2024- PERFORM R0022_00_FETCH_CAMPO_ARQ_DB_CLOSE_1 */

                    R0022_00_FETCH_CAMPO_ARQ_DB_CLOSE_1();

                    /*" -2026- ELSE */
                }
                else
                {


                    /*" -2027- DISPLAY 'VG2600B - FIM ANORMAL' */
                    _.Display($"VG2600B - FIM ANORMAL");

                    /*" -2028- DISPLAY '     ERRO FETCH PF_DET_ARQ_PROPOSTA' */
                    _.Display($"     ERRO FETCH PF_DET_ARQ_PROPOSTA");

                    /*" -2030- DISPLAY '     SQLCODE......................  ' SQLCODE */
                    _.Display($"     SQLCODE......................  {DB.SQLCODE}");

                    /*" -2031- GO TO R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;

                    /*" -2032- END-IF */
                }


                /*" -2032- END-IF. */
            }


        }

        [StopWatch]
        /*" R0022-00-FETCH-CAMPO-ARQ-DB-FETCH-1 */
        public void R0022_00_FETCH_CAMPO_ARQ_DB_FETCH_1()
        {
            /*" -2019- EXEC SQL FETCH CAMPOARQ INTO :PF088-NUM-DET-ARQ-PROPOSTA, :PF088-NOM-DET-ARQ-PROPOSTA END-EXEC. */

            if (CAMPOARQ.Fetch())
            {
                _.Move(CAMPOARQ.PF088_NUM_DET_ARQ_PROPOSTA, PF088.DCLPF_DET_ARQ_PROPOSTA.PF088_NUM_DET_ARQ_PROPOSTA);
                _.Move(CAMPOARQ.PF088_NOM_DET_ARQ_PROPOSTA, PF088.DCLPF_DET_ARQ_PROPOSTA.PF088_NOM_DET_ARQ_PROPOSTA);
            }

        }

        [StopWatch]
        /*" R0022-00-FETCH-CAMPO-ARQ-DB-CLOSE-1 */
        public void R0022_00_FETCH_CAMPO_ARQ_DB_CLOSE_1()
        {
            /*" -2024- EXEC SQL CLOSE CAMPOARQ END-EXEC */

            CAMPOARQ.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0022_SAIDA*/

        [StopWatch]
        /*" R0023-00-CARREGA-CAMPO-ARQ-SECTION */
        private void R0023_00_CARREGA_CAMPO_ARQ_SECTION()
        {
            /*" -2041- MOVE 'R0023-00-CARREGA-CAMPO-ARQ' TO PARAGRAFO. */
            _.Move("R0023-00-CARREGA-CAMPO-ARQ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2042- MOVE 'CARREGA CAMPO ARQUIVO' TO COMANDO. */
            _.Move("CARREGA CAMPO ARQUIVO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2044- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2047- MOVE PF088-NOM-DET-ARQ-PROPOSTA TO W-TB-NOM-CAMPO (PF088-NUM-DET-ARQ-PROPOSTA). */
            _.Move(PF088.DCLPF_DET_ARQ_PROPOSTA.PF088_NOM_DET_ARQ_PROPOSTA, W_TAB_CAMPO.W_TAB_CAMPO_REG[PF088.DCLPF_DET_ARQ_PROPOSTA.PF088_NUM_DET_ARQ_PROPOSTA].W_TB_NOM_CAMPO);

            /*" -2049- SET I02 UP BY 1. */
            I02.Value += 1;

            /*" -2049- PERFORM R0022-00-FETCH-CAMPO-ARQ. */

            R0022_00_FETCH_CAMPO_ARQ_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0023_SAIDA*/

        [StopWatch]
        /*" R0030-00-LER-PARAMETROS-SECTION */
        private void R0030_00_LER_PARAMETROS_SECTION()
        {
            /*" -2061- INITIALIZE LK-GEJVW002-NOM-PROG-ORIGEM LK-GEJVW002-COD-USUARIO-ORIGEM LK-GEJVW002-SIAS-NUM-EMP LK-GEJVW002-SIAS-DTA-INI LK-GEJVW002-SIAS-COD-CGCCPF LK-GEJVW002-SIAS-COD-LIDER LK-GEJVW002-SIAS-COD-EMP-CAP LK-GEJVW002-PREV-NUM-EMP LK-GEJVW002-PREV-DTA-INI LK-GEJVW002-PREV-COD-CGCCPF LK-GEJVW002-PREV-COD-LIDER LK-GEJVW002-PREV-COD-EMP-CAP LK-GEJVW002-JV-NUM-EMP LK-GEJVW002-JV-DTA-INI LK-GEJVW002-JV-COD-CGCCPF LK-GEJVW002-JV-COD-LIDER LK-GEJVW002-JV-COD-EMP-CAP. */
            _.Initialize(
                GEJVW002.LK_GEJVW002_NOM_PROG_ORIGEM
                , GEJVW002.LK_GEJVW002_COD_USUARIO_ORIGEM
                , GEJVW002.LK_GEJVW002_SIAS_NUM_EMP
                , GEJVW002.LK_GEJVW002_SIAS_DTA_INI
                , GEJVW002.LK_GEJVW002_SIAS_COD_CGCCPF
                , GEJVW002.LK_GEJVW002_SIAS_COD_LIDER
                , GEJVW002.LK_GEJVW002_SIAS_COD_EMP_CAP
                , GEJVW002.LK_GEJVW002_PREV_NUM_EMP
                , GEJVW002.LK_GEJVW002_PREV_DTA_INI
                , GEJVW002.LK_GEJVW002_PREV_COD_CGCCPF
                , GEJVW002.LK_GEJVW002_PREV_COD_LIDER
                , GEJVW002.LK_GEJVW002_PREV_COD_EMP_CAP
                , GEJVW002.LK_GEJVW002_JV_NUM_EMP
                , GEJVW002.LK_GEJVW002_JV_DTA_INI
                , GEJVW002.LK_GEJVW002_JV_COD_CGCCPF
                , GEJVW002.LK_GEJVW002_JV_COD_LIDER
                , GEJVW002.LK_GEJVW002_JV_COD_EMP_CAP
            );

            /*" -2065- INITIALIZE LK-GEJVWCNT-IND-ERRO LK-GEJVWCNT-MENSAGEM-RETORNO LK-GEJVWCNT-NOME-TABELA LK-GEJVWCNT-SQLCODE LK-GEJVWCNT-SQLERRMC. */
            _.Initialize(
                GEJVWCNT.LK_GEJVWCNT_IND_ERRO
                , GEJVWCNT.LK_GEJVWCNT_MENSAGEM_RETORNO
                , GEJVWCNT.LK_GEJVWCNT_NOME_TABELA
                , GEJVWCNT.LK_GEJVWCNT_SQLCODE
                , GEJVWCNT.LK_GEJVWCNT_SQLERRMC
            );

            /*" -2066- MOVE 'VG2600B' TO LK-GEJVW002-NOM-PROG-ORIGEM. */
            _.Move("VG2600B", GEJVW002.LK_GEJVW002_NOM_PROG_ORIGEM);

            /*" -2068- MOVE 'BATCH' TO LK-GEJVW002-COD-USUARIO-ORIGEM. */
            _.Move("BATCH", GEJVW002.LK_GEJVW002_COD_USUARIO_ORIGEM);

            /*" -2068- MOVE 'GEJVS002' TO WS-JV1-PROGRAMA. */
            _.Move("GEJVS002", WS_JV1_PROGRAMA);

            /*" -2070- CALL WS-JV1-PROGRAMA USING LK-GEJVW002-NOM-PROG-ORIGEM LK-GEJVW002-COD-USUARIO-ORIGEM LK-GEJVW002-SIAS-NUM-EMP LK-GEJVW002-SIAS-DTA-INI LK-GEJVW002-SIAS-COD-LIDER LK-GEJVW002-SIAS-COD-CGCCPF LK-GEJVW002-SIAS-COD-EMP-CAP LK-GEJVW002-PREV-NUM-EMP LK-GEJVW002-PREV-DTA-INI LK-GEJVW002-PREV-COD-LIDER LK-GEJVW002-PREV-COD-CGCCPF LK-GEJVW002-PREV-COD-EMP-CAP LK-GEJVW002-JV-NUM-EMP LK-GEJVW002-JV-DTA-INI LK-GEJVW002-JV-COD-LIDER LK-GEJVW002-JV-COD-CGCCPF LK-GEJVW002-JV-COD-EMP-CAP LK-GEJVWCNT-IND-ERRO LK-GEJVWCNT-MENSAGEM-RETORNO LK-GEJVWCNT-NOME-TABELA LK-GEJVWCNT-SQLCODE LK-GEJVWCNT-SQLERRMC. */
            _.Call(WS_JV1_PROGRAMA, GEJVW002, GEJVWCNT);

            /*" -2071- IF LK-GEJVWCNT-IND-ERRO NOT = ZEROS */

            if (GEJVWCNT.LK_GEJVWCNT_IND_ERRO != 00)
            {

                /*" -2072- DISPLAY 'VG2600B- ERRO NA CHAMADA DA GEJVS002 ' */
                _.Display($"VG2600B- ERRO NA CHAMADA DA GEJVS002 ");

                /*" -2073- DISPLAY 'VG2600B- ROTINA CANCELADA ' */
                _.Display($"VG2600B- ROTINA CANCELADA ");

                /*" -2074- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -2074- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0030_SAIDA*/

        [StopWatch]
        /*" R0050-00-LER-MOV-PORTALPJ-SECTION */
        private void R0050_00_LER_MOV_PORTALPJ_SECTION()
        {
            /*" -2084- MOVE 'R0050-00-LER-MOV-PORTAL' TO PARAGRAFO. */
            _.Move("R0050-00-LER-MOV-PORTAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2085- MOVE 'READ' TO COMANDO. */
            _.Move("READ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2087- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2088- READ MOV-PORTAL AT END */
            try
            {
                MOV_PORTAL.Read(() =>
                {

                    /*" -2090- MOVE 'FIM' TO W-FIM-MVTO-PORTAL */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MVTO_PORTAL);

                    /*" -2091- NOT AT END */
                }, () =>
                {

                    /*" -2093- ADD 1 TO W-LIDO-MOVTO-PORTAL W-AC-CONTROLE */
                    WAREA_AUXILIAR.W_LIDO_MOVTO_PORTAL.Value = WAREA_AUXILIAR.W_LIDO_MOVTO_PORTAL + 1;
                    WAREA_AUXILIAR.W_AC_CONTROLE.Value = WAREA_AUXILIAR.W_AC_CONTROLE + 1;

                    /*" -2093- END-READ. */
                });

                _.Move(MOV_PORTAL.Value, REG_PORTAL);

            }
            catch (GoToException ex)
            {
                return;
            }
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0100-00-VALIDAR-HEADER-SECTION */
        private void R0100_00_VALIDAR_HEADER_SECTION()
        {
            /*" -2102- MOVE 'R0100-00-VALIDAR-HEADER' TO PARAGRAFO. */
            _.Move("R0100-00-VALIDAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2103- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2105- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2106- MOVE REG-PORTAL TO REG-HEADER */
            _.Move(MOV_PORTAL?.Value, REG_HEADER);

            /*" -2108- MOVE ZEROS TO WS-COD-ERRO */
            _.Move(0, WS_COD_ERRO);

            /*" -2110- IF (RH-TIPO-REG NOT EQUAL '0' ) */

            if ((REG_HEADER.RH_TIPO_REG != "0"))
            {

                /*" -2111- MOVE 030 TO WS-COD-ERRO */
                _.Move(030, WS_COD_ERRO);

                /*" -2112- MOVE 001 TO WS-COD-CAMPO */
                _.Move(001, WS_COD_CAMPO);

                /*" -2113- MOVE RH-TIPO-REG TO WS-DES-CONTEUDO */
                _.Move(REG_HEADER.RH_TIPO_REG, WS_DES_CONTEUDO);

                /*" -2114- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2115- DISPLAY '     ' */
                _.Display($"     ");

                /*" -2116- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -2117- DISPLAY '          MOVIMENTO NAO POSSUI HEADER  ' */
                _.Display($"          MOVIMENTO NAO POSSUI HEADER  ");

                /*" -2118- DISPLAY '          RH-NOME         - ' RH-NOME */
                _.Display($"          RH-NOME         - {REG_HEADER.RH_NOME}");

                /*" -2119- DISPLAY '          RH-DATA-GERACAO - ' RH-DATA-GERACAO */
                _.Display($"          RH-DATA-GERACAO - {REG_HEADER.RH_DATA_GERACAO}");

                /*" -2121- END-IF. */
            }


            /*" -2123- IF (RH-NOME NOT EQUAL 'PORTALPJ' ) */

            if ((REG_HEADER.RH_NOME != "PORTALPJ"))
            {

                /*" -2124- MOVE 002 TO WS-COD-ERRO */
                _.Move(002, WS_COD_ERRO);

                /*" -2125- MOVE 002 TO WS-COD-CAMPO */
                _.Move(002, WS_COD_CAMPO);

                /*" -2126- MOVE RH-NOME TO WS-DES-CONTEUDO */
                _.Move(REG_HEADER.RH_NOME, WS_DES_CONTEUDO);

                /*" -2127- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2128- DISPLAY '     ' */
                _.Display($"     ");

                /*" -2129- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -2130- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -2131- DISPLAY '          NOME DO ARQUIVO INVALIDO  ' */
                _.Display($"          NOME DO ARQUIVO INVALIDO  ");

                /*" -2132- DISPLAY '          RH-NOME         - ' RH-NOME */
                _.Display($"          RH-NOME         - {REG_HEADER.RH_NOME}");

                /*" -2133- DISPLAY '          RH-DATA-GERACAO - ' RH-DATA-GERACAO */
                _.Display($"          RH-DATA-GERACAO - {REG_HEADER.RH_DATA_GERACAO}");

                /*" -2135- END-IF. */
            }


            /*" -2137- PERFORM R0110-00-VALIDAR-CONVENIO. */

            R0110_00_VALIDAR_CONVENIO_SECTION();

            /*" -2140- IF (RH-DATA-GERACAO NOT NUMERIC) OR (RH-DATA-GERACAO EQUAL ZEROS) */

            if ((!REG_HEADER.RH_DATA_GERACAO.IsNumeric()) || (REG_HEADER.RH_DATA_GERACAO == 00))
            {

                /*" -2141- MOVE 003 TO WS-COD-ERRO */
                _.Move(003, WS_COD_ERRO);

                /*" -2142- MOVE 003 TO WS-COD-CAMPO */
                _.Move(003, WS_COD_CAMPO);

                /*" -2143- MOVE RH-DATA-GERACAO TO WS-DES-CONTEUDO */
                _.Move(REG_HEADER.RH_DATA_GERACAO, WS_DES_CONTEUDO);

                /*" -2144- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2145- DISPLAY '     ' */
                _.Display($"     ");

                /*" -2146- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -2147- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -2148- DISPLAY '          DATA DA GERACAO INVALIDA  ' */
                _.Display($"          DATA DA GERACAO INVALIDA  ");

                /*" -2149- DISPLAY '          RH-NOME         - ' RH-NOME */
                _.Display($"          RH-NOME         - {REG_HEADER.RH_NOME}");

                /*" -2150- DISPLAY '          RH-DATA-GERACAO - ' RH-DATA-GERACAO */
                _.Display($"          RH-DATA-GERACAO - {REG_HEADER.RH_DATA_GERACAO}");

                /*" -2152- END-IF. */
            }


            /*" -2154- IF (RH-SIST-ORIGEM NOT EQUAL 5) */

            if ((REG_HEADER.RH_SIST_ORIGEM != 5))
            {

                /*" -2155- MOVE 004 TO WS-COD-ERRO */
                _.Move(004, WS_COD_ERRO);

                /*" -2156- MOVE 004 TO WS-COD-CAMPO */
                _.Move(004, WS_COD_CAMPO);

                /*" -2157- MOVE RH-SIST-ORIGEM TO WS-DES-CONTEUDO */
                _.Move(REG_HEADER.RH_SIST_ORIGEM, WS_DES_CONTEUDO);

                /*" -2158- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2159- DISPLAY '     ' */
                _.Display($"     ");

                /*" -2160- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -2161- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -2162- DISPLAY '          SISTEMA ORIGEM INVALIDO  ' */
                _.Display($"          SISTEMA ORIGEM INVALIDO  ");

                /*" -2163- DISPLAY '          RH-NOME         - ' RH-NOME */
                _.Display($"          RH-NOME         - {REG_HEADER.RH_NOME}");

                /*" -2164- DISPLAY '          RH-SIST-ORIGEM  - ' RH-SIST-ORIGEM */
                _.Display($"          RH-SIST-ORIGEM  - {REG_HEADER.RH_SIST_ORIGEM}");

                /*" -2165- DISPLAY '          RH-DATA-GERACAO - ' RH-DATA-GERACAO */
                _.Display($"          RH-DATA-GERACAO - {REG_HEADER.RH_DATA_GERACAO}");

                /*" -2167- END-IF. */
            }


            /*" -2169- IF (RH-SIST-DESTINO NOT EQUAL 4) */

            if ((REG_HEADER.RH_SIST_DESTINO != 4))
            {

                /*" -2170- MOVE 005 TO WS-COD-ERRO */
                _.Move(005, WS_COD_ERRO);

                /*" -2171- MOVE 005 TO WS-COD-CAMPO */
                _.Move(005, WS_COD_CAMPO);

                /*" -2172- MOVE RH-SIST-DESTINO TO WS-DES-CONTEUDO */
                _.Move(REG_HEADER.RH_SIST_DESTINO, WS_DES_CONTEUDO);

                /*" -2173- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2174- DISPLAY '     ' */
                _.Display($"     ");

                /*" -2175- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -2176- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -2177- DISPLAY '          SISTEMA DESTINO INVALIDO  ' */
                _.Display($"          SISTEMA DESTINO INVALIDO  ");

                /*" -2178- DISPLAY '          RH-NOME         - ' RH-NOME */
                _.Display($"          RH-NOME         - {REG_HEADER.RH_NOME}");

                /*" -2179- DISPLAY '          RH-SIST-DESTINO - ' RH-SIST-DESTINO */
                _.Display($"          RH-SIST-DESTINO - {REG_HEADER.RH_SIST_DESTINO}");

                /*" -2180- DISPLAY '          RH-DATA-GERACAO - ' RH-DATA-GERACAO */
                _.Display($"          RH-DATA-GERACAO - {REG_HEADER.RH_DATA_GERACAO}");

                /*" -2182- END-IF. */
            }


            /*" -2184- IF (RH-TIPO-ARQUIVO NOT EQUAL 1) */

            if ((REG_HEADER.RH_TIPO_ARQUIVO != 1))
            {

                /*" -2185- MOVE 006 TO WS-COD-ERRO */
                _.Move(006, WS_COD_ERRO);

                /*" -2186- MOVE 007 TO WS-COD-CAMPO */
                _.Move(007, WS_COD_CAMPO);

                /*" -2187- MOVE RH-TIPO-ARQUIVO TO WS-DES-CONTEUDO */
                _.Move(REG_HEADER.RH_TIPO_ARQUIVO, WS_DES_CONTEUDO);

                /*" -2188- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2189- DISPLAY '     ' */
                _.Display($"     ");

                /*" -2190- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -2191- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -2192- DISPLAY '          TIPO DE ARQUIVO INVALIDO  ' */
                _.Display($"          TIPO DE ARQUIVO INVALIDO  ");

                /*" -2193- DISPLAY '          RH-NOME         - ' RH-NOME */
                _.Display($"          RH-NOME         - {REG_HEADER.RH_NOME}");

                /*" -2194- DISPLAY '          RH-TIPO-ARQUIVO - ' RH-TIPO-ARQUIVO */
                _.Display($"          RH-TIPO-ARQUIVO - {REG_HEADER.RH_TIPO_ARQUIVO}");

                /*" -2195- DISPLAY '          RH-DATA-GERACAO - ' RH-DATA-GERACAO */
                _.Display($"          RH-DATA-GERACAO - {REG_HEADER.RH_DATA_GERACAO}");

                /*" -2197- END-IF. */
            }


            /*" -2199- PERFORM R0115-00-VAL-ARQUIVO-PORTAL */

            R0115_00_VAL_ARQUIVO_PORTAL_SECTION();

            /*" -2201- IF (SQLCODE EQUAL ZEROS) */

            if ((DB.SQLCODE == 00))
            {

                /*" -2202- MOVE 008 TO WS-COD-ERRO */
                _.Move(008, WS_COD_ERRO);

                /*" -2203- MOVE 006 TO WS-COD-CAMPO */
                _.Move(006, WS_COD_CAMPO);

                /*" -2204- MOVE RH-NSAS TO WS-DES-CONTEUDO */
                _.Move(REG_HEADER.RH_NSAS, WS_DES_CONTEUDO);

                /*" -2205- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2206- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -2207- DISPLAY '          MOVIMENTO JAH PROCESSADO' */
                _.Display($"          MOVIMENTO JAH PROCESSADO");

                /*" -2208- DISPLAY '          NOME ARQUIVO........ ' RH-NOME */
                _.Display($"          NOME ARQUIVO........ {REG_HEADER.RH_NOME}");

                /*" -2209- DISPLAY '          DATA GERACAO........ ' RH-DATA-GERACAO */
                _.Display($"          DATA GERACAO........ {REG_HEADER.RH_DATA_GERACAO}");

                /*" -2210- DISPLAY '          SISTEMA ORIGEM...... ' RH-SIST-ORIGEM */
                _.Display($"          SISTEMA ORIGEM...... {REG_HEADER.RH_SIST_ORIGEM}");

                /*" -2211- DISPLAY '          SISTEMA DESTINO..... ' RH-SIST-DESTINO */
                _.Display($"          SISTEMA DESTINO..... {REG_HEADER.RH_SIST_DESTINO}");

                /*" -2212- DISPLAY '          NSAS................ ' RH-NSAS */
                _.Display($"          NSAS................ {REG_HEADER.RH_NSAS}");

                /*" -2213- DISPLAY '          SQLCODE............. ' SQLCODE */
                _.Display($"          SQLCODE............. {DB.SQLCODE}");

                /*" -2215- END-IF. */
            }


            /*" -2217- IF (RH-TIPO-ARQUIVO NOT EQUAL 1) */

            if ((REG_HEADER.RH_TIPO_ARQUIVO != 1))
            {

                /*" -2218- MOVE 006 TO WS-COD-ERRO */
                _.Move(006, WS_COD_ERRO);

                /*" -2219- MOVE 007 TO WS-COD-CAMPO */
                _.Move(007, WS_COD_CAMPO);

                /*" -2220- MOVE RH-TIPO-ARQUIVO TO WS-DES-CONTEUDO */
                _.Move(REG_HEADER.RH_TIPO_ARQUIVO, WS_DES_CONTEUDO);

                /*" -2221- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2222- DISPLAY '     ' */
                _.Display($"     ");

                /*" -2223- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -2224- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -2225- DISPLAY '          TIPO DE ARQUIVO INVALIDO  ' */
                _.Display($"          TIPO DE ARQUIVO INVALIDO  ");

                /*" -2226- DISPLAY '          RH-NOME         - ' RH-NOME */
                _.Display($"          RH-NOME         - {REG_HEADER.RH_NOME}");

                /*" -2227- DISPLAY '          RH-TIPO-ARQUIVO - ' RH-TIPO-ARQUIVO */
                _.Display($"          RH-TIPO-ARQUIVO - {REG_HEADER.RH_TIPO_ARQUIVO}");

                /*" -2228- DISPLAY '          RH-DATA-GERACAO - ' RH-DATA-GERACAO */
                _.Display($"          RH-DATA-GERACAO - {REG_HEADER.RH_DATA_GERACAO}");

                /*" -2230- END-IF. */
            }


            /*" -2232- IF (RH-NSAS EQUAL ZEROS) */

            if ((REG_HEADER.RH_NSAS == 00))
            {

                /*" -2233- MOVE 007 TO WS-COD-ERRO */
                _.Move(007, WS_COD_ERRO);

                /*" -2234- MOVE 006 TO WS-COD-CAMPO */
                _.Move(006, WS_COD_CAMPO);

                /*" -2235- MOVE RH-NSAS TO WS-DES-CONTEUDO */
                _.Move(REG_HEADER.RH_NSAS, WS_DES_CONTEUDO);

                /*" -2236- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2237- DISPLAY '     ' */
                _.Display($"     ");

                /*" -2238- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -2239- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -2240- DISPLAY '          SEQUENCIAL DO ARQUIVO INVALIDO ' */
                _.Display($"          SEQUENCIAL DO ARQUIVO INVALIDO ");

                /*" -2241- DISPLAY '          RH-NOME         - ' RH-NOME */
                _.Display($"          RH-NOME         - {REG_HEADER.RH_NOME}");

                /*" -2242- DISPLAY '          RH-NSAS         - ' RH-NSAS */
                _.Display($"          RH-NSAS         - {REG_HEADER.RH_NSAS}");

                /*" -2243- DISPLAY '          RH-DATA-GERACAO - ' RH-DATA-GERACAO */
                _.Display($"          RH-DATA-GERACAO - {REG_HEADER.RH_DATA_GERACAO}");

                /*" -2245- END-IF. */
            }


            /*" -2247- MOVE RH-SIST-ORIGEM TO ARQSIVPF-SISTEMA-ORIGEM */
            _.Move(REG_HEADER.RH_SIST_ORIGEM, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -2249- PERFORM R0117-00-OBTER-NSAS-MOVTO. */

            R0117_00_OBTER_NSAS_MOVTO_SECTION();

            /*" -2250- MOVE RH-NSAS TO ARQSIVPF-NSAS-SIVPF */
            _.Move(REG_HEADER.RH_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -2251- MOVE SISTEMAS-DATA-MOV-ABERTO TO ARQSIVPF-DATA-PROCESSAMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO);

            /*" -2252- MOVE RH-DATA-GERACAO TO W-DATA-TRABALHO */
            _.Move(REG_HEADER.RH_DATA_GERACAO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -2253- MOVE W-DIA-TRABALHO TO W-DIA-SQL */
            _.Move(WAREA_AUXILIAR.FILLER_27.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -2254- MOVE W-MES-TRABALHO TO W-MES-SQL */
            _.Move(WAREA_AUXILIAR.FILLER_27.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -2255- MOVE W-ANO-TRABALHO TO W-ANO-SQL */
            _.Move(WAREA_AUXILIAR.FILLER_27.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -2257- MOVE '-' TO W-BARRA1-SQL W-BARRA2-SQL */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_SQL);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_SQL);


            /*" -2259- MOVE W-DATA-SQL TO ARQSIVPF-DATA-GERACAO WS-JV1-DTA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO, WS_JV1_DTA_PROPOSTA);

            /*" -2261- MOVE W-LIDO-MOVTO-PORTAL TO ARQSIVPF-QTDE-REG-GER. */
            _.Move(WAREA_AUXILIAR.W_LIDO_MOVTO_PORTAL, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -2262- IF (W-IND-1 > ZEROS) */

            if ((WAREA_AUXILIAR.W_IND_1 > 00))
            {

                /*" -2263- PERFORM R9980-00-GERAR-RELATORIO */

                R9980_00_GERAR_RELATORIO_SECTION();

                /*" -2263- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_SAIDA*/

        [StopWatch]
        /*" R0110-00-VALIDAR-CONVENIO-SECTION */
        private void R0110_00_VALIDAR_CONVENIO_SECTION()
        {
            /*" -2273- MOVE 'R0110-00-VALIDAR-CONVENIO' TO PARAGRAFO. */
            _.Move("R0110-00-VALIDAR-CONVENIO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2274- MOVE 'SELECT CONVEIO_PORTAL' TO COMANDO. */
            _.Move("SELECT CONVEIO_PORTAL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2276- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2278- MOVE RH-NOME TO CONVESIV-SIGLA-ARQUIVO */
            _.Move(REG_HEADER.RH_NOME, CONVESIV.DCLCONVENIO_SIVPF.CONVESIV_SIGLA_ARQUIVO);

            /*" -2284- PERFORM R0110_00_VALIDAR_CONVENIO_DB_SELECT_1 */

            R0110_00_VALIDAR_CONVENIO_DB_SELECT_1();

            /*" -2287- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2288- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -2289- DISPLAY '          CONVENIO NAO CADASTRADO' */
                _.Display($"          CONVENIO NAO CADASTRADO");

                /*" -2290- DISPLAY '          NOME ARQUIVO........ ' RH-NOME */
                _.Display($"          NOME ARQUIVO........ {REG_HEADER.RH_NOME}");

                /*" -2291- DISPLAY '          DATA GERACAO........ ' RH-DATA-GERACAO */
                _.Display($"          DATA GERACAO........ {REG_HEADER.RH_DATA_GERACAO}");

                /*" -2292- DISPLAY '          SISTEMA ORIGEM...... ' RH-SIST-ORIGEM */
                _.Display($"          SISTEMA ORIGEM...... {REG_HEADER.RH_SIST_ORIGEM}");

                /*" -2293- DISPLAY '          SISTEMA DESTINO..... ' RH-SIST-DESTINO */
                _.Display($"          SISTEMA DESTINO..... {REG_HEADER.RH_SIST_DESTINO}");

                /*" -2294- DISPLAY '          NSAS................ ' RH-NSAS */
                _.Display($"          NSAS................ {REG_HEADER.RH_NSAS}");

                /*" -2296- DISPLAY '          SIGLA-ARQUIVO....... ' CONVESIV-SIGLA-ARQUIVO */
                _.Display($"          SIGLA-ARQUIVO....... {CONVESIV.DCLCONVENIO_SIVPF.CONVESIV_SIGLA_ARQUIVO}");

                /*" -2297- DISPLAY '          SQLCODE .............' SQLCODE */
                _.Display($"          SQLCODE .............{DB.SQLCODE}");

                /*" -2298- DISPLAY '          SQLERRMC.............<' SQLERRMC '>' */

                $"          SQLERRMC.............<{DB.SQLERRMC}>"
                .Display();

                /*" -2299- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -2299- END-IF. */
            }


        }

        [StopWatch]
        /*" R0110-00-VALIDAR-CONVENIO-DB-SELECT-1 */
        public void R0110_00_VALIDAR_CONVENIO_DB_SELECT_1()
        {
            /*" -2284- EXEC SQL SELECT DESCR_ARQUIVO INTO :CONVESIV-DESCR-ARQUIVO FROM SEGUROS.CONVENIO_SIVPF WHERE SIGLA_ARQUIVO = :CONVESIV-SIGLA-ARQUIVO WITH UR END-EXEC. */

            var r0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1 = new R0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1()
            {
                CONVESIV_SIGLA_ARQUIVO = CONVESIV.DCLCONVENIO_SIVPF.CONVESIV_SIGLA_ARQUIVO.ToString(),
            };

            var executed_1 = R0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1.Execute(r0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVESIV_DESCR_ARQUIVO, CONVESIV.DCLCONVENIO_SIVPF.CONVESIV_DESCR_ARQUIVO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_SAIDA*/

        [StopWatch]
        /*" R0115-00-VAL-ARQUIVO-PORTAL-SECTION */
        private void R0115_00_VAL_ARQUIVO_PORTAL_SECTION()
        {
            /*" -2308- MOVE 'R0115-00-VAL-ARQUIVO-PORTAL' TO PARAGRAFO. */
            _.Move("R0115-00-VAL-ARQUIVO-PORTAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2309- MOVE 'SELECT ARQUIVOS_PORTAL' TO COMANDO. */
            _.Move("SELECT ARQUIVOS_PORTAL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2311- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2312- MOVE RH-NOME TO ARQSIVPF-SIGLA-ARQUIVO */
            _.Move(REG_HEADER.RH_NOME, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -2313- MOVE RH-SIST-ORIGEM TO ARQSIVPF-SISTEMA-ORIGEM */
            _.Move(REG_HEADER.RH_SIST_ORIGEM, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -2315- MOVE RH-NSAS TO ARQSIVPF-NSAS-SIVPF */
            _.Move(REG_HEADER.RH_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -2323- PERFORM R0115_00_VAL_ARQUIVO_PORTAL_DB_SELECT_1 */

            R0115_00_VAL_ARQUIVO_PORTAL_DB_SELECT_1();

            /*" -2326- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -2327- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -2328- DISPLAY '        ERRO ACESSO ARQUIVOS_PORTAL' */
                _.Display($"        ERRO ACESSO ARQUIVOS_PORTAL");

                /*" -2329- DISPLAY '        NOME ARQUIVO...... ' RH-NOME */
                _.Display($"        NOME ARQUIVO...... {REG_HEADER.RH_NOME}");

                /*" -2330- DISPLAY '        DATA GERACAO...... ' RH-DATA-GERACAO */
                _.Display($"        DATA GERACAO...... {REG_HEADER.RH_DATA_GERACAO}");

                /*" -2331- DISPLAY '        SISTEMA ORIGEM.... ' RH-SIST-ORIGEM */
                _.Display($"        SISTEMA ORIGEM.... {REG_HEADER.RH_SIST_ORIGEM}");

                /*" -2332- DISPLAY '        SISTEMA DESTINO... ' RH-SIST-DESTINO */
                _.Display($"        SISTEMA DESTINO... {REG_HEADER.RH_SIST_DESTINO}");

                /*" -2333- DISPLAY '        NSAS.............. ' RH-NSAS */
                _.Display($"        NSAS.............. {REG_HEADER.RH_NSAS}");

                /*" -2334- DISPLAY '        SQLCODE........... ' SQLCODE */
                _.Display($"        SQLCODE........... {DB.SQLCODE}");

                /*" -2335- DISPLAY '        SQLERRMC..........<' SQLERRMC '>' */

                $"        SQLERRMC..........<{DB.SQLERRMC}>"
                .Display();

                /*" -2337- DISPLAY '        SIGLA-ARQUIVO..... ' ARQSIVPF-SIGLA-ARQUIVO */
                _.Display($"        SIGLA-ARQUIVO..... {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -2339- DISPLAY '        SISTEMA_ORIGEM.... ' ARQSIVPF-SISTEMA-ORIGEM */
                _.Display($"        SISTEMA_ORIGEM.... {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM}");

                /*" -2341- DISPLAY '        NSAS_SIVPF........ ' ARQSIVPF-NSAS-SIVPF */
                _.Display($"        NSAS_SIVPF........ {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -2342- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -2342- END-IF. */
            }


        }

        [StopWatch]
        /*" R0115-00-VAL-ARQUIVO-PORTAL-DB-SELECT-1 */
        public void R0115_00_VAL_ARQUIVO_PORTAL_DB_SELECT_1()
        {
            /*" -2323- EXEC SQL SELECT DATA_GERACAO INTO :ARQSIVPF-DATA-GERACAO FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :ARQSIVPF-SISTEMA-ORIGEM AND NSAS_SIVPF = :ARQSIVPF-NSAS-SIVPF WITH UR END-EXEC. */

            var r0115_00_VAL_ARQUIVO_PORTAL_DB_SELECT_1_Query1 = new R0115_00_VAL_ARQUIVO_PORTAL_DB_SELECT_1_Query1()
            {
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
            };

            var executed_1 = R0115_00_VAL_ARQUIVO_PORTAL_DB_SELECT_1_Query1.Execute(r0115_00_VAL_ARQUIVO_PORTAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_DATA_GERACAO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0115_SAIDA*/

        [StopWatch]
        /*" R0117-00-OBTER-NSAS-MOVTO-SECTION */
        private void R0117_00_OBTER_NSAS_MOVTO_SECTION()
        {
            /*" -2351- MOVE 'R0117-00-OBTER-NSAS-MOVTO' TO PARAGRAFO. */
            _.Move("R0117-00-OBTER-NSAS-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2352- MOVE 'SELECT COUNT ARQUIVOS-PORTAL' TO COMANDO. */
            _.Move("SELECT COUNT ARQUIVOS-PORTAL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2354- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2355- MOVE RH-NOME TO ARQSIVPF-SIGLA-ARQUIVO */
            _.Move(REG_HEADER.RH_NOME, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -2357- MOVE RH-SIST-ORIGEM TO ARQSIVPF-SISTEMA-ORIGEM */
            _.Move(REG_HEADER.RH_SIST_ORIGEM, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -2364- PERFORM R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1 */

            R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1();

            /*" -2367- IF (SQLCODE EQUAL ZEROS) */

            if ((DB.SQLCODE == 00))
            {

                /*" -2368- MOVE ARQSIVPF-NSAS-SIVPF TO W-NSAS-FILIAL */
                _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS_FILIAL);

                /*" -2369- ELSE */
            }
            else
            {


                /*" -2370- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -2372- DISPLAY '          ERRO ACESSO TABELA ARQUIVOS-SIVPF ' */
                _.Display($"          ERRO ACESSO TABELA ARQUIVOS-SIVPF ");

                /*" -2374- DISPLAY '          SQLCODE ....... ' SQLCODE */
                _.Display($"          SQLCODE ....... {DB.SQLCODE}");

                /*" -2375- DISPLAY '          SQLERRMC..........<' SQLERRMC '>' */

                $"          SQLERRMC..........<{DB.SQLERRMC}>"
                .Display();

                /*" -2377- DISPLAY '          SIGLA DO ARQUIVO................. ' ARQSIVPF-SIGLA-ARQUIVO */
                _.Display($"          SIGLA DO ARQUIVO................. {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -2379- DISPLAY '          SISTEMA ORIGEM................... ' ARQSIVPF-SISTEMA-ORIGEM */
                _.Display($"          SISTEMA ORIGEM................... {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM}");

                /*" -2380- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -2380- END-IF. */
            }


        }

        [StopWatch]
        /*" R0117-00-OBTER-NSAS-MOVTO-DB-SELECT-1 */
        public void R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1()
        {
            /*" -2364- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) + 1 INTO :ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

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
        /*" R0200-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0200_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -2389- MOVE 'R0200-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0200-00-PROCESSA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2390- MOVE 'PROCESSAR MOVIMENTO        ' TO COMANDO. */
            _.Move("PROCESSAR MOVIMENTO        ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2392- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2394- PERFORM R0270-00-INICIALIZAR-AREAS. */

            R0270_00_INICIALIZAR_AREAS_SECTION();

            /*" -2398- PERFORM R0300-00-TRATA-MOVIMENTO UNTIL W-FIM-MVTO-PORTAL EQUAL 'FIM' OR REG-NUM-PROPOSTA NOT EQUAL W-NUM-PROPOSTA-ANT. */

            while (!(WAREA_AUXILIAR.W_FIM_MVTO_PORTAL == "FIM" || REG_PORTAL.REG_NUM_PROPOSTA != WAREA_AUXILIAR.W_NUM_PROPOSTA_ANT))
            {

                R0300_00_TRATA_MOVIMENTO_SECTION();
            }

            /*" -2399- IF (W-CRITICA-PROPOSTA-NAO-88) */

            if ((WREA88.W_CRITICA_PROPOSTA["W_CRITICA_PROPOSTA_NAO_88"]))
            {

                /*" -2400- MOVE ZEROS TO W-IND-TAB */
                _.Move(0, WAREA_AUXILIAR.W_IND_TAB);

                /*" -2401- PERFORM R0400-00-GERAR-APOL-ESPEC W-IND-MOV TIMES */

                for (int i = 0; i < WAREA_AUXILIAR.W_IND_MOV; i++)
                {

                    R0400_00_GERAR_APOL_ESPEC_SECTION();

                }

                /*" -2403- END-IF. */
            }


            /*" -2404- IF (W-CRITICA-PROPOSTA-NAO-88) */

            if ((WREA88.W_CRITICA_PROPOSTA["W_CRITICA_PROPOSTA_NAO_88"]))
            {

                /*" -2406- IF (W-NUM-PROPOSTA-ANT > ZEROS) */

                if ((WAREA_AUXILIAR.W_NUM_PROPOSTA_ANT > 00))
                {

                    /*" -2407- MOVE 001 TO WS-COD-ERRO */
                    _.Move(001, WS_COD_ERRO);

                    /*" -2408- MOVE 000 TO WS-COD-CAMPO */
                    _.Move(000, WS_COD_CAMPO);

                    /*" -2409- MOVE 'SUCESSO' TO WS-TP-MENSAGEM */
                    _.Move("SUCESSO", WS_TP_MENSAGEM);

                    /*" -2410- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -2411- END-IF */
                }


                /*" -2411- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0270-00-INICIALIZAR-AREAS-SECTION */
        private void R0270_00_INICIALIZAR_AREAS_SECTION()
        {
            /*" -2420- MOVE 'R0270-00-INICIALIZAR-AREAS' TO PARAGRAFO */
            _.Move("R0270-00-INICIALIZAR-AREAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2421- MOVE 'INICIALIZAR AREAS ' TO COMANDO. */
            _.Move("INICIALIZAR AREAS ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2423- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2426- MOVE REG-NUM-PROPOSTA TO W-NUM-PROPOSTA W-NUM-PROPOSTA-ANT. */
            _.Move(REG_PORTAL.REG_NUM_PROPOSTA, WREA88.W_NUM_PROPOSTA, WAREA_AUXILIAR.W_NUM_PROPOSTA_ANT);

            /*" -2427- MOVE 1 TO W-CRITICA-PROPOSTA. */
            _.Move(1, WREA88.W_CRITICA_PROPOSTA);

            /*" -2428- MOVE ZEROS TO W-IND-MOV */
            _.Move(0, WAREA_AUXILIAR.W_IND_MOV);

            /*" -2429- MOVE ZEROS TO W-IND-END */
            _.Move(0, WAREA_AUXILIAR.W_IND_END);

            /*" -2430- MOVE 'N' TO WS-FLAG-TEM-TP1 */
            _.Move("N", WS_FLAG_TEM_TP1);

            /*" -2431- MOVE 'N' TO WS-FLAG-TEM-TP2 */
            _.Move("N", WS_FLAG_TEM_TP2);

            /*" -2432- MOVE 'N' TO WS-FLAG-TEM-TP3 */
            _.Move("N", WS_FLAG_TEM_TP3);

            /*" -2433- MOVE 'N' TO WS-FLAG-TEM-TP4 */
            _.Move("N", WS_FLAG_TEM_TP4);

            /*" -2434- MOVE 'N' TO WS-FLAG-TEM-TP5 */
            _.Move("N", WS_FLAG_TEM_TP5);

            /*" -2435- MOVE 'N' TO WS-FLAG-TEM-TP6 */
            _.Move("N", WS_FLAG_TEM_TP6);

            /*" -2436- MOVE 'N' TO WS-FLAG-TEM-TP7 */
            _.Move("N", WS_FLAG_TEM_TP7);

            /*" -2436- MOVE 'N' TO WS-FLAG-TEM-SUBGRUPO. */
            _.Move("N", WS_FLAG_TEM_SUBGRUPO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_SAIDA*/

        [StopWatch]
        /*" R0300-00-TRATA-MOVIMENTO-SECTION */
        private void R0300_00_TRATA_MOVIMENTO_SECTION()
        {
            /*" -2445- MOVE 'R0300-00-TRATA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0300-00-TRATA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2446- MOVE 'CRITICAR' TO COMANDO. */
            _.Move("CRITICAR", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2448- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2449- EVALUATE REG-TIPO-PORTAL */
            switch (REG_PORTAL.REG_TIPO_PORTAL.Value.Trim())
            {

                /*" -2450- WHEN '0' */
                case "0":

                    /*" -2452- PERFORM R0100-00-VALIDAR-HEADER */

                    R0100_00_VALIDAR_HEADER_SECTION();

                    /*" -2453- IF (WS-COD-ERRO > ZEROS) */

                    if ((WS_COD_ERRO > 00))
                    {

                        /*" -2454- MOVE 'FIM' TO W-FIM-MVTO-PORTAL */
                        _.Move("FIM", WAREA_AUXILIAR.W_FIM_MVTO_PORTAL);

                        /*" -2455- MOVE 2 TO W-CRITICA-PROPOSTA */
                        _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                        /*" -2456- GO TO R0300-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_SAIDA*/ //GOTO
                        return;

                        /*" -2458- END-IF */
                    }


                    /*" -2459- ADD 1 TO W-QTD-LD-PORTAL-0 */
                    WAREA_AUXILIAR.W_QTD_LD_PORTAL_0.Value = WAREA_AUXILIAR.W_QTD_LD_PORTAL_0 + 1;

                    /*" -2460- WHEN '1' */
                    break;
                case "1":

                    /*" -2461- PERFORM R0310-00-MOVTO-APOL-SUBG */

                    R0310_00_MOVTO_APOL_SUBG_SECTION();

                    /*" -2462- ADD 1 TO W-QTD-LD-PORTAL-1 */
                    WAREA_AUXILIAR.W_QTD_LD_PORTAL_1.Value = WAREA_AUXILIAR.W_QTD_LD_PORTAL_1 + 1;

                    /*" -2463- WHEN '2' */
                    break;
                case "2":

                    /*" -2464- PERFORM R0315-00-MOVTO-ENDERECO */

                    R0315_00_MOVTO_ENDERECO_SECTION();

                    /*" -2465- ADD 1 TO W-QTD-LD-PORTAL-2 */
                    WAREA_AUXILIAR.W_QTD_LD_PORTAL_2.Value = WAREA_AUXILIAR.W_QTD_LD_PORTAL_2 + 1;

                    /*" -2466- WHEN '3' */
                    break;
                case "3":

                    /*" -2467- PERFORM R0320-00-MOVTO-REPR-LEGAL */

                    R0320_00_MOVTO_REPR_LEGAL_SECTION();

                    /*" -2468- ADD 1 TO W-QTD-LD-PORTAL-3 */
                    WAREA_AUXILIAR.W_QTD_LD_PORTAL_3.Value = WAREA_AUXILIAR.W_QTD_LD_PORTAL_3 + 1;

                    /*" -2469- WHEN '4' */
                    break;
                case "4":

                    /*" -2470- PERFORM R0325-00-MOVTO-COBER-ADIC */

                    R0325_00_MOVTO_COBER_ADIC_SECTION();

                    /*" -2471- ADD 1 TO W-QTD-LD-PORTAL-4 */
                    WAREA_AUXILIAR.W_QTD_LD_PORTAL_4.Value = WAREA_AUXILIAR.W_QTD_LD_PORTAL_4 + 1;

                    /*" -2472- WHEN '5' */
                    break;
                case "5":

                    /*" -2473- PERFORM R0330-00-MOVTO-CORRETAGEM */

                    R0330_00_MOVTO_CORRETAGEM_SECTION();

                    /*" -2474- ADD 1 TO W-QTD-LD-PORTAL-5 */
                    WAREA_AUXILIAR.W_QTD_LD_PORTAL_5.Value = WAREA_AUXILIAR.W_QTD_LD_PORTAL_5 + 1;

                    /*" -2475- WHEN '6' */
                    break;
                case "6":

                    /*" -2476- PERFORM R0340-00-MOVTO-PLANO-CONDTEC */

                    R0340_00_MOVTO_PLANO_CONDTEC_SECTION();

                    /*" -2477- ADD 1 TO W-QTD-LD-PORTAL-6 */
                    WAREA_AUXILIAR.W_QTD_LD_PORTAL_6.Value = WAREA_AUXILIAR.W_QTD_LD_PORTAL_6 + 1;

                    /*" -2478- WHEN '9' */
                    break;
                case "9":

                    /*" -2479- PERFORM R0360-00-VALIDA-TRAILLER */

                    R0360_00_VALIDA_TRAILLER_SECTION();

                    /*" -2480- ADD 1 TO W-QTD-LD-PORTAL-9 */
                    WAREA_AUXILIAR.W_QTD_LD_PORTAL_9.Value = WAREA_AUXILIAR.W_QTD_LD_PORTAL_9 + 1;

                    /*" -2481- WHEN OTHER */
                    break;
                default:

                    /*" -2482- DISPLAY 'VG2600B - FIM ANORMAL' */
                    _.Display($"VG2600B - FIM ANORMAL");

                    /*" -2483- DISPLAY '          TIPO REGISTRO NAO ESPERADO' */
                    _.Display($"          TIPO REGISTRO NAO ESPERADO");

                    /*" -2485- DISPLAY '          TIPO DE REGISTRO........  ' REG-TIPO-PORTAL */
                    _.Display($"          TIPO DE REGISTRO........  {REG_PORTAL.REG_TIPO_PORTAL}");

                    /*" -2487- DISPLAY '          NUMERO DA PROPOSTA......  ' REG-NUM-PROPOSTA */
                    _.Display($"          NUMERO DA PROPOSTA......  {REG_PORTAL.REG_NUM_PROPOSTA}");

                    /*" -2488- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -2489- DISPLAY REG-PORTAL */
                    _.Display(REG_PORTAL);

                    /*" -2490- GO TO R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;

                    /*" -2492- END-EVALUATE. */
                    break;
            }


            /*" -2492- PERFORM R0050-00-LER-MOV-PORTALPJ. */

            R0050_00_LER_MOV_PORTALPJ_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_SAIDA*/

        [StopWatch]
        /*" R0310-00-MOVTO-APOL-SUBG-SECTION */
        private void R0310_00_MOVTO_APOL_SUBG_SECTION()
        {
            /*" -2503- MOVE 'R0310-00-MOVTO-APOL-SUBG' TO PARAGRAFO. */
            _.Move("R0310-00-MOVTO-APOL-SUBG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2504- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2506- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2507- INITIALIZE REG-R1-SUBGRUPO */
            _.Initialize(
                REG_R1_SUBGRUPO
            );

            /*" -2509- MOVE REG-PORTAL TO REG-R1-SUBGRUPO */
            _.Move(MOV_PORTAL?.Value, REG_R1_SUBGRUPO);

            /*" -2527- DISPLAY 'R0310-REG-R1-SUBGRUPO:' ' TP=' R1-TIPO-REG ' PROP=' R1-NUM-PROPOSTA ' SUBG=' R1-NUM-SUBGRUPO ' TPAPO=' R1-NUM-TIPO-APOL ' CGC=' R1-NUM-CGC-CNPJ ' VAL-FAT-ANUAL=' R1-VAL-FAT-ANUAL ' COD-PORT-EMP=' R1-COD-PORTE-EMP ' DTA-CONST-EMP=' R1-DTA-CONST-EMP ' CSUC=' R1-COD-SUCURSAL ' TPPLA=' R1-COD-TP-PLANO ' TPCOR=' R1-COD-TP-CORRECAO ' TPFAT=' R1-COD-TP-FATURA ' TPCOSS=' R1-COD-TP-COSSEG-CED ' PROD=' R1-COD-PRODUTO ' COD-CNAE-ATIV=' R1-COD-CNAE-ATIVIDADE ' NUM-APOLICE   ' R1-NUM-APOLICE */

            $"R0310-REG-R1-SUBGRUPO: TP={REG_R1_SUBGRUPO.R1_TIPO_REG} PROP={REG_R1_SUBGRUPO.R1_NUM_PROPOSTA} SUBG={REG_R1_SUBGRUPO.R1_NUM_SUBGRUPO} TPAPO={REG_R1_SUBGRUPO.R1_NUM_TIPO_APOL} CGC={REG_R1_SUBGRUPO.R1_NUM_CGC_CNPJ} VAL-FAT-ANUAL={REG_R1_SUBGRUPO.R1_VAL_FAT_ANUAL} COD-PORT-EMP={REG_R1_SUBGRUPO.R1_COD_PORTE_EMP} DTA-CONST-EMP={REG_R1_SUBGRUPO.R1_DTA_CONST_EMP} CSUC={REG_R1_SUBGRUPO.R1_COD_SUCURSAL} TPPLA={REG_R1_SUBGRUPO.R1_COD_TP_PLANO} TPCOR={REG_R1_SUBGRUPO.R1_COD_TP_CORRECAO} TPFAT={REG_R1_SUBGRUPO.R1_COD_TP_FATURA} TPCOSS={REG_R1_SUBGRUPO.R1_COD_TP_COSSEG_CED} PROD={REG_R1_SUBGRUPO.R1_COD_PRODUTO} COD-CNAE-ATIV={REG_R1_SUBGRUPO.R1_COD_CNAE_ATIVIDADE} NUM-APOLICE   {REG_R1_SUBGRUPO.R1_NUM_APOLICE}"
            .Display();

            /*" -2528- MOVE R1-NUM-PROPOSTA TO WS-NUM-PROPOSTA */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_PROPOSTA, WS_NUM_PROPOSTA);

            /*" -2529- MOVE R1-NUM-SUBGRUPO TO WS-COD-SUBGRUPO */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_SUBGRUPO, WS_COD_SUBGRUPO);

            /*" -2530- MOVE R1-NUM-APOLICE TO WS-NUM-APOLICE */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_APOLICE, WS_NUM_APOLICE);

            /*" -2531- MOVE ZEROS TO WS-COD-ERRO */
            _.Move(0, WS_COD_ERRO);

            /*" -2532- MOVE ZEROS TO WS-NUM-SEQ-ARQ */
            _.Move(0, WS_NUM_SEQ_ARQ);

            /*" -2534- MOVE 'ERRO' TO WS-TP-MENSAGEM */
            _.Move("ERRO", WS_TP_MENSAGEM);

            /*" -2536- INITIALIZE WS-DES-CONTEUDO */
            _.Initialize(
                WS_DES_CONTEUDO
            );

            /*" -2539- IF (R1-NUM-PROPOSTA IS NOT NUMERIC) OR (R1-NUM-PROPOSTA EQUAL ZEROS) */

            if ((!REG_R1_SUBGRUPO.R1_NUM_PROPOSTA.IsNumeric()) || (REG_R1_SUBGRUPO.R1_NUM_PROPOSTA == 00))
            {

                /*" -2540- MOVE 009 TO WS-COD-ERRO */
                _.Move(009, WS_COD_ERRO);

                /*" -2541- MOVE 009 TO WS-COD-CAMPO */
                _.Move(009, WS_COD_CAMPO);

                /*" -2542- MOVE R1-NUM-PROPOSTA TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_NUM_PROPOSTA, WS_DES_CONTEUDO);

                /*" -2543- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2545- ELSE */
            }
            else
            {


                /*" -2546- MOVE R1-NUM-PROPOSTA TO PF087-NUM-PROPOSTA */
                _.Move(REG_R1_SUBGRUPO.R1_NUM_PROPOSTA, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_PROPOSTA);

                /*" -2548- PERFORM R8036-00-VERIFICA-PROPOSTA */

                R8036_00_VERIFICA_PROPOSTA_SECTION();

                /*" -2550- IF (SQLCODE EQUAL ZEROS) */

                if ((DB.SQLCODE == 00))
                {

                    /*" -2551- MOVE 010 TO WS-COD-ERRO */
                    _.Move(010, WS_COD_ERRO);

                    /*" -2552- MOVE 009 TO WS-COD-CAMPO */
                    _.Move(009, WS_COD_CAMPO);

                    /*" -2553- MOVE R1-NUM-PROPOSTA TO WS-DES-CONTEUDO */
                    _.Move(REG_R1_SUBGRUPO.R1_NUM_PROPOSTA, WS_DES_CONTEUDO);

                    /*" -2554- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -2555- END-IF */
                }


                /*" -2557- END-IF. */
            }


            /*" -2559- IF (R1-NUM-SUBGRUPO IS NOT NUMERIC) */

            if ((!REG_R1_SUBGRUPO.R1_NUM_SUBGRUPO.IsNumeric()))
            {

                /*" -2560- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -2561- MOVE 010 TO WS-COD-CAMPO */
                _.Move(010, WS_COD_CAMPO);

                /*" -2562- MOVE R1-NUM-SUBGRUPO TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_NUM_SUBGRUPO, WS_DES_CONTEUDO);

                /*" -2563- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2565- END-IF. */
            }


            /*" -2567- IF (R1-NUM-SUBGRUPO EQUAL ZEROS) */

            if ((REG_R1_SUBGRUPO.R1_NUM_SUBGRUPO == 00))
            {

                /*" -2568- MOVE 009 TO WS-COD-ERRO */
                _.Move(009, WS_COD_ERRO);

                /*" -2569- MOVE 010 TO WS-COD-CAMPO */
                _.Move(010, WS_COD_CAMPO);

                /*" -2570- MOVE R1-NUM-SUBGRUPO TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_NUM_SUBGRUPO, WS_DES_CONTEUDO);

                /*" -2571- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2573- END-IF. */
            }


            /*" -2574- IF (R1-NUM-SUBGRUPO > 1) */

            if ((REG_R1_SUBGRUPO.R1_NUM_SUBGRUPO > 1))
            {

                /*" -2575- MOVE 'S' TO WS-FLAG-TEM-SUBGRUPO */
                _.Move("S", WS_FLAG_TEM_SUBGRUPO);

                /*" -2577- END-IF */
            }


            /*" -2579- IF (R1-NUM-TIPO-APOL NOT EQUAL '4' AND '5' ) */

            if ((!REG_R1_SUBGRUPO.R1_NUM_TIPO_APOL.In("4", "5")))
            {

                /*" -2580- MOVE 014 TO WS-COD-ERRO */
                _.Move(014, WS_COD_ERRO);

                /*" -2581- MOVE 011 TO WS-COD-CAMPO */
                _.Move(011, WS_COD_CAMPO);

                /*" -2582- MOVE R1-NUM-TIPO-APOL TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_NUM_TIPO_APOL, WS_DES_CONTEUDO);

                /*" -2583- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2585- END-IF. */
            }


            /*" -2587- IF (R1-NOM-EMPRESA EQUAL SPACES OR LOW-VALUES) */

            if ((REG_R1_SUBGRUPO.R1_NOM_EMPRESA.IsLowValues()))
            {

                /*" -2588- MOVE 013 TO WS-COD-ERRO */
                _.Move(013, WS_COD_ERRO);

                /*" -2589- MOVE 013 TO WS-COD-CAMPO */
                _.Move(013, WS_COD_CAMPO);

                /*" -2590- MOVE R1-NOM-EMPRESA TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_NOM_EMPRESA, WS_DES_CONTEUDO);

                /*" -2591- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2592- ELSE */
            }
            else
            {


                /*" -2593- MOVE 1 TO WS-POSICAO */
                _.Move(1, WS_POSICAO);

                /*" -2595- MOVE ZEROS TO WS-CONTA-BRC */
                _.Move(0, WS_CONTA_BRC);

                /*" -2596- PERFORM UNTIL WS-POSICAO > 40 */

                while (!(WS_POSICAO > 40))
                {

                    /*" -2597- IF (R1-NOM-EMPRESA(WS-POSICAO:1) NOT EQUAL SPACES) */

                    if ((REG_R1_SUBGRUPO.R1_NOM_EMPRESA.Substring(WS_POSICAO, 1) != string.Empty))
                    {

                        /*" -2598- ADD 1 TO WS-CONTA-BRC */
                        WS_CONTA_BRC.Value = WS_CONTA_BRC + 1;

                        /*" -2599- END-IF */
                    }


                    /*" -2600- ADD 1 TO WS-POSICAO */
                    WS_POSICAO.Value = WS_POSICAO + 1;

                    /*" -2602- END-PERFORM */
                }

                /*" -2604- IF WS-CONTA-BRC < 5 */

                if (WS_CONTA_BRC < 5)
                {

                    /*" -2605- MOVE 016 TO WS-COD-ERRO */
                    _.Move(016, WS_COD_ERRO);

                    /*" -2606- MOVE 013 TO WS-COD-CAMPO */
                    _.Move(013, WS_COD_CAMPO);

                    /*" -2607- MOVE R1-NOM-EMPRESA TO WS-DES-CONTEUDO */
                    _.Move(REG_R1_SUBGRUPO.R1_NOM_EMPRESA, WS_DES_CONTEUDO);

                    /*" -2608- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -2609- END-IF */
                }


                /*" -2611- END-IF. */
            }


            /*" -2613- IF (R1-VAL-FAT-ANUAL IS NOT NUMERIC) */

            if ((!REG_R1_SUBGRUPO.R1_VAL_FAT_ANUAL.IsNumeric()))
            {

                /*" -2614- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -2615- MOVE 014 TO WS-COD-CAMPO */
                _.Move(014, WS_COD_CAMPO);

                /*" -2616- MOVE R1-VAL-FAT-ANUAL TO WS-DES-CONTEU-N */
                _.Move(REG_R1_SUBGRUPO.R1_VAL_FAT_ANUAL, FILLER_23.WS_DES_CONTEU_N);

                /*" -2617- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2619- END-IF. */
            }


            /*" -2621- IF (R1-COD-PORTE-EMP IS NOT NUMERIC) */

            if ((!REG_R1_SUBGRUPO.R1_COD_PORTE_EMP.IsNumeric()))
            {

                /*" -2622- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -2623- MOVE 015 TO WS-COD-CAMPO */
                _.Move(015, WS_COD_CAMPO);

                /*" -2624- MOVE R1-COD-PORTE-EMP TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_COD_PORTE_EMP, WS_DES_CONTEUDO);

                /*" -2625- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2627- END-IF. */
            }


            /*" -2628- IF (R1-DTA-CONST-EMP NOT EQUAL SPACES OR LOW-VALUES) */

            if ((REG_R1_SUBGRUPO.R1_DTA_CONST_EMP != ""))
            {

                /*" -2629- MOVE R1-DTA-CONST-EMP TO W-DATA-TRABALHO */
                _.Move(REG_R1_SUBGRUPO.R1_DTA_CONST_EMP, WAREA_AUXILIAR.W_DATA_TRABALHO);

                /*" -2631- PERFORM R8001-00-VERIFICA-DATA-VALIDA */

                R8001_00_VERIFICA_DATA_VALIDA_SECTION();

                /*" -2633- IF (SQLCODE NOT EQUAL ZEROS) */

                if ((DB.SQLCODE != 00))
                {

                    /*" -2634- MOVE 012 TO WS-COD-ERRO */
                    _.Move(012, WS_COD_ERRO);

                    /*" -2635- MOVE 016 TO WS-COD-CAMPO */
                    _.Move(016, WS_COD_CAMPO);

                    /*" -2636- MOVE R1-DTA-CONST-EMP TO WS-DES-CONTEUDO */
                    _.Move(REG_R1_SUBGRUPO.R1_DTA_CONST_EMP, WS_DES_CONTEUDO);

                    /*" -2637- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -2638- END-IF */
                }


                /*" -2640- END-IF. */
            }


            /*" -2642- IF (R1-DTA-INI-VIGENCIA EQUAL SPACES OR LOW-VALUES) */

            if ((REG_R1_SUBGRUPO.R1_DTA_INI_VIGENCIA.IsLowValues()))
            {

                /*" -2643- MOVE 013 TO WS-COD-ERRO */
                _.Move(013, WS_COD_ERRO);

                /*" -2644- MOVE 017 TO WS-COD-CAMPO */
                _.Move(017, WS_COD_CAMPO);

                /*" -2645- MOVE R1-DTA-INI-VIGENCIA TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_DTA_INI_VIGENCIA, WS_DES_CONTEUDO);

                /*" -2646- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2647- ELSE */
            }
            else
            {


                /*" -2648- MOVE R1-DTA-INI-VIGENCIA TO W-DATA-TRABALHO */
                _.Move(REG_R1_SUBGRUPO.R1_DTA_INI_VIGENCIA, WAREA_AUXILIAR.W_DATA_TRABALHO);

                /*" -2650- PERFORM R8001-00-VERIFICA-DATA-VALIDA */

                R8001_00_VERIFICA_DATA_VALIDA_SECTION();

                /*" -2652- IF (SQLCODE NOT EQUAL ZEROS) */

                if ((DB.SQLCODE != 00))
                {

                    /*" -2653- MOVE 013 TO WS-COD-ERRO */
                    _.Move(013, WS_COD_ERRO);

                    /*" -2654- MOVE 017 TO WS-COD-CAMPO */
                    _.Move(017, WS_COD_CAMPO);

                    /*" -2655- MOVE R1-DTA-INI-VIGENCIA TO WS-DES-CONTEUDO */
                    _.Move(REG_R1_SUBGRUPO.R1_DTA_INI_VIGENCIA, WS_DES_CONTEUDO);

                    /*" -2656- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -2657- END-IF */
                }


                /*" -2659- END-IF. */
            }


            /*" -2661- IF (R1-COD-SUCURSAL IS NOT NUMERIC) */

            if ((!REG_R1_SUBGRUPO.R1_COD_SUCURSAL.IsNumeric()))
            {

                /*" -2662- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -2663- MOVE 018 TO WS-COD-CAMPO */
                _.Move(018, WS_COD_CAMPO);

                /*" -2664- MOVE R1-COD-SUCURSAL TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_COD_SUCURSAL, WS_DES_CONTEUDO);

                /*" -2665- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2666- ELSE */
            }
            else
            {


                /*" -2668- MOVE R1-COD-SUCURSAL TO FONTES-COD-FONTE */
                _.Move(REG_R1_SUBGRUPO.R1_COD_SUCURSAL, FONTES.DCLFONTES.FONTES_COD_FONTE);

                /*" -2669- MOVE 1 TO WH-QTD-ULT-PROP */
                _.Move(1, WH_QTD_ULT_PROP);

                /*" -2671- PERFORM R8002-00-VERIFICA-FONTES */

                R8002_00_VERIFICA_FONTES_SECTION();

                /*" -2673- IF (SQLCODE NOT EQUAL ZEROS) */

                if ((DB.SQLCODE != 00))
                {

                    /*" -2674- MOVE 014 TO WS-COD-ERRO */
                    _.Move(014, WS_COD_ERRO);

                    /*" -2675- MOVE 018 TO WS-COD-CAMPO */
                    _.Move(018, WS_COD_CAMPO);

                    /*" -2676- MOVE R1-COD-SUCURSAL TO WS-DES-CONTEUDO */
                    _.Move(REG_R1_SUBGRUPO.R1_COD_SUCURSAL, WS_DES_CONTEUDO);

                    /*" -2677- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -2678- END-IF */
                }


                /*" -2680- END-IF. */
            }


            /*" -2683- IF (R1-IND-OP-COBERTUR IS NOT NUMERIC) OR (R1-IND-OP-COBERTUR NOT EQUAL 1 AND 2 AND 3) */

            if ((!REG_R1_SUBGRUPO.R1_IND_OP_COBERTUR.IsNumeric()) || (!REG_R1_SUBGRUPO.R1_IND_OP_COBERTUR.In("1", "2", "3")))
            {

                /*" -2684- MOVE 012 TO WS-COD-ERRO */
                _.Move(012, WS_COD_ERRO);

                /*" -2685- MOVE 019 TO WS-COD-CAMPO */
                _.Move(019, WS_COD_CAMPO);

                /*" -2686- MOVE R1-IND-OP-COBERTUR TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_IND_OP_COBERTUR, WS_DES_CONTEUDO);

                /*" -2687- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2689- END-IF. */
            }


            /*" -2692- IF (R1-IND-OP-CORRETAG IS NOT NUMERIC) OR (R1-IND-OP-CORRETAG NOT EQUAL 1 AND 2) */

            if ((!REG_R1_SUBGRUPO.R1_IND_OP_CORRETAG.IsNumeric()) || (!REG_R1_SUBGRUPO.R1_IND_OP_CORRETAG.In("1", "2")))
            {

                /*" -2693- MOVE 012 TO WS-COD-ERRO */
                _.Move(012, WS_COD_ERRO);

                /*" -2694- MOVE 020 TO WS-COD-CAMPO */
                _.Move(020, WS_COD_CAMPO);

                /*" -2695- MOVE R1-IND-OP-CORRETAG TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_IND_OP_CORRETAG, WS_DES_CONTEUDO);

                /*" -2696- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2698- END-IF. */
            }


            /*" -2701- IF (R1-COD-AG-PRODUTORA IS NOT NUMERIC) OR (R1-COD-AG-PRODUTORA EQUAL ZEROS) */

            if ((!REG_R1_SUBGRUPO.R1_COD_AG_PRODUTORA.IsNumeric()) || (REG_R1_SUBGRUPO.R1_COD_AG_PRODUTORA == 00))
            {

                /*" -2702- MOVE 009 TO WS-COD-ERRO */
                _.Move(009, WS_COD_ERRO);

                /*" -2703- MOVE 021 TO WS-COD-CAMPO */
                _.Move(021, WS_COD_CAMPO);

                /*" -2704- MOVE R1-COD-AG-PRODUTORA TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_COD_AG_PRODUTORA, WS_DES_CONTEUDO);

                /*" -2705- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2706- ELSE */
            }
            else
            {


                /*" -2708- MOVE R1-COD-AG-PRODUTORA TO COD-AGENCIA-CEF */
                _.Move(REG_R1_SUBGRUPO.R1_COD_AG_PRODUTORA, COD_AGENCIA_CEF);

                /*" -2710- PERFORM R8003-00-VERIFICA-AGENCIACEF */

                R8003_00_VERIFICA_AGENCIACEF_SECTION();

                /*" -2712- IF (SQLCODE NOT EQUAL ZEROS) */

                if ((DB.SQLCODE != 00))
                {

                    /*" -2713- MOVE 014 TO WS-COD-ERRO */
                    _.Move(014, WS_COD_ERRO);

                    /*" -2714- MOVE 021 TO WS-COD-CAMPO */
                    _.Move(021, WS_COD_CAMPO);

                    /*" -2715- MOVE R1-COD-AG-PRODUTORA TO WS-DES-CONTEUDO */
                    _.Move(REG_R1_SUBGRUPO.R1_COD_AG_PRODUTORA, WS_DES_CONTEUDO);

                    /*" -2716- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -2717- END-IF */
                }


                /*" -2719- END-IF. */
            }


            /*" -2721- MOVE R1-COD-CLASSE-APOL TO W-COD-CLASSE-APOL */
            _.Move(REG_R1_SUBGRUPO.R1_COD_CLASSE_APOL, WREA88.W_COD_CLASSE_APOL);

            /*" -2723- IF (NOT COD-CLASSE-VALIDA) */

            if ((!WREA88.W_COD_CLASSE_APOL["COD_CLASSE_VALIDA"]))
            {

                /*" -2724- MOVE 012 TO WS-COD-ERRO */
                _.Move(012, WS_COD_ERRO);

                /*" -2725- MOVE 022 TO WS-COD-CAMPO */
                _.Move(022, WS_COD_CAMPO);

                /*" -2726- MOVE R1-COD-CLASSE-APOL TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_COD_CLASSE_APOL, WS_DES_CONTEUDO);

                /*" -2727- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2729- ELSE */
            }
            else
            {


                /*" -2731- IF (R1-COD-TP-PLANO NOT EQUAL '1' AND '2' AND '3' ) */

                if ((!REG_R1_SUBGRUPO.R1_COD_TP_PLANO.In("1", "2", "3")))
                {

                    /*" -2732- MOVE 012 TO WS-COD-ERRO */
                    _.Move(012, WS_COD_ERRO);

                    /*" -2733- MOVE 023 TO WS-COD-CAMPO */
                    _.Move(023, WS_COD_CAMPO);

                    /*" -2734- MOVE R1-COD-TP-PLANO TO WS-DES-CONTEUDO */
                    _.Move(REG_R1_SUBGRUPO.R1_COD_TP_PLANO, WS_DES_CONTEUDO);

                    /*" -2735- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -2737- END-IF. */
                }

            }


            /*" -2739- IF (R1-COD-TP-CORRECAO NOT EQUAL '1' ) */

            if ((REG_R1_SUBGRUPO.R1_COD_TP_CORRECAO != "1"))
            {

                /*" -2740- MOVE 012 TO WS-COD-ERRO */
                _.Move(012, WS_COD_ERRO);

                /*" -2741- MOVE 024 TO WS-COD-CAMPO */
                _.Move(024, WS_COD_CAMPO);

                /*" -2742- MOVE R1-COD-TP-CORRECAO TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_COD_TP_CORRECAO, WS_DES_CONTEUDO);

                /*" -2743- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2747- END-IF. */
            }


            /*" -2749- IF (R1-COD-TP-FATURA NOT EQUAL '1' AND '2' AND '3' ) */

            if ((!REG_R1_SUBGRUPO.R1_COD_TP_FATURA.In("1", "2", "3")))
            {

                /*" -2750- MOVE 012 TO WS-COD-ERRO */
                _.Move(012, WS_COD_ERRO);

                /*" -2751- MOVE 025 TO WS-COD-CAMPO */
                _.Move(025, WS_COD_CAMPO);

                /*" -2752- MOVE R1-COD-TP-FATURA TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_COD_TP_FATURA, WS_DES_CONTEUDO);

                /*" -2753- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2755- END-IF. */
            }


            /*" -2757- MOVE R1-COD-PERIO-FATURA TO W-COD-PERIO-FATURA */
            _.Move(REG_R1_SUBGRUPO.R1_COD_PERIO_FATURA, WREA88.W_COD_PERIO_FATURA);

            /*" -2759- IF (NOT COD-PERIO-FAT-VALIDO) */

            if ((!WREA88.W_COD_PERIO_FATURA["COD_PERIO_FAT_VALIDO"]))
            {

                /*" -2760- MOVE 012 TO WS-COD-ERRO */
                _.Move(012, WS_COD_ERRO);

                /*" -2761- MOVE 026 TO WS-COD-CAMPO */
                _.Move(026, WS_COD_CAMPO);

                /*" -2762- MOVE R1-COD-PERIO-FATURA TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_COD_PERIO_FATURA, WS_DES_CONTEUDO);

                /*" -2763- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2765- END-IF. */
            }


            /*" -2767- IF (R1-IND-FORMA-AVERB NOT EQUAL '1' AND '2' ) */

            if ((!REG_R1_SUBGRUPO.R1_IND_FORMA_AVERB.In("1", "2")))
            {

                /*" -2768- MOVE 012 TO WS-COD-ERRO */
                _.Move(012, WS_COD_ERRO);

                /*" -2769- MOVE 027 TO WS-COD-CAMPO */
                _.Move(027, WS_COD_CAMPO);

                /*" -2770- MOVE R1-IND-FORMA-AVERB TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_IND_FORMA_AVERB, WS_DES_CONTEUDO);

                /*" -2771- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2773- END-IF. */
            }


            /*" -2775- IF (R1-IND-FORMA-FATURA NOT EQUAL '1' AND '2' ) */

            if ((!REG_R1_SUBGRUPO.R1_IND_FORMA_FATURA.In("1", "2")))
            {

                /*" -2776- MOVE 012 TO WS-COD-ERRO */
                _.Move(012, WS_COD_ERRO);

                /*" -2777- MOVE 028 TO WS-COD-CAMPO */
                _.Move(028, WS_COD_CAMPO);

                /*" -2778- MOVE R1-IND-FORMA-FATURA TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_IND_FORMA_FATURA, WS_DES_CONTEUDO);

                /*" -2779- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2781- END-IF. */
            }


            /*" -2783- IF (R1-IND-COBRA-IOF NOT EQUAL 'N' AND 'S' ) */

            if ((!REG_R1_SUBGRUPO.R1_IND_COBRA_IOF.In("N", "S")))
            {

                /*" -2784- MOVE 012 TO WS-COD-ERRO */
                _.Move(012, WS_COD_ERRO);

                /*" -2785- MOVE 029 TO WS-COD-CAMPO */
                _.Move(029, WS_COD_CAMPO);

                /*" -2786- MOVE R1-IND-COBRA-IOF TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_IND_COBRA_IOF, WS_DES_CONTEUDO);

                /*" -2787- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2789- END-IF. */
            }


            /*" -2792- IF (R1-QTD-VIDA-CONTRAT IS NOT NUMERIC) OR (R1-QTD-VIDA-CONTRAT EQUAL ZEROS) */

            if ((!REG_R1_SUBGRUPO.R1_QTD_VIDA_CONTRAT.IsNumeric()) || (REG_R1_SUBGRUPO.R1_QTD_VIDA_CONTRAT == 00))
            {

                /*" -2793- MOVE 009 TO WS-COD-ERRO */
                _.Move(009, WS_COD_ERRO);

                /*" -2794- MOVE 030 TO WS-COD-CAMPO */
                _.Move(030, WS_COD_CAMPO);

                /*" -2795- MOVE R1-QTD-VIDA-CONTRAT TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_QTD_VIDA_CONTRAT, WS_DES_CONTEUDO);

                /*" -2796- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2798- END-IF. */
            }


            /*" -2800- IF (R1-VAL-PRM-INICIAL IS NOT NUMERIC) */

            if ((!REG_R1_SUBGRUPO.R1_VAL_PRM_INICIAL.IsNumeric()))
            {

                /*" -2801- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -2802- MOVE 031 TO WS-COD-CAMPO */
                _.Move(031, WS_COD_CAMPO);

                /*" -2803- MOVE R1-VAL-PRM-INICIAL TO WS-DES-CONTEU-N */
                _.Move(REG_R1_SUBGRUPO.R1_VAL_PRM_INICIAL, FILLER_23.WS_DES_CONTEU_N);

                /*" -2804- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2806- END-IF. */
            }


            /*" -2808- IF (R1-VAL-CAP-INICIAL IS NOT NUMERIC) */

            if ((!REG_R1_SUBGRUPO.R1_VAL_CAP_INICIAL.IsNumeric()))
            {

                /*" -2809- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -2810- MOVE 032 TO WS-COD-CAMPO */
                _.Move(032, WS_COD_CAMPO);

                /*" -2811- MOVE R1-VAL-CAP-INICIAL TO WS-DES-CONTEU-N */
                _.Move(REG_R1_SUBGRUPO.R1_VAL_CAP_INICIAL, FILLER_23.WS_DES_CONTEU_N);

                /*" -2812- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2814- END-IF. */
            }


            /*" -2816- IF (R1-VAL-PRMVG-INICIAL IS NOT NUMERIC) */

            if ((!REG_R1_SUBGRUPO.R1_VAL_PRMVG_INICIAL.IsNumeric()))
            {

                /*" -2817- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -2818- MOVE 033 TO WS-COD-CAMPO */
                _.Move(033, WS_COD_CAMPO);

                /*" -2819- MOVE R1-VAL-PRMVG-INICIAL TO WS-DES-CONTEU-N */
                _.Move(REG_R1_SUBGRUPO.R1_VAL_PRMVG_INICIAL, FILLER_23.WS_DES_CONTEU_N);

                /*" -2820- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2822- END-IF. */
            }


            /*" -2824- IF (R1-VAL-PRMAP-INICIAL IS NOT NUMERIC) */

            if ((!REG_R1_SUBGRUPO.R1_VAL_PRMAP_INICIAL.IsNumeric()))
            {

                /*" -2825- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -2826- MOVE 034 TO WS-COD-CAMPO */
                _.Move(034, WS_COD_CAMPO);

                /*" -2827- MOVE R1-VAL-PRMAP-INICIAL TO WS-DES-CONTEU-N */
                _.Move(REG_R1_SUBGRUPO.R1_VAL_PRMAP_INICIAL, FILLER_23.WS_DES_CONTEU_N);

                /*" -2828- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2830- END-IF. */
            }


            /*" -2833- IF (R1-COD-TP-COSSEG-CED IS NOT NUMERIC) OR (R1-COD-TP-COSSEG-CED NOT EQUAL 0 AND 1 AND 2 AND 3) */

            if ((!REG_R1_SUBGRUPO.R1_COD_TP_COSSEG_CED.IsNumeric()) || (!REG_R1_SUBGRUPO.R1_COD_TP_COSSEG_CED.In("0", "1", "2", "3")))
            {

                /*" -2834- MOVE 012 TO WS-COD-ERRO */
                _.Move(012, WS_COD_ERRO);

                /*" -2835- MOVE 035 TO WS-COD-CAMPO */
                _.Move(035, WS_COD_CAMPO);

                /*" -2836- MOVE R1-COD-TP-COSSEG-CED TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_COD_TP_COSSEG_CED, WS_DES_CONTEUDO);

                /*" -2837- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2839- END-IF. */
            }


            /*" -2844- IF (R1-COD-PRODUTO IS NOT NUMERIC) OR (R1-COD-PRODUTO NOT EQUAL 8203 AND JVPRD8203 AND 9311 AND JVPRD9311 AND 9354) */

            if ((!REG_R1_SUBGRUPO.R1_COD_PRODUTO.IsNumeric()) || (!REG_R1_SUBGRUPO.R1_COD_PRODUTO.In("8203", JVBKINCL.JV_PRODUTOS.JVPRD8203.ToString(), "9311", JVBKINCL.JV_PRODUTOS.JVPRD9311.ToString(), "9354")))
            {

                /*" -2845- MOVE 012 TO WS-COD-ERRO */
                _.Move(012, WS_COD_ERRO);

                /*" -2846- MOVE 036 TO WS-COD-CAMPO */
                _.Move(036, WS_COD_CAMPO);

                /*" -2847- MOVE R1-COD-PRODUTO TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_COD_PRODUTO, WS_DES_CONTEUDO);

                /*" -2848- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2852- END-IF. */
            }


            /*" -2856- IF (R1-COD-PRODUTO EQUAL JVPRD9311 OR JVPRD8205) AND (WS-JV1-DTA-PROPOSTA < LK-GEJVW002-JV-DTA-INI) */

            if ((REG_R1_SUBGRUPO.R1_COD_PRODUTO.In(JVBKINCL.JV_PRODUTOS.JVPRD9311.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8205.ToString())) && (WS_JV1_DTA_PROPOSTA < GEJVW002.LK_GEJVW002_JV_DTA_INI))
            {

                /*" -2857- MOVE 012 TO WS-COD-ERRO */
                _.Move(012, WS_COD_ERRO);

                /*" -2858- MOVE 036 TO WS-COD-CAMPO */
                _.Move(036, WS_COD_CAMPO);

                /*" -2859- MOVE R1-COD-PRODUTO TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_COD_PRODUTO, WS_DES_CONTEUDO);

                /*" -2860- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2862- END-IF. */
            }


            /*" -2864- IF (R1-IND-OPCAO-CONJUGE NOT EQUAL '1' AND '2' ) */

            if ((!REG_R1_SUBGRUPO.R1_IND_OPCAO_CONJUGE.In("1", "2")))
            {

                /*" -2865- MOVE 012 TO WS-COD-ERRO */
                _.Move(012, WS_COD_ERRO);

                /*" -2866- MOVE 037 TO WS-COD-CAMPO */
                _.Move(037, WS_COD_CAMPO);

                /*" -2867- MOVE R1-IND-OPCAO-CONJUGE TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_IND_OPCAO_CONJUGE, WS_DES_CONTEUDO);

                /*" -2868- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2870- END-IF. */
            }


            /*" -2872- IF (R1-PER-COBERVG-CONJ IS NOT NUMERIC) */

            if ((!REG_R1_SUBGRUPO.R1_PER_COBERVG_CONJ.IsNumeric()))
            {

                /*" -2873- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -2874- MOVE 038 TO WS-COD-CAMPO */
                _.Move(038, WS_COD_CAMPO);

                /*" -2875- MOVE R1-PER-COBERVG-CONJ TO WS-DES-CONTEU-N */
                _.Move(REG_R1_SUBGRUPO.R1_PER_COBERVG_CONJ, FILLER_23.WS_DES_CONTEU_N);

                /*" -2876- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2877- ELSE */
            }
            else
            {


                /*" -2878- IF (R1-IND-OPCAO-CONJUGE EQUAL '1' ) */

                if ((REG_R1_SUBGRUPO.R1_IND_OPCAO_CONJUGE == "1"))
                {

                    /*" -2879- IF (R1-IND-OP-COBERTUR EQUAL 1 OR 2) */

                    if ((REG_R1_SUBGRUPO.R1_IND_OP_COBERTUR.In("1", "2")))
                    {

                        /*" -2881- IF R1-PER-COBERVG-CONJ = 0 */

                        if (REG_R1_SUBGRUPO.R1_PER_COBERVG_CONJ == 0)
                        {

                            /*" -2882- MOVE 012 TO WS-COD-ERRO */
                            _.Move(012, WS_COD_ERRO);

                            /*" -2883- MOVE 038 TO WS-COD-CAMPO */
                            _.Move(038, WS_COD_CAMPO);

                            /*" -2884- MOVE R1-PER-COBERVG-CONJ TO WS-DES-CONTEU-N */
                            _.Move(REG_R1_SUBGRUPO.R1_PER_COBERVG_CONJ, FILLER_23.WS_DES_CONTEU_N);

                            /*" -2885- PERFORM R9979-00-MONTA-TAB-CRITICA */

                            R9979_00_MONTA_TAB_CRITICA_SECTION();

                            /*" -2886- END-IF */
                        }


                        /*" -2887- ELSE */
                    }
                    else
                    {


                        /*" -2889- IF (R1-PER-COBERVG-CONJ > ZEROS) */

                        if ((REG_R1_SUBGRUPO.R1_PER_COBERVG_CONJ > 00))
                        {

                            /*" -2890- MOVE 012 TO WS-COD-ERRO */
                            _.Move(012, WS_COD_ERRO);

                            /*" -2891- MOVE 038 TO WS-COD-CAMPO */
                            _.Move(038, WS_COD_CAMPO);

                            /*" -2892- MOVE R1-PER-COBERVG-CONJ TO WS-DES-CONTEU-N */
                            _.Move(REG_R1_SUBGRUPO.R1_PER_COBERVG_CONJ, FILLER_23.WS_DES_CONTEU_N);

                            /*" -2893- PERFORM R9979-00-MONTA-TAB-CRITICA */

                            R9979_00_MONTA_TAB_CRITICA_SECTION();

                            /*" -2894- END-IF */
                        }


                        /*" -2895- END-IF */
                    }


                    /*" -2896- ELSE */
                }
                else
                {


                    /*" -2898- IF (R1-PER-COBERVG-CONJ > ZEROS) */

                    if ((REG_R1_SUBGRUPO.R1_PER_COBERVG_CONJ > 00))
                    {

                        /*" -2899- MOVE 012 TO WS-COD-ERRO */
                        _.Move(012, WS_COD_ERRO);

                        /*" -2900- MOVE 038 TO WS-COD-CAMPO */
                        _.Move(038, WS_COD_CAMPO);

                        /*" -2901- MOVE R1-PER-COBERVG-CONJ TO WS-DES-CONTEU-N */
                        _.Move(REG_R1_SUBGRUPO.R1_PER_COBERVG_CONJ, FILLER_23.WS_DES_CONTEU_N);

                        /*" -2902- PERFORM R9979-00-MONTA-TAB-CRITICA */

                        R9979_00_MONTA_TAB_CRITICA_SECTION();

                        /*" -2903- END-IF */
                    }


                    /*" -2904- END-IF */
                }


                /*" -2906- END-IF. */
            }


            /*" -2908- IF (R1-PER-COBERAP-CONJ IS NOT NUMERIC) */

            if ((!REG_R1_SUBGRUPO.R1_PER_COBERAP_CONJ.IsNumeric()))
            {

                /*" -2909- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -2910- MOVE 039 TO WS-COD-CAMPO */
                _.Move(039, WS_COD_CAMPO);

                /*" -2911- MOVE R1-PER-COBERAP-CONJ TO WS-DES-CONTEU-N */
                _.Move(REG_R1_SUBGRUPO.R1_PER_COBERAP_CONJ, FILLER_23.WS_DES_CONTEU_N);

                /*" -2912- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2913- ELSE */
            }
            else
            {


                /*" -2914- IF (R1-IND-OPCAO-CONJUGE EQUAL '1' ) */

                if ((REG_R1_SUBGRUPO.R1_IND_OPCAO_CONJUGE == "1"))
                {

                    /*" -2915- IF (R1-IND-OP-COBERTUR EQUAL 3) */

                    if ((REG_R1_SUBGRUPO.R1_IND_OP_COBERTUR == 3))
                    {

                        /*" -2917- IF R1-PER-COBERAP-CONJ = 0 */

                        if (REG_R1_SUBGRUPO.R1_PER_COBERAP_CONJ == 0)
                        {

                            /*" -2918- MOVE 012 TO WS-COD-ERRO */
                            _.Move(012, WS_COD_ERRO);

                            /*" -2919- MOVE 039 TO WS-COD-CAMPO */
                            _.Move(039, WS_COD_CAMPO);

                            /*" -2920- MOVE R1-PER-COBERAP-CONJ TO WS-DES-CONTEU-N */
                            _.Move(REG_R1_SUBGRUPO.R1_PER_COBERAP_CONJ, FILLER_23.WS_DES_CONTEU_N);

                            /*" -2921- PERFORM R9979-00-MONTA-TAB-CRITICA */

                            R9979_00_MONTA_TAB_CRITICA_SECTION();

                            /*" -2922- END-IF */
                        }


                        /*" -2923- ELSE */
                    }
                    else
                    {


                        /*" -2924- IF (R1-PER-COBERAP-CONJ > ZEROS) */

                        if ((REG_R1_SUBGRUPO.R1_PER_COBERAP_CONJ > 00))
                        {

                            /*" -2925- IF (R1-IND-OP-COBERTUR EQUAL 2) */

                            if ((REG_R1_SUBGRUPO.R1_IND_OP_COBERTUR == 2))
                            {

                                /*" -2926- CONTINUE */

                                /*" -2928- ELSE */
                            }
                            else
                            {


                                /*" -2929- MOVE 012 TO WS-COD-ERRO */
                                _.Move(012, WS_COD_ERRO);

                                /*" -2930- MOVE 039 TO WS-COD-CAMPO */
                                _.Move(039, WS_COD_CAMPO);

                                /*" -2931- MOVE R1-PER-COBERAP-CONJ TO WS-DES-CONTEU-N */
                                _.Move(REG_R1_SUBGRUPO.R1_PER_COBERAP_CONJ, FILLER_23.WS_DES_CONTEU_N);

                                /*" -2932- PERFORM R9979-00-MONTA-TAB-CRITICA */

                                R9979_00_MONTA_TAB_CRITICA_SECTION();

                                /*" -2933- END-IF */
                            }


                            /*" -2934- END-IF */
                        }


                        /*" -2935- END-IF */
                    }


                    /*" -2936- ELSE */
                }
                else
                {


                    /*" -2938- IF (R1-PER-COBERAP-CONJ > ZEROS) */

                    if ((REG_R1_SUBGRUPO.R1_PER_COBERAP_CONJ > 00))
                    {

                        /*" -2939- MOVE 012 TO WS-COD-ERRO */
                        _.Move(012, WS_COD_ERRO);

                        /*" -2940- MOVE 039 TO WS-COD-CAMPO */
                        _.Move(039, WS_COD_CAMPO);

                        /*" -2941- MOVE R1-PER-COBERAP-CONJ TO WS-DES-CONTEU-N */
                        _.Move(REG_R1_SUBGRUPO.R1_PER_COBERAP_CONJ, FILLER_23.WS_DES_CONTEU_N);

                        /*" -2942- PERFORM R9979-00-MONTA-TAB-CRITICA */

                        R9979_00_MONTA_TAB_CRITICA_SECTION();

                        /*" -2943- END-IF */
                    }


                    /*" -2944- END-IF */
                }


                /*" -2946- END-IF. */
            }


            /*" -2948- IF (R1-IND-PLANO-ASSOC NOT EQUAL 'N' AND 'S' ) */

            if ((!REG_R1_SUBGRUPO.R1_IND_PLANO_ASSOC.In("N", "S")))
            {

                /*" -2949- MOVE 012 TO WS-COD-ERRO */
                _.Move(012, WS_COD_ERRO);

                /*" -2950- MOVE 040 TO WS-COD-CAMPO */
                _.Move(040, WS_COD_CAMPO);

                /*" -2951- MOVE R1-IND-PLANO-ASSOC TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_IND_PLANO_ASSOC, WS_DES_CONTEUDO);

                /*" -2952- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2954- END-IF. */
            }


            /*" -2956- IF (R1-IND-COBER-ADIC NOT EQUAL 'N' AND 'S' ) */

            if ((!REG_R1_SUBGRUPO.R1_IND_COBER_ADIC.In("N", "S")))
            {

                /*" -2957- MOVE 012 TO WS-COD-ERRO */
                _.Move(012, WS_COD_ERRO);

                /*" -2958- MOVE 041 TO WS-COD-CAMPO */
                _.Move(041, WS_COD_CAMPO);

                /*" -2959- MOVE R1-IND-COBER-ADIC TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_IND_COBER_ADIC, WS_DES_CONTEUDO);

                /*" -2960- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2962- END-IF. */
            }


            /*" -2964- IF (R1-IND-VALID-MATRC NOT EQUAL 'N' AND 'S' ) */

            if ((!REG_R1_SUBGRUPO.R1_IND_VALID_MATRC.In("N", "S")))
            {

                /*" -2965- MOVE 012 TO WS-COD-ERRO */
                _.Move(012, WS_COD_ERRO);

                /*" -2966- MOVE 042 TO WS-COD-CAMPO */
                _.Move(042, WS_COD_CAMPO);

                /*" -2967- MOVE R1-IND-VALID-MATRC TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_IND_VALID_MATRC, WS_DES_CONTEUDO);

                /*" -2968- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2970- END-IF. */
            }


            /*" -2974- IF (R1-NUM-DIA-DEBITO IS NOT NUMERIC) OR (R1-NUM-DIA-DEBITO < 01) OR (R1-NUM-DIA-DEBITO > 31) */

            if ((!REG_R1_SUBGRUPO.R1_NUM_DIA_DEBITO.IsNumeric()) || (REG_R1_SUBGRUPO.R1_NUM_DIA_DEBITO < 01) || (REG_R1_SUBGRUPO.R1_NUM_DIA_DEBITO > 31))
            {

                /*" -2975- MOVE 012 TO WS-COD-ERRO */
                _.Move(012, WS_COD_ERRO);

                /*" -2976- MOVE 043 TO WS-COD-CAMPO */
                _.Move(043, WS_COD_CAMPO);

                /*" -2977- MOVE R1-NUM-DIA-DEBITO TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_NUM_DIA_DEBITO, WS_DES_CONTEUDO);

                /*" -2978- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2980- END-IF. */
            }


            /*" -2983- IF (R1-IND-OPCAO-PAGMTO IS NOT NUMERIC) OR (R1-IND-OPCAO-PAGMTO NOT EQUAL 1 AND 2 AND 3 AND 4 AND 5) */

            if ((!REG_R1_SUBGRUPO.R1_IND_OPCAO_PAGMTO.IsNumeric()) || (!REG_R1_SUBGRUPO.R1_IND_OPCAO_PAGMTO.In("1", "2", "3", "4", "5")))
            {

                /*" -2984- MOVE 012 TO WS-COD-ERRO */
                _.Move(012, WS_COD_ERRO);

                /*" -2985- MOVE 044 TO WS-COD-CAMPO */
                _.Move(044, WS_COD_CAMPO);

                /*" -2986- MOVE R1-IND-OPCAO-PAGMTO TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_IND_OPCAO_PAGMTO, WS_DES_CONTEUDO);

                /*" -2987- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -2989- END-IF. */
            }


            /*" -2991- IF (R1-NUM-TITULO-RCAP IS NOT NUMERIC) */

            if ((!REG_R1_SUBGRUPO.R1_NUM_TITULO_RCAP.IsNumeric()))
            {

                /*" -2992- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -2993- MOVE 045 TO WS-COD-CAMPO */
                _.Move(045, WS_COD_CAMPO);

                /*" -2994- MOVE R1-NUM-TITULO-RCAP TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_NUM_TITULO_RCAP, WS_DES_CONTEUDO);

                /*" -2995- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3005- END-IF. */
            }


            /*" -3006- IF (R1-DTA-VENC-TITULO NOT EQUAL SPACES OR LOW-VALUES) */

            if ((REG_R1_SUBGRUPO.R1_DTA_VENC_TITULO != ""))
            {

                /*" -3007- MOVE R1-DTA-VENC-TITULO TO W-DATA-TRABALHO */
                _.Move(REG_R1_SUBGRUPO.R1_DTA_VENC_TITULO, WAREA_AUXILIAR.W_DATA_TRABALHO);

                /*" -3009- PERFORM R8001-00-VERIFICA-DATA-VALIDA */

                R8001_00_VERIFICA_DATA_VALIDA_SECTION();

                /*" -3011- IF (SQLCODE NOT EQUAL ZEROS) */

                if ((DB.SQLCODE != 00))
                {

                    /*" -3012- MOVE 019 TO WS-COD-ERRO */
                    _.Move(019, WS_COD_ERRO);

                    /*" -3013- MOVE 046 TO WS-COD-CAMPO */
                    _.Move(046, WS_COD_CAMPO);

                    /*" -3014- MOVE R1-DTA-VENC-TITULO TO WS-DES-CONTEUDO */
                    _.Move(REG_R1_SUBGRUPO.R1_DTA_VENC_TITULO, WS_DES_CONTEUDO);

                    /*" -3015- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3016- END-IF */
                }


                /*" -3018- END-IF. */
            }


            /*" -3020- IF (R1-VAL-TITULO-RCAP IS NOT NUMERIC) */

            if ((!REG_R1_SUBGRUPO.R1_VAL_TITULO_RCAP.IsNumeric()))
            {

                /*" -3021- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -3022- MOVE 047 TO WS-COD-CAMPO */
                _.Move(047, WS_COD_CAMPO);

                /*" -3023- MOVE R1-VAL-TITULO-RCAP TO WS-DES-CONTEU-N */
                _.Move(REG_R1_SUBGRUPO.R1_VAL_TITULO_RCAP, FILLER_23.WS_DES_CONTEU_N);

                /*" -3024- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3026- END-IF. */
            }


            /*" -3028- IF (R1-NUM-BCO-COBR IS NOT NUMERIC) */

            if ((!REG_R1_SUBGRUPO.R1_NUM_BCO_COBR.IsNumeric()))
            {

                /*" -3029- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -3030- MOVE 048 TO WS-COD-CAMPO */
                _.Move(048, WS_COD_CAMPO);

                /*" -3031- MOVE R1-NUM-BCO-COBR TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_NUM_BCO_COBR, WS_DES_CONTEUDO);

                /*" -3032- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3034- END-IF */
            }


            /*" -3036- IF (R1-NUM-CONTA-COBR IS NOT NUMERIC) */

            if ((!REG_R1_SUBGRUPO.R1_NUM_CONTA_COBR.IsNumeric()))
            {

                /*" -3037- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -3038- MOVE 052 TO WS-COD-CAMPO */
                _.Move(052, WS_COD_CAMPO);

                /*" -3039- MOVE R1-NUM-CONTA-COBR TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_NUM_CONTA_COBR, WS_DES_CONTEUDO);

                /*" -3040- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3042- END-IF */
            }


            /*" -3044- IF (R1-NUM-OPER-CONTA-COBR IS NOT NUMERIC) */

            if ((!REG_R1_SUBGRUPO.R1_NUM_OPER_CONTA_COBR.IsNumeric()))
            {

                /*" -3045- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -3046- MOVE 051 TO WS-COD-CAMPO */
                _.Move(051, WS_COD_CAMPO);

                /*" -3047- MOVE R1-NUM-OPER-CONTA-COBR TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_NUM_OPER_CONTA_COBR, WS_DES_CONTEUDO);

                /*" -3048- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3050- END-IF */
            }


            /*" -3052- IF (R1-NUM-AGE-COBR IS NOT NUMERIC) */

            if ((!REG_R1_SUBGRUPO.R1_NUM_AGE_COBR.IsNumeric()))
            {

                /*" -3053- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -3054- MOVE 049 TO WS-COD-CAMPO */
                _.Move(049, WS_COD_CAMPO);

                /*" -3055- MOVE R1-NUM-AGE-COBR TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_NUM_AGE_COBR, WS_DES_CONTEUDO);

                /*" -3056- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3058- END-IF */
            }


            /*" -3059- IF (R1-NUM-AGE-COBR EQUAL ZEROS) */

            if ((REG_R1_SUBGRUPO.R1_NUM_AGE_COBR == 00))
            {

                /*" -3060- MOVE 0005 TO R1-NUM-AGE-COBR */
                _.Move(0005, REG_R1_SUBGRUPO.R1_NUM_AGE_COBR);

                /*" -3062- END-IF */
            }


            /*" -3067- IF (R1-NUM-BCO-COBR IS NUMERIC) AND (R1-NUM-AGE-COBR IS NUMERIC) AND (R1-NUM-CONTA-COBR IS NUMERIC) AND (R1-NUM-OPER-CONTA-COBR IS NUMERIC) */

            if ((REG_R1_SUBGRUPO.R1_NUM_BCO_COBR.IsNumeric() && REG_R1_SUBGRUPO.R1_NUM_AGE_COBR.IsNumeric() && REG_R1_SUBGRUPO.R1_NUM_CONTA_COBR.IsNumeric() && REG_R1_SUBGRUPO.R1_NUM_OPER_CONTA_COBR.IsNumeric()))
            {

                /*" -3069- IF (R1-NUM-AGE-COBR > ZEROS) AND (R1-NUM-CONTA-COBR > ZEROS) */

                if ((REG_R1_SUBGRUPO.R1_NUM_AGE_COBR > 00) && (REG_R1_SUBGRUPO.R1_NUM_CONTA_COBR > 00))
                {

                    /*" -3070- MOVE R1-NUM-AGE-COBR TO COD-AGENCIA-CEF */
                    _.Move(REG_R1_SUBGRUPO.R1_NUM_AGE_COBR, COD_AGENCIA_CEF);

                    /*" -3072- PERFORM R8003-00-VERIFICA-AGENCIACEF */

                    R8003_00_VERIFICA_AGENCIACEF_SECTION();

                    /*" -3074- IF (SQLCODE NOT EQUAL ZEROS) */

                    if ((DB.SQLCODE != 00))
                    {

                        /*" -3075- MOVE 014 TO WS-COD-ERRO */
                        _.Move(014, WS_COD_ERRO);

                        /*" -3076- MOVE 049 TO WS-COD-CAMPO */
                        _.Move(049, WS_COD_CAMPO);

                        /*" -3077- MOVE R1-NUM-AGE-COBR TO WS-DES-CONTEUDO */
                        _.Move(REG_R1_SUBGRUPO.R1_NUM_AGE_COBR, WS_DES_CONTEUDO);

                        /*" -3078- PERFORM R9979-00-MONTA-TAB-CRITICA */

                        R9979_00_MONTA_TAB_CRITICA_SECTION();

                        /*" -3080- END-IF */
                    }


                    /*" -3081- MOVE R1-NUM-AGE-COBR TO WS-AGENCIA */
                    _.Move(REG_R1_SUBGRUPO.R1_NUM_AGE_COBR, FILLER_21.WS_AGENCIA);

                    /*" -3082- MOVE R1-NUM-OPER-CONTA-COBR TO WS-OPERACAO */
                    _.Move(REG_R1_SUBGRUPO.R1_NUM_OPER_CONTA_COBR, FILLER_21.WS_OPERACAO);

                    /*" -3084- MOVE R1-NUM-CONTA-COBR TO WS-NUMCONTA */
                    _.Move(REG_R1_SUBGRUPO.R1_NUM_CONTA_COBR, FILLER_21.WS_NUMCONTA);

                    /*" -3086- PERFORM R8004-00-VERIFICA-DV-CONTA */

                    R8004_00_VERIFICA_DV_CONTA_SECTION();

                    /*" -3088- IF (R1-NUM-DV-CONTA-COBR NOT EQUAL WS-DIGCONTA) */

                    if ((REG_R1_SUBGRUPO.R1_NUM_DV_CONTA_COBR != WS_DIGCONTA))
                    {

                        /*" -3089- MOVE 015 TO WS-COD-ERRO */
                        _.Move(015, WS_COD_ERRO);

                        /*" -3090- MOVE 053 TO WS-COD-CAMPO */
                        _.Move(053, WS_COD_CAMPO);

                        /*" -3091- MOVE R1-NUM-DV-CONTA-COBR TO WS-DES-CONTEUDO */
                        _.Move(REG_R1_SUBGRUPO.R1_NUM_DV_CONTA_COBR, WS_DES_CONTEUDO);

                        /*" -3092- PERFORM R9979-00-MONTA-TAB-CRITICA */

                        R9979_00_MONTA_TAB_CRITICA_SECTION();

                        /*" -3094- END-IF */
                    }


                    /*" -3095- MOVE R1-NUM-BCO-COBR TO AGENCIAS-COD-BANCO */
                    _.Move(REG_R1_SUBGRUPO.R1_NUM_BCO_COBR, AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_BANCO);

                    /*" -3096- MOVE R1-NUM-AGE-COBR TO AGENCIAS-COD-AGENCIA */
                    _.Move(REG_R1_SUBGRUPO.R1_NUM_AGE_COBR, AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_AGENCIA);

                    /*" -3098- MOVE R1-NUM-DV-AGE-COBR TO AGENCIAS-DAC-AGENCIA */
                    _.Move(REG_R1_SUBGRUPO.R1_NUM_DV_AGE_COBR, AGENCIAS.DCLAGENCIAS.AGENCIAS_DAC_AGENCIA);

                    /*" -3100- PERFORM R8011-00-VERIFICA-BANCO-AG-DAC */

                    R8011_00_VERIFICA_BANCO_AG_DAC_SECTION();

                    /*" -3102- IF (SQLCODE EQUAL +100) */

                    if ((DB.SQLCODE == +100))
                    {

                        /*" -3103- MOVE 039 TO WS-COD-ERRO */
                        _.Move(039, WS_COD_ERRO);

                        /*" -3104- MOVE 053 TO WS-COD-CAMPO */
                        _.Move(053, WS_COD_CAMPO);

                        /*" -3105- MOVE R1-NUM-DV-CONTA-COBR TO WS-DES-CONTEUDO */
                        _.Move(REG_R1_SUBGRUPO.R1_NUM_DV_CONTA_COBR, WS_DES_CONTEUDO);

                        /*" -3109- STRING 'R1-NUM-BCO-COBR=' R1-NUM-BCO-COBR ' ' 'R1-NUM-AGE-COBR=' R1-NUM-AGE-COBR ' ' 'R1-NUM-DV-AGE-COBR=' R1-NUM-DV-AGE-COBR DELIMITED BY SIZE INTO WS-DES-CONTEUDO */
                        #region STRING
                        var spl1 = "R1-NUM-BCO-COBR=" + REG_R1_SUBGRUPO.R1_NUM_BCO_COBR.GetMoveValues();
                        spl1 += " ";
                        spl1 += "R1-NUM-AGE-COBR=";
                        var spl2 = REG_R1_SUBGRUPO.R1_NUM_AGE_COBR.GetMoveValues();
                        spl2 += " ";
                        spl2 += "R1-NUM-DV-AGE-COBR=";
                        var spl3 = REG_R1_SUBGRUPO.R1_NUM_DV_AGE_COBR.GetMoveValues();
                        var results4 = spl1 + spl2 + spl3;
                        _.Move(results4, WS_DES_CONTEUDO);
                        #endregion

                        /*" -3110- PERFORM R9979-00-MONTA-TAB-CRITICA */

                        R9979_00_MONTA_TAB_CRITICA_SECTION();

                        /*" -3111- END-IF */
                    }


                    /*" -3112- END-IF */
                }


                /*" -3114- END-IF. */
            }


            /*" -3116- IF (R1-NUM-CGC-CNPJ IS NOT NUMERIC) */

            if ((!REG_R1_SUBGRUPO.R1_NUM_CGC_CNPJ.IsNumeric()))
            {

                /*" -3117- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -3118- MOVE 012 TO WS-COD-CAMPO */
                _.Move(012, WS_COD_CAMPO);

                /*" -3119- MOVE R1-NUM-CGC-CNPJ TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_NUM_CGC_CNPJ, WS_DES_CONTEUDO);

                /*" -3120- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3121- ELSE */
            }
            else
            {


                /*" -3122- INITIALIZE LPARM-CNPJ */
                _.Initialize(
                    LPARM_CNPJ
                );

                /*" -3123- MOVE R1-NUM-CGC-CNPJ TO LPARM-ENT-CNPJ */
                _.Move(REG_R1_SUBGRUPO.R1_NUM_CGC_CNPJ, LPARM_CNPJ.LPARM_ENT_CNPJ);

                /*" -3125- PERFORM R8005-00-VALIDA-CNPJ */

                R8005_00_VALIDA_CNPJ_SECTION();

                /*" -3127- IF (LPARM-SAI-CNPJ NOT EQUAL ZEROS) */

                if ((LPARM_CNPJ.LPARM_SAI_CNPJ != 00))
                {

                    /*" -3128- MOVE 009 TO WS-COD-ERRO */
                    _.Move(009, WS_COD_ERRO);

                    /*" -3129- MOVE 012 TO WS-COD-CAMPO */
                    _.Move(012, WS_COD_CAMPO);

                    /*" -3130- MOVE R1-NUM-CGC-CNPJ TO WS-DES-CONTEUDO */
                    _.Move(REG_R1_SUBGRUPO.R1_NUM_CGC_CNPJ, WS_DES_CONTEUDO);

                    /*" -3131- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3133- END-IF */
                }


                /*" -3134- IF R1-NUM-APOLICE EQUAL ZEROS */

                if (REG_R1_SUBGRUPO.R1_NUM_APOLICE == 00)
                {

                    /*" -3135- MOVE R1-NUM-CGC-CNPJ TO CLIENTES-CGCCPF */
                    _.Move(REG_R1_SUBGRUPO.R1_NUM_CGC_CNPJ, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);

                    /*" -3137- PERFORM R8006-00-PESQUISA-APOL-ATIVA */

                    R8006_00_PESQUISA_APOL_ATIVA_SECTION();

                    /*" -3139- IF (APOLICES-NUM-APOLICE NOT EQUAL ZEROS) */

                    if ((APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE != 00))
                    {

                        /*" -3140- MOVE WS-COD-ERRO TO WS-COD-ERRO-ANT */
                        _.Move(WS_COD_ERRO, WS_COD_ERRO_ANT);

                        /*" -3141- MOVE 038 TO WS-COD-ERRO */
                        _.Move(038, WS_COD_ERRO);

                        /*" -3142- MOVE 012 TO WS-COD-CAMPO */
                        _.Move(012, WS_COD_CAMPO);

                        /*" -3143- MOVE APOLICES-NUM-APOLICE TO WS-DES-CONTEUDO */
                        _.Move(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE, WS_DES_CONTEUDO);

                        /*" -3144- MOVE 'ALERTA' TO WS-TP-MENSAGEM */
                        _.Move("ALERTA", WS_TP_MENSAGEM);

                        /*" -3145- PERFORM R9979-00-MONTA-TAB-CRITICA */

                        R9979_00_MONTA_TAB_CRITICA_SECTION();

                        /*" -3146- MOVE WS-COD-ERRO-ANT TO WS-COD-ERRO */
                        _.Move(WS_COD_ERRO_ANT, WS_COD_ERRO);

                        /*" -3147- END-IF */
                    }


                    /*" -3148- ELSE */
                }
                else
                {


                    /*" -3149- MOVE R1-NUM-APOLICE TO WHOST-NUM-APOLICE */
                    _.Move(REG_R1_SUBGRUPO.R1_NUM_APOLICE, WHOST_NUM_APOLICE);

                    /*" -3150- MOVE R1-NUM-SUBGRUPO TO WHOST-COD-SUBGRUPO */
                    _.Move(REG_R1_SUBGRUPO.R1_NUM_SUBGRUPO, WHOST_COD_SUBGRUPO);

                    /*" -3152- PERFORM R8006-01-PESQUISA-APOL-ATIVA */

                    R8006_01_PESQUISA_APOL_ATIVA_SECTION();

                    /*" -3154- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -3155- MOVE WS-COD-ERRO TO WS-COD-ERRO-ANT */
                        _.Move(WS_COD_ERRO, WS_COD_ERRO_ANT);

                        /*" -3156- MOVE 100 TO WS-COD-ERRO */
                        _.Move(100, WS_COD_ERRO);

                        /*" -3157- MOVE 012 TO WS-COD-CAMPO */
                        _.Move(012, WS_COD_CAMPO);

                        /*" -3158- MOVE WHOST-NUM-APOLICE TO WS-NUM-APOLICE */
                        _.Move(WHOST_NUM_APOLICE, WS_NUM_APOLICE);

                        /*" -3159- MOVE WS-NUM-APOLICE TO WS-DES-CONTEUDO */
                        _.Move(WS_NUM_APOLICE, WS_DES_CONTEUDO);

                        /*" -3160- MOVE 'ERRO' TO WS-TP-MENSAGEM */
                        _.Move("ERRO", WS_TP_MENSAGEM);

                        /*" -3161- PERFORM R9979-00-MONTA-TAB-CRITICA */

                        R9979_00_MONTA_TAB_CRITICA_SECTION();

                        /*" -3162- MOVE WS-COD-ERRO-ANT TO WS-COD-ERRO */
                        _.Move(WS_COD_ERRO_ANT, WS_COD_ERRO);

                        /*" -3163- END-IF */
                    }


                    /*" -3165- END-IF. */
                }

            }


            /*" -3166- PERFORM DB040-ACESSA-CNAE-ATIVIDADE */

            DB040_ACESSA_CNAE_ATIVIDADE_SECTION();

            /*" -3168- IF SQLCODE = +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -3169- MOVE 014 TO WS-COD-ERRO */
                _.Move(014, WS_COD_ERRO);

                /*" -3170- MOVE 160 TO WS-COD-CAMPO */
                _.Move(160, WS_COD_CAMPO);

                /*" -3171- MOVE R1-COD-CNAE-ATIVIDADE TO WS-DES-CONTEUDO */
                _.Move(REG_R1_SUBGRUPO.R1_COD_CNAE_ATIVIDADE, WS_DES_CONTEUDO);

                /*" -3172- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3174- END-IF */
            }


            /*" -3175- IF (WS-COD-ERRO EQUAL ZEROS) */

            if ((WS_COD_ERRO == 00))
            {

                /*" -3176- ADD 1 TO W-IND-MOV */
                WAREA_AUXILIAR.W_IND_MOV.Value = WAREA_AUXILIAR.W_IND_MOV + 1;

                /*" -3177- MOVE REG-R1-SUBGRUPO TO W-TB-MOV-PORTAL(W-IND-MOV) */
                _.Move(REG_R1_SUBGRUPO, WAREA_AUXILIAR.W_TAB_MOV_PORTAL.W_TAB_MOV_PORTAL_0[WAREA_AUXILIAR.W_IND_MOV].W_TB_MOV_PORTAL);

                /*" -3178- MOVE 'S' TO WS-FLAG-TEM-TP1 */
                _.Move("S", WS_FLAG_TEM_TP1);

                /*" -3179- ELSE */
            }
            else
            {


                /*" -3180- MOVE 2 TO W-CRITICA-PROPOSTA */
                _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                /*" -3180- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_SAIDA*/

        [StopWatch]
        /*" R0315-00-MOVTO-ENDERECO-SECTION */
        private void R0315_00_MOVTO_ENDERECO_SECTION()
        {
            /*" -3191- MOVE 'R0315-00-MOVTO-ENDERECO ' TO PARAGRAFO. */
            _.Move("R0315-00-MOVTO-ENDERECO ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3192- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3194- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3195- INITIALIZE REG-R2-ENDERECO */
            _.Initialize(
                REG_R2_ENDERECO
            );

            /*" -3197- MOVE REG-PORTAL TO REG-R2-ENDERECO */
            _.Move(MOV_PORTAL?.Value, REG_R2_ENDERECO);

            /*" -3198- MOVE R2-NUM-PROPOSTA TO WS-NUM-PROPOSTA */
            _.Move(REG_R2_ENDERECO.R2_NUM_PROPOSTA, WS_NUM_PROPOSTA);

            /*" -3199- MOVE R2-NUM-SUBGRUPO TO WS-COD-SUBGRUPO */
            _.Move(REG_R2_ENDERECO.R2_NUM_SUBGRUPO, WS_COD_SUBGRUPO);

            /*" -3200- MOVE ZEROS TO WS-COD-ERRO */
            _.Move(0, WS_COD_ERRO);

            /*" -3201- MOVE 'ERRO' TO WS-TP-MENSAGEM */
            _.Move("ERRO", WS_TP_MENSAGEM);

            /*" -3202- INITIALIZE WS-DES-CONTEUDO */
            _.Initialize(
                WS_DES_CONTEUDO
            );

            /*" -3204- MOVE R2-NUM-SEQ-REG-TP02 TO WS-NUM-SEQ-ARQ */
            _.Move(REG_R2_ENDERECO.R2_NUM_SEQ_REG_TP02, WS_NUM_SEQ_ARQ);

            /*" -3207- IF (R2-NUM-PROPOSTA IS NOT NUMERIC) OR (R2-NUM-PROPOSTA EQUAL ZEROS) */

            if ((!REG_R2_ENDERECO.R2_NUM_PROPOSTA.IsNumeric()) || (REG_R2_ENDERECO.R2_NUM_PROPOSTA == 00))
            {

                /*" -3208- MOVE 009 TO WS-COD-ERRO */
                _.Move(009, WS_COD_ERRO);

                /*" -3209- MOVE 055 TO WS-COD-CAMPO */
                _.Move(055, WS_COD_CAMPO);

                /*" -3210- MOVE R2-NUM-PROPOSTA TO WS-DES-CONTEUDO */
                _.Move(REG_R2_ENDERECO.R2_NUM_PROPOSTA, WS_DES_CONTEUDO);

                /*" -3211- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3213- END-IF. */
            }


            /*" -3215- IF (R2-NUM-SUBGRUPO IS NOT NUMERIC) */

            if ((!REG_R2_ENDERECO.R2_NUM_SUBGRUPO.IsNumeric()))
            {

                /*" -3216- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -3217- MOVE 056 TO WS-COD-CAMPO */
                _.Move(056, WS_COD_CAMPO);

                /*" -3218- MOVE R2-NUM-SUBGRUPO TO WS-DES-CONTEUDO */
                _.Move(REG_R2_ENDERECO.R2_NUM_SUBGRUPO, WS_DES_CONTEUDO);

                /*" -3219- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3221- END-IF. */
            }


            /*" -3223- IF (R2-NUM-SUBGRUPO EQUAL ZEROS) */

            if ((REG_R2_ENDERECO.R2_NUM_SUBGRUPO == 00))
            {

                /*" -3224- MOVE 009 TO WS-COD-ERRO */
                _.Move(009, WS_COD_ERRO);

                /*" -3225- MOVE 056 TO WS-COD-CAMPO */
                _.Move(056, WS_COD_CAMPO);

                /*" -3226- MOVE R2-NUM-SUBGRUPO TO WS-DES-CONTEUDO */
                _.Move(REG_R2_ENDERECO.R2_NUM_SUBGRUPO, WS_DES_CONTEUDO);

                /*" -3227- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3229- END-IF. */
            }


            /*" -3231- IF (R2-NUM-SEQ-REG-TP02 IS NOT NUMERIC) */

            if ((!REG_R2_ENDERECO.R2_NUM_SEQ_REG_TP02.IsNumeric()))
            {

                /*" -3232- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -3233- MOVE 057 TO WS-COD-CAMPO */
                _.Move(057, WS_COD_CAMPO);

                /*" -3234- MOVE R2-NUM-SEQ-REG-TP02 TO WS-DES-CONTEUDO */
                _.Move(REG_R2_ENDERECO.R2_NUM_SEQ_REG_TP02, WS_DES_CONTEUDO);

                /*" -3235- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3237- END-IF. */
            }


            /*" -3239- IF (R2-NUM-TIPO-END IS NOT NUMERIC) */

            if ((!REG_R2_ENDERECO.R2_NUM_TIPO_END.IsNumeric()))
            {

                /*" -3240- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -3241- MOVE 058 TO WS-COD-CAMPO */
                _.Move(058, WS_COD_CAMPO);

                /*" -3242- MOVE R2-NUM-TIPO-END TO WS-DES-CONTEUDO */
                _.Move(REG_R2_ENDERECO.R2_NUM_TIPO_END, WS_DES_CONTEUDO);

                /*" -3243- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3245- END-IF. */
            }


            /*" -3247- IF (R2-NOM-ENDERECO EQUAL SPACES OR LOW-VALUES) */

            if ((REG_R2_ENDERECO.R2_NOM_ENDERECO.IsLowValues()))
            {

                /*" -3248- MOVE 013 TO WS-COD-ERRO */
                _.Move(013, WS_COD_ERRO);

                /*" -3249- MOVE 059 TO WS-COD-CAMPO */
                _.Move(059, WS_COD_CAMPO);

                /*" -3250- MOVE R2-NOM-ENDERECO TO WS-DES-CONTEUDO */
                _.Move(REG_R2_ENDERECO.R2_NOM_ENDERECO, WS_DES_CONTEUDO);

                /*" -3251- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3252- ELSE */
            }
            else
            {


                /*" -3253- MOVE 1 TO WS-POSICAO */
                _.Move(1, WS_POSICAO);

                /*" -3255- MOVE ZEROS TO WS-CONTA-BRC */
                _.Move(0, WS_CONTA_BRC);

                /*" -3256- PERFORM UNTIL WS-POSICAO > 50 */

                while (!(WS_POSICAO > 50))
                {

                    /*" -3257- IF (R2-NOM-ENDERECO(WS-POSICAO:1) NOT EQUAL SPACES) */

                    if ((REG_R2_ENDERECO.R2_NOM_ENDERECO.Substring(WS_POSICAO, 1) != string.Empty))
                    {

                        /*" -3263- IF (R2-NOM-ENDERECO(WS-POSICAO:1) EQUAL 'A' OR 'B' OR 'C' OR 'D' OR 'E' OR 'F' OR 'G' OR 'H' OR 'I' OR 'J' OR 'K' OR 'L' OR 'M' OR 'N' OR 'O' OR 'P' OR 'Q' OR 'R' OR 'S' OR 'T' OR 'U' OR 'V' OR 'W' OR 'X' OR 'Y' OR 'Z' ) */

                        if ((REG_R2_ENDERECO.R2_NOM_ENDERECO.Substring(WS_POSICAO, 1).In("A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z")))
                        {

                            /*" -3264- SET WS-ENCONTROU-LETRA-SIM-88 TO TRUE */
                            WS_ENCONTROU_LETRA["WS_ENCONTROU_LETRA_SIM_88"] = true;

                            /*" -3265- END-IF */
                        }


                        /*" -3266- ADD 1 TO WS-CONTA-BRC */
                        WS_CONTA_BRC.Value = WS_CONTA_BRC + 1;

                        /*" -3267- END-IF */
                    }


                    /*" -3268- ADD 1 TO WS-POSICAO */
                    WS_POSICAO.Value = WS_POSICAO + 1;

                    /*" -3270- END-PERFORM */
                }

                /*" -3272- IF (WS-CONTA-BRC < 3) */

                if ((WS_CONTA_BRC < 3))
                {

                    /*" -3273- MOVE 017 TO WS-COD-ERRO */
                    _.Move(017, WS_COD_ERRO);

                    /*" -3274- MOVE 059 TO WS-COD-CAMPO */
                    _.Move(059, WS_COD_CAMPO);

                    /*" -3275- MOVE R2-NOM-ENDERECO TO WS-DES-CONTEUDO */
                    _.Move(REG_R2_ENDERECO.R2_NOM_ENDERECO, WS_DES_CONTEUDO);

                    /*" -3276- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3278- END-IF */
                }


                /*" -3280- IF (WS-ENCONTROU-LETRA-NAO-88) */

                if ((WS_ENCONTROU_LETRA["WS_ENCONTROU_LETRA_NAO_88"]))
                {

                    /*" -3281- MOVE 021 TO WS-COD-ERRO */
                    _.Move(021, WS_COD_ERRO);

                    /*" -3282- MOVE 059 TO WS-COD-CAMPO */
                    _.Move(059, WS_COD_CAMPO);

                    /*" -3283- MOVE R2-NOM-ENDERECO TO WS-DES-CONTEUDO */
                    _.Move(REG_R2_ENDERECO.R2_NOM_ENDERECO, WS_DES_CONTEUDO);

                    /*" -3284- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3285- END-IF */
                }


                /*" -3287- END-IF. */
            }


            /*" -3289- IF (R2-NOM-CIDADE EQUAL SPACES OR LOW-VALUES) */

            if ((REG_R2_ENDERECO.R2_NOM_CIDADE.IsLowValues()))
            {

                /*" -3290- MOVE 013 TO WS-COD-ERRO */
                _.Move(013, WS_COD_ERRO);

                /*" -3291- MOVE 062 TO WS-COD-CAMPO */
                _.Move(062, WS_COD_CAMPO);

                /*" -3292- MOVE R2-NOM-CIDADE TO WS-DES-CONTEUDO */
                _.Move(REG_R2_ENDERECO.R2_NOM_CIDADE, WS_DES_CONTEUDO);

                /*" -3293- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3294- ELSE */
            }
            else
            {


                /*" -3295- MOVE 1 TO WS-POSICAO */
                _.Move(1, WS_POSICAO);

                /*" -3297- MOVE ZEROS TO WS-CONTA-BRC */
                _.Move(0, WS_CONTA_BRC);

                /*" -3298- PERFORM UNTIL WS-POSICAO > 35 */

                while (!(WS_POSICAO > 35))
                {

                    /*" -3299- IF (R2-NOM-CIDADE(WS-POSICAO:1) NOT EQUAL SPACES) */

                    if ((REG_R2_ENDERECO.R2_NOM_CIDADE.Substring(WS_POSICAO, 1) != string.Empty))
                    {

                        /*" -3300- ADD 1 TO WS-CONTA-BRC */
                        WS_CONTA_BRC.Value = WS_CONTA_BRC + 1;

                        /*" -3301- END-IF */
                    }


                    /*" -3302- ADD 1 TO WS-POSICAO */
                    WS_POSICAO.Value = WS_POSICAO + 1;

                    /*" -3304- END-PERFORM */
                }

                /*" -3306- IF (WS-CONTA-BRC < 3) */

                if ((WS_CONTA_BRC < 3))
                {

                    /*" -3307- MOVE 017 TO WS-COD-ERRO */
                    _.Move(017, WS_COD_ERRO);

                    /*" -3308- MOVE 062 TO WS-COD-CAMPO */
                    _.Move(062, WS_COD_CAMPO);

                    /*" -3309- MOVE R2-NOM-CIDADE TO WS-DES-CONTEUDO */
                    _.Move(REG_R2_ENDERECO.R2_NOM_CIDADE, WS_DES_CONTEUDO);

                    /*" -3310- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3311- END-IF */
                }


                /*" -3313- END-IF */
            }


            /*" -3315- IF (R2-SIG-UF EQUAL SPACES OR LOW-VALUES) */

            if ((REG_R2_ENDERECO.R2_SIG_UF.IsLowValues()))
            {

                /*" -3316- MOVE 013 TO WS-COD-ERRO */
                _.Move(013, WS_COD_ERRO);

                /*" -3317- MOVE 063 TO WS-COD-CAMPO */
                _.Move(063, WS_COD_CAMPO);

                /*" -3318- MOVE R2-SIG-UF TO WS-DES-CONTEUDO */
                _.Move(REG_R2_ENDERECO.R2_SIG_UF, WS_DES_CONTEUDO);

                /*" -3319- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3320- ELSE */
            }
            else
            {


                /*" -3322- MOVE R2-SIG-UF TO ENDERECO-SIGLA-UF */
                _.Move(REG_R2_ENDERECO.R2_SIG_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);

                /*" -3324- PERFORM R8013-00-VERIFICA-SIGLA-UF */

                R8013_00_VERIFICA_SIGLA_UF_SECTION();

                /*" -3326- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -3327- MOVE 014 TO WS-COD-ERRO */
                    _.Move(014, WS_COD_ERRO);

                    /*" -3328- MOVE 063 TO WS-COD-CAMPO */
                    _.Move(063, WS_COD_CAMPO);

                    /*" -3329- MOVE R2-SIG-UF TO WS-DES-CONTEUDO */
                    _.Move(REG_R2_ENDERECO.R2_SIG_UF, WS_DES_CONTEUDO);

                    /*" -3330- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3331- END-IF */
                }


                /*" -3333- END-IF */
            }


            /*" -3337- IF (R2-NUM-CEP IS NOT NUMERIC) OR (R2-NUM-CEP EQUAL ZEROS) OR (R2-NUM-CEP > 99999999) */

            if ((!REG_R2_ENDERECO.R2_NUM_CEP.IsNumeric()) || (REG_R2_ENDERECO.R2_NUM_CEP == 00) || (REG_R2_ENDERECO.R2_NUM_CEP > 99999999))
            {

                /*" -3338- MOVE 009 TO WS-COD-ERRO */
                _.Move(009, WS_COD_ERRO);

                /*" -3339- MOVE 064 TO WS-COD-CAMPO */
                _.Move(064, WS_COD_CAMPO);

                /*" -3340- MOVE R2-NUM-CEP TO WS-DES-CONTEUDO */
                _.Move(REG_R2_ENDERECO.R2_NUM_CEP, WS_DES_CONTEUDO);

                /*" -3341- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3343- END-IF. */
            }


            /*" -3346- IF (R2-NUM-DDD-TEL IS NOT NUMERIC) OR (R2-NUM-DDD-TEL EQUAL ZEROS) */

            if ((!REG_R2_ENDERECO.R2_NUM_DDD_TEL.IsNumeric()) || (REG_R2_ENDERECO.R2_NUM_DDD_TEL == 00))
            {

                /*" -3347- MOVE 009 TO WS-COD-ERRO */
                _.Move(009, WS_COD_ERRO);

                /*" -3348- MOVE 065 TO WS-COD-CAMPO */
                _.Move(065, WS_COD_CAMPO);

                /*" -3349- MOVE R2-NUM-DDD-TEL TO WS-DES-CONTEUDO */
                _.Move(REG_R2_ENDERECO.R2_NUM_DDD_TEL, WS_DES_CONTEUDO);

                /*" -3350- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3352- END-IF. */
            }


            /*" -3354- IF (R2-NUM-TEL-FIXO IS NOT NUMERIC) */

            if ((!REG_R2_ENDERECO.R2_NUM_TEL_FIXO.IsNumeric()))
            {

                /*" -3355- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -3356- MOVE 066 TO WS-COD-CAMPO */
                _.Move(066, WS_COD_CAMPO);

                /*" -3357- MOVE R2-NUM-TEL-FIXO TO WS-DES-CONTEUDO */
                _.Move(REG_R2_ENDERECO.R2_NUM_TEL_FIXO, WS_DES_CONTEUDO);

                /*" -3358- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3360- END-IF. */
            }


            /*" -3362- IF (R2-NUM-TEL-FAX IS NOT NUMERIC) */

            if ((!REG_R2_ENDERECO.R2_NUM_TEL_FAX.IsNumeric()))
            {

                /*" -3363- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -3364- MOVE 067 TO WS-COD-CAMPO */
                _.Move(067, WS_COD_CAMPO);

                /*" -3365- MOVE R2-NUM-TEL-FAX TO WS-DES-CONTEUDO */
                _.Move(REG_R2_ENDERECO.R2_NUM_TEL_FAX, WS_DES_CONTEUDO);

                /*" -3366- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3368- END-IF. */
            }


            /*" -3370- IF (R2-NUM-TEL-CEL IS NOT NUMERIC) */

            if ((!REG_R2_ENDERECO.R2_NUM_TEL_CEL.IsNumeric()))
            {

                /*" -3371- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -3372- MOVE 068 TO WS-COD-CAMPO */
                _.Move(068, WS_COD_CAMPO);

                /*" -3373- MOVE R2-NUM-TEL-CEL TO WS-DES-CONTEUDO */
                _.Move(REG_R2_ENDERECO.R2_NUM_TEL_CEL, WS_DES_CONTEUDO);

                /*" -3374- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3376- END-IF. */
            }


            /*" -3378- IF (R2-NOM-EMAIL EQUAL SPACES) */

            if ((REG_R2_ENDERECO.R2_NOM_EMAIL.IsEmpty()))
            {

                /*" -3379- MOVE 013 TO WS-COD-ERRO */
                _.Move(013, WS_COD_ERRO);

                /*" -3380- MOVE 069 TO WS-COD-CAMPO */
                _.Move(069, WS_COD_CAMPO);

                /*" -3381- MOVE R2-NOM-EMAIL TO WS-DES-CONTEUDO */
                _.Move(REG_R2_ENDERECO.R2_NOM_EMAIL, WS_DES_CONTEUDO);

                /*" -3382- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3383- ELSE */
            }
            else
            {


                /*" -3384- MOVE 1 TO WS-POSICAO */
                _.Move(1, WS_POSICAO);

                /*" -3385- MOVE ZEROS TO WS-CONTA-BRC */
                _.Move(0, WS_CONTA_BRC);

                /*" -3387- SET WS-ENCONTROU-LETRA-NAO-88 TO TRUE */
                WS_ENCONTROU_LETRA["WS_ENCONTROU_LETRA_NAO_88"] = true;

                /*" -3388- PERFORM UNTIL WS-POSICAO > 50 */

                while (!(WS_POSICAO > 50))
                {

                    /*" -3389- IF (R2-NOM-EMAIL(WS-POSICAO:1) NOT EQUAL SPACES) */

                    if ((REG_R2_ENDERECO.R2_NOM_EMAIL.Substring(WS_POSICAO, 1) != string.Empty))
                    {

                        /*" -3390- IF (R2-NOM-EMAIL(WS-POSICAO:1) EQUAL '@' ) */

                        if ((REG_R2_ENDERECO.R2_NOM_EMAIL.Substring(WS_POSICAO, 1) == "@"))
                        {

                            /*" -3391- SET WS-ENCONTROU-LETRA-SIM-88 TO TRUE */
                            WS_ENCONTROU_LETRA["WS_ENCONTROU_LETRA_SIM_88"] = true;

                            /*" -3392- END-IF */
                        }


                        /*" -3393- ADD 1 TO WS-CONTA-BRC */
                        WS_CONTA_BRC.Value = WS_CONTA_BRC + 1;

                        /*" -3394- END-IF */
                    }


                    /*" -3395- ADD 1 TO WS-POSICAO */
                    WS_POSICAO.Value = WS_POSICAO + 1;

                    /*" -3397- END-PERFORM */
                }

                /*" -3399- IF (WS-ENCONTROU-LETRA-NAO-88) */

                if ((WS_ENCONTROU_LETRA["WS_ENCONTROU_LETRA_NAO_88"]))
                {

                    /*" -3400- MOVE 021 TO WS-COD-ERRO */
                    _.Move(021, WS_COD_ERRO);

                    /*" -3401- MOVE 069 TO WS-COD-CAMPO */
                    _.Move(069, WS_COD_CAMPO);

                    /*" -3402- MOVE R2-NOM-EMAIL TO WS-DES-CONTEUDO */
                    _.Move(REG_R2_ENDERECO.R2_NOM_EMAIL, WS_DES_CONTEUDO);

                    /*" -3403- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3405- END-IF */
                }


                /*" -3407- IF (WS-CONTA-BRC < 10) */

                if ((WS_CONTA_BRC < 10))
                {

                    /*" -3408- MOVE 018 TO WS-COD-ERRO */
                    _.Move(018, WS_COD_ERRO);

                    /*" -3409- MOVE 069 TO WS-COD-CAMPO */
                    _.Move(069, WS_COD_CAMPO);

                    /*" -3410- MOVE R2-NOM-EMAIL TO WS-DES-CONTEUDO */
                    _.Move(REG_R2_ENDERECO.R2_NOM_EMAIL, WS_DES_CONTEUDO);

                    /*" -3411- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3412- END-IF */
                }


                /*" -3414- END-IF. */
            }


            /*" -3415- IF (WS-COD-ERRO EQUAL ZEROS) */

            if ((WS_COD_ERRO == 00))
            {

                /*" -3416- ADD 1 TO W-IND-MOV */
                WAREA_AUXILIAR.W_IND_MOV.Value = WAREA_AUXILIAR.W_IND_MOV + 1;

                /*" -3417- MOVE REG-R2-ENDERECO TO W-TB-MOV-PORTAL(W-IND-MOV) */
                _.Move(REG_R2_ENDERECO, WAREA_AUXILIAR.W_TAB_MOV_PORTAL.W_TAB_MOV_PORTAL_0[WAREA_AUXILIAR.W_IND_MOV].W_TB_MOV_PORTAL);

                /*" -3418- MOVE 'S' TO WS-FLAG-TEM-TP2 */
                _.Move("S", WS_FLAG_TEM_TP2);

                /*" -3419- ELSE */
            }
            else
            {


                /*" -3420- MOVE 2 TO W-CRITICA-PROPOSTA */
                _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                /*" -3420- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0315_SAIDA*/

        [StopWatch]
        /*" R0320-00-MOVTO-REPR-LEGAL-SECTION */
        private void R0320_00_MOVTO_REPR_LEGAL_SECTION()
        {
            /*" -3431- MOVE 'R0320-00-MOVTO-REPR-LEGAL' TO PARAGRAFO. */
            _.Move("R0320-00-MOVTO-REPR-LEGAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3432- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3434- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3435- INITIALIZE REG-R3-REPRESENTANTE */
            _.Initialize(
                REG_R3_REPRESENTANTE
            );

            /*" -3437- MOVE REG-PORTAL TO REG-R3-REPRESENTANTE */
            _.Move(MOV_PORTAL?.Value, REG_R3_REPRESENTANTE);

            /*" -3438- MOVE R3-NUM-PROPOSTA TO WS-NUM-PROPOSTA */
            _.Move(REG_R3_REPRESENTANTE.R3_NUM_PROPOSTA, WS_NUM_PROPOSTA);

            /*" -3439- MOVE R3-NUM-SUBGRUPO TO WS-COD-SUBGRUPO */
            _.Move(REG_R3_REPRESENTANTE.R3_NUM_SUBGRUPO, WS_COD_SUBGRUPO);

            /*" -3440- MOVE ZEROS TO WS-COD-ERRO */
            _.Move(0, WS_COD_ERRO);

            /*" -3441- MOVE 'ERRO' TO WS-TP-MENSAGEM */
            _.Move("ERRO", WS_TP_MENSAGEM);

            /*" -3442- INITIALIZE WS-DES-CONTEUDO */
            _.Initialize(
                WS_DES_CONTEUDO
            );

            /*" -3445- MOVE R3-NUM-SEQ-REG-TP03 TO WS-NUM-SEQ-ARQ */
            _.Move(REG_R3_REPRESENTANTE.R3_NUM_SEQ_REG_TP03, WS_NUM_SEQ_ARQ);

            /*" -3447- MOVE FUNCTION UPPER-CASE(R3-NOM-REPRES-LEGAL) TO R3-NOM-REPRES-LEGAL. */
            _.Move(REG_R3_REPRESENTANTE.R3_NOM_REPRES_LEGAL.ToString().ToUpper(), REG_R3_REPRESENTANTE.R3_NOM_REPRES_LEGAL);

            /*" -3449- MOVE FUNCTION UPPER-CASE(R3-NOM-ENDERECO) TO R3-NOM-ENDERECO. */
            _.Move(REG_R3_REPRESENTANTE.R3_NOM_ENDERECO.ToString().ToUpper(), REG_R3_REPRESENTANTE.R3_NOM_ENDERECO);

            /*" -3451- MOVE FUNCTION UPPER-CASE(R3-NOM-COMPL-END) TO R3-NOM-COMPL-END */
            _.Move(REG_R3_REPRESENTANTE.R3_NOM_COMPL_END.ToString().ToUpper(), REG_R3_REPRESENTANTE.R3_NOM_COMPL_END);

            /*" -3453- MOVE FUNCTION UPPER-CASE(R3-NOM-BAIRRO) TO R3-NOM-BAIRRO. */
            _.Move(REG_R3_REPRESENTANTE.R3_NOM_BAIRRO.ToString().ToUpper(), REG_R3_REPRESENTANTE.R3_NOM_BAIRRO);

            /*" -3456- MOVE FUNCTION UPPER-CASE(R3-NOM-CIDADE) TO R3-NOM-CIDADE. */
            _.Move(REG_R3_REPRESENTANTE.R3_NOM_CIDADE.ToString().ToUpper(), REG_R3_REPRESENTANTE.R3_NOM_CIDADE);

            /*" -3459- IF (R3-NUM-PROPOSTA IS NOT NUMERIC) OR (R3-NUM-PROPOSTA EQUAL ZEROS) */

            if ((!REG_R3_REPRESENTANTE.R3_NUM_PROPOSTA.IsNumeric()) || (REG_R3_REPRESENTANTE.R3_NUM_PROPOSTA == 00))
            {

                /*" -3460- MOVE 009 TO WS-COD-ERRO */
                _.Move(009, WS_COD_ERRO);

                /*" -3461- MOVE 071 TO WS-COD-CAMPO */
                _.Move(071, WS_COD_CAMPO);

                /*" -3462- MOVE R3-NUM-PROPOSTA TO WS-DES-CONTEUDO */
                _.Move(REG_R3_REPRESENTANTE.R3_NUM_PROPOSTA, WS_DES_CONTEUDO);

                /*" -3463- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3465- END-IF. */
            }


            /*" -3467- IF (R3-NUM-SUBGRUPO IS NOT NUMERIC) */

            if ((!REG_R3_REPRESENTANTE.R3_NUM_SUBGRUPO.IsNumeric()))
            {

                /*" -3468- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -3469- MOVE 072 TO WS-COD-CAMPO */
                _.Move(072, WS_COD_CAMPO);

                /*" -3470- MOVE R3-NUM-SUBGRUPO TO WS-DES-CONTEUDO */
                _.Move(REG_R3_REPRESENTANTE.R3_NUM_SUBGRUPO, WS_DES_CONTEUDO);

                /*" -3471- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3473- END-IF. */
            }


            /*" -3475- IF (R3-NUM-SUBGRUPO EQUAL ZEROS) */

            if ((REG_R3_REPRESENTANTE.R3_NUM_SUBGRUPO == 00))
            {

                /*" -3476- MOVE 009 TO WS-COD-ERRO */
                _.Move(009, WS_COD_ERRO);

                /*" -3477- MOVE 072 TO WS-COD-CAMPO */
                _.Move(072, WS_COD_CAMPO);

                /*" -3478- MOVE R3-NUM-SUBGRUPO TO WS-DES-CONTEUDO */
                _.Move(REG_R3_REPRESENTANTE.R3_NUM_SUBGRUPO, WS_DES_CONTEUDO);

                /*" -3479- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3481- END-IF. */
            }


            /*" -3483- IF (R3-NUM-SEQ-REG-TP03 IS NOT NUMERIC) */

            if ((!REG_R3_REPRESENTANTE.R3_NUM_SEQ_REG_TP03.IsNumeric()))
            {

                /*" -3484- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -3485- MOVE 073 TO WS-COD-CAMPO */
                _.Move(073, WS_COD_CAMPO);

                /*" -3486- MOVE R3-NUM-SEQ-REG-TP03 TO WS-DES-CONTEUDO */
                _.Move(REG_R3_REPRESENTANTE.R3_NUM_SEQ_REG_TP03, WS_DES_CONTEUDO);

                /*" -3487- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3489- END-IF. */
            }


            /*" -3492- IF (R3-NUM-CPF-REPRES IS NOT NUMERIC) OR (R3-NUM-CPF-REPRES EQUAL ZEROS) */

            if ((!REG_R3_REPRESENTANTE.R3_NUM_CPF_REPRES.IsNumeric()) || (REG_R3_REPRESENTANTE.R3_NUM_CPF_REPRES == 00))
            {

                /*" -3493- MOVE 009 TO WS-COD-ERRO */
                _.Move(009, WS_COD_ERRO);

                /*" -3494- MOVE 074 TO WS-COD-CAMPO */
                _.Move(074, WS_COD_CAMPO);

                /*" -3495- MOVE R3-NUM-CPF-REPRES TO WS-DES-CONTEUDO */
                _.Move(REG_R3_REPRESENTANTE.R3_NUM_CPF_REPRES, WS_DES_CONTEUDO);

                /*" -3496- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3497- ELSE */
            }
            else
            {


                /*" -3498- INITIALIZE LPARM-CPF */
                _.Initialize(
                    LPARM_CPF
                );

                /*" -3499- MOVE R3-NUM-CPF-REPRES TO LPARM-ENT-CPF */
                _.Move(REG_R3_REPRESENTANTE.R3_NUM_CPF_REPRES, LPARM_CPF.LPARM_ENT_CPF);

                /*" -3501- PERFORM R8018-00-VALIDA-CPF */

                R8018_00_VALIDA_CPF_SECTION();

                /*" -3503- IF (LPARM-SAI-CPF NOT EQUAL ZEROS) */

                if ((LPARM_CPF.LPARM_SAI_CPF != 00))
                {

                    /*" -3504- MOVE 015 TO WS-COD-ERRO */
                    _.Move(015, WS_COD_ERRO);

                    /*" -3505- MOVE 074 TO WS-COD-CAMPO */
                    _.Move(074, WS_COD_CAMPO);

                    /*" -3506- MOVE R3-NUM-CPF-REPRES TO WS-DES-CONTEUDO */
                    _.Move(REG_R3_REPRESENTANTE.R3_NUM_CPF_REPRES, WS_DES_CONTEUDO);

                    /*" -3507- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3509- END-IF */
                }


                /*" -3510- MOVE R3-NUM-CPF-REPRES TO CPF OF DCLPESSOA-FISICA */
                _.Move(REG_R3_REPRESENTANTE.R3_NUM_CPF_REPRES, PESFIS.DCLPESSOA_FISICA.CPF);

                /*" -3512- PERFORM R8020-00-VERIFICA-PESSOA-FIS */

                R8020_00_VERIFICA_PESSOA_FIS_SECTION();

                /*" -3513- IF (SQLCODE EQUAL ZEROS) */

                if ((DB.SQLCODE == 00))
                {

                    /*" -3515- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO VG093-COD-PESSOA */
                    _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, VG093.DCLVG_REPRES_LEGAL.VG093_COD_PESSOA);

                    /*" -3517- PERFORM R8037-00-VERIFICA-REPRES-LEGAL */

                    R8037_00_VERIFICA_REPRES_LEGAL_SECTION();

                    /*" -3519- IF (VG093-NUM-OCORR-HIST > ZEROS) */

                    if ((VG093.DCLVG_REPRES_LEGAL.VG093_NUM_OCORR_HIST > 00))
                    {

                        /*" -3520- MOVE WS-COD-ERRO TO WS-COD-ERRO-ANT */
                        _.Move(WS_COD_ERRO, WS_COD_ERRO_ANT);

                        /*" -3521- MOVE 027 TO WS-COD-ERRO */
                        _.Move(027, WS_COD_ERRO);

                        /*" -3522- MOVE 075 TO WS-COD-CAMPO */
                        _.Move(075, WS_COD_CAMPO);

                        /*" -3523- MOVE R3-NOM-REPRES-LEGAL TO WS-DES-CONTEUDO */
                        _.Move(REG_R3_REPRESENTANTE.R3_NOM_REPRES_LEGAL, WS_DES_CONTEUDO);

                        /*" -3524- MOVE 'ALERTA' TO WS-TP-MENSAGEM */
                        _.Move("ALERTA", WS_TP_MENSAGEM);

                        /*" -3525- PERFORM R9979-00-MONTA-TAB-CRITICA */

                        R9979_00_MONTA_TAB_CRITICA_SECTION();

                        /*" -3526- MOVE WS-COD-ERRO-ANT TO WS-COD-ERRO */
                        _.Move(WS_COD_ERRO_ANT, WS_COD_ERRO);

                        /*" -3528- END-IF */
                    }


                    /*" -3529- END-IF */
                }


                /*" -3531- END-IF. */
            }


            /*" -3533- IF (R3-NOM-REPRES-LEGAL EQUAL SPACES OR LOW-VALUES) */

            if ((REG_R3_REPRESENTANTE.R3_NOM_REPRES_LEGAL.IsLowValues()))
            {

                /*" -3534- MOVE 013 TO WS-COD-ERRO */
                _.Move(013, WS_COD_ERRO);

                /*" -3535- MOVE 075 TO WS-COD-CAMPO */
                _.Move(075, WS_COD_CAMPO);

                /*" -3536- MOVE R3-NOM-REPRES-LEGAL TO WS-DES-CONTEUDO */
                _.Move(REG_R3_REPRESENTANTE.R3_NOM_REPRES_LEGAL, WS_DES_CONTEUDO);

                /*" -3537- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3538- ELSE */
            }
            else
            {


                /*" -3539- MOVE 1 TO WS-POSICAO */
                _.Move(1, WS_POSICAO);

                /*" -3540- MOVE ZEROS TO WS-CONTA-BRC */
                _.Move(0, WS_CONTA_BRC);

                /*" -3542- SET WS-ENCONTROU-LETRA-NAO-88 TO TRUE */
                WS_ENCONTROU_LETRA["WS_ENCONTROU_LETRA_NAO_88"] = true;

                /*" -3543- PERFORM UNTIL WS-POSICAO > 40 */

                while (!(WS_POSICAO > 40))
                {

                    /*" -3544- IF (R3-NOM-REPRES-LEGAL(WS-POSICAO:1) NOT EQUAL SPACES) */

                    if ((REG_R3_REPRESENTANTE.R3_NOM_REPRES_LEGAL.Substring(WS_POSICAO, 1) != string.Empty))
                    {

                        /*" -3545- ADD 1 TO WS-CONTA-BRC */
                        WS_CONTA_BRC.Value = WS_CONTA_BRC + 1;

                        /*" -3546- END-IF */
                    }


                    /*" -3547- ADD 1 TO WS-POSICAO */
                    WS_POSICAO.Value = WS_POSICAO + 1;

                    /*" -3549- END-PERFORM */
                }

                /*" -3551- IF WS-CONTA-BRC < 5 */

                if (WS_CONTA_BRC < 5)
                {

                    /*" -3552- MOVE 016 TO WS-COD-ERRO */
                    _.Move(016, WS_COD_ERRO);

                    /*" -3553- MOVE 075 TO WS-COD-CAMPO */
                    _.Move(075, WS_COD_CAMPO);

                    /*" -3554- MOVE R3-NOM-REPRES-LEGAL TO WS-DES-CONTEUDO */
                    _.Move(REG_R3_REPRESENTANTE.R3_NOM_REPRES_LEGAL, WS_DES_CONTEUDO);

                    /*" -3555- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3556- END-IF */
                }


                /*" -3558- END-IF. */
            }


            /*" -3559- IF (R3-DTA-NASC-REPRES EQUAL SPACES OR LOW-VALUES) */

            if ((REG_R3_REPRESENTANTE.R3_DTA_NASC_REPRES.IsLowValues()))
            {

                /*" -3561- IF (R3-DTA-NASC-REPRES EQUAL LOW-VALUES) */

                if ((REG_R3_REPRESENTANTE.R3_DTA_NASC_REPRES.IsLowValues()))
                {

                    /*" -3562- MOVE 016 TO WS-COD-ERRO */
                    _.Move(016, WS_COD_ERRO);

                    /*" -3563- MOVE 076 TO WS-COD-CAMPO */
                    _.Move(076, WS_COD_CAMPO);

                    /*" -3564- MOVE R3-DTA-NASC-REPRES TO WS-DES-CONTEUDO */
                    _.Move(REG_R3_REPRESENTANTE.R3_DTA_NASC_REPRES, WS_DES_CONTEUDO);

                    /*" -3565- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3566- ELSE */
                }
                else
                {


                    /*" -3567- MOVE '01010001' TO R3-DTA-NASC-REPRES */
                    _.Move("01010001", REG_R3_REPRESENTANTE.R3_DTA_NASC_REPRES);

                    /*" -3568- END-IF */
                }


                /*" -3569- ELSE */
            }
            else
            {


                /*" -3570- MOVE R3-DTA-NASC-REPRES TO W-DATA-TRABALHO */
                _.Move(REG_R3_REPRESENTANTE.R3_DTA_NASC_REPRES, WAREA_AUXILIAR.W_DATA_TRABALHO);

                /*" -3572- PERFORM R8001-00-VERIFICA-DATA-VALIDA */

                R8001_00_VERIFICA_DATA_VALIDA_SECTION();

                /*" -3574- IF (SQLCODE NOT EQUAL ZEROS) */

                if ((DB.SQLCODE != 00))
                {

                    /*" -3575- MOVE 019 TO WS-COD-ERRO */
                    _.Move(019, WS_COD_ERRO);

                    /*" -3576- MOVE 076 TO WS-COD-CAMPO */
                    _.Move(076, WS_COD_CAMPO);

                    /*" -3577- MOVE R3-DTA-NASC-REPRES TO WS-DES-CONTEUDO */
                    _.Move(REG_R3_REPRESENTANTE.R3_DTA_NASC_REPRES, WS_DES_CONTEUDO);

                    /*" -3578- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3579- ELSE */
                }
                else
                {


                    /*" -3581- PERFORM R8019-00-CALCULA-IDADE */

                    R8019_00_CALCULA_IDADE_SECTION();

                    /*" -3583- IF (WS-IDADE < 18) OR (WS-IDADE > 100) */

                    if ((WS_IDADE < 18) || (WS_IDADE > 100))
                    {

                        /*" -3584- MOVE 020 TO WS-COD-ERRO */
                        _.Move(020, WS_COD_ERRO);

                        /*" -3585- MOVE 076 TO WS-COD-CAMPO */
                        _.Move(076, WS_COD_CAMPO);

                        /*" -3586- MOVE R3-DTA-NASC-REPRES TO WS-DES-CONTEUDO */
                        _.Move(REG_R3_REPRESENTANTE.R3_DTA_NASC_REPRES, WS_DES_CONTEUDO);

                        /*" -3587- PERFORM R9979-00-MONTA-TAB-CRITICA */

                        R9979_00_MONTA_TAB_CRITICA_SECTION();

                        /*" -3588- END-IF */
                    }


                    /*" -3589- END-IF */
                }


                /*" -3591- END-IF */
            }


            /*" -3592- IF (R3-IND-SEXO-REPRES NOT EQUAL 'M' AND 'F' ) */

            if ((!REG_R3_REPRESENTANTE.R3_IND_SEXO_REPRES.In("M", "F")))
            {

                /*" -3593- MOVE 'M' TO R3-IND-SEXO-REPRES */
                _.Move("M", REG_R3_REPRESENTANTE.R3_IND_SEXO_REPRES);

                /*" -3595- END-IF */
            }


            /*" -3597- IF (R3-IND-SEXO-REPRES NOT EQUAL 'M' AND 'F' ) */

            if ((!REG_R3_REPRESENTANTE.R3_IND_SEXO_REPRES.In("M", "F")))
            {

                /*" -3598- MOVE 012 TO WS-COD-ERRO */
                _.Move(012, WS_COD_ERRO);

                /*" -3599- MOVE 077 TO WS-COD-CAMPO */
                _.Move(077, WS_COD_CAMPO);

                /*" -3600- MOVE R3-IND-SEXO-REPRES TO WS-DES-CONTEUDO */
                _.Move(REG_R3_REPRESENTANTE.R3_IND_SEXO_REPRES, WS_DES_CONTEUDO);

                /*" -3601- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3603- END-IF. */
            }


            /*" -3605- IF (R3-IND-EST-CIVIL NOT EQUAL 'C' AND 'D' AND 'J' AND 'O' AND 'S' AND 'V' ) */

            if ((!REG_R3_REPRESENTANTE.R3_IND_EST_CIVIL.In("C", "D", "J", "O", "S", "V")))
            {

                /*" -3606- MOVE 'S' TO R3-IND-EST-CIVIL */
                _.Move("S", REG_R3_REPRESENTANTE.R3_IND_EST_CIVIL);

                /*" -3608- END-IF. */
            }


            /*" -3611- IF (R3-IND-EST-CIVIL NOT EQUAL 'C' AND 'D' AND 'J' AND 'O' AND 'S' AND 'V' ) */

            if ((!REG_R3_REPRESENTANTE.R3_IND_EST_CIVIL.In("C", "D", "J", "O", "S", "V")))
            {

                /*" -3612- MOVE 012 TO WS-COD-ERRO */
                _.Move(012, WS_COD_ERRO);

                /*" -3613- MOVE 078 TO WS-COD-CAMPO */
                _.Move(078, WS_COD_CAMPO);

                /*" -3614- MOVE R3-IND-EST-CIVIL TO WS-DES-CONTEUDO */
                _.Move(REG_R3_REPRESENTANTE.R3_IND_EST_CIVIL, WS_DES_CONTEUDO);

                /*" -3615- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3617- END-IF. */
            }


            /*" -3619- IF (R3-VAL-RENDA-REPRES IS NOT NUMERIC) */

            if ((!REG_R3_REPRESENTANTE.R3_VAL_RENDA_REPRES.IsNumeric()))
            {

                /*" -3620- MOVE 009 TO WS-COD-ERRO */
                _.Move(009, WS_COD_ERRO);

                /*" -3621- MOVE 079 TO WS-COD-CAMPO */
                _.Move(079, WS_COD_CAMPO);

                /*" -3622- MOVE R3-VAL-RENDA-REPRES TO WS-DES-CONTEU-N */
                _.Move(REG_R3_REPRESENTANTE.R3_VAL_RENDA_REPRES, FILLER_23.WS_DES_CONTEU_N);

                /*" -3623- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3636- END-IF. */
            }


            /*" -3638- IF (R3-IND-TIPO-VINCULO EQUAL SPACES) */

            if ((REG_R3_REPRESENTANTE.R3_NOM_VINCULO.R3_IND_TIPO_VINCULO.IsEmpty()))
            {

                /*" -3639- IF W-DATA-PROPOSTA < 20221110 */

                if (WAREA_AUXILIAR.W_DATA_PROPOSTA.GetMoveValues().ToInt() < 20221110)
                {

                    /*" -3640- MOVE WS-COD-ERRO TO WS-COD-ERRO-ANT */
                    _.Move(WS_COD_ERRO, WS_COD_ERRO_ANT);

                    /*" -3641- MOVE 040 TO WS-COD-ERRO */
                    _.Move(040, WS_COD_ERRO);

                    /*" -3642- MOVE 161 TO WS-COD-CAMPO */
                    _.Move(161, WS_COD_CAMPO);

                    /*" -3643- MOVE R3-IND-TIPO-VINCULO TO WS-DES-CONTEUDO */
                    _.Move(REG_R3_REPRESENTANTE.R3_NOM_VINCULO.R3_IND_TIPO_VINCULO, WS_DES_CONTEUDO);

                    /*" -3644- MOVE 'ALERTA' TO WS-TP-MENSAGEM */
                    _.Move("ALERTA", WS_TP_MENSAGEM);

                    /*" -3645- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3646- MOVE WS-COD-ERRO-ANT TO WS-COD-ERRO */
                    _.Move(WS_COD_ERRO_ANT, WS_COD_ERRO);

                    /*" -3647- GO TO R0320-CONTINUA-CRITICA */

                    R0320_CONTINUA_CRITICA(); //GOTO
                    return;

                    /*" -3648- ELSE */
                }
                else
                {


                    /*" -3649- MOVE 040 TO WS-COD-ERRO */
                    _.Move(040, WS_COD_ERRO);

                    /*" -3650- MOVE 161 TO WS-COD-CAMPO */
                    _.Move(161, WS_COD_CAMPO);

                    /*" -3651- MOVE R3-IND-TIPO-VINCULO TO WS-DES-CONTEUDO */
                    _.Move(REG_R3_REPRESENTANTE.R3_NOM_VINCULO.R3_IND_TIPO_VINCULO, WS_DES_CONTEUDO);

                    /*" -3652- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3653- END-IF */
                }


                /*" -3654- ELSE */
            }
            else
            {


                /*" -3657- IF (R3-IND-TIPO-VINCULO NOT EQUAL '01' AND '02' AND '03' AND '04' AND '05' AND '06' ) */

                if ((!REG_R3_REPRESENTANTE.R3_NOM_VINCULO.R3_IND_TIPO_VINCULO.In("01", "02", "03", "04", "05", "06")))
                {

                    /*" -3658- IF W-DATA-PROPOSTA < 20221110 */

                    if (WAREA_AUXILIAR.W_DATA_PROPOSTA.GetMoveValues().ToInt() < 20221110)
                    {

                        /*" -3659- MOVE WS-COD-ERRO TO WS-COD-ERRO-ANT */
                        _.Move(WS_COD_ERRO, WS_COD_ERRO_ANT);

                        /*" -3660- MOVE 041 TO WS-COD-ERRO */
                        _.Move(041, WS_COD_ERRO);

                        /*" -3661- MOVE 161 TO WS-COD-CAMPO */
                        _.Move(161, WS_COD_CAMPO);

                        /*" -3662- MOVE R3-IND-TIPO-VINCULO TO WS-DES-CONTEUDO */
                        _.Move(REG_R3_REPRESENTANTE.R3_NOM_VINCULO.R3_IND_TIPO_VINCULO, WS_DES_CONTEUDO);

                        /*" -3663- MOVE 'ALERTA' TO WS-TP-MENSAGEM */
                        _.Move("ALERTA", WS_TP_MENSAGEM);

                        /*" -3664- PERFORM R9979-00-MONTA-TAB-CRITICA */

                        R9979_00_MONTA_TAB_CRITICA_SECTION();

                        /*" -3665- MOVE WS-COD-ERRO-ANT TO WS-COD-ERRO */
                        _.Move(WS_COD_ERRO_ANT, WS_COD_ERRO);

                        /*" -3666- GO TO R0320-CONTINUA-CRITICA */

                        R0320_CONTINUA_CRITICA(); //GOTO
                        return;

                        /*" -3668- ELSE */
                    }
                    else
                    {


                        /*" -3669- MOVE 041 TO WS-COD-ERRO */
                        _.Move(041, WS_COD_ERRO);

                        /*" -3670- MOVE 161 TO WS-COD-CAMPO */
                        _.Move(161, WS_COD_CAMPO);

                        /*" -3671- MOVE R3-IND-TIPO-VINCULO TO WS-DES-CONTEUDO */
                        _.Move(REG_R3_REPRESENTANTE.R3_NOM_VINCULO.R3_IND_TIPO_VINCULO, WS_DES_CONTEUDO);

                        /*" -3672- PERFORM R9979-00-MONTA-TAB-CRITICA */

                        R9979_00_MONTA_TAB_CRITICA_SECTION();

                        /*" -3673- END-IF */
                    }


                    /*" -3674- END-IF */
                }


                /*" -3676- END-IF. */
            }


            /*" -3678- IF (R3-NUM-CEP IS NOT NUMERIC) OR (R3-NUM-CEP > 99999999) */

            if ((!REG_R3_REPRESENTANTE.R3_NUM_CEP.IsNumeric()) || (REG_R3_REPRESENTANTE.R3_NUM_CEP > 99999999))
            {

                /*" -3679- IF W-DATA-PROPOSTA < 20221110 */

                if (WAREA_AUXILIAR.W_DATA_PROPOSTA.GetMoveValues().ToInt() < 20221110)
                {

                    /*" -3680- MOVE WS-COD-ERRO TO WS-COD-ERRO-ANT */
                    _.Move(WS_COD_ERRO, WS_COD_ERRO_ANT);

                    /*" -3681- MOVE 009 TO WS-COD-ERRO */
                    _.Move(009, WS_COD_ERRO);

                    /*" -3682- MOVE 086 TO WS-COD-CAMPO */
                    _.Move(086, WS_COD_CAMPO);

                    /*" -3683- MOVE R3-NUM-CEP TO WS-DES-CONTEUDO */
                    _.Move(REG_R3_REPRESENTANTE.R3_NUM_CEP, WS_DES_CONTEUDO);

                    /*" -3684- MOVE 'ALERTA' TO WS-TP-MENSAGEM */
                    _.Move("ALERTA", WS_TP_MENSAGEM);

                    /*" -3685- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3686- MOVE WS-COD-ERRO-ANT TO WS-COD-ERRO */
                    _.Move(WS_COD_ERRO_ANT, WS_COD_ERRO);

                    /*" -3687- GO TO R0320-CONTINUA-CRITICA */

                    R0320_CONTINUA_CRITICA(); //GOTO
                    return;

                    /*" -3689- ELSE */
                }
                else
                {


                    /*" -3691- IF (R3-IND-TIPO-VINCULO NOT EQUAL '01' ) */

                    if ((REG_R3_REPRESENTANTE.R3_NOM_VINCULO.R3_IND_TIPO_VINCULO != "01"))
                    {

                        /*" -3692- MOVE 009 TO WS-COD-ERRO */
                        _.Move(009, WS_COD_ERRO);

                        /*" -3693- MOVE 086 TO WS-COD-CAMPO */
                        _.Move(086, WS_COD_CAMPO);

                        /*" -3694- MOVE R3-NUM-CEP TO WS-DES-CONTEUDO */
                        _.Move(REG_R3_REPRESENTANTE.R3_NUM_CEP, WS_DES_CONTEUDO);

                        /*" -3695- PERFORM R9979-00-MONTA-TAB-CRITICA */

                        R9979_00_MONTA_TAB_CRITICA_SECTION();

                        /*" -3697- ELSE */
                    }
                    else
                    {


                        /*" -3698- MOVE WS-COD-ERRO TO WS-COD-ERRO-ANT */
                        _.Move(WS_COD_ERRO, WS_COD_ERRO_ANT);

                        /*" -3699- MOVE 042 TO WS-COD-ERRO */
                        _.Move(042, WS_COD_ERRO);

                        /*" -3700- MOVE 086 TO WS-COD-CAMPO */
                        _.Move(086, WS_COD_CAMPO);

                        /*" -3701- MOVE R3-NUM-CEP TO WS-DES-CONTEUDO */
                        _.Move(REG_R3_REPRESENTANTE.R3_NUM_CEP, WS_DES_CONTEUDO);

                        /*" -3702- MOVE 'ALERTA' TO WS-TP-MENSAGEM */
                        _.Move("ALERTA", WS_TP_MENSAGEM);

                        /*" -3703- PERFORM R9979-00-MONTA-TAB-CRITICA */

                        R9979_00_MONTA_TAB_CRITICA_SECTION();

                        /*" -3704- MOVE WS-COD-ERRO-ANT TO WS-COD-ERRO */
                        _.Move(WS_COD_ERRO_ANT, WS_COD_ERRO);

                        /*" -3705- GO TO R0320-CONTINUA-CRITICA */

                        R0320_CONTINUA_CRITICA(); //GOTO
                        return;

                        /*" -3706- END-IF */
                    }


                    /*" -3707- END-IF */
                }


                /*" -3709- END-IF. */
            }


            /*" -3711- IF (R3-NUM-TIPO-END IS NOT NUMERIC) */

            if ((!REG_R3_REPRESENTANTE.R3_NUM_TIPO_END.IsNumeric()))
            {

                /*" -3712- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -3713- MOVE 080 TO WS-COD-CAMPO */
                _.Move(080, WS_COD_CAMPO);

                /*" -3714- MOVE R3-NUM-TIPO-END TO WS-DES-CONTEUDO */
                _.Move(REG_R3_REPRESENTANTE.R3_NUM_TIPO_END, WS_DES_CONTEUDO);

                /*" -3715- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3717- END-IF. */
            }


            /*" -3718- IF (R3-NOM-ENDERECO EQUAL SPACES OR LOW-VALUES) */

            if ((REG_R3_REPRESENTANTE.R3_NOM_ENDERECO.IsLowValues()))
            {

                /*" -3720- IF (R3-NOM-ENDERECO EQUAL LOW-VALUES) */

                if ((REG_R3_REPRESENTANTE.R3_NOM_ENDERECO.IsLowValues()))
                {

                    /*" -3721- MOVE 013 TO WS-COD-ERRO */
                    _.Move(013, WS_COD_ERRO);

                    /*" -3722- MOVE 081 TO WS-COD-CAMPO */
                    _.Move(081, WS_COD_CAMPO);

                    /*" -3723- MOVE R3-NOM-ENDERECO TO WS-DES-CONTEUDO */
                    _.Move(REG_R3_REPRESENTANTE.R3_NOM_ENDERECO, WS_DES_CONTEUDO);

                    /*" -3724- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3725- END-IF */
                }


                /*" -3726- ELSE */
            }
            else
            {


                /*" -3727- MOVE 1 TO WS-POSICAO */
                _.Move(1, WS_POSICAO);

                /*" -3728- MOVE ZEROS TO WS-CONTA-BRC */
                _.Move(0, WS_CONTA_BRC);

                /*" -3731- SET WS-ENCONTROU-LETRA-NAO-88 TO TRUE */
                WS_ENCONTROU_LETRA["WS_ENCONTROU_LETRA_NAO_88"] = true;

                /*" -3732- PERFORM UNTIL WS-POSICAO > 40 */

                while (!(WS_POSICAO > 40))
                {

                    /*" -3733- IF (R3-NOM-ENDERECO(WS-POSICAO:1) NOT EQUAL SPACES) */

                    if ((REG_R3_REPRESENTANTE.R3_NOM_ENDERECO.Substring(WS_POSICAO, 1) != string.Empty))
                    {

                        /*" -3739- IF (R3-NOM-ENDERECO(WS-POSICAO:1) EQUAL 'A' OR 'B' OR 'C' OR 'D' OR 'E' OR 'F' OR 'G' OR 'H' OR 'I' OR 'J' OR 'K' OR 'L' OR 'M' OR 'N' OR 'O' OR 'P' OR 'Q' OR 'R' OR 'S' OR 'T' OR 'U' OR 'V' OR 'W' OR 'X' OR 'Y' OR 'Z' ) */

                        if ((REG_R3_REPRESENTANTE.R3_NOM_ENDERECO.Substring(WS_POSICAO, 1).In("A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z")))
                        {

                            /*" -3740- SET WS-ENCONTROU-LETRA-SIM-88 TO TRUE */
                            WS_ENCONTROU_LETRA["WS_ENCONTROU_LETRA_SIM_88"] = true;

                            /*" -3741- END-IF */
                        }


                        /*" -3742- ADD 1 TO WS-CONTA-BRC */
                        WS_CONTA_BRC.Value = WS_CONTA_BRC + 1;

                        /*" -3743- END-IF */
                    }


                    /*" -3744- ADD 1 TO WS-POSICAO */
                    WS_POSICAO.Value = WS_POSICAO + 1;

                    /*" -3746- END-PERFORM */
                }

                /*" -3748- IF (WS-ENCONTROU-LETRA-NAO-88) */

                if ((WS_ENCONTROU_LETRA["WS_ENCONTROU_LETRA_NAO_88"]))
                {

                    /*" -3749- MOVE 021 TO WS-COD-ERRO */
                    _.Move(021, WS_COD_ERRO);

                    /*" -3750- MOVE 081 TO WS-COD-CAMPO */
                    _.Move(081, WS_COD_CAMPO);

                    /*" -3751- MOVE R3-NOM-ENDERECO TO WS-DES-CONTEUDO */
                    _.Move(REG_R3_REPRESENTANTE.R3_NOM_ENDERECO, WS_DES_CONTEUDO);

                    /*" -3752- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3754- END-IF */
                }


                /*" -3756- IF (WS-CONTA-BRC < 3) */

                if ((WS_CONTA_BRC < 3))
                {

                    /*" -3757- MOVE 017 TO WS-COD-ERRO */
                    _.Move(017, WS_COD_ERRO);

                    /*" -3758- MOVE 081 TO WS-COD-CAMPO */
                    _.Move(081, WS_COD_CAMPO);

                    /*" -3759- MOVE R3-NOM-ENDERECO TO WS-DES-CONTEUDO */
                    _.Move(REG_R3_REPRESENTANTE.R3_NOM_ENDERECO, WS_DES_CONTEUDO);

                    /*" -3760- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3761- END-IF */
                }


                /*" -3763- END-IF. */
            }


            /*" -3765- IF (R3-NOM-COMPL-END EQUAL LOW-VALUES) */

            if ((REG_R3_REPRESENTANTE.R3_NOM_COMPL_END.IsLowValues()))
            {

                /*" -3766- MOVE 013 TO WS-COD-ERRO */
                _.Move(013, WS_COD_ERRO);

                /*" -3767- MOVE 082 TO WS-COD-CAMPO */
                _.Move(082, WS_COD_CAMPO);

                /*" -3768- MOVE R3-NOM-COMPL-END TO WS-DES-CONTEUDO */
                _.Move(REG_R3_REPRESENTANTE.R3_NOM_COMPL_END, WS_DES_CONTEUDO);

                /*" -3769- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3771- END-IF */
            }


            /*" -3772- IF (R3-NOM-CIDADE EQUAL SPACES OR LOW-VALUES) */

            if ((REG_R3_REPRESENTANTE.R3_NOM_CIDADE.IsLowValues()))
            {

                /*" -3774- IF (R3-NOM-CIDADE EQUAL LOW-VALUES) */

                if ((REG_R3_REPRESENTANTE.R3_NOM_CIDADE.IsLowValues()))
                {

                    /*" -3775- MOVE 013 TO WS-COD-ERRO */
                    _.Move(013, WS_COD_ERRO);

                    /*" -3776- MOVE 084 TO WS-COD-CAMPO */
                    _.Move(084, WS_COD_CAMPO);

                    /*" -3777- MOVE R3-NOM-CIDADE TO WS-DES-CONTEUDO */
                    _.Move(REG_R3_REPRESENTANTE.R3_NOM_CIDADE, WS_DES_CONTEUDO);

                    /*" -3778- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3779- END-IF */
                }


                /*" -3780- ELSE */
            }
            else
            {


                /*" -3781- MOVE 1 TO WS-POSICAO */
                _.Move(1, WS_POSICAO);

                /*" -3782- MOVE ZEROS TO WS-CONTA-BRC */
                _.Move(0, WS_CONTA_BRC);

                /*" -3784- SET WS-ENCONTROU-LETRA-NAO-88 TO TRUE */
                WS_ENCONTROU_LETRA["WS_ENCONTROU_LETRA_NAO_88"] = true;

                /*" -3785- PERFORM UNTIL WS-POSICAO > 20 */

                while (!(WS_POSICAO > 20))
                {

                    /*" -3786- IF (R3-NOM-CIDADE(WS-POSICAO:1) NOT EQUAL SPACES) */

                    if ((REG_R3_REPRESENTANTE.R3_NOM_CIDADE.Substring(WS_POSICAO, 1) != string.Empty))
                    {

                        /*" -3792- IF (R3-NOM-CIDADE(WS-POSICAO:1) EQUAL 'A' OR 'B' OR 'C' OR 'D' OR 'E' OR 'F' OR 'G' OR 'H' OR 'I' OR 'J' OR 'K' OR 'L' OR 'M' OR 'N' OR 'O' OR 'P' OR 'Q' OR 'R' OR 'S' OR 'T' OR 'U' OR 'V' OR 'W' OR 'X' OR 'Y' OR 'Z' ) */

                        if ((REG_R3_REPRESENTANTE.R3_NOM_CIDADE.Substring(WS_POSICAO, 1).In("A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z")))
                        {

                            /*" -3793- SET WS-ENCONTROU-LETRA-SIM-88 TO TRUE */
                            WS_ENCONTROU_LETRA["WS_ENCONTROU_LETRA_SIM_88"] = true;

                            /*" -3794- END-IF */
                        }


                        /*" -3795- ADD 1 TO WS-CONTA-BRC */
                        WS_CONTA_BRC.Value = WS_CONTA_BRC + 1;

                        /*" -3796- END-IF */
                    }


                    /*" -3797- ADD 1 TO WS-POSICAO */
                    WS_POSICAO.Value = WS_POSICAO + 1;

                    /*" -3799- END-PERFORM */
                }

                /*" -3801- IF (WS-CONTA-BRC < 3) */

                if ((WS_CONTA_BRC < 3))
                {

                    /*" -3802- MOVE 017 TO WS-COD-ERRO */
                    _.Move(017, WS_COD_ERRO);

                    /*" -3803- MOVE 084 TO WS-COD-CAMPO */
                    _.Move(084, WS_COD_CAMPO);

                    /*" -3804- MOVE R3-NOM-CIDADE TO WS-DES-CONTEUDO */
                    _.Move(REG_R3_REPRESENTANTE.R3_NOM_CIDADE, WS_DES_CONTEUDO);

                    /*" -3805- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3807- END-IF */
                }


                /*" -3809- IF (WS-ENCONTROU-LETRA-NAO-88) */

                if ((WS_ENCONTROU_LETRA["WS_ENCONTROU_LETRA_NAO_88"]))
                {

                    /*" -3810- MOVE 021 TO WS-COD-ERRO */
                    _.Move(021, WS_COD_ERRO);

                    /*" -3811- MOVE 084 TO WS-COD-CAMPO */
                    _.Move(084, WS_COD_CAMPO);

                    /*" -3812- MOVE R3-NOM-CIDADE TO WS-DES-CONTEUDO */
                    _.Move(REG_R3_REPRESENTANTE.R3_NOM_CIDADE, WS_DES_CONTEUDO);

                    /*" -3813- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3814- END-IF */
                }


                /*" -3816- END-IF */
            }


            /*" -3818- IF (R3-NOM-BAIRRO EQUAL LOW-VALUES) */

            if ((REG_R3_REPRESENTANTE.R3_NOM_BAIRRO.IsLowValues()))
            {

                /*" -3819- MOVE 013 TO WS-COD-ERRO */
                _.Move(013, WS_COD_ERRO);

                /*" -3820- MOVE 083 TO WS-COD-CAMPO */
                _.Move(083, WS_COD_CAMPO);

                /*" -3821- MOVE R3-NOM-BAIRRO TO WS-DES-CONTEUDO */
                _.Move(REG_R3_REPRESENTANTE.R3_NOM_BAIRRO, WS_DES_CONTEUDO);

                /*" -3822- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3824- END-IF */
            }


            /*" -3825- IF (R3-SIG-UF EQUAL SPACES OR LOW-VALUES) */

            if ((REG_R3_REPRESENTANTE.R3_SIG_UF.IsLowValues()))
            {

                /*" -3827- IF (R3-SIG-UF EQUAL LOW-VALUES) */

                if ((REG_R3_REPRESENTANTE.R3_SIG_UF.IsLowValues()))
                {

                    /*" -3828- MOVE 013 TO WS-COD-ERRO */
                    _.Move(013, WS_COD_ERRO);

                    /*" -3829- MOVE 085 TO WS-COD-CAMPO */
                    _.Move(085, WS_COD_CAMPO);

                    /*" -3830- MOVE R3-SIG-UF TO WS-DES-CONTEUDO */
                    _.Move(REG_R3_REPRESENTANTE.R3_SIG_UF, WS_DES_CONTEUDO);

                    /*" -3831- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3832- END-IF */
                }


                /*" -3833- ELSE */
            }
            else
            {


                /*" -3835- MOVE R3-SIG-UF TO ENDERECO-SIGLA-UF */
                _.Move(REG_R3_REPRESENTANTE.R3_SIG_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);

                /*" -3837- PERFORM R8013-00-VERIFICA-SIGLA-UF */

                R8013_00_VERIFICA_SIGLA_UF_SECTION();

                /*" -3839- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -3840- MOVE 014 TO WS-COD-ERRO */
                    _.Move(014, WS_COD_ERRO);

                    /*" -3841- MOVE 085 TO WS-COD-CAMPO */
                    _.Move(085, WS_COD_CAMPO);

                    /*" -3842- MOVE R3-SIG-UF TO WS-DES-CONTEUDO */
                    _.Move(REG_R3_REPRESENTANTE.R3_SIG_UF, WS_DES_CONTEUDO);

                    /*" -3843- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3844- END-IF */
                }


                /*" -3844- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0320_CONTINUA_CRITICA */

            R0320_CONTINUA_CRITICA();

        }

        [StopWatch]
        /*" R0320-CONTINUA-CRITICA */
        private void R0320_CONTINUA_CRITICA(bool isPerform = false)
        {
            /*" -3850- IF (R3-COD-CBO IS NOT NUMERIC) */

            if ((!REG_R3_REPRESENTANTE.R3_COD_CBO.IsNumeric()))
            {

                /*" -3851- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -3852- MOVE 087 TO WS-COD-CAMPO */
                _.Move(087, WS_COD_CAMPO);

                /*" -3853- MOVE R3-COD-CBO TO WS-DES-CONTEUDO */
                _.Move(REG_R3_REPRESENTANTE.R3_COD_CBO, WS_DES_CONTEUDO);

                /*" -3854- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3855- ELSE */
            }
            else
            {


                /*" -3856- IF (R3-COD-CBO > ZEROS) */

                if ((REG_R3_REPRESENTANTE.R3_COD_CBO > 00))
                {

                    /*" -3857- MOVE WS-COD-CBO TO CBO-COD-CBO */
                    _.Move(WAREA_AUXILIAR.WS_COD_CBO, CBO.DCLCBO.CBO_COD_CBO);

                    /*" -3859- PERFORM R8029-00-OBTER-CBO */

                    R8029_00_OBTER_CBO_SECTION();

                    /*" -3861- IF (SQLCODE EQUAL +100) */

                    if ((DB.SQLCODE == +100))
                    {

                        /*" -3862- MOVE 014 TO WS-COD-ERRO */
                        _.Move(014, WS_COD_ERRO);

                        /*" -3863- MOVE 087 TO WS-COD-CAMPO */
                        _.Move(087, WS_COD_CAMPO);

                        /*" -3864- MOVE R3-COD-CBO TO WS-DES-CONTEUDO */
                        _.Move(REG_R3_REPRESENTANTE.R3_COD_CBO, WS_DES_CONTEUDO);

                        /*" -3865- PERFORM R9979-00-MONTA-TAB-CRITICA */

                        R9979_00_MONTA_TAB_CRITICA_SECTION();

                        /*" -3866- END-IF */
                    }


                    /*" -3868- END-IF. */
                }

            }


            /*" -3870- MOVE 1 TO WS-POS */
            _.Move(1, WS_POS);

            /*" -3871- PERFORM UNTIL WS-POS > 3 */

            while (!(WS_POS > 3))
            {

                /*" -3873- IF (R3-NOM-EMAIL(WS-POS) EQUAL LOW-VALUES) */

                if ((REG_R3_REPRESENTANTE.R3_TAB_EMAIL_TEL.R3_TAB_EMAIL_TEL_REG[WS_POS].R3_NOM_EMAIL == ""))
                {

                    /*" -3874- MOVE 013 TO WS-COD-ERRO */
                    _.Move(013, WS_COD_ERRO);

                    /*" -3875- MOVE 088 TO WS-COD-CAMPO */
                    _.Move(088, WS_COD_CAMPO);

                    /*" -3876- MOVE R3-NOM-EMAIL(WS-POS) TO WS-DES-CONTEUDO */
                    _.Move(REG_R3_REPRESENTANTE.R3_TAB_EMAIL_TEL.R3_TAB_EMAIL_TEL_REG[WS_POS].R3_NOM_EMAIL, WS_DES_CONTEUDO);

                    /*" -3877- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3878- ELSE */
                }
                else
                {


                    /*" -3879- IF (R3-NOM-EMAIL(WS-POS) NOT EQUAL SPACES) */

                    if ((REG_R3_REPRESENTANTE.R3_TAB_EMAIL_TEL.R3_TAB_EMAIL_TEL_REG[WS_POS].R3_NOM_EMAIL != string.Empty))
                    {

                        /*" -3880- MOVE 1 TO WS-POSICAO */
                        _.Move(1, WS_POSICAO);

                        /*" -3881- MOVE ZEROS TO WS-CONTA-BRC */
                        _.Move(0, WS_CONTA_BRC);

                        /*" -3882- SET WS-ENCONTROU-LETRA-NAO-88 TO TRUE */
                        WS_ENCONTROU_LETRA["WS_ENCONTROU_LETRA_NAO_88"] = true;

                        /*" -3884- MOVE R3-NOM-EMAIL(WS-POS) TO WS-NOME-EMAIL */
                        _.Move(REG_R3_REPRESENTANTE.R3_TAB_EMAIL_TEL.R3_TAB_EMAIL_TEL_REG[WS_POS].R3_NOM_EMAIL, WS_NOME_EMAIL);

                        /*" -3885- PERFORM UNTIL WS-POSICAO > 50 */

                        while (!(WS_POSICAO > 50))
                        {

                            /*" -3886- IF (WS-NOME-EMAIL(WS-POSICAO:1) NOT EQUAL SPACES) */

                            if ((WS_NOME_EMAIL.Substring(WS_POSICAO, 1) != string.Empty))
                            {

                                /*" -3887- IF (WS-NOME-EMAIL(WS-POSICAO:1) EQUAL '@' ) */

                                if ((WS_NOME_EMAIL.Substring(WS_POSICAO, 1) == "@"))
                                {

                                    /*" -3888- SET WS-ENCONTROU-LETRA-SIM-88 TO TRUE */
                                    WS_ENCONTROU_LETRA["WS_ENCONTROU_LETRA_SIM_88"] = true;

                                    /*" -3889- END-IF */
                                }


                                /*" -3890- ADD 1 TO WS-CONTA-BRC */
                                WS_CONTA_BRC.Value = WS_CONTA_BRC + 1;

                                /*" -3891- END-IF */
                            }


                            /*" -3892- ADD 1 TO WS-POSICAO */
                            WS_POSICAO.Value = WS_POSICAO + 1;

                            /*" -3894- END-PERFORM */
                        }

                        /*" -3896- IF (WS-ENCONTROU-LETRA-NAO-88) */

                        if ((WS_ENCONTROU_LETRA["WS_ENCONTROU_LETRA_NAO_88"]))
                        {

                            /*" -3897- MOVE 012 TO WS-COD-ERRO */
                            _.Move(012, WS_COD_ERRO);

                            /*" -3898- MOVE 088 TO WS-COD-CAMPO */
                            _.Move(088, WS_COD_CAMPO);

                            /*" -3899- MOVE R3-NOM-EMAIL(WS-POS) TO WS-DES-CONTEUDO */
                            _.Move(REG_R3_REPRESENTANTE.R3_TAB_EMAIL_TEL.R3_TAB_EMAIL_TEL_REG[WS_POS].R3_NOM_EMAIL, WS_DES_CONTEUDO);

                            /*" -3900- PERFORM R9979-00-MONTA-TAB-CRITICA */

                            R9979_00_MONTA_TAB_CRITICA_SECTION();

                            /*" -3902- END-IF */
                        }


                        /*" -3904- IF (WS-CONTA-BRC < 10) */

                        if ((WS_CONTA_BRC < 10))
                        {

                            /*" -3905- MOVE 018 TO WS-COD-ERRO */
                            _.Move(018, WS_COD_ERRO);

                            /*" -3906- MOVE 088 TO WS-COD-CAMPO */
                            _.Move(088, WS_COD_CAMPO);

                            /*" -3907- MOVE R3-NOM-EMAIL(WS-POS) TO WS-DES-CONTEUDO */
                            _.Move(REG_R3_REPRESENTANTE.R3_TAB_EMAIL_TEL.R3_TAB_EMAIL_TEL_REG[WS_POS].R3_NOM_EMAIL, WS_DES_CONTEUDO);

                            /*" -3908- PERFORM R9979-00-MONTA-TAB-CRITICA */

                            R9979_00_MONTA_TAB_CRITICA_SECTION();

                            /*" -3909- END-IF */
                        }


                        /*" -3910- END-IF */
                    }


                    /*" -3912- END-IF */
                }


                /*" -3915- IF (R3-IND-TIPO-TEL(WS-POS) IS NOT NUMERIC) OR (R3-IND-TIPO-TEL(WS-POS) > 3) */

                if ((!REG_R3_REPRESENTANTE.R3_TAB_EMAIL_TEL.R3_TAB_EMAIL_TEL_REG[WS_POS].R3_IND_TIPO_TEL.IsNumeric()) || (REG_R3_REPRESENTANTE.R3_TAB_EMAIL_TEL.R3_TAB_EMAIL_TEL_REG[WS_POS].R3_IND_TIPO_TEL > 3))
                {

                    /*" -3916- MOVE 012 TO WS-COD-ERRO */
                    _.Move(012, WS_COD_ERRO);

                    /*" -3917- MOVE 089 TO WS-COD-CAMPO */
                    _.Move(089, WS_COD_CAMPO);

                    /*" -3918- MOVE R3-IND-TIPO-TEL(WS-POS) TO WS-DES-CONTEUDO */
                    _.Move(REG_R3_REPRESENTANTE.R3_TAB_EMAIL_TEL.R3_TAB_EMAIL_TEL_REG[WS_POS].R3_IND_TIPO_TEL, WS_DES_CONTEUDO);

                    /*" -3919- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -3920- ELSE */
                }
                else
                {


                    /*" -3921- IF (R3-IND-TIPO-TEL(WS-POS) > ZEROS) */

                    if ((REG_R3_REPRESENTANTE.R3_TAB_EMAIL_TEL.R3_TAB_EMAIL_TEL_REG[WS_POS].R3_IND_TIPO_TEL > 00))
                    {

                        /*" -3924- IF (R3-NUM-DDD-TEL(WS-POS) IS NOT NUMERIC) OR (R3-NUM-DDD-TEL(WS-POS) EQUAL ZEROS) */

                        if ((!REG_R3_REPRESENTANTE.R3_TAB_EMAIL_TEL.R3_TAB_EMAIL_TEL_REG[WS_POS].R3_NUM_DDD_TEL.IsNumeric()) || (REG_R3_REPRESENTANTE.R3_TAB_EMAIL_TEL.R3_TAB_EMAIL_TEL_REG[WS_POS].R3_NUM_DDD_TEL == 00))
                        {

                            /*" -3925- MOVE 332 TO WS-COD-ERRO */
                            _.Move(332, WS_COD_ERRO);

                            /*" -3926- MOVE 090 TO WS-COD-CAMPO */
                            _.Move(090, WS_COD_CAMPO);

                            /*" -3927- MOVE R3-NUM-DDD-TEL(WS-POS) TO WS-DES-CONTEUDO */
                            _.Move(REG_R3_REPRESENTANTE.R3_TAB_EMAIL_TEL.R3_TAB_EMAIL_TEL_REG[WS_POS].R3_NUM_DDD_TEL, WS_DES_CONTEUDO);

                            /*" -3928- PERFORM R9979-00-MONTA-TAB-CRITICA */

                            R9979_00_MONTA_TAB_CRITICA_SECTION();

                            /*" -3930- END-IF */
                        }


                        /*" -3933- IF (R3-NUM-TELEFONE(WS-POS) IS NOT NUMERIC) OR (R3-NUM-TELEFONE(WS-POS) EQUAL ZEROS) */

                        if ((!REG_R3_REPRESENTANTE.R3_TAB_EMAIL_TEL.R3_TAB_EMAIL_TEL_REG[WS_POS].R3_NUM_TELEFONE.IsNumeric()) || (REG_R3_REPRESENTANTE.R3_TAB_EMAIL_TEL.R3_TAB_EMAIL_TEL_REG[WS_POS].R3_NUM_TELEFONE == 00))
                        {

                            /*" -3934- MOVE 012 TO WS-COD-ERRO */
                            _.Move(012, WS_COD_ERRO);

                            /*" -3935- MOVE 091 TO WS-COD-CAMPO */
                            _.Move(091, WS_COD_CAMPO);

                            /*" -3936- MOVE R3-NUM-TELEFONE(WS-POS) TO WS-DES-CONTEUDO */
                            _.Move(REG_R3_REPRESENTANTE.R3_TAB_EMAIL_TEL.R3_TAB_EMAIL_TEL_REG[WS_POS].R3_NUM_TELEFONE, WS_DES_CONTEUDO);

                            /*" -3937- PERFORM R9979-00-MONTA-TAB-CRITICA */

                            R9979_00_MONTA_TAB_CRITICA_SECTION();

                            /*" -3938- END-IF */
                        }


                        /*" -3939- END-IF */
                    }


                    /*" -3941- END-IF */
                }


                /*" -3942- ADD 1 TO WS-POS */
                WS_POS.Value = WS_POS + 1;

                /*" -3944- END-PERFORM. */
            }

            /*" -3945- IF (WS-COD-ERRO EQUAL ZEROS) */

            if ((WS_COD_ERRO == 00))
            {

                /*" -3946- ADD 1 TO W-IND-MOV */
                WAREA_AUXILIAR.W_IND_MOV.Value = WAREA_AUXILIAR.W_IND_MOV + 1;

                /*" -3947- MOVE REG-R3-REPRESENTANTE TO W-TB-MOV-PORTAL(W-IND-MOV) */
                _.Move(REG_R3_REPRESENTANTE, WAREA_AUXILIAR.W_TAB_MOV_PORTAL.W_TAB_MOV_PORTAL_0[WAREA_AUXILIAR.W_IND_MOV].W_TB_MOV_PORTAL);

                /*" -3948- MOVE 'S' TO WS-FLAG-TEM-TP3 */
                _.Move("S", WS_FLAG_TEM_TP3);

                /*" -3949- ELSE */
            }
            else
            {


                /*" -3950- MOVE 2 TO W-CRITICA-PROPOSTA */
                _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                /*" -3950- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_SAIDA*/

        [StopWatch]
        /*" R0325-00-MOVTO-COBER-ADIC-SECTION */
        private void R0325_00_MOVTO_COBER_ADIC_SECTION()
        {
            /*" -3962- MOVE 'R0325-00-MOVTO-COBER-ADIC' TO PARAGRAFO. */
            _.Move("R0325-00-MOVTO-COBER-ADIC", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3963- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3965- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3966- INITIALIZE REG-R4-COBERTURA */
            _.Initialize(
                REG_R4_COBERTURA
            );

            /*" -3968- MOVE REG-PORTAL TO REG-R4-COBERTURA */
            _.Move(MOV_PORTAL?.Value, REG_R4_COBERTURA);

            /*" -3969- MOVE R4-NUM-PROPOSTA TO WS-NUM-PROPOSTA */
            _.Move(REG_R4_COBERTURA.R4_NUM_PROPOSTA, WS_NUM_PROPOSTA);

            /*" -3970- MOVE R4-NUM-SUBGRUPO TO WS-COD-SUBGRUPO */
            _.Move(REG_R4_COBERTURA.R4_NUM_SUBGRUPO, WS_COD_SUBGRUPO);

            /*" -3971- MOVE ZEROS TO WS-COD-ERRO */
            _.Move(0, WS_COD_ERRO);

            /*" -3972- MOVE 'ERRO' TO WS-TP-MENSAGEM */
            _.Move("ERRO", WS_TP_MENSAGEM);

            /*" -3973- INITIALIZE WS-DES-CONTEUDO */
            _.Initialize(
                WS_DES_CONTEUDO
            );

            /*" -3975- MOVE R4-NUM-SEQ-REG-TP04 TO WS-NUM-SEQ-ARQ */
            _.Move(REG_R4_COBERTURA.R4_NUM_SEQ_REG_TP04, WS_NUM_SEQ_ARQ);

            /*" -3978- IF (R4-NUM-PROPOSTA IS NOT NUMERIC) OR (R4-NUM-PROPOSTA EQUAL ZEROS) */

            if ((!REG_R4_COBERTURA.R4_NUM_PROPOSTA.IsNumeric()) || (REG_R4_COBERTURA.R4_NUM_PROPOSTA == 00))
            {

                /*" -3979- MOVE 009 TO WS-COD-ERRO */
                _.Move(009, WS_COD_ERRO);

                /*" -3980- MOVE 093 TO WS-COD-CAMPO */
                _.Move(093, WS_COD_CAMPO);

                /*" -3981- MOVE R4-NUM-PROPOSTA TO WS-DES-CONTEUDO */
                _.Move(REG_R4_COBERTURA.R4_NUM_PROPOSTA, WS_DES_CONTEUDO);

                /*" -3982- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3984- END-IF. */
            }


            /*" -3986- IF (R4-NUM-SUBGRUPO IS NOT NUMERIC) */

            if ((!REG_R4_COBERTURA.R4_NUM_SUBGRUPO.IsNumeric()))
            {

                /*" -3987- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -3988- MOVE 094 TO WS-COD-CAMPO */
                _.Move(094, WS_COD_CAMPO);

                /*" -3989- MOVE R4-NUM-SUBGRUPO TO WS-DES-CONTEUDO */
                _.Move(REG_R4_COBERTURA.R4_NUM_SUBGRUPO, WS_DES_CONTEUDO);

                /*" -3990- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -3992- END-IF. */
            }


            /*" -3994- IF (R4-NUM-SUBGRUPO EQUAL ZEROS) */

            if ((REG_R4_COBERTURA.R4_NUM_SUBGRUPO == 00))
            {

                /*" -3995- MOVE 009 TO WS-COD-ERRO */
                _.Move(009, WS_COD_ERRO);

                /*" -3996- MOVE 094 TO WS-COD-CAMPO */
                _.Move(094, WS_COD_CAMPO);

                /*" -3997- MOVE R4-NUM-SUBGRUPO TO WS-DES-CONTEUDO */
                _.Move(REG_R4_COBERTURA.R4_NUM_SUBGRUPO, WS_DES_CONTEUDO);

                /*" -3998- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4000- END-IF. */
            }


            /*" -4002- IF (R4-NUM-SEQ-REG-TP04 IS NOT NUMERIC) */

            if ((!REG_R4_COBERTURA.R4_NUM_SEQ_REG_TP04.IsNumeric()))
            {

                /*" -4003- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4004- MOVE 095 TO WS-COD-CAMPO */
                _.Move(095, WS_COD_CAMPO);

                /*" -4005- MOVE R4-NUM-SEQ-REG-TP04 TO WS-DES-CONTEUDO */
                _.Move(REG_R4_COBERTURA.R4_NUM_SEQ_REG_TP04, WS_DES_CONTEUDO);

                /*" -4006- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4008- END-IF. */
            }


            /*" -4010- MOVE 1 TO WS-POS */
            _.Move(1, WS_POS);

            /*" -4011- PERFORM UNTIL WS-POS > 6 */

            while (!(WS_POS > 6))
            {

                /*" -4013- IF (R4-COD-COBERTURA(WS-POS) IS NOT NUMERIC) */

                if ((!REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_COD_COBERTURA.IsNumeric()))
                {

                    /*" -4014- MOVE 011 TO WS-COD-ERRO */
                    _.Move(011, WS_COD_ERRO);

                    /*" -4015- MOVE 096 TO WS-COD-CAMPO */
                    _.Move(096, WS_COD_CAMPO);

                    /*" -4016- MOVE R4-COD-COBERTURA(WS-POS) TO WS-DES-CONTEUDO */
                    _.Move(REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_COD_COBERTURA, WS_DES_CONTEUDO);

                    /*" -4017- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -4018- ELSE */
                }
                else
                {


                    /*" -4019- IF (R4-COD-COBERTURA(WS-POS) > ZEROS) */

                    if ((REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_COD_COBERTURA > 00))
                    {

                        /*" -4022- IF (R4-VAL-IMP-SEGURADA(WS-POS) IS NOT NUMERIC) OR (R4-VAL-IMP-SEGURADA(WS-POS) EQUAL ZEROS) */

                        if ((!REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_VAL_IMP_SEGURADA.IsNumeric()) || (REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_VAL_IMP_SEGURADA == 00))
                        {

                            /*" -4023- MOVE 009 TO WS-COD-ERRO */
                            _.Move(009, WS_COD_ERRO);

                            /*" -4024- MOVE 097 TO WS-COD-CAMPO */
                            _.Move(097, WS_COD_CAMPO);

                            /*" -4026- MOVE R4-VAL-IMP-SEGURADA(WS-POS) TO WS-DES-CONTEU-N */
                            _.Move(REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_VAL_IMP_SEGURADA, FILLER_23.WS_DES_CONTEU_N);

                            /*" -4027- PERFORM R9979-00-MONTA-TAB-CRITICA */

                            R9979_00_MONTA_TAB_CRITICA_SECTION();

                            /*" -4029- END-IF */
                        }


                        /*" -4032- IF (R4-VAL-PRM-INDIVID(WS-POS) IS NOT NUMERIC) OR (R4-VAL-PRM-INDIVID(WS-POS) EQUAL ZEROS) */

                        if ((!REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_VAL_PRM_INDIVID.IsNumeric()) || (REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_VAL_PRM_INDIVID == 00))
                        {

                            /*" -4033- MOVE 009 TO WS-COD-ERRO */
                            _.Move(009, WS_COD_ERRO);

                            /*" -4034- MOVE 098 TO WS-COD-CAMPO */
                            _.Move(098, WS_COD_CAMPO);

                            /*" -4036- MOVE R4-VAL-PRM-INDIVID(WS-POS) TO WS-DES-CONTEU-N */
                            _.Move(REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_VAL_PRM_INDIVID, FILLER_23.WS_DES_CONTEU_N);

                            /*" -4037- PERFORM R9979-00-MONTA-TAB-CRITICA */

                            R9979_00_MONTA_TAB_CRITICA_SECTION();

                            /*" -4039- END-IF */
                        }


                        /*" -4041- IF (R4-IND-TRAT-FATURA(WS-POS) IS NOT NUMERIC) */

                        if ((!REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_IND_TRAT_FATURA.IsNumeric()))
                        {

                            /*" -4042- MOVE 011 TO WS-COD-ERRO */
                            _.Move(011, WS_COD_ERRO);

                            /*" -4043- MOVE 099 TO WS-COD-CAMPO */
                            _.Move(099, WS_COD_CAMPO);

                            /*" -4045- MOVE R4-IND-TRAT-FATURA(WS-POS) TO WS-DES-CONTEUDO */
                            _.Move(REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_IND_TRAT_FATURA, WS_DES_CONTEUDO);

                            /*" -4046- PERFORM R9979-00-MONTA-TAB-CRITICA */

                            R9979_00_MONTA_TAB_CRITICA_SECTION();

                            /*" -4048- END-IF */
                        }


                        /*" -4050- IF (R4-IND-TRAT-PREMIO(WS-POS) IS NOT NUMERIC) */

                        if ((!REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_IND_TRAT_PREMIO.IsNumeric()))
                        {

                            /*" -4051- MOVE 011 TO WS-COD-ERRO */
                            _.Move(011, WS_COD_ERRO);

                            /*" -4052- MOVE 100 TO WS-COD-CAMPO */
                            _.Move(100, WS_COD_CAMPO);

                            /*" -4054- MOVE R4-IND-TRAT-PREMIO(WS-POS) TO WS-DES-CONTEUDO */
                            _.Move(REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_IND_TRAT_PREMIO, WS_DES_CONTEUDO);

                            /*" -4055- PERFORM R9979-00-MONTA-TAB-CRITICA */

                            R9979_00_MONTA_TAB_CRITICA_SECTION();

                            /*" -4057- END-IF */
                        }


                        /*" -4059- IF (R4-PCT-COBER-BASICA(WS-POS) IS NOT NUMERIC) */

                        if ((!REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_PCT_COBER_BASICA.IsNumeric()))
                        {

                            /*" -4060- MOVE 011 TO WS-COD-ERRO */
                            _.Move(011, WS_COD_ERRO);

                            /*" -4061- MOVE 101 TO WS-COD-CAMPO */
                            _.Move(101, WS_COD_CAMPO);

                            /*" -4063- MOVE R4-PCT-COBER-BASICA(WS-POS) TO WS-DES-CONTEU-N */
                            _.Move(REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_PCT_COBER_BASICA, FILLER_23.WS_DES_CONTEU_N);

                            /*" -4064- PERFORM R9979-00-MONTA-TAB-CRITICA */

                            R9979_00_MONTA_TAB_CRITICA_SECTION();

                            /*" -4066- END-IF */
                        }


                        /*" -4069- IF (R4-VAL-LIM-MINIMO(WS-POS) IS NOT NUMERIC) OR (R4-VAL-LIM-MINIMO(WS-POS) EQUAL ZEROS) */

                        if ((!REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_VAL_LIM_MINIMO.IsNumeric()) || (REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_VAL_LIM_MINIMO == 00))
                        {

                            /*" -4070- MOVE 009 TO WS-COD-ERRO */
                            _.Move(009, WS_COD_ERRO);

                            /*" -4071- MOVE 102 TO WS-COD-CAMPO */
                            _.Move(102, WS_COD_CAMPO);

                            /*" -4073- MOVE R4-VAL-LIM-MINIMO(WS-POS) TO WS-DES-CONTEU-N */
                            _.Move(REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_VAL_LIM_MINIMO, FILLER_23.WS_DES_CONTEU_N);

                            /*" -4074- PERFORM R9979-00-MONTA-TAB-CRITICA */

                            R9979_00_MONTA_TAB_CRITICA_SECTION();

                            /*" -4076- END-IF */
                        }


                        /*" -4079- IF (R4-VAL-LIM-MAXIMO(WS-POS) IS NOT NUMERIC) OR (R4-VAL-LIM-MAXIMO(WS-POS) EQUAL ZEROS) */

                        if ((!REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_VAL_LIM_MAXIMO.IsNumeric()) || (REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_VAL_LIM_MAXIMO == 00))
                        {

                            /*" -4080- MOVE 009 TO WS-COD-ERRO */
                            _.Move(009, WS_COD_ERRO);

                            /*" -4081- MOVE 103 TO WS-COD-CAMPO */
                            _.Move(103, WS_COD_CAMPO);

                            /*" -4083- MOVE R4-VAL-LIM-MAXIMO(WS-POS) TO WS-DES-CONTEU-N */
                            _.Move(REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_VAL_LIM_MAXIMO, FILLER_23.WS_DES_CONTEU_N);

                            /*" -4084- PERFORM R9979-00-MONTA-TAB-CRITICA */

                            R9979_00_MONTA_TAB_CRITICA_SECTION();

                            /*" -4086- END-IF */
                        }


                        /*" -4087- END-IF */
                    }


                    /*" -4089- END-IF */
                }


                /*" -4090- ADD 1 TO WS-POS */
                WS_POS.Value = WS_POS + 1;

                /*" -4092- END-PERFORM. */
            }

            /*" -4093- IF (WS-COD-ERRO EQUAL ZEROS) */

            if ((WS_COD_ERRO == 00))
            {

                /*" -4094- ADD 1 TO W-IND-MOV */
                WAREA_AUXILIAR.W_IND_MOV.Value = WAREA_AUXILIAR.W_IND_MOV + 1;

                /*" -4095- MOVE REG-R4-COBERTURA TO W-TB-MOV-PORTAL(W-IND-MOV) */
                _.Move(REG_R4_COBERTURA, WAREA_AUXILIAR.W_TAB_MOV_PORTAL.W_TAB_MOV_PORTAL_0[WAREA_AUXILIAR.W_IND_MOV].W_TB_MOV_PORTAL);

                /*" -4096- MOVE 'S' TO WS-FLAG-TEM-TP4 */
                _.Move("S", WS_FLAG_TEM_TP4);

                /*" -4097- ELSE */
            }
            else
            {


                /*" -4098- MOVE 2 TO W-CRITICA-PROPOSTA */
                _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                /*" -4098- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0325_SAIDA*/

        [StopWatch]
        /*" R0330-00-MOVTO-CORRETAGEM-SECTION */
        private void R0330_00_MOVTO_CORRETAGEM_SECTION()
        {
            /*" -4109- MOVE 'R0330-00-MOVTO-CORRETAGEM    ' TO PARAGRAFO. */
            _.Move("R0330-00-MOVTO-CORRETAGEM    ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4110- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4112- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4113- INITIALIZE REG-R5-CORRETAGEM */
            _.Initialize(
                REG_R5_CORRETAGEM
            );

            /*" -4115- MOVE REG-PORTAL TO REG-R5-CORRETAGEM */
            _.Move(MOV_PORTAL?.Value, REG_R5_CORRETAGEM);

            /*" -4116- MOVE R5-NUM-PROPOSTA TO WS-NUM-PROPOSTA */
            _.Move(REG_R5_CORRETAGEM.R5_NUM_PROPOSTA, WS_NUM_PROPOSTA);

            /*" -4117- MOVE R5-NUM-SUBGRUPO TO WS-COD-SUBGRUPO */
            _.Move(REG_R5_CORRETAGEM.R5_NUM_SUBGRUPO, WS_COD_SUBGRUPO);

            /*" -4118- MOVE ZEROS TO WS-COD-ERRO */
            _.Move(0, WS_COD_ERRO);

            /*" -4119- MOVE 'ERRO' TO WS-TP-MENSAGEM */
            _.Move("ERRO", WS_TP_MENSAGEM);

            /*" -4120- INITIALIZE WS-DES-CONTEUDO */
            _.Initialize(
                WS_DES_CONTEUDO
            );

            /*" -4122- MOVE R5-NUM-SEQ-REG-TP05 TO WS-NUM-SEQ-ARQ */
            _.Move(REG_R5_CORRETAGEM.R5_NUM_SEQ_REG_TP05, WS_NUM_SEQ_ARQ);

            /*" -4125- IF (R5-NUM-PROPOSTA IS NOT NUMERIC) OR (R5-NUM-PROPOSTA EQUAL ZEROS) */

            if ((!REG_R5_CORRETAGEM.R5_NUM_PROPOSTA.IsNumeric()) || (REG_R5_CORRETAGEM.R5_NUM_PROPOSTA == 00))
            {

                /*" -4126- MOVE 009 TO WS-COD-ERRO */
                _.Move(009, WS_COD_ERRO);

                /*" -4127- MOVE 105 TO WS-COD-CAMPO */
                _.Move(105, WS_COD_CAMPO);

                /*" -4128- MOVE R5-NUM-PROPOSTA TO WS-DES-CONTEUDO */
                _.Move(REG_R5_CORRETAGEM.R5_NUM_PROPOSTA, WS_DES_CONTEUDO);

                /*" -4129- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4131- END-IF. */
            }


            /*" -4133- IF (R5-NUM-SUBGRUPO IS NOT NUMERIC) */

            if ((!REG_R5_CORRETAGEM.R5_NUM_SUBGRUPO.IsNumeric()))
            {

                /*" -4134- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4135- MOVE 106 TO WS-COD-CAMPO */
                _.Move(106, WS_COD_CAMPO);

                /*" -4136- MOVE R5-NUM-SUBGRUPO TO WS-DES-CONTEUDO */
                _.Move(REG_R5_CORRETAGEM.R5_NUM_SUBGRUPO, WS_DES_CONTEUDO);

                /*" -4137- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4139- END-IF. */
            }


            /*" -4141- IF (R5-NUM-SUBGRUPO EQUAL ZEROS) */

            if ((REG_R5_CORRETAGEM.R5_NUM_SUBGRUPO == 00))
            {

                /*" -4142- MOVE 009 TO WS-COD-ERRO */
                _.Move(009, WS_COD_ERRO);

                /*" -4143- MOVE 106 TO WS-COD-CAMPO */
                _.Move(106, WS_COD_CAMPO);

                /*" -4144- MOVE R5-NUM-SUBGRUPO TO WS-DES-CONTEUDO */
                _.Move(REG_R5_CORRETAGEM.R5_NUM_SUBGRUPO, WS_DES_CONTEUDO);

                /*" -4145- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4147- END-IF. */
            }


            /*" -4149- IF (R5-NUM-SEQ-REG-TP05 IS NOT NUMERIC) */

            if ((!REG_R5_CORRETAGEM.R5_NUM_SEQ_REG_TP05.IsNumeric()))
            {

                /*" -4150- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4151- MOVE 107 TO WS-COD-CAMPO */
                _.Move(107, WS_COD_CAMPO);

                /*" -4152- MOVE R5-NUM-SEQ-REG-TP05 TO WS-DES-CONTEUDO */
                _.Move(REG_R5_CORRETAGEM.R5_NUM_SEQ_REG_TP05, WS_DES_CONTEUDO);

                /*" -4153- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4155- END-IF. */
            }


            /*" -4156- MOVE 1 TO WS-POS */
            _.Move(1, WS_POS);

            /*" -4157- MOVE ZEROS TO WS-PCT-PARTIC-1 */
            _.Move(0, WS_PCT_PARTIC_1);

            /*" -4158- MOVE ZEROS TO WS-PCT-PARTIC-2 */
            _.Move(0, WS_PCT_PARTIC_2);

            /*" -4160- MOVE ZEROS TO WS-PCT-PARTIC-3 */
            _.Move(0, WS_PCT_PARTIC_3);

            /*" -4161- PERFORM UNTIL WS-POS > 10 */

            while (!(WS_POS > 10))
            {

                /*" -4163- IF (R5-COD-TIPO-CORR(WS-POS) IS NOT NUMERIC) */

                if ((!REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_COD_TIPO_CORR.IsNumeric()))
                {

                    /*" -4164- MOVE 011 TO WS-COD-ERRO */
                    _.Move(011, WS_COD_ERRO);

                    /*" -4165- MOVE 108 TO WS-COD-CAMPO */
                    _.Move(108, WS_COD_CAMPO);

                    /*" -4166- MOVE R5-COD-TIPO-CORR(WS-POS) TO WS-DES-CONTEUDO */
                    _.Move(REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_COD_TIPO_CORR, WS_DES_CONTEUDO);

                    /*" -4167- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -4168- ELSE */
                }
                else
                {


                    /*" -4169- IF (R5-COD-TIPO-CORR(WS-POS) > ZEROS) */

                    if ((REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_COD_TIPO_CORR > 00))
                    {

                        /*" -4171- IF (R5-COD-TIPO-CORR(WS-POS) NOT = 1 AND 2 AND 3) */

                        if ((!REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_COD_TIPO_CORR.In("1", "2", "3")))
                        {

                            /*" -4172- MOVE 012 TO WS-COD-ERRO */
                            _.Move(012, WS_COD_ERRO);

                            /*" -4173- MOVE 108 TO WS-COD-CAMPO */
                            _.Move(108, WS_COD_CAMPO);

                            /*" -4174- MOVE R5-COD-TIPO-CORR(WS-POS) TO WS-DES-CONTEUDO */
                            _.Move(REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_COD_TIPO_CORR, WS_DES_CONTEUDO);

                            /*" -4175- PERFORM R9979-00-MONTA-TAB-CRITICA */

                            R9979_00_MONTA_TAB_CRITICA_SECTION();

                            /*" -4177- END-IF */
                        }


                        /*" -4180- IF (R5-COD-CORRETOR(WS-POS) IS NOT NUMERIC) OR (R5-COD-CORRETOR(WS-POS) EQUAL ZEROS) */

                        if ((!REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_COD_CORRETOR.IsNumeric()) || (REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_COD_CORRETOR == 00))
                        {

                            /*" -4181- MOVE 009 TO WS-COD-ERRO */
                            _.Move(009, WS_COD_ERRO);

                            /*" -4182- MOVE 109 TO WS-COD-CAMPO */
                            _.Move(109, WS_COD_CAMPO);

                            /*" -4183- MOVE R5-COD-CORRETOR(WS-POS) TO WS-DES-CONTEUDO */
                            _.Move(REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_COD_CORRETOR, WS_DES_CONTEUDO);

                            /*" -4184- PERFORM R9979-00-MONTA-TAB-CRITICA */

                            R9979_00_MONTA_TAB_CRITICA_SECTION();

                            /*" -4185- ELSE */
                        }
                        else
                        {


                            /*" -4188- DISPLAY 'TIPO ' R5-COD-TIPO-CORR(WS-POS) ' COD-CORRETOR ' R5-COD-CORRETOR(WS-POS) ' PERC ' R5-PCT-COMERCIALIZ(WS-POS) */

                            $"TIPO {REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS]} COD-CORRETOR {REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS]} PERC {REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS]}"
                            .Display();

                            /*" -4189- IF (R5-COD-TIPO-CORR(WS-POS) EQUAL 1 OR 2) */

                            if ((REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_COD_TIPO_CORR.In("1", "2")))
                            {

                                /*" -4191- MOVE R5-COD-CORRETOR(WS-POS) TO PRODUTOR-COD-PRODUTOR */
                                _.Move(REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_COD_CORRETOR, PRODUTOR.DCLPRODUTORES.PRODUTOR_COD_PRODUTOR);

                                /*" -4193- PERFORM R8030-00-VERIFICA-CORRET */

                                R8030_00_VERIFICA_CORRET_SECTION();

                                /*" -4195- IF (SQLCODE EQUAL +100) */

                                if ((DB.SQLCODE == +100))
                                {

                                    /*" -4196- MOVE 014 TO WS-COD-ERRO */
                                    _.Move(014, WS_COD_ERRO);

                                    /*" -4197- MOVE 109 TO WS-COD-CAMPO */
                                    _.Move(109, WS_COD_CAMPO);

                                    /*" -4199- MOVE R5-COD-CORRETOR(WS-POS) TO WS-DES-CONTEUDO */
                                    _.Move(REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_COD_CORRETOR, WS_DES_CONTEUDO);

                                    /*" -4200- PERFORM R9979-00-MONTA-TAB-CRITICA */

                                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                                    /*" -4201- END-IF */
                                }


                                /*" -4202- ELSE */
                            }
                            else
                            {


                                /*" -4204- MOVE R5-COD-CORRETOR(WS-POS) TO FUNCICEF-NUM-MATRICULA */
                                _.Move(REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_COD_CORRETOR, FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NUM_MATRICULA);

                                /*" -4206- PERFORM R8031-00-VERIFICA-INDICADOR */

                                R8031_00_VERIFICA_INDICADOR_SECTION();

                                /*" -4208- IF (SQLCODE EQUAL +100) */

                                if ((DB.SQLCODE == +100))
                                {

                                    /*" -4209- MOVE 014 TO WS-COD-ERRO */
                                    _.Move(014, WS_COD_ERRO);

                                    /*" -4210- MOVE 109 TO WS-COD-CAMPO */
                                    _.Move(109, WS_COD_CAMPO);

                                    /*" -4212- MOVE R5-COD-CORRETOR(WS-POS) TO WS-DES-CONTEUDO */
                                    _.Move(REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_COD_CORRETOR, WS_DES_CONTEUDO);

                                    /*" -4213- PERFORM R9979-00-MONTA-TAB-CRITICA */

                                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                                    /*" -4214- END-IF */
                                }


                                /*" -4215- END-IF */
                            }


                            /*" -4217- END-IF */
                        }


                        /*" -4219- IF (R5-PCT-COMERCIALIZ(WS-POS) IS NOT NUMERIC) */

                        if ((!REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_PCT_COMERCIALIZ.IsNumeric()))
                        {

                            /*" -4220- MOVE 011 TO WS-COD-ERRO */
                            _.Move(011, WS_COD_ERRO);

                            /*" -4221- MOVE 110 TO WS-COD-CAMPO */
                            _.Move(110, WS_COD_CAMPO);

                            /*" -4223- MOVE R5-PCT-COMERCIALIZ(WS-POS) TO WS-DES-CONTEU-N */
                            _.Move(REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_PCT_COMERCIALIZ, FILLER_23.WS_DES_CONTEU_N);

                            /*" -4224- PERFORM R9979-00-MONTA-TAB-CRITICA */

                            R9979_00_MONTA_TAB_CRITICA_SECTION();

                            /*" -4226- END-IF */
                        }


                        /*" -4228- IF (R5-PCT-PARTICIPAC(WS-POS) IS NOT NUMERIC) */

                        if ((!REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_PCT_PARTICIPAC.IsNumeric()))
                        {

                            /*" -4229- MOVE 011 TO WS-COD-ERRO */
                            _.Move(011, WS_COD_ERRO);

                            /*" -4230- MOVE 111 TO WS-COD-CAMPO */
                            _.Move(111, WS_COD_CAMPO);

                            /*" -4232- MOVE R5-PCT-PARTICIPAC(WS-POS) TO WS-DES-CONTEU-N */
                            _.Move(REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_PCT_PARTICIPAC, FILLER_23.WS_DES_CONTEU_N);

                            /*" -4233- PERFORM R9979-00-MONTA-TAB-CRITICA */

                            R9979_00_MONTA_TAB_CRITICA_SECTION();

                            /*" -4234- ELSE */
                        }
                        else
                        {


                            /*" -4235- EVALUATE R5-COD-TIPO-CORR(WS-POS) */
                            switch (REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_COD_TIPO_CORR.Value)
                            {

                                /*" -4236- WHEN 1 */
                                case 1:

                                    /*" -4238- ADD R5-PCT-PARTICIPAC(WS-POS) TO WS-PCT-PARTIC-1 */
                                    WS_PCT_PARTIC_1.Value = WS_PCT_PARTIC_1 + REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_PCT_PARTICIPAC;

                                    /*" -4239- WHEN 2 */
                                    break;
                                case 2:

                                    /*" -4241- ADD R5-PCT-PARTICIPAC(WS-POS) TO WS-PCT-PARTIC-2 */
                                    WS_PCT_PARTIC_2.Value = WS_PCT_PARTIC_2 + REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_PCT_PARTICIPAC;

                                    /*" -4242- WHEN OTHER */
                                    break;
                                default:

                                    /*" -4244- ADD R5-PCT-PARTICIPAC(WS-POS) TO WS-PCT-PARTIC-3 */
                                    WS_PCT_PARTIC_3.Value = WS_PCT_PARTIC_3 + REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_PCT_PARTICIPAC;

                                    /*" -4245- END-EVALUATE */
                                    break;
                            }


                            /*" -4247- END-IF */
                        }


                        /*" -4248- END-IF */
                    }


                    /*" -4250- END-IF */
                }


                /*" -4251- ADD 1 TO WS-POS */
                WS_POS.Value = WS_POS + 1;

                /*" -4253- END-PERFORM. */
            }

            /*" -4255- IF (WS-PCT-PARTIC-1 > 100) */

            if ((WS_PCT_PARTIC_1 > 100))
            {

                /*" -4256- MOVE 028 TO WS-COD-ERRO */
                _.Move(028, WS_COD_ERRO);

                /*" -4257- MOVE 111 TO WS-COD-CAMPO */
                _.Move(111, WS_COD_CAMPO);

                /*" -4258- MOVE WS-PCT-PARTIC-1 TO WS-DES-CONTEU-N */
                _.Move(WS_PCT_PARTIC_1, FILLER_23.WS_DES_CONTEU_N);

                /*" -4259- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4261- END-IF */
            }


            /*" -4263- IF (WS-PCT-PARTIC-2 > 100) */

            if ((WS_PCT_PARTIC_2 > 100))
            {

                /*" -4264- MOVE 028 TO WS-COD-ERRO */
                _.Move(028, WS_COD_ERRO);

                /*" -4265- MOVE 111 TO WS-COD-CAMPO */
                _.Move(111, WS_COD_CAMPO);

                /*" -4266- MOVE WS-PCT-PARTIC-2 TO WS-DES-CONTEU-N */
                _.Move(WS_PCT_PARTIC_2, FILLER_23.WS_DES_CONTEU_N);

                /*" -4267- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4269- END-IF */
            }


            /*" -4271- IF (WS-PCT-PARTIC-3 > 100) */

            if ((WS_PCT_PARTIC_3 > 100))
            {

                /*" -4272- MOVE 028 TO WS-COD-ERRO */
                _.Move(028, WS_COD_ERRO);

                /*" -4273- MOVE 111 TO WS-COD-CAMPO */
                _.Move(111, WS_COD_CAMPO);

                /*" -4274- MOVE WS-PCT-PARTIC-3 TO WS-DES-CONTEU-N */
                _.Move(WS_PCT_PARTIC_3, FILLER_23.WS_DES_CONTEU_N);

                /*" -4275- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4277- END-IF */
            }


            /*" -4278- IF (WS-COD-ERRO EQUAL ZEROS) */

            if ((WS_COD_ERRO == 00))
            {

                /*" -4279- ADD 1 TO W-IND-MOV */
                WAREA_AUXILIAR.W_IND_MOV.Value = WAREA_AUXILIAR.W_IND_MOV + 1;

                /*" -4280- MOVE REG-R5-CORRETAGEM TO W-TB-MOV-PORTAL(W-IND-MOV) */
                _.Move(REG_R5_CORRETAGEM, WAREA_AUXILIAR.W_TAB_MOV_PORTAL.W_TAB_MOV_PORTAL_0[WAREA_AUXILIAR.W_IND_MOV].W_TB_MOV_PORTAL);

                /*" -4281- MOVE 'S' TO WS-FLAG-TEM-TP5 */
                _.Move("S", WS_FLAG_TEM_TP5);

                /*" -4282- ELSE */
            }
            else
            {


                /*" -4283- MOVE 2 TO W-CRITICA-PROPOSTA */
                _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                /*" -4283- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_SAIDA*/

        [StopWatch]
        /*" R0340-00-MOVTO-PLANO-CONDTEC-SECTION */
        private void R0340_00_MOVTO_PLANO_CONDTEC_SECTION()
        {
            /*" -4295- MOVE 'R0340-00-MOVTO-PLANO-CONDTEC ' TO PARAGRAFO. */
            _.Move("R0340-00-MOVTO-PLANO-CONDTEC ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4296- MOVE 'TRATA DADOS PLANOS VGAP    ' TO COMANDO. */
            _.Move("TRATA DADOS PLANOS VGAP    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4298- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4299- INITIALIZE REG-R6-PLANO-CONDTEC */
            _.Initialize(
                REG_R6_PLANO_CONDTEC
            );

            /*" -4301- MOVE REG-PORTAL TO REG-R6-PLANO-CONDTEC */
            _.Move(MOV_PORTAL?.Value, REG_R6_PLANO_CONDTEC);

            /*" -4302- MOVE R6-NUM-PROPOSTA TO WS-NUM-PROPOSTA */
            _.Move(REG_R6_PLANO_CONDTEC.R6_NUM_PROPOSTA, WS_NUM_PROPOSTA);

            /*" -4303- MOVE R6-NUM-SUBGRUPO TO WS-COD-SUBGRUPO */
            _.Move(REG_R6_PLANO_CONDTEC.R6_NUM_SUBGRUPO, WS_COD_SUBGRUPO);

            /*" -4304- MOVE ZEROS TO WS-COD-ERRO */
            _.Move(0, WS_COD_ERRO);

            /*" -4306- MOVE 'ERRO' TO WS-TP-MENSAGEM */
            _.Move("ERRO", WS_TP_MENSAGEM);

            /*" -4307- INITIALIZE WS-DES-CONTEUDO */
            _.Initialize(
                WS_DES_CONTEUDO
            );

            /*" -4309- MOVE R6-NUM-SEQ-REG-TP06 TO WS-NUM-SEQ-ARQ */
            _.Move(REG_R6_PLANO_CONDTEC.R6_NUM_SEQ_REG_TP06, WS_NUM_SEQ_ARQ);

            /*" -4312- IF (R6-NUM-PROPOSTA IS NOT NUMERIC) OR (R6-NUM-PROPOSTA EQUAL ZEROS) */

            if ((!REG_R6_PLANO_CONDTEC.R6_NUM_PROPOSTA.IsNumeric()) || (REG_R6_PLANO_CONDTEC.R6_NUM_PROPOSTA == 00))
            {

                /*" -4313- MOVE 009 TO WS-COD-ERRO */
                _.Move(009, WS_COD_ERRO);

                /*" -4314- MOVE 113 TO WS-COD-CAMPO */
                _.Move(113, WS_COD_CAMPO);

                /*" -4315- MOVE R6-NUM-PROPOSTA TO WS-DES-CONTEUDO */
                _.Move(REG_R6_PLANO_CONDTEC.R6_NUM_PROPOSTA, WS_DES_CONTEUDO);

                /*" -4316- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4318- END-IF. */
            }


            /*" -4320- IF (R6-NUM-SEQ-REG-TP06 IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_NUM_SEQ_REG_TP06.IsNumeric()))
            {

                /*" -4321- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4322- MOVE 115 TO WS-COD-CAMPO */
                _.Move(115, WS_COD_CAMPO);

                /*" -4323- MOVE R6-NUM-SEQ-REG-TP06 TO WS-DES-CONTEUDO */
                _.Move(REG_R6_PLANO_CONDTEC.R6_NUM_SEQ_REG_TP06, WS_DES_CONTEUDO);

                /*" -4324- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4326- END-IF. */
            }


            /*" -4328- IF (R6-NUM-SUBGRUPO IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_NUM_SUBGRUPO.IsNumeric()))
            {

                /*" -4329- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4330- MOVE 114 TO WS-COD-CAMPO */
                _.Move(114, WS_COD_CAMPO);

                /*" -4331- MOVE R6-NUM-SUBGRUPO TO WS-DES-CONTEUDO */
                _.Move(REG_R6_PLANO_CONDTEC.R6_NUM_SUBGRUPO, WS_DES_CONTEUDO);

                /*" -4332- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4334- END-IF. */
            }


            /*" -4336- IF (R6-NUM-SUBGRUPO EQUAL ZEROS) */

            if ((REG_R6_PLANO_CONDTEC.R6_NUM_SUBGRUPO == 00))
            {

                /*" -4337- MOVE 009 TO WS-COD-ERRO */
                _.Move(009, WS_COD_ERRO);

                /*" -4338- MOVE 114 TO WS-COD-CAMPO */
                _.Move(114, WS_COD_CAMPO);

                /*" -4339- MOVE R6-NUM-SUBGRUPO TO WS-DES-CONTEUDO */
                _.Move(REG_R6_PLANO_CONDTEC.R6_NUM_SUBGRUPO, WS_DES_CONTEUDO);

                /*" -4340- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4342- END-IF. */
            }


            /*" -4345- IF (R6-NUM-TIPO-PLANO IS NOT NUMERIC) OR (R6-NUM-TIPO-PLANO NOT EQUAL 1 AND 2 AND 3) */

            if ((!REG_R6_PLANO_CONDTEC.R6_NUM_TIPO_PLANO.IsNumeric()) || (!REG_R6_PLANO_CONDTEC.R6_NUM_TIPO_PLANO.In("1", "2", "3")))
            {

                /*" -4346- MOVE 012 TO WS-COD-ERRO */
                _.Move(012, WS_COD_ERRO);

                /*" -4347- MOVE 116 TO WS-COD-CAMPO */
                _.Move(116, WS_COD_CAMPO);

                /*" -4348- MOVE R6-NUM-TIPO-PLANO TO WS-DES-CONTEUDO */
                _.Move(REG_R6_PLANO_CONDTEC.R6_NUM_TIPO_PLANO, WS_DES_CONTEUDO);

                /*" -4349- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4351- END-IF. */
            }


            /*" -4353- IF (R6-DTA-INI-VIGENCIA EQUAL SPACES OR LOW-VALUES) */

            if ((REG_R6_PLANO_CONDTEC.R6_DTA_INI_VIGENCIA.IsLowValues()))
            {

                /*" -4354- MOVE 013 TO WS-COD-ERRO */
                _.Move(013, WS_COD_ERRO);

                /*" -4355- MOVE 117 TO WS-COD-CAMPO */
                _.Move(117, WS_COD_CAMPO);

                /*" -4356- MOVE R6-DTA-INI-VIGENCIA TO WS-DES-CONTEUDO */
                _.Move(REG_R6_PLANO_CONDTEC.R6_DTA_INI_VIGENCIA, WS_DES_CONTEUDO);

                /*" -4357- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4358- ELSE */
            }
            else
            {


                /*" -4359- MOVE R6-DTA-INI-VIGENCIA TO W-DATA-TRABALHO */
                _.Move(REG_R6_PLANO_CONDTEC.R6_DTA_INI_VIGENCIA, WAREA_AUXILIAR.W_DATA_TRABALHO);

                /*" -4361- PERFORM R8001-00-VERIFICA-DATA-VALIDA */

                R8001_00_VERIFICA_DATA_VALIDA_SECTION();

                /*" -4363- IF (SQLCODE NOT EQUAL ZEROS) */

                if ((DB.SQLCODE != 00))
                {

                    /*" -4364- MOVE 019 TO WS-COD-ERRO */
                    _.Move(019, WS_COD_ERRO);

                    /*" -4365- MOVE 117 TO WS-COD-CAMPO */
                    _.Move(117, WS_COD_CAMPO);

                    /*" -4366- MOVE R6-DTA-INI-VIGENCIA TO WS-DES-CONTEUDO */
                    _.Move(REG_R6_PLANO_CONDTEC.R6_DTA_INI_VIGENCIA, WS_DES_CONTEUDO);

                    /*" -4367- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -4368- END-IF */
                }


                /*" -4370- END-IF. */
            }


            /*" -4372- IF (R6-VAL-TAXA-AP IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_AP.IsNumeric()))
            {

                /*" -4373- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4374- MOVE 118 TO WS-COD-CAMPO */
                _.Move(118, WS_COD_CAMPO);

                /*" -4375- MOVE R6-VAL-TAXA-AP TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_AP, FILLER_23.WS_DES_CONTEU_N);

                /*" -4376- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4378- END-IF. */
            }


            /*" -4380- IF (R6-VAL-TAXA-AP-MORACID IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_AP_MORACID.IsNumeric()))
            {

                /*" -4381- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4382- MOVE 119 TO WS-COD-CAMPO */
                _.Move(119, WS_COD_CAMPO);

                /*" -4383- MOVE R6-VAL-TAXA-AP-MORACID TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_AP_MORACID, FILLER_23.WS_DES_CONTEU_N);

                /*" -4384- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4386- END-IF. */
            }


            /*" -4388- IF (R6-VAL-TAXA-AP-INVPERM IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_AP_INVPERM.IsNumeric()))
            {

                /*" -4389- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4390- MOVE 120 TO WS-COD-CAMPO */
                _.Move(120, WS_COD_CAMPO);

                /*" -4391- MOVE R6-VAL-TAXA-AP-INVPERM TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_AP_INVPERM, FILLER_23.WS_DES_CONTEU_N);

                /*" -4392- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4394- END-IF. */
            }


            /*" -4396- IF (R6-VAL-TAXA-AP-AMDS IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_AP_AMDS.IsNumeric()))
            {

                /*" -4397- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4398- MOVE 121 TO WS-COD-CAMPO */
                _.Move(121, WS_COD_CAMPO);

                /*" -4399- MOVE R6-VAL-TAXA-AP-AMDS TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_AP_AMDS, FILLER_23.WS_DES_CONTEU_N);

                /*" -4400- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4402- END-IF. */
            }


            /*" -4404- IF (R6-VAL-TAXA-AP-DH IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_AP_DH.IsNumeric()))
            {

                /*" -4405- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4406- MOVE 122 TO WS-COD-CAMPO */
                _.Move(122, WS_COD_CAMPO);

                /*" -4407- MOVE R6-VAL-TAXA-AP-DH TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_AP_DH, FILLER_23.WS_DES_CONTEU_N);

                /*" -4408- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4410- END-IF. */
            }


            /*" -4412- IF (R6-VAL-TAXA-AP-DIT IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_AP_DIT.IsNumeric()))
            {

                /*" -4413- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4414- MOVE 123 TO WS-COD-CAMPO */
                _.Move(123, WS_COD_CAMPO);

                /*" -4415- MOVE R6-VAL-TAXA-AP-DIT TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_AP_DIT, FILLER_23.WS_DES_CONTEU_N);

                /*" -4416- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4418- END-IF. */
            }


            /*" -4420- IF (R6-VAL-CARREGA-PRINC IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_CARREGA_PRINC.IsNumeric()))
            {

                /*" -4421- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4422- MOVE 124 TO WS-COD-CAMPO */
                _.Move(124, WS_COD_CAMPO);

                /*" -4423- MOVE R6-VAL-CARREGA-PRINC TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_CARREGA_PRINC, FILLER_23.WS_DES_CONTEU_N);

                /*" -4424- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4426- END-IF. */
            }


            /*" -4428- IF (R6-VAL-CARREGA-CONJ IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_CARREGA_CONJ.IsNumeric()))
            {

                /*" -4429- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4430- MOVE 125 TO WS-COD-CAMPO */
                _.Move(125, WS_COD_CAMPO);

                /*" -4431- MOVE R6-VAL-CARREGA-CONJ TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_CARREGA_CONJ, FILLER_23.WS_DES_CONTEU_N);

                /*" -4432- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4434- END-IF. */
            }


            /*" -4436- IF (R6-VAL-CARREGA-FILHO IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_CARREGA_FILHO.IsNumeric()))
            {

                /*" -4437- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4438- MOVE 126 TO WS-COD-CAMPO */
                _.Move(126, WS_COD_CAMPO);

                /*" -4439- MOVE R6-VAL-CARREGA-FILHO TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_CARREGA_FILHO, FILLER_23.WS_DES_CONTEU_N);

                /*" -4440- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4442- END-IF. */
            }


            /*" -4444- IF (R6-VAL-GARAN-ADIC-IEA IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_GARAN_ADIC_IEA.IsNumeric()))
            {

                /*" -4445- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4446- MOVE 127 TO WS-COD-CAMPO */
                _.Move(127, WS_COD_CAMPO);

                /*" -4447- MOVE R6-VAL-GARAN-ADIC-IEA TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_GARAN_ADIC_IEA, FILLER_23.WS_DES_CONTEU_N);

                /*" -4448- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4450- END-IF. */
            }


            /*" -4452- IF (R6-VAL-GARAN-ADIC-IPA IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_GARAN_ADIC_IPA.IsNumeric()))
            {

                /*" -4453- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4454- MOVE 128 TO WS-COD-CAMPO */
                _.Move(128, WS_COD_CAMPO);

                /*" -4455- MOVE R6-VAL-GARAN-ADIC-IPA TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_GARAN_ADIC_IPA, FILLER_23.WS_DES_CONTEU_N);

                /*" -4456- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4458- END-IF. */
            }


            /*" -4460- IF (R6-VAL-GARAN-ADIC-IPD IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_GARAN_ADIC_IPD.IsNumeric()))
            {

                /*" -4461- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4462- MOVE 129 TO WS-COD-CAMPO */
                _.Move(129, WS_COD_CAMPO);

                /*" -4463- MOVE R6-VAL-GARAN-ADIC-IPD TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_GARAN_ADIC_IPD, FILLER_23.WS_DES_CONTEU_N);

                /*" -4464- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4466- END-IF. */
            }


            /*" -4468- IF (R6-VAL-GARAN-ADIC-HD IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_GARAN_ADIC_HD.IsNumeric()))
            {

                /*" -4469- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4470- MOVE 130 TO WS-COD-CAMPO */
                _.Move(130, WS_COD_CAMPO);

                /*" -4471- MOVE R6-VAL-GARAN-ADIC-HD TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_GARAN_ADIC_HD, FILLER_23.WS_DES_CONTEU_N);

                /*" -4472- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4474- END-IF. */
            }


            /*" -4476- IF (R6-VAL-TAXA-DESP-ADM IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_DESP_ADM.IsNumeric()))
            {

                /*" -4477- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4478- MOVE 131 TO WS-COD-CAMPO */
                _.Move(131, WS_COD_CAMPO);

                /*" -4479- MOVE R6-VAL-TAXA-DESP-ADM TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_DESP_ADM, FILLER_23.WS_DES_CONTEU_N);

                /*" -4480- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4482- END-IF. */
            }


            /*" -4484- IF (R6-VAL-TAXA-IRB IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_IRB.IsNumeric()))
            {

                /*" -4485- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4486- MOVE 132 TO WS-COD-CAMPO */
                _.Move(132, WS_COD_CAMPO);

                /*" -4487- MOVE R6-VAL-TAXA-IRB TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_IRB, FILLER_23.WS_DES_CONTEU_N);

                /*" -4488- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4490- END-IF. */
            }


            /*" -4492- IF (R6-QTD-SAL-MORNATU IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_QTD_SAL_MORNATU.IsNumeric()))
            {

                /*" -4493- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4494- MOVE 133 TO WS-COD-CAMPO */
                _.Move(133, WS_COD_CAMPO);

                /*" -4495- MOVE R6-QTD-SAL-MORNATU TO WS-DES-CONTEUDO */
                _.Move(REG_R6_PLANO_CONDTEC.R6_QTD_SAL_MORNATU, WS_DES_CONTEUDO);

                /*" -4496- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4498- END-IF. */
            }


            /*" -4500- IF (R6-QTD-SAL-MORACID IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_QTD_SAL_MORACID.IsNumeric()))
            {

                /*" -4501- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4502- MOVE 134 TO WS-COD-CAMPO */
                _.Move(134, WS_COD_CAMPO);

                /*" -4503- MOVE R6-QTD-SAL-MORACID TO WS-DES-CONTEUDO */
                _.Move(REG_R6_PLANO_CONDTEC.R6_QTD_SAL_MORACID, WS_DES_CONTEUDO);

                /*" -4504- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4506- END-IF. */
            }


            /*" -4508- IF (R6-QTD-SAL-INVPERM IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_QTD_SAL_INVPERM.IsNumeric()))
            {

                /*" -4509- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4510- MOVE 135 TO WS-COD-CAMPO */
                _.Move(135, WS_COD_CAMPO);

                /*" -4511- MOVE R6-QTD-SAL-INVPERM TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_QTD_SAL_INVPERM, FILLER_23.WS_DES_CONTEU_N);

                /*" -4512- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4514- END-IF. */
            }


            /*" -4516- IF (R6-VAL-LIM-CAP-MORNATU IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_LIM_CAP_MORNATU.IsNumeric()))
            {

                /*" -4517- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4518- MOVE 136 TO WS-COD-CAMPO */
                _.Move(136, WS_COD_CAMPO);

                /*" -4519- MOVE R6-VAL-LIM-CAP-MORNATU TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_LIM_CAP_MORNATU, FILLER_23.WS_DES_CONTEU_N);

                /*" -4520- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4522- END-IF. */
            }


            /*" -4524- IF (R6-VAL-LIM-CAP-MORACID IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_LIM_CAP_MORACID.IsNumeric()))
            {

                /*" -4525- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4526- MOVE 137 TO WS-COD-CAMPO */
                _.Move(137, WS_COD_CAMPO);

                /*" -4527- MOVE R6-VAL-LIM-CAP-MORACID TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_LIM_CAP_MORACID, FILLER_23.WS_DES_CONTEU_N);

                /*" -4528- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4530- END-IF. */
            }


            /*" -4532- IF (R6-VAL-LIM-CAP-INVPERM IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_LIM_CAP_INVPERM.IsNumeric()))
            {

                /*" -4533- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4534- MOVE 138 TO WS-COD-CAMPO */
                _.Move(138, WS_COD_CAMPO);

                /*" -4535- MOVE R6-VAL-LIM-CAP-INVPERM TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_LIM_CAP_INVPERM, FILLER_23.WS_DES_CONTEU_N);

                /*" -4536- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4538- END-IF. */
            }


            /*" -4540- IF (R6-VAL-IMP-MORNATU IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_IMP_MORNATU.IsNumeric()))
            {

                /*" -4541- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4542- MOVE 139 TO WS-COD-CAMPO */
                _.Move(139, WS_COD_CAMPO);

                /*" -4543- MOVE R6-VAL-IMP-MORNATU TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_IMP_MORNATU, FILLER_23.WS_DES_CONTEU_N);

                /*" -4544- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4546- END-IF. */
            }


            /*" -4548- IF (R6-VAL-IMP-MORACID IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_IMP_MORACID.IsNumeric()))
            {

                /*" -4549- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4550- MOVE 140 TO WS-COD-CAMPO */
                _.Move(140, WS_COD_CAMPO);

                /*" -4551- MOVE R6-VAL-IMP-MORACID TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_IMP_MORACID, FILLER_23.WS_DES_CONTEU_N);

                /*" -4552- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4554- END-IF. */
            }


            /*" -4556- IF (R6-VAL-IMP-INVPERM IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_IMP_INVPERM.IsNumeric()))
            {

                /*" -4557- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4558- MOVE 141 TO WS-COD-CAMPO */
                _.Move(141, WS_COD_CAMPO);

                /*" -4559- MOVE R6-VAL-IMP-INVPERM TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_IMP_INVPERM, FILLER_23.WS_DES_CONTEU_N);

                /*" -4560- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4562- END-IF. */
            }


            /*" -4564- IF (R6-VAL-IMP-AMDS IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_IMP_AMDS.IsNumeric()))
            {

                /*" -4565- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4566- MOVE 142 TO WS-COD-CAMPO */
                _.Move(142, WS_COD_CAMPO);

                /*" -4567- MOVE R6-VAL-IMP-AMDS TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_IMP_AMDS, FILLER_23.WS_DES_CONTEU_N);

                /*" -4568- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4570- END-IF. */
            }


            /*" -4572- IF (R6-VAL-IMP-DH IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_IMP_DH.IsNumeric()))
            {

                /*" -4573- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4574- MOVE 143 TO WS-COD-CAMPO */
                _.Move(143, WS_COD_CAMPO);

                /*" -4575- MOVE R6-VAL-IMP-DH TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_IMP_DH, FILLER_23.WS_DES_CONTEU_N);

                /*" -4576- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4578- END-IF. */
            }


            /*" -4580- IF (R6-VAL-IMP-DIT IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_IMP_DIT.IsNumeric()))
            {

                /*" -4581- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4582- MOVE 144 TO WS-COD-CAMPO */
                _.Move(144, WS_COD_CAMPO);

                /*" -4583- MOVE R6-VAL-IMP-DIT TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_IMP_DIT, FILLER_23.WS_DES_CONTEU_N);

                /*" -4584- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4586- END-IF. */
            }


            /*" -4588- IF (R6-VAL-PRM-AP IS NOT NUMERIC) */

            if ((!REG_R6_PLANO_CONDTEC.R6_VAL_PRM_AP.IsNumeric()))
            {

                /*" -4589- MOVE 011 TO WS-COD-ERRO */
                _.Move(011, WS_COD_ERRO);

                /*" -4590- MOVE 145 TO WS-COD-CAMPO */
                _.Move(145, WS_COD_CAMPO);

                /*" -4591- MOVE R6-VAL-PRM-AP TO WS-DES-CONTEU-N */
                _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_PRM_AP, FILLER_23.WS_DES_CONTEU_N);

                /*" -4592- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -4593- ELSE */
            }
            else
            {


                /*" -4596- IF (R1-COD-PRODUTO EQUAL 8203 OR JVPRD8203) AND (R6-VAL-PRM-AP EQUAL ZEROS) */

                if ((REG_R1_SUBGRUPO.R1_COD_PRODUTO.In("8203", JVBKINCL.JV_PRODUTOS.JVPRD8203.ToString())) && (REG_R6_PLANO_CONDTEC.R6_VAL_PRM_AP == 00))
                {

                    /*" -4597- MOVE 009 TO WS-COD-ERRO */
                    _.Move(009, WS_COD_ERRO);

                    /*" -4598- MOVE 145 TO WS-COD-CAMPO */
                    _.Move(145, WS_COD_CAMPO);

                    /*" -4599- MOVE R6-VAL-PRM-AP TO WS-DES-CONTEU-N */
                    _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_PRM_AP, FILLER_23.WS_DES_CONTEU_N);

                    /*" -4600- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -4601- END-IF */
                }


                /*" -4603- END-IF. */
            }


            /*" -4604- MOVE 1 TO WS-POS */
            _.Move(1, WS_POS);

            /*" -4606- MOVE 'N' TO WS-TEM-FAIXA-LIM */
            _.Move("N", WS_TEM_FAIXA_LIM);

            /*" -4609- IF (R6-NUM-TIPO-PLANO EQUAL 1 OR 2 OR 3) AND (R1-COD-PRODUTO EQUAL 9311 OR 9354 OR JVPRD9311) */

            if ((REG_R6_PLANO_CONDTEC.R6_NUM_TIPO_PLANO.In("1", "2", "3")) && (REG_R1_SUBGRUPO.R1_COD_PRODUTO.In("9311", "9354", JVBKINCL.JV_PRODUTOS.JVPRD9311.ToString())))
            {

                /*" -4610- PERFORM UNTIL WS-POS > 06 */

                while (!(WS_POS > 06))
                {

                    /*" -4612- IF (R6-VAL-LIM-INFERIOR(WS-POS) IS NOT NUMERIC) */

                    if ((!REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_LIM_INFERIOR.IsNumeric()))
                    {

                        /*" -4613- MOVE 011 TO WS-COD-ERRO */
                        _.Move(011, WS_COD_ERRO);

                        /*" -4614- MOVE 146 TO WS-COD-CAMPO */
                        _.Move(146, WS_COD_CAMPO);

                        /*" -4615- MOVE R6-VAL-LIM-INFERIOR(WS-POS) TO WS-DES-CONTEU-N */
                        _.Move(REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_LIM_INFERIOR, FILLER_23.WS_DES_CONTEU_N);

                        /*" -4616- PERFORM R9979-00-MONTA-TAB-CRITICA */

                        R9979_00_MONTA_TAB_CRITICA_SECTION();

                        /*" -4617- ELSE */
                    }
                    else
                    {


                        /*" -4619- IF (R6-VAL-LIM-SUPERIOR(WS-POS) IS NOT NUMERIC) */

                        if ((!REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_LIM_SUPERIOR.IsNumeric()))
                        {

                            /*" -4620- MOVE 011 TO WS-COD-ERRO */
                            _.Move(011, WS_COD_ERRO);

                            /*" -4621- MOVE 147 TO WS-COD-CAMPO */
                            _.Move(147, WS_COD_CAMPO);

                            /*" -4623- MOVE R6-VAL-LIM-SUPERIOR(WS-POS) TO WS-DES-CONTEU-N */
                            _.Move(REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_LIM_SUPERIOR, FILLER_23.WS_DES_CONTEU_N);

                            /*" -4624- PERFORM R9979-00-MONTA-TAB-CRITICA */

                            R9979_00_MONTA_TAB_CRITICA_SECTION();

                            /*" -4625- ELSE */
                        }
                        else
                        {


                            /*" -4626- IF (R6-VAL-LIM-SUPERIOR(WS-POS) > ZEROS) */

                            if ((REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_LIM_SUPERIOR > 00))
                            {

                                /*" -4627- MOVE 'S' TO WS-TEM-FAIXA-LIM */
                                _.Move("S", WS_TEM_FAIXA_LIM);

                                /*" -4630- IF (R6-VAL-LIM-INFERIOR(WS-POS) > R6-VAL-LIM-SUPERIOR(WS-POS)) */

                                if ((REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_LIM_INFERIOR > REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_LIM_SUPERIOR))
                                {

                                    /*" -4631- MOVE 029 TO WS-COD-ERRO */
                                    _.Move(029, WS_COD_ERRO);

                                    /*" -4632- MOVE 146 TO WS-COD-CAMPO */
                                    _.Move(146, WS_COD_CAMPO);

                                    /*" -4634- MOVE R6-VAL-LIM-INFERIOR(WS-POS) TO WS-DES-CONTEU-N */
                                    _.Move(REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_LIM_INFERIOR, FILLER_23.WS_DES_CONTEU_N);

                                    /*" -4635- PERFORM R9979-00-MONTA-TAB-CRITICA */

                                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                                    /*" -4637- END-IF */
                                }


                                /*" -4640- IF (R6-VAL-TAXA-VG(WS-POS) IS NOT NUMERIC) OR (R6-VAL-TAXA-VG(WS-POS) EQUAL ZEROS) */

                                if ((!REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_TAXA_VG.IsNumeric()) || (REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_TAXA_VG == 00))
                                {

                                    /*" -4641- MOVE 009 TO WS-COD-ERRO */
                                    _.Move(009, WS_COD_ERRO);

                                    /*" -4642- MOVE 148 TO WS-COD-CAMPO */
                                    _.Move(148, WS_COD_CAMPO);

                                    /*" -4644- MOVE R6-VAL-TAXA-VG(WS-POS) TO WS-DES-CONTEU-N */
                                    _.Move(REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_TAXA_VG, FILLER_23.WS_DES_CONTEU_N);

                                    /*" -4645- PERFORM R9979-00-MONTA-TAB-CRITICA */

                                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                                    /*" -4647- END-IF */
                                }


                                /*" -4649- IF (R6-VAL-PRM-VG(WS-POS) IS NOT NUMERIC) */

                                if ((!REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_PRM_VG.IsNumeric()))
                                {

                                    /*" -4650- MOVE 011 TO WS-COD-ERRO */
                                    _.Move(011, WS_COD_ERRO);

                                    /*" -4651- MOVE 149 TO WS-COD-CAMPO */
                                    _.Move(149, WS_COD_CAMPO);

                                    /*" -4653- MOVE R6-VAL-PRM-VG(WS-POS) TO WS-DES-CONTEU-N */
                                    _.Move(REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_PRM_VG, FILLER_23.WS_DES_CONTEU_N);

                                    /*" -4654- PERFORM R9979-00-MONTA-TAB-CRITICA */

                                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                                    /*" -4655- MOVE ZEROS TO R6-VAL-PRM-VG(WS-POS) */
                                    _.Move(0, REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_PRM_VG);

                                    /*" -4657- END-IF */
                                }


                                /*" -4659- IF (R6-VAL-PRM-VG(WS-POS) EQUAL ZEROS) */

                                if ((REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_PRM_VG == 00))
                                {

                                    /*" -4660- MOVE 009 TO WS-COD-ERRO */
                                    _.Move(009, WS_COD_ERRO);

                                    /*" -4661- MOVE 149 TO WS-COD-CAMPO */
                                    _.Move(149, WS_COD_CAMPO);

                                    /*" -4663- MOVE R6-VAL-PRM-VG(WS-POS) TO WS-DES-CONTEU-N */
                                    _.Move(REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_PRM_VG, FILLER_23.WS_DES_CONTEU_N);

                                    /*" -4664- PERFORM R9979-00-MONTA-TAB-CRITICA */

                                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                                    /*" -4665- END-IF */
                                }


                                /*" -4666- END-IF */
                            }


                            /*" -4667- END-IF */
                        }


                        /*" -4668- END-IF */
                    }


                    /*" -4669- ADD 1 TO WS-POS */
                    WS_POS.Value = WS_POS + 1;

                    /*" -4671- END-PERFORM */
                }

                /*" -4673- IF (WS-TEM-FAIXA-LIM EQUAL 'N' ) */

                if ((WS_TEM_FAIXA_LIM == "N"))
                {

                    /*" -4674- MOVE 037 TO WS-COD-ERRO */
                    _.Move(037, WS_COD_ERRO);

                    /*" -4675- MOVE 146 TO WS-COD-CAMPO */
                    _.Move(146, WS_COD_CAMPO);

                    /*" -4676- MOVE ZEROS TO WS-DES-CONTEU-N */
                    _.Move(0, FILLER_23.WS_DES_CONTEU_N);

                    /*" -4677- PERFORM R9979-00-MONTA-TAB-CRITICA */

                    R9979_00_MONTA_TAB_CRITICA_SECTION();

                    /*" -4678- END-IF */
                }


                /*" -4680- END-IF. */
            }


            /*" -4681- IF (WS-COD-ERRO EQUAL ZEROS) */

            if ((WS_COD_ERRO == 00))
            {

                /*" -4682- ADD 1 TO W-IND-MOV */
                WAREA_AUXILIAR.W_IND_MOV.Value = WAREA_AUXILIAR.W_IND_MOV + 1;

                /*" -4683- MOVE REG-R6-PLANO-CONDTEC TO W-TB-MOV-PORTAL(W-IND-MOV) */
                _.Move(REG_R6_PLANO_CONDTEC, WAREA_AUXILIAR.W_TAB_MOV_PORTAL.W_TAB_MOV_PORTAL_0[WAREA_AUXILIAR.W_IND_MOV].W_TB_MOV_PORTAL);

                /*" -4684- MOVE 'S' TO WS-FLAG-TEM-TP6 */
                _.Move("S", WS_FLAG_TEM_TP6);

                /*" -4685- ELSE */
            }
            else
            {


                /*" -4686- MOVE 2 TO W-CRITICA-PROPOSTA */
                _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                /*" -4686- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0340_SAIDA*/

        [StopWatch]
        /*" R0360-00-VALIDA-TRAILLER-SECTION */
        private void R0360_00_VALIDA_TRAILLER_SECTION()
        {
            /*" -4695- MOVE 'R0360-00-VALIDA-TRAILLER' TO PARAGRAFO. */
            _.Move("R0360-00-VALIDA-TRAILLER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4696- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4698- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4700- MOVE RT-QTD-REG-TOTAL TO ARQSIVPF-QTDE-REG-GER */
            _.Move(REG_TRAILER.RT_QTD_REG_TOTAL, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -4701- PERFORM R2060-00-ATUALIZA-ARQSIVPF. */

            R2060_00_ATUALIZA_ARQSIVPF_SECTION();

            /*" -4703- MOVE 2 TO W-CRITICA-PROPOSTA. */
            _.Move(2, WREA88.W_CRITICA_PROPOSTA);

            /*" -4705- MOVE ZEROS TO PF087-NUM-PROPOSTA. */
            _.Move(0, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_PROPOSTA);

            /*" -4707- PERFORM R3000-00-GERAR-CNTRLE-PROC VARYING W-IND-2 FROM 1 BY 1 UNTIL W-IND-2 GREATER W-IND-1. */

            for (WAREA_AUXILIAR.W_IND_2.Value = 1; !(WAREA_AUXILIAR.W_IND_2 > WAREA_AUXILIAR.W_IND_1); WAREA_AUXILIAR.W_IND_2.Value += 1)
            {

                R3000_00_GERAR_CNTRLE_PROC_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0360_SAIDA*/

        [StopWatch]
        /*" R0400-00-GERAR-APOL-ESPEC-SECTION */
        private void R0400_00_GERAR_APOL_ESPEC_SECTION()
        {
            /*" -4716- MOVE 'R0400-00-GERAR-APOL-ESPEC' TO PARAGRAFO. */
            _.Move("R0400-00-GERAR-APOL-ESPEC", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4717- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4719- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4721- ADD 1 TO W-IND-TAB */
            WAREA_AUXILIAR.W_IND_TAB.Value = WAREA_AUXILIAR.W_IND_TAB + 1;

            /*" -4723- MOVE W-TB-MOV-PORTAL(W-IND-TAB)(1:1) TO W-TP-REGISTRO. */
            _.Move(WAREA_AUXILIAR.W_TAB_MOV_PORTAL.W_TAB_MOV_PORTAL_0[WAREA_AUXILIAR.W_IND_TAB].W_TB_MOV_PORTAL.Substring(1, 1), W_TP_REGISTRO);

            /*" -4724- EVALUATE W-TP-REGISTRO */
            switch (W_TP_REGISTRO.Value.Trim())
            {

                /*" -4725- WHEN '0' */
                case "0":

                    /*" -4726- MOVE 1 TO W-CRITICA-PROPOSTA */
                    _.Move(1, WREA88.W_CRITICA_PROPOSTA);

                    /*" -4727- WHEN '1' */
                    break;
                case "1":

                    /*" -4728- PERFORM R0450-00-CARREGA-APOL-SUBG */

                    R0450_00_CARREGA_APOL_SUBG_SECTION();

                    /*" -4729- WHEN '2' */
                    break;
                case "2":

                    /*" -4730- PERFORM R0460-00-CARREGA-ENDERECO */

                    R0460_00_CARREGA_ENDERECO_SECTION();

                    /*" -4731- WHEN '3' */
                    break;
                case "3":

                    /*" -4732- PERFORM R0470-00-CARREGA-REPRES-LEG */

                    R0470_00_CARREGA_REPRES_LEG_SECTION();

                    /*" -4733- WHEN '4' */
                    break;
                case "4":

                    /*" -4734- PERFORM R0480-00-CARREGA-COBER-ADIC */

                    R0480_00_CARREGA_COBER_ADIC_SECTION();

                    /*" -4735- WHEN '5' */
                    break;
                case "5":

                    /*" -4736- PERFORM R0490-00-CARREGA-CORRETAGEM */

                    R0490_00_CARREGA_CORRETAGEM_SECTION();

                    /*" -4737- WHEN '6' */
                    break;
                case "6":

                    /*" -4738- PERFORM R0500-00-CARREGA-PLANO-CONDTEC */

                    R0500_00_CARREGA_PLANO_CONDTEC_SECTION();

                    /*" -4739- WHEN '9' */
                    break;
                case "9":

                    /*" -4740- MOVE 1 TO W-CRITICA-PROPOSTA */
                    _.Move(1, WREA88.W_CRITICA_PROPOSTA);

                    /*" -4741- WHEN OTHER */
                    break;
                default:

                    /*" -4742- DISPLAY 'VG2600B - FIM ANORMAL' */
                    _.Display($"VG2600B - FIM ANORMAL");

                    /*" -4743- DISPLAY '          TIPO REGISTRO NAO ESPERADO' */
                    _.Display($"          TIPO REGISTRO NAO ESPERADO");

                    /*" -4745- DISPLAY '          TIPO DA TABELA..........  ' W-TP-REGISTRO */
                    _.Display($"          TIPO DA TABELA..........  {W_TP_REGISTRO}");

                    /*" -4746- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -4747- DISPLAY W-TB-MOV-PORTAL(W-IND-TAB) */
                    _.Display(WAREA_AUXILIAR.W_TAB_MOV_PORTAL.W_TAB_MOV_PORTAL_0[WAREA_AUXILIAR.W_IND_TAB]);

                    /*" -4748- GO TO R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;

                    /*" -4748- END-EVALUATE. */
                    break;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_SAIDA*/

        [StopWatch]
        /*" R0450-00-CARREGA-APOL-SUBG-SECTION */
        private void R0450_00_CARREGA_APOL_SUBG_SECTION()
        {
            /*" -4759- MOVE 'R0450-00-CARREGA-APOL-SUBG' TO PARAGRAFO. */
            _.Move("R0450-00-CARREGA-APOL-SUBG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4760- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4762- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4763- INITIALIZE REG-R1-SUBGRUPO */
            _.Initialize(
                REG_R1_SUBGRUPO
            );

            /*" -4765- MOVE W-TB-MOV-PORTAL(W-IND-TAB) TO REG-R1-SUBGRUPO */
            _.Move(WAREA_AUXILIAR.W_TAB_MOV_PORTAL.W_TAB_MOV_PORTAL_0[WAREA_AUXILIAR.W_IND_TAB].W_TB_MOV_PORTAL, REG_R1_SUBGRUPO);

            /*" -4766- MOVE R1-NUM-CGC-CNPJ TO CLIENTES-CGCCPF */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_CGC_CNPJ, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);

            /*" -4768- PERFORM R8012-00-VERIFICA-CLIENTE */

            R8012_00_VERIFICA_CLIENTE_SECTION();

            /*" -4769- IF (SQLCODE EQUAL +100) */

            if ((DB.SQLCODE == +100))
            {

                /*" -4770- PERFORM R0530-00-INSERT-CLIENTE */

                R0530_00_INSERT_CLIENTE_SECTION();

                /*" -4771- ELSE */
            }
            else
            {


                /*" -4772- IF R1-COD-PORTE-EMP NOT = 0 */

                if (REG_R1_SUBGRUPO.R1_COD_PORTE_EMP != 0)
                {

                    /*" -4773- PERFORM DB050-UPDATE-CLIENTES */

                    DB050_UPDATE_CLIENTES_SECTION();

                    /*" -4774- ELSE */
                }
                else
                {


                    /*" -4776- DISPLAY 'NAO INSERT/UPDATE CLIENTE >>> ' R1-COD-PORTE-EMP */
                    _.Display($"NAO INSERT/UPDATE CLIENTE >>> {REG_R1_SUBGRUPO.R1_COD_PORTE_EMP}");

                    /*" -4777- END-IF */
                }


                /*" -4779- END-IF. */
            }


            /*" -4780- IF (R1-NUM-SUBGRUPO EQUAL 1) */

            if ((REG_R1_SUBGRUPO.R1_NUM_SUBGRUPO == 1))
            {

                /*" -4781- PERFORM R0451-00-INCLUIR-APOLICE */

                R0451_00_INCLUIR_APOLICE_SECTION();

                /*" -4782- ELSE */
            }
            else
            {


                /*" -4783- MOVE R1-NUM-SUBGRUPO TO SUBGVGAP-COD-SUBGRUPO */
                _.Move(REG_R1_SUBGRUPO.R1_NUM_SUBGRUPO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

                /*" -4784- PERFORM R0452-00-INCLUIR-SUBGRUPO */

                R0452_00_INCLUIR_SUBGRUPO_SECTION();

                /*" -4786- END-IF. */
            }


            /*" -4787- IF (SUBGVGAP-COD-SUBGRUPO > ZEROS) */

            if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO > 00))
            {

                /*" -4788- PERFORM R0458-00-INCLUIR-SOL-FATURA */

                R0458_00_INCLUIR_SOL_FATURA_SECTION();

                /*" -4790- END-IF. */
            }


            /*" -4792- PERFORM DB030-INSERT-VG-COMPL-CLI-EMP */

            DB030_INSERT_VG_COMPL_CLI_EMP_SECTION();

            /*" -4793- IF SQLCODE = -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -4794- PERFORM DB035-UPDATE-VG-COMPL-CLI-EMP */

                DB035_UPDATE_VG_COMPL_CLI_EMP_SECTION();

                /*" -4795- END-IF */
            }


            /*" -4795- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0451-00-INCLUIR-APOLICE-SECTION */
        private void R0451_00_INCLUIR_APOLICE_SECTION()
        {
            /*" -4803- MOVE 'R0451-00-INCLUIR-APOLICE' TO PARAGRAFO. */
            _.Move("R0451-00-INCLUIR-APOLICE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4804- MOVE 'INCLUIR' TO COMANDO. */
            _.Move("INCLUIR", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4806- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4813- MOVE R1-COD-PRODUTO TO WS-COD-PRODUTO */
            _.Move(REG_R1_SUBGRUPO.R1_COD_PRODUTO, WS_COD_PRODUTO);

            /*" -4815- MOVE R1-COD-PRODUTO TO PRODUTO-COD-PRODUTO. */
            _.Move(REG_R1_SUBGRUPO.R1_COD_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);

            /*" -4817- PERFORM R7000-JV1-BUSCA-RAMO. */

            R7000_JV1_BUSCA_RAMO_SECTION();

            /*" -4819- MOVE PRODUTO-RAMO-EMISSOR TO RAMOCOMP-RAMO-EMISSOR */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_RAMO_EMISSOR, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR);

            /*" -4824- PERFORM R8007-00-GERAR-MAX-APOLICE */

            R8007_00_GERAR_MAX_APOLICE_SECTION();

            /*" -4829- STRING R1-DTA-INI-VIGENCIA(05:04) '-' R1-DTA-INI-VIGENCIA(03:02) '-' R1-DTA-INI-VIGENCIA(01:02) DELIMITED BY SIZE INTO WS-DTA-INI-VIGENCIA */
            #region STRING
            var spl4 = REG_R1_SUBGRUPO.R1_DTA_INI_VIGENCIA.Substring(05, 04).GetMoveValues();
            spl4 += "-";
            var spl5 = REG_R1_SUBGRUPO.R1_DTA_INI_VIGENCIA.Substring(03, 02).GetMoveValues();
            spl5 += "-";
            var spl6 = REG_R1_SUBGRUPO.R1_DTA_INI_VIGENCIA.Substring(01, 02).GetMoveValues();
            var results7 = spl4 + spl5 + spl6;
            _.Move(results7, WS_DTA_INI_VIGENCIA);
            #endregion

            /*" -4830- PERFORM R8008-00-PESQUISA-RAMO-COMPL */

            R8008_00_PESQUISA_RAMO_COMPL_SECTION();

            /*" -4831- MOVE CLIENTES-COD-CLIENTE TO APOLICES-COD-CLIENTE */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE, APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE);

            /*" -4832- MOVE ZEROS TO APOLICES-NUM-ITEM */
            _.Move(0, APOLICES.DCLAPOLICES.APOLICES_NUM_ITEM);

            /*" -4833- MOVE ZEROS TO APOLICES-COD-MODALIDADE */
            _.Move(0, APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE);

            /*" -4834- MOVE FONTES-ORGAO-EMISSOR TO APOLICES-ORGAO-EMISSOR */
            _.Move(FONTES.DCLFONTES.FONTES_ORGAO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR);

            /*" -4835- MOVE RAMOCOMP-RAMO-EMISSOR TO APOLICES-RAMO-EMISSOR */
            _.Move(RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);

            /*" -4836- MOVE WS-COD-PRODUTO TO APOLICES-COD-PRODUTO */
            _.Move(WS_COD_PRODUTO, APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO);

            /*" -4837- MOVE ZEROS TO APOLICES-NUM-APOL-ANTERIOR */
            _.Move(0, APOLICES.DCLAPOLICES.APOLICES_NUM_APOL_ANTERIOR);

            /*" -4838- MOVE ZEROS TO APOLICES-NUM-BILHETE */
            _.Move(0, APOLICES.DCLAPOLICES.APOLICES_NUM_BILHETE);

            /*" -4839- MOVE '1' TO APOLICES-TIPO-SEGURO */
            _.Move("1", APOLICES.DCLAPOLICES.APOLICES_TIPO_SEGURO);

            /*" -4840- MOVE R1-NUM-TIPO-APOL TO APOLICES-TIPO-APOLICE */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_TIPO_APOL, APOLICES.DCLAPOLICES.APOLICES_TIPO_APOLICE);

            /*" -4841- MOVE '2' TO APOLICES-TIPO-CALCULO */
            _.Move("2", APOLICES.DCLAPOLICES.APOLICES_TIPO_CALCULO);

            /*" -4842- MOVE 'N' TO APOLICES-IND-SORTEIO */
            _.Move("N", APOLICES.DCLAPOLICES.APOLICES_IND_SORTEIO);

            /*" -4843- MOVE ZEROS TO APOLICES-NUM-ATA */
            _.Move(0, APOLICES.DCLAPOLICES.APOLICES_NUM_ATA);

            /*" -4844- MOVE ZEROS TO APOLICES-ANO-ATA */
            _.Move(0, APOLICES.DCLAPOLICES.APOLICES_ANO_ATA);

            /*" -4845- MOVE SPACES TO APOLICES-IND-ENDOS-MANUAL */
            _.Move("", APOLICES.DCLAPOLICES.APOLICES_IND_ENDOS_MANUAL);

            /*" -4846- MOVE ZEROS TO APOLICES-PCT-DESC-PREMIO */
            _.Move(0, APOLICES.DCLAPOLICES.APOLICES_PCT_DESC_PREMIO);

            /*" -4847- MOVE RAMOCOMP-PCT-IOCC-RAMO TO APOLICES-PCT-IOCC */
            _.Move(RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO, APOLICES.DCLAPOLICES.APOLICES_PCT_IOCC);

            /*" -4848- MOVE R1-COD-TP-COSSEG-CED TO APOLICES-TIPO-COSSEGURO-CED */
            _.Move(REG_R1_SUBGRUPO.R1_COD_TP_COSSEG_CED, APOLICES.DCLAPOLICES.APOLICES_TIPO_COSSEGURO_CED);

            /*" -4849- MOVE ZEROS TO APOLICES-QTD-COSSEGURADORA */
            _.Move(0, APOLICES.DCLAPOLICES.APOLICES_QTD_COSSEGURADORA);

            /*" -4851- MOVE ZEROS TO APOLICES-PCT-COSSEGURO-CED */
            _.Move(0, APOLICES.DCLAPOLICES.APOLICES_PCT_COSSEGURO_CED);

            /*" -4853- PERFORM R0531-00-INSERT-APOLICE. */

            R0531_00_INSERT_APOLICE_SECTION();

            /*" -4854- MOVE ZEROS TO SUBGVGAP-COD-SUBGRUPO */
            _.Move(0, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

            /*" -4856- PERFORM R0452-00-INCLUIR-SUBGRUPO. */

            R0452_00_INCLUIR_SUBGRUPO_SECTION();

            /*" -4857- MOVE R1-NUM-SUBGRUPO TO SUBGVGAP-COD-SUBGRUPO */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_SUBGRUPO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

            /*" -4859- PERFORM R0532-00-INSERT-SUBGRUPO */

            R0532_00_INSERT_SUBGRUPO_SECTION();

            /*" -4860- PERFORM R0453-00-INCLUIR-ENDOSSOS. */

            R0453_00_INCLUIR_ENDOSSOS_SECTION();

            /*" -4861- PERFORM R0454-00-INCLUIR-PARCELAS. */

            R0454_00_INCLUIR_PARCELAS_SECTION();

            /*" -4862- PERFORM R0455-00-INCLUIR-HIST-PARC. */

            R0455_00_INCLUIR_HIST_PARC_SECTION();

            /*" -4865- PERFORM R0456-00-INCLUIR-APOL-COBER. */

            R0456_00_INCLUIR_APOL_COBER_SECTION();

            /*" -4866- MOVE R1-NUM-PROPOSTA TO CONVERSI-NUM-PROPOSTA-SIVPF. */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_PROPOSTA, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);

            /*" -4868- PERFORM R0459-00-CONSULTA-CONV-SICOB. */

            R0459_00_CONSULTA_CONV_SICOB_SECTION();

            /*" -4869- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4870- PERFORM R0457-00-INCLUIR-CONV-SICOB */

                R0457_00_INCLUIR_CONV_SICOB_SECTION();

                /*" -4871- ELSE */
            }
            else
            {


                /*" -4872- PERFORM R0459-00-UPDATE-CONV-SICOB */

                R0459_00_UPDATE_CONV_SICOB_SECTION();

                /*" -4872- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0451_99_SAIDA*/

        [StopWatch]
        /*" R0452-00-INCLUIR-SUBGRUPO-SECTION */
        private void R0452_00_INCLUIR_SUBGRUPO_SECTION()
        {
            /*" -4881- MOVE 'R0452-00-INCLUIR-SUBGRU' TO PARAGRAFO. */
            _.Move("R0452-00-INCLUIR-SUBGRU", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4882- MOVE 'INCLUIR' TO COMANDO. */
            _.Move("INCLUIR", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4887- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4892- STRING R1-DTA-INI-VIGENCIA(05:04) '-' R1-DTA-INI-VIGENCIA(03:02) '-' R1-DTA-INI-VIGENCIA(01:02) DELIMITED BY SIZE INTO WS-DTA-INI-VIGENCIA */
            #region STRING
            var spl7 = REG_R1_SUBGRUPO.R1_DTA_INI_VIGENCIA.Substring(05, 04).GetMoveValues();
            spl7 += "-";
            var spl8 = REG_R1_SUBGRUPO.R1_DTA_INI_VIGENCIA.Substring(03, 02).GetMoveValues();
            spl8 += "-";
            var spl9 = REG_R1_SUBGRUPO.R1_DTA_INI_VIGENCIA.Substring(01, 02).GetMoveValues();
            var results10 = spl7 + spl8 + spl9;
            _.Move(results10, WS_DTA_INI_VIGENCIA);
            #endregion

            /*" -4893- MOVE WS-DTA-INI-VIGENCIA TO W-DATA-SQL */
            _.Move(WS_DTA_INI_VIGENCIA, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -4894- PERFORM R8009-00-CALCULA-FIM-VIGENCIA */

            R8009_00_CALCULA_FIM_VIGENCIA_SECTION();

            /*" -4896- MOVE W-DATA-SQL TO WS-DTA-TER-VIGENCIA */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, WS_DTA_TER_VIGENCIA);

            /*" -4897- MOVE APOLICES-NUM-APOLICE TO SUBGVGAP-NUM-APOLICE */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

            /*" -4898- IF R1-NUM-APOLICE NOT EQUAL ZEROS */

            if (REG_R1_SUBGRUPO.R1_NUM_APOLICE != 00)
            {

                /*" -4899- MOVE R1-NUM-APOLICE TO SUBGVGAP-NUM-APOLICE */
                _.Move(REG_R1_SUBGRUPO.R1_NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

                /*" -4900- END-IF */
            }


            /*" -4901- MOVE CLIENTES-COD-CLIENTE TO SUBGVGAP-COD-CLIENTE */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE);

            /*" -4902- MOVE R1-COD-CLASSE-APOL TO SUBGVGAP-CLASSE-APOLICE */
            _.Move(REG_R1_SUBGRUPO.R1_COD_CLASSE_APOL, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_CLASSE_APOLICE);

            /*" -4903- MOVE FONTES-ORGAO-EMISSOR TO SUBGVGAP-COD-FONTE */
            _.Move(FONTES.DCLFONTES.FONTES_ORGAO_EMISSOR, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE);

            /*" -4904- MOVE R1-COD-TP-FATURA TO SUBGVGAP-TIPO-FATURAMENTO */
            _.Move(REG_R1_SUBGRUPO.R1_COD_TP_FATURA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_FATURAMENTO);

            /*" -4905- MOVE R1-IND-FORMA-FATURA TO SUBGVGAP-FORMA-FATURAMENTO */
            _.Move(REG_R1_SUBGRUPO.R1_IND_FORMA_FATURA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_FORMA_FATURAMENTO);

            /*" -4906- MOVE R1-IND-FORMA-AVERB TO SUBGVGAP-FORMA-AVERBACAO */
            _.Move(REG_R1_SUBGRUPO.R1_IND_FORMA_AVERB, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_FORMA_AVERBACAO);

            /*" -4907- MOVE R1-COD-TP-PLANO TO SUBGVGAP-TIPO-PLANO */
            _.Move(REG_R1_SUBGRUPO.R1_COD_TP_PLANO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO);

            /*" -4908- MOVE R1-COD-PERIO-FATURA TO SUBGVGAP-PERI-FATURAMENTO */
            _.Move(REG_R1_SUBGRUPO.R1_COD_PERIO_FATURA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO);

            /*" -4909- MOVE ZEROS TO SUBGVGAP-PERI-RENOVACAO */
            _.Move(0, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_RENOVACAO);

            /*" -4910- MOVE ZEROS TO SUBGVGAP-PERI-RETROATI-INC */
            _.Move(0, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_RETROATI_INC);

            /*" -4911- MOVE ZEROS TO SUBGVGAP-PERI-RETROATI-CAN */
            _.Move(0, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_RETROATI_CAN);

            /*" -4912- MOVE 1 TO SUBGVGAP-OCORR-ENDERECO */
            _.Move(1, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OCORR_ENDERECO);

            /*" -4913- MOVE 1 TO SUBGVGAP-OCORR-END-COBRAN */
            _.Move(1, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OCORR_END_COBRAN);

            /*" -4914- MOVE R1-NUM-BCO-COBR TO SUBGVGAP-BCO-COBRANCA */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_BCO_COBR, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_BCO_COBRANCA);

            /*" -4915- MOVE R1-NUM-AGE-COBR TO SUBGVGAP-AGE-COBRANCA */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_AGE_COBR, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_AGE_COBRANCA);

            /*" -4916- MOVE R1-NUM-DV-AGE-COBR TO SUBGVGAP-DAC-COBRANCA */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_DV_AGE_COBR, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DAC_COBRANCA);

            /*" -4917- MOVE R1-COD-TP-FATURA TO SUBGVGAP-TIPO-COBRANCA */
            _.Move(REG_R1_SUBGRUPO.R1_COD_TP_FATURA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_COBRANCA);

            /*" -4918- MOVE ZEROS TO SUBGVGAP-COD-PAG-ANGARIACAO */
            _.Move(0, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_PAG_ANGARIACAO);

            /*" -4919- MOVE R1-PER-COBERVG-CONJ TO SUBGVGAP-PCT-CONJUGE-VG */
            _.Move(REG_R1_SUBGRUPO.R1_PER_COBERVG_CONJ, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PCT_CONJUGE_VG);

            /*" -4920- MOVE R1-PER-COBERAP-CONJ TO SUBGVGAP-PCT-CONJUGE-AP */
            _.Move(REG_R1_SUBGRUPO.R1_PER_COBERAP_CONJ, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PCT_CONJUGE_AP);

            /*" -4921- MOVE R1-IND-OP-COBERTUR TO SUBGVGAP-OPCAO-COBERTURA */
            _.Move(REG_R1_SUBGRUPO.R1_IND_OP_COBERTUR, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_COBERTURA);

            /*" -4922- MOVE R1-IND-OP-CORRETAG TO SUBGVGAP-OPCAO-CORRETAGEM */
            _.Move(REG_R1_SUBGRUPO.R1_IND_OP_CORRETAG, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CORRETAGEM);

            /*" -4923- MOVE R1-IND-VALID-MATRC TO SUBGVGAP-IND-CONSISTE-MATRI */
            _.Move(REG_R1_SUBGRUPO.R1_IND_VALID_MATRC, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_CONSISTE_MATRI);

            /*" -4924- MOVE R1-IND-PLANO-ASSOC TO SUBGVGAP-IND-PLANO-ASSOCIA */
            _.Move(REG_R1_SUBGRUPO.R1_IND_PLANO_ASSOC, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_PLANO_ASSOCIA);

            /*" -4925- MOVE '0' TO SUBGVGAP-SIT-REGISTRO */
            _.Move("0", SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_SIT_REGISTRO);

            /*" -4926- MOVE R1-IND-OPCAO-CONJUGE TO SUBGVGAP-OPCAO-CONJUGE */
            _.Move(REG_R1_SUBGRUPO.R1_IND_OPCAO_CONJUGE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE);

            /*" -4927- MOVE R1-NUM-TIPO-APOL TO SUBGVGAP-TIPO-SUBGRUPO */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_TIPO_APOL, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_SUBGRUPO);

            /*" -4928- MOVE SISTEMAS-DATA-MOV-ABERTO TO SUBGVGAP-DATA-INCLUSAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_INCLUSAO);

            /*" -4929- MOVE WS-DTA-INI-VIGENCIA TO SUBGVGAP-DATA-INIVIGENCIA */
            _.Move(WS_DTA_INI_VIGENCIA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_INIVIGENCIA);

            /*" -4930- MOVE WS-DTA-TER-VIGENCIA TO SUBGVGAP-DATA-TERVIGENCIA */
            _.Move(WS_DTA_TER_VIGENCIA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_TERVIGENCIA);

            /*" -4931- MOVE R1-IND-COBRA-IOF TO SUBGVGAP-IND-IOF */
            _.Move(REG_R1_SUBGRUPO.R1_IND_COBRA_IOF, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_IOF);

            /*" -4933- MOVE '1' TO SUBGVGAP-TIPO-POSTAGEM */
            _.Move("1", SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_POSTAGEM);

            /*" -4934- IF R1-NUM-SUBGRUPO GREATER 1 */

            if (REG_R1_SUBGRUPO.R1_NUM_SUBGRUPO > 1)
            {

                /*" -4935- MOVE R1-NUM-PROPOSTA TO CONVERSI-NUM-PROPOSTA-SIVPF */
                _.Move(REG_R1_SUBGRUPO.R1_NUM_PROPOSTA, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);

                /*" -4937- PERFORM R0459-00-CONSULTA-CONV-SICOB */

                R0459_00_CONSULTA_CONV_SICOB_SECTION();

                /*" -4938- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4939- PERFORM R0457-00-INCLUIR-CONV-SICOB */

                    R0457_00_INCLUIR_CONV_SICOB_SECTION();

                    /*" -4940- ELSE */
                }
                else
                {


                    /*" -4941- PERFORM R0459-00-UPDATE-CONV-SICOB */

                    R0459_00_UPDATE_CONV_SICOB_SECTION();

                    /*" -4942- END-IF */
                }


                /*" -4944- END-IF */
            }


            /*" -4945- PERFORM R0532-00-INSERT-SUBGRUPO */

            R0532_00_INSERT_SUBGRUPO_SECTION();

            /*" -4945- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0452_99_SAIDA*/

        [StopWatch]
        /*" R0453-00-INCLUIR-ENDOSSOS-SECTION */
        private void R0453_00_INCLUIR_ENDOSSOS_SECTION()
        {
            /*" -4954- MOVE 'R0453-00-INCLUIR-ENDOSSO' TO PARAGRAFO. */
            _.Move("R0453-00-INCLUIR-ENDOSSO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4955- MOVE 'INCLUIR' TO COMANDO. */
            _.Move("INCLUIR", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4960- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4962- INITIALIZE W-FIM-FONTE */
            _.Initialize(
                WAREA_AUXILIAR.W_FIM_FONTE
            );

            /*" -4964- MOVE 1 TO WH-QTD-ULT-PROP */
            _.Move(1, WH_QTD_ULT_PROP);

            /*" -4965- PERFORM UNTIL W-FIM-FONTE = 'FIM' */

            while (!(WAREA_AUXILIAR.W_FIM_FONTE == "FIM"))
            {

                /*" -4966- PERFORM R8002-00-VERIFICA-FONTES */

                R8002_00_VERIFICA_FONTES_SECTION();

                /*" -4967- IF SQLCODE = +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -4968- MOVE 'FIM' TO W-FIM-FONTE */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_FONTE);

                    /*" -4969- ELSE */
                }
                else
                {


                    /*" -4970- PERFORM DB010-ACESSA-ENDOSSOS */

                    DB010_ACESSA_ENDOSSOS_SECTION();

                    /*" -4971- IF SQLCODE = +100 */

                    if (DB.SQLCODE == +100)
                    {

                        /*" -4972- MOVE 'FIM' TO W-FIM-FONTE */
                        _.Move("FIM", WAREA_AUXILIAR.W_FIM_FONTE);

                        /*" -4973- ELSE */
                    }
                    else
                    {


                        /*" -4974- ADD 1 TO WH-QTD-ULT-PROP */
                        WH_QTD_ULT_PROP.Value = WH_QTD_ULT_PROP + 1;

                        /*" -4977- DISPLAY 'R0453-JAH EXISTE ENDOSSO COM ' ' COD-FONTE=' ENDOSSOS-COD-FONTE ' NUM-PROPOSTA=' ENDOSSOS-NUM-PROPOSTA */

                        $"R0453-JAH EXISTE ENDOSSO COM  COD-FONTE={ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE} NUM-PROPOSTA={ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA}"
                        .Display();

                        /*" -4978- END-IF */
                    }


                    /*" -4979- END-IF */
                }


                /*" -4983- END-PERFORM */
            }

            /*" -4987- PERFORM DB020-UPDATE-FONTES */

            DB020_UPDATE_FONTES_SECTION();

            /*" -4991- PERFORM R8010-00-PESQUISA-MOEDAS */

            R8010_00_PESQUISA_MOEDAS_SECTION();

            /*" -4992- MOVE APOLICES-NUM-APOLICE TO ENDOSSOS-NUM-APOLICE */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -4993- IF R1-NUM-APOLICE NOT EQUAL ZEROS */

            if (REG_R1_SUBGRUPO.R1_NUM_APOLICE != 00)
            {

                /*" -4994- MOVE R1-NUM-APOLICE TO ENDOSSOS-NUM-APOLICE */
                _.Move(REG_R1_SUBGRUPO.R1_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

                /*" -4995- END-IF */
            }


            /*" -4996- MOVE ZEROS TO ENDOSSOS-NUM-ENDOSSO */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -4997- MOVE RAMOCOMP-RAMO-EMISSOR TO ENDOSSOS-RAMO-EMISSOR */
            _.Move(RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);

            /*" -4998- MOVE APOLICES-COD-PRODUTO TO ENDOSSOS-COD-PRODUTO */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);

            /*" -4999- MOVE ZEROS TO ENDOSSOS-COD-SUBGRUPO */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO);

            /*" -5000- MOVE FONTES-ORGAO-EMISSOR TO ENDOSSOS-COD-FONTE */
            _.Move(FONTES.DCLFONTES.FONTES_ORGAO_EMISSOR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);

            /*" -5001- MOVE FONTES-ULT-PROP-AUTOMAT TO ENDOSSOS-NUM-PROPOSTA */
            _.Move(FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA);

            /*" -5002- MOVE SISTEMAS-DATA-MOV-ABERTO TO ENDOSSOS-DATA-PROPOSTA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA);

            /*" -5003- MOVE SISTEMAS-DATA-MOV-ABERTO TO ENDOSSOS-DATA-LIBERACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_LIBERACAO);

            /*" -5004- MOVE SISTEMAS-DATA-MOV-ABERTO TO ENDOSSOS-DATA-EMISSAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO);

            /*" -5005- MOVE ZEROS TO ENDOSSOS-NUM-RCAP */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP);

            /*" -5006- MOVE ZEROS TO ENDOSSOS-VAL-RCAP */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP);

            /*" -5007- MOVE ZEROS TO ENDOSSOS-BCO-RCAP */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_RCAP);

            /*" -5008- MOVE R1-COD-AG-PRODUTORA TO ENDOSSOS-AGE-RCAP */
            _.Move(REG_R1_SUBGRUPO.R1_COD_AG_PRODUTORA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP);

            /*" -5009- MOVE SPACES TO ENDOSSOS-DAC-RCAP */
            _.Move("", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_RCAP);

            /*" -5010- MOVE SPACES TO ENDOSSOS-TIPO-RCAP */
            _.Move("", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_RCAP);

            /*" -5011- MOVE R1-NUM-BCO-COBR TO ENDOSSOS-BCO-COBRANCA */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_BCO_COBR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_COBRANCA);

            /*" -5012- MOVE R1-NUM-AGE-COBR TO ENDOSSOS-AGE-COBRANCA */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_AGE_COBR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA);

            /*" -5013- MOVE R1-NUM-DV-AGE-COBR TO ENDOSSOS-DAC-COBRANCA */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_DV_AGE_COBR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_COBRANCA);

            /*" -5014- MOVE WS-DTA-INI-VIGENCIA TO ENDOSSOS-DATA-INIVIGENCIA */
            _.Move(WS_DTA_INI_VIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

            /*" -5015- MOVE WS-DTA-TER-VIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
            _.Move(WS_DTA_TER_VIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

            /*" -5016- MOVE ZEROS TO ENDOSSOS-PLANO-SEGURO */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PLANO_SEGURO);

            /*" -5017- MOVE ZEROS TO ENDOSSOS-PCT-ENTRADA */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ENTRADA);

            /*" -5018- MOVE ZEROS TO ENDOSSOS-PCT-ADIC-FRACIO */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ADIC_FRACIO);

            /*" -5019- MOVE ZEROS TO ENDOSSOS-QTD-DIAS-PRIMEIRA */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_DIAS_PRIMEIRA);

            /*" -5020- MOVE ZEROS TO ENDOSSOS-QTD-PARCELAS */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PARCELAS);

            /*" -5021- MOVE ZEROS TO ENDOSSOS-QTD-PRESTACOES */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PRESTACOES);

            /*" -5022- MOVE R1-QTD-VIDA-CONTRAT TO ENDOSSOS-QTD-ITENS */
            _.Move(REG_R1_SUBGRUPO.R1_QTD_VIDA_CONTRAT, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_ITENS);

            /*" -5023- MOVE SPACES TO ENDOSSOS-COD-TEXTO-PADRAO */
            _.Move("", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_TEXTO_PADRAO);

            /*" -5024- MOVE SPACES TO ENDOSSOS-COD-ACEITACAO */
            _.Move("", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_ACEITACAO);

            /*" -5025- MOVE MOEDAS-COD-MOEDA TO ENDOSSOS-COD-MOEDA-IMP */
            _.Move(MOEDAS.DCLMOEDAS.MOEDAS_COD_MOEDA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_IMP);

            /*" -5026- MOVE MOEDAS-COD-MOEDA TO ENDOSSOS-COD-MOEDA-PRM */
            _.Move(MOEDAS.DCLMOEDAS.MOEDAS_COD_MOEDA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM);

            /*" -5027- MOVE '0' TO ENDOSSOS-TIPO-ENDOSSO */
            _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO);

            /*" -5028- MOVE 'VG2600B' TO ENDOSSOS-COD-USUARIO */
            _.Move("VG2600B", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO);

            /*" -5029- MOVE 1 TO ENDOSSOS-OCORR-ENDERECO */
            _.Move(1, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO);

            /*" -5030- MOVE '0' TO ENDOSSOS-SIT-REGISTRO */
            _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO);

            /*" -5032- MOVE R1-COD-TP-CORRECAO TO ENDOSSOS-TIPO-CORRECAO */
            _.Move(REG_R1_SUBGRUPO.R1_COD_TP_CORRECAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_CORRECAO);

            /*" -5033- IF (RAMOCOMP-IND-ISENCAO-CUSTO EQUAL '0' OR '2' ) */

            if ((RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_IND_ISENCAO_CUSTO.In("0", "2")))
            {

                /*" -5034- MOVE 'N' TO ENDOSSOS-ISENTA-CUSTO */
                _.Move("N", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_ISENTA_CUSTO);

                /*" -5035- ELSE */
            }
            else
            {


                /*" -5036- MOVE 'S' TO ENDOSSOS-ISENTA-CUSTO */
                _.Move("S", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_ISENTA_CUSTO);

                /*" -5038- END-IF */
            }


            /*" -5038- PERFORM R0533-00-INSERT-ENDOSSOS. */

            R0533_00_INSERT_ENDOSSOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0453_99_SAIDA*/

        [StopWatch]
        /*" R0454-00-INCLUIR-PARCELAS-SECTION */
        private void R0454_00_INCLUIR_PARCELAS_SECTION()
        {
            /*" -5047- MOVE 'R0454-00-INCLUIR-PARCELA' TO PARAGRAFO. */
            _.Move("R0454-00-INCLUIR-PARCELA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5048- MOVE 'INCLUIR' TO COMANDO. */
            _.Move("INCLUIR", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5050- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5051- MOVE APOLICES-NUM-APOLICE TO PARCELAS-NUM-APOLICE */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE, PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE);

            /*" -5052- IF WS-NUM-APOLICE NOT EQUAL ZEROS */

            if (WS_NUM_APOLICE != 00)
            {

                /*" -5053- MOVE WS-NUM-APOLICE TO PARCELAS-NUM-APOLICE */
                _.Move(WS_NUM_APOLICE, PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE);

                /*" -5054- END-IF */
            }


            /*" -5055- MOVE ZEROS TO PARCELAS-NUM-ENDOSSO */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO);

            /*" -5056- MOVE ZEROS TO PARCELAS-NUM-PARCELA */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA);

            /*" -5057- MOVE ZEROS TO PARCELAS-DAC-PARCELA */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA);

            /*" -5058- MOVE FONTES-ORGAO-EMISSOR TO PARCELAS-COD-FONTE */
            _.Move(FONTES.DCLFONTES.FONTES_ORGAO_EMISSOR, PARCELAS.DCLPARCELAS.PARCELAS_COD_FONTE);

            /*" -5059- MOVE ZEROS TO PARCELAS-NUM-TITULO */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_NUM_TITULO);

            /*" -5060- MOVE ZEROS TO PARCELAS-PRM-TARIFARIO-IX */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX);

            /*" -5061- MOVE ZEROS TO PARCELAS-VAL-DESCONTO-IX */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX);

            /*" -5062- MOVE ZEROS TO PARCELAS-PRM-LIQUIDO-IX */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX);

            /*" -5063- MOVE ZEROS TO PARCELAS-ADICIONAL-FRAC-IX */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX);

            /*" -5064- MOVE ZEROS TO PARCELAS-VAL-CUSTO-EMIS-IX */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX);

            /*" -5065- MOVE ZEROS TO PARCELAS-VAL-IOCC-IX */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX);

            /*" -5066- MOVE ZEROS TO PARCELAS-PRM-TOTAL-IX */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX);

            /*" -5067- MOVE 1 TO PARCELAS-OCORR-HISTORICO */
            _.Move(1, PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO);

            /*" -5068- MOVE ZEROS TO PARCELAS-QTD-DOCUMENTOS */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_QTD_DOCUMENTOS);

            /*" -5070- MOVE '0' TO PARCELAS-SIT-REGISTRO */
            _.Move("0", PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO);

            /*" -5070- PERFORM R0534-00-INSERT-PARCELAS. */

            R0534_00_INSERT_PARCELAS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0454_99_SAIDA*/

        [StopWatch]
        /*" R0455-00-INCLUIR-HIST-PARC-SECTION */
        private void R0455_00_INCLUIR_HIST_PARC_SECTION()
        {
            /*" -5079- MOVE 'R0455-00-INCLUIR-HIST-PARC' TO PARAGRAFO. */
            _.Move("R0455-00-INCLUIR-HIST-PARC", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5080- MOVE 'INCLUIR' TO COMANDO. */
            _.Move("INCLUIR", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5082- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5083- MOVE APOLICES-NUM-APOLICE TO PARCEHIS-NUM-APOLICE */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);

            /*" -5084- IF WS-NUM-APOLICE NOT EQUAL ZEROS */

            if (WS_NUM_APOLICE != 00)
            {

                /*" -5085- MOVE WS-NUM-APOLICE TO PARCEHIS-NUM-APOLICE */
                _.Move(WS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);

                /*" -5086- END-IF */
            }


            /*" -5087- MOVE ZEROS TO PARCEHIS-NUM-ENDOSSO */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);

            /*" -5088- MOVE ZEROS TO PARCEHIS-NUM-PARCELA */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);

            /*" -5089- MOVE ZEROS TO PARCEHIS-DAC-PARCELA */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA);

            /*" -5090- MOVE SISTEMAS-DATA-MOV-ABERTO TO PARCEHIS-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);

            /*" -5091- MOVE 101 TO PARCEHIS-COD-OPERACAO */
            _.Move(101, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);

            /*" -5092- MOVE 1 TO PARCEHIS-OCORR-HISTORICO */
            _.Move(1, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);

            /*" -5093- MOVE ZEROS TO PARCEHIS-PRM-TARIFARIO */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO);

            /*" -5094- MOVE ZEROS TO PARCEHIS-VAL-DESCONTO */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO);

            /*" -5095- MOVE ZEROS TO PARCEHIS-PRM-LIQUIDO */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO);

            /*" -5096- MOVE ZEROS TO PARCEHIS-ADICIONAL-FRACIO */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO);

            /*" -5097- MOVE ZEROS TO PARCEHIS-VAL-CUSTO-EMISSAO */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO);

            /*" -5103- MOVE ZEROS TO PARCEHIS-VAL-IOCC */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC);

            /*" -5104-  EVALUATE R1-COD-PRODUTO  */

            /*" -5104-  WHEN 9311 */

            /*" -5104- IF   R1-COD-PRODUTO EQUALS  9311 */

            if (REG_R1_SUBGRUPO.R1_COD_PRODUTO == 9311)
            {

                /*" -5104-  WHEN JVPRD9311 */

                /*" -5104- ELSE IF   R1-COD-PRODUTO EQUALS  JVPRD9311 */
            }
            else

            if (REG_R1_SUBGRUPO.R1_COD_PRODUTO == JVBKINCL.JV_PRODUTOS.JVPRD9311)
            {

                /*" -5106-  WHEN 9354  */

                /*" -5106- ELSE IF   R1-COD-PRODUTO EQUALS  9354 */
            }
            else

            if (REG_R1_SUBGRUPO.R1_COD_PRODUTO == 9354)
            {

                /*" -5108- MOVE R1-VAL-PRMVG-INICIAL TO PARCEHIS-PRM-TOTAL */
                _.Move(REG_R1_SUBGRUPO.R1_VAL_PRMVG_INICIAL, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL);

                /*" -5108-  WHEN 8203 */

                /*" -5108-  WHEN JVPRD8203 */

                /*" -5111-  MOVE R1-VAL-PRMAP-INICIAL TO PARCEHIS-PRM-TOTAL  */

                /*" -5111- MOVE R1-VAL-PRMAP-INICIAL TO PARCEHIS-PRM-TOTAL */
                _.Move(REG_R1_SUBGRUPO.R1_VAL_PRMAP_INICIAL, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL);

                /*" -5112-  WHEN OTHER  */

                /*" -5112- ELSE */
            }
            else
            {


                /*" -5113- MOVE ZEROS TO PARCEHIS-PRM-TOTAL */
                _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL);

                /*" -5115-  END-EVALUATE.  */

                /*" -5115- END-IF. */
            }


            /*" -5116- MOVE ZEROS TO PARCEHIS-VAL-OPERACAO */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);

            /*" -5117- MOVE ENDOSSOS-DATA-EMISSAO TO PARCEHIS-DATA-VENCIMENTO */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);

            /*" -5118- MOVE 104 TO PARCEHIS-BCO-COBRANCA */
            _.Move(104, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA);

            /*" -5119- MOVE 630 TO PARCEHIS-AGE-COBRANCA */
            _.Move(630, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA);

            /*" -5120- MOVE ZEROS TO PARCEHIS-NUM-AVISO-CREDITO */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);

            /*" -5121- MOVE ZEROS TO PARCEHIS-ENDOS-CANCELA */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA);

            /*" -5122- MOVE SPACES TO PARCEHIS-SIT-CONTABIL */
            _.Move("", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL);

            /*" -5123- MOVE 'VG2600B' TO PARCEHIS-COD-USUARIO */
            _.Move("VG2600B", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO);

            /*" -5125- MOVE ZEROS TO PARCEHIS-RENUM-DOCUMENTO */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO);

            /*" -5125- PERFORM R0535-00-INSERT-HIST-PARC. */

            R0535_00_INSERT_HIST_PARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0455_99_SAIDA*/

        [StopWatch]
        /*" R0456-00-INCLUIR-APOL-COBER-SECTION */
        private void R0456_00_INCLUIR_APOL_COBER_SECTION()
        {
            /*" -5134- MOVE 'R0456-00-INCLUIR-APOL-COBER' TO PARAGRAFO. */
            _.Move("R0456-00-INCLUIR-APOL-COBER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5135- MOVE 'INCLUIR' TO COMANDO. */
            _.Move("INCLUIR", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5137- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5138- MOVE APOLICES-NUM-APOLICE TO APOLICOB-NUM-APOLICE */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE);

            /*" -5139- IF WS-NUM-APOLICE NOT EQUAL ZEROS */

            if (WS_NUM_APOLICE != 00)
            {

                /*" -5140- MOVE WS-NUM-APOLICE TO APOLICOB-NUM-APOLICE */
                _.Move(WS_NUM_APOLICE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE);

                /*" -5141- END-IF */
            }


            /*" -5142- MOVE ZEROS TO APOLICOB-NUM-ENDOSSO */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO);

            /*" -5143- MOVE ZEROS TO APOLICOB-NUM-ITEM */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM);

            /*" -5144- MOVE ZEROS TO APOLICOB-OCORR-HISTORICO */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO);

            /*" -5145- MOVE RAMOCOMP-RAMO-EMISSOR TO APOLICOB-RAMO-COBERTURA */
            _.Move(RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);

            /*" -5146- MOVE ZEROS TO APOLICOB-MODALI-COBERTURA */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA);

            /*" -5147- MOVE ZEROS TO APOLICOB-COD-COBERTURA */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);

            /*" -5148- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-IX */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX);

            /*" -5149- MOVE ZEROS TO APOLICOB-PRM-TARIFARIO-IX */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);

            /*" -5150- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-VAR */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR);

            /*" -5151- MOVE ZEROS TO APOLICOB-PRM-TARIFARIO-VAR */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR);

            /*" -5152- MOVE ZEROS TO APOLICOB-PCT-COBERTURA */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA);

            /*" -5153- MOVE 1 TO APOLICOB-FATOR-MULTIPLICA */
            _.Move(1, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

            /*" -5154- MOVE WS-DTA-INI-VIGENCIA TO APOLICOB-DATA-INIVIGENCIA */
            _.Move(WS_DTA_INI_VIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA);

            /*" -5155- MOVE WS-DTA-TER-VIGENCIA TO APOLICOB-DATA-TERVIGENCIA */
            _.Move(WS_DTA_TER_VIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA);

            /*" -5156- MOVE ZEROS TO APOLICOB-COD-EMPRESA */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_EMPRESA);

            /*" -5158- MOVE '0' TO APOLICOB-SIT-REGISTRO */
            _.Move("0", APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_SIT_REGISTRO);

            /*" -5158- PERFORM R0536-00-INSERT-APOL-COBER. */

            R0536_00_INSERT_APOL_COBER_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0456_SAIDA*/

        [StopWatch]
        /*" R0457-00-INCLUIR-CONV-SICOB-SECTION */
        private void R0457_00_INCLUIR_CONV_SICOB_SECTION()
        {
            /*" -5167- MOVE 'R0457-00-INCLUIR-CONV-SICOB' TO PARAGRAFO. */
            _.Move("R0457-00-INCLUIR-CONV-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5168- MOVE 'INCLUIR' TO COMANDO. */
            _.Move("INCLUIR", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5170- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5171- MOVE R1-NUM-PROPOSTA TO CONVERSI-NUM-PROPOSTA-SIVPF */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_PROPOSTA, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);

            /*" -5172- MOVE APOLICES-NUM-APOLICE TO CONVERSI-NUM-SICOB */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB);

            /*" -5173- IF R1-NUM-APOLICE NOT EQUAL ZEROS */

            if (REG_R1_SUBGRUPO.R1_NUM_APOLICE != 00)
            {

                /*" -5174- MOVE R1-NUM-APOLICE TO CONVERSI-NUM-SICOB */
                _.Move(REG_R1_SUBGRUPO.R1_NUM_APOLICE, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB);

                /*" -5175- END-IF */
            }


            /*" -5176- MOVE ZEROS TO CONVERSI-COD-EMPRESA-SIVPF */
            _.Move(0, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_EMPRESA_SIVPF);

            /*" -5177- MOVE 16 TO CONVERSI-COD-PRODUTO-SIVPF */
            _.Move(16, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF);

            /*" -5178- MOVE RAMOCOMP-RAMO-EMISSOR TO CONVERSI-AGEPGTO */
            _.Move(RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_AGEPGTO);

            /*" -5179- MOVE SISTEMAS-DATA-MOV-ABERTO TO CONVERSI-DATA-OPERACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_DATA_OPERACAO);

            /*" -5180- MOVE ENDOSSOS-DATA-EMISSAO TO CONVERSI-DATA-QUITACAO */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_DATA_QUITACAO);

            /*" -5181- MOVE ZEROS TO CONVERSI-VAL-RCAP */
            _.Move(0, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_VAL_RCAP);

            /*" -5183- MOVE 'VG2600B' TO CONVERSI-COD-USUARIO */
            _.Move("VG2600B", CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_USUARIO);

            /*" -5183- PERFORM R0556-00-INSERT-CONV-SICOB. */

            R0556_00_INSERT_CONV_SICOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0457_99_SAIDA*/

        [StopWatch]
        /*" R0458-00-INCLUIR-SOL-FATURA-SECTION */
        private void R0458_00_INCLUIR_SOL_FATURA_SECTION()
        {
            /*" -5192- MOVE 'R0458-00-INCLUIR-SOL-FATURA' TO PARAGRAFO. */
            _.Move("R0458-00-INCLUIR-SOL-FATURA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5193- MOVE 'INCLUIR SOLICITA FATURA ' TO COMANDO. */
            _.Move("INCLUIR SOLICITA FATURA ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5195- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5196- MOVE APOLICES-NUM-APOLICE TO VGSOLFAT-NUM-APOLICE */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE);

            /*" -5197- IF R1-NUM-APOLICE NOT EQUAL ZEROS */

            if (REG_R1_SUBGRUPO.R1_NUM_APOLICE != 00)
            {

                /*" -5198- MOVE R1-NUM-APOLICE TO VGSOLFAT-NUM-APOLICE */
                _.Move(REG_R1_SUBGRUPO.R1_NUM_APOLICE, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE);

                /*" -5199- END-IF */
            }


            /*" -5200- MOVE R1-NUM-SUBGRUPO TO VGSOLFAT-COD-SUBGRUPO */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_SUBGRUPO, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO);

            /*" -5201- MOVE SISTEMAS-DATA-MOV-ABERTO TO VGSOLFAT-DATA-SOLICITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DATA_SOLICITACAO);

            /*" -5202- MOVE R1-NUM-DIA-DEBITO TO VGSOLFAT-DIA-DEBITO */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_DIA_DEBITO, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DIA_DEBITO);

            /*" -5203- MOVE R1-IND-OPCAO-PAGMTO TO VGSOLFAT-OPCAOPAG */
            _.Move(REG_R1_SUBGRUPO.R1_IND_OPCAO_PAGMTO, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_OPCAOPAG);

            /*" -5204- MOVE R1-QTD-VIDA-CONTRAT TO VGSOLFAT-QUANT-VIDAS */
            _.Move(REG_R1_SUBGRUPO.R1_QTD_VIDA_CONTRAT, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_QUANT_VIDAS);

            /*" -5205- MOVE R1-VAL-CAP-INICIAL TO VGSOLFAT-CAP-BAS-SEGURADO */
            _.Move(REG_R1_SUBGRUPO.R1_VAL_CAP_INICIAL, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_CAP_BAS_SEGURADO);

            /*" -5206- MOVE R1-VAL-PRMVG-INICIAL TO VGSOLFAT-PRM-VG */
            _.Move(REG_R1_SUBGRUPO.R1_VAL_PRMVG_INICIAL, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_VG);

            /*" -5212- MOVE R1-VAL-PRMAP-INICIAL TO VGSOLFAT-PRM-AP */
            _.Move(REG_R1_SUBGRUPO.R1_VAL_PRMAP_INICIAL, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_AP);

            /*" -5216- STRING R1-DTA-VENC-TITULO(05:04) '-' R1-DTA-VENC-TITULO(03:02) '-' R1-DTA-VENC-TITULO(01:02) DELIMITED BY SIZE INTO VGSOLFAT-DTVENCTO-FATURA */
            #region STRING
            var spl10 = REG_R1_SUBGRUPO.R1_DTA_VENC_TITULO.Substring(05, 04).GetMoveValues();
            spl10 += "-";
            var spl11 = REG_R1_SUBGRUPO.R1_DTA_VENC_TITULO.Substring(03, 02).GetMoveValues();
            spl11 += "-";
            var spl12 = REG_R1_SUBGRUPO.R1_DTA_VENC_TITULO.Substring(01, 02).GetMoveValues();
            var results13 = spl10 + spl11 + spl12;
            _.Move(results13, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DTVENCTO_FATURA);
            #endregion

            /*" -5218- MOVE VGSOLFAT-DTVENCTO-FATURA TO VGSOLFAT-DT-QUITBCO-TITULO */
            _.Move(VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DTVENCTO_FATURA, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DT_QUITBCO_TITULO);

            /*" -5219- MOVE FONTES-ORGAO-EMISSOR TO VGSOLFAT-COD-FONTE */
            _.Move(FONTES.DCLFONTES.FONTES_ORGAO_EMISSOR, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_FONTE);

            /*" -5220- MOVE R1-NUM-TITULO-RCAP TO VGSOLFAT-NUM-TITULO */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_TITULO_RCAP, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO);

            /*" -5222- MOVE R1-VAL-TITULO-RCAP TO VGSOLFAT-VALOR-TITULO */
            _.Move(REG_R1_SUBGRUPO.R1_VAL_TITULO_RCAP, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_VALOR_TITULO);

            /*" -5223- MOVE '0' TO VGSOLFAT-SIT-SOLICITA */
            _.Move("0", VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_SIT_SOLICITA);

            /*" -5225- MOVE 'VG2600B' TO VGSOLFAT-COD-USUARIO */
            _.Move("VG2600B", VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_USUARIO);

            /*" -5226- MOVE R1-NUM-AGE-COBR TO VGSOLFAT-AGECTADEB */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_AGE_COBR, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_AGECTADEB);

            /*" -5227- MOVE R1-NUM-OPER-CONTA-COBR TO VGSOLFAT-OPRCTADEB */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_OPER_CONTA_COBR, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_OPRCTADEB);

            /*" -5228- MOVE R1-NUM-CONTA-COBR TO VGSOLFAT-NUMCTADEB */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_CONTA_COBR, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUMCTADEB);

            /*" -5235- MOVE R1-NUM-DV-CONTA-COBR TO VGSOLFAT-DIGCTADEB. */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_DV_CONTA_COBR, VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DIGCTADEB);

            /*" -5238- PERFORM R7400-PROCURA-AVALIACAO-RISCO */

            R7400_PROCURA_AVALIACAO_RISCO_SECTION();

            /*" -5239- IF WS-ENCONTROU-RISCO EQUAL 'SIM' */

            if (WS_ENCONTROU_RISCO == "SIM")
            {

                /*" -5240- MOVE '2' TO VGSOLFAT-SIT-SOLICITA */
                _.Move("2", VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_SIT_SOLICITA);

                /*" -5242- ADD 1 TO WS-QTD-PCR */
                WS_QTD_PCR.Value = WS_QTD_PCR + 1;

                /*" -5243- MOVE 099 TO WS-COD-ERRO */
                _.Move(099, WS_COD_ERRO);

                /*" -5244- MOVE 106 TO WS-COD-CAMPO */
                _.Move(106, WS_COD_CAMPO);

                /*" -5245- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -5246- MOVE 2 TO W-CRITICA-PROPOSTA */
                _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                /*" -5249- END-IF */
            }


            /*" -5249- PERFORM R0557-00-INSERT-SOL-FATURA. */

            R0557_00_INSERT_SOL_FATURA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0458_99_SAIDA*/

        [StopWatch]
        /*" R0459-00-CONSULTA-CONV-SICOB-SECTION */
        private void R0459_00_CONSULTA_CONV_SICOB_SECTION()
        {
            /*" -5258- MOVE 'R0459-00-CONSULTA-CONV-SICOB' TO PARAGRAFO. */
            _.Move("R0459-00-CONSULTA-CONV-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5259- MOVE 'SELECT VERIF. CONV SICOB' TO COMANDO. */
            _.Move("SELECT VERIF. CONV SICOB", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5261- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5267- PERFORM R0459_00_CONSULTA_CONV_SICOB_DB_SELECT_1 */

            R0459_00_CONSULTA_CONV_SICOB_DB_SELECT_1();

            /*" -5270- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -5271- DISPLAY 'R0459 - PROBLEMAS SELECT CONVERSAO_SICOB... ' */
                _.Display($"R0459 - PROBLEMAS SELECT CONVERSAO_SICOB... ");

                /*" -5272- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -5273- DISPLAY 'SQLERRMC- ' SQLERRMC */
                _.Display($"SQLERRMC- {DB.SQLERRMC}");

                /*" -5274- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -5275- END-IF. */
            }


        }

        [StopWatch]
        /*" R0459-00-CONSULTA-CONV-SICOB-DB-SELECT-1 */
        public void R0459_00_CONSULTA_CONV_SICOB_DB_SELECT_1()
        {
            /*" -5267- EXEC SQL SELECT NUM_SICOB INTO :CONVERSI-NUM-SICOB FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :CONVERSI-NUM-PROPOSTA-SIVPF WITH UR END-EXEC. */

            var r0459_00_CONSULTA_CONV_SICOB_DB_SELECT_1_Query1 = new R0459_00_CONSULTA_CONV_SICOB_DB_SELECT_1_Query1()
            {
                CONVERSI_NUM_PROPOSTA_SIVPF = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0459_00_CONSULTA_CONV_SICOB_DB_SELECT_1_Query1.Execute(r0459_00_CONSULTA_CONV_SICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVERSI_NUM_SICOB, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0459_99_SAIDA*/

        [StopWatch]
        /*" R0459-00-UPDATE-CONV-SICOB-SECTION */
        private void R0459_00_UPDATE_CONV_SICOB_SECTION()
        {
            /*" -5283- MOVE 'R0459-00-UPDATE-CONV-SICOB' TO PARAGRAFO. */
            _.Move("R0459-00-UPDATE-CONV-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5284- MOVE 'UPDATE CONV SICOB' TO COMANDO. */
            _.Move("UPDATE CONV SICOB", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5286- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5287- MOVE APOLICES-NUM-APOLICE TO CONVERSI-NUM-SICOB. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB);

            /*" -5288- IF WS-NUM-APOLICE NOT EQUAL ZEROS */

            if (WS_NUM_APOLICE != 00)
            {

                /*" -5289- MOVE WS-NUM-APOLICE TO CONVERSI-NUM-SICOB */
                _.Move(WS_NUM_APOLICE, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB);

                /*" -5291- END-IF */
            }


            /*" -5295- PERFORM R0459_00_UPDATE_CONV_SICOB_DB_UPDATE_1 */

            R0459_00_UPDATE_CONV_SICOB_DB_UPDATE_1();

            /*" -5298- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -5299- DISPLAY 'R0459 - PROBLEMAS UPDATE CONVERSAO_SICOB... ' */
                _.Display($"R0459 - PROBLEMAS UPDATE CONVERSAO_SICOB... ");

                /*" -5300- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -5301- DISPLAY 'SQLERRMC- ' SQLERRMC */
                _.Display($"SQLERRMC- {DB.SQLERRMC}");

                /*" -5302- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -5303- END-IF. */
            }


        }

        [StopWatch]
        /*" R0459-00-UPDATE-CONV-SICOB-DB-UPDATE-1 */
        public void R0459_00_UPDATE_CONV_SICOB_DB_UPDATE_1()
        {
            /*" -5295- EXEC SQL UPDATE SEGUROS.CONVERSAO_SICOB SET NUM_SICOB = :CONVERSI-NUM-SICOB WHERE NUM_PROPOSTA_SIVPF = :CONVERSI-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r0459_00_UPDATE_CONV_SICOB_DB_UPDATE_1_Update1 = new R0459_00_UPDATE_CONV_SICOB_DB_UPDATE_1_Update1()
            {
                CONVERSI_NUM_SICOB = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB.ToString(),
                CONVERSI_NUM_PROPOSTA_SIVPF = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R0459_00_UPDATE_CONV_SICOB_DB_UPDATE_1_Update1.Execute(r0459_00_UPDATE_CONV_SICOB_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0459_99_01_SAIDA*/

        [StopWatch]
        /*" R0460-00-CARREGA-ENDERECO-SECTION */
        private void R0460_00_CARREGA_ENDERECO_SECTION()
        {
            /*" -5311- MOVE 'R0460-00-CARREGA-ENDERECO ' TO PARAGRAFO. */
            _.Move("R0460-00-CARREGA-ENDERECO ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5312- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5314- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5315- INITIALIZE REG-R2-ENDERECO */
            _.Initialize(
                REG_R2_ENDERECO
            );

            /*" -5317- MOVE W-TB-MOV-PORTAL(W-IND-TAB) TO REG-R2-ENDERECO */
            _.Move(WAREA_AUXILIAR.W_TAB_MOV_PORTAL.W_TAB_MOV_PORTAL_0[WAREA_AUXILIAR.W_IND_TAB].W_TB_MOV_PORTAL, REG_R2_ENDERECO);

            /*" -5318- MOVE APOLICES-NUM-APOLICE TO SUBGVGAP-NUM-APOLICE */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

            /*" -5319- IF WS-NUM-APOLICE NOT EQUAL ZEROS */

            if (WS_NUM_APOLICE != 00)
            {

                /*" -5320- MOVE WS-NUM-APOLICE TO SUBGVGAP-NUM-APOLICE */
                _.Move(WS_NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

                /*" -5321- END-IF */
            }


            /*" -5322- MOVE R2-NUM-SUBGRUPO TO SUBGVGAP-COD-SUBGRUPO */
            _.Move(REG_R2_ENDERECO.R2_NUM_SUBGRUPO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

            /*" -5324- PERFORM R8014-00-VERIFICA-SUBGRUPO-VG */

            R8014_00_VERIFICA_SUBGRUPO_VG_SECTION();

            /*" -5325- IF (SQLCODE EQUAL ZEROS) */

            if ((DB.SQLCODE == 00))
            {

                /*" -5326- PERFORM R0461-00-INCLUIR-ENDERECO */

                R0461_00_INCLUIR_ENDERECO_SECTION();

                /*" -5327- PERFORM R0462-00-INCLUIR-EMAIL */

                R0462_00_INCLUIR_EMAIL_SECTION();

                /*" -5329- ELSE */
            }
            else
            {


                /*" -5330- MOVE 022 TO WS-COD-ERRO */
                _.Move(022, WS_COD_ERRO);

                /*" -5331- MOVE 056 TO WS-COD-CAMPO */
                _.Move(056, WS_COD_CAMPO);

                /*" -5332- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -5333- MOVE 2 TO W-CRITICA-PROPOSTA */
                _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                /*" -5333- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0460_SAIDA*/

        [StopWatch]
        /*" R0461-00-INCLUIR-ENDERECO-SECTION */
        private void R0461_00_INCLUIR_ENDERECO_SECTION()
        {
            /*" -5343- MOVE 'R0461-00-INCLUIR-ENDERECO' TO PARAGRAFO. */
            _.Move("R0461-00-INCLUIR-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5344- MOVE 'INCLUIR END' TO COMANDO. */
            _.Move("INCLUIR END", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5346- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5347- MOVE SUBGVGAP-COD-CLIENTE TO ENDERECO-COD-CLIENTE */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);

            /*" -5349- PERFORM R8015-00-GERAR-MAX-OCORR-END */

            R8015_00_GERAR_MAX_OCORR_END_SECTION();

            /*" -5350- MOVE R2-NUM-TIPO-END TO ENDERECO-COD-ENDERECO */
            _.Move(REG_R2_ENDERECO.R2_NUM_TIPO_END, ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO);

            /*" -5351- MOVE R2-NOM-ENDERECO TO ENDERECO-ENDERECO */
            _.Move(REG_R2_ENDERECO.R2_NOM_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);

            /*" -5352- MOVE R2-NOM-BAIRRO TO ENDERECO-BAIRRO */
            _.Move(REG_R2_ENDERECO.R2_NOM_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);

            /*" -5353- MOVE R2-NOM-CIDADE TO ENDERECO-CIDADE */
            _.Move(REG_R2_ENDERECO.R2_NOM_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);

            /*" -5354- MOVE R2-SIG-UF TO ENDERECO-SIGLA-UF */
            _.Move(REG_R2_ENDERECO.R2_SIG_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);

            /*" -5355- MOVE R2-NUM-CEP TO ENDERECO-CEP */
            _.Move(REG_R2_ENDERECO.R2_NUM_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);

            /*" -5356- MOVE R2-NUM-DDD-TEL TO ENDERECO-DDD */
            _.Move(REG_R2_ENDERECO.R2_NUM_DDD_TEL, ENDERECO.DCLENDERECOS.ENDERECO_DDD);

            /*" -5357- MOVE R2-NUM-TEL-FIXO TO ENDERECO-TELEFONE */
            _.Move(REG_R2_ENDERECO.R2_NUM_TEL_FIXO, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);

            /*" -5358- MOVE R2-NUM-TEL-FAX TO ENDERECO-FAX */
            _.Move(REG_R2_ENDERECO.R2_NUM_TEL_FAX, ENDERECO.DCLENDERECOS.ENDERECO_FAX);

            /*" -5359- MOVE R2-NUM-TEL-CEL TO ENDERECO-TELEX */
            _.Move(REG_R2_ENDERECO.R2_NUM_TEL_CEL, ENDERECO.DCLENDERECOS.ENDERECO_TELEX);

            /*" -5360- MOVE '0' TO ENDERECO-SIT-REGISTRO */
            _.Move("0", ENDERECO.DCLENDERECOS.ENDERECO_SIT_REGISTRO);

            /*" -5361- MOVE ZEROS TO ENDERECO-COD-EMPRESA */
            _.Move(0, ENDERECO.DCLENDERECOS.ENDERECO_COD_EMPRESA);

            /*" -5363- MOVE R2-NOM-COMPLEM-END TO ENDERECO-DES-COMPLEMENTO */
            _.Move(REG_R2_ENDERECO.R2_NOM_COMPLEM_END, ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO);

            /*" -5365- PERFORM R0537-00-INSERT-ENDERECO. */

            R0537_00_INSERT_ENDERECO_SECTION();

            /*" -5366- IF (SQLCODE EQUAL ZEROS) */

            if ((DB.SQLCODE == 00))
            {

                /*" -5367- IF (WS-FLAG-TEM-SUBGRUPO EQUAL 'N' ) */

                if ((WS_FLAG_TEM_SUBGRUPO == "N"))
                {

                    /*" -5368- MOVE 0 TO WS-SUBGRUPO-1 */
                    _.Move(0, WAREA_AUXILIAR.WS_SUBGRUPO_1);

                    /*" -5369- MOVE 1 TO WS-SUBGRUPO-2 */
                    _.Move(1, WAREA_AUXILIAR.WS_SUBGRUPO_2);

                    /*" -5370- ELSE */
                }
                else
                {


                    /*" -5371- MOVE SUBGVGAP-COD-SUBGRUPO TO WS-SUBGRUPO-1 */
                    _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, WAREA_AUXILIAR.WS_SUBGRUPO_1);

                    /*" -5372- MOVE SUBGVGAP-COD-SUBGRUPO TO WS-SUBGRUPO-2 */
                    _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, WAREA_AUXILIAR.WS_SUBGRUPO_2);

                    /*" -5374- END-IF */
                }


                /*" -5376- PERFORM R8017-00-UPDATE-END-SUBGRUPO */

                R8017_00_UPDATE_END_SUBGRUPO_SECTION();

                /*" -5377- IF (SUBGVGAP-COD-SUBGRUPO EQUAL ZEROS) */

                if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO == 00))
                {

                    /*" -5378- PERFORM R8038-00-UPDATE-END-ENDOSSOS */

                    R8038_00_UPDATE_END_ENDOSSOS_SECTION();

                    /*" -5379- END-IF */
                }


                /*" -5379- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0461_SAIDA*/

        [StopWatch]
        /*" R0462-00-INCLUIR-EMAIL-SECTION */
        private void R0462_00_INCLUIR_EMAIL_SECTION()
        {
            /*" -5388- MOVE 'R0462-00-INCLUIR-EMAIL   ' TO PARAGRAFO. */
            _.Move("R0462-00-INCLUIR-EMAIL   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5389- MOVE 'INCLUIR EMAIL' TO COMANDO. */
            _.Move("INCLUIR EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5391- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5392- MOVE SUBGVGAP-COD-CLIENTE TO CLIENEMA-COD-CLIENTE */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_COD_CLIENTE);

            /*" -5394- PERFORM R8016-00-GERAR-MAX-OCORR-EMAIL */

            R8016_00_GERAR_MAX_OCORR_EMAIL_SECTION();

            /*" -5396- MOVE R2-NOM-EMAIL TO CLIENEMA-EMAIL */
            _.Move(REG_R2_ENDERECO.R2_NOM_EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL);

            /*" -5396- PERFORM R0538-00-INSERT-EMAIL. */

            R0538_00_INSERT_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0462_SAIDA*/

        [StopWatch]
        /*" R0470-00-CARREGA-REPRES-LEG-SECTION */
        private void R0470_00_CARREGA_REPRES_LEG_SECTION()
        {
            /*" -5405- MOVE 'R0470-00-CARREGA-REPRES-LEG' TO PARAGRAFO. */
            _.Move("R0470-00-CARREGA-REPRES-LEG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5406- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5408- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5409- INITIALIZE REG-R3-REPRESENTANTE */
            _.Initialize(
                REG_R3_REPRESENTANTE
            );

            /*" -5411- MOVE W-TB-MOV-PORTAL(W-IND-TAB) TO REG-R3-REPRESENTANTE */
            _.Move(WAREA_AUXILIAR.W_TAB_MOV_PORTAL.W_TAB_MOV_PORTAL_0[WAREA_AUXILIAR.W_IND_TAB].W_TB_MOV_PORTAL, REG_R3_REPRESENTANTE);

            /*" -5412- MOVE APOLICES-NUM-APOLICE TO SUBGVGAP-NUM-APOLICE */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

            /*" -5413- IF WS-NUM-APOLICE NOT EQUAL ZEROS */

            if (WS_NUM_APOLICE != 00)
            {

                /*" -5414- MOVE WS-NUM-APOLICE TO SUBGVGAP-NUM-APOLICE */
                _.Move(WS_NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

                /*" -5415- END-IF */
            }


            /*" -5416- MOVE R3-NUM-SUBGRUPO TO SUBGVGAP-COD-SUBGRUPO */
            _.Move(REG_R3_REPRESENTANTE.R3_NUM_SUBGRUPO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

            /*" -5418- PERFORM R8014-00-VERIFICA-SUBGRUPO-VG */

            R8014_00_VERIFICA_SUBGRUPO_VG_SECTION();

            /*" -5419- IF (SQLCODE EQUAL ZEROS) */

            if ((DB.SQLCODE == 00))
            {

                /*" -5420- PERFORM R0471-00-TRATAR-PESSOA-FISICA */

                R0471_00_TRATAR_PESSOA_FISICA_SECTION();

                /*" -5421- PERFORM R0477-00-INCLUIR-REPRES-LEGAL */

                R0477_00_INCLUIR_REPRES_LEGAL_SECTION();

                /*" -5423- ELSE */
            }
            else
            {


                /*" -5424- MOVE 023 TO WS-COD-ERRO */
                _.Move(023, WS_COD_ERRO);

                /*" -5425- MOVE 072 TO WS-COD-CAMPO */
                _.Move(072, WS_COD_CAMPO);

                /*" -5426- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -5427- MOVE 2 TO W-CRITICA-PROPOSTA */
                _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                /*" -5427- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0470_99_SAIDA*/

        [StopWatch]
        /*" R0471-00-TRATAR-PESSOA-FISICA-SECTION */
        private void R0471_00_TRATAR_PESSOA_FISICA_SECTION()
        {
            /*" -5438- MOVE 'R0471-00-TRATAR-PESSOA-FIS' TO PARAGRAFO. */
            _.Move("R0471-00-TRATAR-PESSOA-FIS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5439- MOVE 'TRATAR PESSOA_FISICA' TO COMANDO. */
            _.Move("TRATAR PESSOA_FISICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5441- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5442- MOVE R3-NUM-CPF-REPRES TO CPF OF DCLPESSOA-FISICA */
            _.Move(REG_R3_REPRESENTANTE.R3_NUM_CPF_REPRES, PESFIS.DCLPESSOA_FISICA.CPF);

            /*" -5444- PERFORM R8020-00-VERIFICA-PESSOA-FIS */

            R8020_00_VERIFICA_PESSOA_FIS_SECTION();

            /*" -5445- IF (SQLCODE EQUAL +100) */

            if ((DB.SQLCODE == +100))
            {

                /*" -5446- PERFORM R0472-00-INCLUIR-PESSOA */

                R0472_00_INCLUIR_PESSOA_SECTION();

                /*" -5447- PERFORM R0473-00-INCLUIR-PESSOA-FISICA */

                R0473_00_INCLUIR_PESSOA_FISICA_SECTION();

                /*" -5449- END-IF */
            }


            /*" -5451- PERFORM R0474-00-INCLUIR-PESSOA-END */

            R0474_00_INCLUIR_PESSOA_END_SECTION();

            /*" -5453- MOVE 1 TO WS-POS */
            _.Move(1, WS_POS);

            /*" -5454- PERFORM UNTIL WS-POS > 3 */

            while (!(WS_POS > 3))
            {

                /*" -5455- IF (R3-IND-TIPO-TEL(WS-POS) > ZEROS) */

                if ((REG_R3_REPRESENTANTE.R3_TAB_EMAIL_TEL.R3_TAB_EMAIL_TEL_REG[WS_POS].R3_IND_TIPO_TEL > 00))
                {

                    /*" -5456- PERFORM R0475-00-INCLUIR-PESSOA-FONE */

                    R0475_00_INCLUIR_PESSOA_FONE_SECTION();

                    /*" -5458- END-IF */
                }


                /*" -5459- IF (R3-NOM-EMAIL(WS-POS) NOT EQUAL SPACES) */

                if ((REG_R3_REPRESENTANTE.R3_TAB_EMAIL_TEL.R3_TAB_EMAIL_TEL_REG[WS_POS].R3_NOM_EMAIL != string.Empty))
                {

                    /*" -5460- PERFORM R0476-00-INCLUIR-PESSOA-EMAIL */

                    R0476_00_INCLUIR_PESSOA_EMAIL_SECTION();

                    /*" -5462- END-IF */
                }


                /*" -5463- ADD 1 TO WS-POS */
                WS_POS.Value = WS_POS + 1;

                /*" -5463- END-PERFORM. */
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0471_99_SAIDA*/

        [StopWatch]
        /*" R0472-00-INCLUIR-PESSOA-SECTION */
        private void R0472_00_INCLUIR_PESSOA_SECTION()
        {
            /*" -5472- MOVE 'R0472-00-INCLUIR-PESSOA' TO PARAGRAFO. */
            _.Move("R0472-00-INCLUIR-PESSOA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5473- MOVE 'INCLUIR PESSOA' TO COMANDO. */
            _.Move("INCLUIR PESSOA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5475- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5477- PERFORM R8021-00-GERAR-MAX-COD-PESSOA */

            R8021_00_GERAR_MAX_COD_PESSOA_SECTION();

            /*" -5478- MOVE R3-NOM-REPRES-LEGAL TO PESSOA-NOME-PESSOA */
            _.Move(REG_R3_REPRESENTANTE.R3_NOM_REPRES_LEGAL, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);

            /*" -5479- MOVE 'VG2600B' TO PESSOA-COD-USUARIO */
            _.Move("VG2600B", PESSOA.DCLPESSOA.PESSOA_COD_USUARIO);

            /*" -5480- MOVE 'F' TO PESSOA-TIPO-PESSOA */
            _.Move("F", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);

            /*" -5482- MOVE R3-NOM-REPRES-LEGAL(1:10) TO PESSOA-SIGLA-PESSOA */
            _.Move(REG_R3_REPRESENTANTE.R3_NOM_REPRES_LEGAL.Substring(1, 10), PESSOA.DCLPESSOA.PESSOA_SIGLA_PESSOA);

            /*" -5482- PERFORM R0541-00-INSERT-PESSOA. */

            R0541_00_INSERT_PESSOA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0472_99_SAIDA*/

        [StopWatch]
        /*" R0473-00-INCLUIR-PESSOA-FISICA-SECTION */
        private void R0473_00_INCLUIR_PESSOA_FISICA_SECTION()
        {
            /*" -5491- MOVE 'R0473-00-INCLUIR-PESSOA-FIS' TO PARAGRAFO. */
            _.Move("R0473-00-INCLUIR-PESSOA-FIS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5492- MOVE 'INCLUIR PESSOA FISICA' TO COMANDO. */
            _.Move("INCLUIR PESSOA FISICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5494- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5495- MOVE R3-DTA-NASC-REPRES TO W-DATA-TRABALHO */
            _.Move(REG_R3_REPRESENTANTE.R3_DTA_NASC_REPRES, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -5497- PERFORM R8001-00-VERIFICA-DATA-VALIDA */

            R8001_00_VERIFICA_DATA_VALIDA_SECTION();

            /*" -5498- MOVE R3-NUM-CPF-REPRES TO CPF OF DCLPESSOA-FISICA */
            _.Move(REG_R3_REPRESENTANTE.R3_NUM_CPF_REPRES, PESFIS.DCLPESSOA_FISICA.CPF);

            /*" -5500- MOVE W-DATA-SQL TO DATA-NASCIMENTO OF DCLPESSOA-FISICA */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);

            /*" -5501- MOVE R3-IND-SEXO-REPRES TO SEXO OF DCLPESSOA-FISICA */
            _.Move(REG_R3_REPRESENTANTE.R3_IND_SEXO_REPRES, PESFIS.DCLPESSOA_FISICA.SEXO);

            /*" -5502- MOVE 'VG2600B' TO COD-USUARIO OF DCLPESSOA-FISICA */
            _.Move("VG2600B", PESFIS.DCLPESSOA_FISICA.COD_USUARIO);

            /*" -5503- MOVE R3-IND-EST-CIVIL TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
            _.Move(REG_R3_REPRESENTANTE.R3_IND_EST_CIVIL, PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

            /*" -5505- MOVE R3-COD-CBO TO COD-CBO OF DCLPESSOA-FISICA */
            _.Move(REG_R3_REPRESENTANTE.R3_COD_CBO, PESFIS.DCLPESSOA_FISICA.COD_CBO);

            /*" -5505- PERFORM R0542-00-INSERT-PESSOA-FISICA. */

            R0542_00_INSERT_PESSOA_FISICA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0473_99_SAIDA*/

        [StopWatch]
        /*" R0474-00-INCLUIR-PESSOA-END-SECTION */
        private void R0474_00_INCLUIR_PESSOA_END_SECTION()
        {
            /*" -5514- MOVE 'R0474-00-INCLUI-PESS-END' TO PARAGRAFO. */
            _.Move("R0474-00-INCLUI-PESS-END", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5515- MOVE 'INCLUIR PESSOA ENDERECO ' TO COMANDO. */
            _.Move("INCLUIR PESSOA ENDERECO ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5517- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5518- MOVE R3-NOM-ENDERECO TO ENDERECO OF DCLPESSOA-ENDERECO */
            _.Move(REG_R3_REPRESENTANTE.R3_NOM_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);

            /*" -5519- MOVE R3-NUM-TIPO-END TO TIPO-ENDER OF DCLPESSOA-ENDERECO */
            _.Move(REG_R3_REPRESENTANTE.R3_NUM_TIPO_END, PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER);

            /*" -5520- MOVE R3-NOM-COMPL-END TO COMPL-ENDER OF DCLPESSOA-ENDERECO */
            _.Move(REG_R3_REPRESENTANTE.R3_NOM_COMPL_END, PESENDER.DCLPESSOA_ENDERECO.COMPL_ENDER);

            /*" -5521- MOVE R3-NOM-BAIRRO TO BAIRRO OF DCLPESSOA-ENDERECO */
            _.Move(REG_R3_REPRESENTANTE.R3_NOM_BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);

            /*" -5522- MOVE R3-NUM-CEP TO CEP OF DCLPESSOA-ENDERECO */
            _.Move(REG_R3_REPRESENTANTE.R3_NUM_CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);

            /*" -5523- MOVE R3-NOM-CIDADE TO CIDADE OF DCLPESSOA-ENDERECO */
            _.Move(REG_R3_REPRESENTANTE.R3_NOM_CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);

            /*" -5524- MOVE R3-SIG-UF TO SIGLA-UF OF DCLPESSOA-ENDERECO */
            _.Move(REG_R3_REPRESENTANTE.R3_SIG_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);

            /*" -5526- MOVE 'A' TO SITUACAO-ENDERECO OF DCLPESSOA-ENDERECO */
            _.Move("A", PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO);

            /*" -5528- MOVE 'VG2600B' TO COD-USUARIO OF DCLPESSOA-ENDERECO */
            _.Move("VG2600B", PESENDER.DCLPESSOA_ENDERECO.COD_USUARIO);

            /*" -5530- PERFORM R8023-00-VERIFICA-ENDEREC-PES */

            R8023_00_VERIFICA_ENDEREC_PES_SECTION();

            /*" -5531- IF (SQLCODE EQUAL +100) */

            if ((DB.SQLCODE == +100))
            {

                /*" -5532- PERFORM R8022-00-GERAR-MAX-OCORR-END */

                R8022_00_GERAR_MAX_OCORR_END_SECTION();

                /*" -5533- PERFORM R0543-00-INSERT-PESSOA-END */

                R0543_00_INSERT_PESSOA_END_SECTION();

                /*" -5533- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0474_99_SAIDA*/

        [StopWatch]
        /*" R0475-00-INCLUIR-PESSOA-FONE-SECTION */
        private void R0475_00_INCLUIR_PESSOA_FONE_SECTION()
        {
            /*" -5542- MOVE 'R0475-00-INCLUIR-PESS-FON' TO PARAGRAFO. */
            _.Move("R0475-00-INCLUIR-PESS-FON", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5543- MOVE 'INCLUIR PESSOA TELEFONE  ' TO COMANDO. */
            _.Move("INCLUIR PESSOA TELEFONE  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5545- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5546- MOVE R3-IND-TIPO-TEL(WS-POS) TO TIPO-FONE */
            _.Move(REG_R3_REPRESENTANTE.R3_TAB_EMAIL_TEL.R3_TAB_EMAIL_TEL_REG[WS_POS].R3_IND_TIPO_TEL, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);

            /*" -5547- MOVE 55 TO DDI */
            _.Move(55, PESFONE.DCLPESSOA_TELEFONE.DDI);

            /*" -5548- MOVE R3-NUM-DDD-TEL(WS-POS) TO DDD */
            _.Move(REG_R3_REPRESENTANTE.R3_TAB_EMAIL_TEL.R3_TAB_EMAIL_TEL_REG[WS_POS].R3_NUM_DDD_TEL, PESFONE.DCLPESSOA_TELEFONE.DDD);

            /*" -5549- MOVE R3-NUM-TELEFONE(WS-POS) TO NUM-FONE */
            _.Move(REG_R3_REPRESENTANTE.R3_TAB_EMAIL_TEL.R3_TAB_EMAIL_TEL_REG[WS_POS].R3_NUM_TELEFONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);

            /*" -5551- MOVE 'A' TO SITUACAO-FONE */
            _.Move("A", PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE);

            /*" -5553- PERFORM R8024-00-VERIFICA-FONE-PESSOA */

            R8024_00_VERIFICA_FONE_PESSOA_SECTION();

            /*" -5554- IF (SQLCODE EQUAL +100) */

            if ((DB.SQLCODE == +100))
            {

                /*" -5555- PERFORM R8025-00-GERAR-MAX-SEQ-FONE */

                R8025_00_GERAR_MAX_SEQ_FONE_SECTION();

                /*" -5556- PERFORM R0544-00-INSERT-PESSOA-FONE */

                R0544_00_INSERT_PESSOA_FONE_SECTION();

                /*" -5556- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0475_99_SAIDA*/

        [StopWatch]
        /*" R0476-00-INCLUIR-PESSOA-EMAIL-SECTION */
        private void R0476_00_INCLUIR_PESSOA_EMAIL_SECTION()
        {
            /*" -5565- MOVE 'R0476-00-INCLUIR-PESS-MAIL' TO PARAGRAFO. */
            _.Move("R0476-00-INCLUIR-PESS-MAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5566- MOVE 'INCLUIR PESSOA EMAIL      ' TO COMANDO. */
            _.Move("INCLUIR PESSOA EMAIL      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5568- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5569- MOVE R3-NOM-EMAIL(WS-POS) TO EMAIL */
            _.Move(REG_R3_REPRESENTANTE.R3_TAB_EMAIL_TEL.R3_TAB_EMAIL_TEL_REG[WS_POS].R3_NOM_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);

            /*" -5571- MOVE 'A' TO SITUACAO-EMAIL */
            _.Move("A", PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);

            /*" -5573- PERFORM R8026-00-VERIFICA-EMAIL-PESSOA */

            R8026_00_VERIFICA_EMAIL_PESSOA_SECTION();

            /*" -5574- IF (SQLCODE EQUAL +100) */

            if ((DB.SQLCODE == +100))
            {

                /*" -5575- PERFORM R8027-00-GERAR-MAX-SEQ-MAIL */

                R8027_00_GERAR_MAX_SEQ_MAIL_SECTION();

                /*" -5576- PERFORM R0545-00-INSERT-PESSOA-EMAIL */

                R0545_00_INSERT_PESSOA_EMAIL_SECTION();

                /*" -5576- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0476_99_SAIDA*/

        [StopWatch]
        /*" R0477-00-INCLUIR-REPRES-LEGAL-SECTION */
        private void R0477_00_INCLUIR_REPRES_LEGAL_SECTION()
        {
            /*" -5585- MOVE 'R0477-00-INCLUIR-REPRES-LEGAL' TO PARAGRAFO. */
            _.Move("R0477-00-INCLUIR-REPRES-LEGAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5586- MOVE 'INCLUIR REPRESENTANTE LEGAL  ' TO COMANDO. */
            _.Move("INCLUIR REPRESENTANTE LEGAL  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5588- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5589- MOVE SUBGVGAP-NUM-APOLICE TO VG093-NUM-APOLICE */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE, VG093.DCLVG_REPRES_LEGAL.VG093_NUM_APOLICE);

            /*" -5590- MOVE SUBGVGAP-COD-SUBGRUPO TO VG093-COD-SUBGRUPO */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, VG093.DCLVG_REPRES_LEGAL.VG093_COD_SUBGRUPO);

            /*" -5592- MOVE R3-VAL-RENDA-REPRES TO VG093-VLR-RENDA */
            _.Move(REG_R3_REPRESENTANTE.R3_VAL_RENDA_REPRES, VG093.DCLVG_REPRES_LEGAL.VG093_VLR_RENDA);

            /*" -5593- PERFORM R8028-00-GERAR-MAX-OCORR-REPR */

            R8028_00_GERAR_MAX_OCORR_REPR_SECTION();

            /*" -5593- PERFORM R0546-00-INSERT-REPRES-LEGAL. */

            R0546_00_INSERT_REPRES_LEGAL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0477_SAIDA*/

        [StopWatch]
        /*" R0480-00-CARREGA-COBER-ADIC-SECTION */
        private void R0480_00_CARREGA_COBER_ADIC_SECTION()
        {
            /*" -5602- MOVE 'R0480-00-CARREGA-COBER-ADIC' TO PARAGRAFO. */
            _.Move("R0480-00-CARREGA-COBER-ADIC", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5603- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5605- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5606- INITIALIZE REG-R4-COBERTURA */
            _.Initialize(
                REG_R4_COBERTURA
            );

            /*" -5608- MOVE W-TB-MOV-PORTAL(W-IND-TAB) TO REG-R4-COBERTURA */
            _.Move(WAREA_AUXILIAR.W_TAB_MOV_PORTAL.W_TAB_MOV_PORTAL_0[WAREA_AUXILIAR.W_IND_TAB].W_TB_MOV_PORTAL, REG_R4_COBERTURA);

            /*" -5609- MOVE APOLICES-NUM-APOLICE TO SUBGVGAP-NUM-APOLICE */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

            /*" -5610- IF WS-NUM-APOLICE NOT EQUAL ZEROS */

            if (WS_NUM_APOLICE != 00)
            {

                /*" -5611- MOVE WS-NUM-APOLICE TO SUBGVGAP-NUM-APOLICE */
                _.Move(WS_NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

                /*" -5612- END-IF */
            }


            /*" -5613- MOVE R4-NUM-SUBGRUPO TO SUBGVGAP-COD-SUBGRUPO */
            _.Move(REG_R4_COBERTURA.R4_NUM_SUBGRUPO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

            /*" -5615- PERFORM R8014-00-VERIFICA-SUBGRUPO-VG */

            R8014_00_VERIFICA_SUBGRUPO_VG_SECTION();

            /*" -5616- IF (SQLCODE EQUAL ZEROS) */

            if ((DB.SQLCODE == 00))
            {

                /*" -5618- MOVE 1 TO WS-POS */
                _.Move(1, WS_POS);

                /*" -5619- PERFORM UNTIL WS-POS > 6 */

                while (!(WS_POS > 6))
                {

                    /*" -5620- IF (R4-COD-COBERTURA(WS-POS) > ZEROS) */

                    if ((REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_COD_COBERTURA > 00))
                    {

                        /*" -5621- PERFORM R0481-00-INCLUIR-COBER-SUBG */

                        R0481_00_INCLUIR_COBER_SUBG_SECTION();

                        /*" -5623- END-IF */
                    }


                    /*" -5624- ADD 1 TO WS-POS */
                    WS_POS.Value = WS_POS + 1;

                    /*" -5625- END-PERFORM */
                }

                /*" -5627- ELSE */
            }
            else
            {


                /*" -5628- MOVE 024 TO WS-COD-ERRO */
                _.Move(024, WS_COD_ERRO);

                /*" -5629- MOVE 094 TO WS-COD-CAMPO */
                _.Move(094, WS_COD_CAMPO);

                /*" -5630- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -5631- MOVE 2 TO W-CRITICA-PROPOSTA */
                _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                /*" -5631- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0480_SAIDA*/

        [StopWatch]
        /*" R0481-00-INCLUIR-COBER-SUBG-SECTION */
        private void R0481_00_INCLUIR_COBER_SUBG_SECTION()
        {
            /*" -5640- MOVE 'R0481-00-INCLUIR-COBER-SUBG' TO PARAGRAFO. */
            _.Move("R0481-00-INCLUIR-COBER-SUBG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5641- MOVE 'INCLUIR COBER-SUBG' TO COMANDO. */
            _.Move("INCLUIR COBER-SUBG", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5643- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5644- MOVE SUBGVGAP-NUM-APOLICE TO VGCOBSUB-NUM-APOLICE */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_NUM_APOLICE);

            /*" -5645- MOVE SUBGVGAP-COD-SUBGRUPO TO VGCOBSUB-COD-SUBGRUPO */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_SUBGRUPO);

            /*" -5646- MOVE ZEROS TO VGCOBSUB-RAMO-COBERTURA */
            _.Move(0, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_RAMO_COBERTURA);

            /*" -5647- MOVE R4-COD-COBERTURA(WS-POS) TO VGCOBSUB-COD-COBERTURA */
            _.Move(REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_COD_COBERTURA, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

            /*" -5648- MOVE APOLICES-COD-MODALIDADE TO VGCOBSUB-MODALI-COBERTURA */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_MODALI_COBERTURA);

            /*" -5649- MOVE R4-VAL-IMP-SEGURADA(WS-POS) TO VGCOBSUB-IMP-SEGURADA-IX */
            _.Move(REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_VAL_IMP_SEGURADA, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX);

            /*" -5650- MOVE R4-VAL-PRM-INDIVID(WS-POS) TO VGCOBSUB-PRM-TARIFARIO-IX */
            _.Move(REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_VAL_PRM_INDIVID, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_PRM_TARIFARIO_IX);

            /*" -5651- MOVE R4-VAL-IMP-SEGURADA(WS-POS) TO VGCOBSUB-IMP-SEGURADA-VAR */
            _.Move(REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_VAL_IMP_SEGURADA, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_VAR);

            /*" -5652- MOVE R4-VAL-PRM-INDIVID(WS-POS) TO VGCOBSUB-PRM-TARIFARIO-VAR */
            _.Move(REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_VAL_PRM_INDIVID, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_PRM_TARIFARIO_VAR);

            /*" -5653- MOVE R4-PCT-COBER-BASICA(WS-POS) TO VGCOBSUB-PCT-COBERTURA */
            _.Move(REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_PCT_COBER_BASICA, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_PCT_COBERTURA);

            /*" -5654- MOVE 1 TO VGCOBSUB-FATOR-MULTIPLICA */
            _.Move(1, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_FATOR_MULTIPLICA);

            /*" -5655- MOVE ENDOSSOS-DATA-INIVIGENCIA TO VGCOBSUB-DATA-INIVIGENCIA */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_DATA_INIVIGENCIA);

            /*" -5656- MOVE R4-IND-TRAT-FATURA(WS-POS) TO VGCOBSUB-TRATAMENTO-FATURA */
            _.Move(REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_IND_TRAT_FATURA, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_TRATAMENTO_FATURA);

            /*" -5657- MOVE R4-IND-TRAT-PREMIO(WS-POS) TO VGCOBSUB-TRATAMENTO-PRMTOT */
            _.Move(REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_IND_TRAT_PREMIO, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_TRATAMENTO_PRMTOT);

            /*" -5658- MOVE '0' TO VGCOBSUB-SIT-COBERTURA */
            _.Move("0", VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_SIT_COBERTURA);

            /*" -5659- MOVE 'VG2600B' TO VGCOBSUB-COD-USUARIO */
            _.Move("VG2600B", VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_USUARIO);

            /*" -5660- MOVE R4-VAL-LIM-MINIMO(WS-POS) TO VGCOBSUB-VLR-LIM-MIN-COBER */
            _.Move(REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_VAL_LIM_MINIMO, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_VLR_LIM_MIN_COBER);

            /*" -5661- MOVE R4-VAL-LIM-MAXIMO(WS-POS) TO VGCOBSUB-VLR-LIM-MAX-COBER */
            _.Move(REG_R4_COBERTURA.R4_TAB_COBER_ADIC.R4_TAB_COBER_ADIC_REG[WS_POS].R4_VAL_LIM_MAXIMO, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_VLR_LIM_MAX_COBER);

            /*" -5663- MOVE '9999-12-31' TO VGCOBSUH-DATA-TERVIGENCIA */
            _.Move("9999-12-31", VGCOBSUH.DCLVG_COBER_SUBG_HIST.VGCOBSUH_DATA_TERVIGENCIA);

            /*" -5663- PERFORM R0539-00-INSERT-COBER-SUBG. */

            R0539_00_INSERT_COBER_SUBG_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0481_SAIDA*/

        [StopWatch]
        /*" R0490-00-CARREGA-CORRETAGEM-SECTION */
        private void R0490_00_CARREGA_CORRETAGEM_SECTION()
        {
            /*" -5673- MOVE 'R0490-00-CARREGA-CORRETAGEM' TO PARAGRAFO. */
            _.Move("R0490-00-CARREGA-CORRETAGEM", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5674- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5676- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5677- INITIALIZE REG-R5-CORRETAGEM */
            _.Initialize(
                REG_R5_CORRETAGEM
            );

            /*" -5679- MOVE W-TB-MOV-PORTAL(W-IND-TAB) TO REG-R5-CORRETAGEM */
            _.Move(WAREA_AUXILIAR.W_TAB_MOV_PORTAL.W_TAB_MOV_PORTAL_0[WAREA_AUXILIAR.W_IND_TAB].W_TB_MOV_PORTAL, REG_R5_CORRETAGEM);

            /*" -5680- MOVE APOLICES-NUM-APOLICE TO SUBGVGAP-NUM-APOLICE */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

            /*" -5681- IF WS-NUM-APOLICE NOT EQUAL ZEROS */

            if (WS_NUM_APOLICE != 00)
            {

                /*" -5682- MOVE WS-NUM-APOLICE TO SUBGVGAP-NUM-APOLICE */
                _.Move(WS_NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

                /*" -5683- END-IF */
            }


            /*" -5685- MOVE R5-NUM-SUBGRUPO TO SUBGVGAP-COD-SUBGRUPO */
            _.Move(REG_R5_CORRETAGEM.R5_NUM_SUBGRUPO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

            /*" -5687- PERFORM R8014-00-VERIFICA-SUBGRUPO-VG */

            R8014_00_VERIFICA_SUBGRUPO_VG_SECTION();

            /*" -5688- IF (SQLCODE EQUAL ZEROS) */

            if ((DB.SQLCODE == 00))
            {

                /*" -5690- MOVE 1 TO WS-POS */
                _.Move(1, WS_POS);

                /*" -5691- PERFORM UNTIL WS-POS > 10 */

                while (!(WS_POS > 10))
                {

                    /*" -5693- IF (R5-COD-TIPO-CORR(WS-POS) EQUAL 1 OR 2) */

                    if ((REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_COD_TIPO_CORR.In("1", "2")))
                    {

                        /*" -5694- MOVE ZEROS TO APOLICOR-COD-SUBGRUPO */
                        _.Move(0, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_SUBGRUPO);

                        /*" -5697- PERFORM R0491-00-INCLUIR-APOLICOR */

                        R0491_00_INCLUIR_APOLICOR_SECTION();

                        /*" -5699- MOVE SUBGVGAP-COD-SUBGRUPO TO APOLICOR-COD-SUBGRUPO */
                        _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_SUBGRUPO);

                        /*" -5700- PERFORM R0547-00-INSERT-APOL-CORRET */

                        R0547_00_INSERT_APOL_CORRET_SECTION();

                        /*" -5701- ELSE */
                    }
                    else
                    {


                        /*" -5703- IF (R5-COD-TIPO-CORR(WS-POS) EQUAL 3) */

                        if ((REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_COD_TIPO_CORR == 3))
                        {

                            /*" -5704- MOVE ZEROS TO PLANOAGE-COD-SUBGRUPO */
                            _.Move(0, PLANOAGE.DCLPLANO_AGENCIAMENTO.PLANOAGE_COD_SUBGRUPO);

                            /*" -5707- PERFORM R0492-00-INCLUIR-INDICADOR */

                            R0492_00_INCLUIR_INDICADOR_SECTION();

                            /*" -5709- MOVE SUBGVGAP-COD-SUBGRUPO TO PLANOAGE-COD-SUBGRUPO */
                            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, PLANOAGE.DCLPLANO_AGENCIAMENTO.PLANOAGE_COD_SUBGRUPO);

                            /*" -5710- PERFORM R0548-00-INSERT-PLANO-AGENC */

                            R0548_00_INSERT_PLANO_AGENC_SECTION();

                            /*" -5711- END-IF */
                        }


                        /*" -5713- END-IF */
                    }


                    /*" -5714- ADD 1 TO WS-POS */
                    WS_POS.Value = WS_POS + 1;

                    /*" -5715- END-PERFORM */
                }

                /*" -5717- ELSE */
            }
            else
            {


                /*" -5718- MOVE 025 TO WS-COD-ERRO */
                _.Move(025, WS_COD_ERRO);

                /*" -5719- MOVE 106 TO WS-COD-CAMPO */
                _.Move(106, WS_COD_CAMPO);

                /*" -5720- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -5721- MOVE 2 TO W-CRITICA-PROPOSTA */
                _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                /*" -5721- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0490_SAIDA*/

        [StopWatch]
        /*" R0491-00-INCLUIR-APOLICOR-SECTION */
        private void R0491_00_INCLUIR_APOLICOR_SECTION()
        {
            /*" -5730- MOVE 'R0491-00-INCLUIR-APOLICOR' TO PARAGRAFO. */
            _.Move("R0491-00-INCLUIR-APOLICOR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5731- MOVE 'INCLUIR APOLICE-CORRETOR' TO COMANDO. */
            _.Move("INCLUIR APOLICE-CORRETOR", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5733- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5734- MOVE SUBGVGAP-NUM-APOLICE TO APOLICOR-NUM-APOLICE */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_NUM_APOLICE);

            /*" -5735- MOVE APOLICES-RAMO-EMISSOR TO APOLICOR-RAMO-COBERTURA */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_RAMO_COBERTURA);

            /*" -5736- MOVE APOLICES-COD-MODALIDADE TO APOLICOR-MODALI-COBERTURA */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_MODALI_COBERTURA);

            /*" -5737- MOVE R5-COD-CORRETOR(WS-POS) TO APOLICOR-COD-CORRETOR */
            _.Move(REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_COD_CORRETOR, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_CORRETOR);

            /*" -5738- MOVE SUBGVGAP-DATA-INIVIGENCIA TO APOLICOR-DATA-INIVIGENCIA */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_INIVIGENCIA, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_INIVIGENCIA);

            /*" -5739- MOVE SUBGVGAP-DATA-TERVIGENCIA TO APOLICOR-DATA-TERVIGENCIA */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_TERVIGENCIA, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_TERVIGENCIA);

            /*" -5740- MOVE R5-PCT-PARTICIPAC(WS-POS) TO APOLICOR-PCT-PART-CORRETOR */
            _.Move(REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_PCT_PARTICIPAC, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_PART_CORRETOR);

            /*" -5741- MOVE R5-PCT-COMERCIALIZ(WS-POS) TO APOLICOR-PCT-COM-CORRETOR */
            _.Move(REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_PCT_COMERCIALIZ, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_COM_CORRETOR);

            /*" -5742- MOVE R5-COD-TIPO-CORR(WS-POS) TO APOLICOR-TIPO-COMISSAO */
            _.Move(REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_COD_TIPO_CORR, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_TIPO_COMISSAO);

            /*" -5744- MOVE 'VG2600B' TO APOLICOR-COD-USUARIO */
            _.Move("VG2600B", APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_USUARIO);

            /*" -5745- IF (WS-POS EQUAL 1) */

            if ((WS_POS == 1))
            {

                /*" -5746- MOVE '1' TO APOLICOR-IND-CORRETOR-PRIN */
                _.Move("1", APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_IND_CORRETOR_PRIN);

                /*" -5747- ELSE */
            }
            else
            {


                /*" -5748- MOVE '2' TO APOLICOR-IND-CORRETOR-PRIN */
                _.Move("2", APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_IND_CORRETOR_PRIN);

                /*" -5750- END-IF */
            }


            /*" -5750- PERFORM R0547-00-INSERT-APOL-CORRET. */

            R0547_00_INSERT_APOL_CORRET_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0491_SAIDA*/

        [StopWatch]
        /*" R0492-00-INCLUIR-INDICADOR-SECTION */
        private void R0492_00_INCLUIR_INDICADOR_SECTION()
        {
            /*" -5760- MOVE 'R0492-00-INCLUIR-INDICADOR' TO PARAGRAFO. */
            _.Move("R0492-00-INCLUIR-INDICADOR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5761- MOVE 'INCLUIR PLANO AGENCIAMENTO' TO COMANDO. */
            _.Move("INCLUIR PLANO AGENCIAMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5763- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5764- MOVE SUBGVGAP-NUM-APOLICE TO PLANOAGE-NUM-APOLICE */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE, PLANOAGE.DCLPLANO_AGENCIAMENTO.PLANOAGE_NUM_APOLICE);

            /*" -5765- MOVE 1 TO PLANOAGE-NUM-PARCELA */
            _.Move(1, PLANOAGE.DCLPLANO_AGENCIAMENTO.PLANOAGE_NUM_PARCELA);

            /*" -5766- MOVE R5-PCT-COMERCIALIZ(WS-POS) TO PLANOAGE-PCT-PAGA-PARCELA */
            _.Move(REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_PCT_COMERCIALIZ, PLANOAGE.DCLPLANO_AGENCIAMENTO.PLANOAGE_PCT_PAGA_PARCELA);

            /*" -5767- MOVE 0 TO PLANOAGE-COD-AGENCIADOR */
            _.Move(0, PLANOAGE.DCLPLANO_AGENCIAMENTO.PLANOAGE_COD_AGENCIADOR);

            /*" -5769- MOVE R5-COD-CORRETOR(WS-POS) TO PLANOAGE-MATRIC-INDICADOR */
            _.Move(REG_R5_CORRETAGEM.R5_TAB_CORRETAGEM.R5_TAB_CORRETAGEM_REG[WS_POS].R5_COD_CORRETOR, PLANOAGE.DCLPLANO_AGENCIAMENTO.PLANOAGE_MATRIC_INDICADOR);

            /*" -5769- PERFORM R0548-00-INSERT-PLANO-AGENC. */

            R0548_00_INSERT_PLANO_AGENC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0492_SAIDA*/

        [StopWatch]
        /*" R0500-00-CARREGA-PLANO-CONDTEC-SECTION */
        private void R0500_00_CARREGA_PLANO_CONDTEC_SECTION()
        {
            /*" -5778- MOVE 'R0500-00-CARREGA-PLANO-CONDTEC' TO PARAGRAFO. */
            _.Move("R0500-00-CARREGA-PLANO-CONDTEC", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5779- MOVE 'CARREGA-PLANOS-VGAP' TO COMANDO. */
            _.Move("CARREGA-PLANOS-VGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5781- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5782- INITIALIZE REG-R6-PLANO-CONDTEC */
            _.Initialize(
                REG_R6_PLANO_CONDTEC
            );

            /*" -5784- MOVE W-TB-MOV-PORTAL(W-IND-TAB) TO REG-R6-PLANO-CONDTEC */
            _.Move(WAREA_AUXILIAR.W_TAB_MOV_PORTAL.W_TAB_MOV_PORTAL_0[WAREA_AUXILIAR.W_IND_TAB].W_TB_MOV_PORTAL, REG_R6_PLANO_CONDTEC);

            /*" -5785- MOVE APOLICES-NUM-APOLICE TO SUBGVGAP-NUM-APOLICE */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

            /*" -5786- IF WS-NUM-APOLICE NOT EQUAL ZEROS */

            if (WS_NUM_APOLICE != 00)
            {

                /*" -5787- MOVE WS-NUM-APOLICE TO SUBGVGAP-NUM-APOLICE */
                _.Move(WS_NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

                /*" -5788- END-IF */
            }


            /*" -5789- MOVE R6-NUM-SUBGRUPO TO SUBGVGAP-COD-SUBGRUPO */
            _.Move(REG_R6_PLANO_CONDTEC.R6_NUM_SUBGRUPO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

            /*" -5791- PERFORM R8014-00-VERIFICA-SUBGRUPO-VG */

            R8014_00_VERIFICA_SUBGRUPO_VG_SECTION();

            /*" -5792- IF (SQLCODE EQUAL ZEROS) */

            if ((DB.SQLCODE == 00))
            {

                /*" -5793- IF (SUBGVGAP-COD-SUBGRUPO > ZEROS) */

                if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO > 00))
                {

                    /*" -5794- PERFORM R0511-00-INCLUIR-COND-TECNICA */

                    R0511_00_INCLUIR_COND_TECNICA_SECTION();

                    /*" -5796- PERFORM R0501-00-INCLUIR-PLANOS-VGAP */

                    R0501_00_INCLUIR_PLANOS_VGAP_SECTION();

                    /*" -5797- IF (R6-NUM-TIPO-PLANO EQUAL 3) */

                    if ((REG_R6_PLANO_CONDTEC.R6_NUM_TIPO_PLANO == 3))
                    {

                        /*" -5798- PERFORM R0502-00-INCLUIR-PLAN-MULTISAL */

                        R0502_00_INCLUIR_PLAN_MULTISAL_SECTION();

                        /*" -5800- END-IF */
                    }


                    /*" -5802- MOVE 1 TO WS-POS */
                    _.Move(1, WS_POS);

                    /*" -5803- IF (R1-COD-PRODUTO NOT EQUAL 8203 AND JVPRD8203) */

                    if ((!REG_R1_SUBGRUPO.R1_COD_PRODUTO.In("8203", JVBKINCL.JV_PRODUTOS.JVPRD8203.ToString())))
                    {

                        /*" -5804- PERFORM UNTIL WS-POS > 06 */

                        while (!(WS_POS > 06))
                        {

                            /*" -5805- IF (R6-VAL-LIM-SUPERIOR(WS-POS) > ZEROS) */

                            if ((REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_LIM_SUPERIOR > 00))
                            {

                                /*" -5806- EVALUATE R6-NUM-TIPO-PLANO */
                                switch (REG_R6_PLANO_CONDTEC.R6_NUM_TIPO_PLANO.Value)
                                {

                                    /*" -5807- WHEN 1 */
                                    case 1:

                                        /*" -5808- PERFORM R0503-00-INCLUIR-FAIX-ETARIA */

                                        R0503_00_INCLUIR_FAIX_ETARIA_SECTION();

                                        /*" -5809- PERFORM R0504-00-INCLUIR-PLAN-ETARIA */

                                        R0504_00_INCLUIR_PLAN_ETARIA_SECTION();

                                        /*" -5810- WHEN 2 */
                                        break;
                                    case 2:

                                        /*" -5811- PERFORM R0505-00-INCLUIR-FAIX-SALARL */

                                        R0505_00_INCLUIR_FAIX_SALARL_SECTION();

                                        /*" -5812- PERFORM R0506-00-INCLUIR-PLAN-SALARL */

                                        R0506_00_INCLUIR_PLAN_SALARL_SECTION();

                                        /*" -5813- WHEN 3 */
                                        break;
                                    case 3:

                                        /*" -5814- PERFORM R0505-00-INCLUIR-FAIX-SALARL */

                                        R0505_00_INCLUIR_FAIX_SALARL_SECTION();

                                        /*" -5815- END-EVALUATE */
                                        break;
                                }


                                /*" -5817- END-IF */
                            }


                            /*" -5818- ADD 1 TO WS-POS */
                            WS_POS.Value = WS_POS + 1;

                            /*" -5819- END-PERFORM */
                        }

                        /*" -5820- ELSE */
                    }
                    else
                    {


                        /*" -5821- EVALUATE R6-NUM-TIPO-PLANO */
                        switch (REG_R6_PLANO_CONDTEC.R6_NUM_TIPO_PLANO.Value)
                        {

                            /*" -5822- WHEN 1 */
                            case 1:

                                /*" -5824- MOVE ZEROS TO R6-VAL-LIM-INFERIOR(WS-POS) */
                                _.Move(0, REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_LIM_INFERIOR);

                                /*" -5826- MOVE 999 TO R6-VAL-LIM-SUPERIOR(WS-POS) */
                                _.Move(999, REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_LIM_SUPERIOR);

                                /*" -5828- MOVE ZEROS TO R6-VAL-PRM-VG(WS-POS) */
                                _.Move(0, REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_PRM_VG);

                                /*" -5829- MOVE 1 TO FAIXAETA-FAIXA */
                                _.Move(1, FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_FAIXA);

                                /*" -5830- PERFORM R0504-00-INCLUIR-PLAN-ETARIA */

                                R0504_00_INCLUIR_PLAN_ETARIA_SECTION();

                                /*" -5831- WHEN 2 */
                                break;
                            case 2:

                            /*" -5832- WHEN 3 */
                            case 3:

                                /*" -5834- MOVE ZEROS TO R6-VAL-LIM-INFERIOR(WS-POS) */
                                _.Move(0, REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_LIM_INFERIOR);

                                /*" -5836- MOVE 9999999999 TO R6-VAL-LIM-SUPERIOR(WS-POS) */
                                _.Move(9999999999, REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_LIM_SUPERIOR);

                                /*" -5838- MOVE ZEROS TO R6-VAL-PRM-VG(WS-POS) */
                                _.Move(0, REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_PRM_VG);

                                /*" -5839- MOVE 1 TO FAIXASAL-FAIXA */
                                _.Move(1, FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_FAIXA);

                                /*" -5840- PERFORM R0506-00-INCLUIR-PLAN-SALARL */

                                R0506_00_INCLUIR_PLAN_SALARL_SECTION();

                                /*" -5841- PERFORM R0505-00-INCLUIR-FAIX-SALARL */

                                R0505_00_INCLUIR_FAIX_SALARL_SECTION();

                                /*" -5842- END-EVALUATE */
                                break;
                        }


                        /*" -5843- END-IF */
                    }


                    /*" -5844- END-IF */
                }


                /*" -5846- ELSE */
            }
            else
            {


                /*" -5847- MOVE 029 TO WS-COD-ERRO */
                _.Move(029, WS_COD_ERRO);

                /*" -5848- MOVE 114 TO WS-COD-CAMPO */
                _.Move(114, WS_COD_CAMPO);

                /*" -5849- PERFORM R9979-00-MONTA-TAB-CRITICA */

                R9979_00_MONTA_TAB_CRITICA_SECTION();

                /*" -5850- MOVE 2 TO W-CRITICA-PROPOSTA */
                _.Move(2, WREA88.W_CRITICA_PROPOSTA);

                /*" -5850- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_SAIDA*/

        [StopWatch]
        /*" R0501-00-INCLUIR-PLANOS-VGAP-SECTION */
        private void R0501_00_INCLUIR_PLANOS_VGAP_SECTION()
        {
            /*" -5859- MOVE 'R0501-00-INCLUIR-PLANOS-VGAP' TO PARAGRAFO. */
            _.Move("R0501-00-INCLUIR-PLANOS-VGAP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5860- MOVE 'INCLUIR PLANOS VGAP         ' TO COMANDO. */
            _.Move("INCLUIR PLANOS VGAP         ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5862- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5863- MOVE SUBGVGAP-NUM-APOLICE TO PLANOVGA-NUM-APOLICE */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_NUM_APOLICE);

            /*" -5865- MOVE SUBGVGAP-COD-SUBGRUPO TO PLANOVGA-COD-SUBGRUPO */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_COD_SUBGRUPO);

            /*" -5867- PERFORM R8032-00-GERAR-MAX-COD-PLANO */

            R8032_00_GERAR_MAX_COD_PLANO_SECTION();

            /*" -5868- MOVE R6-DTA-INI-VIGENCIA TO W-DATA-TRABALHO */
            _.Move(REG_R6_PLANO_CONDTEC.R6_DTA_INI_VIGENCIA, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -5869- PERFORM R8001-00-VERIFICA-DATA-VALIDA */

            R8001_00_VERIFICA_DATA_VALIDA_SECTION();

            /*" -5871- MOVE W-DATA-SQL TO PLANOVGA-DATA-INIVIGENCIA */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_DATA_INIVIGENCIA);

            /*" -5872- MOVE R6-VAL-IMP-MORNATU TO PLANOVGA-IMP-MORNATU */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_IMP_MORNATU, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_MORNATU);

            /*" -5873- MOVE R6-VAL-IMP-MORACID TO PLANOVGA-IMP-MORACID */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_IMP_MORACID, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_MORACID);

            /*" -5874- MOVE R6-VAL-IMP-INVPERM TO PLANOVGA-IMP-INVPERM */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_IMP_INVPERM, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_INVPERM);

            /*" -5875- MOVE R6-VAL-IMP-AMDS TO PLANOVGA-IMP-AMDS */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_IMP_AMDS, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_AMDS);

            /*" -5876- MOVE R6-VAL-IMP-DH TO PLANOVGA-IMP-DH */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_IMP_DH, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_DH);

            /*" -5877- MOVE R6-VAL-IMP-DIT TO PLANOVGA-IMP-DIT */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_IMP_DIT, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_DIT);

            /*" -5878- MOVE '0' TO PLANOVGA-SIT-REGISTRO */
            _.Move("0", PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_SIT_REGISTRO);

            /*" -5880- MOVE '9999-12-31' TO PLANOVGA-DATA-TERVIGENCIA */
            _.Move("9999-12-31", PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_DATA_TERVIGENCIA);

            /*" -5880- PERFORM R0550-00-INSERT-PLANOS-VGAP. */

            R0550_00_INSERT_PLANOS_VGAP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0501_SAIDA*/

        [StopWatch]
        /*" R0502-00-INCLUIR-PLAN-MULTISAL-SECTION */
        private void R0502_00_INCLUIR_PLAN_MULTISAL_SECTION()
        {
            /*" -5889- MOVE 'R0502-00-INCLUIR-PLAN-MULTISAL    ' TO PARAGRAFO. */
            _.Move("R0502-00-INCLUIR-PLAN-MULTISAL    ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5890- MOVE 'INCLUIR PLANOS MULTIPLO SALARIAL  ' TO COMANDO. */
            _.Move("INCLUIR PLANOS MULTIPLO SALARIAL  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5892- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5893- MOVE SUBGVGAP-NUM-APOLICE TO PLANOMUL-NUM-APOLICE */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE, PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_NUM_APOLICE);

            /*" -5894- MOVE SUBGVGAP-COD-SUBGRUPO TO PLANOMUL-COD-SUBGRUPO */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_COD_SUBGRUPO);

            /*" -5895- MOVE PLANOVGA-COD-PLANO TO PLANOMUL-COD-PLANO */
            _.Move(PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_COD_PLANO, PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_COD_PLANO);

            /*" -5896- MOVE R6-QTD-SAL-MORNATU TO PLANOMUL-QTD-SAL-MORNATU */
            _.Move(REG_R6_PLANO_CONDTEC.R6_QTD_SAL_MORNATU, PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_QTD_SAL_MORNATU);

            /*" -5897- MOVE R6-QTD-SAL-MORACID TO PLANOMUL-QTD-SAL-MORACID */
            _.Move(REG_R6_PLANO_CONDTEC.R6_QTD_SAL_MORACID, PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_QTD_SAL_MORACID);

            /*" -5898- MOVE R6-QTD-SAL-INVPERM TO PLANOMUL-QTD-SAL-INVPERM */
            _.Move(REG_R6_PLANO_CONDTEC.R6_QTD_SAL_INVPERM, PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_QTD_SAL_INVPERM);

            /*" -5899- MOVE R6-VAL-LIM-CAP-MORNATU TO PLANOMUL-LIM-CAP-MORNATU */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_LIM_CAP_MORNATU, PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_LIM_CAP_MORNATU);

            /*" -5900- MOVE R6-VAL-LIM-CAP-MORACID TO PLANOMUL-LIM-CAP-MORACID */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_LIM_CAP_MORACID, PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_LIM_CAP_MORACID);

            /*" -5902- MOVE R6-VAL-LIM-CAP-INVPERM TO PLANOMUL-LIM-CAP-INVAPER */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_LIM_CAP_INVPERM, PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_LIM_CAP_INVAPER);

            /*" -5902- PERFORM R0551-00-INSERT-PLAN-MULTISAL. */

            R0551_00_INSERT_PLAN_MULTISAL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0502_SAIDA*/

        [StopWatch]
        /*" R0503-00-INCLUIR-FAIX-ETARIA-SECTION */
        private void R0503_00_INCLUIR_FAIX_ETARIA_SECTION()
        {
            /*" -5911- MOVE 'R0503-00-INCLUIR-FAIX-ETARIA' TO PARAGRAFO. */
            _.Move("R0503-00-INCLUIR-FAIX-ETARIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5912- MOVE 'INCLUIR FAIXA ETARIA        ' TO COMANDO. */
            _.Move("INCLUIR FAIXA ETARIA        ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5914- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5915- MOVE SUBGVGAP-NUM-APOLICE TO FAIXAETA-NUM-APOLICE */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE, FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_NUM_APOLICE);

            /*" -5917- MOVE SUBGVGAP-COD-SUBGRUPO TO FAIXAETA-COD-SUBGRUPO */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_COD_SUBGRUPO);

            /*" -5919- PERFORM R8033-00-GERAR-MAX-FX-ETARIA */

            R8033_00_GERAR_MAX_FX_ETARIA_SECTION();

            /*" -5920- MOVE R6-VAL-LIM-INFERIOR(WS-POS) TO FAIXAETA-IDADE-INICIAL */
            _.Move(REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_LIM_INFERIOR, FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_IDADE_INICIAL);

            /*" -5921- MOVE R6-VAL-LIM-SUPERIOR(WS-POS) TO FAIXAETA-IDADE-FINAL */
            _.Move(REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_LIM_SUPERIOR, FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_IDADE_FINAL);

            /*" -5922- MOVE R6-VAL-TAXA-VG(WS-POS) TO FAIXAETA-TAXA-VG */
            _.Move(REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_TAXA_VG, FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_TAXA_VG);

            /*" -5923- MOVE R6-DTA-INI-VIGENCIA TO W-DATA-TRABALHO */
            _.Move(REG_R6_PLANO_CONDTEC.R6_DTA_INI_VIGENCIA, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -5924- PERFORM R8001-00-VERIFICA-DATA-VALIDA */

            R8001_00_VERIFICA_DATA_VALIDA_SECTION();

            /*" -5925- MOVE W-DATA-SQL TO FAIXAETA-DATA-INIVIGENCIA */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_DATA_INIVIGENCIA);

            /*" -5927- MOVE '9999-12-31' TO FAIXAETA-DATA-TERVIGENCIA */
            _.Move("9999-12-31", FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_DATA_TERVIGENCIA);

            /*" -5927- PERFORM R0552-00-INSERT-FAIXA-ETARIA. */

            R0552_00_INSERT_FAIXA_ETARIA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0503_SAIDA*/

        [StopWatch]
        /*" R0504-00-INCLUIR-PLAN-ETARIA-SECTION */
        private void R0504_00_INCLUIR_PLAN_ETARIA_SECTION()
        {
            /*" -5936- MOVE 'R0504-00-INCLUIR-PLAN-ETARIA' TO PARAGRAFO. */
            _.Move("R0504-00-INCLUIR-PLAN-ETARIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5937- MOVE 'INCLUIR PLANO ETARIA        ' TO COMANDO. */
            _.Move("INCLUIR PLANO ETARIA        ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5939- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5940- MOVE SUBGVGAP-NUM-APOLICE TO PLANOFAI-NUM-APOLICE */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE, PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_NUM_APOLICE);

            /*" -5941- MOVE SUBGVGAP-COD-SUBGRUPO TO PLANOFAI-COD-SUBGRUPO */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_COD_SUBGRUPO);

            /*" -5942- MOVE PLANOVGA-COD-PLANO TO PLANOFAI-COD-PLANO */
            _.Move(PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_COD_PLANO, PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_COD_PLANO);

            /*" -5943- MOVE FAIXAETA-FAIXA TO PLANOFAI-FAIXA */
            _.Move(FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_FAIXA, PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_FAIXA);

            /*" -5944- MOVE R6-VAL-LIM-INFERIOR(WS-POS) TO PLANOFAI-IDADE-INICIAL */
            _.Move(REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_LIM_INFERIOR, PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_IDADE_INICIAL);

            /*" -5945- MOVE R6-VAL-LIM-SUPERIOR(WS-POS) TO PLANOFAI-IDADE-FINAL */
            _.Move(REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_LIM_SUPERIOR, PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_IDADE_FINAL);

            /*" -5946- MOVE R6-VAL-PRM-VG(WS-POS) TO PLANOFAI-PRM-VG */
            _.Move(REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_PRM_VG, PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_PRM_VG);

            /*" -5947- MOVE R6-VAL-PRM-AP TO PLANOFAI-PRM-AP */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_PRM_AP, PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_PRM_AP);

            /*" -5948- MOVE R6-DTA-INI-VIGENCIA TO W-DATA-TRABALHO */
            _.Move(REG_R6_PLANO_CONDTEC.R6_DTA_INI_VIGENCIA, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -5949- PERFORM R8001-00-VERIFICA-DATA-VALIDA */

            R8001_00_VERIFICA_DATA_VALIDA_SECTION();

            /*" -5950- MOVE W-DATA-SQL TO PLANOFAI-DATA-INIVIGENCIA */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_DATA_INIVIGENCIA);

            /*" -5952- MOVE '9999-12-31' TO PLANOFAI-DATA-TERVIGENCIA */
            _.Move("9999-12-31", PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_DATA_TERVIGENCIA);

            /*" -5952- PERFORM R0553-00-INSERT-PLANO-ETARIA. */

            R0553_00_INSERT_PLANO_ETARIA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0504_SAIDA*/

        [StopWatch]
        /*" R0505-00-INCLUIR-FAIX-SALARL-SECTION */
        private void R0505_00_INCLUIR_FAIX_SALARL_SECTION()
        {
            /*" -5961- MOVE 'R0505-00-INCLUIR-FAIX-SALARL' TO PARAGRAFO. */
            _.Move("R0505-00-INCLUIR-FAIX-SALARL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5962- MOVE 'INCLUIR FAIXA SALARIAL      ' TO COMANDO. */
            _.Move("INCLUIR FAIXA SALARIAL      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5964- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5965- MOVE SUBGVGAP-NUM-APOLICE TO FAIXASAL-NUM-APOLICE */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE, FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_NUM_APOLICE);

            /*" -5967- MOVE SUBGVGAP-COD-SUBGRUPO TO FAIXASAL-COD-SUBGRUPO */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_COD_SUBGRUPO);

            /*" -5969- PERFORM R8034-00-GERAR-MAX-FX-SALARL */

            R8034_00_GERAR_MAX_FX_SALARL_SECTION();

            /*" -5971- COMPUTE FAIXASAL-SALARIO-INICIAL = R6-VAL-LIM-INFERIOR(WS-POS) / 100 */
            FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_SALARIO_INICIAL.Value = REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_LIM_INFERIOR.Value / 100f;

            /*" -5974- COMPUTE FAIXASAL-SALARIO-FINAL = R6-VAL-LIM-SUPERIOR(WS-POS) / 100 */
            FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_SALARIO_FINAL.Value = REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_LIM_SUPERIOR.Value / 100f;

            /*" -5976- IF FAIXASAL-SALARIO-INICIAL = 0 AND FAIXASAL-SALARIO-FINAL > 0 */

            if (FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_SALARIO_INICIAL == 0 && FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_SALARIO_FINAL > 0)
            {

                /*" -5977- MOVE 0,01 TO FAIXASAL-SALARIO-INICIAL */
                _.Move(0.01, FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_SALARIO_INICIAL);

                /*" -5979- END-IF */
            }


            /*" -5981- MOVE R6-VAL-TAXA-VG(WS-POS) TO FAIXASAL-TAXA-VG */
            _.Move(REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_TAXA_VG, FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_TAXA_VG);

            /*" -5981- PERFORM R0554-00-INSERT-FAIXA-SALARL. */

            R0554_00_INSERT_FAIXA_SALARL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0505_SAIDA*/

        [StopWatch]
        /*" R0506-00-INCLUIR-PLAN-SALARL-SECTION */
        private void R0506_00_INCLUIR_PLAN_SALARL_SECTION()
        {
            /*" -5990- MOVE 'R0506-00-INCLUIR-PLAN-SALARL' TO PARAGRAFO. */
            _.Move("R0506-00-INCLUIR-PLAN-SALARL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5991- MOVE 'INCLUIR PLANO SALARIAL      ' TO COMANDO. */
            _.Move("INCLUIR PLANO SALARIAL      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5993- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5994- MOVE SUBGVGAP-NUM-APOLICE TO PLANFSAL-NUM-APOLICE */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE, PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_NUM_APOLICE);

            /*" -5995- MOVE SUBGVGAP-COD-SUBGRUPO TO PLANFSAL-COD-SUBGRUPO */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_COD_SUBGRUPO);

            /*" -5996- MOVE PLANOVGA-COD-PLANO TO PLANFSAL-COD-PLANO */
            _.Move(PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_COD_PLANO, PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_COD_PLANO);

            /*" -5997- MOVE FAIXASAL-FAIXA TO PLANFSAL-FAIXA */
            _.Move(FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_FAIXA, PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_FAIXA);

            /*" -5999- COMPUTE PLANFSAL-SALARIO-INICIAL = R6-VAL-LIM-INFERIOR(WS-POS) / 100 */
            PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_SALARIO_INICIAL.Value = REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_LIM_INFERIOR.Value / 100f;

            /*" -6002- COMPUTE PLANFSAL-SALARIO-FINAL = R6-VAL-LIM-SUPERIOR(WS-POS) / 100 */
            PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_SALARIO_FINAL.Value = REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_LIM_SUPERIOR.Value / 100f;

            /*" -6004- IF PLANFSAL-SALARIO-INICIAL = 0 AND PLANFSAL-SALARIO-FINAL > 0 */

            if (PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_SALARIO_INICIAL == 0 && PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_SALARIO_FINAL > 0)
            {

                /*" -6005- MOVE 0,01 TO PLANFSAL-SALARIO-INICIAL */
                _.Move(0.01, PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_SALARIO_INICIAL);

                /*" -6007- END-IF */
            }


            /*" -6008- MOVE R6-VAL-PRM-VG(WS-POS) TO PLANFSAL-PRM-VG */
            _.Move(REG_R6_PLANO_CONDTEC.R6_TAB_LIM_TAXAS.R6_TAB_LIM_TAXAS_REG[WS_POS].R6_VAL_PRM_VG, PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_PRM_VG);

            /*" -6010- MOVE R6-VAL-PRM-AP TO PLANFSAL-PRM-AP */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_PRM_AP, PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_PRM_AP);

            /*" -6010- PERFORM R0555-00-INSERT-PLANO-SALARL. */

            R0555_00_INSERT_PLANO_SALARL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0506_SAIDA*/

        [StopWatch]
        /*" R0511-00-INCLUIR-COND-TECNICA-SECTION */
        private void R0511_00_INCLUIR_COND_TECNICA_SECTION()
        {
            /*" -6019- MOVE 'R0511-00-INCLUIR-COND-TECNICA' TO PARAGRAFO. */
            _.Move("R0511-00-INCLUIR-COND-TECNICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6020- MOVE 'INCLUIR CONDICOES TECNICAS ' TO COMANDO. */
            _.Move("INCLUIR CONDICOES TECNICAS ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6022- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6023- MOVE SUBGVGAP-NUM-APOLICE TO CONDITEC-NUM-APOLICE */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_NUM_APOLICE);

            /*" -6024- MOVE SUBGVGAP-COD-SUBGRUPO TO CONDITEC-COD-SUBGRUPO */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_COD_SUBGRUPO);

            /*" -6025- MOVE R6-QTD-SAL-MORNATU TO CONDITEC-QTD-SAL-MORNATU */
            _.Move(REG_R6_PLANO_CONDTEC.R6_QTD_SAL_MORNATU, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_MORNATU);

            /*" -6026- MOVE R6-QTD-SAL-MORACID TO CONDITEC-QTD-SAL-MORACID */
            _.Move(REG_R6_PLANO_CONDTEC.R6_QTD_SAL_MORACID, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_MORACID);

            /*" -6027- MOVE R6-QTD-SAL-INVPERM TO CONDITEC-QTD-SAL-INVPERM */
            _.Move(REG_R6_PLANO_CONDTEC.R6_QTD_SAL_INVPERM, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_INVPERM);

            /*" -6028- MOVE R6-VAL-TAXA-AP-MORACID TO CONDITEC-TAXA-AP-MORACID */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_AP_MORACID, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_MORACID);

            /*" -6029- MOVE R6-VAL-TAXA-AP-INVPERM TO CONDITEC-TAXA-AP-INVPERM */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_AP_INVPERM, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_INVPERM);

            /*" -6030- MOVE R6-VAL-TAXA-AP-AMDS TO CONDITEC-TAXA-AP-AMDS */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_AP_AMDS, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_AMDS);

            /*" -6031- MOVE R6-VAL-TAXA-AP-DH TO CONDITEC-TAXA-AP-DH */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_AP_DH, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DH);

            /*" -6032- MOVE R6-VAL-TAXA-AP-DIT TO CONDITEC-TAXA-AP-DIT */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_AP_DIT, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DIT);

            /*" -6033- MOVE R6-VAL-TAXA-AP TO CONDITEC-TAXA-AP */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_AP, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP);

            /*" -6034- MOVE R6-VAL-CARREGA-PRINC TO CONDITEC-CARREGA-PRINCIPAL */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_CARREGA_PRINC, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_PRINCIPAL);

            /*" -6035- MOVE R6-VAL-CARREGA-CONJ TO CONDITEC-CARREGA-CONJUGE */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_CARREGA_CONJ, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE);

            /*" -6036- MOVE R6-VAL-CARREGA-FILHO TO CONDITEC-CARREGA-FILHOS */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_CARREGA_FILHO, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_FILHOS);

            /*" -6037- MOVE R6-VAL-GARAN-ADIC-IEA TO CONDITEC-GARAN-ADIC-IEA */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_GARAN_ADIC_IEA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IEA);

            /*" -6038- MOVE R6-VAL-GARAN-ADIC-IPA TO CONDITEC-GARAN-ADIC-IPA */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_GARAN_ADIC_IPA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPA);

            /*" -6039- MOVE R6-VAL-GARAN-ADIC-IPD TO CONDITEC-GARAN-ADIC-IPD */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_GARAN_ADIC_IPD, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPD);

            /*" -6040- MOVE R6-VAL-GARAN-ADIC-HD TO CONDITEC-GARAN-ADIC-HD */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_GARAN_ADIC_HD, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_HD);

            /*" -6041- MOVE R6-VAL-TAXA-DESP-ADM TO CONDITEC-TAXA-DESPESA-ADM */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_DESP_ADM, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_DESPESA_ADM);

            /*" -6042- MOVE R6-VAL-TAXA-IRB TO CONDITEC-TAXA-IRB */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_TAXA_IRB, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_IRB);

            /*" -6043- MOVE R6-VAL-LIM-CAP-MORNATU TO CONDITEC-LIM-CAP-MORNATU */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_LIM_CAP_MORNATU, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_LIM_CAP_MORNATU);

            /*" -6044- MOVE R6-VAL-LIM-CAP-MORACID TO CONDITEC-LIM-CAP-MORACID */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_LIM_CAP_MORACID, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_LIM_CAP_MORACID);

            /*" -6046- MOVE R6-VAL-LIM-CAP-INVPERM TO CONDITEC-LIM-CAP-INVAPER */
            _.Move(REG_R6_PLANO_CONDTEC.R6_VAL_LIM_CAP_INVPERM, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_LIM_CAP_INVAPER);

            /*" -6046- PERFORM R0549-00-INSERT-COND-TECNICA. */

            R0549_00_INSERT_COND_TECNICA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0511_SAIDA*/

        [StopWatch]
        /*" R0530-00-INSERT-CLIENTE-SECTION */
        private void R0530_00_INSERT_CLIENTE_SECTION()
        {
            /*" -6055- MOVE 'R0530-00-INSERT-CLIENTE ' TO PARAGRAFO. */
            _.Move("R0530-00-INSERT-CLIENTE ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6056- MOVE 'INSERT CLIENTE          ' TO COMANDO. */
            _.Move("INSERT CLIENTE          ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6058- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6060- PERFORM R8035-00-GERAR-MAX-COD-CLIENTE */

            R8035_00_GERAR_MAX_COD_CLIENTE_SECTION();

            /*" -6061- MOVE R1-NOM-EMPRESA TO CLIENTES-NOME-RAZAO */
            _.Move(REG_R1_SUBGRUPO.R1_NOM_EMPRESA, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

            /*" -6062- MOVE 'J' TO CLIENTES-TIPO-PESSOA */
            _.Move("J", CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);

            /*" -6063- MOVE R1-NUM-CGC-CNPJ TO CLIENTES-CGCCPF */
            _.Move(REG_R1_SUBGRUPO.R1_NUM_CGC_CNPJ, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);

            /*" -6064- IF R1-COD-PORTE-EMP = 0 */

            if (REG_R1_SUBGRUPO.R1_COD_PORTE_EMP == 0)
            {

                /*" -6065- MOVE -1 TO VN-COD-PORTE-EMP */
                _.Move(-1, VN_COD_PORTE_EMP);

                /*" -6066- ELSE */
            }
            else
            {


                /*" -6067- MOVE 0 TO VN-COD-PORTE-EMP */
                _.Move(0, VN_COD_PORTE_EMP);

                /*" -6068- END-IF */
            }


            /*" -6068- MOVE R1-COD-PORTE-EMP TO CLIENTES-COD-PORTE-EMP. */
            _.Move(REG_R1_SUBGRUPO.R1_COD_PORTE_EMP, CLIENTES.DCLCLIENTES.CLIENTES_COD_PORTE_EMP);

            /*" -0- FLUXCONTROL_PERFORM R0530_10_INSERT_CLIENTE */

            R0530_10_INSERT_CLIENTE();

        }

        [StopWatch]
        /*" R0530-10-INSERT-CLIENTE */
        private void R0530_10_INSERT_CLIENTE(bool isPerform = false)
        {
            /*" -6110- PERFORM R0530_10_INSERT_CLIENTE_DB_INSERT_1 */

            R0530_10_INSERT_CLIENTE_DB_INSERT_1();

            /*" -6114- IF (SQLCODE NOT EQUAL ZEROS AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -6115- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -6116- DISPLAY '          ERRO INSERT TABELA CLIENTES     ' */
                _.Display($"          ERRO INSERT TABELA CLIENTES     ");

                /*" -6118- DISPLAY '          COD CLIENTE...................  ' CLIENTES-COD-CLIENTE */
                _.Display($"          COD CLIENTE...................  {CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE}");

                /*" -6120- DISPLAY '          NOME RAZAO....................  ' CLIENTES-NOME-RAZAO */
                _.Display($"          NOME RAZAO....................  {CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO}");

                /*" -6122- DISPLAY '          TIPO PESSOA...................  ' CLIENTES-TIPO-PESSOA */
                _.Display($"          TIPO PESSOA...................  {CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA}");

                /*" -6124- DISPLAY '          CGCCPF........................  ' CLIENTES-CGCCPF */
                _.Display($"          CGCCPF........................  {CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF}");

                /*" -6125- MOVE VN-COD-PORTE-EMP TO VN-COD-PORTE-EMP-ED */
                _.Move(VN_COD_PORTE_EMP, VN_COD_PORTE_EMP_ED);

                /*" -6128- DISPLAY '          COD-PORTE-EMP.................  ' VN-COD-PORTE-EMP-ED '/' CLIENTES-COD-PORTE-EMP */

                $"          COD-PORTE-EMP.................  {VN_COD_PORTE_EMP_ED}/{CLIENTES.DCLCLIENTES.CLIENTES_COD_PORTE_EMP}"
                .Display();

                /*" -6130- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -6131- DISPLAY '          SQLERRMC<' SQLERRMC '>' */

                $"          SQLERRMC<{DB.SQLERRMC}>"
                .Display();

                /*" -6132- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -6134- END-IF. */
            }


            /*" -6135- IF SQLCODE = -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -6136- PERFORM R8035-00-GERAR-MAX-COD-CLIENTE */

                R8035_00_GERAR_MAX_COD_CLIENTE_SECTION();

                /*" -6137- GO TO R0530-10-INSERT-CLIENTE */
                new Task(() => R0530_10_INSERT_CLIENTE()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -6139- END-IF */
            }


            /*" -6139- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0530-10-INSERT-CLIENTE-DB-INSERT-1 */
        public void R0530_10_INSERT_CLIENTE_DB_INSERT_1()
        {
            /*" -6110- EXEC SQL INSERT INTO SEGUROS.CLIENTES ( COD_CLIENTE , NOME_RAZAO , TIPO_PESSOA , CGCCPF , SIT_REGISTRO , DATA_NASCIMENTO , COD_EMPRESA , COD_PORTE_EMP , COD_NATUREZA_ATIV , COD_RAMO_ATIVIDADE , COD_ATIVIDADE , IDE_SEXO , ESTADO_CIVIL , COD_GRD_GRUPO_CBO , COD_SUBGRUPO_CBO , COD_GRUPO_BASE_CBO , COD_SUBGR_BASE_CBO ) VALUES( :CLIENTES-COD-CLIENTE -- COD_CLIENTE , :CLIENTES-NOME-RAZAO -- NOME_RAZAO , :CLIENTES-TIPO-PESSOA -- TIPO_PESSOA , :CLIENTES-CGCCPF -- CGCCPF , '0' -- SIT_REGISTRO , NULL -- DATA_NASCIMENTO , NULL -- COD_EMPRESA , :CLIENTES-COD-PORTE-EMP -- COD_PORTE_EMP INDICATOR :VN-COD-PORTE-EMP , NULL -- COD_NATUREZA_ATIV , NULL -- COD_RAMO_ATIVIDADE , NULL -- COD_ATIVIDADE , NULL -- IDE_SEXO , NULL -- ESTADO_CIVIL , NULL -- COD_GRD_GRUPO_CBO , NULL -- COD_SUBGRUPO_CBO , NULL -- COD_GRUPO_BASE_CBO , NULL -- COD_SUBGR_BASE_CBO ) END-EXEC */

            var r0530_10_INSERT_CLIENTE_DB_INSERT_1_Insert1 = new R0530_10_INSERT_CLIENTE_DB_INSERT_1_Insert1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
                CLIENTES_NOME_RAZAO = CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO.ToString(),
                CLIENTES_TIPO_PESSOA = CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA.ToString(),
                CLIENTES_CGCCPF = CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF.ToString(),
                CLIENTES_COD_PORTE_EMP = CLIENTES.DCLCLIENTES.CLIENTES_COD_PORTE_EMP.ToString(),
                VN_COD_PORTE_EMP = VN_COD_PORTE_EMP.ToString(),
            };

            R0530_10_INSERT_CLIENTE_DB_INSERT_1_Insert1.Execute(r0530_10_INSERT_CLIENTE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0530_SAIDA*/

        [StopWatch]
        /*" R0531-00-INSERT-APOLICE-SECTION */
        private void R0531_00_INSERT_APOLICE_SECTION()
        {
            /*" -6149- MOVE 'R0531-00-INSERT-APOLICE' TO PARAGRAFO. */
            _.Move("R0531-00-INSERT-APOLICE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6150- MOVE 'INSERT APOLICES       ' TO COMANDO. */
            _.Move("INSERT APOLICES       ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6152- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6180- PERFORM R0531_00_INSERT_APOLICE_DB_INSERT_1 */

            R0531_00_INSERT_APOLICE_DB_INSERT_1();

            /*" -6183- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -6184- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -6185- DISPLAY '          ERRO INSERT DA TABELA APOLICES' */
                _.Display($"          ERRO INSERT DA TABELA APOLICES");

                /*" -6187- DISPLAY '          NUM APOLICE...................  ' APOLICES-NUM-APOLICE */
                _.Display($"          NUM APOLICE...................  {APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE}");

                /*" -6189- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA */
                _.Display($"          NUMERO PROPOSTA...............  {REG_R1_SUBGRUPO.R1_NUM_PROPOSTA}");

                /*" -6191- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -6192- DISPLAY '          SQLERRMC<' SQLERRMC '>' */

                $"          SQLERRMC<{DB.SQLERRMC}>"
                .Display();

                /*" -6193- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -6195- END-IF. */
            }


            /*" -6195- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0531-00-INSERT-APOLICE-DB-INSERT-1 */
        public void R0531_00_INSERT_APOLICE_DB_INSERT_1()
        {
            /*" -6180- EXEC SQL INSERT INTO SEGUROS.APOLICES VALUES (:APOLICES-COD-CLIENTE , :APOLICES-NUM-APOLICE , :APOLICES-NUM-ITEM , :APOLICES-COD-MODALIDADE , :APOLICES-ORGAO-EMISSOR , :APOLICES-RAMO-EMISSOR , :APOLICES-COD-PRODUTO , :APOLICES-NUM-APOL-ANTERIOR , :APOLICES-NUM-BILHETE , :APOLICES-TIPO-SEGURO , :APOLICES-TIPO-APOLICE , :APOLICES-TIPO-CALCULO , :APOLICES-IND-SORTEIO , :APOLICES-NUM-ATA , :APOLICES-ANO-ATA , :APOLICES-IND-ENDOS-MANUAL , :APOLICES-PCT-DESC-PREMIO , :APOLICES-PCT-IOCC , :APOLICES-TIPO-COSSEGURO-CED, :APOLICES-QTD-COSSEGURADORA , :APOLICES-PCT-COSSEGURO-CED , NULL , NULL , CURRENT_TIMESTAMP , NULL ) END-EXEC. */

            var r0531_00_INSERT_APOLICE_DB_INSERT_1_Insert1 = new R0531_00_INSERT_APOLICE_DB_INSERT_1_Insert1()
            {
                APOLICES_COD_CLIENTE = APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE.ToString(),
                APOLICES_NUM_APOLICE = APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.ToString(),
                APOLICES_NUM_ITEM = APOLICES.DCLAPOLICES.APOLICES_NUM_ITEM.ToString(),
                APOLICES_COD_MODALIDADE = APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE.ToString(),
                APOLICES_ORGAO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR.ToString(),
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
                APOLICES_COD_PRODUTO = APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO.ToString(),
                APOLICES_NUM_APOL_ANTERIOR = APOLICES.DCLAPOLICES.APOLICES_NUM_APOL_ANTERIOR.ToString(),
                APOLICES_NUM_BILHETE = APOLICES.DCLAPOLICES.APOLICES_NUM_BILHETE.ToString(),
                APOLICES_TIPO_SEGURO = APOLICES.DCLAPOLICES.APOLICES_TIPO_SEGURO.ToString(),
                APOLICES_TIPO_APOLICE = APOLICES.DCLAPOLICES.APOLICES_TIPO_APOLICE.ToString(),
                APOLICES_TIPO_CALCULO = APOLICES.DCLAPOLICES.APOLICES_TIPO_CALCULO.ToString(),
                APOLICES_IND_SORTEIO = APOLICES.DCLAPOLICES.APOLICES_IND_SORTEIO.ToString(),
                APOLICES_NUM_ATA = APOLICES.DCLAPOLICES.APOLICES_NUM_ATA.ToString(),
                APOLICES_ANO_ATA = APOLICES.DCLAPOLICES.APOLICES_ANO_ATA.ToString(),
                APOLICES_IND_ENDOS_MANUAL = APOLICES.DCLAPOLICES.APOLICES_IND_ENDOS_MANUAL.ToString(),
                APOLICES_PCT_DESC_PREMIO = APOLICES.DCLAPOLICES.APOLICES_PCT_DESC_PREMIO.ToString(),
                APOLICES_PCT_IOCC = APOLICES.DCLAPOLICES.APOLICES_PCT_IOCC.ToString(),
                APOLICES_TIPO_COSSEGURO_CED = APOLICES.DCLAPOLICES.APOLICES_TIPO_COSSEGURO_CED.ToString(),
                APOLICES_QTD_COSSEGURADORA = APOLICES.DCLAPOLICES.APOLICES_QTD_COSSEGURADORA.ToString(),
                APOLICES_PCT_COSSEGURO_CED = APOLICES.DCLAPOLICES.APOLICES_PCT_COSSEGURO_CED.ToString(),
            };

            R0531_00_INSERT_APOLICE_DB_INSERT_1_Insert1.Execute(r0531_00_INSERT_APOLICE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0531_SAIDA*/

        [StopWatch]
        /*" R0532-00-INSERT-SUBGRUPO-SECTION */
        private void R0532_00_INSERT_SUBGRUPO_SECTION()
        {
            /*" -6204- MOVE 'R0532-00-INSERT-SUBGRUPO' TO PARAGRAFO. */
            _.Move("R0532-00-INSERT-SUBGRUPO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6205- MOVE 'INSERT SUBGRUPO         ' TO COMANDO. */
            _.Move("INSERT SUBGRUPO         ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6207- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6245- PERFORM R0532_00_INSERT_SUBGRUPO_DB_INSERT_1 */

            R0532_00_INSERT_SUBGRUPO_DB_INSERT_1();

            /*" -6248- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -6249- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -6250- DISPLAY '          ERRO INSERT DA TABELA SUBGRUPO ' */
                _.Display($"          ERRO INSERT DA TABELA SUBGRUPO ");

                /*" -6252- DISPLAY '          NUM APOLICE...................  ' SUBGVGAP-NUM-APOLICE */
                _.Display($"          NUM APOLICE...................  {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                /*" -6254- DISPLAY '          COD SUBGRUPO..................  ' SUBGVGAP-COD-SUBGRUPO */
                _.Display($"          COD SUBGRUPO..................  {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                /*" -6256- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA */
                _.Display($"          NUMERO PROPOSTA...............  {REG_R1_SUBGRUPO.R1_NUM_PROPOSTA}");

                /*" -6258- DISPLAY '          DATA-INCLUSAO.................  ' SUBGVGAP-DATA-INCLUSAO */
                _.Display($"          DATA-INCLUSAO.................  {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_INCLUSAO}");

                /*" -6260- DISPLAY '          DATA-INIVIGENCIA..............  ' SUBGVGAP-DATA-INIVIGENCIA */
                _.Display($"          DATA-INIVIGENCIA..............  {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_INIVIGENCIA}");

                /*" -6262- DISPLAY '          DATA-TERVIGENCIA..............  ' SUBGVGAP-DATA-TERVIGENCIA */
                _.Display($"          DATA-TERVIGENCIA..............  {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_TERVIGENCIA}");

                /*" -6264- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -6266- DISPLAY '          SQLERRMC......................  ' SQLERRMC */
                _.Display($"          SQLERRMC......................  {DB.SQLERRMC}");

                /*" -6267- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -6269- END-IF. */
            }


            /*" -6271- ADD 1 TO WS-TOTAL-INSERT WS-SUBG-GRAVADOS */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;
            WAREA_AUXILIAR.WS_SUBG_GRAVADOS.Value = WAREA_AUXILIAR.WS_SUBG_GRAVADOS + 1;

            /*" -6271- . */

        }

        [StopWatch]
        /*" R0532-00-INSERT-SUBGRUPO-DB-INSERT-1 */
        public void R0532_00_INSERT_SUBGRUPO_DB_INSERT_1()
        {
            /*" -6245- EXEC SQL INSERT INTO SEGUROS.SUBGRUPOS_VGAP VALUES (:SUBGVGAP-NUM-APOLICE , :SUBGVGAP-COD-SUBGRUPO , :SUBGVGAP-COD-CLIENTE , :SUBGVGAP-CLASSE-APOLICE , :SUBGVGAP-COD-FONTE , :SUBGVGAP-TIPO-FATURAMENTO , :SUBGVGAP-FORMA-FATURAMENTO , :SUBGVGAP-FORMA-AVERBACAO , :SUBGVGAP-TIPO-PLANO , :SUBGVGAP-PERI-FATURAMENTO , :SUBGVGAP-PERI-RENOVACAO , :SUBGVGAP-PERI-RETROATI-INC , :SUBGVGAP-PERI-RETROATI-CAN , :SUBGVGAP-OCORR-ENDERECO , :SUBGVGAP-OCORR-END-COBRAN , :SUBGVGAP-BCO-COBRANCA , :SUBGVGAP-AGE-COBRANCA , :SUBGVGAP-DAC-COBRANCA , :SUBGVGAP-TIPO-COBRANCA , :SUBGVGAP-COD-PAG-ANGARIACAO , :SUBGVGAP-PCT-CONJUGE-VG , :SUBGVGAP-PCT-CONJUGE-AP , :SUBGVGAP-OPCAO-COBERTURA , :SUBGVGAP-OPCAO-CORRETAGEM , :SUBGVGAP-IND-CONSISTE-MATRI , :SUBGVGAP-IND-PLANO-ASSOCIA , :SUBGVGAP-SIT-REGISTRO , :SUBGVGAP-OPCAO-CONJUGE , NULL , :SUBGVGAP-TIPO-SUBGRUPO , :SUBGVGAP-DATA-INCLUSAO , :SUBGVGAP-DATA-INIVIGENCIA , :SUBGVGAP-DATA-TERVIGENCIA , :SUBGVGAP-IND-IOF , :SUBGVGAP-TIPO-POSTAGEM ) END-EXEC. */

            var r0532_00_INSERT_SUBGRUPO_DB_INSERT_1_Insert1 = new R0532_00_INSERT_SUBGRUPO_DB_INSERT_1_Insert1()
            {
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_COD_CLIENTE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE.ToString(),
                SUBGVGAP_CLASSE_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_CLASSE_APOLICE.ToString(),
                SUBGVGAP_COD_FONTE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE.ToString(),
                SUBGVGAP_TIPO_FATURAMENTO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_FATURAMENTO.ToString(),
                SUBGVGAP_FORMA_FATURAMENTO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_FORMA_FATURAMENTO.ToString(),
                SUBGVGAP_FORMA_AVERBACAO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_FORMA_AVERBACAO.ToString(),
                SUBGVGAP_TIPO_PLANO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO.ToString(),
                SUBGVGAP_PERI_FATURAMENTO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO.ToString(),
                SUBGVGAP_PERI_RENOVACAO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_RENOVACAO.ToString(),
                SUBGVGAP_PERI_RETROATI_INC = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_RETROATI_INC.ToString(),
                SUBGVGAP_PERI_RETROATI_CAN = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_RETROATI_CAN.ToString(),
                SUBGVGAP_OCORR_ENDERECO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OCORR_ENDERECO.ToString(),
                SUBGVGAP_OCORR_END_COBRAN = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OCORR_END_COBRAN.ToString(),
                SUBGVGAP_BCO_COBRANCA = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_BCO_COBRANCA.ToString(),
                SUBGVGAP_AGE_COBRANCA = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_AGE_COBRANCA.ToString(),
                SUBGVGAP_DAC_COBRANCA = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DAC_COBRANCA.ToString(),
                SUBGVGAP_TIPO_COBRANCA = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_COBRANCA.ToString(),
                SUBGVGAP_COD_PAG_ANGARIACAO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_PAG_ANGARIACAO.ToString(),
                SUBGVGAP_PCT_CONJUGE_VG = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PCT_CONJUGE_VG.ToString(),
                SUBGVGAP_PCT_CONJUGE_AP = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PCT_CONJUGE_AP.ToString(),
                SUBGVGAP_OPCAO_COBERTURA = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_COBERTURA.ToString(),
                SUBGVGAP_OPCAO_CORRETAGEM = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CORRETAGEM.ToString(),
                SUBGVGAP_IND_CONSISTE_MATRI = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_CONSISTE_MATRI.ToString(),
                SUBGVGAP_IND_PLANO_ASSOCIA = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_PLANO_ASSOCIA.ToString(),
                SUBGVGAP_SIT_REGISTRO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_SIT_REGISTRO.ToString(),
                SUBGVGAP_OPCAO_CONJUGE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE.ToString(),
                SUBGVGAP_TIPO_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_SUBGRUPO.ToString(),
                SUBGVGAP_DATA_INCLUSAO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_INCLUSAO.ToString(),
                SUBGVGAP_DATA_INIVIGENCIA = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_INIVIGENCIA.ToString(),
                SUBGVGAP_DATA_TERVIGENCIA = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_TERVIGENCIA.ToString(),
                SUBGVGAP_IND_IOF = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_IOF.ToString(),
                SUBGVGAP_TIPO_POSTAGEM = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_POSTAGEM.ToString(),
            };

            R0532_00_INSERT_SUBGRUPO_DB_INSERT_1_Insert1.Execute(r0532_00_INSERT_SUBGRUPO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0532_SAIDA*/

        [StopWatch]
        /*" R0533-00-INSERT-ENDOSSOS-SECTION */
        private void R0533_00_INSERT_ENDOSSOS_SECTION()
        {
            /*" -6280- MOVE 'R0533-00-INSERT-ENDOSSOS' TO PARAGRAFO. */
            _.Move("R0533-00-INSERT-ENDOSSOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6281- MOVE 'INSERT ENDOSSOS         ' TO COMANDO. */
            _.Move("INSERT ENDOSSOS         ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6283- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6330- PERFORM R0533_00_INSERT_ENDOSSOS_DB_INSERT_1 */

            R0533_00_INSERT_ENDOSSOS_DB_INSERT_1();

            /*" -6333- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -6334- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -6335- DISPLAY '          ERRO INSERT DA TABELA ENDOSSOS ' */
                _.Display($"          ERRO INSERT DA TABELA ENDOSSOS ");

                /*" -6337- DISPLAY '          NUM APOLICE...................  ' ENDOSSOS-NUM-APOLICE */
                _.Display($"          NUM APOLICE...................  {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                /*" -6339- DISPLAY '          COD SUBGRUPO..................  ' ENDOSSOS-COD-SUBGRUPO */
                _.Display($"          COD SUBGRUPO..................  {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO}");

                /*" -6341- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA */
                _.Display($"          NUMERO PROPOSTA...............  {REG_R1_SUBGRUPO.R1_NUM_PROPOSTA}");

                /*" -6343- DISPLAY '          ENDOSSOS-COD-FONTE............  ' ENDOSSOS-COD-FONTE */
                _.Display($"          ENDOSSOS-COD-FONTE............  {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE}");

                /*" -6345- DISPLAY '          ENDOSSOS-NUM-PROPOSTA.........  ' ENDOSSOS-NUM-PROPOSTA */
                _.Display($"          ENDOSSOS-NUM-PROPOSTA.........  {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA}");

                /*" -6347- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -6349- DISPLAY '          SQLERRMC......................  ' SQLERRMC */
                _.Display($"          SQLERRMC......................  {DB.SQLERRMC}");

                /*" -6350- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -6352- END-IF. */
            }


            /*" -6361- DISPLAY 'VG2600B-INSERT ENDOSSOS:' ' R1-NUM-PROPOSTA=' R1-NUM-PROPOSTA ' APOLICE=' ENDOSSOS-NUM-APOLICE ' RAMO=' ENDOSSOS-RAMO-EMISSOR ' ENDOSSO=' ENDOSSOS-NUM-ENDOSSO ' SUBGRUPO=' ENDOSSOS-COD-SUBGRUPO ' FONTE=' ENDOSSOS-COD-FONTE ' PROPOSTA=' ENDOSSOS-NUM-PROPOSTA */

            $"VG2600B-INSERT ENDOSSOS: R1-NUM-PROPOSTA={REG_R1_SUBGRUPO.R1_NUM_PROPOSTA} APOLICE={ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE} RAMO={ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR} ENDOSSO={ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO} SUBGRUPO={ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO} FONTE={ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE} PROPOSTA={ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA}"
            .Display();

            /*" -6361- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0533-00-INSERT-ENDOSSOS-DB-INSERT-1 */
        public void R0533_00_INSERT_ENDOSSOS_DB_INSERT_1()
        {
            /*" -6330- EXEC SQL INSERT INTO SEGUROS.ENDOSSOS VALUES (:ENDOSSOS-NUM-APOLICE , :ENDOSSOS-NUM-ENDOSSO , :ENDOSSOS-RAMO-EMISSOR , :ENDOSSOS-COD-PRODUTO , :ENDOSSOS-COD-SUBGRUPO , :ENDOSSOS-COD-FONTE , :ENDOSSOS-NUM-PROPOSTA , :ENDOSSOS-DATA-PROPOSTA , :ENDOSSOS-DATA-LIBERACAO , :ENDOSSOS-DATA-EMISSAO , :ENDOSSOS-NUM-RCAP , :ENDOSSOS-VAL-RCAP , :ENDOSSOS-BCO-RCAP , :ENDOSSOS-AGE-RCAP , :ENDOSSOS-DAC-RCAP , :ENDOSSOS-TIPO-RCAP , :ENDOSSOS-BCO-COBRANCA , :ENDOSSOS-AGE-COBRANCA , :ENDOSSOS-DAC-COBRANCA , :ENDOSSOS-DATA-INIVIGENCIA , :ENDOSSOS-DATA-TERVIGENCIA , :ENDOSSOS-PLANO-SEGURO , :ENDOSSOS-PCT-ENTRADA , :ENDOSSOS-PCT-ADIC-FRACIO , :ENDOSSOS-QTD-DIAS-PRIMEIRA , :ENDOSSOS-QTD-PARCELAS , :ENDOSSOS-QTD-PRESTACOES , :ENDOSSOS-QTD-ITENS , :ENDOSSOS-COD-TEXTO-PADRAO , :ENDOSSOS-COD-ACEITACAO , :ENDOSSOS-COD-MOEDA-IMP , :ENDOSSOS-COD-MOEDA-PRM , :ENDOSSOS-TIPO-ENDOSSO , :ENDOSSOS-COD-USUARIO , :ENDOSSOS-OCORR-ENDERECO , :ENDOSSOS-SIT-REGISTRO , NULL , NULL , :ENDOSSOS-TIPO-CORRECAO , :ENDOSSOS-ISENTA-CUSTO , CURRENT_TIMESTAMP , NULL , NULL , NULL ) END-EXEC. */

            var r0533_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1 = new R0533_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
                ENDOSSOS_RAMO_EMISSOR = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR.ToString(),
                ENDOSSOS_COD_PRODUTO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.ToString(),
                ENDOSSOS_COD_SUBGRUPO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO.ToString(),
                ENDOSSOS_COD_FONTE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE.ToString(),
                ENDOSSOS_NUM_PROPOSTA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA.ToString(),
                ENDOSSOS_DATA_PROPOSTA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA.ToString(),
                ENDOSSOS_DATA_LIBERACAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_LIBERACAO.ToString(),
                ENDOSSOS_DATA_EMISSAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO.ToString(),
                ENDOSSOS_NUM_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP.ToString(),
                ENDOSSOS_VAL_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP.ToString(),
                ENDOSSOS_BCO_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_RCAP.ToString(),
                ENDOSSOS_AGE_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP.ToString(),
                ENDOSSOS_DAC_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_RCAP.ToString(),
                ENDOSSOS_TIPO_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_RCAP.ToString(),
                ENDOSSOS_BCO_COBRANCA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_COBRANCA.ToString(),
                ENDOSSOS_AGE_COBRANCA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA.ToString(),
                ENDOSSOS_DAC_COBRANCA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_COBRANCA.ToString(),
                ENDOSSOS_DATA_INIVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.ToString(),
                ENDOSSOS_DATA_TERVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.ToString(),
                ENDOSSOS_PLANO_SEGURO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PLANO_SEGURO.ToString(),
                ENDOSSOS_PCT_ENTRADA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ENTRADA.ToString(),
                ENDOSSOS_PCT_ADIC_FRACIO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ADIC_FRACIO.ToString(),
                ENDOSSOS_QTD_DIAS_PRIMEIRA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_DIAS_PRIMEIRA.ToString(),
                ENDOSSOS_QTD_PARCELAS = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PARCELAS.ToString(),
                ENDOSSOS_QTD_PRESTACOES = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PRESTACOES.ToString(),
                ENDOSSOS_QTD_ITENS = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_ITENS.ToString(),
                ENDOSSOS_COD_TEXTO_PADRAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_TEXTO_PADRAO.ToString(),
                ENDOSSOS_COD_ACEITACAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_ACEITACAO.ToString(),
                ENDOSSOS_COD_MOEDA_IMP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_IMP.ToString(),
                ENDOSSOS_COD_MOEDA_PRM = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM.ToString(),
                ENDOSSOS_TIPO_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO.ToString(),
                ENDOSSOS_COD_USUARIO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO.ToString(),
                ENDOSSOS_OCORR_ENDERECO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO.ToString(),
                ENDOSSOS_SIT_REGISTRO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO.ToString(),
                ENDOSSOS_TIPO_CORRECAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_CORRECAO.ToString(),
                ENDOSSOS_ISENTA_CUSTO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_ISENTA_CUSTO.ToString(),
            };

            R0533_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1.Execute(r0533_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0533_SAIDA*/

        [StopWatch]
        /*" R0534-00-INSERT-PARCELAS-SECTION */
        private void R0534_00_INSERT_PARCELAS_SECTION()
        {
            /*" -6370- MOVE 'R0534-00-INSERT-PARCELAS' TO PARAGRAFO. */
            _.Move("R0534-00-INSERT-PARCELAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6371- MOVE 'INSERT PARCELAS         ' TO COMANDO. */
            _.Move("INSERT PARCELAS         ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6373- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6395- PERFORM R0534_00_INSERT_PARCELAS_DB_INSERT_1 */

            R0534_00_INSERT_PARCELAS_DB_INSERT_1();

            /*" -6398- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -6399- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -6400- DISPLAY '          ERRO INSERT DA TABELA PARCELAS ' */
                _.Display($"          ERRO INSERT DA TABELA PARCELAS ");

                /*" -6402- DISPLAY '          NUM APOLICE...................  ' PARCELAS-NUM-APOLICE */
                _.Display($"          NUM APOLICE...................  {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                /*" -6404- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA */
                _.Display($"          NUMERO PROPOSTA...............  {REG_R1_SUBGRUPO.R1_NUM_PROPOSTA}");

                /*" -6406- DISPLAY '          PARCELAS-NUM-APOLICE..........  ' PARCELAS-NUM-APOLICE */
                _.Display($"          PARCELAS-NUM-APOLICE..........  {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                /*" -6408- DISPLAY '          PARCELAS-NUM-ENDOSSO..........  ' PARCELAS-NUM-ENDOSSO */
                _.Display($"          PARCELAS-NUM-ENDOSSO..........  {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}");

                /*" -6410- DISPLAY '          PARCELAS-NUM-PARCELA..........  ' PARCELAS-NUM-PARCELA */
                _.Display($"          PARCELAS-NUM-PARCELA..........  {PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA}");

                /*" -6412- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -6414- DISPLAY '          SQLERRMC......................  ' SQLERRMC */
                _.Display($"          SQLERRMC......................  {DB.SQLERRMC}");

                /*" -6415- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -6417- END-IF. */
            }


            /*" -6417- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0534-00-INSERT-PARCELAS-DB-INSERT-1 */
        public void R0534_00_INSERT_PARCELAS_DB_INSERT_1()
        {
            /*" -6395- EXEC SQL INSERT INTO SEGUROS.PARCELAS VALUES (:PARCELAS-NUM-APOLICE , :PARCELAS-NUM-ENDOSSO , :PARCELAS-NUM-PARCELA , :PARCELAS-DAC-PARCELA , :PARCELAS-COD-FONTE , :PARCELAS-NUM-TITULO , :PARCELAS-PRM-TARIFARIO-IX , :PARCELAS-VAL-DESCONTO-IX , :PARCELAS-PRM-LIQUIDO-IX , :PARCELAS-ADICIONAL-FRAC-IX , :PARCELAS-VAL-CUSTO-EMIS-IX , :PARCELAS-VAL-IOCC-IX , :PARCELAS-PRM-TOTAL-IX , :PARCELAS-OCORR-HISTORICO , :PARCELAS-QTD-DOCUMENTOS , :PARCELAS-SIT-REGISTRO , NULL , CURRENT_TIMESTAMP , NULL ) END-EXEC. */

            var r0534_00_INSERT_PARCELAS_DB_INSERT_1_Insert1 = new R0534_00_INSERT_PARCELAS_DB_INSERT_1_Insert1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
                PARCELAS_NUM_ENDOSSO = PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO.ToString(),
                PARCELAS_NUM_PARCELA = PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA.ToString(),
                PARCELAS_DAC_PARCELA = PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA.ToString(),
                PARCELAS_COD_FONTE = PARCELAS.DCLPARCELAS.PARCELAS_COD_FONTE.ToString(),
                PARCELAS_NUM_TITULO = PARCELAS.DCLPARCELAS.PARCELAS_NUM_TITULO.ToString(),
                PARCELAS_PRM_TARIFARIO_IX = PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX.ToString(),
                PARCELAS_VAL_DESCONTO_IX = PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX.ToString(),
                PARCELAS_PRM_LIQUIDO_IX = PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX.ToString(),
                PARCELAS_ADICIONAL_FRAC_IX = PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX.ToString(),
                PARCELAS_VAL_CUSTO_EMIS_IX = PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX.ToString(),
                PARCELAS_VAL_IOCC_IX = PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX.ToString(),
                PARCELAS_PRM_TOTAL_IX = PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX.ToString(),
                PARCELAS_OCORR_HISTORICO = PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO.ToString(),
                PARCELAS_QTD_DOCUMENTOS = PARCELAS.DCLPARCELAS.PARCELAS_QTD_DOCUMENTOS.ToString(),
                PARCELAS_SIT_REGISTRO = PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO.ToString(),
            };

            R0534_00_INSERT_PARCELAS_DB_INSERT_1_Insert1.Execute(r0534_00_INSERT_PARCELAS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0534_SAIDA*/

        [StopWatch]
        /*" R0535-00-INSERT-HIST-PARC-SECTION */
        private void R0535_00_INSERT_HIST_PARC_SECTION()
        {
            /*" -6426- MOVE 'R0535-00-INSERT-HIST-PARC' TO PARAGRAFO. */
            _.Move("R0535-00-INSERT-HIST-PARC", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6427- MOVE 'INSERT HIST PARC         ' TO COMANDO. */
            _.Move("INSERT HIST PARC         ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6429- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6459- PERFORM R0535_00_INSERT_HIST_PARC_DB_INSERT_1 */

            R0535_00_INSERT_HIST_PARC_DB_INSERT_1();

            /*" -6462- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -6463- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -6464- DISPLAY '          ERRO INSERT DA TABELA HIST PARC ' */
                _.Display($"          ERRO INSERT DA TABELA HIST PARC ");

                /*" -6466- DISPLAY '          NUM APOLICE...................  ' PARCEHIS-NUM-APOLICE */
                _.Display($"          NUM APOLICE...................  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -6468- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA */
                _.Display($"          NUMERO PROPOSTA...............  {REG_R1_SUBGRUPO.R1_NUM_PROPOSTA}");

                /*" -6470- DISPLAY '          PARCEHIS-NUM-ENDOSSO..........  ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"          PARCEHIS-NUM-ENDOSSO..........  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -6472- DISPLAY '          PARCEHIS-NUM-PARCELA..........  ' PARCEHIS-NUM-PARCELA */
                _.Display($"          PARCEHIS-NUM-PARCELA..........  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -6474- DISPLAY '          PARCEHIS-DAC-PARCELA..........  ' PARCEHIS-DAC-PARCELA */
                _.Display($"          PARCEHIS-DAC-PARCELA..........  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA}");

                /*" -6476- DISPLAY '          PARCEHIS-DATA-MOVIMENTO.......  ' PARCEHIS-DATA-MOVIMENTO */
                _.Display($"          PARCEHIS-DATA-MOVIMENTO.......  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                /*" -6478- DISPLAY '          PARCEHIS-COD-OPERACAO.........  ' PARCEHIS-COD-OPERACAO */
                _.Display($"          PARCEHIS-COD-OPERACAO.........  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                /*" -6480- DISPLAY '          PARCEHIS-OCORR-HISTORICO......  ' PARCEHIS-OCORR-HISTORICO */
                _.Display($"          PARCEHIS-OCORR-HISTORICO......  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                /*" -6482- DISPLAY '          PARCEHIS-DATA-VENCIMENTO......  ' PARCEHIS-DATA-VENCIMENTO */
                _.Display($"          PARCEHIS-DATA-VENCIMENTO......  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO}");

                /*" -6484- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -6486- DISPLAY '          SQLERRMC......................  ' SQLERRMC */
                _.Display($"          SQLERRMC......................  {DB.SQLERRMC}");

                /*" -6487- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -6489- END-IF. */
            }


            /*" -6489- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0535-00-INSERT-HIST-PARC-DB-INSERT-1 */
        public void R0535_00_INSERT_HIST_PARC_DB_INSERT_1()
        {
            /*" -6459- EXEC SQL INSERT INTO SEGUROS.PARCELA_HISTORICO VALUES (:PARCEHIS-NUM-APOLICE , :PARCEHIS-NUM-ENDOSSO , :PARCEHIS-NUM-PARCELA , :PARCEHIS-DAC-PARCELA , :PARCEHIS-DATA-MOVIMENTO , :PARCEHIS-COD-OPERACAO , CURRENT_TIME , :PARCEHIS-OCORR-HISTORICO , :PARCEHIS-PRM-TARIFARIO , :PARCEHIS-VAL-DESCONTO , :PARCEHIS-PRM-LIQUIDO , :PARCEHIS-ADICIONAL-FRACIO , :PARCEHIS-VAL-CUSTO-EMISSAO , :PARCEHIS-VAL-IOCC , :PARCEHIS-PRM-TOTAL , :PARCEHIS-VAL-OPERACAO , :PARCEHIS-DATA-VENCIMENTO , :PARCEHIS-BCO-COBRANCA , :PARCEHIS-AGE-COBRANCA , :PARCEHIS-NUM-AVISO-CREDITO , :PARCEHIS-ENDOS-CANCELA , :PARCEHIS-SIT-CONTABIL , :PARCEHIS-COD-USUARIO , :PARCEHIS-RENUM-DOCUMENTO , NULL , NULL , CURRENT_TIMESTAMP ) END-EXEC. */

            var r0535_00_INSERT_HIST_PARC_DB_INSERT_1_Insert1 = new R0535_00_INSERT_HIST_PARC_DB_INSERT_1_Insert1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
                PARCEHIS_DAC_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA.ToString(),
                PARCEHIS_DATA_MOVIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO.ToString(),
                PARCEHIS_COD_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO.ToString(),
                PARCEHIS_OCORR_HISTORICO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.ToString(),
                PARCEHIS_PRM_TARIFARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO.ToString(),
                PARCEHIS_VAL_DESCONTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO.ToString(),
                PARCEHIS_PRM_LIQUIDO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO.ToString(),
                PARCEHIS_ADICIONAL_FRACIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO.ToString(),
                PARCEHIS_VAL_CUSTO_EMISSAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO.ToString(),
                PARCEHIS_VAL_IOCC = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC.ToString(),
                PARCEHIS_PRM_TOTAL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL.ToString(),
                PARCEHIS_VAL_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO.ToString(),
                PARCEHIS_DATA_VENCIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO.ToString(),
                PARCEHIS_BCO_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA.ToString(),
                PARCEHIS_AGE_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA.ToString(),
                PARCEHIS_NUM_AVISO_CREDITO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO.ToString(),
                PARCEHIS_ENDOS_CANCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA.ToString(),
                PARCEHIS_SIT_CONTABIL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL.ToString(),
                PARCEHIS_COD_USUARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO.ToString(),
                PARCEHIS_RENUM_DOCUMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO.ToString(),
            };

            R0535_00_INSERT_HIST_PARC_DB_INSERT_1_Insert1.Execute(r0535_00_INSERT_HIST_PARC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0535_SAIDA*/

        [StopWatch]
        /*" R0536-00-INSERT-APOL-COBER-SECTION */
        private void R0536_00_INSERT_APOL_COBER_SECTION()
        {
            /*" -6498- MOVE 'R0536-00-INSERT-APOL-COBER' TO PARAGRAFO. */
            _.Move("R0536-00-INSERT-APOL-COBER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6499- MOVE 'INSERT APOL COBER         ' TO COMANDO. */
            _.Move("INSERT APOL COBER         ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6501- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6522- PERFORM R0536_00_INSERT_APOL_COBER_DB_INSERT_1 */

            R0536_00_INSERT_APOL_COBER_DB_INSERT_1();

            /*" -6525- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -6526- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -6527- DISPLAY '          ERRO INSERT DA TABELA APOL COBER' */
                _.Display($"          ERRO INSERT DA TABELA APOL COBER");

                /*" -6529- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA */
                _.Display($"          NUMERO PROPOSTA...............  {REG_R1_SUBGRUPO.R1_NUM_PROPOSTA}");

                /*" -6531- DISPLAY '          APOLICOB-NUM-APOLICE..........  ' APOLICOB-NUM-APOLICE */
                _.Display($"          APOLICOB-NUM-APOLICE..........  {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE}");

                /*" -6533- DISPLAY '          APOLICOB-NUM-ENDOSSO..........  ' APOLICOB-NUM-ENDOSSO */
                _.Display($"          APOLICOB-NUM-ENDOSSO..........  {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO}");

                /*" -6535- DISPLAY '          APOLICOB-NUM-ITEM.............  ' APOLICOB-NUM-ITEM */
                _.Display($"          APOLICOB-NUM-ITEM.............  {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM}");

                /*" -6537- DISPLAY '          APOLICOB-OCORR-HISTORICO......  ' APOLICOB-OCORR-HISTORICO */
                _.Display($"          APOLICOB-OCORR-HISTORICO......  {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO}");

                /*" -6539- DISPLAY '          APOLICOB-RAMO-COBERTURA.......  ' APOLICOB-RAMO-COBERTURA */
                _.Display($"          APOLICOB-RAMO-COBERTURA.......  {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA}");

                /*" -6541- DISPLAY '          APOLICOB-MODALI-COBERTURA.....  ' APOLICOB-MODALI-COBERTURA */
                _.Display($"          APOLICOB-MODALI-COBERTURA.....  {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA}");

                /*" -6543- DISPLAY '          APOLICOB-COD-COBERTURA........  ' APOLICOB-COD-COBERTURA */
                _.Display($"          APOLICOB-COD-COBERTURA........  {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA}");

                /*" -6545- DISPLAY '          APOLICOB-DATA-INIVIGENCIA.....  ' APOLICOB-DATA-INIVIGENCIA */
                _.Display($"          APOLICOB-DATA-INIVIGENCIA.....  {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA}");

                /*" -6547- DISPLAY '          APOLICOB-DATA-TERVIGENCIA.....  ' APOLICOB-DATA-TERVIGENCIA */
                _.Display($"          APOLICOB-DATA-TERVIGENCIA.....  {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA}");

                /*" -6549- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -6551- DISPLAY '          SQLERRMC......................  ' SQLERRMC */
                _.Display($"          SQLERRMC......................  {DB.SQLERRMC}");

                /*" -6552- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -6554- END-IF. */
            }


            /*" -6554- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0536-00-INSERT-APOL-COBER-DB-INSERT-1 */
        public void R0536_00_INSERT_APOL_COBER_DB_INSERT_1()
        {
            /*" -6522- EXEC SQL INSERT INTO SEGUROS.APOLICE_COBERTURAS VALUES (:APOLICOB-NUM-APOLICE , :APOLICOB-NUM-ENDOSSO , :APOLICOB-NUM-ITEM , :APOLICOB-OCORR-HISTORICO , :APOLICOB-RAMO-COBERTURA , :APOLICOB-MODALI-COBERTURA , :APOLICOB-COD-COBERTURA , :APOLICOB-IMP-SEGURADA-IX , :APOLICOB-PRM-TARIFARIO-IX , :APOLICOB-IMP-SEGURADA-VAR , :APOLICOB-PRM-TARIFARIO-VAR, :APOLICOB-PCT-COBERTURA , :APOLICOB-FATOR-MULTIPLICA , :APOLICOB-DATA-INIVIGENCIA , :APOLICOB-DATA-TERVIGENCIA , :APOLICOB-COD-EMPRESA , CURRENT_TIMESTAMP , :APOLICOB-SIT-REGISTRO ) END-EXEC */

            var r0536_00_INSERT_APOL_COBER_DB_INSERT_1_Insert1 = new R0536_00_INSERT_APOL_COBER_DB_INSERT_1_Insert1()
            {
                APOLICOB_NUM_APOLICE = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE.ToString(),
                APOLICOB_NUM_ENDOSSO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO.ToString(),
                APOLICOB_NUM_ITEM = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM.ToString(),
                APOLICOB_OCORR_HISTORICO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO.ToString(),
                APOLICOB_RAMO_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA.ToString(),
                APOLICOB_MODALI_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA.ToString(),
                APOLICOB_COD_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA.ToString(),
                APOLICOB_IMP_SEGURADA_IX = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX.ToString(),
                APOLICOB_PRM_TARIFARIO_IX = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX.ToString(),
                APOLICOB_IMP_SEGURADA_VAR = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR.ToString(),
                APOLICOB_PRM_TARIFARIO_VAR = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR.ToString(),
                APOLICOB_PCT_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA.ToString(),
                APOLICOB_FATOR_MULTIPLICA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA.ToString(),
                APOLICOB_DATA_INIVIGENCIA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA.ToString(),
                APOLICOB_DATA_TERVIGENCIA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA.ToString(),
                APOLICOB_COD_EMPRESA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_EMPRESA.ToString(),
                APOLICOB_SIT_REGISTRO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_SIT_REGISTRO.ToString(),
            };

            R0536_00_INSERT_APOL_COBER_DB_INSERT_1_Insert1.Execute(r0536_00_INSERT_APOL_COBER_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0536_SAIDA*/

        [StopWatch]
        /*" R0537-00-INSERT-ENDERECO-SECTION */
        private void R0537_00_INSERT_ENDERECO_SECTION()
        {
            /*" -6563- MOVE 'R0537-00-INSERT-ENDERECO  ' TO PARAGRAFO. */
            _.Move("R0537-00-INSERT-ENDERECO  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6564- MOVE 'INSERT ENDERECO           ' TO COMANDO. */
            _.Move("INSERT ENDERECO           ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6566- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6584- PERFORM R0537_00_INSERT_ENDERECO_DB_INSERT_1 */

            R0537_00_INSERT_ENDERECO_DB_INSERT_1();

            /*" -6587- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -6588- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -6589- DISPLAY '          ERRO INSERT DA TABELA ENDERECOS ' */
                _.Display($"          ERRO INSERT DA TABELA ENDERECOS ");

                /*" -6591- DISPLAY '          COD CLIENTE...................  ' ENDERECO-COD-CLIENTE */
                _.Display($"          COD CLIENTE...................  {ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE}");

                /*" -6593- DISPLAY '          OCORR ENDERECO................  ' ENDERECO-OCORR-ENDERECO */
                _.Display($"          OCORR ENDERECO................  {ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO}");

                /*" -6595- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA */
                _.Display($"          NUMERO PROPOSTA...............  {REG_R1_SUBGRUPO.R1_NUM_PROPOSTA}");

                /*" -6597- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -6599- DISPLAY '          SQLERRMC......................  ' SQLERRMC */
                _.Display($"          SQLERRMC......................  {DB.SQLERRMC}");

                /*" -6600- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -6602- END-IF. */
            }


            /*" -6602- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0537-00-INSERT-ENDERECO-DB-INSERT-1 */
        public void R0537_00_INSERT_ENDERECO_DB_INSERT_1()
        {
            /*" -6584- EXEC SQL INSERT INTO SEGUROS.ENDERECOS VALUES (:ENDERECO-COD-CLIENTE , :ENDERECO-COD-ENDERECO , :ENDERECO-OCORR-ENDERECO , :ENDERECO-ENDERECO , :ENDERECO-BAIRRO , :ENDERECO-CIDADE , :ENDERECO-SIGLA-UF , :ENDERECO-CEP , :ENDERECO-DDD , :ENDERECO-TELEFONE , :ENDERECO-FAX , :ENDERECO-TELEX , :ENDERECO-SIT-REGISTRO , :ENDERECO-COD-EMPRESA , :ENDERECO-DES-COMPLEMENTO ) END-EXEC */

            var r0537_00_INSERT_ENDERECO_DB_INSERT_1_Insert1 = new R0537_00_INSERT_ENDERECO_DB_INSERT_1_Insert1()
            {
                ENDERECO_COD_CLIENTE = ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE.ToString(),
                ENDERECO_COD_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO.ToString(),
                ENDERECO_OCORR_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.ToString(),
                ENDERECO_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO.ToString(),
                ENDERECO_BAIRRO = ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO.ToString(),
                ENDERECO_CIDADE = ENDERECO.DCLENDERECOS.ENDERECO_CIDADE.ToString(),
                ENDERECO_SIGLA_UF = ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF.ToString(),
                ENDERECO_CEP = ENDERECO.DCLENDERECOS.ENDERECO_CEP.ToString(),
                ENDERECO_DDD = ENDERECO.DCLENDERECOS.ENDERECO_DDD.ToString(),
                ENDERECO_TELEFONE = ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE.ToString(),
                ENDERECO_FAX = ENDERECO.DCLENDERECOS.ENDERECO_FAX.ToString(),
                ENDERECO_TELEX = ENDERECO.DCLENDERECOS.ENDERECO_TELEX.ToString(),
                ENDERECO_SIT_REGISTRO = ENDERECO.DCLENDERECOS.ENDERECO_SIT_REGISTRO.ToString(),
                ENDERECO_COD_EMPRESA = ENDERECO.DCLENDERECOS.ENDERECO_COD_EMPRESA.ToString(),
                ENDERECO_DES_COMPLEMENTO = ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO.ToString(),
            };

            R0537_00_INSERT_ENDERECO_DB_INSERT_1_Insert1.Execute(r0537_00_INSERT_ENDERECO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0537_SAIDA*/

        [StopWatch]
        /*" R0538-00-INSERT-EMAIL-SECTION */
        private void R0538_00_INSERT_EMAIL_SECTION()
        {
            /*" -6611- MOVE 'R0538-00-INSERT-EMAIL  ' TO PARAGRAFO. */
            _.Move("R0538-00-INSERT-EMAIL  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6612- MOVE 'INSERT EMAIL           ' TO COMANDO. */
            _.Move("INSERT EMAIL           ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6614- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6620- PERFORM R0538_00_INSERT_EMAIL_DB_INSERT_1 */

            R0538_00_INSERT_EMAIL_DB_INSERT_1();

            /*" -6623- IF (SQLCODE NOT EQUAL ZEROS AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -6624- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -6625- DISPLAY '          ERRO INSERT TABELA CLIENTE_EMAIL ' */
                _.Display($"          ERRO INSERT TABELA CLIENTE_EMAIL ");

                /*" -6627- DISPLAY '          COD CLIENTE...................  ' CLIENEMA-COD-CLIENTE */
                _.Display($"          COD CLIENTE...................  {CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_COD_CLIENTE}");

                /*" -6629- DISPLAY '          SEQ EMAIL.....................  ' CLIENEMA-SEQ-EMAIL */
                _.Display($"          SEQ EMAIL.....................  {CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL}");

                /*" -6631- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -6633- DISPLAY '          SQLERRMC......................  ' SQLERRMC */
                _.Display($"          SQLERRMC......................  {DB.SQLERRMC}");

                /*" -6634- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -6636- END-IF. */
            }


            /*" -6636- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0538-00-INSERT-EMAIL-DB-INSERT-1 */
        public void R0538_00_INSERT_EMAIL_DB_INSERT_1()
        {
            /*" -6620- EXEC SQL INSERT INTO SEGUROS.CLIENTE_EMAIL VALUES (:CLIENEMA-COD-CLIENTE , :CLIENEMA-SEQ-EMAIL , :CLIENEMA-EMAIL ) END-EXEC */

            var r0538_00_INSERT_EMAIL_DB_INSERT_1_Insert1 = new R0538_00_INSERT_EMAIL_DB_INSERT_1_Insert1()
            {
                CLIENEMA_COD_CLIENTE = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_COD_CLIENTE.ToString(),
                CLIENEMA_SEQ_EMAIL = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL.ToString(),
                CLIENEMA_EMAIL = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL.ToString(),
            };

            R0538_00_INSERT_EMAIL_DB_INSERT_1_Insert1.Execute(r0538_00_INSERT_EMAIL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0538_SAIDA*/

        [StopWatch]
        /*" R0539-00-INSERT-COBER-SUBG-SECTION */
        private void R0539_00_INSERT_COBER_SUBG_SECTION()
        {
            /*" -6645- MOVE 'R0539-00-INSERT-COBER-SUBG' TO PARAGRAFO. */
            _.Move("R0539-00-INSERT-COBER-SUBG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6646- MOVE 'INSERT COBER SUBG         ' TO COMANDO. */
            _.Move("INSERT COBER SUBG         ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6647- MOVE SISTEMAS-DATA-MOV-ABERTO TO VGCOBSUB-DATA-INIVIGENCIA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_DATA_INIVIGENCIA);

            /*" -6649- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6671- PERFORM R0539_00_INSERT_COBER_SUBG_DB_INSERT_1 */

            R0539_00_INSERT_COBER_SUBG_DB_INSERT_1();

            /*" -6674- IF (SQLCODE NOT EQUAL ZEROS AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -6675- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -6676- DISPLAY '          ERRO INSERT TABELA COBER-SUBG ' */
                _.Display($"          ERRO INSERT TABELA COBER-SUBG ");

                /*" -6678- DISPLAY '          NUM APOLICE...................  ' VGCOBSUB-NUM-APOLICE */
                _.Display($"          NUM APOLICE...................  {VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_NUM_APOLICE}");

                /*" -6680- DISPLAY '          COD SUBGRUPO..................  ' VGCOBSUB-COD-SUBGRUPO */
                _.Display($"          COD SUBGRUPO..................  {VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_SUBGRUPO}");

                /*" -6682- DISPLAY '          VGCOBSUB-RAMO-COBERTURA.......  ' VGCOBSUB-RAMO-COBERTURA */
                _.Display($"          VGCOBSUB-RAMO-COBERTURA.......  {VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_RAMO_COBERTURA}");

                /*" -6684- DISPLAY '          COD-COBERTURA.................  ' VGCOBSUB-COD-COBERTURA */
                _.Display($"          COD-COBERTURA.................  {VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA}");

                /*" -6686- DISPLAY '          VGCOBSUB-DATA-INIVIGENCIA.....  ' VGCOBSUB-DATA-INIVIGENCIA */
                _.Display($"          VGCOBSUB-DATA-INIVIGENCIA.....  {VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_DATA_INIVIGENCIA}");

                /*" -6688- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA */
                _.Display($"          NUMERO PROPOSTA...............  {REG_R1_SUBGRUPO.R1_NUM_PROPOSTA}");

                /*" -6690- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -6692- DISPLAY '          SQLERRMC......................  ' SQLERRMC */
                _.Display($"          SQLERRMC......................  {DB.SQLERRMC}");

                /*" -6693- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -6695- END-IF. */
            }


            /*" -6695- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0539-00-INSERT-COBER-SUBG-DB-INSERT-1 */
        public void R0539_00_INSERT_COBER_SUBG_DB_INSERT_1()
        {
            /*" -6671- EXEC SQL INSERT INTO SEGUROS.VG_COBERTURAS_SUBG VALUES (:VGCOBSUB-NUM-APOLICE , :VGCOBSUB-COD-SUBGRUPO , :VGCOBSUB-RAMO-COBERTURA , :VGCOBSUB-COD-COBERTURA , :VGCOBSUB-MODALI-COBERTURA , :VGCOBSUB-IMP-SEGURADA-IX , :VGCOBSUB-PRM-TARIFARIO-IX , :VGCOBSUB-IMP-SEGURADA-VAR , :VGCOBSUB-PRM-TARIFARIO-VAR , :VGCOBSUB-PCT-COBERTURA , :VGCOBSUB-FATOR-MULTIPLICA , :VGCOBSUB-DATA-INIVIGENCIA , :VGCOBSUB-TRATAMENTO-FATURA , :VGCOBSUB-TRATAMENTO-PRMTOT , :VGCOBSUB-SIT-COBERTURA , :VGCOBSUB-COD-USUARIO , CURRENT_TIMESTAMP , :VGCOBSUB-VLR-LIM-MIN-COBER , :VGCOBSUB-VLR-LIM-MAX-COBER ) END-EXEC */

            var r0539_00_INSERT_COBER_SUBG_DB_INSERT_1_Insert1 = new R0539_00_INSERT_COBER_SUBG_DB_INSERT_1_Insert1()
            {
                VGCOBSUB_NUM_APOLICE = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_NUM_APOLICE.ToString(),
                VGCOBSUB_COD_SUBGRUPO = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_SUBGRUPO.ToString(),
                VGCOBSUB_RAMO_COBERTURA = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_RAMO_COBERTURA.ToString(),
                VGCOBSUB_COD_COBERTURA = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA.ToString(),
                VGCOBSUB_MODALI_COBERTURA = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_MODALI_COBERTURA.ToString(),
                VGCOBSUB_IMP_SEGURADA_IX = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX.ToString(),
                VGCOBSUB_PRM_TARIFARIO_IX = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_PRM_TARIFARIO_IX.ToString(),
                VGCOBSUB_IMP_SEGURADA_VAR = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_VAR.ToString(),
                VGCOBSUB_PRM_TARIFARIO_VAR = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_PRM_TARIFARIO_VAR.ToString(),
                VGCOBSUB_PCT_COBERTURA = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_PCT_COBERTURA.ToString(),
                VGCOBSUB_FATOR_MULTIPLICA = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_FATOR_MULTIPLICA.ToString(),
                VGCOBSUB_DATA_INIVIGENCIA = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_DATA_INIVIGENCIA.ToString(),
                VGCOBSUB_TRATAMENTO_FATURA = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_TRATAMENTO_FATURA.ToString(),
                VGCOBSUB_TRATAMENTO_PRMTOT = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_TRATAMENTO_PRMTOT.ToString(),
                VGCOBSUB_SIT_COBERTURA = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_SIT_COBERTURA.ToString(),
                VGCOBSUB_COD_USUARIO = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_USUARIO.ToString(),
                VGCOBSUB_VLR_LIM_MIN_COBER = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_VLR_LIM_MIN_COBER.ToString(),
                VGCOBSUB_VLR_LIM_MAX_COBER = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_VLR_LIM_MAX_COBER.ToString(),
            };

            R0539_00_INSERT_COBER_SUBG_DB_INSERT_1_Insert1.Execute(r0539_00_INSERT_COBER_SUBG_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0539_SAIDA*/

        [StopWatch]
        /*" R0540-00-INSERT-COBER-SUBGHIST-SECTION */
        private void R0540_00_INSERT_COBER_SUBGHIST_SECTION()
        {
            /*" -6704- MOVE 'R0540-00-INSERT-COBER-SUBGHIST' TO PARAGRAFO. */
            _.Move("R0540-00-INSERT-COBER-SUBGHIST", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6705- MOVE 'INSERT COBER SUBG HIST        ' TO COMANDO. */
            _.Move("INSERT COBER SUBG HIST        ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6707- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6729- PERFORM R0540_00_INSERT_COBER_SUBGHIST_DB_INSERT_1 */

            R0540_00_INSERT_COBER_SUBGHIST_DB_INSERT_1();

            /*" -6732- IF (SQLCODE NOT EQUAL ZEROS AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -6733- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -6734- DISPLAY '          ERRO INSERT TABELA COB-SUBG-HIST' */
                _.Display($"          ERRO INSERT TABELA COB-SUBG-HIST");

                /*" -6736- DISPLAY '          NUM APOLICE...................  ' VGCOBSUB-NUM-APOLICE */
                _.Display($"          NUM APOLICE...................  {VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_NUM_APOLICE}");

                /*" -6738- DISPLAY '          COD SUBGRUPO..................  ' VGCOBSUB-COD-SUBGRUPO */
                _.Display($"          COD SUBGRUPO..................  {VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_SUBGRUPO}");

                /*" -6740- DISPLAY '          VGCOBSUB-DATA-INIVIGENCIA.....  ' VGCOBSUB-DATA-INIVIGENCIA */
                _.Display($"          VGCOBSUB-DATA-INIVIGENCIA.....  {VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_DATA_INIVIGENCIA}");

                /*" -6742- DISPLAY '          VGCOBSUB-RAMO-COBERTURA.......  ' VGCOBSUB-RAMO-COBERTURA */
                _.Display($"          VGCOBSUB-RAMO-COBERTURA.......  {VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_RAMO_COBERTURA}");

                /*" -6744- DISPLAY '          COD-COBERTURA.................  ' VGCOBSUB-COD-COBERTURA */
                _.Display($"          COD-COBERTURA.................  {VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA}");

                /*" -6746- DISPLAY '          VGCOBSUH-DATA-TERVIGENCIA.....  ' VGCOBSUH-DATA-TERVIGENCIA */
                _.Display($"          VGCOBSUH-DATA-TERVIGENCIA.....  {VGCOBSUH.DCLVG_COBER_SUBG_HIST.VGCOBSUH_DATA_TERVIGENCIA}");

                /*" -6748- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA */
                _.Display($"          NUMERO PROPOSTA...............  {REG_R1_SUBGRUPO.R1_NUM_PROPOSTA}");

                /*" -6750- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -6752- DISPLAY '          SQLERRMC......................  ' SQLERRMC */
                _.Display($"          SQLERRMC......................  {DB.SQLERRMC}");

                /*" -6753- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -6755- END-IF. */
            }


            /*" -6755- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0540-00-INSERT-COBER-SUBGHIST-DB-INSERT-1 */
        public void R0540_00_INSERT_COBER_SUBGHIST_DB_INSERT_1()
        {
            /*" -6729- EXEC SQL INSERT INTO SEGUROS.VG_COBER_SUBG_HIST VALUES (:VGCOBSUB-NUM-APOLICE , :VGCOBSUB-COD-SUBGRUPO , :VGCOBSUB-DATA-INIVIGENCIA , :VGCOBSUB-RAMO-COBERTURA , :VGCOBSUB-COD-COBERTURA , :VGCOBSUB-MODALI-COBERTURA , :VGCOBSUB-IMP-SEGURADA-IX , :VGCOBSUB-PRM-TARIFARIO-IX , :VGCOBSUB-IMP-SEGURADA-VAR , :VGCOBSUB-PRM-TARIFARIO-VAR , :VGCOBSUB-PCT-COBERTURA , :VGCOBSUB-FATOR-MULTIPLICA , :VGCOBSUH-DATA-TERVIGENCIA , :VGCOBSUB-TRATAMENTO-FATURA , :VGCOBSUB-TRATAMENTO-PRMTOT , :VGCOBSUB-COD-USUARIO , CURRENT_TIMESTAMP , :VGCOBSUB-VLR-LIM-MIN-COBER , :VGCOBSUB-VLR-LIM-MAX-COBER ) END-EXEC */

            var r0540_00_INSERT_COBER_SUBGHIST_DB_INSERT_1_Insert1 = new R0540_00_INSERT_COBER_SUBGHIST_DB_INSERT_1_Insert1()
            {
                VGCOBSUB_NUM_APOLICE = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_NUM_APOLICE.ToString(),
                VGCOBSUB_COD_SUBGRUPO = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_SUBGRUPO.ToString(),
                VGCOBSUB_DATA_INIVIGENCIA = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_DATA_INIVIGENCIA.ToString(),
                VGCOBSUB_RAMO_COBERTURA = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_RAMO_COBERTURA.ToString(),
                VGCOBSUB_COD_COBERTURA = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA.ToString(),
                VGCOBSUB_MODALI_COBERTURA = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_MODALI_COBERTURA.ToString(),
                VGCOBSUB_IMP_SEGURADA_IX = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX.ToString(),
                VGCOBSUB_PRM_TARIFARIO_IX = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_PRM_TARIFARIO_IX.ToString(),
                VGCOBSUB_IMP_SEGURADA_VAR = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_VAR.ToString(),
                VGCOBSUB_PRM_TARIFARIO_VAR = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_PRM_TARIFARIO_VAR.ToString(),
                VGCOBSUB_PCT_COBERTURA = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_PCT_COBERTURA.ToString(),
                VGCOBSUB_FATOR_MULTIPLICA = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_FATOR_MULTIPLICA.ToString(),
                VGCOBSUH_DATA_TERVIGENCIA = VGCOBSUH.DCLVG_COBER_SUBG_HIST.VGCOBSUH_DATA_TERVIGENCIA.ToString(),
                VGCOBSUB_TRATAMENTO_FATURA = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_TRATAMENTO_FATURA.ToString(),
                VGCOBSUB_TRATAMENTO_PRMTOT = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_TRATAMENTO_PRMTOT.ToString(),
                VGCOBSUB_COD_USUARIO = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_USUARIO.ToString(),
                VGCOBSUB_VLR_LIM_MIN_COBER = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_VLR_LIM_MIN_COBER.ToString(),
                VGCOBSUB_VLR_LIM_MAX_COBER = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_VLR_LIM_MAX_COBER.ToString(),
            };

            R0540_00_INSERT_COBER_SUBGHIST_DB_INSERT_1_Insert1.Execute(r0540_00_INSERT_COBER_SUBGHIST_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0540_SAIDA*/

        [StopWatch]
        /*" R0541-00-INSERT-PESSOA-SECTION */
        private void R0541_00_INSERT_PESSOA_SECTION()
        {
            /*" -6764- MOVE 'R0541-00-INSERT-PESSOA        ' TO PARAGRAFO. */
            _.Move("R0541-00-INSERT-PESSOA        ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6765- MOVE 'INSERT PESSOA                 ' TO COMANDO. */
            _.Move("INSERT PESSOA                 ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6767- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6776- PERFORM R0541_00_INSERT_PESSOA_DB_INSERT_1 */

            R0541_00_INSERT_PESSOA_DB_INSERT_1();

            /*" -6779- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -6780- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -6781- DISPLAY '          ERRO INSERT TABELA PESSOA       ' */
                _.Display($"          ERRO INSERT TABELA PESSOA       ");

                /*" -6783- DISPLAY '          COD PESSOA....................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          COD PESSOA....................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -6785- DISPLAY '          NOME PESSOA...................  ' PESSOA-NOME-PESSOA */
                _.Display($"          NOME PESSOA...................  {PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA}");

                /*" -6787- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -6789- DISPLAY '          SQLERRMC......................  ' SQLERRMC */
                _.Display($"          SQLERRMC......................  {DB.SQLERRMC}");

                /*" -6790- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -6792- END-IF. */
            }


            /*" -6792- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0541-00-INSERT-PESSOA-DB-INSERT-1 */
        public void R0541_00_INSERT_PESSOA_DB_INSERT_1()
        {
            /*" -6776- EXEC SQL INSERT INTO SEGUROS.PESSOA VALUES (:DCLPESSOA.PESSOA-COD-PESSOA , :PESSOA-NOME-PESSOA , CURRENT_TIMESTAMP , :PESSOA-COD-USUARIO , :PESSOA-TIPO-PESSOA , :PESSOA-SIGLA-PESSOA ) END-EXEC */

            var r0541_00_INSERT_PESSOA_DB_INSERT_1_Insert1 = new R0541_00_INSERT_PESSOA_DB_INSERT_1_Insert1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
                PESSOA_NOME_PESSOA = PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.ToString(),
                PESSOA_COD_USUARIO = PESSOA.DCLPESSOA.PESSOA_COD_USUARIO.ToString(),
                PESSOA_TIPO_PESSOA = PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA.ToString(),
                PESSOA_SIGLA_PESSOA = PESSOA.DCLPESSOA.PESSOA_SIGLA_PESSOA.ToString(),
            };

            R0541_00_INSERT_PESSOA_DB_INSERT_1_Insert1.Execute(r0541_00_INSERT_PESSOA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0541_SAIDA*/

        [StopWatch]
        /*" R0542-00-INSERT-PESSOA-FISICA-SECTION */
        private void R0542_00_INSERT_PESSOA_FISICA_SECTION()
        {
            /*" -6801- MOVE 'R0542-00-INSERT-PESSOA-FISICA ' TO PARAGRAFO. */
            _.Move("R0542-00-INSERT-PESSOA-FISICA ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6802- MOVE 'INSERT PESSOA FISICA          ' TO COMANDO. */
            _.Move("INSERT PESSOA FISICA          ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6804- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6820- PERFORM R0542_00_INSERT_PESSOA_FISICA_DB_INSERT_1 */

            R0542_00_INSERT_PESSOA_FISICA_DB_INSERT_1();

            /*" -6823- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -6824- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -6825- DISPLAY '          ERRO INSERT TABELA PESSOA-FISICA' */
                _.Display($"          ERRO INSERT TABELA PESSOA-FISICA");

                /*" -6827- DISPLAY '          COD PESSOA....................  ' COD-PESSOA OF DCLPESSOA-FISICA */
                _.Display($"          COD PESSOA....................  {PESFIS.DCLPESSOA_FISICA.COD_PESSOA}");

                /*" -6829- DISPLAY '          CPF...........................  ' CPF OF DCLPESSOA-FISICA */
                _.Display($"          CPF...........................  {PESFIS.DCLPESSOA_FISICA.CPF}");

                /*" -6831- DISPLAY '          DATA NASCIMENTO...............  ' DATA-NASCIMENTO OF DCLPESSOA-FISICA */
                _.Display($"          DATA NASCIMENTO...............  {PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO}");

                /*" -6833- DISPLAY '          SEXO..........................  ' SEXO OF DCLPESSOA-FISICA */
                _.Display($"          SEXO..........................  {PESFIS.DCLPESSOA_FISICA.SEXO}");

                /*" -6835- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -6837- DISPLAY '          SQLERRMC......................  ' SQLERRMC */
                _.Display($"          SQLERRMC......................  {DB.SQLERRMC}");

                /*" -6838- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -6840- END-IF. */
            }


            /*" -6840- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0542-00-INSERT-PESSOA-FISICA-DB-INSERT-1 */
        public void R0542_00_INSERT_PESSOA_FISICA_DB_INSERT_1()
        {
            /*" -6820- EXEC SQL INSERT INTO SEGUROS.PESSOA_FISICA VALUES (:DCLPESSOA.PESSOA-COD-PESSOA , :DCLPESSOA-FISICA.CPF , :DCLPESSOA-FISICA.DATA-NASCIMENTO , :DCLPESSOA-FISICA.SEXO , :DCLPESSOA-FISICA.COD-USUARIO , :DCLPESSOA-FISICA.ESTADO-CIVIL , CURRENT_TIMESTAMP , NULL , NULL , NULL , NULL , :DCLPESSOA-FISICA.COD-CBO , NULL ) END-EXEC */

            var r0542_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1 = new R0542_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
                DATA_NASCIMENTO = PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.ToString(),
                SEXO = PESFIS.DCLPESSOA_FISICA.SEXO.ToString(),
                COD_USUARIO = PESFIS.DCLPESSOA_FISICA.COD_USUARIO.ToString(),
                ESTADO_CIVIL = PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL.ToString(),
                COD_CBO = PESFIS.DCLPESSOA_FISICA.COD_CBO.ToString(),
            };

            R0542_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1.Execute(r0542_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0542_SAIDA*/

        [StopWatch]
        /*" R0543-00-INSERT-PESSOA-END-SECTION */
        private void R0543_00_INSERT_PESSOA_END_SECTION()
        {
            /*" -6849- MOVE 'R0543-00-INSERT-PESSOA-END    ' TO PARAGRAFO. */
            _.Move("R0543-00-INSERT-PESSOA-END    ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6850- MOVE 'INSERT PESSOA ENDERECO        ' TO COMANDO. */
            _.Move("INSERT PESSOA ENDERECO        ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6852- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6867- PERFORM R0543_00_INSERT_PESSOA_END_DB_INSERT_1 */

            R0543_00_INSERT_PESSOA_END_DB_INSERT_1();

            /*" -6870- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -6871- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -6872- DISPLAY '          ERRO INSERT TABELA PESSOA ENDER ' */
                _.Display($"          ERRO INSERT TABELA PESSOA ENDER ");

                /*" -6874- DISPLAY '          COD PESSOA................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          COD PESSOA................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -6876- DISPLAY '          OCORR-ENDERECO............  ' OCORR-ENDERECO OF DCLPESSOA-ENDERECO */
                _.Display($"          OCORR-ENDERECO............  {PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO}");

                /*" -6878- DISPLAY '          ENDERECO..................  ' ENDERECO OF DCLPESSOA-ENDERECO */
                _.Display($"          ENDERECO..................  {PESENDER.DCLPESSOA_ENDERECO.ENDERECO}");

                /*" -6880- DISPLAY '          SQLCODE...................  ' SQLCODE */
                _.Display($"          SQLCODE...................  {DB.SQLCODE}");

                /*" -6882- DISPLAY '          SQLERRMC......................  ' SQLERRMC */
                _.Display($"          SQLERRMC......................  {DB.SQLERRMC}");

                /*" -6883- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -6885- END-IF. */
            }


            /*" -6885- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0543-00-INSERT-PESSOA-END-DB-INSERT-1 */
        public void R0543_00_INSERT_PESSOA_END_DB_INSERT_1()
        {
            /*" -6867- EXEC SQL INSERT INTO SEGUROS.PESSOA_ENDERECO VALUES (:DCLPESSOA.PESSOA-COD-PESSOA , :DCLPESSOA-ENDERECO.OCORR-ENDERECO , :DCLPESSOA-ENDERECO.ENDERECO , :DCLPESSOA-ENDERECO.TIPO-ENDER , :DCLPESSOA-ENDERECO.COMPL-ENDER , :DCLPESSOA-ENDERECO.BAIRRO , :DCLPESSOA-ENDERECO.CEP , :DCLPESSOA-ENDERECO.CIDADE , :DCLPESSOA-ENDERECO.SIGLA-UF , :DCLPESSOA-ENDERECO.SITUACAO-ENDERECO , :DCLPESSOA-ENDERECO.COD-USUARIO , CURRENT_TIMESTAMP ) END-EXEC */

            var r0543_00_INSERT_PESSOA_END_DB_INSERT_1_Insert1 = new R0543_00_INSERT_PESSOA_END_DB_INSERT_1_Insert1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
                OCORR_ENDERECO = PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO.ToString(),
                ENDERECO = PESENDER.DCLPESSOA_ENDERECO.ENDERECO.ToString(),
                TIPO_ENDER = PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER.ToString(),
                COMPL_ENDER = PESENDER.DCLPESSOA_ENDERECO.COMPL_ENDER.ToString(),
                BAIRRO = PESENDER.DCLPESSOA_ENDERECO.BAIRRO.ToString(),
                CEP = PESENDER.DCLPESSOA_ENDERECO.CEP.ToString(),
                CIDADE = PESENDER.DCLPESSOA_ENDERECO.CIDADE.ToString(),
                SIGLA_UF = PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF.ToString(),
                SITUACAO_ENDERECO = PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO.ToString(),
                COD_USUARIO = PESENDER.DCLPESSOA_ENDERECO.COD_USUARIO.ToString(),
            };

            R0543_00_INSERT_PESSOA_END_DB_INSERT_1_Insert1.Execute(r0543_00_INSERT_PESSOA_END_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0543_SAIDA*/

        [StopWatch]
        /*" R0544-00-INSERT-PESSOA-FONE-SECTION */
        private void R0544_00_INSERT_PESSOA_FONE_SECTION()
        {
            /*" -6894- MOVE 'R0544-00-INSERT-PESSOA-FONE   ' TO PARAGRAFO. */
            _.Move("R0544-00-INSERT-PESSOA-FONE   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6895- MOVE 'INSERT PESSOA                 ' TO COMANDO. */
            _.Move("INSERT PESSOA                 ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6897- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6909- PERFORM R0544_00_INSERT_PESSOA_FONE_DB_INSERT_1 */

            R0544_00_INSERT_PESSOA_FONE_DB_INSERT_1();

            /*" -6912- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -6913- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -6914- DISPLAY '          ERRO INSERT TABELA PESSOA TELEF ' */
                _.Display($"          ERRO INSERT TABELA PESSOA TELEF ");

                /*" -6916- DISPLAY '          COD PESSOA................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          COD PESSOA................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -6918- DISPLAY '          TIPO-FONE.................  ' TIPO-FONE */
                _.Display($"          TIPO-FONE.................  {PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE}");

                /*" -6920- DISPLAY '          SEQ-FONE..................  ' SEQ-FONE */
                _.Display($"          SEQ-FONE..................  {PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE}");

                /*" -6922- DISPLAY '          SQLCODE...................  ' SQLCODE */
                _.Display($"          SQLCODE...................  {DB.SQLCODE}");

                /*" -6924- DISPLAY '          SQLERRMC..................  ' SQLERRMC */
                _.Display($"          SQLERRMC..................  {DB.SQLERRMC}");

                /*" -6925- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -6927- END-IF. */
            }


            /*" -6927- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0544-00-INSERT-PESSOA-FONE-DB-INSERT-1 */
        public void R0544_00_INSERT_PESSOA_FONE_DB_INSERT_1()
        {
            /*" -6909- EXEC SQL INSERT INTO SEGUROS.PESSOA_TELEFONE VALUES (:DCLPESSOA.PESSOA-COD-PESSOA , :TIPO-FONE , :SEQ-FONE , :DDI , :DDD , :NUM-FONE , :SITUACAO-FONE , 'VG2600B' , CURRENT_TIMESTAMP ) END-EXEC */

            var r0544_00_INSERT_PESSOA_FONE_DB_INSERT_1_Insert1 = new R0544_00_INSERT_PESSOA_FONE_DB_INSERT_1_Insert1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
                TIPO_FONE = PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE.ToString(),
                SEQ_FONE = PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE.ToString(),
                DDI = PESFONE.DCLPESSOA_TELEFONE.DDI.ToString(),
                DDD = PESFONE.DCLPESSOA_TELEFONE.DDD.ToString(),
                NUM_FONE = PESFONE.DCLPESSOA_TELEFONE.NUM_FONE.ToString(),
                SITUACAO_FONE = PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE.ToString(),
            };

            R0544_00_INSERT_PESSOA_FONE_DB_INSERT_1_Insert1.Execute(r0544_00_INSERT_PESSOA_FONE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0544_SAIDA*/

        [StopWatch]
        /*" R0545-00-INSERT-PESSOA-EMAIL-SECTION */
        private void R0545_00_INSERT_PESSOA_EMAIL_SECTION()
        {
            /*" -6936- MOVE 'R0545-00-INSERT-PESSOA-EMAIL  ' TO PARAGRAFO. */
            _.Move("R0545-00-INSERT-PESSOA-EMAIL  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6937- MOVE 'INSERT PESSOA EMAIL           ' TO COMANDO. */
            _.Move("INSERT PESSOA EMAIL           ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6939- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6948- PERFORM R0545_00_INSERT_PESSOA_EMAIL_DB_INSERT_1 */

            R0545_00_INSERT_PESSOA_EMAIL_DB_INSERT_1();

            /*" -6951- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -6952- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -6953- DISPLAY '          ERRO INSERT TABELA PESSOA EMAIL ' */
                _.Display($"          ERRO INSERT TABELA PESSOA EMAIL ");

                /*" -6955- DISPLAY '          COD PESSOA................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          COD PESSOA................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -6957- DISPLAY '          SEQ-EMAIL ................  ' SEQ-EMAIL */
                _.Display($"          SEQ-EMAIL ................  {PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL}");

                /*" -6959- DISPLAY '          EMAIL.....................  ' EMAIL */
                _.Display($"          EMAIL.....................  {PESEMAIL.DCLPESSOA_EMAIL.EMAIL}");

                /*" -6961- DISPLAY '          SQLCODE...................  ' SQLCODE */
                _.Display($"          SQLCODE...................  {DB.SQLCODE}");

                /*" -6963- DISPLAY '          SQLERRMC..................  ' SQLERRMC */
                _.Display($"          SQLERRMC..................  {DB.SQLERRMC}");

                /*" -6964- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -6966- END-IF. */
            }


            /*" -6966- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0545-00-INSERT-PESSOA-EMAIL-DB-INSERT-1 */
        public void R0545_00_INSERT_PESSOA_EMAIL_DB_INSERT_1()
        {
            /*" -6948- EXEC SQL INSERT INTO SEGUROS.PESSOA_EMAIL VALUES (:DCLPESSOA.PESSOA-COD-PESSOA , :SEQ-EMAIL , :EMAIL , :SITUACAO-EMAIL , 'VG2600B' , CURRENT_TIMESTAMP ) END-EXEC */

            var r0545_00_INSERT_PESSOA_EMAIL_DB_INSERT_1_Insert1 = new R0545_00_INSERT_PESSOA_EMAIL_DB_INSERT_1_Insert1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
                SEQ_EMAIL = PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL.ToString(),
                EMAIL = PESEMAIL.DCLPESSOA_EMAIL.EMAIL.ToString(),
                SITUACAO_EMAIL = PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL.ToString(),
            };

            R0545_00_INSERT_PESSOA_EMAIL_DB_INSERT_1_Insert1.Execute(r0545_00_INSERT_PESSOA_EMAIL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0545_SAIDA*/

        [StopWatch]
        /*" R0546-00-INSERT-REPRES-LEGAL-SECTION */
        private void R0546_00_INSERT_REPRES_LEGAL_SECTION()
        {
            /*" -6976- MOVE 'R0546-00-INSERT-REPRES-LEGAL  ' TO PARAGRAFO. */
            _.Move("R0546-00-INSERT-REPRES-LEGAL  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6977- MOVE 'INSERT REPRESENTANTE LEGAL    ' TO COMANDO. */
            _.Move("INSERT REPRESENTANTE LEGAL    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6979- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6994- PERFORM R0546_00_INSERT_REPRES_LEGAL_DB_INSERT_1 */

            R0546_00_INSERT_REPRES_LEGAL_DB_INSERT_1();

            /*" -6997- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -6998- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -6999- DISPLAY '          ERRO INSERT TABELA REPRES LEGAL ' */
                _.Display($"          ERRO INSERT TABELA REPRES LEGAL ");

                /*" -7001- DISPLAY '          COD PESSOA................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          COD PESSOA................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -7003- DISPLAY '          NUM-OCORR-HIST............  ' VG093-NUM-OCORR-HIST */
                _.Display($"          NUM-OCORR-HIST............  {VG093.DCLVG_REPRES_LEGAL.VG093_NUM_OCORR_HIST}");

                /*" -7005- DISPLAY '          NUM APOLICE...............  ' VG093-NUM-APOLICE */
                _.Display($"          NUM APOLICE...............  {VG093.DCLVG_REPRES_LEGAL.VG093_NUM_APOLICE}");

                /*" -7007- DISPLAY '          COD SUBGRUPO..............  ' VG093-COD-SUBGRUPO */
                _.Display($"          COD SUBGRUPO..............  {VG093.DCLVG_REPRES_LEGAL.VG093_COD_SUBGRUPO}");

                /*" -7009- DISPLAY '          VLR RENDA.................  ' VG093-VLR-RENDA */
                _.Display($"          VLR RENDA.................  {VG093.DCLVG_REPRES_LEGAL.VG093_VLR_RENDA}");

                /*" -7011- DISPLAY '          SQLCODE...................  ' SQLCODE */
                _.Display($"          SQLCODE...................  {DB.SQLCODE}");

                /*" -7013- DISPLAY '          SQLERRMC..................  ' SQLERRMC */
                _.Display($"          SQLERRMC..................  {DB.SQLERRMC}");

                /*" -7014- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -7016- END-IF. */
            }


            /*" -7016- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0546-00-INSERT-REPRES-LEGAL-DB-INSERT-1 */
        public void R0546_00_INSERT_REPRES_LEGAL_DB_INSERT_1()
        {
            /*" -6994- EXEC SQL INSERT INTO SEGUROS.VG_REPRES_LEGAL ( COD_PESSOA ,NUM_OCORR_HIST ,NUM_APOLICE ,COD_SUBGRUPO ,VLR_RENDA ) VALUES (:DCLPESSOA.PESSOA-COD-PESSOA , :VG093-NUM-OCORR-HIST , :VG093-NUM-APOLICE , :VG093-COD-SUBGRUPO , :VG093-VLR-RENDA ) END-EXEC */

            var r0546_00_INSERT_REPRES_LEGAL_DB_INSERT_1_Insert1 = new R0546_00_INSERT_REPRES_LEGAL_DB_INSERT_1_Insert1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
                VG093_NUM_OCORR_HIST = VG093.DCLVG_REPRES_LEGAL.VG093_NUM_OCORR_HIST.ToString(),
                VG093_NUM_APOLICE = VG093.DCLVG_REPRES_LEGAL.VG093_NUM_APOLICE.ToString(),
                VG093_COD_SUBGRUPO = VG093.DCLVG_REPRES_LEGAL.VG093_COD_SUBGRUPO.ToString(),
                VG093_VLR_RENDA = VG093.DCLVG_REPRES_LEGAL.VG093_VLR_RENDA.ToString(),
            };

            R0546_00_INSERT_REPRES_LEGAL_DB_INSERT_1_Insert1.Execute(r0546_00_INSERT_REPRES_LEGAL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0546_SAIDA*/

        [StopWatch]
        /*" R0547-00-INSERT-APOL-CORRET-SECTION */
        private void R0547_00_INSERT_APOL_CORRET_SECTION()
        {
            /*" -7025- MOVE 'R0547-00-INSERT-APOL-CORRET  ' TO PARAGRAFO. */
            _.Move("R0547-00-INSERT-APOL-CORRET  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7026- MOVE 'INSERT APOLICE CORRETOR      ' TO COMANDO. */
            _.Move("INSERT APOLICE CORRETOR      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7028- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7045- PERFORM R0547_00_INSERT_APOL_CORRET_DB_INSERT_1 */

            R0547_00_INSERT_APOL_CORRET_DB_INSERT_1();

            /*" -7048- IF (SQLCODE NOT EQUAL ZEROS AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -7049- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -7050- DISPLAY '          ERRO INSERT TABELA APOL CORRETOR' */
                _.Display($"          ERRO INSERT TABELA APOL CORRETOR");

                /*" -7052- DISPLAY '          NUM APOLICE...............  ' APOLICOR-NUM-APOLICE */
                _.Display($"          NUM APOLICE...............  {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_NUM_APOLICE}");

                /*" -7054- DISPLAY '          COD SUBGRUPO..............  ' APOLICOR-COD-SUBGRUPO */
                _.Display($"          COD SUBGRUPO..............  {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_SUBGRUPO}");

                /*" -7056- DISPLAY '          APOLICOR-RAMO-COBERTURA...  ' APOLICOR-RAMO-COBERTURA */
                _.Display($"          APOLICOR-RAMO-COBERTURA...  {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_RAMO_COBERTURA}");

                /*" -7058- DISPLAY '          APOLICOR-MODALI-COBERTURA.  ' APOLICOR-MODALI-COBERTURA */
                _.Display($"          APOLICOR-MODALI-COBERTURA.  {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_MODALI_COBERTURA}");

                /*" -7060- DISPLAY '          COD CORRETOR..............  ' APOLICOR-COD-CORRETOR */
                _.Display($"          COD CORRETOR..............  {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_CORRETOR}");

                /*" -7062- DISPLAY '          APOLICOR-DATA-INIVIGENCIA.  ' APOLICOR-DATA-INIVIGENCIA */
                _.Display($"          APOLICOR-DATA-INIVIGENCIA.  {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_INIVIGENCIA}");

                /*" -7064- DISPLAY '          APOLICOR-TIPO-COMISSAO....  ' APOLICOR-TIPO-COMISSAO */
                _.Display($"          APOLICOR-TIPO-COMISSAO....  {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_TIPO_COMISSAO}");

                /*" -7066- DISPLAY '          APOLICOR-DATA-TERVIGENCIA.  ' APOLICOR-DATA-TERVIGENCIA */
                _.Display($"          APOLICOR-DATA-TERVIGENCIA.  {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_TERVIGENCIA}");

                /*" -7068- DISPLAY '          SQLCODE...................  ' SQLCODE */
                _.Display($"          SQLCODE...................  {DB.SQLCODE}");

                /*" -7070- DISPLAY '          SQLERRMC..................  ' SQLERRMC */
                _.Display($"          SQLERRMC..................  {DB.SQLERRMC}");

                /*" -7071- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -7073- END-IF. */
            }


            /*" -7073- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0547-00-INSERT-APOL-CORRET-DB-INSERT-1 */
        public void R0547_00_INSERT_APOL_CORRET_DB_INSERT_1()
        {
            /*" -7045- EXEC SQL INSERT INTO SEGUROS.APOLICE_CORRETOR VALUES (:APOLICOR-NUM-APOLICE , :APOLICOR-RAMO-COBERTURA , :APOLICOR-MODALI-COBERTURA , :APOLICOR-COD-CORRETOR , :APOLICOR-COD-SUBGRUPO , :APOLICOR-DATA-INIVIGENCIA , :APOLICOR-DATA-TERVIGENCIA , :APOLICOR-PCT-PART-CORRETOR, :APOLICOR-PCT-COM-CORRETOR , :APOLICOR-TIPO-COMISSAO , :APOLICOR-IND-CORRETOR-PRIN, NULL , CURRENT_TIMESTAMP , :APOLICOR-COD-USUARIO ) END-EXEC */

            var r0547_00_INSERT_APOL_CORRET_DB_INSERT_1_Insert1 = new R0547_00_INSERT_APOL_CORRET_DB_INSERT_1_Insert1()
            {
                APOLICOR_NUM_APOLICE = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_NUM_APOLICE.ToString(),
                APOLICOR_RAMO_COBERTURA = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_RAMO_COBERTURA.ToString(),
                APOLICOR_MODALI_COBERTURA = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_MODALI_COBERTURA.ToString(),
                APOLICOR_COD_CORRETOR = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_CORRETOR.ToString(),
                APOLICOR_COD_SUBGRUPO = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_SUBGRUPO.ToString(),
                APOLICOR_DATA_INIVIGENCIA = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_INIVIGENCIA.ToString(),
                APOLICOR_DATA_TERVIGENCIA = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_TERVIGENCIA.ToString(),
                APOLICOR_PCT_PART_CORRETOR = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_PART_CORRETOR.ToString(),
                APOLICOR_PCT_COM_CORRETOR = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_COM_CORRETOR.ToString(),
                APOLICOR_TIPO_COMISSAO = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_TIPO_COMISSAO.ToString(),
                APOLICOR_IND_CORRETOR_PRIN = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_IND_CORRETOR_PRIN.ToString(),
                APOLICOR_COD_USUARIO = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_USUARIO.ToString(),
            };

            R0547_00_INSERT_APOL_CORRET_DB_INSERT_1_Insert1.Execute(r0547_00_INSERT_APOL_CORRET_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0547_SAIDA*/

        [StopWatch]
        /*" R0548-00-INSERT-PLANO-AGENC-SECTION */
        private void R0548_00_INSERT_PLANO_AGENC_SECTION()
        {
            /*" -7082- MOVE 'R0548-00-INSERT-PLANO-AGENC  ' TO PARAGRAFO. */
            _.Move("R0548-00-INSERT-PLANO-AGENC  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7083- MOVE 'INSERT PLANO AGENCIAMENTO    ' TO COMANDO. */
            _.Move("INSERT PLANO AGENCIAMENTO    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7085- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7095- PERFORM R0548_00_INSERT_PLANO_AGENC_DB_INSERT_1 */

            R0548_00_INSERT_PLANO_AGENC_DB_INSERT_1();

            /*" -7098- IF (SQLCODE NOT EQUAL ZEROS AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -7099- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -7100- DISPLAY '          ERRO INSERT TABELA PLANO_AGENC  ' */
                _.Display($"          ERRO INSERT TABELA PLANO_AGENC  ");

                /*" -7102- DISPLAY '          NUM APOLICE...............  ' APOLICOR-NUM-APOLICE */
                _.Display($"          NUM APOLICE...............  {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_NUM_APOLICE}");

                /*" -7104- DISPLAY '          COD SUBGRUPO..............  ' APOLICOR-COD-SUBGRUPO */
                _.Display($"          COD SUBGRUPO..............  {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_SUBGRUPO}");

                /*" -7106- DISPLAY '          PLANOAGE-NUM-PARCELA......  ' PLANOAGE-NUM-PARCELA */
                _.Display($"          PLANOAGE-NUM-PARCELA......  {PLANOAGE.DCLPLANO_AGENCIAMENTO.PLANOAGE_NUM_PARCELA}");

                /*" -7108- DISPLAY '          COD CORRETOR..............  ' PLANOAGE-MATRIC-INDICADOR */
                _.Display($"          COD CORRETOR..............  {PLANOAGE.DCLPLANO_AGENCIAMENTO.PLANOAGE_MATRIC_INDICADOR}");

                /*" -7110- DISPLAY '          SQLCODE...................  ' SQLCODE */
                _.Display($"          SQLCODE...................  {DB.SQLCODE}");

                /*" -7112- DISPLAY '          SQLERRMC..................  ' SQLERRMC */
                _.Display($"          SQLERRMC..................  {DB.SQLERRMC}");

                /*" -7113- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -7115- END-IF. */
            }


            /*" -7115- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0548-00-INSERT-PLANO-AGENC-DB-INSERT-1 */
        public void R0548_00_INSERT_PLANO_AGENC_DB_INSERT_1()
        {
            /*" -7095- EXEC SQL INSERT INTO SEGUROS.PLANO_AGENCIAMENTO VALUES (:PLANOAGE-NUM-APOLICE , :PLANOAGE-COD-SUBGRUPO , :PLANOAGE-NUM-PARCELA , :PLANOAGE-PCT-PAGA-PARCELA , NULL , :PLANOAGE-COD-AGENCIADOR , :PLANOAGE-MATRIC-INDICADOR ) END-EXEC */

            var r0548_00_INSERT_PLANO_AGENC_DB_INSERT_1_Insert1 = new R0548_00_INSERT_PLANO_AGENC_DB_INSERT_1_Insert1()
            {
                PLANOAGE_NUM_APOLICE = PLANOAGE.DCLPLANO_AGENCIAMENTO.PLANOAGE_NUM_APOLICE.ToString(),
                PLANOAGE_COD_SUBGRUPO = PLANOAGE.DCLPLANO_AGENCIAMENTO.PLANOAGE_COD_SUBGRUPO.ToString(),
                PLANOAGE_NUM_PARCELA = PLANOAGE.DCLPLANO_AGENCIAMENTO.PLANOAGE_NUM_PARCELA.ToString(),
                PLANOAGE_PCT_PAGA_PARCELA = PLANOAGE.DCLPLANO_AGENCIAMENTO.PLANOAGE_PCT_PAGA_PARCELA.ToString(),
                PLANOAGE_COD_AGENCIADOR = PLANOAGE.DCLPLANO_AGENCIAMENTO.PLANOAGE_COD_AGENCIADOR.ToString(),
                PLANOAGE_MATRIC_INDICADOR = PLANOAGE.DCLPLANO_AGENCIAMENTO.PLANOAGE_MATRIC_INDICADOR.ToString(),
            };

            R0548_00_INSERT_PLANO_AGENC_DB_INSERT_1_Insert1.Execute(r0548_00_INSERT_PLANO_AGENC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0548_SAIDA*/

        [StopWatch]
        /*" R0549-00-INSERT-COND-TECNICA-SECTION */
        private void R0549_00_INSERT_COND_TECNICA_SECTION()
        {
            /*" -7124- MOVE 'R0549-00-INSERT-COND-TECNICA ' TO PARAGRAFO. */
            _.Move("R0549-00-INSERT-COND-TECNICA ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7125- MOVE 'INSERT CONDICOES TECNICAS    ' TO COMANDO. */
            _.Move("INSERT CONDICOES TECNICAS    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7127- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7154- PERFORM R0549_00_INSERT_COND_TECNICA_DB_INSERT_1 */

            R0549_00_INSERT_COND_TECNICA_DB_INSERT_1();

            /*" -7157- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -7158- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -7159- DISPLAY '          ERRO INSERT TABELA COND TECNICAS' */
                _.Display($"          ERRO INSERT TABELA COND TECNICAS");

                /*" -7161- DISPLAY '          NUM APOLICE...............  ' CONDITEC-NUM-APOLICE */
                _.Display($"          NUM APOLICE...............  {CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_NUM_APOLICE}");

                /*" -7163- DISPLAY '          COD SUBGRUPO..............  ' CONDITEC-COD-SUBGRUPO */
                _.Display($"          COD SUBGRUPO..............  {CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_COD_SUBGRUPO}");

                /*" -7165- DISPLAY '          SQLCODE...................  ' SQLCODE */
                _.Display($"          SQLCODE...................  {DB.SQLCODE}");

                /*" -7167- DISPLAY '          SQLERRMC..................  ' SQLERRMC */
                _.Display($"          SQLERRMC..................  {DB.SQLERRMC}");

                /*" -7168- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -7170- END-IF. */
            }


            /*" -7170- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0549-00-INSERT-COND-TECNICA-DB-INSERT-1 */
        public void R0549_00_INSERT_COND_TECNICA_DB_INSERT_1()
        {
            /*" -7154- EXEC SQL INSERT INTO SEGUROS.CONDICOES_TECNICAS VALUES (:CONDITEC-NUM-APOLICE , :CONDITEC-COD-SUBGRUPO , :CONDITEC-QTD-SAL-MORNATU , :CONDITEC-QTD-SAL-MORACID , :CONDITEC-QTD-SAL-INVPERM , :CONDITEC-TAXA-AP-MORACID , :CONDITEC-TAXA-AP-INVPERM , :CONDITEC-TAXA-AP-AMDS , :CONDITEC-TAXA-AP-DH , :CONDITEC-TAXA-AP-DIT , :CONDITEC-TAXA-AP , :CONDITEC-CARREGA-PRINCIPAL, :CONDITEC-CARREGA-CONJUGE , :CONDITEC-CARREGA-FILHOS , :CONDITEC-GARAN-ADIC-IEA , :CONDITEC-GARAN-ADIC-IPA , :CONDITEC-GARAN-ADIC-IPD , :CONDITEC-GARAN-ADIC-HD , :CONDITEC-TAXA-DESPESA-ADM , :CONDITEC-TAXA-IRB , :CONDITEC-LIM-CAP-MORNATU , :CONDITEC-LIM-CAP-MORACID , :CONDITEC-LIM-CAP-INVAPER , :CONDITEC-COD-EMPRESA ) END-EXEC */

            var r0549_00_INSERT_COND_TECNICA_DB_INSERT_1_Insert1 = new R0549_00_INSERT_COND_TECNICA_DB_INSERT_1_Insert1()
            {
                CONDITEC_NUM_APOLICE = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_NUM_APOLICE.ToString(),
                CONDITEC_COD_SUBGRUPO = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_COD_SUBGRUPO.ToString(),
                CONDITEC_QTD_SAL_MORNATU = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_MORNATU.ToString(),
                CONDITEC_QTD_SAL_MORACID = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_MORACID.ToString(),
                CONDITEC_QTD_SAL_INVPERM = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_INVPERM.ToString(),
                CONDITEC_TAXA_AP_MORACID = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_MORACID.ToString(),
                CONDITEC_TAXA_AP_INVPERM = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_INVPERM.ToString(),
                CONDITEC_TAXA_AP_AMDS = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_AMDS.ToString(),
                CONDITEC_TAXA_AP_DH = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DH.ToString(),
                CONDITEC_TAXA_AP_DIT = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DIT.ToString(),
                CONDITEC_TAXA_AP = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP.ToString(),
                CONDITEC_CARREGA_PRINCIPAL = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_PRINCIPAL.ToString(),
                CONDITEC_CARREGA_CONJUGE = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE.ToString(),
                CONDITEC_CARREGA_FILHOS = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_FILHOS.ToString(),
                CONDITEC_GARAN_ADIC_IEA = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IEA.ToString(),
                CONDITEC_GARAN_ADIC_IPA = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPA.ToString(),
                CONDITEC_GARAN_ADIC_IPD = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPD.ToString(),
                CONDITEC_GARAN_ADIC_HD = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_HD.ToString(),
                CONDITEC_TAXA_DESPESA_ADM = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_DESPESA_ADM.ToString(),
                CONDITEC_TAXA_IRB = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_IRB.ToString(),
                CONDITEC_LIM_CAP_MORNATU = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_LIM_CAP_MORNATU.ToString(),
                CONDITEC_LIM_CAP_MORACID = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_LIM_CAP_MORACID.ToString(),
                CONDITEC_LIM_CAP_INVAPER = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_LIM_CAP_INVAPER.ToString(),
                CONDITEC_COD_EMPRESA = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_COD_EMPRESA.ToString(),
            };

            R0549_00_INSERT_COND_TECNICA_DB_INSERT_1_Insert1.Execute(r0549_00_INSERT_COND_TECNICA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0549_SAIDA*/

        [StopWatch]
        /*" R0550-00-INSERT-PLANOS-VGAP-SECTION */
        private void R0550_00_INSERT_PLANOS_VGAP_SECTION()
        {
            /*" -7179- MOVE 'R0550-00-INSERT-PLANOS-VGAP ' TO PARAGRAFO. */
            _.Move("R0550-00-INSERT-PLANOS-VGAP ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7180- MOVE 'INSERT PLANOS VGAP          ' TO COMANDO. */
            _.Move("INSERT PLANOS VGAP          ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7182- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7198- PERFORM R0550_00_INSERT_PLANOS_VGAP_DB_INSERT_1 */

            R0550_00_INSERT_PLANOS_VGAP_DB_INSERT_1();

            /*" -7201- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -7202- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -7203- DISPLAY '          ERRO INSERT TABELA PLANOS VGAP' */
                _.Display($"          ERRO INSERT TABELA PLANOS VGAP");

                /*" -7205- DISPLAY '          NUM APOLICE...............  ' PLANOVGA-NUM-APOLICE */
                _.Display($"          NUM APOLICE...............  {PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_NUM_APOLICE}");

                /*" -7207- DISPLAY '          COD SUBGRUPO..............  ' PLANOVGA-COD-SUBGRUPO */
                _.Display($"          COD SUBGRUPO..............  {PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_COD_SUBGRUPO}");

                /*" -7209- DISPLAY '          COD PLANO.................  ' PLANOVGA-COD-PLANO */
                _.Display($"          COD PLANO.................  {PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_COD_PLANO}");

                /*" -7211- DISPLAY '          PLANOVGA-DATA-INIVIGENCIA.  ' PLANOVGA-DATA-INIVIGENCIA */
                _.Display($"          PLANOVGA-DATA-INIVIGENCIA.  {PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_DATA_INIVIGENCIA}");

                /*" -7213- DISPLAY '          SQLCODE...................  ' SQLCODE */
                _.Display($"          SQLCODE...................  {DB.SQLCODE}");

                /*" -7215- DISPLAY '          SQLERRMC..................  ' SQLERRMC */
                _.Display($"          SQLERRMC..................  {DB.SQLERRMC}");

                /*" -7216- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -7218- END-IF. */
            }


            /*" -7218- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0550-00-INSERT-PLANOS-VGAP-DB-INSERT-1 */
        public void R0550_00_INSERT_PLANOS_VGAP_DB_INSERT_1()
        {
            /*" -7198- EXEC SQL INSERT INTO SEGUROS.PLANOS_VGAP VALUES (:PLANOVGA-NUM-APOLICE , :PLANOVGA-COD-SUBGRUPO , :PLANOVGA-COD-PLANO , :PLANOVGA-DATA-INIVIGENCIA , :PLANOVGA-IMP-MORNATU , :PLANOVGA-IMP-MORACID , :PLANOVGA-IMP-INVPERM , :PLANOVGA-IMP-AMDS , :PLANOVGA-IMP-DH , :PLANOVGA-IMP-DIT , :PLANOVGA-SIT-REGISTRO , NULL , :PLANOVGA-DATA-TERVIGENCIA ) END-EXEC */

            var r0550_00_INSERT_PLANOS_VGAP_DB_INSERT_1_Insert1 = new R0550_00_INSERT_PLANOS_VGAP_DB_INSERT_1_Insert1()
            {
                PLANOVGA_NUM_APOLICE = PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_NUM_APOLICE.ToString(),
                PLANOVGA_COD_SUBGRUPO = PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_COD_SUBGRUPO.ToString(),
                PLANOVGA_COD_PLANO = PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_COD_PLANO.ToString(),
                PLANOVGA_DATA_INIVIGENCIA = PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_DATA_INIVIGENCIA.ToString(),
                PLANOVGA_IMP_MORNATU = PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_MORNATU.ToString(),
                PLANOVGA_IMP_MORACID = PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_MORACID.ToString(),
                PLANOVGA_IMP_INVPERM = PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_INVPERM.ToString(),
                PLANOVGA_IMP_AMDS = PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_AMDS.ToString(),
                PLANOVGA_IMP_DH = PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_DH.ToString(),
                PLANOVGA_IMP_DIT = PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_DIT.ToString(),
                PLANOVGA_SIT_REGISTRO = PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_SIT_REGISTRO.ToString(),
                PLANOVGA_DATA_TERVIGENCIA = PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_DATA_TERVIGENCIA.ToString(),
            };

            R0550_00_INSERT_PLANOS_VGAP_DB_INSERT_1_Insert1.Execute(r0550_00_INSERT_PLANOS_VGAP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_SAIDA*/

        [StopWatch]
        /*" R0551-00-INSERT-PLAN-MULTISAL-SECTION */
        private void R0551_00_INSERT_PLAN_MULTISAL_SECTION()
        {
            /*" -7227- MOVE 'R0551-00-INSERT-PLAN-MULTISAL ' TO PARAGRAFO. */
            _.Move("R0551-00-INSERT-PLAN-MULTISAL ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7228- MOVE 'INSERT PLANOS MULTISALARIAL   ' TO COMANDO. */
            _.Move("INSERT PLANOS MULTISALARIAL   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7230- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7243- PERFORM R0551_00_INSERT_PLAN_MULTISAL_DB_INSERT_1 */

            R0551_00_INSERT_PLAN_MULTISAL_DB_INSERT_1();

            /*" -7246- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -7247- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -7248- DISPLAY '          ERRO INSERT TABELA PLANOS MULTISAL' */
                _.Display($"          ERRO INSERT TABELA PLANOS MULTISAL");

                /*" -7250- DISPLAY '          NUM APOLICE...............  ' PLANOMUL-NUM-APOLICE */
                _.Display($"          NUM APOLICE...............  {PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_NUM_APOLICE}");

                /*" -7252- DISPLAY '          COD SUBGRUPO..............  ' PLANOMUL-COD-SUBGRUPO */
                _.Display($"          COD SUBGRUPO..............  {PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_COD_SUBGRUPO}");

                /*" -7254- DISPLAY '          COD PLANO.................  ' PLANOMUL-COD-PLANO */
                _.Display($"          COD PLANO.................  {PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_COD_PLANO}");

                /*" -7256- DISPLAY '          SQLCODE...................  ' SQLCODE */
                _.Display($"          SQLCODE...................  {DB.SQLCODE}");

                /*" -7258- DISPLAY '          SQLERRMC..................  ' SQLERRMC */
                _.Display($"          SQLERRMC..................  {DB.SQLERRMC}");

                /*" -7259- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -7261- END-IF. */
            }


            /*" -7261- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0551-00-INSERT-PLAN-MULTISAL-DB-INSERT-1 */
        public void R0551_00_INSERT_PLAN_MULTISAL_DB_INSERT_1()
        {
            /*" -7243- EXEC SQL INSERT INTO SEGUROS.PLANOS_MULTISAL VALUES (:PLANOMUL-NUM-APOLICE , :PLANOMUL-COD-SUBGRUPO , :PLANOMUL-COD-PLANO , :PLANOMUL-QTD-SAL-MORNATU , :PLANOMUL-QTD-SAL-MORACID , :PLANOMUL-QTD-SAL-INVPERM , :PLANOMUL-LIM-CAP-MORNATU , :PLANOMUL-LIM-CAP-MORACID , :PLANOMUL-LIM-CAP-INVAPER , NULL ) END-EXEC */

            var r0551_00_INSERT_PLAN_MULTISAL_DB_INSERT_1_Insert1 = new R0551_00_INSERT_PLAN_MULTISAL_DB_INSERT_1_Insert1()
            {
                PLANOMUL_NUM_APOLICE = PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_NUM_APOLICE.ToString(),
                PLANOMUL_COD_SUBGRUPO = PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_COD_SUBGRUPO.ToString(),
                PLANOMUL_COD_PLANO = PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_COD_PLANO.ToString(),
                PLANOMUL_QTD_SAL_MORNATU = PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_QTD_SAL_MORNATU.ToString(),
                PLANOMUL_QTD_SAL_MORACID = PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_QTD_SAL_MORACID.ToString(),
                PLANOMUL_QTD_SAL_INVPERM = PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_QTD_SAL_INVPERM.ToString(),
                PLANOMUL_LIM_CAP_MORNATU = PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_LIM_CAP_MORNATU.ToString(),
                PLANOMUL_LIM_CAP_MORACID = PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_LIM_CAP_MORACID.ToString(),
                PLANOMUL_LIM_CAP_INVAPER = PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_LIM_CAP_INVAPER.ToString(),
            };

            R0551_00_INSERT_PLAN_MULTISAL_DB_INSERT_1_Insert1.Execute(r0551_00_INSERT_PLAN_MULTISAL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0551_SAIDA*/

        [StopWatch]
        /*" R0552-00-INSERT-FAIXA-ETARIA-SECTION */
        private void R0552_00_INSERT_FAIXA_ETARIA_SECTION()
        {
            /*" -7270- MOVE 'R0552-00-INSERT-FAIXA-ETARIA ' TO PARAGRAFO. */
            _.Move("R0552-00-INSERT-FAIXA-ETARIA ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7271- MOVE 'INSERT FAIXA ETARIA          ' TO COMANDO. */
            _.Move("INSERT FAIXA ETARIA          ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7273- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7285- PERFORM R0552_00_INSERT_FAIXA_ETARIA_DB_INSERT_1 */

            R0552_00_INSERT_FAIXA_ETARIA_DB_INSERT_1();

            /*" -7288- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -7289- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -7290- DISPLAY '          ERRO INSERT TABELA FAIXA ETARIA ' */
                _.Display($"          ERRO INSERT TABELA FAIXA ETARIA ");

                /*" -7292- DISPLAY '          NUM APOLICE...............  ' FAIXAETA-NUM-APOLICE */
                _.Display($"          NUM APOLICE...............  {FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_NUM_APOLICE}");

                /*" -7294- DISPLAY '          COD SUBGRUPO..............  ' FAIXAETA-COD-SUBGRUPO */
                _.Display($"          COD SUBGRUPO..............  {FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_COD_SUBGRUPO}");

                /*" -7297- DISPLAY '          COD FAIXA.................  ' FAIXAETA-FAIXA */
                _.Display($"          COD FAIXA.................  {FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_FAIXA}");

                /*" -7299- DISPLAY '          FAIXAETA-DATA-INIVIGENCIA.  ' FAIXAETA-DATA-INIVIGENCIA */
                _.Display($"          FAIXAETA-DATA-INIVIGENCIA.  {FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_DATA_INIVIGENCIA}");

                /*" -7301- DISPLAY '          FAIXAETA-DATA-TERVIGENCIA.  ' FAIXAETA-DATA-TERVIGENCIA */
                _.Display($"          FAIXAETA-DATA-TERVIGENCIA.  {FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_DATA_TERVIGENCIA}");

                /*" -7303- DISPLAY '          SQLCODE...................  ' SQLCODE */
                _.Display($"          SQLCODE...................  {DB.SQLCODE}");

                /*" -7305- DISPLAY '          SQLERRMC..................  ' SQLERRMC */
                _.Display($"          SQLERRMC..................  {DB.SQLERRMC}");

                /*" -7306- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -7308- END-IF. */
            }


            /*" -7308- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0552-00-INSERT-FAIXA-ETARIA-DB-INSERT-1 */
        public void R0552_00_INSERT_FAIXA_ETARIA_DB_INSERT_1()
        {
            /*" -7285- EXEC SQL INSERT INTO SEGUROS.FAIXA_ETARIA VALUES (:FAIXAETA-NUM-APOLICE , :FAIXAETA-COD-SUBGRUPO , :FAIXAETA-FAIXA , :FAIXAETA-IDADE-INICIAL , :FAIXAETA-IDADE-FINAL , :FAIXAETA-TAXA-VG , NULL , :FAIXAETA-DATA-INIVIGENCIA , :FAIXAETA-DATA-TERVIGENCIA ) END-EXEC */

            var r0552_00_INSERT_FAIXA_ETARIA_DB_INSERT_1_Insert1 = new R0552_00_INSERT_FAIXA_ETARIA_DB_INSERT_1_Insert1()
            {
                FAIXAETA_NUM_APOLICE = FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_NUM_APOLICE.ToString(),
                FAIXAETA_COD_SUBGRUPO = FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_COD_SUBGRUPO.ToString(),
                FAIXAETA_FAIXA = FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_FAIXA.ToString(),
                FAIXAETA_IDADE_INICIAL = FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_IDADE_INICIAL.ToString(),
                FAIXAETA_IDADE_FINAL = FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_IDADE_FINAL.ToString(),
                FAIXAETA_TAXA_VG = FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_TAXA_VG.ToString(),
                FAIXAETA_DATA_INIVIGENCIA = FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_DATA_INIVIGENCIA.ToString(),
                FAIXAETA_DATA_TERVIGENCIA = FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_DATA_TERVIGENCIA.ToString(),
            };

            R0552_00_INSERT_FAIXA_ETARIA_DB_INSERT_1_Insert1.Execute(r0552_00_INSERT_FAIXA_ETARIA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0552_SAIDA*/

        [StopWatch]
        /*" R0553-00-INSERT-PLANO-ETARIA-SECTION */
        private void R0553_00_INSERT_PLANO_ETARIA_SECTION()
        {
            /*" -7317- MOVE 'R0553-00-INSERT-PLANO-ETARIA ' TO PARAGRAFO. */
            _.Move("R0553-00-INSERT-PLANO-ETARIA ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7318- MOVE 'INSERT PLANO ETARIA          ' TO COMANDO. */
            _.Move("INSERT PLANO ETARIA          ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7320- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7334- PERFORM R0553_00_INSERT_PLANO_ETARIA_DB_INSERT_1 */

            R0553_00_INSERT_PLANO_ETARIA_DB_INSERT_1();

            /*" -7337- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -7338- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -7339- DISPLAY '          ERRO INSERT TABELA PLANO ETARIA ' */
                _.Display($"          ERRO INSERT TABELA PLANO ETARIA ");

                /*" -7341- DISPLAY '          NUM APOLICE...............  ' PLANOFAI-NUM-APOLICE */
                _.Display($"          NUM APOLICE...............  {PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_NUM_APOLICE}");

                /*" -7343- DISPLAY '          COD SUBGRUPO..............  ' PLANOFAI-COD-SUBGRUPO */
                _.Display($"          COD SUBGRUPO..............  {PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_COD_SUBGRUPO}");

                /*" -7345- DISPLAY '          COD PLANO.................  ' PLANOFAI-COD-PLANO */
                _.Display($"          COD PLANO.................  {PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_COD_PLANO}");

                /*" -7347- DISPLAY '          COD FAIXA.................  ' PLANOFAI-FAIXA */
                _.Display($"          COD FAIXA.................  {PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_FAIXA}");

                /*" -7349- DISPLAY '          PLANOFAI-IDADE-INICIAL....  ' PLANOFAI-IDADE-INICIAL */
                _.Display($"          PLANOFAI-IDADE-INICIAL....  {PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_IDADE_INICIAL}");

                /*" -7351- DISPLAY '          PLANOFAI-IDADE-FINAL......  ' PLANOFAI-IDADE-FINAL */
                _.Display($"          PLANOFAI-IDADE-FINAL......  {PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_IDADE_FINAL}");

                /*" -7353- DISPLAY '          PLANOFAI-PRM-VG...........  ' PLANOFAI-PRM-VG */
                _.Display($"          PLANOFAI-PRM-VG...........  {PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_PRM_VG}");

                /*" -7355- DISPLAY '          PLANOFAI-PRM-AP...........  ' PLANOFAI-PRM-AP */
                _.Display($"          PLANOFAI-PRM-AP...........  {PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_PRM_AP}");

                /*" -7357- DISPLAY '          PLANOFAI-DATA-INIVIGENCIA.  ' PLANOFAI-DATA-TERVIGENCIA */
                _.Display($"          PLANOFAI-DATA-INIVIGENCIA.  {PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_DATA_TERVIGENCIA}");

                /*" -7359- DISPLAY '          SQLCODE...................  ' SQLCODE */
                _.Display($"          SQLCODE...................  {DB.SQLCODE}");

                /*" -7361- DISPLAY '          SQLERRMC..................  ' SQLERRMC */
                _.Display($"          SQLERRMC..................  {DB.SQLERRMC}");

                /*" -7362- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -7364- END-IF. */
            }


            /*" -7364- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0553-00-INSERT-PLANO-ETARIA-DB-INSERT-1 */
        public void R0553_00_INSERT_PLANO_ETARIA_DB_INSERT_1()
        {
            /*" -7334- EXEC SQL INSERT INTO SEGUROS.PLANOS_FAIXAETA VALUES (:PLANOFAI-NUM-APOLICE , :PLANOFAI-COD-SUBGRUPO , :PLANOFAI-COD-PLANO , :PLANOFAI-FAIXA , :PLANOFAI-IDADE-INICIAL , :PLANOFAI-IDADE-FINAL , :PLANOFAI-PRM-VG , :PLANOFAI-PRM-AP , NULL , :PLANOFAI-DATA-INIVIGENCIA, :PLANOFAI-DATA-TERVIGENCIA) END-EXEC */

            var r0553_00_INSERT_PLANO_ETARIA_DB_INSERT_1_Insert1 = new R0553_00_INSERT_PLANO_ETARIA_DB_INSERT_1_Insert1()
            {
                PLANOFAI_NUM_APOLICE = PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_NUM_APOLICE.ToString(),
                PLANOFAI_COD_SUBGRUPO = PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_COD_SUBGRUPO.ToString(),
                PLANOFAI_COD_PLANO = PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_COD_PLANO.ToString(),
                PLANOFAI_FAIXA = PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_FAIXA.ToString(),
                PLANOFAI_IDADE_INICIAL = PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_IDADE_INICIAL.ToString(),
                PLANOFAI_IDADE_FINAL = PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_IDADE_FINAL.ToString(),
                PLANOFAI_PRM_VG = PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_PRM_VG.ToString(),
                PLANOFAI_PRM_AP = PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_PRM_AP.ToString(),
                PLANOFAI_DATA_INIVIGENCIA = PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_DATA_INIVIGENCIA.ToString(),
                PLANOFAI_DATA_TERVIGENCIA = PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_DATA_TERVIGENCIA.ToString(),
            };

            R0553_00_INSERT_PLANO_ETARIA_DB_INSERT_1_Insert1.Execute(r0553_00_INSERT_PLANO_ETARIA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0553_SAIDA*/

        [StopWatch]
        /*" R0554-00-INSERT-FAIXA-SALARL-SECTION */
        private void R0554_00_INSERT_FAIXA_SALARL_SECTION()
        {
            /*" -7373- MOVE 'R0554-00-INSERT-FAIXA-SALARL ' TO PARAGRAFO. */
            _.Move("R0554-00-INSERT-FAIXA-SALARL ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7374- MOVE 'INSERT FAIXA SALARIAL        ' TO COMANDO. */
            _.Move("INSERT FAIXA SALARIAL        ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7376- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7386- PERFORM R0554_00_INSERT_FAIXA_SALARL_DB_INSERT_1 */

            R0554_00_INSERT_FAIXA_SALARL_DB_INSERT_1();

            /*" -7389- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -7390- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -7391- DISPLAY '          ERRO INSERT TABELA FAIXA SALARIAL' */
                _.Display($"          ERRO INSERT TABELA FAIXA SALARIAL");

                /*" -7393- DISPLAY '          NUM APOLICE...............  ' FAIXASAL-NUM-APOLICE */
                _.Display($"          NUM APOLICE...............  {FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_NUM_APOLICE}");

                /*" -7395- DISPLAY '          COD SUBGRUPO..............  ' FAIXASAL-COD-SUBGRUPO */
                _.Display($"          COD SUBGRUPO..............  {FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_COD_SUBGRUPO}");

                /*" -7397- DISPLAY '          COD FAIXA.................  ' FAIXASAL-FAIXA */
                _.Display($"          COD FAIXA.................  {FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_FAIXA}");

                /*" -7399- DISPLAY '          FAIXASAL-SALARIO-INICIAL..  ' FAIXASAL-SALARIO-INICIAL */
                _.Display($"          FAIXASAL-SALARIO-INICIAL..  {FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_SALARIO_INICIAL}");

                /*" -7401- DISPLAY '          FAIXASAL-SALARIO-FINAL....  ' FAIXASAL-SALARIO-FINAL */
                _.Display($"          FAIXASAL-SALARIO-FINAL....  {FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_SALARIO_FINAL}");

                /*" -7403- DISPLAY '          FAIXASAL-TAXA-VG..........  ' FAIXASAL-TAXA-VG */
                _.Display($"          FAIXASAL-TAXA-VG..........  {FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_TAXA_VG}");

                /*" -7405- DISPLAY '          SQLCODE...................  ' SQLCODE */
                _.Display($"          SQLCODE...................  {DB.SQLCODE}");

                /*" -7407- DISPLAY '          SQLERRMC..................  ' SQLERRMC */
                _.Display($"          SQLERRMC..................  {DB.SQLERRMC}");

                /*" -7408- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -7410- END-IF. */
            }


            /*" -7410- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0554-00-INSERT-FAIXA-SALARL-DB-INSERT-1 */
        public void R0554_00_INSERT_FAIXA_SALARL_DB_INSERT_1()
        {
            /*" -7386- EXEC SQL INSERT INTO SEGUROS.FAIXA_SALARIAL VALUES (:FAIXASAL-NUM-APOLICE , :FAIXASAL-COD-SUBGRUPO , :FAIXASAL-FAIXA , :FAIXASAL-SALARIO-INICIAL , :FAIXASAL-SALARIO-FINAL , :FAIXASAL-TAXA-VG , NULL ) END-EXEC */

            var r0554_00_INSERT_FAIXA_SALARL_DB_INSERT_1_Insert1 = new R0554_00_INSERT_FAIXA_SALARL_DB_INSERT_1_Insert1()
            {
                FAIXASAL_NUM_APOLICE = FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_NUM_APOLICE.ToString(),
                FAIXASAL_COD_SUBGRUPO = FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_COD_SUBGRUPO.ToString(),
                FAIXASAL_FAIXA = FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_FAIXA.ToString(),
                FAIXASAL_SALARIO_INICIAL = FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_SALARIO_INICIAL.ToString(),
                FAIXASAL_SALARIO_FINAL = FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_SALARIO_FINAL.ToString(),
                FAIXASAL_TAXA_VG = FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_TAXA_VG.ToString(),
            };

            R0554_00_INSERT_FAIXA_SALARL_DB_INSERT_1_Insert1.Execute(r0554_00_INSERT_FAIXA_SALARL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0554_SAIDA*/

        [StopWatch]
        /*" R0555-00-INSERT-PLANO-SALARL-SECTION */
        private void R0555_00_INSERT_PLANO_SALARL_SECTION()
        {
            /*" -7419- MOVE 'R0555-00-INSERT-PLANO-SALARL ' TO PARAGRAFO. */
            _.Move("R0555-00-INSERT-PLANO-SALARL ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7420- MOVE 'INSERT PLANO SALARIAL        ' TO COMANDO. */
            _.Move("INSERT PLANO SALARIAL        ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7422- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7434- PERFORM R0555_00_INSERT_PLANO_SALARL_DB_INSERT_1 */

            R0555_00_INSERT_PLANO_SALARL_DB_INSERT_1();

            /*" -7437- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -7438- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -7439- DISPLAY '          ERRO INSERT TABELA PLANO SALARIAL ' */
                _.Display($"          ERRO INSERT TABELA PLANO SALARIAL ");

                /*" -7441- DISPLAY '          NUM APOLICE...............  ' PLANFSAL-NUM-APOLICE */
                _.Display($"          NUM APOLICE...............  {PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_NUM_APOLICE}");

                /*" -7443- DISPLAY '          COD SUBGRUPO..............  ' PLANFSAL-COD-SUBGRUPO */
                _.Display($"          COD SUBGRUPO..............  {PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_COD_SUBGRUPO}");

                /*" -7445- DISPLAY '          COD PLANO.................  ' PLANFSAL-COD-PLANO */
                _.Display($"          COD PLANO.................  {PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_COD_PLANO}");

                /*" -7447- DISPLAY '          COD FAIXA.................  ' PLANFSAL-FAIXA */
                _.Display($"          COD FAIXA.................  {PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_FAIXA}");

                /*" -7449- DISPLAY '          SQLCODE...................  ' SQLCODE */
                _.Display($"          SQLCODE...................  {DB.SQLCODE}");

                /*" -7451- DISPLAY '          SQLERRMC..................  ' SQLERRMC */
                _.Display($"          SQLERRMC..................  {DB.SQLERRMC}");

                /*" -7452- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -7454- END-IF. */
            }


            /*" -7454- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0555-00-INSERT-PLANO-SALARL-DB-INSERT-1 */
        public void R0555_00_INSERT_PLANO_SALARL_DB_INSERT_1()
        {
            /*" -7434- EXEC SQL INSERT INTO SEGUROS.PLANOS_FAIXASAL VALUES (:PLANFSAL-NUM-APOLICE , :PLANFSAL-COD-SUBGRUPO , :PLANFSAL-COD-PLANO , :PLANFSAL-FAIXA , :PLANFSAL-SALARIO-INICIAL , :PLANFSAL-SALARIO-FINAL , :PLANFSAL-PRM-VG , :PLANFSAL-PRM-AP , NULL ) END-EXEC */

            var r0555_00_INSERT_PLANO_SALARL_DB_INSERT_1_Insert1 = new R0555_00_INSERT_PLANO_SALARL_DB_INSERT_1_Insert1()
            {
                PLANFSAL_NUM_APOLICE = PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_NUM_APOLICE.ToString(),
                PLANFSAL_COD_SUBGRUPO = PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_COD_SUBGRUPO.ToString(),
                PLANFSAL_COD_PLANO = PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_COD_PLANO.ToString(),
                PLANFSAL_FAIXA = PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_FAIXA.ToString(),
                PLANFSAL_SALARIO_INICIAL = PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_SALARIO_INICIAL.ToString(),
                PLANFSAL_SALARIO_FINAL = PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_SALARIO_FINAL.ToString(),
                PLANFSAL_PRM_VG = PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_PRM_VG.ToString(),
                PLANFSAL_PRM_AP = PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_PRM_AP.ToString(),
            };

            R0555_00_INSERT_PLANO_SALARL_DB_INSERT_1_Insert1.Execute(r0555_00_INSERT_PLANO_SALARL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0555_SAIDA*/

        [StopWatch]
        /*" R0556-00-INSERT-CONV-SICOB-SECTION */
        private void R0556_00_INSERT_CONV_SICOB_SECTION()
        {
            /*" -7463- MOVE 'R0556-00-INSERT-CONV-SICOB' TO PARAGRAFO. */
            _.Move("R0556-00-INSERT-CONV-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7464- MOVE 'INSERT CONVERSAO SICOB    ' TO COMANDO. */
            _.Move("INSERT CONVERSAO SICOB    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7465- MOVE SISTEMAS-DATA-MOV-ABERTO TO CONVERSI-DATA-QUITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_DATA_QUITACAO);

            /*" -7467- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7480- PERFORM R0556_00_INSERT_CONV_SICOB_DB_INSERT_1 */

            R0556_00_INSERT_CONV_SICOB_DB_INSERT_1();

            /*" -7483- IF (SQLCODE NOT EQUAL ZEROS AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -7484- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -7485- DISPLAY '          ERRO INSERT DA TABELA CONVERSAO ' */
                _.Display($"          ERRO INSERT DA TABELA CONVERSAO ");

                /*" -7487- DISPLAY '          NUM APOLICE...................  ' CONVERSI-NUM-SICOB */
                _.Display($"          NUM APOLICE...................  {CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB}");

                /*" -7489- DISPLAY '          NUMERO PROPOSTA...............  ' CONVERSI-NUM-PROPOSTA-SIVPF */
                _.Display($"          NUMERO PROPOSTA...............  {CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF}");

                /*" -7491- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -7493- DISPLAY '          SQLERRMC......................  ' SQLERRMC */
                _.Display($"          SQLERRMC......................  {DB.SQLERRMC}");

                /*" -7494- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -7496- END-IF. */
            }


            /*" -7496- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0556-00-INSERT-CONV-SICOB-DB-INSERT-1 */
        public void R0556_00_INSERT_CONV_SICOB_DB_INSERT_1()
        {
            /*" -7480- EXEC SQL INSERT INTO SEGUROS.CONVERSAO_SICOB VALUES (:CONVERSI-NUM-PROPOSTA-SIVPF, :CONVERSI-NUM-SICOB , :CONVERSI-COD-EMPRESA-SIVPF , :CONVERSI-COD-PRODUTO-SIVPF , :CONVERSI-AGEPGTO , :CONVERSI-DATA-OPERACAO , :CONVERSI-DATA-QUITACAO , :CONVERSI-VAL-RCAP , :CONVERSI-COD-USUARIO , CURRENT_TIMESTAMP ) END-EXEC. */

            var r0556_00_INSERT_CONV_SICOB_DB_INSERT_1_Insert1 = new R0556_00_INSERT_CONV_SICOB_DB_INSERT_1_Insert1()
            {
                CONVERSI_NUM_PROPOSTA_SIVPF = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF.ToString(),
                CONVERSI_NUM_SICOB = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB.ToString(),
                CONVERSI_COD_EMPRESA_SIVPF = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_EMPRESA_SIVPF.ToString(),
                CONVERSI_COD_PRODUTO_SIVPF = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF.ToString(),
                CONVERSI_AGEPGTO = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_AGEPGTO.ToString(),
                CONVERSI_DATA_OPERACAO = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_DATA_OPERACAO.ToString(),
                CONVERSI_DATA_QUITACAO = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_DATA_QUITACAO.ToString(),
                CONVERSI_VAL_RCAP = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_VAL_RCAP.ToString(),
                CONVERSI_COD_USUARIO = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_USUARIO.ToString(),
            };

            R0556_00_INSERT_CONV_SICOB_DB_INSERT_1_Insert1.Execute(r0556_00_INSERT_CONV_SICOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0556_SAIDA*/

        [StopWatch]
        /*" R0557-00-INSERT-SOL-FATURA-SECTION */
        private void R0557_00_INSERT_SOL_FATURA_SECTION()
        {
            /*" -7505- MOVE 'R0557-00-INSERT-SOL-FATURA' TO PARAGRAFO. */
            _.Move("R0557-00-INSERT-SOL-FATURA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7506- MOVE 'INSERT SOLICITA FATURA    ' TO COMANDO. */
            _.Move("INSERT SOLICITA FATURA    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7508- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7532- PERFORM R0557_00_INSERT_SOL_FATURA_DB_INSERT_1 */

            R0557_00_INSERT_SOL_FATURA_DB_INSERT_1();

            /*" -7535- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -7536- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -7537- DISPLAY '          ERRO INSERT DA TABELA SOL FATURA' */
                _.Display($"          ERRO INSERT DA TABELA SOL FATURA");

                /*" -7539- DISPLAY '          NUM APOLICE...................  ' VGSOLFAT-NUM-APOLICE */
                _.Display($"          NUM APOLICE...................  {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE}");

                /*" -7541- DISPLAY '          COD SUBGRUPO..................  ' VGSOLFAT-COD-SUBGRUPO */
                _.Display($"          COD SUBGRUPO..................  {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO}");

                /*" -7543- DISPLAY '          VGSOLFAT-DATA-SOLICITACAO.....  ' VGSOLFAT-DATA-SOLICITACAO */
                _.Display($"          VGSOLFAT-DATA-SOLICITACAO.....  {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DATA_SOLICITACAO}");

                /*" -7545- DISPLAY '          VGSOLFAT-DTVENCTO-FATURA......  ' VGSOLFAT-DTVENCTO-FATURA */
                _.Display($"          VGSOLFAT-DTVENCTO-FATURA......  {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DTVENCTO_FATURA}");

                /*" -7547- DISPLAY '          VGSOLFAT-DT-QUITBCO-TITULO....  ' VGSOLFAT-DT-QUITBCO-TITULO */
                _.Display($"          VGSOLFAT-DT-QUITBCO-TITULO....  {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DT_QUITBCO_TITULO}");

                /*" -7549- DISPLAY '          VGSOLFAT-OPCAOPAG.............  ' VGSOLFAT-OPCAOPAG */
                _.Display($"          VGSOLFAT-OPCAOPAG.............  {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_OPCAOPAG}");

                /*" -7551- DISPLAY '          VGSOLFAT-SIT-SOLICITA.........  ' VGSOLFAT-SIT-SOLICITA */
                _.Display($"          VGSOLFAT-SIT-SOLICITA.........  {VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_SIT_SOLICITA}");

                /*" -7553- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -7555- DISPLAY '          SQLERRMC......................  ' SQLERRMC */
                _.Display($"          SQLERRMC......................  {DB.SQLERRMC}");

                /*" -7556- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -7558- END-IF. */
            }


            /*" -7558- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0557-00-INSERT-SOL-FATURA-DB-INSERT-1 */
        public void R0557_00_INSERT_SOL_FATURA_DB_INSERT_1()
        {
            /*" -7532- EXEC SQL INSERT INTO SEGUROS.VG_SOLICITA_FATURA VALUES (:VGSOLFAT-NUM-APOLICE , :VGSOLFAT-COD-SUBGRUPO , :VGSOLFAT-DATA-SOLICITACAO , :VGSOLFAT-DIA-DEBITO , :VGSOLFAT-OPCAOPAG , :VGSOLFAT-QUANT-VIDAS , :VGSOLFAT-CAP-BAS-SEGURADO , :VGSOLFAT-PRM-VG , :VGSOLFAT-PRM-AP , :VGSOLFAT-DTVENCTO-FATURA , :VGSOLFAT-COD-FONTE , :VGSOLFAT-NUM-TITULO , :VGSOLFAT-DT-QUITBCO-TITULO , :VGSOLFAT-VALOR-TITULO , :VGSOLFAT-SIT-SOLICITA , :VGSOLFAT-COD-USUARIO , CURRENT_TIMESTAMP , :VGSOLFAT-AGECTADEB , :VGSOLFAT-OPRCTADEB , :VGSOLFAT-NUMCTADEB , :VGSOLFAT-DIGCTADEB ) END-EXEC. */

            var r0557_00_INSERT_SOL_FATURA_DB_INSERT_1_Insert1 = new R0557_00_INSERT_SOL_FATURA_DB_INSERT_1_Insert1()
            {
                VGSOLFAT_NUM_APOLICE = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_APOLICE.ToString(),
                VGSOLFAT_COD_SUBGRUPO = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_SUBGRUPO.ToString(),
                VGSOLFAT_DATA_SOLICITACAO = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DATA_SOLICITACAO.ToString(),
                VGSOLFAT_DIA_DEBITO = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DIA_DEBITO.ToString(),
                VGSOLFAT_OPCAOPAG = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_OPCAOPAG.ToString(),
                VGSOLFAT_QUANT_VIDAS = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_QUANT_VIDAS.ToString(),
                VGSOLFAT_CAP_BAS_SEGURADO = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_CAP_BAS_SEGURADO.ToString(),
                VGSOLFAT_PRM_VG = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_VG.ToString(),
                VGSOLFAT_PRM_AP = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_PRM_AP.ToString(),
                VGSOLFAT_DTVENCTO_FATURA = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DTVENCTO_FATURA.ToString(),
                VGSOLFAT_COD_FONTE = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_FONTE.ToString(),
                VGSOLFAT_NUM_TITULO = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUM_TITULO.ToString(),
                VGSOLFAT_DT_QUITBCO_TITULO = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DT_QUITBCO_TITULO.ToString(),
                VGSOLFAT_VALOR_TITULO = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_VALOR_TITULO.ToString(),
                VGSOLFAT_SIT_SOLICITA = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_SIT_SOLICITA.ToString(),
                VGSOLFAT_COD_USUARIO = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_COD_USUARIO.ToString(),
                VGSOLFAT_AGECTADEB = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_AGECTADEB.ToString(),
                VGSOLFAT_OPRCTADEB = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_OPRCTADEB.ToString(),
                VGSOLFAT_NUMCTADEB = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_NUMCTADEB.ToString(),
                VGSOLFAT_DIGCTADEB = VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DIGCTADEB.ToString(),
            };

            R0557_00_INSERT_SOL_FATURA_DB_INSERT_1_Insert1.Execute(r0557_00_INSERT_SOL_FATURA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0557_SAIDA*/

        [StopWatch]
        /*" R0558-00-INSERT-CNTRLE-PROC-SECTION */
        private void R0558_00_INSERT_CNTRLE_PROC_SECTION()
        {
            /*" -7567- MOVE 'R0558-00-INSERT-CNTRLE-PRC' TO PARAGRAFO. */
            _.Move("R0558-00-INSERT-CNTRLE-PRC", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7568- MOVE 'INSERT PF_PROC_PROPOSTA   ' TO COMANDO. */
            _.Move("INSERT PF_PROC_PROPOSTA   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7570- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7586- PERFORM R0558_00_INSERT_CNTRLE_PROC_DB_INSERT_1 */

            R0558_00_INSERT_CNTRLE_PROC_DB_INSERT_1();

            /*" -7589- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -7590- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -7591- DISPLAY '          ERRO INSERT TAB. PF_PROC_PROPOSTA' */
                _.Display($"          ERRO INSERT TAB. PF_PROC_PROPOSTA");

                /*" -7593- DISPLAY '          SIGLA-ARQUIVO..........  ' PF087-SIGLA-ARQUIVO */
                _.Display($"          SIGLA-ARQUIVO..........  {PF087.DCLPF_PROC_PROPOSTA.PF087_SIGLA_ARQUIVO}");

                /*" -7595- DISPLAY '          SISTEMA-ORIGEM.........  ' PF087-SISTEMA-ORIGEM */
                _.Display($"          SISTEMA-ORIGEM.........  {PF087.DCLPF_PROC_PROPOSTA.PF087_SISTEMA_ORIGEM}");

                /*" -7597- DISPLAY '          NSAS-SIVPF.............  ' PF087-NSAS-SIVPF */
                _.Display($"          NSAS-SIVPF.............  {PF087.DCLPF_PROC_PROPOSTA.PF087_NSAS_SIVPF}");

                /*" -7599- DISPLAY '          NUM-PROPOSTA...........  ' PF087-NUM-PROPOSTA */
                _.Display($"          NUM-PROPOSTA...........  {PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_PROPOSTA}");

                /*" -7601- DISPLAY '          SEQ-OCORRENCIA.........  ' PF087-SEQ-OCORRENCIA */
                _.Display($"          SEQ-OCORRENCIA.........  {PF087.DCLPF_PROC_PROPOSTA.PF087_SEQ_OCORRENCIA}");

                /*" -7603- DISPLAY '          NUM-ERRO-PROPOSTA......  ' PF087-NUM-ERRO-PROPOSTA */
                _.Display($"          NUM-ERRO-PROPOSTA......  {PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_ERRO_PROPOSTA}");

                /*" -7605- DISPLAY '          NUM-DET-ARQ-PROPOSTA...  ' PF087-NUM-DET-ARQ-PROPOSTA */
                _.Display($"          NUM-DET-ARQ-PROPOSTA...  {PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_DET_ARQ_PROPOSTA}");

                /*" -7607- DISPLAY '          NUM-APOLICE-VINC.......  ' PF087-NUM-APOLICE-VINCULADA */
                _.Display($"          NUM-APOLICE-VINC.......  {PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_APOLICE_VINCULADA}");

                /*" -7609- DISPLAY '          SQLCODE................  ' SQLCODE */
                _.Display($"          SQLCODE................  {DB.SQLCODE}");

                /*" -7611- DISPLAY '          SQLERRMC...............  ' SQLERRMC */
                _.Display($"          SQLERRMC...............  {DB.SQLERRMC}");

                /*" -7612- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -7614- END-IF. */
            }


            /*" -7614- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R0558-00-INSERT-CNTRLE-PROC-DB-INSERT-1 */
        public void R0558_00_INSERT_CNTRLE_PROC_DB_INSERT_1()
        {
            /*" -7586- EXEC SQL INSERT INTO SEGUROS.PF_PROC_PROPOSTA VALUES (:PF087-SIGLA-ARQUIVO , :PF087-SISTEMA-ORIGEM , :PF087-NSAS-SIVPF , :PF087-NUM-PROPOSTA , :PF087-SEQ-OCORRENCIA , :PF087-NUM-DET-ARQ-PROPOSTA , :PF087-NUM-ERRO-PROPOSTA , :PF087-NUM-APOLICE-VINCULADA , :PF087-NUM-LINHA-ARQUIVO , :PF087-DES-CONTEUDO , :PF087-STA-PROCESSAMENTO , :PF087-COD-USUARIO , CURRENT_TIMESTAMP ) END-EXEC. */

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
            /*" -7623- MOVE 'R0559-00-INSERT-CNTRLE-HIST' TO PARAGRAFO. */
            _.Move("R0559-00-INSERT-CNTRLE-HIST", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7624- MOVE 'INSERT PF_PROC_PROPOSTA_HIST' TO COMANDO. */
            _.Move("INSERT PF_PROC_PROPOSTA_HIST", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7626- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7638- PERFORM R0559_00_INSERT_CNTRLE_HIST_DB_INSERT_1 */

            R0559_00_INSERT_CNTRLE_HIST_DB_INSERT_1();

            /*" -7641- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -7642- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -7643- DISPLAY '          ERRO INSERT TAB. PF_PROC_PROPOST_HIST' */
                _.Display($"          ERRO INSERT TAB. PF_PROC_PROPOST_HIST");

                /*" -7645- DISPLAY '          SIGLA-ARQUIVO..........  ' PF087-SIGLA-ARQUIVO */
                _.Display($"          SIGLA-ARQUIVO..........  {PF087.DCLPF_PROC_PROPOSTA.PF087_SIGLA_ARQUIVO}");

                /*" -7647- DISPLAY '          SISTEMA-ORIGEM.........  ' PF087-SISTEMA-ORIGEM */
                _.Display($"          SISTEMA-ORIGEM.........  {PF087.DCLPF_PROC_PROPOSTA.PF087_SISTEMA_ORIGEM}");

                /*" -7649- DISPLAY '          NSAS-SIVPF.............  ' PF087-NSAS-SIVPF */
                _.Display($"          NSAS-SIVPF.............  {PF087.DCLPF_PROC_PROPOSTA.PF087_NSAS_SIVPF}");

                /*" -7651- DISPLAY '          NUM-PROPOSTA...........  ' PF087-NUM-PROPOSTA */
                _.Display($"          NUM-PROPOSTA...........  {PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_PROPOSTA}");

                /*" -7653- DISPLAY '          SEQ-OCORRENCIA.........  ' PF087-SEQ-OCORRENCIA */
                _.Display($"          SEQ-OCORRENCIA.........  {PF087.DCLPF_PROC_PROPOSTA.PF087_SEQ_OCORRENCIA}");

                /*" -7655- DISPLAY '          SEQ-OCORR-HIST.........  ' PF090-SEQ-OCORR-HIST */
                _.Display($"          SEQ-OCORR-HIST.........  {PF090.DCLPF_PROC_PROPOSTA_HIST.PF090_SEQ_OCORR_HIST}");

                /*" -7657- DISPLAY '          STA-PROCESSAMENTO......  ' PF087-STA-PROCESSAMENTO */
                _.Display($"          STA-PROCESSAMENTO......  {PF087.DCLPF_PROC_PROPOSTA.PF087_STA_PROCESSAMENTO}");

                /*" -7659- DISPLAY '          PF087-COD-USUARIO......  ' PF087-COD-USUARIO */
                _.Display($"          PF087-COD-USUARIO......  {PF087.DCLPF_PROC_PROPOSTA.PF087_COD_USUARIO}");

                /*" -7661- DISPLAY '          SQLCODE................  ' SQLCODE */
                _.Display($"          SQLCODE................  {DB.SQLCODE}");

                /*" -7663- DISPLAY '          SQLERRMC...............  ' SQLERRMC */
                _.Display($"          SQLERRMC...............  {DB.SQLERRMC}");

                /*" -7664- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -7664- END-IF. */
            }


        }

        [StopWatch]
        /*" R0559-00-INSERT-CNTRLE-HIST-DB-INSERT-1 */
        public void R0559_00_INSERT_CNTRLE_HIST_DB_INSERT_1()
        {
            /*" -7638- EXEC SQL INSERT INTO SEGUROS.PF_PROC_PROPOSTA_HIST VALUES (:PF087-SIGLA-ARQUIVO , :PF087-SISTEMA-ORIGEM , :PF087-NSAS-SIVPF , :PF087-NUM-PROPOSTA , :PF087-SEQ-OCORRENCIA , :PF090-SEQ-OCORR-HIST , :PF087-STA-PROCESSAMENTO , :PF087-COD-USUARIO , CURRENT_TIMESTAMP ) END-EXEC. */

            var r0559_00_INSERT_CNTRLE_HIST_DB_INSERT_1_Insert1 = new R0559_00_INSERT_CNTRLE_HIST_DB_INSERT_1_Insert1()
            {
                PF087_SIGLA_ARQUIVO = PF087.DCLPF_PROC_PROPOSTA.PF087_SIGLA_ARQUIVO.ToString(),
                PF087_SISTEMA_ORIGEM = PF087.DCLPF_PROC_PROPOSTA.PF087_SISTEMA_ORIGEM.ToString(),
                PF087_NSAS_SIVPF = PF087.DCLPF_PROC_PROPOSTA.PF087_NSAS_SIVPF.ToString(),
                PF087_NUM_PROPOSTA = PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_PROPOSTA.ToString(),
                PF087_SEQ_OCORRENCIA = PF087.DCLPF_PROC_PROPOSTA.PF087_SEQ_OCORRENCIA.ToString(),
                PF090_SEQ_OCORR_HIST = PF090.DCLPF_PROC_PROPOSTA_HIST.PF090_SEQ_OCORR_HIST.ToString(),
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
            /*" -7675- MOVE 'R2060-00-ATUALIZAR-ARQSIVPF' TO PARAGRAFO. */
            _.Move("R2060-00-ATUALIZAR-ARQSIVPF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7676- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7678- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7687- PERFORM R2060_00_ATUALIZA_ARQSIVPF_DB_INSERT_1 */

            R2060_00_ATUALIZA_ARQSIVPF_DB_INSERT_1();

            /*" -7691- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL -803) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != -803))
            {

                /*" -7692- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -7693- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -7695- DISPLAY '          SIGLA DO ARQUIVO...............  ' ARQSIVPF-SIGLA-ARQUIVO */
                _.Display($"          SIGLA DO ARQUIVO...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -7697- DISPLAY '          ARQSIVPF-SISTEMA-ORIGEM........  ' ARQSIVPF-SISTEMA-ORIGEM */
                _.Display($"          ARQSIVPF-SISTEMA-ORIGEM........  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM}");

                /*" -7699- DISPLAY '          NSAS PORTAL....................  ' ARQSIVPF-NSAS-SIVPF */
                _.Display($"          NSAS PORTAL....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -7701- DISPLAY '          DATA GERACAO..................  ' ARQSIVPF-DATA-GERACAO */
                _.Display($"          DATA GERACAO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -7703- DISPLAY '          QTDE. REGISTROS...............  ' ARQSIVPF-QTDE-REG-GER */
                _.Display($"          QTDE. REGISTROS...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -7705- DISPLAY '          ARQSIVPF-DATA-PROCESSAMENTO...  ' ARQSIVPF-DATA-PROCESSAMENTO */
                _.Display($"          ARQSIVPF-DATA-PROCESSAMENTO...  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO}");

                /*" -7707- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -7709- DISPLAY '          SQLERRMC......................  ' SQLERRMC */
                _.Display($"          SQLERRMC......................  {DB.SQLERRMC}");

                /*" -7710- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -7712- END-IF. */
            }


            /*" -7712- ADD 1 TO WS-TOTAL-INSERT. */
            WAREA_AUXILIAR.WS_TOTAL_INSERT.Value = WAREA_AUXILIAR.WS_TOTAL_INSERT + 1;

        }

        [StopWatch]
        /*" R2060-00-ATUALIZA-ARQSIVPF-DB-INSERT-1 */
        public void R2060_00_ATUALIZA_ARQSIVPF_DB_INSERT_1()
        {
            /*" -7687- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:ARQSIVPF-SIGLA-ARQUIVO , :ARQSIVPF-SISTEMA-ORIGEM , :ARQSIVPF-NSAS-SIVPF , :ARQSIVPF-DATA-GERACAO , :ARQSIVPF-QTDE-REG-GER , :ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

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
            /*" -7720- MOVE 'R3000-00-GERAR-CNTRLE-PROC  ' TO PARAGRAFO. */
            _.Move("R3000-00-GERAR-CNTRLE-PROC  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7721- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7723- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7724- IF (W-TB-NUM-PROPOSTA(W-IND-2) NOT EQUAL PF087-NUM-PROPOSTA) */

            if ((AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_2].W_TB_NUM_PROPOSTA != PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_PROPOSTA))
            {

                /*" -7725- MOVE ZEROS TO PF087-SEQ-OCORRENCIA */
                _.Move(0, PF087.DCLPF_PROC_PROPOSTA.PF087_SEQ_OCORRENCIA);

                /*" -7727- END-IF */
            }


            /*" -7728- MOVE ARQSIVPF-SIGLA-ARQUIVO TO PF087-SIGLA-ARQUIVO */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO, PF087.DCLPF_PROC_PROPOSTA.PF087_SIGLA_ARQUIVO);

            /*" -7729- MOVE ARQSIVPF-SISTEMA-ORIGEM TO PF087-SISTEMA-ORIGEM */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM, PF087.DCLPF_PROC_PROPOSTA.PF087_SISTEMA_ORIGEM);

            /*" -7730- MOVE ARQSIVPF-NSAS-SIVPF TO PF087-NSAS-SIVPF */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, PF087.DCLPF_PROC_PROPOSTA.PF087_NSAS_SIVPF);

            /*" -7731- MOVE W-TB-NUM-PROPOSTA(W-IND-2) TO PF087-NUM-PROPOSTA */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_2].W_TB_NUM_PROPOSTA, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_PROPOSTA);

            /*" -7732- ADD 1 TO PF087-SEQ-OCORRENCIA */
            PF087.DCLPF_PROC_PROPOSTA.PF087_SEQ_OCORRENCIA.Value = PF087.DCLPF_PROC_PROPOSTA.PF087_SEQ_OCORRENCIA + 1;

            /*" -7733- MOVE W-TB-NUM-APOLICE(W-IND-2) TO PF087-NUM-APOLICE-VINCULADA */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_2].W_TB_NUM_APOLICE, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_APOLICE_VINCULADA);

            /*" -7734- MOVE W-TB-NUM-SUBGRUPO(W-IND-2) TO LC06-NUM-SUBGRUPO */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_2].W_TB_NUM_SUBGRUPO, LC00.LC06.LC06_NUM_SUBGRUPO);

            /*" -7735- MOVE W-TB-NUM-SEQ-REG(W-IND-2) TO LC06-NUM-SEQ-REG */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_2].W_TB_NUM_SEQ_REG, LC00.LC06.LC06_NUM_SEQ_REG);

            /*" -7736- MOVE W-TB-NUM-LIN-ARQ(W-IND-2) TO PF087-NUM-LINHA-ARQUIVO */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_2].W_TB_NUM_LIN_ARQ, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_LINHA_ARQUIVO);

            /*" -7737- MOVE W-TB-COD-ERRO(W-IND-2) TO PF087-NUM-ERRO-PROPOSTA */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_2].W_TB_COD_ERRO, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_ERRO_PROPOSTA);

            /*" -7738- MOVE W-TB-COD-CAMPO(W-IND-2) TO PF087-NUM-DET-ARQ-PROPOSTA */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_2].W_TB_COD_CAMPO, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_DET_ARQ_PROPOSTA);

            /*" -7739- MOVE 100 TO PF087-DES-CONTEUDO-LEN */
            _.Move(100, PF087.DCLPF_PROC_PROPOSTA.PF087_DES_CONTEUDO.PF087_DES_CONTEUDO_LEN);

            /*" -7748- MOVE W-TB-DES-CONTEUDO(W-IND-2) TO PF087-DES-CONTEUDO-TEXT */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_2].W_TB_DES_CONTEUDO, PF087.DCLPF_PROC_PROPOSTA.PF087_DES_CONTEUDO.PF087_DES_CONTEUDO_TEXT);

            /*" -7749- EVALUATE W-TB-TP-MENSAGEM(W-IND-2) */
            switch (AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_2].W_TB_TP_MENSAGEM.Value.Trim())
            {

                /*" -7750- WHEN 'SUCESSO' */
                case "SUCESSO":

                    /*" -7751- MOVE ZEROS TO PF087-NUM-APOLICE-VINCULADA */
                    _.Move(0, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_APOLICE_VINCULADA);

                    /*" -7752- MOVE 'P' TO PF087-STA-PROCESSAMENTO */
                    _.Move("P", PF087.DCLPF_PROC_PROPOSTA.PF087_STA_PROCESSAMENTO);

                    /*" -7753- WHEN 'ALERTA' */
                    break;
                case "ALERTA":

                    /*" -7754- MOVE 'A' TO PF087-STA-PROCESSAMENTO */
                    _.Move("A", PF087.DCLPF_PROC_PROPOSTA.PF087_STA_PROCESSAMENTO);

                    /*" -7756- WHEN OTHER */
                    break;
                default:

                    /*" -7757- MOVE 'E' TO PF087-STA-PROCESSAMENTO */
                    _.Move("E", PF087.DCLPF_PROC_PROPOSTA.PF087_STA_PROCESSAMENTO);

                    /*" -7759- END-EVALUATE */
                    break;
            }


            /*" -7760- MOVE 'VG2600B' TO PF087-COD-USUARIO */
            _.Move("VG2600B", PF087.DCLPF_PROC_PROPOSTA.PF087_COD_USUARIO);

            /*" -7762- MOVE 1 TO PF090-SEQ-OCORR-HIST */
            _.Move(1, PF090.DCLPF_PROC_PROPOSTA_HIST.PF090_SEQ_OCORR_HIST);

            /*" -7763- PERFORM R0558-00-INSERT-CNTRLE-PROC */

            R0558_00_INSERT_CNTRLE_PROC_SECTION();

            /*" -7765- PERFORM R0559-00-INSERT-CNTRLE-HIST */

            R0559_00_INSERT_CNTRLE_HIST_SECTION();

            /*" -7765- ADD 1 TO WS-CONT-CNTRLE-PROC. */
            WAREA_AUXILIAR.WS_CONT_CNTRLE_PROC.Value = WAREA_AUXILIAR.WS_CONT_CNTRLE_PROC + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_SAIDA*/

        [StopWatch]
        /*" R7000-JV1-BUSCA-RAMO-SECTION */
        private void R7000_JV1_BUSCA_RAMO_SECTION()
        {
            /*" -7775- MOVE 'R7000-JV1-BUSCA-RAMO   ' TO PARAGRAFO. */
            _.Move("R7000-JV1-BUSCA-RAMO   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7776- MOVE 'BUSCAR RAMO EMISSOR    ' TO COMANDO. */
            _.Move("BUSCAR RAMO EMISSOR    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7779- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7785- PERFORM R7000_JV1_BUSCA_RAMO_DB_SELECT_1 */

            R7000_JV1_BUSCA_RAMO_DB_SELECT_1();

            /*" -7788- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7789- DISPLAY 'R7000-JV1-BUSCA-RAMO  ..' */
                _.Display($"R7000-JV1-BUSCA-RAMO  ..");

                /*" -7790- DISPLAY 'PRODUTO - ' PRODUTO-COD-PRODUTO */
                _.Display($"PRODUTO - {PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO}");

                /*" -7791- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -7793- DISPLAY 'SQLERRMC - ' SQLERRMC */
                _.Display($"SQLERRMC - {DB.SQLERRMC}");

                /*" -7794- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -7794- END-IF. */
            }


        }

        [StopWatch]
        /*" R7000-JV1-BUSCA-RAMO-DB-SELECT-1 */
        public void R7000_JV1_BUSCA_RAMO_DB_SELECT_1()
        {
            /*" -7785- EXEC SQL SELECT RAMO_EMISSOR INTO :PRODUTO-RAMO-EMISSOR FROM SEGUROS.PRODUTO WHERE COD_PRODUTO = :PRODUTO-COD-PRODUTO WITH UR END-EXEC. */

            var r7000_JV1_BUSCA_RAMO_DB_SELECT_1_Query1 = new R7000_JV1_BUSCA_RAMO_DB_SELECT_1_Query1()
            {
                PRODUTO_COD_PRODUTO = PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO.ToString(),
            };

            var executed_1 = R7000_JV1_BUSCA_RAMO_DB_SELECT_1_Query1.Execute(r7000_JV1_BUSCA_RAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_RAMO_EMISSOR, PRODUTO.DCLPRODUTO.PRODUTO_RAMO_EMISSOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/

        [StopWatch]
        /*" R7400-PROCURA-AVALIACAO-RISCO-SECTION */
        private void R7400_PROCURA_AVALIACAO_RISCO_SECTION()
        {
            /*" -7806- MOVE 'R7400-PROCURA-AVALIACAO-RISCO' TO PARAGRAFO. */
            _.Move("R7400-PROCURA-AVALIACAO-RISCO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7807- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7808- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7810- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7811- MOVE 'NAO' TO WS-ENCONTROU-RISCO */
            _.Move("NAO", WS_ENCONTROU_RISCO);

            /*" -7812- MOVE 'N' TO LK-VG009-E-TRACE */
            _.Move("N", SPVG009W.LK_VG009_E_TRACE);

            /*" -7814- MOVE 'VG2600B' TO LK-VG009-E-COD-USUARIO LK-VG009-E-NOM-PROGRAMA */
            _.Move("VG2600B", SPVG009W.LK_VG009_E_COD_USUARIO, SPVG009W.LK_VG009_E_NOM_PROGRAMA);

            /*" -7815- MOVE 01 TO LK-VG009-E-TIPO-ACAO */
            _.Move(01, SPVG009W.LK_VG009_E_TIPO_ACAO);

            /*" -7817- MOVE CONVERSI-NUM-PROPOSTA-SIVPF TO LK-VG009-E-NUM-PROPOSTA */
            _.Move(CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF, SPVG009W.LK_VG009_E_NUM_PROPOSTA);

            /*" -7818- MOVE 0 TO LK-VG009-IND-ERRO */
            _.Move(0, SPVG009W.LK_VG009_IND_ERRO);

            /*" -7820- MOVE SPACES TO LK-VG009-MSG-ERRO LK-VG009-NOM-TABELA */
            _.Move("", SPVG009W.LK_VG009_MSG_ERRO, SPVG009W.LK_VG009_NOM_TABELA);

            /*" -7821- MOVE 0 TO LK-VG009-SQLCODE */
            _.Move(0, SPVG009W.LK_VG009_SQLCODE);

            /*" -7823- MOVE SPACES TO LK-VG009-SQLERRMC */
            _.Move("", SPVG009W.LK_VG009_SQLERRMC);

            /*" -7825- MOVE 'SPBVG009' TO WS-PROGRAMA */
            _.Move("SPBVG009", WS_PROGRAMA);

            /*" -7846- CALL WS-PROGRAMA USING LK-VG009-E-TRACE LK-VG009-E-COD-USUARIO LK-VG009-E-NOM-PROGRAMA LK-VG009-E-TIPO-ACAO LK-VG009-E-NUM-PROPOSTA LK-VG009-S-COD-PESSOA LK-VG009-S-SEQ-PESSOA-HIST LK-VG009-S-COD-CLASSIF-RISCO LK-VG009-S-NUM-SCORE-RISCO LK-VG009-S-DTA-CLASSIF-RISCO LK-VG009-S-IND-PEND-APROVACAO LK-VG009-S-IND-DECL-AUTOMATICO LK-VG009-S-IND-ATLZ-FXA-RISCO LK-VG009-IND-ERRO LK-VG009-MSG-ERRO LK-VG009-NOM-TABELA LK-VG009-SQLCODE LK-VG009-SQLERRMC */
            _.Call(WS_PROGRAMA, SPVG009W);

            /*" -7847- IF LK-VG009-IND-ERRO EQUAL ZEROS */

            if (SPVG009W.LK_VG009_IND_ERRO == 00)
            {

                /*" -7848- MOVE 'SIM' TO WS-ENCONTROU-RISCO */
                _.Move("SIM", WS_ENCONTROU_RISCO);

                /*" -7849- ELSE */
            }
            else
            {


                /*" -7851- IF LK-VG009-IND-ERRO EQUAL 1 AND LK-VG009-SQLCODE EQUAL +100 */

                if (SPVG009W.LK_VG009_IND_ERRO == 1 && SPVG009W.LK_VG009_SQLCODE == +100)
                {

                    /*" -7852- MOVE 'NAO' TO WS-ENCONTROU-RISCO */
                    _.Move("NAO", WS_ENCONTROU_RISCO);

                    /*" -7853- ELSE */
                }
                else
                {


                    /*" -7854- DISPLAY 'VG2600B - FIM ANORMAL' */
                    _.Display($"VG2600B - FIM ANORMAL");

                    /*" -7856- DISPLAY 'ERRO NA CHAMADA SPBVG009 ' LK-VG009-IND-ERRO */
                    _.Display($"ERRO NA CHAMADA SPBVG009 {SPVG009W.LK_VG009_IND_ERRO}");

                    /*" -7857- DISPLAY 'NUMERO PROPOSTA..: ' LK-VG009-E-NUM-PROPOSTA */
                    _.Display($"NUMERO PROPOSTA..: {SPVG009W.LK_VG009_E_NUM_PROPOSTA}");

                    /*" -7858- DISPLAY 'NOME TABELA......: ' LK-VG009-NOM-TABELA */
                    _.Display($"NOME TABELA......: {SPVG009W.LK_VG009_NOM_TABELA}");

                    /*" -7859- DISPLAY 'SQLCODE..........: ' LK-VG009-SQLCODE */
                    _.Display($"SQLCODE..........: {SPVG009W.LK_VG009_SQLCODE}");

                    /*" -7860- DISPLAY 'SQLERRMC.........: ' LK-VG009-SQLERRMC */
                    _.Display($"SQLERRMC.........: {SPVG009W.LK_VG009_SQLERRMC}");

                    /*" -7862- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -7863- GO TO R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;

                    /*" -7864- END-IF */
                }


                /*" -7865- END-IF */
            }


            /*" -7865- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7400_99_EXIT*/

        [StopWatch]
        /*" R8001-00-VERIFICA-DATA-VALIDA-SECTION */
        private void R8001_00_VERIFICA_DATA_VALIDA_SECTION()
        {
            /*" -7874- MOVE 'R8001-00-VERIFICA-DATA-VALIDA' TO PARAGRAFO. */
            _.Move("R8001-00-VERIFICA-DATA-VALIDA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7875- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7877- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7878- MOVE W-DIA-TRABALHO TO W-DIA-SQL */
            _.Move(WAREA_AUXILIAR.FILLER_27.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -7879- MOVE W-MES-TRABALHO TO W-MES-SQL */
            _.Move(WAREA_AUXILIAR.FILLER_27.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -7881- MOVE W-ANO-TRABALHO TO W-ANO-SQL */
            _.Move(WAREA_AUXILIAR.FILLER_27.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -7884- MOVE '-' TO W-BARRA1-SQL W-BARRA2-SQL */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_SQL);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_SQL);


            /*" -7886- PERFORM R8001_00_VERIFICA_DATA_VALIDA_DB_SET_1 */

            R8001_00_VERIFICA_DATA_VALIDA_DB_SET_1();

        }

        [StopWatch]
        /*" R8001-00-VERIFICA-DATA-VALIDA-DB-SET-1 */
        public void R8001_00_VERIFICA_DATA_VALIDA_DB_SET_1()
        {
            /*" -7886- EXEC SQL SET :W-DATA-SQL = DATE(:W-DATA-SQL) END-EXEC. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL.ToDateTime(), WAREA_AUXILIAR.W_DATA_SQL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8001_99_SAIDA*/

        [StopWatch]
        /*" R8002-00-VERIFICA-FONTES-SECTION */
        private void R8002_00_VERIFICA_FONTES_SECTION()
        {
            /*" -7894- MOVE 'R8002-00-VERIFICA-FONTES ' TO PARAGRAFO. */
            _.Move("R8002-00-VERIFICA-FONTES ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7895- MOVE 'SELECT FONTE' TO COMANDO. */
            _.Move("SELECT FONTE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7899- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7902- IF WS-JV1-DTA-PROPOSTA NOT < LK-GEJVW002-JV-DTA-INI AND R1-COD-PRODUTO = JVPRD9311 OR JVPRD8203 */

            if (WS_JV1_DTA_PROPOSTA! < GEJVW002.LK_GEJVW002_JV_DTA_INI && REG_R1_SUBGRUPO.R1_COD_PRODUTO.In(JVBKINCL.JV_PRODUTOS.JVPRD9311.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8203.ToString()))
            {

                /*" -7903- MOVE 300 TO FONTES-COD-FONTE */
                _.Move(300, FONTES.DCLFONTES.FONTES_COD_FONTE);

                /*" -7906- END-IF. */
            }


            /*" -7910- INITIALIZE FONTES-TIPO-FONTE FONTES-ORGAO-EMISSOR FONTES-ULT-PROP-AUTOMAT */
            _.Initialize(
                FONTES.DCLFONTES.FONTES_TIPO_FONTE
                , FONTES.DCLFONTES.FONTES_ORGAO_EMISSOR
                , FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT
            );

            /*" -7919- PERFORM R8002_00_VERIFICA_FONTES_DB_SELECT_1 */

            R8002_00_VERIFICA_FONTES_DB_SELECT_1();

            /*" -7922- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -7923- DISPLAY 'R8002 - PROBLEMAS SELECT SEGUROS.FONTES.' */
                _.Display($"R8002 - PROBLEMAS SELECT SEGUROS.FONTES.");

                /*" -7924- DISPLAY 'FONTES-COD-FONTE=' FONTES-COD-FONTE */
                _.Display($"FONTES-COD-FONTE={FONTES.DCLFONTES.FONTES_COD_FONTE}");

                /*" -7925- DISPLAY 'WH-QTD-ULT-PROP =' WH-QTD-ULT-PROP */
                _.Display($"WH-QTD-ULT-PROP ={WH_QTD_ULT_PROP}");

                /*" -7926- DISPLAY 'SQLCODE         =' SQLCODE */
                _.Display($"SQLCODE         ={DB.SQLCODE}");

                /*" -7927- DISPLAY 'SQLERRMC        =' SQLERRMC */
                _.Display($"SQLERRMC        ={DB.SQLERRMC}");

                /*" -7928- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -7930- END-IF. */
            }


            /*" -7935- DISPLAY 'R8002-ACESSOU SEGUROS.FONTES:' ' SQLCODE=' SQLCODE ' TIPO-FONTE=' FONTES-TIPO-FONTE ' COD-FONTE=' FONTES-COD-FONTE ' ULT-PROP-AUTOMAT=' FONTES-ULT-PROP-AUTOMAT ' WH-QTD-ULT-PROP=' WH-QTD-ULT-PROP . */

            $"R8002-ACESSOU SEGUROS.FONTES: SQLCODE={DB.SQLCODE} TIPO-FONTE={FONTES.DCLFONTES.FONTES_TIPO_FONTE} COD-FONTE={FONTES.DCLFONTES.FONTES_COD_FONTE} ULT-PROP-AUTOMAT={FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT} WH-QTD-ULT-PROP={WH_QTD_ULT_PROP}"
            .Display();

        }

        [StopWatch]
        /*" R8002-00-VERIFICA-FONTES-DB-SELECT-1 */
        public void R8002_00_VERIFICA_FONTES_DB_SELECT_1()
        {
            /*" -7919- EXEC SQL SELECT TIPO_FONTE, ORGAO_EMISSOR, IFNULL(ULT_PROP_AUTOMAT, 0) + :WH-QTD-ULT-PROP INTO :FONTES-TIPO-FONTE, :FONTES-ORGAO-EMISSOR, :FONTES-ULT-PROP-AUTOMAT FROM SEGUROS.FONTES WHERE COD_FONTE = :FONTES-COD-FONTE END-EXEC. */

            var r8002_00_VERIFICA_FONTES_DB_SELECT_1_Query1 = new R8002_00_VERIFICA_FONTES_DB_SELECT_1_Query1()
            {
                FONTES_COD_FONTE = FONTES.DCLFONTES.FONTES_COD_FONTE.ToString(),
                WH_QTD_ULT_PROP = WH_QTD_ULT_PROP.ToString(),
            };

            var executed_1 = R8002_00_VERIFICA_FONTES_DB_SELECT_1_Query1.Execute(r8002_00_VERIFICA_FONTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_TIPO_FONTE, FONTES.DCLFONTES.FONTES_TIPO_FONTE);
                _.Move(executed_1.FONTES_ORGAO_EMISSOR, FONTES.DCLFONTES.FONTES_ORGAO_EMISSOR);
                _.Move(executed_1.FONTES_ULT_PROP_AUTOMAT, FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8002_99_SAIDA*/

        [StopWatch]
        /*" R8003-00-VERIFICA-AGENCIACEF-SECTION */
        private void R8003_00_VERIFICA_AGENCIACEF_SECTION()
        {
            /*" -7944- MOVE 'R8003-00-VERIFICA-AGENCIACEF' TO PARAGRAFO. */
            _.Move("R8003-00-VERIFICA-AGENCIACEF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7945- MOVE 'SELECT AGENCIA CEF' TO COMANDO. */
            _.Move("SELECT AGENCIA CEF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7947- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7953- PERFORM R8003_00_VERIFICA_AGENCIACEF_DB_SELECT_1 */

            R8003_00_VERIFICA_AGENCIACEF_DB_SELECT_1();

            /*" -7956- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -7957- DISPLAY 'R8003 - PROBLEMAS SELECT SEGUROS.AGENCIAS_CEF.' */
                _.Display($"R8003 - PROBLEMAS SELECT SEGUROS.AGENCIAS_CEF.");

                /*" -7958- DISPLAY 'COD-AGENCIA-CEF = ' COD-AGENCIA-CEF */
                _.Display($"COD-AGENCIA-CEF = {COD_AGENCIA_CEF}");

                /*" -7959- DISPLAY 'SQLCODE         = ' SQLCODE */
                _.Display($"SQLCODE         = {DB.SQLCODE}");

                /*" -7960- DISPLAY 'SQLERRMC        = ' SQLERRMC */
                _.Display($"SQLERRMC        = {DB.SQLERRMC}");

                /*" -7961- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -7961- END-IF. */
            }


        }

        [StopWatch]
        /*" R8003-00-VERIFICA-AGENCIACEF-DB-SELECT-1 */
        public void R8003_00_VERIFICA_AGENCIACEF_DB_SELECT_1()
        {
            /*" -7953- EXEC SQL SELECT COD_AGENCIA INTO :COD-AGENCIA-CEF FROM SEGUROS.AGENCIAS_CEF WHERE COD_AGENCIA = :COD-AGENCIA-CEF WITH UR END-EXEC. */

            var r8003_00_VERIFICA_AGENCIACEF_DB_SELECT_1_Query1 = new R8003_00_VERIFICA_AGENCIACEF_DB_SELECT_1_Query1()
            {
                COD_AGENCIA_CEF = COD_AGENCIA_CEF.ToString(),
            };

            var executed_1 = R8003_00_VERIFICA_AGENCIACEF_DB_SELECT_1_Query1.Execute(r8003_00_VERIFICA_AGENCIACEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_AGENCIA_CEF, COD_AGENCIA_CEF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8003_99_SAIDA*/

        [StopWatch]
        /*" R8004-00-VERIFICA-DV-CONTA-SECTION */
        private void R8004_00_VERIFICA_DV_CONTA_SECTION()
        {
            /*" -7969- MOVE 'R8004-00-VERIFICA-DV-CONTA' TO PARAGRAFO. */
            _.Move("R8004-00-VERIFICA-DV-CONTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7970- MOVE 'VERIFICA DV CONTA ' TO COMANDO. */
            _.Move("VERIFICA DV CONTA ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7972- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7975- MOVE WS-NUM-AGEN-OPER-CC TO LPARM15. */
            _.Move(WS_NUM_AGEN_OPER_CC, LPARM15X.LPARM15);

            /*" -7976- DISPLAY 'RAPHA - WS-NUM-AGEN-OPER-CC = ' WS-NUM-AGEN-OPER-CC */
            _.Display($"RAPHA - WS-NUM-AGEN-OPER-CC = {WS_NUM_AGEN_OPER_CC}");

            /*" -7992- COMPUTE WPARM15-AUX = LPARM15-1 * 8 + LPARM15-2 * 7 + LPARM15-3 * 6 + LPARM15-4 * 5 + LPARM15-5 * 4 + LPARM15-6 * 3 + LPARM15-7 * 2 + LPARM15-8 * 9 + LPARM15-9 * 8 + LPARM15-10 * 7 + LPARM15-11 * 6 + LPARM15-12 * 5 + LPARM15-13 * 4 + LPARM15-14 * 3 + LPARM15-15 * 2 */
            WPARM15_AUX.Value = LPARM15X.FILLER_22.LPARM15_1 * 8 + LPARM15X.FILLER_22.LPARM15_2 * 7 + LPARM15X.FILLER_22.LPARM15_3 * 6 + LPARM15X.FILLER_22.LPARM15_4 * 5 + LPARM15X.FILLER_22.LPARM15_5 * 4 + LPARM15X.FILLER_22.LPARM15_6 * 3 + LPARM15X.FILLER_22.LPARM15_7 * 2 + LPARM15X.FILLER_22.LPARM15_8 * 9 + LPARM15X.FILLER_22.LPARM15_9 * 8 + LPARM15X.FILLER_22.LPARM15_10 * 7 + LPARM15X.FILLER_22.LPARM15_11 * 6 + LPARM15X.FILLER_22.LPARM15_12 * 5 + LPARM15X.FILLER_22.LPARM15_13 * 4 + LPARM15X.FILLER_22.LPARM15_14 * 3 + LPARM15X.FILLER_22.LPARM15_15 * 2;

            /*" -7994- DIVIDE WPARM15-AUX BY 11 GIVING WQUOCIENTE REMAINDER WRESTO. */
            _.Divide(WPARM15_AUX, 11, WQUOCIENTE, WRESTO);

            /*" -7995- DISPLAY 'RAPHA - WPARM15-AUX = ' WPARM15-AUX */
            _.Display($"RAPHA - WPARM15-AUX = {WPARM15_AUX}");

            /*" -7996- DISPLAY 'RAPHA - WQUOCIENTE  = ' WQUOCIENTE */
            _.Display($"RAPHA - WQUOCIENTE  = {WQUOCIENTE}");

            /*" -7998- DISPLAY 'RAPHA - WRESTO      = ' WRESTO */
            _.Display($"RAPHA - WRESTO      = {WRESTO}");

            /*" -7999- IF (WRESTO EQUAL ZEROS) */

            if ((WRESTO == 00))
            {

                /*" -8000- MOVE ZEROS TO LPARM15-D1 */
                _.Move(0, LPARM15X.LPARM15_D1);

                /*" -8001- ELSE */
            }
            else
            {


                /*" -8003- SUBTRACT WRESTO FROM 11 GIVING LPARM15-D1 */
                LPARM15X.LPARM15_D1.Value = 11 - WRESTO;

                /*" -8005- END-IF. */
            }


            /*" -8005- MOVE LPARM15-D1 TO WS-DIGCONTA. */
            _.Move(LPARM15X.LPARM15_D1, WS_DIGCONTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8004_99_SAIDA*/

        [StopWatch]
        /*" R8005-00-VALIDA-CNPJ-SECTION */
        private void R8005_00_VALIDA_CNPJ_SECTION()
        {
            /*" -8015- MOVE 'R8005-00-VALIDA-CNPJ' TO PARAGRAFO. */
            _.Move("R8005-00-VALIDA-CNPJ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8016- MOVE 'VALIDA CNPJ ' TO COMANDO. */
            _.Move("VALIDA CNPJ ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8018- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8020- MOVE 'PROCNPJ2' TO WS-CALL */
            _.Move("PROCNPJ2", WS_CALL);

            /*" -8020- CALL WS-CALL USING LPARM-CNPJ. */
            _.Call(WS_CALL, LPARM_CNPJ);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8005_99_SAIDA*/

        [StopWatch]
        /*" R8006-00-PESQUISA-APOL-ATIVA-SECTION */
        private void R8006_00_PESQUISA_APOL_ATIVA_SECTION()
        {
            /*" -8029- MOVE 'R8006-00-PESQUISA-APOL-ATIVA' TO PARAGRAFO. */
            _.Move("R8006-00-PESQUISA-APOL-ATIVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8030- MOVE 'SELECT APOLICE ATIVA' TO COMANDO. */
            _.Move("SELECT APOLICE ATIVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8032- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8034- INITIALIZE APOLICES-NUM-APOLICE */
            _.Initialize(
                APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE
            );

            /*" -8048- PERFORM R8006_00_PESQUISA_APOL_ATIVA_DB_SELECT_1 */

            R8006_00_PESQUISA_APOL_ATIVA_DB_SELECT_1();

            /*" -8051- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -8052- DISPLAY 'R8006 -PROBLEMAS SELECT CLIENTES X PROPOSTAS_VA' */
                _.Display($"R8006 -PROBLEMAS SELECT CLIENTES X PROPOSTAS_VA");

                /*" -8053- DISPLAY 'CGCCPF    = ' CLIENTES-CGCCPF */
                _.Display($"CGCCPF    = {CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF}");

                /*" -8054- DISPLAY 'JVPRD8203 = ' JVPRD8203 */
                _.Display($"JVPRD8203 = {JVBKINCL.JV_PRODUTOS.JVPRD8203}");

                /*" -8056- DISPLAY 'JVPRD9311 = ' JVPRD9311 */
                _.Display($"JVPRD9311 = {JVBKINCL.JV_PRODUTOS.JVPRD9311}");

                /*" -8057- DISPLAY 'SQLCODE   = ' SQLCODE */
                _.Display($"SQLCODE   = {DB.SQLCODE}");

                /*" -8058- DISPLAY 'SQLERRMC  = ' SQLERRMC */
                _.Display($"SQLERRMC  = {DB.SQLERRMC}");

                /*" -8059- IF SQLCODE NOT = +100 */

                if (DB.SQLCODE != +100)
                {

                    /*" -8060- GO TO R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;

                    /*" -8061- END-IF */
                }


                /*" -8061- END-IF. */
            }


        }

        [StopWatch]
        /*" R8006-00-PESQUISA-APOL-ATIVA-DB-SELECT-1 */
        public void R8006_00_PESQUISA_APOL_ATIVA_DB_SELECT_1()
        {
            /*" -8048- EXEC SQL SELECT VALUE(MAX(B.NUM_APOLICE), 0) INTO :APOLICES-NUM-APOLICE FROM SEGUROS.CLIENTES A, SEGUROS.PROPOSTAS_VA B WHERE A.CGCCPF = :CLIENTES-CGCCPF AND B.COD_CLIENTE = A.COD_CLIENTE AND ((B.COD_PRODUTO IN (9311,9354,8203) AND B.NUM_APOLICE < 3000000000000) OR (B.COD_PRODUTO IN (:JVPRD9311, :JVPRD8203) AND B.NUM_APOLICE > 3000000000000)) AND B.SIT_REGISTRO NOT IN ( '2' , '4' ) WITH UR END-EXEC. */

            var r8006_00_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1 = new R8006_00_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1()
            {
                CLIENTES_CGCCPF = CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF.ToString(),
                JVPRD9311 = JVBKINCL.JV_PRODUTOS.JVPRD9311.ToString(),
                JVPRD8203 = JVBKINCL.JV_PRODUTOS.JVPRD8203.ToString(),
            };

            var executed_1 = R8006_00_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1.Execute(r8006_00_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8006_99_SAIDA*/

        [StopWatch]
        /*" R8006-01-PESQUISA-APOL-ATIVA-SECTION */
        private void R8006_01_PESQUISA_APOL_ATIVA_SECTION()
        {
            /*" -8069- MOVE 'R8006-01-PESQUISA-APOL-ATIVA' TO PARAGRAFO. */
            _.Move("R8006-01-PESQUISA-APOL-ATIVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8070- MOVE 'SELECT APOLICE ATIVA' TO COMANDO. */
            _.Move("SELECT APOLICE ATIVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8072- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8074- INITIALIZE APOLICES-NUM-APOLICE */
            _.Initialize(
                APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE
            );

            /*" -8083- PERFORM R8006_01_PESQUISA_APOL_ATIVA_DB_SELECT_1 */

            R8006_01_PESQUISA_APOL_ATIVA_DB_SELECT_1();

            /*" -8086- IF SQLCODE NOT EQUAL ZEROS AND +100 */

            if (!DB.SQLCODE.In("00", "+100"))
            {

                /*" -8087- DISPLAY 'R8006-01-PROBLEMAS SELECT PROPOSTAS_VA' */
                _.Display($"R8006-01-PROBLEMAS SELECT PROPOSTAS_VA");

                /*" -8088- DISPLAY 'APOLICE   = ' WHOST-NUM-APOLICE */
                _.Display($"APOLICE   = {WHOST_NUM_APOLICE}");

                /*" -8089- DISPLAY 'SUBGRUPO  = ' WHOST-COD-SUBGRUPO */
                _.Display($"SUBGRUPO  = {WHOST_COD_SUBGRUPO}");

                /*" -8090- DISPLAY 'JVPRD8203 = ' JVPRD8203 */
                _.Display($"JVPRD8203 = {JVBKINCL.JV_PRODUTOS.JVPRD8203}");

                /*" -8091- DISPLAY 'JVPRD9311 = ' JVPRD9311 */
                _.Display($"JVPRD9311 = {JVBKINCL.JV_PRODUTOS.JVPRD9311}");

                /*" -8092- DISPLAY 'SQLCODE   = ' SQLCODE */
                _.Display($"SQLCODE   = {DB.SQLCODE}");

                /*" -8093- DISPLAY 'SQLERRMC  = ' SQLERRMC */
                _.Display($"SQLERRMC  = {DB.SQLERRMC}");

                /*" -8094- IF SQLCODE NOT = +100 */

                if (DB.SQLCODE != +100)
                {

                    /*" -8095- GO TO R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;

                    /*" -8096- END-IF */
                }


                /*" -8096- END-IF. */
            }


        }

        [StopWatch]
        /*" R8006-01-PESQUISA-APOL-ATIVA-DB-SELECT-1 */
        public void R8006_01_PESQUISA_APOL_ATIVA_DB_SELECT_1()
        {
            /*" -8083- EXEC SQL SELECT NUM_APOLICE INTO :APOLICES-NUM-APOLICE FROM SEGUROS.PROPOSTAS_VA B WHERE NUM_APOLICE = :WHOST-NUM-APOLICE AND COD_SUBGRUPO = :WHOST-COD-SUBGRUPO AND SIT_REGISTRO IN ( '3' , '6' ) AND DTPROXVEN <> '9999-12-31' WITH UR END-EXEC. */

            var r8006_01_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1 = new R8006_01_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1()
            {
                WHOST_COD_SUBGRUPO = WHOST_COD_SUBGRUPO.ToString(),
                WHOST_NUM_APOLICE = WHOST_NUM_APOLICE.ToString(),
            };

            var executed_1 = R8006_01_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1.Execute(r8006_01_PESQUISA_APOL_ATIVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8006_199_SAIDA*/

        [StopWatch]
        /*" R8007-00-GERAR-MAX-APOLICE-SECTION */
        private void R8007_00_GERAR_MAX_APOLICE_SECTION()
        {
            /*" -8104- MOVE 'R8007-00-GERAR-NOVA-APOLICE' TO PARAGRAFO. */
            _.Move("R8007-00-GERAR-NOVA-APOLICE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8105- MOVE 'SELECT APOLICE ' TO COMANDO. */
            _.Move("SELECT APOLICE ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8107- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8113- PERFORM R8007_00_GERAR_MAX_APOLICE_DB_SELECT_1 */

            R8007_00_GERAR_MAX_APOLICE_DB_SELECT_1();

            /*" -8116- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -8117- DISPLAY 'R8007 - PROBLEMAS SELECT SEGUROS.NUMERO_AES.' */
                _.Display($"R8007 - PROBLEMAS SELECT SEGUROS.NUMERO_AES.");

                /*" -8118- DISPLAY 'FONTES-ORGAO-EMISSOR = ' FONTES-ORGAO-EMISSOR */
                _.Display($"FONTES-ORGAO-EMISSOR = {FONTES.DCLFONTES.FONTES_ORGAO_EMISSOR}");

                /*" -8119- DISPLAY 'RAMOCOMP-RAMO-EMISSOR= ' RAMOCOMP-RAMO-EMISSOR */
                _.Display($"RAMOCOMP-RAMO-EMISSOR= {RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR}");

                /*" -8120- DISPLAY 'SQLCODE              = ' SQLCODE */
                _.Display($"SQLCODE              = {DB.SQLCODE}");

                /*" -8121- DISPLAY 'SQLERRMC             = ' SQLERRMC */
                _.Display($"SQLERRMC             = {DB.SQLERRMC}");

                /*" -8122- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8127- END-IF. */
            }


            /*" -8128- IF FONTES-ORGAO-EMISSOR = 300 */

            if (FONTES.DCLFONTES.FONTES_ORGAO_EMISSOR == 300)
            {

                /*" -8129- MOVE FONTES-ORGAO-EMISSOR TO WH-NUM-VIDA */
                _.Move(FONTES.DCLFONTES.FONTES_ORGAO_EMISSOR, FILLER_19.WH_NUM_VIDA);

                /*" -8130- ELSE */
            }
            else
            {


                /*" -8131- MOVE 010 TO WH-NUM-VIDA */
                _.Move(010, FILLER_19.WH_NUM_VIDA);

                /*" -8133- END-IF. */
            }


            /*" -8134- MOVE RAMOCOMP-RAMO-EMISSOR TO WH-NUM-RAMO */
            _.Move(RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR, FILLER_19.WH_NUM_RAMO);

            /*" -8136- MOVE APOLICES-NUM-APOLICE TO WH-NUM-SEQUENCIAL */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE, FILLER_19.WH_NUM_SEQUENCIAL);

            /*" -8141- PERFORM R8007_00_GERAR_MAX_APOLICE_DB_UPDATE_1 */

            R8007_00_GERAR_MAX_APOLICE_DB_UPDATE_1();

            /*" -8144- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -8145- DISPLAY 'R8007 - PROBLEMAS UPDATE (APOLICES) ..  ' */
                _.Display($"R8007 - PROBLEMAS UPDATE (APOLICES) ..  ");

                /*" -8146- DISPLAY 'R8007 - PROBLEMAS SELECT SEGUROS.NUMERO_AES.' */
                _.Display($"R8007 - PROBLEMAS SELECT SEGUROS.NUMERO_AES.");

                /*" -8147- DISPLAY 'FONTES-ORGAO-EMISSOR  = ' FONTES-ORGAO-EMISSOR */
                _.Display($"FONTES-ORGAO-EMISSOR  = {FONTES.DCLFONTES.FONTES_ORGAO_EMISSOR}");

                /*" -8148- DISPLAY 'RAMOCOMP-RAMO-EMISSOR = ' RAMOCOMP-RAMO-EMISSOR */
                _.Display($"RAMOCOMP-RAMO-EMISSOR = {RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR}");

                /*" -8149- DISPLAY 'APOLICES-NUM-APOLICE  = ' APOLICES-NUM-APOLICE */
                _.Display($"APOLICES-NUM-APOLICE  = {APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE}");

                /*" -8150- DISPLAY 'SQLCODE               = ' SQLCODE */
                _.Display($"SQLCODE               = {DB.SQLCODE}");

                /*" -8151- DISPLAY 'SQLERRMC              = ' SQLERRMC */
                _.Display($"SQLERRMC              = {DB.SQLERRMC}");

                /*" -8152- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8154- END-IF. */
            }


            /*" -8155- MOVE WH-APOLICE TO APOLICES-NUM-APOLICE */
            _.Move(WH_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

            /*" -8155- MOVE WH-APOLICE TO WS-NUM-APOLICE. */
            _.Move(WH_APOLICE, WS_NUM_APOLICE);

        }

        [StopWatch]
        /*" R8007-00-GERAR-MAX-APOLICE-DB-SELECT-1 */
        public void R8007_00_GERAR_MAX_APOLICE_DB_SELECT_1()
        {
            /*" -8113- EXEC SQL SELECT MAX(SEQ_APOLICE) + 1 INTO :APOLICES-NUM-APOLICE FROM SEGUROS.NUMERO_AES WHERE ORGAO_EMISSOR = :FONTES-ORGAO-EMISSOR AND RAMO_EMISSOR = :RAMOCOMP-RAMO-EMISSOR END-EXEC. */

            var r8007_00_GERAR_MAX_APOLICE_DB_SELECT_1_Query1 = new R8007_00_GERAR_MAX_APOLICE_DB_SELECT_1_Query1()
            {
                RAMOCOMP_RAMO_EMISSOR = RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR.ToString(),
                FONTES_ORGAO_EMISSOR = FONTES.DCLFONTES.FONTES_ORGAO_EMISSOR.ToString(),
            };

            var executed_1 = R8007_00_GERAR_MAX_APOLICE_DB_SELECT_1_Query1.Execute(r8007_00_GERAR_MAX_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);
            }


        }

        [StopWatch]
        /*" R8007-00-GERAR-MAX-APOLICE-DB-UPDATE-1 */
        public void R8007_00_GERAR_MAX_APOLICE_DB_UPDATE_1()
        {
            /*" -8141- EXEC SQL UPDATE SEGUROS.NUMERO_AES SET SEQ_APOLICE = :APOLICES-NUM-APOLICE WHERE ORGAO_EMISSOR = :FONTES-ORGAO-EMISSOR AND RAMO_EMISSOR = :RAMOCOMP-RAMO-EMISSOR END-EXEC. */

            var r8007_00_GERAR_MAX_APOLICE_DB_UPDATE_1_Update1 = new R8007_00_GERAR_MAX_APOLICE_DB_UPDATE_1_Update1()
            {
                APOLICES_NUM_APOLICE = APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.ToString(),
                RAMOCOMP_RAMO_EMISSOR = RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR.ToString(),
                FONTES_ORGAO_EMISSOR = FONTES.DCLFONTES.FONTES_ORGAO_EMISSOR.ToString(),
            };

            R8007_00_GERAR_MAX_APOLICE_DB_UPDATE_1_Update1.Execute(r8007_00_GERAR_MAX_APOLICE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8007_99_SAIDA*/

        [StopWatch]
        /*" R8008-00-PESQUISA-RAMO-COMPL-SECTION */
        private void R8008_00_PESQUISA_RAMO_COMPL_SECTION()
        {
            /*" -8164- MOVE 'R8008-00-PESQUISA-RAMO-COMPL' TO PARAGRAFO. */
            _.Move("R8008-00-PESQUISA-RAMO-COMPL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8165- MOVE 'SELECT RAMO COMPL' TO COMANDO. */
            _.Move("SELECT RAMO COMPL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8167- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8178- PERFORM R8008_00_PESQUISA_RAMO_COMPL_DB_SELECT_1 */

            R8008_00_PESQUISA_RAMO_COMPL_DB_SELECT_1();

            /*" -8181- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -8182- DISPLAY 'R8008 - PROBLEMAS SELECT RAMO_COMPLEMENTAR.' */
                _.Display($"R8008 - PROBLEMAS SELECT RAMO_COMPLEMENTAR.");

                /*" -8183- DISPLAY 'RAMO EMISSOR   = ' RAMOCOMP-RAMO-EMISSOR */
                _.Display($"RAMO EMISSOR   = {RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR}");

                /*" -8184- DISPLAY 'WS-DTA-INI-VIG = ' WS-DTA-INI-VIGENCIA */
                _.Display($"WS-DTA-INI-VIG = {WS_DTA_INI_VIGENCIA}");

                /*" -8185- DISPLAY 'SQLCODE        = ' SQLCODE */
                _.Display($"SQLCODE        = {DB.SQLCODE}");

                /*" -8186- DISPLAY 'SQLERRMC       = ' SQLERRMC */
                _.Display($"SQLERRMC       = {DB.SQLERRMC}");

                /*" -8187- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8187- END-IF. */
            }


        }

        [StopWatch]
        /*" R8008-00-PESQUISA-RAMO-COMPL-DB-SELECT-1 */
        public void R8008_00_PESQUISA_RAMO_COMPL_DB_SELECT_1()
        {
            /*" -8178- EXEC SQL SELECT PCT_IOCC_RAMO, IND_ISENCAO_CUSTO INTO :RAMOCOMP-PCT-IOCC-RAMO, :RAMOCOMP-IND-ISENCAO-CUSTO FROM SEGUROS.RAMO_COMPLEMENTAR WHERE RAMO_EMISSOR = :RAMOCOMP-RAMO-EMISSOR AND DATA_INIVIGENCIA < :WS-DTA-INI-VIGENCIA AND DATA_TERVIGENCIA > :WS-DTA-INI-VIGENCIA FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r8008_00_PESQUISA_RAMO_COMPL_DB_SELECT_1_Query1 = new R8008_00_PESQUISA_RAMO_COMPL_DB_SELECT_1_Query1()
            {
                RAMOCOMP_RAMO_EMISSOR = RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR.ToString(),
                WS_DTA_INI_VIGENCIA = WS_DTA_INI_VIGENCIA.ToString(),
            };

            var executed_1 = R8008_00_PESQUISA_RAMO_COMPL_DB_SELECT_1_Query1.Execute(r8008_00_PESQUISA_RAMO_COMPL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMOCOMP_PCT_IOCC_RAMO, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO);
                _.Move(executed_1.RAMOCOMP_IND_ISENCAO_CUSTO, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_IND_ISENCAO_CUSTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8008_99_SAIDA*/

        [StopWatch]
        /*" R8009-00-CALCULA-FIM-VIGENCIA-SECTION */
        private void R8009_00_CALCULA_FIM_VIGENCIA_SECTION()
        {
            /*" -8196- MOVE 'R8009-00-CALCULA-FIM-VIGENCIA' TO PARAGRAFO. */
            _.Move("R8009-00-CALCULA-FIM-VIGENCIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8197- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8207- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8209- PERFORM R8009_00_CALCULA_FIM_VIGENCIA_DB_SET_1 */

            R8009_00_CALCULA_FIM_VIGENCIA_DB_SET_1();

            /*" -8212- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -8213- DISPLAY 'R8009 - PROBLEMAS SET :W-DATA-SQL.' */
                _.Display($"R8009 - PROBLEMAS SET :W-DATA-SQL.");

                /*" -8214- DISPLAY 'W-DATA-SQL = ' W-DATA-SQL */
                _.Display($"W-DATA-SQL = {WAREA_AUXILIAR.W_DATA_SQL}");

                /*" -8215- DISPLAY 'SQLCODE    = ' SQLCODE */
                _.Display($"SQLCODE    = {DB.SQLCODE}");

                /*" -8216- DISPLAY 'SQLERRMC   = ' SQLERRMC */
                _.Display($"SQLERRMC   = {DB.SQLERRMC}");

                /*" -8217- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8217- END-IF. */
            }


        }

        [StopWatch]
        /*" R8009-00-CALCULA-FIM-VIGENCIA-DB-SET-1 */
        public void R8009_00_CALCULA_FIM_VIGENCIA_DB_SET_1()
        {
            /*" -8209- EXEC SQL SET :W-DATA-SQL = DATE(:W-DATA-SQL) + 1 YEAR - 1 DAY END-EXEC. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL.ToDateTime().AddYears(+1).AddDays(-1), WAREA_AUXILIAR.W_DATA_SQL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8009_99_SAIDA*/

        [StopWatch]
        /*" R8010-00-PESQUISA-MOEDAS-SECTION */
        private void R8010_00_PESQUISA_MOEDAS_SECTION()
        {
            /*" -8225- MOVE 'R8010-00-PESQUISA-MOEDAS' TO PARAGRAFO. */
            _.Move("R8010-00-PESQUISA-MOEDAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8226- MOVE 'SELECT MOEDAS ' TO COMANDO. */
            _.Move("SELECT MOEDAS ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8228- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8236- PERFORM R8010_00_PESQUISA_MOEDAS_DB_SELECT_1 */

            R8010_00_PESQUISA_MOEDAS_DB_SELECT_1();

            /*" -8239- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -8240- DISPLAY 'R8010 - PROBLEMAS SELECT SEGUROS.MOEDAS.' */
                _.Display($"R8010 - PROBLEMAS SELECT SEGUROS.MOEDAS.");

                /*" -8241- DISPLAY 'TIPO_MOEDA   = 0' */
                _.Display($"TIPO_MOEDA   = 0");

                /*" -8242- DISPLAY 'SIT_REGISTRO = 0' */
                _.Display($"SIT_REGISTRO = 0");

                /*" -8243- DISPLAY 'SQLCODE      = ' SQLCODE */
                _.Display($"SQLCODE      = {DB.SQLCODE}");

                /*" -8244- DISPLAY 'SQLERRMC     = ' SQLERRMC */
                _.Display($"SQLERRMC     = {DB.SQLERRMC}");

                /*" -8245- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8245- END-IF. */
            }


        }

        [StopWatch]
        /*" R8010-00-PESQUISA-MOEDAS-DB-SELECT-1 */
        public void R8010_00_PESQUISA_MOEDAS_DB_SELECT_1()
        {
            /*" -8236- EXEC SQL SELECT VALUE(COD_MOEDA, 1) INTO :MOEDAS-COD-MOEDA FROM SEGUROS.MOEDAS WHERE TIPO_MOEDA = '0' AND SIT_REGISTRO = '0' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r8010_00_PESQUISA_MOEDAS_DB_SELECT_1_Query1 = new R8010_00_PESQUISA_MOEDAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R8010_00_PESQUISA_MOEDAS_DB_SELECT_1_Query1.Execute(r8010_00_PESQUISA_MOEDAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOEDAS_COD_MOEDA, MOEDAS.DCLMOEDAS.MOEDAS_COD_MOEDA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8010_99_SAIDA*/

        [StopWatch]
        /*" R8011-00-VERIFICA-BANCO-AG-DAC-SECTION */
        private void R8011_00_VERIFICA_BANCO_AG_DAC_SECTION()
        {
            /*" -8254- MOVE 'R8011-00-VERIFICA-BANCO-AG-DAC' TO PARAGRAFO. */
            _.Move("R8011-00-VERIFICA-BANCO-AG-DAC", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8255- MOVE 'SELECT BANCO AG DAC' TO COMANDO. */
            _.Move("SELECT BANCO AG DAC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8257- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8265- PERFORM R8011_00_VERIFICA_BANCO_AG_DAC_DB_SELECT_1 */

            R8011_00_VERIFICA_BANCO_AG_DAC_DB_SELECT_1();

            /*" -8268- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -8269- DISPLAY 'R8011 - PROBLEMAS SELECT SEGUROS.AGENCIAS.' */
                _.Display($"R8011 - PROBLEMAS SELECT SEGUROS.AGENCIAS.");

                /*" -8270- DISPLAY 'AGENCIAS-COD-BANCO   = ' AGENCIAS-COD-BANCO */
                _.Display($"AGENCIAS-COD-BANCO   = {AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_BANCO}");

                /*" -8271- DISPLAY 'AGENCIAS-COD-AGENCIA = ' AGENCIAS-COD-AGENCIA */
                _.Display($"AGENCIAS-COD-AGENCIA = {AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_AGENCIA}");

                /*" -8272- DISPLAY 'SQLCODE              = ' SQLCODE */
                _.Display($"SQLCODE              = {DB.SQLCODE}");

                /*" -8273- DISPLAY 'SQLERRMC             = ' SQLERRMC */
                _.Display($"SQLERRMC             = {DB.SQLERRMC}");

                /*" -8274- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8274- END-IF. */
            }


        }

        [StopWatch]
        /*" R8011-00-VERIFICA-BANCO-AG-DAC-DB-SELECT-1 */
        public void R8011_00_VERIFICA_BANCO_AG_DAC_DB_SELECT_1()
        {
            /*" -8265- EXEC SQL SELECT NOME_AGENCIA INTO :AGENCIAS-NOME-AGENCIA FROM SEGUROS.AGENCIAS WHERE COD_BANCO = :AGENCIAS-COD-BANCO AND COD_AGENCIA = :AGENCIAS-COD-AGENCIA FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r8011_00_VERIFICA_BANCO_AG_DAC_DB_SELECT_1_Query1 = new R8011_00_VERIFICA_BANCO_AG_DAC_DB_SELECT_1_Query1()
            {
                AGENCIAS_COD_AGENCIA = AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_AGENCIA.ToString(),
                AGENCIAS_COD_BANCO = AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_BANCO.ToString(),
            };

            var executed_1 = R8011_00_VERIFICA_BANCO_AG_DAC_DB_SELECT_1_Query1.Execute(r8011_00_VERIFICA_BANCO_AG_DAC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AGENCIAS_NOME_AGENCIA, AGENCIAS.DCLAGENCIAS.AGENCIAS_NOME_AGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8011_99_SAIDA*/

        [StopWatch]
        /*" R8012-00-VERIFICA-CLIENTE-SECTION */
        private void R8012_00_VERIFICA_CLIENTE_SECTION()
        {
            /*" -8282- MOVE 'R8012-00-VERIFICA-CLIENTE' TO PARAGRAFO. */
            _.Move("R8012-00-VERIFICA-CLIENTE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8283- MOVE 'SELECT CLIENTE' TO COMANDO. */
            _.Move("SELECT CLIENTE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8285- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8295- PERFORM R8012_00_VERIFICA_CLIENTE_DB_SELECT_1 */

            R8012_00_VERIFICA_CLIENTE_DB_SELECT_1();

            /*" -8298- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -8299- DISPLAY 'R8012 - PROBLEMAS SELECT SEGUROS.CLIENTES.' */
                _.Display($"R8012 - PROBLEMAS SELECT SEGUROS.CLIENTES.");

                /*" -8300- DISPLAY 'CLIENTES-CGCCPF = ' CLIENTES-CGCCPF */
                _.Display($"CLIENTES-CGCCPF = {CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF}");

                /*" -8301- DISPLAY 'SQLCODE         = ' SQLCODE */
                _.Display($"SQLCODE         = {DB.SQLCODE}");

                /*" -8302- DISPLAY 'SQLERRMC        = ' SQLERRMC */
                _.Display($"SQLERRMC        = {DB.SQLERRMC}");

                /*" -8303- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8304- END-IF. */
            }


            /*" -8305- DISPLAY 'R8012 - SELECT SEGUROS.CLIENTES.' */
            _.Display($"R8012 - SELECT SEGUROS.CLIENTES.");

            /*" -8306- DISPLAY 'SQLCODE             ' SQLCODE */
            _.Display($"SQLCODE             {DB.SQLCODE}");

            /*" -8307- DISPLAY 'CLIENTES-CGCCPF = ' CLIENTES-CGCCPF. */
            _.Display($"CLIENTES-CGCCPF = {CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF}");

            /*" -8308- DISPLAY 'CLIENTES-COD-CLIENTE=' CLIENTES-COD-CLIENTE */
            _.Display($"CLIENTES-COD-CLIENTE={CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE}");

            /*" -8308- DISPLAY 'CLIENTES-NOME-RAZAO=' CLIENTES-NOME-RAZAO. */
            _.Display($"CLIENTES-NOME-RAZAO={CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO}");

        }

        [StopWatch]
        /*" R8012-00-VERIFICA-CLIENTE-DB-SELECT-1 */
        public void R8012_00_VERIFICA_CLIENTE_DB_SELECT_1()
        {
            /*" -8295- EXEC SQL SELECT COD_CLIENTE, NOME_RAZAO INTO :CLIENTES-COD-CLIENTE, :CLIENTES-NOME-RAZAO FROM SEGUROS.CLIENTES WHERE CGCCPF = :CLIENTES-CGCCPF ORDER BY COD_CLIENTE DESC FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r8012_00_VERIFICA_CLIENTE_DB_SELECT_1_Query1 = new R8012_00_VERIFICA_CLIENTE_DB_SELECT_1_Query1()
            {
                CLIENTES_CGCCPF = CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF.ToString(),
            };

            var executed_1 = R8012_00_VERIFICA_CLIENTE_DB_SELECT_1_Query1.Execute(r8012_00_VERIFICA_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8012_99_SAIDA*/

        [StopWatch]
        /*" R8013-00-VERIFICA-SIGLA-UF-SECTION */
        private void R8013_00_VERIFICA_SIGLA_UF_SECTION()
        {
            /*" -8316- MOVE 'R8013-00-VERIFICA-SIGLA-UF' TO PARAGRAFO. */
            _.Move("R8013-00-VERIFICA-SIGLA-UF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8317- MOVE 'SELECT UF' TO COMANDO. */
            _.Move("SELECT UF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8319- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8326- PERFORM R8013_00_VERIFICA_SIGLA_UF_DB_SELECT_1 */

            R8013_00_VERIFICA_SIGLA_UF_DB_SELECT_1();

            /*" -8329- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -8330- DISPLAY 'R8013 - PROBLEMAS SELECT (UNIDADE-FEDERACAO)' */
                _.Display($"R8013 - PROBLEMAS SELECT (UNIDADE-FEDERACAO)");

                /*" -8331- DISPLAY 'ENDERECO-SIGLA-UF = ' ENDERECO-SIGLA-UF */
                _.Display($"ENDERECO-SIGLA-UF = {ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF}");

                /*" -8332- DISPLAY 'SQLCODE           = ' SQLCODE */
                _.Display($"SQLCODE           = {DB.SQLCODE}");

                /*" -8333- DISPLAY 'SQLERRMC          = ' SQLERRMC */
                _.Display($"SQLERRMC          = {DB.SQLERRMC}");

                /*" -8334- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8334- END-IF. */
            }


        }

        [StopWatch]
        /*" R8013-00-VERIFICA-SIGLA-UF-DB-SELECT-1 */
        public void R8013_00_VERIFICA_SIGLA_UF_DB_SELECT_1()
        {
            /*" -8326- EXEC SQL SELECT SIGLA_UF INTO :ENDERECO-SIGLA-UF FROM SEGUROS.UNIDADE_FEDERACAO WHERE SIGLA_UF = :ENDERECO-SIGLA-UF FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var r8013_00_VERIFICA_SIGLA_UF_DB_SELECT_1_Query1 = new R8013_00_VERIFICA_SIGLA_UF_DB_SELECT_1_Query1()
            {
                ENDERECO_SIGLA_UF = ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF.ToString(),
            };

            var executed_1 = R8013_00_VERIFICA_SIGLA_UF_DB_SELECT_1_Query1.Execute(r8013_00_VERIFICA_SIGLA_UF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8013_99_SAIDA*/

        [StopWatch]
        /*" R8014-00-VERIFICA-SUBGRUPO-VG-SECTION */
        private void R8014_00_VERIFICA_SUBGRUPO_VG_SECTION()
        {
            /*" -8343- MOVE 'R8014-00-VERIFICA-SUBGRUPO-VG' TO PARAGRAFO. */
            _.Move("R8014-00-VERIFICA-SUBGRUPO-VG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8344- MOVE 'SELECT SUBGRUPO' TO COMANDO. */
            _.Move("SELECT SUBGRUPO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8346- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8357- PERFORM R8014_00_VERIFICA_SUBGRUPO_VG_DB_SELECT_1 */

            R8014_00_VERIFICA_SUBGRUPO_VG_DB_SELECT_1();

            /*" -8360- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -8361- DISPLAY 'R8014 -PROBLEMAS SELECT SEGUROS.SUBGRUPOS_VGAP.' */
                _.Display($"R8014 -PROBLEMAS SELECT SEGUROS.SUBGRUPOS_VGAP.");

                /*" -8362- DISPLAY 'SUBGVGAP-NUM-APOLICE  = ' SUBGVGAP-NUM-APOLICE */
                _.Display($"SUBGVGAP-NUM-APOLICE  = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                /*" -8363- DISPLAY 'SUBGVGAP-COD-SUBGRUPO = ' SUBGVGAP-COD-SUBGRUPO */
                _.Display($"SUBGVGAP-COD-SUBGRUPO = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                /*" -8364- DISPLAY 'SQLCODE               = ' SQLCODE */
                _.Display($"SQLCODE               = {DB.SQLCODE}");

                /*" -8365- DISPLAY 'SQLERRMC              = ' SQLERRMC */
                _.Display($"SQLERRMC              = {DB.SQLERRMC}");

                /*" -8366- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8367- END-IF. */
            }


            /*" -8368- DISPLAY 'R8014 - SELECT SEGUROS.SUBGRUPOS_VGAP.' */
            _.Display($"R8014 - SELECT SEGUROS.SUBGRUPOS_VGAP.");

            /*" -8369- DISPLAY 'SUBGVGAP-NUM-APOLICE  = ' SUBGVGAP-NUM-APOLICE */
            _.Display($"SUBGVGAP-NUM-APOLICE  = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

            /*" -8370- DISPLAY 'SUBGVGAP-COD-SUBGRUPO = ' SUBGVGAP-COD-SUBGRUPO */
            _.Display($"SUBGVGAP-COD-SUBGRUPO = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

            /*" -8371- DISPLAY 'COD_CLIENTE      = ' SUBGVGAP-COD-CLIENTE */
            _.Display($"COD_CLIENTE      = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE}");

            /*" -8372- DISPLAY 'DATA_INIVIGENCIA = ' SUBGVGAP-DATA-INIVIGENCIA */
            _.Display($"DATA_INIVIGENCIA = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_INIVIGENCIA}");

            /*" -8372- DISPLAY 'DATA_TERVIGENCIA = ' SUBGVGAP-DATA-TERVIGENCIA. */
            _.Display($"DATA_TERVIGENCIA = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_TERVIGENCIA}");

        }

        [StopWatch]
        /*" R8014-00-VERIFICA-SUBGRUPO-VG-DB-SELECT-1 */
        public void R8014_00_VERIFICA_SUBGRUPO_VG_DB_SELECT_1()
        {
            /*" -8357- EXEC SQL SELECT COD_CLIENTE, DATA_INIVIGENCIA, DATA_TERVIGENCIA INTO :SUBGVGAP-COD-CLIENTE, :SUBGVGAP-DATA-INIVIGENCIA, :SUBGVGAP-DATA-TERVIGENCIA FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO WITH UR END-EXEC */

            var r8014_00_VERIFICA_SUBGRUPO_VG_DB_SELECT_1_Query1 = new R8014_00_VERIFICA_SUBGRUPO_VG_DB_SELECT_1_Query1()
            {
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R8014_00_VERIFICA_SUBGRUPO_VG_DB_SELECT_1_Query1.Execute(r8014_00_VERIFICA_SUBGRUPO_VG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_COD_CLIENTE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE);
                _.Move(executed_1.SUBGVGAP_DATA_INIVIGENCIA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_INIVIGENCIA);
                _.Move(executed_1.SUBGVGAP_DATA_TERVIGENCIA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8014_99_SAIDA*/

        [StopWatch]
        /*" R8015-00-GERAR-MAX-OCORR-END-SECTION */
        private void R8015_00_GERAR_MAX_OCORR_END_SECTION()
        {
            /*" -8380- MOVE 'R8015-00-GERAR-MAX-OCORR-END' TO PARAGRAFO. */
            _.Move("R8015-00-GERAR-MAX-OCORR-END", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8381- MOVE 'SELECT OCORR END' TO COMANDO. */
            _.Move("SELECT OCORR END", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8383- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8389- PERFORM R8015_00_GERAR_MAX_OCORR_END_DB_SELECT_1 */

            R8015_00_GERAR_MAX_OCORR_END_DB_SELECT_1();

            /*" -8392- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -8393- DISPLAY 'R8015 - PROBLEMAS SELECT SEGUROS.ENDERECOS.' */
                _.Display($"R8015 - PROBLEMAS SELECT SEGUROS.ENDERECOS.");

                /*" -8394- DISPLAY 'ENDERECO-COD-CLIENTE = ' ENDERECO-COD-CLIENTE */
                _.Display($"ENDERECO-COD-CLIENTE = {ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE}");

                /*" -8395- DISPLAY 'SQLCODE              = ' SQLCODE */
                _.Display($"SQLCODE              = {DB.SQLCODE}");

                /*" -8396- DISPLAY 'SQLERRMC             = ' SQLERRMC */
                _.Display($"SQLERRMC             = {DB.SQLERRMC}");

                /*" -8397- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8397- END-IF. */
            }


        }

        [StopWatch]
        /*" R8015-00-GERAR-MAX-OCORR-END-DB-SELECT-1 */
        public void R8015_00_GERAR_MAX_OCORR_END_DB_SELECT_1()
        {
            /*" -8389- EXEC SQL SELECT VALUE(MAX(OCORR_ENDERECO),0) + 1 INTO :ENDERECO-OCORR-ENDERECO FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :ENDERECO-COD-CLIENTE WITH UR END-EXEC. */

            var r8015_00_GERAR_MAX_OCORR_END_DB_SELECT_1_Query1 = new R8015_00_GERAR_MAX_OCORR_END_DB_SELECT_1_Query1()
            {
                ENDERECO_COD_CLIENTE = ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE.ToString(),
            };

            var executed_1 = R8015_00_GERAR_MAX_OCORR_END_DB_SELECT_1_Query1.Execute(r8015_00_GERAR_MAX_OCORR_END_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8015_99_SAIDA*/

        [StopWatch]
        /*" R8016-00-GERAR-MAX-OCORR-EMAIL-SECTION */
        private void R8016_00_GERAR_MAX_OCORR_EMAIL_SECTION()
        {
            /*" -8406- MOVE 'R8016-00-GERAR-MAX-OCORR-EMAIL' TO PARAGRAFO. */
            _.Move("R8016-00-GERAR-MAX-OCORR-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8407- MOVE 'SELECT OCORR EMAIL' TO COMANDO. */
            _.Move("SELECT OCORR EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8409- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8415- PERFORM R8016_00_GERAR_MAX_OCORR_EMAIL_DB_SELECT_1 */

            R8016_00_GERAR_MAX_OCORR_EMAIL_DB_SELECT_1();

            /*" -8418- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -8419- DISPLAY 'R8016 - PROBLEMAS SELECT SEGUROS.CLIENTE_EMAIL.' */
                _.Display($"R8016 - PROBLEMAS SELECT SEGUROS.CLIENTE_EMAIL.");

                /*" -8420- DISPLAY 'ENDERECO-COD-CLIENTE = ' ENDERECO-COD-CLIENTE */
                _.Display($"ENDERECO-COD-CLIENTE = {ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE}");

                /*" -8421- DISPLAY 'SQLCODE              = ' SQLCODE */
                _.Display($"SQLCODE              = {DB.SQLCODE}");

                /*" -8422- DISPLAY 'SQLERRMC             = ' SQLERRMC */
                _.Display($"SQLERRMC             = {DB.SQLERRMC}");

                /*" -8423- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8423- END-IF. */
            }


        }

        [StopWatch]
        /*" R8016-00-GERAR-MAX-OCORR-EMAIL-DB-SELECT-1 */
        public void R8016_00_GERAR_MAX_OCORR_EMAIL_DB_SELECT_1()
        {
            /*" -8415- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL),0) + 1 INTO :CLIENEMA-SEQ-EMAIL FROM SEGUROS.CLIENTE_EMAIL WHERE COD_CLIENTE = :ENDERECO-COD-CLIENTE WITH UR END-EXEC. */

            var r8016_00_GERAR_MAX_OCORR_EMAIL_DB_SELECT_1_Query1 = new R8016_00_GERAR_MAX_OCORR_EMAIL_DB_SELECT_1_Query1()
            {
                ENDERECO_COD_CLIENTE = ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE.ToString(),
            };

            var executed_1 = R8016_00_GERAR_MAX_OCORR_EMAIL_DB_SELECT_1_Query1.Execute(r8016_00_GERAR_MAX_OCORR_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENEMA_SEQ_EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8016_99_SAIDA*/

        [StopWatch]
        /*" R8017-00-UPDATE-END-SUBGRUPO-SECTION */
        private void R8017_00_UPDATE_END_SUBGRUPO_SECTION()
        {
            /*" -8432- MOVE 'R8017-00-UPDATE-OCORR-END-APOL' TO PARAGRAFO. */
            _.Move("R8017-00-UPDATE-OCORR-END-APOL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8433- MOVE 'SELECT OCORR APOL' TO COMANDO. */
            _.Move("SELECT OCORR APOL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8435- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8441- PERFORM R8017_00_UPDATE_END_SUBGRUPO_DB_UPDATE_1 */

            R8017_00_UPDATE_END_SUBGRUPO_DB_UPDATE_1();

            /*" -8444- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -8445- DISPLAY 'R8017 -PROBLEMAS UPDATE SEGUROS.SUBGRUPOS_VGAP.' */
                _.Display($"R8017 -PROBLEMAS UPDATE SEGUROS.SUBGRUPOS_VGAP.");

                /*" -8446- DISPLAY 'SUBGVGAP-NUM-APOLICE = ' SUBGVGAP-NUM-APOLICE */
                _.Display($"SUBGVGAP-NUM-APOLICE = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                /*" -8447- DISPLAY 'WS-SUBGRUPO-1        = ' WS-SUBGRUPO-1 */
                _.Display($"WS-SUBGRUPO-1        = {WAREA_AUXILIAR.WS_SUBGRUPO_1}");

                /*" -8448- DISPLAY 'WS-SUBGRUPO-2        = ' WS-SUBGRUPO-2 */
                _.Display($"WS-SUBGRUPO-2        = {WAREA_AUXILIAR.WS_SUBGRUPO_2}");

                /*" -8449- DISPLAY 'ENDERECO-OCORR-ENDERE= ' ENDERECO-OCORR-ENDERECO */
                _.Display($"ENDERECO-OCORR-ENDERE= {ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO}");

                /*" -8450- DISPLAY 'SQLCODE              = ' SQLCODE */
                _.Display($"SQLCODE              = {DB.SQLCODE}");

                /*" -8451- DISPLAY 'SQLERRMC             = ' SQLERRMC */
                _.Display($"SQLERRMC             = {DB.SQLERRMC}");

                /*" -8452- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8452- END-IF. */
            }


        }

        [StopWatch]
        /*" R8017-00-UPDATE-END-SUBGRUPO-DB-UPDATE-1 */
        public void R8017_00_UPDATE_END_SUBGRUPO_DB_UPDATE_1()
        {
            /*" -8441- EXEC SQL UPDATE SEGUROS.SUBGRUPOS_VGAP SET OCORR_ENDERECO = :ENDERECO-OCORR-ENDERECO, OCORR_END_COBRAN = :ENDERECO-OCORR-ENDERECO WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO IN (:WS-SUBGRUPO-1, :WS-SUBGRUPO-2) END-EXEC. */

            var r8017_00_UPDATE_END_SUBGRUPO_DB_UPDATE_1_Update1 = new R8017_00_UPDATE_END_SUBGRUPO_DB_UPDATE_1_Update1()
            {
                ENDERECO_OCORR_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
                WS_SUBGRUPO_1 = WAREA_AUXILIAR.WS_SUBGRUPO_1.ToString(),
                WS_SUBGRUPO_2 = WAREA_AUXILIAR.WS_SUBGRUPO_2.ToString(),
            };

            R8017_00_UPDATE_END_SUBGRUPO_DB_UPDATE_1_Update1.Execute(r8017_00_UPDATE_END_SUBGRUPO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8017_99_SAIDA*/

        [StopWatch]
        /*" R8018-00-VALIDA-CPF-SECTION */
        private void R8018_00_VALIDA_CPF_SECTION()
        {
            /*" -8461- MOVE 'R8018-00-VALIDA-CPF' TO PARAGRAFO. */
            _.Move("R8018-00-VALIDA-CPF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8462- MOVE 'VALIDA CPF ' TO COMANDO. */
            _.Move("VALIDA CPF ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8464- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8466- MOVE 'PROCPF02' TO WS-CALL */
            _.Move("PROCPF02", WS_CALL);

            /*" -8466- CALL WS-CALL USING LPARM-CPF. */
            _.Call(WS_CALL, LPARM_CPF);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8018_99_SAIDA*/

        [StopWatch]
        /*" R8019-00-CALCULA-IDADE-SECTION */
        private void R8019_00_CALCULA_IDADE_SECTION()
        {
            /*" -8476- MOVE 'R8019-00-CALCULA-IDADE       ' TO PARAGRAFO. */
            _.Move("R8019-00-CALCULA-IDADE       ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8477- MOVE 'CALCULO IDADE' TO COMANDO. */
            _.Move("CALCULO IDADE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8499- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8500- MOVE W-DATA-SQL TO WS-DTNASC */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, WS_DT_CALC.WS_DTNASC);

            /*" -8502- MOVE R1-DTA-INI-VIGENCIA(1:2) TO WS-DD-DTPROP */
            _.Move(REG_R1_SUBGRUPO.R1_DTA_INI_VIGENCIA.Substring(1, 2), WS_DD_DTPROP);

            /*" -8504- MOVE R1-DTA-INI-VIGENCIA(3:2) TO WS-MM-DTPROP */
            _.Move(REG_R1_SUBGRUPO.R1_DTA_INI_VIGENCIA.Substring(3, 2), WS_DTPROP.WS_MM_DTPROP);

            /*" -8507- MOVE R1-DTA-INI-VIGENCIA(5:4) TO WS-AA-DTPROP */
            _.Move(REG_R1_SUBGRUPO.R1_DTA_INI_VIGENCIA.Substring(5, 4), WS_DTPROP.WS_AA_DTPROP);

            /*" -8510- COMPUTE WS-IDADE = WS-AA-DTPROP - WS-AA-DTNASC. */
            WS_IDADE.Value = WS_DTPROP.WS_AA_DTPROP - WS_DT_CALC.WS_DTNASC.WS_AA_DTNASC;

            /*" -8511- IF WS-MM-DTNASC GREATER WS-MM-DTPROP */

            if (WS_DT_CALC.WS_DTNASC.WS_MM_DTNASC > WS_DTPROP.WS_MM_DTPROP)
            {

                /*" -8512- SUBTRACT 1 FROM WS-IDADE */
                WS_IDADE.Value = WS_IDADE - 1;

                /*" -8513- ELSE */
            }
            else
            {


                /*" -8514- IF WS-MM-DTNASC EQUAL WS-MM-DTPROP */

                if (WS_DT_CALC.WS_DTNASC.WS_MM_DTNASC == WS_DTPROP.WS_MM_DTPROP)
                {

                    /*" -8515- IF WS-DD-DTNASC GREATER WS-DD-DTPROP */

                    if (WS_DT_CALC.WS_DD_DTNASC > WS_DD_DTPROP)
                    {

                        /*" -8516- SUBTRACT 1 FROM WS-IDADE */
                        WS_IDADE.Value = WS_IDADE - 1;

                        /*" -8517- END-IF */
                    }


                    /*" -8518- END-IF */
                }


                /*" -8519- END-IF */
            }


            /*" -8519- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8019_99_SAIDA*/

        [StopWatch]
        /*" R8020-00-VERIFICA-PESSOA-FIS-SECTION */
        private void R8020_00_VERIFICA_PESSOA_FIS_SECTION()
        {
            /*" -8527- MOVE 'R8020-00-VERIFICA-PESSOA-FIS' TO PARAGRAFO. */
            _.Move("R8020-00-VERIFICA-PESSOA-FIS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8528- MOVE 'VERIFICA PESSOA FISICA' TO COMANDO. */
            _.Move("VERIFICA PESSOA FISICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8530- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8561- PERFORM R8020_00_VERIFICA_PESSOA_FIS_DB_SELECT_1 */

            R8020_00_VERIFICA_PESSOA_FIS_DB_SELECT_1();

            /*" -8564- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -8565- DISPLAY 'R8020 - PROBLEMAS ACESSO PESSOA FISICA.  ' */
                _.Display($"R8020 - PROBLEMAS ACESSO PESSOA FISICA.  ");

                /*" -8566- DISPLAY 'CPF      = ' CPF OF DCLPESSOA-FISICA */
                _.Display($"CPF      = {PESFIS.DCLPESSOA_FISICA.CPF}");

                /*" -8567- DISPLAY 'SQLCODE  = ' SQLCODE */
                _.Display($"SQLCODE  = {DB.SQLCODE}");

                /*" -8568- DISPLAY 'SQLERRMC = ' SQLERRMC */
                _.Display($"SQLERRMC = {DB.SQLERRMC}");

                /*" -8569- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8569- END-IF. */
            }


        }

        [StopWatch]
        /*" R8020-00-VERIFICA-PESSOA-FIS-DB-SELECT-1 */
        public void R8020_00_VERIFICA_PESSOA_FIS_DB_SELECT_1()
        {
            /*" -8561- EXEC SQL SELECT COD_PESSOA, CPF, DATA_NASCIMENTO, SEXO, TIPO_IDENT_SIVPF, NUM_IDENTIDADE, ORGAO_EXPEDIDOR, UF_EXPEDIDORA, DATA_EXPEDICAO, COD_CBO, COD_USUARIO, ESTADO_CIVIL, TIMESTAMP INTO :DCLPESSOA.PESSOA-COD-PESSOA, :DCLPESSOA-FISICA.CPF:VIND-CPF, :DCLPESSOA-FISICA.DATA-NASCIMENTO:VIND-DTNASCI, :DCLPESSOA-FISICA.SEXO:VIND-SEXO, :DCLPESSOA-FISICA.TIPO-IDENT-SIVPF:VIND-TP-IDENT, :DCLPESSOA-FISICA.NUM-IDENTIDADE:VIND-NUM-IDENT, :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR:VIND-ORGAO-EXP, :DCLPESSOA-FISICA.UF-EXPEDIDORA:VIND-UF-EXP, :DCLPESSOA-FISICA.DATA-EXPEDICAO:VIND-DTEXPEDI, :DCLPESSOA-FISICA.COD-CBO:VIND-COD-CBO, :DCLPESSOA-FISICA.COD-USUARIO:VIND-COD-USUR, :DCLPESSOA-FISICA.ESTADO-CIVIL, :DCLPESSOA-FISICA.TIMESTAMP:VIND-TIMESTAMP FROM SEGUROS.PESSOA_FISICA WHERE CPF = :DCLPESSOA-FISICA.CPF FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r8020_00_VERIFICA_PESSOA_FIS_DB_SELECT_1_Query1 = new R8020_00_VERIFICA_PESSOA_FIS_DB_SELECT_1_Query1()
            {
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
            };

            var executed_1 = R8020_00_VERIFICA_PESSOA_FIS_DB_SELECT_1_Query1.Execute(r8020_00_VERIFICA_PESSOA_FIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
                _.Move(executed_1.CPF, PESFIS.DCLPESSOA_FISICA.CPF);
                _.Move(executed_1.VIND_CPF, VIND_CPF);
                _.Move(executed_1.DATA_NASCIMENTO, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);
                _.Move(executed_1.VIND_DTNASCI, VIND_DTNASCI);
                _.Move(executed_1.SEXO, PESFIS.DCLPESSOA_FISICA.SEXO);
                _.Move(executed_1.VIND_SEXO, VIND_SEXO);
                _.Move(executed_1.TIPO_IDENT_SIVPF, PESFIS.DCLPESSOA_FISICA.TIPO_IDENT_SIVPF);
                _.Move(executed_1.VIND_TP_IDENT, VIND_TP_IDENT);
                _.Move(executed_1.NUM_IDENTIDADE, PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE);
                _.Move(executed_1.VIND_NUM_IDENT, VIND_NUM_IDENT);
                _.Move(executed_1.ORGAO_EXPEDIDOR, PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR);
                _.Move(executed_1.VIND_ORGAO_EXP, VIND_ORGAO_EXP);
                _.Move(executed_1.UF_EXPEDIDORA, PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA);
                _.Move(executed_1.VIND_UF_EXP, VIND_UF_EXP);
                _.Move(executed_1.DATA_EXPEDICAO, PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO);
                _.Move(executed_1.VIND_DTEXPEDI, VIND_DTEXPEDI);
                _.Move(executed_1.COD_CBO, PESFIS.DCLPESSOA_FISICA.COD_CBO);
                _.Move(executed_1.VIND_COD_CBO, VIND_COD_CBO);
                _.Move(executed_1.COD_USUARIO, PESFIS.DCLPESSOA_FISICA.COD_USUARIO);
                _.Move(executed_1.VIND_COD_USUR, VIND_COD_USUR);
                _.Move(executed_1.ESTADO_CIVIL, PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);
                _.Move(executed_1.TIMESTAMP, PESFIS.DCLPESSOA_FISICA.TIMESTAMP);
                _.Move(executed_1.VIND_TIMESTAMP, VIND_TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8020_99_SAIDA*/

        [StopWatch]
        /*" R8021-00-GERAR-MAX-COD-PESSOA-SECTION */
        private void R8021_00_GERAR_MAX_COD_PESSOA_SECTION()
        {
            /*" -8577- MOVE 'R8021-00-GERAR-MAX-COD-PESSO' TO PARAGRAFO. */
            _.Move("R8021-00-GERAR-MAX-COD-PESSO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8578- MOVE 'SELECT COD PESSOA' TO COMANDO. */
            _.Move("SELECT COD PESSOA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8580- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8585- PERFORM R8021_00_GERAR_MAX_COD_PESSOA_DB_SELECT_1 */

            R8021_00_GERAR_MAX_COD_PESSOA_DB_SELECT_1();

            /*" -8588- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -8589- DISPLAY 'R8021 - PROBLEMAS SELECT MAX SEGUROS.PESSOA.' */
                _.Display($"R8021 - PROBLEMAS SELECT MAX SEGUROS.PESSOA.");

                /*" -8590- DISPLAY 'SQLCODE  = ' SQLCODE */
                _.Display($"SQLCODE  = {DB.SQLCODE}");

                /*" -8591- DISPLAY 'SQLERRMC = ' SQLERRMC */
                _.Display($"SQLERRMC = {DB.SQLERRMC}");

                /*" -8592- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8592- END-IF. */
            }


        }

        [StopWatch]
        /*" R8021-00-GERAR-MAX-COD-PESSOA-DB-SELECT-1 */
        public void R8021_00_GERAR_MAX_COD_PESSOA_DB_SELECT_1()
        {
            /*" -8585- EXEC SQL SELECT VALUE(MAX(COD_PESSOA),0) + 1 INTO :DCLPESSOA.PESSOA-COD-PESSOA FROM SEGUROS.PESSOA WITH UR END-EXEC. */

            var r8021_00_GERAR_MAX_COD_PESSOA_DB_SELECT_1_Query1 = new R8021_00_GERAR_MAX_COD_PESSOA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R8021_00_GERAR_MAX_COD_PESSOA_DB_SELECT_1_Query1.Execute(r8021_00_GERAR_MAX_COD_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8021_99_SAIDA*/

        [StopWatch]
        /*" R8022-00-GERAR-MAX-OCORR-END-SECTION */
        private void R8022_00_GERAR_MAX_OCORR_END_SECTION()
        {
            /*" -8600- MOVE 'R8022-00-GERAR-MAX-OCORR-END' TO PARAGRAFO. */
            _.Move("R8022-00-GERAR-MAX-OCORR-END", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8601- MOVE 'SELECT OCORR END PESSOA' TO COMANDO. */
            _.Move("SELECT OCORR END PESSOA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8603- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8610- PERFORM R8022_00_GERAR_MAX_OCORR_END_DB_SELECT_1 */

            R8022_00_GERAR_MAX_OCORR_END_DB_SELECT_1();

            /*" -8613- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -8614- DISPLAY 'R8022 - PROBLEMAS MAX SEGUROS.PESSOA_ENDERECO.' */
                _.Display($"R8022 - PROBLEMAS MAX SEGUROS.PESSOA_ENDERECO.");

                /*" -8616- DISPLAY 'PESSOA-COD-PESSOA = ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"PESSOA-COD-PESSOA = {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -8617- DISPLAY 'SQLCODE           = ' SQLCODE */
                _.Display($"SQLCODE           = {DB.SQLCODE}");

                /*" -8618- DISPLAY 'SQLERRMC          = ' SQLERRMC */
                _.Display($"SQLERRMC          = {DB.SQLERRMC}");

                /*" -8619- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8619- END-IF. */
            }


        }

        [StopWatch]
        /*" R8022-00-GERAR-MAX-OCORR-END-DB-SELECT-1 */
        public void R8022_00_GERAR_MAX_OCORR_END_DB_SELECT_1()
        {
            /*" -8610- EXEC SQL SELECT VALUE(MAX(OCORR_ENDERECO),0) + 1 INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :PESSOA-COD-PESSOA WITH UR END-EXEC. */

            var r8022_00_GERAR_MAX_OCORR_END_DB_SELECT_1_Query1 = new R8022_00_GERAR_MAX_OCORR_END_DB_SELECT_1_Query1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
            };

            var executed_1 = R8022_00_GERAR_MAX_OCORR_END_DB_SELECT_1_Query1.Execute(r8022_00_GERAR_MAX_OCORR_END_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8022_99_SAIDA*/

        [StopWatch]
        /*" R8023-00-VERIFICA-ENDEREC-PES-SECTION */
        private void R8023_00_VERIFICA_ENDEREC_PES_SECTION()
        {
            /*" -8627- MOVE 'R8023-00-VERIFICA-ENDEREC-PES' TO PARAGRAFO. */
            _.Move("R8023-00-VERIFICA-ENDEREC-PES", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8628- MOVE 'SELECT ENDERECO DE  PESSOA' TO COMANDO. */
            _.Move("SELECT ENDERECO DE  PESSOA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8630- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8642- PERFORM R8023_00_VERIFICA_ENDEREC_PES_DB_SELECT_1 */

            R8023_00_VERIFICA_ENDEREC_PES_DB_SELECT_1();

            /*" -8645- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -8646- DISPLAY 'R8023-PROBLEMAS SELECT SEGUROS.PESSOA_ENDERECO.' */
                _.Display($"R8023-PROBLEMAS SELECT SEGUROS.PESSOA_ENDERECO.");

                /*" -8648- DISPLAY 'PESSOA-COD-PESSOA = ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"PESSOA-COD-PESSOA = {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -8649- DISPLAY 'ENDERECO          = ' ENDERECO */
                _.Display($"ENDERECO          = {ENDERECO}");

                /*" -8650- DISPLAY 'COMPL ENDERECO    = ' COMPL-ENDER */
                _.Display($"COMPL ENDERECO    = {PESENDER.DCLPESSOA_ENDERECO.COMPL_ENDER}");

                /*" -8651- DISPLAY 'CIDADE            = ' CIDADE */
                _.Display($"CIDADE            = {PESENDER.DCLPESSOA_ENDERECO.CIDADE}");

                /*" -8652- DISPLAY 'BAIRRO            = ' BAIRRO */
                _.Display($"BAIRRO            = {PESENDER.DCLPESSOA_ENDERECO.BAIRRO}");

                /*" -8653- DISPLAY 'CEP               = ' CEP */
                _.Display($"CEP               = {PESENDER.DCLPESSOA_ENDERECO.CEP}");

                /*" -8654- DISPLAY 'SQLCODE           = ' SQLCODE */
                _.Display($"SQLCODE           = {DB.SQLCODE}");

                /*" -8655- DISPLAY 'SQLERRMC          = ' SQLERRMC */
                _.Display($"SQLERRMC          = {DB.SQLERRMC}");

                /*" -8656- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8656- END-IF. */
            }


        }

        [StopWatch]
        /*" R8023-00-VERIFICA-ENDEREC-PES-DB-SELECT-1 */
        public void R8023_00_VERIFICA_ENDEREC_PES_DB_SELECT_1()
        {
            /*" -8642- EXEC SQL SELECT OCORR_ENDERECO INTO :OCORR-ENDERECO FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA AND ENDERECO = :ENDERECO AND COMPL_ENDER = :COMPL-ENDER AND CIDADE = :CIDADE AND BAIRRO = :BAIRRO AND CEP = :CEP FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r8023_00_VERIFICA_ENDEREC_PES_DB_SELECT_1_Query1 = new R8023_00_VERIFICA_ENDEREC_PES_DB_SELECT_1_Query1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
                COMPL_ENDER = PESENDER.DCLPESSOA_ENDERECO.COMPL_ENDER.ToString(),
                ENDERECO = ENDERECO.ToString(),
                CIDADE = PESENDER.DCLPESSOA_ENDERECO.CIDADE.ToString(),
                BAIRRO = PESENDER.DCLPESSOA_ENDERECO.BAIRRO.ToString(),
                CEP = PESENDER.DCLPESSOA_ENDERECO.CEP.ToString(),
            };

            var executed_1 = R8023_00_VERIFICA_ENDEREC_PES_DB_SELECT_1_Query1.Execute(r8023_00_VERIFICA_ENDEREC_PES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8023_99_SAIDA*/

        [StopWatch]
        /*" R8024-00-VERIFICA-FONE-PESSOA-SECTION */
        private void R8024_00_VERIFICA_FONE_PESSOA_SECTION()
        {
            /*" -8664- MOVE 'R8024-00-VERIFICA-FONE-PESSOA' TO PARAGRAFO. */
            _.Move("R8024-00-VERIFICA-FONE-PESSOA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8665- MOVE 'SELECT TELEFONE PESSOA       ' TO COMANDO. */
            _.Move("SELECT TELEFONE PESSOA       ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8667- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8676- PERFORM R8024_00_VERIFICA_FONE_PESSOA_DB_SELECT_1 */

            R8024_00_VERIFICA_FONE_PESSOA_DB_SELECT_1();

            /*" -8679- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -8683- DISPLAY 'R8024 - PROBLEMAS SELECT PESSOA_TELEFONE.' PESSOA-COD-PESSOA OF DCLPESSOA ' ...' DDD ' ...' NUM-FONE */

                $"R8024 - PROBLEMAS SELECT PESSOA_TELEFONE.{PESSOA.DCLPESSOA.PESSOA_COD_PESSOA} ...{PESFONE.DCLPESSOA_TELEFONE.DDD} ...{PESFONE.DCLPESSOA_TELEFONE.NUM_FONE}"
                .Display();

                /*" -8685- DISPLAY 'PESSOA-COD-PESSOA = ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"PESSOA-COD-PESSOA = {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -8686- DISPLAY 'DDD               = ' DDD */
                _.Display($"DDD               = {PESFONE.DCLPESSOA_TELEFONE.DDD}");

                /*" -8687- DISPLAY 'NUM-FONE          = ' NUM-FONE */
                _.Display($"NUM-FONE          = {PESFONE.DCLPESSOA_TELEFONE.NUM_FONE}");

                /*" -8688- DISPLAY 'SQLCODE           = ' SQLCODE */
                _.Display($"SQLCODE           = {DB.SQLCODE}");

                /*" -8689- DISPLAY 'SQLERRMC          = ' SQLERRMC */
                _.Display($"SQLERRMC          = {DB.SQLERRMC}");

                /*" -8690- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8690- END-IF. */
            }


        }

        [StopWatch]
        /*" R8024-00-VERIFICA-FONE-PESSOA-DB-SELECT-1 */
        public void R8024_00_VERIFICA_FONE_PESSOA_DB_SELECT_1()
        {
            /*" -8676- EXEC SQL SELECT SEQ_FONE INTO :SEQ-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA AND DDD = :DDD AND NUM_FONE = :NUM-FONE FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r8024_00_VERIFICA_FONE_PESSOA_DB_SELECT_1_Query1 = new R8024_00_VERIFICA_FONE_PESSOA_DB_SELECT_1_Query1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
                NUM_FONE = PESFONE.DCLPESSOA_TELEFONE.NUM_FONE.ToString(),
                DDD = PESFONE.DCLPESSOA_TELEFONE.DDD.ToString(),
            };

            var executed_1 = R8024_00_VERIFICA_FONE_PESSOA_DB_SELECT_1_Query1.Execute(r8024_00_VERIFICA_FONE_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_FONE, PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8024_99_SAIDA*/

        [StopWatch]
        /*" R8025-00-GERAR-MAX-SEQ-FONE-SECTION */
        private void R8025_00_GERAR_MAX_SEQ_FONE_SECTION()
        {
            /*" -8698- MOVE 'R8025-00-GERAR-MAX-SEQ-FONE' TO PARAGRAFO. */
            _.Move("R8025-00-GERAR-MAX-SEQ-FONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8699- MOVE 'SELECT MAX SEQ FONE          ' TO COMANDO. */
            _.Move("SELECT MAX SEQ FONE          ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8701- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8707- PERFORM R8025_00_GERAR_MAX_SEQ_FONE_DB_SELECT_1 */

            R8025_00_GERAR_MAX_SEQ_FONE_DB_SELECT_1();

            /*" -8710- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -8711- DISPLAY 'R8025 - PROBLEMAS SELECT MAX PESSOA_TELEFONE.' */
                _.Display($"R8025 - PROBLEMAS SELECT MAX PESSOA_TELEFONE.");

                /*" -8713- DISPLAY 'PESSOA-COD-PESSOA = ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"PESSOA-COD-PESSOA = {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -8714- DISPLAY 'SQLCODE           = ' SQLCODE */
                _.Display($"SQLCODE           = {DB.SQLCODE}");

                /*" -8715- DISPLAY 'SQLERRMC          = ' SQLERRMC */
                _.Display($"SQLERRMC          = {DB.SQLERRMC}");

                /*" -8716- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8716- END-IF. */
            }


        }

        [StopWatch]
        /*" R8025-00-GERAR-MAX-SEQ-FONE-DB-SELECT-1 */
        public void R8025_00_GERAR_MAX_SEQ_FONE_DB_SELECT_1()
        {
            /*" -8707- EXEC SQL SELECT VALUE(MAX(SEQ_FONE), 0) + 1 INTO :SEQ-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA WITH UR END-EXEC. */

            var r8025_00_GERAR_MAX_SEQ_FONE_DB_SELECT_1_Query1 = new R8025_00_GERAR_MAX_SEQ_FONE_DB_SELECT_1_Query1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
            };

            var executed_1 = R8025_00_GERAR_MAX_SEQ_FONE_DB_SELECT_1_Query1.Execute(r8025_00_GERAR_MAX_SEQ_FONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_FONE, PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8025_99_SAIDA*/

        [StopWatch]
        /*" R8026-00-VERIFICA-EMAIL-PESSOA-SECTION */
        private void R8026_00_VERIFICA_EMAIL_PESSOA_SECTION()
        {
            /*" -8724- MOVE 'R8026-00-VERIFICA-EMAIL-PESSOA' TO PARAGRAFO. */
            _.Move("R8026-00-VERIFICA-EMAIL-PESSOA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8725- MOVE 'SELECT EMAIL PESSOA           ' TO COMANDO. */
            _.Move("SELECT EMAIL PESSOA           ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8727- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8735- PERFORM R8026_00_VERIFICA_EMAIL_PESSOA_DB_SELECT_1 */

            R8026_00_VERIFICA_EMAIL_PESSOA_DB_SELECT_1();

            /*" -8738- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -8739- DISPLAY 'R8026 - PROBLEMAS SELECT SEGUROS.PESSOA_EMAIL.' */
                _.Display($"R8026 - PROBLEMAS SELECT SEGUROS.PESSOA_EMAIL.");

                /*" -8741- DISPLAY 'PESSOA-COD-PESSOA = ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"PESSOA-COD-PESSOA = {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -8742- DISPLAY 'EMAIL             = ' EMAIL */
                _.Display($"EMAIL             = {PESEMAIL.DCLPESSOA_EMAIL.EMAIL}");

                /*" -8743- DISPLAY 'SQLCODE           = ' SQLCODE */
                _.Display($"SQLCODE           = {DB.SQLCODE}");

                /*" -8744- DISPLAY 'SQLERRMC          = ' SQLERRMC */
                _.Display($"SQLERRMC          = {DB.SQLERRMC}");

                /*" -8745- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8745- END-IF. */
            }


        }

        [StopWatch]
        /*" R8026-00-VERIFICA-EMAIL-PESSOA-DB-SELECT-1 */
        public void R8026_00_VERIFICA_EMAIL_PESSOA_DB_SELECT_1()
        {
            /*" -8735- EXEC SQL SELECT SEQ_EMAIL INTO :SEQ-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA AND EMAIL = :EMAIL FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r8026_00_VERIFICA_EMAIL_PESSOA_DB_SELECT_1_Query1 = new R8026_00_VERIFICA_EMAIL_PESSOA_DB_SELECT_1_Query1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
                EMAIL = PESEMAIL.DCLPESSOA_EMAIL.EMAIL.ToString(),
            };

            var executed_1 = R8026_00_VERIFICA_EMAIL_PESSOA_DB_SELECT_1_Query1.Execute(r8026_00_VERIFICA_EMAIL_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8026_99_SAIDA*/

        [StopWatch]
        /*" R8027-00-GERAR-MAX-SEQ-MAIL-SECTION */
        private void R8027_00_GERAR_MAX_SEQ_MAIL_SECTION()
        {
            /*" -8753- MOVE 'R8027-00-GERAR-MAX-SEQ-MAIL' TO PARAGRAFO. */
            _.Move("R8027-00-GERAR-MAX-SEQ-MAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8754- MOVE 'SELECT MAX SEQ EMAIL           ' TO COMANDO. */
            _.Move("SELECT MAX SEQ EMAIL           ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8756- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8762- PERFORM R8027_00_GERAR_MAX_SEQ_MAIL_DB_SELECT_1 */

            R8027_00_GERAR_MAX_SEQ_MAIL_DB_SELECT_1();

            /*" -8765- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -8766- DISPLAY 'R8027 - PROBLEMAS SELECT MAX PESSOA_EMAIL.' */
                _.Display($"R8027 - PROBLEMAS SELECT MAX PESSOA_EMAIL.");

                /*" -8768- DISPLAY 'PESSOA-COD-PESSOA = ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"PESSOA-COD-PESSOA = {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -8769- DISPLAY 'SQLCODE           = ' SQLCODE */
                _.Display($"SQLCODE           = {DB.SQLCODE}");

                /*" -8770- DISPLAY 'SQLERRMC          = ' SQLERRMC */
                _.Display($"SQLERRMC          = {DB.SQLERRMC}");

                /*" -8771- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8771- END-IF. */
            }


        }

        [StopWatch]
        /*" R8027-00-GERAR-MAX-SEQ-MAIL-DB-SELECT-1 */
        public void R8027_00_GERAR_MAX_SEQ_MAIL_DB_SELECT_1()
        {
            /*" -8762- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL), 0) + 1 INTO :SEQ-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA WITH UR END-EXEC. */

            var r8027_00_GERAR_MAX_SEQ_MAIL_DB_SELECT_1_Query1 = new R8027_00_GERAR_MAX_SEQ_MAIL_DB_SELECT_1_Query1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
            };

            var executed_1 = R8027_00_GERAR_MAX_SEQ_MAIL_DB_SELECT_1_Query1.Execute(r8027_00_GERAR_MAX_SEQ_MAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8027_99_SAIDA*/

        [StopWatch]
        /*" R8028-00-GERAR-MAX-OCORR-REPR-SECTION */
        private void R8028_00_GERAR_MAX_OCORR_REPR_SECTION()
        {
            /*" -8779- MOVE 'R8028-00-GERAR-MAX-OCORR-REPR  ' TO PARAGRAFO. */
            _.Move("R8028-00-GERAR-MAX-OCORR-REPR  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8780- MOVE 'SELECT MAX OCORR REPRES LEGAL  ' TO COMANDO. */
            _.Move("SELECT MAX OCORR REPRES LEGAL  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8782- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8788- PERFORM R8028_00_GERAR_MAX_OCORR_REPR_DB_SELECT_1 */

            R8028_00_GERAR_MAX_OCORR_REPR_DB_SELECT_1();

            /*" -8791- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -8792- DISPLAY 'R8028 - PROBLEMAS SELECT MAX VG_REPRES_LEGAL.' */
                _.Display($"R8028 - PROBLEMAS SELECT MAX VG_REPRES_LEGAL.");

                /*" -8794- DISPLAY 'PESSOA-COD-PESSOA = ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"PESSOA-COD-PESSOA = {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -8795- DISPLAY 'SQLCODE           = ' SQLCODE */
                _.Display($"SQLCODE           = {DB.SQLCODE}");

                /*" -8796- DISPLAY 'SQLERRMC          = ' SQLERRMC */
                _.Display($"SQLERRMC          = {DB.SQLERRMC}");

                /*" -8797- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8797- END-IF. */
            }


        }

        [StopWatch]
        /*" R8028-00-GERAR-MAX-OCORR-REPR-DB-SELECT-1 */
        public void R8028_00_GERAR_MAX_OCORR_REPR_DB_SELECT_1()
        {
            /*" -8788- EXEC SQL SELECT VALUE(MAX(NUM_OCORR_HIST), 0) + 1 INTO :VG093-NUM-OCORR-HIST FROM SEGUROS.VG_REPRES_LEGAL WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA WITH UR END-EXEC. */

            var r8028_00_GERAR_MAX_OCORR_REPR_DB_SELECT_1_Query1 = new R8028_00_GERAR_MAX_OCORR_REPR_DB_SELECT_1_Query1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
            };

            var executed_1 = R8028_00_GERAR_MAX_OCORR_REPR_DB_SELECT_1_Query1.Execute(r8028_00_GERAR_MAX_OCORR_REPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG093_NUM_OCORR_HIST, VG093.DCLVG_REPRES_LEGAL.VG093_NUM_OCORR_HIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8028_99_SAIDA*/

        [StopWatch]
        /*" R8029-00-OBTER-CBO-SECTION */
        private void R8029_00_OBTER_CBO_SECTION()
        {
            /*" -8805- MOVE 'R8029-00-OBTER-CBO     ' TO PARAGRAFO. */
            _.Move("R8029-00-OBTER-CBO     ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8806- MOVE 'SELECT SEGUROS.CBO' TO COMANDO. */
            _.Move("SELECT SEGUROS.CBO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8808- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8815- PERFORM R8029_00_OBTER_CBO_DB_SELECT_1 */

            R8029_00_OBTER_CBO_DB_SELECT_1();

            /*" -8818- IF (SQLCODE EQUAL ZEROS AND +100) */

            if ((DB.SQLCODE.In("00", "+100")))
            {

                /*" -8819- DISPLAY 'R8029 - PROBLEMAS SELECT SEGUROS.CBO.' */
                _.Display($"R8029 - PROBLEMAS SELECT SEGUROS.CBO.");

                /*" -8820- DISPLAY 'CBO-COD-CBO       = ' CBO-COD-CBO */
                _.Display($"CBO-COD-CBO       = {CBO.DCLCBO.CBO_COD_CBO}");

                /*" -8821- DISPLAY 'SQLCODE           = ' SQLCODE */
                _.Display($"SQLCODE           = {DB.SQLCODE}");

                /*" -8822- DISPLAY 'SQLERRMC          = ' SQLERRMC */
                _.Display($"SQLERRMC          = {DB.SQLERRMC}");

                /*" -8823- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8823- END-IF. */
            }


        }

        [StopWatch]
        /*" R8029-00-OBTER-CBO-DB-SELECT-1 */
        public void R8029_00_OBTER_CBO_DB_SELECT_1()
        {
            /*" -8815- EXEC SQL SELECT VALUE(DESCR_CBO, ' ' ) INTO :CBO-DESCR-CBO FROM SEGUROS.CBO WHERE COD_CBO = :CBO-COD-CBO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r8029_00_OBTER_CBO_DB_SELECT_1_Query1 = new R8029_00_OBTER_CBO_DB_SELECT_1_Query1()
            {
                CBO_COD_CBO = CBO.DCLCBO.CBO_COD_CBO.ToString(),
            };

            var executed_1 = R8029_00_OBTER_CBO_DB_SELECT_1_Query1.Execute(r8029_00_OBTER_CBO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CBO_DESCR_CBO, CBO.DCLCBO.CBO_DESCR_CBO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8029_SAIDA*/

        [StopWatch]
        /*" R8030-00-VERIFICA-CORRET-SECTION */
        private void R8030_00_VERIFICA_CORRET_SECTION()
        {
            /*" -8831- MOVE 'R8030-00-VERIFICA-CORRET  ' TO PARAGRAFO. */
            _.Move("R8030-00-VERIFICA-CORRET  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8832- MOVE 'SELECT CORRETOR           ' TO COMANDO. */
            _.Move("SELECT CORRETOR           ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8834- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8841- PERFORM R8030_00_VERIFICA_CORRET_DB_SELECT_1 */

            R8030_00_VERIFICA_CORRET_DB_SELECT_1();

            /*" -8844- IF (SQLCODE EQUAL ZEROS AND +100) */

            if ((DB.SQLCODE.In("00", "+100")))
            {

                /*" -8845- DISPLAY 'R8030 - PROBLEMAS SELECT SEGUROS.PRODUTORES.' */
                _.Display($"R8030 - PROBLEMAS SELECT SEGUROS.PRODUTORES.");

                /*" -8846- DISPLAY 'PRODUTOR-COD-PRODUTOR = ' PRODUTOR-COD-PRODUTOR */
                _.Display($"PRODUTOR-COD-PRODUTOR = {PRODUTOR.DCLPRODUTORES.PRODUTOR_COD_PRODUTOR}");

                /*" -8847- DISPLAY 'SQLCODE               = ' SQLCODE */
                _.Display($"SQLCODE               = {DB.SQLCODE}");

                /*" -8848- DISPLAY 'SQLERRMC              = ' SQLERRMC */
                _.Display($"SQLERRMC              = {DB.SQLERRMC}");

                /*" -8849- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8849- END-IF. */
            }


        }

        [StopWatch]
        /*" R8030-00-VERIFICA-CORRET-DB-SELECT-1 */
        public void R8030_00_VERIFICA_CORRET_DB_SELECT_1()
        {
            /*" -8841- EXEC SQL SELECT NOME_PRODUTOR INTO :PRODUTOR-NOME-PRODUTOR FROM SEGUROS.PRODUTORES WHERE COD_PRODUTOR = :PRODUTOR-COD-PRODUTOR FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r8030_00_VERIFICA_CORRET_DB_SELECT_1_Query1 = new R8030_00_VERIFICA_CORRET_DB_SELECT_1_Query1()
            {
                PRODUTOR_COD_PRODUTOR = PRODUTOR.DCLPRODUTORES.PRODUTOR_COD_PRODUTOR.ToString(),
            };

            var executed_1 = R8030_00_VERIFICA_CORRET_DB_SELECT_1_Query1.Execute(r8030_00_VERIFICA_CORRET_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTOR_NOME_PRODUTOR, PRODUTOR.DCLPRODUTORES.PRODUTOR_NOME_PRODUTOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8030_SAIDA*/

        [StopWatch]
        /*" R8031-00-VERIFICA-INDICADOR-SECTION */
        private void R8031_00_VERIFICA_INDICADOR_SECTION()
        {
            /*" -8857- MOVE 'R8031-00-VERIFICA-INDICADOR ' TO PARAGRAFO. */
            _.Move("R8031-00-VERIFICA-INDICADOR ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8858- MOVE 'SELECT INDICADOR          ' TO COMANDO. */
            _.Move("SELECT INDICADOR          ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8860- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8867- PERFORM R8031_00_VERIFICA_INDICADOR_DB_SELECT_1 */

            R8031_00_VERIFICA_INDICADOR_DB_SELECT_1();

            /*" -8870- IF (SQLCODE EQUAL ZEROS AND +100) */

            if ((DB.SQLCODE.In("00", "+100")))
            {

                /*" -8871- DISPLAY 'R8031 - PROBLEMAS SELECT FUNCIONARIOS_CEF.' */
                _.Display($"R8031 - PROBLEMAS SELECT FUNCIONARIOS_CEF.");

                /*" -8872- DISPLAY 'NUM-MATRICULA = ' FUNCICEF-NUM-MATRICULA */
                _.Display($"NUM-MATRICULA = {FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NUM_MATRICULA}");

                /*" -8873- DISPLAY 'SQLCODE       = ' SQLCODE */
                _.Display($"SQLCODE       = {DB.SQLCODE}");

                /*" -8874- DISPLAY 'SQLERRMC      = ' SQLERRMC */
                _.Display($"SQLERRMC      = {DB.SQLERRMC}");

                /*" -8875- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8875- END-IF. */
            }


        }

        [StopWatch]
        /*" R8031-00-VERIFICA-INDICADOR-DB-SELECT-1 */
        public void R8031_00_VERIFICA_INDICADOR_DB_SELECT_1()
        {
            /*" -8867- EXEC SQL SELECT COD_ANGARIADOR INTO :FUNCICEF-COD-ANGARIADOR FROM SEGUROS.FUNCIONARIOS_CEF WHERE NUM_MATRICULA = :FUNCICEF-NUM-MATRICULA FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r8031_00_VERIFICA_INDICADOR_DB_SELECT_1_Query1 = new R8031_00_VERIFICA_INDICADOR_DB_SELECT_1_Query1()
            {
                FUNCICEF_NUM_MATRICULA = FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NUM_MATRICULA.ToString(),
            };

            var executed_1 = R8031_00_VERIFICA_INDICADOR_DB_SELECT_1_Query1.Execute(r8031_00_VERIFICA_INDICADOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FUNCICEF_COD_ANGARIADOR, FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_COD_ANGARIADOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8031_SAIDA*/

        [StopWatch]
        /*" R8032-00-GERAR-MAX-COD-PLANO-SECTION */
        private void R8032_00_GERAR_MAX_COD_PLANO_SECTION()
        {
            /*" -8883- MOVE 'R8032-00-GERAR-MAX-COD-PLANO   ' TO PARAGRAFO. */
            _.Move("R8032-00-GERAR-MAX-COD-PLANO   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8884- MOVE 'SELECT MAX COD PLANO           ' TO COMANDO. */
            _.Move("SELECT MAX COD PLANO           ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8886- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8893- PERFORM R8032_00_GERAR_MAX_COD_PLANO_DB_SELECT_1 */

            R8032_00_GERAR_MAX_COD_PLANO_DB_SELECT_1();

            /*" -8896- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -8897- DISPLAY 'R8032 - PROBLEMAS SELECT MAX PLANOS_VGAP.' */
                _.Display($"R8032 - PROBLEMAS SELECT MAX PLANOS_VGAP.");

                /*" -8898- DISPLAY 'NUM-APOLICE   = ' PLANOVGA-NUM-APOLICE */
                _.Display($"NUM-APOLICE   = {PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_NUM_APOLICE}");

                /*" -8899- DISPLAY 'COD-SUBGRUPO  = ' PLANOVGA-COD-SUBGRUPO */
                _.Display($"COD-SUBGRUPO  = {PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_COD_SUBGRUPO}");

                /*" -8900- DISPLAY 'SQLCODE       = ' SQLCODE */
                _.Display($"SQLCODE       = {DB.SQLCODE}");

                /*" -8901- DISPLAY 'SQLERRMC      = ' SQLERRMC */
                _.Display($"SQLERRMC      = {DB.SQLERRMC}");

                /*" -8902- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8902- END-IF. */
            }


        }

        [StopWatch]
        /*" R8032-00-GERAR-MAX-COD-PLANO-DB-SELECT-1 */
        public void R8032_00_GERAR_MAX_COD_PLANO_DB_SELECT_1()
        {
            /*" -8893- EXEC SQL SELECT VALUE(MAX(COD_PLANO), 0) + 1 INTO :PLANOVGA-COD-PLANO FROM SEGUROS.PLANOS_VGAP WHERE NUM_APOLICE = :PLANOVGA-NUM-APOLICE AND COD_SUBGRUPO = :PLANOVGA-COD-SUBGRUPO WITH UR END-EXEC. */

            var r8032_00_GERAR_MAX_COD_PLANO_DB_SELECT_1_Query1 = new R8032_00_GERAR_MAX_COD_PLANO_DB_SELECT_1_Query1()
            {
                PLANOVGA_COD_SUBGRUPO = PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_COD_SUBGRUPO.ToString(),
                PLANOVGA_NUM_APOLICE = PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R8032_00_GERAR_MAX_COD_PLANO_DB_SELECT_1_Query1.Execute(r8032_00_GERAR_MAX_COD_PLANO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PLANOVGA_COD_PLANO, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_COD_PLANO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8032_99_SAIDA*/

        [StopWatch]
        /*" R8033-00-GERAR-MAX-FX-ETARIA-SECTION */
        private void R8033_00_GERAR_MAX_FX_ETARIA_SECTION()
        {
            /*" -8910- MOVE 'R8033-00-GERAR-MAX-FX-ETARIA   ' TO PARAGRAFO. */
            _.Move("R8033-00-GERAR-MAX-FX-ETARIA   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8911- MOVE 'SELECT MAX FAIXA               ' TO COMANDO. */
            _.Move("SELECT MAX FAIXA               ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8913- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8920- PERFORM R8033_00_GERAR_MAX_FX_ETARIA_DB_SELECT_1 */

            R8033_00_GERAR_MAX_FX_ETARIA_DB_SELECT_1();

            /*" -8923- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -8924- DISPLAY 'R8033 - PROBLEMAS SELECT MAX FAIXA_ETARIA.' */
                _.Display($"R8033 - PROBLEMAS SELECT MAX FAIXA_ETARIA.");

                /*" -8925- DISPLAY 'NUM-APOLICE   = ' FAIXAETA-NUM-APOLICE */
                _.Display($"NUM-APOLICE   = {FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_NUM_APOLICE}");

                /*" -8926- DISPLAY 'COD-SUBGRUPO  = ' FAIXAETA-COD-SUBGRUPO */
                _.Display($"COD-SUBGRUPO  = {FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_COD_SUBGRUPO}");

                /*" -8927- DISPLAY 'SQLCODE       = ' SQLCODE */
                _.Display($"SQLCODE       = {DB.SQLCODE}");

                /*" -8928- DISPLAY 'SQLERRMC      = ' SQLERRMC */
                _.Display($"SQLERRMC      = {DB.SQLERRMC}");

                /*" -8929- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8929- END-IF. */
            }


        }

        [StopWatch]
        /*" R8033-00-GERAR-MAX-FX-ETARIA-DB-SELECT-1 */
        public void R8033_00_GERAR_MAX_FX_ETARIA_DB_SELECT_1()
        {
            /*" -8920- EXEC SQL SELECT VALUE(MAX(FAIXA), 0) + 1 INTO :FAIXAETA-FAIXA FROM SEGUROS.FAIXA_ETARIA WHERE NUM_APOLICE = :FAIXAETA-NUM-APOLICE AND COD_SUBGRUPO = :FAIXAETA-COD-SUBGRUPO WITH UR END-EXEC. */

            var r8033_00_GERAR_MAX_FX_ETARIA_DB_SELECT_1_Query1 = new R8033_00_GERAR_MAX_FX_ETARIA_DB_SELECT_1_Query1()
            {
                FAIXAETA_COD_SUBGRUPO = FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_COD_SUBGRUPO.ToString(),
                FAIXAETA_NUM_APOLICE = FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R8033_00_GERAR_MAX_FX_ETARIA_DB_SELECT_1_Query1.Execute(r8033_00_GERAR_MAX_FX_ETARIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FAIXAETA_FAIXA, FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_FAIXA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8033_99_SAIDA*/

        [StopWatch]
        /*" R8034-00-GERAR-MAX-FX-SALARL-SECTION */
        private void R8034_00_GERAR_MAX_FX_SALARL_SECTION()
        {
            /*" -8937- MOVE 'R8034-00-GERAR-MAX-FX-SALARL   ' TO PARAGRAFO. */
            _.Move("R8034-00-GERAR-MAX-FX-SALARL   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8938- MOVE 'SELECT MAX FAIXA SALARIAL      ' TO COMANDO. */
            _.Move("SELECT MAX FAIXA SALARIAL      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8940- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8947- PERFORM R8034_00_GERAR_MAX_FX_SALARL_DB_SELECT_1 */

            R8034_00_GERAR_MAX_FX_SALARL_DB_SELECT_1();

            /*" -8950- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -8951- DISPLAY 'R8034 - PROBLEMAS SELECT MAX FAIXA_SALARIAL.' */
                _.Display($"R8034 - PROBLEMAS SELECT MAX FAIXA_SALARIAL.");

                /*" -8952- DISPLAY 'NUM-APOLICE   = ' FAIXASAL-NUM-APOLICE */
                _.Display($"NUM-APOLICE   = {FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_NUM_APOLICE}");

                /*" -8953- DISPLAY 'COD-SUBGRUPO  = ' FAIXASAL-COD-SUBGRUPO */
                _.Display($"COD-SUBGRUPO  = {FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_COD_SUBGRUPO}");

                /*" -8954- DISPLAY 'SQLCODE       = ' SQLCODE */
                _.Display($"SQLCODE       = {DB.SQLCODE}");

                /*" -8955- DISPLAY 'SQLERRMC      = ' SQLERRMC */
                _.Display($"SQLERRMC      = {DB.SQLERRMC}");

                /*" -8956- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8956- END-IF. */
            }


        }

        [StopWatch]
        /*" R8034-00-GERAR-MAX-FX-SALARL-DB-SELECT-1 */
        public void R8034_00_GERAR_MAX_FX_SALARL_DB_SELECT_1()
        {
            /*" -8947- EXEC SQL SELECT VALUE(MAX(FAIXA), 0) + 1 INTO :FAIXASAL-FAIXA FROM SEGUROS.FAIXA_SALARIAL WHERE NUM_APOLICE = :FAIXASAL-NUM-APOLICE AND COD_SUBGRUPO = :FAIXASAL-COD-SUBGRUPO WITH UR END-EXEC. */

            var r8034_00_GERAR_MAX_FX_SALARL_DB_SELECT_1_Query1 = new R8034_00_GERAR_MAX_FX_SALARL_DB_SELECT_1_Query1()
            {
                FAIXASAL_COD_SUBGRUPO = FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_COD_SUBGRUPO.ToString(),
                FAIXASAL_NUM_APOLICE = FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_NUM_APOLICE.ToString(),
            };

            var executed_1 = R8034_00_GERAR_MAX_FX_SALARL_DB_SELECT_1_Query1.Execute(r8034_00_GERAR_MAX_FX_SALARL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FAIXASAL_FAIXA, FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_FAIXA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8034_99_SAIDA*/

        [StopWatch]
        /*" R8035-00-GERAR-MAX-COD-CLIENTE-SECTION */
        private void R8035_00_GERAR_MAX_COD_CLIENTE_SECTION()
        {
            /*" -8964- MOVE 'R8035-00-GERAR-MAX-COD-CLIENTE' TO PARAGRAFO. */
            _.Move("R8035-00-GERAR-MAX-COD-CLIENTE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8965- MOVE 'SELECT COD CLIENTE' TO COMANDO. */
            _.Move("SELECT COD CLIENTE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8967- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8972- PERFORM R8035_00_GERAR_MAX_COD_CLIENTE_DB_SELECT_1 */

            R8035_00_GERAR_MAX_COD_CLIENTE_DB_SELECT_1();

            /*" -8975- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -8976- DISPLAY 'R8035 - PROBLEMAS SELECT SEGUROS.NUMERO_OUTROS.' */
                _.Display($"R8035 - PROBLEMAS SELECT SEGUROS.NUMERO_OUTROS.");

                /*" -8977- DISPLAY 'SQLCODE       = ' SQLCODE */
                _.Display($"SQLCODE       = {DB.SQLCODE}");

                /*" -8978- DISPLAY 'SQLERRMC      = ' SQLERRMC */
                _.Display($"SQLERRMC      = {DB.SQLERRMC}");

                /*" -8979- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8981- END-IF. */
            }


            /*" -8985- PERFORM R8035_00_GERAR_MAX_COD_CLIENTE_DB_UPDATE_1 */

            R8035_00_GERAR_MAX_COD_CLIENTE_DB_UPDATE_1();

            /*" -8988- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -8989- DISPLAY 'R8035 - PROBLEMAS UPDATE SEGUROS.NUMERO_OUTROS.' */
                _.Display($"R8035 - PROBLEMAS UPDATE SEGUROS.NUMERO_OUTROS.");

                /*" -8990- DISPLAY 'NUM-CLIENTE   = ' CLIENTES-COD-CLIENTE */
                _.Display($"NUM-CLIENTE   = {CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE}");

                /*" -8991- DISPLAY 'SQLCODE       = ' SQLCODE */
                _.Display($"SQLCODE       = {DB.SQLCODE}");

                /*" -8992- DISPLAY 'SQLERRMC      = ' SQLERRMC */
                _.Display($"SQLERRMC      = {DB.SQLERRMC}");

                /*" -8993- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -8993- END-IF. */
            }


        }

        [StopWatch]
        /*" R8035-00-GERAR-MAX-COD-CLIENTE-DB-SELECT-1 */
        public void R8035_00_GERAR_MAX_COD_CLIENTE_DB_SELECT_1()
        {
            /*" -8972- EXEC SQL SELECT NUM_CLIENTE + 1 INTO :CLIENTES-COD-CLIENTE FROM SEGUROS.NUMERO_OUTROS WITH UR END-EXEC. */

            var r8035_00_GERAR_MAX_COD_CLIENTE_DB_SELECT_1_Query1 = new R8035_00_GERAR_MAX_COD_CLIENTE_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R8035_00_GERAR_MAX_COD_CLIENTE_DB_SELECT_1_Query1.Execute(r8035_00_GERAR_MAX_COD_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);
            }


        }

        [StopWatch]
        /*" R8035-00-GERAR-MAX-COD-CLIENTE-DB-UPDATE-1 */
        public void R8035_00_GERAR_MAX_COD_CLIENTE_DB_UPDATE_1()
        {
            /*" -8985- EXEC SQL UPDATE SEGUROS.NUMERO_OUTROS SET NUM_CLIENTE = :CLIENTES-COD-CLIENTE WHERE 1 = 1 END-EXEC. */

            var r8035_00_GERAR_MAX_COD_CLIENTE_DB_UPDATE_1_Update1 = new R8035_00_GERAR_MAX_COD_CLIENTE_DB_UPDATE_1_Update1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            R8035_00_GERAR_MAX_COD_CLIENTE_DB_UPDATE_1_Update1.Execute(r8035_00_GERAR_MAX_COD_CLIENTE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8035_99_SAIDA*/

        [StopWatch]
        /*" R8036-00-VERIFICA-PROPOSTA-SECTION */
        private void R8036_00_VERIFICA_PROPOSTA_SECTION()
        {
            /*" -9001- MOVE 'R8036-00-VERIFICA-PROPOSTA    ' TO PARAGRAFO. */
            _.Move("R8036-00-VERIFICA-PROPOSTA    ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9002- MOVE 'SELECT VERIFICA PROPOSTA' TO COMANDO. */
            _.Move("SELECT VERIFICA PROPOSTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9004- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9013- PERFORM R8036_00_VERIFICA_PROPOSTA_DB_SELECT_1 */

            R8036_00_VERIFICA_PROPOSTA_DB_SELECT_1();

            /*" -9016- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -9017- DISPLAY 'R8036 - PROBLEMAS SELECT PF_PROC_PROPOSTA.' */
                _.Display($"R8036 - PROBLEMAS SELECT PF_PROC_PROPOSTA.");

                /*" -9018- DISPLAY 'NUM_PROPOSTA  = ' PF087-NUM-PROPOSTA */
                _.Display($"NUM_PROPOSTA  = {PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_PROPOSTA}");

                /*" -9019- DISPLAY 'SIGLA_ARQUIVO = PORTALPJ' */
                _.Display($"SIGLA_ARQUIVO = PORTALPJ");

                /*" -9020- DISPLAY 'STA_PROCESSAM = P' */
                _.Display($"STA_PROCESSAM = P");

                /*" -9021- DISPLAY 'SQLCODE       = ' SQLCODE */
                _.Display($"SQLCODE       = {DB.SQLCODE}");

                /*" -9022- DISPLAY 'SQLERRMC      = ' SQLERRMC */
                _.Display($"SQLERRMC      = {DB.SQLERRMC}");

                /*" -9023- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -9023- END-IF. */
            }


        }

        [StopWatch]
        /*" R8036-00-VERIFICA-PROPOSTA-DB-SELECT-1 */
        public void R8036_00_VERIFICA_PROPOSTA_DB_SELECT_1()
        {
            /*" -9013- EXEC SQL SELECT NUM_PROPOSTA INTO :PF087-NUM-PROPOSTA FROM SEGUROS.PF_PROC_PROPOSTA WHERE NUM_PROPOSTA = :PF087-NUM-PROPOSTA AND SIGLA_ARQUIVO = 'PORTALPJ' AND STA_PROCESSAMENTO = 'P' FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var r8036_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1 = new R8036_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1()
            {
                PF087_NUM_PROPOSTA = PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_PROPOSTA.ToString(),
            };

            var executed_1 = R8036_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1.Execute(r8036_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PF087_NUM_PROPOSTA, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8036_99_SAIDA*/

        [StopWatch]
        /*" R8037-00-VERIFICA-REPRES-LEGAL-SECTION */
        private void R8037_00_VERIFICA_REPRES_LEGAL_SECTION()
        {
            /*" -9031- MOVE 'R8037-00-VERIFICA-REPRES-LEGAL ' TO PARAGRAFO. */
            _.Move("R8037-00-VERIFICA-REPRES-LEGAL ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9032- MOVE 'SELECT VERIFICA REPRES LEGAL   ' TO COMANDO. */
            _.Move("SELECT VERIFICA REPRES LEGAL   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9034- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9040- PERFORM R8037_00_VERIFICA_REPRES_LEGAL_DB_SELECT_1 */

            R8037_00_VERIFICA_REPRES_LEGAL_DB_SELECT_1();

            /*" -9043- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -9044- DISPLAY 'R8037-PROBLEMAS SELECT SEGUROS.VG_REPRES_LEGAL.' */
                _.Display($"R8037-PROBLEMAS SELECT SEGUROS.VG_REPRES_LEGAL.");

                /*" -9045- DISPLAY 'VG093-COD-PESSOA = ' VG093-COD-PESSOA */
                _.Display($"VG093-COD-PESSOA = {VG093.DCLVG_REPRES_LEGAL.VG093_COD_PESSOA}");

                /*" -9046- DISPLAY 'SQLCODE          = ' SQLCODE */
                _.Display($"SQLCODE          = {DB.SQLCODE}");

                /*" -9047- DISPLAY 'SQLERRMC         = ' SQLERRMC */
                _.Display($"SQLERRMC         = {DB.SQLERRMC}");

                /*" -9048- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -9048- END-IF. */
            }


        }

        [StopWatch]
        /*" R8037-00-VERIFICA-REPRES-LEGAL-DB-SELECT-1 */
        public void R8037_00_VERIFICA_REPRES_LEGAL_DB_SELECT_1()
        {
            /*" -9040- EXEC SQL SELECT VALUE(MAX(NUM_OCORR_HIST), 0) INTO :VG093-NUM-OCORR-HIST FROM SEGUROS.VG_REPRES_LEGAL WHERE COD_PESSOA = :VG093-COD-PESSOA WITH UR END-EXEC. */

            var r8037_00_VERIFICA_REPRES_LEGAL_DB_SELECT_1_Query1 = new R8037_00_VERIFICA_REPRES_LEGAL_DB_SELECT_1_Query1()
            {
                VG093_COD_PESSOA = VG093.DCLVG_REPRES_LEGAL.VG093_COD_PESSOA.ToString(),
            };

            var executed_1 = R8037_00_VERIFICA_REPRES_LEGAL_DB_SELECT_1_Query1.Execute(r8037_00_VERIFICA_REPRES_LEGAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG093_NUM_OCORR_HIST, VG093.DCLVG_REPRES_LEGAL.VG093_NUM_OCORR_HIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8037_99_SAIDA*/

        [StopWatch]
        /*" R8038-00-UPDATE-END-ENDOSSOS-SECTION */
        private void R8038_00_UPDATE_END_ENDOSSOS_SECTION()
        {
            /*" -9056- MOVE 'R8038-00-UPDATE-END-ENDOSSOS' TO PARAGRAFO. */
            _.Move("R8038-00-UPDATE-END-ENDOSSOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9057- MOVE 'UPDATE ENDERECOS ENDOSSO    ' TO COMANDO. */
            _.Move("UPDATE ENDERECOS ENDOSSO    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9059- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9064- PERFORM R8038_00_UPDATE_END_ENDOSSOS_DB_UPDATE_1 */

            R8038_00_UPDATE_END_ENDOSSOS_DB_UPDATE_1();

            /*" -9067- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -9068- DISPLAY 'R8038 - PROBLEMAS UPDATE SEGUROS.ENDOSSOS.' */
                _.Display($"R8038 - PROBLEMAS UPDATE SEGUROS.ENDOSSOS.");

                /*" -9069- DISPLAY 'NUM-APOLICE      = ' SUBGVGAP-NUM-APOLICE */
                _.Display($"NUM-APOLICE      = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                /*" -9070- DISPLAY 'NUM-ENDOSSO      = 0' */
                _.Display($"NUM-ENDOSSO      = 0");

                /*" -9071- DISPLAY 'OCORR-ENDERECO   = ' ENDERECO-OCORR-ENDERECO */
                _.Display($"OCORR-ENDERECO   = {ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO}");

                /*" -9072- DISPLAY 'SQLCODE          = ' SQLCODE */
                _.Display($"SQLCODE          = {DB.SQLCODE}");

                /*" -9073- DISPLAY 'SQLERRMC         = ' SQLERRMC */
                _.Display($"SQLERRMC         = {DB.SQLERRMC}");

                /*" -9074- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -9074- END-IF. */
            }


        }

        [StopWatch]
        /*" R8038-00-UPDATE-END-ENDOSSOS-DB-UPDATE-1 */
        public void R8038_00_UPDATE_END_ENDOSSOS_DB_UPDATE_1()
        {
            /*" -9064- EXEC SQL UPDATE SEGUROS.ENDOSSOS SET OCORR_ENDERECO = :ENDERECO-OCORR-ENDERECO WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND NUM_ENDOSSO = 0 END-EXEC. */

            var r8038_00_UPDATE_END_ENDOSSOS_DB_UPDATE_1_Update1 = new R8038_00_UPDATE_END_ENDOSSOS_DB_UPDATE_1_Update1()
            {
                ENDERECO_OCORR_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            R8038_00_UPDATE_END_ENDOSSOS_DB_UPDATE_1_Update1.Execute(r8038_00_UPDATE_END_ENDOSSOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8038_99_SAIDA*/

        [StopWatch]
        /*" DB010-ACESSA-ENDOSSOS-SECTION */
        private void DB010_ACESSA_ENDOSSOS_SECTION()
        {
            /*" -9083- MOVE 'DB010-ACESSA-ENDOSSOS' TO PARAGRAFO. */
            _.Move("DB010-ACESSA-ENDOSSOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9084- MOVE 'ACESSA ENDOSSOS' TO COMANDO. */
            _.Move("ACESSA ENDOSSOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9086- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9087- MOVE FONTES-ORGAO-EMISSOR TO ENDOSSOS-COD-FONTE */
            _.Move(FONTES.DCLFONTES.FONTES_ORGAO_EMISSOR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);

            /*" -9089- MOVE FONTES-ULT-PROP-AUTOMAT TO ENDOSSOS-NUM-PROPOSTA */
            _.Move(FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA);

            /*" -9095- PERFORM DB010_ACESSA_ENDOSSOS_DB_SELECT_1 */

            DB010_ACESSA_ENDOSSOS_DB_SELECT_1();

            /*" -9102- DISPLAY 'DB010-SELECT SEGUROS.ENDOSSOS:' ' SQLCODE=' SQLCODE ' COD-FONTE=' ENDOSSOS-COD-FONTE ' NUM-PROPOSTA=' ENDOSSOS-NUM-PROPOSTA */

            $"DB010-SELECT SEGUROS.ENDOSSOS: SQLCODE={DB.SQLCODE} COD-FONTE={ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE} NUM-PROPOSTA={ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA}"
            .Display();

            /*" -9103- IF SQLCODE NOT = 000 AND +100 */

            if (!DB.SQLCODE.In("000", "+100"))
            {

                /*" -9104- DISPLAY 'DB010 - PROBLEMAS SELECT SEGUROS.ENDOSSOS.' */
                _.Display($"DB010 - PROBLEMAS SELECT SEGUROS.ENDOSSOS.");

                /*" -9105- DISPLAY 'COD-FONTE    = ' FONTES-COD-FONTE */
                _.Display($"COD-FONTE    = {FONTES.DCLFONTES.FONTES_COD_FONTE}");

                /*" -9106- DISPLAY 'NUM-PROPOSTA = ' ENDOSSOS-NUM-PROPOSTA */
                _.Display($"NUM-PROPOSTA = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA}");

                /*" -9107- DISPLAY 'SQLCODE      = ' SQLCODE */
                _.Display($"SQLCODE      = {DB.SQLCODE}");

                /*" -9108- DISPLAY 'SQLERRMC     = ' SQLERRMC */
                _.Display($"SQLERRMC     = {DB.SQLERRMC}");

                /*" -9109- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -9110- END-IF */
            }


            /*" -9110- . */

        }

        [StopWatch]
        /*" DB010-ACESSA-ENDOSSOS-DB-SELECT-1 */
        public void DB010_ACESSA_ENDOSSOS_DB_SELECT_1()
        {
            /*" -9095- EXEC SQL SELECT COD_FONTE INTO :ENDOSSOS-COD-FONTE FROM SEGUROS.ENDOSSOS WHERE COD_FONTE = :ENDOSSOS-COD-FONTE AND NUM_PROPOSTA = :ENDOSSOS-NUM-PROPOSTA END-EXEC. */

            var dB010_ACESSA_ENDOSSOS_DB_SELECT_1_Query1 = new DB010_ACESSA_ENDOSSOS_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_PROPOSTA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA.ToString(),
                ENDOSSOS_COD_FONTE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE.ToString(),
            };

            var executed_1 = DB010_ACESSA_ENDOSSOS_DB_SELECT_1_Query1.Execute(dB010_ACESSA_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_COD_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: DB010_00_SAIDA*/

        [StopWatch]
        /*" DB020-UPDATE-FONTES-SECTION */
        private void DB020_UPDATE_FONTES_SECTION()
        {
            /*" -9117- MOVE 'DB020-UDPATE-FONTES' TO PARAGRAFO. */
            _.Move("DB020-UDPATE-FONTES", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9118- MOVE 'UPDATE FONTES' TO COMANDO. */
            _.Move("UPDATE FONTES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9120- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9124- PERFORM DB020_UPDATE_FONTES_DB_UPDATE_1 */

            DB020_UPDATE_FONTES_DB_UPDATE_1();

            /*" -9131- DISPLAY 'DB020-UPDATED SEGUROS.FONTES:' ' SQLCODE=' SQLCODE ' COD-FONTE=' FONTES-COD-FONTE ' ULT-PROP-AUTOMAT=' FONTES-ULT-PROP-AUTOMAT */

            $"DB020-UPDATED SEGUROS.FONTES: SQLCODE={DB.SQLCODE} COD-FONTE={FONTES.DCLFONTES.FONTES_COD_FONTE} ULT-PROP-AUTOMAT={FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT}"
            .Display();

            /*" -9132- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -9133- DISPLAY 'DB020 - PROBLEMAS UPDATE SEGUROS.FONTES.' */
                _.Display($"DB020 - PROBLEMAS UPDATE SEGUROS.FONTES.");

                /*" -9134- DISPLAY 'COD-FONTE.......= ' FONTES-COD-FONTE */
                _.Display($"COD-FONTE.......= {FONTES.DCLFONTES.FONTES_COD_FONTE}");

                /*" -9135- DISPLAY 'ULT-PROP-AUTOMAT= ' FONTES-ULT-PROP-AUTOMAT */
                _.Display($"ULT-PROP-AUTOMAT= {FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT}");

                /*" -9136- DISPLAY 'SQLCODE         = ' SQLCODE */
                _.Display($"SQLCODE         = {DB.SQLCODE}");

                /*" -9137- DISPLAY 'SQLERRMC        = ' SQLERRMC */
                _.Display($"SQLERRMC        = {DB.SQLERRMC}");

                /*" -9138- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -9139- END-IF */
            }


            /*" -9139- . */

        }

        [StopWatch]
        /*" DB020-UPDATE-FONTES-DB-UPDATE-1 */
        public void DB020_UPDATE_FONTES_DB_UPDATE_1()
        {
            /*" -9124- EXEC SQL UPDATE SEGUROS.FONTES SET ULT_PROP_AUTOMAT = :FONTES-ULT-PROP-AUTOMAT WHERE COD_FONTE = :FONTES-COD-FONTE END-EXEC */

            var dB020_UPDATE_FONTES_DB_UPDATE_1_Update1 = new DB020_UPDATE_FONTES_DB_UPDATE_1_Update1()
            {
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                FONTES_COD_FONTE = FONTES.DCLFONTES.FONTES_COD_FONTE.ToString(),
            };

            DB020_UPDATE_FONTES_DB_UPDATE_1_Update1.Execute(dB020_UPDATE_FONTES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: DB020_SAIDA*/

        [StopWatch]
        /*" DB030-INSERT-VG-COMPL-CLI-EMP-SECTION */
        private void DB030_INSERT_VG_COMPL_CLI_EMP_SECTION()
        {
            /*" -9147- MOVE 'DB030-INSERT-VG-COMPL-CLI-EMP' TO PARAGRAFO */
            _.Move("DB030-INSERT-VG-COMPL-CLI-EMP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9149- MOVE 'INSERT VG_COMPL_CLI_EMP' TO COMANDO */
            _.Move("INSERT VG_COMPL_CLI_EMP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9150- MOVE CLIENTES-COD-CLIENTE TO VG092-COD-CLIENTE */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE, VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CLIENTE);

            /*" -9151- MOVE '0001-01-01' TO VG092-DTA-FAT-ANUAL */
            _.Move("0001-01-01", VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_FAT_ANUAL);

            /*" -9152- MOVE R1-VAL-FAT-ANUAL TO VG092-VLR-FAT-ANUAL */
            _.Move(REG_R1_SUBGRUPO.R1_VAL_FAT_ANUAL, VG092.DCLVG_COMPL_CLI_EMP.VG092_VLR_FAT_ANUAL);

            /*" -9156- STRING R1-DTA-CONST-EMP(05:04) '-' R1-DTA-CONST-EMP(03:02) '-' R1-DTA-CONST-EMP(01:02) DELIMITED BY SIZE INTO VG092-DTA-CONSTITUICAO */
            #region STRING
            var spl13 = REG_R1_SUBGRUPO.R1_DTA_CONST_EMP.Substring(05, 04).GetMoveValues();
            spl13 += "-";
            var spl14 = REG_R1_SUBGRUPO.R1_DTA_CONST_EMP.Substring(03, 02).GetMoveValues();
            spl14 += "-";
            var spl15 = REG_R1_SUBGRUPO.R1_DTA_CONST_EMP.Substring(01, 02).GetMoveValues();
            var results16 = spl13 + spl14 + spl15;
            _.Move(results16, VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_CONSTITUICAO);
            #endregion

            /*" -9158- MOVE R1-COD-CNAE-ATIVIDADE TO VG092-COD-CNAE-ATIVIDADE */
            _.Move(REG_R1_SUBGRUPO.R1_COD_CNAE_ATIVIDADE, VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CNAE_ATIVIDADE);

            /*" -9171- PERFORM DB030_INSERT_VG_COMPL_CLI_EMP_DB_INSERT_1 */

            DB030_INSERT_VG_COMPL_CLI_EMP_DB_INSERT_1();

            /*" -9174- IF (SQLCODE NOT EQUAL 000 AND -803) */

            if ((!DB.SQLCODE.In("000", "-803")))
            {

                /*" -9175- DISPLAY 'DB030 - PROBLEMAS INSERT VG_COMPL_CLI_EMP.' */
                _.Display($"DB030 - PROBLEMAS INSERT VG_COMPL_CLI_EMP.");

                /*" -9176- DISPLAY 'COD_CLIENTE       =' VG092-COD-CLIENTE */
                _.Display($"COD_CLIENTE       ={VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CLIENTE}");

                /*" -9177- DISPLAY 'DTA_FAT_ANUAL     =' VG092-DTA-FAT-ANUAL */
                _.Display($"DTA_FAT_ANUAL     ={VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_FAT_ANUAL}");

                /*" -9178- DISPLAY 'VLR_FAT_ANUAL     =' VG092-VLR-FAT-ANUAL */
                _.Display($"VLR_FAT_ANUAL     ={VG092.DCLVG_COMPL_CLI_EMP.VG092_VLR_FAT_ANUAL}");

                /*" -9179- DISPLAY 'DTA_CONSTITUICAO  =' VG092-DTA-CONSTITUICAO */
                _.Display($"DTA_CONSTITUICAO  ={VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_CONSTITUICAO}");

                /*" -9180- DISPLAY 'COD-CNAE-ATIVIDADE=' VG092-COD-CNAE-ATIVIDADE */
                _.Display($"COD-CNAE-ATIVIDADE={VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CNAE_ATIVIDADE}");

                /*" -9181- DISPLAY 'SQLCODE           =' SQLCODE */
                _.Display($"SQLCODE           ={DB.SQLCODE}");

                /*" -9182- DISPLAY 'SQLERRMC          =' SQLERRMC */
                _.Display($"SQLERRMC          ={DB.SQLERRMC}");

                /*" -9183- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -9184- END-IF. */
            }


            /*" -9185- IF SQLCODE = 000 */

            if (DB.SQLCODE == 000)
            {

                /*" -9191- DISPLAY 'DB030 - INSERT VG_COMPL_CLI_EMP.' ' COD_CLIENTE       =' VG092-COD-CLIENTE ' DTA_FAT_ANUAL     =' VG092-DTA-FAT-ANUAL ' VLR_FAT_ANUAL     =' VG092-VLR-FAT-ANUAL ' DTA_CONSTITUICAO  =' VG092-DTA-CONSTITUICAO ' COD-CNAE-ATIVIDADE=' VG092-COD-CNAE-ATIVIDADE */

                $"DB030 - INSERT VG_COMPL_CLI_EMP. COD_CLIENTE       ={VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CLIENTE} DTA_FAT_ANUAL     ={VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_FAT_ANUAL} VLR_FAT_ANUAL     ={VG092.DCLVG_COMPL_CLI_EMP.VG092_VLR_FAT_ANUAL} DTA_CONSTITUICAO  ={VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_CONSTITUICAO} COD-CNAE-ATIVIDADE={VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CNAE_ATIVIDADE}"
                .Display();

                /*" -9192- END-IF. */
            }


        }

        [StopWatch]
        /*" DB030-INSERT-VG-COMPL-CLI-EMP-DB-INSERT-1 */
        public void DB030_INSERT_VG_COMPL_CLI_EMP_DB_INSERT_1()
        {
            /*" -9171- EXEC SQL INSERT INTO SEGUROS.VG_COMPL_CLI_EMP ( COD_CLIENTE , DTA_FAT_ANUAL , VLR_FAT_ANUAL , DTA_CONSTITUICAO , COD_CNAE_ATIVIDADE ) VALUES( :VG092-COD-CLIENTE , :VG092-DTA-FAT-ANUAL , :VG092-VLR-FAT-ANUAL , :VG092-DTA-CONSTITUICAO , :VG092-COD-CNAE-ATIVIDADE ) END-EXEC */

            var dB030_INSERT_VG_COMPL_CLI_EMP_DB_INSERT_1_Insert1 = new DB030_INSERT_VG_COMPL_CLI_EMP_DB_INSERT_1_Insert1()
            {
                VG092_COD_CLIENTE = VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CLIENTE.ToString(),
                VG092_DTA_FAT_ANUAL = VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_FAT_ANUAL.ToString(),
                VG092_VLR_FAT_ANUAL = VG092.DCLVG_COMPL_CLI_EMP.VG092_VLR_FAT_ANUAL.ToString(),
                VG092_DTA_CONSTITUICAO = VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_CONSTITUICAO.ToString(),
                VG092_COD_CNAE_ATIVIDADE = VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CNAE_ATIVIDADE.ToString(),
            };

            DB030_INSERT_VG_COMPL_CLI_EMP_DB_INSERT_1_Insert1.Execute(dB030_INSERT_VG_COMPL_CLI_EMP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: DB030_SAIDA*/

        [StopWatch]
        /*" DB035-UPDATE-VG-COMPL-CLI-EMP-SECTION */
        private void DB035_UPDATE_VG_COMPL_CLI_EMP_SECTION()
        {
            /*" -9200- MOVE 'DB035-UPDATE-VG-COMPL-CLI-EMP' TO PARAGRAFO */
            _.Move("DB035-UPDATE-VG-COMPL-CLI-EMP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9202- MOVE 'UPDATE VG_COMPL_CLI_EMP' TO COMANDO */
            _.Move("UPDATE VG_COMPL_CLI_EMP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9203- MOVE CLIENTES-COD-CLIENTE TO VG092-COD-CLIENTE */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE, VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CLIENTE);

            /*" -9204- MOVE '0001-01-01' TO VG092-DTA-FAT-ANUAL */
            _.Move("0001-01-01", VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_FAT_ANUAL);

            /*" -9205- MOVE R1-VAL-FAT-ANUAL TO VG092-VLR-FAT-ANUAL */
            _.Move(REG_R1_SUBGRUPO.R1_VAL_FAT_ANUAL, VG092.DCLVG_COMPL_CLI_EMP.VG092_VLR_FAT_ANUAL);

            /*" -9209- STRING R1-DTA-CONST-EMP(05:04) '-' R1-DTA-CONST-EMP(03:02) '-' R1-DTA-CONST-EMP(01:02) DELIMITED BY SIZE INTO VG092-DTA-CONSTITUICAO */
            #region STRING
            var spl16 = REG_R1_SUBGRUPO.R1_DTA_CONST_EMP.Substring(05, 04).GetMoveValues();
            spl16 += "-";
            var spl17 = REG_R1_SUBGRUPO.R1_DTA_CONST_EMP.Substring(03, 02).GetMoveValues();
            spl17 += "-";
            var spl18 = REG_R1_SUBGRUPO.R1_DTA_CONST_EMP.Substring(01, 02).GetMoveValues();
            var results19 = spl16 + spl17 + spl18;
            _.Move(results19, VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_CONSTITUICAO);
            #endregion

            /*" -9211- MOVE R1-COD-CNAE-ATIVIDADE TO VG092-COD-CNAE-ATIVIDADE */
            _.Move(REG_R1_SUBGRUPO.R1_COD_CNAE_ATIVIDADE, VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CNAE_ATIVIDADE);

            /*" -9218- PERFORM DB035_UPDATE_VG_COMPL_CLI_EMP_DB_UPDATE_1 */

            DB035_UPDATE_VG_COMPL_CLI_EMP_DB_UPDATE_1();

            /*" -9221- IF (SQLCODE NOT EQUAL 000) */

            if ((DB.SQLCODE != 000))
            {

                /*" -9222- DISPLAY 'DB035 - PROBLEMAS UPDATE VG_COMPL_CLI_EMP.' */
                _.Display($"DB035 - PROBLEMAS UPDATE VG_COMPL_CLI_EMP.");

                /*" -9223- DISPLAY 'COD_CLIENTE       =' VG092-COD-CLIENTE */
                _.Display($"COD_CLIENTE       ={VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CLIENTE}");

                /*" -9224- DISPLAY 'DTA_FAT_ANUAL     =' VG092-DTA-FAT-ANUAL */
                _.Display($"DTA_FAT_ANUAL     ={VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_FAT_ANUAL}");

                /*" -9225- DISPLAY 'VLR_FAT_ANUAL     =' VG092-VLR-FAT-ANUAL */
                _.Display($"VLR_FAT_ANUAL     ={VG092.DCLVG_COMPL_CLI_EMP.VG092_VLR_FAT_ANUAL}");

                /*" -9226- DISPLAY 'DTA_CONSTITUICAO  =' VG092-DTA-CONSTITUICAO */
                _.Display($"DTA_CONSTITUICAO  ={VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_CONSTITUICAO}");

                /*" -9227- DISPLAY 'COD-CNAE-ATIVIDADE=' VG092-COD-CNAE-ATIVIDADE */
                _.Display($"COD-CNAE-ATIVIDADE={VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CNAE_ATIVIDADE}");

                /*" -9228- DISPLAY 'SQLCODE           =' SQLCODE */
                _.Display($"SQLCODE           ={DB.SQLCODE}");

                /*" -9229- DISPLAY 'SQLERRMC          =' SQLERRMC */
                _.Display($"SQLERRMC          ={DB.SQLERRMC}");

                /*" -9230- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -9232- END-IF. */
            }


            /*" -9233- DISPLAY 'DB035 - UPDATE VG_COMPL_CLI_EMP.' */
            _.Display($"DB035 - UPDATE VG_COMPL_CLI_EMP.");

            /*" -9234- DISPLAY 'COD_CLIENTE       =' VG092-COD-CLIENTE */
            _.Display($"COD_CLIENTE       ={VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CLIENTE}");

            /*" -9235- DISPLAY 'DTA_FAT_ANUAL     =' VG092-DTA-FAT-ANUAL */
            _.Display($"DTA_FAT_ANUAL     ={VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_FAT_ANUAL}");

            /*" -9236- DISPLAY 'VLR_FAT_ANUAL     =' VG092-VLR-FAT-ANUAL */
            _.Display($"VLR_FAT_ANUAL     ={VG092.DCLVG_COMPL_CLI_EMP.VG092_VLR_FAT_ANUAL}");

            /*" -9237- DISPLAY 'DTA_CONSTITUICAO  =' VG092-DTA-CONSTITUICAO */
            _.Display($"DTA_CONSTITUICAO  ={VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_CONSTITUICAO}");

            /*" -9237- DISPLAY 'COD-CNAE-ATIVIDADE=' VG092-COD-CNAE-ATIVIDADE. */
            _.Display($"COD-CNAE-ATIVIDADE={VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CNAE_ATIVIDADE}");

        }

        [StopWatch]
        /*" DB035-UPDATE-VG-COMPL-CLI-EMP-DB-UPDATE-1 */
        public void DB035_UPDATE_VG_COMPL_CLI_EMP_DB_UPDATE_1()
        {
            /*" -9218- EXEC SQL UPDATE SEGUROS.VG_COMPL_CLI_EMP SET VLR_FAT_ANUAL = :VG092-VLR-FAT-ANUAL , DTA_CONSTITUICAO = :VG092-DTA-CONSTITUICAO , COD_CNAE_ATIVIDADE = :VG092-COD-CNAE-ATIVIDADE WHERE COD_CLIENTE = :VG092-COD-CLIENTE AND DTA_FAT_ANUAL = :VG092-DTA-FAT-ANUAL END-EXEC */

            var dB035_UPDATE_VG_COMPL_CLI_EMP_DB_UPDATE_1_Update1 = new DB035_UPDATE_VG_COMPL_CLI_EMP_DB_UPDATE_1_Update1()
            {
                VG092_COD_CNAE_ATIVIDADE = VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CNAE_ATIVIDADE.ToString(),
                VG092_DTA_CONSTITUICAO = VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_CONSTITUICAO.ToString(),
                VG092_VLR_FAT_ANUAL = VG092.DCLVG_COMPL_CLI_EMP.VG092_VLR_FAT_ANUAL.ToString(),
                VG092_DTA_FAT_ANUAL = VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_FAT_ANUAL.ToString(),
                VG092_COD_CLIENTE = VG092.DCLVG_COMPL_CLI_EMP.VG092_COD_CLIENTE.ToString(),
            };

            DB035_UPDATE_VG_COMPL_CLI_EMP_DB_UPDATE_1_Update1.Execute(dB035_UPDATE_VG_COMPL_CLI_EMP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: DB035_SAIDA*/

        [StopWatch]
        /*" DB040-ACESSA-CNAE-ATIVIDADE-SECTION */
        private void DB040_ACESSA_CNAE_ATIVIDADE_SECTION()
        {
            /*" -9246- MOVE 'DB040-ACESSA-CNAE-ATIVIDADE' TO PARAGRAFO */
            _.Move("DB040-ACESSA-CNAE-ATIVIDADE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9248- MOVE 'ACESSA GE_CNAE_ATIVIDADE' TO COMANDO */
            _.Move("ACESSA GE_CNAE_ATIVIDADE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9250- MOVE R1-COD-CNAE-ATIVIDADE TO GE374-COD-CNAE-ATIVIDADE */
            _.Move(REG_R1_SUBGRUPO.R1_COD_CNAE_ATIVIDADE, GE374.DCLGE_CNAE_ATIVIDADE.GE374_COD_CNAE_ATIVIDADE);

            /*" -9256- PERFORM DB040_ACESSA_CNAE_ATIVIDADE_DB_SELECT_1 */

            DB040_ACESSA_CNAE_ATIVIDADE_DB_SELECT_1();

            /*" -9259- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -9260- DISPLAY 'DB040 - PROBLEMAS SELECT GE_CNAE_ATIVIDADE.' */
                _.Display($"DB040 - PROBLEMAS SELECT GE_CNAE_ATIVIDADE.");

                /*" -9261- DISPLAY 'COD-CNAE-ATIVIDADE=' GE374-COD-CNAE-ATIVIDADE */
                _.Display($"COD-CNAE-ATIVIDADE={GE374.DCLGE_CNAE_ATIVIDADE.GE374_COD_CNAE_ATIVIDADE}");

                /*" -9262- DISPLAY 'SQLCODE           =' SQLCODE */
                _.Display($"SQLCODE           ={DB.SQLCODE}");

                /*" -9263- DISPLAY 'SQLERRMC          =' SQLERRMC */
                _.Display($"SQLERRMC          ={DB.SQLERRMC}");

                /*" -9264- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -9265- END-IF. */
            }


            /*" -9266- DISPLAY 'DB040 - SELECT GE_CNAE_ATIVIDADE.' */
            _.Display($"DB040 - SELECT GE_CNAE_ATIVIDADE.");

            /*" -9266- DISPLAY 'COD-CNAE-ATIVIDADE=' GE374-COD-CNAE-ATIVIDADE. */
            _.Display($"COD-CNAE-ATIVIDADE={GE374.DCLGE_CNAE_ATIVIDADE.GE374_COD_CNAE_ATIVIDADE}");

        }

        [StopWatch]
        /*" DB040-ACESSA-CNAE-ATIVIDADE-DB-SELECT-1 */
        public void DB040_ACESSA_CNAE_ATIVIDADE_DB_SELECT_1()
        {
            /*" -9256- EXEC SQL SELECT COD_CNAE_ATIVIDADE INTO :GE374-COD-CNAE-ATIVIDADE FROM SEGUROS.GE_CNAE_ATIVIDADE WHERE COD_CNAE_ATIVIDADE = :GE374-COD-CNAE-ATIVIDADE WITH UR END-EXEC */

            var dB040_ACESSA_CNAE_ATIVIDADE_DB_SELECT_1_Query1 = new DB040_ACESSA_CNAE_ATIVIDADE_DB_SELECT_1_Query1()
            {
                GE374_COD_CNAE_ATIVIDADE = GE374.DCLGE_CNAE_ATIVIDADE.GE374_COD_CNAE_ATIVIDADE.ToString(),
            };

            var executed_1 = DB040_ACESSA_CNAE_ATIVIDADE_DB_SELECT_1_Query1.Execute(dB040_ACESSA_CNAE_ATIVIDADE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE374_COD_CNAE_ATIVIDADE, GE374.DCLGE_CNAE_ATIVIDADE.GE374_COD_CNAE_ATIVIDADE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: DB040_SAIDA*/

        [StopWatch]
        /*" DB050-UPDATE-CLIENTES-SECTION */
        private void DB050_UPDATE_CLIENTES_SECTION()
        {
            /*" -9273- MOVE 'DB050-UPDATE-CLIENTES' TO PARAGRAFO */
            _.Move("DB050-UPDATE-CLIENTES", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9276- MOVE 'UPDATE CLIENTES' TO COMANDO */
            _.Move("UPDATE CLIENTES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9278- MOVE R1-COD-PORTE-EMP TO CLIENTES-COD-PORTE-EMP */
            _.Move(REG_R1_SUBGRUPO.R1_COD_PORTE_EMP, CLIENTES.DCLCLIENTES.CLIENTES_COD_PORTE_EMP);

            /*" -9282- PERFORM DB050_UPDATE_CLIENTES_DB_UPDATE_1 */

            DB050_UPDATE_CLIENTES_DB_UPDATE_1();

            /*" -9285- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -9286- DISPLAY 'VG2600B - FIM ANORMAL' */
                _.Display($"VG2600B - FIM ANORMAL");

                /*" -9287- DISPLAY '          ERRO UPDATE TABELA CLIENTES     ' */
                _.Display($"          ERRO UPDATE TABELA CLIENTES     ");

                /*" -9289- DISPLAY '          COD CLIENTE...................  ' CLIENTES-COD-CLIENTE */
                _.Display($"          COD CLIENTE...................  {CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE}");

                /*" -9291- DISPLAY '          NOME RAZAO....................  ' CLIENTES-NOME-RAZAO */
                _.Display($"          NOME RAZAO....................  {CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO}");

                /*" -9293- DISPLAY '          TIPO PESSOA...................  ' CLIENTES-TIPO-PESSOA */
                _.Display($"          TIPO PESSOA...................  {CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA}");

                /*" -9295- DISPLAY '          CGCCPF........................  ' CLIENTES-CGCCPF */
                _.Display($"          CGCCPF........................  {CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF}");

                /*" -9297- DISPLAY '          COD-PORTE-EMP.................  ' CLIENTES-COD-PORTE-EMP */
                _.Display($"          COD-PORTE-EMP.................  {CLIENTES.DCLCLIENTES.CLIENTES_COD_PORTE_EMP}");

                /*" -9299- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -9300- DISPLAY '          SQLERRMC<' SQLERRMC '>' */

                $"          SQLERRMC<{DB.SQLERRMC}>"
                .Display();

                /*" -9301- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -9302- END-IF. */
            }


            /*" -9303- DISPLAY 'DB050-UPDATE-CLIENTES' */
            _.Display($"DB050-UPDATE-CLIENTES");

            /*" -9304- DISPLAY 'CLIENTES-CGCCPF = ' CLIENTES-CGCCPF. */
            _.Display($"CLIENTES-CGCCPF = {CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF}");

            /*" -9305- DISPLAY 'CLIENTES-COD-CLIENTE=' CLIENTES-COD-CLIENTE */
            _.Display($"CLIENTES-COD-CLIENTE={CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE}");

            /*" -9305- DISPLAY 'CLIENTES-COD-PORTE-EMP=' CLIENTES-COD-PORTE-EMP. */
            _.Display($"CLIENTES-COD-PORTE-EMP={CLIENTES.DCLCLIENTES.CLIENTES_COD_PORTE_EMP}");

        }

        [StopWatch]
        /*" DB050-UPDATE-CLIENTES-DB-UPDATE-1 */
        public void DB050_UPDATE_CLIENTES_DB_UPDATE_1()
        {
            /*" -9282- EXEC SQL UPDATE SEGUROS.CLIENTES SET COD_PORTE_EMP = :CLIENTES-COD-PORTE-EMP WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE END-EXEC */

            var dB050_UPDATE_CLIENTES_DB_UPDATE_1_Update1 = new DB050_UPDATE_CLIENTES_DB_UPDATE_1_Update1()
            {
                CLIENTES_COD_PORTE_EMP = CLIENTES.DCLCLIENTES.CLIENTES_COD_PORTE_EMP.ToString(),
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            DB050_UPDATE_CLIENTES_DB_UPDATE_1_Update1.Execute(dB050_UPDATE_CLIENTES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: DB050_UPDATE_CLIENTES_EXIT*/

        [StopWatch]
        /*" R9979-00-MONTA-TAB-CRITICA-SECTION */
        private void R9979_00_MONTA_TAB_CRITICA_SECTION()
        {
            /*" -9315- MOVE 'R9979-00-MONTA-TAB-CRITICA' TO PARAGRAFO. */
            _.Move("R9979-00-MONTA-TAB-CRITICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9318- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9320- ADD 1 TO W-IND-1 */
            WAREA_AUXILIAR.W_IND_1.Value = WAREA_AUXILIAR.W_IND_1 + 1;

            /*" -9321- IF (W-IND-1 > 9900) */

            if ((WAREA_AUXILIAR.W_IND_1 > 9900))
            {

                /*" -9322- DISPLAY ' ' */
                _.Display($" ");

                /*" -9323- DISPLAY '///////////////////////////////////////////////' */
                _.Display($"///////////////////////////////////////////////");

                /*" -9324- DISPLAY '//           PROGRAMA =>  VG2600B            //' */
                _.Display($"//           PROGRAMA =>  VG2600B            //");

                /*" -9325- DISPLAY '//                                           //' */
                _.Display($"//                                           //");

                /*" -9326- DISPLAY '//                 TERMINO                   //' */
                _.Display($"//                 TERMINO                   //");

                /*" -9327- DISPLAY '//                                           //' */
                _.Display($"//                                           //");

                /*" -9328- DISPLAY '//       ==>   A N O R M A L     <==         //' */
                _.Display($"//       ==>   A N O R M A L     <==         //");

                /*" -9329- DISPLAY '//                                           //' */
                _.Display($"//                                           //");

                /*" -9330- DISPLAY '//    ==> ESTOURO DA TABELA DE ERROS <==     //' */
                _.Display($"//    ==> ESTOURO DA TABELA DE ERROS <==     //");

                /*" -9331- DISPLAY '///////////////////////////////////////////////' */
                _.Display($"///////////////////////////////////////////////");

                /*" -9332- DISPLAY ' ' */
                _.Display($" ");

                /*" -9333- DISPLAY 'VALOR DO INDICE     ' W-IND-1 */
                _.Display($"VALOR DO INDICE     {WAREA_AUXILIAR.W_IND_1}");

                /*" -9334- DISPLAY ' ' */
                _.Display($" ");

                /*" -9335- GO TO R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION(); //GOTO
                return;

                /*" -9338- END-IF */
            }


            /*" -9339- MOVE W-TP-REGISTRO TO W-TB-NUM-TIPO-REG(W-IND-1) */
            _.Move(W_TP_REGISTRO, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_1].W_TB_NUM_TIPO_REG);

            /*" -9340- MOVE WS-NUM-PROPOSTA TO W-TB-NUM-PROPOSTA(W-IND-1) */
            _.Move(WS_NUM_PROPOSTA, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_1].W_TB_NUM_PROPOSTA);

            /*" -9341- MOVE WS-NUM-APOLICE TO W-TB-NUM-APOLICE (W-IND-1) */
            _.Move(WS_NUM_APOLICE, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_1].W_TB_NUM_APOLICE);

            /*" -9342- MOVE WS-COD-SUBGRUPO TO W-TB-NUM-SUBGRUPO(W-IND-1) */
            _.Move(WS_COD_SUBGRUPO, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_1].W_TB_NUM_SUBGRUPO);

            /*" -9343- MOVE WS-NUM-SEQ-ARQ TO W-TB-NUM-SEQ-REG (W-IND-1) */
            _.Move(WS_NUM_SEQ_ARQ, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_1].W_TB_NUM_SEQ_REG);

            /*" -9344- MOVE W-LIDO-MOVTO-PORTAL TO W-TB-NUM-LIN-ARQ (W-IND-1) */
            _.Move(WAREA_AUXILIAR.W_LIDO_MOVTO_PORTAL, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_1].W_TB_NUM_LIN_ARQ);

            /*" -9345- MOVE WS-COD-ERRO TO W-TB-COD-ERRO (W-IND-1) */
            _.Move(WS_COD_ERRO, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_1].W_TB_COD_ERRO);

            /*" -9346- MOVE WS-COD-CAMPO TO W-TB-COD-CAMPO (W-IND-1) */
            _.Move(WS_COD_CAMPO, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_1].W_TB_COD_CAMPO);

            /*" -9347- MOVE WS-DES-CONTEUDO TO W-TB-DES-CONTEUDO(W-IND-1) */
            _.Move(WS_DES_CONTEUDO, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_1].W_TB_DES_CONTEUDO);

            /*" -9348- MOVE RH-NSAS TO W-TB-NSAS (W-IND-1) */
            _.Move(REG_HEADER.RH_NSAS, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_1].W_TB_NSAS);

            /*" -9350- MOVE WS-TP-MENSAGEM TO W-TB-TP-MENSAGEM (W-IND-1) */
            _.Move(WS_TP_MENSAGEM, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_1].W_TB_TP_MENSAGEM);

            /*" -9351- EVALUATE WS-TP-MENSAGEM */
            switch (WS_TP_MENSAGEM.Value.Trim())
            {

                /*" -9352- WHEN 'ERRO' */
                case "ERRO":

                    /*" -9353- ADD 1 TO WS-QTD-ERRO */
                    WAREA_AUXILIAR.WS_QTD_ERRO.Value = WAREA_AUXILIAR.WS_QTD_ERRO + 1;

                    /*" -9354- WHEN 'ALERTA' */
                    break;
                case "ALERTA":

                    /*" -9355- ADD 1 TO WS-QTD-ALERTA */
                    WAREA_AUXILIAR.WS_QTD_ALERTA.Value = WAREA_AUXILIAR.WS_QTD_ALERTA + 1;

                    /*" -9356- WHEN 'SUCESSO' */
                    break;
                case "SUCESSO":

                    /*" -9357- ADD 1 TO WS-APOL-GRAVADAS */
                    WAREA_AUXILIAR.WS_APOL_GRAVADAS.Value = WAREA_AUXILIAR.WS_APOL_GRAVADAS + 1;

                    /*" -9358- WHEN OTHER */
                    break;
                default:

                    /*" -9359- DISPLAY 'TIPO MENSAGEM INVALIDO ' WS-TP-MENSAGEM */
                    _.Display($"TIPO MENSAGEM INVALIDO {WS_TP_MENSAGEM}");

                    /*" -9361- END-EVALUATE. */
                    break;
            }


            /*" -9361- MOVE 'ERRO' TO WS-TP-MENSAGEM. */
            _.Move("ERRO", WS_TP_MENSAGEM);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9979_SAIDA*/

        [StopWatch]
        /*" R9980-00-GERAR-RELATORIO-SECTION */
        private void R9980_00_GERAR_RELATORIO_SECTION()
        {
            /*" -9372- MOVE 'R9980-00-GERAR-RELATORIO' TO PARAGRAFO. */
            _.Move("R9980-00-GERAR-RELATORIO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9375- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9377- MOVE '/' TO W-BARRA1 W-BARRA2 */
            _.Move("/", WAREA_AUXILIAR.W_DTMOVABE1.W_BARRA1);
            _.Move("/", WAREA_AUXILIAR.W_DTMOVABE1.W_BARRA2);


            /*" -9379- MOVE W-DTMOVABE-I TO LC02-DATA. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE_I, LC00.LC02.LC02_DATA);

            /*" -9383- PERFORM R9981-00-INCONSISTENCIA VARYING W-IND-2 FROM 1 BY 1 UNTIL W-IND-2 GREATER W-IND-1. */

            for (WAREA_AUXILIAR.W_IND_2.Value = 1; !(WAREA_AUXILIAR.W_IND_2 > WAREA_AUXILIAR.W_IND_1); WAREA_AUXILIAR.W_IND_2.Value += 1)
            {

                R9981_00_INCONSISTENCIA_SECTION();
            }

            /*" -9385- INITIALIZE W-TAB-CONSISTENCIA. */
            _.Initialize(
                AREA_DAS_TABELAS.W_TAB_CONSISTENCIA
            );

            /*" -9386- MOVE ZEROS TO W-IND-1. */
            _.Move(0, WAREA_AUXILIAR.W_IND_1);

            /*" -9386- MOVE 80 TO W-CONT-LINHAS. */
            _.Move(80, WAREA_AUXILIAR.W_CONT_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9980_SAIDA*/

        [StopWatch]
        /*" R9981-00-INCONSISTENCIA-SECTION */
        private void R9981_00_INCONSISTENCIA_SECTION()
        {
            /*" -9397- MOVE 'R9981-00-INCONSISTENCIA' TO PARAGRAFO. */
            _.Move("R9981-00-INCONSISTENCIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9400- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9401- MOVE SPACES TO LC06-DES-ERRO. */
            _.Move("", LC00.LC06.LC06_DES_ERRO);

            /*" -9402- MOVE SPACES TO LC06-CAMPO-ERRO */
            _.Move("", LC00.LC06.LC06_CAMPO_ERRO);

            /*" -9404- MOVE SPACES TO LC06-DES-CONTEUDO */
            _.Move("", LC00.LC06.LC06_DES_CONTEUDO);

            /*" -9405- MOVE W-TB-NUM-PROPOSTA(W-IND-2) TO LC06-NUM-PROPOSTA */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_2].W_TB_NUM_PROPOSTA, LC00.LC06.LC06_NUM_PROPOSTA);

            /*" -9406- MOVE W-TB-NUM-APOLICE (W-IND-2) TO LC06-NUM-APOLICE */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_2].W_TB_NUM_APOLICE, LC00.LC06.LC06_NUM_APOLICE);

            /*" -9407- MOVE W-TB-NUM-SUBGRUPO(W-IND-2) TO LC06-NUM-SUBGRUPO */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_2].W_TB_NUM_SUBGRUPO, LC00.LC06.LC06_NUM_SUBGRUPO);

            /*" -9408- MOVE W-TB-NUM-SEQ-REG (W-IND-2) TO LC06-NUM-SEQ-REG */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_2].W_TB_NUM_SEQ_REG, LC00.LC06.LC06_NUM_SEQ_REG);

            /*" -9409- MOVE W-TB-NUM-LIN-ARQ (W-IND-2) TO LC06-NUM-LIN-ARQ */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_2].W_TB_NUM_LIN_ARQ, LC00.LC06.LC06_NUM_LIN_ARQ);

            /*" -9410- MOVE W-TB-COD-ERRO (W-IND-2) TO WS-COD-ERRO */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_2].W_TB_COD_ERRO, WS_COD_ERRO);

            /*" -9411- MOVE W-TB-DESC-ERRO (WS-COD-ERRO) TO LC06-DES-ERRO */
            _.Move(W_TAB_ERRO.W_TAB_ERRO_REG[WS_COD_ERRO].W_TB_DESC_ERRO, LC00.LC06.LC06_DES_ERRO);

            /*" -9413- MOVE W-TB-TP-MENSAGEM (W-IND-2) TO LC06-TP-MENSAGEM */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_2].W_TB_TP_MENSAGEM, LC00.LC06.LC06_TP_MENSAGEM);

            /*" -9414- IF (W-TB-TP-MENSAGEM(W-IND-2) = 'SUCESSO' ) */

            if ((AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_2].W_TB_TP_MENSAGEM == "SUCESSO"))
            {

                /*" -9415- MOVE ZEROS TO LC06-NUM-SUBGRUPO */
                _.Move(0, LC00.LC06.LC06_NUM_SUBGRUPO);

                /*" -9416- MOVE ZEROS TO LC06-NUM-SEQ-REG */
                _.Move(0, LC00.LC06.LC06_NUM_SEQ_REG);

                /*" -9417- MOVE ZEROS TO LC06-NUM-LIN-ARQ */
                _.Move(0, LC00.LC06.LC06_NUM_LIN_ARQ);

                /*" -9418- MOVE SPACES TO LC06-CAMPO-ERRO */
                _.Move("", LC00.LC06.LC06_CAMPO_ERRO);

                /*" -9419- MOVE SPACES TO LC06-DES-CONTEUDO */
                _.Move("", LC00.LC06.LC06_DES_CONTEUDO);

                /*" -9420- ELSE */
            }
            else
            {


                /*" -9421- MOVE ZEROS TO LC06-NUM-APOLICE */
                _.Move(0, LC00.LC06.LC06_NUM_APOLICE);

                /*" -9422- MOVE W-TB-COD-CAMPO(W-IND-2) TO WS-COD-CAMPO */
                _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_2].W_TB_COD_CAMPO, WS_COD_CAMPO);

                /*" -9423- MOVE W-TB-NOM-CAMPO(WS-COD-CAMPO) TO LC06-CAMPO-ERRO */
                _.Move(W_TAB_CAMPO.W_TAB_CAMPO_REG[WS_COD_CAMPO].W_TB_NOM_CAMPO, LC00.LC06.LC06_CAMPO_ERRO);

                /*" -9424- MOVE W-TB-DES-CONTEUDO(W-IND-2) TO LC06-DES-CONTEUDO */
                _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_2].W_TB_DES_CONTEUDO, LC00.LC06.LC06_DES_CONTEUDO);

                /*" -9426- END-IF. */
            }


            /*" -9427- IF (W-CONT-LINHAS > 60) */

            if ((WAREA_AUXILIAR.W_CONT_LINHAS > 60))
            {

                /*" -9428- PERFORM R9982-00-GRAVA-CABECALHO */

                R9982_00_GRAVA_CABECALHO_SECTION();

                /*" -9430- END-IF. */
            }


            /*" -9432- WRITE REG-RVG2600B FROM LC06 AFTER 1. */
            _.Move(LC00.LC06.GetMoveValues(), REG_RVG2600B);

            RVG2600B.Write(REG_RVG2600B.GetMoveValues().ToString());

            /*" -9432- ADD 1 TO W-CONT-LINHAS. */
            WAREA_AUXILIAR.W_CONT_LINHAS.Value = WAREA_AUXILIAR.W_CONT_LINHAS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9981_SAIDA*/

        [StopWatch]
        /*" R9982-00-GRAVA-CABECALHO-SECTION */
        private void R9982_00_GRAVA_CABECALHO_SECTION()
        {
            /*" -9443- MOVE 'R9982-00-GRAVA-CABECALHO' TO PARAGRAFO. */
            _.Move("R9982-00-GRAVA-CABECALHO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -9446- MOVE 'WRITE' TO COMANDO. */
            _.Move("WRITE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -9448- ADD 1 TO LC01-PAGINA. */
            LC00.LC01.LC01_PAGINA.Value = LC00.LC01.LC01_PAGINA + 1;

            /*" -9450- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -9451- MOVE WS-TIME-N TO WS-TIME-EDIT */
            _.Move(WS_TIME.WS_TIME_N, WS_TIME_EDIT);

            /*" -9453- MOVE WS-TIME-EDIT TO LC03-HORA. */
            _.Move(WS_TIME_EDIT, LC00.LC03.LC03_HORA);

            /*" -9455- MOVE W-TB-NSAS(W-IND-2) TO LC04-NSAS-PORTAL. */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_79[WAREA_AUXILIAR.W_IND_2].W_TB_NSAS, LC00.LC04.LC04_NSAS_PORTAL);

            /*" -9456- MOVE RH-DATA-GERACAO TO W-DATA-TRABALHO */
            _.Move(REG_HEADER.RH_DATA_GERACAO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -9457- MOVE W-DIA-TRABALHO TO W-DIA-MOVABEI1 */
            _.Move(WAREA_AUXILIAR.FILLER_27.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABEI1);

            /*" -9458- MOVE W-MES-TRABALHO TO W-MES-MOVABEI1 */
            _.Move(WAREA_AUXILIAR.FILLER_27.W_MES_TRABALHO, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABEI1);

            /*" -9460- MOVE W-ANO-TRABALHO TO W-ANO-MOVABEI1 */
            _.Move(WAREA_AUXILIAR.FILLER_27.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABEI1);

            /*" -9463- MOVE '/' TO W-BARRAI1 W-BARRAI2 */
            _.Move("/", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRAI1);
            _.Move("/", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRAI2);


            /*" -9465- MOVE W-DTMOVABE-I TO LC04-DATA-GERACAO. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE_I, LC00.LC04.LC04_DATA_GERACAO);

            /*" -9466- WRITE REG-RVG2600B FROM LC07 AFTER PAGE. */
            _.Move(LC00.LC07.GetMoveValues(), REG_RVG2600B);

            RVG2600B.Write(REG_RVG2600B.GetMoveValues().ToString());

            /*" -9467- WRITE REG-RVG2600B FROM LC01 AFTER 1. */
            _.Move(LC00.LC01.GetMoveValues(), REG_RVG2600B);

            RVG2600B.Write(REG_RVG2600B.GetMoveValues().ToString());

            /*" -9468- WRITE REG-RVG2600B FROM LC02 AFTER 1 */
            _.Move(LC00.LC02.GetMoveValues(), REG_RVG2600B);

            RVG2600B.Write(REG_RVG2600B.GetMoveValues().ToString());

            /*" -9469- WRITE REG-RVG2600B FROM LC03 AFTER 1 */
            _.Move(LC00.LC03.GetMoveValues(), REG_RVG2600B);

            RVG2600B.Write(REG_RVG2600B.GetMoveValues().ToString());

            /*" -9470- WRITE REG-RVG2600B FROM LC04 AFTER 2 */
            _.Move(LC00.LC04.GetMoveValues(), REG_RVG2600B);

            RVG2600B.Write(REG_RVG2600B.GetMoveValues().ToString());

            /*" -9472- WRITE REG-RVG2600B FROM LC07 AFTER 1 */
            _.Move(LC00.LC07.GetMoveValues(), REG_RVG2600B);

            RVG2600B.Write(REG_RVG2600B.GetMoveValues().ToString());

            /*" -9474- WRITE REG-RVG2600B FROM LC05 AFTER 2. */
            _.Move(LC00.LC05.GetMoveValues(), REG_RVG2600B);

            RVG2600B.Write(REG_RVG2600B.GetMoveValues().ToString());

            /*" -9474- MOVE 8 TO W-CONT-LINHAS. */
            _.Move(8, WAREA_AUXILIAR.W_CONT_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9982_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -9483- CLOSE MOV-PORTAL. */
            MOV_PORTAL.Close();

            /*" -9483- CLOSE RVG2600B. */
            RVG2600B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -9494- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -9496- DISPLAY ' ' */
            _.Display($" ");

            /*" -9497- IF (W-FIM-MVTO-PORTAL = 'FIM' ) */

            if ((WAREA_AUXILIAR.W_FIM_MVTO_PORTAL == "FIM"))
            {

                /*" -9498- DISPLAY '  ' */
                _.Display($"  ");

                /*" -9499- DISPLAY '=============================================' */
                _.Display($"=============================================");

                /*" -9500- DISPLAY '============== ESTATISTICA FINAL ============' */
                _.Display($"============== ESTATISTICA FINAL ============");

                /*" -9501- DISPLAY '=============================================' */
                _.Display($"=============================================");

                /*" -9502- DISPLAY 'QUANT. TOTAL LIDAS..... ' W-LIDO-MOVTO-PORTAL */
                _.Display($"QUANT. TOTAL LIDAS..... {WAREA_AUXILIAR.W_LIDO_MOVTO_PORTAL}");

                /*" -9503- DISPLAY 'QUANT. LIDOS TIPO 0.... ' W-QTD-LD-PORTAL-0 */
                _.Display($"QUANT. LIDOS TIPO 0.... {WAREA_AUXILIAR.W_QTD_LD_PORTAL_0}");

                /*" -9504- DISPLAY 'QUANT. LIDOS TIPO 1.... ' W-QTD-LD-PORTAL-1 */
                _.Display($"QUANT. LIDOS TIPO 1.... {WAREA_AUXILIAR.W_QTD_LD_PORTAL_1}");

                /*" -9505- DISPLAY 'QUANT. LIDOS TIPO 2.... ' W-QTD-LD-PORTAL-2 */
                _.Display($"QUANT. LIDOS TIPO 2.... {WAREA_AUXILIAR.W_QTD_LD_PORTAL_2}");

                /*" -9506- DISPLAY 'QUANT. LIDOS TIPO 3.... ' W-QTD-LD-PORTAL-3 */
                _.Display($"QUANT. LIDOS TIPO 3.... {WAREA_AUXILIAR.W_QTD_LD_PORTAL_3}");

                /*" -9507- DISPLAY 'QUANT. LIDOS TIPO 4.... ' W-QTD-LD-PORTAL-4 */
                _.Display($"QUANT. LIDOS TIPO 4.... {WAREA_AUXILIAR.W_QTD_LD_PORTAL_4}");

                /*" -9508- DISPLAY 'QUANT. LIDOS TIPO 5.... ' W-QTD-LD-PORTAL-5 */
                _.Display($"QUANT. LIDOS TIPO 5.... {WAREA_AUXILIAR.W_QTD_LD_PORTAL_5}");

                /*" -9509- DISPLAY 'QUANT. LIDOS TIPO 6.... ' W-QTD-LD-PORTAL-6 */
                _.Display($"QUANT. LIDOS TIPO 6.... {WAREA_AUXILIAR.W_QTD_LD_PORTAL_6}");

                /*" -9510- DISPLAY 'QUANT. LIDOS TIPO 9.... ' W-QTD-LD-PORTAL-9 */
                _.Display($"QUANT. LIDOS TIPO 9.... {WAREA_AUXILIAR.W_QTD_LD_PORTAL_9}");

                /*" -9511- DISPLAY '=============================================' */
                _.Display($"=============================================");

                /*" -9512- DISPLAY 'QUANT. ERRO ENCONTRADOS ' WS-QTD-ERRO */
                _.Display($"QUANT. ERRO ENCONTRADOS {WAREA_AUXILIAR.WS_QTD_ERRO}");

                /*" -9513- DISPLAY 'QUANT. ALERTAS ENCONTRD ' WS-QTD-ALERTA */
                _.Display($"QUANT. ALERTAS ENCONTRD {WAREA_AUXILIAR.WS_QTD_ALERTA}");

                /*" -9514- DISPLAY 'QUANT. APOL. GRAVADAS...' WS-APOL-GRAVADAS */
                _.Display($"QUANT. APOL. GRAVADAS...{WAREA_AUXILIAR.WS_APOL_GRAVADAS}");

                /*" -9515- DISPLAY 'QUANT. SUBG. GRAVADOS...' WS-SUBG-GRAVADOS */
                _.Display($"QUANT. SUBG. GRAVADOS...{WAREA_AUXILIAR.WS_SUBG_GRAVADOS}");

                /*" -9516- DISPLAY 'QUANT. INSERT TAB...... ' WS-TOTAL-INSERT */
                _.Display($"QUANT. INSERT TAB...... {WAREA_AUXILIAR.WS_TOTAL_INSERT}");

                /*" -9517- DISPLAY 'QUANT. INSERT CNTRLE... ' WS-CONT-CNTRLE-PROC */
                _.Display($"QUANT. INSERT CNTRLE... {WAREA_AUXILIAR.WS_CONT_CNTRLE_PROC}");

                /*" -9518- DISPLAY 'QUANT. SEM RISCO MOTOR. ' WS-QTD-PCR */
                _.Display($"QUANT. SEM RISCO MOTOR. {WS_QTD_PCR}");

                /*" -9519- DISPLAY '=========== VG2600B - FIM NORMAL ============' */
                _.Display($"=========== VG2600B - FIM NORMAL ============");

                /*" -9521- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -9521- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -9525- DISPLAY '*** VG2600B *** EXECUTOU COMMIT' */
                _.Display($"*** VG2600B *** EXECUTOU COMMIT");

                /*" -9526- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -9527- ELSE */
            }
            else
            {


                /*" -9528- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -9529- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

                /*" -9530- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

                /*" -9532- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -9533- MOVE SQLERRMC TO WSQLERRMC */
                _.Move(DB.SQLERRMC, WABEND.WSQLERRO.WSQLERRMC);

                /*" -9535- DISPLAY WSQLERRO */
                _.Display(WABEND.WSQLERRO);

                /*" -9536- DISPLAY '*** VG2600B *** ROLLBACK EM ANDAMENTO ...' */
                _.Display($"*** VG2600B *** ROLLBACK EM ANDAMENTO ...");

                /*" -9537- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -9537- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -9540- MOVE 09 TO RETURN-CODE */
                _.Move(09, RETURN_CODE);

                /*" -9541- END-IF. */
            }


            /*" -9541- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}