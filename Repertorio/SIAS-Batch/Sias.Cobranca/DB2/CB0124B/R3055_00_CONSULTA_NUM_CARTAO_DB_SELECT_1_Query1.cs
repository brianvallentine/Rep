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
    public class R3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1 : QueryBasis<R3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_CERTIFICADO
            , A.NUM_CARTAO_CREDITO
            , A.OPCAO_PAGAMENTO
            INTO :OPCPAGVI-NUM-CERTIFICADO
            , :OPCPAGVI-NUM-CARTAO-CREDITO:VIND-CCRE
            , :OPCPAGVI-OPCAO-PAGAMENTO
            FROM SEGUROS.OPCAO_PAG_VIDAZUL A
            WHERE A.NUM_CERTIFICADO = :OPCPAGVI-NUM-CERTIFICADO
            AND A.DATA_INIVIGENCIA <= :WS-DATA-GERACAO-PARCELA
            AND A.DATA_TERVIGENCIA >= :WS-DATA-GERACAO-PARCELA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT A.NUM_CERTIFICADO
											, A.NUM_CARTAO_CREDITO
											, A.OPCAO_PAGAMENTO
											FROM SEGUROS.OPCAO_PAG_VIDAZUL A
											WHERE A.NUM_CERTIFICADO = '{this.OPCPAGVI_NUM_CERTIFICADO}'
											AND A.DATA_INIVIGENCIA <= '{this.WS_DATA_GERACAO_PARCELA}'
											AND A.DATA_TERVIGENCIA >= '{this.WS_DATA_GERACAO_PARCELA}'
											WITH UR";

            return query;
        }
        public string OPCPAGVI_NUM_CERTIFICADO { get; set; }
        public string OPCPAGVI_NUM_CARTAO_CREDITO { get; set; }
        public string VIND_CCRE { get; set; }
        public string OPCPAGVI_OPCAO_PAGAMENTO { get; set; }
        public string WS_DATA_GERACAO_PARCELA { get; set; }

        public static R3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1 Execute(R3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1 r3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1)
        {
            var ths = r3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3055_00_CONSULTA_NUM_CARTAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPCPAGVI_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.OPCPAGVI_NUM_CARTAO_CREDITO = result[i++].Value?.ToString();
            dta.VIND_CCRE = string.IsNullOrWhiteSpace(dta.OPCPAGVI_NUM_CARTAO_CREDITO) ? "-1" : "0";
            dta.OPCPAGVI_OPCAO_PAGAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}