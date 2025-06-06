using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9521B
{
    public class R0000_00_PRINCIPAL_DB_SELECT_2_Query1 : QueryBasis<R0000_00_PRINCIPAL_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            DATA_TERVIGENCIA
            INTO :ENDOSSOS-DATA-TERVIGENCIA
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = 93605000853
            AND NUM_ENDOSSO = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											DATA_TERVIGENCIA
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = 93605000853
											AND NUM_ENDOSSO = 0";

            return query;
        }
        public string ENDOSSOS_DATA_TERVIGENCIA { get; set; }

        public static R0000_00_PRINCIPAL_DB_SELECT_2_Query1 Execute(R0000_00_PRINCIPAL_DB_SELECT_2_Query1 r0000_00_PRINCIPAL_DB_SELECT_2_Query1)
        {
            var ths = r0000_00_PRINCIPAL_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0000_00_PRINCIPAL_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0000_00_PRINCIPAL_DB_SELECT_2_Query1();
            var i = 0;
            dta.ENDOSSOS_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}