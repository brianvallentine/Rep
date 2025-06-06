using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0065B
{
    public class R0500_00_SELECT_V0RCAPS_DB_SELECT_1_Query1 : QueryBasis<R0500_00_SELECT_V0RCAPS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE (B.NUM_CERTIFICADO,0)
            INTO :RCAPS-NUM-CERTIFICADO
            FROM SEGUROS.ENDOSSOS A,
            SEGUROS.RCAPS B
            WHERE A.NUM_APOLICE = :ENDOSSOS-NUM-APOLICE
            AND A.NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO
            AND B.NUM_RCAP = A.NUM_RCAP
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE (B.NUM_CERTIFICADO
							,0)
											FROM SEGUROS.ENDOSSOS A
							,
											SEGUROS.RCAPS B
											WHERE A.NUM_APOLICE = '{this.ENDOSSOS_NUM_APOLICE}'
											AND A.NUM_ENDOSSO = '{this.ENDOSSOS_NUM_ENDOSSO}'
											AND B.NUM_RCAP = A.NUM_RCAP
											WITH UR";

            return query;
        }
        public string RCAPS_NUM_CERTIFICADO { get; set; }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }

        public static R0500_00_SELECT_V0RCAPS_DB_SELECT_1_Query1 Execute(R0500_00_SELECT_V0RCAPS_DB_SELECT_1_Query1 r0500_00_SELECT_V0RCAPS_DB_SELECT_1_Query1)
        {
            var ths = r0500_00_SELECT_V0RCAPS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0500_00_SELECT_V0RCAPS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0500_00_SELECT_V0RCAPS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_NUM_CERTIFICADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}