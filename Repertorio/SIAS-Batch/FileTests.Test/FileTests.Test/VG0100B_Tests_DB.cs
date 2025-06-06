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
using static Code.VG0100B;

namespace FileTests.Test_DB
{
    [Collection("VG0100B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG0100B_Tests_DB
    {

        [Fact]
        public static void VG0100B_Database()
        {
            var program = new VG0100B();
            var data = "2025-01-01";

            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try
            {
                /*1*/
                program.R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*2*/
                program.R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*3*/
                program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*4*/
                program.R0900_00_DECLARE_V1SOLICFAT_DB_DECLARE_1();
                program.R0900_00_DECLARE_V1SOLICFAT_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*5*/
                program.R1300_00_SELECT_V1FATTOT_ANT_DB_DECLARE_1();
                program.R1300_00_SELECT_V1FATTOT_ANT_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*6*/
                program.R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*7*/
                program.R0910_00_FETCH_V1SOLICFAT_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*8*/
                program.R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*9*/
                program.R1200_00_SELECT_V1FATURA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*10*/
                program.R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*11*/
                program.R1500_00_DECLARE_V1SUBGR_DB_DECLARE_1();
                program.R1500_00_DECLARE_V1SUBGR_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*12*/
                program.R1400_00_SELECT_V0NUMEROAES_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*13*/
                program.R1410_00_UPDATE_V0NUMEROAES_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*14*/
                program.R1420_00_UPDATE_V0FONTE_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*15*/
                program.R1700_00_ACESSA_TOTAIS_DB_DECLARE_1();
                program.R1700_00_ACESSA_TOTAIS_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*16*/
                program.R1600_00_SELECT_V1APOLICE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*17*/
                program.V1FATC_DATA_REFER.Value = data;

                program.M_6100_DECLARE_MOVIM_DB_DECLARE_1();
                program.M_6100_DECLARE_MOVIM_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*18*/
                program.R1800_00_SELECT_V1ENDOSSO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*19*/
                program.R1850_00_SELECT_V1MOEDA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*20*/
                program.V1RIND_DTINIVIG.Value = data;

                program.R1900_00_SELECT_V1RAMOIND_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*21*/
                program.R1940_00_ACESSA_RCAPCOMP_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*22*/
                program.R1950_00_SELECT_V1FONTE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*23*/
                program.R2305_00_AJUSTA_VIGENCIA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*24*/
                program.R2315_00_SELECT_V1FATURCONT_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*25*/
                program.R2330_00_SELECT_V1FATURCONT_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*26*/
                program.V0COBE_DATA_INIVIG.Value = data;
                program.V0COBE_DATA_TERVIG.Value = data;

                program.R2450_00_INSERE_COBERAPOL_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*27*/
                program.V0RELT_DATA_SOLI.Value = data;
                program.V0RELT_CODREL.Value = data;
                program.V1SIST_DTMOVABE.Value = data;
                program.V0RELT_DATA_REFER.Value = data;

                program.R3080_00_INSERT_V0RELATORIOS_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*28*/
                program.V0FATR_DATA_INIVIG.Value = data;
                program.V0FATR_DATA_TERVIG.Value = data;
                program.V0FATR_SIT_REG.Value = data;
                program.V0FATR_DATA_FATUR.Value = data;
                program.V0FATR_DATA_FATU_I.Value = 15;
                program.V0FATR_DATA_RCAP.Value = data;
                program.V0FATR_DATA_RCAP_I.Value = 15;
                program.V0FATR_DATA_VENC.Value = data;
                program.V0FATR_DATA_VENC_I.Value = 15;

                program.R3100_00_INSERT_V0FATURAS_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*29*/
                program.R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*30*/
                program.V0ENDO_DATPRO.Value = data;
                program.V0ENDO_DT_LIBER.Value = data;
                program.V0ENDO_DTEMIS.Value = data;
                program.V0ENDO_DTINIVIG.Value = data;
                program.V0ENDO_DTTERVIG.Value = data;
                program.V0ENDO_DATARCAP.Value = data;
                program.V0ENDO_DATARCAP_I.Value = 25;
                program.V0ENDO_DTVENCTO.Value = data;
                program.V0ENDO_DTVENCTO_I.Value = 25;

                program.R3300_00_V0ENDOSSO_PROPAUTOM_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*31*/
                program.R3500_00_SELECT_V1FATURA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*32*/
                program.R4100_00_DELETE_V0FATURASTOT_DB_DELETE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*33*/
                program.R5100_00_DELETE_V0FATURAS_DB_DELETE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*34*/
                program.R5200_00_UPDATE_V0FATURCONT_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*35*/
                program.R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*36*/
                program.R5400_00_SELECT_V1FATURCONT_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*37*/
                program.R5400_00_SELECT_V1FATURCONT_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*38*/
                program.R5500_00_INSERT_V0SOLICITAFAT_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*39*/
                program.R5600_00_SELECT_V0ENDOSSO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*40*/
                program.M_6110_DECLARE_MOVIM_DB_DECLARE_1();
                program.M_6110_DECLARE_MOVIM_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*41*/
                program.V0MOVI_DATA_FATURA.Value = data;
                program.V1FATC_DATA_REFER.Value = data;

                program.M_6510_ATUALIZA_MOV_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*42*/
                program.M_6520_ATUALIZA_MOV_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}