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
using static Code.SI0863B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0863B_Tests")]
    public class SI0863B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R010_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "V1SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region SI0863B_CARTA_AVISO

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SINBENCB_NUM_APOLICE" , ""},
                { "SINBENCB_NUM_SINISTRO" , ""},
                { "SINBENCB_NUM_BILHETE" , ""},
                { "SINBENCB_OCORR_HISTORICO" , ""},
                { "SINBENCB_DTMOVTO" , ""},
                { "SINBENCB_NOME_BENEFICIARIO" , ""},
                { "SINBENCB_ENDERECO" , ""},
                { "SINBENCB_BAIRRO" , ""},
                { "SINBENCB_CIDADE" , ""},
                { "SINBENCB_SIGLA_UF" , ""},
                { "SINBENCB_CEP" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0863B_CARTA_AVISO", q1);

            #endregion

            #region R200_UPDATE_SITUACAO_DB_UPDATE_1_Update1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SINBENCB_OCORR_HISTORICO" , ""},
                { "SINBENCB_NUM_SINISTRO" , ""},
                { "SINBENCB_NUM_APOLICE" , ""},
                { "SINBENCB_NUM_BILHETE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R200_UPDATE_SITUACAO_DB_UPDATE_1_Update1", q2);

            #endregion

            #region R300_GERA_OBJETO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "GEOBJECT_STA_REGISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R300_GERA_OBJETO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R303_INSERT_OBJETO_DB_INSERT_1_Insert1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "GEOBJECT_NUM_CEP" , ""},
                { "GEOBJECT_COD_FORMULARIO" , ""},
                { "GEOBJECT_STA_REGISTRO" , ""},
                { "GEOBJECT_COD_PRODUTO" , ""},
                { "GEOBJECT_NUM_INI_POS_VERSO" , ""},
                { "GEOBJECT_QTD_PESO_GRAMAS" , ""},
                { "GEOBJECT_VLR_DECLARADO" , ""},
                { "GEOBJECT_COD_IDENT_OBJETO" , ""},
                { "GEOBJECT_DES_OBJETO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R303_INSERT_OBJETO_DB_INSERT_1_Insert1", q4);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0863B_t1")]
        public static void SI0863B_Tests_Theory(string SI0863BA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0863BA_FILE_NAME_P = $"{SI0863BA_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R010_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                    { "V1SIST_DTCURRENT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R010_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0863B_CARTA_AVISO

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SINBENCB_NUM_APOLICE" , ""},
                    { "SINBENCB_NUM_SINISTRO" , ""},
                    { "SINBENCB_NUM_BILHETE" , ""},
                    { "SINBENCB_OCORR_HISTORICO" , ""},
                    { "SINBENCB_DTMOVTO" , ""},
                    { "SINBENCB_NOME_BENEFICIARIO" , ""},
                    { "SINBENCB_ENDERECO" , ""},
                    { "SINBENCB_BAIRRO" , ""},
                    { "SINBENCB_CIDADE" , ""},
                    { "SINBENCB_SIGLA_UF" , ""},
                    { "SINBENCB_CEP" , ""},
                    { "SINISMES_COD_PRODUTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0863B_CARTA_AVISO");
                AppSettings.TestSet.DynamicData.Add("SI0863B_CARTA_AVISO", q1);

                #endregion

                #region R200_UPDATE_SITUACAO_DB_UPDATE_1_Update1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "SINBENCB_OCORR_HISTORICO" , ""},
                    { "SINBENCB_NUM_SINISTRO" , ""},
                    { "SINBENCB_NUM_APOLICE" , ""},
                    { "SINBENCB_NUM_BILHETE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R200_UPDATE_SITUACAO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R200_UPDATE_SITUACAO_DB_UPDATE_1_Update1", q2);

                #endregion

                #region R300_GERA_OBJETO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "GEOBJECT_STA_REGISTRO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R300_GERA_OBJETO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R300_GERA_OBJETO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R303_INSERT_OBJETO_DB_INSERT_1_Insert1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "GEOBJECT_NUM_CEP" , ""},
                    { "GEOBJECT_COD_FORMULARIO" , ""},
                    { "GEOBJECT_STA_REGISTRO" , ""},
                    { "GEOBJECT_COD_PRODUTO" , ""},
                    { "GEOBJECT_NUM_INI_POS_VERSO" , ""},
                    { "GEOBJECT_QTD_PESO_GRAMAS" , ""},
                    { "GEOBJECT_VLR_DECLARADO" , ""},
                    { "GEOBJECT_COD_IDENT_OBJETO" , ""},
                    { "GEOBJECT_DES_OBJETO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R303_INSERT_OBJETO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R303_INSERT_OBJETO_DB_INSERT_1_Insert1", q4);

                #endregion

                #endregion
                var program = new SI0863B();
                program.Execute(SI0863BA_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var quantQuerys = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("SI0863B_t2")]
        public static void SI0863B_Tests_Theory_Return99(string SI0863BA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0863BA_FILE_NAME_P = $"{SI0863BA_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R010_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                    { "V1SIST_DTCURRENT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R010_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R010_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0863B_CARTA_AVISO

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SINBENCB_NUM_APOLICE" , ""},
                    { "SINBENCB_NUM_SINISTRO" , ""},
                    { "SINBENCB_NUM_BILHETE" , ""},
                    { "SINBENCB_OCORR_HISTORICO" , ""},
                    { "SINBENCB_DTMOVTO" , ""},
                    { "SINBENCB_NOME_BENEFICIARIO" , ""},
                    { "SINBENCB_ENDERECO" , ""},
                    { "SINBENCB_BAIRRO" , ""},
                    { "SINBENCB_CIDADE" , ""},
                    { "SINBENCB_SIGLA_UF" , ""},
                    { "SINBENCB_CEP" , ""},
                    { "SINISMES_COD_PRODUTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0863B_CARTA_AVISO");
                AppSettings.TestSet.DynamicData.Add("SI0863B_CARTA_AVISO", q1);

                #endregion

                #region R200_UPDATE_SITUACAO_DB_UPDATE_1_Update1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "SINBENCB_OCORR_HISTORICO" , ""},
                    { "SINBENCB_NUM_SINISTRO" , ""},
                    { "SINBENCB_NUM_APOLICE" , ""},
                    { "SINBENCB_NUM_BILHETE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R200_UPDATE_SITUACAO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R200_UPDATE_SITUACAO_DB_UPDATE_1_Update1", q2);

                #endregion

                #region R300_GERA_OBJETO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                });
                AppSettings.TestSet.DynamicData.Remove("R300_GERA_OBJETO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R300_GERA_OBJETO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R303_INSERT_OBJETO_DB_INSERT_1_Insert1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "GEOBJECT_NUM_CEP" , ""},
                    { "GEOBJECT_COD_FORMULARIO" , ""},
                    { "GEOBJECT_STA_REGISTRO" , ""},
                    { "GEOBJECT_COD_PRODUTO" , ""},
                    { "GEOBJECT_NUM_INI_POS_VERSO" , ""},
                    { "GEOBJECT_QTD_PESO_GRAMAS" , ""},
                    { "GEOBJECT_VLR_DECLARADO" , ""},
                    { "GEOBJECT_COD_IDENT_OBJETO" , ""},
                    { "GEOBJECT_DES_OBJETO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R303_INSERT_OBJETO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R303_INSERT_OBJETO_DB_INSERT_1_Insert1", q4);

                #endregion

                #endregion
                var program = new SI0863B();
                program.Execute(SI0863BA_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                var quantQuerys = AppSettings.TestSet.DynamicData.Count();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}