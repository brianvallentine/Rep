using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0070B
{
    public class R0110_00_SELECT_COTACAO_DB_SELECT_1_Query1 : QueryBasis<R0110_00_SELECT_COTACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WHOST-COUNT:VIND-NULL01
            FROM SEGUROS.MOEDAS_COTACAO
            WHERE COD_MOEDA = 28
            AND DATA_INIVIGENCIA >= :SISTEMA-DTINICOT
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.MOEDAS_COTACAO
											WHERE COD_MOEDA = 28
											AND DATA_INIVIGENCIA >= '{this.SISTEMA_DTINICOT}'
											WITH UR";

            return query;
        }
        public string WHOST_COUNT { get; set; }
        public string VIND_NULL01 { get; set; }
        public string SISTEMA_DTINICOT { get; set; }

        public static R0110_00_SELECT_COTACAO_DB_SELECT_1_Query1 Execute(R0110_00_SELECT_COTACAO_DB_SELECT_1_Query1 r0110_00_SELECT_COTACAO_DB_SELECT_1_Query1)
        {
            var ths = r0110_00_SELECT_COTACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0110_00_SELECT_COTACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0110_00_SELECT_COTACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_COUNT = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.WHOST_COUNT) ? "-1" : "0";
            return dta;
        }

    }
}