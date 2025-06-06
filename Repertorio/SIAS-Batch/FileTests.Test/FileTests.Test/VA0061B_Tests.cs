using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using Copies;

namespace FileTests.Test
{
    [Collection("VA0061B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0061B_Tests
    {
        [Fact]
        public static void VA0061B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.Clear();
                AppSettings.TestSet.IsTest = true;
                #region PARAMETERS
                #region VA0061B_CURSOR01

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "NUM_CERTIFICADO" , "2"},
                { "COD_MSG_CRITICA" , "2"},
            });
                q0.AddDynamic(new Dictionary<string, string>
            {
                {"NUM_CERTIFICADO", "4"},
                {"COD_MSG_CRITICA", "4"}
            });
                AppSettings.TestSet.DynamicData.Add("VA0061B_CURSOR01", q0);
                #endregion

                #region VA0061B_CURSOR02

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "NUM_CERTIFICADO" , ""},
                { "COD_MSG_CRITICA" , ""},
                { "SEQ_CRITICA" , ""},
                { "STA_CRITICA" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("VA0061B_CURSOR02", q1);

                #endregion

                #region R1600_00_PROCESSA_CURSOR01_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "ERRPROVI_NUM_CERTIFICADO" , ""},
                { "WS_COUNT" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R1600_00_PROCESSA_CURSOR01_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1700_00_LE_BUSCA_APOLICE_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "PROPSSVD_NUM_APOLICE" , ""},
                { "PROPSSVD_COD_SUBGRUPO" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOFID_COD_PESSOA" , ""},
                { "PROPOFID_NUM_SICOB" , ""},
                { "PROPOFID_OPCAO_COBER" , ""},
                { "PROPOFID_DATA_PROPOSTA" , ""},
                { "PROPOFID_DTQITBCO" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R1700_00_LE_BUSCA_APOLICE_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1750_VE_SE_ESTA_EM_CRITICA_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_SIT_REGISTRO" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R1750_VE_SE_ESTA_EM_CRITICA_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1755_00_SELECT_CLIENTES_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_DATA_NASCIMENTO" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("R1755_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1800_LE_TAB_PLANO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "PLAVAVGA_VLPREMIOTOT" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("R1800_LE_TAB_PLANO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1800_LE_TAB_PLANO_DB_SELECT_2_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R1800_LE_TAB_PLANO_DB_SELECT_2_Query1", q7);

                #endregion

                #region R2000_DELETA_ERROS_PROP_VDAZUL_DB_UPDATE_1_Update1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "ERRPROVI_NUM_CERTIFICADO" , "9"}
            });
                AppSettings.TestSet.DynamicData.Add("R2000_DELETA_ERROS_PROP_VDAZUL_DB_UPDATE_1_Update1", q8);

                #endregion

                #endregion
                var program = new VA0061B();
                program.Execute();
                //var envList = AppSettings.TestSet.DynamicData["VA0061B_CURSOR01"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R2000_DELETA_ERROS_PROP_VDAZUL_DB_UPDATE_1_Update1"].DynamicList;
                //Assert.True(envList[0].TryGetValue("COD_MSG_CRITICA", out var valOr) && valOr == "4");
                Assert.True(envList1[0].TryGetValue("ERRPROVI_NUM_CERTIFICADO", out var valOr) && valOr == "9");
            }
        }
    }
}