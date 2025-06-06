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
using static Code.SI5039B;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI5039B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SI5039B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region SI5039B_CR_HISTORICO

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "12365656"},
                { "SINISHIS_DATA_MOVIMENTO" , "2006-08-16"},
                { "SINISHIS_VAL_OPERACAO" , "50000"},
                { "SINISHIS_COD_OPERACAO" , "101"},
                { "SINISHIS_OCORR_HISTORICO" , "1"},
                { "SINISHIS_NOM_PROGRAMA" , ""},
                { "SINISHIS_COD_USUARIO" , "SARA    "},
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "12365659"},
                { "SINISHIS_DATA_MOVIMENTO" , "2006-08-19"},
                { "SINISHIS_VAL_OPERACAO" , "50000"},
                { "SINISHIS_COD_OPERACAO" , "101"},
                { "SINISHIS_OCORR_HISTORICO" , "1"},
                { "SINISHIS_NOM_PROGRAMA" , ""},
                { "SINISHIS_COD_USUARIO" , "SARA    "},
            });
            q0.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "12365659"},
                { "SINISHIS_DATA_MOVIMENTO" , "2006-08-19"},
                { "SINISHIS_VAL_OPERACAO" , "50000"},
                { "SINISHIS_COD_OPERACAO" , "101"},
                { "SINISHIS_OCORR_HISTORICO" , "1"},
                { "SINISHIS_NOM_PROGRAMA" , ""},
                { "SINISHIS_COD_USUARIO" , "SARA    "},
            });
            AppSettings.TestSet.DynamicData.Add("SI5039B_CR_HISTORICO", q0);

            #endregion

            #region R10_LE_DATA_SISTEMAS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"},
                { "SISTEMAS_DATULT_PROCESSAMEN" , "2020-04-01"},
            });
            AppSettings.TestSet.DynamicData.Add("R10_LE_DATA_SISTEMAS_DB_SELECT_1_Query1", q1);

            #endregion
            SI1017S_Tests.Load_Parameters();
            #endregion
        }

        [Theory]
        [InlineData("Saida_SI5039B")]
        public static void SI5039B_Tests_Theory(string ARQNEGAV_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQNEGAV_FILE_NAME_P = $"{ARQNEGAV_FILE_NAME_P}_{timestamp}.txt";

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
                var program = new SI5039B();
                program.Execute(ARQNEGAV_FILE_NAME_P);

                Assert.True(File.Exists(program.ARQNEGAV.FilePath));
                Assert.True(new FileInfo(program.ARQNEGAV.FilePath)?.Length > 0);

                //sub
                Assert.True(program.LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO == 0000001500000.00);

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Theory]
        [InlineData("Saida_SI5039B")]
        public static void SI5039B_Tests_TheoryErro99(string ARQNEGAV_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQNEGAV_FILE_NAME_P = $"{ARQNEGAV_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R10_LE_DATA_SISTEMAS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R10_LE_DATA_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R10_LE_DATA_SISTEMAS_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion
                var program = new SI5039B();
                program.Execute(ARQNEGAV_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}