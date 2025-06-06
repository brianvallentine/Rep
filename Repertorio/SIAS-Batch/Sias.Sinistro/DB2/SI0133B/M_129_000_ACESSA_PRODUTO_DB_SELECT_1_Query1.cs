using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0133B
{
    public class M_129_000_ACESSA_PRODUTO_DB_SELECT_1_Query1 : QueryBasis<M_129_000_ACESSA_PRODUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCRPROD
            INTO :V0PROD-DESCRPROD
            FROM SEGUROS.V0PRODUTO
            WHERE CODPRODU = :MEST-CODPRODU
            AND SITUACAO IN ( '0' , '1' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DESCRPROD
											FROM SEGUROS.V0PRODUTO
											WHERE CODPRODU = '{this.MEST_CODPRODU}'
											AND SITUACAO IN ( '0' 
							, '1' )";

            return query;
        }
        public string V0PROD_DESCRPROD { get; set; }
        public string MEST_CODPRODU { get; set; }

        public static M_129_000_ACESSA_PRODUTO_DB_SELECT_1_Query1 Execute(M_129_000_ACESSA_PRODUTO_DB_SELECT_1_Query1 m_129_000_ACESSA_PRODUTO_DB_SELECT_1_Query1)
        {
            var ths = m_129_000_ACESSA_PRODUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_129_000_ACESSA_PRODUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_129_000_ACESSA_PRODUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PROD_DESCRPROD = result[i++].Value?.ToString();
            return dta;
        }

    }
}