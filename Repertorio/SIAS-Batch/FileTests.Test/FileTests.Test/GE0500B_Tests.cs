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
using static Code.GE0500B;

namespace FileTests.Test
{
    [Collection("GE0500B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class GE0500B_Tests
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

            #region R010_CRITICA_INCLUSAO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "UNIDAFED_SIGLA_UF" , "SC"}
            });
            AppSettings.TestSet.DynamicData.Add("R010_CRITICA_INCLUSAO_DB_SELECT_1_Query1", q1);

            #endregion

            #region R200_CONSULTA_PF_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "OD001_NUM_PESSOA" , "1"},
                { "OD001_DTH_CADASTRAMENTO" , "2009-10-09 08:20:52.437"},
                { "OD001_NUM_DV_PESSOA" , "9"},
                { "OD001_IND_PESSOA" , "J"},
                { "OD001_STA_INF_INTEGRA" , "S"},
                { "OD002_NUM_PESSOA" , "1002"},
                { "OD002_NUM_CPF" , "06478013906"},
                { "OD002_NUM_DV_CPF" , "20"},
                { "OD002_NOM_PESSOA" , "SILVIA BUENO COSTA"},
                { "OD002_DTH_NASCIMENTO" , "1929-09-04"},
                { "OD002_STA_SEXO" , "F"},
                { "OD002_IND_ESTADO_CIVIL" , ""},
                { "OD002_STA_PESSOA" , "A"},
                { "OD002_NOM_TRATAMENTO" , ""},
                { "OD002_COD_UF" , "PR"},
                { "OD002_NUM_MUNICIPIO" , ""},
                { "OD002_NUM_INSC_SOCIAL" , ""},
                { "OD002_NUM_DV_INSC_SOCIAL" , ""},
                { "OD002_NUM_GRAU_INSTRUCAO" , ""},
                { "OD002_NOM_REDUZIDO" , "ASASDS"},
                { "OD002_COD_CBO" , ""},
                { "OD002_NOM_PRIMEIRO" , "ASDSAD"},
                { "OD002_NOM_ULTIMO" , "SDSADSA"},
            });
            AppSettings.TestSet.DynamicData.Add("R200_CONSULTA_PF_DB_SELECT_1_Query1", q2);

            #endregion

            #region R100_INSERT_PF_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "OD001_NUM_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R100_INSERT_PF_DB_SELECT_1_Query1", q3);

            #endregion

            #region INICIO_LOOP_NOME_DB_INSERT_1_Insert1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "OD001_NUM_PESSOA" , ""},
                { "OD001_DTH_CADASTRAMENTO" , ""},
                { "OD001_NUM_DV_PESSOA" , ""},
                { "OD001_IND_PESSOA" , ""},
                { "OD001_STA_INF_INTEGRA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("INICIO_LOOP_NOME_DB_INSERT_1_Insert1", q4);

            #endregion

            #region INICIO_LOOP_NOME_DB_INSERT_2_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "OD002_NUM_PESSOA" , ""},
                { "OD002_NUM_CPF" , ""},
                { "OD002_NUM_DV_CPF" , ""},
                { "OD002_NOM_PESSOA" , ""},
                { "OD002_DTH_NASCIMENTO" , ""},
                { "OD002_STA_SEXO" , ""},
                { "OD002_IND_ESTADO_CIVIL" , ""},
                { "OD002_STA_PESSOA" , ""},
                { "OD002_NOM_TRATAMENTO" , ""},
                { "OD002_COD_UF" , ""},
                { "OD002_NUM_MUNICIPIO" , ""},
                { "OD002_NUM_INSC_SOCIAL" , ""},
                { "OD002_NUM_DV_INSC_SOCIAL" , ""},
                { "OD002_NUM_GRAU_INSTRUCAO" , ""},
                { "OD002_NOM_REDUZIDO" , ""},
                { "OD002_COD_CBO" , ""},
                { "OD002_NOM_PRIMEIRO" , ""},
                { "OD002_NOM_ULTIMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("INICIO_LOOP_NOME_DB_INSERT_2_Insert1", q5);

            #endregion

            #region GE0500B_V0PFISICA

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "OD001_NUM_PESSOA" , "1"},
                { "OD001_DTH_CADASTRAMENTO" , "2009-10-09 08:20:52.437"},
                { "OD001_NUM_DV_PESSOA" , "9"},
                { "OD001_IND_PESSOA" , "J"},
                { "OD001_STA_INF_INTEGRA" , "S"},
                { "OD002_NUM_PESSOA" , "1002"},
                { "OD002_NUM_CPF" , "887204626"},
                { "OD002_NUM_DV_CPF" , "1929"},
                { "OD002_NOM_PESSOA" , "GUSTAVO"},
                { "OD002_DTH_NASCIMENTO" , "1929-09-04"},
                { "OD002_STA_SEXO" , "F"},
                { "OD002_IND_ESTADO_CIVIL" , ""},
                { "OD002_STA_PESSOA" , "A"},
                { "OD002_NOM_TRATAMENTO" , ""},
                { "OD002_COD_UF" , "SC"},
                { "OD002_NUM_MUNICIPIO" , ""},
                { "OD002_NUM_INSC_SOCIAL" , "DS"},
                { "OD002_NUM_DV_INSC_SOCIAL" , "DF"},
                { "OD002_NUM_GRAU_INSTRUCAO" , "SD"},
                { "OD002_NOM_REDUZIDO" , "FD"},
                { "OD002_COD_CBO" , ""},
                { "OD002_NOM_PRIMEIRO" , "GUSTAVO"},
                { "OD002_NOM_ULTIMO" , "PASSOS"},
            });
            AppSettings.TestSet.DynamicData.Add("GE0500B_V0PFISICA", q6);

            #endregion

            #endregion
        }

        [Fact]
        public static void GE0500B_Tests_Fact()
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
                var program = new GE0500B();
                program.Execute(new GE0500B_LINK_PARAMETRO());

                Assert.True(true);
            }
        }
    }
}