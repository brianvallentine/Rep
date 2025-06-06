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
using static Code.SI0104B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0104B_Tests")]
    public class SI0104B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOME_EMPRESA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""},
                { "V1SISTEMA_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI0104B_RELATORIOS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1RELATORIOS_DATA1" , ""},
                { "V1RELATORIOS_DATA2" , ""},
                { "V1RELATORIOS_APOLICE1" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0104B_RELATORIOS", q2);

            #endregion

            #region SI0104B_HISTMEST

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1HISTMEST_NUM_SINISTRO" , ""},
                { "V1HISTMEST_NUM_APOLICE" , ""},
                { "V1HISTMEST_PROTSINI" , ""},
                { "V1HISTMEST_SDOPAGBT" , ""},
                { "V1HISTMEST_CODSUBES" , ""},
                { "V1HISTMEST_NRCERTIF" , ""},
                { "V1HISTMEST_IDTPSEGU" , ""},
                { "V1HISTMEST_MODALIDA" , ""},
                { "V1HISTMEST_SIGLUNIM" , ""},
                { "V1HISTMEST_VLCRUZAD" , ""},
                { "V1HISTMEST_DTMOVTO" , ""},
                { "V1HISTMEST_FONTE" , ""},
                { "V1HISTMEST_RAMO" , ""},
                { "V1HISTMEST_NOME" , ""},
                { "V1HISTMEST_DAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0104B_HISTMEST", q3);

            #endregion

            #region M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1PARAMRAMO_RAMO_VG" , ""},
                { "V1PARAMRAMO_RAMO_AP" , ""},
                { "V1PARAMRAMO_RAMO_VGAPC" , ""},
                { "V1PARAMRAMO_RAMO_SAUDE" , ""},
                { "V1PARAMRAMO_RAMO_EDUCACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_000_700_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_000_700_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1", q5);

            #endregion

            #region M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1RAMO_NOMERAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1FONTE_NOMEFTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1CLIENTE_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1CLIENTE_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1", q9);

            #endregion

            #region M_500_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1CLIENTE_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_500_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1", q10);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0104B_t1")]
        public static void SI0104B_Tests_OK(string SI0104M1_FILE_NAME_P)
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

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOME_EMPRESA" , "0"}});
                AppSettings.TestSet.DynamicData.Remove("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1", q0);


                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                        { "V1SISTEMA_DTMOVABE" , "2025-01-01"},
                        { "V1SISTEMA_DTCURRENT" , "2025-04-02"},});
                AppSettings.TestSet.DynamicData.Remove("M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q1);


                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1RELATORIOS_DATA1" , "2025-01-01"},
                { "V1RELATORIOS_DATA2" , "2025-01-01"},
                { "V1RELATORIOS_APOLICE1" , "1"},});
                AppSettings.TestSet.DynamicData.Remove("M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1", q2);

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1HISTMEST_NUM_SINISTRO" , ""},
                { "V1HISTMEST_NUM_APOLICE" , ""},
                { "V1HISTMEST_PROTSINI" , ""},
                { "V1HISTMEST_SDOPAGBT" , ""},
                { "V1HISTMEST_CODSUBES" , ""},
                { "V1HISTMEST_NRCERTIF" , ""},
                { "V1HISTMEST_IDTPSEGU" , ""},
                { "V1HISTMEST_MODALIDA" , ""},
                { "V1HISTMEST_SIGLUNIM" , ""},
                { "V1HISTMEST_VLCRUZAD" , ""},
                { "V1HISTMEST_DTMOVTO" , ""},
                { "V1HISTMEST_FONTE" , ""},
                { "V1HISTMEST_RAMO" , ""},
                { "V1HISTMEST_NOME" , ""},
                { "V1HISTMEST_DAC" , ""},});
                AppSettings.TestSet.DynamicData.Remove("M_000_700_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("M_000_700_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1", q3);


                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1PARAMRAMO_RAMO_VG" , ""},
                { "V1PARAMRAMO_RAMO_AP" , ""},
                { "V1PARAMRAMO_RAMO_VGAPC" , ""},
                { "V1PARAMRAMO_RAMO_SAUDE" , ""},
                { "V1PARAMRAMO_RAMO_EDUCACAO" , ""},});
                AppSettings.TestSet.DynamicData.Remove("M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1", q4);

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , ""}});
                AppSettings.TestSet.DynamicData.Remove("M_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1", q5);


                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1RAMO_NOMERAMO" , ""}});
                AppSettings.TestSet.DynamicData.Remove("M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1", q6);


                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V1FONTE_NOMEFTE" , ""}});
                AppSettings.TestSet.DynamicData.Remove("M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1", q7);


                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V1CLIENTE_NOME_RAZAO" , ""}});
                AppSettings.TestSet.DynamicData.Remove("M_500_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_500_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1", q8);


                #endregion
                var program = new SI0104B();

                program.Execute(SI0104M1_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("SI0104B_t2")]
        public static void SI0104B_Tests_Return99(string SI0104M1_FILE_NAME_P)
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

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_100_SELECT_V1EMPRESA_DB_SELECT_1_Query1", q0);


                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                        { "V1SISTEMA_DTMOVABE" , "2026-01-27"},
                        { "V1SISTEMA_DTCURRENT" , "2025-04-01"},});
                AppSettings.TestSet.DynamicData.Remove("M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_200_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q1);


                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1RELATORIOS_DATA1" , "2025-01-01"},
                { "V1RELATORIOS_DATA2" , "2026-01-01"},
                { "V1RELATORIOS_APOLICE1" , "99999"},});
                AppSettings.TestSet.DynamicData.Remove("M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1", q2);

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1HISTMEST_NUM_SINISTRO" , "999"},
                { "V1HISTMEST_NUM_APOLICE" , "999"},
                { "V1HISTMEST_PROTSINI" , "1"},
                { "V1HISTMEST_SDOPAGBT" , "1"},
                { "V1HISTMEST_CODSUBES" , "1"},
                { "V1HISTMEST_NRCERTIF" , "1"},
                { "V1HISTMEST_IDTPSEGU" , "1"},
                { "V1HISTMEST_MODALIDA" , "1"},
                { "V1HISTMEST_SIGLUNIM" , "1"},
                { "V1HISTMEST_VLCRUZAD" , "1"},
                { "V1HISTMEST_DTMOVTO" , "1"},
                { "V1HISTMEST_FONTE" , "1"},
                { "V1HISTMEST_RAMO" , "1"},
                { "V1HISTMEST_NOME" , "1"},
                { "V1HISTMEST_DAC" , "1"},});
                AppSettings.TestSet.DynamicData.Remove("M_000_700_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("M_000_700_UPDATE_V1RELATORIOS_DB_DELETE_1_Delete1", q3);


                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1PARAMRAMO_RAMO_VG" , "999"},
                { "V1PARAMRAMO_RAMO_AP" , "999"},
                { "V1PARAMRAMO_RAMO_VGAPC" , "1"},
                { "V1PARAMRAMO_RAMO_SAUDE" , "1"},
                { "V1PARAMRAMO_RAMO_EDUCACAO" , "1"},});
                AppSettings.TestSet.DynamicData.Remove("M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1", q4);

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V1SISTEMA_DTMOVABE" , "2026-01-01"}});
                AppSettings.TestSet.DynamicData.Remove("M_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_300_100_SELECT_V1FONTE_DB_SELECT_1_Query1", q5);


                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1RAMO_NOMERAMO" , "0"}});
                AppSettings.TestSet.DynamicData.Remove("M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1", q6);


                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "V1FONTE_NOMEFTE" , "0"}});
                AppSettings.TestSet.DynamicData.Remove("M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1", q7);


                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V1CLIENTE_NOME_RAZAO" , "0"}});
                AppSettings.TestSet.DynamicData.Remove("M_500_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_500_300_SELECT_V1CLIENTE3_DB_SELECT_1_Query1", q8);


                #endregion
                var program = new SI0104B();

                program.Execute(SI0104M1_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("update") || x.Key.Contains("insert") || x.Key.Contains("delete")) && x.Value.DynamicList.Count() > 1);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}