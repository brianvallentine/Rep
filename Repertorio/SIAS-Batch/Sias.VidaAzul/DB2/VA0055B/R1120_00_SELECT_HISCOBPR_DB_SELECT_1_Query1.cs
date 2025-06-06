using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0055B
{
    public class R1120_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 : QueryBasis<R1120_00_SELECT_HISCOBPR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMP_MORNATU
            INTO :HISCOBPR-IMP-MORNATU
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND DATA_TERVIGENCIA = '9999-12-31'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMP_MORNATU
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND DATA_TERVIGENCIA = '9999-12-31'
											WITH UR";

            return query;
        }
        public string HISCOBPR_IMP_MORNATU { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R1120_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 Execute(R1120_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 r1120_00_SELECT_HISCOBPR_DB_SELECT_1_Query1)
        {
            var ths = r1120_00_SELECT_HISCOBPR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1120_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1120_00_SELECT_HISCOBPR_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCOBPR_IMP_MORNATU = result[i++].Value?.ToString();
            return dta;
        }

    }
}