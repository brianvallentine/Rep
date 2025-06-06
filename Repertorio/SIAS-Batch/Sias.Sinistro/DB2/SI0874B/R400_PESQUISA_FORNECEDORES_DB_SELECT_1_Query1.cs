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
    public class R400_PESQUISA_FORNECEDORES_DB_SELECT_1_Query1 : QueryBasis<R400_PESQUISA_FORNECEDORES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CGCCPF
            INTO :FORNECED-CGCCPF
            FROM SEGUROS.FORNECEDORES
            WHERE COD_FORNECEDOR = :SINISHIS-COD-PREST-SERVICO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CGCCPF
											FROM SEGUROS.FORNECEDORES
											WHERE COD_FORNECEDOR = '{this.SINISHIS_COD_PREST_SERVICO}'";

            return query;
        }
        public string FORNECED_CGCCPF { get; set; }
        public string SINISHIS_COD_PREST_SERVICO { get; set; }

        public static R400_PESQUISA_FORNECEDORES_DB_SELECT_1_Query1 Execute(R400_PESQUISA_FORNECEDORES_DB_SELECT_1_Query1 r400_PESQUISA_FORNECEDORES_DB_SELECT_1_Query1)
        {
            var ths = r400_PESQUISA_FORNECEDORES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R400_PESQUISA_FORNECEDORES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R400_PESQUISA_FORNECEDORES_DB_SELECT_1_Query1();
            var i = 0;
            dta.FORNECED_CGCCPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}