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
using static Code.FI0100S;

namespace FileTests.Test
{
    [Collection("FI0100S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class FI0100S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0210_00_ACESSA_CEPFXFIL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTDE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0210_00_ACESSA_CEPFXFIL_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0210_00_ACESSA_CEPFXFIL_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "CEPFXFIL_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0210_00_ACESSA_CEPFXFIL_DB_SELECT_2_Query1", q1);

            #endregion

            #region R0220_00_ACESSA_V1FONTE_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_NOMEFTE" , ""},
                { "V1FONT_PCDESISS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0220_00_ACESSA_V1FONTE_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0210_00_ACESSA_CEPFXFIL_DB_SELECT_3_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "CEPFXFIL_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0210_00_ACESSA_CEPFXFIL_DB_SELECT_3_Query1", q3);

            #endregion

            #region R0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1FAVO_NOMFAV" , ""},
                { "V1FAVO_NUMREC" , ""},
                { "V1FAVO_TPPESSOA" , ""},
                { "V1FAVO_DCOIRF" , ""},
                { "V1FAVO_PCTIRF" , ""},
                { "V1FAVO_CODSVI" , ""},
                { "V1FAVO_TIPREG" , ""},
                { "V1FAVO_INSPREFE" , ""},
                { "V1FAVO_INSESTAD" , ""},
                { "V1FAVO_INSINPS" , ""},
                { "V1FAVO_CGCCPF" , ""},
                { "V1FAVO_DCOISS" , ""},
                { "V1FAVO_NUMDEPIRF" , ""},
                { "V1FAVO_CODSVISS" , ""},
                { "V1FAVO_DCOINSS" , ""},
                { "V1FAVO_PCTINSS" , ""},
                { "V1FAVO_FONTE" , ""},
                { "V1FAVO_CEP" , ""},
                { "V1FAVO_DATA_ALT_CC" , ""},
                { "V1FAVO_PCDESISS" , ""},
                { "V1FAVO_OPT_SIMPLES_M" , ""},
                { "V4FAVO_DATA_NASC" , ""},
                { "V4FAVO_INV_PERMANENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1FAVO_NOMFAV" , ""},
                { "V1FAVO_NUMREC" , ""},
                { "V1FAVO_TPPESSOA" , ""},
                { "V1FAVO_INSPREFE" , ""},
                { "V1FAVO_INSINPS" , ""},
                { "V1FAVO_CGCCPF" , ""},
                { "V1FAVO_DCOIRF" , ""},
                { "V1FAVO_CEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1FAVO_NUMREC" , ""},
                { "V1FAVO_CODFAV" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R0870_00_UPDATE_V1PRODUTOR_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1FAVO_NUMREC" , ""},
                { "V1FAVO_CODFAV" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0870_00_UPDATE_V1PRODUTOR_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1FAVO_CODFAV" , ""},
                { "V1FAVO_NUMREC" , ""},
                { "V0REND_DATRDT" , ""},
                { "V0REND_VALRDT" , ""},
                { "V2FAVO_IDECBT" , ""},
                { "V0REND_CODSVI" , ""},
                { "V0REND_CODEMP" , ""},
                { "V0REND_SITUACAO" , ""},
                { "V1FONT_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1_Insert1", q8);

            #endregion

            #region R0910_00_INSERT_V0IMPOSTOS_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1FAVO_CODFAV" , ""},
                { "V1FAVO_NUMREC" , ""},
                { "V0IMPO_DATIPT" , ""},
                { "V0IMPO_TIPIPT" , ""},
                { "V0IMPO_VALIPT" , ""},
                { "V2FAVO_IDECBT" , ""},
                { "V0IMPO_CODSVI" , ""},
                { "V0IMPO_CODEMP" , ""},
                { "V0IMPO_SITUACAO" , ""},
                { "V1FONT_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0910_00_INSERT_V0IMPOSTOS_DB_INSERT_1_Insert1", q9);

            #endregion

            #region R0930_00_SOMA_RENDIMENTO_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1REND_VALRDT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0930_00_SOMA_RENDIMENTO_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0940_00_SOMA_IMPOSTO_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1IMPO_VLIMPOST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0940_00_SOMA_IMPOSTO_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V3IRF_VALDEP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0946_00_APLICA_DEDUCOES_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V3IRF_VALDEP" , ""},
                { "V4IRF_LIMSUP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0946_00_APLICA_DEDUCOES_DB_SELECT_1_Query1", q13);

            #endregion

            #region R0950_00_ACESSA_V1IRFONTE_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V1IRF_ALQIPT" , ""},
                { "V1IRF_VALDDU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0950_00_ACESSA_V1IRFONTE_DB_SELECT_1_Query1", q14);

            #endregion

            #region R0960_00_ACESSA_IRJ_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V1IRF_ALQIPT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0960_00_ACESSA_IRJ_DB_SELECT_1_Query1", q15);

            #endregion

            #region R0978_00_LE_AGRUPA_CH1_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "AGTABCH1_DESCRICAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0978_00_LE_AGRUPA_CH1_DB_SELECT_1_Query1", q16);

            #endregion

            #endregion
        }

        [Fact]
        public static void FI0100S_Tests_Fact()
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
                #region R0210_00_ACESSA_CEPFXFIL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_QTDE" , "2"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0210_00_ACESSA_CEPFXFIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0210_00_ACESSA_CEPFXFIL_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0210_00_ACESSA_CEPFXFIL_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "CEPFXFIL_FONTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0210_00_ACESSA_CEPFXFIL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0210_00_ACESSA_CEPFXFIL_DB_SELECT_2_Query1", q1);

                #endregion

                #region R0220_00_ACESSA_V1FONTE_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V1FONT_NOMEFTE" , ""},
                    { "V1FONT_PCDESISS" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0220_00_ACESSA_V1FONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0220_00_ACESSA_V1FONTE_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0210_00_ACESSA_CEPFXFIL_DB_SELECT_3_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "CEPFXFIL_FONTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0210_00_ACESSA_CEPFXFIL_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R0210_00_ACESSA_CEPFXFIL_DB_SELECT_3_Query1", q3);

                #endregion

                #region R0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V1FAVO_NOMFAV" , ""},
                    { "V1FAVO_NUMREC" , ""},
                    { "V1FAVO_TPPESSOA" , ""},
                    { "V1FAVO_DCOIRF" , ""},
                    { "V1FAVO_PCTIRF" , ""},
                    { "V1FAVO_CODSVI" , ""},
                    { "V1FAVO_TIPREG" , ""},
                    { "V1FAVO_INSPREFE" , ""},
                    { "V1FAVO_INSESTAD" , ""},
                    { "V1FAVO_INSINPS" , ""},
                    { "V1FAVO_CGCCPF" , ""},
                    { "V1FAVO_DCOISS" , ""},
                    { "V1FAVO_NUMDEPIRF" , ""},
                    { "V1FAVO_CODSVISS" , ""},
                    { "V1FAVO_DCOINSS" , ""},
                    { "V1FAVO_PCTINSS" , ""},
                    { "V1FAVO_FONTE" , ""},
                    { "V1FAVO_CEP" , "10000000"},
                    { "V1FAVO_DATA_ALT_CC" , ""},
                    { "V1FAVO_PCDESISS" , ""},
                    { "V1FAVO_OPT_SIMPLES_M" , ""},
                    { "V4FAVO_DATA_NASC" , ""},
                    { "V4FAVO_INV_PERMANENTE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V1FAVO_NOMFAV" , ""},
                    { "V1FAVO_NUMREC" , ""},
                    { "V1FAVO_TPPESSOA" , ""},
                    { "V1FAVO_INSPREFE" , ""},
                    { "V1FAVO_INSINPS" , ""},
                    { "V1FAVO_CGCCPF" , ""},
                    { "V1FAVO_DCOIRF" , ""},
                    { "V1FAVO_CEP" , "1000000"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1_Update1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V1FAVO_NUMREC" , ""},
                    { "V1FAVO_CODFAV" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1_Update1", q6);

                #endregion

                #region R0870_00_UPDATE_V1PRODUTOR_DB_UPDATE_1_Update1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V1FAVO_NUMREC" , ""},
                    { "V1FAVO_CODFAV" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0870_00_UPDATE_V1PRODUTOR_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0870_00_UPDATE_V1PRODUTOR_DB_UPDATE_1_Update1", q7);

                #endregion

                #region R0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1_Insert1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V1FAVO_CODFAV" , ""},
                    { "V1FAVO_NUMREC" , ""},
                    { "V0REND_DATRDT" , ""},
                    { "V0REND_VALRDT" , ""},
                    { "V2FAVO_IDECBT" , ""},
                    { "V0REND_CODSVI" , ""},
                    { "V0REND_CODEMP" , ""},
                    { "V0REND_SITUACAO" , ""},
                    { "V1FONT_FONTE" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1_Insert1", q8);

                #endregion

                #region R0910_00_INSERT_V0IMPOSTOS_DB_INSERT_1_Insert1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "V1FAVO_CODFAV" , ""},
                    { "V1FAVO_NUMREC" , ""},
                    { "V0IMPO_DATIPT" , ""},
                    { "V0IMPO_TIPIPT" , ""},
                    { "V0IMPO_VALIPT" , ""},
                    { "V2FAVO_IDECBT" , ""},
                    { "V0IMPO_CODSVI" , ""},
                    { "V0IMPO_CODEMP" , ""},
                    { "V0IMPO_SITUACAO" , ""},
                    { "V1FONT_FONTE" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0910_00_INSERT_V0IMPOSTOS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0910_00_INSERT_V0IMPOSTOS_DB_INSERT_1_Insert1", q9);

                #endregion

                #region R0930_00_SOMA_RENDIMENTO_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "V1REND_VALRDT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0930_00_SOMA_RENDIMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0930_00_SOMA_RENDIMENTO_DB_SELECT_1_Query1", q10);

                #endregion

                #region R0940_00_SOMA_IMPOSTO_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V1IMPO_VLIMPOST" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0940_00_SOMA_IMPOSTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0940_00_SOMA_IMPOSTO_DB_SELECT_1_Query1", q11);

                #endregion

                #region R0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "V3IRF_VALDEP" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1_Query1", q12);

                #endregion

                #region R0946_00_APLICA_DEDUCOES_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "V3IRF_VALDEP" , ""},
                    { "V4IRF_LIMSUP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0946_00_APLICA_DEDUCOES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0946_00_APLICA_DEDUCOES_DB_SELECT_1_Query1", q13);

                #endregion

                #region R0950_00_ACESSA_V1IRFONTE_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "V1IRF_ALQIPT" , ""},
                    { "V1IRF_VALDDU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0950_00_ACESSA_V1IRFONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0950_00_ACESSA_V1IRFONTE_DB_SELECT_1_Query1", q14);

                #endregion

                #region R0960_00_ACESSA_IRJ_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "V1IRF_ALQIPT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0960_00_ACESSA_IRJ_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0960_00_ACESSA_IRJ_DB_SELECT_1_Query1", q15);

                #endregion

                #region R0978_00_LE_AGRUPA_CH1_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "AGTABCH1_DESCRICAO" , ""}
                });
                q16.AddDynamic(new Dictionary<string, string>{
                    { "AGTABCH1_DESCRICAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0978_00_LE_AGRUPA_CH1_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0978_00_LE_AGRUPA_CH1_DB_SELECT_1_Query1", q16);

                #endregion

                #endregion
                #endregion
                var param = new FI0100S_LK_IMPOSTOS();
                param.LK_ATUALIZA.Value = "S";
                param.LK_IDTRIBUTA.Value = "S";
                //param.LK_PROGRAMA.Value = "FI0100S";
                param.LK_PROGRAMA.Value = "FI0009B";
                param.LK_TIPFAV.Value = "2";
                param.LK_TIPREG.Value = "1";
                param.LK_CODFAV.Value = 1;
                param.LK_VALBRU.Value = 100;
                param.LK_DTMOVABE.Value = "2025-01-01";
                param.LK_FONTE.Value = 1;
                param.LK_DCOISS.Value = "S";
                param.LK_VALINSS.Value = 1;
                param.LK_VALDDUDEP.Value = 1;

                var program = new FI0100S();
                program.Execute(param);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();

                Assert.True(selects.Count >= 5);
                Assert.True(inserts.Count >= allInserts.Count / 2);
                Assert.True(updates.Count >= allUpdates.Count / 2);

                Assert.True(AppSettings.TestSet.DynamicData["R0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1_Insert1"].DynamicList[1].TryGetValue("V1FAVO_CODFAV", out string value1) && value1.Equals("000000001"));
                Assert.True(AppSettings.TestSet.DynamicData["R0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1_Update1"].DynamicList[1].TryGetValue("V1FAVO_NUMREC", out string value2) && value2.Equals("000000001"));

                Assert.True(program.RETURN_CODE.Value == 0);
            }
        }

        [Fact]
        public static void FI0100S_Tests_Fact_ReturnCode99()
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
                #region R0210_00_ACESSA_CEPFXFIL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_QTDE" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0210_00_ACESSA_CEPFXFIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0210_00_ACESSA_CEPFXFIL_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0210_00_ACESSA_CEPFXFIL_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "CEPFXFIL_FONTE" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0210_00_ACESSA_CEPFXFIL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0210_00_ACESSA_CEPFXFIL_DB_SELECT_2_Query1", q1);

                #endregion

                #region R0220_00_ACESSA_V1FONTE_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V1FONT_NOMEFTE" , ""},
                    { "V1FONT_PCDESISS" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0220_00_ACESSA_V1FONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0220_00_ACESSA_V1FONTE_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0210_00_ACESSA_CEPFXFIL_DB_SELECT_3_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "CEPFXFIL_FONTE" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0210_00_ACESSA_CEPFXFIL_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R0210_00_ACESSA_CEPFXFIL_DB_SELECT_3_Query1", q3);

                #endregion

                #region R0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V1FAVO_NOMFAV" , ""},
                    { "V1FAVO_NUMREC" , ""},
                    { "V1FAVO_TPPESSOA" , ""},
                    { "V1FAVO_DCOIRF" , ""},
                    { "V1FAVO_PCTIRF" , ""},
                    { "V1FAVO_CODSVI" , ""},
                    { "V1FAVO_TIPREG" , ""},
                    { "V1FAVO_INSPREFE" , ""},
                    { "V1FAVO_INSESTAD" , ""},
                    { "V1FAVO_INSINPS" , ""},
                    { "V1FAVO_CGCCPF" , ""},
                    { "V1FAVO_DCOISS" , ""},
                    { "V1FAVO_NUMDEPIRF" , ""},
                    { "V1FAVO_CODSVISS" , ""},
                    { "V1FAVO_DCOINSS" , ""},
                    { "V1FAVO_PCTINSS" , ""},
                    { "V1FAVO_FONTE" , ""},
                    { "V1FAVO_CEP" , "10000000"},
                    { "V1FAVO_DATA_ALT_CC" , ""},
                    { "V1FAVO_PCDESISS" , ""},
                    { "V1FAVO_OPT_SIMPLES_M" , ""},
                    { "V4FAVO_DATA_NASC" , ""},
                    { "V4FAVO_INV_PERMANENTE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V1FAVO_NOMFAV" , ""},
                    { "V1FAVO_NUMREC" , ""},
                    { "V1FAVO_TPPESSOA" , ""},
                    { "V1FAVO_INSPREFE" , ""},
                    { "V1FAVO_INSINPS" , ""},
                    { "V1FAVO_CGCCPF" , ""},
                    { "V1FAVO_DCOIRF" , ""},
                    { "V1FAVO_CEP" , "1000000"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1_Update1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V1FAVO_NUMREC" , ""},
                    { "V1FAVO_CODFAV" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1_Update1", q6);

                #endregion

                #region R0870_00_UPDATE_V1PRODUTOR_DB_UPDATE_1_Update1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V1FAVO_NUMREC" , ""},
                    { "V1FAVO_CODFAV" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0870_00_UPDATE_V1PRODUTOR_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0870_00_UPDATE_V1PRODUTOR_DB_UPDATE_1_Update1", q7);

                #endregion

                #region R0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1_Insert1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V1FAVO_CODFAV" , ""},
                    { "V1FAVO_NUMREC" , ""},
                    { "V0REND_DATRDT" , ""},
                    { "V0REND_VALRDT" , ""},
                    { "V2FAVO_IDECBT" , ""},
                    { "V0REND_CODSVI" , ""},
                    { "V0REND_CODEMP" , ""},
                    { "V0REND_SITUACAO" , ""},
                    { "V1FONT_FONTE" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1_Insert1", q8);

                #endregion

                #region R0910_00_INSERT_V0IMPOSTOS_DB_INSERT_1_Insert1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "V1FAVO_CODFAV" , ""},
                    { "V1FAVO_NUMREC" , ""},
                    { "V0IMPO_DATIPT" , ""},
                    { "V0IMPO_TIPIPT" , ""},
                    { "V0IMPO_VALIPT" , ""},
                    { "V2FAVO_IDECBT" , ""},
                    { "V0IMPO_CODSVI" , ""},
                    { "V0IMPO_CODEMP" , ""},
                    { "V0IMPO_SITUACAO" , ""},
                    { "V1FONT_FONTE" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0910_00_INSERT_V0IMPOSTOS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0910_00_INSERT_V0IMPOSTOS_DB_INSERT_1_Insert1", q9);

                #endregion

                #region R0930_00_SOMA_RENDIMENTO_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "V1REND_VALRDT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0930_00_SOMA_RENDIMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0930_00_SOMA_RENDIMENTO_DB_SELECT_1_Query1", q10);

                #endregion

                #region R0940_00_SOMA_IMPOSTO_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V1IMPO_VLIMPOST" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0940_00_SOMA_IMPOSTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0940_00_SOMA_IMPOSTO_DB_SELECT_1_Query1", q11);

                #endregion

                #region R0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "V3IRF_VALDEP" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1_Query1", q12);

                #endregion

                #region R0946_00_APLICA_DEDUCOES_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "V3IRF_VALDEP" , ""},
                    { "V4IRF_LIMSUP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0946_00_APLICA_DEDUCOES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0946_00_APLICA_DEDUCOES_DB_SELECT_1_Query1", q13);

                #endregion

                #region R0950_00_ACESSA_V1IRFONTE_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "V1IRF_ALQIPT" , ""},
                    { "V1IRF_VALDDU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0950_00_ACESSA_V1IRFONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0950_00_ACESSA_V1IRFONTE_DB_SELECT_1_Query1", q14);

                #endregion

                #region R0960_00_ACESSA_IRJ_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "V1IRF_ALQIPT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0960_00_ACESSA_IRJ_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0960_00_ACESSA_IRJ_DB_SELECT_1_Query1", q15);

                #endregion

                #region R0978_00_LE_AGRUPA_CH1_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "AGTABCH1_DESCRICAO" , ""}
                });
                q16.AddDynamic(new Dictionary<string, string>{
                    { "AGTABCH1_DESCRICAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0978_00_LE_AGRUPA_CH1_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0978_00_LE_AGRUPA_CH1_DB_SELECT_1_Query1", q16);

                #endregion

                #endregion
                #endregion
                var param = new FI0100S_LK_IMPOSTOS();
                param.LK_IDTRIBUTA.Value = "S";
                param.LK_PROGRAMA.Value = "FI0009B";
                param.LK_TIPFAV.Value = "2";
                param.LK_TIPREG.Value = "1";
                param.LK_CODFAV.Value = 1;
                param.LK_VALBRU.Value = 100;
                param.LK_DTMOVABE.Value = "2025-01-01";
                param.LK_FONTE.Value = 1;
                param.LK_DCOISS.Value = "S";
                param.LK_VALINSS.Value = 1;
                param.LK_VALDDUDEP.Value = 1;

                var program = new FI0100S();
                program.Execute(param);

                Assert.True(program.RETURN_CODE.Value == 99);
            }
        }
    }
}