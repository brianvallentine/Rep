using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0071B
{
    public class R0121_00_LE_CONVERSI_DB_SELECT_2_Query1 : QueryBasis<R0121_00_LE_CONVERSI_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO
            INTO :V0CONV-CODPRODU
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE = :V0MOVDE-NUM-APOLICE
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE = '{this.V0MOVDE_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string V0CONV_CODPRODU { get; set; }
        public string V0MOVDE_NUM_APOLICE { get; set; }

        public static R0121_00_LE_CONVERSI_DB_SELECT_2_Query1 Execute(R0121_00_LE_CONVERSI_DB_SELECT_2_Query1 r0121_00_LE_CONVERSI_DB_SELECT_2_Query1)
        {
            var ths = r0121_00_LE_CONVERSI_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0121_00_LE_CONVERSI_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0121_00_LE_CONVERSI_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0CONV_CODPRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}