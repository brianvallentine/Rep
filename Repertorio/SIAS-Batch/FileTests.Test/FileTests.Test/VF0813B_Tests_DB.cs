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
using static Code.VF0813B;

namespace FileTests.Test_DB
{
    [Collection("VF0813B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VF0813B_Tests_DB
    {
        [Fact]
        public static void VF0813B_Database()
        {
            var program = new VF0813B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.V0HCOB_DTVENCTO.Value = "2000-10-10";
            program.V0FTCF_DTRET.Value = "2000-10-10";
            program.V0AVIS_DTAVISO.Value = "2000-10-10";
            program.V0AVIS_DTMOVTO.Value = "2000-10-10";
            program.V0SALD_DTMOVTO.Value = "2000-10-10";
            program.V0SALD_DTAVISO.Value = "2000-10-10";
            program.V0SIST_DTMOVABE.Value = "2000-10-10";
            program.V0PARC_DTVENCTO.Value = "2000-10-10";
            program.V0RCDG_DTREFER.Value = "2000-10-10";
            program.V0RSAF_DTREFER.Value = "2000-10-10";
            program.V0HCOB_DTALTOPC.Value = "2000-10-10";
            program.V0DPCF_DTMOVTO.Value = "2000-10-10";
            program.V0DPCF_DTAVISO.Value = "2000-10-10";



            try { /*1*/ program.M_0000_PRINCIPAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_0020_PROCESSA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_0020_PROCESSA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_0020_PROCESSA_DB_DECLARE_1(); program.M_0020_PROCESSA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_1035_QUITA_PARCELA_DB_DECLARE_1(); program.M_1035_QUITA_PARCELA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_0020_PROCESSA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_0020_PROCESSA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.M_0020_PROCESSA_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.M_0020_PROCESSA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.M_0021_LOCALIZA_TIT_DEB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.M_0020_PROCESSA_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.M_0021_LOCALIZA_TIT_DEB_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.M_0021_LOCALIZA_TIT_DEB_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.M_0022_LOCALIZA_TIT_CRN_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.M_0021_LOCALIZA_TIT_DEB_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.M_0022_LOCALIZA_TIT_CRN_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.M_0022_LOCALIZA_TIT_CRN_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.M_0025_ACESSO_NSA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.M_0050_GERA_FITACEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.M_0053_UPDATE_FITACEF_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.M_0055_INSERT_FITACEF_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.M_0100_INSERT_AVISOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.M_0100_INSERT_AVISOS_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.M_1033_APROPRIA_DIFERENCA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.M_1035_QUITA_PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.M_1035_QUITA_PARCELA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.M_1036_BAIXA_HISTCTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.M_1035_QUITA_PARCELA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.M_1035_QUITA_PARCELA_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.M_1035_QUITA_PARCELA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.M_1035_QUITA_PARCELA_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.M_1101_ACHA_PARCELA_DB_DECLARE_1(); program.M_1101_ACHA_PARCELA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.M_1040_GERA_EVENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.M_1035_QUITA_PARCELA_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.M_1040_LOOP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.M_1040_LOOP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.M_1035_QUITA_PARCELA_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.M_1035_QUITA_PARCELA_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.M_1050_GERA_DIFERENCA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.M_1050_GERA_DIFERENCA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.M_1099_INCLUI_CDG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.M_1100_REPASSA_CDG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.M_1100_REPASSA_CDG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.M_1199_INCLUI_SAF_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/ program.M_1199_INCLUI_SAF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/ program.M_1199_INCLUI_SAF_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*47*/ program.M_1200_REPASSA_SAF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*48*/ program.M_1200_REPASSA_SAF_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/ program.M_1037_REJEITA_PARCELA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*50*/ program.M_1037_REJEITA_PARCELA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*51*/ program.M_1038_MUDA_OPCAOPAG_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*52*/ program.M_1038_MUDA_OPCAOPAG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*53*/ program.M_1037_REJEITA_PARCELA_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*54*/ program.R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1(); program.R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*55*/ program.R8010_00_VER_PRODUTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*56*/ program.R8700_00_INSERT_DESPESAS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*57*/ program.R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}