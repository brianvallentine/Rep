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
using static Code.SI0806B;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0806B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0806B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region SI0806B_V1RELATORIOS

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_CODRELAT" , ""},
                { "V1RELA_DATA_REFERE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0806B_V1RELATORIOS", q0);

            #endregion

            #region SI0806B_TRELSIN1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELSIN_APOL_SINI" , ""},
                { "RELSIN_DTMOVTO" , ""},
                { "RELSIN_OPERACAO" , ""},
                { "RELSIN_OCORHIST" , ""},
                { "RELSIN_FONTE" , ""},
                { "MEST_MOEDA_SINI" , ""},
                { "THIST_LIMCRR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0806B_TRELSIN1", q1);

            #endregion

            #region M_015_000_CABECALHOS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOM_EMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE" , ""},
                { "SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PARAM_RAMO_VGAPC" , ""},
                { "PARAM_RAMO_VG" , ""},
                { "PARAM_RAMO_AP" , ""},
                { "PARAM_RAMO_SAUDE" , ""},
                { "PARAM_RAMO_EDUCACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1", q4);

            #endregion

            #region SI0806B_TAPDCORR

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "APDCORR_NUM_APOL" , ""},
                { "APDCORR_CODCORR" , ""},
                { "APDCORR_DTINIVIG" , ""},
                { "APDCORR_DTTERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0806B_TAPDCORR", q5);

            #endregion

            #region M_210_000_LER_THISTSIN_E_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "THIST_APOL_SINI" , ""},
                { "THIST_VALPRI" , ""},
                { "THIST_DTMOVTO" , ""},
                { "THIST_NOMFAV" , ""},
                { "THIST_SITUACAO" , ""},
                { "THIST_TIPFAV" , ""},
                { "THIST_FONPAG" , ""},
                { "THIST_CODPSVI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_210_000_LER_THISTSIN_E_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_215_000_LER_V1FORNECEDOR_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1FORN_PCISS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_215_000_LER_V1FORNECEDOR_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_255_000_LER_THISTSIN_9030_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "THIST_VALPRI1" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_255_000_LER_THISTSIN_9030_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_300_000_LER_TMESTSIN_E_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "MEST_NUM_APOL" , ""},
                { "MEST_SINLID" , ""},
                { "MEST_NRENDOS" , ""},
                { "MEST_NRCERTIF" , ""},
                { "MEST_DIGCERT" , ""},
                { "MEST_IDTPSEGU" , ""},
                { "MEST_DATORR" , ""},
                { "MEST_CODSUBES" , ""},
                { "MEST_CODCAU" , ""},
                { "MEST_MOEDA_SINI" , ""},
                { "MEST_DATCMD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_300_000_LER_TMESTSIN_E_DB_SELECT_1_Query1", q9);

            #endregion

            #region M_310_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "GEFONTE_NOMEFTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_310_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1", q10);

            #endregion

            #region M_313_000_NOME_FONTE_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "GEFONTE_CIDADE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_313_000_NOME_FONTE_DB_SELECT_1_Query1", q11);

            #endregion

            #region M_330_000_LER_TAPOLICE_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "APOL_NOME" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_330_000_LER_TAPOLICE_DB_SELECT_1_Query1", q12);

            #endregion

            #region M_331_000_LER_SINIITEM_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V1SEGVG_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_331_000_LER_SINIITEM_DB_SELECT_1_Query1", q13);

            #endregion

            #region M_332_000_LER_SEGURAVG_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V1SEGVG_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_332_000_LER_SEGURAVG_DB_SELECT_1_Query1", q14);

            #endregion

            #region M_333_000_LER_APOLICE_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V1SEGVG_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_333_000_LER_APOLICE_DB_SELECT_1_Query1", q15);

            #endregion

            #region M_334_000_LER_CLIENTE_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V1CLI_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_334_000_LER_CLIENTE_DB_SELECT_1_Query1", q16);

            #endregion

            #region M_335_000_LER_TENDOSSO_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSO_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_335_000_LER_TENDOSSO_DB_SELECT_1_Query1", q17);

            #endregion

            #region M_345_000_LER_PRODUTOR_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_NOMPDT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_345_000_LER_PRODUTOR_DB_SELECT_1_Query1", q18);

            #endregion

            #region M_350_200_ACESSA_TGERAMO_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "GERAMO_NOMERAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_350_200_ACESSA_TGERAMO_DB_SELECT_1_Query1", q19);

            #endregion

            #region M_355_000_PESQ_TCAUSA_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "CAUSA_DESCAU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_355_000_PESQ_TCAUSA_DB_SELECT_1_Query1", q20);

            #endregion

            #region M_367_000_TEXTO_7_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "THIST_VALPRI_CEF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_367_000_TEXTO_7_DB_SELECT_1_Query1", q21);

            #endregion

            #region M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "GEUNIMO_VLCRUZAD" , ""},
                { "GEUNIMO_SIGLUNIM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1", q22);

            #endregion

            #region M_800_000_LER_PREMIO_IOF_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "THIST_VALPRI2" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_800_000_LER_PREMIO_IOF_DB_SELECT_1_Query1", q23);

            #endregion

            #region M_900_000_FINALIZA_DB_DELETE_1_Delete1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_900_000_FINALIZA_DB_DELETE_1_Delete1", q24);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0806B_OUTPUT_202503310000")]
        public static void SI0806B_Tests_Theory(string SI0806M1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0806M1_FILE_NAME_P = $"{SI0806M1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region SI0806B_V1RELATORIOS
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1RELA_CODRELAT" , ""},
                    { "V1RELA_DATA_REFERE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0806B_V1RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0806B_V1RELATORIOS", q0);

                #endregion

                #region SI0806B_TRELSIN1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "RELSIN_APOL_SINI" , ""},
                    { "RELSIN_DTMOVTO" , ""},
                    { "RELSIN_OPERACAO" , "1001"},
                    { "RELSIN_OCORHIST" , ""},
                    { "RELSIN_FONTE" , ""},
                    { "MEST_MOEDA_SINI" , ""},
                    { "THIST_LIMCRR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0806B_TRELSIN1");
                AppSettings.TestSet.DynamicData.Add("SI0806B_TRELSIN1", q1);

                #endregion

                #region M_015_000_CABECALHOS_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V1EMPRESA_NOM_EMP" , "CAIXA VIDA E SEGURIDADE SA"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_015_000_CABECALHOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q2);

                #endregion

                #region M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "SIST_DTMOVABE" , ""},
                    { "SIST_DTCURRENT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q3);

                #endregion

                #region M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "PARAM_RAMO_VGAPC" , ""},
                    { "PARAM_RAMO_VG" , ""},
                    { "PARAM_RAMO_AP" , ""},
                    { "PARAM_RAMO_SAUDE" , ""},
                    { "PARAM_RAMO_EDUCACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1", q4);

                #endregion

                #region SI0806B_TAPDCORR

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "APDCORR_NUM_APOL" , ""},
                    { "APDCORR_CODCORR" , ""},
                    { "APDCORR_DTINIVIG" , ""},
                    { "APDCORR_DTTERVIG" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0806B_TAPDCORR");
                AppSettings.TestSet.DynamicData.Add("SI0806B_TAPDCORR", q5);

                #endregion

                #region M_210_000_LER_THISTSIN_E_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "THIST_APOL_SINI" , ""},
                    { "THIST_VALPRI" , ""},
                    { "THIST_DTMOVTO" , ""},
                    { "THIST_NOMFAV" , ""},
                    { "THIST_SITUACAO" , "1"},
                    { "THIST_TIPFAV" , "7"},
                    { "THIST_FONPAG" , ""},
                    { "THIST_CODPSVI" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_210_000_LER_THISTSIN_E_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_210_000_LER_THISTSIN_E_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_215_000_LER_V1FORNECEDOR_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V1FORN_PCISS" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_215_000_LER_V1FORNECEDOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_215_000_LER_V1FORNECEDOR_DB_SELECT_1_Query1", q7);

                #endregion

                #region M_255_000_LER_THISTSIN_9030_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "THIST_VALPRI1" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_255_000_LER_THISTSIN_9030_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_255_000_LER_THISTSIN_9030_DB_SELECT_1_Query1", q8);

                #endregion

                #region M_300_000_LER_TMESTSIN_E_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "MEST_NUM_APOL" , ""},
                    { "MEST_SINLID" , ""},
                    { "MEST_NRENDOS" , ""},
                    { "MEST_NRCERTIF" , ""},
                    { "MEST_DIGCERT" , ""},
                    { "MEST_IDTPSEGU" , ""},
                    { "MEST_DATORR" , ""},
                    { "MEST_CODSUBES" , ""},
                    { "MEST_CODCAU" , ""},
                    { "MEST_MOEDA_SINI" , ""},
                    { "MEST_DATCMD" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_300_000_LER_TMESTSIN_E_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_300_000_LER_TMESTSIN_E_DB_SELECT_1_Query1", q9);

                #endregion

                #region M_310_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "GEFONTE_NOMEFTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_310_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_310_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1", q10);

                #endregion

                #region M_313_000_NOME_FONTE_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "GEFONTE_CIDADE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_313_000_NOME_FONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_313_000_NOME_FONTE_DB_SELECT_1_Query1", q11);

                #endregion

                #region M_330_000_LER_TAPOLICE_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "APOL_NOME" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_330_000_LER_TAPOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_330_000_LER_TAPOLICE_DB_SELECT_1_Query1", q12);

                #endregion

                #region M_331_000_LER_SINIITEM_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "V1SEGVG_CLIENTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_331_000_LER_SINIITEM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_331_000_LER_SINIITEM_DB_SELECT_1_Query1", q13);

                #endregion

                #region M_332_000_LER_SEGURAVG_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "V1SEGVG_CLIENTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_332_000_LER_SEGURAVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_332_000_LER_SEGURAVG_DB_SELECT_1_Query1", q14);

                #endregion

                #region M_333_000_LER_APOLICE_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "V1SEGVG_CLIENTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_333_000_LER_APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_333_000_LER_APOLICE_DB_SELECT_1_Query1", q15);

                #endregion

                #region M_334_000_LER_CLIENTE_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "V1CLI_NOME_RAZAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_334_000_LER_CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_334_000_LER_CLIENTE_DB_SELECT_1_Query1", q16);

                #endregion

                #region M_335_000_LER_TENDOSSO_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "ENDOSSO_FONTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_335_000_LER_TENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_335_000_LER_TENDOSSO_DB_SELECT_1_Query1", q17);

                #endregion

                #region M_345_000_LER_PRODUTOR_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "PRODUTOR_NOMPDT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_345_000_LER_PRODUTOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_345_000_LER_PRODUTOR_DB_SELECT_1_Query1", q18);

                #endregion

                #region M_350_200_ACESSA_TGERAMO_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "GERAMO_NOMERAMO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_350_200_ACESSA_TGERAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_350_200_ACESSA_TGERAMO_DB_SELECT_1_Query1", q19);

                #endregion

                #region M_355_000_PESQ_TCAUSA_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "CAUSA_DESCAU" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_355_000_PESQ_TCAUSA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_355_000_PESQ_TCAUSA_DB_SELECT_1_Query1", q20);

                #endregion

                #region M_367_000_TEXTO_7_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                    { "THIST_VALPRI_CEF" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_367_000_TEXTO_7_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_367_000_TEXTO_7_DB_SELECT_1_Query1", q21);

                #endregion

                #region M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                    { "GEUNIMO_VLCRUZAD" , ""},
                    { "GEUNIMO_SIGLUNIM" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1", q22);

                #endregion

                #region M_800_000_LER_PREMIO_IOF_DB_SELECT_1_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                    { "THIST_VALPRI2" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_800_000_LER_PREMIO_IOF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_800_000_LER_PREMIO_IOF_DB_SELECT_1_Query1", q23);

                #endregion

                #region M_900_000_FINALIZA_DB_DELETE_1_Delete1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("M_900_000_FINALIZA_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("M_900_000_FINALIZA_DB_DELETE_1_Delete1", q24);

                #endregion
                #endregion
                var program = new SI0806B();
                program.Execute(SI0806M1_FILE_NAME_P);

                Assert.True(File.Exists(program.SI0806M1.FilePath) && new FileInfo(program.SI0806M1.FilePath).Length > 0);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();

                Assert.True(selects.Count > (AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).Count() / 2));

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0806B_OUTPUT_202503310001")]
        public static void SI0806B_Tests_Theory_ReturnCode99(string SI0806M1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0806M1_FILE_NAME_P = $"{SI0806M1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region SI0806B_V1RELATORIOS
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1RELA_CODRELAT" , ""},
                    { "V1RELA_DATA_REFERE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0806B_V1RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("SI0806B_V1RELATORIOS", q0);

                #endregion

                #region SI0806B_TRELSIN1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "RELSIN_APOL_SINI" , ""},
                    { "RELSIN_DTMOVTO" , ""},
                    { "RELSIN_OPERACAO" , "1001"},
                    { "RELSIN_OCORHIST" , ""},
                    { "RELSIN_FONTE" , ""},
                    { "MEST_MOEDA_SINI" , ""},
                    { "THIST_LIMCRR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0806B_TRELSIN1");
                AppSettings.TestSet.DynamicData.Add("SI0806B_TRELSIN1", q1);

                #endregion

                #region M_015_000_CABECALHOS_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V1EMPRESA_NOM_EMP" , "CAIXA VIDA E SEGURIDADE SA"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_015_000_CABECALHOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q2);

                #endregion

                #region M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q3);

                #endregion
                #endregion
                var program = new SI0806B();
                program.Execute(SI0806M1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}