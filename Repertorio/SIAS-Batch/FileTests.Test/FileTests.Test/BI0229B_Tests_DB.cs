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
using static Code.BI0229B;

namespace FileTests.Test_DB
{
    [Collection("BI0229B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class BI0229B_Tests_DB
    {

        [Fact]
        public static void BI0229B_Database()
        {
            var program = new BI0229B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/

                program.WSHOST_DTINIVIG.Value = "2000-10-10";
                program.WSHOST_DTTERVIG.Value = "2000-10-10";

                program.R0300_00_DECLARE_V0ENDOSSO_DB_DECLARE_1(); program.R0300_00_DECLARE_V0ENDOSSO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0410_00_SELECT_ENDERECOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/

                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2000-10-10";

                program.R1020_00_SELECT_CBCONDEV_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                
                program.CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_CANCELAMENTO.Value = "2000-10-10";
                program.CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_QUITACAO.Value = "2000-10-10";
                program.CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_OCORRENCIA.Value = "2000-10-10";
                program.CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_MOVIMENTO.Value = "2000-10-10";


                program.R1250_00_INSERT_CBCONDEV_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}