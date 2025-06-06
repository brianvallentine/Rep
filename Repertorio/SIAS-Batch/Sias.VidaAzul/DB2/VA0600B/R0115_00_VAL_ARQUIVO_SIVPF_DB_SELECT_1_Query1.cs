using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0600B
{
    public class R0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1 : QueryBasis<R0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_GERACAO
            INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO
            FROM SEGUROS.ARQUIVOS_SIVPF
            WHERE SIGLA_ARQUIVO =
            :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO
            AND SISTEMA_ORIGEM =
            :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM
            AND NSAS_SIVPF =
            :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_GERACAO
											FROM SEGUROS.ARQUIVOS_SIVPF
											WHERE SIGLA_ARQUIVO =
											'{this.ARQSIVPF_SIGLA_ARQUIVO}'
											AND SISTEMA_ORIGEM =
											'{this.ARQSIVPF_SISTEMA_ORIGEM}'
											AND NSAS_SIVPF =
											'{this.ARQSIVPF_NSAS_SIVPF}'";

            return query;
        }
        public string ARQSIVPF_DATA_GERACAO { get; set; }
        public string ARQSIVPF_SISTEMA_ORIGEM { get; set; }
        public string ARQSIVPF_SIGLA_ARQUIVO { get; set; }
        public string ARQSIVPF_NSAS_SIVPF { get; set; }

        public static R0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1 Execute(R0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1 r0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1)
        {
            var ths = r0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1();
            var i = 0;
            dta.ARQSIVPF_DATA_GERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}