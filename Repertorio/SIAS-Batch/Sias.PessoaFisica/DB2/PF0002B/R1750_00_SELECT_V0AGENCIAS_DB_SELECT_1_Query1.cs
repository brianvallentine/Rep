using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0002B
{
    public class R1750_00_SELECT_V0AGENCIAS_DB_SELECT_1_Query1 : QueryBasis<R1750_00_SELECT_V0AGENCIAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ESTADO
            INTO :V0AGEN-ESTADO
            FROM SEGUROS.V0AGENCIAS
            WHERE BANCO = :V0AGEN-BANCO
            AND AGENCIA = :V0AGEN-AGENCIA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ESTADO
											FROM SEGUROS.V0AGENCIAS
											WHERE BANCO = '{this.V0AGEN_BANCO}'
											AND AGENCIA = '{this.V0AGEN_AGENCIA}'
											WITH UR";

            return query;
        }
        public string V0AGEN_ESTADO { get; set; }
        public string V0AGEN_AGENCIA { get; set; }
        public string V0AGEN_BANCO { get; set; }

        public static R1750_00_SELECT_V0AGENCIAS_DB_SELECT_1_Query1 Execute(R1750_00_SELECT_V0AGENCIAS_DB_SELECT_1_Query1 r1750_00_SELECT_V0AGENCIAS_DB_SELECT_1_Query1)
        {
            var ths = r1750_00_SELECT_V0AGENCIAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1750_00_SELECT_V0AGENCIAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1750_00_SELECT_V0AGENCIAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0AGEN_ESTADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}