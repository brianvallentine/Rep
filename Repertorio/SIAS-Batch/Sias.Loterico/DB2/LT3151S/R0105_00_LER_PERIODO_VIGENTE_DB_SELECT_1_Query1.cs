using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT3151S
{
    public class R0105_00_LER_PERIODO_VIGENTE_DB_SELECT_1_Query1 : QueryBasis<R0105_00_LER_PERIODO_VIGENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WS-QT-REG
            FROM SEGUROS.LT_SOLICITA_PARAM
            WHERE COD_PROGRAMA = :LTSOLPAR-COD-PROGRAMA
            AND COD_PRODUTO = :LTSOLPAR-COD-PRODUTO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.LT_SOLICITA_PARAM
											WHERE COD_PROGRAMA = '{this.LTSOLPAR_COD_PROGRAMA}'
											AND COD_PRODUTO = '{this.LTSOLPAR_COD_PRODUTO}'
											WITH UR";

            return query;
        }
        public string WS_QT_REG { get; set; }
        public string LTSOLPAR_COD_PROGRAMA { get; set; }
        public string LTSOLPAR_COD_PRODUTO { get; set; }

        public static R0105_00_LER_PERIODO_VIGENTE_DB_SELECT_1_Query1 Execute(R0105_00_LER_PERIODO_VIGENTE_DB_SELECT_1_Query1 r0105_00_LER_PERIODO_VIGENTE_DB_SELECT_1_Query1)
        {
            var ths = r0105_00_LER_PERIODO_VIGENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0105_00_LER_PERIODO_VIGENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0105_00_LER_PERIODO_VIGENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_QT_REG = result[i++].Value?.ToString();
            return dta;
        }

    }
}