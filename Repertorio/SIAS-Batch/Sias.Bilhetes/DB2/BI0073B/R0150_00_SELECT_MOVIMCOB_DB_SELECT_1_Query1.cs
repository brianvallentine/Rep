using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0073B
{
    public class R0150_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 : QueryBasis<R0150_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(NUM_AVISO)
            INTO :MOVIMCOB-NUM-AVISO:VIND-NULL01
            FROM SEGUROS.MOVIMENTO_COBRANCA
            WHERE COD_BANCO =
            :MOVIMCOB-COD-BANCO
            AND COD_AGENCIA =
            :MOVIMCOB-COD-AGENCIA
            AND NUM_AVISO >= 802800000
            AND NUM_AVISO <= 802899999
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(NUM_AVISO)
											FROM SEGUROS.MOVIMENTO_COBRANCA
											WHERE COD_BANCO =
											'{this.MOVIMCOB_COD_BANCO}'
											AND COD_AGENCIA =
											'{this.MOVIMCOB_COD_AGENCIA}'
											AND NUM_AVISO >= 802800000
											AND NUM_AVISO <= 802899999
											WITH UR";

            return query;
        }
        public string MOVIMCOB_NUM_AVISO { get; set; }
        public string VIND_NULL01 { get; set; }
        public string MOVIMCOB_COD_AGENCIA { get; set; }
        public string MOVIMCOB_COD_BANCO { get; set; }

        public static R0150_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 Execute(R0150_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 r0150_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1)
        {
            var ths = r0150_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0150_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0150_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVIMCOB_NUM_AVISO = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.MOVIMCOB_NUM_AVISO) ? "-1" : "0";
            return dta;
        }

    }
}