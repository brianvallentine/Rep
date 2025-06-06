using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8006B
{
    public class R5610_INSERT_CNTRLE_SIGCB_DB_SELECT_1_Query1 : QueryBasis<R5610_INSERT_CNTRLE_SIGCB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.COD_PRODUTO
            INTO :WS-COD-PRODUTO
            FROM SEGUROS.PROPOSTA_AUTO A
            ,SEGUROS.PROPOSTAS B
            WHERE A.NUM_PROPOSTA_CONV = :GE403-NUM-PROPOSTA
            AND A.SIT_REGISTRO = ' '
            AND B.COD_FONTE = A.COD_FONTE
            AND B.NUM_PROPOSTA = A.NUM_PROPOSTA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT B.COD_PRODUTO
											FROM SEGUROS.PROPOSTA_AUTO A
											,SEGUROS.PROPOSTAS B
											WHERE A.NUM_PROPOSTA_CONV = '{this.GE403_NUM_PROPOSTA}'
											AND A.SIT_REGISTRO = ' '
											AND B.COD_FONTE = A.COD_FONTE
											AND B.NUM_PROPOSTA = A.NUM_PROPOSTA
											WITH UR";

            return query;
        }
        public string WS_COD_PRODUTO { get; set; }
        public string GE403_NUM_PROPOSTA { get; set; }

        public static R5610_INSERT_CNTRLE_SIGCB_DB_SELECT_1_Query1 Execute(R5610_INSERT_CNTRLE_SIGCB_DB_SELECT_1_Query1 r5610_INSERT_CNTRLE_SIGCB_DB_SELECT_1_Query1)
        {
            var ths = r5610_INSERT_CNTRLE_SIGCB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5610_INSERT_CNTRLE_SIGCB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5610_INSERT_CNTRLE_SIGCB_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}