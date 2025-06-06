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
    public class M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1 : QueryBasis<M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1>
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
            FROM SEGUROS.V1SEGURAVG
            WHERE NUM_APOLICE = :V1HISTMEST-NUM-APOLICE AND
            COD_SUBGRUPO = :V1HISTMEST-CODSUBES AND
            NUM_CERTIFICADO = :V1HISTMEST-NRCERTIF AND
            TIPO_SEGURADO = :V1HISTMEST-IDTPSEGU )
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
											FROM SEGUROS.V1CLIENTE
											WHERE COD_CLIENTE = (
											SELECT COD_CLIENTE
											FROM SEGUROS.V1SEGURAVG
											WHERE NUM_APOLICE = '{this.V1HISTMEST_NUM_APOLICE}' AND
											COD_SUBGRUPO = '{this.V1HISTMEST_CODSUBES}' AND
											NUM_CERTIFICADO = '{this.V1HISTMEST_NRCERTIF}' AND
											TIPO_SEGURADO = '{this.V1HISTMEST_IDTPSEGU}' )";

            return query;
        }
        public string V1CLIENTE_NOME_RAZAO { get; set; }
        public string V1HISTMEST_NUM_APOLICE { get; set; }
        public string V1HISTMEST_CODSUBES { get; set; }
        public string V1HISTMEST_NRCERTIF { get; set; }
        public string V1HISTMEST_IDTPSEGU { get; set; }

        public static M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1 Execute(M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1 m_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1)
        {
            var ths = m_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1CLIENTE_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}