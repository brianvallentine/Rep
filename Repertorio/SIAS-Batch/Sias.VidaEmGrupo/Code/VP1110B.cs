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
using Sias.VidaEmGrupo.DB2.VP1110B;

namespace Code
{
    public class VP1110B
    {
        public bool IsCall { get; set; }

        public VP1110B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROGRAMA ...............  VP1110B                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ANALISTA/PROGRAMADOR: TSUGUIRO TOGAWA.                                */
        /*"      *----------------------------------------------------------------*      */
        /*"      * FUNCAO:INVIAR SMS DE CANCELAMENTO DE SEGURO PRESTAMISTA               */
        /*"      *        PARA CELULAR (SIAS/EFP-WEB).                                   */
        /*"      *----------------------------------------------------------------*      */
        /*"      * HISTORICO DE VERSOES                                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * NO   VERSAO    DATA       PROGRAMADOR           ALTERACAO      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO V.04  29.01.2018   TSUGUIRO TOGAWA       CORRECAO PARA         */
        /*"      *                           ENVIAR SMS SOMENTE COM                      */
        /*"      *                           VALORES DE RESTITUICAO > 0 (SIAS).          */
        /*"      *                           CAD153864 - JIRA2943.                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO V.03  29.01.2018   TSUGUIRO TOGAWA       CORRECAO PARA         */
        /*"      *                           ENVIAR SMS SOMENTE COM                      */
        /*"      *                           STA_SITUACAO_SAP = '2'.                     */
        /*"      *                           RETIRA CANCELAMENTOS COM                    */
        /*"      *                           VALORES DE RESTITUICAO IGUAL A 0.           */
        /*"      *                           CAD153864 - JIRA2943.                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO V.02  22.01.2018   TSUGUIRO TOGAWA       CORRECAO PARA         */
        /*"      *                           ENVIAR SMS SOMENTE COM VLR DE               */
        /*"      *                           RESTITUICAO > ZERO E                        */
        /*"      *                           STA_SITUACAO_SAP = 2.                       */
        /*"      *                           CAD153864 - JIRA2943.                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO V.01  10.12.2017   TSUGUIRO TOGAWA       PROGRAMA INICIAL      */
        /*"      *                           CAD153864 - JIRA2943.                       */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _VP1110S1 { get; set; } = new FileBasis(new PIC("X", "65", "X(65)"));

        public FileBasis VP1110S1
        {
            get
            {
                _.Move(VP1110S1_REGISTRO, _VP1110S1); VarBasis.RedefinePassValue(VP1110S1_REGISTRO, _VP1110S1, VP1110S1_REGISTRO); return _VP1110S1;
            }
        }
        /*"01 VP1110S1-REGISTRO              PIC X(65).*/
        public StringBasis VP1110S1_REGISTRO { get; set; } = new StringBasis(new PIC("X", "65", "X(65)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77 WS-FSTATUS-E1                  PIC 9(02) VALUE ZEROS.*/
        public IntBasis WS_FSTATUS_E1 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
        /*"77 WS-FSTATUS-S1                  PIC 9(02) VALUE ZEROS.*/
        public IntBasis WS_FSTATUS_S1 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
        /*"77 WS-SIAS-OK                     PIC X(01) VALUE 'N'.*/
        public StringBasis WS_SIAS_OK { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
        /*"77 WS-TP-ARQ                      PIC 9(01) VALUE 1.*/
        public IntBasis WS_TP_ARQ { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"), 1);
        /*"77 WS-DT-SISTEMA                  PIC X(10) VALUE SPACES.*/
        public StringBasis WS_DT_SISTEMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01 WS-TRABALHOS.*/
        public VP1110B_WS_TRABALHOS WS_TRABALHOS { get; set; } = new VP1110B_WS_TRABALHOS();
        public class VP1110B_WS_TRABALHOS : VarBasis
        {
            /*"   05 WS-FIM-CUR001                   PIC  X(001)  VALUE 'N'.*/
            public StringBasis WS_FIM_CUR001 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"   05 WS-FIM-CUR002                   PIC  X(001)  VALUE 'N'.*/
            public StringBasis WS_FIM_CUR002 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"   05 WS-FLAG-SIAS                PIC X(01) VALUE 'N'.*/
            public StringBasis WS_FLAG_SIAS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"   05 WS-CAN-COM-RESTITUICAO      PIC S9(09) COMP VALUE ZEROS.*/
            public IntBasis WS_CAN_COM_RESTITUICAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"   05 WS-I                        PIC 9(04) VALUE ZEROS.*/
            public IntBasis WS_I { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"   05 WS-REG                      PIC 9(04) VALUE ZEROS.*/
            public IntBasis WS_REG { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"   05 WS-CT-EFP                       PIC 9(06).*/
            public IntBasis WS_CT_EFP { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"   05 WS-CT-SIAS                      PIC 9(06).*/
            public IntBasis WS_CT_SIAS { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"   05 WS-CT-PRODUTO                   PIC S9(09) COMP VALUE 0.*/
            public IntBasis WS_CT_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"   05 WS-CT-RESTITUICAO               PIC S9(09) COMP VALUE 0.*/
            public IntBasis WS_CT_RESTITUICAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"   05 WS-CT-DISP                      PIC 9(09).*/
            public IntBasis WS_CT_DISP { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"   05 WS-CT-CUR001                    PIC 9(09).*/
            public IntBasis WS_CT_CUR001 { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"   05 WS-CT-GRAVADOS-SIAS             PIC  9(05)  VALUE ZEROS.*/
            public IntBasis WS_CT_GRAVADOS_SIAS { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"   05 WS-CT-GRAVADOS-EFP              PIC  9(05)  VALUE ZEROS.*/
            public IntBasis WS_CT_GRAVADOS_EFP { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"   05 WS-VAR-BUSCA-TAM                PIC X(5000).*/
            public StringBasis WS_VAR_BUSCA_TAM { get; set; } = new StringBasis(new PIC("X", "5000", "X(5000)."), @"");
            /*"   05 WS-TAM                          PIC 9(09).*/
            public IntBasis WS_TAM { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"   05 WS-DIF                          PIC 9(09).*/
            public IntBasis WS_DIF { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"   05 WS-COD-PRODUTO-ANT              PIC 9(04).*/
            public IntBasis WS_COD_PRODUTO_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   05 WS-TP-SISTEMA               PIC X(04) VALUE SPACES.*/
            public StringBasis WS_TP_SISTEMA { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"   05 WS-NUM-CONTRATO-TERC        PIC 9(12).*/
            public IntBasis WS_NUM_CONTRATO_TERC { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
            /*"   05 WS-CH-NUM-PROPOSTA              PIC S9(15) COMP-3.*/
            public IntBasis WS_CH_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
            /*"   05 WS-CH-NUM-CONTRATO-TERC     PIC S9(12) COMP-3 VALUE 0.*/
            public IntBasis WS_CH_NUM_CONTRATO_TERC { get; set; } = new IntBasis(new PIC("S9", "12", "S9(12)"));
            /*"01 WS-ERROS.*/
        }
        public VP1110B_WS_ERROS WS_ERROS { get; set; } = new VP1110B_WS_ERROS();
        public class VP1110B_WS_ERROS : VarBasis
        {
            /*"   03 WS-LOCAL                    PIC X(40) VALUE SPACES.*/
            public StringBasis WS_LOCAL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"   03 WS-SQLCODE                  PIC ----9 VALUE ZEROS.*/
            public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "5", "----9"));
            /*"   03 WS-SQLERRMC                 PIC X(070) VALUE SPACES.*/
            public StringBasis WS_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
            /*"01 WS-IC-NULL.*/
        }
        public VP1110B_WS_IC_NULL WS_IC_NULL { get; set; } = new VP1110B_WS_IC_NULL();
        public class VP1110B_WS_IC_NULL : VarBasis
        {
            /*"   03 WS-NULL                          PIC S9(004) VALUE 0 COMP.*/
            public IntBasis WS_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  WS-TABELA-MESES.*/
        }
        public VP1110B_WS_TABELA_MESES WS_TABELA_MESES { get; set; } = new VP1110B_WS_TABELA_MESES();
        public class VP1110B_WS_TABELA_MESES : VarBasis
        {
            /*"   03 FILLER                      PIC X(36) VALUE      'JANFEVMARABRMAIJUNJULAGOSETOUTNOVDEZ'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"JANFEVMARABRMAIJUNJULAGOSETOUTNOVDEZ");
            /*"01  RWS-TABELA-MESES REDEFINES WS-TABELA-MESES.*/
        }
        private _REDEF_VP1110B_RWS_TABELA_MESES _rws_tabela_meses { get; set; }
        public _REDEF_VP1110B_RWS_TABELA_MESES RWS_TABELA_MESES
        {
            get { _rws_tabela_meses = new _REDEF_VP1110B_RWS_TABELA_MESES(); _.Move(WS_TABELA_MESES, _rws_tabela_meses); VarBasis.RedefinePassValue(WS_TABELA_MESES, _rws_tabela_meses, WS_TABELA_MESES); _rws_tabela_meses.ValueChanged += () => { _.Move(_rws_tabela_meses, WS_TABELA_MESES); }; return _rws_tabela_meses; }
            set { VarBasis.RedefinePassValue(value, _rws_tabela_meses, WS_TABELA_MESES); }
        }  //Redefines
        public class _REDEF_VP1110B_RWS_TABELA_MESES : VarBasis
        {
            /*"   03 WS-TAB-MESES OCCURS 12.*/
            public ListBasis<VP1110B_WS_TAB_MESES> WS_TAB_MESES { get; set; } = new ListBasis<VP1110B_WS_TAB_MESES>(12);
            public class VP1110B_WS_TAB_MESES : VarBasis
            {
                /*"      05 WS-TB-MES                PIC X(03).*/
                public StringBasis WS_TB_MES { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
                /*"01 WS-1110-HEADER                 PIC X(65).*/

                public VP1110B_WS_TAB_MESES()
                {
                    WS_TB_MES.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VP1110B_RWS_TABELA_MESES()
            {
                WS_TAB_MESES.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_1110_HEADER { get; set; } = new StringBasis(new PIC("X", "65", "X(65)."), @"");
        /*"01 VP1110S1-REG-CABECALHO.*/
        public VP1110B_VP1110S1_REG_CABECALHO VP1110S1_REG_CABECALHO { get; set; } = new VP1110B_VP1110S1_REG_CABECALHO();
        public class VP1110B_VP1110S1_REG_CABECALHO : VarBasis
        {
            /*"   03 FILLER                      PIC X(14) VALUE      'NUM-CPF-CNPJ'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"NUM_CPF_CNPJ");
            /*"   03 FILLER                      PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   03 FILLER                      PIC X(11) VALUE      'DDD/CELULAR'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"DDD/CELULAR");
            /*"   03 FILLER                      PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   03 FILLER                      PIC X(08) VALUE      'PROPOSTA'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"PROPOSTA");
            /*"   03 FILLER                      PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"   03 FILLER                      PIC X(20) VALUE      'NOME'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"NOME");
            /*"01 VP1110S1-REG-DETALHE.*/
        }
        public VP1110B_VP1110S1_REG_DETALHE VP1110S1_REG_DETALHE { get; set; } = new VP1110B_VP1110S1_REG_DETALHE();
        public class VP1110B_VP1110S1_REG_DETALHE : VarBasis
        {
            /*"   03 WS-VP1110-GCS-CPF-CNPJ      PIC 9(14).*/
            public IntBasis WS_VP1110_GCS_CPF_CNPJ { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"   03 WS-VP1110-PV1               PIC X(01).*/
            public StringBasis WS_VP1110_PV1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   03 WS-VP1110-NUM-DDD           PIC 9(03).*/
            public IntBasis WS_VP1110_NUM_DDD { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"   03 WS-VP1110-NUM-TELEFONE      PIC 9(09).*/
            public IntBasis WS_VP1110_NUM_TELEFONE { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"   03 WS-VP1110-PV3               PIC X(01).*/
            public StringBasis WS_VP1110_PV3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   03 WS-VP1110-NUM-PROPOSTA      PIC 9(14).*/
            public IntBasis WS_VP1110_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"   03 WS-VP1110-PV4               PIC X(01).*/
            public StringBasis WS_VP1110_PV4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   03 WS-VP1110-NOME              PIC X(20).*/
            public StringBasis WS_VP1110_NOME { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        }


        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.PESFONE PESFONE { get; set; } = new Dclgens.PESFONE();
        public Dclgens.EF025 EF025 { get; set; } = new Dclgens.EF025();
        public Dclgens.EF050 EF050 { get; set; } = new Dclgens.EF050();
        public Dclgens.EF060 EF060 { get; set; } = new Dclgens.EF060();
        public Dclgens.EF063 EF063 { get; set; } = new Dclgens.EF063();
        public Dclgens.EF066 EF066 { get; set; } = new Dclgens.EF066();
        public Dclgens.EF072 EF072 { get; set; } = new Dclgens.EF072();
        public Dclgens.EF079 EF079 { get; set; } = new Dclgens.EF079();
        public Dclgens.EF080 EF080 { get; set; } = new Dclgens.EF080();
        public Dclgens.EF150 EF150 { get; set; } = new Dclgens.EF150();
        public Dclgens.GEPESFIS GEPESFIS { get; set; } = new Dclgens.GEPESFIS();
        public Dclgens.GEPESJUR GEPESJUR { get; set; } = new Dclgens.GEPESJUR();
        public Dclgens.GEPESSOA GEPESSOA { get; set; } = new Dclgens.GEPESSOA();
        public Dclgens.GEPESTEL GEPESTEL { get; set; } = new Dclgens.GEPESTEL();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();

        public VP1110B_CUR001 CUR001 { get; set; } = new VP1110B_CUR001(false);
        string GetQuery_CUR001()
        {
            var query = @$"SELECT PROPOVA.TIMESTAMP
							,PROPOVA.NUM_CERTIFICADO
							,PROPOVA.COD_CLIENTE
							,PROPOFID.COD_PESSOA
							FROM SEGUROS.PROPOSTAS_VA PROPOVA
							,SEGUROS.PROPOSTA_FIDELIZ PROPOFID WHERE PROPOVA.TIMESTAMP > '2014-01-01 00:00:00.000000' AND PROPOVA.COD_PRODUTO IN (7705
							, 7707
							, 7713
							, 7715) AND PROPOVA.NUM_CERTIFICADO = PROPOFID.NUM_PROPOSTA_SIVPF AND PROPOFID.COD_USUARIO <> 'VP1111B' AND PROPOFID.SIT_PROPOSTA = 'CAN' AND PROPOFID.COD_PRODUTO_SIVPF = 77";

            return query;
        }


        public VP1110B_CUR002 CUR002 { get; set; } = new VP1110B_CUR002(false);
        string GetQuery_CUR002()
        {
            var query = @$"SELECT EF150.NUM_OCORR_MOVTO
							,EF150.NUM_CONTRATO_SEGUR
							,EF150.NUM_CONTR_TERC
							,EF150.COD_PRODUTO
							,VALUE(EF050.DTH_FIM_VIGENCIA
							, '0001-01-01')
							,EF150.DTH_ATUALIZACAO
							,EF150.VLR_RESTITUIR
							FROM SEGUROS.EF_ENVIO_MOVTO_SAP EF150
							, SEGUROS.EF_CONTRATO EF050 WHERE EF150.DTH_ATUALIZACAO > '2014-01-01 00:00:00.000000' AND EF150.NOM_PROGRAMA <> 'VP1111B' AND EF150.COD_PRODUTO IN (7705
							, 7716) AND EF150.STA_SITUACAO_SAP = '2' AND EF150.VLR_RESTITUIR <> 0 AND EF150.NUM_CONTRATO_SEGUR = EF050.NUM_CONTRATO AND EF050.STA_CONTRATO = 'C'";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string VP1110S1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                VP1110S1.SetFile(VP1110S1_FILE_NAME_P);
                InitializeGetQuery();

                /*" -228- PERFORM P1000-PROCEDIMENTOS-INICIAIS THRU P1000-FIM */

                P1000_PROCEDIMENTOS_INICIAIS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P1000_FIM*/


                /*" -229- PERFORM P2000-PROCEDIMENTOS-PRINCIPAIS THRU P2000-FIM */

                P2000_PROCEDIMENTOS_PRINCIPAIS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P2000_FIM*/


                /*" -230- PERFORM P9000-PROCEDIMENTOS-FINAIS THRU P9000-FIM */

                P9000_PROCEDIMENTOS_FINAIS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P9000_FIM*/


                /*" -230- . */

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        public void InitializeGetQuery()
        {
            CUR001.GetQueryEvent += GetQuery_CUR001;
            CUR002.GetQueryEvent += GetQuery_CUR002;
        }

        [StopWatch]
        /*" P1000-PROCEDIMENTOS-INICIAIS */
        private void P1000_PROCEDIMENTOS_INICIAIS(bool isPerform = false)
        {
            /*" -234- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC */

            /*" -235- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC */

            /*" -236- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC */

            /*" -240- DISPLAY '*---------------------------------*' */
            _.Display($"*---------------------------------*");

            /*" -241- DISPLAY 'PROGRAMA VP1110B - V.04 - 07.02.2018' */
            _.Display($"PROGRAMA VP1110B - V.04 - 07.02.2018");

            /*" -249- DISPLAY 'INICIO: ' FUNCTION CURRENT-DATE(07:2) '.' FUNCTION CURRENT-DATE(05:2) '.' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIO: {_.CurrentDateAsDate():dd}.{_.CurrentDateAsDate():MM}.{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -254- PERFORM P1000_PROCEDIMENTOS_INICIAIS_DB_SELECT_1 */

            P1000_PROCEDIMENTOS_INICIAIS_DB_SELECT_1();

            /*" -257- OPEN OUTPUT VP1110S1 */
            VP1110S1.Open(VP1110S1_REGISTRO, WS_FSTATUS_S1);

            /*" -258- IF WS-FSTATUS-S1 NOT = ZEROS */

            if (WS_FSTATUS_S1 != 00)
            {

                /*" -260- DISPLAY 'ERRO OPEN VP1110S1, ' 'FILE STATUS 1= ' WS-FSTATUS-S1 */

                $"ERRO OPEN VP1110S1, FILE STATUS 1= {WS_FSTATUS_S1}"
                .Display();

                /*" -261- MOVE 16 TO RETURN-CODE */
                _.Move(16, RETURN_CODE);

                /*" -262- PERFORM P9999-ERRO-SQL THRU P9999-FIM */

                P9999_ERRO_SQL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P9999_FIM*/


                /*" -263- END-IF */
            }


            /*" -264- WRITE VP1110S1-REGISTRO FROM VP1110S1-REG-CABECALHO */
            _.Move(VP1110S1_REG_CABECALHO.GetMoveValues(), VP1110S1_REGISTRO);

            VP1110S1.Write(VP1110S1_REGISTRO.GetMoveValues().ToString());

            /*" -265- IF WS-FSTATUS-S1 NOT = ZEROS */

            if (WS_FSTATUS_S1 != 00)
            {

                /*" -267- DISPLAY 'ERRO WRITE CABEC VP1110S1, ' 'FILE STATUS 1= ' WS-FSTATUS-S1 */

                $"ERRO WRITE CABEC VP1110S1, FILE STATUS 1= {WS_FSTATUS_S1}"
                .Display();

                /*" -268- MOVE 16 TO RETURN-CODE */
                _.Move(16, RETURN_CODE);

                /*" -269- PERFORM P9999-ERRO-SQL THRU P9999-FIM */

                P9999_ERRO_SQL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P9999_FIM*/


                /*" -270- END-IF */
            }


            /*" -270- . */

        }

        [StopWatch]
        /*" P1000-PROCEDIMENTOS-INICIAIS-DB-SELECT-1 */
        public void P1000_PROCEDIMENTOS_INICIAIS_DB_SELECT_1()
        {
            /*" -254- EXEC SQL SELECT CURRENT DATE INTO :WS-DT-SISTEMA FROM SYSIBM.SYSDUMMY1 WITH UR END-EXEC */

            /*-- linha suprimida por comandos abaixo EXEC SQL
            /*--SELECT CURRENT DATE
            /*--INTO :WS-DT-SISTEMA
            /*--FROM SYSIBM.SYSDUMMY1
            /*--WITH UR
            /*--END-EXEC
            /*-- */

            _.Move(_.CurrentDate(), WS_DT_SISTEMA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P1000_FIM*/

        [StopWatch]
        /*" P2000-PROCEDIMENTOS-PRINCIPAIS */
        private void P2000_PROCEDIMENTOS_PRINCIPAIS(bool isPerform = false)
        {
            /*" -275- MOVE 'P2000-PROCEDIMENTOS-PRINCIPAIS' TO WS-LOCAL */
            _.Move("P2000-PROCEDIMENTOS-PRINCIPAIS", WS_ERROS.WS_LOCAL);

            /*" -275- PERFORM P2000_PROCEDIMENTOS_PRINCIPAIS_DB_OPEN_1 */

            P2000_PROCEDIMENTOS_PRINCIPAIS_DB_OPEN_1();

            /*" -277- MOVE SQLCODE TO WS-SQLCODE. */
            _.Move(DB.SQLCODE, WS_ERROS.WS_SQLCODE);

            /*" -278- MOVE SQLERRMC TO WS-SQLERRMC. */
            _.Move(DB.SQLERRMC, WS_ERROS.WS_SQLERRMC);

            /*" -279- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -282- DISPLAY 'ERRO DE OPEN CUR001 (SIAS)' 'SQLCODE = ' WS-SQLCODE ', SQLERRMC = ' WS-SQLERRMC */

                $"ERRO DE OPEN CUR001 (SIAS)SQLCODE = {WS_ERROS.WS_SQLCODE}, SQLERRMC = {WS_ERROS.WS_SQLERRMC}"
                .Display();

                /*" -283- PERFORM P9999-ERRO-SQL THRU P9999-FIM */

                P9999_ERRO_SQL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P9999_FIM*/


                /*" -284- END-IF */
            }


            /*" -285- PERFORM P2100-LER-CUR001 THRU P2100-FIM */

            P2100_LER_CUR001(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P2100_FIM*/


            /*" -286- PERFORM UNTIL WS-FIM-CUR001 = 'S' */

            while (!(WS_TRABALHOS.WS_FIM_CUR001 == "S"))
            {

                /*" -287- IF WS-CT-RESTITUICAO > 0 */

                if (WS_TRABALHOS.WS_CT_RESTITUICAO > 0)
                {

                    /*" -288- PERFORM P2200-TRATA-CONTRATO-SIAS THRU P2200-FIM */

                    P2200_TRATA_CONTRATO_SIAS(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: P2200_FIM*/


                    /*" -289- END-IF */
                }


                /*" -290- PERFORM P2100-LER-CUR001 THRU P2100-FIM */

                P2100_LER_CUR001(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P2100_FIM*/


                /*" -292- END-PERFORM */
            }

            /*" -292- PERFORM P2000_PROCEDIMENTOS_PRINCIPAIS_DB_OPEN_2 */

            P2000_PROCEDIMENTOS_PRINCIPAIS_DB_OPEN_2();

            /*" -294- MOVE SQLCODE TO WS-SQLCODE. */
            _.Move(DB.SQLCODE, WS_ERROS.WS_SQLCODE);

            /*" -295- MOVE SQLERRMC TO WS-SQLERRMC. */
            _.Move(DB.SQLERRMC, WS_ERROS.WS_SQLERRMC);

            /*" -296- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -299- DISPLAY 'ERRO DE OPEN CUR002 (EFP)' ' S,QLCODE = ' WS-SQLCODE ', SQLERRMC = ' WS-SQLERRMC */

                $"ERRO DE OPEN CUR002 (EFP) S,QLCODE = {WS_ERROS.WS_SQLCODE}, SQLERRMC = {WS_ERROS.WS_SQLERRMC}"
                .Display();

                /*" -300- PERFORM P9999-ERRO-SQL THRU P9999-FIM */

                P9999_ERRO_SQL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P9999_FIM*/


                /*" -301- END-IF */
            }


            /*" -302- PERFORM P2300-LER-CUR002 THRU P2300-FIM */

            P2300_LER_CUR002(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P2300_FIM*/


            /*" -303- PERFORM UNTIL WS-FIM-CUR002 = 'S' */

            while (!(WS_TRABALHOS.WS_FIM_CUR002 == "S"))
            {

                /*" -304- PERFORM P2400-TRATA-CONTRATO-EFP THRU P2400-FIM */

                P2400_TRATA_CONTRATO_EFP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P2400_FIM*/


                /*" -305- PERFORM P2300-LER-CUR002 THRU P2300-FIM */

                P2300_LER_CUR002(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P2300_FIM*/


                /*" -306- END-PERFORM */
            }

            /*" -306- PERFORM P2000_PROCEDIMENTOS_PRINCIPAIS_DB_CLOSE_1 */

            P2000_PROCEDIMENTOS_PRINCIPAIS_DB_CLOSE_1();

            /*" -308- MOVE SQLCODE TO WS-SQLCODE. */
            _.Move(DB.SQLCODE, WS_ERROS.WS_SQLCODE);

            /*" -309- MOVE SQLERRMC TO WS-SQLERRMC. */
            _.Move(DB.SQLERRMC, WS_ERROS.WS_SQLERRMC);

            /*" -310- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -313- DISPLAY 'ERRO DE OPEN CUR002 ' 'SQLCODE = ' WS-SQLCODE ', SQLERRMC = ' WS-SQLERRMC */

                $"ERRO DE OPEN CUR002 SQLCODE = {WS_ERROS.WS_SQLCODE}, SQLERRMC = {WS_ERROS.WS_SQLERRMC}"
                .Display();

                /*" -314- PERFORM P9999-ERRO-SQL THRU P9999-FIM */

                P9999_ERRO_SQL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P9999_FIM*/


                /*" -315- END-IF */
            }


            /*" -315- . */

        }

        [StopWatch]
        /*" P2000-PROCEDIMENTOS-PRINCIPAIS-DB-OPEN-1 */
        public void P2000_PROCEDIMENTOS_PRINCIPAIS_DB_OPEN_1()
        {
            /*" -275- EXEC SQL OPEN CUR001 END-EXEC */

            CUR001.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2000_FIM*/

        [StopWatch]
        /*" P2000-PROCEDIMENTOS-PRINCIPAIS-DB-CLOSE-1 */
        public void P2000_PROCEDIMENTOS_PRINCIPAIS_DB_CLOSE_1()
        {
            /*" -306- EXEC SQL CLOSE CUR002 END-EXEC */

            CUR002.Close();

        }

        [StopWatch]
        /*" P2000-PROCEDIMENTOS-PRINCIPAIS-DB-OPEN-2 */
        public void P2000_PROCEDIMENTOS_PRINCIPAIS_DB_OPEN_2()
        {
            /*" -292- EXEC SQL OPEN CUR002 END-EXEC */

            CUR002.Open();

        }

        [StopWatch]
        /*" P2100-LER-CUR001 */
        private void P2100_LER_CUR001(bool isPerform = false)
        {
            /*" -320- MOVE 'P2100-LER-CUR001' TO WS-LOCAL */
            _.Move("P2100-LER-CUR001", WS_ERROS.WS_LOCAL);

            /*" -325- INITIALIZE PROPOVA-COD-CLIENTE PROPOVA-TIMESTAMP PROPOFID-COD-PESSOA REPLACING ALPHANUMERIC BY SPACES NUMERIC BY ZEROES */
            _.Initialize(
                PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE
                , PROPOVA.DCLPROPOSTAS_VA.PROPOVA_TIMESTAMP
                , PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA
            );

            /*" -331- PERFORM P2100_LER_CUR001_DB_FETCH_1 */

            P2100_LER_CUR001_DB_FETCH_1();

            /*" -333- MOVE SQLCODE TO WS-SQLCODE. */
            _.Move(DB.SQLCODE, WS_ERROS.WS_SQLCODE);

            /*" -334- MOVE SQLERRMC TO WS-SQLERRMC. */
            _.Move(DB.SQLERRMC, WS_ERROS.WS_SQLERRMC);

            /*" -335-  EVALUATE SQLCODE  */

            /*" -336-  WHEN ZEROS  */

            /*" -336- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -337- ADD 1 TO WS-CT-SIAS */
                WS_TRABALHOS.WS_CT_SIAS.Value = WS_TRABALHOS.WS_CT_SIAS + 1;

                /*" -338- PERFORM P2110-VERIFICA-RESTITUICAO THRU P2110-FIM */

                P2110_VERIFICA_RESTITUICAO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P2110_FIM*/


                /*" -339-  WHEN 100  */

                /*" -339- ELSE IF   SQLCODE EQUALS  100 */
            }
            else

            if (DB.SQLCODE == 100)
            {

                /*" -340- MOVE 'S' TO WS-FIM-CUR001 */
                _.Move("S", WS_TRABALHOS.WS_FIM_CUR001);

                /*" -341-  WHEN OTHER  */

                /*" -341- ELSE */
            }
            else
            {


                /*" -344- DISPLAY 'ERRO DE FETCH CUR001 ' 'SQLCODE = ' WS-SQLCODE ', SQLERRMC = ' WS-SQLERRMC */

                $"ERRO DE FETCH CUR001 SQLCODE = {WS_ERROS.WS_SQLCODE}, SQLERRMC = {WS_ERROS.WS_SQLERRMC}"
                .Display();

                /*" -345- DISPLAY 'LOCAL= ' WS-LOCAL */
                _.Display($"LOCAL= {WS_ERROS.WS_LOCAL}");

                /*" -346- PERFORM P9999-ERRO-SQL THRU P9999-FIM */

                P9999_ERRO_SQL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P9999_FIM*/


                /*" -347-  END-EVALUATE  */

                /*" -347- END-IF */
            }


            /*" -347- . */

        }

        [StopWatch]
        /*" P2100-LER-CUR001-DB-FETCH-1 */
        public void P2100_LER_CUR001_DB_FETCH_1()
        {
            /*" -331- EXEC SQL FETCH CUR001 INTO :PROPOVA-TIMESTAMP ,:PROPOVA-NUM-CERTIFICADO ,:PROPOVA-COD-CLIENTE ,:PROPOFID-COD-PESSOA END-EXEC */

            if (CUR001.Fetch())
            {
                _.Move(CUR001.PROPOVA_TIMESTAMP, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_TIMESTAMP);
                _.Move(CUR001.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(CUR001.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(CUR001.PROPOFID_COD_PESSOA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2100_FIM*/

        [StopWatch]
        /*" P2110-VERIFICA-RESTITUICAO */
        private void P2110_VERIFICA_RESTITUICAO(bool isPerform = false)
        {
            /*" -352- MOVE 'P2110-VERIFICA-RESTITUICAO' TO WS-LOCAL */
            _.Move("P2110-VERIFICA-RESTITUICAO", WS_ERROS.WS_LOCAL);

            /*" -353- MOVE ZEROS TO WS-CT-RESTITUICAO */
            _.Move(0, WS_TRABALHOS.WS_CT_RESTITUICAO);

            /*" -361- PERFORM P2110_VERIFICA_RESTITUICAO_DB_SELECT_1 */

            P2110_VERIFICA_RESTITUICAO_DB_SELECT_1();

            /*" -363- MOVE SQLCODE TO WS-SQLCODE. */
            _.Move(DB.SQLCODE, WS_ERROS.WS_SQLCODE);

            /*" -364- MOVE SQLERRMC TO WS-SQLERRMC. */
            _.Move(DB.SQLERRMC, WS_ERROS.WS_SQLERRMC);

            /*" -365-  EVALUATE SQLCODE  */

            /*" -366-  WHEN ZEROS  */

            /*" -367-  WHEN 100  */

            /*" -367- IF   SQLCODE EQUALS ZEROS OR  100 */

            if (DB.SQLCODE.In("00", "100"))
            {

                /*" -368- CONTINUE */

                /*" -369-  WHEN OTHER  */

                /*" -369- ELSE */
            }
            else
            {


                /*" -373- DISPLAY 'ERRO DE SELECT RELATORIO ' ', NUM_CERTIFICADO= ' PROPOVA-NUM-CERTIFICADO ', SQLCODE = ' WS-SQLCODE ', SQLERRMC = ' WS-SQLERRMC */

                $"ERRO DE SELECT RELATORIO , NUM_CERTIFICADO= {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}, SQLCODE = {WS_ERROS.WS_SQLCODE}, SQLERRMC = {WS_ERROS.WS_SQLERRMC}"
                .Display();

                /*" -374- DISPLAY 'LOCAL= ' WS-LOCAL */
                _.Display($"LOCAL= {WS_ERROS.WS_LOCAL}");

                /*" -375- PERFORM P9999-ERRO-SQL THRU P9999-FIM */

                P9999_ERRO_SQL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P9999_FIM*/


                /*" -376-  END-EVALUATE  */

                /*" -376- END-IF */
            }


            /*" -376- . */

        }

        [StopWatch]
        /*" P2110-VERIFICA-RESTITUICAO-DB-SELECT-1 */
        public void P2110_VERIFICA_RESTITUICAO_DB_SELECT_1()
        {
            /*" -361- EXEC SQL SELECT COUNT(*) INTO :WS-CT-RESTITUICAO FROM SEGUROS.RELATORIOS RELATORI WHERE RELATORI.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND RELATORI.COD_RELATORIO = 'VA0469B' WITH UR END-EXEC */

            var p2110_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1 = new P2110_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = P2110_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1.Execute(p2110_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_CT_RESTITUICAO, WS_TRABALHOS.WS_CT_RESTITUICAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2110_FIM*/

        [StopWatch]
        /*" P2200-TRATA-CONTRATO-SIAS */
        private void P2200_TRATA_CONTRATO_SIAS(bool isPerform = false)
        {
            /*" -381- MOVE 'P2200-TRATA-CONTRATO-SIAS' TO WS-LOCAL */
            _.Move("P2200-TRATA-CONTRATO-SIAS", WS_ERROS.WS_LOCAL);

            /*" -382- MOVE SPACES TO VP1110S1-REG-DETALHE */
            _.Move("", VP1110S1_REG_DETALHE);

            /*" -384- MOVE ';' TO WS-VP1110-PV1 WS-VP1110-PV3 WS-VP1110-PV4 */
            _.Move(";", VP1110S1_REG_DETALHE.WS_VP1110_PV1, VP1110S1_REG_DETALHE.WS_VP1110_PV3, VP1110S1_REG_DETALHE.WS_VP1110_PV4);

            /*" -385- PERFORM P2210-BUSCA-DADOS-CLIENTE THRU P2210-FIM */

            P2210_BUSCA_DADOS_CLIENTE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P2210_FIM*/


            /*" -386- MOVE CLIENTES-CGCCPF TO WS-VP1110-GCS-CPF-CNPJ */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, VP1110S1_REG_DETALHE.WS_VP1110_GCS_CPF_CNPJ);

            /*" -389- PERFORM VARYING WS-I FROM 1 BY 1 UNTIL WS-I > 40 OR CLIENTES-NOME-RAZAO(WS-I:1) = ' ' */

            for (WS_TRABALHOS.WS_I.Value = 1; !(WS_TRABALHOS.WS_I > 40 || CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO.Substring(WS_TRABALHOS.WS_I, 1) == " "); WS_TRABALHOS.WS_I.Value += 1)
            {

                /*" -391- MOVE CLIENTES-NOME-RAZAO(WS-I:1) TO WS-VP1110-NOME(WS-I:1) */
                _.MoveAtPosition(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO.Substring(WS_TRABALHOS.WS_I, 1), VP1110S1_REG_DETALHE.WS_VP1110_NOME, WS_TRABALHOS.WS_I, 1);

                /*" -392- END-PERFORM */
            }

            /*" -393- PERFORM P2220-BUSCA-TELEFONE THRU P2220-FIM */

            P2220_BUSCA_TELEFONE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P2220_FIM*/


            /*" -394- MOVE DDD TO WS-VP1110-NUM-DDD */
            _.Move(PESFONE.DCLPESSOA_TELEFONE.DDD, VP1110S1_REG_DETALHE.WS_VP1110_NUM_DDD);

            /*" -395- MOVE NUM-FONE TO WS-VP1110-NUM-TELEFONE */
            _.Move(PESFONE.DCLPESSOA_TELEFONE.NUM_FONE, VP1110S1_REG_DETALHE.WS_VP1110_NUM_TELEFONE);

            /*" -396- MOVE PROPOVA-NUM-CERTIFICADO TO WS-VP1110-NUM-PROPOSTA */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, VP1110S1_REG_DETALHE.WS_VP1110_NUM_PROPOSTA);

            /*" -397- WRITE VP1110S1-REGISTRO FROM VP1110S1-REG-DETALHE */
            _.Move(VP1110S1_REG_DETALHE.GetMoveValues(), VP1110S1_REGISTRO);

            VP1110S1.Write(VP1110S1_REGISTRO.GetMoveValues().ToString());

            /*" -398- IF WS-FSTATUS-S1 NOT = ZEROS */

            if (WS_FSTATUS_S1 != 00)
            {

                /*" -400- DISPLAY 'ERRO SIAS DETALHE, ' 'FILE STATUS S1= ' WS-FSTATUS-S1 */

                $"ERRO SIAS DETALHE, FILE STATUS S1= {WS_FSTATUS_S1}"
                .Display();

                /*" -401- MOVE 16 TO RETURN-CODE */
                _.Move(16, RETURN_CODE);

                /*" -402- PERFORM P9999-ERRO-SQL THRU P9999-FIM */

                P9999_ERRO_SQL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P9999_FIM*/


                /*" -403- END-IF */
            }


            /*" -404- ADD 1 TO WS-CT-GRAVADOS-SIAS */
            WS_TRABALHOS.WS_CT_GRAVADOS_SIAS.Value = WS_TRABALHOS.WS_CT_GRAVADOS_SIAS + 1;

            /*" -404- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2200_FIM*/

        [StopWatch]
        /*" P2210-BUSCA-DADOS-CLIENTE */
        private void P2210_BUSCA_DADOS_CLIENTE(bool isPerform = false)
        {
            /*" -409- MOVE 'P2210-BUSCA-DADOS-CLIENTE' TO WS-LOCAL */
            _.Move("P2210-BUSCA-DADOS-CLIENTE", WS_ERROS.WS_LOCAL);

            /*" -413- INITIALIZE CLIENTES-CGCCPF CLIENTES-NOME-RAZAO REPLACING ALPHANUMERIC BY SPACES NUMERIC BY ZEROES */
            _.Initialize(
                CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF
                , CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO
            );

            /*" -421- PERFORM P2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1 */

            P2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1();

            /*" -423- MOVE SQLCODE TO WS-SQLCODE. */
            _.Move(DB.SQLCODE, WS_ERROS.WS_SQLCODE);

            /*" -424- MOVE SQLERRMC TO WS-SQLERRMC. */
            _.Move(DB.SQLERRMC, WS_ERROS.WS_SQLERRMC);

            /*" -425-  EVALUATE SQLCODE  */

            /*" -426-  WHEN ZEROS  */

            /*" -427-  WHEN 100  */

            /*" -427- IF   SQLCODE EQUALS ZEROS OR  100 */

            if (DB.SQLCODE.In("00", "100"))
            {

                /*" -428- CONTINUE */

                /*" -429-  WHEN OTHER  */

                /*" -429- ELSE */
            }
            else
            {


                /*" -433- DISPLAY 'ERRO DE SELECT CLIENTES ' ', COD_PESSOA= ' PROPOFID-COD-PESSOA 'SQLCODE = ' WS-SQLCODE ', SQLERRMC = ' WS-SQLERRMC */

                $"ERRO DE SELECT CLIENTES , COD_PESSOA= {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}SQLCODE = {WS_ERROS.WS_SQLCODE}, SQLERRMC = {WS_ERROS.WS_SQLERRMC}"
                .Display();

                /*" -434- DISPLAY 'LOCAL= ' WS-LOCAL */
                _.Display($"LOCAL= {WS_ERROS.WS_LOCAL}");

                /*" -435- PERFORM P9999-ERRO-SQL THRU P9999-FIM */

                P9999_ERRO_SQL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P9999_FIM*/


                /*" -436-  END-EVALUATE  */

                /*" -436- END-IF */
            }


            /*" -436- . */

        }

        [StopWatch]
        /*" P2210-BUSCA-DADOS-CLIENTE-DB-SELECT-1 */
        public void P2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1()
        {
            /*" -421- EXEC SQL SELECT CLIENTES.CGCCPF ,VALUE(CLIENTES.NOME_RAZAO, ' ' ) INTO :CLIENTES-CGCCPF ,:CLIENTES-NOME-RAZAO FROM SEGUROS.CLIENTES CLIENTES WHERE CLIENTES.COD_CLIENTE = :PROPOVA-COD-CLIENTE WITH UR END-EXEC */

            var p2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1_Query1 = new P2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            var executed_1 = P2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1_Query1.Execute(p2210_BUSCA_DADOS_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2210_FIM*/

        [StopWatch]
        /*" P2220-BUSCA-TELEFONE */
        private void P2220_BUSCA_TELEFONE(bool isPerform = false)
        {
            /*" -441- MOVE 'P2220-BUSCA-TELEFONE' TO WS-LOCAL */
            _.Move("P2220-BUSCA-TELEFONE", WS_ERROS.WS_LOCAL);

            /*" -445- INITIALIZE DDD NUM-FONE REPLACING ALPHANUMERIC BY SPACES NUMERIC BY ZEROES */
            _.Initialize(
                PESFONE.DCLPESSOA_TELEFONE.DDD
                , PESFONE.DCLPESSOA_TELEFONE.NUM_FONE
            );

            /*" -455- PERFORM P2220_BUSCA_TELEFONE_DB_SELECT_1 */

            P2220_BUSCA_TELEFONE_DB_SELECT_1();

            /*" -457- MOVE SQLCODE TO WS-SQLCODE. */
            _.Move(DB.SQLCODE, WS_ERROS.WS_SQLCODE);

            /*" -458- MOVE SQLERRMC TO WS-SQLERRMC. */
            _.Move(DB.SQLERRMC, WS_ERROS.WS_SQLERRMC);

            /*" -459-  EVALUATE SQLCODE  */

            /*" -460-  WHEN ZEROS  */

            /*" -461-  WHEN 100  */

            /*" -461- IF   SQLCODE EQUALS ZEROS OR  100 */

            if (DB.SQLCODE.In("00", "100"))
            {

                /*" -462- CONTINUE */

                /*" -463-  WHEN OTHER  */

                /*" -463- ELSE */
            }
            else
            {


                /*" -467- DISPLAY 'ERRO DE SELECT PESSOA_TELEFONE PESFONE ' ', COD_PESSOA= ' PROPOFID-COD-PESSOA 'SQLCODE = ' WS-SQLCODE ', SQLERRMC = ' WS-SQLERRMC */

                $"ERRO DE SELECT PESSOA_TELEFONE PESFONE , COD_PESSOA= {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}SQLCODE = {WS_ERROS.WS_SQLCODE}, SQLERRMC = {WS_ERROS.WS_SQLERRMC}"
                .Display();

                /*" -468- DISPLAY 'LOCAL= ' WS-LOCAL */
                _.Display($"LOCAL= {WS_ERROS.WS_LOCAL}");

                /*" -469- PERFORM P9999-ERRO-SQL THRU P9999-FIM */

                P9999_ERRO_SQL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P9999_FIM*/


                /*" -470-  END-EVALUATE  */

                /*" -470- END-IF */
            }


            /*" -470- . */

        }

        [StopWatch]
        /*" P2220-BUSCA-TELEFONE-DB-SELECT-1 */
        public void P2220_BUSCA_TELEFONE_DB_SELECT_1()
        {
            /*" -455- EXEC SQL SELECT PESFONE.DDD ,PESFONE.NUM_FONE INTO :DDD ,:NUM-FONE FROM SEGUROS.PESSOA_TELEFONE PESFONE WHERE PESFONE.COD_PESSOA = :PROPOFID-COD-PESSOA AND PESFONE.TIPO_FONE IN (3, 4) FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var p2220_BUSCA_TELEFONE_DB_SELECT_1_Query1 = new P2220_BUSCA_TELEFONE_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = P2220_BUSCA_TELEFONE_DB_SELECT_1_Query1.Execute(p2220_BUSCA_TELEFONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);
                _.Move(executed_1.NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2220_FIM*/

        [StopWatch]
        /*" P2300-LER-CUR002 */
        private void P2300_LER_CUR002(bool isPerform = false)
        {
            /*" -475- MOVE 'P2300-LER-CUR002' TO WS-LOCAL */
            _.Move("P2300-LER-CUR002", WS_ERROS.WS_LOCAL);

            /*" -478- INITIALIZE DCLEF-ENVIO-MOVTO-SAP REPLACING ALPHANUMERIC BY SPACES NUMERIC BY ZEROES */
            _.Initialize(
                EF150.DCLEF_ENVIO_MOVTO_SAP
            );

            /*" -487- PERFORM P2300_LER_CUR002_DB_FETCH_1 */

            P2300_LER_CUR002_DB_FETCH_1();

            /*" -489- MOVE SQLCODE TO WS-SQLCODE. */
            _.Move(DB.SQLCODE, WS_ERROS.WS_SQLCODE);

            /*" -490- MOVE SQLERRMC TO WS-SQLERRMC. */
            _.Move(DB.SQLERRMC, WS_ERROS.WS_SQLERRMC);

            /*" -491-  EVALUATE SQLCODE  */

            /*" -492-  WHEN ZEROS  */

            /*" -492- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -493- ADD 1 TO WS-CT-EFP */
                WS_TRABALHOS.WS_CT_EFP.Value = WS_TRABALHOS.WS_CT_EFP + 1;

                /*" -494-  WHEN 100  */

                /*" -494- ELSE IF   SQLCODE EQUALS  100 */
            }
            else

            if (DB.SQLCODE == 100)
            {

                /*" -495- MOVE 'S' TO WS-FIM-CUR002 */
                _.Move("S", WS_TRABALHOS.WS_FIM_CUR002);

                /*" -496-  WHEN OTHER  */

                /*" -496- ELSE */
            }
            else
            {


                /*" -499- DISPLAY 'ERRO DE SELECT EF_ENVIO_MOVTO_SAP EF150 ' 'SQLCODE = ' WS-SQLCODE ', SQLERRMC = ' WS-SQLERRMC */

                $"ERRO DE SELECT EF_ENVIO_MOVTO_SAP EF150 SQLCODE = {WS_ERROS.WS_SQLCODE}, SQLERRMC = {WS_ERROS.WS_SQLERRMC}"
                .Display();

                /*" -500- DISPLAY 'LOCAL= ' WS-LOCAL */
                _.Display($"LOCAL= {WS_ERROS.WS_LOCAL}");

                /*" -501- PERFORM P9999-ERRO-SQL THRU P9999-FIM */

                P9999_ERRO_SQL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P9999_FIM*/


                /*" -502-  END-EVALUATE  */

                /*" -502- END-IF */
            }


            /*" -502- . */

        }

        [StopWatch]
        /*" P2300-LER-CUR002-DB-FETCH-1 */
        public void P2300_LER_CUR002_DB_FETCH_1()
        {
            /*" -487- EXEC SQL FETCH CUR002 INTO :EF150-NUM-OCORR-MOVTO ,:EF150-NUM-CONTRATO-SEGUR ,:EF150-NUM-CONTR-TERC ,:EF150-COD-PRODUTO ,:EF050-DTH-FIM-VIGENCIA ,:EF150-DTH-ATUALIZACAO ,:EF150-VLR-RESTITUIR END-EXEC */

            if (CUR002.Fetch())
            {
                _.Move(CUR002.EF150_NUM_OCORR_MOVTO, EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_NUM_OCORR_MOVTO);
                _.Move(CUR002.EF150_NUM_CONTRATO_SEGUR, EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_NUM_CONTRATO_SEGUR);
                _.Move(CUR002.EF150_NUM_CONTR_TERC, EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_NUM_CONTR_TERC);
                _.Move(CUR002.EF150_COD_PRODUTO, EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_COD_PRODUTO);
                _.Move(CUR002.EF050_DTH_FIM_VIGENCIA, EF050.DCLEF_CONTRATO.EF050_DTH_FIM_VIGENCIA);
                _.Move(CUR002.EF150_DTH_ATUALIZACAO, EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_DTH_ATUALIZACAO);
                _.Move(CUR002.EF150_VLR_RESTITUIR, EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_VLR_RESTITUIR);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2300_FIM*/

        [StopWatch]
        /*" P2400-TRATA-CONTRATO-EFP */
        private void P2400_TRATA_CONTRATO_EFP(bool isPerform = false)
        {
            /*" -507- MOVE 'P2400-TRATA-CONTRATO-EFP' TO WS-LOCAL */
            _.Move("P2400-TRATA-CONTRATO-EFP", WS_ERROS.WS_LOCAL);

            /*" -508- MOVE SPACES TO VP1110S1-REG-DETALHE */
            _.Move("", VP1110S1_REG_DETALHE);

            /*" -510- MOVE ';' TO WS-VP1110-PV1 WS-VP1110-PV3 WS-VP1110-PV4 */
            _.Move(";", VP1110S1_REG_DETALHE.WS_VP1110_PV1, VP1110S1_REG_DETALHE.WS_VP1110_PV3, VP1110S1_REG_DETALHE.WS_VP1110_PV4);

            /*" -511- MOVE EF150-NUM-CONTR-TERC TO WS-VP1110-NUM-PROPOSTA */
            _.Move(EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_NUM_CONTR_TERC, VP1110S1_REG_DETALHE.WS_VP1110_NUM_PROPOSTA);

            /*" -512- PERFORM P2410-BUSCA-GEPESSOA THRU P2410-FIM */

            P2410_BUSCA_GEPESSOA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P2410_FIM*/


            /*" -515- PERFORM VARYING WS-I FROM 1 BY 1 UNTIL WS-I > 60 OR GEPESSOA-NOM-PESSOA(WS-I:1) = ' ' */

            for (WS_TRABALHOS.WS_I.Value = 1; !(WS_TRABALHOS.WS_I > 60 || GEPESSOA.DCLGE_PESSOA.GEPESSOA_NOM_PESSOA.Substring(WS_TRABALHOS.WS_I, 1) == " "); WS_TRABALHOS.WS_I.Value += 1)
            {

                /*" -517- MOVE GEPESSOA-NOM-PESSOA(WS-I:1) TO WS-VP1110-NOME(WS-I:1) */
                _.MoveAtPosition(GEPESSOA.DCLGE_PESSOA.GEPESSOA_NOM_PESSOA.Substring(WS_TRABALHOS.WS_I, 1), VP1110S1_REG_DETALHE.WS_VP1110_NOME, WS_TRABALHOS.WS_I, 1);

                /*" -518- END-PERFORM */
            }

            /*" -519- PERFORM P2420-BUSCA-CPF THRU P2420-FIM */

            P2420_BUSCA_CPF(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P2420_FIM*/


            /*" -520- MOVE GEPESFIS-NUM-CPF TO WS-VP1110-GCS-CPF-CNPJ */
            _.Move(GEPESFIS.DCLGE_PESSOA_FISICA.GEPESFIS_NUM_CPF, VP1110S1_REG_DETALHE.WS_VP1110_GCS_CPF_CNPJ);

            /*" -521- PERFORM P2430-BUSCA-TELEFONE THRU P2430-FIM */

            P2430_BUSCA_TELEFONE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P2430_FIM*/


            /*" -522- MOVE GEPESTEL-NUM-DDD TO WS-VP1110-NUM-DDD */
            _.Move(GEPESTEL.DCLGE_PESSOA_TELEFONE.GEPESTEL_NUM_DDD, VP1110S1_REG_DETALHE.WS_VP1110_NUM_DDD);

            /*" -523- MOVE GEPESTEL-NUM-TELEFONE TO WS-VP1110-NUM-TELEFONE */
            _.Move(GEPESTEL.DCLGE_PESSOA_TELEFONE.GEPESTEL_NUM_TELEFONE, VP1110S1_REG_DETALHE.WS_VP1110_NUM_TELEFONE);

            /*" -524- WRITE VP1110S1-REGISTRO FROM VP1110S1-REG-DETALHE */
            _.Move(VP1110S1_REG_DETALHE.GetMoveValues(), VP1110S1_REGISTRO);

            VP1110S1.Write(VP1110S1_REGISTRO.GetMoveValues().ToString());

            /*" -525- IF WS-FSTATUS-S1 NOT = ZEROS */

            if (WS_FSTATUS_S1 != 00)
            {

                /*" -527- DISPLAY 'ERRO EFP DETALHE, ' 'FILE STATUS S1= ' WS-FSTATUS-S1 */

                $"ERRO EFP DETALHE, FILE STATUS S1= {WS_FSTATUS_S1}"
                .Display();

                /*" -528- MOVE 16 TO RETURN-CODE */
                _.Move(16, RETURN_CODE);

                /*" -529- PERFORM P9999-ERRO-SQL THRU P9999-FIM */

                P9999_ERRO_SQL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P9999_FIM*/


                /*" -530- END-IF */
            }


            /*" -531- ADD 1 TO WS-CT-GRAVADOS-EFP */
            WS_TRABALHOS.WS_CT_GRAVADOS_EFP.Value = WS_TRABALHOS.WS_CT_GRAVADOS_EFP + 1;

            /*" -531- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2400_FIM*/

        [StopWatch]
        /*" P2410-BUSCA-GEPESSOA */
        private void P2410_BUSCA_GEPESSOA(bool isPerform = false)
        {
            /*" -536- MOVE 'P2410-BUSCA-GEPESSOA' TO WS-LOCAL */
            _.Move("P2410-BUSCA-GEPESSOA", WS_ERROS.WS_LOCAL);

            /*" -540- INITIALIZE GEPESSOA-COD-PESSOA GEPESSOA-NOM-PESSOA REPLACING ALPHANUMERIC BY SPACES NUMERIC BY ZEROES */
            _.Initialize(
                GEPESSOA.DCLGE_PESSOA.GEPESSOA_COD_PESSOA
                , GEPESSOA.DCLGE_PESSOA.GEPESSOA_NOM_PESSOA
            );

            /*" -552- PERFORM P2410_BUSCA_GEPESSOA_DB_SELECT_1 */

            P2410_BUSCA_GEPESSOA_DB_SELECT_1();

            /*" -554- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_ERROS.WS_SQLCODE);

            /*" -555- MOVE SQLERRMC TO WS-SQLERRMC */
            _.Move(DB.SQLERRMC, WS_ERROS.WS_SQLERRMC);

            /*" -556-  EVALUATE SQLCODE  */

            /*" -557-  WHEN ZEROS  */

            /*" -558-  WHEN 100  */

            /*" -558- IF   SQLCODE EQUALS ZEROS OR  100 */

            if (DB.SQLCODE.In("00", "100"))
            {

                /*" -559- CONTINUE */

                /*" -560-  WHEN OTHER  */

                /*" -560- ELSE */
            }
            else
            {


                /*" -565- DISPLAY '* VP1110B ' WS-LOCAL ' ERRO SELECT EF079 - SEGUROS.EF_SEGURADO_OBJETO ' 'CONTR SEGUR= ' EF150-NUM-CONTRATO-SEGUR ' SQLCODE ' WS-SQLCODE ' SQLERRMC ' WS-SQLERRMC */

                $"* VP1110B {WS_ERROS.WS_LOCAL} ERRO SELECT EF079 - SEGUROS.EF_SEGURADO_OBJETO CONTR SEGUR= {EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_NUM_CONTRATO_SEGUR} SQLCODE {WS_ERROS.WS_SQLCODE} SQLERRMC {WS_ERROS.WS_SQLERRMC}"
                .Display();

                /*" -566- PERFORM P9999-ERRO-SQL THRU P9999-FIM */

                P9999_ERRO_SQL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P9999_FIM*/


                /*" -567-  END-EVALUATE  */

                /*" -567- END-IF */
            }


            /*" -567- . */

        }

        [StopWatch]
        /*" P2410-BUSCA-GEPESSOA-DB-SELECT-1 */
        public void P2410_BUSCA_GEPESSOA_DB_SELECT_1()
        {
            /*" -552- EXEC SQL SELECT GEPESSOA.COD_PESSOA ,VALUE(GEPESSOA.NOM_PESSOA, ' ' ) INTO :GEPESSOA-COD-PESSOA ,:GEPESSOA-NOM-PESSOA FROM SEGUROS.EF_SEGURADO_OBJETO EF079 ,SEGUROS.GE_PESSOA GEPESSOA WHERE EF079.NUM_CONTRATO_SEGUR = :EF150-NUM-CONTRATO-SEGUR AND EF079.COD_PESSOA_CONTRTE = GEPESSOA.COD_PESSOA FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var p2410_BUSCA_GEPESSOA_DB_SELECT_1_Query1 = new P2410_BUSCA_GEPESSOA_DB_SELECT_1_Query1()
            {
                EF150_NUM_CONTRATO_SEGUR = EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_NUM_CONTRATO_SEGUR.ToString(),
            };

            var executed_1 = P2410_BUSCA_GEPESSOA_DB_SELECT_1_Query1.Execute(p2410_BUSCA_GEPESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEPESSOA_COD_PESSOA, GEPESSOA.DCLGE_PESSOA.GEPESSOA_COD_PESSOA);
                _.Move(executed_1.GEPESSOA_NOM_PESSOA, GEPESSOA.DCLGE_PESSOA.GEPESSOA_NOM_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2410_FIM*/

        [StopWatch]
        /*" P2420-BUSCA-CPF */
        private void P2420_BUSCA_CPF(bool isPerform = false)
        {
            /*" -572- MOVE 'P2420-BUSCA-CPF' TO WS-LOCAL */
            _.Move("P2420-BUSCA-CPF", WS_ERROS.WS_LOCAL);

            /*" -573- MOVE ZEROS TO GEPESFIS-NUM-CPF */
            _.Move(0, GEPESFIS.DCLGE_PESSOA_FISICA.GEPESFIS_NUM_CPF);

            /*" -579- PERFORM P2420_BUSCA_CPF_DB_SELECT_1 */

            P2420_BUSCA_CPF_DB_SELECT_1();

            /*" -581- MOVE SQLCODE TO WS-SQLCODE. */
            _.Move(DB.SQLCODE, WS_ERROS.WS_SQLCODE);

            /*" -582- MOVE SQLERRMC TO WS-SQLERRMC. */
            _.Move(DB.SQLERRMC, WS_ERROS.WS_SQLERRMC);

            /*" -583-  EVALUATE SQLCODE  */

            /*" -584-  WHEN ZEROS  */

            /*" -585-  WHEN 100  */

            /*" -585- IF   SQLCODE EQUALS ZEROS OR  100 */

            if (DB.SQLCODE.In("00", "100"))
            {

                /*" -586- CONTINUE */

                /*" -587-  WHEN OTHER  */

                /*" -587- ELSE */
            }
            else
            {


                /*" -591- DISPLAY 'ERRO DE SELECT GEPESFIS GE_PESSOA_FISICA ' 'COD-PESSOA= ' GEPESSOA-COD-PESSOA ' SQLCODE = ' WS-SQLCODE ', SQLERRMC = ' WS-SQLERRMC */

                $"ERRO DE SELECT GEPESFIS GE_PESSOA_FISICA COD-PESSOA= {GEPESSOA.DCLGE_PESSOA.GEPESSOA_COD_PESSOA} SQLCODE = {WS_ERROS.WS_SQLCODE}, SQLERRMC = {WS_ERROS.WS_SQLERRMC}"
                .Display();

                /*" -592- PERFORM P9999-ERRO-SQL THRU P9999-FIM */

                P9999_ERRO_SQL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P9999_FIM*/


                /*" -593-  END-EVALUATE  */

                /*" -593- END-IF */
            }


            /*" -593- . */

        }

        [StopWatch]
        /*" P2420-BUSCA-CPF-DB-SELECT-1 */
        public void P2420_BUSCA_CPF_DB_SELECT_1()
        {
            /*" -579- EXEC SQL SELECT VALUE(GEPESFIS.NUM_CPF, 0) INTO :GEPESFIS-NUM-CPF FROM SEGUROS.GE_PESSOA_FISICA GEPESFIS WHERE GEPESFIS.COD_PESSOA = :GEPESSOA-COD-PESSOA WITH UR END-EXEC */

            var p2420_BUSCA_CPF_DB_SELECT_1_Query1 = new P2420_BUSCA_CPF_DB_SELECT_1_Query1()
            {
                GEPESSOA_COD_PESSOA = GEPESSOA.DCLGE_PESSOA.GEPESSOA_COD_PESSOA.ToString(),
            };

            var executed_1 = P2420_BUSCA_CPF_DB_SELECT_1_Query1.Execute(p2420_BUSCA_CPF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEPESFIS_NUM_CPF, GEPESFIS.DCLGE_PESSOA_FISICA.GEPESFIS_NUM_CPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2420_FIM*/

        [StopWatch]
        /*" P2430-BUSCA-TELEFONE */
        private void P2430_BUSCA_TELEFONE(bool isPerform = false)
        {
            /*" -598- MOVE 'P2430-BUSCA-TELEFONE' TO WS-LOCAL */
            _.Move("P2430-BUSCA-TELEFONE", WS_ERROS.WS_LOCAL);

            /*" -600- INITIALIZE GEPESTEL-NUM-TELEFONE GEPESTEL-NUM-DDD */
            _.Initialize(
                GEPESTEL.DCLGE_PESSOA_TELEFONE.GEPESTEL_NUM_TELEFONE
                , GEPESTEL.DCLGE_PESSOA_TELEFONE.GEPESTEL_NUM_DDD
            );

            /*" -617- PERFORM P2430_BUSCA_TELEFONE_DB_SELECT_1 */

            P2430_BUSCA_TELEFONE_DB_SELECT_1();

            /*" -619- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_ERROS.WS_SQLCODE);

            /*" -620- MOVE SQLERRMC TO WS-SQLERRMC */
            _.Move(DB.SQLERRMC, WS_ERROS.WS_SQLERRMC);

            /*" -621-  EVALUATE SQLCODE  */

            /*" -622-  WHEN ZEROS  */

            /*" -623-  WHEN 100  */

            /*" -623- IF   SQLCODE EQUALS ZEROS OR  100 */

            if (DB.SQLCODE.In("00", "100"))
            {

                /*" -624- CONTINUE */

                /*" -625-  WHEN OTHER  */

                /*" -625- ELSE */
            }
            else
            {


                /*" -629- DISPLAY '* VP1110B ' WS-LOCAL ' ERRO SELECT GEPESTEL - GE_PESSOA_TELEFONE' ', COD-PESSOA= ' GEPESSOA-COD-PESSOA ' SQLCODE ' WS-SQLCODE ' SQLERRMC ' WS-SQLERRMC */

                $"* VP1110B {WS_ERROS.WS_LOCAL} ERRO SELECT GEPESTEL - GE_PESSOA_TELEFONE, COD-PESSOA= {GEPESSOA.DCLGE_PESSOA.GEPESSOA_COD_PESSOA} SQLCODE {WS_ERROS.WS_SQLCODE} SQLERRMC {WS_ERROS.WS_SQLERRMC}"
                .Display();

                /*" -630- PERFORM P9999-ERRO-SQL THRU P9999-FIM */

                P9999_ERRO_SQL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P9999_FIM*/


                /*" -631-  END-EVALUATE  */

                /*" -631- END-IF */
            }


            /*" -631- . */

        }

        [StopWatch]
        /*" P2430-BUSCA-TELEFONE-DB-SELECT-1 */
        public void P2430_BUSCA_TELEFONE_DB_SELECT_1()
        {
            /*" -617- EXEC SQL SELECT GEPESTEL.NUM_TELEFONE ,GEPESTEL.NUM_DDD INTO :GEPESTEL-NUM-TELEFONE ,:GEPESTEL-NUM-DDD FROM SEGUROS.GE_PESSOA_TELEFONE GEPESTEL WHERE GEPESTEL.COD_PESSOA = :GEPESSOA-COD-PESSOA AND SUBSTR(CHAR(GEPESTEL.NUM_TELEFONE),1,1) IN ( '7' , '8' , '9' ) AND GEPESTEL.SEQ_TELEFONE = (SELECT MAX(GEPESTELB.SEQ_TELEFONE) FROM SEGUROS.GE_PESSOA_TELEFONE GEPESTELB WHERE GEPESTELB.COD_PESSOA = GEPESTEL.COD_PESSOA AND SUBSTR(CHAR(GEPESTELB.NUM_TELEFONE),1,1) IN ( '7' , '8' , '9' )) WITH UR END-EXEC */

            var p2430_BUSCA_TELEFONE_DB_SELECT_1_Query1 = new P2430_BUSCA_TELEFONE_DB_SELECT_1_Query1()
            {
                GEPESSOA_COD_PESSOA = GEPESSOA.DCLGE_PESSOA.GEPESSOA_COD_PESSOA.ToString(),
            };

            var executed_1 = P2430_BUSCA_TELEFONE_DB_SELECT_1_Query1.Execute(p2430_BUSCA_TELEFONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEPESTEL_NUM_TELEFONE, GEPESTEL.DCLGE_PESSOA_TELEFONE.GEPESTEL_NUM_TELEFONE);
                _.Move(executed_1.GEPESTEL_NUM_DDD, GEPESTEL.DCLGE_PESSOA_TELEFONE.GEPESTEL_NUM_DDD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2430_FIM*/

        [StopWatch]
        /*" P9000-PROCEDIMENTOS-FINAIS */
        private void P9000_PROCEDIMENTOS_FINAIS(bool isPerform = false)
        {
            /*" -637- MOVE 'P9000-PROCEDIMENTOS-FINAIS' TO WS-LOCAL */
            _.Move("P9000-PROCEDIMENTOS-FINAIS", WS_ERROS.WS_LOCAL);

            /*" -638- CLOSE VP1110S1 */
            VP1110S1.Close();

            /*" -639- IF WS-FSTATUS-S1 NOT = ZEROS */

            if (WS_FSTATUS_S1 != 00)
            {

                /*" -641- DISPLAY 'ERRO CLOSE VP1110S1, ' 'FILE STATUS 1= ' WS-FSTATUS-S1 */

                $"ERRO CLOSE VP1110S1, FILE STATUS 1= {WS_FSTATUS_S1}"
                .Display();

                /*" -642- MOVE 16 TO RETURN-CODE */
                _.Move(16, RETURN_CODE);

                /*" -643- PERFORM P9999-ERRO-SQL THRU P9999-FIM */

                P9999_ERRO_SQL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P9999_FIM*/


                /*" -644- END-IF */
            }


            /*" -645- DISPLAY ' ' */
            _.Display($" ");

            /*" -646- DISPLAY '*---------------------------------*' */
            _.Display($"*---------------------------------*");

            /*" -647- DISPLAY '** VP1110B  PROCESSAMENTO NORMAL **' */
            _.Display($"** VP1110B  PROCESSAMENTO NORMAL **");

            /*" -648- DISPLAY '*---------------------------------*' */
            _.Display($"*---------------------------------*");

            /*" -649- DISPLAY 'TOTAL LIDO EFP ------> ' WS-CT-EFP */
            _.Display($"TOTAL LIDO EFP ------> {WS_TRABALHOS.WS_CT_EFP}");

            /*" -650- DISPLAY 'TOTAL LIDO SIAS------> ' WS-CT-SIAS */
            _.Display($"TOTAL LIDO SIAS------> {WS_TRABALHOS.WS_CT_SIAS}");

            /*" -651- DISPLAY 'QTD-REG-GRAVADOS SIAS= ' WS-CT-GRAVADOS-SIAS */
            _.Display($"QTD-REG-GRAVADOS SIAS= {WS_TRABALHOS.WS_CT_GRAVADOS_SIAS}");

            /*" -652- DISPLAY 'QTD-REG-GRAVADOS EFP = ' WS-CT-GRAVADOS-EFP */
            _.Display($"QTD-REG-GRAVADOS EFP = {WS_TRABALHOS.WS_CT_GRAVADOS_EFP}");

            /*" -653- DISPLAY '*---------------------------------*' */
            _.Display($"*---------------------------------*");

            /*" -662- DISPLAY '*-- FINALIZOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '.' FUNCTION CURRENT-DATE(05:2) '.' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"*-- FINALIZOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}.{_.CurrentDateAsDate():MM}.{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -663- GOBACK */

            throw new GoBack();

            /*" -663- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P9000_FIM*/

        [StopWatch]
        /*" P9999-ERRO-SQL */
        private void P9999_ERRO_SQL(bool isPerform = false)
        {
            /*" -669- DISPLAY ' ' */
            _.Display($" ");

            /*" -670- CLOSE VP1110S1 */
            VP1110S1.Close();

            /*" -671- IF WS-FSTATUS-S1 NOT = ZEROS */

            if (WS_FSTATUS_S1 != 00)
            {

                /*" -672- DISPLAY 'FILE STATUS 1= ' WS-FSTATUS-S1 */
                _.Display($"FILE STATUS 1= {WS_FSTATUS_S1}");

                /*" -673- MOVE 16 TO RETURN-CODE */
                _.Move(16, RETURN_CODE);

                /*" -674- END-IF */
            }


            /*" -675- DISPLAY '*---------------------------------*' */
            _.Display($"*---------------------------------*");

            /*" -676- DISPLAY '*       ----> ATENCAO <----       *' */
            _.Display($"*       ----> ATENCAO <----       *");

            /*" -677- DISPLAY '*  VP1110B PROCESSAMENTO ANORMAL  *' */
            _.Display($"*  VP1110B PROCESSAMENTO ANORMAL  *");

            /*" -678- DISPLAY '*       ----> ATENCAO <----       *' */
            _.Display($"*       ----> ATENCAO <----       *");

            /*" -679- DISPLAY '*---------------------------------*' */
            _.Display($"*---------------------------------*");

            /*" -680- DISPLAY 'PARAGRAFO         ==> ' WS-LOCAL */
            _.Display($"PARAGRAFO         ==> {WS_ERROS.WS_LOCAL}");

            /*" -681- DISPLAY 'SQLCODE           ==> ' WS-SQLCODE */
            _.Display($"SQLCODE           ==> {WS_ERROS.WS_SQLCODE}");

            /*" -683- DISPLAY 'SQLERRMC          ==> ' WS-SQLERRMC */
            _.Display($"SQLERRMC          ==> {WS_ERROS.WS_SQLERRMC}");

            /*" -684- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -685- DISPLAY '*---------------------------*' */
            _.Display($"*---------------------------*");

            /*" -693- DISPLAY '*** ERRO NO PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) ' ***' */

            $"*** ERRO NO PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss} ***"
            .Display();

            /*" -694- GOBACK */

            throw new GoBack();

            /*" -694- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P9999_FIM*/
    }
}