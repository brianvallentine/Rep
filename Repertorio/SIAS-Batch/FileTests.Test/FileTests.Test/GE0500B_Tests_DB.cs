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
using static Code.GE0500B;

namespace FileTests.Test_DB
{
    [Collection("GE0500B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class GE0500B_Tests_DB
    {

        [Fact]
        public static void GE0500B_Database()
        {
            var program = new GE0500B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.Execute_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R010_CRITICA_INCLUSAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R200_CONSULTA_PF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R100_INSERT_PF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*5*/
                program.OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO.Value = "2020-01-01";
                program.INICIO_LOOP_NOME_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*6*/
                program.OD002.DCLOD_PESSOA_FISICA.OD002_DTH_NASCIMENTO.Value = "2020-01-01";
                program.INICIO_LOOP_NOME_DB_INSERT_2(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*7*/
                program.OD002.DCLOD_PESSOA_FISICA.OD002_NUM_CPF.Value = 887204626;
                program.OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_CPF.Value = 20;
                program.R310_00_DECLARE_PFISICA_DB_DECLARE_1(); 
                program.R310_00_DECLARE_PFISICA_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}