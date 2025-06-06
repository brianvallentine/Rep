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
    public class R0465_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1 : QueryBasis<R0465_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT BCO_AVISO ,
            AGE_AVISO ,
            NUM_AVISO_CREDITO ,
            NUM_SEQUENCIA ,
            DATA_MOVIMENTO ,
            TIPO_AVISO ,
            DATA_AVISO ,
            VAL_DESPESA ,
            PRM_LIQUIDO ,
            PRM_TOTAL ,
            ORIGEM_AVISO
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
            :AVISOCRE-ORIGEM-AVISO:VIND-ORIGEM
            FROM SEGUROS.AVISO_CREDITO
            WHERE AGE_AVISO =
            :RCAPCOMP-AGE-AVISO
            AND NUM_AVISO_CREDITO =
            :RCAPCOMP-NUM-AVISO-CREDITO
            AND NUM_SEQUENCIA = 1
            AND BCO_AVISO =
            :RCAPCOMP-BCO-AVISO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT BCO_AVISO 
							,
											AGE_AVISO 
							,
											NUM_AVISO_CREDITO 
							,
											NUM_SEQUENCIA 
							,
											DATA_MOVIMENTO 
							,
											TIPO_AVISO 
							,
											DATA_AVISO 
							,
											VAL_DESPESA 
							,
											PRM_LIQUIDO 
							,
											PRM_TOTAL 
							,
											ORIGEM_AVISO
											FROM SEGUROS.AVISO_CREDITO
											WHERE AGE_AVISO =
											'{this.RCAPCOMP_AGE_AVISO}'
											AND NUM_AVISO_CREDITO =
											'{this.RCAPCOMP_NUM_AVISO_CREDITO}'
											AND NUM_SEQUENCIA = 1
											AND BCO_AVISO =
											'{this.RCAPCOMP_BCO_AVISO}'";

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
        public string RCAPCOMP_NUM_AVISO_CREDITO { get; set; }
        public string RCAPCOMP_AGE_AVISO { get; set; }
        public string RCAPCOMP_BCO_AVISO { get; set; }

        public static R0465_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1 Execute(R0465_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1 r0465_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1)
        {
            var ths = r0465_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0465_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0465_00_SELECT_V0AVISOCRE_DB_SELECT_1_Query1();
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
            return dta;
        }

    }
}