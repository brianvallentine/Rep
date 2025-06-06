using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R8164_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1 : QueryBasis<R8164_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MIN(NUM_PARCELA),0)
            INTO :WS-NUM-PARCELA-PEND
            FROM SEGUROS.COBER_HIST_VIDAZUL
            WHERE NUM_CERTIFICADO = :V0HISC-NRCERTIF
            AND SIT_REGISTRO IN ( ' ' , '0' , X '00' )
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MIN(NUM_PARCELA)
							,0)
											FROM SEGUROS.COBER_HIST_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.V0HISC_NRCERTIF}'
											AND SIT_REGISTRO IN ( ' ' 
							, '0' 
							, X'00' )
											WITH UR";

            return query;
        }
        public string WS_NUM_PARCELA_PEND { get; set; }
        public string V0HISC_NRCERTIF { get; set; }

        public static R8164_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1 Execute(R8164_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1 r8164_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1)
        {
            var ths = r8164_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8164_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8164_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_NUM_PARCELA_PEND = result[i++].Value?.ToString();
            return dta;
        }

    }
}