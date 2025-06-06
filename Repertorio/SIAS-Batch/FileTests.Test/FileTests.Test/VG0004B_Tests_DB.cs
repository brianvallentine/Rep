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
using static Code.VG0004B;

namespace FileTests.Test_DB
{
    [Collection("VG0004B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG0004B_Tests_DB
    {

        [Fact]
        public static void VG0004B_Database()
        {
            var program = new VG0004B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO.Value = "2000-10-10";
            try { /*1*/ program.M_0900_DECLA_HISTCONTABILVA_DB_DECLARE_1(); program.M_0900_DECLA_HISTCONTABILVA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_1050_SELECT_PROPOVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_1100_SELECT_ENDOSSOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_1100_SELECT_ENDOSSOS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_1200_UPDATE_PARCELVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_1100_SELECT_ENDOSSOS_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_1300_UPDATE_HISTCOBVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.M_1400_UPDATE_HISTCONTABILVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}