using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0590B
{
    public class R0800_00_LE_GE_OPE_CRE_DB_SELECT_1_Query1 : QueryBasis<R0800_00_LE_GE_OPE_CRE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DES_OPER_CREDITO
            INTO :GE372-DES-OPER-CREDITO
            FROM SEGUROS.GE_OPER_CREDITO
            WHERE COD_OPER_CREDITO = :GE372-COD-OPER-CREDITO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DES_OPER_CREDITO
											FROM SEGUROS.GE_OPER_CREDITO
											WHERE COD_OPER_CREDITO = '{this.GE372_COD_OPER_CREDITO}'
											WITH UR";

            return query;
        }
        public string GE372_DES_OPER_CREDITO { get; set; }
        public string GE372_COD_OPER_CREDITO { get; set; }

        public static R0800_00_LE_GE_OPE_CRE_DB_SELECT_1_Query1 Execute(R0800_00_LE_GE_OPE_CRE_DB_SELECT_1_Query1 r0800_00_LE_GE_OPE_CRE_DB_SELECT_1_Query1)
        {
            var ths = r0800_00_LE_GE_OPE_CRE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0800_00_LE_GE_OPE_CRE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0800_00_LE_GE_OPE_CRE_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE372_DES_OPER_CREDITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}