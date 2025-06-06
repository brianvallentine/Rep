using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0021B
{
    public class M_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1 : QueryBasis<M_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE, DATA_NASCIMENTO
            INTO :V1SEGVG-COD-CLI, :V1SEGVG-DTNASCIM
            FROM SEGUROS.V1SEGURAVG
            WHERE NUM_APOLICE = :V1MEST-NUM-APOL
            AND COD_SUBGRUPO = :V1MEST-CODSUBES
            AND NUM_CERTIFICADO = :V1MEST-NRCERTIF
            AND TIPO_SEGURADO = :V1MEST-IDTPSEGU
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
							, DATA_NASCIMENTO
											FROM SEGUROS.V1SEGURAVG
											WHERE NUM_APOLICE = '{this.V1MEST_NUM_APOL}'
											AND COD_SUBGRUPO = '{this.V1MEST_CODSUBES}'
											AND NUM_CERTIFICADO = '{this.V1MEST_NRCERTIF}'
											AND TIPO_SEGURADO = '{this.V1MEST_IDTPSEGU}'";

            return query;
        }
        public string V1SEGVG_COD_CLI { get; set; }
        public string V1SEGVG_DTNASCIM { get; set; }
        public string V1MEST_NUM_APOL { get; set; }
        public string V1MEST_CODSUBES { get; set; }
        public string V1MEST_NRCERTIF { get; set; }
        public string V1MEST_IDTPSEGU { get; set; }

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
            dta.V1SEGVG_COD_CLI = result[i++].Value?.ToString();
            dta.V1SEGVG_DTNASCIM = result[i++].Value?.ToString();
            return dta;
        }

    }
}