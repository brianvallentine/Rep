using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0127B
{
    public class M_0000_PRINCIPAL_DB_SELECT_3_Query1 : QueryBasis<M_0000_PRINCIPAL_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            DATA_INIVIGENCIA,
            DATA_INIVIGENCIA - 1 DAY,
            PCT_IOCC_RAMO
            INTO
            :RAMOCOMP-DATA-INIVIGENCIA,
            :V0RIND-DTMOVTO-1DAY,
            :RAMOCOMP-PCT-IOCC-RAMO
            FROM
            SEGUROS.RAMO_COMPLEMENTAR
            WHERE
            RAMO_EMISSOR = :PARAMRAM-RAMO-VG
            AND DATA_INIVIGENCIA <= :V0RIND-DTMOVTO
            AND DATA_TERVIGENCIA >= :V0RIND-DTMOVTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											DATA_INIVIGENCIA
							,
											DATA_INIVIGENCIA - 1 DAY
							,
											PCT_IOCC_RAMO
											FROM
											SEGUROS.RAMO_COMPLEMENTAR
											WHERE
											RAMO_EMISSOR = '{this.PARAMRAM_RAMO_VG}'
											AND DATA_INIVIGENCIA <= '{this.V0RIND_DTMOVTO}'
											AND DATA_TERVIGENCIA >= '{this.V0RIND_DTMOVTO}'";

            return query;
        }
        public string RAMOCOMP_DATA_INIVIGENCIA { get; set; }
        public string V0RIND_DTMOVTO_1DAY { get; set; }
        public string RAMOCOMP_PCT_IOCC_RAMO { get; set; }
        public string PARAMRAM_RAMO_VG { get; set; }
        public string V0RIND_DTMOVTO { get; set; }

        public static M_0000_PRINCIPAL_DB_SELECT_3_Query1 Execute(M_0000_PRINCIPAL_DB_SELECT_3_Query1 m_0000_PRINCIPAL_DB_SELECT_3_Query1)
        {
            var ths = m_0000_PRINCIPAL_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_PRINCIPAL_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_PRINCIPAL_DB_SELECT_3_Query1();
            var i = 0;
            dta.RAMOCOMP_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.V0RIND_DTMOVTO_1DAY = result[i++].Value?.ToString();
            dta.RAMOCOMP_PCT_IOCC_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}