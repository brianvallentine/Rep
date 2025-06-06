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
    public class R8003_00_VERIFICA_AGENCIACEF_DB_SELECT_1_Query1 : QueryBasis<R8003_00_VERIFICA_AGENCIACEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_AGENCIA
            INTO :COD-AGENCIA-CEF
            FROM SEGUROS.AGENCIAS_CEF
            WHERE COD_AGENCIA = :COD-AGENCIA-CEF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_AGENCIA
											FROM SEGUROS.AGENCIAS_CEF
											WHERE COD_AGENCIA = '{this.COD_AGENCIA_CEF}'
											WITH UR";

            return query;
        }
        public string COD_AGENCIA_CEF { get; set; }

        public static R8003_00_VERIFICA_AGENCIACEF_DB_SELECT_1_Query1 Execute(R8003_00_VERIFICA_AGENCIACEF_DB_SELECT_1_Query1 r8003_00_VERIFICA_AGENCIACEF_DB_SELECT_1_Query1)
        {
            var ths = r8003_00_VERIFICA_AGENCIACEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8003_00_VERIFICA_AGENCIACEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8003_00_VERIFICA_AGENCIACEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.COD_AGENCIA_CEF = result[i++].Value?.ToString();
            return dta;
        }

    }
}