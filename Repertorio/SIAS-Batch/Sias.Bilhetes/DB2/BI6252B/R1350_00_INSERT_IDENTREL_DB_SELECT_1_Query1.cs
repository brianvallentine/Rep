using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6252B
{
    public class R1350_00_INSERT_IDENTREL_DB_SELECT_1_Query1 : QueryBasis<R1350_00_INSERT_IDENTREL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_IDENTIFICACAO),0)
            INTO :IDENTREL-NUM-IDENTIFICACAO
            FROM SEGUROS.IDENTIFICA_RELAC
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_IDENTIFICACAO)
							,0)
											FROM SEGUROS.IDENTIFICA_RELAC";

            return query;
        }
        public string IDENTREL_NUM_IDENTIFICACAO { get; set; }

        public static R1350_00_INSERT_IDENTREL_DB_SELECT_1_Query1 Execute(R1350_00_INSERT_IDENTREL_DB_SELECT_1_Query1 r1350_00_INSERT_IDENTREL_DB_SELECT_1_Query1)
        {
            var ths = r1350_00_INSERT_IDENTREL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1350_00_INSERT_IDENTREL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1350_00_INSERT_IDENTREL_DB_SELECT_1_Query1();
            var i = 0;
            dta.IDENTREL_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}