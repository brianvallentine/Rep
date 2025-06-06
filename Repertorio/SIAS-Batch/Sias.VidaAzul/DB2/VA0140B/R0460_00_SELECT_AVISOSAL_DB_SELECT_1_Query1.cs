using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0140B
{
    public class R0460_00_SELECT_AVISOSAL_DB_SELECT_1_Query1 : QueryBasis<R0460_00_SELECT_AVISOSAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SALDO_ATUAL
            INTO :AVISOSAL-SALDO-ATUAL
            FROM SEGUROS.AVISOS_SALDOS
            WHERE BCO_AVISO = :AVISOSAL-BCO-AVISO
            AND AGE_AVISO = :AVISOSAL-AGE-AVISO
            AND NUM_AVISO_CREDITO = :AVISOSAL-NUM-AVISO-CREDITO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SALDO_ATUAL
											FROM SEGUROS.AVISOS_SALDOS
											WHERE BCO_AVISO = '{this.AVISOSAL_BCO_AVISO}'
											AND AGE_AVISO = '{this.AVISOSAL_AGE_AVISO}'
											AND NUM_AVISO_CREDITO = '{this.AVISOSAL_NUM_AVISO_CREDITO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string AVISOSAL_SALDO_ATUAL { get; set; }
        public string AVISOSAL_NUM_AVISO_CREDITO { get; set; }
        public string AVISOSAL_BCO_AVISO { get; set; }
        public string AVISOSAL_AGE_AVISO { get; set; }

        public static R0460_00_SELECT_AVISOSAL_DB_SELECT_1_Query1 Execute(R0460_00_SELECT_AVISOSAL_DB_SELECT_1_Query1 r0460_00_SELECT_AVISOSAL_DB_SELECT_1_Query1)
        {
            var ths = r0460_00_SELECT_AVISOSAL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0460_00_SELECT_AVISOSAL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0460_00_SELECT_AVISOSAL_DB_SELECT_1_Query1();
            var i = 0;
            dta.AVISOSAL_SALDO_ATUAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}