using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF2002B
{
    public class R3500_TRATA_ADESAO_DB_SELECT_1_Query1 : QueryBasis<R3500_TRATA_ADESAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIGLA_ARQUIVO ,
            NUM_PROPOSTA
            INTO :PF087-SIGLA-ARQUIVO ,
            :PF087-NUM-PROPOSTA
            FROM SEGUROS.PF_PROC_PROPOSTA
            WHERE SIGLA_ARQUIVO = 'PORTALPJ'
            AND NUM_PROPOSTA = :PF087-NUM-PROPOSTA
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIGLA_ARQUIVO 
							,
											NUM_PROPOSTA
											FROM SEGUROS.PF_PROC_PROPOSTA
											WHERE SIGLA_ARQUIVO = 'PORTALPJ'
											AND NUM_PROPOSTA = '{this.PF087_NUM_PROPOSTA}'
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string PF087_SIGLA_ARQUIVO { get; set; }
        public string PF087_NUM_PROPOSTA { get; set; }

        public static R3500_TRATA_ADESAO_DB_SELECT_1_Query1 Execute(R3500_TRATA_ADESAO_DB_SELECT_1_Query1 r3500_TRATA_ADESAO_DB_SELECT_1_Query1)
        {
            var ths = r3500_TRATA_ADESAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3500_TRATA_ADESAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3500_TRATA_ADESAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PF087_SIGLA_ARQUIVO = result[i++].Value?.ToString();
            dta.PF087_NUM_PROPOSTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}