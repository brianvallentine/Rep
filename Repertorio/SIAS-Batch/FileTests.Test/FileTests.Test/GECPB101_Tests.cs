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
using static Code.GECPB101;
using System.IO;

namespace FileTests.Test
{
    [Collection("GECPB101_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class GECPB101_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region GECPB101_C01

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_DTA_LOTE" , ""},
                { "GE536_COD_ORIGEM" , ""},
                { "GE536_COD_EVENTO" , ""},
                { "GE537_NUM_IDLG" , ""},
                { "GE543_NUM_SINISTRO" , ""},
                { "GE543_NUM_APOLICE" , ""},
                { "GE536_COD_CHAVE_NEGOCIO" , ""},
                { "GE547_VLR_COBRAR_PAGAR" , ""},
                { "GE537_DTA_MOVIMENTO" , ""},
                { "GE547_DTA_COBRAR_PAGAR" , ""},
                { "WS_HOST_DES_FORMA" , ""},
                { "WS_HOST_DES_TIPO_MOV" , ""},
                { "WS_HOST_DES_STA_PROCES" , ""},
                { "GE577_COD_RETORNO_ARQ_H" , ""},
                { "GE576_DES_RETORNO_ARQ_H" , ""},
                { "GE541_NOM_EXTERNO_ARQUIVO" , ""},
                { "GE554_NOM_EXTERNO_ARQUIVO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("GECPB101_C01", q0);

            #endregion

            #region GECPB101_C02

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WS_HOST_DTA_LOTE" , ""},
                { "GE536_COD_ORIGEM" , ""},
                { "GE536_COD_EVENTO" , ""},
                { "GE537_COD_LOTE_A" , ""},
                { "GE537_NUM_IDLG" , ""},
                { "GE543_NUM_SINISTRO" , ""},
                { "GE543_NUM_APOLICE" , ""},
                { "GE536_COD_CHAVE_NEGOCIO" , ""},
                { "GE547_VLR_COBRAR_PAGAR" , ""},
                { "GE547_DTA_COBRAR_PAGAR" , ""},
                { "WS_HOST_DES_FORMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("GECPB101_C02", q1);

            #endregion

            #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "GE501_DTA_MOV_ABERTO" , ""},
                { "GE501_DTA_ULT_MOV_ABERTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q2);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("GECPB101_OUTPUT_202504010000", "GECPB101_OUTPUT_202504010001")]
        public static void GECPB101_Tests_Theory(string CPB101S1_FILE_NAME_P, string CPB101S2_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.DynamicData.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region GECPB101_C01

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_DTA_LOTE" , ""},
                    { "GE536_COD_ORIGEM" , ""},
                    { "GE536_COD_EVENTO" , ""},
                    { "GE537_NUM_IDLG" , ""},
                    { "GE543_NUM_SINISTRO" , ""},
                    { "GE543_NUM_APOLICE" , ""},
                    { "GE536_COD_CHAVE_NEGOCIO" , ""},
                    { "GE547_VLR_COBRAR_PAGAR" , ""},
                    { "GE537_DTA_MOVIMENTO" , ""},
                    { "GE547_DTA_COBRAR_PAGAR" , ""},
                    { "WS_HOST_DES_FORMA" , ""},
                    { "WS_HOST_DES_TIPO_MOV" , ""},
                    { "WS_HOST_DES_STA_PROCES" , ""},
                    { "GE577_COD_RETORNO_ARQ_H" , ""},
                    { "GE576_DES_RETORNO_ARQ_H" , ""},
                    { "GE541_NOM_EXTERNO_ARQUIVO" , ""},
                    { "GE554_NOM_EXTERNO_ARQUIVO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("GECPB101_C01");
                AppSettings.TestSet.DynamicData.Add("GECPB101_C01", q0);

                #endregion

                #region GECPB101_C02

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_DTA_LOTE" , ""},
                    { "GE536_COD_ORIGEM" , ""},
                    { "GE536_COD_EVENTO" , ""},
                    { "GE537_COD_LOTE_A" , ""},
                    { "GE537_NUM_IDLG" , ""},
                    { "GE543_NUM_SINISTRO" , ""},
                    { "GE543_NUM_APOLICE" , ""},
                    { "GE536_COD_CHAVE_NEGOCIO" , ""},
                    { "GE547_VLR_COBRAR_PAGAR" , ""},
                    { "GE547_DTA_COBRAR_PAGAR" , ""},
                    { "WS_HOST_DES_FORMA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("GECPB101_C02");
                AppSettings.TestSet.DynamicData.Add("GECPB101_C02", q1);

                #endregion

                #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "GE501_DTA_MOV_ABERTO" , ""},
                    { "GE501_DTA_ULT_MOV_ABERTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q2);

                #endregion

                #endregion
                #endregion

                var program = new GECPB101();
                program.Execute(CPB101S1_FILE_NAME_P, CPB101S2_FILE_NAME_P);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();

                Assert.True(File.Exists(program.CPB101S1.FilePath) && File.Exists(program.CPB101S2.FilePath));
                Assert.True(new FileInfo(program.CPB101S1.FilePath).Length > 0);
                Assert.True(new FileInfo(program.CPB101S2.FilePath).Length > 0);

                Assert.True(selects.Count > (allSelects.Count / 2));

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("GECPB101_OUTPUT_202504010002", "GECPB101_OUTPUT_202504010003")]
        public static void GECPB101_Tests_Theory_ReturnCode99(string CPB101S1_FILE_NAME_P, string CPB101S2_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.DynamicData.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region GECPB101_C01

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_DTA_LOTE" , ""},
                    { "GE536_COD_ORIGEM" , ""},
                    { "GE536_COD_EVENTO" , ""},
                    { "GE537_NUM_IDLG" , ""},
                    { "GE543_NUM_SINISTRO" , ""},
                    { "GE543_NUM_APOLICE" , ""},
                    { "GE536_COD_CHAVE_NEGOCIO" , ""},
                    { "GE547_VLR_COBRAR_PAGAR" , ""},
                    { "GE537_DTA_MOVIMENTO" , ""},
                    { "GE547_DTA_COBRAR_PAGAR" , ""},
                    { "WS_HOST_DES_FORMA" , ""},
                    { "WS_HOST_DES_TIPO_MOV" , ""},
                    { "WS_HOST_DES_STA_PROCES" , ""},
                    { "GE577_COD_RETORNO_ARQ_H" , ""},
                    { "GE576_DES_RETORNO_ARQ_H" , ""},
                    { "GE541_NOM_EXTERNO_ARQUIVO" , ""},
                    { "GE554_NOM_EXTERNO_ARQUIVO" , ""},
                }, new SQLCA(999));
                AppSettings.TestSet.DynamicData.Remove("GECPB101_C01");
                AppSettings.TestSet.DynamicData.Add("GECPB101_C01", q0);

                #endregion

                #region GECPB101_C02

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "WS_HOST_DTA_LOTE" , ""},
                    { "GE536_COD_ORIGEM" , ""},
                    { "GE536_COD_EVENTO" , ""},
                    { "GE537_COD_LOTE_A" , ""},
                    { "GE537_NUM_IDLG" , ""},
                    { "GE543_NUM_SINISTRO" , ""},
                    { "GE543_NUM_APOLICE" , ""},
                    { "GE536_COD_CHAVE_NEGOCIO" , ""},
                    { "GE547_VLR_COBRAR_PAGAR" , ""},
                    { "GE547_DTA_COBRAR_PAGAR" , ""},
                    { "WS_HOST_DES_FORMA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("GECPB101_C02");
                AppSettings.TestSet.DynamicData.Add("GECPB101_C02", q1);

                #endregion

                #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "GE501_DTA_MOV_ABERTO" , ""},
                    { "GE501_DTA_ULT_MOV_ABERTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0000_00_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q2);

                #endregion

                #endregion
                #endregion

                var program = new GECPB101();
                program.Execute(CPB101S1_FILE_NAME_P, CPB101S2_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}