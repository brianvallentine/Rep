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
using static Code.CB1260B;

namespace FileTests.Test_DB
{
    [Collection("CB1260B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class CB1260B_Tests_DB
    {

        [Fact]
        public static void CB1260B_Database()
        {
            var program = new CB1260B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try
            {
                /*1*/
                program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*2*/
                program.R0150_00_SELECT_SISTEMAS_CO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*3*/
                program.R0200_00_DECLARE_CALENDARIO_DB_DECLARE_1();
                program.R0200_00_DECLARE_CALENDARIO_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*4*/
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR.Value = 68;
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "1997-01-01";

                program.R0500_00_DECLARE_PARCELAS_DB_DECLARE_1();
                program.R0500_00_DECLARE_PARCELAS_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*5*/
                program.R0820_00_DECLARE_AU071_DB_DECLARE_1();
                program.R0820_00_DECLARE_AU071_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*6*/
                program.R1100_00_DECLARE_MOVDEBCE_DB_DECLARE_1();
                program.R1100_00_DECLARE_MOVDEBCE_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*7*/
                program.R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*8*/
                program.R0850_00_SELECT_APOL_VIG_PROP_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*9*/
                program.R0860_00_LE_TIPO_ADESAO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*10*/
                program.PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.Value = 6409000052;
                program.PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO.Value = 3;
                program.PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA.Value = 0;

                program.R0870_00_LE_SIT_COBR_CARTAO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*11*/
                program.R0900_00_SELECT_APOLICES_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*12*/
                program.R0950_00_SELECT_ENDOSSOS_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*13*/
                program.R0960_00_SELECT_ENDOSSOS_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*14*/
                program.WS_HOST_DTINIVIG_APOL.Value = "1997-01-01";
                program.WS_HOST_DTTERVIG_APOL.Value = "1997-12-01";

                program.R0970_00_SELECT_CALENDARIO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*15*/
                program.R0990_00_SELECT_PARCEDEV_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*16*/
                program.R1000_00_SELECT_FOLLOW_UP_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*17*/
                program.R1700_00_DECLARE_PARCEHIS_DB_DECLARE_1();
                program.R1700_00_DECLARE_PARCEHIS_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*18*/
                program.R1150_00_SELECT_APOLCOBR_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*19*/
                program.R1200_00_SELECT_SINISTRO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*20*/
                program.R1250_00_SELECT_SINICAUSA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*21*/
                program.R1300_00_SELECT_PARCELAS_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*22*/
                program.CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.Value = "1997-01-01";

                program.R1870_00_DECLARE_CALENDARIO_DB_DECLARE_1();
                program.R1870_00_DECLARE_CALENDARIO_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*23*/
                program.R1800_00_SELECT_PRAZOSEG_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*24*/
                program.R1800_00_SELECT_PRAZOSEG_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*25*/
                program.R1820_00_CALC_DATA_CANCEL_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*26*/
                program.R1830_00_CALC_DATA_NOVOCANCEL_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*27*/
                program.R3200_00_DECLARE_CALENDARIO_DB_DECLARE_1();
                program.R3200_00_DECLARE_CALENDARIO_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*28*/
                program.CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MOVIMENTO.Value = "1997-01-01";
                program.CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_VENCIMENTO.Value = "1998-01-01";
                program.CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_FIM_VIG_PROP.Value = "1998-01-01";
                program.CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_CANCELAMENTO.Value = "1998-01-01";
                program.CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MALA_VIG_PROP.Value = "1998-01-01";
                program.CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MALA_VIG_PROP.Value = "1998-01-01";
                program.CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MALA_CANCEL.Value = "1998-01-01";
                program.VIND_DATA_MALA_CANCEL.Value = 1998;

                program.R2000_00_INSERT_VIG_PROP_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*29*/
                program.R2100_00_UPDATE_VIG_PROP_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*30*/
                program.CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DATA_MOVIMENTO.Value = "1997-01-01";
                program.CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DATA_VENC_CONTR.Value = "1997-01-01";
                program.CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DATA_VENCIMENTO.Value = "1997-01-01";
                program.CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DTA_VENCIMENTO_AR.Value = "1997-01-01";
                program.CBMALPAR.DCLCB_MALA_PARCATRASO.CBMALPAR_DATA_ENVIO.Value = "1997-01-01";
                program.VIND_DTA_VENCTO_AR.Value = 1998;

                program.R3500_00_INSERT_CBMALPAR_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}