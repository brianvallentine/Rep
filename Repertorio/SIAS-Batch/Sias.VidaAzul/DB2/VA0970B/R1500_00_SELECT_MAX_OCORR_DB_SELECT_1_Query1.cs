using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0970B
{
    public class R1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1 : QueryBasis<R1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(OCORR_HISTORICO)
            INTO :WHOST-MAX-OCORR
            FROM SEGUROS.SINISTRO_HISTORICO
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(OCORR_HISTORICO)
											FROM SEGUROS.SINISTRO_HISTORICO
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'";

            return query;
        }
        public string WHOST_MAX_OCORR { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1 Execute(R1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1 r1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1)
        {
            var ths = r1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_MAX_OCORR = result[i++].Value?.ToString();
            return dta;
        }

    }
}