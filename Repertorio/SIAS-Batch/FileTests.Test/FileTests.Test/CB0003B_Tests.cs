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
using static Code.CB0003B;
using Sias.Cobranca.DB2.CB0003B;

namespace FileTests.Test
{
    [Collection("CB0003B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class CB0003B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1PARR_RAMO_VGAPC" , ""},
                { "V1PARR_RAMO_VG" , ""},
                { "V1PARR_RAMO_AP" , ""},
                { "V1PARR_RAMO_SAUDE" , ""},
                { "V1PARR_RAMO_EDUCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1", q1);

            #endregion

            #region CB0003B_V1MOVICOB

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1MCOB_CODMOV" , ""},
                { "V1MCOB_BANCO" , ""},
                { "V1MCOB_AGENCIA" , ""},
                { "V1MCOB_NRAVISO" , ""},
                { "V1MCOB_NUMFITA" , ""},
                { "V1MCOB_DTMOVTO" , ""},
                { "V1MCOB_DTQITBCO" , ""},
                { "V1MCOB_NRTIT" , ""},
                { "V1MCOB_NUM_APOL" , ""},
                { "V1MCOB_NRENDOS" , ""},
                { "V1MCOB_NRPARCEL" , ""},
                { "V1MCOB_VALTIT" , ""},
                { "V1MCOB_VLIOCC" , ""},
                { "V1MCOB_VALCDT" , ""},
                { "V1MCOB_SITUACAO" , ""},
                { "V1MCOB_NOME" , ""},
                { "V1MCOB_NUM_NOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0003B_V1MOVICOB", q2);

            #endregion

            #region CB0003B_V1NOTACRED

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1NOTA_NRENDOSR" , ""},
                { "V1NOTA_NRPARCELR" , ""},
                { "V1NOTA_DTVENCTO" , ""},
                { "V1NOTA_VALCREDR_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0003B_V1NOTACRED", q3);

            #endregion

            #region R1705_00_SUMARIZA_NOTASCRED_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1NOTA_VALCREDR_IX" , ""},
                { "W1_COUNT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1705_00_SUMARIZA_NOTASCRED_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1715_00_CORRECAO_NOTACRED_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "W1_VALCREDR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1715_00_CORRECAO_NOTACRED_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1715_30_INSERE_CORRECAO_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "HNOTCRE_COD_EMP" , ""},
                { "V1MCOB_NUM_APOL" , ""},
                { "V1NOTA_NRENDOSR" , ""},
                { "V1NOTA_NRPARCELR" , ""},
                { "V1MCOB_NRENDOS" , ""},
                { "V1MCOB_NRPARCEL" , ""},
                { "HNOTCRE_OCORHIST" , ""},
                { "HNOTCRE_OPERACAO" , ""},
                { "V1SIST_DTMOVABE" , ""},
                { "HNOTCRE_HORAOPER" , ""},
                { "HNOTCRE_VALCREDR" , ""},
                { "HNOTCRE_VLPAGTO" , ""},
                { "V1NOTA_DTVENCTO" , ""},
                { "HNOTCRE_SITCONTB" , ""},
                { "V1MCOB_BANCO" , ""},
                { "V1MCOB_AGENCIA" , ""},
                { "HNOTCRE_NUMCHQ" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1715_30_INSERE_CORRECAO_DB_INSERT_1_Insert1", q6);

            #endregion

            #region R1720_00_ATUALIZA_NOTASCRED_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "HNOTCRE_OCORHIST" , ""},
                { "V1NOTA_NRPARCELR" , ""},
                { "V1PARC_NUM_APOL" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1NOTA_NRENDOSR" , ""},
                { "V1PARC_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1720_00_ATUALIZA_NOTASCRED_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R1730_00_ACESSA_HISTNOTCRE_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "HNOTCRE_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1730_00_ACESSA_HISTNOTCRE_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1740_00_INSERI_HISTNOTCRE_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "HNOTCRE_COD_EMP" , ""},
                { "V1MCOB_NUM_APOL" , ""},
                { "V1NOTA_NRENDOSR" , ""},
                { "V1NOTA_NRPARCELR" , ""},
                { "V1MCOB_NRENDOS" , ""},
                { "V1MCOB_NRPARCEL" , ""},
                { "HNOTCRE_OCORHIST" , ""},
                { "HNOTCRE_OPERACAO" , ""},
                { "V1SIST_DTMOVABE" , ""},
                { "HNOTCRE_HORAOPER" , ""},
                { "HNOTCRE_VALCREDR" , ""},
                { "HNOTCRE_VLPAGTO" , ""},
                { "V1NOTA_DTVENCTO" , ""},
                { "HNOTCRE_SITCONTB" , ""},
                { "V1MCOB_BANCO" , ""},
                { "V1MCOB_AGENCIA" , ""},
                { "HNOTCRE_NUMCHQ" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1740_00_INSERI_HISTNOTCRE_DB_INSERT_1_Insert1", q9);

            #endregion

            #region CB0003B_C1AU071

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "AU071_NUM_APOLICE" , ""},
                { "AU071_NUM_ENDOSSO" , ""},
                { "AU071_NUM_PARCELA" , ""},
                { "AU071_DTA_VENCTO" , ""},
                { "AU071_NUM_VENCTO" , ""},
                { "AU071_VLR_JUROS" , ""},
                { "AU071_VLR_MULTA" , ""},
                { "CALENDAR_DIA_SEMANA" , ""},
                { "CALENDAR_FERIADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0003B_C1AU071", q10);

            #endregion

            #region R2100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_ORGAO" , ""},
                { "V1ENDO_RAMO" , ""},
                { "V1ENDO_DTEMIS" , ""},
                { "V1ENDO_DTINIVIG" , ""},
                { "V1ENDO_DTTERVIG" , ""},
                { "V1ENDO_MOEDA_IMP" , ""},
                { "V1ENDO_MOEDA_PRM" , ""},
                { "V1ENDO_BCORCAP" , ""},
                { "V1ENDO_AGERCAP" , ""},
                { "V1ENDO_DACRCAP" , ""},
                { "V1ENDO_BCOCOBR" , ""},
                { "V1ENDO_AGECOBR" , ""},
                { "V1ENDO_DACCOBR" , ""},
                { "V1ENDO_CORRECAO" , ""},
                { "V1ENDO_CODPRODU" , ""},
                { "V1ENDO_FONTE" , ""},
                { "V1ENDO_NRRCAP" , ""},
                { "V1ENDO_QTPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1", q11);

            #endregion

            #region R2200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q12);

            #endregion

            #region R2300_00_SELECT_V1PARAMETRO_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V1PARM_CODUNIMO" , ""},
                { "V1PARM_DIFPRM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_V1PARAMETRO_DB_SELECT_1_Query1", q13);

            #endregion

            #region R3000_00_CALCULA_CORRECAO_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "W1_PRM_TAR" , ""},
                { "W1_VAL_DES" , ""},
                { "W1_VLPRMLIQ" , ""},
                { "W1_VLADIFRA" , ""},
                { "W1_VLCUSEMI" , ""},
                { "W1_VLIOCC" , ""},
                { "W1_VLPRMTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_CALCULA_CORRECAO_DB_SELECT_1_Query1", q14);

            #endregion

            #region R3100_00_SELECT_VENCIMENTO_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "W1HISP_DTVENCTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_VENCIMENTO_DB_SELECT_1_Query1", q15);

            #endregion

            #region R3150_00_SELECT_V1PARCELA_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUM_APOL" , ""},
                { "V1PARC_NRENDOS" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1PARC_DACPARC" , ""},
                { "V1PARC_FONTE" , ""},
                { "V1PARC_NRTIT" , ""},
                { "V1PARC_PRM_TAR" , ""},
                { "V1PARC_VAL_DES" , ""},
                { "V1PARC_OTNPRLIQ" , ""},
                { "V1PARC_OTNADFRA" , ""},
                { "V1PARC_OTNCUSTO" , ""},
                { "V1PARC_OTNIOF" , ""},
                { "V1PARC_OTNTOTAL" , ""},
                { "V1PARC_OCORHIST" , ""},
                { "V1PARC_QTDDOC" , ""},
                { "V1PARC_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3150_00_SELECT_V1PARCELA_DB_SELECT_1_Query1", q16);

            #endregion

            #region R3200_00_SELECT_V1PARCELA_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NRPARCEL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_SELECT_V1PARCELA_DB_SELECT_1_Query1", q17);

            #endregion

            #region R3200_00_SELECT_V1PARCELA_DB_SELECT_2_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUM_APOL" , ""},
                { "V1PARC_NRENDOS" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1PARC_DACPARC" , ""},
                { "V1PARC_FONTE" , ""},
                { "V1PARC_NRTIT" , ""},
                { "V1PARC_PRM_TAR" , ""},
                { "V1PARC_VAL_DES" , ""},
                { "V1PARC_OTNPRLIQ" , ""},
                { "V1PARC_OTNADFRA" , ""},
                { "V1PARC_OTNCUSTO" , ""},
                { "V1PARC_OTNIOF" , ""},
                { "V1PARC_OTNTOTAL" , ""},
                { "V1PARC_OCORHIST" , ""},
                { "V1PARC_QTDDOC" , ""},
                { "V1PARC_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_SELECT_V1PARCELA_DB_SELECT_2_Query1", q18);

            #endregion

            #region R3220_00_SELECT_V1PARCELA_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUM_APOL" , ""},
                { "V1PARC_NRENDOS" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1PARC_DACPARC" , ""},
                { "V1PARC_FONTE" , ""},
                { "V1PARC_NRTIT" , ""},
                { "V1PARC_PRM_TAR" , ""},
                { "V1PARC_VAL_DES" , ""},
                { "V1PARC_OTNPRLIQ" , ""},
                { "V1PARC_OTNADFRA" , ""},
                { "V1PARC_OTNCUSTO" , ""},
                { "V1PARC_OTNIOF" , ""},
                { "V1PARC_OTNTOTAL" , ""},
                { "V1PARC_OCORHIST" , ""},
                { "V1PARC_QTDDOC" , ""},
                { "V1PARC_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3220_00_SELECT_V1PARCELA_DB_SELECT_1_Query1", q19);

            #endregion

            #region R3200_00_SELECT_V1PARCELA_DB_SELECT_3_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUM_APOL" , ""},
                { "V1PARC_NRENDOS" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1PARC_DACPARC" , ""},
                { "V1PARC_FONTE" , ""},
                { "V1PARC_NRTIT" , ""},
                { "V1PARC_PRM_TAR" , ""},
                { "V1PARC_VAL_DES" , ""},
                { "V1PARC_OTNPRLIQ" , ""},
                { "V1PARC_OTNADFRA" , ""},
                { "V1PARC_OTNCUSTO" , ""},
                { "V1PARC_OTNIOF" , ""},
                { "V1PARC_OTNTOTAL" , ""},
                { "V1PARC_OCORHIST" , ""},
                { "V1PARC_QTDDOC" , ""},
                { "V1PARC_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_SELECT_V1PARCELA_DB_SELECT_3_Query1", q20);

            #endregion

            #region R3250_00_SELECT_V1PARCELA_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUM_APOL" , ""},
                { "V1PARC_NRENDOS" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1PARC_DACPARC" , ""},
                { "V1PARC_FONTE" , ""},
                { "V1PARC_NRTIT" , ""},
                { "V1PARC_PRM_TAR" , ""},
                { "V1PARC_VAL_DES" , ""},
                { "V1PARC_OTNPRLIQ" , ""},
                { "V1PARC_OTNADFRA" , ""},
                { "V1PARC_OTNCUSTO" , ""},
                { "V1PARC_OTNIOF" , ""},
                { "V1PARC_OTNTOTAL" , ""},
                { "V1PARC_OCORHIST" , ""},
                { "V1PARC_QTDDOC" , ""},
                { "V1PARC_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3250_00_SELECT_V1PARCELA_DB_SELECT_1_Query1", q21);

            #endregion

            #region R3300_00_ACESSA_PARCELADEV_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V0PDEV_VLACRESCIMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3300_00_ACESSA_PARCELADEV_DB_SELECT_1_Query1", q22);

            #endregion

            #region R3400_00_ACESSA_CBMALPAR_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0PDEV_VLACRESCIMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3400_00_ACESSA_CBMALPAR_DB_SELECT_1_Query1", q23);

            #endregion

            #region R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "GE403_DTA_VENCIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_1_Query1", q24);

            #endregion

            #region R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_2_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "WS_QTD_DIAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_2_Query1", q25);

            #endregion

            #region CB0003B_V0CALENDARIO

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""},
                { "CALENDAR_DIA_SEMANA" , ""},
                { "CALENDAR_FERIADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("CB0003B_V0CALENDARIO", q26);

            #endregion

            #region R3500_00_SELECT_CBAPOVIG_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "CBAPOVIG_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3500_00_SELECT_CBAPOVIG_DB_SELECT_1_Query1", q27);

            #endregion

            #region R3600_00_SELECT_V1PARCELA_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3600_00_SELECT_V1PARCELA_DB_SELECT_1_Query1", q28);

            #endregion

            #region R5100_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R5100_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1", q29);

            #endregion

            #region R5200_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "V0FOLP_NUM_APOL" , ""},
                { "V0FOLP_NRENDOS" , ""},
                { "V0FOLP_NRPARCEL" , ""},
                { "V0FOLP_DACPARC" , ""},
                { "V0FOLP_DTMOVTO" , ""},
                { "V0FOLP_HORAOPER" , ""},
                { "V0FOLP_VLPREMIO" , ""},
                { "V0FOLP_BCOAVISO" , ""},
                { "V0FOLP_AGEAVISO" , ""},
                { "V0FOLP_NRAVISO" , ""},
                { "V0FOLP_CODBAIXA" , ""},
                { "V0FOLP_CDERRO01" , ""},
                { "V0FOLP_CDERRO02" , ""},
                { "V0FOLP_CDERRO03" , ""},
                { "V0FOLP_CDERRO04" , ""},
                { "V0FOLP_CDERRO05" , ""},
                { "V0FOLP_CDERRO06" , ""},
                { "V0FOLP_SITUACAO" , ""},
                { "V0FOLP_SITCONTB" , ""},
                { "V0FOLP_OPERACAO" , ""},
                { "V0FOLP_DTLIBER" , ""},
                { "V0FOLP_DTQITBCO" , ""},
                { "V0FOLP_COD_EMPRESA" , ""},
                { "V1ENDO_FONTE" , ""},
                { "V0FOLP_NRRCAP" , ""},
                { "V0FOLP_NUM_NOSSO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5200_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1", q30);

            #endregion

            #region R6100_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "WOCORHIST" , ""},
                { "V1PARC_NUM_APOL" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1PARC_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6100_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1", q31);

            #endregion

            #region R6110_00_INCLUI_AUTO_COMPL_DB_SELECT_1_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "WS_QT_REG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6110_00_INCLUI_AUTO_COMPL_DB_SELECT_1_Query1", q32);

            #endregion

            #region R6110_00_INCLUI_AUTO_COMPL_DB_DELETE_1_Delete1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "AU071_NUM_APOLICE" , ""},
                { "AU071_NUM_ENDOSSO" , ""},
                { "AU071_NUM_PARCELA" , ""},
                { "AU071_NUM_VENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6110_00_INCLUI_AUTO_COMPL_DB_DELETE_1_Delete1", q33);

            #endregion

            #region R6110_00_INCLUI_AUTO_COMPL_DB_INSERT_1_Insert1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "AU071_NUM_APOLICE" , ""},
                { "AU071_NUM_ENDOSSO" , ""},
                { "AU071_NUM_PARCELA" , ""},
                { "AU071_DTA_VENCTO" , ""},
                { "AU071_NUM_VENCTO" , ""},
                { "AU071_VLR_PREMIO_LIQUIDO" , ""},
                { "AU071_VLR_JUROS" , ""},
                { "AU071_VLR_ADIC_FRAC" , ""},
                { "AU071_VLR_MULTA" , ""},
                { "AU071_VLR_CUSTO" , ""},
                { "AU071_VLR_IOF" , ""},
                { "AU071_VLR_PREMIO_TOTAL" , ""},
                { "AU071_NUM_RECIBO_CONV" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6110_00_INCLUI_AUTO_COMPL_DB_INSERT_1_Insert1", q34);

            #endregion

            #region R6110_00_INCLUI_AUTO_COMPL_DB_SELECT_2_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "WS_QT_REG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6110_00_INCLUI_AUTO_COMPL_DB_SELECT_2_Query1", q35);

            #endregion

            #region R6150_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTDDOC" , ""},
                { "V1PARC_NUM_APOL" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1PARC_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6150_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1", q36);

            #endregion

            #region R6160_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTDDOC" , ""},
                { "V1PARC_NRPARCEL" , ""},
                { "V1MCOB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6160_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1", q37);

            #endregion

            #region R6200_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUM_APOL" , ""},
                { "V1PARC_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6200_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1", q38);

            #endregion

            #region R6210_00_VERIFICA_PARCELAS_DB_SELECT_1_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_QUANTIDADE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6210_00_VERIFICA_PARCELAS_DB_SELECT_1_Query1", q39);

            #endregion

            #region R6300_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "W1MCOB_SITUACAO" , ""},
                { "W1MCOB_NOME" , ""},
                { "V1MCOB_NUM_APOL" , ""},
                { "V1MCOB_NRPARCEL" , ""},
                { "V1MCOB_AGENCIA" , ""},
                { "V1MCOB_NRAVISO" , ""},
                { "V1MCOB_NRENDOS" , ""},
                { "V1MCOB_BANCO" , ""},
                { "V0MCOB_NRTIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6300_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1", q40);

            #endregion

            #region R6400_00_UPDATE_V0AVISALDOS_DB_UPDATE_1_Update1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "V1MCOB_VALTIT" , ""},
                { "V1MCOB_AGENCIA" , ""},
                { "V1MCOB_NRAVISO" , ""},
                { "V1MCOB_BANCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6400_00_UPDATE_V0AVISALDOS_DB_UPDATE_1_Update1", q41);

            #endregion

            #region R7200_00_UPDATE_V0FOLLOW_DB_UPDATE_1_Update1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R7200_00_UPDATE_V0FOLLOW_DB_UPDATE_1_Update1", q42);

            #endregion

            #region R7250_00_UPDATE_V0FOLLOW_DB_UPDATE_1_Update1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R7250_00_UPDATE_V0FOLLOW_DB_UPDATE_1_Update1", q43);

            #endregion

            #endregion
        }

        [Fact]
        public static void CB0003B_Tests_Fact_Erro99()
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
                #endregion
                var program = new CB0003B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }

        [Fact]
        public static void CB0003B_Tests_Fact()
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

                #region CB0003B_V1MOVICOB

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V1MCOB_CODMOV" , "100"},
                { "V1MCOB_BANCO" , "200"},
                { "V1MCOB_AGENCIA" , "350"},
                { "V1MCOB_NRAVISO" , "400"},
                { "V1MCOB_NUMFITA" , "1"},
                { "V1MCOB_DTMOVTO" , "2020-01-01"},
                { "V1MCOB_DTQITBCO" , "2020-01-30"},
                { "V1MCOB_NRTIT" , "123"},
                { "V1MCOB_NUM_APOL" , "456"},
                { "V1MCOB_NRENDOS" , "789"},
                { "V1MCOB_NRPARCEL" , "10"},
                { "V1MCOB_VALTIT" , "5555"},
                { "V1MCOB_VLIOCC" , "4444"},
                { "V1MCOB_VALCDT" , "3333"},
                { "V1MCOB_SITUACAO" , "A"},
                { "V1MCOB_NOME" , "Teste 01"},
                { "V1MCOB_NUM_NOSSO" , "123456"},
                });
                AppSettings.TestSet.DynamicData.Remove("CB0003B_V1MOVICOB");
                AppSettings.TestSet.DynamicData.Add("CB0003B_V1MOVICOB", q2);

                #endregion

                #region R2100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_ORGAO" , "10"},
                { "V1ENDO_RAMO" , "37"},
                { "V1ENDO_DTEMIS" , "2020-08-05"},
                { "V1ENDO_DTINIVIG" , "2020-05-08"},
                { "V1ENDO_DTTERVIG" , "2021-05-08"},
                { "V1ENDO_MOEDA_IMP" , "1"},
                { "V1ENDO_MOEDA_PRM" , "1"},
                { "V1ENDO_BCORCAP" , "104"},
                { "V1ENDO_AGERCAP" , "3575"},
                { "V1ENDO_DACRCAP" , "0"},
                { "V1ENDO_BCOCOBR" , "104"},
                { "V1ENDO_AGECOBR" , "3575"},
                { "V1ENDO_DACCOBR" , "0"},
                { "V1ENDO_CORRECAO" , "1"},
                { "V1ENDO_CODPRODU" , "3750"},
                { "V1ENDO_FONTE" , "13"},
                { "V1ENDO_NRRCAP" , "555196658"},
                { "V1ENDO_QTPARCEL" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1", q11);

                #endregion

                #region R2200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , "500"}
                });
                q12.AddDynamic(new Dictionary<string, string>{
                { "V1MOED_VLCRUZAD" , "15889"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q12);

                #endregion

                #region R2300_00_SELECT_V1PARAMETRO_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "V1PARM_CODUNIMO" , "99"},
                { "V1PARM_DIFPRM" , "5"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2300_00_SELECT_V1PARAMETRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2300_00_SELECT_V1PARAMETRO_DB_SELECT_1_Query1", q13);

                #endregion

                #region R3000_00_CALCULA_CORRECAO_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "W1_PRM_TAR" , "1000"},
                { "W1_VAL_DES" , "1000"},
                { "W1_VLPRMLIQ" , "1000"},
                { "W1_VLADIFRA" , "1000"},
                { "W1_VLCUSEMI" , "1000"},
                { "W1_VLIOCC" , "1000"},
                { "W1_VLPRMTOT" , "1000"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_CALCULA_CORRECAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_CALCULA_CORRECAO_DB_SELECT_1_Query1", q14);

                #endregion

                #region R3100_00_SELECT_VENCIMENTO_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "W1HISP_DTVENCTO" , ""}
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "W1HISP_DTVENCTO" , ""}
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "W1HISP_DTVENCTO" , ""}
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "W1HISP_DTVENCTO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_VENCIMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_VENCIMENTO_DB_SELECT_1_Query1", q15);

                #endregion

                #region R3150_00_SELECT_V1PARCELA_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_NUM_APOL" , "456"},
                { "V1PARC_NRENDOS" , "789"},
                { "V1PARC_NRPARCEL" , "10"},
                { "V1PARC_DACPARC" , "6000"},
                { "V1PARC_FONTE" , "1"},
                { "V1PARC_NRTIT" , "100"},
                { "V1PARC_PRM_TAR" , "20"},
                { "V1PARC_VAL_DES" , "30"},
                { "V1PARC_OTNPRLIQ" , "40"},
                { "V1PARC_OTNADFRA" , "50"},
                { "V1PARC_OTNCUSTO" , "60"},
                { "V1PARC_OTNIOF" , "70"},
                { "V1PARC_OTNTOTAL" , "80"},
                { "V1PARC_OCORHIST" , "90"},
                { "V1PARC_QTDDOC" , "100"},
                { "V1PARC_SITUACAO" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3150_00_SELECT_V1PARCELA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3150_00_SELECT_V1PARCELA_DB_SELECT_1_Query1", q16);

                #endregion

                #region R3600_00_SELECT_V1PARCELA_DB_SELECT_1_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_COUNT" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3600_00_SELECT_V1PARCELA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3600_00_SELECT_V1PARCELA_DB_SELECT_1_Query1", q28);

                #endregion

                #endregion
                var program = new CB0003B();
                program.Execute();



                //R5100_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["R5100_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList[1].TryGetValue("V0HISP_OPERACAO", out var valor) && valor.Contains("802"));
                Assert.True(envList.Count > 1);

                //R6100_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R6100_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("WOCORHIST", out var valor2) && valor2.Contains("92"));
                Assert.True(envList2.Count > 1);

                //R6300_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1
                var envList12 = AppSettings.TestSet.DynamicData["R6300_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList12[1].TryGetValue("V1MCOB_NRAVISO", out var valor12) && valor12.Contains("0400"));
                Assert.True(envList12.Count > 1);

                //R6400_00_UPDATE_V0AVISALDOS_DB_UPDATE_1_Update1
                var envList13 = AppSettings.TestSet.DynamicData["R6400_00_UPDATE_V0AVISALDOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList13[1].TryGetValue("V1MCOB_AGENCIA", out var valor13) && valor13.Contains("0350"));
                Assert.True(envList13.Count > 1);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
        

        [Fact]
        public static void CB0003B_Tests_Fact2()
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

                #region R2100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_ORGAO" , "110"},
                { "V1ENDO_RAMO" , "37"},
                { "V1ENDO_DTEMIS" , "2020-08-05"},
                { "V1ENDO_DTINIVIG" , "2020-05-08"},
                { "V1ENDO_DTTERVIG" , "2021-05-08"},
                { "V1ENDO_MOEDA_IMP" , "1"},
                { "V1ENDO_MOEDA_PRM" , "1"},
                { "V1ENDO_BCORCAP" , "104"},
                { "V1ENDO_AGERCAP" , "3575"},
                { "V1ENDO_DACRCAP" , "0"},
                { "V1ENDO_BCOCOBR" , "104"},
                { "V1ENDO_AGECOBR" , "3575"},
                { "V1ENDO_DACCOBR" , "0"},
                { "V1ENDO_CORRECAO" , "1"},
                { "V1ENDO_CODPRODU" , "3100"},
                { "V1ENDO_FONTE" , "13"},
                { "V1ENDO_NRRCAP" , "555196658"},
                { "V1ENDO_QTPARCEL" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1", q11);

                #endregion

                #region R3100_00_SELECT_VENCIMENTO_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "W1HISP_DTVENCTO" , ""}
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "W1HISP_DTVENCTO" , ""}
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "W1HISP_DTVENCTO" , ""}
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "W1HISP_DTVENCTO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_VENCIMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_VENCIMENTO_DB_SELECT_1_Query1", q15);

                #endregion

                #region R3600_00_SELECT_V1PARCELA_DB_SELECT_1_Query1

                var q28 = new DynamicData();
                q28.AddDynamic(new Dictionary<string, string>{
                { "V1PARC_COUNT" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3600_00_SELECT_V1PARCELA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3600_00_SELECT_V1PARCELA_DB_SELECT_1_Query1", q28);

                #endregion

                #endregion
                var program = new CB0003B();
                program.Execute();


                //R5200_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1
                var envList6 = AppSettings.TestSet.DynamicData["R5200_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList6[1].TryGetValue("V0FOLP_CODBAIXA", out var valor6) && valor6.Contains("30"));
                Assert.True(envList6.Count > 1);

                //R6150_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1
                var envList9 = AppSettings.TestSet.DynamicData["R6150_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList9[1].TryGetValue("WHOST_QTDDOC", out var valor9) && valor9.Contains("1"));
                Assert.True(envList9.Count > 1);

                //R6300_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1
                var envList12 = AppSettings.TestSet.DynamicData["R6300_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList12[1].TryGetValue("V1MCOB_AGENCIA", out var valor12) && valor12.Contains("0000"));
                Assert.True(envList12.Count > 1);

                Assert.True(program.RETURN_CODE == 00);
            }
        }

        [Fact]
        public static void CB0003B_Tests_Fact3()
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

                #region R3100_00_SELECT_VENCIMENTO_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "W1HISP_DTVENCTO" , ""}
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "W1HISP_DTVENCTO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R3100_00_SELECT_VENCIMENTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_SELECT_VENCIMENTO_DB_SELECT_1_Query1", q15);

                #endregion

                #endregion
                var program = new CB0003B();
                program.Execute();

                //R5100_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["R5100_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList[1].TryGetValue("V0HISP_OPERACAO", out var valor) && valor.Contains("231"));
                Assert.True(envList.Count > 1);

                //R6100_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1
                var envList2 = AppSettings.TestSet.DynamicData["R6100_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("WOCORHIST", out var valor2) && valor2.Contains("2"));
                Assert.True(envList2.Count > 1);

                //R6300_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1
                var envList12 = AppSettings.TestSet.DynamicData["R6300_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList12[1].TryGetValue("V1MCOB_AGENCIA", out var valor12) && valor12.Contains("0000"));
                Assert.True(envList12.Count > 1);

                //R6400_00_UPDATE_V0AVISALDOS_DB_UPDATE_1_Update1
                var envList13 = AppSettings.TestSet.DynamicData["R6400_00_UPDATE_V0AVISALDOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList13[1].TryGetValue("V1MCOB_AGENCIA", out var valor13) && valor13.Contains("0000"));
                Assert.True(envList13.Count > 1);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}