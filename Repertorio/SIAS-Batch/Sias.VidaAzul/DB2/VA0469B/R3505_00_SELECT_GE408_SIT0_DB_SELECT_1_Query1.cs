using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class R3505_00_SELECT_GE408_SIT0_DB_SELECT_1_Query1 : QueryBasis<R3505_00_SELECT_GE408_SIT0_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT T2.NUM_CERTIFICADO,
            T1.VLR_TOT_PREMIO
            INTO :GE408-NUM-CERTIFICADO,
            :GE408-VLR-COBRANCA
            FROM SEGUROS.GE_CONTROLE_CARTAO_CIELO T1
            , SEGUROS.GE_RETORNO_CA_CIELO T2
            , SEGUROS.PARCELAS_VIDAZUL T3
            WHERE T1.NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            AND T1.NUM_PARCELA = :RELATORI-NUM-PARCELA
            AND T1.COD_TP_PAGAMENTO IN ( '01' , '02' )
            AND T1.NUM_PROPOSTA = T2.NUM_PROPOSTA
            AND T1.NUM_CERTIFICADO = T2.NUM_CERTIFICADO
            AND T1.NUM_PARCELA = T2.NUM_PARCELA
            AND T1.SEQ_CONTROL_CARTAO = T2.SEQ_CONTROL_CARTAO
            AND T2.COD_MOVIMENTO = '03'
            AND T2.COD_RETORNO = ' CC'
            AND T1.NUM_CERTIFICADO = T3.NUM_CERTIFICADO
            AND T1.NUM_PARCELA = T3.NUM_PARCELA
            AND T3.SIT_REGISTRO IN ( ' ' , '0' , '1' , '2' )
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT T2.NUM_CERTIFICADO
							,
											T1.VLR_TOT_PREMIO
											FROM SEGUROS.GE_CONTROLE_CARTAO_CIELO T1
											, SEGUROS.GE_RETORNO_CA_CIELO T2
											, SEGUROS.PARCELAS_VIDAZUL T3
											WHERE T1.NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'
											AND T1.NUM_PARCELA = '{this.RELATORI_NUM_PARCELA}'
											AND T1.COD_TP_PAGAMENTO IN ( '01' 
							, '02' )
											AND T1.NUM_PROPOSTA = T2.NUM_PROPOSTA
											AND T1.NUM_CERTIFICADO = T2.NUM_CERTIFICADO
											AND T1.NUM_PARCELA = T2.NUM_PARCELA
											AND T1.SEQ_CONTROL_CARTAO = T2.SEQ_CONTROL_CARTAO
											AND T2.COD_MOVIMENTO = '03'
											AND T2.COD_RETORNO = ' CC'
											AND T1.NUM_CERTIFICADO = T3.NUM_CERTIFICADO
											AND T1.NUM_PARCELA = T3.NUM_PARCELA
											AND T3.SIT_REGISTRO IN ( ' ' 
							, '0' 
							, '1' 
							, '2' )
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string GE408_NUM_CERTIFICADO { get; set; }
        public string GE408_VLR_COBRANCA { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }

        public static R3505_00_SELECT_GE408_SIT0_DB_SELECT_1_Query1 Execute(R3505_00_SELECT_GE408_SIT0_DB_SELECT_1_Query1 r3505_00_SELECT_GE408_SIT0_DB_SELECT_1_Query1)
        {
            var ths = r3505_00_SELECT_GE408_SIT0_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3505_00_SELECT_GE408_SIT0_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3505_00_SELECT_GE408_SIT0_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE408_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.GE408_VLR_COBRANCA = result[i++].Value?.ToString();
            return dta;
        }

    }
}