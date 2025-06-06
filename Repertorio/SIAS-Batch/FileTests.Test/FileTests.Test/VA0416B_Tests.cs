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
using static Code.VA0416B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]

    [Collection("VA0416B_Tests")]
    public class VA0416B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , ""},
                { "SISTEMA_CURRDATE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_DTREFER" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q1);

            #endregion

            #region VA0416B_CHISTCOB

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "V0HCOB_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0416B_CHISTCOB", q2);

            #endregion

            #region R2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_FONTE" , ""},
                { "V0PROP_CODPRODU" , ""},
                { "V0PROP_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_DIA_FATURA" , ""},
                { "V0PROP_ESTR_COBR" , ""},
                { "V0PROP_ORIG_PRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1", q3);

            #endregion

            #region R2100_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_PRMVG" , ""},
                { "V0PARC_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1", q4);

            #endregion

            #region R4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_OCORHIST" , ""},
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R4200_00_INSERT_V0HISTCONTA_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
                { "V0HCOB_OCORHIST" , ""},
                { "V0PROP_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_FONTE" , ""},
                { "V0HCTB_NRENDOS" , ""},
                { "V0PARC_PRMVG" , ""},
                { "V0PARC_PRMAP" , ""},
                { "V0HCOB_DTVENCTO" , ""},
                { "V0RELA_DTREFER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4200_00_INSERT_V0HISTCONTA_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R4300_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NRENDOS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4300_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1", q8);

            #endregion

            #region R4400_00_ATUALIZA_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , ""},
                { "V0HCOB_NRPARCEL" , ""},
                { "V0HCOB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4400_00_ATUALIZA_DB_UPDATE_1_Update1", q9);

            #endregion

            #endregion
        }

        [Fact]
        public static void VA0416B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();


                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , "2023-12-01" },
                { "SISTEMA_CURRDATE" , "2023-12-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_DTREFER" , "2023-11-30" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q1);

                #endregion

                #region VA0416B_CHISTCOB

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , "123456789" },
                { "V0HCOB_NRPARCEL" , "10" },
                { "V0HCOB_NRTIT" , "987654321" },
                { "V0HCOB_DTVENCTO" , "2023-12-15" },
                { "V0HCOB_OCORHIST" , "Pagamento recebido" },
            });
                AppSettings.TestSet.DynamicData.Remove("VA0416B_CHISTCOB");
                AppSettings.TestSet.DynamicData.Add("VA0416B_CHISTCOB", q2);

                #endregion

                #region R2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_FONTE" , "Sistema Interno" },
                { "V0PROP_CODPRODU" , "PROD001" },
                { "V0PROP_APOLICE" , "AP123456789" },
                { "V0PROP_CODSUBES" , "SUB001" },
                { "V0PROP_DIA_FATURA" , "15" },
                { "V0PROP_ESTR_COBR" , "Mensal" },
                { "V0PROP_ORIG_PRODU" , "ESPEC" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1", q3);

                #endregion

                #region R2100_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_PRMVG" , "500.00" },
                { "V0PARC_PRMAP" , "450.00" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1", q4);

                #endregion

                #region R4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("R4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1", q5);

                #endregion

                #region R4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_OCORHIST" , "Pagamento recebido" },
                { "V0HCOB_NRCERTIF" , "123456789" },
                { "V0HCOB_NRPARCEL" , "10" },
                { "V0HCOB_NRTIT" , "987654321" },
            });
                AppSettings.TestSet.DynamicData.Remove("R4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1", q6);

                #endregion

                #region R4200_00_INSERT_V0HISTCONTA_DB_INSERT_1_Insert1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , "123456789" },
                { "V0HCOB_NRPARCEL" , "10A" },
                { "V0HCOB_NRTIT" , "987654321" },
                { "V0HCOB_OCORHIST" , "Pagamento recebido" },
                { "V0PROP_APOLICE" , "AP123456789" },
                { "V0PROP_CODSUBES" , "SUB001" },
                { "V0PROP_FONTE" , "Sistema Interno" },
                { "V0HCTB_NRENDOS" , "1000" },
                { "V0PARC_PRMVG" , "500.00" },
                { "V0PARC_PRMAP" , "450.00" },
                { "V0HCOB_DTVENCTO" , "2023-12-15" },
                { "V0RELA_DTREFER" , "2023-11-30" },
            });
                AppSettings.TestSet.DynamicData.Remove("R4200_00_INSERT_V0HISTCONTA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R4200_00_INSERT_V0HISTCONTA_DB_INSERT_1_Insert1", q7);

                #endregion

                #region R4300_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NRENDOS" , "1000" }
            });
                AppSettings.TestSet.DynamicData.Remove("R4300_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4300_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1", q8);

                #endregion

                #region R4400_00_ATUALIZA_DB_UPDATE_1_Update1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , "123456789" },
                { "V0HCOB_NRPARCEL" , "10" },
                { "V0HCOB_NRTIT" , "987654321" },
            });
                AppSettings.TestSet.DynamicData.Remove("R4400_00_ATUALIZA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R4400_00_ATUALIZA_DB_UPDATE_1_Update1", q9);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute();
                var program = new VA0416B();
                program.Execute();

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);

                //"Inserts": 1,
                //"Updates": 3,
                //"Deletes": 0,
                //"Selects": 5,
                //"Cursors": 1,
                //"Procedures": 0,
                //"All": 10
            }
        }

        [Fact]
        public static void VA0416B_Tests_Return99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();


                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
    
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_DTREFER" , "2023-11-30" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q1);

                #endregion

                #region VA0416B_CHISTCOB

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , "123456789" },
                { "V0HCOB_NRPARCEL" , "10" },
                { "V0HCOB_NRTIT" , "987654321" },
                { "V0HCOB_DTVENCTO" , "2023-12-15" },
                { "V0HCOB_OCORHIST" , "Pagamento recebido" },
            });
                AppSettings.TestSet.DynamicData.Remove("VA0416B_CHISTCOB");
                AppSettings.TestSet.DynamicData.Add("VA0416B_CHISTCOB", q2);

                #endregion

                #region R2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_FONTE" , "Sistema Interno" },
                { "V0PROP_CODPRODU" , "PROD001" },
                { "V0PROP_APOLICE" , "AP123456789" },
                { "V0PROP_CODSUBES" , "SUB001" },
                { "V0PROP_DIA_FATURA" , "15" },
                { "V0PROP_ESTR_COBR" , "Mensal" },
                { "V0PROP_ORIG_PRODU" , "ESPEC" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1", q3);

                #endregion

                #region R2100_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0PARC_PRMVG" , "500.00" },
                { "V0PARC_PRMAP" , "450.00" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1", q4);

                #endregion

                #region R4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("R4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1", q5);

                #endregion

                #region R4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_OCORHIST" , "Pagamento recebido" },
                { "V0HCOB_NRCERTIF" , "123456789" },
                { "V0HCOB_NRPARCEL" , "10" },
                { "V0HCOB_NRTIT" , "987654321" },
            });
                AppSettings.TestSet.DynamicData.Remove("R4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1", q6);

                #endregion

                #region R4200_00_INSERT_V0HISTCONTA_DB_INSERT_1_Insert1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , "123456789" },
                { "V0HCOB_NRPARCEL" , "10" },
                { "V0HCOB_NRTIT" , "987654321" },
                { "V0HCOB_OCORHIST" , "Pagamento recebido" },
                { "V0PROP_APOLICE" , "AP123456789" },
                { "V0PROP_CODSUBES" , "SUB001" },
                { "V0PROP_FONTE" , "Sistema Interno" },
                { "V0HCTB_NRENDOS" , "1000" },
                { "V0PARC_PRMVG" , "500.00" },
                { "V0PARC_PRMAP" , "450.00" },
                { "V0HCOB_DTVENCTO" , "2023-12-15" },
                { "V0RELA_DTREFER" , "2023-11-30" },
            });
                AppSettings.TestSet.DynamicData.Remove("R4200_00_INSERT_V0HISTCONTA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R4200_00_INSERT_V0HISTCONTA_DB_INSERT_1_Insert1", q7);

                #endregion

                #region R4300_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V0HCTB_NRENDOS" , "1000" }
            });
                AppSettings.TestSet.DynamicData.Remove("R4300_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4300_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1", q8);

                #endregion

                #region R4400_00_ATUALIZA_DB_UPDATE_1_Update1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "V0HCOB_NRCERTIF" , "123456789" },
                { "V0HCOB_NRPARCEL" , "10" },
                { "V0HCOB_NRTIT" , "987654321" },
            });
                AppSettings.TestSet.DynamicData.Remove("R4400_00_ATUALIZA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R4400_00_ATUALIZA_DB_UPDATE_1_Update1", q9);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute();
                var program = new VA0416B();
                program.Execute();

                Assert.True(program.RETURN_CODE != 0);
            }
        }
    }
}