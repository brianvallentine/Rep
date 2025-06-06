using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0005S
{
    public class P0401_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0401_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NSL),0) + 1
            INTO :HISPROFI-NSL
            FROM SEGUROS.HIST_PROP_FIDELIZ
            WHERE NUM_IDENTIFICACAO
            = :HISPROFI-NUM-IDENTIFICACAO
            AND DATA_SITUACAO = :HISPROFI-DATA-SITUACAO
            AND NSAS_SIVPF = :HISPROFI-NSAS-SIVPF
            AND SIT_PROPOSTA = :HISPROFI-SIT-PROPOSTA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NSL)
							,0) + 1
											FROM SEGUROS.HIST_PROP_FIDELIZ
											WHERE NUM_IDENTIFICACAO
											= '{this.HISPROFI_NUM_IDENTIFICACAO}'
											AND DATA_SITUACAO = '{this.HISPROFI_DATA_SITUACAO}'
											AND NSAS_SIVPF = '{this.HISPROFI_NSAS_SIVPF}'
											AND SIT_PROPOSTA = '{this.HISPROFI_SIT_PROPOSTA}'
											WITH UR";

            return query;
        }
        public string HISPROFI_NSL { get; set; }
        public string HISPROFI_NUM_IDENTIFICACAO { get; set; }
        public string HISPROFI_DATA_SITUACAO { get; set; }
        public string HISPROFI_SIT_PROPOSTA { get; set; }
        public string HISPROFI_NSAS_SIVPF { get; set; }

        public static P0401_05_INICIO_DB_SELECT_1_Query1 Execute(P0401_05_INICIO_DB_SELECT_1_Query1 p0401_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0401_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0401_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0401_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISPROFI_NSL = result[i++].Value?.ToString();
            return dta;
        }

    }
}