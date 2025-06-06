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
using static Code.AU0025S;

namespace FileTests.Test_DB
{
    [Collection("AU0025S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class AU0025S_Tests_DB
    {

        [Fact]
        public static void AU0025S_Database()
        {
            var program = new AU0025S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");

            try
            { /*1*/
                program.M_010_000_SELECIONA_TAXAS_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                program.CSP_RETORNO.TAXAC_DTINIVIG.Value = fullDataMock;
                
                program.M_010_000_SELECIONA_TAXAS_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.CSP_RETORNO.V1MOEDA_DTINIVIG.Value = fullDataMock;

                program.M_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.CSP_RETORNO.BONAU_DTINIVIG.Value = fullDataMock;

                program.M_025_000_LE_BONUS_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*5*/
                program.CSP_RETORNO.CATTF_DTINIVIG.Value = fullDataMock;

                program.M_035_000_PESQ_FRANQOBR_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.CSP_RETORNO.FRFAC_DTINIVIG.Value = fullDataMock;

                program.M_072_000_PESQ_V1FRANQFAC_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.CSP_RETORNO.CATTF_DTINIVIG.Value = fullDataMock;

                program.M_074_000_PESQ_V1CATTARIFA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*8*/
                program.CSP_RETORNO.CATTF_DTINIVIG.Value = fullDataMock;

                program.M_160_000_PESQ_V1CATTARIFA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*9*/
                program.CSP_RETORNO.CATTF_DTINIVIG.Value = fullDataMock;

                program.M_162_000_PESQ_V1CATTARIFA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*10*/
                program.CSP_RETORNO.PRAZO_DTINIVIG.Value = fullDataMock;

                program.M_210_000_PESQ_V1PRAZOSEG_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*11*/
                program.CSP_RETORNO.NIVCS_DTINIVIG.Value = fullDataMock;
                program.CSP_RETORNO.NIVCS_DTINIVIG.Value = fullDataMock;

                program.M_237_000_PESQ_V1NIVELCAP_BTN_DB_DECLARE_1();
                program.M_237_000_PESQ_V1NIVELCAP_BTN_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*12*/
                program.CSP_RETORNO.CFRCF_DTINIVIG.Value = fullDataMock;

                program.M_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*13*/
                program.CSP_RETORNO.TXAPP_DTINIVIG.Value = fullDataMock;

                program.M_360_000_PESQ_V1TAXASAPP_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}