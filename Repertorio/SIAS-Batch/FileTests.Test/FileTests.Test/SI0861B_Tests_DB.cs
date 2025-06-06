using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Copies;
using Code;
using static Code.SI0861B;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("SI0861B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0861B_Tests_DB
    {

        [Fact]
        public static void SI0861B_Database()
        {
            var program = new SI0861B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.Execute_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R010_SELECT_SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R020_DECLARE_RELATORIO_DB_DECLARE_1(); program.R020_DECLARE_RELATORIO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.HOST_DATA_INICIAL.Value = "2020-01-01";
                program.HOST_DATA_FINAL.Value = "2020-01-01";
                program.HOST_APOLICE_INICIAL.Value = 123456;
                program.HOST_APOLICE_FINAL.Value = 123456 ;
                program.HOST_RAMO_INICIAL.Value = 1;
                program.HOST_RAMO_FINAL.Value = 2;
                program.HOST_CODSUBES_INICIAL.Value = 4;
                program.HOST_CODSUBES_FINAL.Value = 5;
                program.HOST_PRODUTO_INICIAL.Value = 5;
                program.HOST_PRODUTO_FINAL.Value =6 ; 
                program.R100_DECLARE_PAGO_DB_DECLARE_1(); program.R100_DECLARE_PAGO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.Value ="X";
                program.R021_FETCH_RELATORIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.HOST_DATA_FINAL.Value = "2020-01-01";
                program.HOST_APOLICE_INICIAL.Value= 1234656;
                program.R200_DECLARE_PENDENTE_DB_DECLARE_1(); program.R200_DECLARE_PENDENTE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}