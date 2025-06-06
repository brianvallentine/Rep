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

namespace FileTests.Test_DB
{
    [Collection("FN0301B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class FN0301B_Tests_DB
    {

        [Fact]
        public static void FN0301B_Database()
        {
            var program = new FN0301B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDateMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");

            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                program.V1SIST_DTMOVABE.Value = fullDateMock;

                program.R0300_00_DECLARE_V1HISTOPARC_DB_DECLARE_1();
                program.R0300_00_DECLARE_V1HISTOPARC_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R1400_00_GRAVA_FENCOMI_DB_DECLARE_1(); program.R1400_00_GRAVA_FENCOMI_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1200_00_GRAVA_FENEMIS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R1210_00_SELECT_V1CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1211_00_GRAVA_FENPANA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1215_00_SELECT_PROPCONV_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1220_10_LEITURA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1230_00_INDICADOR_AUTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1240_00_INDICADOR_BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1250_00_AGENCIA_RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1251_00_BUSCA_NCERTIFICADO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1252_00_SELECT_PROPOFID_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R1300_00_GRAVA_FENPARC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R1310_00_PRIMEIRA_PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R1311_00_DEMAIS_PARCELAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R1500_00_GRAVA_FENCOSS_DB_DECLARE_1(); program.R1500_00_GRAVA_FENCOSS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R1600_00_GRAVA_FENRESS_DB_DECLARE_1(); program.R1600_00_GRAVA_FENRESS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R2100_00_DECLARE_V1AUTOAPOL_DB_DECLARE_1(); program.R2100_00_DECLARE_V1AUTOAPOL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R2310_00_DECLARE_V1AUTOCOBER_DB_DECLARE_1(); program.R2310_00_DECLARE_V1AUTOCOBER_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R2230_00_SELECT_TOMADOR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R3000_00_PROCESSA_VIDA_DB_DECLARE_1(); program.R3000_00_PROCESSA_VIDA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R5000_00_PROCESSA_OUTROS_DB_DECLARE_1(); program.R5000_00_PROCESSA_OUTROS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R3250_00_BUSCA_PERIPGTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R6000_00_PROCESSA_OUTROS_DB_DECLARE_1(); program.R6000_00_PROCESSA_OUTROS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R6300_00_MR_APO_COBER_DB_DECLARE_1(); program.R6300_00_MR_APO_COBER_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*31*/
                program.V1ENDO_DTINIVIG.Value = fullDateMock;

                program.R0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R0911_00_VERIF_CORRET_PANAM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}