using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R8036_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<R8036_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA
            INTO :PF087-NUM-PROPOSTA
            FROM SEGUROS.PF_PROC_PROPOSTA
            WHERE NUM_PROPOSTA = :PF087-NUM-PROPOSTA
            AND SIGLA_ARQUIVO = 'PORTALPJ'
            AND STA_PROCESSAMENTO = 'P'
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA
											FROM SEGUROS.PF_PROC_PROPOSTA
											WHERE NUM_PROPOSTA = '{this.PF087_NUM_PROPOSTA}'
											AND SIGLA_ARQUIVO = 'PORTALPJ'
											AND STA_PROCESSAMENTO = 'P'
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string PF087_NUM_PROPOSTA { get; set; }

        public static R8036_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1 Execute(R8036_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1 r8036_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1)
        {
            var ths = r8036_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8036_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8036_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PF087_NUM_PROPOSTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}