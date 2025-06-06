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
using static Code.SI0820B;

namespace FileTests.Test_DB
{
    [Collection("SI0820B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0820B_Tests_DB
    {

        [Fact]
        public static void SI0820B_Database()
        {
            var program = new SI0820B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");

            try
            { /*1*/
                program.V0RELA_PERI_FINAL.Value = fullDataMock;

                program.M_0000_00_DECLARE_CUR_PRINC_DB_DECLARE_1();
                program.M_0000_00_DECLARE_CUR_PRINC_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                program.M_0000_00_SOMA_OPERACOES_SINI_DB_DECLARE_1();
                program.M_0000_00_SOMA_OPERACOES_SINI_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.M_0000_00_VERIFICA_SINISTRO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.M_0000_00_DECLARE_V0RELATORIOS_DB_DECLARE_1();
                program.M_0000_00_DECLARE_V0RELATORIOS_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*5*/
                program.V0CRED_DTTERVIG.Value = fullDataMock;
                program.V0RELA_PERI_INICIAL.Value = fullDataMock;

                program.M_0000_00_CALCULA_SALDO_PREMIO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.M_0000_00_PREPARA_CABECALHO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*8*/
                program.M_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*9*/
                program.M_0000_00_ACESSA_NOME_ESCNEG_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*10*/
                program.M_0000_00_CONTROLE_EXECUCAO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}