using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R3300_00_ACESSA_PARCELADEV_DB_SELECT_1_Query1 : QueryBasis<R3300_00_ACESSA_PARCELADEV_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLACRESCIMO
            INTO :V0PDEV-VLACRESCIMO
            FROM SEGUROS.V0PARCELA_DEVEDOR
            WHERE NUM_APOLICE = :V1PARC-NUM-APOL
            AND NRENDOS = :V1PARC-NRENDOS
            AND NRPARCEL = :V1PARC-NRPARCEL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLACRESCIMO
											FROM SEGUROS.V0PARCELA_DEVEDOR
											WHERE NUM_APOLICE = '{this.V1PARC_NUM_APOL}'
											AND NRENDOS = '{this.V1PARC_NRENDOS}'
											AND NRPARCEL = '{this.V1PARC_NRPARCEL}'
											WITH UR";

            return query;
        }
        public string V0PDEV_VLACRESCIMO { get; set; }
        public string V1PARC_NUM_APOL { get; set; }
        public string V1PARC_NRPARCEL { get; set; }
        public string V1PARC_NRENDOS { get; set; }

        public static R3300_00_ACESSA_PARCELADEV_DB_SELECT_1_Query1 Execute(R3300_00_ACESSA_PARCELADEV_DB_SELECT_1_Query1 r3300_00_ACESSA_PARCELADEV_DB_SELECT_1_Query1)
        {
            var ths = r3300_00_ACESSA_PARCELADEV_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3300_00_ACESSA_PARCELADEV_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3300_00_ACESSA_PARCELADEV_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PDEV_VLACRESCIMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}