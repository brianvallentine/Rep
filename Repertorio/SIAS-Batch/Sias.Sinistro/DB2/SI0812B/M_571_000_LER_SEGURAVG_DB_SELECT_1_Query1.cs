using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0812B
{
    public class M_571_000_LER_SEGURAVG_DB_SELECT_1_Query1 : QueryBasis<M_571_000_LER_SEGURAVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE,
            COD_AGENCIADOR
            INTO :SEGU-COD-CLIENTE,
            :SEGU-COD-AGENCIADOR
            FROM SEGUROS.V0SEGURAVG
            WHERE NUM_APOLICE = :RELSIN-APOLICE
            AND COD_SUBGRUPO = :MEST-CODSUBES
            AND NUM_CERTIFICADO = :MEST-NRCERTIF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
							,
											COD_AGENCIADOR
											FROM SEGUROS.V0SEGURAVG
											WHERE NUM_APOLICE = '{this.RELSIN_APOLICE}'
											AND COD_SUBGRUPO = '{this.MEST_CODSUBES}'
											AND NUM_CERTIFICADO = '{this.MEST_NRCERTIF}'";

            return query;
        }
        public string SEGU_COD_CLIENTE { get; set; }
        public string SEGU_COD_AGENCIADOR { get; set; }
        public string RELSIN_APOLICE { get; set; }
        public string MEST_CODSUBES { get; set; }
        public string MEST_NRCERTIF { get; set; }

        public static M_571_000_LER_SEGURAVG_DB_SELECT_1_Query1 Execute(M_571_000_LER_SEGURAVG_DB_SELECT_1_Query1 m_571_000_LER_SEGURAVG_DB_SELECT_1_Query1)
        {
            var ths = m_571_000_LER_SEGURAVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_571_000_LER_SEGURAVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_571_000_LER_SEGURAVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGU_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SEGU_COD_AGENCIADOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}