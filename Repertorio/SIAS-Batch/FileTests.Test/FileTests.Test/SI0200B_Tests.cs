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
using static Code.SI0200B;

namespace FileTests.Test
{
    [Collection("SI0200B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class SI0200B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_000_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_000_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_000_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_000_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1", q1);

            #endregion

            #region R0500_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_CODUSU" , ""},
                { "V0RELA_DT_SOLIC" , ""},
                { "V0RELA_IDSISTEM" , ""},
                { "V0RELA_CODRELAT" , ""},
                { "V0RELA_NRCOPIAS" , ""},
                { "V0RELA_QTDE" , ""},
                { "V0RELA_PERI_INIC" , ""},
                { "V0RELA_PERI_FINAL" , ""},
                { "V0RELA_DATA_REFER" , ""},
                { "V0RELA_MES_REFER" , ""},
                { "V0RELA_ANO_REFER" , ""},
                { "V0RELA_ORGAO" , ""},
                { "V0RELA_FONTE" , ""},
                { "V0RELA_CODPDT" , ""},
                { "V0RELA_RAMO" , ""},
                { "V0RELA_MODALID" , ""},
                { "V0RELA_CONGENER" , ""},
                { "V0RELA_NUM_APOL" , ""},
                { "V0RELA_NRENDOS" , ""},
                { "V0RELA_NRPARCEL" , ""},
                { "V0RELA_NRCERTIF" , ""},
                { "V0RELA_NRTIT" , ""},
                { "V0RELA_CODSUBES" , ""},
                { "V0RELA_OPERACAO" , ""},
                { "V0RELA_COD_PLANO" , ""},
                { "V0RELA_OCORHIST" , ""},
                { "V0RELA_APOL_LIDER" , ""},
                { "V0RELA_ENDS_LIDER" , ""},
                { "V0RELA_NRPARC_LID" , ""},
                { "V0RELA_NUM_SINIST" , ""},
                { "V0RELA_NSINI_LID" , ""},
                { "V0RELA_NUM_ORDEM" , ""},
                { "V0RELA_CODUNIMO" , ""},
                { "V0RELA_CORRECAO" , ""},
                { "V0RELA_SITUACAO" , ""},
                { "V0RELA_PRV_DEF" , ""},
                { "V0RELA_ANAL_RESU" , ""},
                { "V0RELA_COD_EMPR" , ""},
                { "V0RELA_PERI_RENOV" , ""},
                { "V0RELA_PCT_AUMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1", q2);

            #endregion

            #endregion
        }

        [Fact]
        public static void SI0200B_Tests_Fact()
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
                var program = new SI0200B();
                program.Execute();

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert") || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1 || x.Value.DynamicList.Count == 0);


                var envList = AppSettings.TestSet.DynamicData["M_000_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1"].DynamicList;
                Assert.Empty(envList);

                var envList1 = AppSettings.TestSet.DynamicData["R0500_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("V0RELA_CODUSU", out var valOr) && valOr == "SI0200B ");
                Assert.True(envList1[1].TryGetValue("V0RELA_CODRELAT", out var valSivpf) && valSivpf == "SI0822B ");

                Assert.True(true);
            }
        }

        [Fact]
        public static void SI0200B_Tests_FactSemDados()
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

                #region M_000_00_SELECT_V1SISTEMA_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_000_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new SI0200B();
                program.Execute();

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert") || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1 || x.Value.DynamicList.Count == 0);


                Assert.True(program.AREA_DE_WORK.WABEND.WSQLCODE == 100);
            }
        }
    }
}