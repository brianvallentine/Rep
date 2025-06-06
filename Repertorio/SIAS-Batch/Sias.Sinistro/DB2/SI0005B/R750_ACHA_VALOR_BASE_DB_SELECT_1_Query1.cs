using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R750_ACHA_VALOR_BASE_DB_SELECT_1_Query1 : QueryBasis<R750_ACHA_VALOR_BASE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DISTINCT (COD_CLASSE_ADESAO)
            INTO :LOTERI01-COD-CLASSE-ADESAO
            FROM SEGUROS.LOTERICO01
            WHERE COD_LOT_CEF = :LOTERI01-COD-LOT-CEF
            AND COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL
            AND NUM_APOLICE = :LOTERI01-NUM-APOLICE
            ORDER BY COD_CLASSE_ADESAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DISTINCT (COD_CLASSE_ADESAO)
											FROM SEGUROS.LOTERICO01
											WHERE COD_LOT_CEF = '{this.LOTERI01_COD_LOT_CEF}'
											AND COD_LOT_FENAL = '{this.LOTERI01_COD_LOT_FENAL}'
											AND NUM_APOLICE = '{this.LOTERI01_NUM_APOLICE}'
											ORDER BY COD_CLASSE_ADESAO";

            return query;
        }
        public string LOTERI01_COD_CLASSE_ADESAO { get; set; }
        public string LOTERI01_COD_LOT_FENAL { get; set; }
        public string LOTERI01_COD_LOT_CEF { get; set; }
        public string LOTERI01_NUM_APOLICE { get; set; }

        public static R750_ACHA_VALOR_BASE_DB_SELECT_1_Query1 Execute(R750_ACHA_VALOR_BASE_DB_SELECT_1_Query1 r750_ACHA_VALOR_BASE_DB_SELECT_1_Query1)
        {
            var ths = r750_ACHA_VALOR_BASE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R750_ACHA_VALOR_BASE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R750_ACHA_VALOR_BASE_DB_SELECT_1_Query1();
            var i = 0;
            dta.LOTERI01_COD_CLASSE_ADESAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}