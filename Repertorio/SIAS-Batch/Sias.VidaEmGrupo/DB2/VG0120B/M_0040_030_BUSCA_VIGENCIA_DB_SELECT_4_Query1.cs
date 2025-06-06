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
    public class M_0040_030_BUSCA_VIGENCIA_DB_SELECT_4_Query1 : QueryBasis<M_0040_030_BUSCA_VIGENCIA_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(DATA_VENCIMENTO), '9999-12-31' )
            INTO :WS-DTINIVIG-PARC
            FROM SEGUROS.PARCELAS_VIDAZUL
            WHERE NUM_CERTIFICADO = :WS-NUM-CERT-PROPVA
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(DATA_VENCIMENTO)
							, '9999-12-31' )
											FROM SEGUROS.PARCELAS_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.WS_NUM_CERT_PROPVA}'";

            return query;
        }
        public string WS_DTINIVIG_PARC { get; set; }
        public string WS_NUM_CERT_PROPVA { get; set; }

        public static M_0040_030_BUSCA_VIGENCIA_DB_SELECT_4_Query1 Execute(M_0040_030_BUSCA_VIGENCIA_DB_SELECT_4_Query1 m_0040_030_BUSCA_VIGENCIA_DB_SELECT_4_Query1)
        {
            var ths = m_0040_030_BUSCA_VIGENCIA_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0040_030_BUSCA_VIGENCIA_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0040_030_BUSCA_VIGENCIA_DB_SELECT_4_Query1();
            var i = 0;
            dta.WS_DTINIVIG_PARC = result[i++].Value?.ToString();
            return dta;
        }

    }
}