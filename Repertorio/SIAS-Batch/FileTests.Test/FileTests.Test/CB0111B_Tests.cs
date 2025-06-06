using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.CB0111B;
using System.IO;

namespace FileTests.Test
{
    [Collection("CB0111B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class CB0111B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region CB0111B_V0MOVDEBCE

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_VALOR_DEBITO" , "1"},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_NUM_CARTAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0111B_V0MOVDEBCE", q1);

            #endregion

            #region R0420_00_SELECT_COBHISVI_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0420_00_SELECT_COBHISVI_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0660_00_SELECT_PARAMCON_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PARAMCON_NSAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0660_00_SELECT_PARAMCON_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0700_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "PARAMCON_NSAS" , ""},
                { "WS_NSL" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1", q4);

            #endregion

            #region R0750_00_UPDATE_V0HISTCONTAVA_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_SIT_REGISTRO" , ""},
                { "HISLANCT_NSAS" , ""},
                { "VIND_NSAS" , ""},
                { "HISLANCT_NSL" , ""},
                { "VIND_NSL" , ""},
                { "HISLANCT_NUM_CERTIFICADO" , ""},
                { "HISLANCT_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0750_00_UPDATE_V0HISTCONTAVA_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R1100_00_UPDATE_PARAMCON_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PARAMCON_NSAS" , ""},
                { "PARAMCON_DATA_MOVIMENTO" , ""},
                { "PARAMCON_DATA_PROXIMO_DEB" , ""},
                { "PARAMCON_TIPO_MOVTO_CC" , ""},
                { "PARAMCON_COD_PRODUTO" , ""},
                { "PARAMCON_COD_CONVENIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_UPDATE_PARAMCON_DB_UPDATE_1_Update1", q6);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("MOVIMENTO_00.txt", "RCB0111B.txt")]
        public static void CB0111B_Tests_Theory(string MOVIMENTO_FILE_NAME_P, string RCB0111B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RCB0111B_FILE_NAME_P = $"{RCB0111B_FILE_NAME_P}_{timestamp}.txt";
            #region VARIAVEIS_TESTE
            #endregion
            lock (AppSettings.TestSet._lock)
            {
                var program = new CB0111B();

                var fileName = Path.GetFileNameWithoutExtension(MOVIMENTO_FILE_NAME_P);
                MOVIMENTO_FILE_NAME_P = MOVIMENTO_FILE_NAME_P.Replace(fileName, fileName + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"));
                Console.WriteLine($"#### Arquivo {MOVIMENTO_FILE_NAME_P} em : {AppSettings.Settings.FileFolderPath}");

                fileName = Path.GetFileNameWithoutExtension(RCB0111B_FILE_NAME_P);
                RCB0111B_FILE_NAME_P = RCB0111B_FILE_NAME_P.Replace(fileName, fileName + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"));
                Console.WriteLine($"#### Arquivo {RCB0111B_FILE_NAME_P} em : {AppSettings.Settings.FileFolderPath}");

                AppSettings.TestSet.IsTest = true;

                Load_Parameters();

                program.Execute(MOVIMENTO_FILE_NAME_P, RCB0111B_FILE_NAME_P);

                Assert.True(File.Exists(program.MOVIMENTO.FilePath));
                Assert.True(new FileInfo(program.MOVIMENTO.FilePath)?.Length > 0);

                Assert.True(File.Exists(program.RCB0111B.FilePath));
                Assert.True(new FileInfo(program.RCB0111B.FilePath)?.Length > 0);

                var envList = AppSettings.TestSet.DynamicData["R0700_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R0750_00_UPDATE_V0HISTCONTAVA_DB_UPDATE_1_Update1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R1100_00_UPDATE_PARAMCON_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);

                Assert.True(envList[1].TryGetValue("MOVDEBCE_COD_CONVENIO", out var valor) && valor == "000009021");
                Assert.True(envList1[1].TryGetValue("HISLANCT_SIT_REGISTRO", out valor) && valor == "3");
                Assert.True(envList2[1].TryGetValue("PARAMCON_COD_PRODUTO", out valor) && valor == "0099");
                
            }
        }
    }
}