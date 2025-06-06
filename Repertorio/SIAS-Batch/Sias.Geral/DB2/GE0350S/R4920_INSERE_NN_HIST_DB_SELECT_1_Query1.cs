using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0350S
{
    public class R4920_INSERE_NN_HIST_DB_SELECT_1_Query1 : QueryBasis<R4920_INSERE_NN_HIST_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(SEQ_CONTROLE_SIGCB_HIST), 0) + 1
            INTO :WS-SEQ-CONTROLE-HIST
            FROM SEGUROS.GE_CONTROLE_SIGCB_HIST
            WHERE NUM_PROPOSTA = :GE403-NUM-PROPOSTA
            AND NUM_CERTIFICADO = :GE403-NUM-CERTIFICADO
            AND NUM_PARCELA = :GE403-NUM-PARCELA
            AND NUM_ENDOSSO = :GE403-NUM-ENDOSSO
            AND SEQ_CONTROLE_SIGCB = :GE403-SEQ-CONTROLE-SIGCB
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(SEQ_CONTROLE_SIGCB_HIST)
							, 0) + 1
											FROM SEGUROS.GE_CONTROLE_SIGCB_HIST
											WHERE NUM_PROPOSTA = '{this.GE403_NUM_PROPOSTA}'
											AND NUM_CERTIFICADO = '{this.GE403_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.GE403_NUM_PARCELA}'
											AND NUM_ENDOSSO = '{this.GE403_NUM_ENDOSSO}'
											AND SEQ_CONTROLE_SIGCB = '{this.GE403_SEQ_CONTROLE_SIGCB}'
											WITH UR";

            return query;
        }
        public string WS_SEQ_CONTROLE_HIST { get; set; }
        public string GE403_SEQ_CONTROLE_SIGCB { get; set; }
        public string GE403_NUM_CERTIFICADO { get; set; }
        public string GE403_NUM_PROPOSTA { get; set; }
        public string GE403_NUM_PARCELA { get; set; }
        public string GE403_NUM_ENDOSSO { get; set; }

        public static R4920_INSERE_NN_HIST_DB_SELECT_1_Query1 Execute(R4920_INSERE_NN_HIST_DB_SELECT_1_Query1 r4920_INSERE_NN_HIST_DB_SELECT_1_Query1)
        {
            var ths = r4920_INSERE_NN_HIST_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4920_INSERE_NN_HIST_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4920_INSERE_NN_HIST_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_SEQ_CONTROLE_HIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}