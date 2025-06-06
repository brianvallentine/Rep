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
using static Code.PTACOM2S;

namespace FileTests.Test
{
    [Collection("PTACOM2S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class PTACOM2S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SIDOCACO_NUM_OCORR_DOCACO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1_Insert1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SIDOCACO_COD_FONTE" , ""},
                { "SIDOCACO_NUM_PROTOCOLO_SINI" , ""},
                { "SIDOCACO_DAC_PROTOCOLO_SINI" , ""},
                { "SIDOCACO_COD_DOCUMENTO" , ""},
                { "SIDOCACO_NUM_OCORR_DOCACO" , ""},
                { "SIDOCACO_COD_PRODUTO" , ""},
                { "SIDOCACO_COD_GRUPO_CAUSA" , ""},
                { "SIDOCACO_COD_SUBGRUPO_CAUSA" , ""},
                { "SIDOCACO_DATA_INIVIG_DOCPAR" , ""},
                { "SIDOCACO_COD_EVENTO" , ""},
                { "SIDOCACO_DATA_MOVTO_DOCACO" , ""},
                { "SIDOCACO_DESCR_COMPLEMENTAR" , ""},
                { "SIDOCACO_NUM_CARTA" , ""},
                { "SIDOCACO_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1_Insert1", q1);

            #endregion

            #region R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SIMOVSIN_COD_ESTIPULANTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1400_00_MAX_SIPROACO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SIPROACO_OCORR_HISTORICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_MAX_SIPROACO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SICHEPAR_DATA_INIVIGENCIA" , ""},
                { "SICHEPAR_COD_FASE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1600_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SIDOCACO_COD_FONTE" , ""},
                { "SIDOCACO_NUM_PROTOCOLO_SINI" , ""},
                { "SIDOCACO_DAC_PROTOCOLO_SINI" , ""},
                { "SIPROACO_OCORR_HISTORICO" , ""},
                { "SICHEPAR_DATA_INIVIGENCIA" , ""},
                { "SIDOCACO_DATA_MOVTO_DOCACO" , ""},
                { "SIDOCACO_COD_PRODUTO" , ""},
                { "SIDOCACO_COD_GRUPO_CAUSA" , ""},
                { "SIDOCACO_COD_SUBGRUPO_CAUSA" , ""},
                { "SIMOVSIN_COD_ESTIPULANTE" , ""},
                { "SIDOCACO_COD_DOCUMENTO" , ""},
                { "SIPROACO_COD_FASE" , ""},
                { "SIDOCACO_COD_EVENTO" , ""},
                { "SIDOCACO_NUM_CARTA" , ""},
                { "SIDOCACO_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1", q5);

            #endregion

            #endregion
        }

        [Fact]
        public static void PTACOM2S_Tests_Fact()
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
                #region PARAMETERS
                #region R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SIDOCACO_NUM_OCORR_DOCACO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1_Insert1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SIDOCACO_COD_FONTE" , ""},
                    { "SIDOCACO_NUM_PROTOCOLO_SINI" , ""},
                    { "SIDOCACO_DAC_PROTOCOLO_SINI" , ""},
                    { "SIDOCACO_COD_DOCUMENTO" , ""},
                    { "SIDOCACO_NUM_OCORR_DOCACO" , ""},
                    { "SIDOCACO_COD_PRODUTO" , ""},
                    { "SIDOCACO_COD_GRUPO_CAUSA" , ""},
                    { "SIDOCACO_COD_SUBGRUPO_CAUSA" , ""},
                    { "SIDOCACO_DATA_INIVIG_DOCPAR" , ""},
                    { "SIDOCACO_COD_EVENTO" , ""},
                    { "SIDOCACO_DATA_MOVTO_DOCACO" , ""},
                    { "SIDOCACO_DESCR_COMPLEMENTAR" , ""},
                    { "SIDOCACO_NUM_CARTA" , ""},
                    { "SIDOCACO_COD_USUARIO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1_Insert1", q1);

                #endregion

                #region R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "SIMOVSIN_COD_ESTIPULANTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1400_00_MAX_SIPROACO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "SIPROACO_OCORR_HISTORICO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_MAX_SIPROACO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_MAX_SIPROACO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "SICHEPAR_DATA_INIVIGENCIA" , ""},
                    { "SICHEPAR_COD_FASE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1600_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "SIDOCACO_COD_FONTE" , ""},
                    { "SIDOCACO_NUM_PROTOCOLO_SINI" , ""},
                    { "SIDOCACO_DAC_PROTOCOLO_SINI" , ""},
                    { "SIPROACO_OCORR_HISTORICO" , ""},
                    { "SICHEPAR_DATA_INIVIGENCIA" , ""},
                    { "SIDOCACO_DATA_MOVTO_DOCACO" , ""},
                    { "SIDOCACO_COD_PRODUTO" , ""},
                    { "SIDOCACO_COD_GRUPO_CAUSA" , ""},
                    { "SIDOCACO_COD_SUBGRUPO_CAUSA" , ""},
                    { "SIMOVSIN_COD_ESTIPULANTE" , ""},
                    { "SIDOCACO_COD_DOCUMENTO" , ""},
                    { "SIPROACO_COD_FASE" , ""},
                    { "SIDOCACO_COD_EVENTO" , ""},
                    { "SIDOCACO_NUM_CARTA" , ""},
                    { "SIDOCACO_COD_USUARIO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1", q5);

                #endregion

                #endregion
                #endregion
                var param1 = new LBWCT001_PROTOCOLO_RECEBIDO();
                param1.IN_OPERACAO.Value = "1";

                var param2 = new SIDOCACO_DCLSI_DOCUMENTO_ACOMP();
                param2.SIDOCACO_COD_FONTE.Value = 1;
                param2.SIDOCACO_NUM_PROTOCOLO_SINI.Value = 1;
                param2.SIDOCACO_COD_DOCUMENTO.Value = 1;
                param2.SIDOCACO_COD_EVENTO.Value = 1;
                param2.SIDOCACO_DATA_MOVTO_DOCACO.Value = "2025-01-01";

                var param3 = new LBWCT002_PROTOCOLO_ENVIO();

                var program = new PTACOM2S();
                program.Execute(param1, param2, param3);

                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT"));
                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0);

                Assert.True(selects.Count() >= allSelects.Count() / 2);

                var insert1 = AppSettings.TestSet.DynamicData["R1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1_Insert1"];
                Assert.True(insert1.DynamicList[1].TryGetValue("SIDOCACO_NUM_PROTOCOLO_SINI", out string value1) && value1.Equals("000000001"));

                var insert2 = AppSettings.TestSet.DynamicData["R1600_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1"];
                Assert.True(insert2.DynamicList[1].TryGetValue("SIDOCACO_NUM_PROTOCOLO_SINI", out string value2) && value1.Equals("000000001"));

                Assert.True(selects.Count() >= allSelects.Count() / 2);

                Assert.True(program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL == 0);
                Assert.True(program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 0);
            }
        }

        [Fact]
        public static void PTACOM2S_Tests_Fact_ReturnCode99()
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
                #region PARAMETERS
                #region R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SIDOCACO_NUM_OCORR_DOCACO" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1_Insert1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SIDOCACO_COD_FONTE" , ""},
                    { "SIDOCACO_NUM_PROTOCOLO_SINI" , ""},
                    { "SIDOCACO_DAC_PROTOCOLO_SINI" , ""},
                    { "SIDOCACO_COD_DOCUMENTO" , ""},
                    { "SIDOCACO_NUM_OCORR_DOCACO" , ""},
                    { "SIDOCACO_COD_PRODUTO" , ""},
                    { "SIDOCACO_COD_GRUPO_CAUSA" , ""},
                    { "SIDOCACO_COD_SUBGRUPO_CAUSA" , ""},
                    { "SIDOCACO_DATA_INIVIG_DOCPAR" , ""},
                    { "SIDOCACO_COD_EVENTO" , ""},
                    { "SIDOCACO_DATA_MOVTO_DOCACO" , ""},
                    { "SIDOCACO_DESCR_COMPLEMENTAR" , ""},
                    { "SIDOCACO_NUM_CARTA" , ""},
                    { "SIDOCACO_COD_USUARIO" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1_Insert1", q1);

                #endregion

                #region R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "SIMOVSIN_COD_ESTIPULANTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1", q2);

                #endregion

                #region R1400_00_MAX_SIPROACO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "SIPROACO_OCORR_HISTORICO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_MAX_SIPROACO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_MAX_SIPROACO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "SICHEPAR_DATA_INIVIGENCIA" , ""},
                    { "SICHEPAR_COD_FASE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1600_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "SIDOCACO_COD_FONTE" , ""},
                    { "SIDOCACO_NUM_PROTOCOLO_SINI" , ""},
                    { "SIDOCACO_DAC_PROTOCOLO_SINI" , ""},
                    { "SIPROACO_OCORR_HISTORICO" , ""},
                    { "SICHEPAR_DATA_INIVIGENCIA" , ""},
                    { "SIDOCACO_DATA_MOVTO_DOCACO" , ""},
                    { "SIDOCACO_COD_PRODUTO" , ""},
                    { "SIDOCACO_COD_GRUPO_CAUSA" , ""},
                    { "SIDOCACO_COD_SUBGRUPO_CAUSA" , ""},
                    { "SIMOVSIN_COD_ESTIPULANTE" , ""},
                    { "SIDOCACO_COD_DOCUMENTO" , ""},
                    { "SIPROACO_COD_FASE" , ""},
                    { "SIDOCACO_COD_EVENTO" , ""},
                    { "SIDOCACO_NUM_CARTA" , ""},
                    { "SIDOCACO_COD_USUARIO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1600_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1600_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1", q5);

                #endregion

                #endregion
                #endregion
                var param1 = new LBWCT001_PROTOCOLO_RECEBIDO();
                param1.IN_OPERACAO.Value = "1";

                var param2 = new SIDOCACO_DCLSI_DOCUMENTO_ACOMP();
                param2.SIDOCACO_COD_FONTE.Value = 1;
                param2.SIDOCACO_NUM_PROTOCOLO_SINI.Value = 1;
                param2.SIDOCACO_COD_DOCUMENTO.Value = 1;
                param2.SIDOCACO_COD_EVENTO.Value = 1;
                param2.SIDOCACO_DATA_MOVTO_DOCACO.Value = "2025-01-01";

                var param3 = new LBWCT002_PROTOCOLO_ENVIO();

                var program = new PTACOM2S();
                program.Execute(param1, param2, param3);

                Assert.True(program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL.Value == 99);
                Assert.True(program.LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO.Value == "0001");
            }
        }
    }
}