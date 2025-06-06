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
using static Code.AC0077B;

namespace FileTests.Test_DB
{
    [Collection("AC0077B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class AC0077B_Tests_DB
    {

        [Fact]
        public static void AC0077B_Database()
        {
            var program = new AC0077B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0200_00_CHECA_EXECUCAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0400_00_DECLARE_V1MESTSINI_DB_DECLARE_1(); program.R0400_00_DECLARE_V1MESTSINI_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R1200_00_DECLARE_SX118_DB_DECLARE_1(); program.R1200_00_DECLARE_SX118_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0700_00_SELECT_DATA_AVISO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0800_00_SELECT_GESISFUO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0900_00_SELECT_V0APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1000_00_SELECT_SX010_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1100_00_SELECT_V0COTACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1800_00_INSERT_V0COSSEG_SINI_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R2000_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R2200_00_SELECT_V1COSSEG_SINI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R2300_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}