using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_1_Query1 : QueryBasis<R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(VLPREMIO), 0)
            INTO :WHOST-VL-PRM-1PARC
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :V0HISC-NRCERTIF
            AND DATA_INIVIGENCIA <= :WHOST-DT-VENC-PARC
            AND DATA_TERVIGENCIA >= :WHOST-DT-VENC-PARC
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(VLPREMIO)
							, 0)
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.V0HISC_NRCERTIF}'
											AND DATA_INIVIGENCIA <= '{this.WHOST_DT_VENC_PARC}'
											AND DATA_TERVIGENCIA >= '{this.WHOST_DT_VENC_PARC}'
											WITH UR";

            return query;
        }
        public string WHOST_VL_PRM_1PARC { get; set; }
        public string WHOST_DT_VENC_PARC { get; set; }
        public string V0HISC_NRCERTIF { get; set; }

        public static R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_1_Query1 Execute(R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_1_Query1 r8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_1_Query1)
        {
            var ths = r8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_VL_PRM_1PARC = result[i++].Value?.ToString();
            return dta;
        }

    }
}