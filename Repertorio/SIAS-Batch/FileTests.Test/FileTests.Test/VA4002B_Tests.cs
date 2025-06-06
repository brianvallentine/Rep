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
using static Code.VA4002B;

namespace FileTests.Test
{
    [Collection("VA4002B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class VA4002B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , ""},
                { "SISTEMA_CURRDATE" , ""},
                { "SISTEMA_DTMOVABE2" , ""},
                { "SISTEMA_DTMOVABE3" , ""},
                { "SISTEMA_DTMOV015D" , ""},
                { "SISTEMA_DTMOV365D" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "MIN_PROXVEN_DATE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q1);

            #endregion

            #region VA4002B_CPROPVA

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_CODPRODU" , ""},
                { "PROPVA_CODCLIEN" , ""},
                { "PROPVA_OCOREND" , ""},
                { "PROPVA_FONTE" , ""},
                { "PROPVA_AGECOBR" , ""},
                { "PROPVA_OPCAO_COBER" , ""},
                { "PROPVA_DTQITBCO" , ""},
                { "PROPVA_DTINICDG" , ""},
                { "PROPVA_DTINISAF" , ""},
                { "PROPVA_DT365DIAS" , ""},
                { "PROPVA_DT015DIAS" , ""},
                { "PROPVA_DTPROXVEN" , ""},
                { "PROPVA_DTMINVEN" , ""},
                { "PROPVA_NRMATRVEN" , ""},
                { "PROPVA_CODOPER" , ""},
                { "PROPVA_DTINCLUS" , ""},
                { "PROPVA_DTMOVTO" , ""},
                { "PROPVA_SITUACAO" , ""},
                { "PROPVA_OCORHIST" , ""},
                { "PROPVA_NRPARCEL" , ""},
                { "PROPVA_SIT_INTERF" , ""},
                { "PROPVA_TIMESTAMP" , ""},
                { "PROPVA_IDADE" , ""},
                { "PROPVA_SEXO" , ""},
                { "PROPVA_EST_CIV" , ""},
                { "PROPVA_COD_CRM" , ""},
                { "PROPVA_NRMATRFUN" , ""},
                { "PROPVA_DTADMIS" , ""},
                { "PROPVA_NRPROPOS" , ""},
                { "PROPVA_CODCCT" , ""},
                { "PROPVA_CODUSU" , ""},
                { "PROPVA_DTVENCTO" , ""},
                { "PROPVA_FAIXA_RENDA_IND" , ""},
                { "PROPVA_DATA" , ""},
                { "PROPVA_DPS_TITULAR" , ""},
                { "PROPVA_ORIGEM_PROPOSTA" , ""},
                { "PROPVA_STA_ANTECIPACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA4002B_CPROPVA", q2);

            #endregion

            #region VA4002B_MOVTOVGAP

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MOVIMVGA_NUM_CERTIFICADO" , ""},
                { "MOVIMVGA_COD_OPERACAO" , ""},
                { "MOVIMVGA_DATA_AVERBACAO" , ""},
                { "MOVIMVGA_DATA_INCLUSAO" , ""},
                { "MOVIMVGA_DATA_NASCIMENTO" , ""},
                { "MOVIMVGA_DATA_REFERENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA4002B_MOVTOVGAP", q3);

            #endregion

            #region M_0000_PRINCIPAL_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_UPDATE_1_Update1", q4);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_3_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SUBGRU_CODSUBES" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_3_Query1", q5);

            #endregion

            #region M_0000_PRINCIPAL_DB_SELECT_4_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NRTIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_4_Query1", q6);

            #endregion

            #region M_1050_COUNT_ERRPROVI_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "ERROSVID_DESCR_ERRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1050_COUNT_ERRPROVI_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_1060_UPD_PROPOSTA_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1060_UPD_PROPOSTA_DB_UPDATE_1_Update1", q8);

            #endregion

            #region M_1200_CANCELA_PROPOSTA_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1200_CANCELA_PROPOSTA_DB_UPDATE_1_Update1", q9);

            #endregion

            #region M_1300_INTEGRA_PROPOSTA_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_DTPROXVEN" , ""},
                { "PROPVA_NRMATRVEN" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1300_INTEGRA_PROPOSTA_DB_UPDATE_1_Update1", q10);

            #endregion

            #region M_1310_PESQUISA_SEGURADO_VGAP_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_OCORR_HISTORICO" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
                { "SEGURVGA_SIT_REGISTRO" , ""},
                { "SEGURVGA_DATA_ADMISSAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1310_PESQUISA_SEGURADO_VGAP_DB_SELECT_1_Query1", q11);

            #endregion

            #region M_1330_COUNT_ERRO_OPC_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNTERRO_OPC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1330_COUNT_ERRO_OPC_DB_SELECT_1_Query1", q12);

            #endregion

            #region M_1340_PESQUISA_ERRO_2005_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNTERRO_OPC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1340_PESQUISA_ERRO_2005_DB_SELECT_1_Query1", q13);

            #endregion

            #region M_1350_UPDATE_OPCPAGVI_DB_UPDATE_1_Update1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1350_UPDATE_OPCPAGVI_DB_UPDATE_1_Update1", q14);

            #endregion

            #region M_1355_UPDATE_DIA_DEBITO_DB_UPDATE_1_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_DIA_DEB" , ""},
                { "PROPVA_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1355_UPDATE_DIA_DEBITO_DB_UPDATE_1_Update1", q15);

            #endregion

            #region M_1360_UPDATE_PERIPGTO_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1360_UPDATE_PERIPGTO_DB_UPDATE_1_Update1", q16);

            #endregion

            #region M_1370_PESQUISA_HIST_SEGURVGA_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT_HISTVGAP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1370_PESQUISA_HIST_SEGURVGA_DB_SELECT_1_Query1", q17);

            #endregion

            #region M_1380_PESQUISA_APOLICOB_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT_APOLICOB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1380_PESQUISA_APOLICOB_DB_SELECT_1_Query1", q18);

            #endregion

            #region M_1390_PESQUISA_PLANOS_VAVGA_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "PLAVAVGA_VLPREMIOTOT" , ""},
                { "PLAVAVGA_IMPMORNATU" , ""},
                { "PLAVAVGA_IMPMORACID" , ""},
                { "PLAVAVGA_IMPINVPERM" , ""},
                { "PLAVAVGA_IMPAMDS" , ""},
                { "PLAVAVGA_IMPDH" , ""},
                { "PLAVAVGA_IMPDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1390_PESQUISA_PLANOS_VAVGA_DB_SELECT_1_Query1", q19);

            #endregion

            #region M_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT_MOVIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1_Query1", q20);

            #endregion

            #region M_1450_PROCESSA_MOVTOVGAP_DB_UPDATE_1_Update1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "MOVIMVGA_DATA_NASCIMENTO" , ""},
                { "WDATA_NASCIMENTO" , ""},
                { "MOVIMVGA_DATA_REFERENCIA" , ""},
                { "WDATA_REFERENCIA" , ""},
                { "MOVIMVGA_NUM_CERTIFICADO" , ""},
                { "MOVIMVGA_DATA_AVERBACAO" , ""},
                { "MOVIMVGA_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1450_PROCESSA_MOVTOVGAP_DB_UPDATE_1_Update1", q21);

            #endregion

            #region M_2000_PESQUISA_OPCPAG_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_OPCAOPAG" , ""},
                { "OPCAOP_PERIPGTO" , ""},
                { "OPCAOP_DIA_DEB" , ""},
                { "OPCAOP_AGECTADEB" , ""},
                { "OPCAOP_OPRCTADEB" , ""},
                { "OPCAOP_NUMCTADEB" , ""},
                { "OPCAOP_DIGCTADEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_PESQUISA_OPCPAG_DB_SELECT_1_Query1", q22);

            #endregion

            #region M_2010_VERIFICA_RCAP_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNTRCAP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_2010_VERIFICA_RCAP_DB_SELECT_1_Query1", q23);

            #endregion

            #region M_3100_SELECT_V0APOLICE_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_NUM_APOLICE" , ""},
                { "APOLICES_NUM_ITEM" , ""},
                { "APOLICES_COD_MODALIDADE" , ""},
                { "APOLICES_RAMO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_3100_SELECT_V0APOLICE_DB_SELECT_1_Query1", q24);

            #endregion

            #region M_3200_UPDATE_V0APOLICE_DB_UPDATE_1_Update1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_NUM_ITEM" , ""},
                { "PROPVA_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_3200_UPDATE_V0APOLICE_DB_UPDATE_1_Update1", q25);

            #endregion

            #region M_3300_SELECT_CLIENTES_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_IDE_SEXO" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_3300_SELECT_CLIENTES_DB_SELECT_1_Query1", q26);

            #endregion

            #region M_3400_SELECT_SUBGRUPOS_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_TIPO_PLANO" , ""},
                { "SUBGVGAP_PERI_FATURAMENTO" , ""},
                { "SUBGVGAP_PERI_RENOVACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_3400_SELECT_SUBGRUPOS_DB_SELECT_1_Query1", q27);

            #endregion

            #region M_3500_INSERT_SEGURVGA_DB_INSERT_1_Insert1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "APOLICES_NUM_ITEM" , ""},
                { "PROPVA_CODCLIEN" , ""},
                { "PROPVA_FONTE" , ""},
                { "PROPVA_NRPROPOS" , ""},
                { "SEGURVGA_OCORR_HISTORICO" , ""},
                { "OPCAOP_PERIPGTO" , ""},
                { "SUBGVGAP_PERI_RENOVACAO" , ""},
                { "SEGURVGA_IDE_SEXO" , ""},
                { "PROPVA_OCOREND" , ""},
                { "SUBGVGAP_TIPO_PLANO" , ""},
                { "PROPVA_DTQITBCO" , ""},
                { "SEGURVGA_DATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_3500_INSERT_SEGURVGA_DB_INSERT_1_Insert1", q28);

            #endregion

            #region M_3600_INSERT_HIST_SEGURVGA_DB_INSERT_1_Insert1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "WHOST_NUM_ITEM" , ""},
                { "SEGURVGA_OCORR_HISTORICO" , ""},
                { "PROPVA_DTQITBCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_3600_INSERT_HIST_SEGURVGA_DB_INSERT_1_Insert1", q29);

            #endregion

            #region M_3700_00_INSERT_APOLICOB_DB_INSERT_1_Insert1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , ""},
                { "WHOST_NUM_ITEM" , ""},
                { "SEGURVGA_OCORR_HISTORICO" , ""},
                { "APOLICES_RAMO_EMISSOR" , ""},
                { "APOLICES_COD_MODALIDADE" , ""},
                { "PLAVAVGA_IMPMORNATU" , ""},
                { "PLAVAVGA_VLPREMIOTOT" , ""},
                { "PROPVA_DTQITBCO" , ""},
                { "WHOST_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_3700_00_INSERT_APOLICOB_DB_INSERT_1_Insert1", q30);

            #endregion

            #region M_3750_00_GERA_TERVIG_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA_TERVIGENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_3750_00_GERA_TERVIG_DB_SELECT_1_Query1", q31);

            #endregion

            #region M_3800_INSERT_MOVIMENTO_DB_INSERT_1_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_FONTE" , ""},
                { "FONTE_PROPAUTOM" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_CODCLIEN" , ""},
                { "OPCAOP_PERIPGTO" , ""},
                { "PROPVA_EST_CIV" , ""},
                { "PROPVA_SEXO" , ""},
                { "CONTACOR_COD_AGENCIA" , ""},
                { "CONTACOR_NUM_CTA_CORRENTE" , ""},
                { "CONTACOR_DAC_CTA_CORRENTE" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPMORACID" , ""},
                { "HISCOBPR_IMPINVPERM" , ""},
                { "HISCOBPR_IMPDIT" , ""},
                { "HISCOBPR_PRMVG" , ""},
                { "HISCOBPR_PRMAP" , ""},
                { "PROPVA_DTADMIS" , ""},
                { "PROPVA_DTINCLUS" , ""},
                { "CLIENT_DTNASC" , ""},
                { "FATURCON_DATA_REFERENCIA" , ""},
                { "PROPVA_DTQITBCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_3800_INSERT_MOVIMENTO_DB_INSERT_1_Insert1", q32);

            #endregion

            #region M_3810_ACESSA_FONTE_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_3810_ACESSA_FONTE_DB_SELECT_1_Query1", q33);

            #endregion

            #region M_3820_ATUALIZA_FONTE_DB_UPDATE_1_Update1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , ""},
                { "PROPVA_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_3820_ATUALIZA_FONTE_DB_UPDATE_1_Update1", q34);

            #endregion

            #region M_3830_CONTA_CORRENTE_DB_SELECT_1_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "CONTACOR_COD_AGENCIA" , ""},
                { "CONTACOR_NUM_CTA_CORRENTE" , ""},
                { "CONTACOR_DAC_CTA_CORRENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_3830_CONTA_CORRENTE_DB_SELECT_1_Query1", q35);

            #endregion

            #region M_3840_DATA_REFERENCIA_DB_SELECT_1_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "FATURCON_DATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_3840_DATA_REFERENCIA_DB_SELECT_1_Query1", q36);

            #endregion

            #region M_3840_DATA_REFERENCIA_DB_SELECT_2_Query1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "FATURCON_DATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_3840_DATA_REFERENCIA_DB_SELECT_2_Query1", q37);

            #endregion

            #region M_3850_DATA_CLIENTE_DB_SELECT_1_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "CLIENT_DTNASC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_3850_DATA_CLIENTE_DB_SELECT_1_Query1", q38);

            #endregion

            #region M_3860_HIS_COBER_PROPOST_DB_SELECT_1_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPMORACID" , ""},
                { "HISCOBPR_IMPINVPERM" , ""},
                { "HISCOBPR_IMPAMDS" , ""},
                { "HISCOBPR_IMPDH" , ""},
                { "HISCOBPR_IMPDIT" , ""},
                { "HISCOBPR_VLPREMIO" , ""},
                { "HISCOBPR_PRMVG" , ""},
                { "HISCOBPR_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_3860_HIS_COBER_PROPOST_DB_SELECT_1_Query1", q39);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VA4002B_Saida1.txt")]
        public static void VA4002B_Tests_Theory_Fact1_ReturnCode_00(string ARQEMIT_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQEMIT_FILE_NAME_P = $"{ARQEMIT_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , "2025-01-27"},
                { "SISTEMA_CURRDATE" , "2025-01-27"},
                { "SISTEMA_DTMOVABE2" , "2025-02-04"},
                { "SISTEMA_DTMOVABE3" , "2025-02-27"},
                { "SISTEMA_DTMOV015D" , "2025-02-10"},
                { "SISTEMA_DTMOV365D" , "2026-01-27"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion
                #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "MIN_PROXVEN_DATE" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q1);

                #endregion

                #region VA4002B_CPROPVA

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "3009300012344"},
                { "PROPVA_CODSUBES" , "12"},
                { "PROPVA_NRCERTIF" , "81859110329271"},
                { "PROPVA_CODPRODU" , "9721"},
                { "PROPVA_CODCLIEN" , "37724142"},
                { "PROPVA_OCOREND" , "1"},
                { "PROPVA_FONTE" , "16"},
                { "PROPVA_AGECOBR" , "1859"},
                { "PROPVA_OPCAO_COBER" , "E"},
                { "PROPVA_DTQITBCO" , "2025-01-10"},
                { "PROPVA_DTINICDG" , "2025-07-23"},
                { "PROPVA_DTINISAF" , "2025-02-23"},
                { "PROPVA_DT365DIAS" , "2026-01-23"},
                { "PROPVA_DT015DIAS" , "2025-02-07"},
                { "PROPVA_DTPROXVEN" , "2025-03-05"},
                { "PROPVA_DTMINVEN" , "2025-02-22"},
                { "PROPVA_NRMATRVEN" , "1359074"},
                { "PROPVA_CODOPER" , "106"},
                { "PROPVA_DTINCLUS" , "2025-01-24"},
                { "PROPVA_DTMOVTO" , "2025-01-24"},
                { "PROPVA_SITUACAO" , "1"},
                { "PROPVA_NUM_APOLICE1" , "3009300012344"},
                { "PROPVA_CODSUBES1" , "12"},
                { "PROPVA_OCORHIST" , "1"},
                { "PROPVA_NRPARCEL" , "1"},
                { "PROPVA_SIT_INTERF" , "0"},
                { "PROPVA_TIMESTAMP" , "2025-02-19 17:22:27.153"},
                { "PROPVA_IDADE" , "27"},
                { "PROPVA_SEXO" , "M"},
                { "PROPVA_EST_CIV" , "S"},
                { "PROPVA_COD_CRM" , ""},
                { "PROPVA_NRMATRFUN" , ""},
                { "PROPVA_DTADMIS" , ""},
                { "PROPVA_NRPROPOS" , ""},
                { "PROPVA_CODCCT" , ""},
                { "PROPVA_CODUSU" , "VA0056B "},
                { "PROPVA_DTVENCTO" , "2025-01-23"},
                { "PROPVA_FAIXA_RENDA_IND" , "1"},
                { "PROPVA_DATA" , "2025-02-19"},
                { "PROPVA_DPS_TITULAR" , ""},
                { "PROPVA_ORIGEM_PROPOSTA" , "39"},
                { "PROPVA_STA_ANTECIPACAO" , ""},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "3009300012344"},
                { "PROPVA_CODSUBES" , "12"},
                { "PROPVA_NRCERTIF" , "81859110329271"},
                { "PROPVA_CODPRODU" , "9721"},
                { "PROPVA_CODCLIEN" , "37724142"},
                { "PROPVA_OCOREND" , "1"},
                { "PROPVA_FONTE" , "16"},
                { "PROPVA_AGECOBR" , "1859"},
                { "PROPVA_OPCAO_COBER" , "E"},
                { "PROPVA_DTQITBCO" , "2025-01-23"},
                { "PROPVA_DTINICDG" , "2025-07-23"},
                { "PROPVA_DTINISAF" , "2025-02-23"},
                { "PROPVA_DT365DIAS" , "2026-01-23"},
                { "PROPVA_DT015DIAS" , "2025-02-07"},
                { "PROPVA_DTPROXVEN" , "2025-03-05"},
                { "PROPVA_DTMINVEN" , "2025-02-22"},
                { "PROPVA_NRMATRVEN" , "1359074"},
                { "PROPVA_CODOPER" , "106"},
                { "PROPVA_DTINCLUS" , "2025-01-24"},
                { "PROPVA_DTMOVTO" , "2025-01-24"},
                { "PROPVA_SITUACAO" , "1"},
                { "PROPVA_NUM_APOLICE1" , "3009300012344"},
                { "PROPVA_CODSUBES1" , "12"},
                { "PROPVA_OCORHIST" , "1"},
                { "PROPVA_NRPARCEL" , "1"},
                { "PROPVA_SIT_INTERF" , "0"},
                { "PROPVA_TIMESTAMP" , "2025-02-19 17:22:27.153"},
                { "PROPVA_IDADE" , "27"},
                { "PROPVA_SEXO" , "M"},
                { "PROPVA_EST_CIV" , "S"},
                { "PROPVA_COD_CRM" , ""},
                { "PROPVA_NRMATRFUN" , ""},
                { "PROPVA_DTADMIS" , ""},
                { "PROPVA_NRPROPOS" , ""},
                { "PROPVA_CODCCT" , ""},
                { "PROPVA_CODUSU" , "VA0056B "},
                { "PROPVA_DTVENCTO" , "2025-01-23"},
                { "PROPVA_FAIXA_RENDA_IND" , "1"},
                { "PROPVA_DATA" , "2025-02-19"},
                { "PROPVA_DPS_TITULAR" , ""},
                { "PROPVA_ORIGEM_PROPOSTA" , "39"},
                { "PROPVA_STA_ANTECIPACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VA4002B_CPROPVA");
                AppSettings.TestSet.DynamicData.Add("VA4002B_CPROPVA", q2);

                #endregion
                #region M_0000_PRINCIPAL_DB_SELECT_4_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NRTIT" , "12"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_4_Query1", q6);

                #endregion

                #region M_2000_PESQUISA_OPCPAG_DB_SELECT_1_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_OPCAOPAG" , "5"},
                { "OPCAOP_PERIPGTO" , "12"},
                { "OPCAOP_DIA_DEB" , "9"},
                { "OPCAOP_AGECTADEB" , ""},
                { "OPCAOP_OPRCTADEB" , ""},
                { "OPCAOP_NUMCTADEB" , ""},
                { "OPCAOP_DIGCTADEB" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_2000_PESQUISA_OPCPAG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_2000_PESQUISA_OPCPAG_DB_SELECT_1_Query1", q22);

                #endregion
                #region M_1330_COUNT_ERRO_OPC_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNTERRO_OPC" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1330_COUNT_ERRO_OPC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1330_COUNT_ERRO_OPC_DB_SELECT_1_Query1", q12);

                #endregion
                #region M_1340_PESQUISA_ERRO_2005_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNTERRO_OPC" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1340_PESQUISA_ERRO_2005_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1340_PESQUISA_ERRO_2005_DB_SELECT_1_Query1", q13);

                #endregion
                #region M_1310_PESQUISA_SEGURADO_VGAP_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_1310_PESQUISA_SEGURADO_VGAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1310_PESQUISA_SEGURADO_VGAP_DB_SELECT_1_Query1", q11);

                #endregion
                #region M_1380_PESQUISA_APOLICOB_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT_APOLICOB" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1380_PESQUISA_APOLICOB_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1380_PESQUISA_APOLICOB_DB_SELECT_1_Query1", q18);

                #endregion

                #region M_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT_MOVIMENTO" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1_Query1", q20);

                #endregion
                #region M_3810_ACESSA_FONTE_DB_SELECT_1_Query1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , "14209"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_3810_ACESSA_FONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_3810_ACESSA_FONTE_DB_SELECT_1_Query1", q33);

                #endregion
                #region M_3860_HIS_COBER_PROPOST_DB_SELECT_1_Query1

                var q39 = new DynamicData();
                q39.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_IMP_MORNATU" , "12000.00"},
                { "HISCOBPR_IMPMORACID" , "24000.00"},
                { "HISCOBPR_IMPINVPERM" , "12000.00"},
                { "HISCOBPR_IMPAMDS" , ""},
                { "HISCOBPR_IMPDH" , ""},
                { "HISCOBPR_IMPDIT" , ""},
                { "HISCOBPR_VLPREMIO" , "94.40"},
                { "HISCOBPR_PRMVG" , "71.70"},
                { "HISCOBPR_PRMAP" , "22.70"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_3860_HIS_COBER_PROPOST_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_3860_HIS_COBER_PROPOST_DB_SELECT_1_Query1", q39);

                #endregion
                #endregion
                var program = new VA4002B();
                program.Execute(ARQEMIT_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                //M_0000_PRINCIPAL_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["M_0000_PRINCIPAL_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("BANCOS_NRTIT", out var valor0) && valor0.Contains("0"));

                //M_1300_INTEGRA_PROPOSTA_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["M_1300_INTEGRA_PROPOSTA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("PROPVA_NRMATRVEN", out var valor1) && valor1.Contains("000000001359074"));

                //M_1350_UPDATE_OPCPAGVI_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["M_1350_UPDATE_OPCPAGVI_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("PROPVA_NRCERTIF", out var valor2) && valor2.Contains("081859110329271"));

                //M_1355_UPDATE_DIA_DEBITO_DB_UPDATE_1_Update1
                var envList3 = AppSettings.TestSet.DynamicData["M_1355_UPDATE_DIA_DEBITO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("OPCAOP_DIA_DEB", out var valor3) && valor3.Contains("0010"));

                //M_3200_UPDATE_V0APOLICE_DB_UPDATE_1_Update1
                var envList4 = AppSettings.TestSet.DynamicData["M_3200_UPDATE_V0APOLICE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("PROPVA_NUM_APOLICE", out var valor4) && valor4.Contains("3009300012344"));

                //M_3500_INSERT_SEGURVGA_DB_INSERT_1_Insert1
                var envList5 = AppSettings.TestSet.DynamicData["M_3500_INSERT_SEGURVGA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("PROPVA_CODCLIEN", out var valor5) && valor5.Contains("037724142"));
                Assert.True(envList5.Count > 1);

                //M_3600_INSERT_HIST_SEGURVGA_DB_INSERT_1_Insert1
                var envList6 = AppSettings.TestSet.DynamicData["M_3600_INSERT_HIST_SEGURVGA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList6[1].TryGetValue("PROPVA_CODSUBES", out var valor6) && valor6.Contains("0012"));
                Assert.True(envList6.Count > 1);

                //M_3700_00_INSERT_APOLICOB_DB_INSERT_1_Insert1
                var envList7 = AppSettings.TestSet.DynamicData["M_3700_00_INSERT_APOLICOB_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList7[1].TryGetValue("PROPVA_DTQITBCO", out var valor7) && valor7.Contains("2025-01-10"));
                Assert.True(envList7.Count > 1);

                //M_3800_INSERT_MOVIMENTO_DB_INSERT_1_Insert1
                var envList8 = AppSettings.TestSet.DynamicData["M_3800_INSERT_MOVIMENTO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList8[1].TryGetValue("FONTE_PROPAUTOM", out var valor8) && valor8.Contains("000014210"));
                Assert.True(envList8.Count > 1);

                //M_3820_ATUALIZA_FONTE_DB_UPDATE_1_Update1
                var envList9 = AppSettings.TestSet.DynamicData["M_3820_ATUALIZA_FONTE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList9[1].TryGetValue("PROPVA_FONTE", out var valor9) && valor9.Contains("0016"));

            }
        }
        [Theory]
        [InlineData("VA4002B_Saida2.txt")]
        public static void VA4002B_Tests_Theory_Fact2_ReturnCode_00(string ARQEMIT_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQEMIT_FILE_NAME_P = $"{ARQEMIT_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , "2025-01-27"},
                { "SISTEMA_CURRDATE" , "2025-01-27"},
                { "SISTEMA_DTMOVABE2" , "2025-02-04"},
                { "SISTEMA_DTMOVABE3" , "2025-02-27"},
                { "SISTEMA_DTMOV015D" , "2025-02-10"},
                { "SISTEMA_DTMOV365D" , "2026-01-27"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion
                #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "MIN_PROXVEN_DATE" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q1);

                #endregion

                #region VA4002B_CPROPVA

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "3009300012344"},
                { "PROPVA_CODSUBES" , "12"},
                { "PROPVA_NRCERTIF" , "81859110329271"},
                { "PROPVA_CODPRODU" , "9721"},
                { "PROPVA_CODCLIEN" , "9999"},
                { "PROPVA_OCOREND" , "1"},
                { "PROPVA_FONTE" , "16"},
                { "PROPVA_AGECOBR" , "1859"},
                { "PROPVA_OPCAO_COBER" , "E"},
                { "PROPVA_DTQITBCO" , "2025-01-10"},
                { "PROPVA_DTINICDG" , "2025-07-23"},
                { "PROPVA_DTINISAF" , "2025-02-23"},
                { "PROPVA_DT365DIAS" , "2026-01-23"},
                { "PROPVA_DT015DIAS" , "2025-02-07"},
                { "PROPVA_DTPROXVEN" , "2025-03-05"},
                { "PROPVA_DTMINVEN" , "2025-02-22"},
                { "PROPVA_NRMATRVEN" , "1359074"},
                { "PROPVA_CODOPER" , "106"},
                { "PROPVA_DTINCLUS" , "2025-01-24"},
                { "PROPVA_DTMOVTO" , "2025-01-24"},
                { "PROPVA_SITUACAO" , "1"},
                { "PROPVA_NUM_APOLICE1" , "3009300012344"},
                { "PROPVA_CODSUBES1" , "12"},
                { "PROPVA_OCORHIST" , "1"},
                { "PROPVA_NRPARCEL" , "1"},
                { "PROPVA_SIT_INTERF" , "0"},
                { "PROPVA_TIMESTAMP" , "2025-02-19 17:22:27.153"},
                { "PROPVA_IDADE" , "27"},
                { "PROPVA_SEXO" , "M"},
                { "PROPVA_EST_CIV" , "S"},
                { "PROPVA_COD_CRM" , ""},
                { "PROPVA_NRMATRFUN" , ""},
                { "PROPVA_DTADMIS" , ""},
                { "PROPVA_NRPROPOS" , ""},
                { "PROPVA_CODCCT" , ""},
                { "PROPVA_CODUSU" , "VA0056B "},
                { "PROPVA_DTVENCTO" , "2025-01-23"},
                { "PROPVA_FAIXA_RENDA_IND" , "1"},
                { "PROPVA_DATA" , "2025-02-19"},
                { "PROPVA_DPS_TITULAR" , ""},
                { "PROPVA_ORIGEM_PROPOSTA" , "39"},
                { "PROPVA_STA_ANTECIPACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("VA4002B_CPROPVA");
                AppSettings.TestSet.DynamicData.Add("VA4002B_CPROPVA", q2);

                #endregion
                #region M_0000_PRINCIPAL_DB_SELECT_4_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NRTIT" , "12"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_4_Query1", q6);

                #endregion

                #region M_2000_PESQUISA_OPCPAG_DB_SELECT_1_Query1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "OPCAOP_OPCAOPAG" , "5"},
                { "OPCAOP_PERIPGTO" , "12"},
                { "OPCAOP_DIA_DEB" , "9"},
                { "OPCAOP_AGECTADEB" , ""},
                { "OPCAOP_OPRCTADEB" , ""},
                { "OPCAOP_NUMCTADEB" , ""},
                { "OPCAOP_DIGCTADEB" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("M_2000_PESQUISA_OPCPAG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_2000_PESQUISA_OPCPAG_DB_SELECT_1_Query1", q22);

                #endregion
                #region M_1330_COUNT_ERRO_OPC_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNTERRO_OPC" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1330_COUNT_ERRO_OPC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1330_COUNT_ERRO_OPC_DB_SELECT_1_Query1", q12);

                #endregion
                #region M_1340_PESQUISA_ERRO_2005_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNTERRO_OPC" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1340_PESQUISA_ERRO_2005_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1340_PESQUISA_ERRO_2005_DB_SELECT_1_Query1", q13);

                #endregion
                #region M_1310_PESQUISA_SEGURADO_VGAP_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_1310_PESQUISA_SEGURADO_VGAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1310_PESQUISA_SEGURADO_VGAP_DB_SELECT_1_Query1", q11);

                #endregion
                #region M_1380_PESQUISA_APOLICOB_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT_APOLICOB" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1380_PESQUISA_APOLICOB_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1380_PESQUISA_APOLICOB_DB_SELECT_1_Query1", q18);

                #endregion

                #region M_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT_MOVIMENTO" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1_Query1", q20);

                #endregion
                #region M_3810_ACESSA_FONTE_DB_SELECT_1_Query1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "FONTE_PROPAUTOM" , "14209"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_3810_ACESSA_FONTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_3810_ACESSA_FONTE_DB_SELECT_1_Query1", q33);

                #endregion
                #region M_3860_HIS_COBER_PROPOST_DB_SELECT_1_Query1

                var q39 = new DynamicData();
                q39.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_IMP_MORNATU" , "12000.00"},
                { "HISCOBPR_IMPMORACID" , "24000.00"},
                { "HISCOBPR_IMPINVPERM" , "12000.00"},
                { "HISCOBPR_IMPAMDS" , ""},
                { "HISCOBPR_IMPDH" , ""},
                { "HISCOBPR_IMPDIT" , ""},
                { "HISCOBPR_VLPREMIO" , "94.40"},
                { "HISCOBPR_PRMVG" , "71.70"},
                { "HISCOBPR_PRMAP" , "22.70"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_3860_HIS_COBER_PROPOST_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_3860_HIS_COBER_PROPOST_DB_SELECT_1_Query1", q39);

                #endregion
                #endregion
                var program = new VA4002B();
                program.Execute(ARQEMIT_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                //M_0000_PRINCIPAL_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["M_0000_PRINCIPAL_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("BANCOS_NRTIT", out var valor0) && valor0.Contains("0000000000012"));

                //M_1060_UPD_PROPOSTA_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["M_1060_UPD_PROPOSTA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("PROPVA_NRCERTIF", out var valor1) && valor1.Contains("081859110329271"));
            }
        }
        [Theory]
        [InlineData("VA4002B_Saida3.txt")]
        public static void VA4002B_Tests_Theory_Fact3_Error_ReturnCode_9(string ARQEMIT_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQEMIT_FILE_NAME_P = $"{ARQEMIT_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , "2025-01-27"},
                { "SISTEMA_CURRDATE" , "2025-01-27"},
                { "SISTEMA_DTMOVABE2" , "2025-02-04"},
                { "SISTEMA_DTMOVABE3" , "2025-02-27"},
                { "SISTEMA_DTMOV015D" , "2025-02-10"},
                { "SISTEMA_DTMOV365D" , "2026-01-27"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

                #endregion
                #region M_0000_PRINCIPAL_DB_SELECT_2_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "MIN_PROXVEN_DATE" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_2_Query1", q1);

                #endregion

                #region VA4002B_CPROPVA

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , "3009300012344"},
                { "PROPVA_CODSUBES" , "12"},
                { "PROPVA_NRCERTIF" , "81859110329271"},
                { "PROPVA_CODPRODU" , "9721"},
                { "PROPVA_CODCLIEN" , "9999"},
                { "PROPVA_OCOREND" , "1"},
                { "PROPVA_FONTE" , "16"},
                { "PROPVA_AGECOBR" , ""},
                { "PROPVA_OPCAO_COBER" , ""},
                { "PROPVA_DTQITBCO" , ""},
                { "PROPVA_DTINICDG" , ""},
                { "PROPVA_DTINISAF" , ""},
                { "PROPVA_DT365DIAS" , ""},
                { "PROPVA_DT015DIAS" , ""},
                { "PROPVA_DTPROXVEN" , ""},
                { "PROPVA_DTMINVEN" , ""},
                { "PROPVA_NRMATRVEN" , ""},
                { "PROPVA_CODOPER" , ""},
                { "PROPVA_DTINCLUS" , ""},
                { "PROPVA_DTMOVTO" , ""},
                { "PROPVA_SITUACAO" , ""},
                { "PROPVA_NUM_APOLICE1" , "3009300012344"},
                { "PROPVA_CODSUBES1" , "12"},
                { "PROPVA_OCORHIST" , ""},
                { "PROPVA_NRPARCEL" , ""},
                { "PROPVA_SIT_INTERF" , ""},
                { "PROPVA_TIMESTAMP" , ""},
                { "PROPVA_IDADE" , ""},
                { "PROPVA_SEXO" , ""},
                { "PROPVA_EST_CIV" , ""},
                { "PROPVA_COD_CRM" , ""},
                { "PROPVA_NRMATRFUN" , ""},
                { "PROPVA_DTADMIS" , ""},
                { "PROPVA_NRPROPOS" , ""},
                { "PROPVA_CODCCT" , ""},
                { "PROPVA_CODUSU" , ""},
                { "PROPVA_DTVENCTO" , ""},
                { "PROPVA_FAIXA_RENDA_IND" , ""},
                { "PROPVA_DATA" , ""},
                { "PROPVA_DPS_TITULAR" , ""},
                { "PROPVA_ORIGEM_PROPOSTA" , ""},
                { "PROPVA_STA_ANTECIPACAO" , ""},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("VA4002B_CPROPVA");
                AppSettings.TestSet.DynamicData.Add("VA4002B_CPROPVA", q2);

                #endregion
                #region M_0000_PRINCIPAL_DB_SELECT_4_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "BANCOS_NRTIT" , "12"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0000_PRINCIPAL_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_4_Query1", q6);

                #endregion
                #endregion
                var program = new VA4002B();
                program.Execute(ARQEMIT_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 9);

            }
        }

    }
}