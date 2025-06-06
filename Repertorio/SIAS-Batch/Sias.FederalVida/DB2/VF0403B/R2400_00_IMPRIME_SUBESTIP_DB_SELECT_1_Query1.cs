using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0403B
{
    public class R2400_00_IMPRIME_SUBESTIP_DB_SELECT_1_Query1 : QueryBasis<R2400_00_IMPRIME_SUBESTIP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE
            INTO :V0SUBG-CODCLIEN
            FROM SEGUROS.V0SUBGRUPO
            WHERE NUM_APOLICE = :V0SUBG-NUM-APOLICE
            AND COD_SUBGRUPO = :V0SUBG-CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
											FROM SEGUROS.V0SUBGRUPO
											WHERE NUM_APOLICE = '{this.V0SUBG_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.V0SUBG_CODSUBES}'";

            return query;
        }
        public string V0SUBG_CODCLIEN { get; set; }
        public string V0SUBG_NUM_APOLICE { get; set; }
        public string V0SUBG_CODSUBES { get; set; }

        public static R2400_00_IMPRIME_SUBESTIP_DB_SELECT_1_Query1 Execute(R2400_00_IMPRIME_SUBESTIP_DB_SELECT_1_Query1 r2400_00_IMPRIME_SUBESTIP_DB_SELECT_1_Query1)
        {
            var ths = r2400_00_IMPRIME_SUBESTIP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2400_00_IMPRIME_SUBESTIP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2400_00_IMPRIME_SUBESTIP_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SUBG_CODCLIEN = result[i++].Value?.ToString();
            return dta;
        }

    }
}