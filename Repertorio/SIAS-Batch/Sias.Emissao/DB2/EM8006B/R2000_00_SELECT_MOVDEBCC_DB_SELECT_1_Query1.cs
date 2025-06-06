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
    public class R2000_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1 : QueryBasis<R2000_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE ,
            NUM_ENDOSSO ,
            NUM_PARCELA ,
            SITUACAO_COBRANCA ,
            VALUE(COD_AGENCIA_DEB, 0) ,
            VALUE(OPER_CONTA_DEB, 0) ,
            VALUE(NUM_CONTA_DEB, 0) ,
            VALUE(DIG_CONTA_DEB, 0) ,
            COD_CONVENIO ,
            NSAS ,
            VALUE(NUM_REQUISICAO, 0) ,
            VALUE(NUM_CARTAO, 0)
            INTO :MOVDEBCE-NUM-APOLICE ,
            :MOVDEBCE-NUM-ENDOSSO ,
            :MOVDEBCE-NUM-PARCELA ,
            :MOVDEBCE-SITUACAO-COBRANCA ,
            :MOVDEBCE-COD-AGENCIA-DEB ,
            :MOVDEBCE-OPER-CONTA-DEB ,
            :MOVDEBCE-NUM-CONTA-DEB ,
            :MOVDEBCE-DIG-CONTA-DEB ,
            :MOVDEBCE-COD-CONVENIO ,
            :MOVDEBCE-NSAS ,
            :MOVDEBCE-NUM-REQUISICAO ,
            :MOVDEBCE-NUM-CARTAO
            FROM SEGUROS.MOVTO_DEBITOCC_CEF
            WHERE SITUACAO_COBRANCA = '5'
            AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO
            AND NSAS = :MOVDEBCE-NSAS
            AND NUM_REQUISICAO = :MOVDEBCE-NUM-REQUISICAO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
							,
											NUM_ENDOSSO 
							,
											NUM_PARCELA 
							,
											SITUACAO_COBRANCA 
							,
											VALUE(COD_AGENCIA_DEB
							, 0) 
							,
											VALUE(OPER_CONTA_DEB
							, 0) 
							,
											VALUE(NUM_CONTA_DEB
							, 0) 
							,
											VALUE(DIG_CONTA_DEB
							, 0) 
							,
											COD_CONVENIO 
							,
											NSAS 
							,
											VALUE(NUM_REQUISICAO
							, 0) 
							,
											VALUE(NUM_CARTAO
							, 0)
											FROM SEGUROS.MOVTO_DEBITOCC_CEF
											WHERE SITUACAO_COBRANCA = '5'
											AND COD_CONVENIO = '{this.MOVDEBCE_COD_CONVENIO}'
											AND NSAS = '{this.MOVDEBCE_NSAS}'
											AND NUM_REQUISICAO = '{this.MOVDEBCE_NUM_REQUISICAO}'
											WITH UR";

            return query;
        }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }
        public string MOVDEBCE_SITUACAO_COBRANCA { get; set; }
        public string MOVDEBCE_COD_AGENCIA_DEB { get; set; }
        public string MOVDEBCE_OPER_CONTA_DEB { get; set; }
        public string MOVDEBCE_NUM_CONTA_DEB { get; set; }
        public string MOVDEBCE_DIG_CONTA_DEB { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string MOVDEBCE_NSAS { get; set; }
        public string MOVDEBCE_NUM_REQUISICAO { get; set; }
        public string MOVDEBCE_NUM_CARTAO { get; set; }

        public static R2000_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1 Execute(R2000_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1 r2000_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1)
        {
            var ths = r2000_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2000_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2000_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVDEBCE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_PARCELA = result[i++].Value?.ToString();
            dta.MOVDEBCE_SITUACAO_COBRANCA = result[i++].Value?.ToString();
            dta.MOVDEBCE_COD_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_OPER_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_DIG_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_COD_CONVENIO = result[i++].Value?.ToString();
            dta.MOVDEBCE_NSAS = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_REQUISICAO = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_CARTAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}