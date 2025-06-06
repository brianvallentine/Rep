using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0806B
{
    public class M_332_000_LER_SEGURAVG_DB_SELECT_1_Query1 : QueryBasis<M_332_000_LER_SEGURAVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE
            INTO
            :V1SEGVG-CLIENTE
            FROM
            SEGUROS.V1SEGURAVG
            WHERE
            NUM_APOLICE = :MEST-NUM-APOL
            AND TIPO_SEGURADO = :MEST-IDTPSEGU
            AND NUM_CERTIFICADO = :MEST-NRCERTIF
            AND COD_SUBGRUPO = :MEST-CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
											FROM
											SEGUROS.V1SEGURAVG
											WHERE
											NUM_APOLICE = '{this.MEST_NUM_APOL}'
											AND TIPO_SEGURADO = '{this.MEST_IDTPSEGU}'
											AND NUM_CERTIFICADO = '{this.MEST_NRCERTIF}'
											AND COD_SUBGRUPO = '{this.MEST_CODSUBES}'";

            return query;
        }
        public string V1SEGVG_CLIENTE { get; set; }
        public string MEST_NUM_APOL { get; set; }
        public string MEST_IDTPSEGU { get; set; }
        public string MEST_NRCERTIF { get; set; }
        public string MEST_CODSUBES { get; set; }

        public static M_332_000_LER_SEGURAVG_DB_SELECT_1_Query1 Execute(M_332_000_LER_SEGURAVG_DB_SELECT_1_Query1 m_332_000_LER_SEGURAVG_DB_SELECT_1_Query1)
        {
            var ths = m_332_000_LER_SEGURAVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_332_000_LER_SEGURAVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_332_000_LER_SEGURAVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1SEGVG_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}