using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0301B
{
    public class R1211_00_GRAVA_FENPANA_DB_SELECT_1_Query1 : QueryBasis<R1211_00_GRAVA_FENPANA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SUM(VLPRMLIQ),
            SUM(VLPRMTOT)
            INTO :V1HISP-VLPRMLIQ,
            :V1HISP-VLPRMTOT
            FROM SEGUROS.V1HISTOPARC
            WHERE NUM_APOLICE = :V1HISP-NUMAPOL
            AND NRENDOS = :V1HISP-NRENDOS
            AND OPERACAO BETWEEN 100 AND 199
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SUM(VLPRMLIQ)
							,
											SUM(VLPRMTOT)
											FROM SEGUROS.V1HISTOPARC
											WHERE NUM_APOLICE = '{this.V1HISP_NUMAPOL}'
											AND NRENDOS = '{this.V1HISP_NRENDOS}'
											AND OPERACAO BETWEEN 100 AND 199
											WITH UR";

            return query;
        }
        public string V1HISP_VLPRMLIQ { get; set; }
        public string V1HISP_VLPRMTOT { get; set; }
        public string V1HISP_NUMAPOL { get; set; }
        public string V1HISP_NRENDOS { get; set; }

        public static R1211_00_GRAVA_FENPANA_DB_SELECT_1_Query1 Execute(R1211_00_GRAVA_FENPANA_DB_SELECT_1_Query1 r1211_00_GRAVA_FENPANA_DB_SELECT_1_Query1)
        {
            var ths = r1211_00_GRAVA_FENPANA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1211_00_GRAVA_FENPANA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1211_00_GRAVA_FENPANA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1HISP_VLPRMLIQ = result[i++].Value?.ToString();
            dta.V1HISP_VLPRMTOT = result[i++].Value?.ToString();
            return dta;
        }

    }
}