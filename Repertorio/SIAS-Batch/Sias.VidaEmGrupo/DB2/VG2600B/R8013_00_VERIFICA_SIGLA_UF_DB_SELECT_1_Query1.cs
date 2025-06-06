using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R8013_00_VERIFICA_SIGLA_UF_DB_SELECT_1_Query1 : QueryBasis<R8013_00_VERIFICA_SIGLA_UF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIGLA_UF
            INTO :ENDERECO-SIGLA-UF
            FROM SEGUROS.UNIDADE_FEDERACAO
            WHERE SIGLA_UF = :ENDERECO-SIGLA-UF
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT SIGLA_UF
											FROM SEGUROS.UNIDADE_FEDERACAO
											WHERE SIGLA_UF = '{this.ENDERECO_SIGLA_UF}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string ENDERECO_SIGLA_UF { get; set; }

        public static R8013_00_VERIFICA_SIGLA_UF_DB_SELECT_1_Query1 Execute(R8013_00_VERIFICA_SIGLA_UF_DB_SELECT_1_Query1 r8013_00_VERIFICA_SIGLA_UF_DB_SELECT_1_Query1)
        {
            var ths = r8013_00_VERIFICA_SIGLA_UF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8013_00_VERIFICA_SIGLA_UF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8013_00_VERIFICA_SIGLA_UF_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDERECO_SIGLA_UF = result[i++].Value?.ToString();
            return dta;
        }

    }
}