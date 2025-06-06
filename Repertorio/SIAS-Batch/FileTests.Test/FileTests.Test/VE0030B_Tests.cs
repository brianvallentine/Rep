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
using static Code.VE0030B;

namespace FileTests.Test
{
    [Collection("VE0030B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    public class VE0030B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2020-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region VE0030B_V0RELATORIOS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1REL_COD_USUR" , ""},
                { "V1REL_NUM_APOL" , ""},
                { "V1REL_COD_SUBG" , ""},
                { "V1REL_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0030B_V0RELATORIOS", q1);

            #endregion

            #region VE0030B_V1ENDOSSO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_NUM_APOL" , ""},
                { "V1ENDO_NRENDOS" , ""},
                { "V1ENDO_DTEMIS" , ""},
                { "V1ENDO_DTINIVIG" , ""},
                { "V1ENDO_DTTERVIG" , ""},
                { "V1ENDO_BCORCAP" , ""},
                { "V1ENDO_AGERCAP" , ""},
                { "V1ENDO_DACRCAP" , ""},
                { "V1ENDO_BCOCOBR" , ""},
                { "V1ENDO_AGECOBR" , ""},
                { "V1ENDO_DACCOBR" , ""},
                { "V1ENDO_QTPARCEL" , ""},
                { "V1ENDO_ORGAO" , ""},
                { "V1ENDO_RAMO" , ""},
                { "V1ENDO_CODPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0030B_V1ENDOSSO", q2);

            #endregion

            #region R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0TERMO_NUM_TERMO" , ""},
                { "V0TERMO_NUM_APOLICE" , ""},
                { "V0TERMO_COD_SUBG" , ""},
                { "V0TERMO_DT_ADESAO" , ""},
                { "V0TERMO_DTADESAO_3M" , ""},
                { "V0TERMO_COD_AGE_OP" , ""},
                { "V0TERMO_MAT_VEN" , ""},
                { "V0TERMO_CODPDTVEN" , ""},
                { "V0TERMO_PCCOMVEN" , ""},
                { "V0TERMO_CODPDTGER" , ""},
                { "V0TERMO_PCCOMGER" , ""},
                { "V0TERMO_PLANO_VGAP" , ""},
                { "V0TERMO_PLANO_APC" , ""},
                { "V0TERMO_VL_COMI_AD" , ""},
                { "V0TERMO_QTD_VIDAS" , ""},
                { "V0TERMO_PERI_PGTO" , ""},
                { "V0TERMO_COD_USUR" , ""},
                { "V0TERMO_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1", q3);

            #endregion

            #region VE0030B_V0COMISSAO

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0COMI_NUM_APOL" , ""},
                { "V0COMI_NRENDOS" , ""},
                { "V0COMI_NRCERTIF" , ""},
                { "V0COMI_DIGCERT" , ""},
                { "V0COMI_IDTPSEGU" , ""},
                { "V0COMI_NRPARCEL" , ""},
                { "V0COMI_OPERACAO" , ""},
                { "V0COMI_CODPDT" , ""},
                { "V0COMI_RAMOFR" , ""},
                { "V0COMI_MODALIFR" , ""},
                { "V0COMI_OCORHIST" , ""},
                { "V0COMI_FONTE" , ""},
                { "V0COMI_CODCLIEN" , ""},
                { "V0COMI_VLCOMIS" , ""},
                { "V0COMI_DATCLO" , ""},
                { "V0COMI_NUMREC" , ""},
                { "V0COMI_VALBAS" , ""},
                { "V0COMI_TIPCOM" , ""},
                { "V0COMI_QTPARCEL" , ""},
                { "V0COMI_PCCOMCOR" , ""},
                { "V0COMI_PCDESCON" , ""},
                { "V0COMI_CODSUBES" , ""},
                { "V0COMI_DTMOVTO" , ""},
                { "V0COMI_DATSEL" , ""},
                { "V0COMI_COD_EMPRESA" , ""},
                { "V0COMI_CODPRP" , ""},
                { "V0COMI_NUMBIL" , ""},
                { "V0COMI_VLVARMON" , ""},
                { "V0COMI_DTQITBCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0030B_V0COMISSAO", q4);

            #endregion

            #region R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1REL_NUM_APOL" , ""},
                { "V1REL_COD_SUBG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1AGENC_COD_AGENCIA" , ""},
                { "V1AGENC_COD_SUREG" , ""},
                { "V1AGENC_COD_ESCNEG" , ""},
                { "V1AGENC_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1MALHA_COD_SUREG" , ""},
                { "V1MALHA_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0PRODC_DTOPER" , ""},
                { "V0PRODC_COD_AGENC" , ""},
                { "V0PRODC_CODPRODAZ" , ""},
                { "V0PRODC_NUM_MATRIC" , ""},
                { "V0PRODC_COD_OPER" , ""},
                { "V0PRODC_COD_FONTE" , ""},
                { "V0PRODC_NUM_PROPO" , ""},
                { "V0PRODC_QTD_REALI" , ""},
                { "V0PRODC_VL_COMI_RE" , ""},
                { "V0PRODC_COD_PLANO" , ""},
                { "V0PRODC_DT_REFER" , ""},
                { "V0PRODC_SIT_CAMPAN" , ""},
                { "V0PRODC_SIT_INTERF" , ""},
                { "V0PRODC_SIT_DIARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1", q8);

            #endregion

            #region VE0030B_V1PARCELA

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUM_APOL" , ""},
                { "V1PARC_NRENDOS" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1PARC_DACPARC" , ""},
                { "V1PARC_FONTE" , ""},
                { "V1PARC_NRTIT" , ""},
                { "V1PARC_OCORHIST" , ""},
                { "V1PARC_QTDDOC" , ""},
                { "V1PARC_SITUACAO" , ""},
                { "V1PARC_COD_EMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0030B_V1PARCELA", q9);

            #endregion

            #region R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0COMI_NUM_APOL" , ""},
                { "V0COMI_NRENDOS" , ""},
                { "V0COMI_NRCERTIF" , ""},
                { "V0COMI_DIGCERT" , ""},
                { "V0COMI_IDTPSEGU" , ""},
                { "V0COMI_NRPARCEL" , ""},
                { "V0COMI_OPERACAO" , ""},
                { "V0COMI_CODPDT" , ""},
                { "V0COMI_RAMOFR" , ""},
                { "V0COMI_MODALIFR" , ""},
                { "V0COMI_OCORHIST" , ""},
                { "V0COMI_FONTE" , ""},
                { "V0COMI_CODCLIEN" , ""},
                { "V0COMI_VLCOMIS" , ""},
                { "V0COMI_DATCLO" , ""},
                { "V0COMI_NUMREC" , ""},
                { "V0COMI_VALBAS" , ""},
                { "V0COMI_TIPCOM" , ""},
                { "V0COMI_QTPARCEL" , ""},
                { "V0COMI_PCCOMCOR" , ""},
                { "V0COMI_PCDESCON" , ""},
                { "V0COMI_CODSUBES" , ""},
                { "V0COMI_DATSEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1", q10);

            #endregion

            #region R0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1PROD_COD_ESCNEG" , ""},
                { "V1PROD_DTINIVIG" , ""},
                { "V1PROD_DTTERVIG" , ""},
                { "V1PROD_NUM_MATRIC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1FUNC_NUM_MATRIC" , ""},
                { "V1FUNC_COD_ANGARIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V1REL_COD_USUR" , ""},
                { "V0TERMO_NUM_TERMO" , ""},
                { "V0TERMO_COD_SUBG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1", q13);

            #endregion

            #region R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V1REL_NUM_APOL" , ""},
                { "V1REL_COD_SUBG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1", q14);

            #endregion

            #region R0420_00_CANCELA_V0PROPOSTAVA_DB_UPDATE_1_Update1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V1REL_COD_USUR" , ""},
                { "V1REL_NUM_APOL" , ""},
                { "V1REL_COD_SUBG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0420_00_CANCELA_V0PROPOSTAVA_DB_UPDATE_1_Update1", q15);

            #endregion

            #region R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0NAES_NRENDOCA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1", q16);

            #endregion

            #region R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V0NAES_NRENDOCA" , ""},
                { "V1ENDO_ORGAO" , ""},
                { "V1ENDO_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1", q17);

            #endregion

            #region R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "WP_PRM_TAR" , ""},
                { "WP_VAL_DESC" , ""},
                { "WP_VLPRMLIQ" , ""},
                { "WP_VLADIFRA" , ""},
                { "WP_VLCUSEMI" , ""},
                { "WP_VLIOCC" , ""},
                { "WP_VLPRMTOT" , ""},
                { "WP_VLPREMIO" , ""},
                { "V1HISP_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1", q18);

            #endregion

            #region R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "WC_PRM_TAR" , ""},
                { "WC_VAL_DESC" , ""},
                { "WC_VLPRMLIQ" , ""},
                { "WC_VLADIFRA" , ""},
                { "WC_VLCUSEMI" , ""},
                { "WC_VLIOCC" , ""},
                { "WC_VLPRMTOT" , ""},
                { "WC_VLPREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1", q19);

            #endregion

            #region R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , ""},
                { "V0HISP_NRENDOS" , ""},
                { "V0HISP_NRPARCEL" , ""},
                { "V0HISP_DACPARC" , ""},
                { "V0HISP_DTMOVTO" , ""},
                { "V0HISP_OPERACAO" , ""},
                { "V0HISP_HORAOPER" , ""},
                { "V0HISP_OCORHIST" , ""},
                { "V0HISP_PRM_TAR" , ""},
                { "V0HISP_VAL_DESC" , ""},
                { "V0HISP_VLPRMLIQ" , ""},
                { "V0HISP_VLADIFRA" , ""},
                { "V0HISP_VLCUSEMI" , ""},
                { "V0HISP_VLIOCC" , ""},
                { "V0HISP_VLPRMTOT" , ""},
                { "V0HISP_VLPREMIO" , ""},
                { "V0HISP_DTVENCTO" , ""},
                { "V0HISP_BCOCOBR" , ""},
                { "V0HISP_AGECOBR" , ""},
                { "V0HISP_NRAVISO" , ""},
                { "V0HISP_NRENDOCA" , ""},
                { "V0HISP_SITCONTB" , ""},
                { "V0HISP_COD_USUARIO" , ""},
                { "V0HISP_RNUDOC" , ""},
                { "V0HISP_DTQITBCO" , ""},
                { "V0HISP_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q20);

            #endregion

            #region R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "WOCORHIST" , ""},
                { "V1PARC_NUM_APOL" , ""},
                { "V0HISP_NRPARCEL" , ""},
                { "V1PARC_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1", q21);

            #endregion

            #region R6100_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V0HISP_NUM_APOL" , ""},
                { "V0HISP_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6100_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1", q22);

            #endregion

            #endregion
        }

        [Fact]
        public static void VE0030B_Tests_Fact_ReturnCode00_Updates()
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
                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1SIST_DTMOVABE" , "2024-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region VE0030B_V0RELATORIOS

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V1REL_COD_USUR" , ""},
                    { "V1REL_NUM_APOL" , ""},
                    { "V1REL_COD_SUBG" , ""},
                    { "V1REL_SIT_REGISTRO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("VE0030B_V0RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("VE0030B_V0RELATORIOS", q1);

                #endregion

                #region VE0030B_V1ENDOSSO

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V1ENDO_NUM_APOL" , ""},
                    { "V1ENDO_NRENDOS" , ""},
                    { "V1ENDO_DTEMIS" , ""},
                    { "V1ENDO_DTINIVIG" , "2020-01-01"},
                    { "V1ENDO_DTTERVIG" , "2020-01-01"},
                    { "V1ENDO_BCORCAP" , ""},
                    { "V1ENDO_AGERCAP" , ""},
                    { "V1ENDO_DACRCAP" , ""},
                    { "V1ENDO_BCOCOBR" , ""},
                    { "V1ENDO_AGECOBR" , ""},
                    { "V1ENDO_DACCOBR" , ""},
                    { "V1ENDO_QTPARCEL" , ""},
                    { "V1ENDO_ORGAO" , ""},
                    { "V1ENDO_RAMO" , ""},
                    { "V1ENDO_CODPRODU" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("VE0030B_V1ENDOSSO");
                AppSettings.TestSet.DynamicData.Add("VE0030B_V1ENDOSSO", q2);

                #endregion

                #region R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0TERMO_NUM_TERMO" , ""},
                    { "V0TERMO_NUM_APOLICE" , ""},
                    { "V0TERMO_COD_SUBG" , ""},
                    { "V0TERMO_DT_ADESAO" , "2020-01-01"},
                    { "V0TERMO_DTADESAO_3M" , "2021-01-01"},
                    { "V0TERMO_COD_AGE_OP" , ""},
                    { "V0TERMO_MAT_VEN" , ""},
                    { "V0TERMO_CODPDTVEN" , ""},
                    { "V0TERMO_PCCOMVEN" , ""},
                    { "V0TERMO_CODPDTGER" , ""},
                    { "V0TERMO_PCCOMGER" , ""},
                    { "V0TERMO_PLANO_VGAP" , ""},
                    { "V0TERMO_PLANO_APC" , ""},
                    { "V0TERMO_VL_COMI_AD" , ""},
                    { "V0TERMO_QTD_VIDAS" , ""},
                    { "V0TERMO_PERI_PGTO" , ""},
                    { "V0TERMO_COD_USUR" , ""},
                    { "V0TERMO_SITUACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1", q3);

                #endregion

                #region VE0030B_V0COMISSAO

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0COMI_NUM_APOL" , ""},
                    { "V0COMI_NRENDOS" , ""},
                    { "V0COMI_NRCERTIF" , ""},
                    { "V0COMI_DIGCERT" , ""},
                    { "V0COMI_IDTPSEGU" , ""},
                    { "V0COMI_NRPARCEL" , ""},
                    { "V0COMI_OPERACAO" , ""},
                    { "V0COMI_CODPDT" , ""},
                    { "V0COMI_RAMOFR" , ""},
                    { "V0COMI_MODALIFR" , ""},
                    { "V0COMI_OCORHIST" , ""},
                    { "V0COMI_FONTE" , ""},
                    { "V0COMI_CODCLIEN" , ""},
                    { "V0COMI_VLCOMIS" , ""},
                    { "V0COMI_DATCLO" , ""},
                    { "V0COMI_NUMREC" , ""},
                    { "V0COMI_VALBAS" , ""},
                    { "V0COMI_TIPCOM" , ""},
                    { "V0COMI_QTPARCEL" , ""},
                    { "V0COMI_PCCOMCOR" , ""},
                    { "V0COMI_PCDESCON" , ""},
                    { "V0COMI_CODSUBES" , ""},
                    { "V0COMI_DTMOVTO" , "2020-01-01"},
                    { "V0COMI_DATSEL" , "2020-02-01"},
                    { "V0COMI_COD_EMPRESA" , ""},
                    { "V0COMI_CODPRP" , ""},
                    { "V0COMI_NUMBIL" , ""},
                    { "V0COMI_VLVARMON" , ""},
                    { "V0COMI_DTQITBCO" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("VE0030B_V0COMISSAO");
                AppSettings.TestSet.DynamicData.Add("VE0030B_V0COMISSAO", q4);

                #endregion

                #region R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V1REL_NUM_APOL" , ""},
                    { "V1REL_COD_SUBG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1", q5);

                #endregion

                #region R0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V1AGENC_COD_AGENCIA" , ""},
                    { "V1AGENC_COD_SUREG" , ""},
                    { "V1AGENC_COD_ESCNEG" , ""},
                    { "V1AGENC_SITUACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1", q6);

                #endregion

                #region R0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V1MALHA_COD_SUREG" , ""},
                    { "V1MALHA_COD_FONTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1", q7);

                #endregion

                #region R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V0PRODC_DTOPER" , ""},
                    { "V0PRODC_COD_AGENC" , ""},
                    { "V0PRODC_CODPRODAZ" , ""},
                    { "V0PRODC_NUM_MATRIC" , ""},
                    { "V0PRODC_COD_OPER" , ""},
                    { "V0PRODC_COD_FONTE" , ""},
                    { "V0PRODC_NUM_PROPO" , ""},
                    { "V0PRODC_QTD_REALI" , ""},
                    { "V0PRODC_VL_COMI_RE" , ""},
                    { "V0PRODC_COD_PLANO" , ""},
                    { "V0PRODC_DT_REFER" , ""},
                    { "V0PRODC_SIT_CAMPAN" , ""},
                    { "V0PRODC_SIT_INTERF" , ""},
                    { "V0PRODC_SIT_DIARIO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1", q8);

                #endregion

                #region VE0030B_V1PARCELA

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "V1PARC_NUM_APOL" , ""},
                    { "V1PARC_NRENDOS" , ""},
                    { "V1PARC_NRPARCEL" , ""},
                    { "V1PARC_DACPARC" , ""},
                    { "V1PARC_FONTE" , ""},
                    { "V1PARC_NRTIT" , ""},
                    { "V1PARC_OCORHIST" , ""},
                    { "V1PARC_QTDDOC" , ""},
                    { "V1PARC_SITUACAO" , ""},
                    { "V1PARC_COD_EMP" , ""}
                });

                AppSettings.TestSet.DynamicData.Remove("VE0030B_V1PARCELA");
                AppSettings.TestSet.DynamicData.Add("VE0030B_V1PARCELA", q9);

                #endregion

                #region R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "V0COMI_NUM_APOL" , ""},
                    { "V0COMI_NRENDOS" , ""},
                    { "V0COMI_NRCERTIF" , ""},
                    { "V0COMI_DIGCERT" , ""},
                    { "V0COMI_IDTPSEGU" , ""},
                    { "V0COMI_NRPARCEL" , ""},
                    { "V0COMI_OPERACAO" , ""},
                    { "V0COMI_CODPDT" , ""},
                    { "V0COMI_RAMOFR" , ""},
                    { "V0COMI_MODALIFR" , ""},
                    { "V0COMI_OCORHIST" , ""},
                    { "V0COMI_FONTE" , ""},
                    { "V0COMI_CODCLIEN" , ""},
                    { "V0COMI_VLCOMIS" , ""},
                    { "V0COMI_DATCLO" , ""},
                    { "V0COMI_NUMREC" , ""},
                    { "V0COMI_VALBAS" , ""},
                    { "V0COMI_TIPCOM" , ""},
                    { "V0COMI_QTPARCEL" , ""},
                    { "V0COMI_PCCOMCOR" , ""},
                    { "V0COMI_PCDESCON" , ""},
                    { "V0COMI_CODSUBES" , ""},
                    { "V0COMI_DATSEL" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1", q10);

                #endregion

                #region R0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V1PROD_COD_ESCNEG" , ""},
                    { "V1PROD_DTINIVIG" , "2020-01-01"},
                    { "V1PROD_DTTERVIG" , "2020-01-01"},
                    { "V1PROD_NUM_MATRIC" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1", q11);

                #endregion

                #region R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "V1FUNC_NUM_MATRIC" , ""},
                    { "V1FUNC_COD_ANGARIA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1", q12);

                #endregion

                #region R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "V1REL_COD_USUR" , ""},
                    { "V0TERMO_NUM_TERMO" , ""},
                    { "V0TERMO_COD_SUBG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1", q13);

                #endregion

                #region R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "V1REL_NUM_APOL" , ""},
                    { "V1REL_COD_SUBG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1", q14);

                #endregion

                #region R0420_00_CANCELA_V0PROPOSTAVA_DB_UPDATE_1_Update1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "V1REL_COD_USUR" , ""},
                    { "V1REL_NUM_APOL" , ""},
                    { "V1REL_COD_SUBG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0420_00_CANCELA_V0PROPOSTAVA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0420_00_CANCELA_V0PROPOSTAVA_DB_UPDATE_1_Update1", q15);

                #endregion

                #region R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "V0NAES_NRENDOCA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1", q16);

                #endregion

                #region R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "V0NAES_NRENDOCA" , ""},
                    { "V1ENDO_ORGAO" , ""},
                    { "V1ENDO_RAMO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1", q17);

                #endregion

                #region R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "WP_PRM_TAR" , ""},
                    { "WP_VAL_DESC" , ""},
                    { "WP_VLPRMLIQ" , ""},
                    { "WP_VLADIFRA" , ""},
                    { "WP_VLCUSEMI" , ""},
                    { "WP_VLIOCC" , ""},
                    { "WP_VLPRMTOT" , ""},
                    { "WP_VLPREMIO" , ""},
                    { "V1HISP_DTVENCTO" , "2020-10-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1", q18);

                #endregion

                #region R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "WC_PRM_TAR" , "0"},
                    { "WC_VAL_DESC" , "0"},
                    { "WC_VLPRMLIQ" , "0"},
                    { "WC_VLADIFRA" , "0"},
                    { "WC_VLCUSEMI" , "0"},
                    { "WC_VLIOCC" , "0"},
                    { "WC_VLPRMTOT" , "2"},
                    { "WC_VLPREMIO" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1", q19);

                #endregion

                #region R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "V0HISP_NUM_APOL" , ""},
                    { "V0HISP_NRENDOS" , ""},
                    { "V0HISP_NRPARCEL" , ""},
                    { "V0HISP_DACPARC" , ""},
                    { "V0HISP_DTMOVTO" , ""},
                    { "V0HISP_OPERACAO" , ""},
                    { "V0HISP_HORAOPER" , ""},
                    { "V0HISP_OCORHIST" , ""},
                    { "V0HISP_PRM_TAR" , ""},
                    { "V0HISP_VAL_DESC" , ""},
                    { "V0HISP_VLPRMLIQ" , ""},
                    { "V0HISP_VLADIFRA" , ""},
                    { "V0HISP_VLCUSEMI" , ""},
                    { "V0HISP_VLIOCC" , ""},
                    { "V0HISP_VLPRMTOT" , ""},
                    { "V0HISP_VLPREMIO" , ""},
                    { "V0HISP_DTVENCTO" , ""},
                    { "V0HISP_BCOCOBR" , ""},
                    { "V0HISP_AGECOBR" , ""},
                    { "V0HISP_NRAVISO" , ""},
                    { "V0HISP_NRENDOCA" , ""},
                    { "V0HISP_SITCONTB" , ""},
                    { "V0HISP_COD_USUARIO" , ""},
                    { "V0HISP_RNUDOC" , ""},
                    { "V0HISP_DTQITBCO" , ""},
                    { "V0HISP_COD_EMPRESA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q20);

                #endregion

                #region R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                    { "WOCORHIST" , "0"},
                    { "V1PARC_NUM_APOL" , "0"},
                    { "V0HISP_NRPARCEL" , "0"},
                    { "V1PARC_NRENDOS" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1", q21);

                #endregion

                #region R6100_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                    { "V0HISP_NUM_APOL" , ""},
                    { "V0HISP_NRENDOS" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R6100_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R6100_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1", q22);

                #endregion

                #endregion
                var program = new VE0030B();
                program.Execute();

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();

                Assert.True(updates.Count >= allUpdates.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void VE0030B_Tests_Fact_ReturnCode00_Inserts()
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
                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1SIST_DTMOVABE" , "2024-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region VE0030B_V0RELATORIOS

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V1REL_COD_USUR" , ""},
                    { "V1REL_NUM_APOL" , ""},
                    { "V1REL_COD_SUBG" , ""},
                    { "V1REL_SIT_REGISTRO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("VE0030B_V0RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("VE0030B_V0RELATORIOS", q1);

                #endregion

                #region VE0030B_V1ENDOSSO

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V1ENDO_NUM_APOL" , ""},
                    { "V1ENDO_NRENDOS" , ""},
                    { "V1ENDO_DTEMIS" , ""},
                    { "V1ENDO_DTINIVIG" , "2020-01-01"},
                    { "V1ENDO_DTTERVIG" , "2020-01-01"},
                    { "V1ENDO_BCORCAP" , ""},
                    { "V1ENDO_AGERCAP" , ""},
                    { "V1ENDO_DACRCAP" , ""},
                    { "V1ENDO_BCOCOBR" , ""},
                    { "V1ENDO_AGECOBR" , ""},
                    { "V1ENDO_DACCOBR" , ""},
                    { "V1ENDO_QTPARCEL" , ""},
                    { "V1ENDO_ORGAO" , ""},
                    { "V1ENDO_RAMO" , ""},
                    { "V1ENDO_CODPRODU" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("VE0030B_V1ENDOSSO");
                AppSettings.TestSet.DynamicData.Add("VE0030B_V1ENDOSSO", q2);

                #endregion

                #region R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0TERMO_NUM_TERMO" , ""},
                    { "V0TERMO_NUM_APOLICE" , ""},
                    { "V0TERMO_COD_SUBG" , ""},
                    { "V0TERMO_DT_ADESAO" , "2020-01-01"},
                    { "V0TERMO_DTADESAO_3M" , "2021-01-01"},
                    { "V0TERMO_COD_AGE_OP" , ""},
                    { "V0TERMO_MAT_VEN" , ""},
                    { "V0TERMO_CODPDTVEN" , ""},
                    { "V0TERMO_PCCOMVEN" , ""},
                    { "V0TERMO_CODPDTGER" , ""},
                    { "V0TERMO_PCCOMGER" , ""},
                    { "V0TERMO_PLANO_VGAP" , ""},
                    { "V0TERMO_PLANO_APC" , ""},
                    { "V0TERMO_VL_COMI_AD" , ""},
                    { "V0TERMO_QTD_VIDAS" , ""},
                    { "V0TERMO_PERI_PGTO" , ""},
                    { "V0TERMO_COD_USUR" , ""},
                    { "V0TERMO_SITUACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1", q3);

                #endregion

                #region VE0030B_V0COMISSAO

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0COMI_NUM_APOL" , ""},
                    { "V0COMI_NRENDOS" , ""},
                    { "V0COMI_NRCERTIF" , ""},
                    { "V0COMI_DIGCERT" , ""},
                    { "V0COMI_IDTPSEGU" , ""},
                    { "V0COMI_NRPARCEL" , ""},
                    { "V0COMI_OPERACAO" , ""},
                    { "V0COMI_CODPDT" , ""},
                    { "V0COMI_RAMOFR" , ""},
                    { "V0COMI_MODALIFR" , ""},
                    { "V0COMI_OCORHIST" , ""},
                    { "V0COMI_FONTE" , ""},
                    { "V0COMI_CODCLIEN" , ""},
                    { "V0COMI_VLCOMIS" , ""},
                    { "V0COMI_DATCLO" , ""},
                    { "V0COMI_NUMREC" , ""},
                    { "V0COMI_VALBAS" , ""},
                    { "V0COMI_TIPCOM" , ""},
                    { "V0COMI_QTPARCEL" , ""},
                    { "V0COMI_PCCOMCOR" , ""},
                    { "V0COMI_PCDESCON" , ""},
                    { "V0COMI_CODSUBES" , ""},
                    { "V0COMI_DTMOVTO" , "2020-01-01"},
                    { "V0COMI_DATSEL" , "2020-02-01"},
                    { "V0COMI_COD_EMPRESA" , ""},
                    { "V0COMI_CODPRP" , ""},
                    { "V0COMI_NUMBIL" , ""},
                    { "V0COMI_VLVARMON" , ""},
                    { "V0COMI_DTQITBCO" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("VE0030B_V0COMISSAO");
                AppSettings.TestSet.DynamicData.Add("VE0030B_V0COMISSAO", q4);

                #endregion

                #region R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V1REL_NUM_APOL" , ""},
                    { "V1REL_COD_SUBG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1", q5);

                #endregion

                #region R0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V1AGENC_COD_AGENCIA" , ""},
                    { "V1AGENC_COD_SUREG" , ""},
                    { "V1AGENC_COD_ESCNEG" , ""},
                    { "V1AGENC_SITUACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1", q6);

                #endregion

                #region R0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V1MALHA_COD_SUREG" , ""},
                    { "V1MALHA_COD_FONTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1", q7);

                #endregion

                #region R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V0PRODC_DTOPER" , ""},
                    { "V0PRODC_COD_AGENC" , ""},
                    { "V0PRODC_CODPRODAZ" , ""},
                    { "V0PRODC_NUM_MATRIC" , ""},
                    { "V0PRODC_COD_OPER" , ""},
                    { "V0PRODC_COD_FONTE" , ""},
                    { "V0PRODC_NUM_PROPO" , ""},
                    { "V0PRODC_QTD_REALI" , ""},
                    { "V0PRODC_VL_COMI_RE" , ""},
                    { "V0PRODC_COD_PLANO" , ""},
                    { "V0PRODC_DT_REFER" , ""},
                    { "V0PRODC_SIT_CAMPAN" , ""},
                    { "V0PRODC_SIT_INTERF" , ""},
                    { "V0PRODC_SIT_DIARIO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1", q8);

                #endregion

                #region VE0030B_V1PARCELA

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "V1PARC_NUM_APOL" , "1"},
                    { "V1PARC_NRENDOS" , ""},
                    { "V1PARC_NRPARCEL" , ""},
                    { "V1PARC_DACPARC" , ""},
                    { "V1PARC_FONTE" , ""},
                    { "V1PARC_NRTIT" , ""},
                    { "V1PARC_OCORHIST" , ""},
                    { "V1PARC_QTDDOC" , ""},
                    { "V1PARC_SITUACAO" , "0"},
                    { "V1PARC_COD_EMP" , ""}
                });

                AppSettings.TestSet.DynamicData.Remove("VE0030B_V1PARCELA");
                AppSettings.TestSet.DynamicData.Add("VE0030B_V1PARCELA", q9);

                #endregion

                #region R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "V0COMI_NUM_APOL" , ""},
                    { "V0COMI_NRENDOS" , ""},
                    { "V0COMI_NRCERTIF" , ""},
                    { "V0COMI_DIGCERT" , ""},
                    { "V0COMI_IDTPSEGU" , ""},
                    { "V0COMI_NRPARCEL" , ""},
                    { "V0COMI_OPERACAO" , ""},
                    { "V0COMI_CODPDT" , ""},
                    { "V0COMI_RAMOFR" , ""},
                    { "V0COMI_MODALIFR" , ""},
                    { "V0COMI_OCORHIST" , ""},
                    { "V0COMI_FONTE" , ""},
                    { "V0COMI_CODCLIEN" , ""},
                    { "V0COMI_VLCOMIS" , ""},
                    { "V0COMI_DATCLO" , ""},
                    { "V0COMI_NUMREC" , ""},
                    { "V0COMI_VALBAS" , ""},
                    { "V0COMI_TIPCOM" , ""},
                    { "V0COMI_QTPARCEL" , ""},
                    { "V0COMI_PCCOMCOR" , ""},
                    { "V0COMI_PCDESCON" , ""},
                    { "V0COMI_CODSUBES" , ""},
                    { "V0COMI_DATSEL" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1", q10);

                #endregion

                #region R0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V1PROD_COD_ESCNEG" , ""},
                    { "V1PROD_DTINIVIG" , "2020-01-01"},
                    { "V1PROD_DTTERVIG" , "2020-01-01"},
                    { "V1PROD_NUM_MATRIC" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1", q11);

                #endregion

                #region R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "V1FUNC_NUM_MATRIC" , ""},
                    { "V1FUNC_COD_ANGARIA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1", q12);

                #endregion

                #region R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "V1REL_COD_USUR" , ""},
                    { "V0TERMO_NUM_TERMO" , ""},
                    { "V0TERMO_COD_SUBG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1", q13);

                #endregion

                #region R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "V1REL_NUM_APOL" , ""},
                    { "V1REL_COD_SUBG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1", q14);

                #endregion

                #region R0420_00_CANCELA_V0PROPOSTAVA_DB_UPDATE_1_Update1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "V1REL_COD_USUR" , ""},
                    { "V1REL_NUM_APOL" , ""},
                    { "V1REL_COD_SUBG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0420_00_CANCELA_V0PROPOSTAVA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0420_00_CANCELA_V0PROPOSTAVA_DB_UPDATE_1_Update1", q15);

                #endregion

                #region R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "V0NAES_NRENDOCA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1", q16);

                #endregion

                #region R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "V0NAES_NRENDOCA" , ""},
                    { "V1ENDO_ORGAO" , ""},
                    { "V1ENDO_RAMO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1", q17);

                #endregion

                #region R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "WP_PRM_TAR" , ""},
                    { "WP_VAL_DESC" , ""},
                    { "WP_VLPRMLIQ" , ""},
                    { "WP_VLADIFRA" , ""},
                    { "WP_VLCUSEMI" , ""},
                    { "WP_VLIOCC" , ""},
                    { "WP_VLPRMTOT" , ""},
                    { "WP_VLPREMIO" , ""},
                    { "V1HISP_DTVENCTO" , "2020-10-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1", q18);

                #endregion

                #region R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "WC_PRM_TAR" , ""},
                    { "WC_VAL_DESC" , ""},
                    { "WC_VLPRMLIQ" , ""},
                    { "WC_VLADIFRA" , ""},
                    { "WC_VLCUSEMI" , ""},
                    { "WC_VLIOCC" , ""},
                    { "WC_VLPRMTOT" , ""},
                    { "WC_VLPREMIO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1", q19);

                #endregion

                #region R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "V0HISP_NUM_APOL" , ""},
                    { "V0HISP_NRENDOS" , ""},
                    { "V0HISP_NRPARCEL" , ""},
                    { "V0HISP_DACPARC" , ""},
                    { "V0HISP_DTMOVTO" , ""},
                    { "V0HISP_OPERACAO" , ""},
                    { "V0HISP_HORAOPER" , ""},
                    { "V0HISP_OCORHIST" , ""},
                    { "V0HISP_PRM_TAR" , ""},
                    { "V0HISP_VAL_DESC" , ""},
                    { "V0HISP_VLPRMLIQ" , ""},
                    { "V0HISP_VLADIFRA" , ""},
                    { "V0HISP_VLCUSEMI" , ""},
                    { "V0HISP_VLIOCC" , ""},
                    { "V0HISP_VLPRMTOT" , ""},
                    { "V0HISP_VLPREMIO" , ""},
                    { "V0HISP_DTVENCTO" , ""},
                    { "V0HISP_BCOCOBR" , ""},
                    { "V0HISP_AGECOBR" , ""},
                    { "V0HISP_NRAVISO" , ""},
                    { "V0HISP_NRENDOCA" , ""},
                    { "V0HISP_SITCONTB" , ""},
                    { "V0HISP_COD_USUARIO" , ""},
                    { "V0HISP_RNUDOC" , ""},
                    { "V0HISP_DTQITBCO" , ""},
                    { "V0HISP_COD_EMPRESA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q20);

                #endregion

                #region R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                    { "WOCORHIST" , ""},
                    { "V1PARC_NUM_APOL" , ""},
                    { "V0HISP_NRPARCEL" , ""},
                    { "V1PARC_NRENDOS" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1", q21);

                #endregion

                #region R6100_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                    { "V0HISP_NUM_APOL" , ""},
                    { "V0HISP_NRENDOS" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R6100_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R6100_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1", q22);

                #endregion

                #endregion
                var program = new VE0030B();
                program.Execute();

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();

                Assert.True(inserts.Count >= allInserts.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }


        [Fact]
        public static void VE0030B_Tests_Fact_ReturnCode00_Selects()
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
                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1SIST_DTMOVABE" , "2024-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region VE0030B_V0RELATORIOS

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V1REL_COD_USUR" , ""},
                    { "V1REL_NUM_APOL" , ""},
                    { "V1REL_COD_SUBG" , ""},
                    { "V1REL_SIT_REGISTRO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("VE0030B_V0RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("VE0030B_V0RELATORIOS", q1);

                #endregion

                #region VE0030B_V1ENDOSSO

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V1ENDO_NUM_APOL" , ""},
                    { "V1ENDO_NRENDOS" , ""},
                    { "V1ENDO_DTEMIS" , ""},
                    { "V1ENDO_DTINIVIG" , "2020-01-01"},
                    { "V1ENDO_DTTERVIG" , "2020-01-01"},
                    { "V1ENDO_BCORCAP" , ""},
                    { "V1ENDO_AGERCAP" , ""},
                    { "V1ENDO_DACRCAP" , ""},
                    { "V1ENDO_BCOCOBR" , ""},
                    { "V1ENDO_AGECOBR" , ""},
                    { "V1ENDO_DACCOBR" , ""},
                    { "V1ENDO_QTPARCEL" , ""},
                    { "V1ENDO_ORGAO" , ""},
                    { "V1ENDO_RAMO" , ""},
                    { "V1ENDO_CODPRODU" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("VE0030B_V1ENDOSSO");
                AppSettings.TestSet.DynamicData.Add("VE0030B_V1ENDOSSO", q2);

                #endregion

                #region R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0TERMO_NUM_TERMO" , ""},
                    { "V0TERMO_NUM_APOLICE" , ""},
                    { "V0TERMO_COD_SUBG" , ""},
                    { "V0TERMO_DT_ADESAO" , "2020-01-01"},
                    { "V0TERMO_DTADESAO_3M" , "2021-01-01"},
                    { "V0TERMO_COD_AGE_OP" , ""},
                    { "V0TERMO_MAT_VEN" , ""},
                    { "V0TERMO_CODPDTVEN" , ""},
                    { "V0TERMO_PCCOMVEN" , ""},
                    { "V0TERMO_CODPDTGER" , ""},
                    { "V0TERMO_PCCOMGER" , ""},
                    { "V0TERMO_PLANO_VGAP" , ""},
                    { "V0TERMO_PLANO_APC" , ""},
                    { "V0TERMO_VL_COMI_AD" , ""},
                    { "V0TERMO_QTD_VIDAS" , ""},
                    { "V0TERMO_PERI_PGTO" , ""},
                    { "V0TERMO_COD_USUR" , ""},
                    { "V0TERMO_SITUACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1", q3);

                #endregion

                #region VE0030B_V0COMISSAO

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0COMI_NUM_APOL" , ""},
                    { "V0COMI_NRENDOS" , ""},
                    { "V0COMI_NRCERTIF" , ""},
                    { "V0COMI_DIGCERT" , ""},
                    { "V0COMI_IDTPSEGU" , ""},
                    { "V0COMI_NRPARCEL" , ""},
                    { "V0COMI_OPERACAO" , ""},
                    { "V0COMI_CODPDT" , ""},
                    { "V0COMI_RAMOFR" , ""},
                    { "V0COMI_MODALIFR" , ""},
                    { "V0COMI_OCORHIST" , ""},
                    { "V0COMI_FONTE" , ""},
                    { "V0COMI_CODCLIEN" , ""},
                    { "V0COMI_VLCOMIS" , ""},
                    { "V0COMI_DATCLO" , ""},
                    { "V0COMI_NUMREC" , ""},
                    { "V0COMI_VALBAS" , ""},
                    { "V0COMI_TIPCOM" , ""},
                    { "V0COMI_QTPARCEL" , ""},
                    { "V0COMI_PCCOMCOR" , ""},
                    { "V0COMI_PCDESCON" , ""},
                    { "V0COMI_CODSUBES" , ""},
                    { "V0COMI_DTMOVTO" , "2020-01-01"},
                    { "V0COMI_DATSEL" , "2020-02-01"},
                    { "V0COMI_COD_EMPRESA" , ""},
                    { "V0COMI_CODPRP" , ""},
                    { "V0COMI_NUMBIL" , ""},
                    { "V0COMI_VLVARMON" , ""},
                    { "V0COMI_DTQITBCO" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("VE0030B_V0COMISSAO");
                AppSettings.TestSet.DynamicData.Add("VE0030B_V0COMISSAO", q4);

                #endregion

                #region R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V1REL_NUM_APOL" , ""},
                    { "V1REL_COD_SUBG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1", q5);

                #endregion

                #region R0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V1AGENC_COD_AGENCIA" , ""},
                    { "V1AGENC_COD_SUREG" , ""},
                    { "V1AGENC_COD_ESCNEG" , ""},
                    { "V1AGENC_SITUACAO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1", q6);

                #endregion

                #region R0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V1MALHA_COD_SUREG" , ""},
                    { "V1MALHA_COD_FONTE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1", q7);

                #endregion

                #region R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V0PRODC_DTOPER" , ""},
                    { "V0PRODC_COD_AGENC" , ""},
                    { "V0PRODC_CODPRODAZ" , ""},
                    { "V0PRODC_NUM_MATRIC" , ""},
                    { "V0PRODC_COD_OPER" , ""},
                    { "V0PRODC_COD_FONTE" , ""},
                    { "V0PRODC_NUM_PROPO" , ""},
                    { "V0PRODC_QTD_REALI" , ""},
                    { "V0PRODC_VL_COMI_RE" , ""},
                    { "V0PRODC_COD_PLANO" , ""},
                    { "V0PRODC_DT_REFER" , ""},
                    { "V0PRODC_SIT_CAMPAN" , ""},
                    { "V0PRODC_SIT_INTERF" , ""},
                    { "V0PRODC_SIT_DIARIO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1", q8);

                #endregion

                #region VE0030B_V1PARCELA

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "V1PARC_NUM_APOL" , "1"},
                    { "V1PARC_NRENDOS" , ""},
                    { "V1PARC_NRPARCEL" , ""},
                    { "V1PARC_DACPARC" , ""},
                    { "V1PARC_FONTE" , ""},
                    { "V1PARC_NRTIT" , ""},
                    { "V1PARC_OCORHIST" , ""},
                    { "V1PARC_QTDDOC" , ""},
                    { "V1PARC_SITUACAO" , "0"},
                    { "V1PARC_COD_EMP" , ""}
                });

                AppSettings.TestSet.DynamicData.Remove("VE0030B_V1PARCELA");
                AppSettings.TestSet.DynamicData.Add("VE0030B_V1PARCELA", q9);

                #endregion

                #region R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "V0COMI_NUM_APOL" , ""},
                    { "V0COMI_NRENDOS" , ""},
                    { "V0COMI_NRCERTIF" , ""},
                    { "V0COMI_DIGCERT" , ""},
                    { "V0COMI_IDTPSEGU" , ""},
                    { "V0COMI_NRPARCEL" , ""},
                    { "V0COMI_OPERACAO" , ""},
                    { "V0COMI_CODPDT" , ""},
                    { "V0COMI_RAMOFR" , ""},
                    { "V0COMI_MODALIFR" , ""},
                    { "V0COMI_OCORHIST" , ""},
                    { "V0COMI_FONTE" , ""},
                    { "V0COMI_CODCLIEN" , ""},
                    { "V0COMI_VLCOMIS" , ""},
                    { "V0COMI_DATCLO" , ""},
                    { "V0COMI_NUMREC" , ""},
                    { "V0COMI_VALBAS" , ""},
                    { "V0COMI_TIPCOM" , ""},
                    { "V0COMI_QTPARCEL" , ""},
                    { "V0COMI_PCCOMCOR" , ""},
                    { "V0COMI_PCDESCON" , ""},
                    { "V0COMI_CODSUBES" , ""},
                    { "V0COMI_DATSEL" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1", q10);

                #endregion

                #region R0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V1PROD_COD_ESCNEG" , ""},
                    { "V1PROD_DTINIVIG" , "2020-01-01"},
                    { "V1PROD_DTTERVIG" , "2020-01-01"},
                    { "V1PROD_NUM_MATRIC" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1", q11);

                #endregion

                #region R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "V1FUNC_NUM_MATRIC" , ""},
                    { "V1FUNC_COD_ANGARIA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1", q12);

                #endregion

                #region R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "V1REL_COD_USUR" , ""},
                    { "V0TERMO_NUM_TERMO" , ""},
                    { "V0TERMO_COD_SUBG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1", q13);

                #endregion

                #region R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "V1REL_NUM_APOL" , ""},
                    { "V1REL_COD_SUBG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1", q14);

                #endregion

                #region R0420_00_CANCELA_V0PROPOSTAVA_DB_UPDATE_1_Update1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "V1REL_COD_USUR" , ""},
                    { "V1REL_NUM_APOL" , ""},
                    { "V1REL_COD_SUBG" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R0420_00_CANCELA_V0PROPOSTAVA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0420_00_CANCELA_V0PROPOSTAVA_DB_UPDATE_1_Update1", q15);

                #endregion

                #region R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "V0NAES_NRENDOCA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1", q16);

                #endregion

                #region R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "V0NAES_NRENDOCA" , ""},
                    { "V1ENDO_ORGAO" , ""},
                    { "V1ENDO_RAMO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1", q17);

                #endregion

                #region R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "WP_PRM_TAR" , ""},
                    { "WP_VAL_DESC" , ""},
                    { "WP_VLPRMLIQ" , ""},
                    { "WP_VLADIFRA" , ""},
                    { "WP_VLCUSEMI" , ""},
                    { "WP_VLIOCC" , ""},
                    { "WP_VLPRMTOT" , ""},
                    { "WP_VLPREMIO" , ""},
                    { "V1HISP_DTVENCTO" , "2020-10-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1", q18);

                #endregion

                #region R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "WC_PRM_TAR" , ""},
                    { "WC_VAL_DESC" , ""},
                    { "WC_VLPRMLIQ" , ""},
                    { "WC_VLADIFRA" , ""},
                    { "WC_VLCUSEMI" , ""},
                    { "WC_VLIOCC" , ""},
                    { "WC_VLPRMTOT" , ""},
                    { "WC_VLPREMIO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1", q19);

                #endregion

                #region R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "V0HISP_NUM_APOL" , ""},
                    { "V0HISP_NRENDOS" , ""},
                    { "V0HISP_NRPARCEL" , ""},
                    { "V0HISP_DACPARC" , ""},
                    { "V0HISP_DTMOVTO" , ""},
                    { "V0HISP_OPERACAO" , ""},
                    { "V0HISP_HORAOPER" , ""},
                    { "V0HISP_OCORHIST" , ""},
                    { "V0HISP_PRM_TAR" , ""},
                    { "V0HISP_VAL_DESC" , ""},
                    { "V0HISP_VLPRMLIQ" , ""},
                    { "V0HISP_VLADIFRA" , ""},
                    { "V0HISP_VLCUSEMI" , ""},
                    { "V0HISP_VLIOCC" , ""},
                    { "V0HISP_VLPRMTOT" , ""},
                    { "V0HISP_VLPREMIO" , ""},
                    { "V0HISP_DTVENCTO" , ""},
                    { "V0HISP_BCOCOBR" , ""},
                    { "V0HISP_AGECOBR" , ""},
                    { "V0HISP_NRAVISO" , ""},
                    { "V0HISP_NRENDOCA" , ""},
                    { "V0HISP_SITCONTB" , ""},
                    { "V0HISP_COD_USUARIO" , ""},
                    { "V0HISP_RNUDOC" , ""},
                    { "V0HISP_DTQITBCO" , ""},
                    { "V0HISP_COD_EMPRESA" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q20);

                #endregion

                #region R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                    { "WOCORHIST" , ""},
                    { "V1PARC_NUM_APOL" , ""},
                    { "V0HISP_NRPARCEL" , ""},
                    { "V1PARC_NRENDOS" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1", q21);

                #endregion

                #region R6100_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                    { "V0HISP_NUM_APOL" , ""},
                    { "V0HISP_NRENDOS" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R6100_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R6100_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1", q22);

                #endregion

                #endregion
                var program = new VE0030B();
                program.Execute();

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Fact]
        public static void VE0030B_Tests_Fact_ReturnCode99()
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
                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "V1SIST_DTMOVABE" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region VE0030B_V0RELATORIOS

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "V1REL_COD_USUR" , ""},
                    { "V1REL_NUM_APOL" , ""},
                    { "V1REL_COD_SUBG" , ""},
                    { "V1REL_SIT_REGISTRO" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("VE0030B_V0RELATORIOS");
                AppSettings.TestSet.DynamicData.Add("VE0030B_V0RELATORIOS", q1);

                #endregion

                #region VE0030B_V1ENDOSSO

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V1ENDO_NUM_APOL" , ""},
                    { "V1ENDO_NRENDOS" , ""},
                    { "V1ENDO_DTEMIS" , ""},
                    { "V1ENDO_DTINIVIG" , ""},
                    { "V1ENDO_DTTERVIG" , ""},
                    { "V1ENDO_BCORCAP" , ""},
                    { "V1ENDO_AGERCAP" , ""},
                    { "V1ENDO_DACRCAP" , ""},
                    { "V1ENDO_BCOCOBR" , ""},
                    { "V1ENDO_AGECOBR" , ""},
                    { "V1ENDO_DACCOBR" , ""},
                    { "V1ENDO_QTPARCEL" , ""},
                    { "V1ENDO_ORGAO" , ""},
                    { "V1ENDO_RAMO" , ""},
                    { "V1ENDO_CODPRODU" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("VE0030B_V1ENDOSSO");
                AppSettings.TestSet.DynamicData.Add("VE0030B_V1ENDOSSO", q2);

                #endregion

                #region R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "V0TERMO_NUM_TERMO" , ""},
                    { "V0TERMO_NUM_APOLICE" , ""},
                    { "V0TERMO_COD_SUBG" , ""},
                    { "V0TERMO_DT_ADESAO" , ""},
                    { "V0TERMO_DTADESAO_3M" , ""},
                    { "V0TERMO_COD_AGE_OP" , ""},
                    { "V0TERMO_MAT_VEN" , ""},
                    { "V0TERMO_CODPDTVEN" , ""},
                    { "V0TERMO_PCCOMVEN" , ""},
                    { "V0TERMO_CODPDTGER" , ""},
                    { "V0TERMO_PCCOMGER" , ""},
                    { "V0TERMO_PLANO_VGAP" , ""},
                    { "V0TERMO_PLANO_APC" , ""},
                    { "V0TERMO_VL_COMI_AD" , ""},
                    { "V0TERMO_QTD_VIDAS" , ""},
                    { "V0TERMO_PERI_PGTO" , ""},
                    { "V0TERMO_COD_USUR" , ""},
                    { "V0TERMO_SITUACAO" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1", q3);

                #endregion

                #region VE0030B_V0COMISSAO

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "V0COMI_NUM_APOL" , ""},
                    { "V0COMI_NRENDOS" , ""},
                    { "V0COMI_NRCERTIF" , ""},
                    { "V0COMI_DIGCERT" , ""},
                    { "V0COMI_IDTPSEGU" , ""},
                    { "V0COMI_NRPARCEL" , ""},
                    { "V0COMI_OPERACAO" , ""},
                    { "V0COMI_CODPDT" , ""},
                    { "V0COMI_RAMOFR" , ""},
                    { "V0COMI_MODALIFR" , ""},
                    { "V0COMI_OCORHIST" , ""},
                    { "V0COMI_FONTE" , ""},
                    { "V0COMI_CODCLIEN" , ""},
                    { "V0COMI_VLCOMIS" , ""},
                    { "V0COMI_DATCLO" , ""},
                    { "V0COMI_NUMREC" , ""},
                    { "V0COMI_VALBAS" , ""},
                    { "V0COMI_TIPCOM" , ""},
                    { "V0COMI_QTPARCEL" , ""},
                    { "V0COMI_PCCOMCOR" , ""},
                    { "V0COMI_PCDESCON" , ""},
                    { "V0COMI_CODSUBES" , ""},
                    { "V0COMI_DTMOVTO" , ""},
                    { "V0COMI_DATSEL" , ""},
                    { "V0COMI_COD_EMPRESA" , ""},
                    { "V0COMI_CODPRP" , ""},
                    { "V0COMI_NUMBIL" , ""},
                    { "V0COMI_VLVARMON" , ""},
                    { "V0COMI_DTQITBCO" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("VE0030B_V0COMISSAO");
                AppSettings.TestSet.DynamicData.Add("VE0030B_V0COMISSAO", q4);

                #endregion

                #region R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "V1REL_NUM_APOL" , ""},
                    { "V1REL_COD_SUBG" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1_Update1", q5);

                #endregion

                #region R0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "V1AGENC_COD_AGENCIA" , ""},
                    { "V1AGENC_COD_SUREG" , ""},
                    { "V1AGENC_COD_ESCNEG" , ""},
                    { "V1AGENC_SITUACAO" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1", q6);

                #endregion

                #region R0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "V1MALHA_COD_SUREG" , ""},
                    { "V1MALHA_COD_FONTE" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0290_00_LER_V1MALHACEF_DB_SELECT_1_Query1", q7);

                #endregion

                #region R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "V0PRODC_DTOPER" , ""},
                    { "V0PRODC_COD_AGENC" , ""},
                    { "V0PRODC_CODPRODAZ" , ""},
                    { "V0PRODC_NUM_MATRIC" , ""},
                    { "V0PRODC_COD_OPER" , ""},
                    { "V0PRODC_COD_FONTE" , ""},
                    { "V0PRODC_NUM_PROPO" , ""},
                    { "V0PRODC_QTD_REALI" , ""},
                    { "V0PRODC_VL_COMI_RE" , ""},
                    { "V0PRODC_COD_PLANO" , ""},
                    { "V0PRODC_DT_REFER" , ""},
                    { "V0PRODC_SIT_CAMPAN" , ""},
                    { "V0PRODC_SIT_INTERF" , ""},
                    { "V0PRODC_SIT_DIARIO" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1", q8);

                #endregion

                #region VE0030B_V1PARCELA

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "V1PARC_NUM_APOL" , ""},
                    { "V1PARC_NRENDOS" , ""},
                    { "V1PARC_NRPARCEL" , ""},
                    { "V1PARC_DACPARC" , ""},
                    { "V1PARC_FONTE" , ""},
                    { "V1PARC_NRTIT" , ""},
                    { "V1PARC_OCORHIST" , ""},
                    { "V1PARC_QTDDOC" , ""},
                    { "V1PARC_SITUACAO" , ""},
                    { "V1PARC_COD_EMP" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("VE0030B_V1PARCELA");
                AppSettings.TestSet.DynamicData.Add("VE0030B_V1PARCELA", q9);

                #endregion

                #region R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "V0COMI_NUM_APOL" , ""},
                    { "V0COMI_NRENDOS" , ""},
                    { "V0COMI_NRCERTIF" , ""},
                    { "V0COMI_DIGCERT" , ""},
                    { "V0COMI_IDTPSEGU" , ""},
                    { "V0COMI_NRPARCEL" , ""},
                    { "V0COMI_OPERACAO" , ""},
                    { "V0COMI_CODPDT" , ""},
                    { "V0COMI_RAMOFR" , ""},
                    { "V0COMI_MODALIFR" , ""},
                    { "V0COMI_OCORHIST" , ""},
                    { "V0COMI_FONTE" , ""},
                    { "V0COMI_CODCLIEN" , ""},
                    { "V0COMI_VLCOMIS" , ""},
                    { "V0COMI_DATCLO" , ""},
                    { "V0COMI_NUMREC" , ""},
                    { "V0COMI_VALBAS" , ""},
                    { "V0COMI_TIPCOM" , ""},
                    { "V0COMI_QTPARCEL" , ""},
                    { "V0COMI_PCCOMCOR" , ""},
                    { "V0COMI_PCDESCON" , ""},
                    { "V0COMI_CODSUBES" , ""},
                    { "V0COMI_DATSEL" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0370_00_INSERT_ESTORNO_COMIS_DB_INSERT_1_Insert1", q10);

                #endregion

                #region R0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "V1PROD_COD_ESCNEG" , ""},
                    { "V1PROD_DTINIVIG" , ""},
                    { "V1PROD_DTTERVIG" , ""},
                    { "V1PROD_NUM_MATRIC" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1", q11);

                #endregion

                #region R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "V1FUNC_NUM_MATRIC" , ""},
                    { "V1FUNC_COD_ANGARIA" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1", q12);

                #endregion

                #region R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "V1REL_COD_USUR" , ""},
                    { "V0TERMO_NUM_TERMO" , ""},
                    { "V0TERMO_COD_SUBG" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1", q13);

                #endregion

                #region R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "V1REL_NUM_APOL" , ""},
                    { "V1REL_COD_SUBG" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1", q14);

                #endregion

                #region R0420_00_CANCELA_V0PROPOSTAVA_DB_UPDATE_1_Update1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "V1REL_COD_USUR" , ""},
                    { "V1REL_NUM_APOL" , ""},
                    { "V1REL_COD_SUBG" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0420_00_CANCELA_V0PROPOSTAVA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R0420_00_CANCELA_V0PROPOSTAVA_DB_UPDATE_1_Update1", q15);

                #endregion

                #region R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "V0NAES_NRENDOCA" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1", q16);

                #endregion

                #region R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "V0NAES_NRENDOCA" , ""},
                    { "V1ENDO_ORGAO" , ""},
                    { "V1ENDO_RAMO" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1", q17);

                #endregion

                #region R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "WP_PRM_TAR" , ""},
                    { "WP_VAL_DESC" , ""},
                    { "WP_VLPRMLIQ" , ""},
                    { "WP_VLADIFRA" , ""},
                    { "WP_VLCUSEMI" , ""},
                    { "WP_VLIOCC" , ""},
                    { "WP_VLPRMTOT" , ""},
                    { "WP_VLPREMIO" , ""},
                    { "V1HISP_DTVENCTO" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1", q18);

                #endregion

                #region R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "WC_PRM_TAR" , ""},
                    { "WC_VAL_DESC" , ""},
                    { "WC_VLPRMLIQ" , ""},
                    { "WC_VLADIFRA" , ""},
                    { "WC_VLCUSEMI" , ""},
                    { "WC_VLIOCC" , ""},
                    { "WC_VLPRMTOT" , ""},
                    { "WC_VLPREMIO" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1", q19);

                #endregion

                #region R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "V0HISP_NUM_APOL" , ""},
                    { "V0HISP_NRENDOS" , ""},
                    { "V0HISP_NRPARCEL" , ""},
                    { "V0HISP_DACPARC" , ""},
                    { "V0HISP_DTMOVTO" , ""},
                    { "V0HISP_OPERACAO" , ""},
                    { "V0HISP_HORAOPER" , ""},
                    { "V0HISP_OCORHIST" , ""},
                    { "V0HISP_PRM_TAR" , ""},
                    { "V0HISP_VAL_DESC" , ""},
                    { "V0HISP_VLPRMLIQ" , ""},
                    { "V0HISP_VLADIFRA" , ""},
                    { "V0HISP_VLCUSEMI" , ""},
                    { "V0HISP_VLIOCC" , ""},
                    { "V0HISP_VLPRMTOT" , ""},
                    { "V0HISP_VLPREMIO" , ""},
                    { "V0HISP_DTVENCTO" , ""},
                    { "V0HISP_BCOCOBR" , ""},
                    { "V0HISP_AGECOBR" , ""},
                    { "V0HISP_NRAVISO" , ""},
                    { "V0HISP_NRENDOCA" , ""},
                    { "V0HISP_SITCONTB" , ""},
                    { "V0HISP_COD_USUARIO" , ""},
                    { "V0HISP_RNUDOC" , ""},
                    { "V0HISP_DTQITBCO" , ""},
                    { "V0HISP_COD_EMPRESA" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q20);

                #endregion

                #region R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                    { "WOCORHIST" , ""},
                    { "V1PARC_NUM_APOL" , ""},
                    { "V0HISP_NRPARCEL" , ""},
                    { "V1PARC_NRENDOS" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1", q21);

                #endregion

                #region R6100_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                    { "V0HISP_NUM_APOL" , ""},
                    { "V0HISP_NRENDOS" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R6100_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R6100_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1", q22);

                #endregion

                #endregion
                var program = new VE0030B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 9);
            }
        }

    }
}