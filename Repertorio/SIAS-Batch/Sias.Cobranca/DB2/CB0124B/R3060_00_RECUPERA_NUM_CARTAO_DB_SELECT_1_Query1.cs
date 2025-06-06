using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0124B
{
    public class R3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1 : QueryBasis<R3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT T2.NUM_CARTAO
            INTO :GE408-NUM-CARTAO
            FROM SEGUROS.GE_CONTROLE_CARTAO_CIELO T1
            JOIN SEGUROS.GE_RETORNO_CA_CIELO T2
            ON T1.NUM_CERTIFICADO = T2.NUM_CERTIFICADO
            AND T1.NUM_PARCELA = T2.NUM_PARCELA
            AND T1.SEQ_CONTROL_CARTAO = T2.SEQ_CONTROL_CARTAO
            WHERE T1.NUM_CERTIFICADO = :GE407-NUM-CERTIFICADO
            AND T1.NUM_PARCELA = :GE407-NUM-PARCELA
            AND T1.COD_IDLG = :GE407-COD-IDLG
            ORDER BY T2.SEQ_RET_CONTROL_HIST DESC
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT T2.NUM_CARTAO
											FROM SEGUROS.GE_CONTROLE_CARTAO_CIELO T1
											JOIN SEGUROS.GE_RETORNO_CA_CIELO T2
											ON T1.NUM_CERTIFICADO = T2.NUM_CERTIFICADO
											AND T1.NUM_PARCELA = T2.NUM_PARCELA
											AND T1.SEQ_CONTROL_CARTAO = T2.SEQ_CONTROL_CARTAO
											WHERE T1.NUM_CERTIFICADO = '{this.GE407_NUM_CERTIFICADO}'
											AND T1.NUM_PARCELA = '{this.GE407_NUM_PARCELA}'
											AND T1.COD_IDLG = '{this.GE407_COD_IDLG}'
											ORDER BY T2.SEQ_RET_CONTROL_HIST DESC
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string GE408_NUM_CARTAO { get; set; }
        public string GE407_NUM_CERTIFICADO { get; set; }
        public string GE407_NUM_PARCELA { get; set; }
        public string GE407_COD_IDLG { get; set; }

        public static R3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1 Execute(R3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1 r3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1)
        {
            var ths = r3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3060_00_RECUPERA_NUM_CARTAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE408_NUM_CARTAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}