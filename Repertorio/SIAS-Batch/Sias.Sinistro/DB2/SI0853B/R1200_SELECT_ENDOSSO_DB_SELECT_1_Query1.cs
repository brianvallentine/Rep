using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0853B
{
    public class R1200_SELECT_ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R1200_SELECT_ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE
            INTO :ENDOSSOS-COD-FONTE
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE
            AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_FONTE
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.ENDOSSOS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.ENDOSSOS_NUM_ENDOSSO}'";

            return query;
        }
        public string ENDOSSOS_COD_FONTE { get; set; }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }

        public static R1200_SELECT_ENDOSSO_DB_SELECT_1_Query1 Execute(R1200_SELECT_ENDOSSO_DB_SELECT_1_Query1 r1200_SELECT_ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r1200_SELECT_ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_SELECT_ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_SELECT_ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_COD_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}