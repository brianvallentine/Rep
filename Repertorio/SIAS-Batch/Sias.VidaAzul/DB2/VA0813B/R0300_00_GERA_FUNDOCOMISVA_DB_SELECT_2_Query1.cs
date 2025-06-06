using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0813B
{
    public class R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_2_Query1 : QueryBasis<R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PERI_FATURAMENTO,
            COD_FONTE,
            COD_CLIENTE
            INTO :VGPROSIA-NUM-PERIODO-PAG,
            :SUBGVGAP-COD-FONTE,
            :SUBGVGAP-COD-CLIENTE
            FROM SEGUROS.V0SUBGRUPO
            WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE
            AND COD_SUBGRUPO = :V0PROP-CODSUBES
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PERI_FATURAMENTO
							,
											COD_FONTE
							,
											COD_CLIENTE
											FROM SEGUROS.V0SUBGRUPO
											WHERE NUM_APOLICE = '{this.V0PROP_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.V0PROP_CODSUBES}'
											WITH UR";

            return query;
        }
        public string VGPROSIA_NUM_PERIODO_PAG { get; set; }
        public string SUBGVGAP_COD_FONTE { get; set; }
        public string SUBGVGAP_COD_CLIENTE { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }

        public static R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_2_Query1 Execute(R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_2_Query1 r0300_00_GERA_FUNDOCOMISVA_DB_SELECT_2_Query1)
        {
            var ths = r0300_00_GERA_FUNDOCOMISVA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_2_Query1();
            var i = 0;
            dta.VGPROSIA_NUM_PERIODO_PAG = result[i++].Value?.ToString();
            dta.SUBGVGAP_COD_FONTE = result[i++].Value?.ToString();
            dta.SUBGVGAP_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}