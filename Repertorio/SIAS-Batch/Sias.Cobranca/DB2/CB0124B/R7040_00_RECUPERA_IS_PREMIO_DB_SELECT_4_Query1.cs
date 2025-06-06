using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0124B
{
    public class R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4_Query1 : QueryBasis<R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMP_SEGURADA_IX
            INTO :V0COBA-IMPDIT
            FROM SEGUROS.V0COBERAPOL
            WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE
            AND NRENDOS = 0
            AND NUM_ITEM = :V0SEGU-ITEM
            AND OCORHIST = :V0SEGU-OCORHIST
            AND RAMOFR IN (81, 82)
            AND MODALIFR >= 0
            AND COD_COBERTURA = 5
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMP_SEGURADA_IX
											FROM SEGUROS.V0COBERAPOL
											WHERE NUM_APOLICE = '{this.V0PROP_NUM_APOLICE}'
											AND NRENDOS = 0
											AND NUM_ITEM = '{this.V0SEGU_ITEM}'
											AND OCORHIST = '{this.V0SEGU_OCORHIST}'
											AND RAMOFR IN (81
							, 82)
											AND MODALIFR >= 0
											AND COD_COBERTURA = 5
											WITH UR";

            return query;
        }
        public string V0COBA_IMPDIT { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0SEGU_OCORHIST { get; set; }
        public string V0SEGU_ITEM { get; set; }

        public static R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4_Query1 Execute(R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4_Query1 r7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4_Query1)
        {
            var ths = r7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7040_00_RECUPERA_IS_PREMIO_DB_SELECT_4_Query1();
            var i = 0;
            dta.V0COBA_IMPDIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}