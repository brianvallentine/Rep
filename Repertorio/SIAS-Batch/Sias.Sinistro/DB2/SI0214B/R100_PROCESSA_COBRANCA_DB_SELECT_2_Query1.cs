using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0214B
{
    public class R100_PROCESSA_COBRANCA_DB_SELECT_2_Query1 : QueryBasis<R100_PROCESSA_COBRANCA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT F.CGCCPF,
            F.NOME_FORNECEDOR
            INTO :FORNECED-CGCCPF,
            :FORNECED-NOME-FORNECEDOR
            FROM SEGUROS.FORNECEDORES F
            WHERE F.COD_FORNECEDOR = :SINISHIS-COD-PREST-SERVICO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT F.CGCCPF
							,
											F.NOME_FORNECEDOR
											FROM SEGUROS.FORNECEDORES F
											WHERE F.COD_FORNECEDOR = '{this.SINISHIS_COD_PREST_SERVICO}'
											WITH UR";

            return query;
        }
        public string FORNECED_CGCCPF { get; set; }
        public string FORNECED_NOME_FORNECEDOR { get; set; }
        public string SINISHIS_COD_PREST_SERVICO { get; set; }

        public static R100_PROCESSA_COBRANCA_DB_SELECT_2_Query1 Execute(R100_PROCESSA_COBRANCA_DB_SELECT_2_Query1 r100_PROCESSA_COBRANCA_DB_SELECT_2_Query1)
        {
            var ths = r100_PROCESSA_COBRANCA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R100_PROCESSA_COBRANCA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R100_PROCESSA_COBRANCA_DB_SELECT_2_Query1();
            var i = 0;
            dta.FORNECED_CGCCPF = result[i++].Value?.ToString();
            dta.FORNECED_NOME_FORNECEDOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}