using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0618B
{
    public class R0516_00_OBTER_DT_VIA_HIST_DB_SELECT_2_Query1 : QueryBasis<R0516_00_OBTER_DT_VIA_HIST_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORR_HISTORICO
            INTO :SEGVGAPH-OCORR-HISTORICO
            FROM SEGUROS.SEGURADOSVGAP_HIST
            WHERE NUM_APOLICE =
            :SEGVGAPH-NUM-APOLICE
            AND COD_SUBGRUPO =
            :SEGVGAPH-COD-SUBGRUPO
            AND NUM_ITEM =
            :SEGVGAPH-NUM-ITEM
            AND COD_OPERACAO =
            :SEGVGAPH-COD-OPERACAO
            AND DATA_OPERACAO =
            :SEGVGAPH-DATA-OPERACAO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT OCORR_HISTORICO
											FROM SEGUROS.SEGURADOSVGAP_HIST
											WHERE NUM_APOLICE =
											'{this.SEGVGAPH_NUM_APOLICE}'
											AND COD_SUBGRUPO =
											'{this.SEGVGAPH_COD_SUBGRUPO}'
											AND NUM_ITEM =
											'{this.SEGVGAPH_NUM_ITEM}'
											AND COD_OPERACAO =
											'{this.SEGVGAPH_COD_OPERACAO}'
											AND DATA_OPERACAO =
											'{this.SEGVGAPH_DATA_OPERACAO}'
											WITH UR";

            return query;
        }
        public string SEGVGAPH_OCORR_HISTORICO { get; set; }
        public string SEGVGAPH_DATA_OPERACAO { get; set; }
        public string SEGVGAPH_COD_SUBGRUPO { get; set; }
        public string SEGVGAPH_COD_OPERACAO { get; set; }
        public string SEGVGAPH_NUM_APOLICE { get; set; }
        public string SEGVGAPH_NUM_ITEM { get; set; }

        public static R0516_00_OBTER_DT_VIA_HIST_DB_SELECT_2_Query1 Execute(R0516_00_OBTER_DT_VIA_HIST_DB_SELECT_2_Query1 r0516_00_OBTER_DT_VIA_HIST_DB_SELECT_2_Query1)
        {
            var ths = r0516_00_OBTER_DT_VIA_HIST_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0516_00_OBTER_DT_VIA_HIST_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0516_00_OBTER_DT_VIA_HIST_DB_SELECT_2_Query1();
            var i = 0;
            dta.SEGVGAPH_OCORR_HISTORICO = result[i++].Value?.ToString();
            return dta;
        }

    }
}