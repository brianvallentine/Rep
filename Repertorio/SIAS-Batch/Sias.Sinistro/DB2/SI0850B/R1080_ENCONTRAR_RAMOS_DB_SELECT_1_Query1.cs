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
    public class R1080_ENCONTRAR_RAMOS_DB_SELECT_1_Query1 : QueryBasis<R1080_ENCONTRAR_RAMOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT NOME_RAMO
            INTO :RAMOS-NOME-RAMO
            FROM SEGUROS.RAMOS
            WHERE RAMO_EMISSOR = :SINISMES-RAMO
            AND COD_MODALIDADE = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_RAMO
											FROM SEGUROS.RAMOS
											WHERE RAMO_EMISSOR = '{this.SINISMES_RAMO}'
											AND COD_MODALIDADE = 0";

            return query;
        }
        public string RAMOS_NOME_RAMO { get; set; }
        public string SINISMES_RAMO { get; set; }

        public static R1080_ENCONTRAR_RAMOS_DB_SELECT_1_Query1 Execute(R1080_ENCONTRAR_RAMOS_DB_SELECT_1_Query1 r1080_ENCONTRAR_RAMOS_DB_SELECT_1_Query1)
        {
            var ths = r1080_ENCONTRAR_RAMOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1080_ENCONTRAR_RAMOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1080_ENCONTRAR_RAMOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RAMOS_NOME_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}