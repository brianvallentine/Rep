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
using static Code.CB6259B;

namespace FileTests.Test
{
    [Collection("CB6259B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class CB6259B_Tests
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

            #region CB6259B_V0MOVIMCOB

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
                { "MOVIMCOB_NUM_TITULO" , ""},
                { "MOVIMCOB_NUM_APOLICE" , ""},
                { "MOVIMCOB_NUM_ENDOSSO" , ""},
                { "MOVIMCOB_NUM_PARCELA" , ""},
                { "MOVIMCOB_VAL_TITULO" , ""},
                { "MOVIMCOB_VAL_IOCC" , ""},
                { "MOVIMCOB_VAL_CREDITO" , ""},
                { "MOVIMCOB_NOME_SEGURADO" , ""},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , ""},
                { "CONVERSI_NUM_SICOB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB6259B_V0MOVIMCOB", q1);

            #endregion

            #region R0360_00_SELECT_V0BILHETE_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "BILHECOB_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0360_00_SELECT_V0BILHETE_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0700_00_SELECT_V0RCAP_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_NUM_RCAP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_SELECT_V0RCAP_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1100_00_SELECT_AGENCIAS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "MALHACEF_COD_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_AGENCIAS_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1310_00_INSERT_RCAPS_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_NUM_PROPOSTA" , ""},
                { "RCAPS_NOME_SEGURADO" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , ""},
                { "RCAPS_DATA_CADASTRAMENTO" , ""},
                { "RCAPS_DATA_MOVIMENTO" , ""},
                { "RCAPS_SIT_REGISTRO" , ""},
                { "RCAPS_COD_OPERACAO" , ""},
                { "RCAPS_COD_EMPRESA" , ""},
                { "RCAPS_NUM_APOLICE" , ""},
                { "RCAPS_NUM_ENDOSSO" , ""},
                { "RCAPS_NUM_PARCELA" , ""},
                { "RCAPS_NUM_TITULO" , ""},
                { "RCAPS_CODIGO_PRODUTO" , ""},
                { "RCAPS_AGE_COBRANCA" , ""},
                { "RCAPS_RECUPERA" , ""},
                { "RCAPS_VLACRESCIMO" , ""},
                { "RCAPS_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1310_00_INSERT_RCAPS_DB_INSERT_1_Insert1", q5);

            #endregion

            #region R1320_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_COD_FONTE" , ""},
                { "RCAPCOMP_NUM_RCAP" , ""},
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN" , ""},
                { "RCAPCOMP_COD_OPERACAO" , ""},
                { "RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "RCAPCOMP_SIT_REGISTRO" , ""},
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_DATA_CADASTRAMENTO" , ""},
                { "RCAPCOMP_SIT_CONTABIL" , ""},
                { "RCAPCOMP_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1320_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1", q6);

            #endregion

            #region R4100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R4100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_SIT_REGISTRO" , ""},
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_NUM_TITULO" , ""},
                { "MOVIMCOB_COD_BANCO" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R4210_00_UPDATE_V0MOVICOB_TIT_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_NUM_TITULO" , ""},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , ""},
                { "MOVIMCOB_COD_MOVIMENTO" , ""},
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_COD_BANCO" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "MOVIMCOB_NUM_FITA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4210_00_UPDATE_V0MOVICOB_TIT_DB_UPDATE_1_Update1", q9);

            #endregion

            #region R5100_00_SELECT_CONDESCE_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R5100_00_SELECT_CONDESCE_DB_SELECT_1_Query1", q10);

            #endregion

            #region R5200_00_UPDATE_CONDESCE_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "CONDESCE_QTD_REGISTROS" , ""},
                { "CONDESCE_VAL_DESCONTO" , ""},
                { "CONDESCE_PRM_LIQUIDO" , ""},
                { "CONDESCE_VAL_TARIFA" , ""},
                { "CONDESCE_VAL_BALCAO" , ""},
                { "CONDESCE_PRM_TOTAL" , ""},
                { "CONDESCE_VAL_JUROS" , ""},
                { "CONDESCE_VAL_MULTA" , ""},
                { "CONDESCE_VAL_IOCC" , ""},
                { "CONDESCE_NUM_AVISO_CREDITO" , ""},
                { "CONDESCE_ANO_REFERENCIA" , ""},
                { "CONDESCE_MES_REFERENCIA" , ""},
                { "CONDESCE_COD_EMPRESA" , ""},
                { "CONDESCE_COD_PRODUTO" , ""},
                { "CONDESCE_BCO_AVISO" , ""},
                { "CONDESCE_AGE_AVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5200_00_UPDATE_CONDESCE_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R5300_00_INSERT_CONDESCE_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R5300_00_INSERT_CONDESCE_DB_INSERT_1_Insert1", q12);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("CB6259B.txt")]
        public static void CB6259B_Tests_Theory_INSERT_RCAP(string ARQSORT_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #endregion
                var program = new CB6259B();
                program.Execute(ARQSORT_FILE_NAME_P);

                var envList = AppSettings.TestSet.DynamicData["R4100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);

                Assert.True(envList[1].TryGetValue("FOLLOUP_COD_BAIXA_PARCELA", out string valor) && valor == "0030");
                Assert.True(envList1[1].TryGetValue("MOVIMCOB_SIT_REGISTRO", out valor) && valor == "2");
            }
        }
        [Theory]
        [InlineData("CB6259B.txt")]
        public static void CB6259B_Tests_Theory(string ARQSORT_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                AppSettings.TestSet.DynamicData.Remove("R0700_00_SELECT_V0RCAP_DB_SELECT_1_Query1");
                var q3 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R0700_00_SELECT_V0RCAP_DB_SELECT_1_Query1", q3);

                AppSettings.TestSet.DynamicData.Remove("R5100_00_SELECT_CONDESCE_DB_SELECT_1_Query1");
                var q10 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R5100_00_SELECT_CONDESCE_DB_SELECT_1_Query1", q10);
                #endregion
                var program = new CB6259B();
                program.Execute(ARQSORT_FILE_NAME_P);

                var envList = AppSettings.TestSet.DynamicData["R1310_00_INSERT_RCAPS_DB_INSERT_1_Insert1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R1320_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);

                Assert.True(envList[1].TryGetValue("RCAPS_COD_OPERACAO", out string valor) && valor == "0110");
                Assert.True(envList1[1].TryGetValue("RCAPCOMP_COD_FONTE", out valor) && valor == "0000");
            }
        }
    }
}