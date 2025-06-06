using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMPSEGUR
            INTO :DCLHIS-COBER-PROPOST.IMPSEGUR
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF
            AND DATA_TERVIGENCIA = '9999-12-31'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMPSEGUR
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.PROPVA_NRCERTIF}'
											AND DATA_TERVIGENCIA = '9999-12-31'";

            return query;
        }
        public string IMPSEGUR { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1 Execute(R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1 r22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1)
        {
            var ths = r22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.IMPSEGUR = result[i++].Value?.ToString();
            return dta;
        }

    }
}