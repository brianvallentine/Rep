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
using static Code.SI0202S;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("SI0202S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0202S_Tests_DB
    {

        [Fact]
        public static void SI0202S_Database()
        {
            var program = new SI0202S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/
                program.SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_APOL_SINISTRO.Value = 1;
                program.R0500_SEL_NUM_CONTRATO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO_TERC.Value = 1;
                program.R1000_SEL_EF_CONTR_HABIT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO.Value = 1;
                program.R2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO.Value = 1;
                program.R3000_SEL_IMOVEL_OBJ_CTRTO_SEG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO.Value = 1;
                program.R4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.EF079.DCLEF_SEGURADO_OBJETO.EF079_SEQ_TIPO_OBJ_SEG.Value = 1;
                program.EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO.Value =1;    
                program.R5000_SEL_PESSOA_CONTRTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.GEPESEND.DCLGE_PESSOA_ENDERECO.GEPESEND_COD_PESSOA.Value = 1;   
                program.R6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO.Value = 1 ;
                program.R7000_SEL_COD_PESSOA_CRT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO.Value =1 ;   
                program.R8000_SEL_CONTRTE_CONTR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_NUM_CONTRATO.Value =1 ;
                program.ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_PONTO_VENDA.Value = 1 ;
                program.ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_OPERACAO.Value = 1 ;    
                program.R9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}