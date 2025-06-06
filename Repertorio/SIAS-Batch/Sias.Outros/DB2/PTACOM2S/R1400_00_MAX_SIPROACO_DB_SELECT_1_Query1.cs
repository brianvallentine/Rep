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
    public class R1400_00_MAX_SIPROACO_DB_SELECT_1_Query1 : QueryBasis<R1400_00_MAX_SIPROACO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(OCORR_HISTORICO), 0)
            INTO :SIPROACO-OCORR-HISTORICO
            FROM SEGUROS.SI_PROTOCOLO_ACOMP
            WHERE COD_FONTE = :SIDOCACO-COD-FONTE
            AND NUM_PROTOCOLO_SINI = :SIDOCACO-NUM-PROTOCOLO-SINI
            AND DAC_PROTOCOLO_SINI = :SIDOCACO-DAC-PROTOCOLO-SINI
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(OCORR_HISTORICO)
							, 0)
											FROM SEGUROS.SI_PROTOCOLO_ACOMP
											WHERE COD_FONTE = '{this.SIDOCACO_COD_FONTE}'
											AND NUM_PROTOCOLO_SINI = '{this.SIDOCACO_NUM_PROTOCOLO_SINI}'
											AND DAC_PROTOCOLO_SINI = '{this.SIDOCACO_DAC_PROTOCOLO_SINI}'";

            return query;
        }
        public string SIPROACO_OCORR_HISTORICO { get; set; }
        public string SIDOCACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SIDOCACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SIDOCACO_COD_FONTE { get; set; }

        public static R1400_00_MAX_SIPROACO_DB_SELECT_1_Query1 Execute(R1400_00_MAX_SIPROACO_DB_SELECT_1_Query1 r1400_00_MAX_SIPROACO_DB_SELECT_1_Query1)
        {
            var ths = r1400_00_MAX_SIPROACO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_MAX_SIPROACO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_MAX_SIPROACO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIPROACO_OCORR_HISTORICO = result[i++].Value?.ToString();
            return dta;
        }

    }
}