using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8024B
{
    public class R0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1_Query1 : QueryBasis<R0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_OCORR_MOVTO
            , SEQ_CONTROL_CARTAO
            , COD_TP_PAGAMENTO
            , NUM_PARCELA
            INTO :GE407-NUM-OCORR-MOVTO
            , :GE407-SEQ-CONTROL-CARTAO
            , :GE407-COD-TP-PAGAMENTO
            , :GE407-NUM-PARCELA
            FROM SEGUROS.GE_CONTROLE_CARTAO_CIELO
            WHERE NUM_CERTIFICADO = :GE407-NUM-CERTIFICADO
            AND COD_IDLG = :GE407-COD-IDLG
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_OCORR_MOVTO
											, SEQ_CONTROL_CARTAO
											, COD_TP_PAGAMENTO
											, NUM_PARCELA
											FROM SEGUROS.GE_CONTROLE_CARTAO_CIELO
											WHERE NUM_CERTIFICADO = '{this.GE407_NUM_CERTIFICADO}'
											AND COD_IDLG = '{this.GE407_COD_IDLG}'
											WITH UR";

            return query;
        }
        public string GE407_NUM_OCORR_MOVTO { get; set; }
        public string GE407_SEQ_CONTROL_CARTAO { get; set; }
        public string GE407_COD_TP_PAGAMENTO { get; set; }
        public string GE407_NUM_PARCELA { get; set; }
        public string GE407_NUM_CERTIFICADO { get; set; }
        public string GE407_COD_IDLG { get; set; }

        public static R0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1_Query1 Execute(R0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1_Query1 r0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1_Query1)
        {
            var ths = r0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE407_NUM_OCORR_MOVTO = result[i++].Value?.ToString();
            dta.GE407_SEQ_CONTROL_CARTAO = result[i++].Value?.ToString();
            dta.GE407_COD_TP_PAGAMENTO = result[i++].Value?.ToString();
            dta.GE407_NUM_PARCELA = result[i++].Value?.ToString();
            return dta;
        }

    }
}