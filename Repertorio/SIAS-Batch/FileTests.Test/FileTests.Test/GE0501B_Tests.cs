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
using static Code.GE0501B;

namespace FileTests.Test
{
    [Collection("GE0501B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class GE0501B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region Execute_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "HOST_CURRENT_DATE" , "2024-10-25"},
                { "HOST_CURRENT_TIMESTAMP" , "2024-10-25 12:51:10.699"},
            });
            AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

            #endregion

            #region R200_CONSULTA_PJ_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "OD001_NUM_PESSOA" , "1"},
                { "OD001_DTH_CADASTRAMENTO" , "2009-10-09 08:20:52.437"},
                { "OD001_NUM_DV_PESSOA" , "9"},
                { "OD001_IND_PESSOA" , "J"},
                { "OD001_STA_INF_INTEGRA" , "S"},
                { "OD003_NUM_PESSOA" , "1"},
                { "OD003_NUM_CNPJ" , "34020354"},
                { "OD003_NUM_FILIAL" , "1"},
                { "OD003_NUM_DV_CNPJ" , "10"},
                { "OD003_NOM_RAZAO_SOCIAL" , "CAIXA SEGUROS"},
                { "OD003_STA_PESSOA" , "A"},
                { "OD003_NUM_RAMO_ATIVIDADE" , "0"},
                { "OD003_DTH_FUNDACAO" , "1900-01-01"},
                { "OD003_NOM_FANTASIA" , ""},
                { "OD003_NOM_SIGLA_PESSOA" , ""},
                { "OD003_NUM_INSC_ESTADUAL" , ""},
                { "OD003_NUM_INSC_MUNICIPAL" , ""},
                { "OD003_COD_UF" , "DF"},
                { "OD003_NUM_MUNICIPIO" , ""},
                { "OD003_COD_CNAE" , ""},
                { "OD003_NUM_SOCIOS" , ""},
                { "OD003_STA_FRANQUIA" , "S"},
                { "OD003_IND_FINALIDADE" , "S"},
            });
            AppSettings.TestSet.DynamicData.Add("R200_CONSULTA_PJ_DB_SELECT_1_Query1", q1);

            #endregion

            #region R100_INSERT_PJ_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "OD001_NUM_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R100_INSERT_PJ_DB_SELECT_1_Query1", q2);

            #endregion

            #region INICIO_LOOP_NOME_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "OD001_NUM_PESSOA" , ""},
                { "OD001_DTH_CADASTRAMENTO" , ""},
                { "OD001_NUM_DV_PESSOA" , ""},
                { "OD001_IND_PESSOA" , ""},
                { "OD001_STA_INF_INTEGRA" , ""},
            });
            AppSettings.TestSet.DynamicData.Remove("INICIO_LOOP_NOME_DB_INSERT_1_Insert1");
            AppSettings.TestSet.DynamicData.Add("INICIO_LOOP_NOME_DB_INSERT_1_Insert1", q3);

            #endregion

            #region INICIO_LOOP_NOME_DB_INSERT_2_Insert1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "OD003_NUM_PESSOA" , ""},
                { "OD003_NUM_CNPJ" , ""},
                { "OD003_NUM_FILIAL" , ""},
                { "OD003_NUM_DV_CNPJ" , ""},
                { "OD003_NOM_RAZAO_SOCIAL" , ""},
                { "OD003_STA_PESSOA" , ""},
                { "OD003_NUM_RAMO_ATIVIDADE" , ""},
                { "OD003_DTH_FUNDACAO" , ""},
                { "OD003_NOM_FANTASIA" , ""},
                { "OD003_NOM_SIGLA_PESSOA" , ""},
                { "OD003_NUM_INSC_ESTADUAL" , ""},
                { "OD003_NUM_INSC_MUNICIPAL" , ""},
                { "OD003_COD_UF" , ""},
                { "OD003_NUM_MUNICIPIO" , ""},
                { "OD003_COD_CNAE" , ""},
                { "OD003_NUM_SOCIOS" , ""},
                { "OD003_STA_FRANQUIA" , ""},
                { "OD003_IND_FINALIDADE" , ""},
            });
            AppSettings.TestSet.DynamicData.Remove("INICIO_LOOP_NOME_DB_INSERT_2_Insert1");
            AppSettings.TestSet.DynamicData.Add("INICIO_LOOP_NOME_DB_INSERT_2_Insert1", q4);

            #endregion

            #region GE0501B_V0PJURIDICA

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "OD001_NUM_PESSOA" , "1"},
                { "OD001_DTH_CADASTRAMENTO" , "2009-05-04 19:53:40.384"},
                { "OD001_NUM_DV_PESSOA" , "7"},
                { "OD001_IND_PESSOA" , "J"},
                { "OD001_STA_INF_INTEGRA" , "S"},
                { "OD003_NUM_PESSOA" , "1"},
                { "OD003_NUM_CNPJ" , "34020354"},
                { "OD003_NUM_FILIAL" , "1"},
                { "OD003_NUM_DV_CNPJ" , "10"},
                { "OD003_NOM_RAZAO_SOCIAL" , "AAAAAAAAAAAAAA"},
                { "OD003_STA_PESSOA" , "A"},
                { "OD003_NUM_RAMO_ATIVIDADE" , "0"},
                { "OD003_DTH_FUNDACAO" , ""},
                { "OD003_NOM_FANTASIA" , ""},
                { "OD003_NOM_SIGLA_PESSOA" , ""},
                { "OD003_NUM_INSC_ESTADUAL" , ""},
                { "OD003_NUM_INSC_MUNICIPAL" , ""},
                { "OD003_COD_UF" , "DF"},
                { "OD003_NUM_MUNICIPIO" , ""},
                { "OD003_COD_CNAE" , ""},
                { "OD003_NUM_SOCIOS" , ""},
                { "OD003_STA_FRANQUIA" , "S"},
                { "OD003_IND_FINALIDADE" , "S"},
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "OD001_NUM_PESSOA" , "1"},
                { "OD001_DTH_CADASTRAMENTO" , "2009-05-04 19:53:40.384"},
                { "OD001_NUM_DV_PESSOA" , "7"},
                { "OD001_IND_PESSOA" , "J"},
                { "OD001_STA_INF_INTEGRA" , "S"},
                { "OD003_NUM_PESSOA" , "1"},
                { "OD003_NUM_CNPJ" , "34020354"},
                { "OD003_NUM_FILIAL" , "1"},
                { "OD003_NUM_DV_CNPJ" , "10"},
                { "OD003_NOM_RAZAO_SOCIAL" , "AAAAAAAAAAAAAA"},
                { "OD003_STA_PESSOA" , "A"},
                { "OD003_NUM_RAMO_ATIVIDADE" , "0"},
                { "OD003_DTH_FUNDACAO" , ""},
                { "OD003_NOM_FANTASIA" , ""},
                { "OD003_NOM_SIGLA_PESSOA" , ""},
                { "OD003_NUM_INSC_ESTADUAL" , ""},
                { "OD003_NUM_INSC_MUNICIPAL" , ""},
                { "OD003_COD_UF" , "DF"},
                { "OD003_NUM_MUNICIPIO" , ""},
                { "OD003_COD_CNAE" , ""},
                { "OD003_NUM_SOCIOS" , ""},
                { "OD003_STA_FRANQUIA" , "S"},
                { "OD003_IND_FINALIDADE" , "S"},
            });
            AppSettings.TestSet.DynamicData.Add("GE0501B_V0PJURIDICA", q5);

            #endregion

            #endregion
        }

        [Fact]
        public static void GE0501B_Tests_Fact()
        {
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
                var program = new GE0501B();
                program.Execute(new GE0501B_LINK_PARAMETRO());

                Assert.True(true);
            }
        }
    }
}