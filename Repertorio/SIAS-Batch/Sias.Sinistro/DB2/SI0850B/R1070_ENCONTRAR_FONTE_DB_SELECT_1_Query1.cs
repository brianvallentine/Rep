using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0850B
{
    public class R1070_ENCONTRAR_FONTE_DB_SELECT_1_Query1 : QueryBasis<R1070_ENCONTRAR_FONTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT NOME_FONTE
            INTO :FONTES-NOME-FONTE
            FROM SEGUROS.FONTES
            WHERE COD_FONTE = :SINISMES-COD-FONTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_FONTE
											FROM SEGUROS.FONTES
											WHERE COD_FONTE = '{this.SINISMES_COD_FONTE}'";

            return query;
        }
        public string FONTES_NOME_FONTE { get; set; }
        public string SINISMES_COD_FONTE { get; set; }

        public static R1070_ENCONTRAR_FONTE_DB_SELECT_1_Query1 Execute(R1070_ENCONTRAR_FONTE_DB_SELECT_1_Query1 r1070_ENCONTRAR_FONTE_DB_SELECT_1_Query1)
        {
            var ths = r1070_ENCONTRAR_FONTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1070_ENCONTRAR_FONTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1070_ENCONTRAR_FONTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.FONTES_NOME_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}