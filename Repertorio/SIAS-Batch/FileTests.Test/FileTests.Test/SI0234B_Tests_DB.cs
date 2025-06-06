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
using static Code.SI0234B;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0234B_Tests_DB")]
    public class SI0234B_Tests_DB
    {

        [Fact]
        public static void SI0234B_Database()
        {
            var program = new SI0234B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R010_LE_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R120_VALIDA_INDENIZACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R120_VALIDA_INDENIZACAO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R200_LE_CRED_COMERCIAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R210_LE_MATCON_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try 
            {
                /*6*/
                program.RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.Value = "2024-01-01";
                program.RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.Value = "2024-01-01";
                program.RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL.Value = "2024-01-01";
                program.RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.Value = "2024-01-01";
                program.R300_INSERT_RELATORIOS_DB_INSERT_1(); 
            } catch (Exception ex) 
            { 
                _.ThreatableTestError(ex); 
            }

        }
    }
}