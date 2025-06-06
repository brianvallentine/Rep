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
    public class B4055_00_VALIDA_TITULO_CAP_DB_SELECT_1_Query1 : QueryBasis<B4055_00_VALIDA_TITULO_CAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PARAM_DATE03
            INTO :LTSOLPAR-PARAM-DATE03
            FROM SEGUROS.LT_SOLICITA_PARAM
            WHERE COD_PROGRAMA = :LTSOLPAR-COD-PROGRAMA
            AND SIT_SOLICITACAO = '0'
            AND PARAM_SMINT01 = :LTSOLPAR-PARAM-SMINT01
            AND :LTSOLPAR-PARAM-DATE01 BETWEEN PARAM_DATE01
            AND PARAM_DATE02
            AND COD_PRODUTO = :LTSOLPAR-COD-PRODUTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PARAM_DATE03
											FROM SEGUROS.LT_SOLICITA_PARAM
											WHERE COD_PROGRAMA = '{this.LTSOLPAR_COD_PROGRAMA}'
											AND SIT_SOLICITACAO = '0'
											AND PARAM_SMINT01 = '{this.LTSOLPAR_PARAM_SMINT01}'
											AND '{this.LTSOLPAR_PARAM_DATE01}' BETWEEN PARAM_DATE01
											AND PARAM_DATE02
											AND COD_PRODUTO = '{this.LTSOLPAR_COD_PRODUTO}'";

            return query;
        }
        public string LTSOLPAR_PARAM_DATE03 { get; set; }
        public string LTSOLPAR_PARAM_SMINT01 { get; set; }
        public string LTSOLPAR_COD_PROGRAMA { get; set; }
        public string LTSOLPAR_PARAM_DATE01 { get; set; }
        public string LTSOLPAR_COD_PRODUTO { get; set; }

        public static B4055_00_VALIDA_TITULO_CAP_DB_SELECT_1_Query1 Execute(B4055_00_VALIDA_TITULO_CAP_DB_SELECT_1_Query1 b4055_00_VALIDA_TITULO_CAP_DB_SELECT_1_Query1)
        {
            var ths = b4055_00_VALIDA_TITULO_CAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B4055_00_VALIDA_TITULO_CAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B4055_00_VALIDA_TITULO_CAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.LTSOLPAR_PARAM_DATE03 = result[i++].Value?.ToString();
            return dta;
        }

    }
}