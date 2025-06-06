using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_1_Query1 : QueryBasis<R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTA_VENCIMENTO
            INTO :GE403-DTA-VENCIMENTO
            FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB A
            WHERE A.NUM_PROPOSTA = :GE403-NUM-PROPOSTA
            AND A.NUM_CERTIFICADO = :GE403-NUM-CERTIFICADO
            AND A.NUM_PARCELA = :GE403-NUM-PARCELA
            AND A.NUM_APOLICE = :GE403-NUM-APOLICE
            AND A.NUM_ENDOSSO = :GE403-NUM-ENDOSSO
            AND A.SEQ_CONTROLE_SIGCB =
            ( SELECT MAX(B.SEQ_CONTROLE_SIGCB)
            FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB B
            WHERE B.NUM_PROPOSTA = :GE403-NUM-PROPOSTA
            AND B.NUM_CERTIFICADO = :GE403-NUM-CERTIFICADO
            AND B.NUM_PARCELA = :GE403-NUM-PARCELA
            AND B.NUM_APOLICE = :GE403-NUM-APOLICE
            AND B.NUM_ENDOSSO = :GE403-NUM-ENDOSSO
            )
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DTA_VENCIMENTO
											FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB A
											WHERE A.NUM_PROPOSTA = '{this.GE403_NUM_PROPOSTA}'
											AND A.NUM_CERTIFICADO = '{this.GE403_NUM_CERTIFICADO}'
											AND A.NUM_PARCELA = '{this.GE403_NUM_PARCELA}'
											AND A.NUM_APOLICE = '{this.GE403_NUM_APOLICE}'
											AND A.NUM_ENDOSSO = '{this.GE403_NUM_ENDOSSO}'
											AND A.SEQ_CONTROLE_SIGCB =
											( SELECT MAX(B.SEQ_CONTROLE_SIGCB)
											FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB B
											WHERE B.NUM_PROPOSTA = '{this.GE403_NUM_PROPOSTA}'
											AND B.NUM_CERTIFICADO = '{this.GE403_NUM_CERTIFICADO}'
											AND B.NUM_PARCELA = '{this.GE403_NUM_PARCELA}'
											AND B.NUM_APOLICE = '{this.GE403_NUM_APOLICE}'
											AND B.NUM_ENDOSSO = '{this.GE403_NUM_ENDOSSO}'
											)
											WITH UR";

            return query;
        }
        public string GE403_DTA_VENCIMENTO { get; set; }
        public string GE403_NUM_CERTIFICADO { get; set; }
        public string GE403_NUM_PROPOSTA { get; set; }
        public string GE403_NUM_PARCELA { get; set; }
        public string GE403_NUM_APOLICE { get; set; }
        public string GE403_NUM_ENDOSSO { get; set; }

        public static R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_1_Query1 Execute(R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_1_Query1 r3441_00_CALCULA_JUROS_MULTA_DB_SELECT_1_Query1)
        {
            var ths = r3441_00_CALCULA_JUROS_MULTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE403_DTA_VENCIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}