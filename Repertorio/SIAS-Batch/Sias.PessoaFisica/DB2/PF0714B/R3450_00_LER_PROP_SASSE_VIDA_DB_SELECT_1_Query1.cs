using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0714B
{
    public class R3450_00_LER_PROP_SASSE_VIDA_DB_SELECT_1_Query1 : QueryBasis<R3450_00_LER_PROP_SASSE_VIDA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE ,
            COD_SUBGRUPO
            INTO :PROPSSVD-NUM-APOLICE ,
            :PROPSSVD-COD-SUBGRUPO
            FROM SEGUROS.PROP_SASSE_VIDA
            WHERE NUM_IDENTIFICACAO = :PROPSSVD-NUM-IDENTIFICACAO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
							,
											COD_SUBGRUPO
											FROM SEGUROS.PROP_SASSE_VIDA
											WHERE NUM_IDENTIFICACAO = '{this.PROPSSVD_NUM_IDENTIFICACAO}'
											WITH UR";

            return query;
        }
        public string PROPSSVD_NUM_APOLICE { get; set; }
        public string PROPSSVD_COD_SUBGRUPO { get; set; }
        public string PROPSSVD_NUM_IDENTIFICACAO { get; set; }

        public static R3450_00_LER_PROP_SASSE_VIDA_DB_SELECT_1_Query1 Execute(R3450_00_LER_PROP_SASSE_VIDA_DB_SELECT_1_Query1 r3450_00_LER_PROP_SASSE_VIDA_DB_SELECT_1_Query1)
        {
            var ths = r3450_00_LER_PROP_SASSE_VIDA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3450_00_LER_PROP_SASSE_VIDA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3450_00_LER_PROP_SASSE_VIDA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPSSVD_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPSSVD_COD_SUBGRUPO = result[i++].Value?.ToString();
            return dta;
        }

    }
}