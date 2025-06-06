using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0711S
{
    public class M_0900_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1 : QueryBasis<M_0900_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(DATA_MOVIMENTO, CURRENT_DATE),
            VALUE(COD_MOEDA_PRM, 17)
            INTO :SEGVGAPH-DATA-MOVIMENTO,
            :SEGVGAPH-COD-MOEDA-PRM
            FROM SEGUROS.SEGURADOSVGAP_HIST
            WHERE NUM_APOLICE = :WS-NUM-APOLICE
            AND NUM_ITEM = :SEGURVGA-NUM-ITEM
            AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(DATA_MOVIMENTO
							, CURRENT_DATE)
							,
											VALUE(COD_MOEDA_PRM
							, 17)
											FROM SEGUROS.SEGURADOSVGAP_HIST
											WHERE NUM_APOLICE = '{this.WS_NUM_APOLICE}'
											AND NUM_ITEM = '{this.SEGURVGA_NUM_ITEM}'
											AND OCORR_HISTORICO = '{this.SEGURVGA_OCORR_HISTORICO}'
											WITH UR";

            return query;
        }
        public string SEGVGAPH_DATA_MOVIMENTO { get; set; }
        public string SEGVGAPH_COD_MOEDA_PRM { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string WS_NUM_APOLICE { get; set; }

        public static M_0900_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1 Execute(M_0900_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1 m_0900_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1)
        {
            var ths = m_0900_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0900_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0900_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGVGAPH_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.SEGVGAPH_COD_MOEDA_PRM = result[i++].Value?.ToString();
            return dta;
        }

    }
}