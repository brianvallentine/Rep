using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6005B
{
    public class R3000_10_CONTINUA_DB_SELECT_4_Query1 : QueryBasis<R3000_10_CONTINUA_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COBERTURA1 ,
            COBERTURA2 ,
            COBERTURA3
            INTO :V1COBI-COBERTURA1 ,
            :V1COBI-COBERTURA2 ,
            :V1COBI-COBERTURA3
            FROM SEGUROS.V1COMERC_BILHETE
            WHERE COD_ESCNEG = :V1COBI-COD-ESCNEG
            AND RAMO = 14
            AND DTINIVIG <= :V1COBI-DTINIVIG
            AND DTTERVIG >= :V1COBI-DTINIVIG
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COBERTURA1 
							,
											COBERTURA2 
							,
											COBERTURA3
											FROM SEGUROS.V1COMERC_BILHETE
											WHERE COD_ESCNEG = '{this.V1COBI_COD_ESCNEG}'
											AND RAMO = 14
											AND DTINIVIG <= '{this.V1COBI_DTINIVIG}'
											AND DTTERVIG >= '{this.V1COBI_DTINIVIG}'
											WITH UR";

            return query;
        }
        public string V1COBI_COBERTURA1 { get; set; }
        public string V1COBI_COBERTURA2 { get; set; }
        public string V1COBI_COBERTURA3 { get; set; }
        public string V1COBI_COD_ESCNEG { get; set; }
        public string V1COBI_DTINIVIG { get; set; }

        public static R3000_10_CONTINUA_DB_SELECT_4_Query1 Execute(R3000_10_CONTINUA_DB_SELECT_4_Query1 r3000_10_CONTINUA_DB_SELECT_4_Query1)
        {
            var ths = r3000_10_CONTINUA_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3000_10_CONTINUA_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3000_10_CONTINUA_DB_SELECT_4_Query1();
            var i = 0;
            dta.V1COBI_COBERTURA1 = result[i++].Value?.ToString();
            dta.V1COBI_COBERTURA2 = result[i++].Value?.ToString();
            dta.V1COBI_COBERTURA3 = result[i++].Value?.ToString();
            return dta;
        }

    }
}