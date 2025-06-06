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
    public class R0200_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1 : QueryBasis<R0200_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(SUM(PRM_TARIFARIO),+0)
            INTO :V0HISP-PRM-TAR
            FROM SEGUROS.V0HISTOPARC
            WHERE NUM_APOLICE = :WHOST-NUM-APOL
            AND NRENDOS = :WHOST-NRENDOS
            AND OCORHIST = 01
            AND OPERACAO < 0200
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(PRM_TARIFARIO)
							,+0)
											FROM SEGUROS.V0HISTOPARC
											WHERE NUM_APOLICE = '{this.WHOST_NUM_APOL}'
											AND NRENDOS = '{this.WHOST_NRENDOS}'
											AND OCORHIST = 01
											AND OPERACAO < 0200
											WITH UR";

            return query;
        }
        public string V0HISP_PRM_TAR { get; set; }
        public string WHOST_NUM_APOL { get; set; }
        public string WHOST_NRENDOS { get; set; }

        public static R0200_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1 Execute(R0200_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1 r0200_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1)
        {
            var ths = r0200_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0200_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0200_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HISP_PRM_TAR = result[i++].Value?.ToString();
            return dta;
        }

    }
}