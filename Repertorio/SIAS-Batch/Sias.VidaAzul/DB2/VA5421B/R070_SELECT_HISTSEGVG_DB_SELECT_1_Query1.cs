using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5421B
{
    public class R070_SELECT_HISTSEGVG_DB_SELECT_1_Query1 : QueryBasis<R070_SELECT_HISTSEGVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_OPERACAO,
            DATA_MOVIMENTO,
            DATA_MOVIMENTO + 6 MONTHS
            INTO :V0HSEG-CODOPER,
            :V0HSEG-DTMOVTO,
            :V0HSEG-DTREABI:VIND-DTREABI
            FROM SEGUROS.V0HISTSEGVG
            WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE
            AND NUM_ITEM = :V0SEGV-NUMITEM
            AND OCORR_HISTORICO = :V0SEGV-OCORHIST
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_OPERACAO
							,
											DATA_MOVIMENTO
							,
											DATA_MOVIMENTO + 6 MONTHS
											FROM SEGUROS.V0HISTSEGVG
											WHERE NUM_APOLICE = '{this.V0PROP_NUM_APOLICE}'
											AND NUM_ITEM = '{this.V0SEGV_NUMITEM}'
											AND OCORR_HISTORICO = '{this.V0SEGV_OCORHIST}'";

            return query;
        }
        public string V0HSEG_CODOPER { get; set; }
        public string V0HSEG_DTMOVTO { get; set; }
        public string V0HSEG_DTREABI { get; set; }
        public string VIND_DTREABI { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0SEGV_OCORHIST { get; set; }
        public string V0SEGV_NUMITEM { get; set; }

        public static R070_SELECT_HISTSEGVG_DB_SELECT_1_Query1 Execute(R070_SELECT_HISTSEGVG_DB_SELECT_1_Query1 r070_SELECT_HISTSEGVG_DB_SELECT_1_Query1)
        {
            var ths = r070_SELECT_HISTSEGVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R070_SELECT_HISTSEGVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R070_SELECT_HISTSEGVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HSEG_CODOPER = result[i++].Value?.ToString();
            dta.V0HSEG_DTMOVTO = result[i++].Value?.ToString();
            dta.V0HSEG_DTREABI = result[i++].Value?.ToString();
            dta.VIND_DTREABI = string.IsNullOrWhiteSpace(dta.V0HSEG_DTREABI) ? "-1" : "0";
            return dta;
        }

    }
}