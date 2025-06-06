using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VA2513B;
using System.IO;
using Sias.VidaAzul.DB2.VA2513B;

namespace FileTests.Test
{
    [Collection("VA2513B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA2513B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.Clear();
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2020/02/01"},
                { "V1SIST_MESREFER" , "10"},
                { "V1SIST_ANOREFER" , "2001"},
                { "WHOST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region VA2513B_CFAIXACEP

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0FAIC_FAIXA" , "1"},
                { "V0FAIC_CEPINI" , ""},
                { "V0FAIC_CEPFIM" , ""},
                { "V0FAIC_DESC_FAIXA" , ""},
                { "V0FAIC_CENTRALIZA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA2513B_CFAIXACEP", q1);

            #endregion

            #region VA2513B_CMSG

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0MENS_APOLICE" , ""},
                { "V0MENS_CODSUBES" , ""},
                { "V0MENS_CODOPER" , ""},
                { "V0MENS_JDE" , ""},
                { "V0MENS_JDL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA2513B_CMSG", q2);

            #endregion

            #region VA2513B_V1AGENCEF

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1MCEF_COD_FONTE" , ""},
                { "V1FONT_NOMEFTE" , ""},
                { "V1FONT_ENDERFTE" , ""},
                { "V1FONT_BAIRRO" , ""},
                { "V1FONT_CIDADE" , ""},
                { "V1FONT_CEP" , ""},
                { "V1FONT_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA2513B_V1AGENCEF", q3);

            #endregion

            #region VA2513B_CHISTCOB

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0HIST_NRCERTIF" , ""},
                { "V0HIST_NRPARCEL" , ""},
                { "V0HIST_NRTIT" , ""},
                { "V0HIST_DTVENCTO" , ""},
                { "V0HIST_VLPRMTOT" , ""},
                { "V0HIST_CODOPER" , ""},
                { "V0HIST_OPCAOPAG" , ""},
                { "V0HIST_NRTITCOMP" , ""},
                { "V0HIST_CODPRODU" , ""},
                { "V0HIST_OCORHIST" , ""},
                { "V0HIST_CDCLIENTE" , ""},
                { "V0HIST_IDSEXO" , ""},
                { "V0HIST_OPCOBERT" , ""},
                { "V0HIST_NRAPOLICE" , ""},
                { "V0HIST_CODSUBES" , ""},
                { "V0HIST_AGECOBR" , ""},
                { "V0HIST_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA2513B_CHISTCOB", q4);

            #endregion

            #region R1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0CLIE_NOME_RAZAO" , ""},
                { "V0CLIE_CPF" , ""},
                { "V0CLIE_DTNASC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1210_00_SELECT_V0SEGURAVG_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0SEGV_SIT_REGISTRO" , ""},
                { "V0SEGV_IDE_SEXO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_SELECT_V0SEGURAVG_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0ENDE_ENDERECO" , ""},
                { "V0ENDE_BAIRRO" , ""},
                { "V0ENDE_CIDADE" , ""},
                { "V0ENDE_UF" , ""},
                { "V0ENDE_CEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1MCEF_COD_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1", q8);

            #endregion

            #region R2610_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0MENS_JDE" , ""},
                { "V0MENS_JDL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2610_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1", q9);

            #endregion

            #region R2750_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0COND_CAR_CONJUGE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2750_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1", q10);

            #endregion

            #region R2800_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0COBE_IMPMORNATU" , ""},
                { "V0COBE_IMPMORACID" , ""},
                { "V0COBE_VLPREMIO" , ""},
                { "V0COBE_DTINIVIG" , ""},
                { "V0COBE_IMPSEGCDG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2800_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1", q11);

            #endregion

            #region R2850_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NRCERTIF" , ""},
                { "WHOST_NRPARCEL" , ""},
                { "WHOST_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2850_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_NRCOPIAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1", q13);

            #endregion

            #region R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V0RELA_NRCOPIAS" , ""},
                { "V1SIST_MESREFER" , ""},
                { "V1SIST_ANOREFER" , ""},
                { "WHOST_NRAPOLICE" , ""},
                { "WHOST_CODSUBES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1", q14);

            #endregion

            #region R2930_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""},
                { "WHOST_PROXIMA_DATA" , ""},
                { "CALENDAR_DIA_SEMANA" , ""},
                { "CALENDAR_FERIADO" , ""},
            });
            q15.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""},
                { "WHOST_PROXIMA_DATA" , ""},
                { "CALENDAR_DIA_SEMANA" , ""},
                { "CALENDAR_FERIADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2930_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1", q15);

            #endregion

            #region R2950_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_CODPRODU" , ""},
                { "V0PROD_NOMPRODU" , ""},
                { "V0PROD_CODCDT" , ""},
                { "V0PROD_ORIG_PRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2950_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1", q16);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("RVA2513B_FILE.txt", "SVA2513B_FILE.txt", "FVA2513B_FILE.txt")]
        public static void VA2513B_Tests_Theory(string RVA2513B_FILE_NAME_P, string SVA2513B_FILE_NAME_P, string FVA2513B_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

               
                #region VARIAVEIS_TESTE
                #endregion
                var program = new VA2513B();
                program.Execute(RVA2513B_FILE_NAME_P, SVA2513B_FILE_NAME_P, FVA2513B_FILE_NAME_P);

                Assert.True(File.Exists(program.RVA2513B.FilePath));
                Assert.True(new FileInfo(program.RVA2513B.FilePath)?.Length > 0);

                Assert.True(File.Exists(program.FVA2513B.FilePath));
                Assert.True(new FileInfo(program.FVA2513B.FilePath)?.Length > 0);

                var envList = AppSettings.TestSet.DynamicData["R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1"].DynamicList;
                
                //Assert.True(envList?.Count > 1);

                //Assert.True(envList[1].TryGetValue("V1SIST_DTMOVABE", out string valor) && valor == "2020/02/01");
                //Assert.True(envList[1].TryGetValue("V1SIST_ANOREFER", out valor) && valor == "2001");

            }
        }
    }
}