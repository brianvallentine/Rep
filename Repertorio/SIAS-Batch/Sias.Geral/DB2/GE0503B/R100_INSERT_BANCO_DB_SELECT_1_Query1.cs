using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0503B
{
    public class R100_INSERT_BANCO_DB_SELECT_1_Query1 : QueryBasis<R100_INSERT_BANCO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(SEQ_CONTA_BANCARIA),0) + 1
            INTO :OD009-SEQ-CONTA-BANCARIA
            FROM ODS.OD_PESS_CONTA_BANC
            WHERE NUM_PESSOA = :OD009-NUM-PESSOA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(SEQ_CONTA_BANCARIA)
							,0) + 1
											FROM ODS.OD_PESS_CONTA_BANC
											WHERE NUM_PESSOA = '{this.OD009_NUM_PESSOA}'";

            return query;
        }
        public string OD009_SEQ_CONTA_BANCARIA { get; set; }
        public string OD009_NUM_PESSOA { get; set; }

        public static R100_INSERT_BANCO_DB_SELECT_1_Query1 Execute(R100_INSERT_BANCO_DB_SELECT_1_Query1 r100_INSERT_BANCO_DB_SELECT_1_Query1)
        {
            var ths = r100_INSERT_BANCO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R100_INSERT_BANCO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R100_INSERT_BANCO_DB_SELECT_1_Query1();
            var i = 0;
            dta.OD009_SEQ_CONTA_BANCARIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}