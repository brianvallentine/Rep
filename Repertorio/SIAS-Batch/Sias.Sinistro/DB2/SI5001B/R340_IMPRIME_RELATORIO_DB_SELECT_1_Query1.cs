using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5001B
{
    public class R340_IMPRIME_RELATORIO_DB_SELECT_1_Query1 : QueryBasis<R340_IMPRIME_RELATORIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT C.NOME_RAZAO,
            A.COD_LOT_CEF
            INTO :CLIENTES-NOME-RAZAO,
            :SINILT01-COD-LOT-CEF
            FROM SEGUROS.CLIENTES C, SEGUROS.SINI_LOTERICO01 A
            WHERE A.NUM_APOL_SINISTRO = :MOVDEBCE-NUM-APOLICE
            AND C.COD_CLIENTE = A.COD_CLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT C.NOME_RAZAO
							,
											A.COD_LOT_CEF
											FROM SEGUROS.CLIENTES C
							, SEGUROS.SINI_LOTERICO01 A
											WHERE A.NUM_APOL_SINISTRO = '{this.MOVDEBCE_NUM_APOLICE}'
											AND C.COD_CLIENTE = A.COD_CLIENTE";

            return query;
        }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string SINILT01_COD_LOT_CEF { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }

        public static R340_IMPRIME_RELATORIO_DB_SELECT_1_Query1 Execute(R340_IMPRIME_RELATORIO_DB_SELECT_1_Query1 r340_IMPRIME_RELATORIO_DB_SELECT_1_Query1)
        {
            var ths = r340_IMPRIME_RELATORIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R340_IMPRIME_RELATORIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R340_IMPRIME_RELATORIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.SINILT01_COD_LOT_CEF = result[i++].Value?.ToString();
            return dta;
        }

    }
}