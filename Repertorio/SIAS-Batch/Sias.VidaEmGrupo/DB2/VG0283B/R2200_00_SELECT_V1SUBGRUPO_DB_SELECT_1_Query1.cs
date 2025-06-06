using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0283B
{
    public class R2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1 : QueryBasis<R2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE
            INTO :V1SUBG-CODCLIEN
            FROM SEGUROS.V0SUBGRUPO
            WHERE NUM_APOLICE = :V1RELA-NUM-APOL
            AND COD_SUBGRUPO = :V1COMI-CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
											FROM SEGUROS.V0SUBGRUPO
											WHERE NUM_APOLICE = '{this.V1RELA_NUM_APOL}'
											AND COD_SUBGRUPO = '{this.V1COMI_CODSUBES}'";

            return query;
        }
        public string V1SUBG_CODCLIEN { get; set; }
        public string V1RELA_NUM_APOL { get; set; }
        public string V1COMI_CODSUBES { get; set; }

        public static R2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1 Execute(R2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1 r2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1)
        {
            var ths = r2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2200_00_SELECT_V1SUBGRUPO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1SUBG_CODCLIEN = result[i++].Value?.ToString();
            return dta;
        }

    }
}