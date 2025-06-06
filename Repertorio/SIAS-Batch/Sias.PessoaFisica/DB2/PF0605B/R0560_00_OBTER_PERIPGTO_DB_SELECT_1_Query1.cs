using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0605B
{
    public class R0560_00_OBTER_PERIPGTO_DB_SELECT_1_Query1 : QueryBasis<R0560_00_OBTER_PERIPGTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PERI_PAGAMENTO
            INTO :OPCPAGVI-PERI-PAGAMENTO
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO = :DCLPROPOSTAS-VA.NUM-CERTIFICADO
            AND DATA_TERVIGENCIA = '9999-12-31'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PERI_PAGAMENTO
											FROM SEGUROS.OPCAO_PAG_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.NUM_CERTIFICADO}'
											AND DATA_TERVIGENCIA = '9999-12-31'
											WITH UR";

            return query;
        }
        public string OPCPAGVI_PERI_PAGAMENTO { get; set; }
        public string NUM_CERTIFICADO { get; set; }

        public static R0560_00_OBTER_PERIPGTO_DB_SELECT_1_Query1 Execute(R0560_00_OBTER_PERIPGTO_DB_SELECT_1_Query1 r0560_00_OBTER_PERIPGTO_DB_SELECT_1_Query1)
        {
            var ths = r0560_00_OBTER_PERIPGTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0560_00_OBTER_PERIPGTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0560_00_OBTER_PERIPGTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPCPAGVI_PERI_PAGAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}