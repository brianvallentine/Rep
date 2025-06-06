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
using static Code.VA0812B;

namespace FileTests.Test
{
    [Collection("VA0812B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class VA0812B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0025_ATUALIZA_FITASASSE_DB_UPDATE_1_Update1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "FITSAS_CREDNEFET" , ""},
                { "FITSAS_CREDEFET" , ""},
                { "WHOST_CODCONV" , ""},
                { "MVCOM_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0025_ATUALIZA_FITASASSE_DB_UPDATE_1_Update1", q1);

            #endregion

            #region M_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_CODPDT" , ""},
                { "MVCOM_AGENCIA" , ""},
                { "MVCOM_OPERACAO" , ""},
                { "MVCOM_CONTA" , ""},
                { "MVCOM_DIG" , ""},
                { "MVCOM_DATA_MOV" , ""},
                { "MVCOM_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_NSAS" , ""},
                { "MVCOM_DATA_MOV" , ""},
                { "RESA_NRCERTIF" , ""},
                { "RESA_DESCR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_0033_LOCALIZA_RESSARC_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SQL_NSAC" , ""},
                { "SQL_NOT_NULL" , ""},
                { "FITCEF_DTRET" , ""},
                { "MVCOM_NSAS" , ""},
                { "MVCOM_NSL1" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0033_LOCALIZA_RESSARC_DB_UPDATE_1_Update1", q4);

            #endregion

            #region M_0033_LOCALIZA_RESSARC_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PROPAZ_CODPRODAZ" , ""},
                { "PROPAZ_DTQITBCO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0033_LOCALIZA_RESSARC_DB_SELECT_2_Query1", q5);

            #endregion

            #region M_0034_LOCALIZA_PREMIACAO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CAMP_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0034_LOCALIZA_PREMIACAO_DB_SELECT_1_Query1", q6);

            #endregion

            #region M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "CAMP_SITUACAO" , ""},
                { "CAMP_CODRET" , ""},
                { "SQL_NSAC" , ""},
                { "MVCOM_NSAS" , ""},
                { "MVCOM_NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_1_Update1", q7);

            #endregion

            #region M_0033_LOCALIZA_RESSARC_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "RESA_NRCERTIF" , ""},
                { "HISR_NUM_PARCELA" , ""},
                { "MVCOM_DATA_MOV" , ""},
                { "HISR_CODOPER" , ""},
                { "DTMOVABE" , ""},
                { "MVCOM_NSAS" , ""},
                { "MVCOM_NSL1" , ""},
                { "SQL_NSAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0033_LOCALIZA_RESSARC_DB_INSERT_1_Insert1", q8);

            #endregion

            #region M_0034_LOCALIZA_PREMIACAO_DB_SELECT_2_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "CAMP_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0034_LOCALIZA_PREMIACAO_DB_SELECT_2_Query1", q9);

            #endregion

            #region M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_2_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "CAMP_SITUACAO" , ""},
                { "CAMP_CODRET" , ""},
                { "SQL_NSAC" , ""},
                { "MVCOM_NSAS" , ""},
                { "MVCOM_NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_2_Update1", q10);

            #endregion

            #region M_0033_LOCALIZA_RESSARC_DB_UPDATE_2_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SQL_NSAC" , ""},
                { "SQL_NOT_NULL" , ""},
                { "MVCOM_NSAS" , ""},
                { "MVCOM_NSL1" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0033_LOCALIZA_RESSARC_DB_UPDATE_2_Update1", q11);

            #endregion

            #region M_0034_LOCALIZA_PREMIACAO_DB_SELECT_3_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "CAMP_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0034_LOCALIZA_PREMIACAO_DB_SELECT_3_Query1", q12);

            #endregion

            #region M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_3_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "CAMP_SITUACAO" , ""},
                { "CAMP_CODRET" , ""},
                { "SQL_NSAC" , ""},
                { "MVCOM_NSAS" , ""},
                { "MVCOM_NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_3_Update1", q13);

            #endregion

            #region M_0033_LOCALIZA_RESSARC_DB_SELECT_3_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "PROPAZ_CODPRODAZ" , ""},
                { "V0SEGV_DTINIVIG" , ""},
                { "V0SEGV_DTRENOVA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0033_LOCALIZA_RESSARC_DB_SELECT_3_Query1", q14);

            #endregion

            #region M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , ""},
                { "HCTA_NRPARCEL" , ""},
                { "HCTA_VLPRMTOT" , ""},
                { "HCTA_SITUACAO" , ""},
                { "HCTA_CODRET" , ""},
                { "HCTA_OCORRHISTCTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1", q15);

            #endregion

            #region M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , ""},
                { "HCTA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_1_Update1", q16);

            #endregion

            #region M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_2_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , ""},
                { "HCTA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_2_Update1", q17);

            #endregion

            #region M_0036_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "PROP_NUM_APOLICE" , ""},
                { "PROP_CODSUBES" , ""},
                { "PROP_FONTE" , ""},
                { "PROP_DTVENCTO" , ""},
                { "PROP_OCORHIST" , ""},
                { "PROP_DTQITBCO" , ""},
                { "PROP_CODCLIEN" , ""},
                { "PROP_OPCAO_COBER" , ""},
                { "PROP_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0036_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1", q18);

            #endregion

            #region M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_3_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "HCTA_SITUACAO" , ""},
                { "HCTA_CODRET" , ""},
                { "SQL_NSAC" , ""},
                { "WHOST_CODCONV" , ""},
                { "MVCOM_NSAS" , ""},
                { "MVCOM_NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_3_Update1", q19);

            #endregion

            #region M_0036_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_DATA_NASCIMENTO" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0036_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1", q20);

            #endregion

            #region M_0036_INSERT_DB_INSERT_1_Insert1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , ""},
                { "HCTA_NRPARCEL" , ""},
                { "HCVA_NRTIT" , ""},
                { "HCVA_OCORHIST" , ""},
                { "PROP_NUM_APOLICE" , ""},
                { "PROP_CODSUBES" , ""},
                { "PROP_FONTE" , ""},
                { "HOST_PRMVG" , ""},
                { "HOST_PRMAP" , ""},
                { "DTMOVABE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0036_INSERT_DB_INSERT_1_Insert1", q21);

            #endregion

            #region M_0036_INSERT_DB_UPDATE_1_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "HCVA_OCORHIST" , ""},
                { "HCTA_NRCERTIF" , ""},
                { "HCTA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0036_INSERT_DB_UPDATE_1_Update1", q22);

            #endregion

            #region M_0036_INSERT_HISTCONTABILVA_DB_SELECT_3_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "CBVA_VLPREMIO" , ""},
                { "CBVA_PRMVG" , ""},
                { "CBVA_PRMAP" , ""},
                { "CBVA_IMPMORNATU" , ""},
                { "CBVA_IMPMORACID" , ""},
                { "CBVA_IMPDIT" , ""},
                { "CBVA_IMPSEGCDG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0036_INSERT_HISTCONTABILVA_DB_SELECT_3_Query1", q23);

            #endregion

            #region M_0036_INSERT_DB_UPDATE_2_Update1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , ""},
                { "HCTA_NRPARCEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0036_INSERT_DB_UPDATE_2_Update1", q24);

            #endregion

            #region M_0036_INSERT_HISTCONTABILVA_DB_SELECT_4_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "CBVA_VLPREMIO" , ""},
                { "CBVA_PRMVG" , ""},
                { "CBVA_PRMAP" , ""},
                { "CBVA_IMPMORNATU" , ""},
                { "CBVA_IMPMORACID" , ""},
                { "CBVA_IMPDIT" , ""},
                { "CBVA_IMPSEGCDG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0036_INSERT_HISTCONTABILVA_DB_SELECT_4_Query1", q25);

            #endregion

            #region VA0812B_CVGRAMOCOMP

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "VG081_NUM_APOLICE" , ""},
                { "VG081_COD_SUBGRUPO" , ""},
                { "VG081_COD_GRUPO_SUSEP" , ""},
                { "VG081_RAMO_EMISSOR" , ""},
                { "VG081_COD_MODALIDADE" , ""},
                { "VG081_DTH_INI_VIGENCIA" , ""},
                { "VG081_COD_OPCAO_COBERTURA" , ""},
                { "VG081_NUM_IDADE_INICIAL" , ""},
                { "VG081_NUM_IDADE_FINAL" , ""},
                { "VG081_VLR_PERC_PREMIO" , ""},
                { "VG081_COD_USUARIO" , ""},
                { "VG081_DTH_ATUALIZACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0812B_CVGRAMOCOMP", q26);

            #endregion

            #region VA0812B_V1AGENCEF

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "V1ACEF_COD_AGENCIA" , ""},
                { "V1MCEF_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0812B_V1AGENCEF", q27);

            #endregion

            #region M_0036_INSERT_HISTCONTABILVA_DB_SELECT_5_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "CBVA_VLPREMIO" , ""},
                { "CBVA_PRMVG" , ""},
                { "CBVA_PRMAP" , ""},
                { "CBVA_IMPMORNATU" , ""},
                { "CBVA_IMPMORACID" , ""},
                { "CBVA_IMPDIT" , ""},
                { "CBVA_IMPSEGCDG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0036_INSERT_HISTCONTABILVA_DB_SELECT_5_Query1", q28);

            #endregion

            #region M_0036_INSERT_HISTCONTABILVA_DB_SELECT_6_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "HCVA_OCORHIST" , ""},
                { "HCVA_NRTIT" , ""},
                { "HCVA_DTVENCTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0036_INSERT_HISTCONTABILVA_DB_SELECT_6_Query1", q29);

            #endregion

            #region M_0041_LOCALIZA_6039_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_NSAS" , ""},
                { "MVCOM_DATA_MOV" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0041_LOCALIZA_6039_DB_SELECT_1_Query1", q30);

            #endregion

            #region M_0042_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , ""},
                { "HCTA_NRPARCEL" , ""},
                { "HCVA_NRTIT" , ""},
                { "HCVA_OCORHIST" , ""},
                { "WHOST_GRUPO_SUSEP" , ""},
                { "WHOST_COD_RAMO" , ""},
                { "VG082_COD_MODALIDADE" , ""},
                { "VG082_COD_COBERTURA" , ""},
                { "WHOST_PREMIO_CONJ" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0042_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1", q31);

            #endregion

            #region M_0050_GERA_FITACEF_DB_SELECT_1_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "FITCEF_DTRET" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0050_GERA_FITACEF_DB_SELECT_1_Query1", q32);

            #endregion

            #region M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "FITCEF_TOTCRNEFET" , ""},
                { "FITCEF_TOTCREFET" , ""},
                { "FITCEF_QTLANCCR" , ""},
                { "FITCEF_QTCREFET" , ""},
                { "SQL_NSAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1", q33);

            #endregion

            #region M_0055_INSERT_FITACEF_DB_INSERT_1_Insert1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "SQL_NSAC" , ""},
                { "FITCEF_DTRET" , ""},
                { "FITCEF_VERSAO" , ""},
                { "FITCEF_QTREG" , ""},
                { "FITCEF_QTLANCCR" , ""},
                { "FITCEF_TOTCREFET" , ""},
                { "FITCEF_TOTCRNEFET" , ""},
                { "FITCEF_QTCREFET" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0055_INSERT_FITACEF_DB_INSERT_1_Insert1", q34);

            #endregion

            #region M_0060_LOCALIZA_6075_DB_SELECT_1_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "V0RESG_SITUACAO" , ""},
                { "V0RESG_DTCREDITO" , ""},
                { "V0RESG_NSAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0060_LOCALIZA_6075_DB_SELECT_1_Query1", q35);

            #endregion

            #region M_0061_QUITA_RESGATE_DB_UPDATE_1_Update1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_COD_RETORNO" , ""},
                { "V0RESG_DTCREDITO" , ""},
                { "SQL_NSAC" , ""},
                { "V0RESG_NRCERTIF" , ""},
                { "MVCOM_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0061_QUITA_RESGATE_DB_UPDATE_1_Update1", q36);

            #endregion

            #region M_0062_REJEITA_RESGATE_DB_UPDATE_1_Update1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_COD_RETORNO" , ""},
                { "SQL_NSAC" , ""},
                { "V0RESG_NRCERTIF" , ""},
                { "MVCOM_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0062_REJEITA_RESGATE_DB_UPDATE_1_Update1", q37);

            #endregion

            #region M_0075_SOLICITA_RELAT_DB_INSERT_1_Insert1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "DTMOVABE" , ""},
                { "SQL_NSAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0075_SOLICITA_RELAT_DB_INSERT_1_Insert1", q38);

            #endregion

            #region M_0100_INSERT_AVISOS_DB_INSERT_1_Insert1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V0AVIS_BCOAVISO" , ""},
                { "V0AVIS_AGEAVISO" , ""},
                { "V0AVIS_NRAVISO" , ""},
                { "V0AVIS_NRSEQ" , ""},
                { "V0AVIS_DTMOVTO" , ""},
                { "V0AVIS_OPERACAO" , ""},
                { "V0AVIS_TIPAVI" , ""},
                { "V0AVIS_DTAVISO" , ""},
                { "V0AVIS_VLIOCC" , ""},
                { "V0AVIS_VLDESPES" , ""},
                { "V0AVIS_PRECED" , ""},
                { "V0AVIS_VLPRMLIQ" , ""},
                { "V0AVIS_VLPRMTOT" , ""},
                { "V0AVIS_SITCONTB" , ""},
                { "V0AVIS_CODEMP" , ""},
                { "V0AVIS_ORIGAVISO" , ""},
                { "V0AVIS_VALADT" , ""},
                { "V0AVIS_SITDEPTER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_INSERT_AVISOS_DB_INSERT_1_Insert1", q39);

            #endregion

            #region M_0100_INSERT_AVISOS_DB_INSERT_2_Insert1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V0SALD_CODEMP" , ""},
                { "V0SALD_BCOAVISO" , ""},
                { "V0SALD_AGEAVISO" , ""},
                { "V0SALD_TIPSGU" , ""},
                { "V0SALD_NRAVISO" , ""},
                { "V0SALD_DTAVISO" , ""},
                { "V0SALD_DTMOVTO" , ""},
                { "V0SALD_SDOATU" , ""},
                { "V0SALD_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_INSERT_AVISOS_DB_INSERT_2_Insert1", q40);

            #endregion

            #region M_1132_QUITA_COMISSAO_DB_UPDATE_1_Update1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_NSAS" , ""},
                { "MVCOM_NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1132_QUITA_COMISSAO_DB_UPDATE_1_Update1", q41);

            #endregion

            #region M_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "FUNCEF_AGENCIA" , ""},
                { "FUNCEF_OPERACAO" , ""},
                { "FUNCEF_CONTA" , ""},
                { "FUNCEF_DIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1", q42);

            #endregion

            #region M_1332_ATUALIZA_CONTA_DB_UPDATE_1_Update1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "FUNCEF_OPERACAO" , ""},
                { "FUNCEF_AGENCIA" , ""},
                { "FUNCEF_CONTA" , ""},
                { "FUNCEF_DIG" , ""},
                { "MVCOM_NSAS" , ""},
                { "MVCOM_NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1332_ATUALIZA_CONTA_DB_UPDATE_1_Update1", q43);

            #endregion

            #region M_1432_REJEITA_COMISSAO_DB_UPDATE_1_Update1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_NSAS" , ""},
                { "MVCOM_NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1432_REJEITA_COMISSAO_DB_UPDATE_1_Update1", q44);

            #endregion

            #region M_1532_GERA_RETCOMIS_DB_SELECT_1_Query1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_DATA_MOV" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1532_GERA_RETCOMIS_DB_SELECT_1_Query1", q45);

            #endregion

            #region M_1532_GERA_RETCOMIS_DB_INSERT_1_Insert1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "SQL_NSAC" , ""},
                { "MVCOM_NSAS" , ""},
                { "MVCOM_NSL" , ""},
                { "MVCOM_COD_RETORNO" , ""},
                { "DTMOVABE" , ""},
                { "MVCOM_DATA_MOV" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1532_GERA_RETCOMIS_DB_INSERT_1_Insert1", q46);

            #endregion

            #region M_1141_QUITA_COMISSAO_DB_UPDATE_1_Update1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_NSAS" , ""},
                { "MVCOM_NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1141_QUITA_COMISSAO_DB_UPDATE_1_Update1", q47);

            #endregion

            #region M_1241_REJEITA_COMISSAO_DB_SELECT_1_Query1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "PROPAZ_AGELOTE" , ""},
                { "PROPAZ_DTLOTE" , ""},
                { "PROPAZ_DTQITBCO" , ""},
                { "PROPAZ_NRLOTE" , ""},
                { "PROPAZ_NRSEQLOTE" , ""},
                { "PROPAZ_CODPRODAZ" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1241_REJEITA_COMISSAO_DB_SELECT_1_Query1", q48);

            #endregion

            #region M_1241_REJEITA_COMISSAO_DB_UPDATE_1_Update1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_NSAS" , ""},
                { "MVCOM_NSL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1241_REJEITA_COMISSAO_DB_UPDATE_1_Update1", q49);

            #endregion

            #region M_1241_REJEITA_COMISSAO_DB_INSERT_1_Insert1

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "SQL_NSAC" , ""},
                { "MVCOM_NSAS" , ""},
                { "MVCOM_NSL" , ""},
                { "MVCOM_COD_RETORNO" , ""},
                { "DTMOVABE" , ""},
                { "MVCOM_DATA_MOV" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1241_REJEITA_COMISSAO_DB_INSERT_1_Insert1", q50);

            #endregion

            #region M_1241_REJEITA_COMISSAO_DB_SELECT_2_Query1

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>{
                { "COMPROPH_VLCOMISVG" , ""},
                { "COMPROPH_VLCOMISAP" , ""},
                { "COMPROPH_VALBASVG" , ""},
                { "COMPROPH_VALBASAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1241_REJEITA_COMISSAO_DB_SELECT_2_Query1", q51);

            #endregion

            #region M_1241_REJEITA_COMISSAO_DB_UPDATE_2_Update1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "USUARIO" , ""},
                { "PROPAZ_NRSEQLOTE" , ""},
                { "PROPAZ_NRPROPAZ" , ""},
                { "PROPAZ_AGELOTE" , ""},
                { "PROPAZ_DTLOTE" , ""},
                { "PROPAZ_NRLOTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1241_REJEITA_COMISSAO_DB_UPDATE_2_Update1", q52);

            #endregion

            #region M_1241_REJEITA_COMISSAO_DB_INSERT_2_Insert1

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
                { "PROPAZ_NRPROPAZ" , ""},
                { "PROPAZ_AGELOTE" , ""},
                { "PROPAZ_DTLOTE" , ""},
                { "PROPAZ_NRLOTE" , ""},
                { "PROPAZ_NRSEQLOTE" , ""},
                { "COMPROPH_VLCOMISVG" , ""},
                { "COMPROPH_VLCOMISAP" , ""},
                { "COMPROPH_VALBASVG" , ""},
                { "COMPROPH_VALBASAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1241_REJEITA_COMISSAO_DB_INSERT_2_Insert1", q53);

            #endregion

            #region VA0812B_V0PRODUTO

            var q54 = new DynamicData();
            q54.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_CODPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VA0812B_V0PRODUTO", q54);

            #endregion

            #region M_8800_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1

            var q55 = new DynamicData();
            q55.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRPARCEL" , ""},
                { "VGFOLLOW_NUM_CERTIFICADO" , ""},
                { "VGFOLLOW_NUM_NOSSA_FITA" , ""},
                { "VGFOLLOW_NUM_LANCAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_8800_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1", q55);

            #endregion

            #region R8010_00_VER_PRODUTO_DB_SELECT_1_Query1

            var q56 = new DynamicData();
            q56.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8010_00_VER_PRODUTO_DB_SELECT_1_Query1", q56);

            #endregion

            #region R8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1

            var q57 = new DynamicData();
            q57.AddDynamic(new Dictionary<string, string>{
                { "V0DPCF_CODEMP" , ""},
                { "V0DPCF_ANOREF" , ""},
                { "V0DPCF_MESREF" , ""},
                { "V0DPCF_BCOAVISO" , ""},
                { "V0DPCF_AGEAVISO" , ""},
                { "V0DPCF_NRAVISO" , ""},
                { "V0DPCF_CODPRODU" , ""},
                { "V0DPCF_TIPOREG" , ""},
                { "V0DPCF_SITUACAO" , ""},
                { "V0DPCF_TIPOCOB" , ""},
                { "V0DPCF_DTMOVTO" , ""},
                { "V0DPCF_DTAVISO" , ""},
                { "V0DPCF_QTDREG" , ""},
                { "V0DPCF_VLPRMTOT" , ""},
                { "V0DPCF_VLPRMLIQ" , ""},
                { "V0DPCF_VLTARIFA" , ""},
                { "V0DPCF_VLBALCAO" , ""},
                { "V0DPCF_VLIOCC" , ""},
                { "V0DPCF_VLDESCON" , ""},
                { "V0DPCF_VLJUROS" , ""},
                { "V0DPCF_VLMULTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1", q57);

            #endregion

            VA0100S_Tests.Load_Parameters();
            #endregion
        }
        [Theory]
        [InlineData("VA0812B_Entrada1_R6131.txt", "VA0812B_Saida1_R6131.txt")]
        public static void VA0812B_Tests_Theory_R6131_ReturnCode_9(string RETCRE_FILE_NAME_P, string RETINV_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RETINV_FILE_NAME_P = $"{RETINV_FILE_NAME_P}_{timestamp}.txt";
           
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region VA0812B_V1AGENCEF

                var q27 = new DynamicData();
                q27.AddDynamic(new Dictionary<string, string>{
                { "V1ACEF_COD_AGENCIA" , ""},
                { "V1MCEF_COD_FONTE" , ""},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("VA0812B_V1AGENCEF");
                AppSettings.TestSet.DynamicData.Add("VA0812B_V1AGENCEF", q27);

                #endregion
                #endregion
                var program = new VA0812B();
                program.Execute(RETCRE_FILE_NAME_P, RETINV_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 9);


            }
        }
        [Theory]
        [InlineData("VA0812B_Entrada2_R6131.txt", "VA0812B_Saida2_R6131.txt")]
        public static void VA0812B_Tests_Theory_R6131_ReturnCode_0(string RETCRE_FILE_NAME_P, string RETINV_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RETINV_FILE_NAME_P = $"{RETINV_FILE_NAME_P}_{timestamp}.txt";
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
                var program = new VA0812B();
                program.Execute(RETCRE_FILE_NAME_P, RETINV_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                Assert.True(program.V0AVIS_AGEAVISO == 7383);
                Assert.True(program.SQL_NSAC == 29042);

            }
        }
        [Theory]
        [InlineData("VA0812B_Entrada_R6090.txt", "VA0812B_Saida_R6090.txt")]
        public static void VA0812B_Tests_Theory_R6090_ReturnCode_0(string RETCRE_FILE_NAME_P, string RETINV_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RETINV_FILE_NAME_P = $"{RETINV_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , "1023684651"},
                { "HCTA_NRPARCEL" , "1"},
                { "HCTA_VLPRMTOT" , "15"},
                { "HCTA_SITUACAO" , "2"},
                { "HCTA_CODRET" , ""},
                { "HCTA_OCORRHISTCTA" , "1"},
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , "1023684651"},
                { "HCTA_NRPARCEL" , "2"},
                { "HCTA_VLPRMTOT" , "15"},
                { "HCTA_SITUACAO" , "2"},
                { "HCTA_CODRET" , ""},
                { "HCTA_OCORRHISTCTA" , "1"},
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , "1023684651"},
                { "HCTA_NRPARCEL" , "3"},
                { "HCTA_VLPRMTOT" , "15"},
                { "HCTA_SITUACAO" , "2"},
                { "HCTA_CODRET" , ""},
                { "HCTA_OCORRHISTCTA" , "1"},
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , "1023684651"},
                { "HCTA_NRPARCEL" , "4"},
                { "HCTA_VLPRMTOT" , "15"},
                { "HCTA_SITUACAO" , "2"},
                { "HCTA_CODRET" , ""},
                { "HCTA_OCORRHISTCTA" , "1"},
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , "1023684651"},
                { "HCTA_NRPARCEL" , "5"},
                { "HCTA_VLPRMTOT" , "15"},
                { "HCTA_SITUACAO" , "2"},
                { "HCTA_CODRET" , ""},
                { "HCTA_OCORRHISTCTA" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1", q15);

                #endregion
                #region R8010_00_VER_PRODUTO_DB_SELECT_1_Query1

                var q56 = new DynamicData();
                q56.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODPRODU" , "9304"}
                });
                q56.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_CODPRODU" , "9304"}
                });
                AppSettings.TestSet.DynamicData.Remove("R8010_00_VER_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R8010_00_VER_PRODUTO_DB_SELECT_1_Query1", q56);

                #endregion
                #region M_0050_GERA_FITACEF_DB_SELECT_1_Query1

                var q32 = new DynamicData();
                q32.AddDynamic(new Dictionary<string, string>{
                { "FITCEF_DTRET" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0050_GERA_FITACEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0050_GERA_FITACEF_DB_SELECT_1_Query1", q32);

                #endregion
                #endregion
                var program = new VA0812B();
                program.Execute(RETCRE_FILE_NAME_P, RETINV_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                Assert.True(program.V0AVIS_AGEAVISO == 7004);
                Assert.True(program.SQL_NSAC == 25568);

                //M_0025_ATUALIZA_FITASASSE_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["M_0025_ATUALIZA_FITASASSE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("MVCOM_NSAS", out var valor0) && valor0.Contains("1675"));

                //M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("HCTA_NRCERTIF", out var valor1) && valor1.Contains("000001023684651"));

                //M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_2_Update1
                var envList2 = AppSettings.TestSet.DynamicData["M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("HCTA_NRPARCEL", out var valor2) && valor2.Contains("0001"));

                //M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_3_Update1
                var envList3 = AppSettings.TestSet.DynamicData["M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_3_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("MVCOM_NSL", out var valor3) && valor3.Contains("000000276"));

                //M_0036_INSERT_DB_INSERT_1_Insert1
                var envList4 = AppSettings.TestSet.DynamicData["M_0036_INSERT_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("HCVA_OCORHIST", out var valor4) && valor4.Contains("0001"));
                Assert.True(envList4.Count > 1);

                //M_0036_INSERT_DB_UPDATE_1_Update1
                var envList5 = AppSettings.TestSet.DynamicData["M_0036_INSERT_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("HCTA_NRCERTIF", out var valor5) && valor5.Contains("000001023684651"));

                //M_0036_INSERT_DB_UPDATE_2_Update1
                var envList6 = AppSettings.TestSet.DynamicData["M_0036_INSERT_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList6[1].TryGetValue("HCTA_NRCERTIF", out var valor6) && valor6.Contains("000001023684651"));

                //M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1
                var envList7 = AppSettings.TestSet.DynamicData["M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList7[1].TryGetValue("FITCEF_TOTCRNEFET", out var valor7) && valor7.Contains("0000000018803.00"));

                //M_0100_INSERT_AVISOS_DB_INSERT_1_Insert1
                var envList8 = AppSettings.TestSet.DynamicData["M_0100_INSERT_AVISOS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList8[1].TryGetValue("V0AVIS_NRAVISO", out var valor8) && valor8.Contains("609086568"));
                Assert.True(envList8.Count > 1);

                //M_0100_INSERT_AVISOS_DB_INSERT_2_Insert1
                var envList9 = AppSettings.TestSet.DynamicData["M_0100_INSERT_AVISOS_DB_INSERT_2_Insert1"].DynamicList;
                Assert.True(envList9[1].TryGetValue("V0SALD_AGEAVISO", out var valor9) && valor9.Contains("7004"));
                Assert.True(envList9.Count > 1);

                //M_8800_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1
                var envList10 = AppSettings.TestSet.DynamicData["M_8800_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList10[1].TryGetValue("VGFOLLOW_NUM_CERTIFICADO", out var valor10) && valor10.Contains("000095727807117"));


            }
        }
        [Theory]
        [InlineData("VA0812B_Entrada1_R6088.txt", "VA0812B_Saida1_R6088.txt")]
        public static void VA0812B_Tests_Theory_R6088_ReturnCode_0(string RETCRE_FILE_NAME_P, string RETINV_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RETINV_FILE_NAME_P = $"{RETINV_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , "1023684651"},
                { "HCTA_NRPARCEL" , "1"},
                { "HCTA_VLPRMTOT" , "15"},
                { "HCTA_SITUACAO" , "2"},
                { "HCTA_CODRET" , ""},
                { "HCTA_OCORRHISTCTA" , "1"},
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , "1023684651"},
                { "HCTA_NRPARCEL" , "2"},
                { "HCTA_VLPRMTOT" , "15"},
                { "HCTA_SITUACAO" , "2"},
                { "HCTA_CODRET" , ""},
                { "HCTA_OCORRHISTCTA" , "1"},
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , "1023684651"},
                { "HCTA_NRPARCEL" , "3"},
                { "HCTA_VLPRMTOT" , "15"},
                { "HCTA_SITUACAO" , "2"},
                { "HCTA_CODRET" , ""},
                { "HCTA_OCORRHISTCTA" , "1"},
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , "1023684651"},
                { "HCTA_NRPARCEL" , "4"},
                { "HCTA_VLPRMTOT" , "15"},
                { "HCTA_SITUACAO" , "2"},
                { "HCTA_CODRET" , ""},
                { "HCTA_OCORRHISTCTA" , "1"},
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , "1023684651"},
                { "HCTA_NRPARCEL" , "5"},
                { "HCTA_VLPRMTOT" , "15"},
                { "HCTA_SITUACAO" , "2"},
                { "HCTA_CODRET" , ""},
                { "HCTA_OCORRHISTCTA" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1", q15);

                #endregion
                #region M_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_CODPDT" , "306614"},
                { "MVCOM_AGENCIA" , "11"},
                { "MVCOM_OPERACAO" , "0"},
                { "MVCOM_CONTA" , "4800008"},
                { "MVCOM_DIG" , "4"},
                { "MVCOM_DATA_MOV" , "2024-12-06"},
                { "MVCOM_SITUACAO" , "1"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_CODPDT" , "306614"},
                { "MVCOM_AGENCIA" , "11"},
                { "MVCOM_OPERACAO" , "0"},
                { "MVCOM_CONTA" , "4800008"},
                { "MVCOM_DIG" , "4"},
                { "MVCOM_DATA_MOV" , "2024-12-06"},
                { "MVCOM_SITUACAO" , "1"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_CODPDT" , "306614"},
                { "MVCOM_AGENCIA" , "11"},
                { "MVCOM_OPERACAO" , "0"},
                { "MVCOM_CONTA" , "4800008"},
                { "MVCOM_DIG" , "4"},
                { "MVCOM_DATA_MOV" , "2024-12-06"},
                { "MVCOM_SITUACAO" , "1"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_CODPDT" , "306614"},
                { "MVCOM_AGENCIA" , "11"},
                { "MVCOM_OPERACAO" , "0"},
                { "MVCOM_CONTA" , "4800008"},
                { "MVCOM_DIG" , "4"},
                { "MVCOM_DATA_MOV" , "2024-12-06"},
                { "MVCOM_SITUACAO" , "1"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_CODPDT" , "306614"},
                { "MVCOM_AGENCIA" , "11"},
                { "MVCOM_OPERACAO" , "0"},
                { "MVCOM_CONTA" , "4800008"},
                { "MVCOM_DIG" , "4"},
                { "MVCOM_DATA_MOV" , "2024-12-06"},
                { "MVCOM_SITUACAO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1", q2);

                #endregion
                #region M_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1

                var q42 = new DynamicData();
                q42.AddDynamic(new Dictionary<string, string>{
                { "FUNCEF_AGENCIA" , "29"},
                { "FUNCEF_OPERACAO" , "13"},
                { "FUNCEF_CONTA" , "273213"},
                { "FUNCEF_DIG" , "0"},
                });
                q42.AddDynamic(new Dictionary<string, string>{
                { "FUNCEF_AGENCIA" , "29"},
                { "FUNCEF_OPERACAO" , "13"},
                { "FUNCEF_CONTA" , "273213"},
                { "FUNCEF_DIG" , "0"},
                });
                q42.AddDynamic(new Dictionary<string, string>{
                { "FUNCEF_AGENCIA" , "29"},
                { "FUNCEF_OPERACAO" , "13"},
                { "FUNCEF_CONTA" , "273213"},
                { "FUNCEF_DIG" , "0"},
                });
                q42.AddDynamic(new Dictionary<string, string>{
                { "FUNCEF_AGENCIA" , "29"},
                { "FUNCEF_OPERACAO" , "13"},
                { "FUNCEF_CONTA" , "273213"},
                { "FUNCEF_DIG" , "0"},
                });
                q42.AddDynamic(new Dictionary<string, string>{
                { "FUNCEF_AGENCIA" , "29"},
                { "FUNCEF_OPERACAO" , "13"},
                { "FUNCEF_CONTA" , "273213"},
                { "FUNCEF_DIG" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1", q42);

                #endregion
                #region M_1532_GERA_RETCOMIS_DB_SELECT_1_Query1

                var q45 = new DynamicData();
                q45.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_DATA_MOV" , "2022-05-15"}
                });
                q45.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_DATA_MOV" , "2022-05-15"}
                });
                q45.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_DATA_MOV" , "2022-05-15"}
                });
                q45.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_DATA_MOV" , "2022-05-15"}
                });
                q45.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_DATA_MOV" , "2022-05-15"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1532_GERA_RETCOMIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1532_GERA_RETCOMIS_DB_SELECT_1_Query1", q45);

                #endregion

                #region M_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_NSAS" , "198"},
                { "MVCOM_DATA_MOV" , "2024-07-06"},
                { "RESA_NRCERTIF" , "10000021751"},
                { "RESA_DESCR" , "PARC 46 CONTRATACAO SEGURO NOVO"},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_NSAS" , "214"},
                { "MVCOM_DATA_MOV" , "2024-07-06"},
                { "RESA_NRCERTIF" , "10000021751"},
                { "RESA_DESCR" , "PARC 47 CONTRATACAO SEGURO NOVO"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1", q3);

                #endregion
                #endregion
                var program = new VA0812B();
                program.Execute(RETCRE_FILE_NAME_P, RETINV_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                Assert.True(program.SQL_NSAC == 568);

                //M_0025_ATUALIZA_FITASASSE_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["M_0025_ATUALIZA_FITASASSE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("MVCOM_NSAS", out var valor0) && valor0.Contains("1675"));

                //M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("FITCEF_TOTCRNEFET", out var valor1) && valor1.Contains("0000000018803.00"));

                //M_0075_SOLICITA_RELAT_DB_INSERT_1_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["M_0075_SOLICITA_RELAT_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("SQL_NSAC", out var valor2) && valor2.Contains("0568"));
                Assert.True(envList2.Count > 1);

                //M_1132_QUITA_COMISSAO_DB_UPDATE_1_Update1
                var envList3 = AppSettings.TestSet.DynamicData["M_1132_QUITA_COMISSAO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("MVCOM_NSAS", out var valor3) && valor3.Contains("1676"));

                //M_1332_ATUALIZA_CONTA_DB_UPDATE_1_Update1
                var envList4 = AppSettings.TestSet.DynamicData["M_1332_ATUALIZA_CONTA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("FUNCEF_CONTA", out var valor4) && valor4.Contains("0000000273213"));

                //M_1532_GERA_RETCOMIS_DB_INSERT_1_Insert1
                var envList5 = AppSettings.TestSet.DynamicData["M_1532_GERA_RETCOMIS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("MVCOM_NSL", out var valor5) && valor5.Contains("000000276"));
                Assert.True(envList5.Count > 1);

                //M_8800_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1
                var envList6 = AppSettings.TestSet.DynamicData["M_8800_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList6[1].TryGetValue("VGFOLLOW_NUM_CERTIFICADO", out var valor6) && valor6.Contains("000095727807117"));


            }
        }
        [Theory]
        [InlineData("VA0812B_Entrada2_R6088.txt", "VA0812B_Saida2_R6088.txt")]
        public static void VA0812B_Tests_Theory_R6088_SalesComisRejection_ReturnCode_0(string RETCRE_FILE_NAME_P, string RETINV_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RETINV_FILE_NAME_P = $"{RETINV_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , "1023684651"},
                { "HCTA_NRPARCEL" , "1"},
                { "HCTA_VLPRMTOT" , "15"},
                { "HCTA_SITUACAO" , "2"},
                { "HCTA_CODRET" , ""},
                { "HCTA_OCORRHISTCTA" , "1"},
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , "1023684651"},
                { "HCTA_NRPARCEL" , "2"},
                { "HCTA_VLPRMTOT" , "15"},
                { "HCTA_SITUACAO" , "2"},
                { "HCTA_CODRET" , ""},
                { "HCTA_OCORRHISTCTA" , "1"},
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , "1023684651"},
                { "HCTA_NRPARCEL" , "3"},
                { "HCTA_VLPRMTOT" , "15"},
                { "HCTA_SITUACAO" , "2"},
                { "HCTA_CODRET" , ""},
                { "HCTA_OCORRHISTCTA" , "1"},
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , "1023684651"},
                { "HCTA_NRPARCEL" , "4"},
                { "HCTA_VLPRMTOT" , "15"},
                { "HCTA_SITUACAO" , "2"},
                { "HCTA_CODRET" , ""},
                { "HCTA_OCORRHISTCTA" , "1"},
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , "1023684651"},
                { "HCTA_NRPARCEL" , "5"},
                { "HCTA_VLPRMTOT" , "15"},
                { "HCTA_SITUACAO" , "2"},
                { "HCTA_CODRET" , ""},
                { "HCTA_OCORRHISTCTA" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1", q15);

                #endregion
                #region M_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_CODPDT" , "306614"},
                { "MVCOM_AGENCIA" , "11"},
                { "MVCOM_OPERACAO" , "0"},
                { "MVCOM_CONTA" , "4800008"},
                { "MVCOM_DIG" , "4"},
                { "MVCOM_DATA_MOV" , "2024-12-06"},
                { "MVCOM_SITUACAO" , "1"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_CODPDT" , "306614"},
                { "MVCOM_AGENCIA" , "11"},
                { "MVCOM_OPERACAO" , "0"},
                { "MVCOM_CONTA" , "4800008"},
                { "MVCOM_DIG" , "4"},
                { "MVCOM_DATA_MOV" , "2024-12-06"},
                { "MVCOM_SITUACAO" , "1"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_CODPDT" , "306614"},
                { "MVCOM_AGENCIA" , "11"},
                { "MVCOM_OPERACAO" , "0"},
                { "MVCOM_CONTA" , "4800008"},
                { "MVCOM_DIG" , "4"},
                { "MVCOM_DATA_MOV" , "2024-12-06"},
                { "MVCOM_SITUACAO" , "1"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_CODPDT" , "306614"},
                { "MVCOM_AGENCIA" , "11"},
                { "MVCOM_OPERACAO" , "0"},
                { "MVCOM_CONTA" , "4800008"},
                { "MVCOM_DIG" , "4"},
                { "MVCOM_DATA_MOV" , "2024-12-06"},
                { "MVCOM_SITUACAO" , "1"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_CODPDT" , "306614"},
                { "MVCOM_AGENCIA" , "11"},
                { "MVCOM_OPERACAO" , "0"},
                { "MVCOM_CONTA" , "4800008"},
                { "MVCOM_DIG" , "4"},
                { "MVCOM_DATA_MOV" , "2024-12-06"},
                { "MVCOM_SITUACAO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1", q2);

                #endregion
                #region M_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1

                var q42 = new DynamicData();
                q42.AddDynamic(new Dictionary<string, string>{
                { "FUNCEF_AGENCIA" , "0011"},
                { "FUNCEF_OPERACAO" , "0"},
                { "FUNCEF_CONTA" , "0000004800008"},
                { "FUNCEF_DIG" , "4"},
                });
                q42.AddDynamic(new Dictionary<string, string>{
                { "FUNCEF_AGENCIA" , "29"},
                { "FUNCEF_OPERACAO" , "11"},
                { "FUNCEF_CONTA" , "273213"},
                { "FUNCEF_DIG" , "0"},
                });
                q42.AddDynamic(new Dictionary<string, string>{
                { "FUNCEF_AGENCIA" , "29"},
                { "FUNCEF_OPERACAO" , "12"},
                { "FUNCEF_CONTA" , "273213"},
                { "FUNCEF_DIG" , "0"},
                });
                q42.AddDynamic(new Dictionary<string, string>{
                { "FUNCEF_AGENCIA" , "29"},
                { "FUNCEF_OPERACAO" , "13"},
                { "FUNCEF_CONTA" , "273213"},
                { "FUNCEF_DIG" , "0"},
                });
                q42.AddDynamic(new Dictionary<string, string>{
                { "FUNCEF_AGENCIA" , "29"},
                { "FUNCEF_OPERACAO" , "14"},
                { "FUNCEF_CONTA" , "273213"},
                { "FUNCEF_DIG" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1", q42);

                #endregion
                #region M_1532_GERA_RETCOMIS_DB_SELECT_1_Query1

                var q45 = new DynamicData();
                q45.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_DATA_MOV" , "2022-05-15"}
                });
                q45.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_DATA_MOV" , "2022-05-15"}
                });
                q45.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_DATA_MOV" , "2022-05-15"}
                });
                q45.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_DATA_MOV" , "2022-05-15"}
                });
                q45.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_DATA_MOV" , "2022-05-15"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1532_GERA_RETCOMIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1532_GERA_RETCOMIS_DB_SELECT_1_Query1", q45);

                #endregion

                #region M_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_NSAS" , "198"},
                { "MVCOM_DATA_MOV" , "2024-07-06"},
                { "RESA_NRCERTIF" , "10000021751"},
                { "RESA_DESCR" , "PARC 46 CONTRATACAO SEGURO NOVO"},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_NSAS" , "214"},
                { "MVCOM_DATA_MOV" , "2024-07-06"},
                { "RESA_NRCERTIF" , "10000021751"},
                { "RESA_DESCR" , "PARC 47 CONTRATACAO SEGURO NOVO"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1", q3);

                #endregion
                #endregion
                var program = new VA0812B();
                program.Execute(RETCRE_FILE_NAME_P, RETINV_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                Assert.True(program.SQL_NSAC == 568);

                //M_0025_ATUALIZA_FITASASSE_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["M_0025_ATUALIZA_FITASASSE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("MVCOM_NSAS", out var valor0) && valor0.Contains("1675"));

                //M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("FITCEF_TOTCRNEFET", out var valor1) && valor1.Contains("0000000018803.00"));

                //M_0075_SOLICITA_RELAT_DB_INSERT_1_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["M_0075_SOLICITA_RELAT_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("SQL_NSAC", out var valor2) && valor2.Contains("0568"));
                Assert.True(envList2.Count > 1);

                //M_1132_QUITA_COMISSAO_DB_UPDATE_1_Update1
                var envList3 = AppSettings.TestSet.DynamicData["M_1132_QUITA_COMISSAO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("MVCOM_NSAS", out var valor3) && valor3.Contains("1676"));

                //M_1332_ATUALIZA_CONTA_DB_UPDATE_1_Update1
                var envList4 = AppSettings.TestSet.DynamicData["M_1332_ATUALIZA_CONTA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("FUNCEF_CONTA", out var valor4) && valor4.Contains("0000000273213"));

                //M_1432_REJEITA_COMISSAO_DB_UPDATE_1_Update1
                var envList5 = AppSettings.TestSet.DynamicData["M_1432_REJEITA_COMISSAO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("MVCOM_NSAS", out var valor5) && valor5.Contains("1675"));

                //M_1532_GERA_RETCOMIS_DB_INSERT_1_Insert1
                var envList6 = AppSettings.TestSet.DynamicData["M_1532_GERA_RETCOMIS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList6[1].TryGetValue("MVCOM_NSL", out var valor6) && valor6.Contains("000000276"));
                Assert.True(envList6.Count > 1);

                //M_8800_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1
                var envList7 = AppSettings.TestSet.DynamicData["M_8800_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList7[1].TryGetValue("VGFOLLOW_NUM_CERTIFICADO", out var valor7) && valor7.Contains("000095727807117"));


            }
        }
        [Theory]
        [InlineData("VA0812B_Entrada_R6039.txt", "VA0812B_Saida_R6039.txt")]
        public static void VA0812B_Tests_Theory_R6039_SalesComisRejection2_ReturnCode_0(string RETCRE_FILE_NAME_P, string RETINV_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RETINV_FILE_NAME_P = $"{RETINV_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , "1023684651"},
                { "HCTA_NRPARCEL" , "1"},
                { "HCTA_VLPRMTOT" , "15"},
                { "HCTA_SITUACAO" , "2"},
                { "HCTA_CODRET" , ""},
                { "HCTA_OCORRHISTCTA" , "1"},
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , "1023684651"},
                { "HCTA_NRPARCEL" , "2"},
                { "HCTA_VLPRMTOT" , "15"},
                { "HCTA_SITUACAO" , "2"},
                { "HCTA_CODRET" , ""},
                { "HCTA_OCORRHISTCTA" , "1"},
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , "1023684651"},
                { "HCTA_NRPARCEL" , "3"},
                { "HCTA_VLPRMTOT" , "15"},
                { "HCTA_SITUACAO" , "2"},
                { "HCTA_CODRET" , ""},
                { "HCTA_OCORRHISTCTA" , "1"},
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , "1023684651"},
                { "HCTA_NRPARCEL" , "4"},
                { "HCTA_VLPRMTOT" , "15"},
                { "HCTA_SITUACAO" , "2"},
                { "HCTA_CODRET" , ""},
                { "HCTA_OCORRHISTCTA" , "1"},
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "HCTA_NRCERTIF" , "1023684651"},
                { "HCTA_NRPARCEL" , "5"},
                { "HCTA_VLPRMTOT" , "15"},
                { "HCTA_SITUACAO" , "2"},
                { "HCTA_CODRET" , ""},
                { "HCTA_OCORRHISTCTA" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1", q15);

                #endregion
                #region M_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_CODPDT" , "306614"},
                { "MVCOM_AGENCIA" , "11"},
                { "MVCOM_OPERACAO" , "0"},
                { "MVCOM_CONTA" , "4800008"},
                { "MVCOM_DIG" , "4"},
                { "MVCOM_DATA_MOV" , "2024-12-06"},
                { "MVCOM_SITUACAO" , "1"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_CODPDT" , "306614"},
                { "MVCOM_AGENCIA" , "11"},
                { "MVCOM_OPERACAO" , "0"},
                { "MVCOM_CONTA" , "4800008"},
                { "MVCOM_DIG" , "4"},
                { "MVCOM_DATA_MOV" , "2024-12-06"},
                { "MVCOM_SITUACAO" , "1"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_CODPDT" , "306614"},
                { "MVCOM_AGENCIA" , "11"},
                { "MVCOM_OPERACAO" , "0"},
                { "MVCOM_CONTA" , "4800008"},
                { "MVCOM_DIG" , "4"},
                { "MVCOM_DATA_MOV" , "2024-12-06"},
                { "MVCOM_SITUACAO" , "1"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_CODPDT" , "306614"},
                { "MVCOM_AGENCIA" , "11"},
                { "MVCOM_OPERACAO" , "0"},
                { "MVCOM_CONTA" , "4800008"},
                { "MVCOM_DIG" , "4"},
                { "MVCOM_DATA_MOV" , "2024-12-06"},
                { "MVCOM_SITUACAO" , "1"},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_CODPDT" , "306614"},
                { "MVCOM_AGENCIA" , "11"},
                { "MVCOM_OPERACAO" , "0"},
                { "MVCOM_CONTA" , "4800008"},
                { "MVCOM_DIG" , "4"},
                { "MVCOM_DATA_MOV" , "2024-12-06"},
                { "MVCOM_SITUACAO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1", q2);

                #endregion
                #region M_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1

                var q42 = new DynamicData();
                q42.AddDynamic(new Dictionary<string, string>{
                { "FUNCEF_AGENCIA" , "0011"},
                { "FUNCEF_OPERACAO" , "0"},
                { "FUNCEF_CONTA" , "0000004800008"},
                { "FUNCEF_DIG" , "4"},
                });
                q42.AddDynamic(new Dictionary<string, string>{
                { "FUNCEF_AGENCIA" , "29"},
                { "FUNCEF_OPERACAO" , "11"},
                { "FUNCEF_CONTA" , "273213"},
                { "FUNCEF_DIG" , "0"},
                });
                q42.AddDynamic(new Dictionary<string, string>{
                { "FUNCEF_AGENCIA" , "29"},
                { "FUNCEF_OPERACAO" , "12"},
                { "FUNCEF_CONTA" , "273213"},
                { "FUNCEF_DIG" , "0"},
                });
                q42.AddDynamic(new Dictionary<string, string>{
                { "FUNCEF_AGENCIA" , "29"},
                { "FUNCEF_OPERACAO" , "13"},
                { "FUNCEF_CONTA" , "273213"},
                { "FUNCEF_DIG" , "0"},
                });
                q42.AddDynamic(new Dictionary<string, string>{
                { "FUNCEF_AGENCIA" , "29"},
                { "FUNCEF_OPERACAO" , "14"},
                { "FUNCEF_CONTA" , "273213"},
                { "FUNCEF_DIG" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1", q42);

                #endregion
                #region M_1532_GERA_RETCOMIS_DB_SELECT_1_Query1

                var q45 = new DynamicData();
                q45.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_DATA_MOV" , "2022-05-15"}
                });
                q45.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_DATA_MOV" , "2022-05-15"}
                });
                q45.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_DATA_MOV" , "2022-05-15"}
                });
                q45.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_DATA_MOV" , "2022-05-15"}
                });
                q45.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_DATA_MOV" , "2022-05-15"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1532_GERA_RETCOMIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1532_GERA_RETCOMIS_DB_SELECT_1_Query1", q45);

                #endregion
                #region M_0041_LOCALIZA_6039_DB_SELECT_1_Query1

                var q30 = new DynamicData();
                q30.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_NSAS" , "0"},
                { "MVCOM_DATA_MOV" , "2024-01-01"},
                });
                q30.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_NSAS" , "0"},
                { "MVCOM_DATA_MOV" , "2024-01-01"},
                });
                q30.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_NSAS" , "0"},
                { "MVCOM_DATA_MOV" , "2024-01-01"},
                });
                q30.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_NSAS" , "0"},
                { "MVCOM_DATA_MOV" , "2024-01-01"},
                });
                q30.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_NSAS" , "0"},
                { "MVCOM_DATA_MOV" , "2024-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0041_LOCALIZA_6039_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0041_LOCALIZA_6039_DB_SELECT_1_Query1", q30);

                #endregion
                #region M_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_NSAS" , "198"},
                { "MVCOM_DATA_MOV" , "2024-07-06"},
                { "RESA_NRCERTIF" , "10000021751"},
                { "RESA_DESCR" , "PARC 46 CONTRATACAO SEGURO NOVO"},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "MVCOM_NSAS" , "214"},
                { "MVCOM_DATA_MOV" , "2024-07-06"},
                { "RESA_NRCERTIF" , "10000021751"},
                { "RESA_DESCR" , "PARC 47 CONTRATACAO SEGURO NOVO"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0033_LOCALIZA_RESSARC_DB_SELECT_1_Query1", q3);

                #endregion
                #region M_1241_REJEITA_COMISSAO_DB_SELECT_1_Query1

                var q48 = new DynamicData();
                q48.AddDynamic(new Dictionary<string, string>{
                { "PROPAZ_AGELOTE" , "0"},
                { "PROPAZ_DTLOTE" , "0"},
                { "PROPAZ_DTQITBCO" , "2020-01-09"},
                { "PROPAZ_NRLOTE" , "0"},
                { "PROPAZ_NRSEQLOTE" , "0"},
                { "PROPAZ_CODPRODAZ" , "PRM"},
                });
                q48.AddDynamic(new Dictionary<string, string>{
                { "PROPAZ_AGELOTE" , "0"},
                { "PROPAZ_DTLOTE" , "0"},
                { "PROPAZ_DTQITBCO" , "2020-01-09"},
                { "PROPAZ_NRLOTE" , "0"},
                { "PROPAZ_NRSEQLOTE" , "0"},
                { "PROPAZ_CODPRODAZ" , "PRM"},
                });
                q48.AddDynamic(new Dictionary<string, string>{
                { "PROPAZ_AGELOTE" , "0"},
                { "PROPAZ_DTLOTE" , "0"},
                { "PROPAZ_DTQITBCO" , "2020-01-09"},
                { "PROPAZ_NRLOTE" , "0"},
                { "PROPAZ_NRSEQLOTE" , "0"},
                { "PROPAZ_CODPRODAZ" , "PRM"},
                });
                q48.AddDynamic(new Dictionary<string, string>{
                { "PROPAZ_AGELOTE" , "0"},
                { "PROPAZ_DTLOTE" , "0"},
                { "PROPAZ_DTQITBCO" , "2020-01-09"},
                { "PROPAZ_NRLOTE" , "0"},
                { "PROPAZ_NRSEQLOTE" , "0"},
                { "PROPAZ_CODPRODAZ" , "PRM"},
                });
                q48.AddDynamic(new Dictionary<string, string>{
                { "PROPAZ_AGELOTE" , "0"},
                { "PROPAZ_DTLOTE" , "0"},
                { "PROPAZ_DTQITBCO" , "2020-01-09"},
                { "PROPAZ_NRLOTE" , "0"},
                { "PROPAZ_NRSEQLOTE" , "0"},
                { "PROPAZ_CODPRODAZ" , "PRM"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1241_REJEITA_COMISSAO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1241_REJEITA_COMISSAO_DB_SELECT_1_Query1", q48);

                #endregion

                #region M_1241_REJEITA_COMISSAO_DB_SELECT_2_Query1

                var q51 = new DynamicData();
                q51.AddDynamic(new Dictionary<string, string>{
                { "COMPROPH_VLCOMISVG" , "3872179.86"},
                { "COMPROPH_VLCOMISAP" , "519709.28"},
                { "COMPROPH_VALBASVG" , "1717.64"},
                { "COMPROPH_VALBASAP" , "176.47"},
                });
                q51.AddDynamic(new Dictionary<string, string>{
                { "COMPROPH_VLCOMISVG" , "3872179.86"},
                { "COMPROPH_VLCOMISAP" , "519709.28"},
                { "COMPROPH_VALBASVG" , "1717.64"},
                { "COMPROPH_VALBASAP" , "176.47"},
                });
                q51.AddDynamic(new Dictionary<string, string>{
                { "COMPROPH_VLCOMISVG" , "3872179.86"},
                { "COMPROPH_VLCOMISAP" , "519709.28"},
                { "COMPROPH_VALBASVG" , "1717.64"},
                { "COMPROPH_VALBASAP" , "176.47"},
                });
                q51.AddDynamic(new Dictionary<string, string>{
                { "COMPROPH_VLCOMISVG" , "3872179.86"},
                { "COMPROPH_VLCOMISAP" , "519709.28"},
                { "COMPROPH_VALBASVG" , "1717.64"},
                { "COMPROPH_VALBASAP" , "176.47"},
                });
                q51.AddDynamic(new Dictionary<string, string>{
                { "COMPROPH_VLCOMISVG" , "3872179.86"},
                { "COMPROPH_VLCOMISAP" , "519709.28"},
                { "COMPROPH_VALBASVG" , "1717.64"},
                { "COMPROPH_VALBASAP" , "176.47"},
                });

                AppSettings.TestSet.DynamicData.Remove("M_1241_REJEITA_COMISSAO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1241_REJEITA_COMISSAO_DB_SELECT_2_Query1", q51);

                #endregion

                #region PARAMETERS_VA0100S
                #region Execute_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_1_Query1");

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "NUM_APOLICE" , "998877665544"},
                { "COD_SUBGRUPO" , ""},
            }); q0.AddDynamic(new Dictionary<string, string>{
                { "NUM_APOLICE" , "998877665544"},
                { "COD_SUBGRUPO" , ""},
            }); q0.AddDynamic(new Dictionary<string, string>{
                { "NUM_APOLICE" , "998877665544"},
                { "COD_SUBGRUPO" , ""},
            }); q0.AddDynamic(new Dictionary<string, string>{
                { "NUM_APOLICE" , "998877665544"},
                { "COD_SUBGRUPO" , ""},
            }); q0.AddDynamic(new Dictionary<string, string>{
                { "NUM_APOLICE" , "998877665544"},
                { "COD_SUBGRUPO" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

                #endregion

                #region Execute_DB_SELECT_2_Query1
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_2_Query1");

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "RAMO" , ""}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "RAMO" , ""}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "RAMO" , ""}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "RAMO" , ""}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "RAMO" , ""}
            }); q1.AddDynamic(new Dictionary<string, string>{
                { "RAMO" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_2_Query1", q1);

                #endregion

                #region M_0100_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1
                AppSettings.TestSet.DynamicData.Remove("M_0100_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1");

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "DTMOVTO" , ""},
                { "CODPRODAZ" , ""},
                { "CODOPER" , ""},
                { "VLOPER" , ""},
                { "NUMFAT" , ""},
                { "VLIOCC" , ""},
            }); q22.AddDynamic(new Dictionary<string, string>{
                { "DTMOVTO" , ""},
                { "CODPRODAZ" , ""},
                { "CODOPER" , ""},
                { "VLOPER" , ""},
                { "NUMFAT" , ""},
                { "VLIOCC" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("M_0100_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1", q2);

                #endregion

                #region Execute_DB_SELECT_3_Query1
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_3_Query1");

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "PCIOF" , ""}
            }); q33.AddDynamic(new Dictionary<string, string>{
                { "PCIOF" , ""}
            }); q33.AddDynamic(new Dictionary<string, string>{
                { "PCIOF" , ""}
            }); q33.AddDynamic(new Dictionary<string, string>{
                { "PCIOF" , ""}
            }); q33.AddDynamic(new Dictionary<string, string>{
                { "PCIOF" , ""}
            }); q33.AddDynamic(new Dictionary<string, string>{
                { "PCIOF" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_3_Query1", q33);

                #endregion

                #region Execute_DB_SELECT_4_Query1
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_4_Query1");

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "VLOPER_W" , "2050"},
                { "VLIOCC_W" , ""},
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_4_Query1", q4);

                #endregion

                #region M_0200_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1
                AppSettings.TestSet.DynamicData.Remove("M_0200_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1");

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "VLOPER_W" , ""},
                { "VLIOCC_W" , ""},
                { "CODPRODAZ" , ""},
                { "DTMOVTO" , ""},
                { "CODOPER" , ""},
            }); q5.AddDynamic(new Dictionary<string, string>{
                { "VLOPER_W" , ""},
                { "VLIOCC_W" , ""},
                { "CODPRODAZ" , ""},
                { "DTMOVTO" , ""},
                { "CODOPER" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("M_0200_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1", q5);

                #endregion

                #region M_0300_CONTABIL_NOVA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("M_0300_CONTABIL_NOVA_DB_SELECT_1_Query1");

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "VLOPER_FIL" , ""},
                { "VLIOCC_FIL" , ""},
            }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Add("M_0300_CONTABIL_NOVA_DB_SELECT_1_Query1", q6);

                #endregion

                #region M_0400_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1
                AppSettings.TestSet.DynamicData.Remove("M_0400_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1");

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "NUM_APOLICE" , ""},
                { "FONTE" , ""},
                { "COD_SUBGRUPO" , ""},
                { "CODOPER" , ""},
                { "VLOPER" , ""},
                { "DTMOVTO" , ""},
                { "NUMFAT" , ""},
                { "VLIOCC" , ""},
            }); q7.AddDynamic(new Dictionary<string, string>{
                { "NUM_APOLICE" , ""},
                { "FONTE" , ""},
                { "COD_SUBGRUPO" , ""},
                { "CODOPER" , ""},
                { "VLOPER" , ""},
                { "DTMOVTO" , ""},
                { "NUMFAT" , ""},
                { "VLIOCC" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("M_0400_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1", q7);

                #endregion

                #region M_0500_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1
                AppSettings.TestSet.DynamicData.Remove("M_0500_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1");

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "VLOPER_FIL" , ""},
                { "VLIOCC_FIL" , ""},
                { "COD_SUBGRUPO" , ""},
                { "NUM_APOLICE" , ""},
                { "DTMOVTO" , ""},
                { "CODOPER" , ""},
                { "FONTE" , ""},
            }); q8.AddDynamic(new Dictionary<string, string>{
                { "VLOPER_FIL" , ""},
                { "VLIOCC_FIL" , ""},
                { "COD_SUBGRUPO" , ""},
                { "NUM_APOLICE" , ""},
                { "DTMOVTO" , ""},
                { "CODOPER" , ""},
                { "FONTE" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("M_0500_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1", q8);

                #endregion

                #endregion
                #endregion
                var program = new VA0812B();
                program.Execute(RETCRE_FILE_NAME_P, RETINV_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                Assert.True(program.SQL_NSAC == 3568);

                //M_0025_ATUALIZA_FITASASSE_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["M_0025_ATUALIZA_FITASASSE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("WHOST_CODCONV", out var valor0) && valor0.Contains("000006039"));

                //M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("FITCEF_TOTCRNEFET", out var valor1) && valor1.Contains("0000000018803.00"));

                //M_0075_SOLICITA_RELAT_DB_INSERT_1_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["M_0075_SOLICITA_RELAT_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("SQL_NSAC", out var valor2) && valor2.Contains("3568"));
                Assert.True(envList2.Count > 1);

                //M_1141_QUITA_COMISSAO_DB_UPDATE_1_Update1
                var envList3 = AppSettings.TestSet.DynamicData["M_1141_QUITA_COMISSAO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("MVCOM_NSL", out var valor3) && valor3.Contains("760000082"));

                //M_1241_REJEITA_COMISSAO_DB_UPDATE_1_Update1
                var envList4 = AppSettings.TestSet.DynamicData["M_1241_REJEITA_COMISSAO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("MVCOM_NSL", out var valor4) && valor4.Contains("750000276"));

                //M_1241_REJEITA_COMISSAO_DB_INSERT_1_Insert1
                var envList5 = AppSettings.TestSet.DynamicData["M_1241_REJEITA_COMISSAO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("MVCOM_COD_RETORNO", out var valor5) && valor5.Contains("0004"));
                Assert.True(envList5.Count > 1);

                //M_1241_REJEITA_COMISSAO_DB_UPDATE_2_Update1
                var envList6 = AppSettings.TestSet.DynamicData["M_1241_REJEITA_COMISSAO_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList6[1].TryGetValue("PROPAZ_NRPROPAZ", out var valor6) && valor6.Contains("0752000002760"));

                //M_1241_REJEITA_COMISSAO_DB_INSERT_2_Insert1
                var envList7 = AppSettings.TestSet.DynamicData["M_1241_REJEITA_COMISSAO_DB_INSERT_2_Insert1"].DynamicList;
                Assert.True(envList7[1].TryGetValue("PROPAZ_NRPROPAZ", out var valor7) && valor7.Contains("0752000002760"));
                Assert.True(envList7.Count > 1);

                //M_8800_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1
                var envList8 = AppSettings.TestSet.DynamicData["M_8800_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList8[1].TryGetValue("VGFOLLOW_NUM_CERTIFICADO", out var valor8) && valor8.Contains("000095727807117"));

            }
        }
    }
}