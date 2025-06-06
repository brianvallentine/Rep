using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class R3000_LE_CUSTO_APOLICE_DB_SELECT_1_Query1 : QueryBasis<R3000_LE_CUSTO_APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            SUM(OTNCUSTO)
            INTO
            :PARC-OTNCUSTO
            FROM
            SEGUROS.V0PARCELA
            WHERE
            NUM_APOLICE = :ENDO-NUM-APOLICE
            AND NRENDOS = 0
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											SUM(OTNCUSTO)
											FROM
											SEGUROS.V0PARCELA
											WHERE
											NUM_APOLICE = '{this.ENDO_NUM_APOLICE}'
											AND NRENDOS = 0
											WITH UR";

            return query;
        }
        public string PARC_OTNCUSTO { get; set; }
        public string ENDO_NUM_APOLICE { get; set; }

        public static R3000_LE_CUSTO_APOLICE_DB_SELECT_1_Query1 Execute(R3000_LE_CUSTO_APOLICE_DB_SELECT_1_Query1 r3000_LE_CUSTO_APOLICE_DB_SELECT_1_Query1)
        {
            var ths = r3000_LE_CUSTO_APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3000_LE_CUSTO_APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3000_LE_CUSTO_APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARC_OTNCUSTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}