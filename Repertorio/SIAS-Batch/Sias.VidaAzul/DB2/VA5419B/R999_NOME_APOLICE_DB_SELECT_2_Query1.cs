using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5419B
{
    public class R999_NOME_APOLICE_DB_SELECT_2_Query1 : QueryBasis<R999_NOME_APOLICE_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.NOME_RAZAO
            INTO :V0CLIE-NOME
            FROM SEGUROS.V0SUBGRUPO A,
            SEGUROS.V0CLIENTE B
            WHERE A.NUM_APOLICE = :V0RSAF-NUM-APOLANT
            AND A.COD_SUBGRUPO = :V0RSAF-CODSUBESANT
            AND A.COD_CLIENTE = B.COD_CLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.NOME_RAZAO
											FROM SEGUROS.V0SUBGRUPO A
							,
											SEGUROS.V0CLIENTE B
											WHERE A.NUM_APOLICE = '{this.V0RSAF_NUM_APOLANT}'
											AND A.COD_SUBGRUPO = '{this.V0RSAF_CODSUBESANT}'
											AND A.COD_CLIENTE = B.COD_CLIENTE";

            return query;
        }
        public string V0CLIE_NOME { get; set; }
        public string V0RSAF_NUM_APOLANT { get; set; }
        public string V0RSAF_CODSUBESANT { get; set; }

        public static R999_NOME_APOLICE_DB_SELECT_2_Query1 Execute(R999_NOME_APOLICE_DB_SELECT_2_Query1 r999_NOME_APOLICE_DB_SELECT_2_Query1)
        {
            var ths = r999_NOME_APOLICE_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R999_NOME_APOLICE_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R999_NOME_APOLICE_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0CLIE_NOME = result[i++].Value?.ToString();
            return dta;
        }

    }
}