using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0010B
{
    public class M_1000_IDADE_DB_SELECT_1_Query1 : QueryBasis<M_1000_IDADE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODPRODU,
            PERIPGTO,
            TEM_CDG
            INTO :V0PROD-CODPRODU,
            :HOST-PERIPGTO,
            :V0PROD-TEM-CDG:V0PROD-TEM-CDG-I
            FROM SEGUROS.V0PRODUTOSVG
            WHERE NUM_APOLICE = :V1SEGV-NUM-APOLICE
            AND CODSUBES = :V1SEGV-COD-SUBGRUPO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODPRODU
							,
											PERIPGTO
							,
											TEM_CDG
											FROM SEGUROS.V0PRODUTOSVG
											WHERE NUM_APOLICE = '{this.V1SEGV_NUM_APOLICE}'
											AND CODSUBES = '{this.V1SEGV_COD_SUBGRUPO}'";

            return query;
        }
        public string V0PROD_CODPRODU { get; set; }
        public string HOST_PERIPGTO { get; set; }
        public string V0PROD_TEM_CDG { get; set; }
        public string V0PROD_TEM_CDG_I { get; set; }
        public string V1SEGV_COD_SUBGRUPO { get; set; }
        public string V1SEGV_NUM_APOLICE { get; set; }

        public static M_1000_IDADE_DB_SELECT_1_Query1 Execute(M_1000_IDADE_DB_SELECT_1_Query1 m_1000_IDADE_DB_SELECT_1_Query1)
        {
            var ths = m_1000_IDADE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_IDADE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_IDADE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PROD_CODPRODU = result[i++].Value?.ToString();
            dta.HOST_PERIPGTO = result[i++].Value?.ToString();
            dta.V0PROD_TEM_CDG = result[i++].Value?.ToString();
            dta.V0PROD_TEM_CDG_I = string.IsNullOrWhiteSpace(dta.V0PROD_TEM_CDG) ? "-1" : "0";
            return dta;
        }

    }
}