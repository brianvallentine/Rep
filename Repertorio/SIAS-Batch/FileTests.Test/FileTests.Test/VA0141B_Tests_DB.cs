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
using static Code.VA0141B;

namespace FileTests.Test_DB
{
    [Collection("VA0141B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0141B_Tests_DB
    {

        [Fact]
        public static void VA0141B_Database()
        {
            var program = new VA0141B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.Value = "2000-10-10";
            program.CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.Value = "2000-10-10";

            program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_VENCIMENTO.Value = "2000-10-10";
            program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_RCAP.Value = "2000-10-10";
            program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO.Value = "2000-10-10";
            program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_LIBERACAO.Value = "2000-10-10";
            program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA.Value = "2000-10-10";

            program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.Value = "2000-10-10";

            program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO.Value = "2000-10-10";
            program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO.Value = "2000-10-10";
            program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO.Value = "2000-10-10";

            program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA.Value = "2000-10-10";
            program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA.Value = "2000-10-10";

            program.HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DTFATUR.Value = "2000-10-10";

            program.RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.Value = "2000-10-10";
            program.RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.Value = "2000-10-10";

            program.RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.Value = "2000-10-10";
            program.RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL.Value = "2000-10-10";

            try { /*1*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0120_00_SELECT_CALENDAR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0180_00_SELECT_GE403_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0190_00_SELECT_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0210_00_UPDATE_HISCONPA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0220_00_UPDATE_COBHISVI_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0270_00_SELECT_CALENDAR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0300_00_UPDATE_ENDOSSOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0310_00_UPDATE_APOLICOB_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0360_00_SELECT_HISCONPA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0460_00_SELECT_HISCONPA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R0470_00_SELECT_CALENDAR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R0600_00_SELECT_NUMERAES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R0700_00_SELECT_FONTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R0710_00_SELECT_ENDOSSOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R1010_00_DECLARE_VG082_DB_DECLARE_1(); program.R1010_00_DECLARE_VG082_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R2710_00_DECLARE_APOLCOSS_DB_DECLARE_1(); program.R2710_00_DECLARE_APOLCOSS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R2350_00_UPDATE_NUMERAES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R2450_00_UPDATE_FONTES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R2510_00_SELECT_PARCEVID_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R2513_00_SELECT_ENDOSSOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R2514_00_SELECT_ENDOSSOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R2520_00_INSERT_ENDOSSOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R2530_00_INSERT_PARCELAS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R2550_00_INSERT_PARCEHIS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R2740_00_SELECT_NUMERCOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R2750_00_INSERT_ORDEMCOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R2760_00_UPDATE_NUMERCOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R2800_00_INSERT_EMISSDIA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R3100_00_INSERT_APOLICOB_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R4000_00_UPDATE_HISCONPA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R4100_00_UPDATE_V0RCAPS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R9000_00_INSERT_RELATORI_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}