using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0139B
{
    public class R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1 : QueryBasis<R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPCAO_PAGAMENTO
            INTO :OPCPAGVI-OPCAO-PAGAMENTO
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO = :OPCPAGVI-NUM-CERTIFICADO
            AND DATA_TERVIGENCIA = '9999-12-31'
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT OPCAO_PAGAMENTO
											FROM SEGUROS.OPCAO_PAG_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.OPCPAGVI_NUM_CERTIFICADO}'
											AND DATA_TERVIGENCIA = '9999-12-31'";

            return query;
        }
        public string OPCPAGVI_OPCAO_PAGAMENTO { get; set; }
        public string OPCPAGVI_NUM_CERTIFICADO { get; set; }

        public static R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1 Execute(R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1 r1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1)
        {
            var ths = r1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPCPAGVI_OPCAO_PAGAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}