using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0720B
{
    public class R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1 : QueryBasis<R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NSAS_SIVPF
            INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF
            FROM SEGUROS.ARQUIVOS_SIVPF
            WHERE SIGLA_ARQUIVO =
            :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO
            AND SISTEMA_ORIGEM =
            :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM
            AND DATA_PROCESSAMENTO =
            :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO
            AND DATA_GERACAO =
            :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NSAS_SIVPF
											FROM SEGUROS.ARQUIVOS_SIVPF
											WHERE SIGLA_ARQUIVO =
											'{this.ARQSIVPF_SIGLA_ARQUIVO}'
											AND SISTEMA_ORIGEM =
											'{this.ARQSIVPF_SISTEMA_ORIGEM}'
											AND DATA_PROCESSAMENTO =
											'{this.ARQSIVPF_DATA_PROCESSAMENTO}'
											AND DATA_GERACAO =
											'{this.ARQSIVPF_DATA_GERACAO}'
											WITH UR";

            return query;
        }
        public string ARQSIVPF_NSAS_SIVPF { get; set; }
        public string ARQSIVPF_DATA_PROCESSAMENTO { get; set; }
        public string ARQSIVPF_SISTEMA_ORIGEM { get; set; }
        public string ARQSIVPF_SIGLA_ARQUIVO { get; set; }
        public string ARQSIVPF_DATA_GERACAO { get; set; }

        public static R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1 Execute(R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1 r0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1)
        {
            var ths = r0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0200_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ARQSIVPF_NSAS_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}