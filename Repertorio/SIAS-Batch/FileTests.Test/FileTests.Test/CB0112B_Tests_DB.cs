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
using static Code.CB0112B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("CB0112B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class CB0112B_Tests_DB
    {
        private static string pData = "2020-01-01";

        [Fact]
        public static void CB0112B_Database()
        {
            var program = new CB0112B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Value = pData;
                program.R0300_00_DECLARE_V0MOVDEBCE_DB_DECLARE_1(); 
                program.R0300_00_DECLARE_V0MOVDEBCE_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*3*/ program.R0420_00_SELECT_COBHISVI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0660_00_SELECT_PARAMCON_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = pData;
                program.R0700_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*6*/ program.R0750_00_UPDATE_V0HISTCONTAVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.PARAMCON.DCLPARAM_CONTACEF.PARAMCON_DATA_PROXIMO_DEB.Value = pData;
                program.PARAMCON.DCLPARAM_CONTACEF.PARAMCON_DATA_MOVIMENTO.Value = pData;
                program.R1100_00_UPDATE_PARAMCON_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}