using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Dclgens;
using Copies;
using Sias.Outros.DB2.EF148S;

namespace Code
{
    public class EF148S
    {
        public bool IsCall { get; set; }

        public EF148S()
        {
            AppSettings.Load();
        }

        #region VARIABLES

        /*"77 WS-DTH-FIM-VIGENCIA-NULL    PIC S9(04) COMP VALUE +0.*/
        public IntBasis WS_DTH_FIM_VIGENCIA_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 WS-OPERACAO                 PIC X(01) VALUE SPACES.*/
        public StringBasis WS_OPERACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"77 WS-PROGRAMA                 PIC X(08) VALUE 'EF148S'.*/
        public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"EF148S");
        /*"77 WS-OCORRENCIA               PIC X(80) VALUE SPACES.*/
        public StringBasis WS_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"");
        /*"77 EF148-NUM-APOLICE-EF        PIC S9(15) COMP-3 VALUE +0.*/
        public IntBasis EF148_NUM_APOLICE_EF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01 LINKAGE-EF148S.*/
        public EF148S_LINKAGE_EF148S LINKAGE_EF148S { get; set; } = new EF148S_LINKAGE_EF148S();
        public class EF148S_LINKAGE_EF148S : VarBasis
        {
            /*"   10 LK-RETORNO                    PIC 9(5).*/
            public IntBasis LK_RETORNO { get; set; } = new IntBasis(new PIC("9", "5", "9(5)."));
            /*"   10 LK-OPERACAO                   PIC X(1).*/
            public StringBasis LK_OPERACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"   10 LK-NUM-CONTRATO-APOL          PIC 9(16).*/
            public IntBasis LK_NUM_CONTRATO_APOL { get; set; } = new IntBasis(new PIC("9", "16", "9(16)."));
            /*"   10 LK-COD-PRODUTO                PIC 9(04).*/
            public IntBasis LK_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   10 LK-COD-COBERTURA              PIC 9(04).*/
            public IntBasis LK_COD_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   10 LK-DTH-INI-VIGENCIA           PIC X(10).*/
            public StringBasis LK_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   10 LK-NUM-RAMO-CONTABIL          PIC 9(04).*/
            public IntBasis LK_NUM_RAMO_CONTABIL { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   10 LK-COD-PRODUTO-ACESS          PIC 9(04).*/
            public IntBasis LK_COD_PRODUTO_ACESS { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   10 LK-COD-COBERTURA-ACESS        PIC 9(04).*/
            public IntBasis LK_COD_COBERTURA_ACESS { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   10 LK-NUM-APOLICE                PIC 9(16).*/
            public IntBasis LK_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "16", "9(16)."));
            /*"   10 LK-DTH-FIM-VIGENCIA           PIC X(10).*/
            public StringBasis LK_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   10 LK-NUM-APOLICE-EF             PIC 9(16).*/
            public IntBasis LK_NUM_APOLICE_EF { get; set; } = new IntBasis(new PIC("9", "16", "9(16)."));
        }


        public Dclgens.EF148 EF148 { get; set; } = new Dclgens.EF148();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(EF148S_LINKAGE_EF148S EF148S_LINKAGE_EF148S_P) //PROCEDURE DIVISION USING 
        /*LINKAGE_EF148S*/
        {
            try
            {
                this.LINKAGE_EF148S = EF148S_LINKAGE_EF148S_P;

                /*" -43- EXEC SQL WHENEVER SQLERROR GOTO P910-DB2-ERRO END-EXEC */

                /*" -45- PERFORM P000-INI-VARIAVEIS */

                P000_INI_VARIAVEIS(true);

                /*" -47- EVALUATE WS-OPERACAO */
                switch (WS_OPERACAO.Value.Trim())
                {

                    /*" -48- WHEN 'I' */
                    case "I":

                        /*" -49- PERFORM P070-VER-CMP-NULOS */

                        P070_VER_CMP_NULOS(true);

                        /*" -50- PERFORM P010-INS-PROC */

                        P010_INS_PROC(true);

                        /*" -51- PERFORM P060-TRA-VAR-LINKAGE */

                        P060_TRA_VAR_LINKAGE(true);

                        /*" -52- WHEN 'D' */
                        break;
                    case "D":

                        /*" -53- PERFORM P030-DEL-PROC */

                        P030_DEL_PROC(true);

                        /*" -54- WHEN 'S' */
                        break;
                    case "S":

                        /*" -55- PERFORM P040-SEL-PROC */

                        P040_SEL_PROC(true);

                        /*" -56- PERFORM P080-VER-SAIDA-CMP-NULOS */

                        P080_VER_SAIDA_CMP_NULOS(true);

                        /*" -57- PERFORM P060-TRA-VAR-LINKAGE */

                        P060_TRA_VAR_LINKAGE(true);

                        /*" -58- WHEN 'C' */
                        break;
                    case "C":

                        /*" -59- PERFORM P041-SEL-PROC */

                        P041_SEL_PROC(true);

                        /*" -60- PERFORM P080-VER-SAIDA-CMP-NULOS */

                        P080_VER_SAIDA_CMP_NULOS(true);

                        /*" -61- PERFORM P060-TRA-VAR-LINKAGE */

                        P060_TRA_VAR_LINKAGE(true);

                        /*" -62- WHEN 'U' */
                        break;
                    case "U":

                        /*" -63- PERFORM P040-SEL-PROC */

                        P040_SEL_PROC(true);

                        /*" -64- PERFORM P050-INI-VAR-UPD */

                        P050_INI_VAR_UPD(true);

                        /*" -65- PERFORM P070-VER-CMP-NULOS */

                        P070_VER_CMP_NULOS(true);

                        /*" -66- PERFORM P020-UPD-PROC */

                        P020_UPD_PROC(true);

                        /*" -67- END-EVALUATE */
                        break;
                }


                /*" -68- GOBACK */

                throw new GoBack();

                /*" -68- . */

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LINKAGE_EF148S };
            return Result;
        }

        [StopWatch]
        /*" P000-INI-VARIAVEIS */
        private void P000_INI_VARIAVEIS(bool isPerform = false)
        {
            /*" -73- DISPLAY '* ' WS-PROGRAMA ' - SUBROTINA CHAMADA' */

            $"* {WS_PROGRAMA} - SUBROTINA CHAMADA"
            .Display();

            /*" -74- IF ( LK-NUM-CONTRATO-APOL EQUAL LOW-VALUES ) THEN */

            if ((LINKAGE_EF148S.LK_NUM_CONTRATO_APOL.IsLowValues()))
            {

                /*" -76- MOVE ZEROS TO LK-NUM-CONTRATO-APOL */
                _.Move(0, LINKAGE_EF148S.LK_NUM_CONTRATO_APOL);

                /*" -78- END-IF */
            }


            /*" -79- IF ( LK-COD-PRODUTO EQUAL LOW-VALUES ) THEN */

            if ((LINKAGE_EF148S.LK_COD_PRODUTO.IsLowValues()))
            {

                /*" -81- MOVE ZEROS TO LK-COD-PRODUTO */
                _.Move(0, LINKAGE_EF148S.LK_COD_PRODUTO);

                /*" -83- END-IF */
            }


            /*" -84- IF ( LK-COD-COBERTURA EQUAL LOW-VALUES ) THEN */

            if ((LINKAGE_EF148S.LK_COD_COBERTURA.IsLowValues()))
            {

                /*" -86- MOVE ZEROS TO LK-COD-COBERTURA */
                _.Move(0, LINKAGE_EF148S.LK_COD_COBERTURA);

                /*" -88- END-IF */
            }


            /*" -89- IF ( LK-DTH-INI-VIGENCIA EQUAL LOW-VALUES ) THEN */

            if ((LINKAGE_EF148S.LK_DTH_INI_VIGENCIA.IsLowValues()))
            {

                /*" -91- MOVE SPACES TO LK-DTH-INI-VIGENCIA */
                _.Move("", LINKAGE_EF148S.LK_DTH_INI_VIGENCIA);

                /*" -93- END-IF */
            }


            /*" -94- IF ( LK-NUM-RAMO-CONTABIL EQUAL LOW-VALUES ) THEN */

            if ((LINKAGE_EF148S.LK_NUM_RAMO_CONTABIL.IsLowValues()))
            {

                /*" -96- MOVE ZEROS TO LK-NUM-RAMO-CONTABIL */
                _.Move(0, LINKAGE_EF148S.LK_NUM_RAMO_CONTABIL);

                /*" -98- END-IF */
            }


            /*" -99- IF ( LK-COD-PRODUTO-ACESS EQUAL LOW-VALUES ) THEN */

            if ((LINKAGE_EF148S.LK_COD_PRODUTO_ACESS.IsLowValues()))
            {

                /*" -101- MOVE ZEROS TO LK-COD-PRODUTO-ACESS */
                _.Move(0, LINKAGE_EF148S.LK_COD_PRODUTO_ACESS);

                /*" -103- END-IF */
            }


            /*" -104- IF ( LK-COD-COBERTURA-ACESS EQUAL LOW-VALUES ) THEN */

            if ((LINKAGE_EF148S.LK_COD_COBERTURA_ACESS.IsLowValues()))
            {

                /*" -106- MOVE ZEROS TO LK-COD-COBERTURA-ACESS */
                _.Move(0, LINKAGE_EF148S.LK_COD_COBERTURA_ACESS);

                /*" -108- END-IF */
            }


            /*" -109- IF ( LK-NUM-APOLICE EQUAL LOW-VALUES ) THEN */

            if ((LINKAGE_EF148S.LK_NUM_APOLICE.IsLowValues()))
            {

                /*" -111- MOVE ZEROS TO LK-NUM-APOLICE */
                _.Move(0, LINKAGE_EF148S.LK_NUM_APOLICE);

                /*" -113- END-IF */
            }


            /*" -114- IF ( LK-DTH-FIM-VIGENCIA EQUAL LOW-VALUES ) THEN */

            if ((LINKAGE_EF148S.LK_DTH_FIM_VIGENCIA.IsLowValues()))
            {

                /*" -116- MOVE SPACES TO LK-DTH-FIM-VIGENCIA */
                _.Move("", LINKAGE_EF148S.LK_DTH_FIM_VIGENCIA);

                /*" -118- END-IF */
            }


            /*" -119- IF ( LK-NUM-APOLICE-EF EQUAL LOW-VALUES ) THEN */

            if ((LINKAGE_EF148S.LK_NUM_APOLICE_EF.IsLowValues()))
            {

                /*" -121- MOVE ZEROS TO LK-NUM-APOLICE-EF */
                _.Move(0, LINKAGE_EF148S.LK_NUM_APOLICE_EF);

                /*" -123- END-IF */
            }


            /*" -124- MOVE LK-OPERACAO TO WS-OPERACAO */
            _.Move(LINKAGE_EF148S.LK_OPERACAO, WS_OPERACAO);

            /*" -126- MOVE LK-NUM-CONTRATO-APOL TO EF148-NUM-CONTRATO-APOL */
            _.Move(LINKAGE_EF148S.LK_NUM_CONTRATO_APOL, EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_CONTRATO_APOL);

            /*" -128- MOVE LK-COD-PRODUTO TO EF148-COD-PRODUTO */
            _.Move(LINKAGE_EF148S.LK_COD_PRODUTO, EF148.DCLEF_PROD_ACESSORIO.EF148_COD_PRODUTO);

            /*" -130- MOVE LK-COD-COBERTURA TO EF148-COD-COBERTURA */
            _.Move(LINKAGE_EF148S.LK_COD_COBERTURA, EF148.DCLEF_PROD_ACESSORIO.EF148_COD_COBERTURA);

            /*" -132- MOVE LK-DTH-INI-VIGENCIA TO EF148-DTH-INI-VIGENCIA */
            _.Move(LINKAGE_EF148S.LK_DTH_INI_VIGENCIA, EF148.DCLEF_PROD_ACESSORIO.EF148_DTH_INI_VIGENCIA);

            /*" -134- MOVE LK-NUM-RAMO-CONTABIL TO EF148-NUM-RAMO-CONTABIL */
            _.Move(LINKAGE_EF148S.LK_NUM_RAMO_CONTABIL, EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_RAMO_CONTABIL);

            /*" -136- MOVE LK-COD-PRODUTO-ACESS TO EF148-COD-PRODUTO-ACESS */
            _.Move(LINKAGE_EF148S.LK_COD_PRODUTO_ACESS, EF148.DCLEF_PROD_ACESSORIO.EF148_COD_PRODUTO_ACESS);

            /*" -138- MOVE LK-COD-COBERTURA-ACESS TO EF148-COD-COBERTURA-ACESS */
            _.Move(LINKAGE_EF148S.LK_COD_COBERTURA_ACESS, EF148.DCLEF_PROD_ACESSORIO.EF148_COD_COBERTURA_ACESS);

            /*" -140- MOVE LK-NUM-APOLICE TO EF148-NUM-APOLICE */
            _.Move(LINKAGE_EF148S.LK_NUM_APOLICE, EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_APOLICE);

            /*" -142- MOVE LK-DTH-FIM-VIGENCIA TO EF148-DTH-FIM-VIGENCIA */
            _.Move(LINKAGE_EF148S.LK_DTH_FIM_VIGENCIA, EF148.DCLEF_PROD_ACESSORIO.EF148_DTH_FIM_VIGENCIA);

            /*" -144- MOVE LK-NUM-APOLICE-EF TO EF148-NUM-APOLICE-EF */
            _.Move(LINKAGE_EF148S.LK_NUM_APOLICE_EF, EF148_NUM_APOLICE_EF);

            /*" -144- . */

        }

        [StopWatch]
        /*" P010-INS-PROC */
        private void P010_INS_PROC(bool isPerform = false)
        {
            /*" -169- PERFORM P010_INS_PROC_DB_INSERT_1 */

            P010_INS_PROC_DB_INSERT_1();

            /*" -170- . */

        }

        [StopWatch]
        /*" P010-INS-PROC-DB-INSERT-1 */
        public void P010_INS_PROC_DB_INSERT_1()
        {
            /*" -169- EXEC SQL INSERT INTO SEGUROS.EF_PROD_ACESSORIO (NUM_CONTRATO_APOL , COD_PRODUTO , COD_COBERTURA , DTH_INI_VIGENCIA , NUM_RAMO_CONTABIL , COD_PRODUTO_ACESS , COD_COBERTURA_ACESS , NUM_APOLICE , DTH_FIM_VIGENCIA) VALUES ( :EF148-NUM-CONTRATO-APOL , :EF148-COD-PRODUTO , :EF148-COD-COBERTURA , :EF148-DTH-INI-VIGENCIA , :EF148-NUM-RAMO-CONTABIL , :EF148-COD-PRODUTO-ACESS , :EF148-COD-COBERTURA-ACESS , :EF148-NUM-APOLICE , :EF148-DTH-FIM-VIGENCIA :WS-DTH-FIM-VIGENCIA-NULL) END-EXEC */

            var p010_INS_PROC_DB_INSERT_1_Insert1 = new P010_INS_PROC_DB_INSERT_1_Insert1()
            {
                EF148_NUM_CONTRATO_APOL = EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_CONTRATO_APOL.ToString(),
                EF148_COD_PRODUTO = EF148.DCLEF_PROD_ACESSORIO.EF148_COD_PRODUTO.ToString(),
                EF148_COD_COBERTURA = EF148.DCLEF_PROD_ACESSORIO.EF148_COD_COBERTURA.ToString(),
                EF148_DTH_INI_VIGENCIA = EF148.DCLEF_PROD_ACESSORIO.EF148_DTH_INI_VIGENCIA.ToString(),
                EF148_NUM_RAMO_CONTABIL = EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_RAMO_CONTABIL.ToString(),
                EF148_COD_PRODUTO_ACESS = EF148.DCLEF_PROD_ACESSORIO.EF148_COD_PRODUTO_ACESS.ToString(),
                EF148_COD_COBERTURA_ACESS = EF148.DCLEF_PROD_ACESSORIO.EF148_COD_COBERTURA_ACESS.ToString(),
                EF148_NUM_APOLICE = EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_APOLICE.ToString(),
                EF148_DTH_FIM_VIGENCIA = EF148.DCLEF_PROD_ACESSORIO.EF148_DTH_FIM_VIGENCIA.ToString(),
                WS_DTH_FIM_VIGENCIA_NULL = WS_DTH_FIM_VIGENCIA_NULL.ToString(),
            };

            P010_INS_PROC_DB_INSERT_1_Insert1.Execute(p010_INS_PROC_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" P020-UPD-PROC */
        private void P020_UPD_PROC(bool isPerform = false)
        {
            /*" -185- PERFORM P020_UPD_PROC_DB_UPDATE_1 */

            P020_UPD_PROC_DB_UPDATE_1();

            /*" -186- . */

        }

        [StopWatch]
        /*" P020-UPD-PROC-DB-UPDATE-1 */
        public void P020_UPD_PROC_DB_UPDATE_1()
        {
            /*" -185- EXEC SQL UPDATE SEGUROS.EF_PROD_ACESSORIO SET NUM_RAMO_CONTABIL = :EF148-NUM-RAMO-CONTABIL , COD_PRODUTO_ACESS = :EF148-COD-PRODUTO-ACESS , COD_COBERTURA_ACESS = :EF148-COD-COBERTURA-ACESS , NUM_APOLICE = :EF148-NUM-APOLICE , DTH_FIM_VIGENCIA = :EF148-DTH-FIM-VIGENCIA :WS-DTH-FIM-VIGENCIA-NULL WHERE NUM_CONTRATO_APOL = :EF148-NUM-CONTRATO-APOL AND COD_PRODUTO = :EF148-COD-PRODUTO AND COD_COBERTURA = :EF148-COD-COBERTURA AND DTH_INI_VIGENCIA = :EF148-DTH-INI-VIGENCIA END-EXEC */

            var p020_UPD_PROC_DB_UPDATE_1_Update1 = new P020_UPD_PROC_DB_UPDATE_1_Update1()
            {
                EF148_DTH_FIM_VIGENCIA = EF148.DCLEF_PROD_ACESSORIO.EF148_DTH_FIM_VIGENCIA.ToString(),
                WS_DTH_FIM_VIGENCIA_NULL = WS_DTH_FIM_VIGENCIA_NULL.ToString(),
                EF148_COD_COBERTURA_ACESS = EF148.DCLEF_PROD_ACESSORIO.EF148_COD_COBERTURA_ACESS.ToString(),
                EF148_NUM_RAMO_CONTABIL = EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_RAMO_CONTABIL.ToString(),
                EF148_COD_PRODUTO_ACESS = EF148.DCLEF_PROD_ACESSORIO.EF148_COD_PRODUTO_ACESS.ToString(),
                EF148_NUM_APOLICE = EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_APOLICE.ToString(),
                EF148_NUM_CONTRATO_APOL = EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_CONTRATO_APOL.ToString(),
                EF148_DTH_INI_VIGENCIA = EF148.DCLEF_PROD_ACESSORIO.EF148_DTH_INI_VIGENCIA.ToString(),
                EF148_COD_COBERTURA = EF148.DCLEF_PROD_ACESSORIO.EF148_COD_COBERTURA.ToString(),
                EF148_COD_PRODUTO = EF148.DCLEF_PROD_ACESSORIO.EF148_COD_PRODUTO.ToString(),
            };

            P020_UPD_PROC_DB_UPDATE_1_Update1.Execute(p020_UPD_PROC_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" P030-DEL-PROC */
        private void P030_DEL_PROC(bool isPerform = false)
        {
            /*" -195- PERFORM P030_DEL_PROC_DB_DELETE_1 */

            P030_DEL_PROC_DB_DELETE_1();

            /*" -196- . */

        }

        [StopWatch]
        /*" P030-DEL-PROC-DB-DELETE-1 */
        public void P030_DEL_PROC_DB_DELETE_1()
        {
            /*" -195- EXEC SQL DELETE FROM SEGUROS.EF_PROD_ACESSORIO WHERE NUM_CONTRATO_APOL = :EF148-NUM-CONTRATO-APOL AND COD_PRODUTO = :EF148-COD-PRODUTO AND COD_COBERTURA = :EF148-COD-COBERTURA AND DTH_INI_VIGENCIA = :EF148-DTH-INI-VIGENCIA END-EXEC */

            var p030_DEL_PROC_DB_DELETE_1_Delete1 = new P030_DEL_PROC_DB_DELETE_1_Delete1()
            {
                EF148_NUM_CONTRATO_APOL = EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_CONTRATO_APOL.ToString(),
                EF148_COD_PRODUTO = EF148.DCLEF_PROD_ACESSORIO.EF148_COD_PRODUTO.ToString(),
                EF148_COD_COBERTURA = EF148.DCLEF_PROD_ACESSORIO.EF148_COD_COBERTURA.ToString(),
                EF148_DTH_INI_VIGENCIA = EF148.DCLEF_PROD_ACESSORIO.EF148_DTH_INI_VIGENCIA.ToString(),
            };

            P030_DEL_PROC_DB_DELETE_1_Delete1.Execute(p030_DEL_PROC_DB_DELETE_1_Delete1);

        }

        [StopWatch]
        /*" P040-SEL-PROC */
        private void P040_SEL_PROC(bool isPerform = false)
        {
            /*" -228- PERFORM P040_SEL_PROC_DB_SELECT_1 */

            P040_SEL_PROC_DB_SELECT_1();

            /*" -229- . */

        }

        [StopWatch]
        /*" P040-SEL-PROC-DB-SELECT-1 */
        public void P040_SEL_PROC_DB_SELECT_1()
        {
            /*" -228- EXEC SQL SELECT NUM_CONTRATO_APOL , COD_PRODUTO , COD_COBERTURA , DTH_INI_VIGENCIA , NUM_RAMO_CONTABIL , COD_PRODUTO_ACESS , COD_COBERTURA_ACESS , NUM_APOLICE , DTH_FIM_VIGENCIA INTO :EF148-NUM-CONTRATO-APOL , :EF148-COD-PRODUTO , :EF148-COD-COBERTURA , :EF148-DTH-INI-VIGENCIA , :EF148-NUM-RAMO-CONTABIL , :EF148-COD-PRODUTO-ACESS , :EF148-COD-COBERTURA-ACESS , :EF148-NUM-APOLICE , :EF148-DTH-FIM-VIGENCIA :WS-DTH-FIM-VIGENCIA-NULL FROM SEGUROS.EF_PROD_ACESSORIO WHERE NUM_CONTRATO_APOL = :EF148-NUM-CONTRATO-APOL AND COD_PRODUTO = :EF148-COD-PRODUTO AND COD_COBERTURA = :EF148-COD-COBERTURA AND :EF148-DTH-INI-VIGENCIA BETWEEN DTH_INI_VIGENCIA AND DTH_FIM_VIGENCIA WITH UR END-EXEC */

            var p040_SEL_PROC_DB_SELECT_1_Query1 = new P040_SEL_PROC_DB_SELECT_1_Query1()
            {
                EF148_NUM_CONTRATO_APOL = EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_CONTRATO_APOL.ToString(),
                EF148_DTH_INI_VIGENCIA = EF148.DCLEF_PROD_ACESSORIO.EF148_DTH_INI_VIGENCIA.ToString(),
                EF148_COD_COBERTURA = EF148.DCLEF_PROD_ACESSORIO.EF148_COD_COBERTURA.ToString(),
                EF148_COD_PRODUTO = EF148.DCLEF_PROD_ACESSORIO.EF148_COD_PRODUTO.ToString(),
            };

            var executed_1 = P040_SEL_PROC_DB_SELECT_1_Query1.Execute(p040_SEL_PROC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EF148_NUM_CONTRATO_APOL, EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_CONTRATO_APOL);
                _.Move(executed_1.EF148_COD_PRODUTO, EF148.DCLEF_PROD_ACESSORIO.EF148_COD_PRODUTO);
                _.Move(executed_1.EF148_COD_COBERTURA, EF148.DCLEF_PROD_ACESSORIO.EF148_COD_COBERTURA);
                _.Move(executed_1.EF148_DTH_INI_VIGENCIA, EF148.DCLEF_PROD_ACESSORIO.EF148_DTH_INI_VIGENCIA);
                _.Move(executed_1.EF148_NUM_RAMO_CONTABIL, EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_RAMO_CONTABIL);
                _.Move(executed_1.EF148_COD_PRODUTO_ACESS, EF148.DCLEF_PROD_ACESSORIO.EF148_COD_PRODUTO_ACESS);
                _.Move(executed_1.EF148_COD_COBERTURA_ACESS, EF148.DCLEF_PROD_ACESSORIO.EF148_COD_COBERTURA_ACESS);
                _.Move(executed_1.EF148_NUM_APOLICE, EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_APOLICE);
                _.Move(executed_1.EF148_DTH_FIM_VIGENCIA, EF148.DCLEF_PROD_ACESSORIO.EF148_DTH_FIM_VIGENCIA);
                _.Move(executed_1.WS_DTH_FIM_VIGENCIA_NULL, WS_DTH_FIM_VIGENCIA_NULL);
            }


        }

        [StopWatch]
        /*" P041-SEL-PROC */
        private void P041_SEL_PROC(bool isPerform = false)
        {
            /*" -265- PERFORM P041_SEL_PROC_DB_SELECT_1 */

            P041_SEL_PROC_DB_SELECT_1();

            /*" -266- . */

        }

        [StopWatch]
        /*" P041-SEL-PROC-DB-SELECT-1 */
        public void P041_SEL_PROC_DB_SELECT_1()
        {
            /*" -265- EXEC SQL SELECT EPA.NUM_CONTRATO_APOL ,EPA.COD_PRODUTO ,EPA.COD_COBERTURA ,EPA.DTH_INI_VIGENCIA ,EPA.NUM_RAMO_CONTABIL ,EPA.COD_PRODUTO_ACESS ,EPA.COD_COBERTURA_ACESS ,EPA.NUM_APOLICE ,EPA.DTH_FIM_VIGENCIA ,EA.NUM_APOLICE INTO :EF148-NUM-CONTRATO-APOL , :EF148-COD-PRODUTO , :EF148-COD-COBERTURA , :EF148-DTH-INI-VIGENCIA , :EF148-NUM-RAMO-CONTABIL , :EF148-COD-PRODUTO-ACESS , :EF148-COD-COBERTURA-ACESS , :EF148-NUM-APOLICE , :EF148-DTH-FIM-VIGENCIA :WS-DTH-FIM-VIGENCIA-NULL , :EF148-NUM-APOLICE-EF FROM SEGUROS.EF_PROD_ACESSORIO EPA , SEGUROS.EF_APOLICE EA WHERE EPA.NUM_APOLICE = :EF148-NUM-APOLICE AND EPA.COD_PRODUTO_ACESS = :EF148-COD-PRODUTO-ACESS AND :EF148-DTH-INI-VIGENCIA BETWEEN EPA.DTH_INI_VIGENCIA AND EPA.DTH_FIM_VIGENCIA AND EA.NUM_CONTRATO = EPA.NUM_CONTRATO_APOL FETCH FIRST 1 ROW ONLY WITH UR END-EXEC */

            var p041_SEL_PROC_DB_SELECT_1_Query1 = new P041_SEL_PROC_DB_SELECT_1_Query1()
            {
                EF148_COD_PRODUTO_ACESS = EF148.DCLEF_PROD_ACESSORIO.EF148_COD_PRODUTO_ACESS.ToString(),
                EF148_DTH_INI_VIGENCIA = EF148.DCLEF_PROD_ACESSORIO.EF148_DTH_INI_VIGENCIA.ToString(),
                EF148_NUM_APOLICE = EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_APOLICE.ToString(),
            };

            var executed_1 = P041_SEL_PROC_DB_SELECT_1_Query1.Execute(p041_SEL_PROC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EF148_NUM_CONTRATO_APOL, EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_CONTRATO_APOL);
                _.Move(executed_1.EF148_COD_PRODUTO, EF148.DCLEF_PROD_ACESSORIO.EF148_COD_PRODUTO);
                _.Move(executed_1.EF148_COD_COBERTURA, EF148.DCLEF_PROD_ACESSORIO.EF148_COD_COBERTURA);
                _.Move(executed_1.EF148_DTH_INI_VIGENCIA, EF148.DCLEF_PROD_ACESSORIO.EF148_DTH_INI_VIGENCIA);
                _.Move(executed_1.EF148_NUM_RAMO_CONTABIL, EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_RAMO_CONTABIL);
                _.Move(executed_1.EF148_COD_PRODUTO_ACESS, EF148.DCLEF_PROD_ACESSORIO.EF148_COD_PRODUTO_ACESS);
                _.Move(executed_1.EF148_COD_COBERTURA_ACESS, EF148.DCLEF_PROD_ACESSORIO.EF148_COD_COBERTURA_ACESS);
                _.Move(executed_1.EF148_NUM_APOLICE, EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_APOLICE);
                _.Move(executed_1.EF148_DTH_FIM_VIGENCIA, EF148.DCLEF_PROD_ACESSORIO.EF148_DTH_FIM_VIGENCIA);
                _.Move(executed_1.WS_DTH_FIM_VIGENCIA_NULL, WS_DTH_FIM_VIGENCIA_NULL);
                _.Move(executed_1.EF148_NUM_APOLICE_EF, EF148_NUM_APOLICE_EF);
            }


        }

        [StopWatch]
        /*" P050-INI-VAR-UPD */
        private void P050_INI_VAR_UPD(bool isPerform = false)
        {
            /*" -273- IF ( LK-NUM-CONTRATO-APOL NOT EQUAL EF148-NUM-CONTRATO-APOL AND LK-NUM-CONTRATO-APOL NOT EQUAL ZEROS ) THEN */

            if ((LINKAGE_EF148S.LK_NUM_CONTRATO_APOL != EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_CONTRATO_APOL && LINKAGE_EF148S.LK_NUM_CONTRATO_APOL != 00))
            {

                /*" -275- MOVE LK-NUM-CONTRATO-APOL TO EF148-NUM-CONTRATO-APOL */
                _.Move(LINKAGE_EF148S.LK_NUM_CONTRATO_APOL, EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_CONTRATO_APOL);

                /*" -277- END-IF */
            }


            /*" -280- IF ( LK-COD-PRODUTO NOT EQUAL EF148-COD-PRODUTO AND LK-COD-PRODUTO NOT EQUAL ZEROS ) THEN */

            if ((LINKAGE_EF148S.LK_COD_PRODUTO != EF148.DCLEF_PROD_ACESSORIO.EF148_COD_PRODUTO && LINKAGE_EF148S.LK_COD_PRODUTO != 00))
            {

                /*" -282- MOVE LK-COD-PRODUTO TO EF148-COD-PRODUTO */
                _.Move(LINKAGE_EF148S.LK_COD_PRODUTO, EF148.DCLEF_PROD_ACESSORIO.EF148_COD_PRODUTO);

                /*" -284- END-IF */
            }


            /*" -287- IF ( LK-COD-COBERTURA NOT EQUAL EF148-COD-COBERTURA AND LK-COD-COBERTURA NOT EQUAL ZEROS ) THEN */

            if ((LINKAGE_EF148S.LK_COD_COBERTURA != EF148.DCLEF_PROD_ACESSORIO.EF148_COD_COBERTURA && LINKAGE_EF148S.LK_COD_COBERTURA != 00))
            {

                /*" -289- MOVE LK-COD-COBERTURA TO EF148-COD-COBERTURA */
                _.Move(LINKAGE_EF148S.LK_COD_COBERTURA, EF148.DCLEF_PROD_ACESSORIO.EF148_COD_COBERTURA);

                /*" -291- END-IF */
            }


            /*" -294- IF ( LK-DTH-INI-VIGENCIA NOT EQUAL EF148-DTH-INI-VIGENCIA AND LK-DTH-INI-VIGENCIA NOT EQUAL SPACES ) THEN */

            if ((LINKAGE_EF148S.LK_DTH_INI_VIGENCIA != EF148.DCLEF_PROD_ACESSORIO.EF148_DTH_INI_VIGENCIA && !LINKAGE_EF148S.LK_DTH_INI_VIGENCIA.IsEmpty()))
            {

                /*" -296- MOVE LK-DTH-INI-VIGENCIA TO EF148-DTH-INI-VIGENCIA */
                _.Move(LINKAGE_EF148S.LK_DTH_INI_VIGENCIA, EF148.DCLEF_PROD_ACESSORIO.EF148_DTH_INI_VIGENCIA);

                /*" -298- END-IF */
            }


            /*" -301- IF ( LK-NUM-RAMO-CONTABIL NOT EQUAL EF148-NUM-RAMO-CONTABIL AND LK-NUM-RAMO-CONTABIL NOT EQUAL ZEROS ) THEN */

            if ((LINKAGE_EF148S.LK_NUM_RAMO_CONTABIL != EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_RAMO_CONTABIL && LINKAGE_EF148S.LK_NUM_RAMO_CONTABIL != 00))
            {

                /*" -303- MOVE LK-NUM-RAMO-CONTABIL TO EF148-NUM-RAMO-CONTABIL */
                _.Move(LINKAGE_EF148S.LK_NUM_RAMO_CONTABIL, EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_RAMO_CONTABIL);

                /*" -305- END-IF */
            }


            /*" -308- IF ( LK-COD-PRODUTO-ACESS NOT EQUAL EF148-COD-PRODUTO-ACESS AND LK-COD-PRODUTO-ACESS NOT EQUAL ZEROS ) THEN */

            if ((LINKAGE_EF148S.LK_COD_PRODUTO_ACESS != EF148.DCLEF_PROD_ACESSORIO.EF148_COD_PRODUTO_ACESS && LINKAGE_EF148S.LK_COD_PRODUTO_ACESS != 00))
            {

                /*" -310- MOVE LK-COD-PRODUTO-ACESS TO EF148-COD-PRODUTO-ACESS */
                _.Move(LINKAGE_EF148S.LK_COD_PRODUTO_ACESS, EF148.DCLEF_PROD_ACESSORIO.EF148_COD_PRODUTO_ACESS);

                /*" -312- END-IF */
            }


            /*" -315- IF ( LK-COD-COBERTURA-ACESS NOT EQUAL EF148-COD-COBERTURA-ACESS AND LK-COD-COBERTURA-ACESS NOT EQUAL ZEROS ) THEN */

            if ((LINKAGE_EF148S.LK_COD_COBERTURA_ACESS != EF148.DCLEF_PROD_ACESSORIO.EF148_COD_COBERTURA_ACESS && LINKAGE_EF148S.LK_COD_COBERTURA_ACESS != 00))
            {

                /*" -317- MOVE LK-COD-COBERTURA-ACESS TO EF148-COD-COBERTURA-ACESS */
                _.Move(LINKAGE_EF148S.LK_COD_COBERTURA_ACESS, EF148.DCLEF_PROD_ACESSORIO.EF148_COD_COBERTURA_ACESS);

                /*" -319- END-IF */
            }


            /*" -322- IF ( LK-NUM-APOLICE NOT EQUAL EF148-NUM-APOLICE AND LK-NUM-APOLICE NOT EQUAL ZEROS ) THEN */

            if ((LINKAGE_EF148S.LK_NUM_APOLICE != EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_APOLICE && LINKAGE_EF148S.LK_NUM_APOLICE != 00))
            {

                /*" -324- MOVE LK-NUM-APOLICE TO EF148-NUM-APOLICE */
                _.Move(LINKAGE_EF148S.LK_NUM_APOLICE, EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_APOLICE);

                /*" -326- END-IF */
            }


            /*" -329- IF ( LK-DTH-FIM-VIGENCIA NOT EQUAL EF148-DTH-FIM-VIGENCIA AND LK-DTH-FIM-VIGENCIA NOT EQUAL SPACES ) THEN */

            if ((LINKAGE_EF148S.LK_DTH_FIM_VIGENCIA != EF148.DCLEF_PROD_ACESSORIO.EF148_DTH_FIM_VIGENCIA && !LINKAGE_EF148S.LK_DTH_FIM_VIGENCIA.IsEmpty()))
            {

                /*" -331- MOVE LK-DTH-FIM-VIGENCIA TO EF148-DTH-FIM-VIGENCIA */
                _.Move(LINKAGE_EF148S.LK_DTH_FIM_VIGENCIA, EF148.DCLEF_PROD_ACESSORIO.EF148_DTH_FIM_VIGENCIA);

                /*" -332- END-IF */
            }


            /*" -332- . */

        }

        [StopWatch]
        /*" P060-TRA-VAR-LINKAGE */
        private void P060_TRA_VAR_LINKAGE(bool isPerform = false)
        {
            /*" -337- MOVE EF148-NUM-CONTRATO-APOL TO LK-NUM-CONTRATO-APOL */
            _.Move(EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_CONTRATO_APOL, LINKAGE_EF148S.LK_NUM_CONTRATO_APOL);

            /*" -339- MOVE EF148-COD-PRODUTO TO LK-COD-PRODUTO */
            _.Move(EF148.DCLEF_PROD_ACESSORIO.EF148_COD_PRODUTO, LINKAGE_EF148S.LK_COD_PRODUTO);

            /*" -341- MOVE EF148-COD-COBERTURA TO LK-COD-COBERTURA */
            _.Move(EF148.DCLEF_PROD_ACESSORIO.EF148_COD_COBERTURA, LINKAGE_EF148S.LK_COD_COBERTURA);

            /*" -343- MOVE EF148-DTH-INI-VIGENCIA TO LK-DTH-INI-VIGENCIA */
            _.Move(EF148.DCLEF_PROD_ACESSORIO.EF148_DTH_INI_VIGENCIA, LINKAGE_EF148S.LK_DTH_INI_VIGENCIA);

            /*" -345- MOVE EF148-NUM-RAMO-CONTABIL TO LK-NUM-RAMO-CONTABIL */
            _.Move(EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_RAMO_CONTABIL, LINKAGE_EF148S.LK_NUM_RAMO_CONTABIL);

            /*" -347- MOVE EF148-COD-PRODUTO-ACESS TO LK-COD-PRODUTO-ACESS */
            _.Move(EF148.DCLEF_PROD_ACESSORIO.EF148_COD_PRODUTO_ACESS, LINKAGE_EF148S.LK_COD_PRODUTO_ACESS);

            /*" -349- MOVE EF148-COD-COBERTURA-ACESS TO LK-COD-COBERTURA-ACESS */
            _.Move(EF148.DCLEF_PROD_ACESSORIO.EF148_COD_COBERTURA_ACESS, LINKAGE_EF148S.LK_COD_COBERTURA_ACESS);

            /*" -351- MOVE EF148-NUM-APOLICE TO LK-NUM-APOLICE */
            _.Move(EF148.DCLEF_PROD_ACESSORIO.EF148_NUM_APOLICE, LINKAGE_EF148S.LK_NUM_APOLICE);

            /*" -353- MOVE EF148-DTH-FIM-VIGENCIA TO LK-DTH-FIM-VIGENCIA */
            _.Move(EF148.DCLEF_PROD_ACESSORIO.EF148_DTH_FIM_VIGENCIA, LINKAGE_EF148S.LK_DTH_FIM_VIGENCIA);

            /*" -355- MOVE EF148-NUM-APOLICE-EF TO LK-NUM-APOLICE-EF */
            _.Move(EF148_NUM_APOLICE_EF, LINKAGE_EF148S.LK_NUM_APOLICE_EF);

            /*" -355- . */

        }

        [StopWatch]
        /*" P070-VER-CMP-NULOS */
        private void P070_VER_CMP_NULOS(bool isPerform = false)
        {
            /*" -359- IF ( EF148-DTH-FIM-VIGENCIA EQUAL SPACES ) THEN */

            if ((EF148.DCLEF_PROD_ACESSORIO.EF148_DTH_FIM_VIGENCIA.IsEmpty()))
            {

                /*" -360- MOVE -1 TO WS-DTH-FIM-VIGENCIA-NULL */
                _.Move(-1, WS_DTH_FIM_VIGENCIA_NULL);

                /*" -361- ELSE */
            }
            else
            {


                /*" -362- MOVE 0 TO WS-DTH-FIM-VIGENCIA-NULL */
                _.Move(0, WS_DTH_FIM_VIGENCIA_NULL);

                /*" -363- END-IF */
            }


            /*" -363- . */

        }

        [StopWatch]
        /*" P080-VER-SAIDA-CMP-NULOS */
        private void P080_VER_SAIDA_CMP_NULOS(bool isPerform = false)
        {
            /*" -367- IF ( WS-DTH-FIM-VIGENCIA-NULL NOT EQUAL ZEROS ) THEN */

            if ((WS_DTH_FIM_VIGENCIA_NULL != 00))
            {

                /*" -369- MOVE SPACES TO LK-DTH-FIM-VIGENCIA */
                _.Move("", LINKAGE_EF148S.LK_DTH_FIM_VIGENCIA);

                /*" -370- END-IF */
            }


            /*" -370- . */

        }

        [StopWatch]
        /*" P910-DB2-ERRO */
        private void P910_DB2_ERRO(bool isPerform = false)
        {
            /*" -374- MOVE SQLCODE TO LK-RETORNO */
            _.Move(DB.SQLCODE, LINKAGE_EF148S.LK_RETORNO);

            /*" -380- STRING '* ' WS-PROGRAMA ' SQLCODE: ' LK-RETORNO ' SQLERRMC: ' SQLERRMC ' OPERACAO: ' WS-OPERACAO DELIMITED BY SIZE INTO WS-OCORRENCIA END-STRING */
            #region STRING
            var spl1 = "* " + WS_PROGRAMA.GetMoveValues();
            spl1 += " SQLCODE: ";
            var spl2 = LINKAGE_EF148S.LK_RETORNO.GetMoveValues();
            spl2 += " SQLERRMC: ";
            var spl3 = DB.SQLERRMC.GetMoveValues();
            spl3 += " OPERACAO: ";
            var spl4 = WS_OPERACAO.GetMoveValues();
            var results5 = spl1 + spl2 + spl3 + spl4;
            _.Move(results5, WS_OCORRENCIA);
            #endregion

            /*" -381- DISPLAY WS-OCORRENCIA */
            _.Display(WS_OCORRENCIA);

            /*" -383- DISPLAY 'LK-NUM-CONTRATO-APOL: ' LK-NUM-CONTRATO-APOL */
            _.Display($"LK-NUM-CONTRATO-APOL: {LINKAGE_EF148S.LK_NUM_CONTRATO_APOL}");

            /*" -385- DISPLAY 'LK-COD-PRODUTO: ' LK-COD-PRODUTO */
            _.Display($"LK-COD-PRODUTO: {LINKAGE_EF148S.LK_COD_PRODUTO}");

            /*" -387- DISPLAY 'LK-COD-COBERTURA: ' LK-COD-COBERTURA */
            _.Display($"LK-COD-COBERTURA: {LINKAGE_EF148S.LK_COD_COBERTURA}");

            /*" -389- DISPLAY 'LK-DTH-INI-VIGENCIA: ' LK-DTH-INI-VIGENCIA */
            _.Display($"LK-DTH-INI-VIGENCIA: {LINKAGE_EF148S.LK_DTH_INI_VIGENCIA}");

            /*" -391- DISPLAY 'LK-NUM-RAMO-CONTABIL: ' LK-NUM-RAMO-CONTABIL */
            _.Display($"LK-NUM-RAMO-CONTABIL: {LINKAGE_EF148S.LK_NUM_RAMO_CONTABIL}");

            /*" -393- DISPLAY 'LK-COD-PRODUTO-ACESS: ' LK-COD-PRODUTO-ACESS */
            _.Display($"LK-COD-PRODUTO-ACESS: {LINKAGE_EF148S.LK_COD_PRODUTO_ACESS}");

            /*" -395- DISPLAY 'LK-COD-COBERTURA-ACESS: ' LK-COD-COBERTURA-ACESS */
            _.Display($"LK-COD-COBERTURA-ACESS: {LINKAGE_EF148S.LK_COD_COBERTURA_ACESS}");

            /*" -397- DISPLAY 'LK-NUM-APOLICE: ' LK-NUM-APOLICE */
            _.Display($"LK-NUM-APOLICE: {LINKAGE_EF148S.LK_NUM_APOLICE}");

            /*" -399- DISPLAY 'LK-DTH-FIM-VIGENCIA: ' LK-DTH-FIM-VIGENCIA */
            _.Display($"LK-DTH-FIM-VIGENCIA: {LINKAGE_EF148S.LK_DTH_FIM_VIGENCIA}");

            /*" -400- GOBACK */

            throw new GoBack();

            /*" -400- . */

        }
    }
}