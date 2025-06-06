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
using static Code.VG0283B;

namespace FileTests.Test_DB
{
    [Collection("VG0283B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VG0283B_Tests_DB
    {

        [Fact]
        public static void VG0283B_Database()
        {
            var program = new VG0283B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0200_00_DECLARE_V1RELATORIOS_DB_DECLARE_1(); program.R0200_00_DECLARE_V1RELATORIOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0900_00_DECLARE_V2COMISSAO_DB_DECLARE_1(); program.R0900_00_DECLARE_V2COMISSAO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0220_00_UPDATE_V0RELATORIOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0300_00_MONTA_CABECALHOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0300_00_MONTA_CABECALHOS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R2100_00_SELECT_V1APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R2300_00_SELECT_V1CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/

                program.WHOST_DTINIVIG.Value = "2000-10-10";

                program.R2400_00_SELECT_V1MOEDA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}