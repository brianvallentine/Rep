using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7401B
{
    public class R0250_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R0250_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :HOST-COUNT:VIND-NULL01
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :RELATORI-NUM-APOLICE
            AND TIPO_ENDOSSO NOT IN ( '3' , '4' , '5' )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.RELATORI_NUM_APOLICE}'
											AND TIPO_ENDOSSO NOT IN ( '3' 
							, '4' 
							, '5' )
											WITH UR";

            return query;
        }
        public string HOST_COUNT { get; set; }
        public string VIND_NULL01 { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }

        public static R0250_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 Execute(R0250_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 r0250_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = r0250_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0250_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0250_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_COUNT = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.HOST_COUNT) ? "-1" : "0";
            return dta;
        }

    }
}