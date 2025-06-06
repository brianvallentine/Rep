using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5001B
{
    public class R210_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1 : QueryBasis<R210_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_LOT_FENAL
            INTO :WS-COD-LOT-FENAL
            FROM SEGUROS.SINI_LOTERICO01
            WHERE NUM_APOL_SINISTRO = :MOVDEBCE-NUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_LOT_FENAL
											FROM SEGUROS.SINI_LOTERICO01
											WHERE NUM_APOL_SINISTRO = '{this.MOVDEBCE_NUM_APOLICE}'";

            return query;
        }
        public string WS_COD_LOT_FENAL { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }

        public static R210_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1 Execute(R210_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1 r210_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1)
        {
            var ths = r210_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R210_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R210_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_COD_LOT_FENAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}