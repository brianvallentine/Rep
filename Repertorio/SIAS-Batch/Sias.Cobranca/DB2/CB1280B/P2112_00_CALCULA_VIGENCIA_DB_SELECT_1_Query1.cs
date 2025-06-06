using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1280B
{
    public class P2112_00_CALCULA_VIGENCIA_DB_SELECT_1_Query1 : QueryBasis<P2112_00_CALCULA_VIGENCIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA
            ,DATA_TERVIGENCIA
            INTO :ENDOSSOS-DATA-INIVIGENCIA
            ,:ENDOSSOS-DATA-TERVIGENCIA
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE
            AND NUM_ENDOSSO = 0
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA
											,DATA_TERVIGENCIA
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.PARCEHIS_NUM_APOLICE}'
											AND NUM_ENDOSSO = 0
											WITH UR";

            return query;
        }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string ENDOSSOS_DATA_TERVIGENCIA { get; set; }
        public string PARCEHIS_NUM_APOLICE { get; set; }

        public static P2112_00_CALCULA_VIGENCIA_DB_SELECT_1_Query1 Execute(P2112_00_CALCULA_VIGENCIA_DB_SELECT_1_Query1 p2112_00_CALCULA_VIGENCIA_DB_SELECT_1_Query1)
        {
            var ths = p2112_00_CALCULA_VIGENCIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P2112_00_CALCULA_VIGENCIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P2112_00_CALCULA_VIGENCIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}