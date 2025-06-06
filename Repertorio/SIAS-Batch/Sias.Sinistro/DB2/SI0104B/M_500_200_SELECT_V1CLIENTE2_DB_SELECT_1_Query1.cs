using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0104B
{
    public class M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1 : QueryBasis<M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO
            INTO :V1CLIENTE-NOME-RAZAO
            FROM SEGUROS.V1CLIENTE
            WHERE COD_CLIENTE = (
            SELECT COD_CLIENTE
            FROM SEGUROS.V1SINI_ITEM
            WHERE NUM_APOL_SINISTRO = :V1HISTMEST-NUM-SINISTRO)
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
											FROM SEGUROS.V1CLIENTE
											WHERE COD_CLIENTE = (
											SELECT COD_CLIENTE
											FROM SEGUROS.V1SINI_ITEM
											WHERE NUM_APOL_SINISTRO = '{this.V1HISTMEST_NUM_SINISTRO}')";

            return query;
        }
        public string V1CLIENTE_NOME_RAZAO { get; set; }
        public string V1HISTMEST_NUM_SINISTRO { get; set; }

        public static M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1 Execute(M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1 m_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1)
        {
            var ths = m_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1CLIENTE_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}