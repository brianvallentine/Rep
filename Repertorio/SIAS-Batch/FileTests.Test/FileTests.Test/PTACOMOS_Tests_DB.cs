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
using Dclgens;
using Code;
using static Code.PTACOMOS;

namespace FileTests.Test_DB
{
    [Collection("PTACOMOS_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class PTACOMOS_Tests_DB
    {
        [Fact]
        public static void PTACOMOS_Database()
        {
            var program = new PTACOMOS();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");

            try
            { /*1*/
                program.R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                program.SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO.Value = fullDataMock;

                program.R1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.R1400_00_INCLUI_SIPARTIC_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*5*/
                program.R1500_00_MAX_SIPROACO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.R1600_00_LE_SINISCAU_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.R1700_00_MAX_SICHEPAR_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*8*/
                program.SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO.Value = fullDataMock;
                program.SICHEPAR.DCLSI_CHECKLIST_PARAM.SICHEPAR_DATA_INIVIGENCIA.Value = fullDataMock;

                program.R1800_00_INCLUI_SIPROACO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*9*/
                program.R2100_00_EXCLUI_SISINACO_DB_DELETE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}