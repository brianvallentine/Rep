using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0437B
{
    public class R1700_00_SELECT_PLANOVID_DB_SELECT_1_Query1 : QueryBasis<R1700_00_SELECT_PLANOVID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PLANO
            INTO :PLANOVID-COD-PLANO
            FROM SEGUROS.PLANOS_VIDAZUL
            WHERE COD_PRODUTO =
            :PROPOVA-COD-PRODUTO
            AND OPCAO_COBERTURA =
            :HISCOBPR-OPCAO-COBERTURA
            AND IDADE_INICIAL <= :PROPOVA-IDADE
            AND IDADE_FINAL >= :PROPOVA-IDADE
            AND DATA_INIVIGENCIA <= CURRENT DATE
            AND DATA_TERVIGENCIA >= CURRENT DATE
            AND PERI_PAGAMENTO = 1
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PLANO
											FROM SEGUROS.PLANOS_VIDAZUL
											WHERE COD_PRODUTO =
											'{this.PROPOVA_COD_PRODUTO}'
											AND OPCAO_COBERTURA =
											'{this.HISCOBPR_OPCAO_COBERTURA}'
											AND IDADE_INICIAL <= '{this.PROPOVA_IDADE}'
											AND IDADE_FINAL >= '{this.PROPOVA_IDADE}'
											AND DATA_INIVIGENCIA <= CURRENT DATE
											AND DATA_TERVIGENCIA >= CURRENT DATE
											AND PERI_PAGAMENTO = 1";

            return query;
        }
        public string PLANOVID_COD_PLANO { get; set; }
        public string HISCOBPR_OPCAO_COBERTURA { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PROPOVA_IDADE { get; set; }

        public static R1700_00_SELECT_PLANOVID_DB_SELECT_1_Query1 Execute(R1700_00_SELECT_PLANOVID_DB_SELECT_1_Query1 r1700_00_SELECT_PLANOVID_DB_SELECT_1_Query1)
        {
            var ths = r1700_00_SELECT_PLANOVID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1700_00_SELECT_PLANOVID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1700_00_SELECT_PLANOVID_DB_SELECT_1_Query1();
            var i = 0;
            dta.PLANOVID_COD_PLANO = result[i++].Value?.ToString();
            return dta;
        }

    }
}