using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.RE0001S
{
    public class R0500_00_SELECT_V0HISTORES_DB_SELECT_1_Query1 : QueryBasis<R0500_00_SELECT_V0HISTORES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(SUM(PRERSP),+0),
            VALUE(SUM(COMRSP),+0),
            DECIMAL(VALUE(SUM(ROUND((VLSEGURO * PCTRSP/100),2)),+0),15,2)
            INTO :V0HISR-PRERSP,
            :V0HISR-COMRSP,
            :WHOST-IMPSEG-ER
            FROM SEGUROS.V0HISTORES
            WHERE NUM_APOLICE = :WHOST-NUM-APOL
            AND NRENDOS = :WHOST-NRENDOS
            AND RAMOFR = :WHOST-RAMOFR
            AND OPERACAO IN (0101,0102)
            AND SITUACAO <> '2'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(PRERSP)
							,+0)
							,
											VALUE(SUM(COMRSP)
							,+0)
							,
											DECIMAL(VALUE(SUM(ROUND((VLSEGURO * PCTRSP/100)
							,2))
							,+0)
							,15
							,2)
											FROM SEGUROS.V0HISTORES
											WHERE NUM_APOLICE = '{this.WHOST_NUM_APOL}'
											AND NRENDOS = '{this.WHOST_NRENDOS}'
											AND RAMOFR = '{this.WHOST_RAMOFR}'
											AND OPERACAO IN (0101
							,0102)
											AND SITUACAO <> '2'
											WITH UR";

            return query;
        }
        public string V0HISR_PRERSP { get; set; }
        public string V0HISR_COMRSP { get; set; }
        public string WHOST_IMPSEG_ER { get; set; }
        public string WHOST_NUM_APOL { get; set; }
        public string WHOST_NRENDOS { get; set; }
        public string WHOST_RAMOFR { get; set; }

        public static R0500_00_SELECT_V0HISTORES_DB_SELECT_1_Query1 Execute(R0500_00_SELECT_V0HISTORES_DB_SELECT_1_Query1 r0500_00_SELECT_V0HISTORES_DB_SELECT_1_Query1)
        {
            var ths = r0500_00_SELECT_V0HISTORES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0500_00_SELECT_V0HISTORES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0500_00_SELECT_V0HISTORES_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HISR_PRERSP = result[i++].Value?.ToString();
            dta.V0HISR_COMRSP = result[i++].Value?.ToString();
            dta.WHOST_IMPSEG_ER = result[i++].Value?.ToString();
            return dta;
        }

    }
}