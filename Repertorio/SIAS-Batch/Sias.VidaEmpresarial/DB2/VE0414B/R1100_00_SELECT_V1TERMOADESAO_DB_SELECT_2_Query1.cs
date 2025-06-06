using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0414B
{
    public class R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1 : QueryBasis<R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_PRODUTO_EMP,
            A.COD_PRODUTO,
            B.COD_EMPRESA
            INTO :VGPROSIA-COD-PRODUTO-EMP,
            :VGPROSIA-COD-PRODUTO,
            :PRODUTO-COD-EMPRESA
            FROM
            SEGUROS.VG_PRODUTO_SIAS A
            ,SEGUROS.PRODUTO B
            WHERE
            A.NUM_APOLICE = :VGPROSIA-NUM-APOLICE
            AND A.NUM_PERIODO_PAG = :VGPROSIA-NUM-PERIODO-PAG
            AND B.COD_PRODUTO = A.COD_PRODUTO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT A.COD_PRODUTO_EMP
							,
											A.COD_PRODUTO
							,
											B.COD_EMPRESA
											FROM
											SEGUROS.VG_PRODUTO_SIAS A
											,SEGUROS.PRODUTO B
											WHERE
											A.NUM_APOLICE = '{this.VGPROSIA_NUM_APOLICE}'
											AND A.NUM_PERIODO_PAG = '{this.VGPROSIA_NUM_PERIODO_PAG}'
											AND B.COD_PRODUTO = A.COD_PRODUTO";

            return query;
        }
        public string VGPROSIA_COD_PRODUTO_EMP { get; set; }
        public string VGPROSIA_COD_PRODUTO { get; set; }
        public string PRODUTO_COD_EMPRESA { get; set; }
        public string VGPROSIA_NUM_PERIODO_PAG { get; set; }
        public string VGPROSIA_NUM_APOLICE { get; set; }

        public static R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1 Execute(R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1 r1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1)
        {
            var ths = r1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_V1TERMOADESAO_DB_SELECT_2_Query1();
            var i = 0;
            dta.VGPROSIA_COD_PRODUTO_EMP = result[i++].Value?.ToString();
            dta.VGPROSIA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUTO_COD_EMPRESA = result[i++].Value?.ToString();
            return dta;
        }

    }
}