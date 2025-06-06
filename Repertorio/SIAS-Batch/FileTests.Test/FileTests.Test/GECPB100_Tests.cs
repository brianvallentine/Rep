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
using static Code.GECPB100;

namespace FileTests.Test
{
    [Collection("GECPB100_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class GECPB100_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region GECPB100_C01

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "GE536_COD_EMPRESA" , ""},
                { "GE538_DES_EMPRESA" , ""},
                { "GE537_COD_ORIGEM" , ""},
                { "GE538_DES_ORIGEM" , ""},
                { "GE537_DTA_MOVIMENTO" , ""},
                { "C01_COD_TIPO_OCOR" , ""},
                { "C01_QTD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("GECPB100_C01", q0);

            #endregion

            #region GECPB100_C02

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "GE540_COD_EMPRESA" , ""},
                { "GE538_DES_EMPRESA" , ""},
                { "GE537_NUM_IDLG" , ""},
                { "GE540_COD_ID_PAGAM_COBR" , ""},
                { "GE540_NUM_NSA_SAP" , ""},
                { "GE540_SEQ_REGISTRO" , ""},
                { "GE541_DTA_GERACAO_ARQ" , ""},
                { "C02_STA_CONSUMO" , ""},
                { "GE577_COD_RETORNO_ARQ_H" , ""},
                { "GE576_DES_RETORNO_ARQ_H" , ""},
                { "C02_QTD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("GECPB100_C02", q1);

            #endregion

            #region GECPB100_C04

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "GE536_COD_EMPRESA" , ""},
                { "GE538_DES_EMPRESA" , ""},
                { "GE537_DTA_MOVIMENTO" , ""},
                { "GE537_COD_ORIGEM" , ""},
                { "GE538_DES_ORIGEM" , ""},
                { "GE537_NOM_PROGRAMA" , ""},
                { "C04_QTD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("GECPB100_C04", q2);

            #endregion

            #region GECPB100_C05

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "GE536_COD_EMPRESA" , ""},
                { "GE538_DES_EMPRESA" , ""},
                { "GE554_COD_LOTE_A" , ""},
                { "GE554_NOM_EXTERNO_ARQUIVO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("GECPB100_C05", q3);

            #endregion

            #region GECPB100_C06

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "GE536_COD_EMPRESA" , ""},
                { "GE538_DES_EMPRESA" , ""},
                { "GE551_COD_ORIGEM" , ""},
                { "GE538_DES_ORIGEM" , ""},
                { "GE551_COD_LOTE_G" , ""},
                { "C06_STA_CONSUMO" , ""},
                { "GE562_DES_MSG_ERRO" , ""},
                { "GE552_NOM_EXTERNO_ARQUIVO" , ""},
                { "C06_QTD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("GECPB100_C06", q4);

            #endregion

            #region GECPB100_C08

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "GE536_COD_EMPRESA" , ""},
                { "GE538_DES_EMPRESA" , ""},
                { "GE537_COD_LOTE_G" , ""},
                { "GE537_COD_ORIGEM" , ""},
                { "GE538_DES_ORIGEM" , ""},
                { "GE547_DTA_COBRAR_PAGAR" , ""},
                { "GE552_NOM_EXTERNO_ARQUIVO" , ""},
                { "C08_QTD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("GECPB100_C08", q5);

            #endregion

            #region GECPB100_C09

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "GE536_COD_EMPRESA" , ""},
                { "GE538_DES_EMPRESA" , ""},
                { "GE537_COD_LOTE_A" , ""},
                { "GE537_COD_ORIGEM" , ""},
                { "GE538_DES_ORIGEM" , ""},
                { "GE547_DTA_COBRAR_PAGAR" , ""},
                { "GE552_NOM_EXTERNO_ARQUIVO" , ""},
                { "C09_QTD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("GECPB100_C09", q6);

            #endregion

            #region GECPB100_C10

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "GE536_COD_EMPRESA" , ""},
                { "GE538_DES_EMPRESA" , ""},
                { "GE537_COD_ORIGEM" , ""},
                { "GE538_DES_ORIGEM" , ""},
                { "GE537_DTA_MOVIMENTO" , ""},
                { "GE540_COD_TIPO_REGISTRO" , ""},
                { "GE577_COD_RETORNO_ARQ_H" , ""},
                { "GE576_DES_RETORNO_ARQ_H" , ""},
                { "C10_QTD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("GECPB100_C10", q7);

            #endregion

            #region GECPB100_C11

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "GE597_NOM_EXTERNO_ARQUIVO" , ""},
                { "GE597_NUM_NSA_SAP" , ""},
                { "GE597_SEQ_REGISTRO" , ""},
                { "GE597_DES_REJEICAO" , ""},
                { "GE597_STA_REJEICAO" , ""},
                { "GE597_DTH_ATUALIZACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("GECPB100_C11", q8);

            #endregion

            #region GECPB100_C12

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "GE541_DTA_GERACAO_ARQ" , ""},
                { "C12_QTD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("GECPB100_C12", q9);

            #endregion

            #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "GE501_DTA_MOV_ABERTO" , ""},
                { "GE501_DTA_ULT_MOV_ABERTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q10);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("GECPB100_1_t1", "GECPB100_2_t1", "GECPB100_3_t1", "GECPB100_4_t1", "GECPB100_5_t1", "GECPB100_6_t1", "GECPB100_7_t1", "GECPB100_8_t1", "GECPB100_9_t1", "GECPB100_10_t1")]
        public static void GECPB100_Tests_Theory(string CPB100S1_FILE_NAME_P, string CP100T01_FILE_NAME_P, string CP100T02_FILE_NAME_P, string CP100T03_FILE_NAME_P, string CP100T04_FILE_NAME_P, string CP100T05_FILE_NAME_P, string CP100T67_FILE_NAME_P, string CP100T08_FILE_NAME_P, string CP100T09_FILE_NAME_P, string CP100T10_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CPB100S1_FILE_NAME_P = $"{CPB100S1_FILE_NAME_P}_{timestamp}.txt";
            CP100T01_FILE_NAME_P = $"{CP100T01_FILE_NAME_P}_{timestamp}.txt";
            CP100T02_FILE_NAME_P = $"{CP100T02_FILE_NAME_P}_{timestamp}.txt";
            CP100T03_FILE_NAME_P = $"{CP100T03_FILE_NAME_P}_{timestamp}.txt";
            CP100T04_FILE_NAME_P = $"{CP100T04_FILE_NAME_P}_{timestamp}.txt";
            CP100T05_FILE_NAME_P = $"{CP100T05_FILE_NAME_P}_{timestamp}.txt";
            CP100T67_FILE_NAME_P = $"{CP100T67_FILE_NAME_P}_{timestamp}.txt";
            CP100T08_FILE_NAME_P = $"{CP100T08_FILE_NAME_P}_{timestamp}.txt";
            CP100T09_FILE_NAME_P = $"{CP100T09_FILE_NAME_P}_{timestamp}.txt";
            CP100T10_FILE_NAME_P = $"{CP100T10_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.DynamicData.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region GECPB100_C01

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "GE536_COD_EMPRESA" , "1"},
                { "GE538_DES_EMPRESA" , "X"},
                { "GE537_COD_ORIGEM" , "2"},
                { "GE538_DES_ORIGEM" , "Y"},
                { "GE537_DTA_MOVIMENTO" , "2020-01-01"},
                { "C01_COD_TIPO_OCOR" , "3"},
                { "C01_QTD" , "2"},
            });
                AppSettings.TestSet.DynamicData.Remove("GECPB100_C01");
                AppSettings.TestSet.DynamicData.Add("GECPB100_C01", q0);

                #endregion

                #region GECPB100_C02

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "GE540_COD_EMPRESA" , "1"},
                { "GE538_DES_EMPRESA" , "X"},
                { "GE537_NUM_IDLG" , "2"},
                { "GE540_COD_ID_PAGAM_COBR" , "3"},
                { "GE540_NUM_NSA_SAP" , "4"},
                { "GE540_SEQ_REGISTRO" , "5"},
                { "GE541_DTA_GERACAO_ARQ" , "2020-01-01"},
                { "C02_STA_CONSUMO" , "X"},
                { "GE577_COD_RETORNO_ARQ_H" , "6"},
                { "GE576_DES_RETORNO_ARQ_H" , "X"},
                { "C02_QTD" , "7"},
            });
                AppSettings.TestSet.DynamicData.Remove("GECPB100_C02");
                AppSettings.TestSet.DynamicData.Add("GECPB100_C02", q1);

                #endregion

                #region GECPB100_C04

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "GE536_COD_EMPRESA" , "1"},
                { "GE538_DES_EMPRESA" , "X"},
                { "GE537_DTA_MOVIMENTO" , "2020-01-01"},
                { "GE537_COD_ORIGEM" , "2"},
                { "GE538_DES_ORIGEM" , "X"},
                { "GE537_NOM_PROGRAMA" , "X"},
                { "C04_QTD" , "3"},
            });
                AppSettings.TestSet.DynamicData.Remove("GECPB100_C04");
                AppSettings.TestSet.DynamicData.Add("GECPB100_C04", q2);

                #endregion

                #region GECPB100_C05

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "GE536_COD_EMPRESA" , "1"},
                { "GE538_DES_EMPRESA" , "X"},
                { "GE554_COD_LOTE_A" , "2"},
                { "GE554_NOM_EXTERNO_ARQUIVO" , "X"},
                });
                AppSettings.TestSet.DynamicData.Remove("GECPB100_C05");
                AppSettings.TestSet.DynamicData.Add("GECPB100_C05", q3);

                #endregion

                #region GECPB100_C06

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "GE536_COD_EMPRESA" , "1"},
                { "GE538_DES_EMPRESA" , "X"},
                { "GE551_COD_ORIGEM" , "2"},
                { "GE538_DES_ORIGEM" , "X"},
                { "GE551_COD_LOTE_G" , "3"},
                { "C06_STA_CONSUMO" , "X"},
                { "GE562_DES_MSG_ERRO" , "X"},
                { "GE552_NOM_EXTERNO_ARQUIVO" , "X"},
                { "C06_QTD" , "4"},
            });
                AppSettings.TestSet.DynamicData.Remove("GECPB100_C06");
                AppSettings.TestSet.DynamicData.Add("GECPB100_C06", q4);

                #endregion

                #region GECPB100_C08

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "GE536_COD_EMPRESA" , "1"},
                { "GE538_DES_EMPRESA" , "X"},
                { "GE537_COD_LOTE_G" , "2"},
                { "GE537_COD_ORIGEM" , "3"},
                { "GE538_DES_ORIGEM" , "X"},
                { "GE547_DTA_COBRAR_PAGAR" , "2020-01-01"},
                { "GE552_NOM_EXTERNO_ARQUIVO" , "X"},
                { "C08_QTD" , "4"},
            });
                AppSettings.TestSet.DynamicData.Remove("GECPB100_C08");
                AppSettings.TestSet.DynamicData.Add("GECPB100_C08", q5);

                #endregion

                #region GECPB100_C09

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "GE536_COD_EMPRESA" , "1"},
                { "GE538_DES_EMPRESA" , "X"},
                { "GE537_COD_LOTE_A" , "2"},
                { "GE537_COD_ORIGEM" , "3"},
                { "GE538_DES_ORIGEM" , "X"},
                { "GE547_DTA_COBRAR_PAGAR" , "2020-01-01"},
                { "GE552_NOM_EXTERNO_ARQUIVO" , "X"},
                { "C09_QTD" , "4"},
            });
                AppSettings.TestSet.DynamicData.Remove("GECPB100_C09");
                AppSettings.TestSet.DynamicData.Add("GECPB100_C09", q6);
                #endregion

                #region GECPB100_C10

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "GE536_COD_EMPRESA" , "1"},
                { "GE538_DES_EMPRESA" , "X"},
                { "GE537_COD_ORIGEM" , "2"},
                { "GE538_DES_ORIGEM" , "X"},
                { "GE537_DTA_MOVIMENTO" , "2020-01-01"},
                { "GE540_COD_TIPO_REGISTRO" , "3"},
                { "GE577_COD_RETORNO_ARQ_H" , "4"},
                { "GE576_DES_RETORNO_ARQ_H" , "X"},
                { "C10_QTD" , "5"},
            });
                AppSettings.TestSet.DynamicData.Remove("GECPB100_C10");
                AppSettings.TestSet.DynamicData.Add("GECPB100_C10", q7);

                #endregion

                #endregion
                var program = new GECPB100();
                program.Execute(CPB100S1_FILE_NAME_P, CP100T01_FILE_NAME_P, CP100T02_FILE_NAME_P, CP100T03_FILE_NAME_P, CP100T04_FILE_NAME_P, CP100T05_FILE_NAME_P, CP100T67_FILE_NAME_P, CP100T08_FILE_NAME_P, CP100T09_FILE_NAME_P, CP100T10_FILE_NAME_P);


                var envList1 = AppSettings.TestSet.DynamicData["GECPB100_C01"].DynamicList;
                Assert.Empty(envList1);

                var envList2 = AppSettings.TestSet.DynamicData["GECPB100_C02"].DynamicList;
                Assert.Empty(envList2);

                var envList3 = AppSettings.TestSet.DynamicData["GECPB100_C04"].DynamicList;
                Assert.Empty(envList3);

                var envList4 = AppSettings.TestSet.DynamicData["GECPB100_C05"].DynamicList;
                Assert.Empty(envList4);

                var envList5 = AppSettings.TestSet.DynamicData["GECPB100_C06"].DynamicList;
                Assert.Empty(envList5);

                var envList6 = AppSettings.TestSet.DynamicData["GECPB100_C08"].DynamicList;
                Assert.Empty(envList6);

                var envList7 = AppSettings.TestSet.DynamicData["GECPB100_C09"].DynamicList;
                Assert.Empty(envList7);

                var envList8 = AppSettings.TestSet.DynamicData["GECPB100_C10"].DynamicList;
                Assert.Empty(envList8);


                Assert.True(program.RETURN_CODE == 0);
            }
        }


        [Theory]
        [InlineData("GECPB100_1_t2", "GECPB100_2_t2", "GECPB100_3_t2", "GECPB100_4_t2", "GECPB100_5_t2", "GECPB100_6_t2", "GECPB100_7_t2", "GECPB100_8_t2", "GECPB100_9_t2", "GECPB100_10_t2")]
        public static void GECPB100_Tests99_Theory(string CPB100S1_FILE_NAME_P, string CP100T01_FILE_NAME_P, string CP100T02_FILE_NAME_P, string CP100T03_FILE_NAME_P, string CP100T04_FILE_NAME_P, string CP100T05_FILE_NAME_P, string CP100T67_FILE_NAME_P, string CP100T08_FILE_NAME_P, string CP100T09_FILE_NAME_P, string CP100T10_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            CPB100S1_FILE_NAME_P = $"{CPB100S1_FILE_NAME_P}_{timestamp}.txt";
            CP100T01_FILE_NAME_P = $"{CP100T01_FILE_NAME_P}_{timestamp}.txt";
            CP100T02_FILE_NAME_P = $"{CP100T02_FILE_NAME_P}_{timestamp}.txt";
            CP100T03_FILE_NAME_P = $"{CP100T03_FILE_NAME_P}_{timestamp}.txt";
            CP100T04_FILE_NAME_P = $"{CP100T04_FILE_NAME_P}_{timestamp}.txt";
            CP100T05_FILE_NAME_P = $"{CP100T05_FILE_NAME_P}_{timestamp}.txt";
            CP100T67_FILE_NAME_P = $"{CP100T67_FILE_NAME_P}_{timestamp}.txt";
            CP100T08_FILE_NAME_P = $"{CP100T08_FILE_NAME_P}_{timestamp}.txt";
            CP100T09_FILE_NAME_P = $"{CP100T09_FILE_NAME_P}_{timestamp}.txt";
            CP100T10_FILE_NAME_P = $"{CP100T10_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.DynamicData.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region GECPB100_C01
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                //{ "GE536_COD_EMPRESA" , "1"},
                { "GE538_DES_EMPRESA" , null},
                { "GE537_COD_ORIGEM" , null},
                { "GE538_DES_ORIGEM" , null},
                { "GE537_DTA_MOVIMENTO" , null},
                { "C01_COD_TIPO_OCOR" , null},
                { "C01_QTD" , null},
            });
                AppSettings.TestSet.DynamicData.Remove("GECPB100_C01");
                AppSettings.TestSet.DynamicData.Add("GECPB100_C01", q0);

                #endregion

                #region GECPB100_C02

              //  var q1 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("GECPB100_C02");
               // AppSettings.TestSet.DynamicData.Add("GECPB100_C02", q1);

                #endregion

                #region GECPB100_C04

              //  var q2 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("GECPB100_C04");
                //AppSettings.TestSet.DynamicData.Add("GECPB100_C04", q2);

                #endregion

                #region GECPB100_C05

               // var q3 = new DynamicData();             
                AppSettings.TestSet.DynamicData.Remove("GECPB100_C05");
              //  AppSettings.TestSet.DynamicData.Add("GECPB100_C05", q3);

                #endregion

                #region GECPB100_C06

               // var q4 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("GECPB100_C06");
                //AppSettings.TestSet.DynamicData.Add("GECPB100_C06", q4);

                #endregion

                #region GECPB100_C08

                //var q5 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("GECPB100_C08");
                //AppSettings.TestSet.DynamicData.Add("GECPB100_C08", q5);

                #endregion

                #region GECPB100_C09

               // var q6 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("GECPB100_C09");
                //AppSettings.TestSet.DynamicData.Add("GECPB100_C09", q6);
                #endregion

                #region GECPB100_C10

               // var q7 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("GECPB100_C10");
               // AppSettings.TestSet.DynamicData.Add("GECPB100_C10", q7);

                #endregion

                #endregion
                var program = new GECPB100();
                program.Execute(CPB100S1_FILE_NAME_P, CP100T01_FILE_NAME_P, CP100T02_FILE_NAME_P, CP100T03_FILE_NAME_P, CP100T04_FILE_NAME_P, CP100T05_FILE_NAME_P, CP100T67_FILE_NAME_P, CP100T08_FILE_NAME_P, CP100T09_FILE_NAME_P, CP100T10_FILE_NAME_P);

                Assert.True(program.RETURN_CODE != 0);
            }
        }


    }
}