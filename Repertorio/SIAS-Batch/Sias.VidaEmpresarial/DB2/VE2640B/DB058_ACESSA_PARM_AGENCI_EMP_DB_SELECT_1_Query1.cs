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
    public class DB058_ACESSA_PARM_AGENCI_EMP_DB_SELECT_1_Query1 : QueryBasis<DB058_ACESSA_PARM_AGENCI_EMP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PCCOMGER,
            PCCOMVEN
            INTO :PARAGEEM-PCCOMGER,
            :PARAGEEM-PCCOMVEN
            FROM SEGUROS.PARM_AGENCI_EMP
            WHERE NUM_APOLICE = :PARAGEEM-NUM-APOLICE
            AND PERI_PAGAMENTO = :PARAGEEM-PERI-PAGAMENTO
            AND DATA_INIVIGENCIA <= :PARAGEEM-DATA-INIVIGENCIA
            AND DATA_TERVIGENCIA >= :PARAGEEM-DATA-INIVIGENCIA
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT PCCOMGER
							,
											PCCOMVEN
											FROM SEGUROS.PARM_AGENCI_EMP
											WHERE NUM_APOLICE = '{this.PARAGEEM_NUM_APOLICE}'
											AND PERI_PAGAMENTO = '{this.PARAGEEM_PERI_PAGAMENTO}'
											AND DATA_INIVIGENCIA <= '{this.PARAGEEM_DATA_INIVIGENCIA}'
											AND DATA_TERVIGENCIA >= '{this.PARAGEEM_DATA_INIVIGENCIA}'";

            return query;
        }
        public string PARAGEEM_PCCOMGER { get; set; }
        public string PARAGEEM_PCCOMVEN { get; set; }
        public string PARAGEEM_DATA_INIVIGENCIA { get; set; }
        public string PARAGEEM_PERI_PAGAMENTO { get; set; }
        public string PARAGEEM_NUM_APOLICE { get; set; }

        public static DB058_ACESSA_PARM_AGENCI_EMP_DB_SELECT_1_Query1 Execute(DB058_ACESSA_PARM_AGENCI_EMP_DB_SELECT_1_Query1 dB058_ACESSA_PARM_AGENCI_EMP_DB_SELECT_1_Query1)
        {
            var ths = dB058_ACESSA_PARM_AGENCI_EMP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB058_ACESSA_PARM_AGENCI_EMP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB058_ACESSA_PARM_AGENCI_EMP_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARAGEEM_PCCOMGER = result[i++].Value?.ToString();
            dta.PARAGEEM_PCCOMVEN = result[i++].Value?.ToString();
            return dta;
        }

    }
}