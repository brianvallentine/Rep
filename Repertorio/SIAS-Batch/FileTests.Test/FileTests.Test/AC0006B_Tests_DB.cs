using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.AC0006B;

namespace FileTests.Test_DB
{

    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("AC0006B_Tests_DB")]
    public class AC0006B_Tests_DB
    {

        [Fact]
        public static void AC0006B_Database()
        {
            var program = new AC0006B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.R0200_00_CHECA_EXECUCAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.R0500_00_DECLARE_PARCEHIS_DB_DECLARE_1(); program.R0500_00_DECLARE_PARCEHIS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.Value =  123 ;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.Value = "2020-01-01";
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.Value = "2020-01-01";
                program.R1400_00_DECLARE_APOLCOSS_DB_DECLARE_1(); program.R1400_00_DECLARE_APOLCOSS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.Value = 1 ;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.Value = 2;
                program.R0800_00_SELECT_GE397_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.Value = 2;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.Value = 3;
                program.R0900_00_SELECT_ENDOSSOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ 
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.Value = 1;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.Value = 2;
                program.R1200_00_SELECT_PARCELAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.Value = 1 ;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.Value =  2;
                program.R1300_00_SELECT_APOLICOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.Value = 1;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.Value = 2;
                program.APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA.Value = 3;
                program.R1700_00_DECLARE_GE397_GE398_DB_DECLARE_1(); program.R1700_00_DECLARE_GE397_GE398_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.Value = 1;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.Value = 2;
                program.GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_COD_RAMO_COBER.Value = 3;
                program.R2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/
                program.GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_NUM_APOLICE.Value = 1;
                program.GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_NUM_ENDOSSO.Value = 2;
                program.GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_COD_RAMO_COBER.Value = 3;
                program.GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_COD_COSSEGURADORA.Value = 4;
                program.GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_VLR_IMPSEG_CED_VAR.Value = 5;
                program.GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_RAMO_IS.Value = 6;
                program.GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_TOTAL_IS.Value = 7;
                program.GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_VLR_PRMTAR_CED_VAR.Value = 8;
                program.GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_RAMO_PR.Value = 9;
                program.GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_TOTAL_PR.Value = 10;
                program.GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_VLR_COMCOS_RAMO.Value = 11;
                program.GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_COM_RAMO.Value = 12;
                program.GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_COM_TOTAL.Value = 13;
                program.GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_NOM_PROGRAMA.Value = "X";
                program.R2500_00_INSERT_GE399_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}