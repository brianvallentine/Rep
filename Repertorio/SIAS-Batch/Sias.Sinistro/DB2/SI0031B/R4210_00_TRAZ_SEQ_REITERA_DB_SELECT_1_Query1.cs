using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0031B
{
    public class R4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1_Query1 : QueryBasis<R4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SEQ_CARTA_REITERA
            INTO :GECARTA-SEQ-CARTA-REITERA
            FROM SEGUROS.GE_CARTA
            WHERE NUM_CARTA = :WS-CARTA-ANT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SEQ_CARTA_REITERA
											FROM SEGUROS.GE_CARTA
											WHERE NUM_CARTA = '{this.WS_CARTA_ANT}'";

            return query;
        }
        public string GECARTA_SEQ_CARTA_REITERA { get; set; }
        public string WS_CARTA_ANT { get; set; }

        public static R4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1_Query1 Execute(R4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1_Query1 r4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1_Query1)
        {
            var ths = r4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1_Query1();
            var i = 0;
            dta.GECARTA_SEQ_CARTA_REITERA = result[i++].Value?.ToString();
            return dta;
        }

    }
}