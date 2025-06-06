using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Auto.DB2.AU2055B
{
    public class R3241_00_SELECT_PROPOAUT_DB_SELECT_1_Query1 : QueryBasis<R3241_00_SELECT_PROPOAUT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA_CONV
            INTO :PROPOAUT-NUM-PROPOSTA-CONV
            FROM SEGUROS.PROPOSTA_AUTO
            WHERE COD_FONTE = :PROPOAUT-COD-FONTE
            AND NUM_PROPOSTA = :PROPOAUT-NUM-PROPOSTA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA_CONV
											FROM SEGUROS.PROPOSTA_AUTO
											WHERE COD_FONTE = '{this.PROPOAUT_COD_FONTE}'
											AND NUM_PROPOSTA = '{this.PROPOAUT_NUM_PROPOSTA}'";

            return query;
        }
        public string PROPOAUT_NUM_PROPOSTA_CONV { get; set; }
        public string PROPOAUT_NUM_PROPOSTA { get; set; }
        public string PROPOAUT_COD_FONTE { get; set; }

        public static R3241_00_SELECT_PROPOAUT_DB_SELECT_1_Query1 Execute(R3241_00_SELECT_PROPOAUT_DB_SELECT_1_Query1 r3241_00_SELECT_PROPOAUT_DB_SELECT_1_Query1)
        {
            var ths = r3241_00_SELECT_PROPOAUT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3241_00_SELECT_PROPOAUT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3241_00_SELECT_PROPOAUT_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOAUT_NUM_PROPOSTA_CONV = result[i++].Value?.ToString();
            return dta;
        }

    }
}