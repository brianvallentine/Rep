using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0355S
{
    public class R2000_00_CALCULA_FATOR_VENC_DB_SELECT_1_Query1 : QueryBasis<R2000_00_CALCULA_FATOR_VENC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DAYS(DATE(:WS-DATA-VENCIMENTO))
            - DAYS( '1997-10-07' )
            INTO :WS-FATOR-VENC
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'FI'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DAYS(DATE('{this.WS_DATA_VENCIMENTO}'))
											- DAYS( '1997-10-07' )
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'FI'
											WITH UR";

            return query;
        }
        public string WS_FATOR_VENC { get; set; }
        public string WS_DATA_VENCIMENTO { get; set; }

        public static R2000_00_CALCULA_FATOR_VENC_DB_SELECT_1_Query1 Execute(R2000_00_CALCULA_FATOR_VENC_DB_SELECT_1_Query1 r2000_00_CALCULA_FATOR_VENC_DB_SELECT_1_Query1)
        {
            var ths = r2000_00_CALCULA_FATOR_VENC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2000_00_CALCULA_FATOR_VENC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2000_00_CALCULA_FATOR_VENC_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_FATOR_VENC = result[i++].Value?.ToString();
            return dta;
        }

    }
}