using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0502B
{
    public class R100_INSERT_ENDERECO_DB_SELECT_1_Query1 : QueryBasis<R100_INSERT_ENDERECO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(SEQ_ENDERECO),0) + 1
            INTO :OD007-SEQ-ENDERECO
            FROM ODS.OD_PESSOA_ENDERECO
            WHERE NUM_PESSOA = :OD007-NUM-PESSOA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(SEQ_ENDERECO)
							,0) + 1
											FROM ODS.OD_PESSOA_ENDERECO
											WHERE NUM_PESSOA = '{this.OD007_NUM_PESSOA}'";

            return query;
        }
        public string OD007_SEQ_ENDERECO { get; set; }
        public string OD007_NUM_PESSOA { get; set; }

        public static R100_INSERT_ENDERECO_DB_SELECT_1_Query1 Execute(R100_INSERT_ENDERECO_DB_SELECT_1_Query1 r100_INSERT_ENDERECO_DB_SELECT_1_Query1)
        {
            var ths = r100_INSERT_ENDERECO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R100_INSERT_ENDERECO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R100_INSERT_ENDERECO_DB_SELECT_1_Query1();
            var i = 0;
            dta.OD007_SEQ_ENDERECO = result[i++].Value?.ToString();
            return dta;
        }

    }
}