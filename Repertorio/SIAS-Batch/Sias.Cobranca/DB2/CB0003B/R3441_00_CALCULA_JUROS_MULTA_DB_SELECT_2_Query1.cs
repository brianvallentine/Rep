using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_2_Query1 : QueryBasis<R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT (DAYS(:V1MCOB-DTQITBCO) -
            DAYS(:GE403-DTA-VENCIMENTO))
            INTO :WS-QTD-DIAS
            FROM SYSIBM.SYSDUMMY1
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT (DAYS('{this.V1MCOB_DTQITBCO}') -
											DAYS('{this.GE403_DTA_VENCIMENTO}'))
											FROM SYSIBM.SYSDUMMY1";

            return query;
        }
        public string WS_QTD_DIAS { get; set; }
        public string GE403_DTA_VENCIMENTO { get; set; }
        public string V1MCOB_DTQITBCO { get; set; }

        public static R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_2_Query1 Execute(R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_2_Query1 r3441_00_CALCULA_JUROS_MULTA_DB_SELECT_2_Query1)
        {
            var ths = r3441_00_CALCULA_JUROS_MULTA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_2_Query1();
            var i = 0;
            dta.WS_QTD_DIAS = result[i++].Value?.ToString();
            return dta;
        }

    }
}