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
using static Code.SI0133B;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0133B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0133B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_015_000_CABECALHOS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1EMPRESA_NOM_EMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SIST_DTMOVABE" , ""},
                { "SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);

            #endregion

            #region SI0133B_V1RELATSINI

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RELSIN_APOL_SINI" , ""},
                { "RELSIN_DTMOVTO" , ""},
                { "RELSIN_OPERACAO" , ""},
                { "RELSIN_OCORHIST" , ""},
                { "RELSIN_CODPSI" , ""},
                { "RELSIN_CODUSU" , ""},
                { "RELSIN_MOVPCS" , ""},
                { "MEST_TIPREG" , ""},
                { "MEST_NUM_APOL" , ""},
                { "MEST_NRENDOS" , ""},
                { "MEST_NRCERTIF" , ""},
                { "MEST_DIGCERT" , ""},
                { "MEST_IDTPSEGU" , ""},
                { "MEST_DATCMD" , ""},
                { "MEST_DATTEC" , ""},
                { "MEST_DATORR" , ""},
                { "MEST_FONTE" , ""},
                { "MEST_DAC" , ""},
                { "MEST_PCPARTIC" , ""},
                { "MEST_PCTRES" , ""},
                { "MEST_TOTPAGBT" , ""},
                { "MEST_TOTDSABT" , ""},
                { "MEST_TOTHONBT" , ""},
                { "MEST_TOTRSDBT" , ""},
                { "MEST_SDORCPBT" , ""},
                { "MEST_SDOADTBT" , ""},
                { "MEST_CODCAU" , ""},
                { "MEST_PROTSINI" , ""},
                { "MEST_CODSUBES" , ""},
                { "MEST_OCORHIST" , ""},
                { "MEST_COD_MOEDA_SIN" , ""},
                { "MEST_NUMIRB" , ""},
                { "MEST_CODPRODU" , ""},
                { "MEST_RAMO" , ""},
                { "PRODUTO_DESCR_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0133B_V1RELATSINI", q2);

            #endregion

            #region SI0133B_V1BENEF

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "TBENEF_NOME_BENEFIC" , ""},
                { "TBENEF_GRAU_PARENT" , ""},
                { "TBENEF_PCT_PART_BENEF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0133B_V1BENEF", q3);

            #endregion

            #region M_125_000_CREDITO_HABITACIONAL_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0HABIT01_OPERACAO" , ""},
                { "V0HABIT01_PONTO_VENDA" , ""},
                { "V0HABIT01_NUM_CONTRATO" , ""},
                { "V0HABIT01_CGCCPF" , ""},
                { "V0HABIT01_NOME_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_125_000_CREDITO_HABITACIONAL_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_126_000_PELA_V0SINI_ITEM_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "CLIE_NOME_RAZAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_126_000_PELA_V0SINI_ITEM_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0AG_NOME_AGENCIA" , ""},
                { "V0AG_AGE_CENTRAL_PROD01" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_2_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0AG_NOME_AGENCIA_CENTR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_2_Query1", q7);

            #endregion

            #region M_129_000_ACESSA_PRODUTO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_DESCRPROD" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_129_000_ACESSA_PRODUTO_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_134_000_REATIVACAO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "THIST_VALPRI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_134_000_REATIVACAO_DB_SELECT_1_Query1", q9);

            #endregion

            #region M_135_000_CANCELAMENTO_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "THIST_VALPRI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_135_000_CANCELAMENTO_DB_SELECT_1_Query1", q10);

            #endregion

            #region SI0133B_V1HISTSINI

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "THIST_VALPRI" , ""},
                { "THIST_OCORHIST" , ""},
                { "THIST_DTMOVTO" , ""},
                { "THIST_SITUACAO" , ""},
                { "THIST_OPERACAO" , ""},
                { "THIST_FONPAG" , ""},
                { "THIST_NOMFAV" , ""},
                { "THIST_CODPSVI" , ""},
                { "THIST_TIPFAV" , ""},
                { "THIST_LIMCRR" , ""},
                { "THIST_MOVPCS" , ""},
                { "THIST_NUMOPG" , ""},
                { "GEOPERAC_FUNCAO_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0133B_V1HISTSINI", q11);

            #endregion

            #region SI0133B_V1HISTFAV

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "THIST_VALPRI" , ""},
                { "THIST_OCORHIST" , ""},
                { "THIST_DTMOVTO" , ""},
                { "THIST_SITUACAO" , ""},
                { "THIST_OPERACAO" , ""},
                { "THIST_FONPAG" , ""},
                { "THIST_NOMFAV" , ""},
                { "THIST_CODPSVI" , ""},
                { "THIST_TIPFAV" , ""},
                { "THIST_LIMCRR" , ""},
                { "THIST_MOVPCS" , ""},
                { "THIST_NUMOPG" , ""},
                { "GEOPERAC_IND_TIPO_FUNCAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0133B_V1HISTFAV", q12);

            #endregion

            #region SI0133B_V1HISTSIN2

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "THIST_VALPRI4" , ""},
                { "THIST_DTMOVTO2" , ""},
                { "THIST_OPERACAO2" , ""},
                { "THIST_OCORHIST2" , ""},
                { "THIST_TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0133B_V1HISTSIN2", q13);

            #endregion

            #region M_186_000_ACESSA_PROC_JURID_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "SI042_COD_PROCESSO_JURID" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_186_000_ACESSA_PROC_JURID_DB_SELECT_1_Query1", q14);

            #endregion

            #region SI0133B_V1APOLCORRET

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "APDCORR_CODCORR" , ""},
                { "APDCORR_NUM_APOL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0133B_V1APOLCORRET", q15);

            #endregion

            #region M_190_000_ACESSA_AVISO_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "THIST_VALPRI2" , ""},
                { "THIST_DTMOVTO1" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_190_000_ACESSA_AVISO_DB_SELECT_1_Query1", q16);

            #endregion

            #region M_200_000_ACESSA_OPERACAO_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "GEOPERAC_DES_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_200_000_ACESSA_OPERACAO_DB_SELECT_1_Query1", q17);

            #endregion

            #region M_220_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "FONTE_NOMEFTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_220_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1", q18);

            #endregion

            #region M_230_200_ACESSA_TGERAMO_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "GERAMO_NOMERAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_230_200_ACESSA_TGERAMO_DB_SELECT_1_Query1", q19);

            #endregion

            #region M_240_000_LER_TAPOLICE_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "APOL_NOME" , ""},
                { "APOL_PCTCED" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_240_000_LER_TAPOLICE_DB_SELECT_1_Query1", q20);

            #endregion

            #region M_241_000_LER_APOLCOSCED_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "COSS_PCPARTIC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_241_000_LER_APOLCOSCED_DB_SELECT_1_Query1", q21);

            #endregion

            #region M_270_000_LER_TENDOSSO_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "ENDOS_DTINIVIG" , ""},
                { "ENDOS_DTTERVIG" , ""},
                { "ENDOS_QTPARCEL" , ""},
                { "ENDOS_SITUACAO" , ""},
                { "ENDOS_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_270_000_LER_TENDOSSO_DB_SELECT_1_Query1", q22);

            #endregion

            #region SI0133B_RESERVA

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "THIST_OPERACAO1" , ""},
                { "THIST_VALPRI1" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0133B_RESERVA", q23);

            #endregion

            #region M_360_200_ACESSA_PRODUTOR_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "PROD_NOMPDT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_360_200_ACESSA_PRODUTOR_DB_SELECT_1_Query1", q24);

            #endregion

            #region M_390_200_ACESSA_TCAUSA_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "CAUSA_DESCAU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_390_200_ACESSA_TCAUSA_DB_SELECT_1_Query1", q25);

            #endregion

            #region M_391_003_LER_TCAUSA_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "CAUSA_DESCAU" , ""},
                { "CAUSA_GRUPO_CAUSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_391_003_LER_TCAUSA_DB_SELECT_1_Query1", q26);

            #endregion

            #region SI0133B_V1PARCELA

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "PARCEL_NRPARCEL" , ""},
                { "PARCEL_SITUACAO" , ""},
                { "PARCEL_OCORHIST" , ""},
                { "PARCEL_NUM_APOL" , ""},
                { "PARCEL_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0133B_V1PARCELA", q27);

            #endregion

            #region M_480_000_LER_THISTPAR_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "THISTPAR_DTMOVTO" , ""},
                { "THISTPAR_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_480_000_LER_THISTPAR_DB_SELECT_1_Query1", q28);

            #endregion

            #region M_500_000_LER_FORNECEDOR_DB_SELECT_1_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NOME_BANCO" , ""},
                { "AGENCIAS_NOME_AGENCIA" , ""},
                { "FORNECED_COD_AGENCIA" , ""},
                { "FORNECED_NUM_CTA_CORRENTE" , ""},
                { "FORNECED_COD_BANCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_500_000_LER_FORNECEDOR_DB_SELECT_1_Query1", q29);

            #endregion

            #region M_510_FOLHA_SEPARADORA_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_NOME_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_510_FOLHA_SEPARADORA_DB_SELECT_1_Query1", q30);

            #endregion

            #region M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "GEUNIMO_VLCRUZAD" , ""},
                { "GEUNIMO_SIGLUNIM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1", q31);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0133B_OUTPUT_202504070000")]
        public static void SI0133B_Tests_Theory(string SI0133M1_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                SI1000S_Tests.Load_Parameters();

                #region R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1

                var si100s = new DynamicData();
                si100s.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"}
                });
                si100s.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"}
                });
                si100s.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"}
                });
                si100s.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"}
                });
                si100s.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"}
                });
                si100s.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1", si100s);

                #endregion

                #region PARAMETERS
                #region R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1

                var SI100S_1 = new DynamicData();
                SI100S_1.AddDynamic(new Dictionary<string, string>{
                    { "GESISFUN_NOM_FUNCAO" , "ADIANTAMENTOS CEF/SGTO"}
                });
                SI100S_1.AddDynamic(new Dictionary<string, string>{
                    { "GESISFUN_NOM_FUNCAO" , "ADIANTAMENTOS CEF/SGTO"}
                });
                SI100S_1.AddDynamic(new Dictionary<string, string>{
                    { "GESISFUN_NOM_FUNCAO" , "ADIANTAMENTOS CEF/SGTO"}
                });
                SI100S_1.AddDynamic(new Dictionary<string, string>{
                    { "GESISFUN_NOM_FUNCAO" , "ADIANTAMENTOS CEF/SGTO"}
                });
                SI100S_1.AddDynamic(new Dictionary<string, string>{
                    { "GESISFUN_NOM_FUNCAO" , "ADIANTAMENTOS CEF/SGTO"}
                });
                SI100S_1.AddDynamic(new Dictionary<string, string>{
                    { "GESISFUN_NOM_FUNCAO" , "ADIANTAMENTOS CEF/SGTO"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1", SI100S_1);

                #endregion

                #region R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1

                var SI100S_2 = new DynamicData();
                SI100S_2.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "500000"}
                });
                SI100S_2.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "500000"}
                });
                SI100S_2.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "500000"}
                });
                SI100S_2.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "500000"}
                });
                SI100S_2.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "500000"}
                });
                SI100S_2.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_VAL_OPERACAO" , "500000"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1", SI100S_2);

                #endregion

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region M_015_000_CABECALHOS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1EMPRESA_NOM_EMP" , "CAIXA VIDA E SEGURIDADE SA"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_015_000_CABECALHOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SIST_DTMOVABE" , ""},
                    { "SIST_DTCURRENT" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0133B_V1RELATSINI

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "RELSIN_APOL_SINI" , "1"},
                    { "RELSIN_DTMOVTO" , ""},
                    { "RELSIN_OPERACAO" , ""},
                    { "RELSIN_OCORHIST" , ""},
                    { "RELSIN_CODPSI" , ""},
                    { "RELSIN_CODUSU" , ""},
                    { "RELSIN_MOVPCS" , ""},
                    { "MEST_TIPREG" , ""},
                    { "MEST_NUM_APOL" , ""},
                    { "MEST_NRENDOS" , ""},
                    { "MEST_NRCERTIF" , ""},
                    { "MEST_DIGCERT" , ""},
                    { "MEST_IDTPSEGU" , ""},
                    { "MEST_DATCMD" , ""},
                    { "MEST_DATTEC" , ""},
                    { "MEST_DATORR" , ""},
                    { "MEST_FONTE" , ""},
                    { "MEST_DAC" , ""},
                    { "MEST_PCPARTIC" , ""},
                    { "MEST_PCTRES" , ""},
                    { "MEST_TOTPAGBT" , ""},
                    { "MEST_TOTDSABT" , ""},
                    { "MEST_TOTHONBT" , ""},
                    { "MEST_TOTRSDBT" , ""},
                    { "MEST_SDORCPBT" , ""},
                    { "MEST_SDOADTBT" , ""},
                    { "MEST_CODCAU" , ""},
                    { "MEST_PROTSINI" , ""},
                    { "MEST_CODSUBES" , ""},
                    { "MEST_OCORHIST" , ""},
                    { "MEST_COD_MOEDA_SIN" , ""},
                    { "MEST_NUMIRB" , ""},
                    { "MEST_CODPRODU" , ""},
                    { "MEST_RAMO" , ""},
                    { "PRODUTO_DESCR_PRODUTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0133B_V1RELATSINI");
                AppSettings.TestSet.DynamicData.Add("SI0133B_V1RELATSINI", q2);

                #endregion

                #region SI0133B_V1BENEF

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "TBENEF_NOME_BENEFIC" , ""},
                    { "TBENEF_GRAU_PARENT" , ""},
                    { "TBENEF_PCT_PART_BENEF" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0133B_V1BENEF");
                AppSettings.TestSet.DynamicData.Add("SI0133B_V1BENEF", q3);

                #endregion

                #region M_125_000_CREDITO_HABITACIONAL_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0HABIT01_OPERACAO" , ""},
                    { "V0HABIT01_PONTO_VENDA" , ""},
                    { "V0HABIT01_NUM_CONTRATO" , ""},
                    { "V0HABIT01_CGCCPF" , ""},
                    { "V0HABIT01_NOME_SEGURADO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_125_000_CREDITO_HABITACIONAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_125_000_CREDITO_HABITACIONAL_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_126_000_PELA_V0SINI_ITEM_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "CLIE_NOME_RAZAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_126_000_PELA_V0SINI_ITEM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_126_000_PELA_V0SINI_ITEM_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V0AG_NOME_AGENCIA" , ""},
                    { "V0AG_AGE_CENTRAL_PROD01" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_2_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V0AG_NOME_AGENCIA_CENTR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_2_Query1", q7);

                #endregion

                #region M_129_000_ACESSA_PRODUTO_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V0PROD_DESCRPROD" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_129_000_ACESSA_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_129_000_ACESSA_PRODUTO_DB_SELECT_1_Query1", q8);

                #endregion

                #region M_134_000_REATIVACAO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "THIST_VALPRI" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_134_000_REATIVACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_134_000_REATIVACAO_DB_SELECT_1_Query1", q9);

                #endregion

                #region M_135_000_CANCELAMENTO_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "THIST_VALPRI" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_135_000_CANCELAMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_135_000_CANCELAMENTO_DB_SELECT_1_Query1", q10);

                #endregion

                #region SI0133B_V1HISTSINI

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "THIST_VALPRI" , ""},
                    { "THIST_OCORHIST" , ""},
                    { "THIST_DTMOVTO" , ""},
                    { "THIST_SITUACAO" , ""},
                    { "THIST_OPERACAO" , ""},
                    { "THIST_FONPAG" , ""},
                    { "THIST_NOMFAV" , ""},
                    { "THIST_CODPSVI" , ""},
                    { "THIST_TIPFAV" , ""},
                    { "THIST_LIMCRR" , ""},
                    { "THIST_MOVPCS" , ""},
                    { "THIST_NUMOPG" , ""},
                    { "GEOPERAC_FUNCAO_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0133B_V1HISTSINI");
                AppSettings.TestSet.DynamicData.Add("SI0133B_V1HISTSINI", q11);

                #endregion

                #region SI0133B_V1HISTFAV

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "THIST_VALPRI" , ""},
                    { "THIST_OCORHIST" , ""},
                    { "THIST_DTMOVTO" , ""},
                    { "THIST_SITUACAO" , ""},
                    { "THIST_OPERACAO" , ""},
                    { "THIST_FONPAG" , ""},
                    { "THIST_NOMFAV" , ""},
                    { "THIST_CODPSVI" , ""},
                    { "THIST_TIPFAV" , ""},
                    { "THIST_LIMCRR" , ""},
                    { "THIST_MOVPCS" , ""},
                    { "THIST_NUMOPG" , ""},
                    { "GEOPERAC_IND_TIPO_FUNCAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0133B_V1HISTFAV");
                AppSettings.TestSet.DynamicData.Add("SI0133B_V1HISTFAV", q12);

                #endregion

                #region SI0133B_V1HISTSIN2

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "THIST_VALPRI4" , ""},
                    { "THIST_DTMOVTO2" , ""},
                    { "THIST_OPERACAO2" , ""},
                    { "THIST_OCORHIST2" , ""},
                    { "THIST_TIMESTAMP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0133B_V1HISTSIN2");
                AppSettings.TestSet.DynamicData.Add("SI0133B_V1HISTSIN2", q13);

                #endregion

                #region M_186_000_ACESSA_PROC_JURID_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "SI042_COD_PROCESSO_JURID" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_186_000_ACESSA_PROC_JURID_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_186_000_ACESSA_PROC_JURID_DB_SELECT_1_Query1", q14);

                #endregion

                #region SI0133B_V1APOLCORRET

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "APDCORR_CODCORR" , ""},
                    { "APDCORR_NUM_APOL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0133B_V1APOLCORRET");
                AppSettings.TestSet.DynamicData.Add("SI0133B_V1APOLCORRET", q15);

                #endregion

                #region M_190_000_ACESSA_AVISO_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "THIST_VALPRI2" , ""},
                    { "THIST_DTMOVTO1" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_190_000_ACESSA_AVISO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_190_000_ACESSA_AVISO_DB_SELECT_1_Query1", q16);

                #endregion

                #region M_200_000_ACESSA_OPERACAO_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "GEOPERAC_DES_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_200_000_ACESSA_OPERACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_200_000_ACESSA_OPERACAO_DB_SELECT_1_Query1", q17);

                #endregion

                #region M_220_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "FONTE_NOMEFTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_220_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_220_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1", q18);

                #endregion

                #region M_230_200_ACESSA_TGERAMO_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "GERAMO_NOMERAMO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_230_200_ACESSA_TGERAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_230_200_ACESSA_TGERAMO_DB_SELECT_1_Query1", q19);

                #endregion

                #region M_240_000_LER_TAPOLICE_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "APOL_NOME" , ""},
                    { "APOL_PCTCED" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_240_000_LER_TAPOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_240_000_LER_TAPOLICE_DB_SELECT_1_Query1", q20);

                #endregion

                #region M_241_000_LER_APOLCOSCED_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                    { "COSS_PCPARTIC" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_241_000_LER_APOLCOSCED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_241_000_LER_APOLCOSCED_DB_SELECT_1_Query1", q21);

                #endregion

                #region M_270_000_LER_TENDOSSO_DB_SELECT_1_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                    { "ENDOS_DTINIVIG" , ""},
                    { "ENDOS_DTTERVIG" , ""},
                    { "ENDOS_QTPARCEL" , ""},
                    { "ENDOS_SITUACAO" , ""},
                    { "ENDOS_FONTE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_270_000_LER_TENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_270_000_LER_TENDOSSO_DB_SELECT_1_Query1", q22);

                #endregion

                #region SI0133B_RESERVA

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                    { "THIST_OPERACAO1" , ""},
                    { "THIST_VALPRI1" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0133B_RESERVA");
                AppSettings.TestSet.DynamicData.Add("SI0133B_RESERVA", q23);

                #endregion

                #region M_360_200_ACESSA_PRODUTOR_DB_SELECT_1_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                    { "PROD_NOMPDT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_360_200_ACESSA_PRODUTOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_360_200_ACESSA_PRODUTOR_DB_SELECT_1_Query1", q24);

                #endregion

                #region M_390_200_ACESSA_TCAUSA_DB_SELECT_1_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                    { "CAUSA_DESCAU" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_390_200_ACESSA_TCAUSA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_390_200_ACESSA_TCAUSA_DB_SELECT_1_Query1", q25);

                #endregion

                #region M_391_003_LER_TCAUSA_DB_SELECT_1_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                    { "CAUSA_DESCAU" , ""},
                    { "CAUSA_GRUPO_CAUSAS" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_391_003_LER_TCAUSA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_391_003_LER_TCAUSA_DB_SELECT_1_Query1", q26);

                #endregion

                #region SI0133B_V1PARCELA

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                    { "PARCEL_NRPARCEL" , ""},
                    { "PARCEL_SITUACAO" , ""},
                    { "PARCEL_OCORHIST" , ""},
                    { "PARCEL_NUM_APOL" , ""},
                    { "PARCEL_NRENDOS" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0133B_V1PARCELA");
                AppSettings.TestSet.DynamicData.Add("SI0133B_V1PARCELA", q27);

                #endregion

                #region M_480_000_LER_THISTPAR_DB_SELECT_1_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                    { "THISTPAR_DTMOVTO" , ""},
                    { "THISTPAR_DTVENCTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_480_000_LER_THISTPAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_480_000_LER_THISTPAR_DB_SELECT_1_Query1", q28);

                #endregion

                #region M_500_000_LER_FORNECEDOR_DB_SELECT_1_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                    { "BANCOS_NOME_BANCO" , ""},
                    { "AGENCIAS_NOME_AGENCIA" , ""},
                    { "FORNECED_COD_AGENCIA" , ""},
                    { "FORNECED_NUM_CTA_CORRENTE" , ""},
                    { "FORNECED_COD_BANCO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_500_000_LER_FORNECEDOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_500_000_LER_FORNECEDOR_DB_SELECT_1_Query1", q29);

                #endregion

                #region M_510_FOLHA_SEPARADORA_DB_SELECT_1_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                    { "USUARIOS_NOME_USUARIO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_510_FOLHA_SEPARADORA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_510_FOLHA_SEPARADORA_DB_SELECT_1_Query1", q30);

                #endregion

                #region M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                    { "GEUNIMO_VLCRUZAD" , "500"},
                    { "GEUNIMO_SIGLUNIM" , ""},
                });
                q31.AddDynamic(new Dictionary<string, string>{
                    { "GEUNIMO_VLCRUZAD" , "500"},
                    { "GEUNIMO_SIGLUNIM" , ""},
                });
                q31.AddDynamic(new Dictionary<string, string>{
                    { "GEUNIMO_VLCRUZAD" , "500"},
                    { "GEUNIMO_SIGLUNIM" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1", q31);

                #endregion

                #endregion
                #endregion
                #endregion
                var program = new SI0133B();
                program.Execute(SI0133M1_FILE_NAME_P);

                Assert.True(File.Exists(program.SI0133M1.FilePath));
                Assert.True(new FileInfo(program.SI0133M1.FilePath).Length > 0);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                Assert.True(selects.Count > (allSelects.Count / 2));

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0133B_OUTPUT_202504070001")]
        public static void SI0133B_Tests_Theory_ReturnCode99(string SI0133M1_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                SI1000S_Tests.Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region M_015_000_CABECALHOS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1EMPRESA_NOM_EMP" , "CAIXA VIDA E SEGURIDADE SA"}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("M_015_000_CABECALHOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_015_000_CABECALHOS_DB_SELECT_1_Query1", q0);

                #endregion

                #region M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SIST_DTMOVABE" , ""},
                    { "SIST_DTCURRENT" , ""},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1", q1);

                #endregion

                #region SI0133B_V1RELATSINI

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "RELSIN_APOL_SINI" , "1"},
                    { "RELSIN_DTMOVTO" , ""},
                    { "RELSIN_OPERACAO" , ""},
                    { "RELSIN_OCORHIST" , ""},
                    { "RELSIN_CODPSI" , ""},
                    { "RELSIN_CODUSU" , ""},
                    { "RELSIN_MOVPCS" , ""},
                    { "MEST_TIPREG" , ""},
                    { "MEST_NUM_APOL" , ""},
                    { "MEST_NRENDOS" , ""},
                    { "MEST_NRCERTIF" , ""},
                    { "MEST_DIGCERT" , ""},
                    { "MEST_IDTPSEGU" , ""},
                    { "MEST_DATCMD" , ""},
                    { "MEST_DATTEC" , ""},
                    { "MEST_DATORR" , ""},
                    { "MEST_FONTE" , ""},
                    { "MEST_DAC" , ""},
                    { "MEST_PCPARTIC" , ""},
                    { "MEST_PCTRES" , ""},
                    { "MEST_TOTPAGBT" , ""},
                    { "MEST_TOTDSABT" , ""},
                    { "MEST_TOTHONBT" , ""},
                    { "MEST_TOTRSDBT" , ""},
                    { "MEST_SDORCPBT" , ""},
                    { "MEST_SDOADTBT" , ""},
                    { "MEST_CODCAU" , ""},
                    { "MEST_PROTSINI" , ""},
                    { "MEST_CODSUBES" , ""},
                    { "MEST_OCORHIST" , ""},
                    { "MEST_COD_MOEDA_SIN" , ""},
                    { "MEST_NUMIRB" , ""},
                    { "MEST_CODPRODU" , ""},
                    { "MEST_RAMO" , ""},
                    { "PRODUTO_DESCR_PRODUTO" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("SI0133B_V1RELATSINI");
                AppSettings.TestSet.DynamicData.Add("SI0133B_V1RELATSINI", q2);

                #endregion

                #region SI0133B_V1BENEF

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "TBENEF_NOME_BENEFIC" , ""},
                    { "TBENEF_GRAU_PARENT" , ""},
                    { "TBENEF_PCT_PART_BENEF" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0133B_V1BENEF");
                AppSettings.TestSet.DynamicData.Add("SI0133B_V1BENEF", q3);

                #endregion

                #region M_125_000_CREDITO_HABITACIONAL_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0HABIT01_OPERACAO" , ""},
                    { "V0HABIT01_PONTO_VENDA" , ""},
                    { "V0HABIT01_NUM_CONTRATO" , ""},
                    { "V0HABIT01_CGCCPF" , ""},
                    { "V0HABIT01_NOME_SEGURADO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_125_000_CREDITO_HABITACIONAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_125_000_CREDITO_HABITACIONAL_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_126_000_PELA_V0SINI_ITEM_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "CLIE_NOME_RAZAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_126_000_PELA_V0SINI_ITEM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_126_000_PELA_V0SINI_ITEM_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V0AG_NOME_AGENCIA" , ""},
                    { "V0AG_AGE_CENTRAL_PROD01" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_2_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V0AG_NOME_AGENCIA_CENTR" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_2_Query1", q7);

                #endregion

                #region M_129_000_ACESSA_PRODUTO_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V0PROD_DESCRPROD" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_129_000_ACESSA_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_129_000_ACESSA_PRODUTO_DB_SELECT_1_Query1", q8);

                #endregion

                #region M_134_000_REATIVACAO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "THIST_VALPRI" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_134_000_REATIVACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_134_000_REATIVACAO_DB_SELECT_1_Query1", q9);

                #endregion

                #region M_135_000_CANCELAMENTO_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "THIST_VALPRI" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_135_000_CANCELAMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_135_000_CANCELAMENTO_DB_SELECT_1_Query1", q10);

                #endregion

                #region SI0133B_V1HISTSINI

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "THIST_VALPRI" , ""},
                    { "THIST_OCORHIST" , ""},
                    { "THIST_DTMOVTO" , ""},
                    { "THIST_SITUACAO" , ""},
                    { "THIST_OPERACAO" , ""},
                    { "THIST_FONPAG" , ""},
                    { "THIST_NOMFAV" , ""},
                    { "THIST_CODPSVI" , ""},
                    { "THIST_TIPFAV" , ""},
                    { "THIST_LIMCRR" , ""},
                    { "THIST_MOVPCS" , ""},
                    { "THIST_NUMOPG" , ""},
                    { "GEOPERAC_FUNCAO_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0133B_V1HISTSINI");
                AppSettings.TestSet.DynamicData.Add("SI0133B_V1HISTSINI", q11);

                #endregion

                #region SI0133B_V1HISTFAV

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "THIST_VALPRI" , ""},
                    { "THIST_OCORHIST" , ""},
                    { "THIST_DTMOVTO" , ""},
                    { "THIST_SITUACAO" , ""},
                    { "THIST_OPERACAO" , ""},
                    { "THIST_FONPAG" , ""},
                    { "THIST_NOMFAV" , ""},
                    { "THIST_CODPSVI" , ""},
                    { "THIST_TIPFAV" , ""},
                    { "THIST_LIMCRR" , ""},
                    { "THIST_MOVPCS" , ""},
                    { "THIST_NUMOPG" , ""},
                    { "GEOPERAC_IND_TIPO_FUNCAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0133B_V1HISTFAV");
                AppSettings.TestSet.DynamicData.Add("SI0133B_V1HISTFAV", q12);

                #endregion

                #region SI0133B_V1HISTSIN2

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "THIST_VALPRI4" , ""},
                    { "THIST_DTMOVTO2" , ""},
                    { "THIST_OPERACAO2" , ""},
                    { "THIST_OCORHIST2" , ""},
                    { "THIST_TIMESTAMP" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0133B_V1HISTSIN2");
                AppSettings.TestSet.DynamicData.Add("SI0133B_V1HISTSIN2", q13);

                #endregion

                #region M_186_000_ACESSA_PROC_JURID_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "SI042_COD_PROCESSO_JURID" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_186_000_ACESSA_PROC_JURID_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_186_000_ACESSA_PROC_JURID_DB_SELECT_1_Query1", q14);

                #endregion

                #region SI0133B_V1APOLCORRET

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "APDCORR_CODCORR" , ""},
                    { "APDCORR_NUM_APOL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0133B_V1APOLCORRET");
                AppSettings.TestSet.DynamicData.Add("SI0133B_V1APOLCORRET", q15);

                #endregion

                #region M_190_000_ACESSA_AVISO_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "THIST_VALPRI2" , ""},
                    { "THIST_DTMOVTO1" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_190_000_ACESSA_AVISO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_190_000_ACESSA_AVISO_DB_SELECT_1_Query1", q16);

                #endregion

                #region M_200_000_ACESSA_OPERACAO_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "GEOPERAC_DES_OPERACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_200_000_ACESSA_OPERACAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_200_000_ACESSA_OPERACAO_DB_SELECT_1_Query1", q17);

                #endregion

                #region M_220_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "FONTE_NOMEFTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_220_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_220_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1", q18);

                #endregion

                #region M_230_200_ACESSA_TGERAMO_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "GERAMO_NOMERAMO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_230_200_ACESSA_TGERAMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_230_200_ACESSA_TGERAMO_DB_SELECT_1_Query1", q19);

                #endregion

                #region M_240_000_LER_TAPOLICE_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "APOL_NOME" , ""},
                    { "APOL_PCTCED" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_240_000_LER_TAPOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_240_000_LER_TAPOLICE_DB_SELECT_1_Query1", q20);

                #endregion

                #region M_241_000_LER_APOLCOSCED_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                    { "COSS_PCPARTIC" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_241_000_LER_APOLCOSCED_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_241_000_LER_APOLCOSCED_DB_SELECT_1_Query1", q21);

                #endregion

                #region M_270_000_LER_TENDOSSO_DB_SELECT_1_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                    { "ENDOS_DTINIVIG" , ""},
                    { "ENDOS_DTTERVIG" , ""},
                    { "ENDOS_QTPARCEL" , ""},
                    { "ENDOS_SITUACAO" , ""},
                    { "ENDOS_FONTE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_270_000_LER_TENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_270_000_LER_TENDOSSO_DB_SELECT_1_Query1", q22);

                #endregion

                #region SI0133B_RESERVA

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                    { "THIST_OPERACAO1" , ""},
                    { "THIST_VALPRI1" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0133B_RESERVA");
                AppSettings.TestSet.DynamicData.Add("SI0133B_RESERVA", q23);

                #endregion

                #region M_360_200_ACESSA_PRODUTOR_DB_SELECT_1_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                    { "PROD_NOMPDT" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_360_200_ACESSA_PRODUTOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_360_200_ACESSA_PRODUTOR_DB_SELECT_1_Query1", q24);

                #endregion

                #region M_390_200_ACESSA_TCAUSA_DB_SELECT_1_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                    { "CAUSA_DESCAU" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_390_200_ACESSA_TCAUSA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_390_200_ACESSA_TCAUSA_DB_SELECT_1_Query1", q25);

                #endregion

                #region M_391_003_LER_TCAUSA_DB_SELECT_1_Query1

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                    { "CAUSA_DESCAU" , ""},
                    { "CAUSA_GRUPO_CAUSAS" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_391_003_LER_TCAUSA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_391_003_LER_TCAUSA_DB_SELECT_1_Query1", q26);

                #endregion

                #region SI0133B_V1PARCELA

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                    { "PARCEL_NRPARCEL" , ""},
                    { "PARCEL_SITUACAO" , ""},
                    { "PARCEL_OCORHIST" , ""},
                    { "PARCEL_NUM_APOL" , ""},
                    { "PARCEL_NRENDOS" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0133B_V1PARCELA");
                AppSettings.TestSet.DynamicData.Add("SI0133B_V1PARCELA", q27);

                #endregion

                #region M_480_000_LER_THISTPAR_DB_SELECT_1_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                    { "THISTPAR_DTMOVTO" , ""},
                    { "THISTPAR_DTVENCTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_480_000_LER_THISTPAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_480_000_LER_THISTPAR_DB_SELECT_1_Query1", q28);

                #endregion

                #region M_500_000_LER_FORNECEDOR_DB_SELECT_1_Query1

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                    { "BANCOS_NOME_BANCO" , ""},
                    { "AGENCIAS_NOME_AGENCIA" , ""},
                    { "FORNECED_COD_AGENCIA" , ""},
                    { "FORNECED_NUM_CTA_CORRENTE" , ""},
                    { "FORNECED_COD_BANCO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_500_000_LER_FORNECEDOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_500_000_LER_FORNECEDOR_DB_SELECT_1_Query1", q29);

                #endregion

                #region M_510_FOLHA_SEPARADORA_DB_SELECT_1_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                    { "USUARIOS_NOME_USUARIO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_510_FOLHA_SEPARADORA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_510_FOLHA_SEPARADORA_DB_SELECT_1_Query1", q30);

                #endregion

                #region M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                    { "GEUNIMO_VLCRUZAD" , "500"},
                    { "GEUNIMO_SIGLUNIM" , ""},
                });
                q31.AddDynamic(new Dictionary<string, string>{
                    { "GEUNIMO_VLCRUZAD" , "500"},
                    { "GEUNIMO_SIGLUNIM" , ""},
                });
                q31.AddDynamic(new Dictionary<string, string>{
                    { "GEUNIMO_VLCRUZAD" , "500"},
                    { "GEUNIMO_SIGLUNIM" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1", q31);

                #endregion

                #endregion
                #endregion
                var program = new SI0133B();
                program.Execute(SI0133M1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}