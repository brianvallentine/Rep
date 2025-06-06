using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0155B
{
    public class R0460_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1 : QueryBasis<R0460_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.BCO_AVISO ,
            A.AGE_AVISO ,
            A.NUM_AVISO_CREDITO ,
            A.NUM_SEQUENCIA ,
            A.DATA_MOVIMENTO ,
            A.TIPO_AVISO ,
            A.DATA_AVISO ,
            A.VAL_DESPESA ,
            A.PRM_LIQUIDO ,
            A.PRM_TOTAL ,
            A.ORIGEM_AVISO ,
            B.SALDO_ATUAL ,
            B.SIT_REGISTRO
            INTO :AVISOCRE-BCO-AVISO ,
            :AVISOCRE-AGE-AVISO ,
            :AVISOCRE-NUM-AVISO-CREDITO ,
            :AVISOCRE-NUM-SEQUENCIA ,
            :AVISOCRE-DATA-MOVIMENTO ,
            :AVISOCRE-TIPO-AVISO ,
            :AVISOCRE-DATA-AVISO ,
            :AVISOCRE-VAL-DESPESA ,
            :AVISOCRE-PRM-LIQUIDO ,
            :AVISOCRE-PRM-TOTAL ,
            :AVISOCRE-ORIGEM-AVISO:VIND-ORIGEM ,
            :AVISOSAL-SALDO-ATUAL ,
            :AVISOSAL-SIT-REGISTRO
            FROM SEGUROS.AVISO_CREDITO A,
            SEGUROS.AVISOS_SALDOS B
            WHERE B.BCO_AVISO =
            :RCAPCOMP-BCO-AVISO
            AND B.AGE_AVISO =
            :RCAPCOMP-AGE-AVISO
            AND B.NUM_AVISO_CREDITO =
            :RCAPCOMP-NUM-AVISO-CREDITO
            AND A.AGE_AVISO = B.AGE_AVISO
            AND A.NUM_AVISO_CREDITO = B.NUM_AVISO_CREDITO
            AND A.BCO_AVISO = B.BCO_AVISO
            AND A.NUM_SEQUENCIA = 1
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.BCO_AVISO 
							,
											A.AGE_AVISO 
							,
											A.NUM_AVISO_CREDITO 
							,
											A.NUM_SEQUENCIA 
							,
											A.DATA_MOVIMENTO 
							,
											A.TIPO_AVISO 
							,
											A.DATA_AVISO 
							,
											A.VAL_DESPESA 
							,
											A.PRM_LIQUIDO 
							,
											A.PRM_TOTAL 
							,
											A.ORIGEM_AVISO 
							,
											B.SALDO_ATUAL 
							,
											B.SIT_REGISTRO
											FROM SEGUROS.AVISO_CREDITO A
							,
											SEGUROS.AVISOS_SALDOS B
											WHERE B.BCO_AVISO =
											'{this.RCAPCOMP_BCO_AVISO}'
											AND B.AGE_AVISO =
											'{this.RCAPCOMP_AGE_AVISO}'
											AND B.NUM_AVISO_CREDITO =
											'{this.RCAPCOMP_NUM_AVISO_CREDITO}'
											AND A.AGE_AVISO = B.AGE_AVISO
											AND A.NUM_AVISO_CREDITO = B.NUM_AVISO_CREDITO
											AND A.BCO_AVISO = B.BCO_AVISO
											AND A.NUM_SEQUENCIA = 1";

            return query;
        }
        public string AVISOCRE_BCO_AVISO { get; set; }
        public string AVISOCRE_AGE_AVISO { get; set; }
        public string AVISOCRE_NUM_AVISO_CREDITO { get; set; }
        public string AVISOCRE_NUM_SEQUENCIA { get; set; }
        public string AVISOCRE_DATA_MOVIMENTO { get; set; }
        public string AVISOCRE_TIPO_AVISO { get; set; }
        public string AVISOCRE_DATA_AVISO { get; set; }
        public string AVISOCRE_VAL_DESPESA { get; set; }
        public string AVISOCRE_PRM_LIQUIDO { get; set; }
        public string AVISOCRE_PRM_TOTAL { get; set; }
        public string AVISOCRE_ORIGEM_AVISO { get; set; }
        public string VIND_ORIGEM { get; set; }
        public string AVISOSAL_SALDO_ATUAL { get; set; }
        public string AVISOSAL_SIT_REGISTRO { get; set; }
        public string RCAPCOMP_NUM_AVISO_CREDITO { get; set; }
        public string RCAPCOMP_BCO_AVISO { get; set; }
        public string RCAPCOMP_AGE_AVISO { get; set; }

        public static R0460_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1 Execute(R0460_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1 r0460_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1)
        {
            var ths = r0460_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0460_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0460_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1();
            var i = 0;
            dta.AVISOCRE_BCO_AVISO = result[i++].Value?.ToString();
            dta.AVISOCRE_AGE_AVISO = result[i++].Value?.ToString();
            dta.AVISOCRE_NUM_AVISO_CREDITO = result[i++].Value?.ToString();
            dta.AVISOCRE_NUM_SEQUENCIA = result[i++].Value?.ToString();
            dta.AVISOCRE_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.AVISOCRE_TIPO_AVISO = result[i++].Value?.ToString();
            dta.AVISOCRE_DATA_AVISO = result[i++].Value?.ToString();
            dta.AVISOCRE_VAL_DESPESA = result[i++].Value?.ToString();
            dta.AVISOCRE_PRM_LIQUIDO = result[i++].Value?.ToString();
            dta.AVISOCRE_PRM_TOTAL = result[i++].Value?.ToString();
            dta.AVISOCRE_ORIGEM_AVISO = result[i++].Value?.ToString();
            dta.VIND_ORIGEM = string.IsNullOrWhiteSpace(dta.AVISOCRE_ORIGEM_AVISO) ? "-1" : "0";
            dta.AVISOSAL_SALDO_ATUAL = result[i++].Value?.ToString();
            dta.AVISOSAL_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}