using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0078B
{
    public class M_510_IMPRIME_OPERACOES_DB_SELECT_1_Query1 : QueryBasis<M_510_IMPRIME_OPERACOES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DES_OPERACAO
            INTO :GEOPERAC-DES-OPERACAO
            FROM SEGUROS.GE_OPERACAO
            WHERE COD_OPERACAO = :SINI-OPERACAO
            AND IDE_SISTEMA = 'SI'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DES_OPERACAO
											FROM SEGUROS.GE_OPERACAO
											WHERE COD_OPERACAO = '{this.SINI_OPERACAO}'
											AND IDE_SISTEMA = 'SI'";

            return query;
        }
        public string GEOPERAC_DES_OPERACAO { get; set; }
        public string SINI_OPERACAO { get; set; }

        public static M_510_IMPRIME_OPERACOES_DB_SELECT_1_Query1 Execute(M_510_IMPRIME_OPERACOES_DB_SELECT_1_Query1 m_510_IMPRIME_OPERACOES_DB_SELECT_1_Query1)
        {
            var ths = m_510_IMPRIME_OPERACOES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_510_IMPRIME_OPERACOES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_510_IMPRIME_OPERACOES_DB_SELECT_1_Query1();
            var i = 0;
            dta.GEOPERAC_DES_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}