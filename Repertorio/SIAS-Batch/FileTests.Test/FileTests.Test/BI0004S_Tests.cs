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
using static Code.BI0004S;

namespace FileTests.Test
{
    [Collection("BI0004S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI0004S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_30000_00_PESSOA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_PES_004" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_30000_00_PESSOA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_50000_00_PRODUTO_SIGPF_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , ""},
                { "PRDSIVPF_COD_RELAC" , ""},
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_50000_00_PRODUTO_SIGPF_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_70000_00_RELAC_TIP_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "COD_RELAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_70000_00_RELAC_TIP_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_90000_00_INS_RELAC_TIP_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_PES_004" , ""},
                { "PRDSIVPF_COD_RELAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_90000_00_INS_RELAC_TIP_DB_INSERT_1_Insert1", q3);

            #endregion

            #region B0000_INS_RELAC_IDE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_NUM_IDE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("B0000_INS_RELAC_IDE_DB_SELECT_1_Query1", q4);

            #endregion

            #region B0000_INS_RELAC_IDE_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "BI0004L_S_COD_IDE" , ""},
                { "WS_COD_PES_004" , ""},
                { "PRDSIVPF_COD_RELAC" , ""},
                { "BI0004L_E_COD_USU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B0000_INS_RELAC_IDE_DB_INSERT_1_Insert1", q5);

            #endregion

            #endregion
        }

        [Fact]
        public static void BI0004S_Tests_Fact_Erro999()
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

                #region M_50000_00_PRODUTO_SIGPF_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                });
                AppSettings.TestSet.DynamicData.Remove("M_50000_00_PRODUTO_SIGPF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_50000_00_PRODUTO_SIGPF_DB_SELECT_1_Query1", q1);

                #endregion

                #endregion
                var program = new BI0004S();
                var parm = new BI0004S_BI0004L_LINKAGE();
                parm.BI0004L_E_PESSOA.BI0004L_E_COD_PES.Value = 1;
                parm.BI0004L_E_PESSOA.BI0004L_E_COD_PRD_SIG.Value = 1;
                parm.BI0004L_E_PESSOA.BI0004L_E_DAT_SIS.Value = "2020-02-02";
                parm.BI0004L_E_PESSOA.BI0004L_E_COD_USU.Value = "BI0003S";

                program.Execute(parm);

                Assert.True(program.BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_ERR == 999);
            }
        }

        [Fact]
        public static void BI0004S_Tests_Fact()
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

                #region M_70000_00_RELAC_TIP_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "COD_RELAC" , ""},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("M_70000_00_RELAC_TIP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_70000_00_RELAC_TIP_DB_SELECT_1_Query1", q2);

                #endregion

                #endregion
                var program = new BI0004S();
                var parm = new BI0004S_BI0004L_LINKAGE();
                parm.BI0004L_E_PESSOA.BI0004L_E_COD_PES.Value = 1;
                parm.BI0004L_E_PESSOA.BI0004L_E_COD_PRD_SIG.Value = 1;
                parm.BI0004L_E_PESSOA.BI0004L_E_DAT_SIS.Value = "2020-02-02";
                parm.BI0004L_E_PESSOA.BI0004L_E_COD_USU.Value = "BI0003S";

                program.Execute(parm);

                //M_90000_00_INS_RELAC_TIP_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["M_90000_00_INS_RELAC_TIP_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList[1].TryGetValue("PRDSIVPF_COD_RELAC", out var valor) && valor.Contains("0"));
                Assert.True(envList.Count > 1);

                //B0000_INS_RELAC_IDE_DB_INSERT_1_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["B0000_INS_RELAC_IDE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("BI0004L_E_COD_USU", out var valor2) && valor2.Contains("BI0003S"));
                Assert.True(envList2.Count > 1);

                Assert.True(program.BI0004L_LINKAGE.BI0004L_SAIDA.BI0004L_S_COD_ERR == 0);
            }
        }
    }
}