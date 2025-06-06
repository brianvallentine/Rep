using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0930B
{
    public class R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1 : QueryBasis<R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_VENCIMENTO
            , PRM_TOTAL
            , COD_AGENCIA_DEBITO
            , OPE_CONTA_DEBITO
            , NUM_CONTA_DEBITO
            , DIG_CONTA_DEBITO
            , SIT_REGISTRO
            INTO :HISLANCT-DATA-VENCIMENTO
            , :HISLANCT-PRM-TOTAL
            , :HISLANCT-COD-AGENCIA-DEBITO
            , :HISLANCT-OPE-CONTA-DEBITO
            , :HISLANCT-NUM-CONTA-DEBITO
            , :HISLANCT-DIG-CONTA-DEBITO
            , :HISLANCT-SIT-REGISTRO
            FROM SEGUROS.HIST_LANC_CTA
            WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            AND NUM_PARCELA = :RELATORI-NUM-PARCELA
            AND TIPLANC IN ( '2' , '3' )
            AND CODCONV = 6090
            ORDER BY OCORR_HISTORICOCTA DESC
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATA_VENCIMENTO
											, PRM_TOTAL
											, COD_AGENCIA_DEBITO
											, OPE_CONTA_DEBITO
											, NUM_CONTA_DEBITO
											, DIG_CONTA_DEBITO
											, SIT_REGISTRO
											FROM SEGUROS.HIST_LANC_CTA
											WHERE NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.RELATORI_NUM_PARCELA}'
											AND TIPLANC IN ( '2' 
							, '3' )
											AND CODCONV = 6090
											ORDER BY OCORR_HISTORICOCTA DESC
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string HISLANCT_DATA_VENCIMENTO { get; set; }
        public string HISLANCT_PRM_TOTAL { get; set; }
        public string HISLANCT_COD_AGENCIA_DEBITO { get; set; }
        public string HISLANCT_OPE_CONTA_DEBITO { get; set; }
        public string HISLANCT_NUM_CONTA_DEBITO { get; set; }
        public string HISLANCT_DIG_CONTA_DEBITO { get; set; }
        public string HISLANCT_SIT_REGISTRO { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }

        public static R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1 Execute(R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1 r1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1)
        {
            var ths = r1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISLANCT_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.HISLANCT_PRM_TOTAL = result[i++].Value?.ToString();
            dta.HISLANCT_COD_AGENCIA_DEBITO = result[i++].Value?.ToString();
            dta.HISLANCT_OPE_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.HISLANCT_NUM_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.HISLANCT_DIG_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.HISLANCT_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}