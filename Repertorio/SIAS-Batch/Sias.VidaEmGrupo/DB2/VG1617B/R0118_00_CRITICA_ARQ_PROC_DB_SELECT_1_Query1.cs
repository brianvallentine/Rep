using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1617B
{
    public class R0118_00_CRITICA_ARQ_PROC_DB_SELECT_1_Query1 : QueryBasis<R0118_00_CRITICA_ARQ_PROC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(DATA_PROCESSAMENTO), '0001-01-01' )
            INTO :ARQSIVPF-DATA-PROCESSAMENTO
            FROM SEGUROS.ARQUIVOS_SIVPF
            WHERE SIGLA_ARQUIVO = :ARQSIVPF-SIGLA-ARQUIVO
            AND SISTEMA_ORIGEM = :ARQSIVPF-SISTEMA-ORIGEM
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(DATA_PROCESSAMENTO)
							, '0001-01-01' )
											FROM SEGUROS.ARQUIVOS_SIVPF
											WHERE SIGLA_ARQUIVO = '{this.ARQSIVPF_SIGLA_ARQUIVO}'
											AND SISTEMA_ORIGEM = '{this.ARQSIVPF_SISTEMA_ORIGEM}'
											WITH UR";

            return query;
        }
        public string ARQSIVPF_DATA_PROCESSAMENTO { get; set; }
        public string ARQSIVPF_SISTEMA_ORIGEM { get; set; }
        public string ARQSIVPF_SIGLA_ARQUIVO { get; set; }

        public static R0118_00_CRITICA_ARQ_PROC_DB_SELECT_1_Query1 Execute(R0118_00_CRITICA_ARQ_PROC_DB_SELECT_1_Query1 r0118_00_CRITICA_ARQ_PROC_DB_SELECT_1_Query1)
        {
            var ths = r0118_00_CRITICA_ARQ_PROC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0118_00_CRITICA_ARQ_PROC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0118_00_CRITICA_ARQ_PROC_DB_SELECT_1_Query1();
            var i = 0;
            dta.ARQSIVPF_DATA_PROCESSAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}