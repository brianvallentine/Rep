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
    public class M_0040_030_BUSCA_VIGENCIA_DB_SELECT_3_Query1 : QueryBasis<M_0040_030_BUSCA_VIGENCIA_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CERTIFICADO
            INTO :WS-NUM-CERT-PROPVA
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_APOLICE = :SEGURAVG-NUM-APOL
            AND COD_SUBGRUPO = :WS-COD-SUBG-ZERO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_CERTIFICADO
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_APOLICE = '{this.SEGURAVG_NUM_APOL}'
											AND COD_SUBGRUPO = '{this.WS_COD_SUBG_ZERO}'";

            return query;
        }
        public string WS_NUM_CERT_PROPVA { get; set; }
        public string SEGURAVG_NUM_APOL { get; set; }
        public string WS_COD_SUBG_ZERO { get; set; }

        public static M_0040_030_BUSCA_VIGENCIA_DB_SELECT_3_Query1 Execute(M_0040_030_BUSCA_VIGENCIA_DB_SELECT_3_Query1 m_0040_030_BUSCA_VIGENCIA_DB_SELECT_3_Query1)
        {
            var ths = m_0040_030_BUSCA_VIGENCIA_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0040_030_BUSCA_VIGENCIA_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0040_030_BUSCA_VIGENCIA_DB_SELECT_3_Query1();
            var i = 0;
            dta.WS_NUM_CERT_PROPVA = result[i++].Value?.ToString();
            return dta;
        }

    }
}