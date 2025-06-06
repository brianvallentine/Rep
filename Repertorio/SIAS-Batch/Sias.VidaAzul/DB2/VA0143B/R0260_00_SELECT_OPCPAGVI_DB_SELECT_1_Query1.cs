using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0143B
{
    public class R0260_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 : QueryBasis<R0260_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA
            ,DATA_TERVIGENCIA
            ,OPCAO_PAGAMENTO
            ,PERI_PAGAMENTO
            ,DIA_DEBITO
            INTO :OPCPAGVI-DATA-INIVIGENCIA
            ,:OPCPAGVI-DATA-TERVIGENCIA
            ,:OPCPAGVI-OPCAO-PAGAMENTO
            ,:OPCPAGVI-PERI-PAGAMENTO
            ,:OPCPAGVI-DIA-DEBITO
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO
            AND DATA_INIVIGENCIA <= :PARCEVID-DATA-VENCIMENTO
            AND DATA_TERVIGENCIA >= :PARCEVID-DATA-VENCIMENTO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA
											,DATA_TERVIGENCIA
											,OPCAO_PAGAMENTO
											,PERI_PAGAMENTO
											,DIA_DEBITO
											FROM SEGUROS.OPCAO_PAG_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.HISCONPA_NUM_CERTIFICADO}'
											AND DATA_INIVIGENCIA <= '{this.PARCEVID_DATA_VENCIMENTO}'
											AND DATA_TERVIGENCIA >= '{this.PARCEVID_DATA_VENCIMENTO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string OPCPAGVI_DATA_INIVIGENCIA { get; set; }
        public string OPCPAGVI_DATA_TERVIGENCIA { get; set; }
        public string OPCPAGVI_OPCAO_PAGAMENTO { get; set; }
        public string OPCPAGVI_PERI_PAGAMENTO { get; set; }
        public string OPCPAGVI_DIA_DEBITO { get; set; }
        public string HISCONPA_NUM_CERTIFICADO { get; set; }
        public string PARCEVID_DATA_VENCIMENTO { get; set; }

        public static R0260_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 Execute(R0260_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 r0260_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1)
        {
            var ths = r0260_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0260_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0260_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPCPAGVI_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.OPCPAGVI_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.OPCPAGVI_OPCAO_PAGAMENTO = result[i++].Value?.ToString();
            dta.OPCPAGVI_PERI_PAGAMENTO = result[i++].Value?.ToString();
            dta.OPCPAGVI_DIA_DEBITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}