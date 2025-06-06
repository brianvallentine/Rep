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
using static Code.FC1111S;

namespace FileTests.Test
{
    [Collection("FC1111S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class FC1111S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"},
                { "WHOST_DTCURRENT" , "2024-01-01"},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0300_00_SELECT_GE_ROT_BATCH_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "GE385_NOM_ROTINA" , "NAME"},
                { "GE385_STA_ROTINA" , "0"},
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_SELECT_GE_ROT_BATCH_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0500_00_SELECT_GE_ROT_ETAPA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "GE386_NOM_ROTINA" , "JPFCD00 "},
                { "GE386_SEQ_ETAPA" , "1"},
                { "GE386_DTH_INI_VIGENCIA" , "2016-08-14 14:32:30.214"},
                { "GE386_IND_TIPO_ETAPA" , "0"},
                { "GE386_NOM_PROGRAMA" , "FC2009B "},
                { "GE386_STA_ETAPA" , "0"},
                { "GE386_QTD_EXEC_ETAPA" , "1694"},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_GE_ROT_ETAPA_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0700_00_SELECT_GE_EXC_ROT_ETP_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "GE387_NOM_ROTINA" , ""},
                { "GE387_SEQ_ETAPA" , ""},
                { "GE387_DTH_INI_VIGENCIA" , ""},
                { "GE387_NUM_EXEC_ETAPA" , ""},
                { "GE387_DTA_INI_MOVIMENTO" , ""},
                { "GE387_DTA_FIM_MOVIMENTO" , ""},
                { "GE387_STA_EXECUCAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_SELECT_GE_EXC_ROT_ETP_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0900_00_CRITICA_EXEC_ETP_POS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTD_ETP_POST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0900_00_CRITICA_EXEC_ETP_POS_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1100_00_SELECT_CALENDARIO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTMOVTO_I" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_CALENDARIO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1200_00_INS_GE_EXC_ROT_ETP_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "GE387_NOM_ROTINA" , ""},
                { "GE387_SEQ_ETAPA" , ""},
                { "GE387_DTH_INI_VIGENCIA" , ""},
                { "GE387_NUM_EXEC_ETAPA" , ""},
                { "GE387_QTD_REG_LIDOS" , ""},
                { "GE387_QTD_REG_PROCS" , ""},
                { "GE387_QTD_REG_GRAVD" , ""},
                { "GE387_QTD_REG_ALTER" , ""},
                { "GE387_QTD_REG_EXCLU" , ""},
                { "GE387_STA_EXECUCAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_INS_GE_EXC_ROT_ETP_DB_INSERT_1_Insert1", q6);

            #endregion

            #region R1300_00_UPD_GE_ROT_ETAPA_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "GE386_QTD_EXEC_ETAPA" , ""},
                { "GE386_DTH_INI_VIGENCIA" , ""},
                { "GE386_IND_TIPO_ETAPA" , ""},
                { "GE386_NOM_PROGRAMA" , ""},
                { "GE386_NOM_ROTINA" , ""},
                { "GE386_SEQ_ETAPA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_UPD_GE_ROT_ETAPA_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R1500_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "GE387_QTD_REG_LIDOS" , ""},
                { "GE387_QTD_REG_PROCS" , ""},
                { "GE387_QTD_REG_GRAVD" , ""},
                { "GE387_QTD_REG_ALTER" , ""},
                { "GE387_QTD_REG_EXCLU" , ""},
                { "GE387_STA_EXECUCAO" , ""},
                { "GE387_DTH_INI_VIGENCIA" , ""},
                { "GE387_NUM_EXEC_ETAPA" , ""},
                { "GE387_NOM_ROTINA" , ""},
                { "GE387_SEQ_ETAPA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R1700_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "GE387_DTA_FIM_MOVIMENTO" , ""},
                { "GE387_QTD_REG_LIDOS" , ""},
                { "GE387_QTD_REG_PROCS" , ""},
                { "GE387_QTD_REG_GRAVD" , ""},
                { "GE387_QTD_REG_ALTER" , ""},
                { "GE387_QTD_REG_EXCLU" , ""},
                { "GE387_STA_EXECUCAO" , ""},
                { "GE387_DTH_INI_VIGENCIA" , ""},
                { "GE387_NUM_EXEC_ETAPA" , ""},
                { "GE387_NOM_ROTINA" , ""},
                { "GE387_SEQ_ETAPA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1_Update1", q9);

            #endregion

            #endregion
        }

        [Fact]
        public static void FC1111S_Tests_Fact_Sucess_ReturnCode_0()
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
                var param = new FC1111S_REGISTRO_LINKAGE();
                param.LKFC_PARM_INPUT.LKFC_COD_SISTEM.Value = "teste";
                param.LKFC_PARM_INPUT.LKFC_NOM_ROTINA.Value = "rotina";
                param.LKFC_PARM_INPUT.LKFC_SEQ_ETAPA.Value = 1;
                param.LKFC_PARM_INPUT.LKFC_NOM_PROGM.Value = "FC2009B";
                param.LKFC_PARM_INPUT.LKFC_TIP_PROCS.Value = "P0";
                #endregion
                var program = new FC1111S();
                program.Execute(param);

                Assert.True(program.REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_RETN_CODE.Value == 0);
                Assert.True(program.REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_TIP_PROCS.Value == "P0");

                //R1200_00_INS_GE_EXC_ROT_ETP_DB_INSERT_1_Insert1
                var envList0 = AppSettings.TestSet.DynamicData["R1200_00_INS_GE_EXC_ROT_ETP_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("GE387_STA_EXECUCAO", out var val0r) && val0r.Contains("1"));
                Assert.True(envList0.Count > 1);

                //R1300_00_UPD_GE_ROT_ETAPA_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["R1300_00_UPD_GE_ROT_ETAPA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("GE386_NOM_PROGRAMA", out var val1r) && val1r.Contains("FC2009B"));



            }
        }
        [Fact]
        public static void FC1111S_Tests_Fact_InvalidType_ReturnCode_99()
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
                var param = new FC1111S_REGISTRO_LINKAGE();
                param.LKFC_PARM_INPUT.LKFC_COD_SISTEM.Value = "teste";
                param.LKFC_PARM_INPUT.LKFC_NOM_ROTINA.Value = "rotina";
                param.LKFC_PARM_INPUT.LKFC_SEQ_ETAPA.Value = 1;
                param.LKFC_PARM_INPUT.LKFC_NOM_PROGM.Value = "FC2009B";
                param.LKFC_PARM_INPUT.LKFC_TIP_PROCS.Value = "X0";
                #endregion
                var program = new FC1111S();
                program.Execute(param);

                Assert.True(program.REGISTRO_LINKAGE.LKFC_PARM_OUTPUT.LKFC_RETN_CODE.Value == 99);
                Assert.True(program.REGISTRO_LINKAGE.LKFC_PARM_INPUT.LKFC_TIP_PROCS.Value == "X0");
            }
        }
    }
}