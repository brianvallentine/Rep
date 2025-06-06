using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Copies;
using Dclgens;
using Code;
using static Code.PTACOMOS;

namespace FileTests.Test
{
    [Collection("PTACOMOS_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class PTACOMOS_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_NUM_OCORR_SINIACO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1_Insert1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_COD_FONTE" , ""},
                { "SISINACO_NUM_PROTOCOLO_SINI" , ""},
                { "SISINACO_DAC_PROTOCOLO_SINI" , ""},
                { "SISINACO_NUM_OCORR_SINIACO" , ""},
                { "SISINACO_COD_EVENTO" , ""},
                { "SISINACO_DATA_MOVTO_SINIACO" , ""},
                { "SISINACO_DESCR_COMPLEMENTAR" , ""},
                { "SISINACO_COD_USUARIO" , ""},
                { "SISINACO_NUM_CARTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1_Insert1", q1);

            #endregion

            #region R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SIMOVSIN_COD_ESTIPULANTE" , ""},
                { "SIMOVSIN_COD_PRODUTO" , ""},
                { "SIMOVSIN_RAMO_EMISSOR" , ""},
                { "SIMOVSIN_COD_CAUSA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1400_00_INCLUI_SIPARTIC_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_COD_FONTE" , ""},
                { "SISINACO_NUM_PROTOCOLO_SINI" , ""},
                { "SISINACO_DAC_PROTOCOLO_SINI" , ""},
                { "SIMOVSIN_COD_ESTIPULANTE" , ""},
                { "SISINACO_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_INCLUI_SIPARTIC_DB_INSERT_1_Insert1", q3);

            #endregion

            #region R1500_00_MAX_SIPROACO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SIPROACO_OCORR_HISTORICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_MAX_SIPROACO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1600_00_LE_SINISCAU_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_COD_GRUPO_CAUSA" , ""},
                { "SINISCAU_COD_SUBGRUPO_CAUSA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_LE_SINISCAU_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SICHEPAR_DATA_INIVIGENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1800_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_COD_FONTE" , ""},
                { "SISINACO_NUM_PROTOCOLO_SINI" , ""},
                { "SISINACO_DAC_PROTOCOLO_SINI" , ""},
                { "SIPROACO_OCORR_HISTORICO" , ""},
                { "SICHEPAR_DATA_INIVIGENCIA" , ""},
                { "SISINACO_DATA_MOVTO_SINIACO" , ""},
                { "SIMOVSIN_COD_PRODUTO" , ""},
                { "SINISCAU_COD_GRUPO_CAUSA" , ""},
                { "SINISCAU_COD_SUBGRUPO_CAUSA" , ""},
                { "SIMOVSIN_COD_ESTIPULANTE" , ""},
                { "SISINACO_COD_EVENTO" , ""},
                { "SISINACO_NUM_CARTA" , ""},
                { "SISINACO_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1800_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R2100_00_EXCLUI_SISINACO_DB_DELETE_1_Delete1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_COD_FONTE" , ""},
                { "SISINACO_NUM_PROTOCOLO_SINI" , ""},
                { "SISINACO_DAC_PROTOCOLO_SINI" , ""},
                { "SISINACO_NUM_OCORR_SINIACO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_EXCLUI_SISINACO_DB_DELETE_1_Delete1", q8);

            #endregion

            #endregion
        }

        [Fact]
        public static void PTACOMOS_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();


                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_NUM_OCORR_SINIACO" , "1234" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1_Insert1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_COD_FONTE" , "1001" },
                { "SISINACO_NUM_PROTOCOLO_SINI" , "987654321" },
                { "SISINACO_DAC_PROTOCOLO_SINI" , "A" },
                { "SISINACO_NUM_OCORR_SINIACO" , "1234" },
                { "SISINACO_COD_EVENTO" , "2002" },
                { "SISINACO_DATA_MOVTO_SINIACO" , "2023-12-01" },
                { "SISINACO_DESCR_COMPLEMENTAR" , "Detalhes adicionais do evento" },
                { "SISINACO_COD_USUARIO" , "USR123" },
                { "SISINACO_NUM_CARTA" , "5555" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1_Insert1", q1);

                #endregion

                #region R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SIMOVSIN_COD_ESTIPULANTE" , "3003" },
                { "SIMOVSIN_COD_PRODUTO" , "4004" },
                { "SIMOVSIN_RAMO_EMISSOR" , "5005" },
                { "SIMOVSIN_COD_CAUSA" , "6006" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1400_00_INCLUI_SIPARTIC_DB_INSERT_1_Insert1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_COD_FONTE" , "1001" },
                { "SISINACO_NUM_PROTOCOLO_SINI" , "987654321" },
                { "SISINACO_DAC_PROTOCOLO_SINI" , "A" },
                { "SIMOVSIN_COD_ESTIPULANTE" , "3003" },
                { "SISINACO_COD_USUARIO" , "USR123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_INCLUI_SIPARTIC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_INCLUI_SIPARTIC_DB_INSERT_1_Insert1", q3);

                #endregion

                #region R1500_00_MAX_SIPROACO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SIPROACO_OCORR_HISTORICO" , "Histórico de ocorrências" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_MAX_SIPROACO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_MAX_SIPROACO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1600_00_LE_SINISCAU_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_COD_GRUPO_CAUSA" , "7007" },
                { "SINISCAU_COD_SUBGRUPO_CAUSA" , "8008" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_LE_SINISCAU_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_LE_SINISCAU_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SICHEPAR_DATA_INIVIGENCIA" , "2023-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1800_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_COD_FONTE" , "1001" },
                { "SISINACO_NUM_PROTOCOLO_SINI" , "987654321" },
                { "SISINACO_DAC_PROTOCOLO_SINI" , "A" },
                { "SIPROACO_OCORR_HISTORICO" , "Histórico de ocorrências" },
                { "SICHEPAR_DATA_INIVIGENCIA" , "2023-01-01" },
                { "SISINACO_DATA_MOVTO_SINIACO" , "2023-12-01" },
                { "SIMOVSIN_COD_PRODUTO" , "4004" },
                { "SINISCAU_COD_GRUPO_CAUSA" , "7007" },
                { "SINISCAU_COD_SUBGRUPO_CAUSA" , "8008" },
                { "SIMOVSIN_COD_ESTIPULANTE" , "3003" },
                { "SISINACO_COD_EVENTO" , "2002" },
                { "SISINACO_NUM_CARTA" , "5555" },
                { "SISINACO_COD_USUARIO" , "USR123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1800_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1800_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1", q7);

                #endregion

                #region R2100_00_EXCLUI_SISINACO_DB_DELETE_1_Delete1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_COD_FONTE" , "1001" },
                { "SISINACO_NUM_PROTOCOLO_SINI" , "987654321" },
                { "SISINACO_DAC_PROTOCOLO_SINI" , "A" },
                { "SISINACO_NUM_OCORR_SINIACO" , "1234" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_EXCLUI_SISINACO_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_EXCLUI_SISINACO_DB_DELETE_1_Delete1", q8);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute(new LBWCT001_PROTOCOLO_RECEBIDO(), new SISINACO_DCLSI_SINISTRO_ACOMP(), new LBWCT002_PROTOCOLO_ENVIO());
                var param1 = new LBWCT001_PROTOCOLO_RECEBIDO();
                param1.IN_OPERACAO.Value = "1";

                var param2 = new SISINACO_DCLSI_SINISTRO_ACOMP();
                param2.SISINACO_COD_FONTE.Value = 1;
                param2.SISINACO_NUM_PROTOCOLO_SINI.Value = 1;
                param2.SISINACO_COD_EVENTO.Value = 1;
                param2.SISINACO_DATA_MOVTO_SINIACO.Value = "0";

                var param3 = new LBWCT002_PROTOCOLO_ENVIO();

                var program = new PTACOMOS();

                program.Execute(param1, param2, param3);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);
                
                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.Equal("0000", program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO.Value);
            }
        }

        [Fact]
        public static void PTACOMOS_Tests_Updates_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();


                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_NUM_OCORR_SINIACO" , "1234" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1_Insert1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_COD_FONTE" , "1001" },
                { "SISINACO_NUM_PROTOCOLO_SINI" , "987654321" },
                { "SISINACO_DAC_PROTOCOLO_SINI" , "A" },
                { "SISINACO_NUM_OCORR_SINIACO" , "1234" },
                { "SISINACO_COD_EVENTO" , "2002" },
                { "SISINACO_DATA_MOVTO_SINIACO" , "2023-12-01" },
                { "SISINACO_DESCR_COMPLEMENTAR" , "Detalhes adicionais do evento" },
                { "SISINACO_COD_USUARIO" , "USR123" },
                { "SISINACO_NUM_CARTA" , "5555" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1_Insert1", q1);

                #endregion

                #region R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SIMOVSIN_COD_ESTIPULANTE" , "3003" },
                { "SIMOVSIN_COD_PRODUTO" , "4004" },
                { "SIMOVSIN_RAMO_EMISSOR" , "5005" },
                { "SIMOVSIN_COD_CAUSA" , "6006" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1400_00_INCLUI_SIPARTIC_DB_INSERT_1_Insert1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_COD_FONTE" , "1001" },
                { "SISINACO_NUM_PROTOCOLO_SINI" , "987654321" },
                { "SISINACO_DAC_PROTOCOLO_SINI" , "A" },
                { "SIMOVSIN_COD_ESTIPULANTE" , "3003" },
                { "SISINACO_COD_USUARIO" , "USR123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_INCLUI_SIPARTIC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_INCLUI_SIPARTIC_DB_INSERT_1_Insert1", q3);

                #endregion

                #region R1500_00_MAX_SIPROACO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SIPROACO_OCORR_HISTORICO" , "Histórico de ocorrências" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_MAX_SIPROACO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_MAX_SIPROACO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1600_00_LE_SINISCAU_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_COD_GRUPO_CAUSA" , "7007" },
                { "SINISCAU_COD_SUBGRUPO_CAUSA" , "8008" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_LE_SINISCAU_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_LE_SINISCAU_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SICHEPAR_DATA_INIVIGENCIA" , "2023-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1800_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_COD_FONTE" , "1001" },
                { "SISINACO_NUM_PROTOCOLO_SINI" , "987654321" },
                { "SISINACO_DAC_PROTOCOLO_SINI" , "A" },
                { "SIPROACO_OCORR_HISTORICO" , "Histórico de ocorrências" },
                { "SICHEPAR_DATA_INIVIGENCIA" , "2023-01-01" },
                { "SISINACO_DATA_MOVTO_SINIACO" , "2023-12-01" },
                { "SIMOVSIN_COD_PRODUTO" , "4004" },
                { "SINISCAU_COD_GRUPO_CAUSA" , "7007" },
                { "SINISCAU_COD_SUBGRUPO_CAUSA" , "8008" },
                { "SIMOVSIN_COD_ESTIPULANTE" , "3003" },
                { "SISINACO_COD_EVENTO" , "2002" },
                { "SISINACO_NUM_CARTA" , "5555" },
                { "SISINACO_COD_USUARIO" , "USR123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1800_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1800_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1", q7);

                #endregion

                #region R2100_00_EXCLUI_SISINACO_DB_DELETE_1_Delete1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_COD_FONTE" , "1001" },
                { "SISINACO_NUM_PROTOCOLO_SINI" , "987654321" },
                { "SISINACO_DAC_PROTOCOLO_SINI" , "A" },
                { "SISINACO_NUM_OCORR_SINIACO" , "1234" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_EXCLUI_SISINACO_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_EXCLUI_SISINACO_DB_DELETE_1_Delete1", q8);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute(new LBWCT001_PROTOCOLO_RECEBIDO(), new SISINACO_DCLSI_SINISTRO_ACOMP(), new LBWCT002_PROTOCOLO_ENVIO());
                var param1 = new LBWCT001_PROTOCOLO_RECEBIDO();
                param1.IN_OPERACAO.Value = "3";

                var param2 = new SISINACO_DCLSI_SINISTRO_ACOMP();
                param2.SISINACO_COD_FONTE.Value = 1;
                param2.SISINACO_NUM_PROTOCOLO_SINI.Value = 1;
                param2.SISINACO_COD_EVENTO.Value = 1;
                param2.SISINACO_DATA_MOVTO_SINIACO.Value = "0";
                param2.SISINACO_NUM_OCORR_SINIACO.Value = 1;

                var param3 = new LBWCT002_PROTOCOLO_ENVIO();

                var program = new PTACOMOS();

                program.Execute(param1, param2, param3);

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var deletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE") && x.Value.DynamicList.Count == 0).ToList();
                var allDeletes = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("DELETE")).ToList();
                Assert.True(deletes.Count >= allDeletes.Count / 2);

                Assert.Equal("0000", program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO.Value);
            }
        }

        [Fact]
        public static void PTACOMOS_Tests_ReturnCode99_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();


                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_NUM_OCORR_SINIACO" , "1234" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1_Insert1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_COD_FONTE" , "1001" },
                { "SISINACO_NUM_PROTOCOLO_SINI" , "987654321" },
                { "SISINACO_DAC_PROTOCOLO_SINI" , "A" },
                { "SISINACO_NUM_OCORR_SINIACO" , "1234" },
                { "SISINACO_COD_EVENTO" , "2002" },
                { "SISINACO_DATA_MOVTO_SINIACO" , "2023-12-01" },
                { "SISINACO_DESCR_COMPLEMENTAR" , "Detalhes adicionais do evento" },
                { "SISINACO_COD_USUARIO" , "USR123" },
                { "SISINACO_NUM_CARTA" , "5555" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1_Insert1", q1);

                #endregion

                #region R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SIMOVSIN_COD_ESTIPULANTE" , "3003" },
                { "SIMOVSIN_COD_PRODUTO" , "4004" },
                { "SIMOVSIN_RAMO_EMISSOR" , "5005" },
                { "SIMOVSIN_COD_CAUSA" , "6006" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1400_00_INCLUI_SIPARTIC_DB_INSERT_1_Insert1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_COD_FONTE" , "1001" },
                { "SISINACO_NUM_PROTOCOLO_SINI" , "987654321" },
                { "SISINACO_DAC_PROTOCOLO_SINI" , "A" },
                { "SIMOVSIN_COD_ESTIPULANTE" , "3003" },
                { "SISINACO_COD_USUARIO" , "USR123" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1400_00_INCLUI_SIPARTIC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_INCLUI_SIPARTIC_DB_INSERT_1_Insert1", q3);

                #endregion

                #region R1500_00_MAX_SIPROACO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "SIPROACO_OCORR_HISTORICO" , "Histórico de ocorrências" }
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1500_00_MAX_SIPROACO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_MAX_SIPROACO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1600_00_LE_SINISCAU_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_COD_GRUPO_CAUSA" , "7007" },
                { "SINISCAU_COD_SUBGRUPO_CAUSA" , "8008" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1600_00_LE_SINISCAU_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_LE_SINISCAU_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "SICHEPAR_DATA_INIVIGENCIA" , "2023-01-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1800_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_COD_FONTE" , "1001" },
                { "SISINACO_NUM_PROTOCOLO_SINI" , "987654321" },
                { "SISINACO_DAC_PROTOCOLO_SINI" , "A" },
                { "SIPROACO_OCORR_HISTORICO" , "Histórico de ocorrências" },
                { "SICHEPAR_DATA_INIVIGENCIA" , "2023-01-01" },
                { "SISINACO_DATA_MOVTO_SINIACO" , "2023-12-01" },
                { "SIMOVSIN_COD_PRODUTO" , "4004" },
                { "SINISCAU_COD_GRUPO_CAUSA" , "7007" },
                { "SINISCAU_COD_SUBGRUPO_CAUSA" , "8008" },
                { "SIMOVSIN_COD_ESTIPULANTE" , "3003" },
                { "SISINACO_COD_EVENTO" , "2002" },
                { "SISINACO_NUM_CARTA" , "5555" },
                { "SISINACO_COD_USUARIO" , "USR123" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1800_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1800_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1", q7);

                #endregion

                #region R2100_00_EXCLUI_SISINACO_DB_DELETE_1_Delete1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_COD_FONTE" , "1001" },
                { "SISINACO_NUM_PROTOCOLO_SINI" , "987654321" },
                { "SISINACO_DAC_PROTOCOLO_SINI" , "A" },
                { "SISINACO_NUM_OCORR_SINIACO" , "1234" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_EXCLUI_SISINACO_DB_DELETE_1_Delete1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_EXCLUI_SISINACO_DB_DELETE_1_Delete1", q8);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute(new LBWCT001_PROTOCOLO_RECEBIDO(), new SISINACO_DCLSI_SINISTRO_ACOMP(), new LBWCT002_PROTOCOLO_ENVIO());
                var param1 = new LBWCT001_PROTOCOLO_RECEBIDO();
                var param2 = new SISINACO_DCLSI_SINISTRO_ACOMP();
                var param3 = new LBWCT002_PROTOCOLO_ENVIO();

                var program = new PTACOMOS();
                program.Execute(param1, param2, param3);

                Assert.Equal("0001", program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO.Value);
            }
        }
    }
}