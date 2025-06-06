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
    public class DB048_ACESSA_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1 : QueryBasis<DB048_ACESSA_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_IDENTIFICACAO
            , IND_TP_PROPOSTA
            INTO :PROPOFID-NUM-IDENTIFICACAO
            , :PROPOFID-IND-TP-PROPOSTA:N-TP-PROPOSTA
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF = :H-NUM-PROPOSTA-SIVPF
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_IDENTIFICACAO
											, IND_TP_PROPOSTA
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF = '{this.H_NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }
        public string PROPOFID_IND_TP_PROPOSTA { get; set; }
        public string N_TP_PROPOSTA { get; set; }
        public string H_NUM_PROPOSTA_SIVPF { get; set; }

        public static DB048_ACESSA_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1 Execute(DB048_ACESSA_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1 dB048_ACESSA_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1)
        {
            var ths = dB048_ACESSA_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB048_ACESSA_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB048_ACESSA_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            dta.PROPOFID_IND_TP_PROPOSTA = result[i++].Value?.ToString();
            dta.N_TP_PROPOSTA = string.IsNullOrWhiteSpace(dta.PROPOFID_IND_TP_PROPOSTA) ? "-1" : "0";
            return dta;
        }

    }
}