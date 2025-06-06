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
    public class R3600_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 : QueryBasis<R3600_00_SELECT_V1PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :V1PARC-COUNT:VIND-COUNT
            FROM SEGUROS.V1PARCELA
            WHERE NUM_APOLICE = :V1PARC-NUM-APOL
            AND NRENDOS = :V1PARC-NRENDOS
            AND NRPARCEL < :V1PARC-NRPARCEL
            AND SITUACAO = '0'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.V1PARCELA
											WHERE NUM_APOLICE = '{this.V1PARC_NUM_APOL}'
											AND NRENDOS = '{this.V1PARC_NRENDOS}'
											AND NRPARCEL < '{this.V1PARC_NRPARCEL}'
											AND SITUACAO = '0'
											WITH UR";

            return query;
        }
        public string V1PARC_COUNT { get; set; }
        public string VIND_COUNT { get; set; }
        public string V1PARC_NUM_APOL { get; set; }
        public string V1PARC_NRPARCEL { get; set; }
        public string V1PARC_NRENDOS { get; set; }

        public static R3600_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 Execute(R3600_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 r3600_00_SELECT_V1PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r3600_00_SELECT_V1PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3600_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3600_00_SELECT_V1PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1PARC_COUNT = result[i++].Value?.ToString();
            dta.VIND_COUNT = string.IsNullOrWhiteSpace(dta.V1PARC_COUNT) ? "-1" : "0";
            return dta;
        }

    }
}