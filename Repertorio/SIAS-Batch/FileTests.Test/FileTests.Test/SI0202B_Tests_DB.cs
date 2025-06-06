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
using static Code.SI0202B;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0202B_Tests_DB")]
    public class SI0202B_Tests_DB
    {

        [Fact]
        public static void SI0202B_Database()
        {
            var program = new SI0202B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R010_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R020_ACHA_DATA_HOJE_MENOS_10_DB_DECLARE_1(); program.R020_ACHA_DATA_HOJE_MENOS_10_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try 
            { /*3*/
                program.W_DATA_INICIO_SELECAO.Value = "2025-01-01";
                program.W_DATA_FIM_SELECAO.Value = "2025-01-01";

                program.R030_DECLARE_SINISHIS_DB_DECLARE_1(); 
                program.R030_DECLARE_SINISHIS_DB_OPEN_1(); 
            } catch (Exception ex) 
            { 
                _.ThreatableTestError(ex); 
            }
            
            try { /*4*/ program.R110_LE_AGENCIA_INDENIZA_DB_DECLARE_1(); program.R110_LE_AGENCIA_INDENIZA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R105_PRIMEIRA_DATA_INDENIZA_1_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R150_PRIMEIRA_DATA_INDENIZA_2_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R107_LE_VALOR_PREMIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R500_LE_PLANILHA_DECLARE_DB_DECLARE_1(); program.R500_LE_PLANILHA_DECLARE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R200_LE_PRE_LIBERACOES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R200_LE_PRE_LIBERACOES_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R210_LE_ESTORNO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R220_LE_VALOR_PAGO_EST_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R510_LE_PLANILHA_SELECT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}