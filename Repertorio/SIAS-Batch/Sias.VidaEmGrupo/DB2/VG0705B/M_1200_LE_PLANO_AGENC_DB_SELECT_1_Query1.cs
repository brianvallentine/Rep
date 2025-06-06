using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0705B
{
    public class M_1200_LE_PLANO_AGENC_DB_SELECT_1_Query1 : QueryBasis<M_1200_LE_PLANO_AGENC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PCT_PAGA_PARCELA
            INTO :SQL-PCT-AGENC
            FROM SEGUROS.V1PLANOAGEN
            WHERE NUM_APOLICE = :SQL-NUM-APOL
            AND COD_SUBGRUPO = :SQL-COD-SUB
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCT_PAGA_PARCELA
											FROM SEGUROS.V1PLANOAGEN
											WHERE NUM_APOLICE = '{this.SQL_NUM_APOL}'
											AND COD_SUBGRUPO = '{this.SQL_COD_SUB}'";

            return query;
        }
        public string SQL_PCT_AGENC { get; set; }
        public string SQL_NUM_APOL { get; set; }
        public string SQL_COD_SUB { get; set; }

        public static M_1200_LE_PLANO_AGENC_DB_SELECT_1_Query1 Execute(M_1200_LE_PLANO_AGENC_DB_SELECT_1_Query1 m_1200_LE_PLANO_AGENC_DB_SELECT_1_Query1)
        {
            var ths = m_1200_LE_PLANO_AGENC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1200_LE_PLANO_AGENC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1200_LE_PLANO_AGENC_DB_SELECT_1_Query1();
            var i = 0;
            dta.SQL_PCT_AGENC = result[i++].Value?.ToString();
            return dta;
        }

    }
}