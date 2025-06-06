using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0970B
{
    public class R1250_00_SELECT_BILHETE_DB_SELECT_1_Query1 : QueryBasis<R1250_00_SELECT_BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_CLIENTE
            INTO
            :BILHETE-COD-CLIENTE
            FROM
            SEGUROS.BILHETE
            WHERE
            NUM_APOLICE = :SINISMES-NUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_CLIENTE
											FROM
											SEGUROS.BILHETE
											WHERE
											NUM_APOLICE = '{this.SINISMES_NUM_APOLICE}'";

            return query;
        }
        public string BILHETE_COD_CLIENTE { get; set; }
        public string SINISMES_NUM_APOLICE { get; set; }

        public static R1250_00_SELECT_BILHETE_DB_SELECT_1_Query1 Execute(R1250_00_SELECT_BILHETE_DB_SELECT_1_Query1 r1250_00_SELECT_BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r1250_00_SELECT_BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1250_00_SELECT_BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1250_00_SELECT_BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILHETE_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}