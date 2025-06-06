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
using static Code.VA0010B;

namespace FileTests.Test_DB
{
    [Collection("VA0010B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0010B_Tests_DB
    {

        [Fact]
        public static void VA0010B_Database()
        {
            var program = new VA0010B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.HOST_DTVENCTO.Value = "2000-10-10";
            program.HOST_DTPROXVEN.Value = "2000-10-10";
            program.V1HSEG_DTMOVTO.Value = "2000-10-10";
            program.V1SEGV_DTINIVIG.Value = "2000-10-10";

            try { /*1*/ program.M_0889_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_0889_SELECT_V1SISTEMA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_0900_DECLA_SEGURAVG_DB_DECLARE_1(); program.M_0900_DECLA_SEGURAVG_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_1000_PROCESSA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_1000_COBERTURAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_1000_PROCESSA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_1000_COBERTURAS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.M_1000_IDADE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.M_1000_COBERTURAS_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.M_1000_IDADE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.M_1000_PROCESSA_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.M_1000_COBERTURAS_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.M_1000_JA_INTEGRADO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.M_1000_COBERTURAS_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.M_1000_PROCESSA_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.M_1000_COBERTURAS_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.M_1000_COBERTURAS_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.M_1000_COBERTURAS_DB_SELECT_8(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.M_2000_INSERT_PROPOSTAVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.M_1000_COBERTURAS_DB_SELECT_9(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.M_1000_COBERTURAS_DB_SELECT_10(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/
                //banco possui 3 colunas a mais em relacao ao codigo cobol
                
                program.M_2100_INSERT_COBERPROPVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.M_2500_INSERT_CDGCOBER_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.M_2500_INSERT_CDGCOBER_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.M_3000_00_SELECT_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}