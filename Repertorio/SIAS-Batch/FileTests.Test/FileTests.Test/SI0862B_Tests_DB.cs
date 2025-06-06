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
using static Code.SI0862B;

namespace FileTests.Test_DB
{
    [Collection("SI0862B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0862B_Tests_DB
    {

        [Fact]
        public static void SI0862B_Database()
        {
            var program = new SI0862B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");

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
                program.R021_FETCH_RELATORIO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*5*/
                program.HOST_DATA_INICIAL.Value = fullDataMock;
                program.HOST_DATA_FINAL.Value = fullDataMock;

                program.R040_GRAVA_COLUNA_A_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.R050_GRAVA_COLUNA_B_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.R060_GRAVA_COLUNA_C_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*8*/
                program.R070_GRAVA_COLUNA_D_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*9*/
                program.R080_GRAVA_COLUNA_E_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*10*/
                program.R090_GRAVA_COLUNA_F_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*11*/
                program.R100_GRAVA_COLUNA_G_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*12*/
                program.R110_GRAVA_COLUNA_H_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*13*/
                program.R120_GRAVA_COLUNA_I_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*14*/
                program.R130_GRAVA_COLUNA_J_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*15*/
                program.R140_GRAVA_COLUNA_K_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*16*/
                program.R150_GRAVA_COLUNA_L_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*17*/
                program.R160_GRAVA_COLUNA_M_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*18*/
                program.R170_GRAVA_COLUNA_N_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*19*/
                program.R180_GRAVA_COLUNA_O_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*20*/
                program.R190_GRAVA_COLUNA_P_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*21*/
                program.R200_GRAVA_COLUNA_Q_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}