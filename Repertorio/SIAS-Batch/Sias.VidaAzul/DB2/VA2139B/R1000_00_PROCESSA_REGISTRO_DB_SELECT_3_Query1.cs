using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2139B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTTERVIG
            INTO :V0SUBGR-DTTERVIG
            FROM SEGUROS.V0SUBGRUPO
            WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE
            AND COD_SUBGRUPO = :V0HCTB-CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTTERVIG
											FROM SEGUROS.V0SUBGRUPO
											WHERE NUM_APOLICE = '{this.V0HCTB_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.V0HCTB_CODSUBES}'";

            return query;
        }
        public string V0SUBGR_DTTERVIG { get; set; }
        public string V0HCTB_NUM_APOLICE { get; set; }
        public string V0HCTB_CODSUBES { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1();
            var i = 0;
            dta.V0SUBGR_DTTERVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}