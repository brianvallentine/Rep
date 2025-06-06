using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9211B
{
    public class R1010_00_CHECA_ESTORNO_DB_SELECT_2_Query1 : QueryBasis<R1010_00_CHECA_ESTORNO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOM_PROGRAMA
            INTO :SINISHIS-NOM-PROGRAMA
            FROM SEGUROS.SINISTRO_HISTORICO
            WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO
            AND DATA_MOVIMENTO = :SINISHIS-DATA-MOVIMENTO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NOM_PROGRAMA
											FROM SEGUROS.SINISTRO_HISTORICO
											WHERE NUM_APOL_SINISTRO = '{this.SIARDEVC_NUM_APOL_SINISTRO}'
											AND DATA_MOVIMENTO = '{this.SINISHIS_DATA_MOVIMENTO}'";

            return query;
        }
        public string SINISHIS_NOM_PROGRAMA { get; set; }
        public string SIARDEVC_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }

        public static R1010_00_CHECA_ESTORNO_DB_SELECT_2_Query1 Execute(R1010_00_CHECA_ESTORNO_DB_SELECT_2_Query1 r1010_00_CHECA_ESTORNO_DB_SELECT_2_Query1)
        {
            var ths = r1010_00_CHECA_ESTORNO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1010_00_CHECA_ESTORNO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1010_00_CHECA_ESTORNO_DB_SELECT_2_Query1();
            var i = 0;
            dta.SINISHIS_NOM_PROGRAMA = result[i++].Value?.ToString();
            return dta;
        }

    }
}