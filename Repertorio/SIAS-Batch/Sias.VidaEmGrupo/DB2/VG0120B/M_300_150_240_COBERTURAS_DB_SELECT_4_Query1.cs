using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0120B
{
    public class M_300_150_240_COBERTURAS_DB_SELECT_4_Query1 : QueryBasis<M_300_150_240_COBERTURAS_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(CUSTOCAP_TOTAL, ' ' )
            INTO :PRODUVG-CUSTOCAP-TOTAL
            FROM SEGUROS.V0PRODUTOSVG
            WHERE NUM_APOLICE = :SEGURAVG-NUM-APOL
            AND CODSUBES = :SEGURAVG-COD-SUBG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(CUSTOCAP_TOTAL
							, ' ' )
											FROM SEGUROS.V0PRODUTOSVG
											WHERE NUM_APOLICE = '{this.SEGURAVG_NUM_APOL}'
											AND CODSUBES = '{this.SEGURAVG_COD_SUBG}'";

            return query;
        }
        public string PRODUVG_CUSTOCAP_TOTAL { get; set; }
        public string SEGURAVG_NUM_APOL { get; set; }
        public string SEGURAVG_COD_SUBG { get; set; }

        public static M_300_150_240_COBERTURAS_DB_SELECT_4_Query1 Execute(M_300_150_240_COBERTURAS_DB_SELECT_4_Query1 m_300_150_240_COBERTURAS_DB_SELECT_4_Query1)
        {
            var ths = m_300_150_240_COBERTURAS_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_300_150_240_COBERTURAS_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_300_150_240_COBERTURAS_DB_SELECT_4_Query1();
            var i = 0;
            dta.PRODUVG_CUSTOCAP_TOTAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}