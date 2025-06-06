using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0141B
{
    public class R2510_00_SELECT_PARCEVID_DB_SELECT_1_Query1 : QueryBasis<R2510_00_SELECT_PARCEVID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_VENCIMENTO
            ,DATA_VENCIMENTO - 1 MONTH
            INTO :PARCEVID-DATA-VENCIMENTO
            ,:PARCEVID-DATA-VENCIMENTO-1M
            FROM SEGUROS.PARCELAS_VIDAZUL
            WHERE NUM_CERTIFICADO =
            :PARCEVID-NUM-CERTIFICADO
            AND NUM_PARCELA =
            :PARCEVID-NUM-PARCELA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_VENCIMENTO
											,DATA_VENCIMENTO - 1 MONTH
											FROM SEGUROS.PARCELAS_VIDAZUL
											WHERE NUM_CERTIFICADO =
											'{this.PARCEVID_NUM_CERTIFICADO}'
											AND NUM_PARCELA =
											'{this.PARCEVID_NUM_PARCELA}'
											WITH UR";

            return query;
        }
        public string PARCEVID_DATA_VENCIMENTO { get; set; }
        public string PARCEVID_DATA_VENCIMENTO_1M { get; set; }
        public string PARCEVID_NUM_CERTIFICADO { get; set; }
        public string PARCEVID_NUM_PARCELA { get; set; }

        public static R2510_00_SELECT_PARCEVID_DB_SELECT_1_Query1 Execute(R2510_00_SELECT_PARCEVID_DB_SELECT_1_Query1 r2510_00_SELECT_PARCEVID_DB_SELECT_1_Query1)
        {
            var ths = r2510_00_SELECT_PARCEVID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2510_00_SELECT_PARCEVID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2510_00_SELECT_PARCEVID_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCEVID_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.PARCEVID_DATA_VENCIMENTO_1M = result[i++].Value?.ToString();
            return dta;
        }

    }
}