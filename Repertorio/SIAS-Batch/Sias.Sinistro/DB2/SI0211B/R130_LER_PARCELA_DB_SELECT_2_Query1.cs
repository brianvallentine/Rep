using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0211B
{
    public class R130_LER_PARCELA_DB_SELECT_2_Query1 : QueryBasis<R130_LER_PARCELA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VALUE(MAX(P.NUM_RESSARC),0)
            INTO
            :W-NU-RESSARC-MAX
            FROM
            SEGUROS.SI_RESSARC_PARCELA P,
            SEGUROS.SI_RESSARC_ACORDO A
            WHERE
            A.NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO
            AND A.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO
            AND A.NUM_RESSARC = P.NUM_RESSARC
            AND A.SEQ_RESSARC = P.SEQ_RESSARC
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(MAX(P.NUM_RESSARC)
							,0)
											FROM
											SEGUROS.SI_RESSARC_PARCELA P
							,
											SEGUROS.SI_RESSARC_ACORDO A
											WHERE
											A.NUM_APOL_SINISTRO = '{this.SI111_NUM_APOL_SINISTRO}'
											AND A.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO
											AND A.NUM_RESSARC = P.NUM_RESSARC
											AND A.SEQ_RESSARC = P.SEQ_RESSARC";

            return query;
        }
        public string W_NU_RESSARC_MAX { get; set; }
        public string SI111_NUM_APOL_SINISTRO { get; set; }

        public static R130_LER_PARCELA_DB_SELECT_2_Query1 Execute(R130_LER_PARCELA_DB_SELECT_2_Query1 r130_LER_PARCELA_DB_SELECT_2_Query1)
        {
            var ths = r130_LER_PARCELA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R130_LER_PARCELA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R130_LER_PARCELA_DB_SELECT_2_Query1();
            var i = 0;
            dta.W_NU_RESSARC_MAX = result[i++].Value?.ToString();
            return dta;
        }

    }
}