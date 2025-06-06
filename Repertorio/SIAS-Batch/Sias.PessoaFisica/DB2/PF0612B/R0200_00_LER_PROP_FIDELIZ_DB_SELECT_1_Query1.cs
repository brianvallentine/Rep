using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0612B
{
    public class R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 : QueryBasis<R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_PROPOSTA,
            NUM_SICOB,
            ORIGEM_PROPOSTA,
            IND_TP_PROPOSTA
            INTO :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA,
            :DCLPROPOSTA-FIDELIZ.NUM-SICOB ,
            :DCLPROPOSTA-FIDELIZ.ORIGEM-PROPOSTA,
            :DCLPROPOSTA-FIDELIZ.IND-TP-PROPOSTA :VIND-NULL
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF =
            :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF
            AND COD_PRODUTO_SIVPF <> 48
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_PROPOSTA
							,
											NUM_SICOB
							,
											ORIGEM_PROPOSTA
							,
											IND_TP_PROPOSTA
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF =
											'{this.NUM_PROPOSTA_SIVPF}'
											AND COD_PRODUTO_SIVPF <> 48
											WITH UR";

            return query;
        }
        public string SIT_PROPOSTA { get; set; }
        public string NUM_SICOB { get; set; }
        public string ORIGEM_PROPOSTA { get; set; }
        public string IND_TP_PROPOSTA { get; set; }
        public string VIND_NULL { get; set; }
        public string NUM_PROPOSTA_SIVPF { get; set; }

        public static R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 Execute(R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 r0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1)
        {
            var ths = r0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIT_PROPOSTA = result[i++].Value?.ToString();
            dta.NUM_SICOB = result[i++].Value?.ToString();
            dta.ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            dta.IND_TP_PROPOSTA = result[i++].Value?.ToString();
            dta.VIND_NULL = string.IsNullOrWhiteSpace(dta.IND_TP_PROPOSTA) ? "-1" : "0";
            return dta;
        }

    }
}