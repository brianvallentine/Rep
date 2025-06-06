using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.VE0505B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("VE0505B_Tests")]
    public class VE0505B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0100_PROCESSA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "DTQITBCO" , ""},
                { "AGENCIA" , ""},
                { "NRTERMO" , ""},
                { "NRMATRVEN" , ""},
                { "PERI_PAGAMENTO" , ""},
                { "NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_DB_SELECT_1_Query1", q1);

            #endregion

            #region VE0505B_CCOMIS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0COMI_NUM_APOLICE" , ""},
                { "CODSUBES" , ""},
                { "TIPCOM" , ""},
                { "RAMO" , ""},
                { "VALBAS" , ""},
                { "VLCOMIS" , ""},
                { "FONTE" , ""},
                { "CODCLIEN" , ""},
                { "CODOPER" , ""},
                { "PCCOMCOR" , ""},
                { "V0COMI_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0505B_CCOMIS", q2);

            #endregion

            #region M_0100_PROCESSA_DB_SELECT_2_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_DB_SELECT_2_Query1", q3);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_RAMO_VGAPC" , ""},
                { "PARAMRAM_RAMO_VG" , ""},
                { "PARAMRAM_RAMO_AP" , ""},
                { "PARAMRAM_NUM_RAMO_PRSTMISTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q4);

            #endregion

            #region M_0200_APROPRIA_FUNDO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "VALBASVG" , ""},
                { "VALBASAP" , ""},
                { "VLCOMISVG" , ""},
                { "VLCOMISAP" , ""},
                { "PCCOMIND" , ""},
                { "PCCOMGER" , ""},
                { "PCCOMSUP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0200_APROPRIA_FUNDO_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_0200_APROPRIA_FUNDO_DB_DELETE_1_Delete1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_0200_APROPRIA_FUNDO_DB_DELETE_1_Delete1", q6);

            #endregion

            #region M_0300_GRAVA_FUNDO_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "COD_PRODUTO" , ""},
                { "NRTERMO" , ""},
                { "CODOPER" , ""},
                { "FONTE" , ""},
                { "AGENCIA" , ""},
                { "CODCLIEN" , ""},
                { "NRMATRVEN" , ""},
                { "VALBASVG" , ""},
                { "VALBASAP" , ""},
                { "VLCOMISVG" , ""},
                { "VLCOMISAP" , ""},
                { "DTQITBCO" , ""},
                { "PCCOMIND" , ""},
                { "PCCOMGER" , ""},
                { "PCCOMSUP" , ""},
                { "DTMOVABE" , ""},
                { "NUM_APOLICE" , ""},
                { "CODSUBES" , ""},
                { "V0COMI_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0300_GRAVA_FUNDO_DB_INSERT_1_Insert1", q7);

            #endregion

            #region M_0400_ATUALIZA_FUNDO_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0COMI_NRPARCEL" , ""},
                { "NUM_APOLICE" , ""},
                { "VLCOMISVG" , ""},
                { "VLCOMISAP" , ""},
                { "PCCOMIND" , ""},
                { "PCCOMGER" , ""},
                { "PCCOMSUP" , ""},
                { "CODSUBES" , ""},
                { "NRTERMO" , ""},
                { "CODOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0400_ATUALIZA_FUNDO_DB_UPDATE_1_Update1", q8);

            #endregion

            #endregion
        }

        [Fact]
        public static void VE0505B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                
                #region VARIAVEIS_TESTE

                #region PARAMETERS

    #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "DTMOVABE" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_0100_PROCESSA_DB_SELECT_1_Query1

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "DTQITBCO" , "2023-12-02" },
                { "AGENCIA" , "001" },
                { "NRTERMO" , "123456" },
                { "NRMATRVEN" , "78910" },
                { "PERI_PAGAMENTO" , "Mensal" },
                { "NUM_APOLICE" , "AP123456789" },
            });
            AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_DB_SELECT_1_Query1", q1);

                #endregion

                #region VE0505B_CCOMIS

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0COMI_NUM_APOLICE" , "AP123456789" },
                { "CODSUBES" , "Sub123" },
                { "TIPCOM" , "Direta" },
                { "RAMO" , "81" },
                { "VALBAS" , "100000" },
                { "VLCOMIS" , "5000" },
                { "FONTE" , "Sistema Interno" },
                { "CODCLIEN" , "CL123456" },
                { "CODOPER" , "OP78910" },
                { "PCCOMCOR" , "5" },
                { "V0COMI_NRPARCEL" , "1" },
            });
            AppSettings.TestSet.DynamicData.Remove("VE0505B_CCOMIS");
AppSettings.TestSet.DynamicData.Add("VE0505B_CCOMIS", q2);

                #endregion

                #region M_0100_PROCESSA_DB_SELECT_2_Query1

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "COD_PRODUTO" , "PRD321" }
            });
            AppSettings.TestSet.DynamicData.Remove("M_0100_PROCESSA_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_DB_SELECT_2_Query1", q3);

                #endregion

                #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_RAMO_VGAPC" , "81" },
                { "PARAMRAM_RAMO_VG" , "81" },
                { "PARAMRAM_RAMO_AP" , "81" },
                { "PARAMRAM_NUM_RAMO_PRSTMISTA" , "81" },
            });
            AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q4);

                #endregion

                #region M_0200_APROPRIA_FUNDO_DB_SELECT_1_Query1

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "VALBASVG" , "50000" },
                { "VALBASAP" , "50000" },
                { "VLCOMISVG" , "2500" },
                { "VLCOMISAP" , "2500" },
                { "PCCOMIND" , "2" },
                { "PCCOMGER" , "1" },
                { "PCCOMSUP" , "0.5" },
            });
            AppSettings.TestSet.DynamicData.Remove("M_0200_APROPRIA_FUNDO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("M_0200_APROPRIA_FUNDO_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_0200_APROPRIA_FUNDO_DB_DELETE_1_Delete1

    var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Remove("M_0200_APROPRIA_FUNDO_DB_DELETE_1_Delete1");
AppSettings.TestSet.DynamicData.Add("M_0200_APROPRIA_FUNDO_DB_DELETE_1_Delete1", q6);

                #endregion

                #region M_0300_GRAVA_FUNDO_DB_INSERT_1_Insert1

    var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "COD_PRODUTO" , "PRD321" },
                { "NRTERMO" , "123456" },
                { "CODOPER" , "OP78910" },
                { "FONTE" , "Sistema Interno" },
                { "AGENCIA" , "001" },
                { "CODCLIEN" , "CL123456" },
                { "NRMATRVEN" , "78910" },
                { "VALBASVG" , "50000" },
                { "VALBASAP" , "50000" },
                { "VLCOMISVG" , "2500" },
                { "VLCOMISAP" , "2500" },
                { "DTQITBCO" , "2023-12-02" },
                { "PCCOMIND" , "2" },
                { "PCCOMGER" , "1" },
                { "PCCOMSUP" , "0.5" },
                { "DTMOVABE" , "2023-12-01" },
                { "NUM_APOLICE" , "AP123456789" },
                { "CODSUBES" , "Sub123" },
                { "V0COMI_NRPARCEL" , "1" },
            });
            AppSettings.TestSet.DynamicData.Remove("M_0300_GRAVA_FUNDO_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("M_0300_GRAVA_FUNDO_DB_INSERT_1_Insert1", q7);

                #endregion

                #region M_0400_ATUALIZA_FUNDO_DB_UPDATE_1_Update1

    var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0COMI_NRPARCEL" , "1" },
                { "NUM_APOLICE" , "AP123456789" },
                { "VLCOMISVG" , "2500" },
                { "VLCOMISAP" , "2500" },
                { "PCCOMIND" , "2" },
                { "PCCOMGER" , "1" },
                { "PCCOMSUP" , "0.5" },
                { "CODSUBES" , "Sub123" },
                { "NRTERMO" , "123456" },
                { "CODOPER" , "OP78910" },
            });
            AppSettings.TestSet.DynamicData.Remove("M_0400_ATUALIZA_FUNDO_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("M_0400_ATUALIZA_FUNDO_DB_UPDATE_1_Update1", q8);

                #endregion

                #endregion

      #endregion
//para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute();
                var program = new VE0505B();
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
            }
        }


        [Fact]
        public static void VE0505B_Tests_Fact_Erro9()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "DTMOVABE" , "2023-12-01" }
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion
                var program = new VE0505B();
                program.Execute();
                Assert.True(program.RETURN_CODE == 9);
            }
        }
    }
}