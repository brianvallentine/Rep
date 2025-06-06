using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8008B
{
    public class R1160_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 : QueryBasis<R1160_00_SELECT_AVISOCRE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_AVISO_CREDITO),0)
            INTO :AVISOCRE-NUM-AVISO-CREDITO
            FROM SEGUROS.AVISO_CREDITO
            WHERE NUM_AVISO_CREDITO
            BETWEEN :WSHOST-NRAVISO3
            AND :WSHOST-NRAVISO4
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_AVISO_CREDITO)
							,0)
											FROM SEGUROS.AVISO_CREDITO
											WHERE NUM_AVISO_CREDITO
											BETWEEN '{this.WSHOST_NRAVISO3}'
											AND '{this.WSHOST_NRAVISO4}'
											WITH UR";

            return query;
        }
        public string AVISOCRE_NUM_AVISO_CREDITO { get; set; }
        public string WSHOST_NRAVISO3 { get; set; }
        public string WSHOST_NRAVISO4 { get; set; }

        public static R1160_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 Execute(R1160_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 r1160_00_SELECT_AVISOCRE_DB_SELECT_1_Query1)
        {
            var ths = r1160_00_SELECT_AVISOCRE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1160_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1160_00_SELECT_AVISOCRE_DB_SELECT_1_Query1();
            var i = 0;
            dta.AVISOCRE_NUM_AVISO_CREDITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}