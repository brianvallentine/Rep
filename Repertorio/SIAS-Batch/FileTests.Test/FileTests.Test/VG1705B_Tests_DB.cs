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
using static Code.VG1705B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("VG1705B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG1705B_Tests_DB
    {

        [Fact]
        public static void VG1705B_Database()
        {
            var program = new VG1705B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_0000_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_0000_INICIO_DB_DECLARE_1(); program.M_0000_INICIO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_1000_PROCESSA_EVENTO_DB_DECLARE_1(); program.M_1000_PROCESSA_EVENTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_1000_PROCESSA_EVENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_1000_CONTINUA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_1000_PROCESSA_EVENTO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_1500_PROC_FATURAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*8*/
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.Value = "2025-01-27";
                program.M_1500_PROC_FATURAS_DB_SELECT_2(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.M_1500_PROC_FATURAS_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.M_1500_PROC_FATURAS_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.M_1500_PROC_FATURAS_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.M_1500_PROC_FATURAS_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.M_1500_PROC_FATURAS_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*14*/
                program.COMISSOE.DCLCOMISSOES.COMISSOE_DATA_CALCULO.Value = "2025-01-27";
                program.COMISSOE.DCLCOMISSOES.COMISSOE_HORA_OPERACAO.Value = "00:00:00";
                program.COMISSOE.DCLCOMISSOES.COMISSOE_DATA_SELECAO.Value = "2025-01-27";
                program.COMISSOE.DCLCOMISSOES.COMISSOE_DATA_QUITACAO.Value = "2025-01-27";

                program.M_2000_LOOP_TIME_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.M_1500_PROC_FATURAS_DB_SELECT_8(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.M_1500_PROC_FATURAS_DB_SELECT_9(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*17*/
                program.FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_DATA_QUITACAO.Value = "2025-01-27";
                program.FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_DATA_MOVIMENTO.Value = "2025-01-27";
                program.M_3000_GRAVA_FUNDAO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.M_1500_PROC_FATURAS_DB_SELECT_10(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}