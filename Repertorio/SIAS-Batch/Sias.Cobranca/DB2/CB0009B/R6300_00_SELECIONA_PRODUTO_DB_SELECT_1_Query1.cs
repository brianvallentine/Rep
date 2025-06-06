using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class R6300_00_SELECIONA_PRODUTO_DB_SELECT_1_Query1 : QueryBasis<R6300_00_SELECIONA_PRODUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO
            INTO :V0BILP-CODPRODU
            FROM SEGUROS.BILHETE_COBERTURA
            WHERE COD_EMPRESA = 0
            AND RAMO_COBERTURA = :V0BILH-RAMO
            AND MODALI_COBERTURA = 0
            AND COD_OPCAO_PLANO = :V0BILH-OPCOBER
            AND IDE_COBERTURA = '1'
            AND DATA_INIVIGENCIA <= :V0BILH-DTQITBCO
            AND DATA_TERVIGENCIA >= :V0BILH-DTQITBCO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
											FROM SEGUROS.BILHETE_COBERTURA
											WHERE COD_EMPRESA = 0
											AND RAMO_COBERTURA = '{this.V0BILH_RAMO}'
											AND MODALI_COBERTURA = 0
											AND COD_OPCAO_PLANO = '{this.V0BILH_OPCOBER}'
											AND IDE_COBERTURA = '1'
											AND DATA_INIVIGENCIA <= '{this.V0BILH_DTQITBCO}'
											AND DATA_TERVIGENCIA >= '{this.V0BILH_DTQITBCO}'";

            return query;
        }
        public string V0BILP_CODPRODU { get; set; }
        public string V0BILH_DTQITBCO { get; set; }
        public string V0BILH_OPCOBER { get; set; }
        public string V0BILH_RAMO { get; set; }

        public static R6300_00_SELECIONA_PRODUTO_DB_SELECT_1_Query1 Execute(R6300_00_SELECIONA_PRODUTO_DB_SELECT_1_Query1 r6300_00_SELECIONA_PRODUTO_DB_SELECT_1_Query1)
        {
            var ths = r6300_00_SELECIONA_PRODUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6300_00_SELECIONA_PRODUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6300_00_SELECIONA_PRODUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0BILP_CODPRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}