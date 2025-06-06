using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0048B
{
    public class R2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1_Query1 : QueryBasis<R2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(NUM_CONTRATO,0)
            INTO :SINIPENH-NUM-CONTRATO
            FROM SEGUROS.SINI_PENHOR01
            WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(NUM_CONTRATO
							,0)
											FROM SEGUROS.SINI_PENHOR01
											WHERE NUM_APOL_SINISTRO = '{this.SINISMES_NUM_APOL_SINISTRO}'
											WITH UR";

            return query;
        }
        public string SINIPENH_NUM_CONTRATO { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }

        public static R2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1_Query1 Execute(R2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1_Query1 r2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1_Query1)
        {
            var ths = r2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINIPENH_NUM_CONTRATO = result[i++].Value?.ToString();
            return dta;
        }

    }
}