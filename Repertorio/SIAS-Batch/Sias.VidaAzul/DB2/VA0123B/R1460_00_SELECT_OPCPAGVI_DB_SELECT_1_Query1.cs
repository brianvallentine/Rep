using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R1460_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 : QueryBasis<R1460_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPCAO_PAGAMENTO
            INTO :OPCPAGVI-OPCAO-PAGAMENTO
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND DATA_INIVIGENCIA = :SISTEMAS-DATA-MOV-ABERTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OPCAO_PAGAMENTO
											FROM SEGUROS.OPCAO_PAG_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND DATA_INIVIGENCIA = '{this.SISTEMAS_DATA_MOV_ABERTO}'
											WITH UR";

            return query;
        }
        public string OPCPAGVI_OPCAO_PAGAMENTO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R1460_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 Execute(R1460_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 r1460_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1)
        {
            var ths = r1460_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1460_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1460_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPCPAGVI_OPCAO_PAGAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}