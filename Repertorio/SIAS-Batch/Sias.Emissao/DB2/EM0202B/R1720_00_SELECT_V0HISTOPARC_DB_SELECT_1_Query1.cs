using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0202B
{
    public class R1720_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1 : QueryBasis<R1720_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(PRM_TARIFARIO), 0),
            VALUE(SUM(VAL_DESCONTO), 0),
            VALUE(SUM(VLPRMLIQ), 0),
            VALUE(SUM(VLADIFRA), 0),
            VALUE(SUM(VLCUSEMI), 0),
            VALUE(SUM(VLIOCC), 0),
            VALUE(SUM(VLPRMTOT), 0)
            INTO :V0HIST-PRM-TARIF ,
            :V0HIST-DESCONTO ,
            :V0HIST-VLPRMLIQ ,
            :V0HIST-VLADIFRA ,
            :V0HIST-VLCUSEMI ,
            :V0HIST-VLIOCC ,
            :V0HIST-VLPRMTOT
            FROM SEGUROS.V1HISTOPARC
            WHERE NUM_APOLICE = :V1HIST-NUM-APOL
            AND NRENDOS = :V1HIST-NRENDOS
            AND NRPARCEL = :V1HIST-NRPARCEL
            AND OPERACAO = 0801
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(PRM_TARIFARIO)
							, 0)
							,
											VALUE(SUM(VAL_DESCONTO)
							, 0)
							,
											VALUE(SUM(VLPRMLIQ)
							, 0)
							,
											VALUE(SUM(VLADIFRA)
							, 0)
							,
											VALUE(SUM(VLCUSEMI)
							, 0)
							,
											VALUE(SUM(VLIOCC)
							, 0)
							,
											VALUE(SUM(VLPRMTOT)
							, 0)
											FROM SEGUROS.V1HISTOPARC
											WHERE NUM_APOLICE = '{this.V1HIST_NUM_APOL}'
											AND NRENDOS = '{this.V1HIST_NRENDOS}'
											AND NRPARCEL = '{this.V1HIST_NRPARCEL}'
											AND OPERACAO = 0801";

            return query;
        }
        public string V0HIST_PRM_TARIF { get; set; }
        public string V0HIST_DESCONTO { get; set; }
        public string V0HIST_VLPRMLIQ { get; set; }
        public string V0HIST_VLADIFRA { get; set; }
        public string V0HIST_VLCUSEMI { get; set; }
        public string V0HIST_VLIOCC { get; set; }
        public string V0HIST_VLPRMTOT { get; set; }
        public string V1HIST_NUM_APOL { get; set; }
        public string V1HIST_NRPARCEL { get; set; }
        public string V1HIST_NRENDOS { get; set; }

        public static R1720_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1 Execute(R1720_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1 r1720_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1)
        {
            var ths = r1720_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1720_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1720_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HIST_PRM_TARIF = result[i++].Value?.ToString();
            dta.V0HIST_DESCONTO = result[i++].Value?.ToString();
            dta.V0HIST_VLPRMLIQ = result[i++].Value?.ToString();
            dta.V0HIST_VLADIFRA = result[i++].Value?.ToString();
            dta.V0HIST_VLCUSEMI = result[i++].Value?.ToString();
            dta.V0HIST_VLIOCC = result[i++].Value?.ToString();
            dta.V0HIST_VLPRMTOT = result[i++].Value?.ToString();
            return dta;
        }

    }
}