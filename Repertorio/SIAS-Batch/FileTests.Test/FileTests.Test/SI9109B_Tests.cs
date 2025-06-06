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
using static Code.SI9109B;

namespace FileTests.Test
{
    [Collection("SI9109B_Tests")]

    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]

    public class SI9109B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_LE_CALENDAR_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_LE_CALENDAR_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI9109B_C01_SIARDEVC

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NOM_ARQUIVO" , ""},
                { "SIARDEVC_SEQ_GERACAO" , ""},
                { "SIARDEVC_TIPO_REGISTRO" , ""},
                { "SIARDEVC_SEQ_REGISTRO" , ""},
                { "SIARDEVC_NUM_APOL_SINISTRO" , ""},
                { "SIARDEVC_NUM_SINISTRO_VC" , ""},
                { "SIARDEVC_NUM_EXPEDIENTE_VC" , ""},
                { "SIARDEVC_COD_OPERACAO" , ""},
                { "SIARDEVC_NUM_APOLICE" , ""},
                { "SIARDEVC_NUM_ENDOSSO" , ""},
                { "SIARDEVC_NUM_ITEM" , ""},
                { "SIARDEVC_COD_COBERTURA" , ""},
                { "SIARDEVC_DATA_OCORRENCIA" , ""},
                { "SIARDEVC_VAL_TOT_MOVIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI9109B_C01_SIARDEVC", q2);

            #endregion

            #region R1100_00_LE_SINISMES_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SINISMES_SALDO_PAGAR_IX" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
                { "SINISMES_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SINISMES_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HOST_NUM_SINISTRO_VC" , ""},
                { "HOST_NUM_EXPEDIENTE_VC" , ""},
                { "HOST_COD_COBERTURA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_TIPO_FAVORECIDO" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_SIT_REGISTRO" , ""},
                { "SIARDEVC_NUM_APOLICE" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1", q5);

            #endregion

            #region R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_OCORR_HISTORICO" , ""},
                { "SINISMES_SALDO_PAGAR_IX" , ""},
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SIARDEVC_NUM_APOL_SINISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_COD_ERRO" , ""},
                { "IND_COD_ERRO" , ""},
                { "SIARDEVC_STA_PROCESSAMENTO" , ""},
                { "SIARDEVC_OCORR_HISTORICO" , ""},
                { "SIARDEVC_TIPO_REGISTRO" , ""},
                { "SIARDEVC_SEQ_REGISTRO" , ""},
                { "SIARDEVC_NOM_ARQUIVO" , ""},
                { "SIARDEVC_SEQ_GERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q7);

            #endregion

            #endregion
        }

     
        [Fact]
        public static void SI9109B_Tests1_Fact()
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

                #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0200_00_LE_CALENDAR_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_LE_CALENDAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_LE_CALENDAR_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI9109B_C01_SIARDEVC

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NOM_ARQUIVO" , "arquivo1" },
                { "SIARDEVC_SEQ_GERACAO" , "1" },
                { "SIARDEVC_TIPO_REGISTRO" , "A" },
                { "SIARDEVC_SEQ_REGISTRO" , "100" },
                { "SIARDEVC_NUM_APOL_SINISTRO" , "123456" },
                { "SIARDEVC_NUM_SINISTRO_VC" , "SIN123" },
                { "SIARDEVC_NUM_EXPEDIENTE_VC" , "EXP123" },
                { "SIARDEVC_COD_OPERACAO" , "101" },
                { "SIARDEVC_NUM_APOLICE" , "APL123" },
                { "SIARDEVC_NUM_ENDOSSO" , "END123" },
                { "SIARDEVC_NUM_ITEM" , "10" },
                { "SIARDEVC_COD_COBERTURA" , "COB123" },
                { "SIARDEVC_DATA_OCORRENCIA" , "2023-11-01" },
                { "SIARDEVC_VAL_TOT_MOVIMENTO" , "5000.0" },
            });
                AppSettings.TestSet.DynamicData.Remove("SI9109B_C01_SIARDEVC");
                AppSettings.TestSet.DynamicData.Add("SI9109B_C01_SIARDEVC", q2);

                #endregion

                #region R1100_00_LE_SINISMES_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_SIT_REGISTRO" , "1" },
                { "SINISMES_SALDO_PAGAR_IX" , "2000.0" },
                { "SINISMES_COD_FONTE" , "FNT123" },
                { "SINISMES_COD_PRODUTO" , "PRD123" },
                { "SINISMES_OCORR_HISTORICO" , "Histórico de ocorrência" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SINISMES_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "HOST_NUM_SINISTRO_VC" , "2" },
                { "HOST_NUM_EXPEDIENTE_VC" , "HEXP123" },
                { "HOST_COD_COBERTURA" , "HCOB123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NUM_APOL_SINISTRO" , "2" },
                { "SINISMES_OCORR_HISTORICO" , "Histórico de ocorrência" },
                { "SINISHIS_COD_OPERACAO" , "102" },
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "SINISHIS_NOME_FAVORECIDO" , "Favorecido1" },
                { "SINISHIS_VAL_OPERACAO" , "3000.0" },
                { "SINISHIS_TIPO_FAVORECIDO" , "Tipo1" },
                { "SINISMES_COD_FONTE" , "FNT123" },
                { "SINISHIS_SIT_CONTABIL" , "Contábil1" },
                { "SINISHIS_SIT_REGISTRO" , "Registro1" },
                { "SIARDEVC_NUM_APOLICE" , "APL123" },
                { "SINISMES_COD_PRODUTO" , "PRD123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1", q5);

                #endregion

                #region R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_OCORR_HISTORICO" , "Histórico de ocorrência" },
                { "SINISMES_SALDO_PAGAR_IX" , "2000.0" },
                { "SINISMES_SIT_REGISTRO" , "1" },
                { "SIARDEVC_NUM_APOL_SINISTRO" , "123456" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1", q6);

                #endregion

                #region R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_COD_ERRO" , "Erro1" },
                { "IND_COD_ERRO" , "Erro2" },
                { "SIARDEVC_STA_PROCESSAMENTO" , "Processando" },
                { "SIARDEVC_OCORR_HISTORICO" , "Histórico de processamento" },
                { "SIARDEVC_TIPO_REGISTRO" , "A" },
                { "SIARDEVC_SEQ_REGISTRO" , "100" },
                { "SIARDEVC_NOM_ARQUIVO" , "arquivo1" },
                { "SIARDEVC_SEQ_GERACAO" , "1" },
            });
                AppSettings.TestSet.DynamicData.Remove("R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q7);

                #endregion

                #endregion

                var program = new SI9109B();
                program.Execute();

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

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
        public static void SI9109B_Tests2_Fact()
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

                #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0200_00_LE_CALENDAR_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_LE_CALENDAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_LE_CALENDAR_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI9109B_C01_SIARDEVC

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NOM_ARQUIVO" , "Arquivo1" },
                { "SIARDEVC_SEQ_GERACAO" , "1" },
                { "SIARDEVC_TIPO_REGISTRO" , "Tipo1" },
                { "SIARDEVC_SEQ_REGISTRO" , "1" },
                { "SIARDEVC_NUM_APOL_SINISTRO" , "2" },
                { "SIARDEVC_NUM_SINISTRO_VC" , "2" },
                { "SIARDEVC_NUM_EXPEDIENTE_VC" , "Expediente123" },
                { "SIARDEVC_COD_OPERACAO" , "100" },
                { "SIARDEVC_NUM_APOLICE" , "Apolice456" },
                { "SIARDEVC_NUM_ENDOSSO" , "Endosso123" },
                { "SIARDEVC_NUM_ITEM" , "1" },
                { "SIARDEVC_COD_COBERTURA" , "200" },
                { "SIARDEVC_DATA_OCORRENCIA" , "2023-11-01" },
                { "SIARDEVC_VAL_TOT_MOVIMENTO" , "5000.0" },
            });
                AppSettings.TestSet.DynamicData.Remove("SI9109B_C01_SIARDEVC");
                AppSettings.TestSet.DynamicData.Add("SI9109B_C01_SIARDEVC", q2);

                #endregion

                #region R1100_00_LE_SINISMES_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_SIT_REGISTRO" , "Ativo" },
                { "SINISMES_SALDO_PAGAR_IX" , "3000.0" },
                { "SINISMES_COD_FONTE" , "Fonte1" },
                { "SINISMES_COD_PRODUTO" , "Produto1" },
                { "SINISMES_OCORR_HISTORICO" , "Histórico1" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SINISMES_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "HOST_NUM_SINISTRO_VC" , "Sinistro999" },
                { "HOST_NUM_EXPEDIENTE_VC" , "Expediente999" },
                { "HOST_COD_COBERTURA" , "999" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_NUM_APOL_SINISTRO" , "2" },
                { "SINISMES_OCORR_HISTORICO" , "Histórico1" },
                { "SINISHIS_COD_OPERACAO" , "101" },
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "SINISHIS_NOME_FAVORECIDO" , "Favorecido1" },
                { "SINISHIS_VAL_OPERACAO" , "2000.0" },
                { "SINISHIS_TIPO_FAVORECIDO" , "TipoFav1" },
                { "SINISMES_COD_FONTE" , "Fonte1" },
                { "SINISHIS_SIT_CONTABIL" , "Contabil1" },
                { "SINISHIS_SIT_REGISTRO" , "Registro1" },
                { "SIARDEVC_NUM_APOLICE" , "Apolice456" },
                { "SINISMES_COD_PRODUTO" , "Produto1" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1", q5);

                #endregion

                #region R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_OCORR_HISTORICO" , "Histórico1" },
                { "SINISMES_SALDO_PAGAR_IX" , "3000.0" },
                { "SINISMES_SIT_REGISTRO" , "Ativo" },
                { "SIARDEVC_NUM_APOL_SINISTRO" , "Apolice123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1", q6);

                #endregion

                #region R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SIARDEVC_COD_ERRO" , "0" },
                { "IND_COD_ERRO" , "0" },
                { "SIARDEVC_STA_PROCESSAMENTO" , "Processando" },
                { "SIARDEVC_OCORR_HISTORICO" , "Histórico2" },
                { "SIARDEVC_TIPO_REGISTRO" , "Tipo1" },
                { "SIARDEVC_SEQ_REGISTRO" , "1" },
                { "SIARDEVC_NOM_ARQUIVO" , "Arquivo1" },
                { "SIARDEVC_SEQ_GERACAO" , "1" },
            });
                AppSettings.TestSet.DynamicData.Remove("R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q7);

                #endregion

                #endregion

                var program = new SI9109B();
                program.Execute();

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);


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
        public static void SI9109B_Tests99_Fact()
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

                #region R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0200_00_LE_CALENDAR_DB_SELECT_1_Query1

                var q1 = new DynamicData();              
                AppSettings.TestSet.DynamicData.Remove("R0200_00_LE_CALENDAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_LE_CALENDAR_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI9109B_C01_SIARDEVC

                var q2 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("SI9109B_C01_SIARDEVC");
                AppSettings.TestSet.DynamicData.Add("SI9109B_C01_SIARDEVC", q2);

                #endregion

                #region R1100_00_LE_SINISMES_DB_SELECT_1_Query1

                var q3 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_SINISMES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_SINISMES_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1

                var q4 = new DynamicData();               
                AppSettings.TestSet.DynamicData.Remove("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1

                var q5 = new DynamicData();
              
                AppSettings.TestSet.DynamicData.Remove("R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1", q5);

                #endregion

                #region R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1

                var q6 = new DynamicData();
               
                AppSettings.TestSet.DynamicData.Remove("R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1", q6);

                #endregion

                #region R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1

                var q7 = new DynamicData();
              
                AppSettings.TestSet.DynamicData.Remove("R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1", q7);

                #endregion

                #endregion

                var program = new SI9109B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);


            }
        }

    }
}