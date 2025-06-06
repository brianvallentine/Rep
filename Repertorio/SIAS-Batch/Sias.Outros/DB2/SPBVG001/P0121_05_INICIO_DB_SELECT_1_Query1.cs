using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG001
{
    public class P0121_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0121_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VG099.DES_STA_CRITICA
            INTO :VG099-DES-STA-CRITICA
            FROM SEGUROS.VG_DM_STA_CRITICA VG099
            WHERE VG099.STA_CRITICA = :VG099-STA-CRITICA
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VG099.DES_STA_CRITICA
											FROM SEGUROS.VG_DM_STA_CRITICA VG099
											WHERE VG099.STA_CRITICA = '{this.VG099_STA_CRITICA}'";

            return query;
        }
        public string VG099_DES_STA_CRITICA { get; set; }
        public string VG099_STA_CRITICA { get; set; }

        public static P0121_05_INICIO_DB_SELECT_1_Query1 Execute(P0121_05_INICIO_DB_SELECT_1_Query1 p0121_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0121_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0121_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0121_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG099_DES_STA_CRITICA = result[i++].Value?.ToString();
            return dta;
        }

    }
}