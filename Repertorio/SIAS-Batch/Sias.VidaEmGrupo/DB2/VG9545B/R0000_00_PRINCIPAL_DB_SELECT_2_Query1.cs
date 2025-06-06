using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9545B
{
    public class R0000_00_PRINCIPAL_DB_SELECT_2_Query1 : QueryBasis<R0000_00_PRINCIPAL_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VALUE(COUNT(*),0)
            INTO
            :MOVIMVGA-NUM-PROPOSTA
            FROM
            SEGUROS.MOVIMENTO_VGAP
            WHERE
            DATA_INCLUSAO IS NULL
            AND DATA_AVERBACAO IS NOT NULL
            AND NUM_APOLICE = 0109300000799
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(COUNT(*)
							,0)
											FROM
											SEGUROS.MOVIMENTO_VGAP
											WHERE
											DATA_INCLUSAO IS NULL
											AND DATA_AVERBACAO IS NOT NULL
											AND NUM_APOLICE = 0109300000799";

            return query;
        }
        public string MOVIMVGA_NUM_PROPOSTA { get; set; }

        public static R0000_00_PRINCIPAL_DB_SELECT_2_Query1 Execute(R0000_00_PRINCIPAL_DB_SELECT_2_Query1 r0000_00_PRINCIPAL_DB_SELECT_2_Query1)
        {
            var ths = r0000_00_PRINCIPAL_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0000_00_PRINCIPAL_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0000_00_PRINCIPAL_DB_SELECT_2_Query1();
            var i = 0;
            dta.MOVIMVGA_NUM_PROPOSTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}