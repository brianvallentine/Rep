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
using static Code.SI0112B;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0112B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0112B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_015_000_CABECALHOS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_MNUEMP" , ""},
                { "V1EMPRESA_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q0);

            #endregion

            #region SI0112B_TRELSIN

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1RELA_NUMSINI" , ""},
                { "V1RELA_CONGE" , ""},
                { "V1RELA_OPERACAO" , ""},
                { "V1RELA_OCORHIST" , ""},
                { "V1RELA_DTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0112B_TRELSIN", q1);

            #endregion

            #region SI0112B_TAPOCOS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "APCOSSC_PCPARTIC" , ""},
                { "APCOSSC_DTINIVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0112B_TAPOCOS", q2);

            #endregion

            #region M_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1CONGE_NOMECONG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_180_000_LER_V1HISTSINI_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "THIST_OPERACAO" , ""},
                { "THIST_OCORHIST" , ""},
                { "THIST_NOMFAV" , ""},
                { "THIST_DTMOVTO" , ""},
                { "THIST_VAL_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_180_000_LER_V1HISTSINI_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_210_000_LER_V1MESTSINI_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "MEST_NUM_APOL" , ""},
                { "MEST_NRENDOS" , ""},
                { "MEST_APOL_SINI" , ""},
                { "MEST_DATCMD" , ""},
                { "MEST_DATORR" , ""},
                { "MEST_NRCERTIF" , ""},
                { "MEST_MOEDA_SINI" , ""},
                { "MEST_IDTPSEGU" , ""},
                { "MEST_NUMIRB" , ""},
                { "MEST_CODSUBES" , ""},
                { "MEST_NREMBARQ" , ""},
                { "MEST_REFEMBQ" , ""},
                { "MEST_VALSEGBT" , ""},
                { "MEST_PCPARTIC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_210_000_LER_V1MESTSINI_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "APOL_NOME" , ""},
                { "APOL_MODALIDA" , ""},
                { "APOL_CODCLIEN" , ""},
                { "APOL_PODPUBL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "ENDOS_DTINIVIG" , ""},
                { "ENDOS_DTTERVIG" , ""},
                { "ENDOS_CORRECAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_300_000_LER_V1RAMO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1RAMO_NOMERAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_300_000_LER_V1RAMO_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "ORDEM_NRORDEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1", q9);

            #endregion

            #region M_370_000_LER_V1MOEDA_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZAD" , ""},
                { "MOEDA_SIGLUNIM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_370_000_LER_V1MOEDA_DB_SELECT_1_Query1", q10);

            #endregion

            #region M_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "APITE_DESCRITEM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1", q11);

            #endregion

            #region M_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "SEGVG_COD_CLIENTE" , ""},
                { "SEGVG_DTNASCIM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1", q12);

            #endregion

            #region M_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "CLIEN_NOME" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1", q13);

            #endregion

            #region M_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V1COND_GARAN_IEA" , ""},
                { "V1COND_GARAN_IPA" , ""},
                { "V1COND_GARAN_IPD" , ""},
                { "V1COND_GARAN_HD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1", q14);

            #endregion

            #region M_800_000_ATUALIZA_V0RELATORIOS_DB_DELETE_1_Delete1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_800_000_ATUALIZA_V0RELATORIOS_DB_DELETE_1_Delete1", q15);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0112B_OUTPUT_202504020000")]
        public static void SI0112B_Tests_Theory(string SI0112M1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0112M1_FILE_NAME_P = $"{SI0112M1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region M_015_000_CABECALHOS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1EMPRESA_MNUEMP" , "CAIXA VIDA E SEGURIDADE SA"},
                    { "V1EMPRESA_DTCURRENT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_015_000_CABECALHOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0112B_TRELSIN

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V1RELA_NUMSINI" , "1"},
                    { "V1RELA_CONGE" , "1"},
                    { "V1RELA_OPERACAO" , ""},
                    { "V1RELA_OCORHIST" , ""},
                    { "V1RELA_DTMOVTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0112B_TRELSIN");
                AppSettings.TestSet.DynamicData.Add("SI0112B_TRELSIN", q1);

                #endregion

                #region SI0112B_TAPOCOS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "APCOSSC_PCPARTIC" , ""},
                    { "APCOSSC_DTINIVIG" , ""},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                    { "APCOSSC_PCPARTIC" , ""},
                    { "APCOSSC_DTINIVIG" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0112B_TAPOCOS");
                AppSettings.TestSet.DynamicData.Add("SI0112B_TAPOCOS", q2);

                #endregion

                #region M_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V1CONGE_NOMECONG" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1", q3);

                #endregion

                #region M_180_000_LER_V1HISTSINI_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "THIST_OPERACAO" , "101"},
                    { "THIST_OCORHIST" , ""},
                    { "THIST_NOMFAV" , ""},
                    { "THIST_DTMOVTO" , ""},
                    { "THIST_VAL_OPERACAO" , "100"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_180_000_LER_V1HISTSINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_180_000_LER_V1HISTSINI_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_210_000_LER_V1MESTSINI_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "MEST_NUM_APOL" , ""},
                    { "MEST_NRENDOS" , ""},
                    { "MEST_APOL_SINI" , ""},
                    { "MEST_DATCMD" , ""},
                    { "MEST_DATORR" , ""},
                    { "MEST_NRCERTIF" , ""},
                    { "MEST_MOEDA_SINI" , ""},
                    { "MEST_IDTPSEGU" , ""},
                    { "MEST_NUMIRB" , ""},
                    { "MEST_CODSUBES" , ""},
                    { "MEST_NREMBARQ" , ""},
                    { "MEST_REFEMBQ" , ""},
                    { "MEST_VALSEGBT" , ""},
                    { "MEST_PCPARTIC" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_210_000_LER_V1MESTSINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_210_000_LER_V1MESTSINI_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "APOL_NOME" , ""},
                    { "APOL_MODALIDA" , ""},
                    { "APOL_CODCLIEN" , ""},
                    { "APOL_PODPUBL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "ENDOS_DTINIVIG" , ""},
                    { "ENDOS_DTTERVIG" , ""},
                    { "ENDOS_CORRECAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1", q7);

                #endregion

                #region M_300_000_LER_V1RAMO_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V1RAMO_NOMERAMO" , ""}
                });
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V1RAMO_NOMERAMO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_300_000_LER_V1RAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_300_000_LER_V1RAMO_DB_SELECT_1_Query1", q8);

                #endregion

                #region M_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "ORDEM_NRORDEM" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1", q9);

                #endregion

                #region M_370_000_LER_V1MOEDA_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "MOEDA_VLCRUZAD" , "20"},
                    { "MOEDA_SIGLUNIM" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_370_000_LER_V1MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_370_000_LER_V1MOEDA_DB_SELECT_1_Query1", q10);

                #endregion

                #region M_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "APITE_DESCRITEM" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1", q11);

                #endregion

                #region M_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "SEGVG_COD_CLIENTE" , ""},
                    { "SEGVG_DTNASCIM" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1", q12);

                #endregion

                #region M_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "CLIEN_NOME" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1", q13);

                #endregion

                #region M_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "V1COND_GARAN_IEA" , ""},
                    { "V1COND_GARAN_IPA" , ""},
                    { "V1COND_GARAN_IPD" , ""},
                    { "V1COND_GARAN_HD" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1", q14);

                #endregion

                #region M_800_000_ATUALIZA_V0RELATORIOS_DB_DELETE_1_Delete1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("M_800_000_ATUALIZA_V0RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("M_800_000_ATUALIZA_V0RELATORIOS_DB_DELETE_1_Delete1", q15);

                #endregion

                #endregion
                #endregion
                var program = new SI0112B();
                program.Execute(SI0112M1_FILE_NAME_P);

                Assert.True(File.Exists(program.SI0112M1.FilePath));
                Assert.True(new FileInfo(program.SI0112M1.FilePath).Length > 0);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();

                var delete = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE") && x.Value.DynamicList.Count == 0).ToList();

                Assert.True(selects.Count > (allSelects.Count / 2));

                Assert.True(delete.Count > 0);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0112B_OUTPUT_202504020001")]
        public static void SI0112B_Tests_Theory_ReturnCode99(string SI0112M1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SI0112M1_FILE_NAME_P = $"{SI0112M1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region M_015_000_CABECALHOS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1EMPRESA_MNUEMP" , "CAIXA VIDA E SEGURIDADE SA"},
                    { "V1EMPRESA_DTCURRENT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_015_000_CABECALHOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0112B_TRELSIN

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V1RELA_NUMSINI" , "1"},
                    { "V1RELA_CONGE" , "1"},
                    { "V1RELA_OPERACAO" , ""},
                    { "V1RELA_OCORHIST" , ""},
                    { "V1RELA_DTMOVTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0112B_TRELSIN");
                AppSettings.TestSet.DynamicData.Add("SI0112B_TRELSIN", q1);

                #endregion

                #region SI0112B_TAPOCOS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "APCOSSC_PCPARTIC" , ""},
                    { "APCOSSC_DTINIVIG" , ""},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                    { "APCOSSC_PCPARTIC" , ""},
                    { "APCOSSC_DTINIVIG" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0112B_TAPOCOS");
                AppSettings.TestSet.DynamicData.Add("SI0112B_TAPOCOS", q2);

                #endregion

                #region M_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V1CONGE_NOMECONG" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1", q3);

                #endregion

                #region M_180_000_LER_V1HISTSINI_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "THIST_OPERACAO" , "101"},
                    { "THIST_OCORHIST" , ""},
                    { "THIST_NOMFAV" , ""},
                    { "THIST_DTMOVTO" , ""},
                    { "THIST_VAL_OPERACAO" , "100"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_180_000_LER_V1HISTSINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_180_000_LER_V1HISTSINI_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_210_000_LER_V1MESTSINI_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_210_000_LER_V1MESTSINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_210_000_LER_V1MESTSINI_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "APOL_NOME" , ""},
                    { "APOL_MODALIDA" , ""},
                    { "APOL_CODCLIEN" , ""},
                    { "APOL_PODPUBL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "ENDOS_DTINIVIG" , ""},
                    { "ENDOS_DTTERVIG" , ""},
                    { "ENDOS_CORRECAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1", q7);

                #endregion

                #region M_300_000_LER_V1RAMO_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V1RAMO_NOMERAMO" , ""}
                });
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V1RAMO_NOMERAMO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_300_000_LER_V1RAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_300_000_LER_V1RAMO_DB_SELECT_1_Query1", q8);

                #endregion

                #region M_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "ORDEM_NRORDEM" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1", q9);

                #endregion

                #region M_370_000_LER_V1MOEDA_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "MOEDA_VLCRUZAD" , "20"},
                    { "MOEDA_SIGLUNIM" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_370_000_LER_V1MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_370_000_LER_V1MOEDA_DB_SELECT_1_Query1", q10);

                #endregion

                #region M_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "APITE_DESCRITEM" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1", q11);

                #endregion

                #region M_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "SEGVG_COD_CLIENTE" , ""},
                    { "SEGVG_DTNASCIM" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1", q12);

                #endregion

                #region M_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "CLIEN_NOME" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1", q13);

                #endregion

                #region M_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "V1COND_GARAN_IEA" , ""},
                    { "V1COND_GARAN_IPA" , ""},
                    { "V1COND_GARAN_IPD" , ""},
                    { "V1COND_GARAN_HD" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1", q14);

                #endregion

                #region M_800_000_ATUALIZA_V0RELATORIOS_DB_DELETE_1_Delete1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("M_800_000_ATUALIZA_V0RELATORIOS_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("M_800_000_ATUALIZA_V0RELATORIOS_DB_DELETE_1_Delete1", q15);

                #endregion

                #endregion
                #endregion
                var program = new SI0112B();
                program.Execute(SI0112M1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}