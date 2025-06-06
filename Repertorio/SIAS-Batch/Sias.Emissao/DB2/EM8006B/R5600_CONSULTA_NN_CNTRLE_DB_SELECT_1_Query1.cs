using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8006B
{
    public class R5600_CONSULTA_NN_CNTRLE_DB_SELECT_1_Query1 : QueryBasis<R5600_CONSULTA_NN_CNTRLE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_PRODUTO
            INTO :GE403-COD-PRODUTO
            FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB A
            WHERE A.NUM_NOSSO_NUMERO_SAP =
            :GE403-NUM-NOSSO-NUMERO-SAP
            AND A.SEQ_CONTROLE_SIGCB =
            ( SELECT MAX(B.SEQ_CONTROLE_SIGCB)
            FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB B
            WHERE B.NUM_PROPOSTA = A.NUM_PROPOSTA
            AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO
            AND B.NUM_PARCELA = A.NUM_PARCELA
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.NUM_ENDOSSO = A.NUM_ENDOSSO
            )
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT A.COD_PRODUTO
											FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB A
											WHERE A.NUM_NOSSO_NUMERO_SAP =
											'{this.GE403_NUM_NOSSO_NUMERO_SAP}'
											AND A.SEQ_CONTROLE_SIGCB =
											( SELECT MAX(B.SEQ_CONTROLE_SIGCB)
											FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB B
											WHERE B.NUM_PROPOSTA = A.NUM_PROPOSTA
											AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO
											AND B.NUM_PARCELA = A.NUM_PARCELA
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.NUM_ENDOSSO = A.NUM_ENDOSSO
											)
											WITH UR";

            return query;
        }
        public string GE403_COD_PRODUTO { get; set; }
        public string GE403_NUM_NOSSO_NUMERO_SAP { get; set; }

        public static R5600_CONSULTA_NN_CNTRLE_DB_SELECT_1_Query1 Execute(R5600_CONSULTA_NN_CNTRLE_DB_SELECT_1_Query1 r5600_CONSULTA_NN_CNTRLE_DB_SELECT_1_Query1)
        {
            var ths = r5600_CONSULTA_NN_CNTRLE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5600_CONSULTA_NN_CNTRLE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5600_CONSULTA_NN_CNTRLE_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE403_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}