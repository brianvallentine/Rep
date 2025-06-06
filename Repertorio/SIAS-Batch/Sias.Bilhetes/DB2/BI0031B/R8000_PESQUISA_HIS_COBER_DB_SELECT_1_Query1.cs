using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0031B
{
    public class R8000_PESQUISA_HIS_COBER_DB_SELECT_1_Query1 : QueryBasis<R8000_PESQUISA_HIS_COBER_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(A.COD_PRODUTO,0)
            ,VALUE(A.SEQ_PRODUTO_VRS,0)
            INTO :HISCOBPR-COD-PRODUTO
            ,:HISCOBPR-SEQ-PRODUTO-VRS
            FROM SEGUROS.HIS_COBER_PROPOST A
            WHERE A.NUM_CERTIFICADO = :HISCOBPR-NUM-CERTIFICADO
            AND A.OCORR_HISTORICO =
            ( SELECT MAX(VW1.OCORR_HISTORICO)
            FROM SEGUROS.HIS_COBER_PROPOST VW1
            WHERE VW1.NUM_CERTIFICADO
            = A.NUM_CERTIFICADO )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(A.COD_PRODUTO
							,0)
											,VALUE(A.SEQ_PRODUTO_VRS
							,0)
											FROM SEGUROS.HIS_COBER_PROPOST A
											WHERE A.NUM_CERTIFICADO = '{this.HISCOBPR_NUM_CERTIFICADO}'
											AND A.OCORR_HISTORICO =
											( SELECT MAX(VW1.OCORR_HISTORICO)
											FROM SEGUROS.HIS_COBER_PROPOST VW1
											WHERE VW1.NUM_CERTIFICADO
											= A.NUM_CERTIFICADO )";

            return query;
        }
        public string HISCOBPR_COD_PRODUTO { get; set; }
        public string HISCOBPR_SEQ_PRODUTO_VRS { get; set; }
        public string HISCOBPR_NUM_CERTIFICADO { get; set; }

        public static R8000_PESQUISA_HIS_COBER_DB_SELECT_1_Query1 Execute(R8000_PESQUISA_HIS_COBER_DB_SELECT_1_Query1 r8000_PESQUISA_HIS_COBER_DB_SELECT_1_Query1)
        {
            var ths = r8000_PESQUISA_HIS_COBER_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8000_PESQUISA_HIS_COBER_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8000_PESQUISA_HIS_COBER_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCOBPR_COD_PRODUTO = result[i++].Value?.ToString();
            dta.HISCOBPR_SEQ_PRODUTO_VRS = result[i++].Value?.ToString();
            return dta;
        }

    }
}