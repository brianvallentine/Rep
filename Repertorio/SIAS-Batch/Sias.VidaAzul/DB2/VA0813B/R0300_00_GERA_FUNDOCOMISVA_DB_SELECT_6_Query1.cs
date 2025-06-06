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
    public class R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_6_Query1 : QueryBasis<R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_6_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PCCOMVEN
            INTO :PARAGEEM-PCCOMVEN
            FROM SEGUROS.PARM_AGENCI_EMP
            WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE
            AND PERI_PAGAMENTO = :VGPROSIA-NUM-PERIODO-PAG
            AND DATA_INIVIGENCIA <= :V0HCOB-DTVENCTO
            AND DATA_TERVIGENCIA >= :V0HCOB-DTVENCTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCCOMVEN
											FROM SEGUROS.PARM_AGENCI_EMP
											WHERE NUM_APOLICE = '{this.V0PROP_NUM_APOLICE}'
											AND PERI_PAGAMENTO = '{this.VGPROSIA_NUM_PERIODO_PAG}'
											AND DATA_INIVIGENCIA <= '{this.V0HCOB_DTVENCTO}'
											AND DATA_TERVIGENCIA >= '{this.V0HCOB_DTVENCTO}'
											WITH UR";

            return query;
        }
        public string PARAGEEM_PCCOMVEN { get; set; }
        public string VGPROSIA_NUM_PERIODO_PAG { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0HCOB_DTVENCTO { get; set; }

        public static R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_6_Query1 Execute(R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_6_Query1 r0300_00_GERA_FUNDOCOMISVA_DB_SELECT_6_Query1)
        {
            var ths = r0300_00_GERA_FUNDOCOMISVA_DB_SELECT_6_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_6_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_6_Query1();
            var i = 0;
            dta.PARAGEEM_PCCOMVEN = result[i++].Value?.ToString();
            return dta;
        }

    }
}