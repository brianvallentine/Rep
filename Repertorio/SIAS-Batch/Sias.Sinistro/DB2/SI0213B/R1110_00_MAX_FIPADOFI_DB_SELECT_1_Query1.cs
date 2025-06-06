using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0213B
{
    public class R1110_00_MAX_FIPADOFI_DB_SELECT_1_Query1 : QueryBasis<R1110_00_MAX_FIPADOFI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_DOCF_INTERNO),0)
            INTO :FIPADOFI-NUM-DOCF-INTERNO
            FROM SEGUROS.FI_PAGA_DOC_FISCAL
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_DOCF_INTERNO)
							,0)
											FROM SEGUROS.FI_PAGA_DOC_FISCAL";

            return query;
        }
        public string FIPADOFI_NUM_DOCF_INTERNO { get; set; }

        public static R1110_00_MAX_FIPADOFI_DB_SELECT_1_Query1 Execute(R1110_00_MAX_FIPADOFI_DB_SELECT_1_Query1 r1110_00_MAX_FIPADOFI_DB_SELECT_1_Query1)
        {
            var ths = r1110_00_MAX_FIPADOFI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1110_00_MAX_FIPADOFI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1110_00_MAX_FIPADOFI_DB_SELECT_1_Query1();
            var i = 0;
            dta.FIPADOFI_NUM_DOCF_INTERNO = result[i++].Value?.ToString();
            return dta;
        }

    }
}