using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1280B
{
    public class P2112_00_CALCULA_VIGENCIA_DB_SELECT_2_Query1 : QueryBasis<P2112_00_CALCULA_VIGENCIA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),+0)
            INTO :WS-QT-DIAS-VIG
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO BETWEEN :ENDOSSOS-DATA-INIVIGENCIA
            AND :ENDOSSOS-DATA-TERVIGENCIA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,+0)
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO BETWEEN '{this.ENDOSSOS_DATA_INIVIGENCIA}'
											AND '{this.ENDOSSOS_DATA_TERVIGENCIA}'
											WITH UR";

            return query;
        }
        public string WS_QT_DIAS_VIG { get; set; }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string ENDOSSOS_DATA_TERVIGENCIA { get; set; }

        public static P2112_00_CALCULA_VIGENCIA_DB_SELECT_2_Query1 Execute(P2112_00_CALCULA_VIGENCIA_DB_SELECT_2_Query1 p2112_00_CALCULA_VIGENCIA_DB_SELECT_2_Query1)
        {
            var ths = p2112_00_CALCULA_VIGENCIA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P2112_00_CALCULA_VIGENCIA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P2112_00_CALCULA_VIGENCIA_DB_SELECT_2_Query1();
            var i = 0;
            dta.WS_QT_DIAS_VIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}