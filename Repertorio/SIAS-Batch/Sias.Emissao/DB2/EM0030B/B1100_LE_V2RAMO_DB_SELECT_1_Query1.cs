using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class B1100_LE_V2RAMO_DB_SELECT_1_Query1 : QueryBasis<B1100_LE_V2RAMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TIPOFRAC
            INTO :RAMO-TIPOFRAC
            FROM SEGUROS.V2RAMO
            WHERE RAMO = :ENDO-RAMO
            AND MODALIDA = 0
            AND DTINIVIG <= :ENDO-DTINIVIG
            AND DTTERVIG >= :ENDO-DTINIVIG
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TIPOFRAC
											FROM SEGUROS.V2RAMO
											WHERE RAMO = '{this.ENDO_RAMO}'
											AND MODALIDA = 0
											AND DTINIVIG <= '{this.ENDO_DTINIVIG}'
											AND DTTERVIG >= '{this.ENDO_DTINIVIG}'
											WITH UR";

            return query;
        }
        public string RAMO_TIPOFRAC { get; set; }
        public string ENDO_DTINIVIG { get; set; }
        public string ENDO_RAMO { get; set; }

        public static B1100_LE_V2RAMO_DB_SELECT_1_Query1 Execute(B1100_LE_V2RAMO_DB_SELECT_1_Query1 b1100_LE_V2RAMO_DB_SELECT_1_Query1)
        {
            var ths = b1100_LE_V2RAMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B1100_LE_V2RAMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B1100_LE_V2RAMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.RAMO_TIPOFRAC = result[i++].Value?.ToString();
            return dta;
        }

    }
}