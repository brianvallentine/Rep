using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF2002B
{
    public class R3210_VER_MOVIMENTO_DB_SELECT_1_Query1 : QueryBasis<R3210_VER_MOVIMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.NUM_APOLICE
            ,B.NUM_ENDOSSO
            ,B.NUM_PARCELA
            ,B.TIPO_MOVIMENTO
            ,B.NUM_NOSSO_TITULO
            INTO :MOVIMCOB-NUM-APOLICE
            ,:MOVIMCOB-NUM-ENDOSSO
            ,:MOVIMCOB-NUM-PARCELA
            ,:MOVIMCOB-TIPO-MOVIMENTO
            ,:MOVIMCOB-NUM-NOSSO-TITULO
            FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB A
            ,SEGUROS.MOVIMENTO_COBRANCA B
            WHERE A.NUM_NOSSO_NUMERO_SAP =
            :GE403-NUM-NOSSO-NUMERO-SAP
            AND A.NUM_PROPOSTA = B.NUM_NOSSO_TITULO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.NUM_APOLICE
											,B.NUM_ENDOSSO
											,B.NUM_PARCELA
											,B.TIPO_MOVIMENTO
											,B.NUM_NOSSO_TITULO
											FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB A
											,SEGUROS.MOVIMENTO_COBRANCA B
											WHERE A.NUM_NOSSO_NUMERO_SAP =
											'{this.GE403_NUM_NOSSO_NUMERO_SAP}'
											AND A.NUM_PROPOSTA = B.NUM_NOSSO_TITULO
											WITH UR";

            return query;
        }
        public string MOVIMCOB_NUM_APOLICE { get; set; }
        public string MOVIMCOB_NUM_ENDOSSO { get; set; }
        public string MOVIMCOB_NUM_PARCELA { get; set; }
        public string MOVIMCOB_TIPO_MOVIMENTO { get; set; }
        public string MOVIMCOB_NUM_NOSSO_TITULO { get; set; }
        public string GE403_NUM_NOSSO_NUMERO_SAP { get; set; }

        public static R3210_VER_MOVIMENTO_DB_SELECT_1_Query1 Execute(R3210_VER_MOVIMENTO_DB_SELECT_1_Query1 r3210_VER_MOVIMENTO_DB_SELECT_1_Query1)
        {
            var ths = r3210_VER_MOVIMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3210_VER_MOVIMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3210_VER_MOVIMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVIMCOB_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVIMCOB_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.MOVIMCOB_NUM_PARCELA = result[i++].Value?.ToString();
            dta.MOVIMCOB_TIPO_MOVIMENTO = result[i++].Value?.ToString();
            dta.MOVIMCOB_NUM_NOSSO_TITULO = result[i++].Value?.ToString();
            return dta;
        }

    }
}