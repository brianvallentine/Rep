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
    public class B2025_TRATA_2PCELA_CCA_DB_SELECT_1_Query1 : QueryBasis<B2025_TRATA_2PCELA_CCA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PARAM_DATE03
            INTO :LTSOLPAR-PARAM-DATE03
            FROM SEGUROS.LT_SOLICITA_PARAM
            WHERE COD_PROGRAMA = 'SPBLTPRM'
            AND COD_PRODUTO = :LTSOLPAR-COD-PRODUTO
            AND PARAM_SMINT01 = 74
            AND :LTMVPROP-DT-INIVIG-PROPOSTA
            BETWEEN PARAM_DATE01 AND PARAM_DATE02
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT PARAM_DATE03
											FROM SEGUROS.LT_SOLICITA_PARAM
											WHERE COD_PROGRAMA = 'SPBLTPRM'
											AND COD_PRODUTO = '{this.LTSOLPAR_COD_PRODUTO}'
											AND PARAM_SMINT01 = 74
											AND '{this.LTMVPROP_DT_INIVIG_PROPOSTA}'
											BETWEEN PARAM_DATE01 AND PARAM_DATE02
											WITH UR";

            return query;
        }
        public string LTSOLPAR_PARAM_DATE03 { get; set; }
        public string LTMVPROP_DT_INIVIG_PROPOSTA { get; set; }
        public string LTSOLPAR_COD_PRODUTO { get; set; }

        public static B2025_TRATA_2PCELA_CCA_DB_SELECT_1_Query1 Execute(B2025_TRATA_2PCELA_CCA_DB_SELECT_1_Query1 b2025_TRATA_2PCELA_CCA_DB_SELECT_1_Query1)
        {
            var ths = b2025_TRATA_2PCELA_CCA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B2025_TRATA_2PCELA_CCA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B2025_TRATA_2PCELA_CCA_DB_SELECT_1_Query1();
            var i = 0;
            dta.LTSOLPAR_PARAM_DATE03 = result[i++].Value?.ToString();
            return dta;
        }

    }
}