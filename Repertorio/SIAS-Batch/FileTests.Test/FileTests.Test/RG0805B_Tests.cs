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
using static Code.RG0805B;

namespace FileTests.Test
{
    [Collection("RG0805B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class RG0805B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""},
                { "V0SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1", q1);

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
        public static void RG0805B_Tests_Fact()
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

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , "2020-01-01"},
                { "V0SIST_DTCURRENT" , "2020-01-02"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #endregion
                var program = new RG0805B();
                program.Execute();

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                #region R0500_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1   

                var envList1 = AppSettings.TestSet.DynamicData["R0500_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("V0RELA_CODUSU", out var V0RELA_CODUSU) && V0RELA_CODUSU == "RG0805B ");
                Assert.True(envList1[1].TryGetValue("V0RELA_DT_SOLIC", out var V0RELA_DT_SOLIC) && V0RELA_DT_SOLIC == "2020 01-31");
                Assert.True(envList1[1].TryGetValue("V0RELA_IDSISTEM", out var V0RELA_IDSISTEM) && V0RELA_IDSISTEM == "RG");
                Assert.True(envList1[1].TryGetValue("V0RELA_CODRELAT", out var V0RELA_CODRELAT) && V0RELA_CODRELAT == "RG0051B1");
                Assert.True(envList1[1].TryGetValue("V0RELA_NRCOPIAS", out var V0RELA_NRCOPIAS) && V0RELA_NRCOPIAS == "0000");
                Assert.True(envList1[1].TryGetValue("V0RELA_QTDE", out var V0RELA_QTDE) && V0RELA_QTDE == "0000");
                Assert.True(envList1[1].TryGetValue("V0RELA_PERI_INIC", out var V0RELA_PERI_INIC) && V0RELA_PERI_INIC == "2020 01-01");
                Assert.True(envList1[1].TryGetValue("V0RELA_PERI_FINAL", out var V0RELA_PERI_FINAL) && V0RELA_PERI_FINAL == "2020 01-31");
                Assert.True(envList1[1].TryGetValue("V0RELA_DATA_REFER", out var V0RELA_DATA_REFER) && V0RELA_DATA_REFER == "2020 01-31");
                Assert.True(envList1[1].TryGetValue("V0RELA_MES_REFER", out var V0RELA_MES_REFER) && V0RELA_MES_REFER == "0001");
                Assert.True(envList1[1].TryGetValue("V0RELA_ANO_REFER", out var V0RELA_ANO_REFER) && V0RELA_ANO_REFER == "2020");
                Assert.True(envList1[1].TryGetValue("V0RELA_ORGAO", out var V0RELA_ORGAO) && V0RELA_ORGAO == "0000");
                Assert.True(envList1[1].TryGetValue("V0RELA_FONTE", out var V0RELA_FONTE) && V0RELA_FONTE == "0000");
                Assert.True(envList1[1].TryGetValue("V0RELA_CODPDT", out var V0RELA_CODPDT) && V0RELA_CODPDT == "000000000");
                Assert.True(envList1[1].TryGetValue("V0RELA_RAMO", out var V0RELA_RAMO) && V0RELA_RAMO == "0000");
                Assert.True(envList1[1].TryGetValue("V0RELA_MODALID", out var V0RELA_MODALID) && V0RELA_MODALID == "0000");
                Assert.True(envList1[1].TryGetValue("V0RELA_CONGENER", out var V0RELA_CONGENER) && V0RELA_CONGENER == "0000");
                Assert.True(envList1[1].TryGetValue("V0RELA_NUM_APOL", out var V0RELA_NUM_APOL) && V0RELA_NUM_APOL == "0000000000000");
                Assert.True(envList1[1].TryGetValue("V0RELA_NRENDOS", out var V0RELA_NRENDOS) && V0RELA_NRENDOS == "000000000");
                Assert.True(envList1[1].TryGetValue("V0RELA_NRPARCEL", out var V0RELA_NRPARCEL) && V0RELA_NRPARCEL == "0000");
                Assert.True(envList1[1].TryGetValue("V0RELA_NRCERTIF", out var V0RELA_NRCERTIF) && V0RELA_NRCERTIF == "000000000000000");
                Assert.True(envList1[1].TryGetValue("V0RELA_NRTIT", out var V0RELA_NRTIT) && V0RELA_NRTIT == "0000000000000");
                Assert.True(envList1[1].TryGetValue("V0RELA_CODSUBES", out var V0RELA_CODSUBES) && V0RELA_CODSUBES == "0000");
                Assert.True(envList1[1].TryGetValue("V0RELA_OPERACAO", out var V0RELA_OPERACAO) && V0RELA_OPERACAO == "0000");
                Assert.True(envList1[1].TryGetValue("V0RELA_COD_PLANO", out var V0RELA_COD_PLANO) && V0RELA_COD_PLANO == "0000");
                Assert.True(envList1[1].TryGetValue("V0RELA_APOL_LIDER", out var V0RELA_APOL_LIDER) && V0RELA_APOL_LIDER == "               ");
                Assert.True(envList1[1].TryGetValue("V0RELA_ENDS_LIDER", out var V0RELA_ENDS_LIDER) && V0RELA_ENDS_LIDER == "               ");
                Assert.True(envList1[1].TryGetValue("V0RELA_NRPARC_LID", out var V0RELA_NRPARC_LID) && V0RELA_NRPARC_LID == "0000");
                Assert.True(envList1[1].TryGetValue("V0RELA_NUM_SINIST", out var V0RELA_NUM_SINIST) && V0RELA_NUM_SINIST == "0000000000000");
                Assert.True(envList1[1].TryGetValue("V0RELA_NSINI_LID", out var V0RELA_NSINI_LID) && V0RELA_NSINI_LID == "               ");
                Assert.True(envList1[1].TryGetValue("V0RELA_NUM_ORDEM", out var V0RELA_NUM_ORDEM) && V0RELA_NUM_ORDEM == "000000000000000");
                Assert.True(envList1[1].TryGetValue("V0RELA_CODUNIMO", out var V0RELA_CODUNIMO) && V0RELA_CODUNIMO == "0000");
                Assert.True(envList1[1].TryGetValue("V0RELA_CORRECAO", out var V0RELA_CORRECAO) && V0RELA_CORRECAO == " ");
                Assert.True(envList1[1].TryGetValue("V0RELA_SITUACAO", out var V0RELA_SITUACAO) && V0RELA_SITUACAO == "0");
                Assert.True(envList1[1].TryGetValue("V0RELA_PRV_DEF", out var V0RELA_PRV_DEF) && V0RELA_PRV_DEF == "D");
                Assert.True(envList1[1].TryGetValue("V0RELA_ANAL_RESU", out var V0RELA_ANAL_RESU) && V0RELA_ANAL_RESU == "A");
                Assert.True(envList1[1].TryGetValue("V0RELA_COD_EMPR", out var V0RELA_COD_EMPR) && V0RELA_COD_EMPR == "000000000");
                Assert.True(envList1[1].TryGetValue("V0RELA_PERI_RENOV", out var V0RELA_PERI_RENOV) && V0RELA_PERI_RENOV == "0000");
                Assert.True(envList1[1].TryGetValue("V0RELA_PCT_AUMENTO", out var V0RELA_PCT_AUMENTO) && V0RELA_PCT_AUMENTO == "000.00");

                #endregion

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void RG0805B_Tests99_Fact()
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

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #endregion
                var program = new RG0805B();
                program.Execute();         

                Assert.True(program.RETURN_CODE == 99);
            }
        }


    }
}