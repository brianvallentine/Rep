using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PTACOMOS
{
    public class R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1 : QueryBasis<R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_ESTIPULANTE,
            COD_PRODUTO,
            RAMO_EMISSOR,
            COD_CAUSA
            INTO :SIMOVSIN-COD-ESTIPULANTE,
            :SIMOVSIN-COD-PRODUTO,
            :SIMOVSIN-RAMO-EMISSOR,
            :SIMOVSIN-COD-CAUSA
            FROM SEGUROS.SI_MOVIMENTO_SINI
            WHERE COD_FONTE = :SISINACO-COD-FONTE
            AND NUM_PROTOCOLO_SINI = :SISINACO-NUM-PROTOCOLO-SINI
            AND DAC_PROTOCOLO_SINI = :SISINACO-DAC-PROTOCOLO-SINI
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_ESTIPULANTE
							,
											COD_PRODUTO
							,
											RAMO_EMISSOR
							,
											COD_CAUSA
											FROM SEGUROS.SI_MOVIMENTO_SINI
											WHERE COD_FONTE = '{this.SISINACO_COD_FONTE}'
											AND NUM_PROTOCOLO_SINI = '{this.SISINACO_NUM_PROTOCOLO_SINI}'
											AND DAC_PROTOCOLO_SINI = '{this.SISINACO_DAC_PROTOCOLO_SINI}'";

            return query;
        }
        public string SIMOVSIN_COD_ESTIPULANTE { get; set; }
        public string SIMOVSIN_COD_PRODUTO { get; set; }
        public string SIMOVSIN_RAMO_EMISSOR { get; set; }
        public string SIMOVSIN_COD_CAUSA { get; set; }
        public string SISINACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SISINACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SISINACO_COD_FONTE { get; set; }

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
            dta.SIMOVSIN_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SIMOVSIN_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.SIMOVSIN_COD_CAUSA = result[i++].Value?.ToString();
            return dta;
        }

    }
}