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
using Code;
using static Code.SI0031B;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0031B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0031B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region SI0031B_JOIN_1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "H_SIDOCACO_COD_FONTE" , ""},
                { "H_SIDOCACO_NUM_PROTOCOLO_SINI" , ""},
                { "H_SIDOCACO_DAC_PROTOCOLO_SINI" , ""},
                { "H_SIDOCACO_COD_DOCUMENTO" , ""},
                { "H_SIDOCACO_NUM_OCORR_DOCACO" , ""},
                { "H_SIDOCACO_COD_PRODUTO" , ""},
                { "H_SIDOCACO_COD_GRUPO_CAUSA" , ""},
                { "H_SIDOCACO_COD_SUBGRUPO_CAUSA" , ""},
                { "H_SIDOCACO_DATA_INIVIG_DOCPAR" , ""},
                { "H_SIDOCACO_DATA_MOVTO_DOCACO" , ""},
                { "H_SIDOCACO_NUM_CARTA" , ""},
                { "SIDOCPAR_COD_TIPO_CARTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0031B_JOIN_1", q1);

            #endregion

            #region SI0031B_C01_SISINFAS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISINFAS_COD_FASE" , ""},
                { "SISINFAS_NUM_OCORR_SINIACO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0031B_C01_SISINFAS", q2);

            #endregion

            #region R1100_00_LE_MOVIMENTO_SINI_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SIMOVSIN_COD_ESTIPULANTE" , ""},
                { "SIMOVSIN_COD_GIAFI" , ""},
                { "SIMOVSIN_NOME_PROCURADOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_LE_MOVIMENTO_SINI_DB_SELECT_1_Query1", q3);

            #endregion

            #region SI0031B_CARDEST

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "GERECADE_COD_DESTINATARIO" , ""},
                { "GERECADE_IND_DEST_PRINC" , ""},
                { "GEDESTIN_NOME_DESTINATARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0031B_CARDEST", q4);

            #endregion

            #region R2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "GECARPAR_PRAZO_REITERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R2200_00_LE_EVENTO_TIPO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SIEVETIP_COD_EVENTO" , ""},
                { "SIEVETIP_IND_SINISTRO_ACOMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_LE_EVENTO_TIPO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R2400_00_VERIFICA_LVI_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SIDOCACO_COD_EVENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_VERIFICA_LVI_DB_SELECT_1_Query1", q7);

            #endregion

            #region R3100_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1", q8);

            #endregion

            #region R3300_00_CONTA_SIDOCACO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3300_00_CONTA_SIDOCACO_DB_SELECT_1_Query1", q9);

            #endregion

            #region R3400_00_LE_CARTA_ACOMP_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "GECARACO_COD_EVENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3400_00_LE_CARTA_ACOMP_DB_SELECT_1_Query1", q10);

            #endregion

            #region R4050_00_LE_CARTA_DEST_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "GERECADE_COD_DESTINATARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4050_00_LE_CARTA_DEST_DB_SELECT_1_Query1", q11);

            #endregion

            #region R4100_00_LE_CARTA_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "GECARTA_COD_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4100_00_LE_CARTA_DB_SELECT_1_Query1", q12);

            #endregion

            #region R4150_00_LE_ANALISTA_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "SIANAROD_COD_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4150_00_LE_ANALISTA_DB_SELECT_1_Query1", q13);

            #endregion

            #region R4200_00_LE_CARTA_TEXTO_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "GECARTEX_TEXTO_CARTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4200_00_LE_CARTA_TEXTO_DB_SELECT_1_Query1", q14);

            #endregion

            #region R4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "GECARTA_SEQ_CARTA_REITERA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1_Query1", q15);

            #endregion

            #endregion
        }

        [Fact]
        public static void SI0031B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                PTCARTAS_Tests.Load_Parameters();

                #region R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1

                var qptacomps1 = new DynamicData();
                qptacomps1.AddDynamic(new Dictionary<string, string>{
                    { "GECARACO_NUM_OCORR_CARTACO" , ""}
                });
                qptacomps1.AddDynamic(new Dictionary<string, string>{
                    { "GECARACO_NUM_OCORR_CARTACO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1", qptacomps1);

                #endregion

                #region R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1

                var ptacom2s_1 = new DynamicData();
                ptacom2s_1.AddDynamic(new Dictionary<string, string>{
                    { "SIMOVSIN_COD_ESTIPULANTE" , ""}
                });
                ptacom2s_1.AddDynamic(new Dictionary<string, string>{
                    { "SIMOVSIN_COD_ESTIPULANTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1", ptacom2s_1);

                #endregion

                #region R1400_00_MAX_SIPROACO_DB_SELECT_1_Query1

                var ptacom2s_2 = new DynamicData();
                ptacom2s_2.AddDynamic(new Dictionary<string, string>{
                    { "SIPROACO_OCORR_HISTORICO" , ""}
                });
                ptacom2s_2.AddDynamic(new Dictionary<string, string>{
                    { "SIPROACO_OCORR_HISTORICO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_MAX_SIPROACO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_MAX_SIPROACO_DB_SELECT_1_Query1", ptacom2s_1);
                #endregion

                #region R1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1

                var ptacom2s_3 = new DynamicData();
                ptacom2s_3.AddDynamic(new Dictionary<string, string>{
                    { "SICHEPAR_DATA_INIVIGENCIA" , ""},
                    { "SICHEPAR_COD_FASE" , ""},
                });
                ptacom2s_3.AddDynamic(new Dictionary<string, string>{
                    { "SICHEPAR_DATA_INIVIGENCIA" , ""},
                    { "SICHEPAR_COD_FASE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1", ptacom2s_3);

                #endregion

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE#region PARAMETERS
                #region R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2025-05-09"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0031B_JOIN_1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "H_SIDOCACO_COD_FONTE" , "10"},
                    { "H_SIDOCACO_NUM_PROTOCOLO_SINI" , "9792788"},
                    { "H_SIDOCACO_DAC_PROTOCOLO_SINI" , "0"},
                    { "H_SIDOCACO_COD_DOCUMENTO" , "38"},
                    { "H_SIDOCACO_NUM_OCORR_DOCACO" , ""},
                    { "H_SIDOCACO_COD_PRODUTO" , ""},
                    { "H_SIDOCACO_COD_GRUPO_CAUSA" , ""},
                    { "H_SIDOCACO_COD_SUBGRUPO_CAUSA" , ""},
                    { "H_SIDOCACO_DATA_INIVIG_DOCPAR" , ""},
                    { "H_SIDOCACO_DATA_MOVTO_DOCACO" , ""},
                    { "H_SIDOCACO_NUM_CARTA" , ""},
                    { "SIDOCPAR_COD_TIPO_CARTA" , "3"},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0031B_JOIN_1");
                AppSettings.TestSet.DynamicData.Add("SI0031B_JOIN_1", q1);

                #endregion

                #region SI0031B_C01_SISINFAS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "SISINFAS_COD_FASE" , ""},
                    { "SISINFAS_NUM_OCORR_SINIACO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0031B_C01_SISINFAS");
                AppSettings.TestSet.DynamicData.Add("SI0031B_C01_SISINFAS", q2);

                #endregion

                #region R1100_00_LE_MOVIMENTO_SINI_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "SIMOVSIN_COD_ESTIPULANTE" , ""},
                    { "SIMOVSIN_COD_GIAFI" , ""},
                    { "SIMOVSIN_NOME_PROCURADOR" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                    { "SIMOVSIN_COD_ESTIPULANTE" , ""},
                    { "SIMOVSIN_COD_GIAFI" , ""},
                    { "SIMOVSIN_NOME_PROCURADOR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_MOVIMENTO_SINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_MOVIMENTO_SINI_DB_SELECT_1_Query1", q3);

                #endregion

                #region SI0031B_CARDEST

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "GERECADE_COD_DESTINATARIO" , ""},
                    { "GERECADE_IND_DEST_PRINC" , ""},
                    { "GEDESTIN_NOME_DESTINATARIO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0031B_CARDEST");
                AppSettings.TestSet.DynamicData.Add("SI0031B_CARDEST", q4);

                #endregion

                #region R2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "GECARPAR_PRAZO_REITERACAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R2200_00_LE_EVENTO_TIPO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "SIEVETIP_COD_EVENTO" , "1"},
                    { "SIEVETIP_IND_SINISTRO_ACOMP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_LE_EVENTO_TIPO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_LE_EVENTO_TIPO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R2400_00_VERIFICA_LVI_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "SIDOCACO_COD_EVENTO" , "2013"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2400_00_VERIFICA_LVI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_VERIFICA_LVI_DB_SELECT_1_Query1", q7);

                #endregion

                #region R3100_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "HOST_COUNT" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3100_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1", q8);

                #endregion

                #region R3300_00_CONTA_SIDOCACO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "HOST_COUNT" , ""}
                });
                q9.AddDynamic(new Dictionary<string, string>{
                    { "HOST_COUNT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R3300_00_CONTA_SIDOCACO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3300_00_CONTA_SIDOCACO_DB_SELECT_1_Query1", q9);

                #endregion

                #region R3400_00_LE_CARTA_ACOMP_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "GECARACO_COD_EVENTO" , "2"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3400_00_LE_CARTA_ACOMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3400_00_LE_CARTA_ACOMP_DB_SELECT_1_Query1", q10);

                #endregion

                #region R4050_00_LE_CARTA_DEST_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "GERECADE_COD_DESTINATARIO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R4050_00_LE_CARTA_DEST_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4050_00_LE_CARTA_DEST_DB_SELECT_1_Query1", q11);

                #endregion

                #region R4100_00_LE_CARTA_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "GECARTA_COD_USUARIO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R4100_00_LE_CARTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4100_00_LE_CARTA_DB_SELECT_1_Query1", q12);

                #endregion

                #region R4150_00_LE_ANALISTA_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "SIANAROD_COD_USUARIO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R4150_00_LE_ANALISTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4150_00_LE_ANALISTA_DB_SELECT_1_Query1", q13);

                #endregion

                #region R4200_00_LE_CARTA_TEXTO_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "GECARTEX_TEXTO_CARTA" , "TEXTO"}
                });
                AppSettings.TestSet.DynamicData.Remove("R4200_00_LE_CARTA_TEXTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4200_00_LE_CARTA_TEXTO_DB_SELECT_1_Query1", q14);

                #endregion

                #region R4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "GECARTA_SEQ_CARTA_REITERA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1_Query1", q15);

                #endregion
                #endregion
                var program = new SI0031B();
                program.Execute();

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void SI0031B_Tests_Fact_ReturnCode99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                PTCARTAS_Tests.Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE#region PARAMETERS
                #region R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2025-05-09"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0031B_JOIN_1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "H_SIDOCACO_COD_FONTE" , "10"},
                    { "H_SIDOCACO_NUM_PROTOCOLO_SINI" , "9792788"},
                    { "H_SIDOCACO_DAC_PROTOCOLO_SINI" , "0"},
                    { "H_SIDOCACO_COD_DOCUMENTO" , "38"},
                    { "H_SIDOCACO_NUM_OCORR_DOCACO" , ""},
                    { "H_SIDOCACO_COD_PRODUTO" , ""},
                    { "H_SIDOCACO_COD_GRUPO_CAUSA" , ""},
                    { "H_SIDOCACO_COD_SUBGRUPO_CAUSA" , ""},
                    { "H_SIDOCACO_DATA_INIVIG_DOCPAR" , ""},
                    { "H_SIDOCACO_DATA_MOVTO_DOCACO" , ""},
                    { "H_SIDOCACO_NUM_CARTA" , ""},
                    { "SIDOCPAR_COD_TIPO_CARTA" , "2"},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("SI0031B_JOIN_1");
                AppSettings.TestSet.DynamicData.Add("SI0031B_JOIN_1", q1);

                #endregion

                #region SI0031B_C01_SISINFAS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "SISINFAS_COD_FASE" , ""},
                    { "SISINFAS_NUM_OCORR_SINIACO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0031B_C01_SISINFAS");
                AppSettings.TestSet.DynamicData.Add("SI0031B_C01_SISINFAS", q2);

                #endregion

                #region R1100_00_LE_MOVIMENTO_SINI_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "SIMOVSIN_COD_ESTIPULANTE" , ""},
                    { "SIMOVSIN_COD_GIAFI" , ""},
                    { "SIMOVSIN_NOME_PROCURADOR" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                    { "SIMOVSIN_COD_ESTIPULANTE" , ""},
                    { "SIMOVSIN_COD_GIAFI" , ""},
                    { "SIMOVSIN_NOME_PROCURADOR" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_LE_MOVIMENTO_SINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_LE_MOVIMENTO_SINI_DB_SELECT_1_Query1", q3);

                #endregion

                #region SI0031B_CARDEST

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "GERECADE_COD_DESTINATARIO" , ""},
                    { "GERECADE_IND_DEST_PRINC" , ""},
                    { "GEDESTIN_NOME_DESTINATARIO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0031B_CARDEST");
                AppSettings.TestSet.DynamicData.Add("SI0031B_CARDEST", q4);

                #endregion

                #region R2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "GECARPAR_PRAZO_REITERACAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1_Query1", q5);

                #endregion

                #region R2200_00_LE_EVENTO_TIPO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "SIEVETIP_COD_EVENTO" , "1"},
                    { "SIEVETIP_IND_SINISTRO_ACOMP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_LE_EVENTO_TIPO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_LE_EVENTO_TIPO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R2400_00_VERIFICA_LVI_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "SIDOCACO_COD_EVENTO" , "2013"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2400_00_VERIFICA_LVI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2400_00_VERIFICA_LVI_DB_SELECT_1_Query1", q7);

                #endregion

                #region R3100_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "HOST_COUNT" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3100_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1", q8);

                #endregion

                #region R3300_00_CONTA_SIDOCACO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "HOST_COUNT" , ""}
                });
                q9.AddDynamic(new Dictionary<string, string>{
                    { "HOST_COUNT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R3300_00_CONTA_SIDOCACO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3300_00_CONTA_SIDOCACO_DB_SELECT_1_Query1", q9);

                #endregion

                #region R3400_00_LE_CARTA_ACOMP_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "GECARACO_COD_EVENTO" , "2"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3400_00_LE_CARTA_ACOMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3400_00_LE_CARTA_ACOMP_DB_SELECT_1_Query1", q10);

                #endregion

                #region R4050_00_LE_CARTA_DEST_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "GERECADE_COD_DESTINATARIO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R4050_00_LE_CARTA_DEST_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4050_00_LE_CARTA_DEST_DB_SELECT_1_Query1", q11);

                #endregion

                #region R4100_00_LE_CARTA_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "GECARTA_COD_USUARIO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R4100_00_LE_CARTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4100_00_LE_CARTA_DB_SELECT_1_Query1", q12);

                #endregion

                #region R4150_00_LE_ANALISTA_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "SIANAROD_COD_USUARIO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R4150_00_LE_ANALISTA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4150_00_LE_ANALISTA_DB_SELECT_1_Query1", q13);

                #endregion

                #region R4200_00_LE_CARTA_TEXTO_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "GECARTEX_TEXTO_CARTA" , "TEXTO"}
                });
                AppSettings.TestSet.DynamicData.Remove("R4200_00_LE_CARTA_TEXTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4200_00_LE_CARTA_TEXTO_DB_SELECT_1_Query1", q14);

                #endregion

                #region R4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "GECARTA_SEQ_CARTA_REITERA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1_Query1", q15);

                #endregion
                #endregion
                var program = new SI0031B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}