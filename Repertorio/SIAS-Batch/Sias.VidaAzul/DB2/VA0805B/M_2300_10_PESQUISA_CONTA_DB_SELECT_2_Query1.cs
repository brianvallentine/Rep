using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0805B
{
    public class M_2300_10_PESQUISA_CONTA_DB_SELECT_2_Query1 : QueryBasis<M_2300_10_PESQUISA_CONTA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_FUNCIONARIO
            INTO :WHOST-NOME
            FROM SEGUROS.V0FUNCIOCEF
            WHERE COD_AGENCIA = :WHOST-AGENCIA
            AND OPERACAO_CONTA = :WHOST-OPERACAO
            AND NUM_CONTA = :WHOST-NRCONTA-P
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_FUNCIONARIO
											FROM SEGUROS.V0FUNCIOCEF
											WHERE COD_AGENCIA = '{this.WHOST_AGENCIA}'
											AND OPERACAO_CONTA = '{this.WHOST_OPERACAO}'
											AND NUM_CONTA = '{this.WHOST_NRCONTA_P}'
											WITH UR";

            return query;
        }
        public string WHOST_NOME { get; set; }
        public string WHOST_NRCONTA_P { get; set; }
        public string WHOST_OPERACAO { get; set; }
        public string WHOST_AGENCIA { get; set; }

        public static M_2300_10_PESQUISA_CONTA_DB_SELECT_2_Query1 Execute(M_2300_10_PESQUISA_CONTA_DB_SELECT_2_Query1 m_2300_10_PESQUISA_CONTA_DB_SELECT_2_Query1)
        {
            var ths = m_2300_10_PESQUISA_CONTA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_2300_10_PESQUISA_CONTA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_2300_10_PESQUISA_CONTA_DB_SELECT_2_Query1();
            var i = 0;
            dta.WHOST_NOME = result[i++].Value?.ToString();
            return dta;
        }

    }
}