using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0105B
{
    public class R2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1 : QueryBasis<R2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            DATA_REFERENCIA
            INTO :V1FATC-NUM-APOLICE,
            :V1FATC-DATA-REFER
            FROM SEGUROS.V1FATURCONT
            WHERE NUM_APOLICE = :V1SOLF-NUM-APOL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											DATA_REFERENCIA
											FROM SEGUROS.V1FATURCONT
											WHERE NUM_APOLICE = '{this.V1SOLF_NUM_APOL}'";

            return query;
        }
        public string V1FATC_NUM_APOLICE { get; set; }
        public string V1FATC_DATA_REFER { get; set; }
        public string V1SOLF_NUM_APOL { get; set; }

        public static R2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1 Execute(R2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1 r2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1)
        {
            var ths = r2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2330_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1FATC_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V1FATC_DATA_REFER = result[i++].Value?.ToString();
            return dta;
        }

    }
}