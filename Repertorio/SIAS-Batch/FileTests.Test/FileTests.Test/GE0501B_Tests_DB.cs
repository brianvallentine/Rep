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
using static Code.GE0501B;

namespace FileTests.Test_DB
{
    [Collection("GE0501B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class GE0501B_Tests_DB
    {

        [Fact]
        public static void GE0501B_Database()
        {
            var program = new GE0501B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.Execute_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R200_CONSULTA_PJ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R100_INSERT_PJ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*4*/
                program.OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO.Value = "2020-01-01";
                program.INICIO_LOOP_NOME_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*5*/
                program.OD003.DCLOD_PESSOA_JURIDICA.OD003_DTH_FUNDACAO.Value = "2020-01-01";
                program.INICIO_LOOP_NOME_DB_INSERT_2(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*6*/
                program.OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_CNPJ.Value = 34020354;
                program.OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_FILIAL.Value = 1;
                program.OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_DV_CNPJ.Value = 10;
                program.R310_00_DECLARE_PJURIDICA_DB_DECLARE_1(); 
                program.R310_00_DECLARE_PJURIDICA_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}