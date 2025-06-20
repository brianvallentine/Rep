using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class R8000_00_OBTER_NSAS_MOVTO_Query1 : QueryBasis<R8000_00_OBTER_NSAS_MOVTO_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NSAS_SIVPF),0) + 1
            INTO :ARQSIVPF-NSAS-SIVPF
            FROM SEGUROS.ARQUIVOS_SIVPF
            WHERE SIGLA_ARQUIVO = :ARQSIVPF-SIGLA-ARQUIVO
            AND SISTEMA_ORIGEM = :ARQSIVPF-SISTEMA-ORIGEM
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NSAS_SIVPF)
							,0) + 1
											FROM SEGUROS.ARQUIVOS_SIVPF
											WHERE SIGLA_ARQUIVO = '{this.ARQSIVPF_SIGLA_ARQUIVO}'
											AND SISTEMA_ORIGEM = '{this.ARQSIVPF_SISTEMA_ORIGEM}'
											WITH UR";

            return query;
        }
        public string ARQSIVPF_NSAS_SIVPF { get; set; }
        public string ARQSIVPF_SISTEMA_ORIGEM { get; set; }
        public string ARQSIVPF_SIGLA_ARQUIVO { get; set; }

        public static R8000_00_OBTER_NSAS_MOVTO_Query1 Execute(R8000_00_OBTER_NSAS_MOVTO_Query1 r8000_00_OBTER_NSAS_MOVTO_Query1)
        {
            var ths = r8000_00_OBTER_NSAS_MOVTO_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8000_00_OBTER_NSAS_MOVTO_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8000_00_OBTER_NSAS_MOVTO_Query1();
            var i = 0;
            dta.ARQSIVPF_NSAS_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}