using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0709B
{
    public class R0430_00_LER_PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<R0430_00_LER_PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO
            INTO :DCLPROPOSTAS-VA.SIT-REGISTRO
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_CERTIFICADO =
            :DCLPARCELAS-VIDAZUL.NUM-CERTIFICADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_CERTIFICADO =
											'{this.NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string SIT_REGISTRO { get; set; }
        public string NUM_CERTIFICADO { get; set; }

        public static R0430_00_LER_PROPOSTA_DB_SELECT_1_Query1 Execute(R0430_00_LER_PROPOSTA_DB_SELECT_1_Query1 r0430_00_LER_PROPOSTA_DB_SELECT_1_Query1)
        {
            var ths = r0430_00_LER_PROPOSTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0430_00_LER_PROPOSTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0430_00_LER_PROPOSTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}