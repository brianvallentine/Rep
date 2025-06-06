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
using static Code.FC0038B;

namespace FileTests.Test
{
    [Collection("FC0038B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class FC0038B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_ACESSA_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""},
                { "WHOST_DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_ACESSA_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0120_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""},
                { "WHOST_PROXIMA_DATA" , ""},
                { "CALENDAR_DIA_SEMANA" , ""},
                { "CALENDAR_FERIADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0120_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1", q1);

            #endregion

            #region FC0038B_V0FAIXACEP

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0FCEP_FAIXA" , ""},
                { "V0FCEP_CEPINI" , ""},
                { "V0FCEP_CEPFIM" , ""},
                { "V0FCEP_DESC_FAIXA" , ""},
                { "V0FCEP_CENTRALIZADOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("FC0038B_V0FAIXACEP", q2);

            #endregion

            #region R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_NRCOPIAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1", q3);

            #endregion

            #region B0300_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_CODUSU" , ""},
                { "V0RELA_DATA_SOLICITACAO" , ""},
                { "V0RELA_IDSISTEM" , ""},
                { "V0RELA_CODRELAT" , ""},
                { "V0RELA_NRCOPIAS" , ""},
                { "V0RELA_QUANTIDADE" , ""},
                { "V0RELA_PERI_INICIAL" , ""},
                { "V0RELA_PERI_FINAL" , ""},
                { "V0RELA_DATA_REFERENCIA" , ""},
                { "V0RELA_MES_REFERENCIA" , ""},
                { "V0RELA_ANO_REFERENCIA" , ""},
                { "V0RELA_ORGAO" , ""},
                { "V0RELA_FONTE" , ""},
                { "V0RELA_CODPDT" , ""},
                { "V0RELA_RAMO" , ""},
                { "V0RELA_MODALIDA" , ""},
                { "V0RELA_CONGENER" , ""},
                { "V0RELA_NUM_APOLICE" , ""},
                { "V0RELA_NRENDOS" , ""},
                { "V0RELA_NRPARCEL" , ""},
                { "V0RELA_NRCERTIF" , ""},
                { "V0RELA_NRTIT" , ""},
                { "V0RELA_CODSUBES" , ""},
                { "V0RELA_OPERACAO" , ""},
                { "V0RELA_COD_PLANO" , ""},
                { "V0RELA_OCORHIST" , ""},
                { "V0RELA_APOLIDER" , ""},
                { "V0RELA_ENDOSLID" , ""},
                { "V0RELA_NUM_PARC_LIDER" , ""},
                { "V0RELA_NUM_SINISTRO" , ""},
                { "V0RELA_NUM_SINI_LIDER" , ""},
                { "V0RELA_NUM_ORDEM" , ""},
                { "V0RELA_CODUNIMO" , ""},
                { "V0RELA_CORRECAO" , ""},
                { "V0RELA_SITUACAO" , ""},
                { "V0RELA_PREVIA_DEFINITIVA" , ""},
                { "V0RELA_ANAL_RESUMO" , ""},
                { "V0RELA_COD_EMPRESA" , ""},
                { "V0RELA_PERI_RENOVACAO" , ""},
                { "V0RELA_PCT_AUMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("B0300_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1", q4);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("123456789", "123456789", "FC0038B_1_t1", "FC0038B_2_t1", "FC0038B_3_t1")]
        public static void FC0038B_Tests_Theory_ReturnCode00(string ENTRADA_FILE_NAME_P, string ARQCARTA_FILE_NAME_P, string RFC0038B1_FILE_NAME_P, string RFC0038B2_FILE_NAME_P, string CEPERROS_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RFC0038B1_FILE_NAME_P = $"{RFC0038B1_FILE_NAME_P}_{timestamp}.txt";
            RFC0038B2_FILE_NAME_P = $"{RFC0038B2_FILE_NAME_P}_{timestamp}.txt";
            CEPERROS_FILE_NAME_P = $"{CEPERROS_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0100_00_ACESSA_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , "0"},
                { "WHOST_DTMOVABE" , "0"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_ACESSA_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_ACESSA_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0120_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "2025-01-01"},
                { "WHOST_PROXIMA_DATA" , "0"},
                { "CALENDAR_DIA_SEMANA" , "0"},
                { "CALENDAR_FERIADO" , "0"},
            });
                AppSettings.TestSet.DynamicData.Remove("R0120_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0120_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1", q1);

                #endregion

                #region FC0038B_V0FAIXACEP

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0FCEP_FAIXA" , "0"},
                { "V0FCEP_CEPINI" , "0"},
                { "V0FCEP_CEPFIM" , "0"},
                { "V0FCEP_DESC_FAIXA" , "0"},
                { "V0FCEP_CENTRALIZADOR" , "0"},
            });
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0FCEP_FAIXA" , "0"},
                { "V0FCEP_CEPINI" , "0"},
                { "V0FCEP_CEPFIM" , "0"},
                { "V0FCEP_DESC_FAIXA" , "0"},
                { "V0FCEP_CENTRALIZADOR" , "0"},
            });
                AppSettings.TestSet.DynamicData.Remove("FC0038B_V0FAIXACEP");
                AppSettings.TestSet.DynamicData.Add("FC0038B_V0FAIXACEP", q2);

                #endregion

                #region R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_NRCOPIAS" , "0"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1", q3);

                #endregion

                #region B0300_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_CODUSU" , "0"},
                { "V0RELA_DATA_SOLICITACAO" , "0"},
                { "V0RELA_IDSISTEM" , "0"},
                { "V0RELA_CODRELAT" , "0"},
                { "V0RELA_NRCOPIAS" , "0"},
                { "V0RELA_QUANTIDADE" , "0"},
                { "V0RELA_PERI_INICIAL" , "0"},
                { "V0RELA_PERI_FINAL" , "0"},
                { "V0RELA_DATA_REFERENCIA" , "0"},
                { "V0RELA_MES_REFERENCIA" , "0"},
                { "V0RELA_ANO_REFERENCIA" , "0"},
                { "V0RELA_ORGAO" , "0"},
                { "V0RELA_FONTE" , "0"},
                { "V0RELA_CODPDT" , "0"},
                { "V0RELA_RAMO" , "0"},
                { "V0RELA_MODALIDA" , "0"},
                { "V0RELA_CONGENER" , "0"},
                { "V0RELA_NUM_APOLICE" , "0"},
                { "V0RELA_NRENDOS" , "0"},
                { "V0RELA_NRPARCEL" , "0"},
                { "V0RELA_NRCERTIF" , "0"},
                { "V0RELA_NRTIT" , "0"},
                { "V0RELA_CODSUBES" , "0"},
                { "V0RELA_OPERACAO" , "0"},
                { "V0RELA_COD_PLANO" , "0"},
                { "V0RELA_OCORHIST" , "0"},
                { "V0RELA_APOLIDER" , "0"},
                { "V0RELA_ENDOSLID" , "0"},
                { "V0RELA_NUM_PARC_LIDER" , "0"},
                { "V0RELA_NUM_SINISTRO" , "0"},
                { "V0RELA_NUM_SINI_LIDER" , "0"},
                { "V0RELA_NUM_ORDEM" , "0"},
                { "V0RELA_CODUNIMO" , "0"},
                { "V0RELA_CORRECAO" , "0"},
                { "V0RELA_SITUACAO" , "0"},
                { "V0RELA_PREVIA_DEFINITIVA" , "0"},
                { "V0RELA_ANAL_RESUMO" , "0"},
                { "V0RELA_COD_EMPRESA" , "0"},
                { "V0RELA_PERI_RENOVACAO" , "0"},
                { "V0RELA_PCT_AUMENTO" , "0"},
            });
                AppSettings.TestSet.DynamicData.Remove("B0300_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("B0300_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1", q4);

                #endregion
                #endregion
                var program = new FC0038B();
                
                program.Execute(ENTRADA_FILE_NAME_P, ARQCARTA_FILE_NAME_P, RFC0038B1_FILE_NAME_P, RFC0038B2_FILE_NAME_P, CEPERROS_FILE_NAME_P);


                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                Assert.True(selects.Count >= allSelects.Count / 2);


                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Theory]
        [InlineData("123456789", "123456789", "FC0038B_1_t2", "FC0038B_2_t2", "FC0038B_3_t2")]
        public static void FC0038B_Tests_Theory_ReturnCode99(string ENTRADA_FILE_NAME_P, string ARQCARTA_FILE_NAME_P, string RFC0038B1_FILE_NAME_P, string RFC0038B2_FILE_NAME_P, string CEPERROS_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RFC0038B1_FILE_NAME_P = $"{RFC0038B1_FILE_NAME_P}_{timestamp}.txt";
            RFC0038B2_FILE_NAME_P = $"{RFC0038B2_FILE_NAME_P}_{timestamp}.txt";
            CEPERROS_FILE_NAME_P = $"{CEPERROS_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0100_00_ACESSA_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""},
                { "WHOST_DTMOVABE" , ""},
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_ACESSA_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_ACESSA_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0120_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""},
                { "WHOST_PROXIMA_DATA" , ""},
                { "CALENDAR_DIA_SEMANA" , ""},
                { "CALENDAR_FERIADO" , ""},
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0120_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0120_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1", q1);

                #endregion

                #region FC0038B_V0FAIXACEP

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0FCEP_FAIXA" , ""},
                { "V0FCEP_CEPINI" , ""},
                { "V0FCEP_CEPFIM" , ""},
                { "V0FCEP_DESC_FAIXA" , ""},
                { "V0FCEP_CENTRALIZADOR" , ""},
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("FC0038B_V0FAIXACEP");
                AppSettings.TestSet.DynamicData.Add("FC0038B_V0FAIXACEP", q2);

                #endregion

                #region R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_NRCOPIAS" , ""}
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1", q3);

                #endregion

                #region B0300_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_CODUSU" , ""},
                { "V0RELA_DATA_SOLICITACAO" , ""},
                { "V0RELA_IDSISTEM" , ""},
                { "V0RELA_CODRELAT" , ""},
                { "V0RELA_NRCOPIAS" , ""},
                { "V0RELA_QUANTIDADE" , ""},
                { "V0RELA_PERI_INICIAL" , ""},
                { "V0RELA_PERI_FINAL" , ""},
                { "V0RELA_DATA_REFERENCIA" , ""},
                { "V0RELA_MES_REFERENCIA" , ""},
                { "V0RELA_ANO_REFERENCIA" , ""},
                { "V0RELA_ORGAO" , ""},
                { "V0RELA_FONTE" , ""},
                { "V0RELA_CODPDT" , ""},
                { "V0RELA_RAMO" , ""},
                { "V0RELA_MODALIDA" , ""},
                { "V0RELA_CONGENER" , ""},
                { "V0RELA_NUM_APOLICE" , ""},
                { "V0RELA_NRENDOS" , ""},
                { "V0RELA_NRPARCEL" , ""},
                { "V0RELA_NRCERTIF" , ""},
                { "V0RELA_NRTIT" , ""},
                { "V0RELA_CODSUBES" , ""},
                { "V0RELA_OPERACAO" , ""},
                { "V0RELA_COD_PLANO" , ""},
                { "V0RELA_OCORHIST" , ""},
                { "V0RELA_APOLIDER" , ""},
                { "V0RELA_ENDOSLID" , ""},
                { "V0RELA_NUM_PARC_LIDER" , ""},
                { "V0RELA_NUM_SINISTRO" , ""},
                { "V0RELA_NUM_SINI_LIDER" , ""},
                { "V0RELA_NUM_ORDEM" , ""},
                { "V0RELA_CODUNIMO" , ""},
                { "V0RELA_CORRECAO" , ""},
                { "V0RELA_SITUACAO" , ""},
                { "V0RELA_PREVIA_DEFINITIVA" , ""},
                { "V0RELA_ANAL_RESUMO" , ""},
                { "V0RELA_COD_EMPRESA" , ""},
                { "V0RELA_PERI_RENOVACAO" , ""},
                { "V0RELA_PCT_AUMENTO" , ""},
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("B0300_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("B0300_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1", q4);

                #endregion
                #endregion
                var program = new FC0038B();
                program.Execute(ENTRADA_FILE_NAME_P, ARQCARTA_FILE_NAME_P, RFC0038B1_FILE_NAME_P, RFC0038B2_FILE_NAME_P, CEPERROS_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}