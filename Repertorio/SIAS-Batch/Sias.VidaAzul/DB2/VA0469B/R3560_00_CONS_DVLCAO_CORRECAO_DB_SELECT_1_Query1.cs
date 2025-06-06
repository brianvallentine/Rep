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
    public class R3560_00_CONS_DVLCAO_CORRECAO_DB_SELECT_1_Query1 : QueryBasis<R3560_00_CONS_DVLCAO_CORRECAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WS-QTD-CORRECAO
            FROM SEGUROS.MOVTO_DEBITOCC_CEF
            WHERE NUM_CARTAO = :MOVDEBCE-NUM-CARTAO
            AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA
            AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO
            AND SITUACAO_COBRANCA IN ( ' ' , '0' , '1' , '2' , '5' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.MOVTO_DEBITOCC_CEF
											WHERE NUM_CARTAO = '{this.MOVDEBCE_NUM_CARTAO}'
											AND NUM_PARCELA = '{this.MOVDEBCE_NUM_PARCELA}'
											AND COD_CONVENIO = '{this.MOVDEBCE_COD_CONVENIO}'
											AND SITUACAO_COBRANCA IN ( ' ' 
							, '0' 
							, '1' 
							, '2' 
							, '5' )";

            return query;
        }
        public string WS_QTD_CORRECAO { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }
        public string MOVDEBCE_NUM_CARTAO { get; set; }

        public static R3560_00_CONS_DVLCAO_CORRECAO_DB_SELECT_1_Query1 Execute(R3560_00_CONS_DVLCAO_CORRECAO_DB_SELECT_1_Query1 r3560_00_CONS_DVLCAO_CORRECAO_DB_SELECT_1_Query1)
        {
            var ths = r3560_00_CONS_DVLCAO_CORRECAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3560_00_CONS_DVLCAO_CORRECAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3560_00_CONS_DVLCAO_CORRECAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_QTD_CORRECAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}