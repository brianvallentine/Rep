using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class R7180_00_SELECT_PROPIDELIZ_DB_SELECT_1_Query1 : QueryBasis<R7180_00_SELECT_PROPIDELIZ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ORIGEM_PROPOSTA
            , COD_PLANO
            , CANAL_PROPOSTA
            INTO :PRPFIDEL-ORIGEM
            ,:PRPFIDEL-COD-PLANO
            ,:PRPFIDEL-CANAL
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_SICOB = :V0BILH-NUMBIL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ORIGEM_PROPOSTA
											, COD_PLANO
											, CANAL_PROPOSTA
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_SICOB = '{this.V0BILH_NUMBIL}'";

            return query;
        }
        public string PRPFIDEL_ORIGEM { get; set; }
        public string PRPFIDEL_COD_PLANO { get; set; }
        public string PRPFIDEL_CANAL { get; set; }
        public string V0BILH_NUMBIL { get; set; }

        public static R7180_00_SELECT_PROPIDELIZ_DB_SELECT_1_Query1 Execute(R7180_00_SELECT_PROPIDELIZ_DB_SELECT_1_Query1 r7180_00_SELECT_PROPIDELIZ_DB_SELECT_1_Query1)
        {
            var ths = r7180_00_SELECT_PROPIDELIZ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7180_00_SELECT_PROPIDELIZ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7180_00_SELECT_PROPIDELIZ_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRPFIDEL_ORIGEM = result[i++].Value?.ToString();
            dta.PRPFIDEL_COD_PLANO = result[i++].Value?.ToString();
            dta.PRPFIDEL_CANAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}