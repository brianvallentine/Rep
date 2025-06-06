using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0503B
{
    public class R200_CONSULTA_BANCO_DB_SELECT_1_Query1 : QueryBasis<R200_CONSULTA_BANCO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_PESSOA ,
            A.DTH_CADASTRAMENTO ,
            A.NUM_DV_PESSOA ,
            A.IND_PESSOA ,
            A.STA_INF_INTEGRA ,
            B.SEQ_CONTA_BANCARIA ,
            B.DTH_CADASTRAMENTO ,
            B.STA_CONTA ,
            B.COD_BANCO ,
            B.COD_AGENCIA ,
            B.IND_CONTA_BANCARIA ,
            B.NUM_CONTA ,
            B.NUM_DV_CONTA ,
            B.NUM_OPERACAO_CONTA
            INTO :OD001-NUM-PESSOA ,
            :OD001-DTH-CADASTRAMENTO ,
            :OD001-NUM-DV-PESSOA ,
            :OD001-IND-PESSOA ,
            :OD001-STA-INF-INTEGRA ,
            :OD009-SEQ-CONTA-BANCARIA ,
            :OD009-DTH-CADASTRAMENTO ,
            :OD009-STA-CONTA ,
            :OD009-COD-BANCO ,
            :OD009-COD-AGENCIA ,
            :OD009-IND-CONTA-BANCARIA ,
            :OD009-NUM-CONTA ,
            :OD009-NUM-DV-CONTA:VIND-NULL01 ,
            :OD009-NUM-OPERACAO-CONTA:VIND-NULL02
            FROM ODS.OD_PESSOA A,
            ODS.OD_PESS_CONTA_BANC B
            WHERE A.NUM_PESSOA = :OD001-NUM-PESSOA
            AND B.NUM_PESSOA = A.NUM_PESSOA
            AND B.SEQ_CONTA_BANCARIA = :OD009-SEQ-CONTA-BANCARIA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_PESSOA 
							,
											A.DTH_CADASTRAMENTO 
							,
											A.NUM_DV_PESSOA 
							,
											A.IND_PESSOA 
							,
											A.STA_INF_INTEGRA 
							,
											B.SEQ_CONTA_BANCARIA 
							,
											B.DTH_CADASTRAMENTO 
							,
											B.STA_CONTA 
							,
											B.COD_BANCO 
							,
											B.COD_AGENCIA 
							,
											B.IND_CONTA_BANCARIA 
							,
											B.NUM_CONTA 
							,
											B.NUM_DV_CONTA 
							,
											B.NUM_OPERACAO_CONTA
											FROM ODS.OD_PESSOA A
							,
											ODS.OD_PESS_CONTA_BANC B
											WHERE A.NUM_PESSOA = '{this.OD001_NUM_PESSOA}'
											AND B.NUM_PESSOA = A.NUM_PESSOA
											AND B.SEQ_CONTA_BANCARIA = '{this.OD009_SEQ_CONTA_BANCARIA}'
											WITH UR";

            return query;
        }
        public string OD001_NUM_PESSOA { get; set; }
        public string OD001_DTH_CADASTRAMENTO { get; set; }
        public string OD001_NUM_DV_PESSOA { get; set; }
        public string OD001_IND_PESSOA { get; set; }
        public string OD001_STA_INF_INTEGRA { get; set; }
        public string OD009_SEQ_CONTA_BANCARIA { get; set; }
        public string OD009_DTH_CADASTRAMENTO { get; set; }
        public string OD009_STA_CONTA { get; set; }
        public string OD009_COD_BANCO { get; set; }
        public string OD009_COD_AGENCIA { get; set; }
        public string OD009_IND_CONTA_BANCARIA { get; set; }
        public string OD009_NUM_CONTA { get; set; }
        public string OD009_NUM_DV_CONTA { get; set; }
        public string VIND_NULL01 { get; set; }
        public string OD009_NUM_OPERACAO_CONTA { get; set; }
        public string VIND_NULL02 { get; set; }

        public static R200_CONSULTA_BANCO_DB_SELECT_1_Query1 Execute(R200_CONSULTA_BANCO_DB_SELECT_1_Query1 r200_CONSULTA_BANCO_DB_SELECT_1_Query1)
        {
            var ths = r200_CONSULTA_BANCO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R200_CONSULTA_BANCO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R200_CONSULTA_BANCO_DB_SELECT_1_Query1();
            var i = 0;
            dta.OD001_NUM_PESSOA = result[i++].Value?.ToString();
            dta.OD001_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.OD001_NUM_DV_PESSOA = result[i++].Value?.ToString();
            dta.OD001_IND_PESSOA = result[i++].Value?.ToString();
            dta.OD001_STA_INF_INTEGRA = result[i++].Value?.ToString();
            dta.OD009_SEQ_CONTA_BANCARIA = result[i++].Value?.ToString();
            dta.OD009_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.OD009_STA_CONTA = result[i++].Value?.ToString();
            dta.OD009_COD_BANCO = result[i++].Value?.ToString();
            dta.OD009_COD_AGENCIA = result[i++].Value?.ToString();
            dta.OD009_IND_CONTA_BANCARIA = result[i++].Value?.ToString();
            dta.OD009_NUM_CONTA = result[i++].Value?.ToString();
            dta.OD009_NUM_DV_CONTA = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.OD009_NUM_DV_CONTA) ? "-1" : "0";
            dta.OD009_NUM_OPERACAO_CONTA = result[i++].Value?.ToString();
            dta.VIND_NULL02 = string.IsNullOrWhiteSpace(dta.OD009_NUM_OPERACAO_CONTA) ? "-1" : "0";
            return dta;
        }

    }
}