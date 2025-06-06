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
using static Code.SI5000B;
using Dclgens;
namespace FileTests.Test_DB
{
    [Collection("SI5000B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class SI5000B_Tests_DB
    {
        [Fact]
        public static void SI5000B_Database()
        {
            var program = new SI5000B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R010_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R010_SISTEMAS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R020_DECLARE_CALENDARIO_DB_DECLARE_1(); program.R020_DECLARE_CALENDARIO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R100_DECLARE_HISTSINI_DB_DECLARE_1(); program.R100_DECLARE_HISTSINI_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R105_00_VER_COBRANCA_SUSP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R110_VE_SE_ESTORNO_ADIANT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R200_PROCESSA_SINISTRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*8*/
                //foreign key
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Value = "2000-10-10";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO.Value = "2000-10-10";
                program.R200_PROCESSA_SINISTRO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R210_UPDATE_SINISTROS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*10*/
                //constraints
                program.SI112.DCLSI_RESSARC_ACORDO.SI112_DTH_ACORDO.Value = "2000-10-10";
                program.SI112.DCLSI_RESSARC_ACORDO.SI112_DTH_INDENIZACAO.Value = "2000-10-10";
                program.R220_GRAVA_RESSARC_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R221_MAX_NUM_RESSARC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*12*/
                //constraints
                program.SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_PAGAMENTO.Value = "2000-10-10";
                program.SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_VENCIMENTO.Value = "2000-10-10";
                program.R230_GRAVA_RESSARC_PCLA_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
        }
    }
}