using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0805B
{
    public class M_2000_CONSISTE_RET_LANCAMENTO_DB_SELECT_1_Query1 : QueryBasis<M_2000_CONSISTE_RET_LANCAMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.CODPRODAZ
            INTO :V0PROD-CODPRODAZ
            FROM SEGUROS.V0SEGURAVG A,
            SEGUROS.V0PRODUTOSVG B
            WHERE A.NUM_CERTIFICADO = :WHOST-ACESSO
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.CODSUBES = A.COD_SUBGRUPO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT B.CODPRODAZ
											FROM SEGUROS.V0SEGURAVG A
							,
											SEGUROS.V0PRODUTOSVG B
											WHERE A.NUM_CERTIFICADO = '{this.WHOST_ACESSO}'
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.CODSUBES = A.COD_SUBGRUPO
											WITH UR";

            return query;
        }
        public string V0PROD_CODPRODAZ { get; set; }
        public string WHOST_ACESSO { get; set; }

        public static M_2000_CONSISTE_RET_LANCAMENTO_DB_SELECT_1_Query1 Execute(M_2000_CONSISTE_RET_LANCAMENTO_DB_SELECT_1_Query1 m_2000_CONSISTE_RET_LANCAMENTO_DB_SELECT_1_Query1)
        {
            var ths = m_2000_CONSISTE_RET_LANCAMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_2000_CONSISTE_RET_LANCAMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_2000_CONSISTE_RET_LANCAMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PROD_CODPRODAZ = result[i++].Value?.ToString();
            return dta;
        }

    }
}