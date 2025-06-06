using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0964B
{
    public class R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CERTIFICADO,
            IMP_SEGURADA_IX,
            COD_FONTE
            INTO :SINISMES-NUM-CERTIFICADO,
            :SINISMES-IMP-SEGURADA-IX,
            :SINISMES-COD-FONTE
            FROM SEGUROS.SINISTRO_MESTRE
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND NUM_CERTIFICADO <> 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CERTIFICADO
							,
											IMP_SEGURADA_IX
							,
											COD_FONTE
											FROM SEGUROS.SINISTRO_MESTRE
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND NUM_CERTIFICADO <> 0";

            return query;
        }
        public string SINISMES_NUM_CERTIFICADO { get; set; }
        public string SINISMES_IMP_SEGURADA_IX { get; set; }
        public string SINISMES_COD_FONTE { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1 r1100_00_SELECT_SINISMES_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_SINISMES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISMES_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.SINISMES_IMP_SEGURADA_IX = result[i++].Value?.ToString();
            dta.SINISMES_COD_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}