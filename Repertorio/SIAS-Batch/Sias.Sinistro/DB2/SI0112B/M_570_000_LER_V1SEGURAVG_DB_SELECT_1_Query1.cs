using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0112B
{
    public class M_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1 : QueryBasis<M_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE, DATA_NASCIMENTO
            INTO :SEGVG-COD-CLIENTE, :SEGVG-DTNASCIM
            FROM SEGUROS.V1SEGURAVG
            WHERE NUM_APOLICE = :MEST-NUM-APOL
            AND COD_SUBGRUPO = :MEST-CODSUBES
            AND NUM_CERTIFICADO = :MEST-NRCERTIF
            AND TIPO_SEGURADO = :MEST-IDTPSEGU
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
							, DATA_NASCIMENTO
											FROM SEGUROS.V1SEGURAVG
											WHERE NUM_APOLICE = '{this.MEST_NUM_APOL}'
											AND COD_SUBGRUPO = '{this.MEST_CODSUBES}'
											AND NUM_CERTIFICADO = '{this.MEST_NRCERTIF}'
											AND TIPO_SEGURADO = '{this.MEST_IDTPSEGU}'";

            return query;
        }
        public string SEGVG_COD_CLIENTE { get; set; }
        public string SEGVG_DTNASCIM { get; set; }
        public string MEST_NUM_APOL { get; set; }
        public string MEST_CODSUBES { get; set; }
        public string MEST_NRCERTIF { get; set; }
        public string MEST_IDTPSEGU { get; set; }

        public static M_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1 Execute(M_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1 m_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1)
        {
            var ths = m_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGVG_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SEGVG_DTNASCIM = result[i++].Value?.ToString();
            return dta;
        }

    }
}