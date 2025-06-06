using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0140B
{
    public class R0250_00_SELECT_PARCEVID_DB_SELECT_1_Query1 : QueryBasis<R0250_00_SELECT_PARCEVID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_VENCIMENTO
            , DATE(TIMESTAMP)
            INTO :PARCEVID-DATA-VENCIMENTO
            , :WHOST-DATA-GEROU-PARCELA
            FROM SEGUROS.PARCELAS_VIDAZUL
            WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO
            AND NUM_PARCELA = :HISCONPA-NUM-PARCELA
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_VENCIMENTO
											, DATE(TIMESTAMP)
											FROM SEGUROS.PARCELAS_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.HISCONPA_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.HISCONPA_NUM_PARCELA}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string PARCEVID_DATA_VENCIMENTO { get; set; }
        public string WHOST_DATA_GEROU_PARCELA { get; set; }
        public string HISCONPA_NUM_CERTIFICADO { get; set; }
        public string HISCONPA_NUM_PARCELA { get; set; }

        public static R0250_00_SELECT_PARCEVID_DB_SELECT_1_Query1 Execute(R0250_00_SELECT_PARCEVID_DB_SELECT_1_Query1 r0250_00_SELECT_PARCEVID_DB_SELECT_1_Query1)
        {
            var ths = r0250_00_SELECT_PARCEVID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0250_00_SELECT_PARCEVID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0250_00_SELECT_PARCEVID_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCEVID_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.WHOST_DATA_GEROU_PARCELA = result[i++].Value?.ToString();
            return dta;
        }

    }
}