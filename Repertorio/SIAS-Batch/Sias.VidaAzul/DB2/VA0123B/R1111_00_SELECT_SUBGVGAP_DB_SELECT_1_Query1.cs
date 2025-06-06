using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R1111_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 : QueryBasis<R1111_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(A.COD_SUBGRUPO),0)
            INTO :SUBGVGAP-COD-SUBGRUPO
            FROM SEGUROS.SUBGRUPOS_VGAP A,
            SEGUROS.PRODUTOS_VG B
            WHERE A.NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND A.OPCAO_CONJUGE = :SUBGVGAP-OPCAO-CONJUGE
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.COD_SUBGRUPO = A.COD_SUBGRUPO
            AND B.PERI_PAGAMENTO = :PRODUVG-PERI-PAGAMENTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(A.COD_SUBGRUPO)
							,0)
											FROM SEGUROS.SUBGRUPOS_VGAP A
							,
											SEGUROS.PRODUTOS_VG B
											WHERE A.NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND A.OPCAO_CONJUGE = '{this.SUBGVGAP_OPCAO_CONJUGE}'
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.COD_SUBGRUPO = A.COD_SUBGRUPO
											AND B.PERI_PAGAMENTO = '{this.PRODUVG_PERI_PAGAMENTO}'
											WITH UR";

            return query;
        }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string SUBGVGAP_OPCAO_CONJUGE { get; set; }
        public string PRODUVG_PERI_PAGAMENTO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R1111_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 Execute(R1111_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 r1111_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1)
        {
            var ths = r1111_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1111_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1111_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.SUBGVGAP_COD_SUBGRUPO = result[i++].Value?.ToString();
            return dta;
        }

    }
}