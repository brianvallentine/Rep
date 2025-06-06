using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0107B
{
    public class M_230_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1 : QueryBasis<M_230_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            IMP_SEGURADA_IX,
            PRM_TARIFARIO_IX
            INTO
            :CIMP-SEGURADA-IX,
            :CPRM-TARIFARIO-IX
            FROM
            SEGUROS.V0COBERAPOL
            WHERE
            NUM_APOLICE = 93010000890 AND
            NRENDOS = 0 AND
            NUM_ITEM = :SNUM-ITEM AND
            OCORHIST = :SOCORR-HISTORICO AND
            MODALIFR = 0 AND
            RAMOFR = 93
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											IMP_SEGURADA_IX
							,
											PRM_TARIFARIO_IX
											FROM
											SEGUROS.V0COBERAPOL
											WHERE
											NUM_APOLICE = 93010000890 AND
											NRENDOS = 0 AND
											NUM_ITEM = '{this.SNUM_ITEM}' AND
											OCORHIST = '{this.SOCORR_HISTORICO}' AND
											MODALIFR = 0 AND
											RAMOFR = 93";

            return query;
        }
        public string CIMP_SEGURADA_IX { get; set; }
        public string CPRM_TARIFARIO_IX { get; set; }
        public string SOCORR_HISTORICO { get; set; }
        public string SNUM_ITEM { get; set; }

        public static M_230_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1 Execute(M_230_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1 m_230_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1)
        {
            var ths = m_230_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_230_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_230_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1();
            var i = 0;
            dta.CIMP_SEGURADA_IX = result[i++].Value?.ToString();
            dta.CPRM_TARIFARIO_IX = result[i++].Value?.ToString();
            return dta;
        }

    }
}