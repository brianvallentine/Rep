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
using static Code.FC1112S;
using static Code.FC1112S.FC1112S_REGISTRO_LINKAFC;
using Sias.Outros.DB2.FC1112S;

namespace FileTests.Test
{
    [Collection("FC1112S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class FC1112S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WHOST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_SELECT_FC_ROT_ETAPA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "GE386_NOM_ROTINA" , ""},
                { "GE386_SEQ_ETAPA" , ""},
                { "GE386_DTH_INI_VIGENCIA" , ""},
                { "GE386_DTH_FIM_VIGENCIA" , ""},
                { "GE386_IND_TIPO_ETAPA" , ""},
                { "GE386_NOM_PROGRAMA" , ""},
                { "GE386_STA_ETAPA" , ""},
                { "GE386_QTD_EXEC_ETAPA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_FC_ROT_ETAPA_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0300_00_UPD_FC_EXC_ROT_ETP_DB_UPDATE_1_Update1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "GE387_QTD_REG_LIDOS" , ""},
                { "GE387_QTD_REG_PROCS" , ""},
                { "GE387_QTD_REG_GRAVD" , ""},
                { "GE387_QTD_REG_ALTER" , ""},
                { "GE387_QTD_REG_EXCLU" , ""},
                { "GE387_STA_EXECUCAO" , ""},
                { "GE387_DTH_INI_VIGENCIA" , ""},
                { "GE387_NOM_ROTINA" , ""},
                { "GE387_SEQ_ETAPA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_UPD_FC_EXC_ROT_ETP_DB_UPDATE_1_Update1", q2);

            #endregion

            #endregion
        }

        [Fact]
        public static void FC1112S_Tests_Fact()
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
                var program = new FC1112S();

                var param = new FC1112S_REGISTRO_LINKAFC() 
                { LKFC_PARM_INPUT = new FC1112S_LKFC_PARM_INPUT() 
                { 
                    LKFC_COD_SISTEM = new StringBasis(new PIC("X", "2", "X(002)."), @"teste"),
                    LKFC_NOM_ROTINA = new StringBasis(new PIC("X", "8", "X(008)."), @"teste"),
                    LKFC_NOM_PROGM = new StringBasis(new PIC("X", "8", "X(008)."), @"123"),
                    LKFC_STA_EXECUCAO = new StringBasis(new PIC("X", "1", "X(001)."), @"1")
                } };

                program.Execute(param);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                var envList = AppSettings.TestSet.DynamicData["R0300_00_UPD_FC_EXC_ROT_ETP_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("GE387_STA_EXECUCAO", out var valor) && valor == "1");

                Assert.True(program.REGISTRO_LINKAFC.LKFC_PARM_OUTPUT.LKFC_RETN_CODE == 0);
            }
        }
        [Fact]
        public static void FC1112S_Tests_Erro()
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
                var program = new FC1112S();

                var param = new FC1112S_REGISTRO_LINKAFC()
                {
                    LKFC_PARM_INPUT = new FC1112S_LKFC_PARM_INPUT()
                    {
                    }
                };

                program.Execute(param);

                Assert.True(program.REGISTRO_LINKAFC.LKFC_PARM_OUTPUT.LKFC_RETN_CODE == 99);
            }
        }
    }
}