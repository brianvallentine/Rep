using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0017B
{
    public class R0900_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1 : QueryBasis<R0900_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVTO
            INTO :WHOST-DATA-AVS
            FROM SEGUROS.V0HISTSINI
            WHERE NUM_APOL_SINISTRO = :V1MSIN-NUM-SINI
            AND OCORHIST = 01
            AND OPERACAO = 0101
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVTO
											FROM SEGUROS.V0HISTSINI
											WHERE NUM_APOL_SINISTRO = '{this.V1MSIN_NUM_SINI}'
											AND OCORHIST = 01
											AND OPERACAO = 0101";

            return query;
        }
        public string WHOST_DATA_AVS { get; set; }
        public string V1MSIN_NUM_SINI { get; set; }

        public static R0900_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1 Execute(R0900_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1 r0900_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1)
        {
            var ths = r0900_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0900_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0900_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DATA_AVS = result[i++].Value?.ToString();
            return dta;
        }

    }
}