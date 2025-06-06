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
using static Code.SI0867B;

namespace FileTests.Test_DB
{
    [Collection("SI0867B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0867B_Tests_DB
    {
        [Fact]
        public static void SI0867B_Database()
        {
            var program = new SI0867B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");
            var dayDataMock = DateTime.Now.AddDays(-100).ToString("dd");

            try
            { /*1*/
                program.Execute_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                program.R010_SELECT_SISTEMA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.R020_DECLARE_RELATORIO_DB_DECLARE_1();
                program.R020_DECLARE_RELATORIO_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.HOST_APOL_FIM.Value = long.Parse(dayDataMock);
                program.RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL.Value = fullDataMock;
                program.RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.Value = fullDataMock;

                program.R041_DECLARE_RAMO_DB_DECLARE_1();
                program.R041_DECLARE_RAMO_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*5*/
                program.R021_FETCH_RELATORIO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.R042_DECLARE_PRODUTO_DB_DECLARE_1(); 
                program.R042_DECLARE_PRODUTO_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.R043_DECLARE_APOLICE_DB_DECLARE_1(); 
                program.R043_DECLARE_APOLICE_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*8*/
                program.R044_DECLARE_RAMOVG_DB_DECLARE_1(); 
                program.R044_DECLARE_RAMOVG_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*9*/
                program.R810_BUSCA_FONTE_VIDA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*10*/
                program.R830_BUSCA_FONTE_OUTROS_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*11*/
                program.R850_BUSCA_DESC_FONTE_SINISTRO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}