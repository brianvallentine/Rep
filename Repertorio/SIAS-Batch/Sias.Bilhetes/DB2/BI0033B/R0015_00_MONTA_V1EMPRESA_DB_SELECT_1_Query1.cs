using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0033B
{
    public class R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1 : QueryBasis<R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT NOME_EMPRESA
            INTO :V1EMPR-NOM-EMP
            FROM SEGUROS.V0EMPRESA
            WHERE COD_EMPRESA = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_EMPRESA
											FROM SEGUROS.V0EMPRESA
											WHERE COD_EMPRESA = 0";

            return query;
        }
        public string V1EMPR_NOM_EMP { get; set; }

        public static R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1 Execute(R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1 r0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1)
        {
            var ths = r0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1EMPR_NOM_EMP = result[i++].Value?.ToString();
            return dta;
        }

    }
}