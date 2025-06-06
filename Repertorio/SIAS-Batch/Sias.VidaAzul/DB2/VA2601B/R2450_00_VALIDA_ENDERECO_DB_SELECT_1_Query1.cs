using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2601B
{
    public class R2450_00_VALIDA_ENDERECO_DB_SELECT_1_Query1 : QueryBasis<R2450_00_VALIDA_ENDERECO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIGLA_UF
            INTO :WS-SIGLA-UF
            FROM SEGUROS.UNIDADE_FEDERACAO
            WHERE SIGLA_UF = :DCLPESSOA-ENDERECO.SIGLA-UF
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT SIGLA_UF
											FROM SEGUROS.UNIDADE_FEDERACAO
											WHERE SIGLA_UF = '{this.SIGLA_UF}'";

            return query;
        }
        public string WS_SIGLA_UF { get; set; }
        public string SIGLA_UF { get; set; }

        public static R2450_00_VALIDA_ENDERECO_DB_SELECT_1_Query1 Execute(R2450_00_VALIDA_ENDERECO_DB_SELECT_1_Query1 r2450_00_VALIDA_ENDERECO_DB_SELECT_1_Query1)
        {
            var ths = r2450_00_VALIDA_ENDERECO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2450_00_VALIDA_ENDERECO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2450_00_VALIDA_ENDERECO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_SIGLA_UF = result[i++].Value?.ToString();
            return dta;
        }

    }
}