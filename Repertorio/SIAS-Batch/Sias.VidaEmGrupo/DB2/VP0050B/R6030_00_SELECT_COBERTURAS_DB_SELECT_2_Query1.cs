using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0050B
{
    public class R6030_00_SELECT_COBERTURAS_DB_SELECT_2_Query1 : QueryBasis<R6030_00_SELECT_COBERTURAS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLTITCAP
            INTO :V0COBP-VLTITCAP
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :V0SEGV-NRCERTIF
            AND DTINIVIG <= :V1RELA-DATA-REFER
            AND DTTERVIG >= :V1RELA-DATA-REFER
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VLTITCAP
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.V0SEGV_NRCERTIF}'
											AND DTINIVIG <= '{this.V1RELA_DATA_REFER}'
											AND DTTERVIG >= '{this.V1RELA_DATA_REFER}'";

            return query;
        }
        public string V0COBP_VLTITCAP { get; set; }
        public string V1RELA_DATA_REFER { get; set; }
        public string V0SEGV_NRCERTIF { get; set; }

        public static R6030_00_SELECT_COBERTURAS_DB_SELECT_2_Query1 Execute(R6030_00_SELECT_COBERTURAS_DB_SELECT_2_Query1 r6030_00_SELECT_COBERTURAS_DB_SELECT_2_Query1)
        {
            var ths = r6030_00_SELECT_COBERTURAS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6030_00_SELECT_COBERTURAS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6030_00_SELECT_COBERTURAS_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0COBP_VLTITCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}