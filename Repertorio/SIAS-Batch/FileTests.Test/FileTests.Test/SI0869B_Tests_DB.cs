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
using static Code.SI0869B;

namespace FileTests.Test_DB
{
    [Collection("SI0869B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0869B_Tests_DB
    {

        [Fact]
        public static void SI0869B_Database()
        {
            var program = new SI0869B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R010_LE_SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R020_DECLARE_PAGAMENTOS_DB_DECLARE_1(); program.R020_DECLARE_PAGAMENTOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R150_DECLARE_CURSOR_RETENCAO_DB_DECLARE_1(); program.R150_DECLARE_CURSOR_RETENCAO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R105_BUSCA_SINISTRO_PREST_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try 
            { /*5*/
                program.CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.Value = "2025-01-01";
                program.R110_CALCULA_PROX_DIA_UTIL_DB_SELECT_1(); 
            } catch (Exception ex) 
            { 
                _.ThreatableTestError(ex); 
            }

            try { /*6*/ program.R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R130_VALOR_APURADO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R135_VALOR_ESTORNADO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R210_TELEFONE_TAB_LOTERICO01_DB_DECLARE_1(); program.R210_TELEFONE_TAB_LOTERICO01_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R190_VALOR_ADIANTAMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R200_VALOR_DIFERENCA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R240_MONTA_TIPO_ESTORNO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}