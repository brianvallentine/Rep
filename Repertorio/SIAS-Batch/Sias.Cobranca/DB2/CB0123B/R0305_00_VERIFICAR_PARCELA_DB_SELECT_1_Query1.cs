using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0123B
{
    public class R0305_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1 : QueryBasis<R0305_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_CERTIFICADO
            , A.NUM_PARCELA
            , A.OCORR_HISTORICOCTA
            , A.SIT_REGISTRO
            , DATE(C.TIMESTAMP)
            , B.SIT_REGISTRO
            INTO :HISLANCT-NUM-CERTIFICADO
            , :HISLANCT-NUM-PARCELA
            , :HISLANCT-OCORR-HISTORICOCTA
            , :HISLANCT-SIT-REGISTRO
            , :WS-DATA-GERACAO-PARCELA
            , :PROPOVA-SIT-REGISTRO
            FROM SEGUROS.HIST_LANC_CTA A
            , SEGUROS.PROPOSTAS_VA B
            , SEGUROS.PARCELAS_VIDAZUL C
            WHERE A.NUM_CERTIFICADO = :HISLANCT-NUM-CERTIFICADO
            AND A.NUM_PARCELA = :HISLANCT-NUM-PARCELA
            AND A.SIT_REGISTRO IN ( '2' , '3' )
            AND A.TIPLANC = '1'
            AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO
            AND A.NUM_CERTIFICADO = C.NUM_CERTIFICADO
            AND A.NUM_PARCELA = C.NUM_PARCELA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT A.NUM_CERTIFICADO
											, A.NUM_PARCELA
											, A.OCORR_HISTORICOCTA
											, A.SIT_REGISTRO
											, DATE(C.TIMESTAMP)
											, B.SIT_REGISTRO
											FROM SEGUROS.HIST_LANC_CTA A
											, SEGUROS.PROPOSTAS_VA B
											, SEGUROS.PARCELAS_VIDAZUL C
											WHERE A.NUM_CERTIFICADO = '{this.HISLANCT_NUM_CERTIFICADO}'
											AND A.NUM_PARCELA = '{this.HISLANCT_NUM_PARCELA}'
											AND A.SIT_REGISTRO IN ( '2' 
							, '3' )
											AND A.TIPLANC = '1'
											AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO
											AND A.NUM_CERTIFICADO = C.NUM_CERTIFICADO
											AND A.NUM_PARCELA = C.NUM_PARCELA
											WITH UR";

            return query;
        }
        public string HISLANCT_NUM_CERTIFICADO { get; set; }
        public string HISLANCT_NUM_PARCELA { get; set; }
        public string HISLANCT_OCORR_HISTORICOCTA { get; set; }
        public string HISLANCT_SIT_REGISTRO { get; set; }
        public string WS_DATA_GERACAO_PARCELA { get; set; }
        public string PROPOVA_SIT_REGISTRO { get; set; }

        public static R0305_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1 Execute(R0305_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1 r0305_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r0305_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0305_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0305_00_VERIFICAR_PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISLANCT_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.HISLANCT_NUM_PARCELA = result[i++].Value?.ToString();
            dta.HISLANCT_OCORR_HISTORICOCTA = result[i++].Value?.ToString();
            dta.HISLANCT_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.WS_DATA_GERACAO_PARCELA = result[i++].Value?.ToString();
            dta.PROPOVA_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}