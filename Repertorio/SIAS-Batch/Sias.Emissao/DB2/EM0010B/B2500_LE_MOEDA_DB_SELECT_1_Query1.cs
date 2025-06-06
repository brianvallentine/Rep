using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class B2500_LE_MOEDA_DB_SELECT_1_Query1 : QueryBasis<B2500_LE_MOEDA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VLCRUZAD
            INTO :MOED-VALOR
            FROM SEGUROS.V1MOEDA
            WHERE CODUNIMO = :ENDO-COD-MOEDA-PRM
            AND DTINIVIG <= :WHOST-DTINIVIG
            AND DTTERVIG >= :WHOST-DTINIVIG
            AND SITUACAO = '0'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VLCRUZAD
											FROM SEGUROS.V1MOEDA
											WHERE CODUNIMO = '{this.ENDO_COD_MOEDA_PRM}'
											AND DTINIVIG <= '{this.WHOST_DTINIVIG}'
											AND DTTERVIG >= '{this.WHOST_DTINIVIG}'
											AND SITUACAO = '0'
											WITH UR";

            return query;
        }
        public string MOED_VALOR { get; set; }
        public string ENDO_COD_MOEDA_PRM { get; set; }
        public string WHOST_DTINIVIG { get; set; }

        public static B2500_LE_MOEDA_DB_SELECT_1_Query1 Execute(B2500_LE_MOEDA_DB_SELECT_1_Query1 b2500_LE_MOEDA_DB_SELECT_1_Query1)
        {
            var ths = b2500_LE_MOEDA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B2500_LE_MOEDA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B2500_LE_MOEDA_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOED_VALOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}