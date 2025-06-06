using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB132_ACESSA_VGPRODUTO_SIAS_DB_SELECT_1_Query1 : QueryBasis<DB132_ACESSA_VGPRODUTO_SIAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO,
            COD_PRODUTO_EMP
            INTO :VGPROSIA-COD-PRODUTO,
            :VGPROSIA-COD-PRODUTO-EMP
            FROM SEGUROS.VG_PRODUTO_SIAS
            WHERE NUM_APOLICE = :VGSOLFAT-NUM-APOLICE
            AND NUM_PERIODO_PAG = :SUBGVGAP-PERI-FATURAMENTO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
							,
											COD_PRODUTO_EMP
											FROM SEGUROS.VG_PRODUTO_SIAS
											WHERE NUM_APOLICE = '{this.VGSOLFAT_NUM_APOLICE}'
											AND NUM_PERIODO_PAG = '{this.SUBGVGAP_PERI_FATURAMENTO}'
											WITH UR";

            return query;
        }
        public string VGPROSIA_COD_PRODUTO { get; set; }
        public string VGPROSIA_COD_PRODUTO_EMP { get; set; }
        public string SUBGVGAP_PERI_FATURAMENTO { get; set; }
        public string VGSOLFAT_NUM_APOLICE { get; set; }

        public static DB132_ACESSA_VGPRODUTO_SIAS_DB_SELECT_1_Query1 Execute(DB132_ACESSA_VGPRODUTO_SIAS_DB_SELECT_1_Query1 dB132_ACESSA_VGPRODUTO_SIAS_DB_SELECT_1_Query1)
        {
            var ths = dB132_ACESSA_VGPRODUTO_SIAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB132_ACESSA_VGPRODUTO_SIAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB132_ACESSA_VGPRODUTO_SIAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.VGPROSIA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.VGPROSIA_COD_PRODUTO_EMP = result[i++].Value?.ToString();
            return dta;
        }

    }
}