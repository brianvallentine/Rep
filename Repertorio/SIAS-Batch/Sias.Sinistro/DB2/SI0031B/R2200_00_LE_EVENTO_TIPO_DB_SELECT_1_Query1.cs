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
    public class R2200_00_LE_EVENTO_TIPO_DB_SELECT_1_Query1 : QueryBasis<R2200_00_LE_EVENTO_TIPO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_EVENTO,
            IND_SINISTRO_ACOMP
            INTO :SIEVETIP-COD-EVENTO,
            :SIEVETIP-IND-SINISTRO-ACOMP
            FROM SEGUROS.SI_EVENTO_TIPO
            WHERE COD_TIPO_CARTA = :SIDOCPAR-COD-TIPO-CARTA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_EVENTO
							,
											IND_SINISTRO_ACOMP
											FROM SEGUROS.SI_EVENTO_TIPO
											WHERE COD_TIPO_CARTA = '{this.SIDOCPAR_COD_TIPO_CARTA}'";

            return query;
        }
        public string SIEVETIP_COD_EVENTO { get; set; }
        public string SIEVETIP_IND_SINISTRO_ACOMP { get; set; }
        public string SIDOCPAR_COD_TIPO_CARTA { get; set; }

        public static R2200_00_LE_EVENTO_TIPO_DB_SELECT_1_Query1 Execute(R2200_00_LE_EVENTO_TIPO_DB_SELECT_1_Query1 r2200_00_LE_EVENTO_TIPO_DB_SELECT_1_Query1)
        {
            var ths = r2200_00_LE_EVENTO_TIPO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2200_00_LE_EVENTO_TIPO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2200_00_LE_EVENTO_TIPO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIEVETIP_COD_EVENTO = result[i++].Value?.ToString();
            dta.SIEVETIP_IND_SINISTRO_ACOMP = result[i++].Value?.ToString();
            return dta;
        }

    }
}