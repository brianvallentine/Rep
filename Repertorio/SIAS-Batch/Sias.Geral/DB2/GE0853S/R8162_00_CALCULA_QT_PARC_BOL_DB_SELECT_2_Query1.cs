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
    public class R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_2_Query1 : QueryBasis<R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATE(:WHOST-DT-VENC-PARC) - 1 MONTH
            INTO :WHOST-DT-VENC-PARC
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'VA'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATE('{this.WHOST_DT_VENC_PARC}') - 1 MONTH
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'VA'
											WITH UR";

            return query;
        }
        public string WHOST_DT_VENC_PARC { get; set; }

        public static R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_2_Query1 Execute(R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_2_Query1 r8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_2_Query1)
        {
            var ths = r8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_2_Query1();
            var i = 0;
            dta.WHOST_DT_VENC_PARC = result[i++].Value?.ToString();
            return dta;
        }

    }
}