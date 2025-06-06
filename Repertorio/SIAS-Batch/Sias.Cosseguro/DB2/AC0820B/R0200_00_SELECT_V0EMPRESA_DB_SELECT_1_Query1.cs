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
    public class R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1 : QueryBasis<R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_EMPRESA,
            CGCCPF
            INTO :V0EMPR-NOM-EMP,
            :V0EMPR-CGCCPF
            FROM SEGUROS.V0EMPRESA
            WHERE COD_EMPRESA = 99
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_EMPRESA
							,
											CGCCPF
											FROM SEGUROS.V0EMPRESA
											WHERE COD_EMPRESA = 99
											WITH UR";

            return query;
        }
        public string V0EMPR_NOM_EMP { get; set; }
        public string V0EMPR_CGCCPF { get; set; }

        public static R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1 Execute(R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1 r0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1)
        {
            var ths = r0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0EMPR_NOM_EMP = result[i++].Value?.ToString();
            dta.V0EMPR_CGCCPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}