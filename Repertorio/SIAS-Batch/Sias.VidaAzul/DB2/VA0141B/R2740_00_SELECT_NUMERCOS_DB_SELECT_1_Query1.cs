using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0141B
{
    public class R2740_00_SELECT_NUMERCOS_DB_SELECT_1_Query1 : QueryBasis<R2740_00_SELECT_NUMERCOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SEQ_ORD_CEDIDO
            INTO :NUMERCOS-SEQ-ORD-CEDIDO
            FROM SEGUROS.NUMERO_COSSEGURO
            WHERE ORGAO_EMISSOR = :NUMERAES-ORGAO-EMISSOR
            AND COD_CONGENERE = :APOLCOSS-COD-COSSEGURADORA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SEQ_ORD_CEDIDO
											FROM SEGUROS.NUMERO_COSSEGURO
											WHERE ORGAO_EMISSOR = '{this.NUMERAES_ORGAO_EMISSOR}'
											AND COD_CONGENERE = '{this.APOLCOSS_COD_COSSEGURADORA}'
											WITH UR";

            return query;
        }
        public string NUMERCOS_SEQ_ORD_CEDIDO { get; set; }
        public string APOLCOSS_COD_COSSEGURADORA { get; set; }
        public string NUMERAES_ORGAO_EMISSOR { get; set; }

        public static R2740_00_SELECT_NUMERCOS_DB_SELECT_1_Query1 Execute(R2740_00_SELECT_NUMERCOS_DB_SELECT_1_Query1 r2740_00_SELECT_NUMERCOS_DB_SELECT_1_Query1)
        {
            var ths = r2740_00_SELECT_NUMERCOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2740_00_SELECT_NUMERCOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2740_00_SELECT_NUMERCOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUMERCOS_SEQ_ORD_CEDIDO = result[i++].Value?.ToString();
            return dta;
        }

    }
}