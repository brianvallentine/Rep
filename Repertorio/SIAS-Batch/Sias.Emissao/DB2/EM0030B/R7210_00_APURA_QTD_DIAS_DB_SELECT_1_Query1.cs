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
    public class R7210_00_APURA_QTD_DIAS_DB_SELECT_1_Query1 : QueryBasis<R7210_00_APURA_QTD_DIAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COUNT(*)
            INTO
            :WHOST-QTDIAS
            FROM
            SEGUROS.CALENDARIO
            WHERE
            DATA_CALENDARIO > :WHOST-DTCALEND1
            AND DATA_CALENDARIO <= :WHOST-DTCALEND2
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COUNT(*)
											FROM
											SEGUROS.CALENDARIO
											WHERE
											DATA_CALENDARIO > '{this.WHOST_DTCALEND1}'
											AND DATA_CALENDARIO <= '{this.WHOST_DTCALEND2}'
											WITH UR";

            return query;
        }
        public string WHOST_QTDIAS { get; set; }
        public string WHOST_DTCALEND1 { get; set; }
        public string WHOST_DTCALEND2 { get; set; }

        public static R7210_00_APURA_QTD_DIAS_DB_SELECT_1_Query1 Execute(R7210_00_APURA_QTD_DIAS_DB_SELECT_1_Query1 r7210_00_APURA_QTD_DIAS_DB_SELECT_1_Query1)
        {
            var ths = r7210_00_APURA_QTD_DIAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7210_00_APURA_QTD_DIAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7210_00_APURA_QTD_DIAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_QTDIAS = result[i++].Value?.ToString();
            return dta;
        }

    }
}