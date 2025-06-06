using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0820B
{
    public class M_0000_00_ACESSA_NOME_ESCNEG_DB_SELECT_1_Query1 : QueryBasis<M_0000_00_ACESSA_NOME_ESCNEG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT REGIAO_ESCNEG
            INTO :V0ESCNEG-REGIAO-ESCNEG
            FROM SEGUROS.ESCRITORIO_NEGOCIO
            WHERE COD_ESCNEG = :V0AGEN-COD-ESCNEG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT REGIAO_ESCNEG
											FROM SEGUROS.ESCRITORIO_NEGOCIO
											WHERE COD_ESCNEG = '{this.V0AGEN_COD_ESCNEG}'";

            return query;
        }
        public string V0ESCNEG_REGIAO_ESCNEG { get; set; }
        public string V0AGEN_COD_ESCNEG { get; set; }

        public static M_0000_00_ACESSA_NOME_ESCNEG_DB_SELECT_1_Query1 Execute(M_0000_00_ACESSA_NOME_ESCNEG_DB_SELECT_1_Query1 m_0000_00_ACESSA_NOME_ESCNEG_DB_SELECT_1_Query1)
        {
            var ths = m_0000_00_ACESSA_NOME_ESCNEG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_00_ACESSA_NOME_ESCNEG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_00_ACESSA_NOME_ESCNEG_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ESCNEG_REGIAO_ESCNEG = result[i++].Value?.ToString();
            return dta;
        }

    }
}