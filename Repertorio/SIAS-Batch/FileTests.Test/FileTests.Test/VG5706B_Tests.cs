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
using static Code.VG5706B;

namespace FileTests.Test
{
    [Collection("VG5706B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG5706B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0000_INICIO_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SQL_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_INICIO_DB_SELECT_1_Query1", q0);

            #endregion

            #region VG5706B_V0MOVIMENTO

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SQL_NUM_APOL" , ""},
                { "SQL_COD_SUB" , ""},
                { "SQL_COD_FONTE" , ""},
                { "SQL_PROPOSTA" , ""},
                { "SQL_TIPO_SEG" , ""},
                { "SQL_NUM_CERT" , ""},
                { "SQL_DAC_CERT" , ""},
                { "SQL_COD_CLIE" , ""},
                { "SQL_COD_AGEN" , ""},
                { "SQL_MATRICULA" , ""},
                { "SQL_PRM_VG" , ""},
                { "SQL_PRM_AP" , ""},
                { "SQL_COD_OPERAC" , ""},
                { "SQL_FAIXA" , ""},
                { "SQL_PERC_COMIS" , ""},
                { "SQL_NRPARCEL" , ""},
                { "SQL_DTMOVTO" , ""},
                { "SQL_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG5706B_V0MOVIMENTO", q1);

            #endregion

            #region M_0000_INICIO_DB_SELECT_2_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SQL_PCIOF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_INICIO_DB_SELECT_2_Query1", q2);

            #endregion

            #region M_1300_UPDATE_DB_UPDATE_1_Update1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SQL_SITUACAO" , ""},
                { "SQL_DTMOVABE" , ""},
                { "SQL_COD_OPERAC" , ""},
                { "SQL_NUM_CERT" , ""},
                { "SQL_NRPARCEL" , ""},
                { "SQL_DTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1300_UPDATE_DB_UPDATE_1_Update1", q3);

            #endregion

            #region M_1350_CALCULA_COMISSAO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SQL_PAGAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1350_CALCULA_COMISSAO_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_1400_LOOP_GRAVA_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SQL_NUM_APOL" , ""},
                { "SQL_NUM_CERT" , ""},
                { "SQL_DAC_CERT" , ""},
                { "SQL_TIPO_SEG" , ""},
                { "SQL_COD_AGEN" , ""},
                { "SQL_RAMOFR" , ""},
                { "SQL_COD_FONTE" , ""},
                { "SQL_COD_CLIE" , ""},
                { "SQL_VLCOMIS" , ""},
                { "SQL_DTMOVABE" , ""},
                { "SQL_VALBAS" , ""},
                { "SQL_PCT_AGENC" , ""},
                { "SQL_COD_SUB" , ""},
                { "SQL_HORAOPER" , ""},
                { "SQL_DATSEL" , ""},
                { "SQL_PROPOSTA" , ""},
                { "SQL_NUMBIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1400_LOOP_GRAVA_DB_INSERT_1_Insert1", q5);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG5706B_Tests_Fact()
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
                AppSettings.TestSet.DynamicData.Remove("VG5706B_V0MOVIMENTO");
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SQL_NUM_APOL" , ""},
                { "SQL_COD_SUB" , ""},
                { "SQL_COD_FONTE" , ""},
                { "SQL_PROPOSTA" , ""},
                { "SQL_TIPO_SEG" , ""},
                { "SQL_NUM_CERT" , "000000000001234"},
                { "SQL_DAC_CERT" , ""},
                { "SQL_COD_CLIE" , ""},
                { "SQL_COD_AGEN" , ""},
                { "SQL_MATRICULA" , ""},
                { "SQL_PRM_VG" , "1"},
                { "SQL_PRM_AP" , ""},
                { "SQL_COD_OPERAC" , ""},
                { "SQL_FAIXA" , ""},
                { "SQL_PERC_COMIS" , ""},
                { "SQL_NRPARCEL" , ""},
                { "SQL_DTMOVTO" , ""},
                { "SQL_SITUACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("VG5706B_V0MOVIMENTO", q2);

                #endregion
                var program = new VG5706B();
                program.Execute();

                var envList = AppSettings.TestSet.DynamicData["M_1300_UPDATE_DB_UPDATE_1_Update1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["M_1400_LOOP_GRAVA_DB_INSERT_1_Insert1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);

                Assert.True(envList[1].TryGetValue("SQL_NUM_CERT", out string valor) && valor == "000000000001234");
                Assert.True(envList1[1].TryGetValue("SQL_DATSEL", out valor) && valor == "9999-12-31");
            }
        }
    }
}