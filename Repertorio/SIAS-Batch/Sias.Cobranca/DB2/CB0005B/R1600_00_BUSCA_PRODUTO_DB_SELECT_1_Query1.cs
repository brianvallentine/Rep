using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0005B
{
    public class R1600_00_BUSCA_PRODUTO_DB_SELECT_1_Query1 : QueryBasis<R1600_00_BUSCA_PRODUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO
            INTO :V1BILP-CODPRODU
            FROM SEGUROS.BILHETE_COBERTURA
            WHERE RAMO_COBERTURA = :V0BILH-RAMO
            AND COD_OPCAO_PLANO = :V0BILH-OPCAO-COBER
            AND DATA_INIVIGENCIA <= :V0BILH-DTQITBCO
            AND DATA_TERVIGENCIA >= :V0BILH-DTQITBCO
            AND IDE_COBERTURA = '1'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
											FROM SEGUROS.BILHETE_COBERTURA
											WHERE RAMO_COBERTURA = '{this.V0BILH_RAMO}'
											AND COD_OPCAO_PLANO = '{this.V0BILH_OPCAO_COBER}'
											AND DATA_INIVIGENCIA <= '{this.V0BILH_DTQITBCO}'
											AND DATA_TERVIGENCIA >= '{this.V0BILH_DTQITBCO}'
											AND IDE_COBERTURA = '1'
											WITH UR";

            return query;
        }
        public string V1BILP_CODPRODU { get; set; }
        public string V0BILH_OPCAO_COBER { get; set; }
        public string V0BILH_DTQITBCO { get; set; }
        public string V0BILH_RAMO { get; set; }

        public static R1600_00_BUSCA_PRODUTO_DB_SELECT_1_Query1 Execute(R1600_00_BUSCA_PRODUTO_DB_SELECT_1_Query1 r1600_00_BUSCA_PRODUTO_DB_SELECT_1_Query1)
        {
            var ths = r1600_00_BUSCA_PRODUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1600_00_BUSCA_PRODUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1600_00_BUSCA_PRODUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1BILP_CODPRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}