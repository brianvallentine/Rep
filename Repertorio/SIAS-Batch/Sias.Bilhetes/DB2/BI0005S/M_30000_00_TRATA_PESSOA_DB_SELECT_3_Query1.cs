using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0005S
{
    public class M_30000_00_TRATA_PESSOA_DB_SELECT_3_Query1 : QueryBasis<M_30000_00_TRATA_PESSOA_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CGC ,
            NOME_FANTASIA
            INTO :BI0005L-S-CGC ,
            :BI0005L-S-NOME-FANTASIA
            FROM SEGUROS.PESSOA_JURIDICA
            WHERE COD_PESSOA = :BI0005L-E-COD-PESSOA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT CGC 
							,
											NOME_FANTASIA
											FROM SEGUROS.PESSOA_JURIDICA
											WHERE COD_PESSOA = '{this.BI0005L_E_COD_PESSOA}'
											WITH UR";

            return query;
        }
        public string BI0005L_S_CGC { get; set; }
        public string BI0005L_S_NOME_FANTASIA { get; set; }
        public string BI0005L_E_COD_PESSOA { get; set; }

        public static M_30000_00_TRATA_PESSOA_DB_SELECT_3_Query1 Execute(M_30000_00_TRATA_PESSOA_DB_SELECT_3_Query1 m_30000_00_TRATA_PESSOA_DB_SELECT_3_Query1)
        {
            var ths = m_30000_00_TRATA_PESSOA_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_30000_00_TRATA_PESSOA_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_30000_00_TRATA_PESSOA_DB_SELECT_3_Query1();
            var i = 0;
            dta.BI0005L_S_CGC = result[i++].Value?.ToString();
            dta.BI0005L_S_NOME_FANTASIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}