using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0010B
{
    public class R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1 : QueryBasis<R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(COUNT(*),+0)
            INTO :WHOST-QTDE-REG
            FROM SEGUROS.V1COSSEG_HISTPRE A,
            SEGUROS.V0APOLICE B
            WHERE A.DTMOVTO = :V1SIST-DTMOVABE
            AND A.TIPSGU = '1'
            AND A.OPERACAO < 0600
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.TIPSGU = A.TIPSGU
            AND B.ORGAO IN (0010,0300)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(COUNT(*)
							,+0)
											FROM SEGUROS.V1COSSEG_HISTPRE A
							,
											SEGUROS.V0APOLICE B
											WHERE A.DTMOVTO = '{this.V1SIST_DTMOVABE}'
											AND A.TIPSGU = '1'
											AND A.OPERACAO < 0600
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.TIPSGU = A.TIPSGU
											AND B.ORGAO IN (0010
							,0300)";

            return query;
        }
        public string WHOST_QTDE_REG { get; set; }
        public string V1SIST_DTMOVABE { get; set; }

        public static R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1 Execute(R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1 r0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1)
        {
            var ths = r0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_QTDE_REG = result[i++].Value?.ToString();
            return dta;
        }

    }
}