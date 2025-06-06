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
using static Code.VA1184B;

namespace FileTests.Test
{
    [Collection("VA1184B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA1184B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0000_PRINCIPAL_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , "2024-11-11"},
                { "SISTEMA_CURRENT" , "2024-11-11"},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_Query1", q0);

            #endregion

            #region VA1184B_CPROPVA

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATO_DTSOLICITACAO" , "2021-10-10"},
                { "RELATO_NUM_APOLICE" , "19790324"},
                { "RELATO_CODSUBES" , "12"},
                { "RELATO_NRCERTIF" , "10020100826"},
                { "RELATO_OPERACAO" , "799"},
                { "RELATO_PCT_AUMENTO" , "1.5"},
                { "RELATO_SITUACAO" , "0"},
            });
            AppSettings.TestSet.DynamicData.Add("VA1184B_CPROPVA", q1);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SEGURA_SIT_REGISTRO" , ""},
                { "SEGURA_FAIXA" , ""},
                { "SEGURA_LOT_EMP_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_Query1", q2);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_Query2

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MOVIME_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_Query2", q3);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_Query3

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , ""},
                { "PROPVA_OCORHIST" , ""},
                { "PROPVA_OPCAO_COBER" , ""},
                { "PROPVA_FONTE" , ""},
                { "PROPVA_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_Query3", q4);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_Query4

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PRODVG_ARQFDCAP" , ""},
                { "PRODVG_ESTRCOBR" , ""},
                { "PRODVG_COBERADIC" , ""},
                { "PRODVG_CUSTOCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_Query4", q5);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_Query5

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_Query5", q6);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_Query6

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_Query6", q7);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_Query7

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_PERIPGTO" , ""},
                { "OPCAOP_AGECTADEB" , ""},
                { "OPCAOP_OPRCTADEB" , ""},
                { "OPCAOP_NUMCTADEB" , ""},
                { "OPCAOP_DIGCTADEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_Query7", q8);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_Query8

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "COBERP_DTINIVIG" , ""},
                { "COBERP_DTINIVIG1DAY" , ""},
                { "COBERP_IMPMORNATU_ANT" , ""},
                { "COBERP_IMPMORACID_ANT" , ""},
                { "COBERP_IMPINVPERM_ANT" , ""},
                { "COBERP_IMPAMDS_ANT" , ""},
                { "COBERP_IMPDH_ANT" , ""},
                { "COBERP_IMPDIT_ANT" , ""},
                { "COBERP_VLPREMIO_ANT" , ""},
                { "COBERP_PRMVG_ANT" , ""},
                { "COBERP_PRMAP_ANT" , ""},
                { "COBERP_QTTITCAP" , ""},
                { "COBERP_VLTITCAP" , ""},
                { "COBERP_VLCUSTCAP" , ""},
                { "COBERP_IMPSEGCDG" , ""},
                { "COBERP_VLCUSTCDG" , ""},
                { "COBERP_IMPSEGAUXF" , ""},
                { "COBERP_VLCUSTAUXF" , ""},
                { "COBERP_PRMDIT_ANT" , ""},
                { "COBERP_QTDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_Query8", q9);

            #endregion

            #region M_0300_ATUALIZA_TABELAS_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "RELATO_DTSOLICITACAO" , ""},
                { "RELATO_NRCERTIF" , ""},
                { "PROPVA_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_ATUALIZA_TABELAS_Update1", q10);

            #endregion

            #region M_0300_ATUALIZA_TABELAS_Update2

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NRCERTIF" , ""},
                { "PROPVA_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_ATUALIZA_TABELAS_Update2", q11);

            #endregion

            #region M_0300_ATUALIZA_TABELAS_Update3

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "RELATO_DTSOLICITACAO" , ""},
                { "RELATO_OPERACAO" , ""},
                { "PROPVA_OCORHIST" , ""},
                { "RELATO_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_ATUALIZA_TABELAS_Update3", q12);

            #endregion

            #region M_0300_ATUALIZA_TABELAS_Insert4

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NRCERTIF" , ""},
                { "PROPVA_OCORHIST" , ""},
                { "RELATO_DTSOLICITACAO" , ""},
                { "COBERP_IMPMORNATU_ATU" , ""},
                { "RELATO_OPERACAO" , ""},
                { "PROPVA_OPCAO_COBER" , ""},
                { "COBERP_IMPMORACID_ATU" , ""},
                { "COBERP_IMPINVPERM_ATU" , ""},
                { "COBERP_IMPAMDS_ATU" , ""},
                { "COBERP_IMPDH_ATU" , ""},
                { "COBERP_IMPDIT_ATU" , ""},
                { "COBERP_VLPREMIO_ATU" , ""},
                { "COBERP_PRMVG_ATU" , ""},
                { "COBERP_PRMAP_ATU" , ""},
                { "COBERP_QTTITCAP" , ""},
                { "COBERP_VLTITCAP" , ""},
                { "COBERP_VLCUSTCAP" , ""},
                { "COBERP_IMPSEGCDG" , ""},
                { "COBERP_VLCUSTCDG" , ""},
                { "COBERP_IMPSEGAUXF" , ""},
                { "COBERP_VLCUSTAUXF" , ""},
                { "COBERP_PRMDIT_ANT" , ""},
                { "COBERP_QTDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_ATUALIZA_TABELAS_Insert4", q13);

            #endregion

            #region M_0300_ATUALIZA_TABELAS_Query5

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_ATUALIZA_TABELAS_Query5", q14);

            #endregion

            #region M_0300_PROPAUTOM_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "RELATO_NUM_APOLICE" , ""},
                { "RELATO_CODSUBES" , ""},
                { "PROPVA_FONTE" , ""},
                { "FONTE_PROPAUTOM" , ""},
                { "RELATO_NRCERTIF" , ""},
                { "PROPVA_CODCLIEN" , ""},
                { "SEGURA_FAIXA" , ""},
                { "OPCAOP_PERIPGTO" , ""},
                { "OPCAOP_AGECTADEB" , ""},
                { "MNUM_CTA_CORRENTE" , ""},
                { "MDAC_CTA_CORRENTE" , ""},
                { "COBERP_IMPMORNATU_ANT" , ""},
                { "COBERP_IMPMORNATU_ATU" , ""},
                { "COBERP_IMPMORACID_ANT" , ""},
                { "COBERP_IMPMORACID_ATU" , ""},
                { "COBERP_IMPINVPERM_ANT" , ""},
                { "COBERP_IMPINVPERM_ATU" , ""},
                { "COBERP_IMPAMDS_ANT" , ""},
                { "COBERP_IMPAMDS_ATU" , ""},
                { "COBERP_IMPDH_ANT" , ""},
                { "COBERP_IMPDH_ATU" , ""},
                { "COBERP_IMPDIT_ANT" , ""},
                { "COBERP_IMPDIT_ATU" , ""},
                { "COBERP_PRMVG_ANT" , ""},
                { "COBERP_PRMVG_ATU" , ""},
                { "COBERP_PRMAP_ANT" , ""},
                { "COBERP_PRMAP_ATU" , ""},
                { "RELATO_OPERACAO" , ""},
                { "SISTEMA_DTMOVABE" , ""},
                { "CLIENT_DTNASC" , ""},
                { "RELATO_DTSOLICITACAO" , ""},
                { "SEGURA_LOT_EMP_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_PROPAUTOM_Insert1", q15);

            #endregion

            #region M_0300_PROPAUTOM_Update2

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""},
                { "PROPVA_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_PROPAUTOM_Update2", q16);

            #endregion

            #region M_0300_PROPAUTOM_Update3

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_PROPAUTOM_Update3", q17);

            #endregion

            #endregion
        }

        [Fact]
        public static void VA1184B_Tests_Fact()
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
                #region M_0100_PROCESSA_PROPOSTA_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SEGURA_SIT_REGISTRO" , "1"},
                { "SEGURA_FAIXA" , "0"},
                { "SEGURA_LOT_EMP_SEGURADO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_Query1", q2);

                #endregion
                #region M_0100_PROCESSA_PROPOSTA_Query3

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_CODCLIEN" , "778899"},
                { "PROPVA_OCORHIST" , "1"},
                { "PROPVA_OPCAO_COBER" , "C"},
                { "PROPVA_FONTE" , "5"},
                { "PROPVA_SITUACAO" , "3"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_Query3");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_Query3", q4);

                #endregion
                #region M_0100_PROCESSA_PROPOSTA_Query4

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "PRODVG_ARQFDCAP" , "12"},
                { "PRODVG_ESTRCOBR" , ""},
                { "PRODVG_COBERADIC" , "N"},
                { "PRODVG_CUSTOCAP" , "N"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_Query4");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_Query4", q5);

                #endregion
                #region M_0100_PROCESSA_PROPOSTA_Query5

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , "1990-02-02"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_Query5");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_Query5", q6);

                #endregion

                #endregion
                var program = new VA1184B();
                program.Execute();

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);
                
                //M_0300_ATUALIZA_TABELAS_Update1
                var envList0 = AppSettings.TestSet.DynamicData["M_0300_ATUALIZA_TABELAS_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("RELATO_NRCERTIF", out var val0r) && val0r.Contains("000010020100826"));
                Assert.True(envList0[1].TryGetValue("RELATO_DTSOLICITACAO", out var val1r) && val1r.Contains("2021-10-10"));

                //M_0300_ATUALIZA_TABELAS_Update2
                var envList1 = AppSettings.TestSet.DynamicData["M_0300_ATUALIZA_TABELAS_Update2"].DynamicList;
                Assert.True(envList1[1].TryGetValue("RELATO_NRCERTIF", out var val2r) && val2r.Contains("000010020100826"));

                //M_0300_ATUALIZA_TABELAS_Update3
                var envList2 = AppSettings.TestSet.DynamicData["M_0300_ATUALIZA_TABELAS_Update3"].DynamicList;
                Assert.True(envList2[1].TryGetValue("RELATO_OPERACAO", out var val3r) && val3r.Contains("0799"));
                Assert.True(envList2[1].TryGetValue("RELATO_NRCERTIF", out var val4r) && val4r.Contains("000010020100826"));

                //M_0300_ATUALIZA_TABELAS_Insert4
                var envList3 = AppSettings.TestSet.DynamicData["M_0300_ATUALIZA_TABELAS_Insert4"].DynamicList;
                Assert.True(envList3[1].TryGetValue("RELATO_OPERACAO", out var val5r) && val5r.Contains("0799"));
                Assert.True(envList3[1].TryGetValue("RELATO_NRCERTIF", out var val6r) && val6r.Contains("000010020100826"));
                Assert.True(envList3[1].TryGetValue("PROPVA_OPCAO_COBER", out var val7r) && val7r.Contains("C"));
                
                Assert.True(envList3.Count > 1);

                //M_0300_PROPAUTOM_Insert1
                var envList4 = AppSettings.TestSet.DynamicData["M_0300_PROPAUTOM_Insert1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("RELATO_NUM_APOLICE", out var val8r) && val8r.Contains("0000019790324"));
                Assert.True(envList4[1].TryGetValue("PROPVA_CODCLIEN", out var val9r) && val9r.Contains("000778899"));
                Assert.True(envList4[1].TryGetValue("PROPVA_FONTE", out var val10r) && val10r.Contains("0005"));

                Assert.True(envList4.Count > 1);

                //M_0300_PROPAUTOM_Update2
                var envList5 = AppSettings.TestSet.DynamicData["M_0300_PROPAUTOM_Update2"].DynamicList;
                Assert.True(envList5[1].TryGetValue("PROPVA_FONTE", out var val11r) && val11r.Contains("0005"));

                //M_0300_PROPAUTOM_Update3
                var envList6 = AppSettings.TestSet.DynamicData["M_0300_PROPAUTOM_Update3"].DynamicList;
                Assert.True(envList6[1].TryGetValue("UpdateCheck", out var val12r) && val12r.Contains("UpdateCheck"));

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Fact]
        public static void VA1184B_Tests_Fact_ReturnCode_9()
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
                #region M_0100_PROCESSA_PROPOSTA_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SEGURA_SIT_REGISTRO" , ""},
                { "SEGURA_FAIXA" , ""},
                { "SEGURA_LOT_EMP_SEGURADO" , ""},
                },new SQLCA(999));
                AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_PROPOSTA_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_Query1", q2);

                #endregion


                #endregion
                var program = new VA1184B();
                program.Execute();
                Assert.True(program.RETURN_CODE == 9);
            }
        }
        [Fact]
        public static void VA1184B_Tests_Fact_SemDados_ReturnCode_9()
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
                #region VA1184B_CPROPVA

                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("VA1184B_CPROPVA");
                AppSettings.TestSet.DynamicData.Add("VA1184B_CPROPVA", q1);

                #endregion

                #endregion
                var program = new VA1184B();
                program.Execute();
                Assert.True(program.RETURN_CODE == 0);
                var envList = AppSettings.TestSet.DynamicData["VA1184B_CPROPVA"].DynamicList;
                Assert.True(envList.Count == 0);
            }
        }
    }
}