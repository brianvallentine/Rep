using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0852B
{
    public class R310_00_INSE_ARG_SIVPF_DB_SELECT_1_Query1 : QueryBasis<R310_00_INSE_ARG_SIVPF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NSAS_SIVPF),0)
            INTO :ARQSIVPF-NSAS-SIVPF
            FROM SEGUROS.ARQUIVOS_SIVPF
            WHERE SIGLA_ARQUIVO = 'STASASSE'
            AND SISTEMA_ORIGEM = 4
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NSAS_SIVPF)
							,0)
											FROM SEGUROS.ARQUIVOS_SIVPF
											WHERE SIGLA_ARQUIVO = 'STASASSE'
											AND SISTEMA_ORIGEM = 4
											WITH UR";

            return query;
        }
        public string ARQSIVPF_NSAS_SIVPF { get; set; }

        public static R310_00_INSE_ARG_SIVPF_DB_SELECT_1_Query1 Execute(R310_00_INSE_ARG_SIVPF_DB_SELECT_1_Query1 r310_00_INSE_ARG_SIVPF_DB_SELECT_1_Query1)
        {
            var ths = r310_00_INSE_ARG_SIVPF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R310_00_INSE_ARG_SIVPF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R310_00_INSE_ARG_SIVPF_DB_SELECT_1_Query1();
            var i = 0;
            dta.ARQSIVPF_NSAS_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}