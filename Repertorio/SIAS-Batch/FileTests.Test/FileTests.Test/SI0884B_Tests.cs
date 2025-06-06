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
using static Code.SI0884B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("SI0884B_Tests")]
    public class SI0884B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region SI0884B_CURS01

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_COD_FONTE" , ""},
                { "SISINACO_NUM_PROTOCOLO_SINI" , ""},
                { "SISINACO_DAC_PROTOCOLO_SINI" , ""},
                { "SISINACO_DATA_MOVTO_SINIACO" , ""},
                { "SISINACO_NUM_OCORR_SINIACO" , ""},
                { "SIMOVSIN_NATUREZA_SINISTRO" , ""},
                { "SIMOVSIN_COD_SUBESTIPULANTE" , ""},
                { "SIMOVSIN_NOME_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0884B_CURS01", q1);

            #endregion

            #region SI0884B_CURS02

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISINFAS_COD_FASE" , ""},
                { "SIFASTIP_SIGLA_FASE" , ""},
                { "SISINFAS_DATA_ABERTURA_SIFA" , ""},
                { "SISINFAS_NUM_OCORR_SINIACO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0884B_CURS02", q2);

            #endregion

            #region M_1000_00_PROCESSA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_NOME_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_00_PROCESSA_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_1000_00_PROCESSA_DB_SELECT_2_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_00_PROCESSA_DB_SELECT_2_Query1", q4);

            #endregion

            #region M_1200_00_CALCULA_DIAS_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1200_00_CALCULA_DIAS_DB_SELECT_1_Query1", q5);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0884B_t1")]
        public static void SI0884B_Tests_Theory_Erro99(string RSICV23B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RSICV23B_FILE_NAME_P = $"{RSICV23B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new SI0884B();
                program.Execute(RSICV23B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Theory]
        [InlineData("SI0884B_t2")]
        public static void SI0884B_Tests_Theory(string RSICV23B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RSICV23B_FILE_NAME_P = $"{RSICV23B_FILE_NAME_P}_{timestamp}.txt";

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
                var program = new SI0884B();
                program.Execute(RSICV23B_FILE_NAME_P);

                //M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1"].DynamicList);

                //M_1000_00_PROCESSA_DB_SELECT_1_Query1
                Assert.Empty(AppSettings.TestSet.DynamicData["M_1000_00_PROCESSA_DB_SELECT_1_Query1"].DynamicList);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}