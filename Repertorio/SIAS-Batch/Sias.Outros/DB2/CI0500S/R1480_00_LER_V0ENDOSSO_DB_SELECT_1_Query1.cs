using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.CI0500S
{
    public class R1480_00_LER_V0ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R1480_00_LER_V0ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            CODPRODU
            ,RAMO
            INTO
            :LK-COD-PRODUTO
            ,:LK-COD-RAMO
            FROM
            SEGUROS.V0ENDOSSO
            WHERE
            NUM_APOLICE = :LK-NUM-APOLICE
            AND NRENDOS = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											CODPRODU
											,RAMO
											FROM
											SEGUROS.V0ENDOSSO
											WHERE
											NUM_APOLICE = '{this.LK_NUM_APOLICE}'
											AND NRENDOS = 0";

            return query;
        }
        public string LK_COD_PRODUTO { get; set; }
        public string LK_COD_RAMO { get; set; }
        public string LK_NUM_APOLICE { get; set; }

        public static R1480_00_LER_V0ENDOSSO_DB_SELECT_1_Query1 Execute(R1480_00_LER_V0ENDOSSO_DB_SELECT_1_Query1 r1480_00_LER_V0ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r1480_00_LER_V0ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1480_00_LER_V0ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1480_00_LER_V0ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.LK_COD_PRODUTO = result[i++].Value?.ToString();
            dta.LK_COD_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}