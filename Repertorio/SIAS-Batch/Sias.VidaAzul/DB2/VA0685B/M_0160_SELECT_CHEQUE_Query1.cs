using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0685B
{
    public class M_0160_SELECT_CHEQUE_Query1 : QueryBasis<M_0160_SELECT_CHEQUE_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CHEQUE_INTERNO,
            DIG_CHEQUE_INTERNO
            INTO :CBCONDEV-NUM-CHEQUE-INTERNO,
            :CBCONDEV-DIG-CHEQUE-INTERNO
            FROM SEGUROS.CB_CONTR_DEVPREMIO
            WHERE NUM_CERTIFICADO = :HISCOBPR-NUM-CERTIFICADO
            FETCH FIRST 1 ROW ONLY
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CHEQUE_INTERNO
							,
											DIG_CHEQUE_INTERNO
											FROM SEGUROS.CB_CONTR_DEVPREMIO
											WHERE NUM_CERTIFICADO = '{this.HISCOBPR_NUM_CERTIFICADO}'
											FETCH FIRST 1 ROW ONLY";

            return query;
        }
        public string CBCONDEV_NUM_CHEQUE_INTERNO { get; set; }
        public string CBCONDEV_DIG_CHEQUE_INTERNO { get; set; }
        public string HISCOBPR_NUM_CERTIFICADO { get; set; }

        public static M_0160_SELECT_CHEQUE_Query1 Execute(M_0160_SELECT_CHEQUE_Query1 m_0160_SELECT_CHEQUE_Query1)
        {
            var ths = m_0160_SELECT_CHEQUE_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0160_SELECT_CHEQUE_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0160_SELECT_CHEQUE_Query1();
            var i = 0;
            dta.CBCONDEV_NUM_CHEQUE_INTERNO = result[i++].Value?.ToString();
            dta.CBCONDEV_DIG_CHEQUE_INTERNO = result[i++].Value?.ToString();
            return dta;
        }

    }
}