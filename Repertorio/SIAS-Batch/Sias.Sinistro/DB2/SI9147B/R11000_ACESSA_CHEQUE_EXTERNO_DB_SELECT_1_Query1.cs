using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9147B
{
    public class R11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1_Query1 : QueryBasis<R11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CHEQUE ,
            SERIE_CHEQUE
            INTO :LOTECHEQ-NUM-CHEQUE,
            :LOTECHEQ-SERIE-CHEQUE
            FROM SEGUROS.LOTE_CHEQUES
            WHERE NUM_CHEQUE_INTERNO = :SISINCHE-NUM-CHEQUE-INTERNO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CHEQUE 
							,
											SERIE_CHEQUE
											FROM SEGUROS.LOTE_CHEQUES
											WHERE NUM_CHEQUE_INTERNO = '{this.SISINCHE_NUM_CHEQUE_INTERNO}'";

            return query;
        }
        public string LOTECHEQ_NUM_CHEQUE { get; set; }
        public string LOTECHEQ_SERIE_CHEQUE { get; set; }
        public string SISINCHE_NUM_CHEQUE_INTERNO { get; set; }

        public static R11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1_Query1 Execute(R11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1_Query1 r11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1_Query1)
        {
            var ths = r11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1_Query1();
            var i = 0;
            dta.LOTECHEQ_NUM_CHEQUE = result[i++].Value?.ToString();
            dta.LOTECHEQ_SERIE_CHEQUE = result[i++].Value?.ToString();
            return dta;
        }

    }
}