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
using static Code.SI9229B;
using Newtonsoft.Json;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI9229B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SI9229B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region SI9229B_CUR01_HIST_MESTRE

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_PRODUTO" , ""},
                { "SINISMES_COD_CAUSA" , ""},
                { "SINISCAU_DESCR_CAUSA" , ""},
                { "CAUSACOB_COD_COBERTURA" , ""},
                { "COBERDES_DESCR_COBERTURA" , ""},
                { "SINISMES_NUM_APOLICE" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "SINISMES_DATA_TECNICA" , ""},
                { "WS_VLR_AVISADO" , ""},
                { "WS_E_ENDOSSO" , ""},
                { "ENDOSSOS_DATA_EMISSAO" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "WS_E_PREMATURO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI9229B_CUR01_HIST_MESTRE", q0);

            #endregion

            #region R0050_00_MAX_GEARDETA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_SEQ_GERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0050_00_MAX_GEARDETA_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SISTEMAS_DATULT_PROCESSAMEN" , ""},
                { "HOST_ANO_MOV_SISTEMAS" , ""},
                { "HOST_MES_MOV_SISTEMAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q2);

            #endregion

            #region R6000_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "GEARDETA_NOM_ARQUIVO" , ""},
                { "GEARDETA_SEQ_GERACAO" , ""},
                { "GEARDETA_DTH_ANO_REFERENCIA" , ""},
                { "GEARDETA_DTH_MES_REFERENCIA" , ""},
                { "GEARDETA_DTH_MOVIMENTO" , ""},
                { "GEARDETA_DTH_GERACAO" , ""},
                { "GEARDETA_DTH_RECEPCAO" , ""},
                { "GEARDETA_IND_MEIO_ENVIO" , ""},
                { "GEARDETA_STA_ENVIO_RECEPCAO" , ""},
                { "GEARDETA_COD_TIPO_ARQUIVO" , ""},
                { "GEARDETA_QTD_REG_PROCESSADO" , ""},
                { "GEARDETA_QTD_REG_REJEITADOS" , ""},
                { "GEARDETA_QTD_REG_ACEITOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1", q3);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SIAVISAD")]
        public static void SI9229B_Tests_Theory(string SIAVISAD_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SIAVISAD_FILE_NAME_P = $"{SIAVISAD_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                var program = new SI9229B();

                var fileName = Path.GetFileNameWithoutExtension(SIAVISAD_FILE_NAME_P);
                SIAVISAD_FILE_NAME_P = SIAVISAD_FILE_NAME_P.Replace(fileName, fileName + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"));

                Console.WriteLine($"#### Arquivo {JsonConvert.SerializeObject(AppSettings.Settings, Formatting.Indented)}");
                Console.WriteLine($"#### Arquivo {SIAVISAD_FILE_NAME_P} em : {AppSettings.Settings.FileFolderPath}");

                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                program.Execute(SIAVISAD_FILE_NAME_P);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);
                var envList = AppSettings.TestSet.DynamicData["R6000_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1"].DynamicList;

                Assert.True(File.Exists(program.SIAVISAD.FilePath));
                Assert.True(new FileInfo(program.SIAVISAD.FilePath)?.Length > 0);

                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("GEARDETA_NOM_ARQUIVO", out var valor) && valor == "SIAVISAD");
                Assert.True(envList[1].TryGetValue("GEARDETA_SEQ_GERACAO", out valor) && valor == "000000001");

            }
        }

        [Theory]
        [InlineData("SIAVISAD_FILE_NAME_P")]
        public static void SI9229B_Tests_Sem_Dados(string SIAVISAD_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SIAVISAD_FILE_NAME_P = $"{SIAVISAD_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...
                #region VARIAVEIS_TESTE
                #region R0100_00_SELECT_SISTEMAS_Query1

                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion
                var program = new SI9229B();
                program.Execute(SIAVISAD_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}