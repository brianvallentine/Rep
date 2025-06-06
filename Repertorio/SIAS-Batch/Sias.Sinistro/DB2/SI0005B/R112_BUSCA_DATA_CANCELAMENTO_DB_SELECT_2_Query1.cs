using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_2_Query1 : QueryBasis<R112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA
            INTO :WS-DT-CANCELAMENTO
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :LOTERI01-NUM-APOLICE
            AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.LOTERI01_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.ENDOSSOS_NUM_ENDOSSO}'
											WITH UR";

            return query;
        }
        public string WS_DT_CANCELAMENTO { get; set; }
        public string LOTERI01_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }

        public static R112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_2_Query1 Execute(R112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_2_Query1 r112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_2_Query1)
        {
            var ths = r112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_2_Query1();
            var i = 0;
            dta.WS_DT_CANCELAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}