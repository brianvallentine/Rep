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
using static Code.VA0010B;
using Newtonsoft.Json;
using System.Globalization;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace FileTests.Test
{
    [Collection("VA0010B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0010B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0889_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTMOVABE_05" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0889_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0889_SELECT_V1SISTEMA_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "HOST_IMPSEGCDG" , ""},
                { "HOST_VLCUSTCDG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0889_SELECT_V1SISTEMA_DB_SELECT_2_Query1", q1);

            #endregion

            #region VA0010B_CSEGURAVG

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1SEGV_NUM_APOLICE" , ""},
                { "V1SEGV_COD_SUBGRUPO" , ""},
                { "V1SEGV_NRCERTIF" , ""},
                { "V1SEGV_DVCERTIF" , ""},
                { "V1SEGV_ITEM" , ""},
                { "V1SEGV_CODCLI" , ""},
                { "V1SEGV_FONTE" , ""},
                { "V1SEGV_OCORHIST" , ""},
                { "V1SEGV_EST_CIVIL" , ""},
                { "V1SEGV_IDE_SEXO" , ""},
                { "V1SEGV_OCORR_END" , ""},
                { "V1SEGV_MATRICULA" , ""},
                { "V1SEGV_DTINIVIG" , ""},
                { "V1SEGV_DTADMISS" , ""},
                { "V1SEGV_DTNASCIM" , ""},
                { "V1SEGV_SITUACAO" , ""},
                { "V1SEGV_NRPROPOS" , ""},
                { "V1SEGV_NUM_CARNE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0010B_CSEGURAVG", q2);

            #endregion

            #region M_1000_PROCESSA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_CODPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_1000_COBERTURAS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1HSEG_DTMOVTO" , ""},
                { "V1HSEG_CODOPER" , ""},
                { "V1HSEG_CODMOEDA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_COBERTURAS_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_1000_PROCESSA_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0PROPAZ_AGENCIA" , ""},
                { "V0PROPAZ_DIA_DEBITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DB_SELECT_2_Query1", q5);

            #endregion

            #region M_1000_COBERTURAS_DB_SELECT_2_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VALCPR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_COBERTURAS_DB_SELECT_2_Query1", q6);

            #endregion

            #region M_1000_IDADE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_CODPRODU" , ""},
                { "HOST_PERIPGTO" , ""},
                { "V0PROD_TEM_CDG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_IDADE_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_1000_COBERTURAS_DB_SELECT_3_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "CIMP_SEGURADA_VG" , ""},
                { "CPRM_TARIFARIO_VG" , ""},
                { "CFATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_COBERTURAS_DB_SELECT_3_Query1", q8);

            #endregion

            #region M_1000_IDADE_DB_SELECT_2_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "HOST_DIA_DEBITO" , ""},
                { "HOST_DTVENCTO" , ""},
                { "HOST_DTPROXVEN" , ""},
                { "HOST_VALOPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_IDADE_DB_SELECT_2_Query1", q9);

            #endregion

            #region M_1000_PROCESSA_DB_SELECT_3_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1CLIE_DTNASCIM" , ""},
                { "V1CLIE_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DB_SELECT_3_Query1", q10);

            #endregion

            #region M_1000_COBERTURAS_DB_SELECT_4_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "CIMP_SEGURADA_AP" , ""},
                { "CPRM_TARIFARIO_AP" , ""},
                { "CFATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_COBERTURAS_DB_SELECT_4_Query1", q11);

            #endregion

            #region M_1000_JA_INTEGRADO_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_JA_INTEGRADO_DB_UPDATE_1_Update1", q12);

            #endregion

            #region M_1000_COBERTURAS_DB_SELECT_5_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "CIMP_SEGURADA_IP" , ""},
                { "CFATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_COBERTURAS_DB_SELECT_5_Query1", q13);

            #endregion

            #region M_1000_PROCESSA_DB_SELECT_4_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0CCOR_OPCAOCAP" , ""},
                { "V0CCOR_COD_AGENCIA" , ""},
                { "V0CCOR_NUM_CTA_CORRENTE" , ""},
                { "V0CCOR_DAC_CTA_CORRENTE" , ""},
                { "V0CCOR_DIA_DEBITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DB_SELECT_4_Query1", q14);

            #endregion

            #region M_1000_COBERTURAS_DB_SELECT_6_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "CIMP_SEGURADA_AMDS" , ""},
                { "CFATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_COBERTURAS_DB_SELECT_6_Query1", q15);

            #endregion

            #region M_1000_COBERTURAS_DB_SELECT_7_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "CIMP_SEGURADA_DH" , ""},
                { "CFATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_COBERTURAS_DB_SELECT_7_Query1", q16);

            #endregion

            #region M_1000_COBERTURAS_DB_SELECT_8_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "CIMP_SEGURADA_DIT" , ""},
                { "CFATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_COBERTURAS_DB_SELECT_8_Query1", q17);

            #endregion

            #region M_2000_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V1SEGV_NRCERTIF" , ""},
                { "V0PROD_CODPRODU" , ""},
                { "V1SEGV_CODCLI" , ""},
                { "V1SEGV_OCORR_END" , ""},
                { "V1SEGV_FONTE" , ""},
                { "V0PROP_AGECOBR" , ""},
                { "V1SEGV_DTINIVIG" , ""},
                { "V1HSEG_CODOPER" , ""},
                { "V1HSEG_DTMOVTO" , ""},
                { "V1SEGV_NUM_APOLICE" , ""},
                { "V1SEGV_COD_SUBGRUPO" , ""},
                { "V1SEGV_OCORHIST" , ""},
                { "HOST_DTPROXVEN" , ""},
                { "V1SEGV_NUM_CARNE" , ""},
                { "HOST_DTVENCTO" , ""},
                { "HOST_IDADE" , ""},
                { "V1SEGV_IDE_SEXO" , ""},
                { "V1SEGV_EST_CIVIL" , ""},
                { "V1SEGV_NRPROPOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2000_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1", q18);

            #endregion

            #region M_1000_COBERTURAS_DB_SELECT_9_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "PLACAP_QTTITCAP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_COBERTURAS_DB_SELECT_9_Query1", q19);

            #endregion

            #region M_1000_COBERTURAS_DB_SELECT_10_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "CUSTCAP_VLCUSTCAP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_COBERTURAS_DB_SELECT_10_Query1", q20);

            #endregion

            #region M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V1SEGV_NRCERTIF" , ""},
                { "V1SEGV_OCORHIST" , ""},
                { "V1HSEG_DTMOVTO" , ""},
                { "HOST_IMPSEGUR" , ""},
                { "HOST_IMPSEGIND" , ""},
                { "V1HSEG_CODOPER" , ""},
                { "CIMP_SEGURADA_VG" , ""},
                { "CIMP_SEGURADA_AP" , ""},
                { "CIMP_SEGURADA_IP" , ""},
                { "VLPREMIO" , ""},
                { "PRMVG" , ""},
                { "PRMAP" , ""},
                { "HOST_QTTITCAP" , ""},
                { "HOST_VLTITCAP" , ""},
                { "HOST_VLCUSCAP" , ""},
                { "V0PLAN_IMPSEGCDG" , ""},
                { "V0PLAN_VLCUSTCDG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1", q21);

            #endregion

            #region M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V1SEGV_NRCERTIF" , ""},
                { "V1SEGV_DTINIVIG" , ""},
                { "HOST_OPCAOPAG" , ""},
                { "HOST_PERIPGTO" , ""},
                { "V0CCOR_DIA_DEBITO" , ""},
                { "V0CCOR_COD_AGENCIA" , ""},
                { "HOST_OPRCTADEB" , ""},
                { "HOST_NUMCTADEB" , ""},
                { "HOST_DIGCTADEB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1", q22);

            #endregion

            #region M_2500_INSERT_CDGCOBER_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0CDGC_CODCLIEN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_2500_INSERT_CDGCOBER_DB_SELECT_1_Query1", q23);

            #endregion

            #region M_2500_INSERT_CDGCOBER_DB_INSERT_1_Insert1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V1SEGV_CODCLI" , ""},
                { "V1SIST_DTMOVABE" , ""},
                { "HOST_IMPSEGCDG" , ""},
                { "HOST_VLCUSTCDG" , ""},
                { "V1SEGV_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_2500_INSERT_CDGCOBER_DB_INSERT_1_Insert1", q24);

            #endregion

            #region M_3000_00_SELECT_APOLICE_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "WS_APOL_COD_MODALIDADE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_3000_00_SELECT_APOLICE_DB_SELECT_1_Query1", q25);

            #endregion

            VG0710S_Tests.Load_Parameters();
            #endregion
        }

        [Fact]
        public static void VA0010B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.Clear();
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();
                #region PARAMETERS

                #region VA0010B_CSEGURAVG
                AppSettings.TestSet.DynamicData.Remove("VA0010B_CSEGURAVG");

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "NUM_APOLICE" , "55"},
                { "COD_SUBGRUPO" , "55"},
                { "NUM_CERTIFICADO" , "55"},
                { "DAC_CERTIFICADO" , "55"},
                { "NUM_ITEM" , "55"},
                { "COD_CLIENTE" , "55"},
                { "COD_FONTE" , "55"},
                { "OCORR_HISTORICO" , "55"},
                { "ESTADO_CIVIL" , "55"},
                { "IDE_SEXO" , "55"},
                { "OCORR_ENDERECO" , "55"},
                { "NUM_MATRICULA" , "55"},
                { "DATA_INIVIGENCIA" , "55"},
                { "DATA_ADMISSAO" , "55"},
                { "DATA_NASCIMENTO" , "2000-10-10"},
                { "SIT_REGISTRO" , "55"},
                { "NUM_PROPOSTA" , "55"},
                { "NUM_CARNE" , "55"},
            });
                AppSettings.TestSet.DynamicData.Add("VA0010B_CSEGURAVG", q2);

                #endregion
                #region M_1000_COBERTURAS_DB_SELECT_2_Query1
                AppSettings.TestSet.DynamicData.Remove("M_1000_COBERTURAS_DB_SELECT_2_Query1");

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VALCPR" , "2"}
            });
                AppSettings.TestSet.DynamicData.Add("M_1000_COBERTURAS_DB_SELECT_2_Query1", q6);

                #endregion

                #region M_1000_COBERTURAS_DB_SELECT_3_Query1
                AppSettings.TestSet.DynamicData.Remove("M_1000_COBERTURAS_DB_SELECT_3_Query1");

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "CIMP_SEGURADA_VG" , "2"},
                { "CPRM_TARIFARIO_VG" , "2"},
                { "CFATOR_MULTIPLICA" , "2"},
            });
                AppSettings.TestSet.DynamicData.Add("M_1000_COBERTURAS_DB_SELECT_3_Query1", q8);

                #endregion
                #region M_1000_PROCESSA_DB_SELECT_3_Query1
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_DB_SELECT_3_Query1");

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V1CLIE_DTNASCIM" , ""},
                { "V1CLIE_DTNASCIM_I" , ""},
                { "V1CLIE_CGCCPF" , ""},
            });
                q10.AddDynamic(new Dictionary<string, string>{
                { "V1CLIE_DTNASCIM" , ""},
                { "V1CLIE_DTNASCIM_I" , ""},
                { "V1CLIE_CGCCPF" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DB_SELECT_3_Query1", q10);

                #endregion

                #region M_1000_PROCESSA_DB_SELECT_4_Query1
                AppSettings.TestSet.DynamicData.Remove("M_1000_PROCESSA_DB_SELECT_4_Query1");

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V0CCOR_OPCAOCAP" , "1"},
                { "V0CCOR_OPCAOCAP_I" , ""},
                { "V0CCOR_COD_AGENCIA" , ""},
                { "V0CCOR_NUM_CTA_CORRENTE" , ""},
                { "V0CCOR_DAC_CTA_CORRENTE" , ""},
                { "V0CCOR_DIA_DEBITO" , ""},
                { "V0CCOR_DIA_DEBITO_I" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("M_1000_PROCESSA_DB_SELECT_4_Query1", q14);

                #endregion

                #region M_1000_COBERTURAS_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("M_1000_COBERTURAS_DB_SELECT_1_Query1");

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                 { "V1HSEG_DTMOVTO" , ""},
                { "V1HSEG_CODOPER" , ""},
                { "V1HSEG_CODMOEDA" , ""},
            });
                q4.AddDynamic(new Dictionary<string, string>{
                 { "V1HSEG_DTMOVTO" , ""},
                { "V1HSEG_CODOPER" , ""},
                { "V1HSEG_CODMOEDA" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("M_1000_COBERTURAS_DB_SELECT_1_Query1", q4);

                #endregion

                #region M_2000_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1
                AppSettings.TestSet.DynamicData.Remove("M_2000_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1");

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "V1SEGV_NRCERTIF" , "11"},
                { "V0PROD_CODPRODU" , "11"},
                { "V1SEGV_CODCLI" , "11"},
                { "V1SEGV_OCORR_END" , "11"},
                { "V1SEGV_FONTE" , "11"},
                { "V0PROP_AGECOBR" , "11"},
                { "V1SEGV_DTINIVIG" , "3"},
                { "V1HSEG_CODOPER" , "11"},
                { "V1HSEG_DTMOVTO" , "11"},
                { "V1SEGV_NUM_APOLICE" , "11"},
                { "V1SEGV_COD_SUBGRUPO" , "11"},
                { "V1SEGV_OCORHIST" , "11"},
                { "HOST_DTPROXVEN" , "11"},
                { "V1SEGV_NUM_CARNE" , "11"},
                { "HOST_DTVENCTO" , "11"},
                { "HOST_IDADE" , "11"},
                { "V1SEGV_IDE_SEXO" , "2"},
                { "V1SEGV_EST_CIVIL" , "11"},
                { "V1SEGV_NRPROPOS" , "11"},
            });
                AppSettings.TestSet.DynamicData.Add("M_2000_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1", q18);

                #endregion

                #region M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1
                AppSettings.TestSet.DynamicData.Remove("M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1");

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "V1SEGV_NRCERTIF" , "2"},
                { "V1SEGV_OCORHIST" , "2"},
                { "V1HSEG_DTMOVTO" , "2"},
                { "HOST_IMPSEGUR" , "2"},
                { "HOST_IMPSEGIND" , "2"},
                { "V1HSEG_CODOPER" , "2"},
                { "CIMP_SEGURADA_VG" , "2"},
                { "CIMP_SEGURADA_AP" , "2"},
                { "CIMP_SEGURADA_IP" , "2"},
                { "VLPREMIO" , "2"},
                { "PRMVG" , "2"},
                { "PRMAP" , "2"},
                { "HOST_QTTITCAP" , "2"},
                { "HOST_VLTITCAP" , "2"},
                { "HOST_VLCUSCAP" , "2"},
                { "V0PLAN_IMPSEGCDG" , "2"},
                { "V0PLAN_VLCUSTCDG" , "2"},
            });
                AppSettings.TestSet.DynamicData.Add("M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1", q21);

                #endregion

                #region M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1
                AppSettings.TestSet.DynamicData.Remove("M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1");

                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "V1SEGV_NRCERTIF" , "3"},
                { "V1SEGV_DTINIVIG" , "3"},
                { "HOST_OPCAOPAG" , "3"},
                { "HOST_PERIPGTO" , "3"},
                { "V0CCOR_DIA_DEBITO" , "3"},
                { "V0CCOR_COD_AGENCIA" , "3"},
                { "HOST_OPRCTADEB" , "3"},
                { "HOST_NUMCTADEB" , "3"},
                { "HOST_DIGCTADEB" , "3"},
            });
                AppSettings.TestSet.DynamicData.Add("M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1", q22);

                #endregion

                #region M_2500_INSERT_CDGCOBER_DB_INSERT_1_Insert1
                AppSettings.TestSet.DynamicData.Remove("M_2500_INSERT_CDGCOBER_DB_INSERT_1_Insert1");

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "V1SEGV_CODCLI" , "12"},
                { "V1SIST_DTMOVABE" , "12"},
                { "HOST_IMPSEGCDG" , "12"},
                { "HOST_VLCUSTCDG" , "12"},
                { "V1SEGV_NRCERTIF" , "12"},
            });
                AppSettings.TestSet.DynamicData.Add("M_2500_INSERT_CDGCOBER_DB_INSERT_1_Insert1", q24);

                #endregion
                #endregion

                var program = new VA0010B();

                LogHelper.Log($"#### Arquivo {JsonConvert.SerializeObject(AppSettings.Settings, Formatting.Indented)}");

                program.Execute();

                var envList2 = AppSettings.TestSet.DynamicData["M_2000_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1"].DynamicList;
                var envList3 = AppSettings.TestSet.DynamicData["M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1"].DynamicList;
                var envList4 = AppSettings.TestSet.DynamicData["M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1"].DynamicList;

                LogHelper.Log($"CULTURE: {CultureInfo.CurrentCulture}");
                LogHelper.Log($"ENVLIST: {JsonConvert.SerializeObject(envList3, Formatting.Indented)}");

                Assert.True(envList2[1].TryGetValue("V1SEGV_IDE_SEXO", out var valor) && valor == "5");
                Assert.True(envList2[1].TryGetValue("HOST_IDADE", out valor) && valor == "-001");
                Assert.True(envList3[1].TryGetValue("VLPREMIO", out valor) && valor == "0000000000009.71");
                Assert.True(envList4[1].TryGetValue("V1SEGV_DTINIVIG", out valor) && valor == "55        ");

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Fact]
        public static void VA0010B_Tests_99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.Clear();
                AppSettings.TestSet.IsTest = true;

                var program = new VA0010B();
                program.Execute();
                Assert.True(program.RETURN_CODE == 9);

            }
        }
    }
}