using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0101S
{
    public class Execute_DB_SELECT_4_Query1 : QueryBasis<Execute_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT QTD_VIDAS_VG,
            QTD_VIDAS_AP,
            PRM_VG,
            PRM_AP,
            TIMESTAMP
            INTO :QTD-VIDAS-VG-W,
            :QTD-VIDAS-AP-W,
            :PRM-VG-W,
            :PRM-AP-W,
            :TIMESTAMP
            FROM SEGUROS.V0FATURCONTAZ
            WHERE DATA_REFERENCIA = :DTREF
            AND CODPRODAZ = :CODPRODAZ
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT QTD_VIDAS_VG
							,
											QTD_VIDAS_AP
							,
											PRM_VG
							,
											PRM_AP
							,
											TIMESTAMP
											FROM SEGUROS.V0FATURCONTAZ
											WHERE DATA_REFERENCIA = '{this.DTREF}'
											AND CODPRODAZ = '{this.CODPRODAZ}'";

            return query;
        }
        public string QTD_VIDAS_VG_W { get; set; }
        public string QTD_VIDAS_AP_W { get; set; }
        public string PRM_VG_W { get; set; }
        public string PRM_AP_W { get; set; }
        public string TIMESTAMP { get; set; }
        public string CODPRODAZ { get; set; }
        public string DTREF { get; set; }

        public static Execute_DB_SELECT_4_Query1 Execute(Execute_DB_SELECT_4_Query1 execute_DB_SELECT_4_Query1)
        {
            var ths = execute_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override Execute_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new Execute_DB_SELECT_4_Query1();
            var i = 0;
            dta.QTD_VIDAS_VG_W = result[i++].Value?.ToString();
            dta.QTD_VIDAS_AP_W = result[i++].Value?.ToString();
            dta.PRM_VG_W = result[i++].Value?.ToString();
            dta.PRM_AP_W = result[i++].Value?.ToString();
            dta.TIMESTAMP = result[i++].Value?.ToString();
            return dta;
        }

    }
}