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
    public class R0586_00_OBTER_DT_MOVTO_DB_SELECT_1_Query1 : QueryBasis<R0586_00_OBTER_DT_MOVTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOVIMENTO
            INTO :SEGVGAPH-DATA-MOVIMENTO
            FROM SEGUROS.SEGURADOSVGAP_HIST
            WHERE NUM_APOLICE =
            :SEGVGAPH-NUM-APOLICE
            AND NUM_ITEM =
            :SEGVGAPH-NUM-ITEM
            AND OCORR_HISTORICO =
            :SEGVGAPH-OCORR-HISTORICO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOVIMENTO
											FROM SEGUROS.SEGURADOSVGAP_HIST
											WHERE NUM_APOLICE =
											'{this.SEGVGAPH_NUM_APOLICE}'
											AND NUM_ITEM =
											'{this.SEGVGAPH_NUM_ITEM}'
											AND OCORR_HISTORICO =
											'{this.SEGVGAPH_OCORR_HISTORICO}'
											WITH UR";

            return query;
        }
        public string SEGVGAPH_DATA_MOVIMENTO { get; set; }
        public string SEGVGAPH_OCORR_HISTORICO { get; set; }
        public string SEGVGAPH_NUM_APOLICE { get; set; }
        public string SEGVGAPH_NUM_ITEM { get; set; }

        public static R0586_00_OBTER_DT_MOVTO_DB_SELECT_1_Query1 Execute(R0586_00_OBTER_DT_MOVTO_DB_SELECT_1_Query1 r0586_00_OBTER_DT_MOVTO_DB_SELECT_1_Query1)
        {
            var ths = r0586_00_OBTER_DT_MOVTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0586_00_OBTER_DT_MOVTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0586_00_OBTER_DT_MOVTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGVGAPH_DATA_MOVIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}