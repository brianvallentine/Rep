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
using static Code.BI0074B;

namespace FileTests.Test
{
    [Collection("BI0074B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class BI0074B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region BI0074B_V0MOVIMCOB

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , ""},
                { "MOVIMCOB_COD_MOVIMENTO" , ""},
                { "MOVIMCOB_COD_BANCO" , ""},
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "MOVIMCOB_NUM_FITA" , ""},
                { "MOVIMCOB_DATA_MOVIMENTO" , ""},
                { "MOVIMCOB_DATA_QUITACAO" , ""},
                { "WSHOST_DATA_INIVIGENCIA" , ""},
                { "WSHOST_DATA_TERVIGENCIA" , ""},
                { "MOVIMCOB_NUM_TITULO" , ""},
                { "MOVIMCOB_NUM_APOLICE" , ""},
                { "MOVIMCOB_NUM_ENDOSSO" , ""},
                { "MOVIMCOB_NUM_PARCELA" , ""},
                { "MOVIMCOB_VAL_TITULO" , ""},
                { "MOVIMCOB_VAL_CREDITO" , ""},
                { "MOVIMCOB_SIT_REGISTRO" , ""},
                { "MOVIMCOB_NOME_SEGURADO" , ""},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI0074B_V0MOVIMCOB", q1);

            #endregion

            #region R0351_00_SELECT_PROPOFID_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_AGECOBR" , ""},
                { "PROPOFID_DATA_PROPOSTA" , ""},
                { "MALHACEF_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0351_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0360_00_SELECT_MOVCOB_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0360_00_SELECT_MOVCOB_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0370_00_SELECT_AVISOCRED_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_NUM_AVISO_CREDITO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0370_00_SELECT_AVISOCRED_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0370_00_SELECT_AVISOCRED_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_NUM_AVISO_CREDITO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0370_00_SELECT_AVISOCRED_DB_SELECT_2_Query1", q5);

            #endregion

            #region R0400_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_NUM_APOLICE" , ""},
                { "MOVIMCOB_NUM_TITULO" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WSHOST_NUM_NOSSO_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0400_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R0370_00_SELECT_AVISOCRED_DB_SELECT_3_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_NUM_AVISO_CREDITO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0370_00_SELECT_AVISOCRED_DB_SELECT_3_Query1", q7);

            #endregion

            #region R0370_00_SELECT_AVISOCRED_DB_SELECT_4_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_NUM_AVISO_CREDITO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0370_00_SELECT_AVISOCRED_DB_SELECT_4_Query1", q8);

            #endregion

            #region R1200_00_SELECT_FONTES_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_FONTES_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1250_00_UPDATE_FONTES_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , ""},
                { "FONTES_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1250_00_UPDATE_FONTES_DB_UPDATE_1_Update1", q10);

            #endregion

            #region R4100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "FOLLOUP_NUM_APOLICE" , ""},
                { "FOLLOUP_NUM_ENDOSSO" , ""},
                { "FOLLOUP_NUM_PARCELA" , ""},
                { "FOLLOUP_DAC_PARCELA" , ""},
                { "FOLLOUP_DATA_MOVIMENTO" , ""},
                { "FOLLOUP_HORA_OPERACAO" , ""},
                { "FOLLOUP_VAL_OPERACAO" , ""},
                { "FOLLOUP_BCO_AVISO" , ""},
                { "FOLLOUP_AGE_AVISO" , ""},
                { "FOLLOUP_NUM_AVISO_CREDITO" , ""},
                { "FOLLOUP_COD_BAIXA_PARCELA" , ""},
                { "FOLLOUP_COD_ERRO01" , ""},
                { "FOLLOUP_COD_ERRO02" , ""},
                { "FOLLOUP_COD_ERRO03" , ""},
                { "FOLLOUP_COD_ERRO04" , ""},
                { "FOLLOUP_COD_ERRO05" , ""},
                { "FOLLOUP_COD_ERRO06" , ""},
                { "FOLLOUP_SIT_REGISTRO" , ""},
                { "FOLLOUP_SIT_CONTABIL" , ""},
                { "FOLLOUP_COD_OPERACAO" , ""},
                { "FOLLOUP_DATA_LIBERACAO" , ""},
                { "FOLLOUP_DATA_QUITACAO" , ""},
                { "FOLLOUP_COD_EMPRESA" , ""},
                { "FOLLOUP_ORDEM_LIDER" , ""},
                { "FOLLOUP_TIPO_SEGURO" , ""},
                { "FOLLOUP_NUM_APOL_LIDER" , ""},
                { "FOLLOUP_ENDOS_LIDER" , ""},
                { "FOLLOUP_COD_LIDER" , ""},
                { "FOLLOUP_COD_FONTE" , ""},
                { "FOLLOUP_NUM_RCAP" , ""},
                { "FOLLOUP_NUM_NOSSO_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1", q11);

            #endregion

            #region R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_SIT_REGISTRO" , ""},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R4300_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_SITUACAO" , ""},
                { "BILHETE_NUM_BILHETE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4300_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q13);

            #endregion

            #region R4500_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "WSHOST_SALDO_ATUAL" , ""},
                { "AVISOSAL_NUM_AVISO_CREDITO" , ""},
                { "AVISOSAL_BCO_AVISO" , ""},
                { "AVISOSAL_AGE_AVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4500_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1", q14);

            #endregion

            #region R5100_00_INSERT_AVISOCRE_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "AVISOCRE_BCO_AVISO" , ""},
                { "AVISOCRE_AGE_AVISO" , ""},
                { "AVISOCRE_NUM_AVISO_CREDITO" , ""},
                { "AVISOCRE_NUM_SEQUENCIA" , ""},
                { "AVISOCRE_DATA_MOVIMENTO" , ""},
                { "AVISOCRE_COD_OPERACAO" , ""},
                { "AVISOCRE_TIPO_AVISO" , ""},
                { "AVISOCRE_DATA_AVISO" , ""},
                { "AVISOCRE_VAL_IOCC" , ""},
                { "AVISOCRE_VAL_DESPESA" , ""},
                { "AVISOCRE_PRM_COSSEGURO_CED" , ""},
                { "AVISOCRE_PRM_LIQUIDO" , ""},
                { "AVISOCRE_PRM_TOTAL" , ""},
                { "AVISOCRE_SIT_CONTABIL" , ""},
                { "AVISOCRE_COD_EMPRESA" , ""},
                { "AVISOCRE_ORIGEM_AVISO" , ""},
                { "AVISOCRE_VAL_ADIANTAMENTO" , ""},
                { "AVISOCRE_STA_DEPOSITO_TER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5100_00_INSERT_AVISOCRE_DB_INSERT_1_Insert1", q15);

            #endregion

            #region R5200_00_INSERT_AVISOSAL_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "AVISOSAL_COD_EMPRESA" , ""},
                { "AVISOSAL_BCO_AVISO" , ""},
                { "AVISOSAL_AGE_AVISO" , ""},
                { "AVISOSAL_TIPO_SEGURO" , ""},
                { "AVISOSAL_NUM_AVISO_CREDITO" , ""},
                { "AVISOSAL_DATA_AVISO" , ""},
                { "AVISOSAL_DATA_MOVIMENTO" , ""},
                { "AVISOSAL_SALDO_ATUAL" , ""},
                { "AVISOSAL_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5200_00_INSERT_AVISOSAL_DB_INSERT_1_Insert1", q16);

            #endregion

            #region R5300_00_INSERT_CONDESCE_DB_INSERT_1_Insert1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "CONDESCE_COD_EMPRESA" , ""},
                { "CONDESCE_ANO_REFERENCIA" , ""},
                { "CONDESCE_MES_REFERENCIA" , ""},
                { "CONDESCE_BCO_AVISO" , ""},
                { "CONDESCE_AGE_AVISO" , ""},
                { "CONDESCE_NUM_AVISO_CREDITO" , ""},
                { "CONDESCE_COD_PRODUTO" , ""},
                { "CONDESCE_TIPO_REGISTRO" , ""},
                { "CONDESCE_SITUACAO" , ""},
                { "CONDESCE_TIPO_COBRANCA" , ""},
                { "CONDESCE_DATA_MOVIMENTO" , ""},
                { "CONDESCE_DATA_AVISO" , ""},
                { "CONDESCE_QTD_REGISTROS" , ""},
                { "CONDESCE_PRM_TOTAL" , ""},
                { "CONDESCE_PRM_LIQUIDO" , ""},
                { "CONDESCE_VAL_TARIFA" , ""},
                { "CONDESCE_VAL_BALCAO" , ""},
                { "CONDESCE_VAL_IOCC" , ""},
                { "CONDESCE_VAL_DESCONTO" , ""},
                { "CONDESCE_VAL_JUROS" , ""},
                { "CONDESCE_VAL_MULTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5300_00_INSERT_CONDESCE_DB_INSERT_1_Insert1", q17);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("ARQSORT_FILE_NAME_P", "BI0074B1_FILE_NAME_P")]
        public static void BI0074B_Tests_Theory(string ARQSORT_FILE_NAME_P, string BI0074B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";
            BI0074B1_FILE_NAME_P = $"{BI0074B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                AppSettings.TestSet.DynamicData.Remove("BI0074B_V0MOVIMCOB");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , "0"},
                { "MOVIMCOB_COD_MOVIMENTO" , "-28536"},
                { "MOVIMCOB_COD_BANCO" , "104"},
                { "MOVIMCOB_COD_AGENCIA" , "9581"},
                { "MOVIMCOB_NUM_AVISO" , "802800053"},
                { "MOVIMCOB_NUM_FITA" , "53"},
                { "MOVIMCOB_DATA_MOVIMENTO" , "2011-01-21"},
                { "MOVIMCOB_DATA_QUITACAO" , "2010-12-22"},
                { "WSHOST_DATA_INIVIGENCIA" , "2010-12-23"},
                { "WSHOST_DATA_TERVIGENCIA" , "2011-12-23"},
                { "MOVIMCOB_NUM_TITULO" , "0"},
                { "MOVIMCOB_NUM_APOLICE" , "1600003705000"},
                { "MOVIMCOB_NUM_ENDOSSO" , "0"},
                { "MOVIMCOB_NUM_PARCELA" , "0"},
                { "MOVIMCOB_VAL_TITULO" , "9900.00"},
                { "MOVIMCOB_VAL_CREDITO" , "9900.00"},
                { "MOVIMCOB_SIT_REGISTRO" , "2"},
                { "MOVIMCOB_NOME_SEGURADO" , "000                                     "},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , "16000037050009"},
            });

                q1.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , "0"},
                { "MOVIMCOB_COD_MOVIMENTO" , "0"},
                { "MOVIMCOB_COD_BANCO" , "104"},
                { "MOVIMCOB_COD_AGENCIA" , "630"},
                { "MOVIMCOB_NUM_AVISO" , "0"},
                { "MOVIMCOB_NUM_FITA" , "0"},
                { "MOVIMCOB_DATA_MOVIMENTO" , "2018-05-18"},
                { "MOVIMCOB_DATA_QUITACAO" , "2018-06-30"},
                { "WSHOST_DATA_INIVIGENCIA" , "2018-07-01"},
                { "WSHOST_DATA_TERVIGENCIA" , "2019-07-01"},
                { "MOVIMCOB_NUM_TITULO" , "0"},
                { "MOVIMCOB_NUM_APOLICE" , "108199999998"},
                { "MOVIMCOB_NUM_ENDOSSO" , "2"},
                { "MOVIMCOB_NUM_PARCELA" , "1"},
                { "MOVIMCOB_VAL_TITULO" , "106054.61"},
                { "MOVIMCOB_VAL_CREDITO" , "0.00"},
                { "MOVIMCOB_SIT_REGISTRO" , "1"},
                { "MOVIMCOB_NOME_SEGURADO" , "009227084000175ELO SERVICOS S.A         "},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , "201805220000001"},
                });
                AppSettings.TestSet.DynamicData.Add("BI0074B_V0MOVIMCOB", q1);

                AppSettings.TestSet.DynamicData.Remove("R0360_00_SELECT_MOVCOB_DB_SELECT_1_Query1");
                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "0"}
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "1"}
                });
                AppSettings.TestSet.DynamicData.Add("R0360_00_SELECT_MOVCOB_DB_SELECT_1_Query1", q3);

                #endregion
                var program = new BI0074B();
                program.Execute(ARQSORT_FILE_NAME_P, BI0074B1_FILE_NAME_P);

                var envList = AppSettings.TestSet.DynamicData["R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList?.Count > 1);
                var envList1 = AppSettings.TestSet.DynamicData["R4500_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1?.Count > 1);

                Assert.True(envList[1].TryGetValue("MOVIMCOB_SIT_REGISTRO", out string valor) && valor == "1");

                Assert.True(envList1[1].TryGetValue("WSHOST_SALDO_ATUAL", out valor) && valor == "0000000009900.00");
            }
        }
        [Theory]
        [InlineData("ARQSORT_FILE_NAME_P", "BI0074B1_FILE_NAME_P")]
        public static void BI0074B_Tests_Theory_SIT_REGISTRO_VAZIO(string ARQSORT_FILE_NAME_P, string BI0074B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";
            BI0074B1_FILE_NAME_P = $"{BI0074B1_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                AppSettings.TestSet.DynamicData.Remove("BI0074B_V0MOVIMCOB");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , "0"},
                { "MOVIMCOB_COD_MOVIMENTO" , "0"},
                { "MOVIMCOB_COD_BANCO" , "104"},
                { "MOVIMCOB_COD_AGENCIA" , "630"},
                { "MOVIMCOB_NUM_AVISO" , "0"},
                { "MOVIMCOB_NUM_FITA" , "0"},
                { "MOVIMCOB_DATA_MOVIMENTO" , "2018-05-18"},
                { "MOVIMCOB_DATA_QUITACAO" , "2018-06-30"},
                { "WSHOST_DATA_INIVIGENCIA" , "2018-07-01"},
                { "WSHOST_DATA_TERVIGENCIA" , "2019-07-01"},
                { "MOVIMCOB_NUM_TITULO" , "0"},
                { "MOVIMCOB_NUM_APOLICE" , "108199999998"},
                { "MOVIMCOB_NUM_ENDOSSO" , "2"},
                { "MOVIMCOB_NUM_PARCELA" , "1"},
                { "MOVIMCOB_VAL_TITULO" , "106054.61"},
                { "MOVIMCOB_VAL_CREDITO" , "0.00"},
                { "MOVIMCOB_SIT_REGISTRO" , ""},
                { "MOVIMCOB_NOME_SEGURADO" , "009227084000175ELO SERVICOS S.A         "},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , "201805220000001"},
                });

                AppSettings.TestSet.DynamicData.Add("BI0074B_V0MOVIMCOB", q1);

                var q3 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0360_00_SELECT_MOVCOB_DB_SELECT_1_Query1");
                q3.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , "0"}
                });

                AppSettings.TestSet.DynamicData.Add("R0360_00_SELECT_MOVCOB_DB_SELECT_1_Query1", q3);

                #endregion
                var program = new BI0074B();
                program.Execute(ARQSORT_FILE_NAME_P, BI0074B1_FILE_NAME_P);

                var envList = AppSettings.TestSet.DynamicData["R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList?.Count > 1);

                var envList1 = AppSettings.TestSet.DynamicData["R5100_00_INSERT_AVISOCRE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1?.Count > 1);

                var envList2 = AppSettings.TestSet.DynamicData["R5200_00_INSERT_AVISOSAL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2?.Count > 1);

                var envList3 = AppSettings.TestSet.DynamicData["R5300_00_INSERT_CONDESCE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3?.Count > 1);

                Assert.True(envList[1].TryGetValue("MOVIMCOB_NUM_NOSSO_TITULO", out string valor) && valor == "0201805220000001");

                Assert.True(envList1[1].TryGetValue("AVISOCRE_AGE_AVISO", out valor) && valor == "0630");

                Assert.True(envList2[1].TryGetValue("AVISOSAL_BCO_AVISO", out valor) && valor == "0104");

                Assert.True(envList3[1].TryGetValue("CONDESCE_ANO_REFERENCIA", out valor) && valor == "2018");

            }
        }
    }
}