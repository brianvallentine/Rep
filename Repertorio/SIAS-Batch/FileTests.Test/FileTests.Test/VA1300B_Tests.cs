using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VA1300B;

namespace FileTests.Test
{
    [Collection("VA1300B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA1300B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region R003_LE_SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "HOST_CURRENT_DATE" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R003_LE_SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R1100_LE_PESSOA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "OD001_NUM_PESSOA" , ""},
                { "OD001_IND_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_LE_PESSOA_DB_SELECT_1_Query1", q1);

            #endregion

            #region R1120_00_SELECT_OD002_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "OD002_NUM_PESSOA" , ""},
                { "OD002_NUM_CPF" , ""},
                { "OD002_NUM_DV_CPF" , ""},
                { "OD002_NOM_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1120_00_SELECT_OD002_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1140_00_SELECT_OD003_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "OD003_NUM_PESSOA" , ""},
                { "OD003_NUM_CNPJ" , ""},
                { "OD003_NUM_FILIAL" , ""},
                { "OD003_NUM_DV_CNPJ" , ""},
                { "OD003_NOM_RAZAO_SOCIAL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1140_00_SELECT_OD003_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1200_LE_ENDERECO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "OD007_NOM_LOGRADOURO" , ""},
                { "OD007_DES_NUM_IMOVEL" , ""},
                { "OD007_DES_COMPL_ENDERECO" , ""},
                { "OD007_NOM_BAIRRO" , ""},
                { "OD007_NOM_CIDADE" , ""},
                { "OD007_COD_CEP" , ""},
                { "OD007_COD_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_LE_ENDERECO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1210_TRATAR_ENDERECO_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "OD007_NUM_PESSOA" , ""},
                { "OD007_SEQ_ENDERECO" , ""},
                { "OD007_IND_ENDERECO" , ""},
                { "OD007_STA_ENDERECO" , ""},
                { "OD007_NOM_LOGRADOURO" , ""},
                { "OD007_DES_NUM_IMOVEL" , ""},
                { "OD007_DES_COMPL_ENDERECO" , ""},
                { "OD007_NOM_BAIRRO" , ""},
                { "OD007_NOM_CIDADE" , ""},
                { "OD007_COD_CEP" , ""},
                { "OD007_COD_UF" , ""},
                { "OD007_STA_CORRESPONDER" , ""},
                { "OD007_STA_PROPAGANDA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1210_TRATAR_ENDERECO_DB_INSERT_1_Insert1", q5);

            #endregion

            #region R10000_GRAVA_RELATORIOS_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "HOST_CURRENT_DATE" , ""},
                { "PARM_NSA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R10000_GRAVA_RELATORIOS_DB_INSERT_1_Insert1", q6);

            #endregion

            #region R300_SELECT_HISLANCT_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
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
                { "OD009_COD_BANCO" , ""},
                { "OD009_COD_AGENCIA" , ""},
                { "OD009_NUM_CONTA" , ""},
                { "OD009_NUM_DV_CONTA" , ""},
                { "OD009_NUM_OPERACAO_CONTA" , ""},
                { "OD009_NUM_PESSOA" , ""},
                { "OD009_SEQ_CONTA_BANCARIA" , ""},
                { "GE368_NUM_OCORR_MOVTO" , ""},
                { "GE368_NUM_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R300_SELECT_HISLANCT_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1600_00_UPDATE_GE366_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "GE366_IND_EVENTO" , ""},
                { "GE366_NUM_OCORR_MOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_UPDATE_GE366_DB_UPDATE_1_Update1", q8);

            #endregion

            #endregion
        }


        /*
         {{
            /*"  05 MOV-OUTROBC-NUM-SEQUENCIA     PIC 9(01)
            /*"  05 FILLER                        PIC X(01) VALUE '-'
            /*"  05 MOV-OUTROBC-COD-BANCO         PIC 9(03)
            /*"  05 FILLER                        PIC X(01) VALUE '-'
            /*"  05 MOV-OUTROBC-NUM-OCORR-MOVTO   PIC 9(09)
            /*"  05 FILLER                        PIC X(01) VALUE '-'
            /*"  05 MOV-OUTROBC-NUM-CERTIFICADO   PIC 9(15)
            /*"  05 FILLER                        PIC X(01) VALUE '-'
            /*"  05 MOV-OUTROBC-NUM-PARCELA       PIC 9(05)
            /*"  05 FILLER                        PIC X(01) VALUE '-'
            /*"  05 MOV-OUTROBC-NUM-TITULO        PIC 9(13)
            /*"  05 FILLER                        PIC X(01) VALUE '-'
            /*"  05 MOV-OUTROBC-NUM-PESSOA        PIC 9(09)
            /*"  05 FILLER                        PIC X(01) VALUE '-'
            /*"  05 MOV-OUTROBC-DATA-VENCIMENTO   PIC X(10)
            /*"  05 FILLER                        PIC X(01) VALUE '-'
            /*"  05 MOV-OUTROBC-NSA               PIC 9(06)
         */
        [Theory]
        [InlineData(
              "VA1300B_1_t1", "1-002-000000003-000000000000004-00005-0000000000006-000000007-2024-09-30-000008                     "
            , "123456789"
            , "123456789"
        )]
        public static void VA1300B_Tests_Theory(string SORTWK01_FILE_NAME_P, string OUTROSBC_FILE_NAME_P, string SAIDA_FILE_NAME_P, string RELAT_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SORTWK01_FILE_NAME_P = $"{SORTWK01_FILE_NAME_P}_{timestamp}.txt";
            SAIDA_FILE_NAME_P = $"{SAIDA_FILE_NAME_P}_{timestamp}.txt";
            RELAT_FILE_NAME_P = $"{RELAT_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VA1300B();

                AppSettings.Settings.MemoryFiles.Add(OUTROSBC_FILE_NAME_P);

                program.Execute(SORTWK01_FILE_NAME_P, OUTROSBC_FILE_NAME_P, SAIDA_FILE_NAME_P, RELAT_FILE_NAME_P);

                AppSettings.Settings.MemoryFiles.Clear();
                Assert.True(true);
            }
        }
    }
}