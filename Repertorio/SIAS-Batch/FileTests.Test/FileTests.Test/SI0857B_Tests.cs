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
using static Code.SI0857B;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0857B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0857B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region SI0857B_LISTA

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SIANAROD_COD_USUARIO" , ""},
                { "SIDOCPAR_COD_TIPO_CARTA" , ""},
                { "SIDOCACO_COD_FONTE" , ""},
                { "SIDOCACO_NUM_PROTOCOLO_SINI" , ""},
                { "SIDOCACO_DAC_PROTOCOLO_SINI" , ""},
                { "SIDOCACO_DATA_MOVTO_DOCACO" , ""},
                { "SIDOCACO_COD_DOCUMENTO" , ""},
                { "GEDOCTIP_DESCR_DOCUMENTO" , ""},
                { "SIMOVSIN_NATUREZA_SINISTRO" , ""},
                { "SIMOVSIN_NOME_SEGURADO" , ""},
                { "SIMOVSIN_COD_GIAFI" , ""},
                { "SIMOVSIN_NUM_CONTR_ESTIP" , ""},
                { "GERECADE_COD_DESTINATARIO" , ""},
                { "SIDOCACO_NUM_CARTA" , ""},
                { "SIMOVSIN_COD_SUBESTIPULANTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0857B_LISTA", q0);

            #endregion

            #region R10_LE_DATA_SISTEMAS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R10_LE_DATA_SISTEMAS_DB_SELECT_1_Query1", q1);

            #endregion

            #region R31000_LE_GEDESTIN_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "GEDESTIN_NOME_DESTINATARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R31000_LE_GEDESTIN_DB_SELECT_1_Query1", q2);

            #endregion

            #region R31010_LE_SISINACO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_DATA_MOVTO_SINIACO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R31010_LE_SISINACO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R31020_LE_SINISMES_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_IRB" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R31020_LE_SINISMES_DB_SELECT_1_Query1", q4);

            #endregion

            #region R31030_LE_PRODUTO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R31030_LE_PRODUTO_DB_SELECT_1_Query1", q5);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0857B_1_t1", "SI0857B_2_t1", "SI0857B_3_t1", "SI0857B_4_t1", "SI0857B_5_t1", "SI0857B_6_t1")]
        public static void SI0857B_Tests_TheoryReturnCode00(string ARQGEMAN_FILE_NAME_P, string ARQGEHAB_FILE_NAME_P, string ARQGILIE_FILE_NAME_P, string ARQFUNCE_FILE_NAME_P, string ARQCONSO_FILE_NAME_P, string ARQGEPOI_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQGEMAN_FILE_NAME_P = $"{ARQGEMAN_FILE_NAME_P}_{timestamp}.txt";
            ARQGEHAB_FILE_NAME_P = $"{ARQGEHAB_FILE_NAME_P}_{timestamp}.txt";
            ARQGILIE_FILE_NAME_P = $"{ARQGILIE_FILE_NAME_P}_{timestamp}.txt";
            ARQFUNCE_FILE_NAME_P = $"{ARQFUNCE_FILE_NAME_P}_{timestamp}.txt";
            ARQCONSO_FILE_NAME_P = $"{ARQCONSO_FILE_NAME_P}_{timestamp}.txt";
            ARQGEPOI_FILE_NAME_P = $"{ARQGEPOI_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region SI0857B_LISTA

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SIANAROD_COD_USUARIO" , ""},
                { "SIDOCPAR_COD_TIPO_CARTA" , ""},
                { "SIDOCACO_COD_FONTE" , ""},
                { "SIDOCACO_NUM_PROTOCOLO_SINI" , ""},
                { "SIDOCACO_DAC_PROTOCOLO_SINI" , ""},
                { "SIDOCACO_DATA_MOVTO_DOCACO" , ""},
                { "SIDOCACO_COD_DOCUMENTO" , ""},
                { "GEDOCTIP_DESCR_DOCUMENTO" , ""},
                { "SIMOVSIN_NATUREZA_SINISTRO" , ""},
                { "SIMOVSIN_NOME_SEGURADO" , ""},
                { "SIMOVSIN_COD_GIAFI" , ""},
                { "SIMOVSIN_NUM_CONTR_ESTIP" , ""},
                { "GERECADE_COD_DESTINATARIO" , ""},
                { "SIDOCACO_NUM_CARTA" , ""},
                { "SIMOVSIN_COD_SUBESTIPULANTE" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0857B_LISTA");
                AppSettings.TestSet.DynamicData.Add("SI0857B_LISTA", q0);

                #endregion

                #region R10_LE_DATA_SISTEMAS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R10_LE_DATA_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R10_LE_DATA_SISTEMAS_DB_SELECT_1_Query1", q1);

                #endregion

                #region R31000_LE_GEDESTIN_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "GEDESTIN_NOME_DESTINATARIO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R31000_LE_GEDESTIN_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31000_LE_GEDESTIN_DB_SELECT_1_Query1", q2);

                #endregion

                #region R31010_LE_SISINACO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_DATA_MOVTO_SINIACO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R31010_LE_SISINACO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31010_LE_SISINACO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R31020_LE_SINISMES_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_IRB" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("R31020_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31020_LE_SINISMES_DB_SELECT_1_Query1", q4);

                #endregion

                #region R31030_LE_PRODUTO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , ""}
            });
                AppSettings.TestSet.DynamicData.Remove("R31030_LE_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31030_LE_PRODUTO_DB_SELECT_1_Query1", q5);

                #endregion
                #endregion
                var program = new SI0857B();
                program.Execute(ARQGEMAN_FILE_NAME_P, ARQGEHAB_FILE_NAME_P, ARQGILIE_FILE_NAME_P, ARQFUNCE_FILE_NAME_P, ARQCONSO_FILE_NAME_P, ARQGEPOI_FILE_NAME_P);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                Assert.True(selects.Count > (allSelects.Count / 2));

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0857B_1_t2", "SI0857B_2_t2", "SI0857B_3_t2", "SI0857B_4_t2", "SI0857B_5_t2", "SI0857B_6_t2")]
        public static void SI0857B_Tests_Theory_ReturnCode99(string ARQGEMAN_FILE_NAME_P, string ARQGEHAB_FILE_NAME_P, string ARQGILIE_FILE_NAME_P, string ARQFUNCE_FILE_NAME_P, string ARQCONSO_FILE_NAME_P, string ARQGEPOI_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQGEMAN_FILE_NAME_P = $"{ARQGEMAN_FILE_NAME_P}_{timestamp}.txt";
            ARQGEHAB_FILE_NAME_P = $"{ARQGEHAB_FILE_NAME_P}_{timestamp}.txt";
            ARQGILIE_FILE_NAME_P = $"{ARQGILIE_FILE_NAME_P}_{timestamp}.txt";
            ARQFUNCE_FILE_NAME_P = $"{ARQFUNCE_FILE_NAME_P}_{timestamp}.txt";
            ARQCONSO_FILE_NAME_P = $"{ARQCONSO_FILE_NAME_P}_{timestamp}.txt";
            ARQGEPOI_FILE_NAME_P = $"{ARQGEPOI_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region SI0857B_LISTA

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SIANAROD_COD_USUARIO" , ""},
                { "SIDOCPAR_COD_TIPO_CARTA" , ""},
                { "SIDOCACO_COD_FONTE" , ""},
                { "SIDOCACO_NUM_PROTOCOLO_SINI" , ""},
                { "SIDOCACO_DAC_PROTOCOLO_SINI" , ""},
                { "SIDOCACO_DATA_MOVTO_DOCACO" , ""},
                { "SIDOCACO_COD_DOCUMENTO" , ""},
                { "GEDOCTIP_DESCR_DOCUMENTO" , ""},
                { "SIMOVSIN_NATUREZA_SINISTRO" , ""},
                { "SIMOVSIN_NOME_SEGURADO" , ""},
                { "SIMOVSIN_COD_GIAFI" , ""},
                { "SIMOVSIN_NUM_CONTR_ESTIP" , ""},
                { "GERECADE_COD_DESTINATARIO" , ""},
                { "SIDOCACO_NUM_CARTA" , ""},
                { "SIMOVSIN_COD_SUBESTIPULANTE" , ""},
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("SI0857B_LISTA");
                AppSettings.TestSet.DynamicData.Add("SI0857B_LISTA", q0);

                #endregion

                #region R10_LE_DATA_SISTEMAS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R10_LE_DATA_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R10_LE_DATA_SISTEMAS_DB_SELECT_1_Query1", q1);

                #endregion

                #region R31000_LE_GEDESTIN_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "GEDESTIN_NOME_DESTINATARIO" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R31000_LE_GEDESTIN_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31000_LE_GEDESTIN_DB_SELECT_1_Query1", q2);

                #endregion

                #region R31010_LE_SISINACO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_DATA_MOVTO_SINIACO" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R31010_LE_SISINACO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31010_LE_SISINACO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R31020_LE_SINISMES_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_IRB" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R31020_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31020_LE_SINISMES_DB_SELECT_1_Query1", q4);

                #endregion

                #region R31030_LE_PRODUTO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R31030_LE_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R31030_LE_PRODUTO_DB_SELECT_1_Query1", q5);

                #endregion
                #endregion
                var program = new SI0857B();
                program.Execute(ARQGEMAN_FILE_NAME_P, ARQGEHAB_FILE_NAME_P, ARQGILIE_FILE_NAME_P, ARQFUNCE_FILE_NAME_P, ARQCONSO_FILE_NAME_P, ARQGEPOI_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}