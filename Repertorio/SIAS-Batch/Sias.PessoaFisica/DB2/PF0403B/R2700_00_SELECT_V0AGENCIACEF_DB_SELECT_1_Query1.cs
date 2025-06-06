using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0403B
{
    public class R2700_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1 : QueryBasis<R2700_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_AGENCIA
            INTO :V0AGEN-NOMEAGE
            FROM SEGUROS.V0AGENCIACEF
            WHERE COD_AGENCIA = :WHOST-AGENCIA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_AGENCIA
											FROM SEGUROS.V0AGENCIACEF
											WHERE COD_AGENCIA = '{this.WHOST_AGENCIA}'
											WITH UR";

            return query;
        }
        public string V0AGEN_NOMEAGE { get; set; }
        public string WHOST_AGENCIA { get; set; }

        public static R2700_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1 Execute(R2700_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1 r2700_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1)
        {
            var ths = r2700_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2700_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2700_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0AGEN_NOMEAGE = result[i++].Value?.ToString();
            return dta;
        }

    }
}