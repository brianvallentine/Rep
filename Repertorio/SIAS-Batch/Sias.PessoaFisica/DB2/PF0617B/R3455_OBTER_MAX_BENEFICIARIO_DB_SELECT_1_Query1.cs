using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0617B
{
    public class R3455_OBTER_MAX_BENEFICIARIO_DB_SELECT_1_Query1 : QueryBasis<R3455_OBTER_MAX_BENEFICIARIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_BENEFICIARIO),0)
            INTO :DCLBENEF-PROP-AZUL.NUM-BENEFICIARIO
            FROM SEGUROS.BENEF_PROP_AZUL
            WHERE NUM_PROPOSTA_AZUL =
            :DCLBENEF-PROP-AZUL.NUM-PROPOSTA-AZUL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_BENEFICIARIO)
							,0)
											FROM SEGUROS.BENEF_PROP_AZUL
											WHERE NUM_PROPOSTA_AZUL =
											'{this.NUM_PROPOSTA_AZUL}'";

            return query;
        }
        public string NUM_BENEFICIARIO { get; set; }
        public string NUM_PROPOSTA_AZUL { get; set; }

        public static R3455_OBTER_MAX_BENEFICIARIO_DB_SELECT_1_Query1 Execute(R3455_OBTER_MAX_BENEFICIARIO_DB_SELECT_1_Query1 r3455_OBTER_MAX_BENEFICIARIO_DB_SELECT_1_Query1)
        {
            var ths = r3455_OBTER_MAX_BENEFICIARIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3455_OBTER_MAX_BENEFICIARIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3455_OBTER_MAX_BENEFICIARIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUM_BENEFICIARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}