using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0241B
{
    public class R0300_00_SELECT_V1EMPRESA_DB_SELECT_1_Query1 : QueryBasis<R0300_00_SELECT_V1EMPRESA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_EMPRESA,
            NOME_EMPRESA
            INTO :V1EMPR-COD-EMP,
            :V1EMPR-NOM-EMP
            FROM SEGUROS.V1EMPRESA
            WHERE COD_EMPRESA = :V1EMPR-COD-EMP
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_EMPRESA
							,
											NOME_EMPRESA
											FROM SEGUROS.V1EMPRESA
											WHERE COD_EMPRESA = '{this.V1EMPR_COD_EMP}'";

            return query;
        }
        public string V1EMPR_COD_EMP { get; set; }
        public string V1EMPR_NOM_EMP { get; set; }

        public static R0300_00_SELECT_V1EMPRESA_DB_SELECT_1_Query1 Execute(R0300_00_SELECT_V1EMPRESA_DB_SELECT_1_Query1 r0300_00_SELECT_V1EMPRESA_DB_SELECT_1_Query1)
        {
            var ths = r0300_00_SELECT_V1EMPRESA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0300_00_SELECT_V1EMPRESA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0300_00_SELECT_V1EMPRESA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1EMPR_COD_EMP = result[i++].Value?.ToString();
            dta.V1EMPR_NOM_EMP = result[i++].Value?.ToString();
            return dta;
        }

    }
}