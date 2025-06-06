using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VA0341B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VA0341B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0341B_Tests
    {
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SIST_CURRDATE" , "2020-04-01"}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PARM_CODCONV" , ""},
                { "PARM_NSA" , ""},
                { "PARM_VERSAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q1);

            #endregion

            #region VA0341B_RESSARC

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "AGECTADEB" , ""},
                { "OPRCTADEB" , ""},
                { "NUMCTADEB" , ""},
                { "DIGCTADEB" , ""},
                { "COD_BANCO" , ""},
                { "VLPRMTOT" , ""},
                { "SITUACAO" , ""},
                { "DTVENCTO" , ""},
                { "NSAS" , ""},
                { "NSL" , ""},
                { "NRCERTIF" , ""},
                { "NRPARCEL" , ""},
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "AGECTADEB" , ""},
                { "OPRCTADEB" , ""},
                { "NUMCTADEB" , ""},
                { "DIGCTADEB" , ""},
                { "COD_BANCO" , ""},
                { "VLPRMTOT" , ""},
                { "SITUACAO" , ""},
                { "DTVENCTO" , ""},
                { "NSAS" , ""},
                { "NSL" , ""},
                { "NRCERTIF" , ""},
                { "NRPARCEL" , ""},
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "AGECTADEB" , ""},
                { "OPRCTADEB" , ""},
                { "NUMCTADEB" , ""},
                { "DIGCTADEB" , ""},
                { "COD_BANCO" , ""},
                { "VLPRMTOT" , ""},
                { "SITUACAO" , ""},
                { "DTVENCTO" , ""},
                { "NSAS" , ""},
                { "NSL" , ""},
                { "NRCERTIF" , ""},
                { "NRPARCEL" , ""},
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "AGECTADEB" , ""},
                { "OPRCTADEB" , ""},
                { "NUMCTADEB" , ""},
                { "DIGCTADEB" , ""},
                { "COD_BANCO" , ""},
                { "VLPRMTOT" , ""},
                { "SITUACAO" , ""},
                { "DTVENCTO" , ""},
                { "NSAS" , ""},
                { "NSL" , ""},
                { "NRCERTIF" , ""},
                { "NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0341B_RESSARC", q2);

            #endregion

            #region R1000_LE_REGISTRO_DB_UPDATE_1_Update1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTCREDITO" , ""},
                { "PARM_NSA" , ""},
                { "SQL_NOT_NULL" , ""},
                { "NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_LE_REGISTRO_DB_UPDATE_1_Update1", q3);

            #endregion

            #region R2000_ACESSA_REDUCAO_CHEQUE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_CERTIFICADO" , ""},
                { "HISLANCT_NUM_PARCELA" , ""},
                { "COBHISVI_NUM_TITULO" , ""},
                { "HISLANCT_PRM_TOTAL" , ""},
                { "HISLANCT_SIT_REGISTRO" , ""},
                { "HISLANCT_DATA_VENCIMENTO" , ""},
                { "HISLANCT_NSAS" , ""},
                { "HISLANCT_NSL" , ""},
                { "HISLANCT_CODCONV" , ""},
                { "VG079_NUM_OCORR_MOVTO" , ""},
                { "OD009_NUM_PESSOA" , ""},
                { "OD009_SEQ_CONTA_BANCARIA" , ""},
                { "OD009_COD_BANCO" , ""},
                { "OD009_COD_AGENCIA" , ""},
                { "OD009_NUM_CONTA" , ""},
                { "OD009_NUM_DV_CONTA" , ""},
                { "OD009_NUM_OPERACAO_CONTA" , ""},
                { "GE368_NUM_OCORR_MOVTO" , ""},
                { "GE368_NUM_PESSOA" , ""},
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_NUM_CERTIFICADO" , ""},
                { "HISLANCT_NUM_PARCELA" , ""},
                { "COBHISVI_NUM_TITULO" , ""},
                { "HISLANCT_PRM_TOTAL" , ""},
                { "HISLANCT_SIT_REGISTRO" , ""},
                { "HISLANCT_DATA_VENCIMENTO" , ""},
                { "HISLANCT_NSAS" , ""},
                { "HISLANCT_NSL" , ""},
                { "HISLANCT_CODCONV" , ""},
                { "VG079_NUM_OCORR_MOVTO" , ""},
                { "OD009_NUM_PESSOA" , ""},
                { "OD009_SEQ_CONTA_BANCARIA" , ""},
                { "OD009_COD_BANCO" , ""},
                { "OD009_COD_AGENCIA" , ""},
                { "OD009_NUM_CONTA" , ""},
                { "OD009_NUM_DV_CONTA" , ""},
                { "OD009_NUM_OPERACAO_CONTA" , ""},
                { "GE368_NUM_OCORR_MOVTO" , ""},
                { "GE368_NUM_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_ACESSA_REDUCAO_CHEQUE_DB_SELECT_1_Query1", q4);

            #endregion

            #region R5000_GRAVA_RELATORIOS_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SIST_CURRDATE" , ""},
                { "PARM_NSA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_GRAVA_RELATORIOS_DB_INSERT_1_Insert1", q5);

            #endregion

            #region R9000_FINALIZA_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PARM_NSA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R9000_FINALIZA_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R9000_FINALIZA_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PARM_CODCONV" , ""},
                { "PARM_NSA" , ""},
                { "SIST_CURRDATE" , ""},
                { "SIST_DTCREDITO" , ""},
                { "PARM_VERSAO" , ""},
                { "FITSAS_REG" , ""},
                { "FITSAS_VALOR" , ""},
                { "FITSAS_NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9000_FINALIZA_DB_INSERT_1_Insert1", q7);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("MOVIMENTO_01.txt", "OUTROSBC.txt")]
        public static void VA0341B_Tests_Theory(string MOVIMENTO_FILE_NAME_P, string OUTROSBC_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVIMENTO_FILE_NAME_P = $"{MOVIMENTO_FILE_NAME_P}_{timestamp}.txt";
            OUTROSBC_FILE_NAME_P = $"{OUTROSBC_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                var program = new VA0341B();

                var fileName = Path.GetFileNameWithoutExtension(MOVIMENTO_FILE_NAME_P);
                MOVIMENTO_FILE_NAME_P = MOVIMENTO_FILE_NAME_P.Replace(fileName, fileName + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"));
                Console.WriteLine($"#### Arquivo {MOVIMENTO_FILE_NAME_P} em : {AppSettings.Settings.FileFolderPath}");

                fileName = Path.GetFileNameWithoutExtension(OUTROSBC_FILE_NAME_P);
                OUTROSBC_FILE_NAME_P = OUTROSBC_FILE_NAME_P.Replace(fileName, fileName + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"));
                Console.WriteLine($"#### Arquivo {OUTROSBC_FILE_NAME_P} em : {AppSettings.Settings.FileFolderPath}");

                AppSettings.TestSet.IsTest = true;

                Load_Parameters();

                program.Execute(MOVIMENTO_FILE_NAME_P, OUTROSBC_FILE_NAME_P);

                Assert.True(File.Exists(program.MOVIMENTO.FilePath));
                Assert.True(new FileInfo(program.MOVIMENTO.FilePath)?.Length > 0);

                Assert.True(File.Exists(program.OUTROSBC.FilePath));
                Assert.True(new FileInfo(program.OUTROSBC.FilePath)?.Length > 0);

                var envList = AppSettings.TestSet.DynamicData["R5000_GRAVA_RELATORIOS_DB_INSERT_1_Insert1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R9000_FINALIZA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);

                Assert.True(envList[1].TryGetValue("PARM_NSA", out var valOr) && valOr == "0001");
                Assert.True(envList[1].TryGetValue("SIST_CURRDATE", out valOr) && valOr == "2020-04-01");

                Assert.True(envList1[1].TryGetValue("SIST_CURRDATE", out valOr) && valOr == "2020-04-01");
                Assert.True(envList1[1].TryGetValue("FITSAS_REG", out valOr) && valOr == "000000002");
            }
        }
    }
}