using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class R1105_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1 : QueryBasis<R1105_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MIN(NUM_PARCELA),0)
            INTO :WS-NUM-PARCELA-PEND
            FROM SEGUROS.COBER_HIST_VIDAZUL
            WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF
            AND SIT_REGISTRO IN ( ' ' , '0' , X '00' )
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MIN(NUM_PARCELA)
							,0)
											FROM SEGUROS.COBER_HIST_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.V0PROP_NRCERTIF}'
											AND SIT_REGISTRO IN ( ' ' 
							, '0' 
							, X '00' )
											WITH UR";

            return query;
        }
        public string WS_NUM_PARCELA_PEND { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1105_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1 Execute(R1105_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1 r1105_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1)
        {
            var ths = r1105_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1105_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1105_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_NUM_PARCELA_PEND = result[i++].Value?.ToString();
            return dta;
        }

    }
}