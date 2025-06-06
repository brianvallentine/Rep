using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0031B
{
    public class R0224_50_OBTER_CONTA_CORR_DB_SELECT_1_Query1 : QueryBasis<R0224_50_OBTER_CONTA_CORR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_CLIENTE,
            NUM_APOLICE,
            NUM_CTA_CORRENTE,
            DAC_CTA_CORRENTE
            INTO
            :V0CTAC-COD-CLIENTE,
            :V0CTAC-NUM-APOLICE,
            :V0CTAC-NUM-CTA-COR,
            :V0CTAC-DAC-CTA-COR
            FROM
            SEGUROS.V1CONTACOR
            WHERE NUM_CERTIFICADO = :V0SEG-NUM-CERTIF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_CLIENTE
							,
											NUM_APOLICE
							,
											NUM_CTA_CORRENTE
							,
											DAC_CTA_CORRENTE
											FROM
											SEGUROS.V1CONTACOR
											WHERE NUM_CERTIFICADO = '{this.V0SEG_NUM_CERTIF}'";

            return query;
        }
        public string V0CTAC_COD_CLIENTE { get; set; }
        public string V0CTAC_NUM_APOLICE { get; set; }
        public string V0CTAC_NUM_CTA_COR { get; set; }
        public string V0CTAC_DAC_CTA_COR { get; set; }
        public string V0SEG_NUM_CERTIF { get; set; }

        public static R0224_50_OBTER_CONTA_CORR_DB_SELECT_1_Query1 Execute(R0224_50_OBTER_CONTA_CORR_DB_SELECT_1_Query1 r0224_50_OBTER_CONTA_CORR_DB_SELECT_1_Query1)
        {
            var ths = r0224_50_OBTER_CONTA_CORR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0224_50_OBTER_CONTA_CORR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0224_50_OBTER_CONTA_CORR_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CTAC_COD_CLIENTE = result[i++].Value?.ToString();
            dta.V0CTAC_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0CTAC_NUM_CTA_COR = result[i++].Value?.ToString();
            dta.V0CTAC_DAC_CTA_COR = result[i++].Value?.ToString();
            return dta;
        }

    }
}