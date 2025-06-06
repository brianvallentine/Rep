using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0601B
{
    public class R2247_CALCULO_IDADE_DB_SELECT_2_Query1 : QueryBasis<R2247_CALCULO_IDADE_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DAYS(CURRENT DATE) - DAYS(:WS-DATA-NASCIMENTO)
            INTO :WS-DIAS-ANO
            FROM SYSIBM.SYSDUMMY1
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DAYS(CURRENT DATE) - DAYS('{this.WS_DATA_NASCIMENTO}')
											FROM SYSIBM.SYSDUMMY1";

            return query;
        }
        public string WS_DIAS_ANO { get; set; }
        public string WS_DATA_NASCIMENTO { get; set; }

        public static R2247_CALCULO_IDADE_DB_SELECT_2_Query1 Execute(R2247_CALCULO_IDADE_DB_SELECT_2_Query1 r2247_CALCULO_IDADE_DB_SELECT_2_Query1)
        {
            var ths = r2247_CALCULO_IDADE_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2247_CALCULO_IDADE_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2247_CALCULO_IDADE_DB_SELECT_2_Query1();
            var i = 0;
            dta.WS_DIAS_ANO = result[i++].Value?.ToString();
            return dta;
        }

    }
}