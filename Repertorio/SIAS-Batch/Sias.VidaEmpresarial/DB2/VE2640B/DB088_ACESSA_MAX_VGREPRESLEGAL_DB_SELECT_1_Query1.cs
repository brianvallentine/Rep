using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB088_ACESSA_MAX_VGREPRESLEGAL_DB_SELECT_1_Query1 : QueryBasis<DB088_ACESSA_MAX_VGREPRESLEGAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_OCORR_HIST),0)
            INTO :VG093-NUM-OCORR-HIST
            FROM SEGUROS.VG_REPRES_LEGAL
            WHERE COD_PESSOA = :PESSOFIS-COD-PESSOA
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_OCORR_HIST)
							,0)
											FROM SEGUROS.VG_REPRES_LEGAL
											WHERE COD_PESSOA = '{this.PESSOFIS_COD_PESSOA}'";

            return query;
        }
        public string VG093_NUM_OCORR_HIST { get; set; }
        public string PESSOFIS_COD_PESSOA { get; set; }

        public static DB088_ACESSA_MAX_VGREPRESLEGAL_DB_SELECT_1_Query1 Execute(DB088_ACESSA_MAX_VGREPRESLEGAL_DB_SELECT_1_Query1 dB088_ACESSA_MAX_VGREPRESLEGAL_DB_SELECT_1_Query1)
        {
            var ths = dB088_ACESSA_MAX_VGREPRESLEGAL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB088_ACESSA_MAX_VGREPRESLEGAL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB088_ACESSA_MAX_VGREPRESLEGAL_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG093_NUM_OCORR_HIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}