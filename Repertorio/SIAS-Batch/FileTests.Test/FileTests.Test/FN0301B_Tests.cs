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
using static Code.FN0301B;
using System.IO;

namespace FileTests.Test
{
    [Collection("FN0301B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class FN0301B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region FN0301B_MOVTO

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1HISP_NUMAPOL" , ""},
                { "V1HISP_NRENDOS" , ""},
                { "APOLICES_COD_PRODUTO" , ""},
                { "V1ENDO_CODSUBES" , ""},
                { "V1ENDO_DTINIVIG" , ""},
                { "V1ENDO_DTTERVIG" , ""},
                { "V1ENDO_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("FN0301B_MOVTO", q1);

            #endregion

            #region FN0301B_V1APOLCORRET

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1APCR_NUM_APOL" , ""},
                { "V1APCR_CODSUBES" , ""},
                { "V1APCR_RAMOFR" , ""},
                { "V1APCR_CODCORR" , ""},
                { "V1APCR_PCCOMCOR" , ""},
                { "V1APCR_PCPARCOR" , ""},
                { "V1APCR_TIPCOM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("FN0301B_V1APOLCORRET", q2);

            #endregion

            #region R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_NUMAPOL" , ""},
                { "V1ENDO_NRENDOS" , ""},
                { "V1ENDO_CODSUBES" , ""},
                { "V1ENDO_FONTE" , ""},
                { "V1ENDO_NRPROPOS" , ""},
                { "V1ENDO_NUMBIL" , ""},
                { "V1ENDO_NRRCAP" , ""},
                { "V1ENDO_RAMO" , ""},
                { "V1ENDO_CODPRODU" , ""},
                { "V1ENDO_APOLANT" , ""},
                { "V1ENDO_DTEMIS" , ""},
                { "V1ENDO_DTINIVIG" , ""},
                { "V1ENDO_DTTERVIG" , ""},
                { "V1ENDO_CODCLIEN" , ""},
                { "V1ENDO_QTPARCEL" , ""},
                { "V1ENDO_OCORR_END" , ""},
                { "V1ENDO_MOEDA_IMP" , ""},
                { "V1ENDO_MOEDA_PRM" , ""},
                { "V1ENDO_TIPO_ENDO" , ""},
                { "V1ENDO_SITUACAO" , ""},
                { "V1ENDO_AGERCAP" , ""},
                { "V1ENDO_AGECOBR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1200_00_GRAVA_FENEMIS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1HISP_VLPRMLIQ" , ""},
                { "V1HISP_VLPRMTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_GRAVA_FENEMIS_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1210_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1CLIE_NOME" , ""},
                { "V1CLIE_TPPESSOA" , ""},
                { "V1CLIE_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1211_00_GRAVA_FENPANA_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1HISP_VLPRMLIQ" , ""},
                { "V1HISP_VLPRMTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1211_00_GRAVA_FENPANA_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1215_00_SELECT_PROPCONV_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_PROPOSTA_VC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1215_00_SELECT_PROPCONV_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1220_10_LEITURA_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1ENDE_ENDERECO" , ""},
                { "V1ENDE_CIDADE" , ""},
                { "V1ENDE_BAIRRO" , ""},
                { "V1ENDE_CEP" , ""},
                { "V1ENDE_ESTADO" , ""},
                { "V1ENDE_DDD" , ""},
                { "V1ENDE_TELEFONE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1220_10_LEITURA_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1230_00_INDICADOR_AUTO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "WHOST_MATRIC_IND" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1230_00_INDICADOR_AUTO_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1240_00_INDICADOR_BILHETE_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "WHOST_MATRIC_IND" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1240_00_INDICADOR_BILHETE_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1250_00_AGENCIA_RCAP_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_AGECOBR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1250_00_AGENCIA_RCAP_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1251_00_BUSCA_NCERTIFICADO_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1251_00_BUSCA_NCERTIFICADO_DB_SELECT_1_Query1", q12);

            #endregion

            #region R1252_00_SELECT_PROPOFID_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_IDENTIFICACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1252_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q13);

            #endregion

            #region R1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRRCAP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "APOLIAUT_NUM_PROPOSTA_CONV" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1_Query1", q15);

            #endregion

            #region R1300_00_GRAVA_FENPARC_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_QTPARCEL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_GRAVA_FENPARC_DB_SELECT_1_Query1", q16);

            #endregion

            #region R1310_00_PRIMEIRA_PARCELA_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUMAPOL" , ""},
                { "V1PARC_NRENDOS" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1PARC_NRTIT" , ""},
                { "V1PARC_VLPRMLIQ" , ""},
                { "V1PARC_QTDOCORR" , ""},
                { "V1PARC_SITUACAO" , ""},
                { "V1HISP_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1310_00_PRIMEIRA_PARCELA_DB_SELECT_1_Query1", q17);

            #endregion

            #region R1311_00_DEMAIS_PARCELAS_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUMAPOL" , ""},
                { "V1PARC_NRENDOS" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1PARC_NRTIT" , ""},
                { "V1PARC_VLPRMLIQ" , ""},
                { "V1PARC_QTDOCORR" , ""},
                { "V1PARC_SITUACAO" , ""},
                { "V1HISP_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1311_00_DEMAIS_PARCELAS_DB_SELECT_1_Query1", q18);

            #endregion

            #region FN0301B_V1APOLCOSCED

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V1APCC_NUM_APOL" , ""},
                { "V1APCC_CODCOSS" , ""},
                { "V1APCC_PCPARTIC" , ""},
                { "V1APCC_PCCOMCOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("FN0301B_V1APOLCOSCED", q19);

            #endregion

            #region FN0301B_V1HISTORES

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V1HRES_NUMAPOL" , ""},
                { "V1HRES_NRENDOS" , ""},
                { "V1HRES_NRITEM" , ""},
                { "V1HRES_OCORHIST" , ""},
                { "V1HRES_CODRESSEG" , ""},
                { "V1HRES_RAMOFR" , ""},
                { "V1HRES_PCTRSP" , ""},
                { "V1HRES_PCTCOMRS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("FN0301B_V1HISTORES", q20);

            #endregion

            #region FN0301B_V1AUTOAPOL

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V1AUTO_FONTE" , ""},
                { "V1AUTO_NRPROPOS" , ""},
                { "V1AUTO_NRITEM" , ""},
                { "V1AUTO_CDVEICL" , ""},
                { "V1AUTO_ANOVEICL" , ""},
                { "V1AUTO_ANOMOD" , ""},
                { "V1AUTO_CHASSIS" , ""},
                { "V1AUTO_COMBUST" , ""},
                { "V1AUTO_PLACALET" , ""},
                { "V1AUTO_PLACANR" , ""},
                { "V1AUTO_PLACAUF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("FN0301B_V1AUTOAPOL", q21);

            #endregion

            #region FN0301B_V1AUTOCOBER

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V1AUCB_RAMOFR" , ""},
                { "V1AUCB_CODCOBER" , ""},
                { "V1AUCB_IMP_SEG_IX" , ""},
                { "V1AUCB_PRM_TAR_VAR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("FN0301B_V1AUTOCOBER", q22);

            #endregion

            #region R2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V1TARI_DTINIVIG" , ""},
                { "V1TARI_DTTERVIG" , ""},
                { "V1TARI_TIPOCOB" , ""},
                { "V1TARI_REGIAO" , ""},
                { "V1TARI_FRANQFAC" , ""},
                { "V1TARI_CLABONAT" , ""},
                { "V1TARI_CATAUTO" , ""},
                { "V1TARI_CATRCF" , ""},
                { "V1TARI_VRFROBR_IX" , ""},
                { "V1TARI_VRFRFACC_IX" , ""},
                { "V1TARI_VRFRFACA_IX" , ""},
                { "V1TARI_VRFRADIC_IX" , ""},
                { "V1TARI_TPCDSBAU" , ""},
                { "V1TARI_TPCPZSEG" , ""},
                { "V1TARI_TPCBONDM" , ""},
                { "V1TARI_TPCBONDP" , ""},
                { "V1TARI_DTINIVIG_1DIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1_Query1", q23);

            #endregion

            #region R2230_00_SELECT_TOMADOR_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "TOMADOR_COD_FONTE" , ""},
                { "TOMADOR_NUM_PROPOSTA" , ""},
                { "TOMADOR_COD_CLIENTE" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_TOMADOR_DB_SELECT_1_Query1", q24);

            #endregion

            #region FN0301B_V1FATURA

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V1FATT_NUMAPOL" , ""},
                { "V1FATT_CODSUBES" , ""},
                { "V1FATT_NUM_FATUR" , ""},
                { "V1FATT_COD_OPER" , ""},
                { "V1FATT_QT_VIDA_VG" , ""},
                { "V1FATT_QT_VIDA_AP" , ""},
                { "V1FATT_IMP_MORNAT" , ""},
                { "V1FATT_IMP_MORACI" , ""},
                { "V1FATT_IMP_INVPER" , ""},
                { "V1FATT_IMP_AMDS" , ""},
                { "V1FATT_IMP_DH" , ""},
                { "V1FATT_IMP_DIT" , ""},
                { "V1FATT_PRM_VG" , ""},
                { "V1FATT_PRM_AP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("FN0301B_V1FATURA", q25);

            #endregion

            #region FN0301B_V1COBERAPOL

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V1COBA_NRITEM" , ""},
                { "V1COBA_RAMOFR" , ""},
                { "V1COBA_CODCOBER" , ""},
                { "V1COBA_DTINIVIG" , ""},
                { "V1COBA_DTTERVIG" , ""},
                { "V1COBA_IMP_SEG_IX" , ""},
                { "V1COBA_PRM_TAR_VAR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("FN0301B_V1COBERAPOL", q26);

            #endregion

            #region R3250_00_BUSCA_PERIPGTO_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_PERI_PAGAMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3250_00_BUSCA_PERIPGTO_DB_SELECT_1_Query1", q27);

            #endregion

            #region FN0301B_V1OUTRCOBER

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V1OCOB_NRRISCO" , ""},
                { "V1OCOB_RAMOFR" , ""},
                { "V1OCOB_CODCOBER" , ""},
                { "V1OCOB_DTINIVIG" , ""},
                { "V1OCOB_DTTERVIG" , ""},
                { "V1OCOB_IMP_SEG_IX" , ""},
                { "V1OCOB_PRM_TAR_VAR" , ""},
                { "V1OCOB_VRFROBR_IX" , ""},
                { "V1OCOB_LIMINDENIZ" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("FN0301B_V1OUTRCOBER", q28);

            #endregion

            #region FN0301B_MRAPCOBER

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "V1OCOB_NRRISCO" , ""},
                { "V1OCOB_RAMOFR" , ""},
                { "V1OCOB_CODCOBER" , ""},
                { "V1OCOB_DTINIVIG" , ""},
                { "V1OCOB_DTTERVIG" , ""},
                { "V1OCOB_IMP_SEG_IX" , ""},
                { "V1OCOB_PRM_TAR_VAR" , ""},
                { "V1OCOB_VRFROBR_IX" , ""},
                { "V1OCOB_LIMINDENIZ" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("FN0301B_MRAPCOBER", q29);

            #endregion

            #region R0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODCORR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1", q30);

            #endregion

            #region R0911_00_VERIF_CORRET_PANAM_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0911_00_VERIF_CORRET_PANAM_DB_SELECT_1_Query1", q31);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("FN0301B_o1", "FN0301B_o2", "FN0301B_o3", "FN0301B_o4", "FN0301B_o5", "FN0301B_o6", "FN0301B_o7", "FN0301B_o8", "FN0301B_o9", "FN0301B_10")]
        public static void FN0301B_Tests_Theory(string FENPANA_FILE_NAME_P, string FENEMIS_FILE_NAME_P, string FENAUTO_FILE_NAME_P, string FENAUT1_FILE_NAME_P, string FENVIDA_FILE_NAME_P, string FENOUTR_FILE_NAME_P, string FENPARC_FILE_NAME_P, string FENCOMI_FILE_NAME_P, string FENCOSS_FILE_NAME_P, string FENRESS_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                FENPANA_FILE_NAME_P = $"{FENPANA_FILE_NAME_P}_{timestamp}.txt";
                FENEMIS_FILE_NAME_P = $"{FENEMIS_FILE_NAME_P}_{timestamp}.txt";
                FENAUTO_FILE_NAME_P = $"{FENAUTO_FILE_NAME_P}_{timestamp}.txt";
                FENAUT1_FILE_NAME_P = $"{FENAUT1_FILE_NAME_P}_{timestamp}.txt";
                FENVIDA_FILE_NAME_P = $"{FENVIDA_FILE_NAME_P}_{timestamp}.txt";
                FENOUTR_FILE_NAME_P = $"{FENOUTR_FILE_NAME_P}_{timestamp}.txt";
                FENPARC_FILE_NAME_P = $"{FENPARC_FILE_NAME_P}_{timestamp}.txt";
                FENCOMI_FILE_NAME_P = $"{FENCOMI_FILE_NAME_P}_{timestamp}.txt";
                FENCOSS_FILE_NAME_P = $"{FENCOSS_FILE_NAME_P}_{timestamp}.txt";
                FENRESS_FILE_NAME_P = $"{FENRESS_FILE_NAME_P}_{timestamp}.txt";

                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" },
                { "V1SIST_TIMESTAMP" , "2023-12-01T12:00:00" },
            });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region FN0301B_MOVTO

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1HISP_NUMAPOL" , "A123456" },
                { "V1HISP_NRENDOS" , "R123456" },
                { "APOLICES_COD_PRODUTO" , "P123" },
                { "V1ENDO_CODSUBES" , "S123" },
                { "V1ENDO_DTINIVIG" , "2023-12-01" },
                { "V1ENDO_DTTERVIG" , "2023-12-31" },
                { "V1ENDO_SITUACAO" , "Active" },
            });
                AppSettings.TestSet.DynamicData.Remove("FN0301B_MOVTO");
                AppSettings.TestSet.DynamicData.Add("FN0301B_MOVTO", q1);

                #endregion

                #region FN0301B_V1APOLCORRET

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1APCR_NUM_APOL" , "A123457" },
                { "V1APCR_CODSUBES" , "S124" },
                { "V1APCR_RAMOFR" , "Ramo1" },
                { "V1APCR_CODCORR" , "C123" },
                { "V1APCR_PCCOMCOR" , "10.0" },
                { "V1APCR_PCPARCOR" , "5.0" },
                { "V1APCR_TIPCOM" , "Type1" },
            });
                AppSettings.TestSet.DynamicData.Remove("FN0301B_V1APOLCORRET");
                AppSettings.TestSet.DynamicData.Add("FN0301B_V1APOLCORRET", q2);

                #endregion

                #region R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_NUMAPOL" , "A123458" },
                { "V1ENDO_NRENDOS" , "R123457" },
                { "V1ENDO_CODSUBES" , "S123" },
                { "V1ENDO_FONTE" , "Source1" },
                { "V1ENDO_NRPROPOS" , "Prop123" },
                { "V1ENDO_NUMBIL" , "Bil123" },
                { "V1ENDO_NRRCAP" , "RC123" },
                { "V1ENDO_RAMO" , "Ramo2" },
                { "V1ENDO_CODPRODU" , "Prod123" },
                { "V1ENDO_APOLANT" , "ApolAnt123" },
                { "V1ENDO_DTEMIS" , "2023-12-01" },
                { "V1ENDO_DTINIVIG" , "2023-12-01" },
                { "V1ENDO_DTTERVIG" , "2023-12-31" },
                { "V1ENDO_CODCLIEN" , "Client123" },
                { "V1ENDO_QTPARCEL" , "12" },
                { "V1ENDO_OCORR_END" , "Occur123" },
                { "V1ENDO_MOEDA_IMP" , "USD" },
                { "V1ENDO_MOEDA_PRM" , "EUR" },
                { "V1ENDO_TIPO_ENDO" , "TypeEndo1" },
                { "V1ENDO_SITUACAO" , "Active" },
                { "V1ENDO_AGERCAP" , "30" },
                { "V1ENDO_AGECOBR" , "25" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1200_00_GRAVA_FENEMIS_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1HISP_VLPRMLIQ" , "1000.0" },
                { "V1HISP_VLPRMTOT" , "1200.0" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_GRAVA_FENEMIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_GRAVA_FENEMIS_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1210_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V1CLIE_NOME" , "John Doe" },
                { "V1CLIE_TPPESSOA" , "Individual" },
                { "V1CLIE_CGCCPF" , "12345678901" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1210_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1210_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1211_00_GRAVA_FENPANA_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1HISP_VLPRMLIQ" , "1000.0" },
                { "V1HISP_VLPRMTOT" , "1200.0" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1211_00_GRAVA_FENPANA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1211_00_GRAVA_FENPANA_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1215_00_SELECT_PROPCONV_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_PROPOSTA_VC" , "PropVC123" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1215_00_SELECT_PROPCONV_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1215_00_SELECT_PROPCONV_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1220_10_LEITURA_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V1ENDE_ENDERECO" , "123 Main St" },
                { "V1ENDE_CIDADE" , "Anytown" },
                { "V1ENDE_BAIRRO" , "Anydistrict" },
                { "V1ENDE_CEP" , "12345" },
                { "V1ENDE_ESTADO" , "State" },
                { "V1ENDE_DDD" , "123" },
                { "V1ENDE_TELEFONE" , "1234567890" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1220_10_LEITURA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1220_10_LEITURA_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1230_00_INDICADOR_AUTO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "WHOST_MATRIC_IND" , "MatInd123" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1230_00_INDICADOR_AUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1230_00_INDICADOR_AUTO_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1240_00_INDICADOR_BILHETE_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "WHOST_MATRIC_IND" , "MatInd123" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1240_00_INDICADOR_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1240_00_INDICADOR_BILHETE_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1250_00_AGENCIA_RCAP_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_AGECOBR" , "20" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1250_00_AGENCIA_RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1250_00_AGENCIA_RCAP_DB_SELECT_1_Query1", q11);

                #endregion

                #region R1251_00_BUSCA_NCERTIFICADO_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_NRCERTIF" , "Cert123" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1251_00_BUSCA_NCERTIFICADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1251_00_BUSCA_NCERTIFICADO_DB_SELECT_1_Query1", q12);

                #endregion

                #region R1252_00_SELECT_PROPOFID_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_IDENTIFICACAO" , "ID123" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1252_00_SELECT_PROPOFID_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1252_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRRCAP" , "RC124" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1_Query1", q14);

                #endregion

                #region R1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "APOLIAUT_NUM_PROPOSTA_CONV" , "PropConv123" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1_Query1", q15);

                #endregion

                #region R1300_00_GRAVA_FENPARC_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_QTPARCEL" , "12" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_GRAVA_FENPARC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_GRAVA_FENPARC_DB_SELECT_1_Query1", q16);

                #endregion

                #region R1310_00_PRIMEIRA_PARCELA_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUMAPOL" , "A123459" },
                { "V1PARC_NRENDOS" , "R123458" },
                { "V1PARC_NRPARCEL" , "1" },
                { "V1PARC_NRTIT" , "Tit123" },
                { "V1PARC_VLPRMLIQ" , "500.0" },
                { "V1PARC_QTDOCORR" , "0" },
                { "V1PARC_SITUACAO" , "Pending" },
                { "V1HISP_DTVENCTO" , "2023-12-31" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1310_00_PRIMEIRA_PARCELA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1310_00_PRIMEIRA_PARCELA_DB_SELECT_1_Query1", q17);

                #endregion

                #region R1311_00_DEMAIS_PARCELAS_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUMAPOL" , "A123459" },
                { "V1PARC_NRENDOS" , "R123458" },
                { "V1PARC_NRPARCEL" , "1" },
                { "V1PARC_NRTIT" , "Tit123" },
                { "V1PARC_VLPRMLIQ" , "500.0" },
                { "V1PARC_QTDOCORR" , "0" },
                { "V1PARC_SITUACAO" , "Pending" },
                { "V1HISP_DTVENCTO" , "2023-12-31" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1311_00_DEMAIS_PARCELAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1311_00_DEMAIS_PARCELAS_DB_SELECT_1_Query1", q18);

                #endregion

                #region FN0301B_V1APOLCOSCED

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "V1APCC_NUM_APOL" , "A123460" },
                { "V1APCC_CODCOSS" , "Coss123" },
                { "V1APCC_PCPARTIC" , "15.0" },
                { "V1APCC_PCCOMCOS" , "7.5" },
            });
                AppSettings.TestSet.DynamicData.Remove("FN0301B_V1APOLCOSCED");
                AppSettings.TestSet.DynamicData.Add("FN0301B_V1APOLCOSCED", q19);

                #endregion

                #region FN0301B_V1HISTORES

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "V1HRES_NUMAPOL" , "A123461" },
                { "V1HRES_NRENDOS" , "R123459" },
                { "V1HRES_NRITEM" , "Item123" },
                { "V1HRES_OCORHIST" , "Hist123" },
                { "V1HRES_CODRESSEG" , "ResSeg123" },
                { "V1HRES_RAMOFR" , "Ramo3" },
                { "V1HRES_PCTRSP" , "20.0" },
                { "V1HRES_PCTCOMRS" , "10.0" },
            });
                AppSettings.TestSet.DynamicData.Remove("FN0301B_V1HISTORES");
                AppSettings.TestSet.DynamicData.Add("FN0301B_V1HISTORES", q20);

                #endregion

                #region FN0301B_V1AUTOAPOL

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V1AUTO_FONTE" , "AutoSource" },
                { "V1AUTO_NRPROPOS" , "AutoProp123" },
                { "V1AUTO_NRITEM" , "AutoItem123" },
                { "V1AUTO_CDVEICL" , "Veh123" },
                { "V1AUTO_ANOVEICL" , "2023" },
                { "V1AUTO_ANOMOD" , "2022" },
                { "V1AUTO_CHASSIS" , "Chassis123" },
                { "V1AUTO_COMBUST" , "Gasoline" },
                { "V1AUTO_PLACALET" , "ABC" },
                { "V1AUTO_PLACANR" , "1234" },
                { "V1AUTO_PLACAUF" , "UF" },
            });
                AppSettings.TestSet.DynamicData.Remove("FN0301B_V1AUTOAPOL");
                AppSettings.TestSet.DynamicData.Add("FN0301B_V1AUTOAPOL", q21);

                #endregion

                #region FN0301B_V1AUTOCOBER

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "V1AUCB_RAMOFR" , "Ramo4" },
                { "V1AUCB_CODCOBER" , "Cob123" },
                { "V1AUCB_IMP_SEG_IX" , "10000.0" },
                { "V1AUCB_PRM_TAR_VAR" , "200.0" },
            });
                AppSettings.TestSet.DynamicData.Remove("FN0301B_V1AUTOCOBER");
                AppSettings.TestSet.DynamicData.Add("FN0301B_V1AUTOCOBER", q22);

                #endregion

                #region R2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "V1TARI_DTINIVIG" , "2023-12-01" },
                { "V1TARI_DTTERVIG" , "2023-12-31" },
                { "V1TARI_TIPOCOB" , "CobType" },
                { "V1TARI_REGIAO" , "Region1" },
                { "V1TARI_FRANQFAC" , "Franq123" },
                { "V1TARI_CLABONAT" , "Clas123" },
                { "V1TARI_CATAUTO" , "CatAuto123" },
                { "V1TARI_CATRCF" , "CatRCF123" },
                { "V1TARI_VRFROBR_IX" , "300.0" },
                { "V1TARI_VRFRFACC_IX" , "150.0" },
                { "V1TARI_VRFRFACA_IX" , "75.0" },
                { "V1TARI_VRFRADIC_IX" , "50.0" },
                { "V1TARI_TPCDSBAU" , "TPCDSBau123" },
                { "V1TARI_TPCPZSEG" , "TPCPZSeg123" },
                { "V1TARI_TPCBONDM" , "TPCBonDM123" },
                { "V1TARI_TPCBONDP" , "TPCBonDP123" },
                { "V1TARI_DTINIVIG_1DIA" , "2023-12-02" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1_Query1", q23);

                #endregion

                #region R2230_00_SELECT_TOMADOR_DB_SELECT_1_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "TOMADOR_COD_FONTE" , "TomSource" },
                { "TOMADOR_NUM_PROPOSTA" , "TomProp123" },
                { "TOMADOR_COD_CLIENTE" , "TomClient123" },
                { "CLIENTES_NOME_RAZAO" , "ClientName" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2230_00_SELECT_TOMADOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_TOMADOR_DB_SELECT_1_Query1", q24);

                #endregion

                #region FN0301B_V1FATURA

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "V1FATT_NUMAPOL" , "A123462" },
                { "V1FATT_CODSUBES" , "Sub123" },
                { "V1FATT_NUM_FATUR" , "Fatur123" },
                { "V1FATT_COD_OPER" , "Oper123" },
                { "V1FATT_QT_VIDA_VG" , "1" },
                { "V1FATT_QT_VIDA_AP" , "1" },
                { "V1FATT_IMP_MORNAT" , "100.0" },
                { "V1FATT_IMP_MORACI" , "50.0" },
                { "V1FATT_IMP_INVPER" , "25.0" },
                { "V1FATT_IMP_AMDS" , "15.0" },
                { "V1FATT_IMP_DH" , "10.0" },
                { "V1FATT_IMP_DIT" , "5.0" },
                { "V1FATT_PRM_VG" , "100.0" },
                { "V1FATT_PRM_AP" , "50.0" },
            });
                AppSettings.TestSet.DynamicData.Remove("FN0301B_V1FATURA");
                AppSettings.TestSet.DynamicData.Add("FN0301B_V1FATURA", q25);

                #endregion

                #region FN0301B_V1COBERAPOL

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "V1COBA_NRITEM" , "CobaItem123" },
                { "V1COBA_RAMOFR" , "Ramo5" },
                { "V1COBA_CODCOBER" , "Cob124" },
                { "V1COBA_DTINIVIG" , "2023-12-01" },
                { "V1COBA_DTTERVIG" , "2023-12-31" },
                { "V1COBA_IMP_SEG_IX" , "5000.0" },
                { "V1COBA_PRM_TAR_VAR" , "100.0" },
            });
                AppSettings.TestSet.DynamicData.Remove("FN0301B_V1COBERAPOL");
                AppSettings.TestSet.DynamicData.Add("FN0301B_V1COBERAPOL", q26);

                #endregion

                #region R3250_00_BUSCA_PERIPGTO_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_PERI_PAGAMENTO" , "Monthly" }
            });
                AppSettings.TestSet.DynamicData.Remove("R3250_00_BUSCA_PERIPGTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3250_00_BUSCA_PERIPGTO_DB_SELECT_1_Query1", q27);

                #endregion

                #region FN0301B_V1OUTRCOBER

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "V1OCOB_NRRISCO" , "Risk123" },
                { "V1OCOB_RAMOFR" , "Ramo6" },
                { "V1OCOB_CODCOBER" , "Cob125" },
                { "V1OCOB_DTINIVIG" , "2023-12-01" },
                { "V1OCOB_DTTERVIG" , "2023-12-31" },
                { "V1OCOB_IMP_SEG_IX" , "2000.0" },
                { "V1OCOB_PRM_TAR_VAR" , "400.0" },
                { "V1OCOB_VRFROBR_IX" , "200.0" },
                { "V1OCOB_LIMINDENIZ" , "100000.0" },
            });
                AppSettings.TestSet.DynamicData.Remove("FN0301B_V1OUTRCOBER");
                AppSettings.TestSet.DynamicData.Add("FN0301B_V1OUTRCOBER", q28);

                #endregion

                #region FN0301B_MRAPCOBER

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "V1OCOB_NRRISCO" , "Risk123" },
                { "V1OCOB_RAMOFR" , "Ramo6" },
                { "V1OCOB_CODCOBER" , "Cob125" },
                { "V1OCOB_DTINIVIG" , "2023-12-01" },
                { "V1OCOB_DTTERVIG" , "2023-12-31" },
                { "V1OCOB_IMP_SEG_IX" , "2000.0" },
                { "V1OCOB_PRM_TAR_VAR" , "400.0" },
                { "V1OCOB_VRFROBR_IX" , "200.0" },
                { "V1OCOB_LIMINDENIZ" , "100000.0" },
            });
                AppSettings.TestSet.DynamicData.Remove("FN0301B_MRAPCOBER");
                AppSettings.TestSet.DynamicData.Add("FN0301B_MRAPCOBER", q29);

                #endregion

                #region R0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODCORR" , "Corr123" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1", q30);

                #endregion

                #region R0911_00_VERIF_CORRET_PANAM_DB_SELECT_1_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0911_00_VERIF_CORRET_PANAM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0911_00_VERIF_CORRET_PANAM_DB_SELECT_1_Query1", q31);

                #endregion
                #endregion
                #endregion


                var program = new FN0301B();
                program.Execute(
                    FENPANA_FILE_NAME_P,
                    FENEMIS_FILE_NAME_P,
                    FENAUTO_FILE_NAME_P,
                    FENAUT1_FILE_NAME_P,
                    FENVIDA_FILE_NAME_P,
                    FENOUTR_FILE_NAME_P,
                    FENPARC_FILE_NAME_P,
                    FENCOMI_FILE_NAME_P,
                    FENCOSS_FILE_NAME_P,
                    FENRESS_FILE_NAME_P);

                Assert.True(File.Exists(program.FENPANA.FilePath));
                Assert.True(new FileInfo(program.FENPANA.FilePath).Length > 0);

                Assert.True(File.Exists(program.FENEMIS.FilePath));
                Assert.True(new FileInfo(program.FENEMIS.FilePath).Length > 0);
                
                Assert.True(File.Exists(program.FENAUTO.FilePath));
                Assert.True(new FileInfo(program.FENAUTO.FilePath).Length > 0);
                
                Assert.True(File.Exists(program.FENAUT1.FilePath));
                Assert.True(new FileInfo(program.FENAUT1.FilePath).Length > 0);
                
                Assert.True(File.Exists(program.FENVIDA.FilePath));
                Assert.True(new FileInfo(program.FENVIDA.FilePath).Length > 0);
                
                Assert.True(File.Exists(program.FENPARC.FilePath));
                Assert.True(new FileInfo(program.FENPARC.FilePath).Length > 0);
                
                Assert.True(File.Exists(program.FENOUTR.FilePath));
                Assert.True(new FileInfo(program.FENOUTR.FilePath).Length > 0);
                
                Assert.True(File.Exists(program.FENCOMI.FilePath));
                Assert.True(new FileInfo(program.FENCOMI.FilePath).Length > 0);
                
                Assert.True(File.Exists(program.FENCOSS.FilePath));
                Assert.True(new FileInfo(program.FENCOSS.FilePath).Length > 0);
                
                Assert.True(File.Exists(program.FENRESS.FilePath));
                Assert.True(new FileInfo(program.FENRESS.FilePath).Length > 0);

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= 10);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("FN0301B_o1", "FN0301B_o2", "FN0301B_o3", "FN0301B_o4", "FN0301B_o5", "FN0301B_o6", "FN0301B_o7", "FN0301B_o8", "FN0301B_o9", "FN0301B_10")]
        public static void FN0301B_Tests_Cenario2_Theory(string FENPANA_FILE_NAME_P, string FENEMIS_FILE_NAME_P, string FENAUTO_FILE_NAME_P, string FENAUT1_FILE_NAME_P, string FENVIDA_FILE_NAME_P, string FENOUTR_FILE_NAME_P, string FENPARC_FILE_NAME_P, string FENCOMI_FILE_NAME_P, string FENCOSS_FILE_NAME_P, string FENRESS_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                FENPANA_FILE_NAME_P = $"{FENPANA_FILE_NAME_P}_{timestamp}.txt";
                FENEMIS_FILE_NAME_P = $"{FENEMIS_FILE_NAME_P}_{timestamp}.txt";
                FENAUTO_FILE_NAME_P = $"{FENAUTO_FILE_NAME_P}_{timestamp}.txt";
                FENAUT1_FILE_NAME_P = $"{FENAUT1_FILE_NAME_P}_{timestamp}.txt";
                FENVIDA_FILE_NAME_P = $"{FENVIDA_FILE_NAME_P}_{timestamp}.txt";
                FENOUTR_FILE_NAME_P = $"{FENOUTR_FILE_NAME_P}_{timestamp}.txt";
                FENPARC_FILE_NAME_P = $"{FENPARC_FILE_NAME_P}_{timestamp}.txt";
                FENCOMI_FILE_NAME_P = $"{FENCOMI_FILE_NAME_P}_{timestamp}.txt";
                FENCOSS_FILE_NAME_P = $"{FENCOSS_FILE_NAME_P}_{timestamp}.txt";
                FENRESS_FILE_NAME_P = $"{FENRESS_FILE_NAME_P}_{timestamp}.txt";

                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2023-12-01" },
                { "V1SIST_TIMESTAMP" , "2023-12-01T12:00:00" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region FN0301B_MOVTO

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1HISP_NUMAPOL" , "A123456" },
                { "V1HISP_NRENDOS" , "R123456" },
                { "APOLICES_COD_PRODUTO" , "P123456" },
                { "V1ENDO_CODSUBES" , "S123456" },
                { "V1ENDO_DTINIVIG" , "2023-12-01" },
                { "V1ENDO_DTTERVIG" , "2024-12-01" },
                { "V1ENDO_SITUACAO" , "Ativo" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("FN0301B_MOVTO");
                AppSettings.TestSet.DynamicData.Add("FN0301B_MOVTO", q1);

                #endregion

                #region FN0301B_V1APOLCORRET

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1APCR_NUM_APOL" , "A654321" },
                { "V1APCR_CODSUBES" , "S654321" },
                { "V1APCR_RAMOFR" , "Ramo1" },
                { "V1APCR_CODCORR" , "C123456" },
                { "V1APCR_PCCOMCOR" , "10.0" },
                { "V1APCR_PCPARCOR" , "5.0" },
                { "V1APCR_TIPCOM" , "Tipo1" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("FN0301B_V1APOLCORRET");
                AppSettings.TestSet.DynamicData.Add("FN0301B_V1APOLCORRET", q2);

                #endregion

                #region R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_NUMAPOL" , "A123457" },
                { "V1ENDO_NRENDOS" , "R123457" },
                { "V1ENDO_CODSUBES" , "S123456" },
                { "V1ENDO_FONTE" , "Fonte1" },
                { "V1ENDO_NRPROPOS" , "Prop123456" },
                { "V1ENDO_NUMBIL" , "Bil123456" },
                { "V1ENDO_NRRCAP" , "RC123456" },
                { "V1ENDO_RAMO" , "Ramo2" },
                { "V1ENDO_CODPRODU" , "Prod123456" },
                { "V1ENDO_APOLANT" , "ApolAnt123" },
                { "V1ENDO_DTEMIS" , "2023-12-01" },
                { "V1ENDO_DTINIVIG" , "2023-12-01" },
                { "V1ENDO_DTTERVIG" , "2024-12-01" },
                { "V1ENDO_CODCLIEN" , "Cli123456" },
                { "V1ENDO_QTPARCEL" , "12" },
                { "V1ENDO_OCORR_END" , "Ocorr1" },
                { "V1ENDO_MOEDA_IMP" , "USD" },
                { "V1ENDO_MOEDA_PRM" , "BRL" },
                { "V1ENDO_TIPO_ENDO" , "TipoEndo1" },
                { "V1ENDO_SITUACAO" , "Ativo" },
                { "V1ENDO_AGERCAP" , "30" },
                { "V1ENDO_AGECOBR" , "25" },
            }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1200_00_GRAVA_FENEMIS_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1HISP_VLPRMLIQ" , "1000.0" },
                { "V1HISP_VLPRMTOT" , "1100.0" },
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("R1200_00_GRAVA_FENEMIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_GRAVA_FENEMIS_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1210_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V1CLIE_NOME" , "Cliente1" },
                { "V1CLIE_TPPESSOA" , "Física" },
                { "V1CLIE_CGCCPF" , "123.456.789-00" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1210_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1210_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1211_00_GRAVA_FENPANA_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V1HISP_VLPRMLIQ" , "1000.0" },
                { "V1HISP_VLPRMTOT" , "1100.0" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1211_00_GRAVA_FENPANA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1211_00_GRAVA_FENPANA_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1215_00_SELECT_PROPCONV_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_PROPOSTA_VC" , "PropVC123" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1215_00_SELECT_PROPCONV_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1215_00_SELECT_PROPCONV_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1220_10_LEITURA_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V1ENDE_ENDERECO" , "Rua ABC, 123" },
                { "V1ENDE_CIDADE" , "Cidade1" },
                { "V1ENDE_BAIRRO" , "Bairro1" },
                { "V1ENDE_CEP" , "12345-678" },
                { "V1ENDE_ESTADO" , "Estado1" },
                { "V1ENDE_DDD" , "11" },
                { "V1ENDE_TELEFONE" , "1234-5678" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1220_10_LEITURA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1220_10_LEITURA_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1230_00_INDICADOR_AUTO_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "WHOST_MATRIC_IND" , "Mat123456" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1230_00_INDICADOR_AUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1230_00_INDICADOR_AUTO_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1240_00_INDICADOR_BILHETE_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "WHOST_MATRIC_IND" , "Mat123456" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1240_00_INDICADOR_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1240_00_INDICADOR_BILHETE_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1250_00_AGENCIA_RCAP_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_AGECOBR" , "25" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1250_00_AGENCIA_RCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1250_00_AGENCIA_RCAP_DB_SELECT_1_Query1", q11);

                #endregion

                #region R1251_00_BUSCA_NCERTIFICADO_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "V0RCAP_NRCERTIF" , "Cert123456" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1251_00_BUSCA_NCERTIFICADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1251_00_BUSCA_NCERTIFICADO_DB_SELECT_1_Query1", q12);

                #endregion

                #region R1252_00_SELECT_PROPOFID_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_IDENTIFICACAO" , "ID123456" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1252_00_SELECT_PROPOFID_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1252_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NRRCAP" , "RC654321" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1_Query1", q14);

                #endregion

                #region R1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "APOLIAUT_NUM_PROPOSTA_CONV" , "PropConv123" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1_Query1", q15);

                #endregion

                #region R1300_00_GRAVA_FENPARC_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_QTPARCEL" , "12" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_GRAVA_FENPARC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_GRAVA_FENPARC_DB_SELECT_1_Query1", q16);

                #endregion

                #region R1310_00_PRIMEIRA_PARCELA_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUMAPOL" , "A123458" },
                { "V1PARC_NRENDOS" , "R123458" },
                { "V1PARC_NRPARCEL" , "1" },
                { "V1PARC_NRTIT" , "Tit123456" },
                { "V1PARC_VLPRMLIQ" , "500.0" },
                { "V1PARC_QTDOCORR" , "0" },
                { "V1PARC_SITUACAO" , "Pendente" },
                { "V1HISP_DTVENCTO" , "2024-01-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1310_00_PRIMEIRA_PARCELA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1310_00_PRIMEIRA_PARCELA_DB_SELECT_1_Query1", q17);

                #endregion

                #region R1311_00_DEMAIS_PARCELAS_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUMAPOL" , "A123458" },
                { "V1PARC_NRENDOS" , "R123458" },
                { "V1PARC_NRPARCEL" , "1" },
                { "V1PARC_NRTIT" , "Tit123456" },
                { "V1PARC_VLPRMLIQ" , "500.0" },
                { "V1PARC_QTDOCORR" , "0" },
                { "V1PARC_SITUACAO" , "Pendente" },
                { "V1HISP_DTVENCTO" , "2024-01-01" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1311_00_DEMAIS_PARCELAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1311_00_DEMAIS_PARCELAS_DB_SELECT_1_Query1", q18);

                #endregion

                #region FN0301B_V1APOLCOSCED

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "V1APCC_NUM_APOL" , "A123459" },
                { "V1APCC_CODCOSS" , "Coss123456" },
                { "V1APCC_PCPARTIC" , "20.0" },
                { "V1APCC_PCCOMCOS" , "15.0" },
            });
                AppSettings.TestSet.DynamicData.Remove("FN0301B_V1APOLCOSCED");
                AppSettings.TestSet.DynamicData.Add("FN0301B_V1APOLCOSCED", q19);

                #endregion

                #region FN0301B_V1HISTORES

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "V1HRES_NUMAPOL" , "A123460" },
                { "V1HRES_NRENDOS" , "R123460" },
                { "V1HRES_NRITEM" , "Item123456" },
                { "V1HRES_OCORHIST" , "Hist1" },
                { "V1HRES_CODRESSEG" , "ResSeg123" },
                { "V1HRES_RAMOFR" , "Ramo3" },
                { "V1HRES_PCTRSP" , "30.0" },
                { "V1HRES_PCTCOMRS" , "25.0" },
            });
                AppSettings.TestSet.DynamicData.Remove("FN0301B_V1HISTORES");
                AppSettings.TestSet.DynamicData.Add("FN0301B_V1HISTORES", q20);

                #endregion

                #region FN0301B_V1AUTOAPOL

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V1AUTO_FONTE" , "Fonte2" },
                { "V1AUTO_NRPROPOS" , "Prop123457" },
                { "V1AUTO_NRITEM" , "Item123457" },
                { "V1AUTO_CDVEICL" , "Veic123456" },
                { "V1AUTO_ANOVEICL" , "2023" },
                { "V1AUTO_ANOMOD" , "2024" },
                { "V1AUTO_CHASSIS" , "CH123456789" },
                { "V1AUTO_COMBUST" , "Gasolina" },
                { "V1AUTO_PLACALET" , "ABC" },
                { "V1AUTO_PLACANR" , "1234" },
                { "V1AUTO_PLACAUF" , "UF1" },
            });
                AppSettings.TestSet.DynamicData.Remove("FN0301B_V1AUTOAPOL");
                AppSettings.TestSet.DynamicData.Add("FN0301B_V1AUTOAPOL", q21);

                #endregion

                #region FN0301B_V1AUTOCOBER

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "V1AUCB_RAMOFR" , "Ramo4" },
                { "V1AUCB_CODCOBER" , "Cob123456" },
                { "V1AUCB_IMP_SEG_IX" , "2000.0" },
                { "V1AUCB_PRM_TAR_VAR" , "100.0" },
            });
                AppSettings.TestSet.DynamicData.Remove("FN0301B_V1AUTOCOBER");
                AppSettings.TestSet.DynamicData.Add("FN0301B_V1AUTOCOBER", q22);

                #endregion

                #region R2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1_Query1

                var q23 = new DynamicData();
                q23.AddDynamic(new Dictionary<string, string>{
                { "V1TARI_DTINIVIG" , "2023-12-01" },
                { "V1TARI_DTTERVIG" , "2024-12-01" },
                { "V1TARI_TIPOCOB" , "TipoCob1" },
                { "V1TARI_REGIAO" , "Região1" },
                { "V1TARI_FRANQFAC" , "Franq1" },
                { "V1TARI_CLABONAT" , "Classe1" },
                { "V1TARI_CATAUTO" , "CatAuto1" },
                { "V1TARI_CATRCF" , "CatRCF1" },
                { "V1TARI_VRFROBR_IX" , "300.0" },
                { "V1TARI_VRFRFACC_IX" , "200.0" },
                { "V1TARI_VRFRFACA_IX" , "100.0" },
                { "V1TARI_VRFRADIC_IX" , "50.0" },
                { "V1TARI_TPCDSBAU" , "TipoDSBau1" },
                { "V1TARI_TPCPZSEG" , "PzSeg1" },
                { "V1TARI_TPCBONDM" , "BonDM1" },
                { "V1TARI_TPCBONDP" , "BonDP1" },
                { "V1TARI_DTINIVIG_1DIA" , "2023-12-02" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1_Query1", q23);

                #endregion

                #region R2230_00_SELECT_TOMADOR_DB_SELECT_1_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "TOMADOR_COD_FONTE" , "Fonte3" },
                { "TOMADOR_NUM_PROPOSTA" , "Prop123458" },
                { "TOMADOR_COD_CLIENTE" , "Cli123457" },
                { "CLIENTES_NOME_RAZAO" , "Cliente2" },
            });
                AppSettings.TestSet.DynamicData.Remove("R2230_00_SELECT_TOMADOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2230_00_SELECT_TOMADOR_DB_SELECT_1_Query1", q24);

                #endregion

                #region FN0301B_V1FATURA

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "V1FATT_NUMAPOL" , "A123461" },
                { "V1FATT_CODSUBES" , "S123457" },
                { "V1FATT_NUM_FATUR" , "Fatur123456" },
                { "V1FATT_COD_OPER" , "Oper123456" },
                { "V1FATT_QT_VIDA_VG" , "2" },
                { "V1FATT_QT_VIDA_AP" , "1" },
                { "V1FATT_IMP_MORNAT" , "3000.0" },
                { "V1FATT_IMP_MORACI" , "2000.0" },
                { "V1FATT_IMP_INVPER" , "1000.0" },
                { "V1FATT_IMP_AMDS" , "500.0" },
                { "V1FATT_IMP_DH" , "250.0" },
                { "V1FATT_IMP_DIT" , "125.0" },
                { "V1FATT_PRM_VG" , "150.0" },
                { "V1FATT_PRM_AP" , "75.0" },
            });
                AppSettings.TestSet.DynamicData.Remove("FN0301B_V1FATURA");
                AppSettings.TestSet.DynamicData.Add("FN0301B_V1FATURA", q25);

                #endregion

                #region FN0301B_V1COBERAPOL

                var q26 = new DynamicData();
                q26.AddDynamic(new Dictionary<string, string>{
                { "V1COBA_NRITEM" , "Item123458" },
                { "V1COBA_RAMOFR" , "Ramo5" },
                { "V1COBA_CODCOBER" , "Cob123457" },
                { "V1COBA_DTINIVIG" , "2023-12-01" },
                { "V1COBA_DTTERVIG" , "2024-12-01" },
                { "V1COBA_IMP_SEG_IX" , "2500.0" },
                { "V1COBA_PRM_TAR_VAR" , "125.0" },
            });
                AppSettings.TestSet.DynamicData.Remove("FN0301B_V1COBERAPOL");
                AppSettings.TestSet.DynamicData.Add("FN0301B_V1COBERAPOL", q26);

                #endregion

                #region R3250_00_BUSCA_PERIPGTO_DB_SELECT_1_Query1

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_PERI_PAGAMENTO" , "Anual" }
            });
                AppSettings.TestSet.DynamicData.Remove("R3250_00_BUSCA_PERIPGTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3250_00_BUSCA_PERIPGTO_DB_SELECT_1_Query1", q27);

                #endregion

                #region FN0301B_V1OUTRCOBER

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "V1OCOB_NRRISCO" , "Risco123" },
                { "V1OCOB_RAMOFR" , "Ramo6" },
                { "V1OCOB_CODCOBER" , "Cob123458" },
                { "V1OCOB_DTINIVIG" , "2023-12-01" },
                { "V1OCOB_DTTERVIG" , "2024-12-01" },
                { "V1OCOB_IMP_SEG_IX" , "3500.0" },
                { "V1OCOB_PRM_TAR_VAR" , "175.0" },
                { "V1OCOB_VRFROBR_IX" , "400.0" },
                { "V1OCOB_LIMINDENIZ" , "5000.0" },
            });
                AppSettings.TestSet.DynamicData.Remove("FN0301B_V1OUTRCOBER");
                AppSettings.TestSet.DynamicData.Add("FN0301B_V1OUTRCOBER", q28);

                #endregion

                #region FN0301B_MRAPCOBER

                var q29 = new DynamicData();
                q29.AddDynamic(new Dictionary<string, string>{
                { "V1OCOB_NRRISCO" , "Risco123" },
                { "V1OCOB_RAMOFR" , "Ramo6" },
                { "V1OCOB_CODCOBER" , "Cob123458" },
                { "V1OCOB_DTINIVIG" , "2023-12-01" },
                { "V1OCOB_DTTERVIG" , "2024-12-01" },
                { "V1OCOB_IMP_SEG_IX" , "3500.0" },
                { "V1OCOB_PRM_TAR_VAR" , "175.0" },
                { "V1OCOB_VRFROBR_IX" , "400.0" },
                { "V1OCOB_LIMINDENIZ" , "5000.0" },
            });
                AppSettings.TestSet.DynamicData.Remove("FN0301B_MRAPCOBER");
                AppSettings.TestSet.DynamicData.Add("FN0301B_MRAPCOBER", q29);

                #endregion

                #region R0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODCORR" , "Corr123456" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1", q30);

                #endregion

                #region R0911_00_VERIF_CORRET_PANAM_DB_SELECT_1_Query1

                var q31 = new DynamicData();
                q31.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , "1" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0911_00_VERIF_CORRET_PANAM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0911_00_VERIF_CORRET_PANAM_DB_SELECT_1_Query1", q31);

                #endregion
                #endregion
                #endregion

                var program = new FN0301B();
                program.Execute(
                    FENPANA_FILE_NAME_P,
                    FENEMIS_FILE_NAME_P,
                    FENAUTO_FILE_NAME_P,
                    FENAUT1_FILE_NAME_P,
                    FENVIDA_FILE_NAME_P,
                    FENOUTR_FILE_NAME_P,
                    FENPARC_FILE_NAME_P,
                    FENCOMI_FILE_NAME_P,
                    FENCOSS_FILE_NAME_P,
                    FENRESS_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}