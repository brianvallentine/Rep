using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0415B
{
    public class R060_SELECT_HISTSEGVG_DB_SELECT_1_Query1 : QueryBasis<R060_SELECT_HISTSEGVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_OPERACAO,
            DATA_REFERENCIA
            INTO :V0HSEG-CODOPER,
            :V0HSEG-DTREFER
            FROM SEGUROS.V0HISTSEGVG
            WHERE NUM_APOLICE = :V0PROP-APOLICE
            AND NUM_ITEM = :V0SEGV-NUMITEM
            AND OCORR_HISTORICO = :V0SEGV-OCORHIST
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_OPERACAO
							,
											DATA_REFERENCIA
											FROM SEGUROS.V0HISTSEGVG
											WHERE NUM_APOLICE = '{this.V0PROP_APOLICE}'
											AND NUM_ITEM = '{this.V0SEGV_NUMITEM}'
											AND OCORR_HISTORICO = '{this.V0SEGV_OCORHIST}'";

            return query;
        }
        public string V0HSEG_CODOPER { get; set; }
        public string V0HSEG_DTREFER { get; set; }
        public string V0SEGV_OCORHIST { get; set; }
        public string V0PROP_APOLICE { get; set; }
        public string V0SEGV_NUMITEM { get; set; }

        public static R060_SELECT_HISTSEGVG_DB_SELECT_1_Query1 Execute(R060_SELECT_HISTSEGVG_DB_SELECT_1_Query1 r060_SELECT_HISTSEGVG_DB_SELECT_1_Query1)
        {
            var ths = r060_SELECT_HISTSEGVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R060_SELECT_HISTSEGVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R060_SELECT_HISTSEGVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HSEG_CODOPER = result[i++].Value?.ToString();
            dta.V0HSEG_DTREFER = result[i++].Value?.ToString();
            return dta;
        }

    }
}