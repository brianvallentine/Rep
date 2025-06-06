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
    public class B2081_SELECT_V0PREMIO_HAB_DB_SELECT_1_Query1 : QueryBasis<B2081_SELECT_V0PREMIO_HAB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VALUE(SUM(R.VAL_IOF_ATRASO),0) +
            VALUE(SUM(R.VAL_CORR_IOF_TOT),0)
            INTO :V0PRHA-VAL-IOF-TOTAL
            FROM SEGUROS.V0RESUMO_HABIT R,
            SEGUROS.V0CONTRO_REL_HABIT C
            WHERE
            R.COD_PRODUTO = :ENDO-CODPRODU
            AND R.COD_CLIENTE = :V0PRHA-CODCLIEN
            AND R.COD_ITEM = '3'
            AND C.COD_PRODUTO = :ENDO-CODPRODU
            AND C.COD_CLIENTE = :V0PRHA-CODCLIEN
            AND C.NUM_DOC = :ENDO-NRENDOS
            AND C.DATA_MOVIMENTO = R.DATA_MOVIMENTO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(R.VAL_IOF_ATRASO)
							,0) +
											VALUE(SUM(R.VAL_CORR_IOF_TOT)
							,0)
											FROM SEGUROS.V0RESUMO_HABIT R
							,
											SEGUROS.V0CONTRO_REL_HABIT C
											WHERE
											R.COD_PRODUTO = '{this.ENDO_CODPRODU}'
											AND R.COD_CLIENTE = '{this.V0PRHA_CODCLIEN}'
											AND R.COD_ITEM = '3'
											AND C.COD_PRODUTO = '{this.ENDO_CODPRODU}'
											AND C.COD_CLIENTE = '{this.V0PRHA_CODCLIEN}'
											AND C.NUM_DOC = '{this.ENDO_NRENDOS}'
											AND C.DATA_MOVIMENTO = R.DATA_MOVIMENTO
											WITH UR";

            return query;
        }
        public string V0PRHA_VAL_IOF_TOTAL { get; set; }
        public string V0PRHA_CODCLIEN { get; set; }
        public string ENDO_CODPRODU { get; set; }
        public string ENDO_NRENDOS { get; set; }

        public static B2081_SELECT_V0PREMIO_HAB_DB_SELECT_1_Query1 Execute(B2081_SELECT_V0PREMIO_HAB_DB_SELECT_1_Query1 b2081_SELECT_V0PREMIO_HAB_DB_SELECT_1_Query1)
        {
            var ths = b2081_SELECT_V0PREMIO_HAB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B2081_SELECT_V0PREMIO_HAB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B2081_SELECT_V0PREMIO_HAB_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PRHA_VAL_IOF_TOTAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}