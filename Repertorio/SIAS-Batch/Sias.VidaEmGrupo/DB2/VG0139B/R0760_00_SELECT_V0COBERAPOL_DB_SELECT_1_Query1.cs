using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0139B
{
    public class R0760_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1 : QueryBasis<R0760_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_TERVIGENCIA
            INTO :WHOST-DTTERVIG
            FROM SEGUROS.V0COBERAPOL
            WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE
            AND NRENDOS = 0
            AND DATA_TERVIGENCIA > :V0PARC-DTVENCTO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_TERVIGENCIA
											FROM SEGUROS.V0COBERAPOL
											WHERE NUM_APOLICE = '{this.V0HCTB_NUM_APOLICE}'
											AND NRENDOS = 0
											AND DATA_TERVIGENCIA > '{this.V0PARC_DTVENCTO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string WHOST_DTTERVIG { get; set; }
        public string V0HCTB_NUM_APOLICE { get; set; }
        public string V0PARC_DTVENCTO { get; set; }

        public static R0760_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1 Execute(R0760_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1 r0760_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1)
        {
            var ths = r0760_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0760_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0760_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DTTERVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}