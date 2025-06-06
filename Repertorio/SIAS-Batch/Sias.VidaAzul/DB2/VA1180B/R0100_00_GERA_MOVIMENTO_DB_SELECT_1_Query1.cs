using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1180B
{
    public class R0100_00_GERA_MOVIMENTO_DB_SELECT_1_Query1 : QueryBasis<R0100_00_GERA_MOVIMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT QTDE_TIT_CAPITALIZ,
            VAL_TIT_CAPITALIZ,
            VLPREMIO
            INTO :HISCOBPR-QTDE-TIT-CAPITALIZ,
            :HISCOBPR-VAL-TIT-CAPITALIZ,
            :HISCOBPR-VLPREMIO
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND DATA_TERVIGENCIA = '9999-12-31'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT QTDE_TIT_CAPITALIZ
							,
											VAL_TIT_CAPITALIZ
							,
											VLPREMIO
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND DATA_TERVIGENCIA = '9999-12-31'";

            return query;
        }
        public string HISCOBPR_QTDE_TIT_CAPITALIZ { get; set; }
        public string HISCOBPR_VAL_TIT_CAPITALIZ { get; set; }
        public string HISCOBPR_VLPREMIO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R0100_00_GERA_MOVIMENTO_DB_SELECT_1_Query1 Execute(R0100_00_GERA_MOVIMENTO_DB_SELECT_1_Query1 r0100_00_GERA_MOVIMENTO_DB_SELECT_1_Query1)
        {
            var ths = r0100_00_GERA_MOVIMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_00_GERA_MOVIMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_00_GERA_MOVIMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCOBPR_QTDE_TIT_CAPITALIZ = result[i++].Value?.ToString();
            dta.HISCOBPR_VAL_TIT_CAPITALIZ = result[i++].Value?.ToString();
            dta.HISCOBPR_VLPREMIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}