using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0930B
{
    public class R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1 : QueryBasis<R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            CODCLIEN
            INTO :V0BILH-NUM-APOLICE,
            :V0BILH-CODCLIEN
            FROM SEGUROS.V0BILHETE
            WHERE NUMBIL = :WS-NUM-BILHETE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											CODCLIEN
											FROM SEGUROS.V0BILHETE
											WHERE NUMBIL = '{this.WS_NUM_BILHETE}'
											WITH UR";

            return query;
        }
        public string V0BILH_NUM_APOLICE { get; set; }
        public string V0BILH_CODCLIEN { get; set; }
        public string WS_NUM_BILHETE { get; set; }

        public static R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1 Execute(R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1 r1020_00_SELECT_BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r1020_00_SELECT_BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0BILH_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0BILH_CODCLIEN = result[i++].Value?.ToString();
            return dta;
        }

    }
}