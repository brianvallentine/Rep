using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1471B
{
    public class M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_3_Query1 : QueryBasis<M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_FUNCIONARIO
            INTO :FUNCIONA-NOME-FUNCIONARIO
            FROM SEGUROS.FUNCIONARIOS
            WHERE NUM_CPF = :FUNCIONA-NUM-CPF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_FUNCIONARIO
											FROM SEGUROS.FUNCIONARIOS
											WHERE NUM_CPF = '{this.FUNCIONA_NUM_CPF}'";

            return query;
        }
        public string FUNCIONA_NOME_FUNCIONARIO { get; set; }
        public string FUNCIONA_NUM_CPF { get; set; }

        public static M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_3_Query1 Execute(M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_3_Query1 m_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_3_Query1)
        {
            var ths = m_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0101_VERIFICA_SAF_LOTERICO_DB_SELECT_3_Query1();
            var i = 0;
            dta.FUNCIONA_NOME_FUNCIONARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}