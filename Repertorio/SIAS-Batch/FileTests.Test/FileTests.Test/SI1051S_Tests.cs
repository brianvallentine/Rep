using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.SI1051S;

namespace FileTests.Test
{
    [Collection("SI1051S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SI1051S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R100_ROTINA_CRITICA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_EMPRESA" , ""},
                { "SINISHIS_TIPO_REGISTRO" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_HORA_OPERACAO" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_DATA_LIM_CORRECAO" , ""},
                { "SINISHIS_TIPO_FAVORECIDO" , ""},
                { "SINISHIS_DATA_NEGOCIADA" , ""},
                { "SINISHIS_FONTE_PAGAMENTO" , ""},
                { "SINISHIS_COD_PREST_SERVICO" , ""},
                { "SINISHIS_COD_SERVICO" , ""},
                { "SINISHIS_ORDEM_PAGAMENTO" , ""},
                { "SINISHIS_NUM_RECIBO" , ""},
                { "SINISHIS_NUM_MOV_SINISTRO" , ""},
                { "SINISHIS_COD_USUARIO" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_SIT_REGISTRO" , ""},
                { "SINISHIS_TIMESTAMP" , ""},
                { "SINISHIS_NUM_APOLICE" , ""},
                { "SINISHIS_COD_PRODUTO" , ""},
                { "SINISHIS_NOM_PROGRAMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R100_ROTINA_CRITICA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R100_ROTINA_CRITICA_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SI111_NUM_APOL_SINISTRO" , ""},
                { "SI111_OCORR_HISTORICO" , ""},
                { "SI111_COD_OPERACAO" , ""},
                { "SI111_NUM_RESSARC" , ""},
                { "SI111_SEQ_RESSARC" , ""},
                { "SI111_NUM_PARCELA" , ""},
                { "SI111_COD_AGENCIA_CEDENT" , ""},
                { "SI111_COD_SISTEMA_ORIGEM" , ""},
                { "SI111_NUM_CEDENTE" , ""},
                { "SI111_NUM_CEDENTE_DV" , ""},
                { "SI111_DTH_VENCIMENTO" , ""},
                { "SI111_NUM_NOSSO_TITULO" , ""},
                { "SI111_DTH_CADASTRAMENTO" , ""},
                { "SI111_PCT_OPERACAO" , ""},
                { "SI111_IND_FORMA_BAIXA" , ""},
                { "SI111_NOM_PROGRAMA" , ""},
                { "SI111_DTH_PAGAMENTO" , ""},
                { "SI111_IND_INTEGRACAO" , ""},
                { "SI111_NUM_TITULO_SIGCB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R100_ROTINA_CRITICA_DB_SELECT_2_Query1", q1);

            #endregion

            #region R100_ROTINA_CRITICA_DB_SELECT_3_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R100_ROTINA_CRITICA_DB_SELECT_3_Query1", q2);

            #endregion

            #region R100_ROTINA_CRITICA_DB_SELECT_4_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINCREIN_COD_OPERACAO" , ""},
                { "SINCREIN_COD_AGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R100_ROTINA_CRITICA_DB_SELECT_4_Query1", q3);

            #endregion

            #region R100_ROTINA_CRITICA_DB_SELECT_5_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HOST_MIN_DATA_MOVIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R100_ROTINA_CRITICA_DB_SELECT_5_Query1", q4);

            #endregion

            #region R500_LE_SISTEMAS_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R500_LE_SISTEMAS_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1000_LE_MESTSINI_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "HOST_MAX_OCORR_HISTORICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_LE_MESTSINI_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1000_LE_MESTSINI_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "HOST_MAX_OCORR_HISTORICO" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_LE_MESTSINI_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R1000_LE_MESTSINI_DB_SELECT_2_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_OCORR_HISTORICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_LE_MESTSINI_DB_SELECT_2_Query1", q8);

            #endregion

            #region R1000_LE_MESTSINI_DB_UPDATE_2_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_OCORR_HISTORICO" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_LE_MESTSINI_DB_UPDATE_2_Update1", q9);

            #endregion

            #region R1500_VALIDAR_RUNOFF_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "W_MIN_DATA_MOV_INDENIZADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_VALIDAR_RUNOFF_DB_SELECT_1_Query1", q10);

            #endregion

            #region R2000_INSERT_HISTSINI_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_EMPRESA" , ""},
                { "SINISHIS_TIPO_REGISTRO" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_DATA_LIM_CORRECAO" , ""},
                { "SINISHIS_TIPO_FAVORECIDO" , ""},
                { "SINISHIS_DATA_NEGOCIADA" , ""},
                { "SINISHIS_FONTE_PAGAMENTO" , ""},
                { "SINISHIS_COD_PREST_SERVICO" , ""},
                { "SINISHIS_COD_SERVICO" , ""},
                { "SINISHIS_ORDEM_PAGAMENTO" , ""},
                { "SINISHIS_NUM_RECIBO" , ""},
                { "SINISHIS_NUM_MOV_SINISTRO" , ""},
                { "SINISHIS_COD_USUARIO" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_SIT_REGISTRO" , ""},
                { "SINISHIS_NUM_APOLICE" , ""},
                { "SINISHIS_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_INSERT_HISTSINI_DB_INSERT_1_Insert1", q11);

            #endregion

            #region R2100_INSERT_PARCELA_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "SI111_NUM_APOL_SINISTRO" , ""},
                { "SI111_OCORR_HISTORICO" , ""},
                { "SI111_COD_OPERACAO" , ""},
                { "SI111_NUM_RESSARC" , ""},
                { "SI111_SEQ_RESSARC" , ""},
                { "SI111_NUM_PARCELA" , ""},
                { "SI111_COD_AGENCIA_CEDENT" , ""},
                { "SI111_COD_SISTEMA_ORIGEM" , ""},
                { "SI111_NUM_CEDENTE" , ""},
                { "SI111_NUM_CEDENTE_DV" , ""},
                { "SI111_DTH_VENCIMENTO" , ""},
                { "SI111_NUM_NOSSO_TITULO" , ""},
                { "SI111_PCT_OPERACAO" , ""},
                { "SI111_IND_FORMA_BAIXA" , ""},
                { "SI111_DTH_PAGAMENTO" , ""},
                { "SI111_IND_INTEGRACAO" , ""},
                { "SI111_NUM_TITULO_SIGCB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_INSERT_PARCELA_DB_INSERT_1_Insert1", q12);

            #endregion

            #endregion
        }
        public static void Load_Parameters2()
        {
            #region PARAMETERS
            #region R100_ROTINA_CRITICA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_EMPRESA" , ""},
                { "SINISHIS_TIPO_REGISTRO" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_HORA_OPERACAO" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISHIS_VAL_OPERACAO" , "99999"},
                { "SINISHIS_DATA_LIM_CORRECAO" , ""},
                { "SINISHIS_TIPO_FAVORECIDO" , ""},
                { "SINISHIS_DATA_NEGOCIADA" , ""},
                { "SINISHIS_FONTE_PAGAMENTO" , ""},
                { "SINISHIS_COD_PREST_SERVICO" , ""},
                { "SINISHIS_COD_SERVICO" , ""},
                { "SINISHIS_ORDEM_PAGAMENTO" , ""},
                { "SINISHIS_NUM_RECIBO" , ""},
                { "SINISHIS_NUM_MOV_SINISTRO" , ""},
                { "SINISHIS_COD_USUARIO" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_SIT_REGISTRO" , ""},
                { "SINISHIS_TIMESTAMP" , ""},
                { "SINISHIS_NUM_APOLICE" , ""},
                { "SINISHIS_COD_PRODUTO" , ""},
                { "SINISHIS_NOM_PROGRAMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R100_ROTINA_CRITICA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R100_ROTINA_CRITICA_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SI111_NUM_APOL_SINISTRO" , ""},
                { "SI111_OCORR_HISTORICO" , ""},
                { "SI111_COD_OPERACAO" , ""},
                { "SI111_NUM_RESSARC" , ""},
                { "SI111_SEQ_RESSARC" , ""},
                { "SI111_NUM_PARCELA" , ""},
                { "SI111_COD_AGENCIA_CEDENT" , ""},
                { "SI111_COD_SISTEMA_ORIGEM" , ""},
                { "SI111_NUM_CEDENTE" , ""},
                { "SI111_NUM_CEDENTE_DV" , ""},
                { "SI111_DTH_VENCIMENTO" , ""},
                { "SI111_NUM_NOSSO_TITULO" , ""},
                { "SI111_DTH_CADASTRAMENTO" , ""},
                { "SI111_PCT_OPERACAO" , ""},
                { "SI111_IND_FORMA_BAIXA" , ""},
                { "SI111_NOM_PROGRAMA" , ""},
                { "SI111_DTH_PAGAMENTO" , ""},
                { "SI111_IND_INTEGRACAO" , ""},
                { "SI111_NUM_TITULO_SIGCB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R100_ROTINA_CRITICA_DB_SELECT_2_Query1", q1);

            #endregion

            #region R100_ROTINA_CRITICA_DB_SELECT_3_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R100_ROTINA_CRITICA_DB_SELECT_3_Query1", q2);

            #endregion

            #region R100_ROTINA_CRITICA_DB_SELECT_4_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINCREIN_COD_OPERACAO" , ""},
                { "SINCREIN_COD_AGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R100_ROTINA_CRITICA_DB_SELECT_4_Query1", q3);

            #endregion

            #region R100_ROTINA_CRITICA_DB_SELECT_5_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HOST_MIN_DATA_MOVIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R100_ROTINA_CRITICA_DB_SELECT_5_Query1", q4);

            #endregion

            #region R500_LE_SISTEMAS_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R500_LE_SISTEMAS_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1000_LE_MESTSINI_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "HOST_MAX_OCORR_HISTORICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_LE_MESTSINI_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1000_LE_MESTSINI_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "HOST_MAX_OCORR_HISTORICO" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_LE_MESTSINI_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R1000_LE_MESTSINI_DB_SELECT_2_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_OCORR_HISTORICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_LE_MESTSINI_DB_SELECT_2_Query1", q8);

            #endregion

            #region R1000_LE_MESTSINI_DB_UPDATE_2_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_OCORR_HISTORICO" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_LE_MESTSINI_DB_UPDATE_2_Update1", q9);

            #endregion

            #region R1500_VALIDAR_RUNOFF_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "W_MIN_DATA_MOV_INDENIZADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_VALIDAR_RUNOFF_DB_SELECT_1_Query1", q10);

            #endregion

            #region R2000_INSERT_HISTSINI_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_EMPRESA" , ""},
                { "SINISHIS_TIPO_REGISTRO" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_DATA_LIM_CORRECAO" , ""},
                { "SINISHIS_TIPO_FAVORECIDO" , ""},
                { "SINISHIS_DATA_NEGOCIADA" , ""},
                { "SINISHIS_FONTE_PAGAMENTO" , ""},
                { "SINISHIS_COD_PREST_SERVICO" , ""},
                { "SINISHIS_COD_SERVICO" , ""},
                { "SINISHIS_ORDEM_PAGAMENTO" , ""},
                { "SINISHIS_NUM_RECIBO" , ""},
                { "SINISHIS_NUM_MOV_SINISTRO" , ""},
                { "SINISHIS_COD_USUARIO" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_SIT_REGISTRO" , ""},
                { "SINISHIS_NUM_APOLICE" , ""},
                { "SINISHIS_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_INSERT_HISTSINI_DB_INSERT_1_Insert1", q11);

            #endregion

            #region R2100_INSERT_PARCELA_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "SI111_NUM_APOL_SINISTRO" , ""},
                { "SI111_OCORR_HISTORICO" , ""},
                { "SI111_COD_OPERACAO" , ""},
                { "SI111_NUM_RESSARC" , ""},
                { "SI111_SEQ_RESSARC" , ""},
                { "SI111_NUM_PARCELA" , ""},
                { "SI111_COD_AGENCIA_CEDENT" , ""},
                { "SI111_COD_SISTEMA_ORIGEM" , ""},
                { "SI111_NUM_CEDENTE" , ""},
                { "SI111_NUM_CEDENTE_DV" , ""},
                { "SI111_DTH_VENCIMENTO" , ""},
                { "SI111_NUM_NOSSO_TITULO" , ""},
                { "SI111_PCT_OPERACAO" , ""},
                { "SI111_IND_FORMA_BAIXA" , ""},
                { "SI111_DTH_PAGAMENTO" , ""},
                { "SI111_IND_INTEGRACAO" , ""},
                { "SI111_NUM_TITULO_SIGCB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_INSERT_PARCELA_DB_INSERT_1_Insert1", q12);

            #endregion

            #endregion
        }
        [Fact]
        public static void SI1051S_Tests_Fact_CodOperNot_4292_ReturnError_1()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region inputParam
                var inputParam = new SI1051S_LINK_ESTORNA_REPASSE()
                {
                    PARM_NUM_APOL_SINISTRO = new IntBasis()
                    {
                        Pic = new PIC("S9", "13", "S9(13)"),
                        Value = 1234567890123
                    },
                    PARM_OCORR_HISTORICO = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0077
                    },
                    PARM_COD_OPERACAO = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 9988
                    },
                    PARM_COD_USUARIO = new StringBasis()
                    {
                        Pic = new PIC("X", "8", "X(08)."),
                        Value = "PAT1234"
                    },
                    PARM_TAMANHO = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0324
                    },
                    PARM_VAL_OPERACAO = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "13", "S9(13)V99"),
                        Value = 000001100
                    }
                };
                #endregion

                #endregion
                var program = new SI1051S();
                program.Execute(inputParam);

                Assert.True(program.LINK_ESTORNA_REPASSE.PARM_IND_RETORNO == 01);
                Assert.True(program.LINK_ESTORNA_REPASSE.PARM_COD_OPERACAO != 4292);

            }
        }
        [Fact]
        public static void SI1051S_Tests_Fact_CodOperIs_4292_Return_00()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region inputParam


                var inputParam = new SI1051S_LINK_ESTORNA_REPASSE()
                {
                    PARM_NUM_APOL_SINISTRO = new IntBasis()
                    {
                        Pic = new PIC("S9", "13", "S9(13)"),
                        Value = 1234567890123
                    },
                    PARM_OCORR_HISTORICO = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0077
                    },
                    PARM_COD_OPERACAO = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 4292
                    },
                    PARM_COD_USUARIO = new StringBasis()
                    {
                        Pic = new PIC("X", "8", "X(08)."),
                        Value = "PAT1234"
                    },
                    PARM_TAMANHO = new IntBasis()
                    {
                        Pic = new PIC("S9", "4", "S9(04)"),
                        Value = 0324
                    },
                    PARM_VAL_OPERACAO = new DoubleBasis()
                    {
                        Pic = new PIC("S9", "13", "S9(13)V99"),
                        Value = 000001100
                    }
                };
                #endregion
                #region R100_ROTINA_CRITICA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_EMPRESA" , "0"},
                { "SINISHIS_TIPO_REGISTRO" , "1"},
                { "SINISHIS_NUM_APOL_SINISTRO" , "000020100826"},
                { "SINISHIS_OCORR_HISTORICO" , "1"},
                { "SINISHIS_COD_OPERACAO" , "101"},
                { "SINISHIS_DATA_MOVIMENTO" , "2006-08-16"},
                { "SINISHIS_HORA_OPERACAO" , "11,52,54Z"},
                { "SINISHIS_NOME_FAVORECIDO" , "                                        "},
                { "SINISHIS_VAL_OPERACAO" , "7777.00"},
                { "SINISHIS_DATA_LIM_CORRECAO" , "9999-12-31"},
                { "SINISHIS_TIPO_FAVORECIDO" , "0"},
                { "SINISHIS_DATA_NEGOCIADA" , "9999-12-31"},
                { "SINISHIS_FONTE_PAGAMENTO" , "0"},
                { "SINISHIS_COD_PREST_SERVICO" , "0"},
                { "SINISHIS_COD_SERVICO" , "0"},
                { "SINISHIS_ORDEM_PAGAMENTO" , "0"},
                { "SINISHIS_NUM_RECIBO" , "0"},
                { "SINISHIS_NUM_MOV_SINISTRO" , "0"},
                { "SINISHIS_COD_USUARIO" , "SARA    "},
                { "SINISHIS_SIT_CONTABIL" , "0"},
                { "SINISHIS_SIT_REGISTRO" , "0"},
                { "SINISHIS_TIMESTAMP" , "2006-08-16T11,52,54.885Z"},
                { "SINISHIS_NUM_APOLICE" , "66001000001"},
                { "SINISHIS_COD_PRODUTO" , "6600"},
                { "SINISHIS_NOM_PROGRAMA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R100_ROTINA_CRITICA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R100_ROTINA_CRITICA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R100_ROTINA_CRITICA_Query3

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R100_ROTINA_CRITICA_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R100_ROTINA_CRITICA_DB_SELECT_3_Query1", q2);

                #endregion
                #region R100_ROTINA_CRITICA_Query4

                var q3 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R100_ROTINA_CRITICA_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R100_ROTINA_CRITICA_DB_SELECT_4_Query1", q3);

                #endregion
                #region R100_ROTINA_CRITICA_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SI111_NUM_APOL_SINISTRO" , "19790324"},
                { "SI111_OCORR_HISTORICO" , "10"},
                { "SI111_COD_OPERACAO" , "7777"},
                { "SI111_NUM_RESSARC" , "1"},
                { "SI111_SEQ_RESSARC" , "0"},
                { "SI111_NUM_PARCELA" , "1"},
                { "SI111_COD_AGENCIA_CEDENT" , "630"},
                { "SI111_COD_SISTEMA_ORIGEM" , "3"},
                { "SI111_NUM_CEDENTE" , "87000000044"},
                { "SI111_NUM_CEDENTE_DV" , "0"},
                { "SI111_DTH_VENCIMENTO" , "2024-11-11"},
                { "SI111_NUM_NOSSO_TITULO" , "8000100043268445"},
                { "SI111_DTH_CADASTRAMENTO" , "2010-05-29T22,25,34.980Z"},
                { "SI111_PCT_OPERACAO" , "0.00000"},
                { "SI111_IND_FORMA_BAIXA" , "0"},
                { "SI111_NOM_PROGRAMA" , "SI0221B "},
                { "SI111_DTH_PAGAMENTO" , ""},
                { "SI111_IND_INTEGRACAO" , "0"},
                { "SI111_NUM_TITULO_SIGCB" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R100_ROTINA_CRITICA_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R100_ROTINA_CRITICA_DB_SELECT_2_Query1", q1);

                #endregion

                #endregion
                var program = new SI1051S();
                program.Execute(inputParam);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(program.LINK_ESTORNA_REPASSE.PARM_IND_RETORNO == 00);
                Assert.True(program.LINK_ESTORNA_REPASSE.PARM_COD_OPERACAO == 4292);
                Assert.True(program.LINK_ESTORNA_REPASSE.PARM_SQLCODE == 0000);

                //R1000_LE_MESTSINI_Update2
                var envList0 = AppSettings.TestSet.DynamicData["R1000_LE_MESTSINI_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("SINISMES_NUM_APOL_SINISTRO", out var val0r) && val0r.Contains("0000020100826"));

                //R1000_LE_MESTSINI_Update4
                var envList1 = AppSettings.TestSet.DynamicData["R1000_LE_MESTSINI_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("SINISMES_NUM_APOL_SINISTRO", out var val1r) && val1r.Contains("0000020100826"));

                //R2000_INSERT_HISTSINI_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["R2000_INSERT_HISTSINI_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2.Count > 1);
                Assert.True(envList2[1].TryGetValue("SINISHIS_VAL_OPERACAO", out var val2r) && val2r.Contains("0000000777700.00"));
                Assert.True(envList2[1].TryGetValue("SINISHIS_COD_PRODUTO", out var val3r) && val3r.Contains("6600"));

                //R2100_INSERT_PARCELA_Insert1
                var envList3 = AppSettings.TestSet.DynamicData["R2100_INSERT_PARCELA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3.Count > 1);
                Assert.True(envList3[1].TryGetValue("SI111_NUM_APOL_SINISTRO", out var val4r) && val4r.Contains("0000019790324"));
                Assert.True(envList3[1].TryGetValue("SI111_NUM_NOSSO_TITULO", out var val5r) && val5r.Contains("8000100043268445"));
            }
        }
    }
}