using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0656B
{
    public class R2600_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 : QueryBasis<R2600_00_SELECT_HISCOBPR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLPREMIO,
            IMP_MORNATU
            INTO :HISCOBPR-VLPREMIO,
            :HISCOBPR-IMP-MORNATU
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :SVA-NUM-CERTIFICADO
            AND OCORR_HISTORICO = 1
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLPREMIO
							,
											IMP_MORNATU
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.SVA_NUM_CERTIFICADO}'
											AND OCORR_HISTORICO = 1";

            return query;
        }
        public string HISCOBPR_VLPREMIO { get; set; }
        public string HISCOBPR_IMP_MORNATU { get; set; }
        public string SVA_NUM_CERTIFICADO { get; set; }

        public static R2600_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 Execute(R2600_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 r2600_00_SELECT_HISCOBPR_DB_SELECT_1_Query1)
        {
            var ths = r2600_00_SELECT_HISCOBPR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2600_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2600_00_SELECT_HISCOBPR_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCOBPR_VLPREMIO = result[i++].Value?.ToString();
            dta.HISCOBPR_IMP_MORNATU = result[i++].Value?.ToString();
            return dta;
        }

    }
}