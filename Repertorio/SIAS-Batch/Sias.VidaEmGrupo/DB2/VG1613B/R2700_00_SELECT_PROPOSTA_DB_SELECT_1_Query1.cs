using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class R2700_00_SELECT_PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<R2700_00_SELECT_PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            A.NUM_CERTIFICADO,
            B.DATA_INIVIGENCIA +
            :SUBGVGAP-PERI-FATURAMENTO MONTH,
            B.QUANT_VIDAS,
            B.VLPREMIO
            INTO
            :PROPOVA-NUM-CERTIFICADO ,
            :HISCOBPR-DATA-INIVIGENCIA,
            :HISCOBPR-QUANT-VIDAS,
            :HISCOBPR-VLPREMIO
            FROM SEGUROS.PROPOSTAS_VA A,
            SEGUROS.HIS_COBER_PROPOST B
            WHERE
            A.NUM_APOLICE = :SUBGVGAP-NUM-APOLICE
            AND A.COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO
            AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO
            AND B.OCORR_HISTORICO = A.OCORR_HISTORICO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											A.NUM_CERTIFICADO
							,
											B.DATA_INIVIGENCIA +
											{this.SUBGVGAP_PERI_FATURAMENTO} MONTH
							,
											B.QUANT_VIDAS
							,
											B.VLPREMIO
											FROM SEGUROS.PROPOSTAS_VA A
							,
											SEGUROS.HIS_COBER_PROPOST B
											WHERE
											A.NUM_APOLICE = '{this.SUBGVGAP_NUM_APOLICE}'
											AND A.COD_SUBGRUPO = '{this.SUBGVGAP_COD_SUBGRUPO}'
											AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO
											AND B.OCORR_HISTORICO = A.OCORR_HISTORICO
											WITH UR";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string HISCOBPR_DATA_INIVIGENCIA { get; set; }
        public string HISCOBPR_QUANT_VIDAS { get; set; }
        public string HISCOBPR_VLPREMIO { get; set; }
        public string SUBGVGAP_PERI_FATURAMENTO { get; set; }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }

        public static R2700_00_SELECT_PROPOSTA_DB_SELECT_1_Query1 Execute(R2700_00_SELECT_PROPOSTA_DB_SELECT_1_Query1 r2700_00_SELECT_PROPOSTA_DB_SELECT_1_Query1)
        {
            var ths = r2700_00_SELECT_PROPOSTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2700_00_SELECT_PROPOSTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2700_00_SELECT_PROPOSTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.HISCOBPR_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.HISCOBPR_QUANT_VIDAS = result[i++].Value?.ToString();
            dta.HISCOBPR_VLPREMIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}