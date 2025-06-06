using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0110B
{
    public class M_000_00_ACESSA_NOME_SEGURADO_DB_SELECT_1_Query1 : QueryBasis<M_000_00_ACESSA_NOME_SEGURADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT C.NOME_RAZAO
            INTO :V1HISTMEST-NOME
            FROM SEGUROS.V0APOLICE A,
            SEGUROS.V0CLIENTE C
            WHERE A.NUM_APOLICE = :V1HISTMEST-NUM-APOLICE
            AND A.CODCLIEN = C.COD_CLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT C.NOME_RAZAO
											FROM SEGUROS.V0APOLICE A
							,
											SEGUROS.V0CLIENTE C
											WHERE A.NUM_APOLICE = '{this.V1HISTMEST_NUM_APOLICE}'
											AND A.CODCLIEN = C.COD_CLIENTE";

            return query;
        }
        public string V1HISTMEST_NOME { get; set; }
        public string V1HISTMEST_NUM_APOLICE { get; set; }

        public static M_000_00_ACESSA_NOME_SEGURADO_DB_SELECT_1_Query1 Execute(M_000_00_ACESSA_NOME_SEGURADO_DB_SELECT_1_Query1 m_000_00_ACESSA_NOME_SEGURADO_DB_SELECT_1_Query1)
        {
            var ths = m_000_00_ACESSA_NOME_SEGURADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_000_00_ACESSA_NOME_SEGURADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_000_00_ACESSA_NOME_SEGURADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1HISTMEST_NOME = result[i++].Value?.ToString();
            return dta;
        }

    }
}