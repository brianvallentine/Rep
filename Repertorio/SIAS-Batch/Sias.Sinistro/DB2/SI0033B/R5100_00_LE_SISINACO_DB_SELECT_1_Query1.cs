using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0033B
{
    public class R5100_00_LE_SISINACO_DB_SELECT_1_Query1 : QueryBasis<R5100_00_LE_SISINACO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOVTO_SINIACO
            INTO :SISINACO-DATA-MOVTO-SINIACO
            FROM SEGUROS.SI_SINISTRO_ACOMP
            WHERE COD_FONTE = :SIDOCACO-COD-FONTE
            AND NUM_PROTOCOLO_SINI =
            :SIDOCACO-NUM-PROTOCOLO-SINI
            AND DAC_PROTOCOLO_SINI =
            :SIDOCACO-DAC-PROTOCOLO-SINI
            AND COD_EVENTO = 1001
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOVTO_SINIACO
											FROM SEGUROS.SI_SINISTRO_ACOMP
											WHERE COD_FONTE = '{this.SIDOCACO_COD_FONTE}'
											AND NUM_PROTOCOLO_SINI =
											'{this.SIDOCACO_NUM_PROTOCOLO_SINI}'
											AND DAC_PROTOCOLO_SINI =
											'{this.SIDOCACO_DAC_PROTOCOLO_SINI}'
											AND COD_EVENTO = 1001";

            return query;
        }
        public string SISINACO_DATA_MOVTO_SINIACO { get; set; }
        public string SIDOCACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SIDOCACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SIDOCACO_COD_FONTE { get; set; }

        public static R5100_00_LE_SISINACO_DB_SELECT_1_Query1 Execute(R5100_00_LE_SISINACO_DB_SELECT_1_Query1 r5100_00_LE_SISINACO_DB_SELECT_1_Query1)
        {
            var ths = r5100_00_LE_SISINACO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5100_00_LE_SISINACO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5100_00_LE_SISINACO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISINACO_DATA_MOVTO_SINIACO = result[i++].Value?.ToString();
            return dta;
        }

    }
}