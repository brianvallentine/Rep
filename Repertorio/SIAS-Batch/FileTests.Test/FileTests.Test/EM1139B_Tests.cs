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
using static Code.EM1139B;

namespace FileTests.Test
{
    [Collection("EM1139B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM1139B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region EM1139B_V0PARCEHIS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "ORDEMCOS_NUM_APOLICE" , ""},
                { "ORDEMCOS_NUM_ENDOSSO" , ""},
                { "ORDEMCOS_COD_COSSEGURADORA" , ""},
                { "APOLICOB_RAMO_COBERTURA" , ""},
                { "APOLICOB_COD_COBERTURA" , ""},
                { "APOLICOB_IMP_SEGURADA_VAR" , ""},
                { "APOLICOB_PRM_TARIFARIO_VAR" , ""},
                { "PARCEHIS_DATA_MOVIMENTO" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "APOLCOSS_PCT_COM_COSSEGURO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM1139B_V0PARCEHIS", q1);

            #endregion

            #region R0510_00_INSERT_GE397_DB_INSERT_1_Insert1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "GE397_NUM_APOLICE" , ""},
                { "GE397_NUM_ENDOSSO" , ""},
                { "GE397_COD_RAMO_COBER" , ""},
                { "GE397_COD_COBERTURA" , ""},
                { "GE397_VLR_IMP_SEGUR_VAR" , ""},
                { "GE397_VLR_PREMIO_TARIF_VAR" , ""},
                { "GE397_NOM_PROGRAMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0510_00_INSERT_GE397_DB_INSERT_1_Insert1", q2);

            #endregion

            #region R0520_00_INSERT_GE398_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "GE398_NUM_APOLICE" , ""},
                { "GE398_NUM_ENDOSSO" , ""},
                { "GE398_COD_RAMO_COBER" , ""},
                { "GE398_COD_COBERTURA" , ""},
                { "GE398_COD_COSSEGURADORA" , ""},
                { "GE398_PCT_PARTIC_COBER" , ""},
                { "GE398_PCT_COMCOS_COBER" , ""},
                { "GE398_NOM_PROGRAMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0520_00_INSERT_GE398_DB_INSERT_1_Insert1", q3);

            #endregion

            #endregion
        }

        [Fact]
        public static void EM1139B_Tests_Fact()
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
                var program = new EM1139B();
                program.Execute();

                var envList = AppSettings.TestSet.DynamicData["R0510_00_INSERT_GE397_DB_INSERT_1_Insert1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R0520_00_INSERT_GE398_DB_INSERT_1_Insert1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);

                Assert.True(envList[1].TryGetValue("GE397_NUM_APOLICE", out string valor) && valor == "0000000000000");
                Assert.True(envList1[1].TryGetValue("GE398_NUM_APOLICE", out valor) && valor == "0000000000000");
            }
        }
    }
}