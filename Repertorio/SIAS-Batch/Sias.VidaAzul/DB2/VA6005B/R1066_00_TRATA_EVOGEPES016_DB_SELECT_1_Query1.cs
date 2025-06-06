using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA6005B
{
    public class R1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1 : QueryBasis<R1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALOR_COMISSAO_PRD ,
            PERCEN_COMIS_FUNC
            INTO :PARAMPRO-VALOR-COMISSAO-PRD ,
            :PARAMPRO-PERCEN-COMIS-FUNC
            FROM SEGUROS.PARAM_PRODUTO
            WHERE COD_PRODUTO = :V0ENDO-CODPRODU
            AND TIPO_FUNCIONARIO = '1'
            AND DATA_INIVIGENCIA <= :V0ENDO-DTINIVIG
            AND DATA_TERVIGENCIA >= :V0ENDO-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALOR_COMISSAO_PRD 
							,
											PERCEN_COMIS_FUNC
											FROM SEGUROS.PARAM_PRODUTO
											WHERE COD_PRODUTO = '{this.V0ENDO_CODPRODU}'
											AND TIPO_FUNCIONARIO = '1'
											AND DATA_INIVIGENCIA <= '{this.V0ENDO_DTINIVIG}'
											AND DATA_TERVIGENCIA >= '{this.V0ENDO_DTINIVIG}'";

            return query;
        }
        public string PARAMPRO_VALOR_COMISSAO_PRD { get; set; }
        public string PARAMPRO_PERCEN_COMIS_FUNC { get; set; }
        public string V0ENDO_CODPRODU { get; set; }
        public string V0ENDO_DTINIVIG { get; set; }

        public static R1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1 Execute(R1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1 r1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1)
        {
            var ths = r1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1066_00_TRATA_EVOGEPES016_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARAMPRO_VALOR_COMISSAO_PRD = result[i++].Value?.ToString();
            dta.PARAMPRO_PERCEN_COMIS_FUNC = result[i++].Value?.ToString();
            return dta;
        }

    }
}