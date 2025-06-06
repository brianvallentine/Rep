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
    public class R2200_MAX_SEQ_CONTROLE_EMISSAO_DB_SELECT_1_Query1 : QueryBasis<R2200_MAX_SEQ_CONTROLE_EMISSAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(SEQ_CONTROLE_SIGCB), 0) + 1
            INTO :GE403-SEQ-CONTROLE-SIGCB
            FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB
            WHERE NUM_PROPOSTA = :GE403-NUM-PROPOSTA
            AND NUM_CERTIFICADO = :GE403-NUM-CERTIFICADO
            AND NUM_PARCELA = :GE403-NUM-PARCELA
            AND NUM_APOLICE = :GE403-NUM-APOLICE
            AND NUM_ENDOSSO = :GE403-NUM-ENDOSSO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(SEQ_CONTROLE_SIGCB)
							, 0) + 1
											FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB
											WHERE NUM_PROPOSTA = '{this.GE403_NUM_PROPOSTA}'
											AND NUM_CERTIFICADO = '{this.GE403_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.GE403_NUM_PARCELA}'
											AND NUM_APOLICE = '{this.GE403_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.GE403_NUM_ENDOSSO}'
											WITH UR";

            return query;
        }
        public string GE403_SEQ_CONTROLE_SIGCB { get; set; }
        public string GE403_NUM_CERTIFICADO { get; set; }
        public string GE403_NUM_PROPOSTA { get; set; }
        public string GE403_NUM_PARCELA { get; set; }
        public string GE403_NUM_APOLICE { get; set; }
        public string GE403_NUM_ENDOSSO { get; set; }

        public static R2200_MAX_SEQ_CONTROLE_EMISSAO_DB_SELECT_1_Query1 Execute(R2200_MAX_SEQ_CONTROLE_EMISSAO_DB_SELECT_1_Query1 r2200_MAX_SEQ_CONTROLE_EMISSAO_DB_SELECT_1_Query1)
        {
            var ths = r2200_MAX_SEQ_CONTROLE_EMISSAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2200_MAX_SEQ_CONTROLE_EMISSAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2200_MAX_SEQ_CONTROLE_EMISSAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE403_SEQ_CONTROLE_SIGCB = result[i++].Value?.ToString();
            return dta;
        }

    }
}