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
using static Code.VA0965B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("VA0965B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0965B_Tests_DB
    {

        [Fact]
        public static void VA0965B_Database()
        {
            var program = new VA0965B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }


            try { /*2*/
                program.AREA_DE_WORK.WHOST_DTH_INI.Value = "1993-11-10";
                program.AREA_DE_WORK.WHOST_DTH_FIM.Value = "1993-11-30";
                program.JVBKINCL.JV_PRODUTOS.JVPRD9327.Value = 9701;
                program.JVBKINCL.JV_PRODUTOS.JVPRD9320.Value = 9701;
                program.JVBKINCL.JV_PRODUTOS.JVPRD9311.Value = 9701;
                program.JVBKINCL.JV_PRODUTOS.JVPRD9321.Value = 9701;
                program.JVBKINCL.JV_PRODUTOS.JVPRD9327.Value = 9701;
                program.R0900_00_DECLARE_CURSOR_DB_DECLARE_1(); program.R0900_00_DECLARE_CURSOR_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }


            try { /*3*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 101100000011;
                program.R1900_00_DECLARE_CURSOR_DB_DECLARE_1(); program.R1900_00_DECLARE_CURSOR_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*4*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 103100000058;
                program.R1100_00_SELECT_SINISMES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*5*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO.Value = 10000342585;
                program.R1200_00_SELECT_SEGURVGA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           
            try { /*6*/
                program.SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE.Value = 1;
                program.R1300_00_SELECT_CLIENTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*7*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 335216;
                program.R1400_00_SELECT_SINISHIS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
          
            try { /*8*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 101100000001;
                program.R1500_00_SELECT_MAX_OCORR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
          
            try { /*9*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 109300077301;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.Value = 7;
                program.R1600_00_SELECT_SI175_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           
            try { /*10*/
                program.WHOST_NUM_OCORR_MOVTO.Value = 2016498;
                program.R1700_00_SELECT_GE368_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
          
            try { /*11*/
                program.GE368.DCLGE_LEG_PESS_EVENTO.GE368_SEQ_ENTIDADE.Value = 2;
                program.GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA.Value   = 1;
                program.R1800_00_SELECT_OD009_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
         
            try { /*12*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 401086240105.46;
                program.R2100_00_SELECT_SINISHIS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           
            try { /*13*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 106100000279;
                program.WHOST_MAX_OCORR.Value = 2;
                program.R2200_00_SELECT_SI155_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}