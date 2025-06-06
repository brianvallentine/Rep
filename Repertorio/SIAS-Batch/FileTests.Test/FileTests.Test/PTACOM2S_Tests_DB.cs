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
using static Code.PTACOM2S;

namespace FileTests.Test_DB
{
    [Collection("PTACOM2S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class PTACOM2S_Tests_DB
    {

        [Fact]
        public static void PTACOM2S_Database()
        {
            var program = new PTACOM2S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");

            try
            { /*1*/
                program.R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                program.SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DATA_INIVIG_DOCPAR.Value = fullDataMock;
                program.SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DATA_MOVTO_DOCACO.Value = fullDataMock;

                program.R1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.R1400_00_MAX_SIPROACO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*5*/
                program.R1500_00_MAX_SICHEPAR_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.SICHEPAR.DCLSI_CHECKLIST_PARAM.SICHEPAR_DATA_INIVIGENCIA.Value = fullDataMock;

                program.R1600_00_INCLUI_SIPROACO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}