using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF2002B
{
    public class R7050_SELECT_PROPOSTA_DB_SELECT_2_Query1 : QueryBasis<R7050_SELECT_PROPOSTA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT P.COD_PRODUTO
            INTO :PROPOSTA-COD-PRODUTO
            FROM SEGUROS.AU_VENDA_ONLINE P
            WHERE P.NUM_PROPOSTA_CONV = :PROPOAUT-NUM-PROPOSTA-CONV
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT P.COD_PRODUTO
											FROM SEGUROS.AU_VENDA_ONLINE P
											WHERE P.NUM_PROPOSTA_CONV = '{this.PROPOAUT_NUM_PROPOSTA_CONV}'
											WITH UR";

            return query;
        }
        public string PROPOSTA_COD_PRODUTO { get; set; }
        public string PROPOAUT_NUM_PROPOSTA_CONV { get; set; }

        public static R7050_SELECT_PROPOSTA_DB_SELECT_2_Query1 Execute(R7050_SELECT_PROPOSTA_DB_SELECT_2_Query1 r7050_SELECT_PROPOSTA_DB_SELECT_2_Query1)
        {
            var ths = r7050_SELECT_PROPOSTA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7050_SELECT_PROPOSTA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7050_SELECT_PROPOSTA_DB_SELECT_2_Query1();
            var i = 0;
            dta.PROPOSTA_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}