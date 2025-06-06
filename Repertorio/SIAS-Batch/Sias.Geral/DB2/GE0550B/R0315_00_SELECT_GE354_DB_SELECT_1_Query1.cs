using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0550B
{
    public class R0315_00_SELECT_GE354_DB_SELECT_1_Query1 : QueryBasis<R0315_00_SELECT_GE354_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DES_EVENTO
            INTO :GE354-DES-EVENTO
            FROM SEGUROS.GE_EVENTO
            WHERE COD_EVENTO = :GE354-COD-EVENTO
            AND IDE_SISTEMA = :GE354-IDE-SISTEMA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DES_EVENTO
											FROM SEGUROS.GE_EVENTO
											WHERE COD_EVENTO = '{this.GE354_COD_EVENTO}'
											AND IDE_SISTEMA = '{this.GE354_IDE_SISTEMA}'";

            return query;
        }
        public string GE354_DES_EVENTO { get; set; }
        public string GE354_IDE_SISTEMA { get; set; }
        public string GE354_COD_EVENTO { get; set; }

        public static R0315_00_SELECT_GE354_DB_SELECT_1_Query1 Execute(R0315_00_SELECT_GE354_DB_SELECT_1_Query1 r0315_00_SELECT_GE354_DB_SELECT_1_Query1)
        {
            var ths = r0315_00_SELECT_GE354_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0315_00_SELECT_GE354_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0315_00_SELECT_GE354_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE354_DES_EVENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}