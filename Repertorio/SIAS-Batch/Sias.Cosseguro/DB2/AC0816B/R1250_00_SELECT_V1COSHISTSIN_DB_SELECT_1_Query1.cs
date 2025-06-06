using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0816B
{
    public class R1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1 : QueryBasis<R1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(SUM(VAL_OPERACAO),+0)
            INTO :WHOST-VAL-COR-PEND
            FROM SEGUROS.V1COSSEG_HISTSIN
            WHERE CONGENER = :V1CHSI-CONGENER
            AND NUM_SINISTRO = :V1CHSI-NUM-SINI
            AND OCORHIST = :V1CHSI-OCORHIST
            AND OPERACAO = :WHOST-OP-COR-PEND
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(VAL_OPERACAO)
							,+0)
											FROM SEGUROS.V1COSSEG_HISTSIN
											WHERE CONGENER = '{this.V1CHSI_CONGENER}'
											AND NUM_SINISTRO = '{this.V1CHSI_NUM_SINI}'
											AND OCORHIST = '{this.V1CHSI_OCORHIST}'
											AND OPERACAO = '{this.WHOST_OP_COR_PEND}'";

            return query;
        }
        public string WHOST_VAL_COR_PEND { get; set; }
        public string WHOST_OP_COR_PEND { get; set; }
        public string V1CHSI_CONGENER { get; set; }
        public string V1CHSI_NUM_SINI { get; set; }
        public string V1CHSI_OCORHIST { get; set; }

        public static R1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1 Execute(R1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1 r1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1)
        {
            var ths = r1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_VAL_COR_PEND = result[i++].Value?.ToString();
            return dta;
        }

    }
}