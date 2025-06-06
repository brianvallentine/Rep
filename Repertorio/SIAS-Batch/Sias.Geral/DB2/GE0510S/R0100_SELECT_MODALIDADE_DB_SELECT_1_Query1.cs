using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0510S
{
    public class R0100_SELECT_MODALIDADE_DB_SELECT_1_Query1 : QueryBasis<R0100_SELECT_MODALIDADE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_MODALIDADE
            INTO :LK-GE510-COD-MODALIDADE
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE = :LK-GE510-NUM-APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_MODALIDADE
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE = '{this.LK_GE510_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string LK_GE510_COD_MODALIDADE { get; set; }
        public string LK_GE510_NUM_APOLICE { get; set; }

        public static R0100_SELECT_MODALIDADE_DB_SELECT_1_Query1 Execute(R0100_SELECT_MODALIDADE_DB_SELECT_1_Query1 r0100_SELECT_MODALIDADE_DB_SELECT_1_Query1)
        {
            var ths = r0100_SELECT_MODALIDADE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_SELECT_MODALIDADE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_SELECT_MODALIDADE_DB_SELECT_1_Query1();
            var i = 0;
            dta.LK_GE510_COD_MODALIDADE = result[i++].Value?.ToString();
            return dta;
        }

    }
}