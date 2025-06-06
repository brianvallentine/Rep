using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0106B
{
    public class R1250_00_SELECT_V0FATURASFIL_DB_SELECT_1_Query1 : QueryBasis<R1250_00_SELECT_V0FATURASFIL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_OPERACAO
            INTO :V1FATR-CODOPER
            FROM SEGUROS.V0FATURASFIL
            WHERE NUM_APOLICE = :V1FATC-NUM-APOL
            AND COD_SUBGRUPO = :V1FATC-COD-SUBG
            AND NUM_FATURA = :V1FATR-NUM-FATUR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_OPERACAO
											FROM SEGUROS.V0FATURASFIL
											WHERE NUM_APOLICE = '{this.V1FATC_NUM_APOL}'
											AND COD_SUBGRUPO = '{this.V1FATC_COD_SUBG}'
											AND NUM_FATURA = '{this.V1FATR_NUM_FATUR}'";

            return query;
        }
        public string V1FATR_CODOPER { get; set; }
        public string V1FATR_NUM_FATUR { get; set; }
        public string V1FATC_NUM_APOL { get; set; }
        public string V1FATC_COD_SUBG { get; set; }

        public static R1250_00_SELECT_V0FATURASFIL_DB_SELECT_1_Query1 Execute(R1250_00_SELECT_V0FATURASFIL_DB_SELECT_1_Query1 r1250_00_SELECT_V0FATURASFIL_DB_SELECT_1_Query1)
        {
            var ths = r1250_00_SELECT_V0FATURASFIL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1250_00_SELECT_V0FATURASFIL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1250_00_SELECT_V0FATURASFIL_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1FATR_CODOPER = result[i++].Value?.ToString();
            return dta;
        }

    }
}