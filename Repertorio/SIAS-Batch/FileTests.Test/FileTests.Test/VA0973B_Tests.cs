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
using static Code.VA0973B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VA0973B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VA0973B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region VA0973B_CPARCELAS

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_CERTIFICADO" , "1234"},
                { "WS_HOST_DES_SITU" , "TESTE"},
                { "HISLANCT_NUM_PARCELA" , "10"},
                { "PROPOVA_NUM_APOLICE" , "123456"},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "GE407_COD_IDLG" , ""},
                { "PARCEVID_DATA_VENCIMENTO" , ""},
                { "GE408_DTA_CREDITO" , ""},
                { "PROPOVA_DTPROXVEN" , ""},
                { "OPCPAGVI_DIA_DEBITO" , ""},
                { "HISLANCT_PRM_TOTAL" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "PRODUVG_NOME_PRODUTO" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "ENDERECO_DDD" , ""},
                { "ENDERECO_TELEFONE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0973B_CPARCELAS", q0);

            #endregion

            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-12-12"},
                { "WS_HOST_DT_HOJE" , "2024-12-31"},
                { "WS_HOST_DT_MAIS5D" , "2025-01-05"},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q1);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("RETCIELO_FILE_NAME_P")]
        public static void VA0973B_Tests_Theory(string RETCIELO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RETCIELO_FILE_NAME_P = $"{RETCIELO_FILE_NAME_P}_{timestamp}.txt";
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
                var program = new VA0973B();
                program.Execute(RETCIELO_FILE_NAME_P);

                Assert.True(File.Exists(program.RETCIELO.FilePath));
                Assert.True(new FileInfo(program.RETCIELO.FilePath)?.Length > 0);
                
                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("RETCIELO_FILE_NAME_P")]
        public static void VA0973B_Tests_Theory_Error99(string RETCIELO_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RETCIELO_FILE_NAME_P = $"{RETCIELO_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q1 = new DynamicData();

                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");

                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q1);

                #endregion

                #endregion
                var program = new VA0973B();
                program.Execute(RETCIELO_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}