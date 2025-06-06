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
using static Code.GE0531S;

namespace FileTests.Test_DB
{
    [Collection("GE0531S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class GE0531S_Tests_DB
    {
        [Fact]
        public static void GE0531S_Database()
        {
            var program = new GE0531S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            program.GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_DTA_INCLUSAO.Value = "2000-10-10";

            try { /*1*/ program.R1050_00_BUSCAR_DTH_RESTR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R1100_00_BUSCAR_ULT_SEQ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R1200_00_INSERIR_DADOS_LOG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}