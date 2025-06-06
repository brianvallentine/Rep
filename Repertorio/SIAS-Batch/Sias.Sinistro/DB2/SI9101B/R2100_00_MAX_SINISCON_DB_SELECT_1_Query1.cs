using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9101B
{
    public class R2100_00_MAX_SINISCON_DB_SELECT_1_Query1 : QueryBasis<R2100_00_MAX_SINISCON_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_PROTOCOLO_SINI),0)
            INTO :SINISCON-NUM-PROTOCOLO-SINI
            FROM SEGUROS.SINISTRO_CONTROLE
            WHERE COD_FONTE = :ENDOSSOS-COD-FONTE
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_PROTOCOLO_SINI)
							,0)
											FROM SEGUROS.SINISTRO_CONTROLE
											WHERE COD_FONTE = '{this.ENDOSSOS_COD_FONTE}'";

            return query;
        }
        public string SINISCON_NUM_PROTOCOLO_SINI { get; set; }
        public string ENDOSSOS_COD_FONTE { get; set; }

        public static R2100_00_MAX_SINISCON_DB_SELECT_1_Query1 Execute(R2100_00_MAX_SINISCON_DB_SELECT_1_Query1 r2100_00_MAX_SINISCON_DB_SELECT_1_Query1)
        {
            var ths = r2100_00_MAX_SINISCON_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2100_00_MAX_SINISCON_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2100_00_MAX_SINISCON_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISCON_NUM_PROTOCOLO_SINI = result[i++].Value?.ToString();
            return dta;
        }

    }
}