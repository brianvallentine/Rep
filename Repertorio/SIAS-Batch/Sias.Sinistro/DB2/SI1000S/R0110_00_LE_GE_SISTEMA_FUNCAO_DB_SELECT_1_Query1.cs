using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI1000S
{
    public class R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1 : QueryBasis<R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOM_FUNCAO
            INTO :GESISFUN-NOM-FUNCAO
            FROM SEGUROS.GE_SISTEMA_FUNCAO
            WHERE IDE_SISTEMA = :GESISFUN-IDE-SISTEMA
            AND COD_FUNCAO = :GESISFUN-COD-FUNCAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOM_FUNCAO
											FROM SEGUROS.GE_SISTEMA_FUNCAO
											WHERE IDE_SISTEMA = '{this.GESISFUN_IDE_SISTEMA}'
											AND COD_FUNCAO = '{this.GESISFUN_COD_FUNCAO}'";

            return query;
        }
        public string GESISFUN_NOM_FUNCAO { get; set; }
        public string GESISFUN_IDE_SISTEMA { get; set; }
        public string GESISFUN_COD_FUNCAO { get; set; }

        public static R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1 Execute(R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1 r0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1)
        {
            var ths = r0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.GESISFUN_NOM_FUNCAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}