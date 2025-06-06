using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Copies;
using Code;
using static Code.PF0726B;
using System.IO;

namespace FileTests.Test
{
    [Collection("PF0726B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0726B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region R0100_00_INICIALIZA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_INICIALIZA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , ""}
            });
            //AppSettings.TestSet.DynamicData.Add("R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0200_00_OBTER_MAX_NSAS_DB_SELECT_2_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_OBTER_MAX_NSAS_DB_SELECT_2_Query1", q2);

            #endregion

            #region R0340_00_OBTER_PARCELA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PARCEVID_PREMIO_VG" , ""},
                { "PARCEVID_PREMIO_AP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0340_00_OBTER_PARCELA_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1", q4);

            #endregion

            #region PF0726B_CPAGAMENTOS

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_APOLICE" , ""},
                { "HISCONPA_COD_SUBGRUPO" , ""},
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
                { "HISCONPA_PREMIO_VG" , ""},
                { "HISCONPA_PREMIO_AP" , ""},
                { "HISCONPA_OCORR_HISTORICO" , ""},
                { "HISCONPA_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0726B_CPAGAMENTOS", q5);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("MOVTO_STA_SASSE_FILE_03.txt")]
        public static void PF0726B_Tests_Theory(string MOVTO_STA_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_SASSE_FILE_NAME_P = $"{MOVTO_STA_SASSE_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new PF0726B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                Assert.True(File.Exists(program.MOVTO_STA_SASSE.FilePath));
                Assert.True(new FileInfo(program.MOVTO_STA_SASSE.FilePath)?.Length > 0);

                var envList = AppSettings.TestSet.DynamicData["R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList?.Count > 1);

                Assert.True(envList[1].TryGetValue("ARQSIVPF_SIGLA_ARQUIVO", out var valor) && valor == "STAPF726");
                Assert.True(envList[1].TryGetValue("ARQSIVPF_SISTEMA_ORIGEM", out valor) && valor == "0004");

            }
        }
    }
}