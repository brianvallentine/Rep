using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0003B
{
    public class R1300_00_SELECT_NUMERCOS_DB_SELECT_1_Query1 : QueryBasis<R1300_00_SELECT_NUMERCOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ORGAO_EMISSOR,
            SEQ_ORD_CEDIDO
            INTO :NUMERCOS-ORGAO-EMISSOR,
            :NUMERCOS-SEQ-ORD-CEDIDO
            FROM SEGUROS.NUMERO_COSSEGURO
            WHERE ORGAO_EMISSOR = :APOLICES-ORGAO-EMISSOR
            AND COD_CONGENERE = :APOLCOSS-COD-COSSEGURADORA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ORGAO_EMISSOR
							,
											SEQ_ORD_CEDIDO
											FROM SEGUROS.NUMERO_COSSEGURO
											WHERE ORGAO_EMISSOR = '{this.APOLICES_ORGAO_EMISSOR}'
											AND COD_CONGENERE = '{this.APOLCOSS_COD_COSSEGURADORA}'";

            return query;
        }
        public string NUMERCOS_ORGAO_EMISSOR { get; set; }
        public string NUMERCOS_SEQ_ORD_CEDIDO { get; set; }
        public string APOLCOSS_COD_COSSEGURADORA { get; set; }
        public string APOLICES_ORGAO_EMISSOR { get; set; }

        public static R1300_00_SELECT_NUMERCOS_DB_SELECT_1_Query1 Execute(R1300_00_SELECT_NUMERCOS_DB_SELECT_1_Query1 r1300_00_SELECT_NUMERCOS_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_SELECT_NUMERCOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_SELECT_NUMERCOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_SELECT_NUMERCOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUMERCOS_ORGAO_EMISSOR = result[i++].Value?.ToString();
            dta.NUMERCOS_SEQ_ORD_CEDIDO = result[i++].Value?.ToString();
            return dta;
        }

    }
}