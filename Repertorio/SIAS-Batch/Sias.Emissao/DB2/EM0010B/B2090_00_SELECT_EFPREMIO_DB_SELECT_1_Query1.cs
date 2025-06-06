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
    public class B2090_00_SELECT_EFPREMIO_DB_SELECT_1_Query1 : QueryBasis<B2090_00_SELECT_EFPREMIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(
            SUM(CASE WHEN PE.IND_TIPO_PREMIO = '1'
            OR PE.IND_TIPO_PREMIO = '3'
            THEN VALUE(VLR_PREMIO_TARIF, 0.0)
            ELSE 0
            END),0) CASE_VLR_EMISSAO
            ,VALUE(
            SUM(CASE WHEN PE.IND_TIPO_PREMIO = '2'
            THEN VALUE(VLR_PREMIO_TARIF, 0.0)
            ELSE 0
            END),0) CASE_VLR_CREDITO
            ,VALUE(
            SUM(CASE WHEN PE.IND_TIPO_PREMIO = '1'
            OR PE.IND_TIPO_PREMIO = '3'
            THEN VALUE(VLR_IOF, 0.0)
            ELSE 0
            END),0) CASE_VLR_IOF_EMIS
            ,VALUE(
            SUM(CASE WHEN PE.IND_TIPO_PREMIO = '2'
            THEN VALUE(VLR_IOF, 0.0)
            ELSE 0
            END),0) CASE_VLR_IOF_CRED
            INTO :WS-EF-VLR-EMISSAO ,
            :WS-EF-VLR-CREDITO ,
            :WS-EF-IOF-EMISSAO ,
            :WS-EF-IOF-CREDITO
            FROM SEGUROS.EF_ENDOSSO E,
            SEGUROS.EF_FATURAS_ENDOSSO FE,
            SEGUROS.EF_FATURA F,
            SEGUROS.EF_PREMIOS_FATURA PF,
            SEGUROS.EF_PREMIO_EMITIDO PE
            WHERE E.NUM_ENDOSSO = :ENDO-NRENDOS
            AND E.NUM_ENDOSSO = FE.NUM_ENDOSSO
            AND E.NUM_CONTRATO = FE.NUM_CONTRATO_FATUR
            AND FE.NUM_CONTRATO_FATUR = F.NUM_CONTRATO
            AND FE.SEQ_OPERACAO_FATUR = F.SEQ_OPERACAO
            AND F.COD_PRODUTO = :ENDO-CODPRODU
            AND F.NUM_CONTRATO = PF.NUM_CONTRATO_APOL
            AND F.SEQ_OPERACAO = PF.SEQ_OPERACAO_FATUR
            AND PF.NUM_CONTRATO_SEGUR = PE.NUM_CONTRATO_SEGUR
            AND PF.SEQ_PREMIO = PE.SEQ_PREMIO
            AND PF.NUM_CONTRATO_APOL = PF.NUM_CONTRATO_APOL
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(
											SUM(CASE WHEN PE.IND_TIPO_PREMIO = '1'
											OR PE.IND_TIPO_PREMIO = '3'
											THEN VALUE(VLR_PREMIO_TARIF
							, 0.0)
											ELSE 0
											END)
							,0) CASE_VLR_EMISSAO
											,VALUE(
											SUM(CASE WHEN PE.IND_TIPO_PREMIO = '2'
											THEN VALUE(VLR_PREMIO_TARIF
							, 0.0)
											ELSE 0
											END)
							,0) CASE_VLR_CREDITO
											,VALUE(
											SUM(CASE WHEN PE.IND_TIPO_PREMIO = '1'
											OR PE.IND_TIPO_PREMIO = '3'
											THEN VALUE(VLR_IOF
							, 0.0)
											ELSE 0
											END)
							,0) CASE_VLR_IOF_EMIS
											,VALUE(
											SUM(CASE WHEN PE.IND_TIPO_PREMIO = '2'
											THEN VALUE(VLR_IOF
							, 0.0)
											ELSE 0
											END)
							,0) CASE_VLR_IOF_CRED
											FROM SEGUROS.EF_ENDOSSO E
							,
											SEGUROS.EF_FATURAS_ENDOSSO FE
							,
											SEGUROS.EF_FATURA F
							,
											SEGUROS.EF_PREMIOS_FATURA PF
							,
											SEGUROS.EF_PREMIO_EMITIDO PE
											WHERE E.NUM_ENDOSSO = '{this.ENDO_NRENDOS}'
											AND E.NUM_ENDOSSO = FE.NUM_ENDOSSO
											AND E.NUM_CONTRATO = FE.NUM_CONTRATO_FATUR
											AND FE.NUM_CONTRATO_FATUR = F.NUM_CONTRATO
											AND FE.SEQ_OPERACAO_FATUR = F.SEQ_OPERACAO
											AND F.COD_PRODUTO = '{this.ENDO_CODPRODU}'
											AND F.NUM_CONTRATO = PF.NUM_CONTRATO_APOL
											AND F.SEQ_OPERACAO = PF.SEQ_OPERACAO_FATUR
											AND PF.NUM_CONTRATO_SEGUR = PE.NUM_CONTRATO_SEGUR
											AND PF.SEQ_PREMIO = PE.SEQ_PREMIO
											AND PF.NUM_CONTRATO_APOL = PF.NUM_CONTRATO_APOL
											WITH UR";

            return query;
        }
        public string WS_EF_VLR_EMISSAO { get; set; }
        public string WS_EF_VLR_CREDITO { get; set; }
        public string WS_EF_IOF_EMISSAO { get; set; }
        public string WS_EF_IOF_CREDITO { get; set; }
        public string ENDO_CODPRODU { get; set; }
        public string ENDO_NRENDOS { get; set; }

        public static B2090_00_SELECT_EFPREMIO_DB_SELECT_1_Query1 Execute(B2090_00_SELECT_EFPREMIO_DB_SELECT_1_Query1 b2090_00_SELECT_EFPREMIO_DB_SELECT_1_Query1)
        {
            var ths = b2090_00_SELECT_EFPREMIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B2090_00_SELECT_EFPREMIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B2090_00_SELECT_EFPREMIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_EF_VLR_EMISSAO = result[i++].Value?.ToString();
            dta.WS_EF_VLR_CREDITO = result[i++].Value?.ToString();
            dta.WS_EF_IOF_EMISSAO = result[i++].Value?.ToString();
            dta.WS_EF_IOF_CREDITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}