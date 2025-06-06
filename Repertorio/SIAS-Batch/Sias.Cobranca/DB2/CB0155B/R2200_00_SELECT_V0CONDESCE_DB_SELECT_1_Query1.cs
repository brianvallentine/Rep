using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0155B
{
    public class R2200_00_SELECT_V0CONDESCE_DB_SELECT_1_Query1 : QueryBasis<R2200_00_SELECT_V0CONDESCE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SUM(QTD_REGISTROS)
            INTO :CONDESCE-QTD-REGISTROS:VIND-ORIGEM
            FROM SEGUROS.CONTROL_DESPES_CEF
            WHERE BCO_AVISO =
            :CONDESCE-BCO-AVISO
            AND AGE_AVISO =
            :CONDESCE-AGE-AVISO
            AND NUM_AVISO_CREDITO =
            :CONDESCE-NUM-AVISO-CREDITO
            AND COD_EMPRESA = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SUM(QTD_REGISTROS)
											FROM SEGUROS.CONTROL_DESPES_CEF
											WHERE BCO_AVISO =
											'{this.CONDESCE_BCO_AVISO}'
											AND AGE_AVISO =
											'{this.CONDESCE_AGE_AVISO}'
											AND NUM_AVISO_CREDITO =
											'{this.CONDESCE_NUM_AVISO_CREDITO}'
											AND COD_EMPRESA = 0";

            return query;
        }
        public string CONDESCE_QTD_REGISTROS { get; set; }
        public string VIND_ORIGEM { get; set; }
        public string CONDESCE_NUM_AVISO_CREDITO { get; set; }
        public string CONDESCE_BCO_AVISO { get; set; }
        public string CONDESCE_AGE_AVISO { get; set; }

        public static R2200_00_SELECT_V0CONDESCE_DB_SELECT_1_Query1 Execute(R2200_00_SELECT_V0CONDESCE_DB_SELECT_1_Query1 r2200_00_SELECT_V0CONDESCE_DB_SELECT_1_Query1)
        {
            var ths = r2200_00_SELECT_V0CONDESCE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2200_00_SELECT_V0CONDESCE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2200_00_SELECT_V0CONDESCE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONDESCE_QTD_REGISTROS = result[i++].Value?.ToString();
            dta.VIND_ORIGEM = string.IsNullOrWhiteSpace(dta.CONDESCE_QTD_REGISTROS) ? "-1" : "0";
            return dta;
        }

    }
}