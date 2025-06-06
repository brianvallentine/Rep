using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0030B
{
    public class R0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1 : QueryBasis<R0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_ESCNEG,
            DATA_INIVIGENCIA,
            DATA_TERVIGENCIA,
            NUM_MATRICULA
            INTO :V1PROD-COD-ESCNEG,
            :V1PROD-DTINIVIG,
            :V1PROD-DTTERVIG,
            :V1PROD-NUM-MATRIC
            FROM SEGUROS.V1PRODESCNEG
            WHERE COD_ESCNEG = :V1PROD-COD-ESCNEG
            AND DATA_TERVIGENCIA IN ( '1999-12-31' , '9999-12-31' )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_ESCNEG
							,
											DATA_INIVIGENCIA
							,
											DATA_TERVIGENCIA
							,
											NUM_MATRICULA
											FROM SEGUROS.V1PRODESCNEG
											WHERE COD_ESCNEG = '{this.V1PROD_COD_ESCNEG}'
											AND DATA_TERVIGENCIA IN ( '1999-12-31' 
							, '9999-12-31' )
											WITH UR";

            return query;
        }
        public string V1PROD_COD_ESCNEG { get; set; }
        public string V1PROD_DTINIVIG { get; set; }
        public string V1PROD_DTTERVIG { get; set; }
        public string V1PROD_NUM_MATRIC { get; set; }

        public static R0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1 Execute(R0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1 r0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1)
        {
            var ths = r0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0380_00_LER_V0PRODESCNEG_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1PROD_COD_ESCNEG = result[i++].Value?.ToString();
            dta.V1PROD_DTINIVIG = result[i++].Value?.ToString();
            dta.V1PROD_DTTERVIG = result[i++].Value?.ToString();
            dta.V1PROD_NUM_MATRIC = result[i++].Value?.ToString();
            return dta;
        }

    }
}