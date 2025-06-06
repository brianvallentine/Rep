using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0123B
{
    public class R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 : QueryBasis<R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(OCORR_HISTORICO)
            INTO :HISCOBPR-OCORR-HISTORICO
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(OCORR_HISTORICO)
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string HISCOBPR_OCORR_HISTORICO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 Execute(R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 r8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1)
        {
            var ths = r8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8000_00_SELECT_HISCOBPR_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCOBPR_OCORR_HISTORICO = result[i++].Value?.ToString();
            return dta;
        }

    }
}