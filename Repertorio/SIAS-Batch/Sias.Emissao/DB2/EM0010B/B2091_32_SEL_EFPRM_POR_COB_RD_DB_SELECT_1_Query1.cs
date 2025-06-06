using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class B2091_32_SEL_EFPRM_POR_COB_RD_DB_SELECT_1_Query1 : QueryBasis<B2091_32_SEL_EFPRM_POR_COB_RD_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VALUE(SUM(CASE WHEN EF066.IND_TIPO_PREMIO = 1
            OR EF066.IND_TIPO_PREMIO = 3
            THEN EF157.VLR_PREMIO_ACESS
            + EF157.VLR_IOF_ACESS
            ELSE 0
            END),0) VLR_EMISSAO_A_14
            ,(VALUE(SUM(CASE WHEN EF066.IND_TIPO_PREMIO = 2
            THEN EF157.VLR_PREMIO_ACESS
            + EF157.VLR_IOF_ACESS
            ELSE 0
            END),0) * -1) VLR_CREDITO_A_14
            ,VALUE(SUM(CASE WHEN EF066.IND_TIPO_PREMIO = 1
            OR EF066.IND_TIPO_PREMIO = 3
            THEN EF157.VLR_IOF_ACESS
            ELSE 0
            END),0) VLR_IOF_EMISSAO_A_14
            ,(VALUE(SUM(CASE WHEN EF066.IND_TIPO_PREMIO = 2
            THEN EF157.VLR_IOF_ACESS
            ELSE 0
            END),0) * -1) VLR_IOF_CREDITO_A_14
            INTO :WS-EF-VLR-EMISSAO-14 ,
            :WS-EF-VLR-CREDITO-14 ,
            :WS-EF-IOF-EMISSAO-14 ,
            :WS-EF-IOF-CREDITO-14
            FROM SEGUROS.EF_ENDOSSO EF053
            JOIN SEGUROS.EF_FATURAS_ENDOSSO EF054
            ON EF054.NUM_ENDOSSO = EF053.NUM_ENDOSSO
            AND EF054.NUM_CONTRATO_FATUR = EF053.NUM_CONTRATO
            JOIN SEGUROS.EF_FATURA EF056
            ON EF056.NUM_CONTRATO = EF054.NUM_CONTRATO_FATUR
            AND EF056.SEQ_OPERACAO = EF054.SEQ_OPERACAO_FATUR
            JOIN SEGUROS.EF_APOLICE EF063
            ON EF063.NUM_CONTRATO = EF054.NUM_CONTRATO_FATUR
            JOIN SEGUROS.EF_PROD_ACESSORIO EF148
            ON EF148.NUM_CONTRATO_APOL = EF056.NUM_CONTRATO
            AND EF148.COD_PRODUTO = EF056.COD_PRODUTO
            AND EF148.COD_COBERTURA = EF056.COD_COBERTURA
            AND EF056.DTH_REFERENCIA BETWEEN EF148.DTH_INI_VIGENCIA
            AND EF148.DTH_FIM_VIGENCIA
            JOIN SEGUROS.ENDOSSOS ENDOS
            ON ENDOS.NUM_ENDOSSO = EF053.NUM_ENDOSSO
            AND ENDOS.NUM_APOLICE = EF148.NUM_APOLICE
            JOIN SEGUROS.EF_PREMIOS_FATURA EF060
            ON EF060.NUM_CONTRATO_APOL = EF056.NUM_CONTRATO
            AND EF060.SEQ_OPERACAO_FATUR = EF056.SEQ_OPERACAO
            JOIN SEGUROS.EF_PREMIO_EMITIDO EF066
            ON EF066.NUM_CONTRATO_SEGUR = EF060.NUM_CONTRATO_SEGUR
            AND EF066.SEQ_PREMIO = EF060.SEQ_PREMIO
            JOIN SEGUROS.EF_PREMIO_COB_ACESS EF157
            ON EF157.NUM_CONTRATO_SEGUR = EF066.NUM_CONTRATO_SEGUR
            AND EF157.SEQ_PREMIO = EF066.SEQ_PREMIO
            AND EF157.COD_COB_ACESS = EF148.COD_COBERTURA_ACESS
            WHERE EF053.NUM_ENDOSSO = :ENDO-NRENDOS
            AND EF148.NUM_APOLICE = :ENDO-NUM-APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(CASE WHEN EF066.IND_TIPO_PREMIO = 1
											OR EF066.IND_TIPO_PREMIO = 3
											THEN EF157.VLR_PREMIO_ACESS
											+ EF157.VLR_IOF_ACESS
											ELSE 0
											END)
							,0) VLR_EMISSAO_A_14
											,(VALUE(SUM(CASE WHEN EF066.IND_TIPO_PREMIO = 2
											THEN EF157.VLR_PREMIO_ACESS
											+ EF157.VLR_IOF_ACESS
											ELSE 0
											END)
							,0) * -1) VLR_CREDITO_A_14
											,VALUE(SUM(CASE WHEN EF066.IND_TIPO_PREMIO = 1
											OR EF066.IND_TIPO_PREMIO = 3
											THEN EF157.VLR_IOF_ACESS
											ELSE 0
											END)
							,0) VLR_IOF_EMISSAO_A_14
											,(VALUE(SUM(CASE WHEN EF066.IND_TIPO_PREMIO = 2
											THEN EF157.VLR_IOF_ACESS
											ELSE 0
											END)
							,0) * -1) VLR_IOF_CREDITO_A_14
											FROM SEGUROS.EF_ENDOSSO EF053
											JOIN SEGUROS.EF_FATURAS_ENDOSSO EF054
											ON EF054.NUM_ENDOSSO = EF053.NUM_ENDOSSO
											AND EF054.NUM_CONTRATO_FATUR = EF053.NUM_CONTRATO
											JOIN SEGUROS.EF_FATURA EF056
											ON EF056.NUM_CONTRATO = EF054.NUM_CONTRATO_FATUR
											AND EF056.SEQ_OPERACAO = EF054.SEQ_OPERACAO_FATUR
											JOIN SEGUROS.EF_APOLICE EF063
											ON EF063.NUM_CONTRATO = EF054.NUM_CONTRATO_FATUR
											JOIN SEGUROS.EF_PROD_ACESSORIO EF148
											ON EF148.NUM_CONTRATO_APOL = EF056.NUM_CONTRATO
											AND EF148.COD_PRODUTO = EF056.COD_PRODUTO
											AND EF148.COD_COBERTURA = EF056.COD_COBERTURA
											AND EF056.DTH_REFERENCIA BETWEEN EF148.DTH_INI_VIGENCIA
											AND EF148.DTH_FIM_VIGENCIA
											JOIN SEGUROS.ENDOSSOS ENDOS
											ON ENDOS.NUM_ENDOSSO = EF053.NUM_ENDOSSO
											AND ENDOS.NUM_APOLICE = EF148.NUM_APOLICE
											JOIN SEGUROS.EF_PREMIOS_FATURA EF060
											ON EF060.NUM_CONTRATO_APOL = EF056.NUM_CONTRATO
											AND EF060.SEQ_OPERACAO_FATUR = EF056.SEQ_OPERACAO
											JOIN SEGUROS.EF_PREMIO_EMITIDO EF066
											ON EF066.NUM_CONTRATO_SEGUR = EF060.NUM_CONTRATO_SEGUR
											AND EF066.SEQ_PREMIO = EF060.SEQ_PREMIO
											JOIN SEGUROS.EF_PREMIO_COB_ACESS EF157
											ON EF157.NUM_CONTRATO_SEGUR = EF066.NUM_CONTRATO_SEGUR
											AND EF157.SEQ_PREMIO = EF066.SEQ_PREMIO
											AND EF157.COD_COB_ACESS = EF148.COD_COBERTURA_ACESS
											WHERE EF053.NUM_ENDOSSO = '{this.ENDO_NRENDOS}'
											AND EF148.NUM_APOLICE = '{this.ENDO_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string WS_EF_VLR_EMISSAO_14 { get; set; }
        public string WS_EF_VLR_CREDITO_14 { get; set; }
        public string WS_EF_IOF_EMISSAO_14 { get; set; }
        public string WS_EF_IOF_CREDITO_14 { get; set; }
        public string ENDO_NUM_APOLICE { get; set; }
        public string ENDO_NRENDOS { get; set; }

        public static B2091_32_SEL_EFPRM_POR_COB_RD_DB_SELECT_1_Query1 Execute(B2091_32_SEL_EFPRM_POR_COB_RD_DB_SELECT_1_Query1 b2091_32_SEL_EFPRM_POR_COB_RD_DB_SELECT_1_Query1)
        {
            var ths = b2091_32_SEL_EFPRM_POR_COB_RD_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B2091_32_SEL_EFPRM_POR_COB_RD_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B2091_32_SEL_EFPRM_POR_COB_RD_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_EF_VLR_EMISSAO_14 = result[i++].Value?.ToString();
            dta.WS_EF_VLR_CREDITO_14 = result[i++].Value?.ToString();
            dta.WS_EF_IOF_EMISSAO_14 = result[i++].Value?.ToString();
            dta.WS_EF_IOF_CREDITO_14 = result[i++].Value?.ToString();
            return dta;
        }

    }
}