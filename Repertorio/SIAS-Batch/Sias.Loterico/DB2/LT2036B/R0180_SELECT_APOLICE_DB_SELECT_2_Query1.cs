using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT2036B
{
    public class R0180_SELECT_APOLICE_DB_SELECT_2_Query1 : QueryBasis<R0180_SELECT_APOLICE_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NOME
            INTO :V0APO-NOME
            FROM SEGUROS.V1APOLICE A,
            SEGUROS.V0ENDOSSO E
            WHERE
            A.NUM_APOLICE = :V0APO-NUM-APOLICE
            AND A.NUM_APOLICE = E.NUM_APOLICE
            AND E.NRENDOS = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NOME
											FROM SEGUROS.V1APOLICE A
							,
											SEGUROS.V0ENDOSSO E
											WHERE
											A.NUM_APOLICE = '{this.V0APO_NUM_APOLICE}'
											AND A.NUM_APOLICE = E.NUM_APOLICE
											AND E.NRENDOS = 0";

            return query;
        }
        public string V0APO_NOME { get; set; }
        public string V0APO_NUM_APOLICE { get; set; }

        public static R0180_SELECT_APOLICE_DB_SELECT_2_Query1 Execute(R0180_SELECT_APOLICE_DB_SELECT_2_Query1 r0180_SELECT_APOLICE_DB_SELECT_2_Query1)
        {
            var ths = r0180_SELECT_APOLICE_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0180_SELECT_APOLICE_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0180_SELECT_APOLICE_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0APO_NOME = result[i++].Value?.ToString();
            return dta;
        }

    }
}