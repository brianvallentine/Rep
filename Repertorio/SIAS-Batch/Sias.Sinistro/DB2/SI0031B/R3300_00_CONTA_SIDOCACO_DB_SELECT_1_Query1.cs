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
    public class R3300_00_CONTA_SIDOCACO_DB_SELECT_1_Query1 : QueryBasis<R3300_00_CONTA_SIDOCACO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :HOST-COUNT
            FROM SEGUROS.SI_DOCUMENTO_ACOMP
            WHERE COD_FONTE = :H-SIDOCACO-COD-FONTE
            AND NUM_PROTOCOLO_SINI =
            :H-SIDOCACO-NUM-PROTOCOLO-SINI
            AND DAC_PROTOCOLO_SINI =
            :H-SIDOCACO-DAC-PROTOCOLO-SINI
            AND DATA_MOVTO_DOCACO >
            :H-SIDOCACO-DATA-MOVTO-DOCACO
            AND COD_DOCUMENTO IN (50, 17, 46, 42, 37)
            AND NUM_OCORR_DOCACO = 1
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.SI_DOCUMENTO_ACOMP
											WHERE COD_FONTE = '{this.H_SIDOCACO_COD_FONTE}'
											AND NUM_PROTOCOLO_SINI =
											'{this.H_SIDOCACO_NUM_PROTOCOLO_SINI}'
											AND DAC_PROTOCOLO_SINI =
											'{this.H_SIDOCACO_DAC_PROTOCOLO_SINI}'
											AND DATA_MOVTO_DOCACO >
											'{this.H_SIDOCACO_DATA_MOVTO_DOCACO}'
											AND COD_DOCUMENTO IN (50
							, 17
							, 46
							, 42
							, 37)
											AND NUM_OCORR_DOCACO = 1";

            return query;
        }
        public string HOST_COUNT { get; set; }
        public string H_SIDOCACO_NUM_PROTOCOLO_SINI { get; set; }
        public string H_SIDOCACO_DAC_PROTOCOLO_SINI { get; set; }
        public string H_SIDOCACO_DATA_MOVTO_DOCACO { get; set; }
        public string H_SIDOCACO_COD_FONTE { get; set; }

        public static R3300_00_CONTA_SIDOCACO_DB_SELECT_1_Query1 Execute(R3300_00_CONTA_SIDOCACO_DB_SELECT_1_Query1 r3300_00_CONTA_SIDOCACO_DB_SELECT_1_Query1)
        {
            var ths = r3300_00_CONTA_SIDOCACO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3300_00_CONTA_SIDOCACO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3300_00_CONTA_SIDOCACO_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}