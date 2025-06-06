using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0820B
{
    public class R0600_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1 : QueryBasis<R0600_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_EMPRESA,
            NOME_EMPRESA
            INTO :V0EMPR-COD-EMP,
            :V0EMPR-NOM-EMP
            FROM SEGUROS.V0EMPRESA
            WHERE COD_EMPRESA = :V0CCCH-COD-EMPR
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_EMPRESA
							,
											NOME_EMPRESA
											FROM SEGUROS.V0EMPRESA
											WHERE COD_EMPRESA = '{this.V0CCCH_COD_EMPR}'
											WITH UR";

            return query;
        }
        public string V0EMPR_COD_EMP { get; set; }
        public string V0EMPR_NOM_EMP { get; set; }
        public string V0CCCH_COD_EMPR { get; set; }

        public static R0600_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1 Execute(R0600_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1 r0600_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1)
        {
            var ths = r0600_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0600_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0600_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0EMPR_COD_EMP = result[i++].Value?.ToString();
            dta.V0EMPR_NOM_EMP = result[i++].Value?.ToString();
            return dta;
        }

    }
}