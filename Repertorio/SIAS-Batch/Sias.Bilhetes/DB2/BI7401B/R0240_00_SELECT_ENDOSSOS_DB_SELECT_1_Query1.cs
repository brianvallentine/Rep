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
    public class R0240_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R0240_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO
            INTO :ENDOSSOS-COD-PRODUTO
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :RELATORI-NUM-APOLICE
            AND TIPO_ENDOSSO IN ( '3' , '5' )
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.RELATORI_NUM_APOLICE}'
											AND TIPO_ENDOSSO IN ( '3' 
							, '5' )
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string ENDOSSOS_COD_PRODUTO { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }

        public static R0240_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 Execute(R0240_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 r0240_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = r0240_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0240_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0240_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}