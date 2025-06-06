using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0102B
{
    public class M_071_000_LER_SEGURAVG_DB_SELECT_1_Query1 : QueryBasis<M_071_000_LER_SEGURAVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE
            INTO :SEGV-CLIENTE
            FROM SEGUROS.V1SEGURAVG
            WHERE NUM_APOLICE = :TAPDCORR-NUM-APOL
            AND COD_SUBGRUPO = :TMESTSIN-CODSUBES
            AND NUM_CERTIFICADO = :TMESTSIN-NRCERTIF
            AND TIPO_SEGURADO = :TMESTSIN-IDTPSEGU
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
											FROM SEGUROS.V1SEGURAVG
											WHERE NUM_APOLICE = '{this.TAPDCORR_NUM_APOL}'
											AND COD_SUBGRUPO = '{this.TMESTSIN_CODSUBES}'
											AND NUM_CERTIFICADO = '{this.TMESTSIN_NRCERTIF}'
											AND TIPO_SEGURADO = '{this.TMESTSIN_IDTPSEGU}'";

            return query;
        }
        public string SEGV_CLIENTE { get; set; }
        public string TAPDCORR_NUM_APOL { get; set; }
        public string TMESTSIN_CODSUBES { get; set; }
        public string TMESTSIN_NRCERTIF { get; set; }
        public string TMESTSIN_IDTPSEGU { get; set; }

        public static M_071_000_LER_SEGURAVG_DB_SELECT_1_Query1 Execute(M_071_000_LER_SEGURAVG_DB_SELECT_1_Query1 m_071_000_LER_SEGURAVG_DB_SELECT_1_Query1)
        {
            var ths = m_071_000_LER_SEGURAVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_071_000_LER_SEGURAVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_071_000_LER_SEGURAVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGV_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}