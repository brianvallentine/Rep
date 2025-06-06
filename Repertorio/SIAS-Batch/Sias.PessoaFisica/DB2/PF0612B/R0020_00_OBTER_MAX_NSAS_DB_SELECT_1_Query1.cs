using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0612B
{
    public class R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1 : QueryBasis<R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NSAS_SIVPF),0)
            INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF
            FROM SEGUROS.ARQUIVOS_SIVPF
            WHERE SIGLA_ARQUIVO = 'PRPSASSE'
            AND SISTEMA_ORIGEM = 4
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NSAS_SIVPF)
							,0)
											FROM SEGUROS.ARQUIVOS_SIVPF
											WHERE SIGLA_ARQUIVO = 'PRPSASSE'
											AND SISTEMA_ORIGEM = 4
											WITH UR";

            return query;
        }
        public string ARQSIVPF_NSAS_SIVPF { get; set; }

        public static R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1 Execute(R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1 r0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1)
        {
            var ths = r0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ARQSIVPF_NSAS_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}