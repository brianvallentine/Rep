using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2646B
{
    public class R1005_00_SELECT_AGE_EXCLUSIVO_DB_SELECT_1_Query1 : QueryBasis<R1005_00_SELECT_AGE_EXCLUSIVO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_AGENCIA_DEBITO
            INTO :OPCPAGVI-COD-AGENCIA-DEBITO
            FROM SEGUROS.OPCAO_PAG_VIDAZUL A
            WHERE A.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND A.OPCAO_PAGAMENTO = '1'
            AND A.DATA_TERVIGENCIA =
            (SELECT MAX(X.DATA_TERVIGENCIA)
            FROM SEGUROS.OPCAO_PAG_VIDAZUL X
            WHERE X.NUM_CERTIFICADO = A.NUM_CERTIFICADO
            AND X.OPCAO_PAGAMENTO = A.OPCAO_PAGAMENTO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_AGENCIA_DEBITO
											FROM SEGUROS.OPCAO_PAG_VIDAZUL A
											WHERE A.NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND A.OPCAO_PAGAMENTO = '1'
											AND A.DATA_TERVIGENCIA =
											(SELECT MAX(X.DATA_TERVIGENCIA)
											FROM SEGUROS.OPCAO_PAG_VIDAZUL X
											WHERE X.NUM_CERTIFICADO = A.NUM_CERTIFICADO
											AND X.OPCAO_PAGAMENTO = A.OPCAO_PAGAMENTO)";

            return query;
        }
        public string OPCPAGVI_COD_AGENCIA_DEBITO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R1005_00_SELECT_AGE_EXCLUSIVO_DB_SELECT_1_Query1 Execute(R1005_00_SELECT_AGE_EXCLUSIVO_DB_SELECT_1_Query1 r1005_00_SELECT_AGE_EXCLUSIVO_DB_SELECT_1_Query1)
        {
            var ths = r1005_00_SELECT_AGE_EXCLUSIVO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1005_00_SELECT_AGE_EXCLUSIVO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1005_00_SELECT_AGE_EXCLUSIVO_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPCPAGVI_COD_AGENCIA_DEBITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}