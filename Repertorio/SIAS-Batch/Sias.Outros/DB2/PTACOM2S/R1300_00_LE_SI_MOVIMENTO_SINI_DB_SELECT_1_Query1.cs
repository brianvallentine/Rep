using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PTACOM2S
{
    public class R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1 : QueryBasis<R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_ESTIPULANTE
            INTO :SIMOVSIN-COD-ESTIPULANTE
            FROM SEGUROS.SI_MOVIMENTO_SINI
            WHERE COD_FONTE = :SIDOCACO-COD-FONTE
            AND NUM_PROTOCOLO_SINI = :SIDOCACO-NUM-PROTOCOLO-SINI
            AND DAC_PROTOCOLO_SINI = :SIDOCACO-DAC-PROTOCOLO-SINI
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_ESTIPULANTE
											FROM SEGUROS.SI_MOVIMENTO_SINI
											WHERE COD_FONTE = '{this.SIDOCACO_COD_FONTE}'
											AND NUM_PROTOCOLO_SINI = '{this.SIDOCACO_NUM_PROTOCOLO_SINI}'
											AND DAC_PROTOCOLO_SINI = '{this.SIDOCACO_DAC_PROTOCOLO_SINI}'";

            return query;
        }
        public string SIMOVSIN_COD_ESTIPULANTE { get; set; }
        public string SIDOCACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SIDOCACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SIDOCACO_COD_FONTE { get; set; }

        public static R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1 Execute(R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1 r1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIMOVSIN_COD_ESTIPULANTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}