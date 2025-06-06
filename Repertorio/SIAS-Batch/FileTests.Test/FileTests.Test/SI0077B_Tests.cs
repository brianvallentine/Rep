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
using static Code.SI0077B;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0077B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0077B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_9999_00_ENCERRA_DB_DELETE_1_Delete1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_9999_00_ENCERRA_DB_DELETE_1_Delete1", q0);

            #endregion

            #region M_010_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0RELATORIOS_DATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_010_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_020_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0SISTEMA_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_020_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q2);

            #endregion

            #region SI0077B_V0SINIHABIT4

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0HABIT4_NUM_APOL_SINISTRO" , ""},
                { "V0HABIT4_NUM_FIAP" , ""},
                { "V0HABIT4_DATA_CONTRATO" , ""},
                { "V0HABIT4_DATA_SINISTRO" , ""},
                { "V0HABIT4_DATA_INDENIZACAO" , ""},
                { "V0HABIT4_DATA_SALDO_DEVEDOR" , ""},
                { "V0HABIT4_NOME_SEGURADO" , ""},
                { "V0HABIT4_PERC_PARTICIPACAO" , ""},
                { "V0HABIT4_DIAS_M" , ""},
                { "V0HABIT4_DIAS_N" , ""},
                { "V0HABIT4_DIAS_CORRIDOS_D" , ""},
                { "V0HABIT4_PERC_JUROS" , ""},
                { "V0HABIT4_VAL_SDO_DEVEDOR" , ""},
                { "V0HABIT4_VAL_SDO_CORRIGIDO" , ""},
                { "V0HABIT4_VAL_INDENIZACAO" , ""},
                { "V0HABIT4_PRI_INPC" , ""},
                { "V0HABIT4_PRI_INPC_MMAA" , ""},
                { "V0HABIT4_ULT_INPC" , ""},
                { "V0HABIT4_ULT_INPC_MMAA" , ""},
                { "V0HABIT4_INPC_INDENI" , ""},
                { "V0HABIT4_INPC_INDENI_MMAA" , ""},
                { "V0HABIT4_INPC_PRO_RATA" , ""},
                { "V0HABIT4_TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0077B_V0SINIHABIT4", q3);

            #endregion

            #region M_110_SELECT_V0MESTSINI_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0MEST_NUM_APOLICE" , ""},
                { "V0MEST_CODCAU" , ""},
                { "V0MEST_RAMO" , ""},
                { "V0MEST_NUMIRB" , ""},
                { "V0MEST_DATORR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_110_SELECT_V0MESTSINI_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_115_SELECT_V0SINICAUSA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0CAUSA_DESCAU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_115_SELECT_V0SINICAUSA_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_140_SELECT_ESTIPULANTE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0CLIENTE_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_140_SELECT_ESTIPULANTE_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_153_ACESSA_V0COTACAO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "W_V0COTACAO_VALCPR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_153_ACESSA_V0COTACAO_DB_SELECT_1_Query1", q7);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0077B_OUTPUT_202504100000")]
        public static void SI0077B_Tests_Theory(string SIHAPLAN_FILE_NAME_P)
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
                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0HABIT4_NUM_APOL_SINISTRO" , ""},
                { "V0HABIT4_NUM_FIAP" , ""},
                { "V0HABIT4_DATA_CONTRATO" , ""},
                { "V0HABIT4_DATA_SINISTRO" , ""},
                { "V0HABIT4_DATA_INDENIZACAO" , ""},
                { "V0HABIT4_DATA_SALDO_DEVEDOR" , ""},
                { "V0HABIT4_NOME_SEGURADO" , ""},
                { "V0HABIT4_PERC_PARTICIPACAO" , ""},
                { "V0HABIT4_DIAS_M" , ""},
                { "V0HABIT4_DIAS_N" , ""},
                { "V0HABIT4_DIAS_CORRIDOS_D" , ""},
                { "V0HABIT4_PERC_JUROS" , ""},
                { "V0HABIT4_VAL_SDO_DEVEDOR" , ""},
                { "V0HABIT4_VAL_SDO_CORRIGIDO" , ""},
                { "V0HABIT4_VAL_INDENIZACAO" , ""},
                { "V0HABIT4_PRI_INPC" , ""},
                { "V0HABIT4_PRI_INPC_MMAA" , "0902"},
                { "V0HABIT4_ULT_INPC" , ""},
                { "V0HABIT4_ULT_INPC_MMAA" , "1002"},
                { "V0HABIT4_INPC_INDENI" , ""},
                { "V0HABIT4_INPC_INDENI_MMAA" , ""},
                { "V0HABIT4_INPC_PRO_RATA" , ""},
                { "V0HABIT4_TIMESTAMP" , ""},
            });
                AppSettings.TestSet.DynamicData.Remove("SI0077B_V0SINIHABIT4");
                AppSettings.TestSet.DynamicData.Add("SI0077B_V0SINIHABIT4", q3);
                #endregion
                var program = new SI0077B();
                program.Execute(SIHAPLAN_FILE_NAME_P);

                Assert.Empty(AppSettings.TestSet.DynamicData["M_9999_00_ENCERRA_DB_DELETE_1_Delete1"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["SI0077B_V0SINIHABIT4"].DynamicList.ToList());

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);
                Assert.True(program.RETURN_CODE == 0);
            }
        }
    }
}