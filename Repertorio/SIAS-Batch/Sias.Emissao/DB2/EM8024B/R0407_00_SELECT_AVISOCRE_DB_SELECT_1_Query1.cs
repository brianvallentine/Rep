using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8024B
{
    public class R0407_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 : QueryBasis<R0407_00_SELECT_AVISOCRE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_AVISO_CREDITO),0)
            INTO :AVISOCRE-NUM-AVISO-CREDITO
            FROM SEGUROS.AVISO_CREDITO
            WHERE NUM_AVISO_CREDITO BETWEEN :WSHOST-NRAVISO1
            AND :WSHOST-NRAVISO2
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_AVISO_CREDITO)
							,0)
											FROM SEGUROS.AVISO_CREDITO
											WHERE NUM_AVISO_CREDITO BETWEEN '{this.WSHOST_NRAVISO1}'
											AND '{this.WSHOST_NRAVISO2}'
											WITH UR";

            return query;
        }
        public string AVISOCRE_NUM_AVISO_CREDITO { get; set; }
        public string WSHOST_NRAVISO1 { get; set; }
        public string WSHOST_NRAVISO2 { get; set; }

        public static R0407_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 Execute(R0407_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 r0407_00_SELECT_AVISOCRE_DB_SELECT_1_Query1)
        {
            var ths = r0407_00_SELECT_AVISOCRE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0407_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0407_00_SELECT_AVISOCRE_DB_SELECT_1_Query1();
            var i = 0;
            dta.AVISOCRE_NUM_AVISO_CREDITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}