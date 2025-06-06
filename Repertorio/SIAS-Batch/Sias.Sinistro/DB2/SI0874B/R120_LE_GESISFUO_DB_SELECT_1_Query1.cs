using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0874B
{
    public class R120_LE_GESISFUO_DB_SELECT_1_Query1 : QueryBasis<R120_LE_GESISFUO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_FATOR
            INTO :GESISFUO-NUM-FATOR
            FROM SEGUROS.GE_SIS_FUNCAO_OPER
            WHERE IDE_SISTEMA = 'SI'
            AND COD_FUNCAO IN (5, 6, 15, 16)
            AND IDE_SISTEMA_OPER = IDE_SISTEMA
            AND COD_OPERACAO = :SINISHIS-COD-OPERACAO
            AND TIPO_ENDOSSO = '9'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_FATOR
											FROM SEGUROS.GE_SIS_FUNCAO_OPER
											WHERE IDE_SISTEMA = 'SI'
											AND COD_FUNCAO IN (5
							, 6
							, 15
							, 16)
											AND IDE_SISTEMA_OPER = IDE_SISTEMA
											AND COD_OPERACAO = '{this.SINISHIS_COD_OPERACAO}'
											AND TIPO_ENDOSSO = '9'";

            return query;
        }
        public string GESISFUO_NUM_FATOR { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }

        public static R120_LE_GESISFUO_DB_SELECT_1_Query1 Execute(R120_LE_GESISFUO_DB_SELECT_1_Query1 r120_LE_GESISFUO_DB_SELECT_1_Query1)
        {
            var ths = r120_LE_GESISFUO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R120_LE_GESISFUO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R120_LE_GESISFUO_DB_SELECT_1_Query1();
            var i = 0;
            dta.GESISFUO_NUM_FATOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}