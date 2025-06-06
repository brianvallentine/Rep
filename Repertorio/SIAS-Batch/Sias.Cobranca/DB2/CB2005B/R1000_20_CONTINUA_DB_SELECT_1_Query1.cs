using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB2005B
{
    public class R1000_20_CONTINUA_DB_SELECT_1_Query1 : QueryBasis<R1000_20_CONTINUA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUMOPG
            INTO :WHOST-NUMOPG
            FROM SEGUROS.V0ADIANTA
            WHERE CODPDT = 17256
            AND NUM_APOLICE = :WHOST-NUMBIL
            AND NUMOPG > 0
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUMOPG
											FROM SEGUROS.V0ADIANTA
											WHERE CODPDT = 17256
											AND NUM_APOLICE = '{this.WHOST_NUMBIL}'
											AND NUMOPG > 0
											WITH UR";

            return query;
        }
        public string WHOST_NUMOPG { get; set; }
        public string WHOST_NUMBIL { get; set; }

        public static R1000_20_CONTINUA_DB_SELECT_1_Query1 Execute(R1000_20_CONTINUA_DB_SELECT_1_Query1 r1000_20_CONTINUA_DB_SELECT_1_Query1)
        {
            var ths = r1000_20_CONTINUA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_20_CONTINUA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_20_CONTINUA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_NUMOPG = result[i++].Value?.ToString();
            return dta;
        }

    }
}