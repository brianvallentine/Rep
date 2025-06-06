using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0618B
{
    public class R0156_00_OBTER_PERIPGTO_DB_SELECT_1_Query1 : QueryBasis<R0156_00_OBTER_PERIPGTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PERI_PAGAMENTO
            INTO :OPCPAGVI-PERI-PAGAMENTO
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO = :OPCPAGVI-NUM-CERTIFICADO
            AND DATA_INIVIGENCIA <=
            :MOVIMVGA-DATA-INCLUSAO
            AND DATA_TERVIGENCIA >=
            :MOVIMVGA-DATA-INCLUSAO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT PERI_PAGAMENTO
											FROM SEGUROS.OPCAO_PAG_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.OPCPAGVI_NUM_CERTIFICADO}'
											AND DATA_INIVIGENCIA <=
											'{this.MOVIMVGA_DATA_INCLUSAO}'
											AND DATA_TERVIGENCIA >=
											'{this.MOVIMVGA_DATA_INCLUSAO}'
											WITH UR";

            return query;
        }
        public string OPCPAGVI_PERI_PAGAMENTO { get; set; }
        public string OPCPAGVI_NUM_CERTIFICADO { get; set; }
        public string MOVIMVGA_DATA_INCLUSAO { get; set; }

        public static R0156_00_OBTER_PERIPGTO_DB_SELECT_1_Query1 Execute(R0156_00_OBTER_PERIPGTO_DB_SELECT_1_Query1 r0156_00_OBTER_PERIPGTO_DB_SELECT_1_Query1)
        {
            var ths = r0156_00_OBTER_PERIPGTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0156_00_OBTER_PERIPGTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0156_00_OBTER_PERIPGTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPCPAGVI_PERI_PAGAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}